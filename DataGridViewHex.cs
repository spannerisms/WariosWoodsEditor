using System.ComponentModel;

namespace WariosWoodsEditor;
internal class DataGridViewHexColumn : DataGridViewColumn {
	public DataGridViewHexColumn() {
		CellTemplate = new DataGridViewHexCell();
	}
}

internal class DataGridViewHexCell : DataGridViewTextBoxCell {

	public DataGridViewHexCell() {
		this.MaxInputLength = 2;
		Style = new() {
			Alignment = DataGridViewContentAlignment.MiddleRight,
			Format = "X2",
			Font = new Font("Consolas", 9.0f),
		};
	}

	public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter) {
		if (formattedValue is string s) {
			bool works = int.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out int ret);
			if (works) {
				return ret;
			}
		}

		return 0;
	}
}