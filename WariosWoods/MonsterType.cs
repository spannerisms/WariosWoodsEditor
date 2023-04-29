namespace WariosWoodsEditor.WariosWoods;
public class MonsterType {

	public string Name { get; }
	public byte Value { get; }
	public Bitmap Icon { get; }

	private MonsterType(string name, byte value, Bitmap icon) {
		Name = name;
		Value = value;
		Icon = icon;
	}

	public static ImmutableArray<MonsterType> ListOf { get; }

	static MonsterType() {
		ListOf = PredefinitionFunctions.GetListOfPredefinedFields<MonsterType>(typeof(MonsterType));
	}

	public override string ToString() => Name;

	public static (MonsterType h, MonsterType l) FindTypesFromByte(byte b) {
		return (FindOne((byte) (b >> 4)), FindOne((byte) (b & 0xF)));


		static MonsterType FindOne(byte bb) => ListOf.FirstOrDefault(o => o.Value == bb, Moo);
	}


	[PredefinedItem]
	public static readonly MonsterType Moo = new(name: nameof(Moo), value: 0, icon: Resource1.icon_moo);

	[PredefinedItem]
	public static readonly MonsterType Blob = new(name: nameof(Blob), value: 1, icon: Resource1.icon_blob);

	[PredefinedItem]
	public static readonly MonsterType Rabbit = new(name: nameof(Rabbit), value: 2, icon: Resource1.icon_rabbit);

	[PredefinedItem]
	public static readonly MonsterType Robot = new(name: nameof(Robot), value: 3, icon: Resource1.icon_robot);

	[PredefinedItem]
	public static readonly MonsterType Ballerina = new(name: nameof(Ballerina), value: 4, icon: Resource1.icon_ballerina);

	[PredefinedItem]
	public static readonly MonsterType Twintails = new(name: nameof(Twintails), value: 5, icon: Resource1.icon_twintails);

	[PredefinedItem]
	public static readonly MonsterType Mushroom = new(name: nameof(Mushroom), value: 6, icon: Resource1.icon_mushroom);
}
