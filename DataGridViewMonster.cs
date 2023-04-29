using System.ComponentModel;

namespace WariosWoodsEditor;

internal class DataGridViewMonsterColumn : DataGridViewComboBoxColumn {
	public DataGridViewMonsterColumn() {
		CellTemplate = new DataGridViewMonsterCell();
		DataSource = MonsterType.ListOf;
		Width = 48;
	}
}

internal class DataGridViewMonsterCell : DataGridViewComboBoxCell {

	public override Type EditType => typeof(GridMonsterComboBox);
	public override Type ValueType => typeof(MonsterType);

	public override Type FormattedValueType => typeof(MonsterType);

	public override object DefaultNewRowValue => MonsterType.Moo;

	public DataGridViewMonsterCell() {
		DataSource = MonsterType.ListOf;
	}

	public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter) {
		if (formattedValue is string s) {
			return MonsterType.ListOf.FirstOrDefault(o => o.Name == s, MonsterType.Moo);
		}
		
		
		return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
	}

	protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
		//base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
		graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), cellBounds);
		PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
		var mon = (formattedValue as MonsterType) ?? MonsterType.Moo;
		graphics.DrawImage(mon.Icon, cellBounds.Left + 4, cellBounds.Top + 4);
	}
}