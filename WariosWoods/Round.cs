namespace WariosWoodsEditor.WariosWoods;

internal class Round {
	public int RoundNumber { get; }

	public Round(int roundNumber) {
		RoundNumber = roundNumber;
	}

	private void LevelABox_ValueChanged(object sender, EventArgs e) {

	}

	public byte LevelA { get; set; }
	public byte LevelB { get; set; }



	public MonsterType MonsterTypesGRWP { get; set; } = MonsterType.Moo;

	public MonsterType MonsterTypesBYKT { get; set; } = MonsterType.Moo;

	public byte Speed { get; set; }

	public byte Map { get; set; }

	public byte Aggro { get; set; }

	public byte Gold { get; set; }


	public byte[] GetGameData() {
		return new byte[] {
			LevelA,
			LevelB,
			(byte) ((MonsterTypesGRWP.Value << 4) | MonsterTypesBYKT.Value),
			Speed,
			Map,
			Aggro,
			Gold,
		};
	}
}
