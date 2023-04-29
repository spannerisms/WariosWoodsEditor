namespace WariosWoodsEditor;

#nullable disable
internal partial class WoodsROM {
	public const int VanillaSize = 0x10_0000;

	public const int RoundData = 0x85F391;
	public const int RoundDataPointers = 0x85F28F;

	public static readonly Range LevelDataA = new(0x858200, 0x85C7FD);
	public static readonly Range LevelDataB = new(0x85D181, 0x85D277);
	public static readonly Range LevelDataC = new(0x85CC31, 0x85D171);
	public static readonly Range LevelDataD = new(0x85DCFF, 0x85F000);
	public static readonly Range LevelDataE = new(0x85FAAA, 0x85FFFF);

	private record LevelSet(string Name, int PointersAddress, int Count) {
		public Level[] Levels { get; } = new Level[Count];
	}


	public const int NumberOfRounds = 129;

	public const int RNGTable = 0x83B138;

	public const int HackedMetaData = 0x80F800;

	public const ushort HackedMarker = 0xBEBE;
	public const int HackedFlag = HackedMetaData + 0;

	public const int CreditsTextAddress = 0x83D500;

	public byte[] Stream { get; } = new byte[VanillaSize];

	private readonly LevelSet RoundGameLevels = new(MainForm.RoundName, 0x858000, 256);
	private readonly LevelSet MoreLevelsA = new(MainForm.RoundName, 0x85CBDD, 42);
	private readonly LevelSet MoreLevelsB = new(MainForm.RoundName, 0x85D171, 8);
	private readonly LevelSet MoreLevelsC = new(MainForm.RoundName, 0x85C93D, 336);
	private readonly LevelSet MoreLevelsD = new(MainForm.RoundName, 0x85C7FD, 160);

	public Round[] AllRounds { get; } = new Round[NumberOfRounds];

	public Level[] AllRoundLevels => RoundGameLevels.Levels;

	public string Path { get; init; }

	public StringWrap[] CreditsLines { get; } = new StringWrap[9];

	public WoodsROM(byte[] s) {
		Array.Copy(s, Stream, s.Length);

		bool vanilla = Read16(HackedFlag) is not HackedMarker;

		for (int i = 0; i < NumberOfRounds; i++) {
			int rl = RoundData + i * 7;

			var (m1, m2) = MonsterType.FindTypesFromByte(this[rl + 2]);

			AllRounds[i] = new Round(i + 1) {
				LevelA = this[rl + 0],
				LevelB = this[rl + 1],
				Speed = this[rl + 3],
				MonsterTypesGRWP = m1,
				MonsterTypesBYKT = m2,
				Map = this[rl + 4],
				Aggro = this[rl + 5],
				Gold = this[rl + 6],
			};
		}

		// read every level
		ReadLevelSet(RoundGameLevels);
//		ReadLevelSet(MoreLevelsA);
//		ReadLevelSet(MoreLevelsB);
//		ReadLevelSet(MoreLevelsC);
//		ReadLevelSet(MoreLevelsD);


		for (int i = 0; i < 9; i++) {
			var line = new char[22];
			for (int a = CreditsTextAddress + (i * 23), j = 0; j < 22; a++, j++) {
				line[j] = (char) this[a];
			}
			CreditsLines[i] = new(new(line));
		}

		void ReadLevelSet(LevelSet levels) {
			int count = levels.Count;
			if (vanilla && levels == RoundGameLevels) {
				count = 252;
			}

			int lc = 0;
			int ptrtable = levels.PointersAddress;
			for (; lc < count; lc++) {
				var ret = levels.Levels[lc] = new(lc);
				int pointer = Read16(ptrtable) | 0x850000;
				ptrtable += 2;
				int rows = this[pointer++];

				for (int lrow = 11 - rows; rows > 0; rows--, lrow++) {
					for (int lcol = 0; lcol < 7; lcol++) {
						byte m = this[pointer++];
						ret[lrow, lcol] = new() {
							EntityType = GetTypeFromByte(m),
							Color = ObjectColor.GetColorFromByte(m)
						};
					}
				}
			}

			
			for (; lc < levels.Count; lc++) {
				levels.Levels[lc] = new(lc);
			}
		}

	}

	private static ObjectType GetTypeFromByte(byte b) {
		if (b is 0x01) {
			return ObjectType.Breakfast;
		}

		return (b & 0xF0) switch {
			0x10 => ObjectType.Bomb,
			0x50 => ObjectType.Diamond,
			0x90 => ObjectType.Monster,
			0xF0 => ObjectType.Fancy,
			_ => ObjectType.Nothing
		};
	}

	public const string LegalCreditsCharacters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz -.!?'\"/";
	public void CleanUpText() {
		for (int i = 0; i < CreditsLines.Length; i++) {
			var lineNew = CreditsLines[i].Contents?.TrimEnd() ?? "";
			lineNew = new(lineNew.Where(o => LegalCreditsCharacters.Contains(o)).ToArray());
			lineNew += "                      ";
			lineNew = lineNew[0..22];
			CreditsLines[i] = new(lineNew);
		}
	}

	public void MakeFinalNecessaryPatches() {
		CleanUpText();
		// write credits text
		byte num = 0x81;
		int writeAt = CreditsTextAddress;
		foreach (var line in CreditsLines) {
			foreach (var c in line.Contents) {
				this[writeAt++] = (byte) c;
			}
			this[writeAt++] = num switch {
				0x89 => 0x00,
				_ => num,
			};
			num++;
		}





		// mark as a hack
		Write16(HackedFlag, HackedMarker);


		// calculate checksum - do last
		Stream[0x7FDC] = 0xFF;
		Stream[0x7FDD] = 0xFF;
		Stream[0x7FDE] = 0x00;
		Stream[0x7FDF] = 0x00;

		ushort cksm = 0x0000;
		foreach (var b in Stream) {
			cksm += b;
		}

		Write16(0x00FFDE, cksm);
		cksm ^= 0xFFFF;
		Write16(0x00FFDC, cksm);
	}

	public bool Save() {
		var backup = Stream[..];

		try {
			SaveEveryLevel();
			SaveEveryRound();
			MakeFinalNecessaryPatches();
		} catch (WoodsException e) {
			Array.Copy(backup, Stream, Stream.Length);
			throw e;
		}

		return true;
	}

	private void SaveEveryRound() {

		int writeAddr = RoundData;

		foreach (var r in AllRounds) {
			Write8Continuous(ref writeAddr, r.GetGameData());
		}

	}

	private void SaveEveryLevel() {
		int cur, curend;
		int curblock = 0;

		Range[] datablocks = {
			LevelDataA,
			LevelDataB,
			LevelDataC,
			LevelDataD,
		};

		NextBlock();

		WriteLevelSet(RoundGameLevels);
//		WriteLevelSet(MoreLevelsA);
//		WriteLevelSet(MoreLevelsB);
//		WriteLevelSet(MoreLevelsC);
//		WriteLevelSet(MoreLevelsD);
		
		void WriteLevelSet(LevelSet levels) {
			int pointerAddr = levels.PointersAddress;
			foreach (var l in levels.Levels) {
				if (l is null) continue;

				var levelData = l.GetGameData();

				if ((cur + levelData.Length) >= curend) {
					NextBlock();
				}

				Write16iContinuous(ref pointerAddr, cur & 0xFFFF);

				Write8Continuous(ref cur, levelData);
			}
		}



		void NextBlock() {
			if (curblock >= datablocks.Length) {
				throw new WoodsException("Too much level data.");
			}
			var r = datablocks[curblock++];
			cur = r.Start.Value;
			curend = r.End.Value;
		}
	}


	public int Length => Stream.Length;

	/// <summary>
	/// Read or write a single byte at SNES lorom address <paramref name="a"/>.
	/// </summary>
	public byte this[int a] {
		get => Stream[SNESToPC(a)];
		set => Stream[SNESToPC(a)] = value;
	}

	/*================================================================================================*\
	 * ACCESS ROUTINES
	\*================================================================================================*/

	public void Write8(int address, params byte[] bytes) {
		int addr = SNESToPC(address);
		foreach (byte b in bytes) {
			Stream[addr++] = b;
		}
	}

	public void Write8Continuous(ref int address, params byte[] bytes) {
		int addr = SNESToPC(address);
		foreach (byte b in bytes) {
			Stream[addr++] = b;
		}
		address += bytes.Length;
	}

	public byte[] Read8(int address, int count) {
		int addr = SNESToPC(address);

		return Stream[addr..(addr + count)];
	}

	public void Write16(int address, params ushort[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
	}

	public void Write16Continuous(ref int address, params ushort[] words) {
		int a = SNESToPC(address);
		foreach (var s in words) {
			Stream[a++] = (byte) s;
			Stream[a++] = (byte) (s >> 8);
		}
		address += 2 * words.Length;
	}

	public void Write16i(int address, params int[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
	}

	public void Write16iContinuous(ref int address, params int[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
		address += 2 * words.Length;
	}

	public ushort Read16(int address) {
		int a = SNESToPC(address);
		return (ushort) (Stream[a] | (Stream[a + 1] << 8));
	}

	public ushort[] Read16(int address, int count) {
		ushort[] ret = new ushort[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 2, i++) {
			ret[i] = (ushort) (Stream[a] | (Stream[a + 1] << 8));
		}
		return ret;
	}

	public void Write24(int address, params int[] longs) {
		int addr = SNESToPC(address);
		foreach (int s in longs) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
			Stream[addr++] = (byte) (s >> 16);
		}
	}

	public int[] Read24(int address, int count) {
		int[] ret = new int[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 3, i++) {
			ret[i] = Stream[a] | (Stream[a + 1] << 8) | (Stream[a + 2] << 16);
		}
		return ret;
	}

	public void Write32(int address, params uint[] dlongs) {
		int addr = SNESToPC(address);
		foreach (uint s in dlongs) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
			Stream[addr++] = (byte) (s >> 16);
			Stream[addr++] = (byte) (s >> 24);
		}
	}

	public uint[] Read32(int address, int count) {
		uint[] ret = new uint[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 4, i++) {
			ret[i] = (uint) (Stream[a] | (Stream[a + 1] << 8) |
				(Stream[a + 2] << 16) | (Stream[a + 2] << 24));
		}
		return ret;
	}

	private static int SNESToPC(int a) {
		if ((a & 0xFFFF) < 0x8000) {
			throw new ArgumentOutOfRangeException(nameof(a), "Illegal ROM write");
		}

		return a & 0x7FFF | (a & 0x7F0000) >> 1;
	}

	//public ROMWriter CreatePatch(byte[] bps) => BPSPatcher.ApplyPatch(Stream, bps);
}
