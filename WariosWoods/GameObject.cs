namespace WariosWoodsEditor.WariosWoods;

internal class GameObject {
	public ObjectType EntityType { get; set; } = ObjectType.Nothing;

	public ObjectColor Color { get; set; } = ObjectColor.Green;

	public int Row { get; set; }
	public int Column { get; set; }

	public override string ToString() => EntityType switch {
		ObjectType.Nothing => "Empty",
		ObjectType.Breakfast => "Random Breakfast",
		_ => $"{Color.Name} {EntityType}"
	};

	public byte GetDataByte() => EntityType switch {
		ObjectType.Nothing => 0x00,
		ObjectType.Breakfast => 0x01,
		_ => (byte) ((byte) EntityType | Color.Value),
	};
}
