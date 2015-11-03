namespace OpenDental{
	partial class FormLanguageAndRegion {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLanguageAndRegion));
			this.butOK = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.textBoxDescript = new System.Windows.Forms.TextBox();
			this.textLanguageAndRegion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboLanguageAndRegion = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(385, 177);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 3;
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
			this.butCancel.Location = new System.Drawing.Point(304, 177);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 2;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// textBoxDescript
			// 
			this.textBoxDescript.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxDescript.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxDescript.Location = new System.Drawing.Point(36, 12);
			this.textBoxDescript.Multiline = true;
			this.textBoxDescript.Name = "textBoxDescript";
			this.textBoxDescript.Size = new System.Drawing.Size(402, 47);
			this.textBoxDescript.TabIndex = 5;
			this.textBoxDescript.Text = "Set language and region setting to display appropriate windows and translations t" +
    "hroughout the program.";
			// 
			// textLanguageAndRegion
			// 
			this.textLanguageAndRegion.Location = new System.Drawing.Point(189, 90);
			this.textLanguageAndRegion.Name = "textLanguageAndRegion";
			this.textLanguageAndRegion.ReadOnly = true;
			this.textLanguageAndRegion.Size = new System.Drawing.Size(212, 20);
			this.textLanguageAndRegion.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(12, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 17);
			this.label1.TabIndex = 17;
			this.label1.Text = "Current Settings";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboLanguageAndRegion
			// 
			this.comboLanguageAndRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLanguageAndRegion.Location = new System.Drawing.Point(189, 116);
			this.comboLanguageAndRegion.Name = "comboLanguageAndRegion";
			this.comboLanguageAndRegion.Size = new System.Drawing.Size(212, 21);
			this.comboLanguageAndRegion.TabIndex = 105;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(12, 117);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(177, 16);
			this.label14.TabIndex = 106;
			this.label14.Text = "New Language and Region";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// FormLanguageAndRegion
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(472, 213);
			this.Controls.Add(this.comboLanguageAndRegion);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textLanguageAndRegion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxDescript);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.butCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(100, 100);
			this.Name = "FormLanguageAndRegion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Language and Region Settings";
			this.Load += new System.EventHandler(this.FormLanguageAndRegion_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butOK;
		private UI.Button butCancel;
		private System.Windows.Forms.TextBox textBoxDescript;
		private System.Windows.Forms.TextBox textLanguageAndRegion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboLanguageAndRegion;
		private System.Windows.Forms.Label label14;
	}
}