namespace OpenDental{
	partial class FormJobEdit {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobEdit));
			this.butDelete = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.butAddNote = new OpenDental.UI.Button();
			this.splitDescriptNotes = new System.Windows.Forms.SplitContainer();
			this.labelWarning = new System.Windows.Forms.Label();
			this.comboFontSize = new System.Windows.Forms.ComboBox();
			this.butHighlightSelect = new System.Windows.Forms.Button();
			this.comboFontType = new System.Windows.Forms.ComboBox();
			this.butColorSelect = new System.Windows.Forms.Button();
			this.butHighlight = new System.Windows.Forms.Button();
			this.butFont = new System.Windows.Forms.Button();
			this.butBullet = new System.Windows.Forms.Button();
			this.butStrikeout = new System.Windows.Forms.Button();
			this.butRedo = new System.Windows.Forms.Button();
			this.butColor = new System.Windows.Forms.Button();
			this.butUnderline = new System.Windows.Forms.Button();
			this.butItalics = new System.Windows.Forms.Button();
			this.butPaste = new System.Windows.Forms.Button();
			this.butBold = new System.Windows.Forms.Button();
			this.butUndo = new System.Windows.Forms.Button();
			this.textDescription = new OpenDental.ODtextBox();
			this.butCopy = new System.Windows.Forms.Button();
			this.butCut = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.gridLinks = new OpenDental.UI.ODGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gridNotes = new OpenDental.UI.ODGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupAddLink = new System.Windows.Forms.GroupBox();
			this.butLinkQuote = new OpenDental.UI.Button();
			this.butLinkTask = new OpenDental.UI.Button();
			this.butLinkFeatReq = new OpenDental.UI.Button();
			this.butLinkBug = new OpenDental.UI.Button();
			this.butRemove = new OpenDental.UI.Button();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.tabReviews = new System.Windows.Forms.TabPage();
			this.gridReview = new OpenDental.UI.ODGrid();
			this.butAddReview = new OpenDental.UI.Button();
			this.tabHistory = new System.Windows.Forms.TabPage();
			this.gridHistory = new OpenDental.UI.ODGrid();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboStatus = new System.Windows.Forms.ComboBox();
			this.butExpertPick = new OpenDental.UI.Button();
			this.butOwnerPick = new OpenDental.UI.Button();
			this.textActualHours = new OpenDental.ValidNumber();
			this.textEstHours = new OpenDental.ValidNumber();
			this.groupActions = new System.Windows.Forms.GroupBox();
			this.butAction2 = new OpenDental.UI.Button();
			this.butAction3 = new OpenDental.UI.Button();
			this.butAction4 = new OpenDental.UI.Button();
			this.butAction1 = new OpenDental.UI.Button();
			this.butOverride = new OpenDental.UI.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.textTitle = new System.Windows.Forms.TextBox();
			this.comboCategory = new System.Windows.Forms.ComboBox();
			this.comboPriority = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textOwner = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textDateEntry = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textVersion = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.butProjectPick = new OpenDental.UI.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textProject = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textExpert = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.textJobNum = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitDescriptNotes)).BeginInit();
			this.splitDescriptNotes.Panel1.SuspendLayout();
			this.splitDescriptNotes.Panel2.SuspendLayout();
			this.splitDescriptNotes.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupAddLink.SuspendLayout();
			this.tabControlMain.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabReviews.SuspendLayout();
			this.tabHistory.SuspendLayout();
			this.groupActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// butDelete
			// 
			this.butDelete.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butDelete.Autosize = true;
			this.butDelete.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDelete.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDelete.CornerRadius = 4F;
			this.butDelete.Image = global::OpenDental.Properties.Resources.deleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(12, 678);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(75, 24);
			this.butDelete.TabIndex = 17;
			this.butDelete.Text = "Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(1113, 676);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 15;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.Location = new System.Drawing.Point(1194, 676);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 16;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// butAddNote
			// 
			this.butAddNote.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butAddNote.Autosize = true;
			this.butAddNote.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAddNote.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAddNote.CornerRadius = 4F;
			this.butAddNote.Image = global::OpenDental.Properties.Resources.Add;
			this.butAddNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAddNote.Location = new System.Drawing.Point(650, 20);
			this.butAddNote.Name = "butAddNote";
			this.butAddNote.Size = new System.Drawing.Size(75, 24);
			this.butAddNote.TabIndex = 151;
			this.butAddNote.Text = "Add";
			this.butAddNote.Click += new System.EventHandler(this.butAddNote_Click);
			// 
			// splitDescriptNotes
			// 
			this.splitDescriptNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitDescriptNotes.BackColor = System.Drawing.Color.WhiteSmoke;
			this.splitDescriptNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitDescriptNotes.Location = new System.Drawing.Point(0, 7);
			this.splitDescriptNotes.Name = "splitDescriptNotes";
			this.splitDescriptNotes.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitDescriptNotes.Panel1
			// 
			this.splitDescriptNotes.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitDescriptNotes.Panel1.Controls.Add(this.labelWarning);
			this.splitDescriptNotes.Panel1.Controls.Add(this.comboFontSize);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butHighlightSelect);
			this.splitDescriptNotes.Panel1.Controls.Add(this.comboFontType);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butColorSelect);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butHighlight);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butFont);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butBullet);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butStrikeout);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butRedo);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butColor);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butUnderline);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butItalics);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butPaste);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butBold);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butUndo);
			this.splitDescriptNotes.Panel1.Controls.Add(this.textDescription);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butCopy);
			this.splitDescriptNotes.Panel1.Controls.Add(this.butCut);
			// 
			// splitDescriptNotes.Panel2
			// 
			this.splitDescriptNotes.Panel2.Controls.Add(this.panel3);
			this.splitDescriptNotes.Panel2.Controls.Add(this.panel2);
			this.splitDescriptNotes.Panel2.Controls.Add(this.panel1);
			this.splitDescriptNotes.Size = new System.Drawing.Size(978, 633);
			this.splitDescriptNotes.SplitterDistance = 365;
			this.splitDescriptNotes.SplitterWidth = 10;
			this.splitDescriptNotes.TabIndex = 0;
			// 
			// labelWarning
			// 
			this.labelWarning.AutoSize = true;
			this.labelWarning.Location = new System.Drawing.Point(734, 4);
			this.labelWarning.Name = "labelWarning";
			this.labelWarning.Size = new System.Drawing.Size(0, 13);
			this.labelWarning.TabIndex = 169;
			// 
			// comboFontSize
			// 
			this.comboFontSize.FormattingEnabled = true;
			this.comboFontSize.Location = new System.Drawing.Point(555, -1);
			this.comboFontSize.Name = "comboFontSize";
			this.comboFontSize.Size = new System.Drawing.Size(39, 21);
			this.comboFontSize.TabIndex = 168;
			// 
			// butHighlightSelect
			// 
			this.butHighlightSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butHighlightSelect.Image = global::OpenDental.Properties.Resources.arrowDownTriangle;
			this.butHighlightSelect.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.butHighlightSelect.Location = new System.Drawing.Point(701, -3);
			this.butHighlightSelect.Name = "butHighlightSelect";
			this.butHighlightSelect.Size = new System.Drawing.Size(10, 24);
			this.butHighlightSelect.TabIndex = 167;
			this.butHighlightSelect.Text = "Cut";
			this.butHighlightSelect.Click += new System.EventHandler(this.butHighlightSelect_Click);
			this.butHighlightSelect.MouseEnter += new System.EventHandler(this.butHighlightSelect_MouseEnter);
			this.butHighlightSelect.MouseLeave += new System.EventHandler(this.butHighlightSelect_MouseLeave);
			// 
			// comboFontType
			// 
			this.comboFontType.FormattingEnabled = true;
			this.comboFontType.Location = new System.Drawing.Point(441, -1);
			this.comboFontType.Name = "comboFontType";
			this.comboFontType.Size = new System.Drawing.Size(113, 21);
			this.comboFontType.TabIndex = 167;
			// 
			// butColorSelect
			// 
			this.butColorSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butColorSelect.Image = global::OpenDental.Properties.Resources.arrowDownTriangle;
			this.butColorSelect.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.butColorSelect.Location = new System.Drawing.Point(626, -3);
			this.butColorSelect.Name = "butColorSelect";
			this.butColorSelect.Size = new System.Drawing.Size(10, 24);
			this.butColorSelect.TabIndex = 166;
			this.butColorSelect.Text = "Cut";
			this.butColorSelect.Click += new System.EventHandler(this.butColorSelect_Click);
			this.butColorSelect.MouseEnter += new System.EventHandler(this.butColorSelect_MouseEnter);
			this.butColorSelect.MouseLeave += new System.EventHandler(this.butColorSelect_MouseLeave);
			// 
			// butHighlight
			// 
			this.butHighlight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butHighlight.Location = new System.Drawing.Point(644, -3);
			this.butHighlight.Name = "butHighlight";
			this.butHighlight.Size = new System.Drawing.Size(57, 24);
			this.butHighlight.TabIndex = 166;
			this.butHighlight.Text = "Highlight";
			this.butHighlight.Click += new System.EventHandler(this.butHighlight_Click);
			this.butHighlight.MouseEnter += new System.EventHandler(this.butHighlight_MouseEnter);
			this.butHighlight.MouseLeave += new System.EventHandler(this.butHighlight_MouseLeave);
			// 
			// butFont
			// 
			this.butFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butFont.Location = new System.Drawing.Point(399, -3);
			this.butFont.Name = "butFont";
			this.butFont.Size = new System.Drawing.Size(41, 24);
			this.butFont.TabIndex = 165;
			this.butFont.Text = "Font";
			this.butFont.Click += new System.EventHandler(this.butFont_Click);
			this.butFont.MouseEnter += new System.EventHandler(this.butFont_MouseEnter);
			this.butFont.MouseLeave += new System.EventHandler(this.butFont_MouseLeave);
			// 
			// butBullet
			// 
			this.butBullet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBullet.Location = new System.Drawing.Point(344, -3);
			this.butBullet.Name = "butBullet";
			this.butBullet.Size = new System.Drawing.Size(55, 24);
			this.butBullet.TabIndex = 166;
			this.butBullet.Text = "Bulleted";
			this.butBullet.Click += new System.EventHandler(this.butBullet_Click);
			this.butBullet.MouseEnter += new System.EventHandler(this.butBullet_MouseEnter);
			this.butBullet.MouseLeave += new System.EventHandler(this.butBullet_MouseLeave);
			// 
			// butStrikeout
			// 
			this.butStrikeout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butStrikeout.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butStrikeout.Location = new System.Drawing.Point(314, -3);
			this.butStrikeout.Name = "butStrikeout";
			this.butStrikeout.Size = new System.Drawing.Size(30, 24);
			this.butStrikeout.TabIndex = 167;
			this.butStrikeout.Text = "abc";
			this.butStrikeout.Click += new System.EventHandler(this.butStrikeout_Click);
			this.butStrikeout.MouseEnter += new System.EventHandler(this.butStrikeout_MouseEnter);
			this.butStrikeout.MouseLeave += new System.EventHandler(this.butStrikeout_MouseLeave);
			// 
			// butRedo
			// 
			this.butRedo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butRedo.Location = new System.Drawing.Point(204, -3);
			this.butRedo.Name = "butRedo";
			this.butRedo.Size = new System.Drawing.Size(41, 24);
			this.butRedo.TabIndex = 164;
			this.butRedo.Text = "Redo";
			this.butRedo.Click += new System.EventHandler(this.butRedo_Click);
			this.butRedo.MouseEnter += new System.EventHandler(this.butRedo_MouseEnter);
			this.butRedo.MouseLeave += new System.EventHandler(this.butRedo_MouseLeave);
			// 
			// butColor
			// 
			this.butColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butColor.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butColor.Location = new System.Drawing.Point(600, -3);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(26, 24);
			this.butColor.TabIndex = 161;
			this.butColor.Text = "A";
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			this.butColor.MouseEnter += new System.EventHandler(this.butColor_MouseEnter);
			this.butColor.MouseLeave += new System.EventHandler(this.butColor_MouseLeave);
			// 
			// butUnderline
			// 
			this.butUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butUnderline.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butUnderline.Location = new System.Drawing.Point(291, -3);
			this.butUnderline.Name = "butUnderline";
			this.butUnderline.Size = new System.Drawing.Size(23, 24);
			this.butUnderline.TabIndex = 166;
			this.butUnderline.Text = "U";
			this.butUnderline.Click += new System.EventHandler(this.butUnderline_Click);
			this.butUnderline.MouseEnter += new System.EventHandler(this.butUnderline_MouseEnter);
			this.butUnderline.MouseLeave += new System.EventHandler(this.butUnderline_MouseLeave);
			// 
			// butItalics
			// 
			this.butItalics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butItalics.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butItalics.Location = new System.Drawing.Point(268, -3);
			this.butItalics.Name = "butItalics";
			this.butItalics.Size = new System.Drawing.Size(23, 24);
			this.butItalics.TabIndex = 164;
			this.butItalics.Text = "I";
			this.butItalics.Click += new System.EventHandler(this.butItalics_Click);
			this.butItalics.MouseEnter += new System.EventHandler(this.butItalics_MouseEnter);
			this.butItalics.MouseLeave += new System.EventHandler(this.butItalics_MouseLeave);
			// 
			// butPaste
			// 
			this.butPaste.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butPaste.Image = global::OpenDental.Properties.Resources.butPaste;
			this.butPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPaste.Location = new System.Drawing.Point(101, -3);
			this.butPaste.Name = "butPaste";
			this.butPaste.Size = new System.Drawing.Size(62, 24);
			this.butPaste.TabIndex = 164;
			this.butPaste.Text = "Paste";
			this.butPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butPaste.Click += new System.EventHandler(this.butPaste_Click);
			this.butPaste.MouseEnter += new System.EventHandler(this.butPaste_MouseEnter);
			this.butPaste.MouseLeave += new System.EventHandler(this.butPaste_MouseLeave);
			// 
			// butBold
			// 
			this.butBold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBold.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butBold.Location = new System.Drawing.Point(245, -3);
			this.butBold.Name = "butBold";
			this.butBold.Size = new System.Drawing.Size(23, 24);
			this.butBold.TabIndex = 163;
			this.butBold.Text = "B";
			this.butBold.Click += new System.EventHandler(this.butBold_Click);
			this.butBold.MouseEnter += new System.EventHandler(this.butBold_MouseEnter);
			this.butBold.MouseLeave += new System.EventHandler(this.butBold_MouseLeave);
			// 
			// butUndo
			// 
			this.butUndo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butUndo.Location = new System.Drawing.Point(163, -3);
			this.butUndo.Name = "butUndo";
			this.butUndo.Size = new System.Drawing.Size(41, 24);
			this.butUndo.TabIndex = 163;
			this.butUndo.Text = "Undo";
			this.butUndo.Click += new System.EventHandler(this.butUndo_Click);
			this.butUndo.MouseEnter += new System.EventHandler(this.butUndo_MouseEnter);
			this.butUndo.MouseLeave += new System.EventHandler(this.butUndo_MouseLeave);
			// 
			// textDescription
			// 
			this.textDescription.AcceptsTab = true;
			this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textDescription.BackColor = System.Drawing.SystemColors.Window;
			this.textDescription.DetectUrls = false;
			this.textDescription.HideSelection = false;
			this.textDescription.Location = new System.Drawing.Point(-1, 20);
			this.textDescription.Name = "textDescription";
			this.textDescription.QuickPasteType = OpenDentBusiness.QuickPasteType.None;
			this.textDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textDescription.Size = new System.Drawing.Size(975, 335);
			this.textDescription.TabIndex = 11;
			this.textDescription.Text = "";
			// 
			// butCopy
			// 
			this.butCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butCopy.Image = global::OpenDental.Properties.Resources.butCopy;
			this.butCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCopy.Location = new System.Drawing.Point(41, -3);
			this.butCopy.Name = "butCopy";
			this.butCopy.Size = new System.Drawing.Size(60, 24);
			this.butCopy.TabIndex = 163;
			this.butCopy.Text = "Copy";
			this.butCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
			this.butCopy.MouseEnter += new System.EventHandler(this.butCopy_MouseEnter);
			this.butCopy.MouseLeave += new System.EventHandler(this.butCopy_MouseLeave);
			// 
			// butCut
			// 
			this.butCut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butCut.Location = new System.Drawing.Point(0, -3);
			this.butCut.Name = "butCut";
			this.butCut.Size = new System.Drawing.Size(41, 24);
			this.butCut.TabIndex = 162;
			this.butCut.Text = "Cut";
			this.butCut.Click += new System.EventHandler(this.butCut_Click);
			this.butCut.MouseEnter += new System.EventHandler(this.butCut_MouseEnter);
			this.butCut.MouseLeave += new System.EventHandler(this.butCut_MouseLeave);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.gridLinks);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(389, 198);
			this.panel3.TabIndex = 157;
			// 
			// gridLinks
			// 
			this.gridLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridLinks.HasMultilineHeaders = false;
			this.gridLinks.HScrollVisible = false;
			this.gridLinks.Location = new System.Drawing.Point(1, 1);
			this.gridLinks.Name = "gridLinks";
			this.gridLinks.ScrollValue = 0;
			this.gridLinks.Size = new System.Drawing.Size(386, 195);
			this.gridLinks.TabIndex = 154;
			this.gridLinks.TabStop = false;
			this.gridLinks.Title = "Links";
			this.gridLinks.TranslationName = null;
			this.gridLinks.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridLinks_CellDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.gridNotes);
			this.panel2.Location = new System.Drawing.Point(394, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(582, 192);
			this.panel2.TabIndex = 156;
			// 
			// gridNotes
			// 
			this.gridNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridNotes.HasMultilineHeaders = false;
			this.gridNotes.HScrollVisible = false;
			this.gridNotes.Location = new System.Drawing.Point(1, 1);
			this.gridNotes.Name = "gridNotes";
			this.gridNotes.ScrollValue = 0;
			this.gridNotes.Size = new System.Drawing.Size(579, 189);
			this.gridNotes.TabIndex = 150;
			this.gridNotes.Title = "Notes";
			this.gridNotes.TranslationName = "FormTaskEdit";
			this.gridNotes.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridNotes_CellDoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.butAddNote);
			this.panel1.Controls.Add(this.groupAddLink);
			this.panel1.Controls.Add(this.butRemove);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 198);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(976, 58);
			this.panel1.TabIndex = 155;
			// 
			// groupAddLink
			// 
			this.groupAddLink.Controls.Add(this.butLinkQuote);
			this.groupAddLink.Controls.Add(this.butLinkTask);
			this.groupAddLink.Controls.Add(this.butLinkFeatReq);
			this.groupAddLink.Controls.Add(this.butLinkBug);
			this.groupAddLink.Location = new System.Drawing.Point(121, 3);
			this.groupAddLink.Name = "groupAddLink";
			this.groupAddLink.Size = new System.Drawing.Size(270, 51);
			this.groupAddLink.TabIndex = 152;
			this.groupAddLink.TabStop = false;
			this.groupAddLink.Text = "Add Link";
			// 
			// butLinkQuote
			// 
			this.butLinkQuote.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLinkQuote.Autosize = true;
			this.butLinkQuote.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLinkQuote.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLinkQuote.CornerRadius = 4F;
			this.butLinkQuote.Location = new System.Drawing.Point(200, 19);
			this.butLinkQuote.Name = "butLinkQuote";
			this.butLinkQuote.Size = new System.Drawing.Size(60, 22);
			this.butLinkQuote.TabIndex = 3;
			this.butLinkQuote.Text = "Quote";
			this.butLinkQuote.Click += new System.EventHandler(this.butLinkQuote_Click);
			// 
			// butLinkTask
			// 
			this.butLinkTask.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLinkTask.Autosize = true;
			this.butLinkTask.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLinkTask.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLinkTask.CornerRadius = 4F;
			this.butLinkTask.Location = new System.Drawing.Point(6, 19);
			this.butLinkTask.Name = "butLinkTask";
			this.butLinkTask.Size = new System.Drawing.Size(60, 22);
			this.butLinkTask.TabIndex = 0;
			this.butLinkTask.Text = "Task";
			this.butLinkTask.Click += new System.EventHandler(this.butLinkTask_Click);
			// 
			// butLinkFeatReq
			// 
			this.butLinkFeatReq.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLinkFeatReq.Autosize = true;
			this.butLinkFeatReq.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLinkFeatReq.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLinkFeatReq.CornerRadius = 4F;
			this.butLinkFeatReq.Location = new System.Drawing.Point(70, 19);
			this.butLinkFeatReq.Name = "butLinkFeatReq";
			this.butLinkFeatReq.Size = new System.Drawing.Size(62, 22);
			this.butLinkFeatReq.TabIndex = 1;
			this.butLinkFeatReq.Text = "Feat. Req.";
			this.butLinkFeatReq.Click += new System.EventHandler(this.butLinkFeatReq_Click);
			// 
			// butLinkBug
			// 
			this.butLinkBug.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLinkBug.Autosize = true;
			this.butLinkBug.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLinkBug.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLinkBug.CornerRadius = 4F;
			this.butLinkBug.Enabled = false;
			this.butLinkBug.Location = new System.Drawing.Point(136, 19);
			this.butLinkBug.Name = "butLinkBug";
			this.butLinkBug.Size = new System.Drawing.Size(60, 22);
			this.butLinkBug.TabIndex = 2;
			this.butLinkBug.Text = "Bug";
			this.butLinkBug.Click += new System.EventHandler(this.butLinkBug_Click);
			// 
			// butRemove
			// 
			this.butRemove.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butRemove.Autosize = true;
			this.butRemove.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butRemove.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butRemove.CornerRadius = 4F;
			this.butRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butRemove.Location = new System.Drawing.Point(5, 22);
			this.butRemove.Name = "butRemove";
			this.butRemove.Size = new System.Drawing.Size(75, 24);
			this.butRemove.TabIndex = 153;
			this.butRemove.Text = "Remove";
			this.butRemove.Click += new System.EventHandler(this.butLinkRemove_Click);
			// 
			// tabControlMain
			// 
			this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlMain.Controls.Add(this.tabMain);
			this.tabControlMain.Controls.Add(this.tabReviews);
			this.tabControlMain.Controls.Add(this.tabHistory);
			this.tabControlMain.Location = new System.Drawing.Point(283, 4);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(986, 666);
			this.tabControlMain.TabIndex = 158;
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.splitDescriptNotes);
			this.tabMain.Location = new System.Drawing.Point(4, 22);
			this.tabMain.Name = "tabMain";
			this.tabMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabMain.Size = new System.Drawing.Size(978, 640);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Main";
			this.tabMain.UseVisualStyleBackColor = true;
			// 
			// tabReviews
			// 
			this.tabReviews.Controls.Add(this.gridReview);
			this.tabReviews.Controls.Add(this.butAddReview);
			this.tabReviews.Location = new System.Drawing.Point(4, 22);
			this.tabReviews.Name = "tabReviews";
			this.tabReviews.Padding = new System.Windows.Forms.Padding(3);
			this.tabReviews.Size = new System.Drawing.Size(978, 640);
			this.tabReviews.TabIndex = 2;
			this.tabReviews.Text = "Reviews";
			this.tabReviews.UseVisualStyleBackColor = true;
			// 
			// gridReview
			// 
			this.gridReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridReview.HasMultilineHeaders = false;
			this.gridReview.HScrollVisible = false;
			this.gridReview.Location = new System.Drawing.Point(0, 0);
			this.gridReview.Name = "gridReview";
			this.gridReview.ScrollValue = 0;
			this.gridReview.Size = new System.Drawing.Size(978, 607);
			this.gridReview.TabIndex = 21;
			this.gridReview.TabStop = false;
			this.gridReview.Title = "Reviews";
			this.gridReview.TranslationName = null;
			this.gridReview.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridReview_CellDoubleClick);
			// 
			// butAddReview
			// 
			this.butAddReview.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAddReview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.butAddReview.Autosize = true;
			this.butAddReview.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAddReview.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAddReview.CornerRadius = 4F;
			this.butAddReview.Image = global::OpenDental.Properties.Resources.Add;
			this.butAddReview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAddReview.Location = new System.Drawing.Point(452, 613);
			this.butAddReview.Name = "butAddReview";
			this.butAddReview.Size = new System.Drawing.Size(75, 24);
			this.butAddReview.TabIndex = 20;
			this.butAddReview.Text = "Add";
			this.butAddReview.Click += new System.EventHandler(this.butAddReview_Click);
			// 
			// tabHistory
			// 
			this.tabHistory.Controls.Add(this.gridHistory);
			this.tabHistory.Location = new System.Drawing.Point(4, 22);
			this.tabHistory.Name = "tabHistory";
			this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
			this.tabHistory.Size = new System.Drawing.Size(978, 640);
			this.tabHistory.TabIndex = 3;
			this.tabHistory.Text = "History";
			this.tabHistory.UseVisualStyleBackColor = true;
			// 
			// gridHistory
			// 
			this.gridHistory.HasMultilineHeaders = false;
			this.gridHistory.HScrollVisible = false;
			this.gridHistory.Location = new System.Drawing.Point(0, 0);
			this.gridHistory.Name = "gridHistory";
			this.gridHistory.ScrollValue = 0;
			this.gridHistory.Size = new System.Drawing.Size(523, 295);
			this.gridHistory.TabIndex = 19;
			this.gridHistory.TabStop = false;
			this.gridHistory.Title = "History Events";
			this.gridHistory.TranslationName = null;
			this.gridHistory.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridHistory_CellDoubleClick);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(0, 116);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 20);
			this.label9.TabIndex = 189;
			this.label9.Text = "Prev. Owner";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(68, 116);
			this.textBox1.MaxLength = 100;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(183, 20);
			this.textBox1.TabIndex = 190;
			this.textBox1.TabStop = false;
			// 
			// comboStatus
			// 
			this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatus.Enabled = false;
			this.comboStatus.FormattingEnabled = true;
			this.comboStatus.Location = new System.Drawing.Point(68, 194);
			this.comboStatus.Name = "comboStatus";
			this.comboStatus.Size = new System.Drawing.Size(183, 21);
			this.comboStatus.TabIndex = 188;
			// 
			// butExpertPick
			// 
			this.butExpertPick.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butExpertPick.Autosize = true;
			this.butExpertPick.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butExpertPick.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butExpertPick.CornerRadius = 4F;
			this.butExpertPick.Location = new System.Drawing.Point(228, 142);
			this.butExpertPick.Name = "butExpertPick";
			this.butExpertPick.Size = new System.Drawing.Size(23, 21);
			this.butExpertPick.TabIndex = 187;
			this.butExpertPick.Text = "...";
			this.butExpertPick.Visible = false;
			// 
			// butOwnerPick
			// 
			this.butOwnerPick.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOwnerPick.Autosize = true;
			this.butOwnerPick.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOwnerPick.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOwnerPick.CornerRadius = 4F;
			this.butOwnerPick.Location = new System.Drawing.Point(228, 167);
			this.butOwnerPick.Name = "butOwnerPick";
			this.butOwnerPick.Size = new System.Drawing.Size(23, 21);
			this.butOwnerPick.TabIndex = 186;
			this.butOwnerPick.Text = "...";
			this.butOwnerPick.Visible = false;
			// 
			// textActualHours
			// 
			this.textActualHours.Location = new System.Drawing.Point(68, 327);
			this.textActualHours.MaxVal = 255;
			this.textActualHours.MinVal = 0;
			this.textActualHours.Name = "textActualHours";
			this.textActualHours.Size = new System.Drawing.Size(46, 20);
			this.textActualHours.TabIndex = 185;
			// 
			// textEstHours
			// 
			this.textEstHours.Location = new System.Drawing.Point(68, 301);
			this.textEstHours.MaxVal = 255;
			this.textEstHours.MinVal = 0;
			this.textEstHours.Name = "textEstHours";
			this.textEstHours.Size = new System.Drawing.Size(46, 20);
			this.textEstHours.TabIndex = 184;
			// 
			// groupActions
			// 
			this.groupActions.Controls.Add(this.butAction2);
			this.groupActions.Controls.Add(this.butAction3);
			this.groupActions.Controls.Add(this.butAction4);
			this.groupActions.Controls.Add(this.butAction1);
			this.groupActions.Location = new System.Drawing.Point(67, 353);
			this.groupActions.Name = "groupActions";
			this.groupActions.Size = new System.Drawing.Size(174, 143);
			this.groupActions.TabIndex = 183;
			this.groupActions.TabStop = false;
			this.groupActions.Text = "Job Actions";
			// 
			// butAction2
			// 
			this.butAction2.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAction2.Autosize = true;
			this.butAction2.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAction2.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAction2.CornerRadius = 4F;
			this.butAction2.Location = new System.Drawing.Point(16, 51);
			this.butAction2.Name = "butAction2";
			this.butAction2.Size = new System.Drawing.Size(145, 24);
			this.butAction2.TabIndex = 0;
			this.butAction2.Text = "Action 2";
			// 
			// butAction3
			// 
			this.butAction3.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAction3.Autosize = true;
			this.butAction3.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAction3.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAction3.CornerRadius = 4F;
			this.butAction3.Location = new System.Drawing.Point(16, 81);
			this.butAction3.Name = "butAction3";
			this.butAction3.Size = new System.Drawing.Size(145, 24);
			this.butAction3.TabIndex = 18;
			this.butAction3.Text = "Action 3";
			// 
			// butAction4
			// 
			this.butAction4.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAction4.Autosize = true;
			this.butAction4.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAction4.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAction4.CornerRadius = 4F;
			this.butAction4.Location = new System.Drawing.Point(16, 111);
			this.butAction4.Name = "butAction4";
			this.butAction4.Size = new System.Drawing.Size(145, 24);
			this.butAction4.TabIndex = 14;
			this.butAction4.Text = "Action 4";
			// 
			// butAction1
			// 
			this.butAction1.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAction1.Autosize = true;
			this.butAction1.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAction1.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAction1.CornerRadius = 4F;
			this.butAction1.Location = new System.Drawing.Point(16, 21);
			this.butAction1.Name = "butAction1";
			this.butAction1.Size = new System.Drawing.Size(145, 24);
			this.butAction1.TabIndex = 19;
			this.butAction1.Text = "Action 1";
			// 
			// butOverride
			// 
			this.butOverride.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOverride.Autosize = true;
			this.butOverride.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOverride.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOverride.CornerRadius = 4F;
			this.butOverride.Location = new System.Drawing.Point(83, 502);
			this.butOverride.Name = "butOverride";
			this.butOverride.Size = new System.Drawing.Size(145, 24);
			this.butOverride.TabIndex = 154;
			this.butOverride.Text = "Override";
			this.butOverride.Visible = false;
			this.butOverride.Click += new System.EventHandler(this.butOverride_Click);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(3, 64);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 20);
			this.label12.TabIndex = 182;
			this.label12.Text = "Title";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textTitle
			// 
			this.textTitle.Location = new System.Drawing.Point(68, 64);
			this.textTitle.MaxLength = 255;
			this.textTitle.Name = "textTitle";
			this.textTitle.Size = new System.Drawing.Size(183, 20);
			this.textTitle.TabIndex = 181;
			// 
			// comboCategory
			// 
			this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCategory.FormattingEnabled = true;
			this.comboCategory.Location = new System.Drawing.Point(68, 248);
			this.comboCategory.Name = "comboCategory";
			this.comboCategory.Size = new System.Drawing.Size(183, 21);
			this.comboCategory.TabIndex = 178;
			// 
			// comboPriority
			// 
			this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPriority.FormattingEnabled = true;
			this.comboPriority.Location = new System.Drawing.Point(68, 221);
			this.comboPriority.Name = "comboPriority";
			this.comboPriority.Size = new System.Drawing.Size(183, 21);
			this.comboPriority.TabIndex = 177;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(3, 168);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 20);
			this.label11.TabIndex = 175;
			this.label11.Text = "Owner";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textOwner
			// 
			this.textOwner.Location = new System.Drawing.Point(68, 168);
			this.textOwner.MaxLength = 100;
			this.textOwner.Name = "textOwner";
			this.textOwner.ReadOnly = true;
			this.textOwner.Size = new System.Drawing.Size(160, 20);
			this.textOwner.TabIndex = 176;
			this.textOwner.TabStop = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(3, 90);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 20);
			this.label10.TabIndex = 161;
			this.label10.Text = "Date Entry";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDateEntry
			// 
			this.textDateEntry.Location = new System.Drawing.Point(68, 90);
			this.textDateEntry.MaxLength = 100;
			this.textDateEntry.Name = "textDateEntry";
			this.textDateEntry.ReadOnly = true;
			this.textDateEntry.Size = new System.Drawing.Size(183, 20);
			this.textDateEntry.TabIndex = 172;
			this.textDateEntry.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 327);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 20);
			this.label8.TabIndex = 171;
			this.label8.Text = "Act. Hours";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(2, 302);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 20);
			this.label7.TabIndex = 170;
			this.label7.Text = "Est Hours";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textVersion
			// 
			this.textVersion.Location = new System.Drawing.Point(68, 275);
			this.textVersion.MaxLength = 100;
			this.textVersion.Name = "textVersion";
			this.textVersion.Size = new System.Drawing.Size(183, 20);
			this.textVersion.TabIndex = 179;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 276);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 20);
			this.label6.TabIndex = 169;
			this.label6.Text = "Version";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 194);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 20);
			this.label5.TabIndex = 168;
			this.label5.Text = "Status";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 249);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 20);
			this.label4.TabIndex = 167;
			this.label4.Text = "Category";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 222);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 20);
			this.label3.TabIndex = 166;
			this.label3.Text = "Priority";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butProjectPick
			// 
			this.butProjectPick.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butProjectPick.Autosize = false;
			this.butProjectPick.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butProjectPick.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butProjectPick.CornerRadius = 2F;
			this.butProjectPick.Location = new System.Drawing.Point(228, 38);
			this.butProjectPick.Name = "butProjectPick";
			this.butProjectPick.Size = new System.Drawing.Size(23, 21);
			this.butProjectPick.TabIndex = 180;
			this.butProjectPick.Text = "...";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 165;
			this.label2.Text = "Project";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textProject
			// 
			this.textProject.Location = new System.Drawing.Point(68, 38);
			this.textProject.MaxLength = 255;
			this.textProject.Name = "textProject";
			this.textProject.ReadOnly = true;
			this.textProject.Size = new System.Drawing.Size(160, 20);
			this.textProject.TabIndex = 164;
			this.textProject.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 141);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 20);
			this.label1.TabIndex = 163;
			this.label1.Text = "Expert";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textExpert
			// 
			this.textExpert.Location = new System.Drawing.Point(68, 142);
			this.textExpert.MaxLength = 100;
			this.textExpert.Name = "textExpert";
			this.textExpert.ReadOnly = true;
			this.textExpert.Size = new System.Drawing.Size(160, 20);
			this.textExpert.TabIndex = 162;
			this.textExpert.TabStop = false;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(3, 12);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(63, 20);
			this.label19.TabIndex = 173;
			this.label19.Text = "JobNum";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textJobNum
			// 
			this.textJobNum.Location = new System.Drawing.Point(68, 12);
			this.textJobNum.MaxLength = 100;
			this.textJobNum.Name = "textJobNum";
			this.textJobNum.ReadOnly = true;
			this.textJobNum.Size = new System.Drawing.Size(73, 20);
			this.textJobNum.TabIndex = 174;
			this.textJobNum.TabStop = false;
			// 
			// FormJobEdit
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1281, 714);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboStatus);
			this.Controls.Add(this.butExpertPick);
			this.Controls.Add(this.butOverride);
			this.Controls.Add(this.butOwnerPick);
			this.Controls.Add(this.textActualHours);
			this.Controls.Add(this.textEstHours);
			this.Controls.Add(this.groupActions);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textTitle);
			this.Controls.Add(this.comboCategory);
			this.Controls.Add(this.comboPriority);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textOwner);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textDateEntry);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textVersion);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.butProjectPick);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textProject);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textExpert);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.textJobNum);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butDelete);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1297, 752);
			this.Name = "FormJobEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Job Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJobEdit_FormClosing);
			this.Load += new System.EventHandler(this.FormJobEdit_Load);
			this.splitDescriptNotes.Panel1.ResumeLayout(false);
			this.splitDescriptNotes.Panel1.PerformLayout();
			this.splitDescriptNotes.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitDescriptNotes)).EndInit();
			this.splitDescriptNotes.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupAddLink.ResumeLayout(false);
			this.tabControlMain.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tabReviews.ResumeLayout(false);
			this.tabHistory.ResumeLayout(false);
			this.groupActions.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butOK;
		private OpenDental.UI.Button butCancel;
		private UI.Button butDelete;
		private ODtextBox textDescription;
		private UI.ODGrid gridNotes;
		private UI.Button butAddNote;
		private System.Windows.Forms.SplitContainer splitDescriptNotes;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.TabPage tabReviews;
		private System.Windows.Forms.TabPage tabHistory;
		private UI.ODGrid gridHistory;
		private UI.ODGrid gridReview;
		private UI.Button butAddReview;
		private System.Windows.Forms.Button butColor;
		private System.Windows.Forms.Button butCut;
		private System.Windows.Forms.Button butCopy;
		private System.Windows.Forms.Button butPaste;
		private System.Windows.Forms.ComboBox comboFontSize;
		private System.Windows.Forms.Button butHighlightSelect;
		private System.Windows.Forms.ComboBox comboFontType;
		private System.Windows.Forms.Button butColorSelect;
		private System.Windows.Forms.Button butHighlight;
		private System.Windows.Forms.Button butFont;
		private System.Windows.Forms.Button butBullet;
		private System.Windows.Forms.Button butStrikeout;
		private System.Windows.Forms.Button butRedo;
		private System.Windows.Forms.Button butUnderline;
		private System.Windows.Forms.Button butItalics;
		private System.Windows.Forms.Button butBold;
		private System.Windows.Forms.Button butUndo;
		private UI.ODGrid gridLinks;
		private System.Windows.Forms.GroupBox groupAddLink;
		private UI.Button butLinkQuote;
		private UI.Button butLinkTask;
		private UI.Button butLinkFeatReq;
		private UI.Button butLinkBug;
		private UI.Button butRemove;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboStatus;
		private UI.Button butExpertPick;
		private UI.Button butOwnerPick;
		private ValidNumber textActualHours;
		private ValidNumber textEstHours;
		private System.Windows.Forms.GroupBox groupActions;
		private UI.Button butAction2;
		private UI.Button butAction3;
		private UI.Button butAction4;
		private UI.Button butAction1;
		private UI.Button butOverride;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textTitle;
		private System.Windows.Forms.ComboBox comboCategory;
		private System.Windows.Forms.ComboBox comboPriority;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textOwner;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textDateEntry;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textVersion;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private UI.Button butProjectPick;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textExpert;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox textJobNum;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelWarning;
	}
}