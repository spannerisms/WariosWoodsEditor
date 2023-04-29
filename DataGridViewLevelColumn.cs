namespace WariosWoodsEditor;

#nullable disable
internal class DataGridViewLevelColumn : DataGridViewColumn {
	public DataGridViewLevelColumn() : base(new DataGridViewLevelCell()) {

	}
}

internal class DataGridViewLevelCell : DataGridViewHexCell {
	public DataGridViewLevelCell() : base() {
		Style.Format = "X2";
	}
}