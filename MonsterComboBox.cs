namespace WariosWoodsEditor;

#nullable disable

internal class GridMonsterComboBox : DataGridViewComboBoxEditingControl {
	public GridMonsterComboBox() {
		DrawMode = DrawMode.OwnerDrawFixed;
		DropDownStyle = ComboBoxStyle.DropDownList;
		DataSource = MonsterType.ListOf;
	}




	protected override void OnDrawItem(DrawItemEventArgs e) {
		e.DrawBackground();
		e.DrawFocusRectangle();

		if (Items[e.Index] is MonsterType m) {
			e.Graphics.DrawImage(m.Icon, e.Bounds.Left, e.Bounds.Top);
		}

		//base.OnDrawItem(e);
	}
}

internal class MonsterComboBox : ComboBox {
	public MonsterComboBox() {
		DrawMode = DrawMode.OwnerDrawFixed;
		DropDownStyle = ComboBoxStyle.DropDownList;
		DataSource = MonsterType.ListOf;
	}




	protected override void OnDrawItem(DrawItemEventArgs e) {
		e.DrawBackground();
		e.DrawFocusRectangle();

		if (Items[e.Index] is MonsterType m) {
			e.Graphics.DrawImage(m.Icon, e.Bounds.Left, e.Bounds.Top);
			e.Graphics.DrawString(m.Name, Font, new SolidBrush(ForeColor), e.Bounds.Left + 18, e.Bounds.Top);
		}

		//base.OnDrawItem(e);
	}
}
