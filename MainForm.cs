namespace WariosWoodsEditor;

public record StringWrap(string Contents);

public partial class MainForm : Form {
	public const string RoundName = "Round Game";


	internal WoodsROM? ROM { get; set; }

	private Level? selectedLevel = null;



	public MainForm() {
		InitializeComponent();

		Icon = Resource1.hat;
		tabControl1.Enabled = false;

		InitializeRoundView();

		InitializeColorButtons();
		InitializePlacementButtons();
		InitializeEditModeButtons();

		LevelPanel.Image = LevelPreviewBig;
		LevelPanel.Size = LevelPreviewBig.Size;

		LevelPanel.MouseWheel += LevelPanel_MouseWheel;

		CreditsTextGrid.Columns.Add(new DataGridViewTextBoxColumn() {
			DataPropertyName = nameof(StringWrap.Contents),
			Width = 400,
			MaxInputLength = 22,
		});
	}

	private void LevelPanel_MouseWheel(object? sender, MouseEventArgs e) {
		if (ModifierKeys is Keys.Control) {
			SelectNextRadioButton(ColorGroupBox, -Math.Sign(e.Delta));
		} else if (ModifierKeys is Keys.Shift) {
			SelectNextRadioButton(TypeGroupBox, -Math.Sign(e.Delta));
		}
	}

	private static readonly DataGridViewCellStyle numberStyle = new() {
		Alignment = DataGridViewContentAlignment.MiddleRight,
	};

	private ObjectColor selectedColor = ObjectColor.Green;
	private ObjectType selectedType = ObjectType.Nothing;


	private static void SelectNextRadioButton(Control group, int direction) {
		int count = 0;
		int selected = -1;

		foreach (var cn in group.Controls) {
			if (cn is RadioButton r) {
				count++;
				if (r.Checked) {
					selected = r.TabIndex;
				}
			}
		}

		selected += direction;
		selected += count;
		selected %= count;

		foreach (var c in group.Controls) {
			if (c is RadioButton r && r.TabIndex == selected) {
				r.Checked = true;
				return;
			}
		}
	}

	private void InitializeColorButtons() {
		int i = 0;

		SetButtonUp(RadioButtonG, ObjectColor.Green);
		SetButtonUp(RadioButtonR, ObjectColor.Red);
		SetButtonUp(RadioButtonW, ObjectColor.White);
		SetButtonUp(RadioButtonP, ObjectColor.Pink);

		SetButtonUp(RadioButtonB, ObjectColor.Blue);
		SetButtonUp(RadioButtonY, ObjectColor.Yellow);
		SetButtonUp(RadioButtonK, ObjectColor.Gray);
		SetButtonUp(RadioButtonT, ObjectColor.Turquoise);

		RadioButtonG.Checked = true;

		void SetButtonUp(RadioButton butt, ObjectColor color) {
			butt.Tag = color;
			butt.TabIndex = i++;
			butt.TabStop = false;
			butt.BackColor = color.MainColor;
			butt.Padding = butt.Padding with { Left = 9 };
			butt.CheckedChanged += new EventHandler(ColorCheckChanged);
		}
	}

	private void InitializePlacementButtons() {
		int i = 0;

		SetButtonUp(ActionButtonMonster, ObjectType.Monster);
		SetButtonUp(ActionButtonBomb, ObjectType.Bomb);
		SetButtonUp(ActionButtonDiamond, ObjectType.Diamond);
		SetButtonUp(ActionButtonBreakfast, ObjectType.Breakfast);
		SetButtonUp(ActionButtonFancy, ObjectType.Fancy);

		ActionButtonMonster.Checked = true;

		void SetButtonUp(RadioButton butt, ObjectType objectType) {
			butt.Tag = objectType;
			butt.TabIndex = i++;
			butt.TabStop = false;
			butt.CheckedChanged += new EventHandler(TypeCheckChanged);
		}
	}
	private void InitializeEditModeButtons() {
		int i = 0;

		SetButtonUp(ModeButtonType, EditMode.SetType);
		SetButtonUp(ModeButtonColor, EditMode.SetColor);
		SetButtonUp(ModeButtonBoth, EditMode.SetBoth);

		ModeButtonBoth.Checked = true;

		void SetButtonUp(RadioButton butt, EditMode editMode) {
			butt.Tag = editMode;
			butt.TabIndex = i++;
			butt.TabStop = false;
			butt.CheckedChanged += new EventHandler(ModeCheckChanged);
		}
	}



	private void ColorCheckChanged(object? sender, EventArgs e) {
		if (sender is not RadioButton rb) return;
		if (rb.Tag is not ObjectColor col) return;
		selectedColor = col;
		ColorGroupBox.BackColor = Color.FromArgb(col.MainColor.ToArgb() & 0x7FFFFFFF);
	}

	private void TypeCheckChanged(object? sender, EventArgs e) {
		if (sender is not RadioButton rb) return;
		if (rb.Tag is not ObjectType t) return;
		selectedType = t;

		InfoLabel.Text = t switch {
			ObjectType.Breakfast => "Breakfast is always a random color.\r\nPlacing breakfast on multiple rows\r\nwill cause a crash.",
			ObjectType.Fancy => "Fancy monsters are are\r\nimmune to diamonds,\r\nact weird, and die with a\r\nfancy explosion.",
			_ => "",
		};

	}

	private void ModeCheckChanged(object? sender, EventArgs e) {
		if (sender is not RadioButton rb) return;
		if (rb.Tag is not EditMode t) return;
		currentEditMode = t;
	}

	private void InitializeRoundView() {
		RoundView.AutoGenerateColumns = false;

		RoundView.AlternatingRowsDefaultCellStyle = new() {
			BackColor = Color.PaleTurquoise,
		};

		RoundView.Columns.Add(new DataGridViewTextBoxColumn() {
			DataPropertyName = nameof(Round.RoundNumber),
			HeaderText = "R#",
			Width = 35,
			DefaultCellStyle = new() {
				Alignment = DataGridViewContentAlignment.MiddleRight,
			}
		});

		RoundView.Columns.Add(new DataGridViewLevelColumn() {
			DataPropertyName = nameof(Round.LevelA),
			HeaderText = "A",
			Width = 50,
		});

		RoundView.Columns.Add(new DataGridViewLevelColumn() {
			DataPropertyName = nameof(Round.LevelB),
			HeaderText = "B",
			Width = 50,
		});

		RoundView.Columns.Add(new DataGridViewMonsterColumn() {
			DataPropertyName = nameof(Round.MonsterTypesGRWP),
			HeaderText = "GRWP",
		});

		RoundView.Columns.Add(new DataGridViewMonsterColumn() {
			DataPropertyName = nameof(Round.MonsterTypesBYKT),
			HeaderText = "BYKT",
		});

		RoundView.Columns.Add(new DataGridViewHexColumn() {
			DataPropertyName = nameof(Round.Speed),
			HeaderText = "Speed",
			Width = 50,
		});

		RoundView.Columns.Add(new DataGridViewHexColumn() {
			DataPropertyName = nameof(Round.Aggro),
			HeaderText = "Aggro",
			Width = 50,
		});

		RoundView.Columns.Add(new DataGridViewTextBoxColumn() {
			DataPropertyName = nameof(Round.Gold),
			HeaderText = "Gold",
			Width = 50,
			DefaultCellStyle = numberStyle,
		});

		RoundView.Columns.Add(new DataGridViewHexColumn() {
			DataPropertyName = nameof(Round.Map),
			HeaderText = "Map",
			Width = 50,
		});

	}

	private readonly OpenFileDialog openROM = new() {
		Multiselect = false,
		Filter = "SNES ROM files (*.sfc)|*.sfc",
		CheckFileExists = true,
		CheckPathExists = true,
		DereferenceLinks = true,
		ValidateNames = true,
		Title = "Open",
		ShowHelp = false,
	};



	private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
		if (openROM.ShowDialog() is DialogResult.OK) {
			string path = openROM.FileName;
			using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);

			int length = (int) fs.Length;
			var g = new byte[length];

			fs.Read(g, 0, length);

			SetROM(new WoodsROM(g) { Path = path });
		}
	}

	private void SetROM(WoodsROM rom) {
		ROM = rom;

		if (ROM is null) {
			tabControl1.Enabled = false;
			return;
		}

		tabControl1.Enabled = true;

		CreditsTextGrid.DataSource = ROM.CreditsLines;

		RoundView.DataSource = ROM.AllRounds;

		LevelSelectTree.Nodes.Clear();
		var rlevels = LevelSelectTree.Nodes.Add(RoundName);

		rlevels.Nodes.Clear();
		foreach (var l in ROM.AllRoundLevels) {
			if (l is null) continue;

			rlevels.Nodes.Add(new TreeNode() {
				Text = $"{l.LevelNumber:X2}",
				Tag = l,
			});
		}
	}


	private void SaveROM() {
		if (ROM is null) return;

		if (RerandomizeBox.Checked) {
			var crng = new byte[256];
			new Random().NextBytes(crng);
			ROM.Write8(WoodsROM.RNGTable, crng);
		}

		ROM.Save();
	}

	private void UpdateSelectedLevel(Level? level) {
		selectedLevel = level;

		string s = level is null ? "--" : $"{level.LevelNumber:X2}";

		LevelEditLabel.Text = $"Editing level: {s}";

		RefreshBoard();
	}

	// =====================================================

	public MonsterType PreviewTypeGRWP { get; set; } = MonsterType.Blob;
	public MonsterType PreviewTypeBYKT { get; set; } = MonsterType.Blob;

	const int PreviewScale = 3;
	const int PreviewSize = 16 * PreviewScale;

	const int BoardSizeX = 16 * 7;
	const int BoardSizeY = 16 * 11;

	private Bitmap LevelPreview { get; } = new Bitmap(BoardSizeX, BoardSizeY * PreviewScale);
	private Bitmap LevelPreviewBig { get; } = new Bitmap(BoardSizeX * PreviewScale, BoardSizeY * PreviewScale);

	private static readonly Rectangle PanelSourceRect = new(0, 0, BoardSizeX, BoardSizeY);
	private static readonly Rectangle PanelDestinationRect = new(1, 1, BoardSizeX * PreviewScale, BoardSizeY * PreviewScale);

	
	private static readonly SolidBrush HoverBrush = new (Color.FromArgb(100, Color.Black));
	private static readonly Pen HoverPen = new (Color.Black, 2);
	private void LevelPanel_Paint(object sender, PaintEventArgs e) {
		var g = e.Graphics;

		if (selectedLevel is null) return;
		
		if (onBoard) {
			g.DrawRectangle(HoverPen, boardX * PreviewSize, boardY * PreviewSize, PreviewSize, PreviewSize);
			g.FillRectangle(HoverBrush, boardX * PreviewSize, boardY * PreviewSize, PreviewSize, PreviewSize);
		}
	}

	private Rectangle GetSourceRectangle(ObjectType type, ObjectColor color) {
		int coloff = color.Value * 16;
		int rowoff;

		switch (type) {
			default:
			case ObjectType.Nothing:
				coloff = 32;
				rowoff = 10 * 16;
				break;

			case ObjectType.Breakfast:
				rowoff = 10 * 16;
				coloff = 0;
				break;

			case ObjectType.Bomb:
				rowoff = 7 * 16;
				break;

			case ObjectType.Diamond:
				rowoff = 8 * 16;
				break;

			case ObjectType.Monster:
			case ObjectType.Fancy:
				var ptype = color.Value < 4 ? PreviewTypeGRWP : PreviewTypeBYKT;
				rowoff = ptype.Value * 16;
				break;
		}


		return new Rectangle(coloff, rowoff, 16, 16);
	}


	private void RefreshBoard() {
		using var g = Graphics.FromImage(LevelPreview);

		g.Clear(Color.SaddleBrown);

		if (selectedLevel is not Level l) {
			LevelPanel.Invalidate();
			return;
		}

		g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

		l.ForAllObjects(o => {
			var destRect = new Rectangle(o.Column * 16, o.Row * 16, 16, 16);
			var srcRect = GetSourceRectangle(o.EntityType, o.Color);

			g.DrawImage(Resource1.levelobjects, destRect, srcRect, GraphicsUnit.Pixel);

			if (o.EntityType is ObjectType.Fancy) {
				g.DrawImage(Resource1.fancy, destRect);
			}
		});

		using var g2 = Graphics.FromImage(LevelPreviewBig);
		g2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
		g2.DrawImage(LevelPreview, PanelDestinationRect, PanelSourceRect, GraphicsUnit.Pixel);


		LevelPanel.Invalidate();
	}

	private bool codedLevelChange = false;

	private void LevelSelectTree_AfterSelect(object sender, TreeViewEventArgs e) {
		if (codedLevelChange) return;
		UpdateSelectedLevel(e?.Node?.Tag as Level);
	}

	private void PreviewTypeBoxGRWP_SelectedValueChanged(object sender, EventArgs e) {
		if (codedLevelChange) return;
		PreviewTypeGRWP = PreviewTypeBoxGRWP.SelectedItem as MonsterType ?? MonsterType.Moo;
		RefreshBoard();
	}
	private void PreviewTypeBoxBYKT_SelectionChangeCommitted(object sender, EventArgs e) {
		if (codedLevelChange) return;
		PreviewTypeBYKT = PreviewTypeBoxBYKT.SelectedItem as MonsterType ?? MonsterType.Moo;
		RefreshBoard();
	}

	private void EditLevelButton_Click(object sender, EventArgs e) {
		bool roundA;
		if (sender == EditAButton) {
			roundA = true;
		} else if (sender == EditBButton) {
			roundA = false;
		} else {
			return;
		}

		var rows = RoundView.SelectedCells;

		if (rows.Count is 0) {
			return;
		}

		codedLevelChange = true;

		if (RoundView.Rows[rows[0].RowIndex].DataBoundItem is not Round selround) return;

		PreviewTypeBoxGRWP.SelectedItem = PreviewTypeGRWP = selround.MonsterTypesGRWP;
		PreviewTypeBoxBYKT.SelectedItem = PreviewTypeBYKT = selround.MonsterTypesBYKT;


		codedLevelChange = false;

		UpdateSelectedLevel(ROM!.AllRoundLevels[roundA ? selround.LevelA : selround.LevelB]);


	}

	private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
		SaveFile(ROM?.Path ?? "");
	}

	private void SaveFile(string path) {
		if (ROM is null) {
			MessageBox.Show("No ROM loaded.", "You have no rom", MessageBoxButtons.OK, MessageBoxIcon.Error);

			return;
		}

		try {
			SaveROM();

			using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);

			fs.Write(ROM.Stream, 0, ROM.Stream.Length);
			fs.Close();

		} catch (Exception e) {
			MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}


	//======================================================================================
	//======================================================================================
	//======================================================================================
	private enum EditMode {
		Delete = 0,
		SetType,
		SetColor,
		SetBoth
	}

	private EditMode currentEditMode = EditMode.SetBoth;

	private bool onBoard = false;

	private int boardX, boardY;

	private void LevelPanel_MouseLeave(object sender, EventArgs e) {
		onBoard = false;
		LevelPanel.Refresh();
	}

	private void LevelPanel_MouseClick(object sender, MouseEventArgs e) {
		if (selectedLevel is null) return;

		var selobj = selectedLevel[boardY, boardX];

		if (e.Button is MouseButtons.Right) {
			selobj.EntityType = ObjectType.Nothing;
		} else if (e.Button is MouseButtons.Left) {
			switch (currentEditMode) {
				case EditMode.Delete:
					selobj.EntityType = ObjectType.Nothing;
					break;

				case EditMode.SetType:
					selobj.EntityType = selectedType;
					break;

				case EditMode.SetColor:
					selobj.Color = selectedColor;
					break;

				case EditMode.SetBoth:
					selobj.EntityType = selectedType;
					selobj.Color = selectedColor;
					break;
			}
		}

		RefreshBoard();

	}

	private void LevelPanel_MouseEnter(object sender, EventArgs e) {
		onBoard = true;
		LevelPanel.Refresh();
	}

	private void ClearLevelButton_Click(object sender, EventArgs e) {
		selectedLevel?.ForAllObjects(o => o.EntityType = ObjectType.Nothing);
		RefreshBoard();
	}

	private void SingleLevelButton_Click(object sender, EventArgs e) {
		if (ROM is null) return;
		if (MessageBox.Show("Click okay to make all B levels the same as the A level for each round.",
			"Singlify levels?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) is DialogResult.OK) {
			foreach (var r in ROM.AllRounds) {
				r.LevelB = r.LevelA;
			}
		}
	}

	private void LevelPanel_MouseMove(object sender, MouseEventArgs e) {
		boardX = e.X / PreviewSize;
		boardY = e.Y / PreviewSize;

		LevelPanel.Refresh();
	}
}
