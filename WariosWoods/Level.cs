namespace WariosWoodsEditor.WariosWoods;

internal class Level {

	public int LevelNumber { get; init; }

	public GameObject[,] Board { get; } = new GameObject[11, 7];

	public GameObject this[int r, int c] {
		get => Board[r, c];
		set => Board[r, c] = value;
	}

	public Level(int number) {
		LevelNumber = number;
		for (int r = 0; r < 11; r++) {
			for (int c = 0; c < 7; c++) {
				Board[r,c] = new GameObject() {
					Row = r,
					Column = c,
				};
			}
		}
	}

	public byte CountRows() {
		byte count = 11;
		for (int row = 0; row < 11; row++, count--) {
			for (int col = 0; col < 7; col++) {
				if (Board[row,col].EntityType is not ObjectType.Nothing) {
					return count;
				}
			}
		}

		return 1;
	}


	public byte[] GetGameData() {
		var rows = CountRows();

		var ret = new byte[1 + (rows * 7)];

		ret[0] = rows;

		int i = 1;

		for (int r = 0, rr = 11 - rows; r < rows; r++, rr++) {
			for (int c = 0; c < 7; c++) {
				ret[i++] = Board[rr, c].GetDataByte();
			}
		}

		return ret;
	}

	public void ForAllObjects(Action<GameObject> func) {
		for (int r = 10; r >= 0; r--) {
			for (int c = 0; c < 7; c++) {
				var obj = Board[r, c];

				obj.Row = r;
				obj.Column = c;

				func(obj);
			}
		}
	}

}
