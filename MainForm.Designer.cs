namespace WariosWoodsEditor;

partial class MainForm {
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.levelsPage = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.InfoLabel = new System.Windows.Forms.Label();
			this.LevelEditLabel = new System.Windows.Forms.Label();
			this.EditModeBox = new System.Windows.Forms.Panel();
			this.ModeButtonBoth = new System.Windows.Forms.RadioButton();
			this.ModeButtonColor = new System.Windows.Forms.RadioButton();
			this.ModeButtonType = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.ClearLevelButton = new System.Windows.Forms.Button();
			this.TypeGroupBox = new System.Windows.Forms.Panel();
			this.ActionButtonFancy = new System.Windows.Forms.RadioButton();
			this.ActionButtonBreakfast = new System.Windows.Forms.RadioButton();
			this.ActionButtonDiamond = new System.Windows.Forms.RadioButton();
			this.ActionButtonBomb = new System.Windows.Forms.RadioButton();
			this.ActionButtonMonster = new System.Windows.Forms.RadioButton();
			this.ColorGroupBox = new System.Windows.Forms.Panel();
			this.RadioButtonT = new System.Windows.Forms.RadioButton();
			this.RadioButtonK = new System.Windows.Forms.RadioButton();
			this.RadioButtonY = new System.Windows.Forms.RadioButton();
			this.RadioButtonB = new System.Windows.Forms.RadioButton();
			this.RadioButtonP = new System.Windows.Forms.RadioButton();
			this.RadioButtonW = new System.Windows.Forms.RadioButton();
			this.RadioButtonR = new System.Windows.Forms.RadioButton();
			this.RadioButtonG = new System.Windows.Forms.RadioButton();
			this.PreviewTypeBoxBYKT = new WariosWoodsEditor.MonsterComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.PreviewTypeBoxGRWP = new WariosWoodsEditor.MonsterComboBox();
			this.LevelPanel = new System.Windows.Forms.PictureBox();
			this.LevelSelectTree = new System.Windows.Forms.TreeView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SingleLevelButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.EditBButton = new System.Windows.Forms.Button();
			this.EditAButton = new System.Windows.Forms.Button();
			this.RoundView = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.RerandomizeBox = new System.Windows.Forms.CheckBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.CreditsTextGrid = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.levelsPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.EditModeBox.SuspendLayout();
			this.TypeGroupBox.SuspendLayout();
			this.ColorGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelPanel)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RoundView)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CreditsTextGrid)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.levelsPage);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1234, 787);
			this.tabControl1.TabIndex = 1;
			// 
			// levelsPage
			// 
			this.levelsPage.Controls.Add(this.groupBox1);
			this.levelsPage.Controls.Add(this.groupBox2);
			this.levelsPage.Location = new System.Drawing.Point(4, 24);
			this.levelsPage.Name = "levelsPage";
			this.levelsPage.Padding = new System.Windows.Forms.Padding(3);
			this.levelsPage.Size = new System.Drawing.Size(1226, 759);
			this.levelsPage.TabIndex = 0;
			this.levelsPage.Text = "Level editor";
			this.levelsPage.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.InfoLabel);
			this.groupBox1.Controls.Add(this.LevelEditLabel);
			this.groupBox1.Controls.Add(this.EditModeBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.ClearLevelButton);
			this.groupBox1.Controls.Add(this.TypeGroupBox);
			this.groupBox1.Controls.Add(this.ColorGroupBox);
			this.groupBox1.Controls.Add(this.PreviewTypeBoxBYKT);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.PreviewTypeBoxGRWP);
			this.groupBox1.Controls.Add(this.LevelPanel);
			this.groupBox1.Controls.Add(this.LevelSelectTree);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(490, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(733, 753);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actual Level Designer";
			// 
			// InfoLabel
			// 
			this.InfoLabel.AutoSize = true;
			this.InfoLabel.Location = new System.Drawing.Point(540, 460);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(17, 15);
			this.InfoLabel.TabIndex = 14;
			this.InfoLabel.Text = "--";
			// 
			// LevelEditLabel
			// 
			this.LevelEditLabel.AutoSize = true;
			this.LevelEditLabel.Location = new System.Drawing.Point(198, 19);
			this.LevelEditLabel.Name = "LevelEditLabel";
			this.LevelEditLabel.Size = new System.Drawing.Size(87, 15);
			this.LevelEditLabel.TabIndex = 13;
			this.LevelEditLabel.Text = "Editing level: --";
			// 
			// EditModeBox
			// 
			this.EditModeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EditModeBox.Controls.Add(this.ModeButtonBoth);
			this.EditModeBox.Controls.Add(this.ModeButtonColor);
			this.EditModeBox.Controls.Add(this.ModeButtonType);
			this.EditModeBox.Location = new System.Drawing.Point(540, 42);
			this.EditModeBox.Name = "EditModeBox";
			this.EditModeBox.Padding = new System.Windows.Forms.Padding(9, 4, 9, 9);
			this.EditModeBox.Size = new System.Drawing.Size(173, 81);
			this.EditModeBox.TabIndex = 11;
			// 
			// ModeButtonBoth
			// 
			this.ModeButtonBoth.AutoSize = true;
			this.ModeButtonBoth.Location = new System.Drawing.Point(8, 57);
			this.ModeButtonBoth.Name = "ModeButtonBoth";
			this.ModeButtonBoth.Size = new System.Drawing.Size(69, 19);
			this.ModeButtonBoth.TabIndex = 2;
			this.ModeButtonBoth.TabStop = true;
			this.ModeButtonBoth.Text = "Set both";
			this.ModeButtonBoth.UseVisualStyleBackColor = true;
			// 
			// ModeButtonColor
			// 
			this.ModeButtonColor.AutoSize = true;
			this.ModeButtonColor.Location = new System.Drawing.Point(8, 32);
			this.ModeButtonColor.Name = "ModeButtonColor";
			this.ModeButtonColor.Size = new System.Drawing.Size(71, 19);
			this.ModeButtonColor.TabIndex = 1;
			this.ModeButtonColor.TabStop = true;
			this.ModeButtonColor.Text = "Set color";
			this.ModeButtonColor.UseVisualStyleBackColor = true;
			// 
			// ModeButtonType
			// 
			this.ModeButtonType.AutoSize = true;
			this.ModeButtonType.Location = new System.Drawing.Point(8, 7);
			this.ModeButtonType.Name = "ModeButtonType";
			this.ModeButtonType.Size = new System.Drawing.Size(67, 19);
			this.ModeButtonType.TabIndex = 0;
			this.ModeButtonType.TabStop = true;
			this.ModeButtonType.Text = "Set type";
			this.ModeButtonType.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(198, 630);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(213, 45);
			this.label4.TabIndex = 10;
			this.label4.Text = "Shift + Mouse wheel - Change type\r\nControl + Mouse wheel - Change color\r\nRight cl" +
    "ick - delete";
			// 
			// ClearLevelButton
			// 
			this.ClearLevelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ClearLevelButton.Location = new System.Drawing.Point(198, 727);
			this.ClearLevelButton.Name = "ClearLevelButton";
			this.ClearLevelButton.Size = new System.Drawing.Size(75, 23);
			this.ClearLevelButton.TabIndex = 9;
			this.ClearLevelButton.Text = "Clear";
			this.ClearLevelButton.UseVisualStyleBackColor = true;
			this.ClearLevelButton.Click += new System.EventHandler(this.ClearLevelButton_Click);
			// 
			// TypeGroupBox
			// 
			this.TypeGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.TypeGroupBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TypeGroupBox.Controls.Add(this.ActionButtonFancy);
			this.TypeGroupBox.Controls.Add(this.ActionButtonBreakfast);
			this.TypeGroupBox.Controls.Add(this.ActionButtonDiamond);
			this.TypeGroupBox.Controls.Add(this.ActionButtonBomb);
			this.TypeGroupBox.Controls.Add(this.ActionButtonMonster);
			this.TypeGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TypeGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.TypeGroupBox.Location = new System.Drawing.Point(540, 129);
			this.TypeGroupBox.Name = "TypeGroupBox";
			this.TypeGroupBox.Padding = new System.Windows.Forms.Padding(9, 4, 9, 9);
			this.TypeGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TypeGroupBox.Size = new System.Drawing.Size(173, 136);
			this.TypeGroupBox.TabIndex = 8;
			// 
			// ActionButtonFancy
			// 
			this.ActionButtonFancy.AutoSize = true;
			this.ActionButtonFancy.Location = new System.Drawing.Point(8, 107);
			this.ActionButtonFancy.Name = "ActionButtonFancy";
			this.ActionButtonFancy.Size = new System.Drawing.Size(56, 19);
			this.ActionButtonFancy.TabIndex = 5;
			this.ActionButtonFancy.TabStop = true;
			this.ActionButtonFancy.Text = "Fancy";
			this.ActionButtonFancy.UseVisualStyleBackColor = true;
			// 
			// ActionButtonBreakfast
			// 
			this.ActionButtonBreakfast.AutoSize = true;
			this.ActionButtonBreakfast.Location = new System.Drawing.Point(8, 82);
			this.ActionButtonBreakfast.Name = "ActionButtonBreakfast";
			this.ActionButtonBreakfast.Size = new System.Drawing.Size(73, 19);
			this.ActionButtonBreakfast.TabIndex = 4;
			this.ActionButtonBreakfast.TabStop = true;
			this.ActionButtonBreakfast.Text = "Breakfast";
			this.ActionButtonBreakfast.UseVisualStyleBackColor = true;
			// 
			// ActionButtonDiamond
			// 
			this.ActionButtonDiamond.AutoSize = true;
			this.ActionButtonDiamond.Location = new System.Drawing.Point(8, 57);
			this.ActionButtonDiamond.Name = "ActionButtonDiamond";
			this.ActionButtonDiamond.Size = new System.Drawing.Size(74, 19);
			this.ActionButtonDiamond.TabIndex = 3;
			this.ActionButtonDiamond.TabStop = true;
			this.ActionButtonDiamond.Text = "Diamond";
			this.ActionButtonDiamond.UseVisualStyleBackColor = true;
			// 
			// ActionButtonBomb
			// 
			this.ActionButtonBomb.AutoSize = true;
			this.ActionButtonBomb.Location = new System.Drawing.Point(8, 32);
			this.ActionButtonBomb.Name = "ActionButtonBomb";
			this.ActionButtonBomb.Size = new System.Drawing.Size(57, 19);
			this.ActionButtonBomb.TabIndex = 2;
			this.ActionButtonBomb.TabStop = true;
			this.ActionButtonBomb.Text = "Bomb";
			this.ActionButtonBomb.UseVisualStyleBackColor = true;
			// 
			// ActionButtonMonster
			// 
			this.ActionButtonMonster.AutoSize = true;
			this.ActionButtonMonster.Location = new System.Drawing.Point(8, 7);
			this.ActionButtonMonster.Name = "ActionButtonMonster";
			this.ActionButtonMonster.Size = new System.Drawing.Size(69, 19);
			this.ActionButtonMonster.TabIndex = 1;
			this.ActionButtonMonster.TabStop = true;
			this.ActionButtonMonster.Text = "Monster";
			this.ActionButtonMonster.UseVisualStyleBackColor = true;
			// 
			// ColorGroupBox
			// 
			this.ColorGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.ColorGroupBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorGroupBox.Controls.Add(this.RadioButtonT);
			this.ColorGroupBox.Controls.Add(this.RadioButtonK);
			this.ColorGroupBox.Controls.Add(this.RadioButtonY);
			this.ColorGroupBox.Controls.Add(this.RadioButtonB);
			this.ColorGroupBox.Controls.Add(this.RadioButtonP);
			this.ColorGroupBox.Controls.Add(this.RadioButtonW);
			this.ColorGroupBox.Controls.Add(this.RadioButtonR);
			this.ColorGroupBox.Controls.Add(this.RadioButtonG);
			this.ColorGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ColorGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ColorGroupBox.Location = new System.Drawing.Point(540, 271);
			this.ColorGroupBox.Name = "ColorGroupBox";
			this.ColorGroupBox.Padding = new System.Windows.Forms.Padding(9);
			this.ColorGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ColorGroupBox.Size = new System.Drawing.Size(173, 70);
			this.ColorGroupBox.TabIndex = 7;
			// 
			// RadioButtonT
			// 
			this.RadioButtonT.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonT.Location = new System.Drawing.Point(128, 38);
			this.RadioButtonT.Name = "RadioButtonT";
			this.RadioButtonT.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonT.TabIndex = 13;
			this.RadioButtonT.UseVisualStyleBackColor = false;
			// 
			// RadioButtonK
			// 
			this.RadioButtonK.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonK.Location = new System.Drawing.Point(88, 38);
			this.RadioButtonK.Name = "RadioButtonK";
			this.RadioButtonK.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonK.TabIndex = 12;
			this.RadioButtonK.UseVisualStyleBackColor = false;
			// 
			// RadioButtonY
			// 
			this.RadioButtonY.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonY.Location = new System.Drawing.Point(48, 38);
			this.RadioButtonY.Name = "RadioButtonY";
			this.RadioButtonY.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonY.TabIndex = 11;
			this.RadioButtonY.UseVisualStyleBackColor = false;
			// 
			// RadioButtonB
			// 
			this.RadioButtonB.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonB.Location = new System.Drawing.Point(8, 38);
			this.RadioButtonB.Name = "RadioButtonB";
			this.RadioButtonB.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonB.TabIndex = 10;
			this.RadioButtonB.UseVisualStyleBackColor = false;
			// 
			// RadioButtonP
			// 
			this.RadioButtonP.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonP.Location = new System.Drawing.Point(128, 8);
			this.RadioButtonP.Name = "RadioButtonP";
			this.RadioButtonP.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonP.TabIndex = 9;
			this.RadioButtonP.UseVisualStyleBackColor = false;
			// 
			// RadioButtonW
			// 
			this.RadioButtonW.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonW.Location = new System.Drawing.Point(88, 8);
			this.RadioButtonW.Name = "RadioButtonW";
			this.RadioButtonW.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonW.TabIndex = 8;
			this.RadioButtonW.UseVisualStyleBackColor = false;
			// 
			// RadioButtonR
			// 
			this.RadioButtonR.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonR.Location = new System.Drawing.Point(48, 8);
			this.RadioButtonR.Name = "RadioButtonR";
			this.RadioButtonR.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonR.TabIndex = 7;
			this.RadioButtonR.UseVisualStyleBackColor = false;
			// 
			// RadioButtonG
			// 
			this.RadioButtonG.BackColor = System.Drawing.Color.DarkGray;
			this.RadioButtonG.Location = new System.Drawing.Point(8, 8);
			this.RadioButtonG.Name = "RadioButtonG";
			this.RadioButtonG.Size = new System.Drawing.Size(34, 24);
			this.RadioButtonG.TabIndex = 6;
			this.RadioButtonG.UseVisualStyleBackColor = false;
			// 
			// PreviewTypeBoxBYKT
			// 
			this.PreviewTypeBoxBYKT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.PreviewTypeBoxBYKT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PreviewTypeBoxBYKT.FormattingEnabled = true;
			this.PreviewTypeBoxBYKT.Location = new System.Drawing.Point(244, 606);
			this.PreviewTypeBoxBYKT.Name = "PreviewTypeBoxBYKT";
			this.PreviewTypeBoxBYKT.Size = new System.Drawing.Size(104, 24);
			this.PreviewTypeBoxBYKT.TabIndex = 5;
			this.PreviewTypeBoxBYKT.SelectionChangeCommitted += new System.EventHandler(this.PreviewTypeBoxBYKT_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(204, 611);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "BYKT";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(198, 579);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "GRWP\r\n";
			// 
			// PreviewTypeBoxGRWP
			// 
			this.PreviewTypeBoxGRWP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.PreviewTypeBoxGRWP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PreviewTypeBoxGRWP.FormattingEnabled = true;
			this.PreviewTypeBoxGRWP.Location = new System.Drawing.Point(244, 576);
			this.PreviewTypeBoxGRWP.Name = "PreviewTypeBoxGRWP";
			this.PreviewTypeBoxGRWP.Size = new System.Drawing.Size(104, 24);
			this.PreviewTypeBoxGRWP.TabIndex = 2;
			this.PreviewTypeBoxGRWP.SelectionChangeCommitted += new System.EventHandler(this.PreviewTypeBoxGRWP_SelectedValueChanged);
			// 
			// LevelPanel
			// 
			this.LevelPanel.BackColor = System.Drawing.SystemColors.Control;
			this.LevelPanel.Location = new System.Drawing.Point(198, 42);
			this.LevelPanel.Name = "LevelPanel";
			this.LevelPanel.Size = new System.Drawing.Size(336, 528);
			this.LevelPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.LevelPanel.TabIndex = 1;
			this.LevelPanel.TabStop = false;
			this.LevelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelPanel_Paint);
			this.LevelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LevelPanel_MouseClick);
			this.LevelPanel.MouseEnter += new System.EventHandler(this.LevelPanel_MouseEnter);
			this.LevelPanel.MouseLeave += new System.EventHandler(this.LevelPanel_MouseLeave);
			this.LevelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LevelPanel_MouseMove);
			// 
			// LevelSelectTree
			// 
			this.LevelSelectTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.LevelSelectTree.Location = new System.Drawing.Point(3, 19);
			this.LevelSelectTree.Name = "LevelSelectTree";
			this.LevelSelectTree.Size = new System.Drawing.Size(189, 731);
			this.LevelSelectTree.TabIndex = 0;
			this.LevelSelectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LevelSelectTree_AfterSelect);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SingleLevelButton);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.EditBButton);
			this.groupBox2.Controls.Add(this.EditAButton);
			this.groupBox2.Controls.Add(this.RoundView);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(487, 753);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Round Editor";
			// 
			// SingleLevelButton
			// 
			this.SingleLevelButton.Location = new System.Drawing.Point(347, 528);
			this.SingleLevelButton.Name = "SingleLevelButton";
			this.SingleLevelButton.Size = new System.Drawing.Size(134, 23);
			this.SingleLevelButton.TabIndex = 6;
			this.SingleLevelButton.Text = "Single level rounds";
			this.SingleLevelButton.UseVisualStyleBackColor = true;
			this.SingleLevelButton.Click += new System.EventHandler(this.SingleLevelButton_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 640);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(336, 120);
			this.label3.TabIndex = 5;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// EditBButton
			// 
			this.EditBButton.Location = new System.Drawing.Point(87, 528);
			this.EditBButton.Name = "EditBButton";
			this.EditBButton.Size = new System.Drawing.Size(75, 23);
			this.EditBButton.TabIndex = 4;
			this.EditBButton.Text = "Edit B";
			this.EditBButton.UseVisualStyleBackColor = true;
			this.EditBButton.Click += new System.EventHandler(this.EditLevelButton_Click);
			// 
			// EditAButton
			// 
			this.EditAButton.Location = new System.Drawing.Point(6, 528);
			this.EditAButton.Name = "EditAButton";
			this.EditAButton.Size = new System.Drawing.Size(75, 23);
			this.EditAButton.TabIndex = 3;
			this.EditAButton.Text = "Edit A";
			this.EditAButton.UseVisualStyleBackColor = true;
			this.EditAButton.Click += new System.EventHandler(this.EditLevelButton_Click);
			// 
			// RoundView
			// 
			this.RoundView.AllowUserToAddRows = false;
			this.RoundView.AllowUserToDeleteRows = false;
			this.RoundView.AllowUserToResizeColumns = false;
			this.RoundView.AllowUserToResizeRows = false;
			this.RoundView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.RoundView.Dock = System.Windows.Forms.DockStyle.Top;
			this.RoundView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.RoundView.Location = new System.Drawing.Point(3, 19);
			this.RoundView.MultiSelect = false;
			this.RoundView.Name = "RoundView";
			this.RoundView.RowHeadersVisible = false;
			this.RoundView.RowTemplate.Height = 25;
			this.RoundView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.RoundView.ShowEditingIcon = false;
			this.RoundView.Size = new System.Drawing.Size(481, 503);
			this.RoundView.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.RerandomizeBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1226, 759);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "General";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// RerandomizeBox
			// 
			this.RerandomizeBox.AutoSize = true;
			this.RerandomizeBox.Location = new System.Drawing.Point(6, 14);
			this.RerandomizeBox.Name = "RerandomizeBox";
			this.RerandomizeBox.Size = new System.Drawing.Size(181, 19);
			this.RerandomizeBox.TabIndex = 0;
			this.RerandomizeBox.Text = "Rerandomize color RNG table";
			this.RerandomizeBox.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.CreditsTextGrid);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(1226, 759);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Text";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 15);
			this.label5.TabIndex = 1;
			this.label5.Text = "Round Game ending";
			// 
			// CreditsTextGrid
			// 
			this.CreditsTextGrid.AllowUserToAddRows = false;
			this.CreditsTextGrid.AllowUserToDeleteRows = false;
			this.CreditsTextGrid.AllowUserToResizeColumns = false;
			this.CreditsTextGrid.AllowUserToResizeRows = false;
			this.CreditsTextGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CreditsTextGrid.ColumnHeadersVisible = false;
			this.CreditsTextGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.CreditsTextGrid.Location = new System.Drawing.Point(3, 38);
			this.CreditsTextGrid.MultiSelect = false;
			this.CreditsTextGrid.Name = "CreditsTextGrid";
			this.CreditsTextGrid.RowHeadersVisible = false;
			this.CreditsTextGrid.RowTemplate.Height = 25;
			this.CreditsTextGrid.Size = new System.Drawing.Size(549, 397);
			this.CreditsTextGrid.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1234, 811);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(1250, 850);
			this.Name = "MainForm";
			this.Text = "Hello, Sweet Breakfast!";
			this.tabControl1.ResumeLayout(false);
			this.levelsPage.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.EditModeBox.ResumeLayout(false);
			this.EditModeBox.PerformLayout();
			this.TypeGroupBox.ResumeLayout(false);
			this.TypeGroupBox.PerformLayout();
			this.ColorGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LevelPanel)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RoundView)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CreditsTextGrid)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion
	private TabControl tabControl1;
	private TabPage levelsPage;
	private TabPage tabPage2;
	private GroupBox groupBox1;
	private DataGridView RoundView;
	private TreeView LevelSelectTree;
	private PictureBox LevelPanel;
	private MonsterComboBox PreviewTypeBoxGRWP;
	private Label label1;
	private Label label2;
	private MonsterComboBox PreviewTypeBoxBYKT;
	private GroupBox groupBox2;
	private Button EditBButton;
	private Button EditAButton;
	private Label label3;
	private Panel ColorGroupBox;
	private RadioButton RadioButtonT;
	private RadioButton RadioButtonK;
	private RadioButton RadioButtonY;
	private RadioButton RadioButtonB;
	private RadioButton RadioButtonP;
	private RadioButton RadioButtonW;
	private RadioButton RadioButtonR;
	private RadioButton RadioButtonG;
	private CheckBox RerandomizeBox;
	private MenuStrip menuStrip1;
	private ToolStripMenuItem fileToolStripMenuItem;
	private ToolStripMenuItem openToolStripMenuItem;
	private ToolStripMenuItem saveToolStripMenuItem;
	private Panel TypeGroupBox;
	private RadioButton ActionButtonDiamond;
	private RadioButton ActionButtonBomb;
	private RadioButton ActionButtonMonster;
	private RadioButton ActionButtonBreakfast;
	private Button ClearLevelButton;
	private Label label4;
	private Panel EditModeBox;
	private RadioButton ModeButtonBoth;
	private RadioButton ModeButtonColor;
	private RadioButton ModeButtonType;
	private Button SingleLevelButton;
	private Label LevelEditLabel;
	private Label InfoLabel;
	private RadioButton ActionButtonFancy;
	private TabPage tabPage1;
	private DataGridView CreditsTextGrid;
	private Label label5;
}
