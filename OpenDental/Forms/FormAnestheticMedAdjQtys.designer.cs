namespace OpenDental{
	partial class FormAnestheticMedsAdjQtys
	{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnestheticMedsAdjQtys));
			this.gridAnesthMedsAdjQtys = new System.Windows.Forms.DataGridView();
			this.labelAdjustQtys = new System.Windows.Forms.Label();
			this.groupBoxAdjQtys = new System.Windows.Forms.GroupBox();
			this.button1 = new OpenDental.UI.Button();
			this.butClose = new OpenDental.UI.Button();
			this.AnestheticMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.HowSupplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QtyOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QtyAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridAnesthMedsAdjQtys)).BeginInit();
			this.groupBoxAdjQtys.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridAnesthMedsAdjQtys
			// 
			this.gridAnesthMedsAdjQtys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridAnesthMedsAdjQtys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnestheticMed,
            this.HowSupplied,
            this.QtyOnHand,
            this.QtyAdjustment,
            this.Notes});
			this.gridAnesthMedsAdjQtys.Location = new System.Drawing.Point(30, 66);
			this.gridAnesthMedsAdjQtys.Name = "gridAnesthMedsAdjQtys";
			this.gridAnesthMedsAdjQtys.Size = new System.Drawing.Size(803, 307);
			this.gridAnesthMedsAdjQtys.TabIndex = 4;
			this.gridAnesthMedsAdjQtys.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAnesthMeds_CellContentClick);
			// 
			// labelAdjustQtys
			// 
			this.labelAdjustQtys.AutoSize = true;
			this.labelAdjustQtys.Location = new System.Drawing.Point(28, 27);
			this.labelAdjustQtys.Name = "labelAdjustQtys";
			this.labelAdjustQtys.Size = new System.Drawing.Size(472, 13);
			this.labelAdjustQtys.TabIndex = 143;
			this.labelAdjustQtys.Text = "You may adjust quantities by entering positive or negative values in the \"Quantit" +
				"y Adjustment\" Field";
			// 
			// groupBoxAdjQtys
			// 
			this.groupBoxAdjQtys.Controls.Add(this.labelAdjustQtys);
			this.groupBoxAdjQtys.Controls.Add(this.button1);
			this.groupBoxAdjQtys.Controls.Add(this.butClose);
			this.groupBoxAdjQtys.Location = new System.Drawing.Point(12, 12);
			this.groupBoxAdjQtys.Name = "groupBoxAdjQtys";
			this.groupBoxAdjQtys.Size = new System.Drawing.Size(840, 431);
			this.groupBoxAdjQtys.TabIndex = 144;
			this.groupBoxAdjQtys.TabStop = false;
			this.groupBoxAdjQtys.Text = "Adjust Anesthetic Medication Inventory Quantities";
			// 
			// button1
			// 
			this.button1.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.button1.Autosize = true;
			this.button1.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.button1.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.button1.CornerRadius = 4F;
			this.button1.Image = global::OpenDental.Properties.Resources.deleteX;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(653, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(66, 26);
			this.button1.TabIndex = 141;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butClose.Location = new System.Drawing.Point(725, 380);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(90, 26);
			this.butClose.TabIndex = 142;
			this.butClose.Text = "Save and Close";
			this.butClose.UseVisualStyleBackColor = true;
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// AnestheticMed
			// 
			this.AnestheticMed.HeaderText = "Anesthetic medication";
			this.AnestheticMed.Name = "AnestheticMed";
			this.AnestheticMed.Width = 240;
			// 
			// HowSupplied
			// 
			this.HowSupplied.HeaderText = "How supplied";
			this.HowSupplied.Name = "HowSupplied";
			this.HowSupplied.Width = 160;
			// 
			// QtyOnHand
			// 
			this.QtyOnHand.HeaderText = "Quantity on hand";
			this.QtyOnHand.Name = "QtyOnHand";
			this.QtyOnHand.Width = 80;
			// 
			// QtyAdjustment
			// 
			this.QtyAdjustment.HeaderText = "Quantity Adjustment";
			this.QtyAdjustment.Name = "QtyAdjustment";
			this.QtyAdjustment.Width = 80;
			// 
			// Notes
			// 
			this.Notes.HeaderText = "Notes";
			this.Notes.Name = "Notes";
			this.Notes.Width = 200;
			// 
			// FormAnestheticMedsAdjQtys
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(864, 479);
			this.Controls.Add(this.gridAnesthMedsAdjQtys);
			this.Controls.Add(this.groupBoxAdjQtys);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormAnestheticMedsAdjQtys";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.BasicTemplate_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridAnesthMedsAdjQtys)).EndInit();
			this.groupBoxAdjQtys.ResumeLayout(false);
			this.groupBoxAdjQtys.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridAnesthMedsAdjQtys;
		private OpenDental.UI.Button butClose;
		private OpenDental.UI.Button button1;
		private System.Windows.Forms.Label labelAdjustQtys;
		private System.Windows.Forms.GroupBox groupBoxAdjQtys;
		private System.Windows.Forms.DataGridViewTextBoxColumn AnestheticMed;
		private System.Windows.Forms.DataGridViewTextBoxColumn HowSupplied;
		private System.Windows.Forms.DataGridViewTextBoxColumn QtyOnHand;
		private System.Windows.Forms.DataGridViewTextBoxColumn QtyAdjustment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
	}
}