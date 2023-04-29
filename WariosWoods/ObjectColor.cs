namespace WariosWoodsEditor.WariosWoods;

internal class ObjectColor {
	public string Name { get; }
	public char Token { get; }
	public byte Value { get; }
	public Color MainColor { get; }

	private ObjectColor(string name, char token, byte value, int hexcol) {
		Name = name;
		Token = token;
		Value = value;
		MainColor = Color.FromArgb((int) (hexcol | 0xFF000000));
	}

	public static ImmutableArray<ObjectColor> ListOf { get; }

	static ObjectColor() {
		ListOf = PredefinitionFunctions.GetListOfPredefinedFields<ObjectColor>(typeof(ObjectColor));
	}


	public static ObjectColor GetColorFromByte(byte b) {
		b &= 0x07;
		return ListOf.FirstOrDefault(o => o.Value == b, Green);
	}

	public override string ToString() => Name;

	[PredefinedItem]
	public static readonly ObjectColor Green = new(name: nameof(Green), token: 'G', value: 0, hexcol: 0x42CE00);

	[PredefinedItem]
	public static readonly ObjectColor Red = new(name: nameof(Red), token: 'R', value: 1, hexcol: 0xFF3129);

	[PredefinedItem]
	public static readonly ObjectColor White = new(name: nameof(White), token: 'W', value: 2, hexcol: 0xF0F0F0);

	[PredefinedItem]
	public static readonly ObjectColor Pink = new(name: nameof(Pink), token: 'P', value: 3, hexcol: 0xFF84FF);

	[PredefinedItem]
	public static readonly ObjectColor Blue = new(name: nameof(Blue), token: 'B', value: 4, hexcol: 0x0084FF);

	[PredefinedItem]
	public static readonly ObjectColor Yellow = new(name: nameof(Yellow), token: 'Y', value: 5, hexcol: 0xF0F020);

	[PredefinedItem]
	public static readonly ObjectColor Gray = new(name: nameof(Gray), token: 'K', value: 6, hexcol: 0x848484);

	[PredefinedItem]
	public static readonly ObjectColor Turquoise = new(name: nameof(Turquoise), token: 'T', value: 7, hexcol: 0x42D6F8);

}
