namespace OpenDental{
	partial class FormProgramLinkOutputFile {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgramLinkOutputFile));
			this.textPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.listFields = new System.Windows.Forms.ListBox();
			this.butOk = new OpenDental.UI.Button();
			this.textTemplate = new OpenDental.ODtextBox();
			this.butImport = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.SuspendLayout();
			// 
			// textPath
			// 
			this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textPath.Location = new System.Drawing.Point(114, 31);
			this.textPath.Name = "textPath";
			this.textPath.Size = new System.Drawing.Size(404, 20);
			this.textPath.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Output File Path";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(1, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Output Template";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(111, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(267, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "This form is for custom program links only.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listFields
			// 
			this.listFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listFields.FormattingEnabled = true;
			this.listFields.Location = new System.Drawing.Point(559, 57);
			this.listFields.Name = "listFields";
			this.listFields.Size = new System.Drawing.Size(267, 238);
			this.listFields.TabIndex = 12;
			this.listFields.Click += new System.EventHandler(this.listBoxFields_Click);
			// 
			// butOk
			// 
			this.butOk.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOk.Autosize = true;
			this.butOk.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOk.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOk.CornerRadius = 4F;
			this.butOk.Location = new System.Drawing.Point(751, 570);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(75, 24);
			this.butOk.TabIndex = 13;
			this.butOk.Text = "&OK";
			this.butOk.Click += new System.EventHandler(this.butOK_Click);
			// 
			// textTemplate
			// 
			this.textTemplate.AcceptsTab = true;
			this.textTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textTemplate.DetectUrls = false;
			this.textTemplate.Location = new System.Drawing.Point(114, 57);
			this.textTemplate.Name = "textTemplate";
			this.textTemplate.QuickPasteType = OpenDentBusiness.QuickPasteType.None;
			this.textTemplate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textTemplate.Size = new System.Drawing.Size(438, 506);
			this.textTemplate.TabIndex = 9;
			this.textTemplate.Text = "";
			// 
			// butImport
			// 
			this.butImport.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butImport.Autosize = true;
			this.butImport.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butImport.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butImport.CornerRadius = 4F;
			this.butImport.Location = new System.Drawing.Point(522, 29);
			this.butImport.Name = "butImport";
			this.butImport.Size = new System.Drawing.Size(29, 24);
			this.butImport.TabIndex = 6;
			this.butImport.Text = "...";
			this.butImport.UseVisualStyleBackColor = true;
			this.butImport.Click += new System.EventHandler(this.butImport_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.Location = new System.Drawing.Point(751, 600);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 2;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// FormProgramLinkOutputFile
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(838, 636);
			this.Controls.Add(this.butOk);
			this.Controls.Add(this.listFields);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textTemplate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butImport);
			this.Controls.Add(this.textPath);
			this.Controls.Add(this.butCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(854, 674);
			this.Name = "FormProgramLinkOutputFile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Program Link Output File";
			this.Load += new System.EventHandler(this.FormProgramLinkOutputFile_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butCancel;
		private UI.Button butImport;
		private System.Windows.Forms.TextBox textPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private ODtextBox textTemplate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listFields;
		private UI.Button butOk;
	}
}