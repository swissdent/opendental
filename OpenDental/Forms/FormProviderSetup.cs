using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public class FormProviderSetup:System.Windows.Forms.Form {
		private OpenDental.UI.Button butClose;
		private OpenDental.UI.Button butDown;
		private OpenDental.UI.Button butUp;
		private OpenDental.UI.Button butAdd;
		private System.ComponentModel.Container components = null;
		private OpenDental.UI.ODGrid gridMain;
		private GroupBox groupDentalSchools;
		private ComboBox comboClass;
		private Label label1;
		private bool changed;
		private OpenDental.UI.Button butCreateUsers;
		private GroupBox groupCreateUsers;
		private Label label3;
		private ComboBox comboUserGroup;
		private GroupBox groupMovePats;
		private Label label2;
		private UI.Button butMove;
		private UI.Button butReassign;
		private Label label5;
		private RadioButton radioInstructors;
		private RadioButton radioStudents;
		private RadioButton radioAll;
		private Label label4;
		private TextBox textName;
		private UI.Button butProvPick;
		private TextBox textMoveTo;
		//private User user;
		private DataTable table;
		///<summary>Set when prov picker button is used.  textMoveTo shows this prov in human readable format.</summary>
		private long _provNumMoveTo;

		///<summary>Not used for selection.  Use FormProviderPick or FormProviderMultiPick for that.</summary>
		public FormProviderSetup(){
			InitializeComponent();
			Lan.F(this);
			if(PrefC.GetBool(PrefName.EasyHideDentalSchools)) {
				this.Width=796;
			}
		}

		///<summary></summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}    

		#region Windows Form Designer generated code

		private void InitializeComponent(){
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProviderSetup));
			this.butClose = new OpenDental.UI.Button();
			this.butDown = new OpenDental.UI.Button();
			this.butUp = new OpenDental.UI.Button();
			this.butAdd = new OpenDental.UI.Button();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.groupDentalSchools = new System.Windows.Forms.GroupBox();
			this.comboClass = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.butCreateUsers = new OpenDental.UI.Button();
			this.groupCreateUsers = new System.Windows.Forms.GroupBox();
			this.comboUserGroup = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupMovePats = new System.Windows.Forms.GroupBox();
			this.butReassign = new OpenDental.UI.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.butMove = new OpenDental.UI.Button();
			this.radioAll = new System.Windows.Forms.RadioButton();
			this.radioStudents = new System.Windows.Forms.RadioButton();
			this.radioInstructors = new System.Windows.Forms.RadioButton();
			this.textName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textMoveTo = new System.Windows.Forms.TextBox();
			this.butProvPick = new OpenDental.UI.Button();
			this.groupDentalSchools.SuspendLayout();
			this.groupCreateUsers.SuspendLayout();
			this.groupMovePats.SuspendLayout();
			this.SuspendLayout();
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butClose.Location = new System.Drawing.Point(885, 665);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(82, 26);
			this.butClose.TabIndex = 3;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// butDown
			// 
			this.butDown.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butDown.Autosize = true;
			this.butDown.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDown.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDown.CornerRadius = 4F;
			this.butDown.Image = global::OpenDental.Properties.Resources.down;
			this.butDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDown.Location = new System.Drawing.Point(885, 450);
			this.butDown.Name = "butDown";
			this.butDown.Size = new System.Drawing.Size(82, 26);
			this.butDown.TabIndex = 12;
			this.butDown.Text = "&Down";
			this.butDown.Click += new System.EventHandler(this.butDown_Click);
			// 
			// butUp
			// 
			this.butUp.AdjustImageLocation = new System.Drawing.Point(0, 1);
			this.butUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butUp.Autosize = true;
			this.butUp.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butUp.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butUp.CornerRadius = 4F;
			this.butUp.Image = global::OpenDental.Properties.Resources.up;
			this.butUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butUp.Location = new System.Drawing.Point(885, 411);
			this.butUp.Name = "butUp";
			this.butUp.Size = new System.Drawing.Size(82, 26);
			this.butUp.TabIndex = 11;
			this.butUp.Text = "&Up";
			this.butUp.Click += new System.EventHandler(this.butUp_Click);
			// 
			// butAdd
			// 
			this.butAdd.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butAdd.Autosize = true;
			this.butAdd.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAdd.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAdd.CornerRadius = 4F;
			this.butAdd.Image = global::OpenDental.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(885, 522);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(82, 26);
			this.butAdd.TabIndex = 10;
			this.butAdd.Text = "&Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// gridMain
			// 
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.HScrollVisible = true;
			this.gridMain.Location = new System.Drawing.Point(7, 12);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.gridMain.Size = new System.Drawing.Size(688, 679);
			this.gridMain.TabIndex = 13;
			this.gridMain.Title = "Providers";
			this.gridMain.TranslationName = "TableProviderSetup";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// groupDentalSchools
			// 
			this.groupDentalSchools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupDentalSchools.Controls.Add(this.label4);
			this.groupDentalSchools.Controls.Add(this.textName);
			this.groupDentalSchools.Controls.Add(this.radioInstructors);
			this.groupDentalSchools.Controls.Add(this.radioStudents);
			this.groupDentalSchools.Controls.Add(this.radioAll);
			this.groupDentalSchools.Controls.Add(this.comboClass);
			this.groupDentalSchools.Controls.Add(this.label1);
			this.groupDentalSchools.Location = new System.Drawing.Point(703, 12);
			this.groupDentalSchools.Name = "groupDentalSchools";
			this.groupDentalSchools.Size = new System.Drawing.Size(273, 127);
			this.groupDentalSchools.TabIndex = 14;
			this.groupDentalSchools.TabStop = false;
			this.groupDentalSchools.Text = "Dental Schools";
			// 
			// comboClass
			// 
			this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClass.FormattingEnabled = true;
			this.comboClass.Location = new System.Drawing.Point(98, 19);
			this.comboClass.Name = "comboClass";
			this.comboClass.Size = new System.Drawing.Size(166, 21);
			this.comboClass.TabIndex = 0;
			this.comboClass.SelectionChangeCommitted += new System.EventHandler(this.comboClass_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 18);
			this.label1.TabIndex = 16;
			this.label1.Text = "Classes";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butCreateUsers
			// 
			this.butCreateUsers.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butCreateUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butCreateUsers.Autosize = true;
			this.butCreateUsers.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCreateUsers.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCreateUsers.CornerRadius = 4F;
			this.butCreateUsers.Location = new System.Drawing.Point(182, 42);
			this.butCreateUsers.Name = "butCreateUsers";
			this.butCreateUsers.Size = new System.Drawing.Size(82, 26);
			this.butCreateUsers.TabIndex = 15;
			this.butCreateUsers.Text = "Create";
			this.butCreateUsers.Click += new System.EventHandler(this.butCreateUsers_Click);
			// 
			// groupCreateUsers
			// 
			this.groupCreateUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCreateUsers.Controls.Add(this.comboUserGroup);
			this.groupCreateUsers.Controls.Add(this.label3);
			this.groupCreateUsers.Controls.Add(this.butCreateUsers);
			this.groupCreateUsers.Location = new System.Drawing.Point(703, 145);
			this.groupCreateUsers.Name = "groupCreateUsers";
			this.groupCreateUsers.Size = new System.Drawing.Size(273, 76);
			this.groupCreateUsers.TabIndex = 18;
			this.groupCreateUsers.TabStop = false;
			this.groupCreateUsers.Text = "Create Users";
			// 
			// comboUserGroup
			// 
			this.comboUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUserGroup.FormattingEnabled = true;
			this.comboUserGroup.Location = new System.Drawing.Point(98, 15);
			this.comboUserGroup.Name = "comboUserGroup";
			this.comboUserGroup.Size = new System.Drawing.Size(166, 21);
			this.comboUserGroup.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 18);
			this.label3.TabIndex = 18;
			this.label3.Text = "User Group";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupMovePats
			// 
			this.groupMovePats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupMovePats.Controls.Add(this.butProvPick);
			this.groupMovePats.Controls.Add(this.textMoveTo);
			this.groupMovePats.Controls.Add(this.butReassign);
			this.groupMovePats.Controls.Add(this.label5);
			this.groupMovePats.Controls.Add(this.label2);
			this.groupMovePats.Controls.Add(this.butMove);
			this.groupMovePats.Location = new System.Drawing.Point(703, 226);
			this.groupMovePats.Name = "groupMovePats";
			this.groupMovePats.Size = new System.Drawing.Size(273, 132);
			this.groupMovePats.TabIndex = 18;
			this.groupMovePats.TabStop = false;
			this.groupMovePats.Text = "Move Patients";
			// 
			// butReassign
			// 
			this.butReassign.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReassign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butReassign.Autosize = true;
			this.butReassign.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReassign.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReassign.CornerRadius = 4F;
			this.butReassign.Location = new System.Drawing.Point(182, 98);
			this.butReassign.Name = "butReassign";
			this.butReassign.Size = new System.Drawing.Size(82, 26);
			this.butReassign.TabIndex = 15;
			this.butReassign.Text = "Reassign";
			this.butReassign.Click += new System.EventHandler(this.butReassign_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 15);
			this.label5.TabIndex = 18;
			this.label5.Text = "Reassign by most-used provider";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 18);
			this.label2.TabIndex = 18;
			this.label2.Text = "To Provider";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butMove
			// 
			this.butMove.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butMove.Autosize = true;
			this.butMove.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butMove.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butMove.CornerRadius = 4F;
			this.butMove.Location = new System.Drawing.Point(182, 46);
			this.butMove.Name = "butMove";
			this.butMove.Size = new System.Drawing.Size(82, 26);
			this.butMove.TabIndex = 15;
			this.butMove.Text = "Move";
			this.butMove.Click += new System.EventHandler(this.butMove_Click);
			// 
			// radioAll
			// 
			this.radioAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioAll.Checked = true;
			this.radioAll.Location = new System.Drawing.Point(6, 46);
			this.radioAll.Name = "radioAll";
			this.radioAll.Size = new System.Drawing.Size(104, 18);
			this.radioAll.TabIndex = 17;
			this.radioAll.TabStop = true;
			this.radioAll.Text = "All";
			this.radioAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioAll.UseVisualStyleBackColor = true;
			// 
			// radioStudents
			// 
			this.radioStudents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioStudents.Location = new System.Drawing.Point(6, 63);
			this.radioStudents.Name = "radioStudents";
			this.radioStudents.Size = new System.Drawing.Size(104, 18);
			this.radioStudents.TabIndex = 18;
			this.radioStudents.Text = "Students";
			this.radioStudents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioStudents.UseVisualStyleBackColor = true;
			// 
			// radioInstructors
			// 
			this.radioInstructors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioInstructors.Location = new System.Drawing.Point(6, 80);
			this.radioInstructors.Name = "radioInstructors";
			this.radioInstructors.Size = new System.Drawing.Size(104, 18);
			this.radioInstructors.TabIndex = 19;
			this.radioInstructors.Text = "Instructors";
			this.radioInstructors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioInstructors.UseVisualStyleBackColor = true;
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(98, 101);
			this.textName.MaxLength = 15;
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(166, 20);
			this.textName.TabIndex = 20;
			this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 18);
			this.label4.TabIndex = 21;
			this.label4.Text = "Name";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textMoveTo
			// 
			this.textMoveTo.Location = new System.Drawing.Point(98, 19);
			this.textMoveTo.MaxLength = 15;
			this.textMoveTo.Name = "textMoveTo";
			this.textMoveTo.Size = new System.Drawing.Size(135, 20);
			this.textMoveTo.TabIndex = 22;
			// 
			// butProvPick
			// 
			this.butProvPick.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butProvPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butProvPick.Autosize = true;
			this.butProvPick.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butProvPick.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butProvPick.CornerRadius = 4F;
			this.butProvPick.Location = new System.Drawing.Point(237, 17);
			this.butProvPick.Name = "butProvPick";
			this.butProvPick.Size = new System.Drawing.Size(27, 26);
			this.butProvPick.TabIndex = 23;
			this.butProvPick.Text = "...";
			this.butProvPick.Click += new System.EventHandler(this.butProvPick_Click);
			// 
			// FormProviderSetup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butClose;
			this.ClientSize = new System.Drawing.Size(982, 707);
			this.Controls.Add(this.groupMovePats);
			this.Controls.Add(this.groupCreateUsers);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.butDown);
			this.Controls.Add(this.butUp);
			this.Controls.Add(this.groupDentalSchools);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormProviderSetup";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Provider Setup";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormProviderSelect_Closing);
			this.Load += new System.EventHandler(this.FormProviderSetup_Load);
			this.groupDentalSchools.ResumeLayout(false);
			this.groupDentalSchools.PerformLayout();
			this.groupCreateUsers.ResumeLayout(false);
			this.groupMovePats.ResumeLayout(false);
			this.groupMovePats.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void FormProviderSetup_Load(object sender, System.EventArgs e) {
			//There are two permissions which allow access to this window: Providers and AdminDentalStudents.  SecurityAdmin allows some extra functions.
			if(Security.IsAuthorized(Permissions.SecurityAdmin,true)){
				for(int i=0;i<UserGroups.List.Length;i++){
					comboUserGroup.Items.Add(UserGroups.List[i].Description);
				}
			}
			else{
				groupCreateUsers.Enabled=false;
				groupMovePats.Enabled=false;
			}
			if(PrefC.GetBool(PrefName.EasyHideDentalSchools)){
				groupDentalSchools.Visible=false;
			}
			else{
				comboClass.Items.Add(Lan.g(this,"All"));
				comboClass.SelectedIndex=0;
				for(int i=0;i<SchoolClasses.List.Length;i++){
					comboClass.Items.Add(SchoolClasses.GetDescript(SchoolClasses.List[i]));
				}
				butUp.Visible=false;
				butDown.Visible=false;
			}
			FillGrid();
		}

		private void FillGrid(){
			long selectedProvNum=0;
			if(gridMain.SelectedIndices.Length==1){
				selectedProvNum=PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString());
			}
			int scroll=gridMain.ScrollValue;
			Cache.Refresh(InvalidType.Providers);//this needs to go away for speed
			if(groupDentalSchools.Visible) {
				long schoolClass=0;
				if(comboClass.SelectedIndex>0) {
					schoolClass=SchoolClasses.List[comboClass.SelectedIndex-1].SchoolClassNum;
				}
				table=Providers.RefreshForDentalSchool(schoolClass);
			}
			else {
				table=Providers.RefreshStandard();
				//fix orders
				bool neededFixing=false;
				Provider prov;
				for(int i=0;i<table.Rows.Count;i++) {
					if(table.Rows[i]["ItemOrder"].ToString()!=i.ToString()) {
						prov=Providers.GetProv(PIn.Long(table.Rows[i]["ProvNum"].ToString()));
						prov.ItemOrder=i;
						Providers.Update(prov);
						neededFixing=true;
					}
				}
				if(neededFixing) {
					DataValid.SetInvalid(InvalidType.Providers);
					table=Providers.RefreshStandard();
				}
			}
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableProviderSetup","Abbrev"),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableProviderSetup","Last Name"),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableProviderSetup","First Name"),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableProviderSetup","User Name"),90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableProviderSetup","Hidden"),50,HorizontalAlignment.Center);
			gridMain.Columns.Add(col);
			if(!PrefC.GetBool(PrefName.EasyHideDentalSchools)) {
				col=new ODGridColumn(Lan.g("TableProviderSetup","Class"),100);
				gridMain.Columns.Add(col);
			}
			col=new ODGridColumn(Lan.g("TableProviderSetup","Patients"),50,HorizontalAlignment.Center);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<table.Rows.Count;i++){
				row=new ODGridRow();
				row.Cells.Add(table.Rows[i]["Abbr"].ToString());
				row.Cells.Add(table.Rows[i]["LName"].ToString());
				row.Cells.Add(table.Rows[i]["FName"].ToString());
				row.Cells.Add(table.Rows[i]["UserName"].ToString());
				if(table.Rows[i]["IsHidden"].ToString()=="1"){
					row.Cells.Add("X");
				}
				else{
					row.Cells.Add("");
				}
				if(!PrefC.GetBool(PrefName.EasyHideDentalSchools)) {
					if(table.Rows[i]["GradYear"].ToString()!=""){
						row.Cells.Add(table.Rows[i]["GradYear"].ToString()+"-"+table.Rows[i]["Descript"].ToString());
					}
					else{
						row.Cells.Add("");
					}
				}
				row.Cells.Add(table.Rows[i]["PatCount"].ToString());
				//row.Tag
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
			for(int i=0;i<table.Rows.Count;i++){
				if(table.Rows[i]["ProvNum"].ToString()==selectedProvNum.ToString()){
					gridMain.SetSelected(i,true);
					break;
				}
			}
			gridMain.ScrollValue=scroll;
		}

		private void comboClass_SelectionChangeCommitted(object sender,EventArgs e) {
			FillGrid();
		}

		private void textName_TextChanged(object sender,EventArgs e) {
			FillGrid();
		}

		private void butAdd_Click(object sender, System.EventArgs e) {
			FormProvEdit FormP=new FormProvEdit();
			FormP.ProvCur=new Provider();
			if(groupDentalSchools.Visible) {
				//don't worry about orders.
			}
			else {
				if(gridMain.SelectedIndices.Length>0) {//place new provider after the first selected index. No changes are made to DB until after provider is actually inserted.
					FormP.ProvCur.ItemOrder=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString())).ItemOrder;//now two with this itemorder
				}
				else {
					FormP.ProvCur.ItemOrder=Providers.GetProv(PIn.Long(table.Rows[gridMain.Rows.Count-1]["ProvNum"].ToString())).ItemOrder;
				}
			}
			if(groupDentalSchools.Visible && comboClass.SelectedIndex>0){
				FormP.ProvCur.SchoolClassNum=SchoolClasses.List[comboClass.SelectedIndex-1].SchoolClassNum;
			}
			FormP.IsNew=true;
			FormP.ShowDialog();
			if(FormP.DialogResult!=DialogResult.OK){
				return;
			}
			//new provider has already been inserted into DB from FormP.
			Providers.MoveDownBelow(FormP.ProvCur);//safe to run even if none selected.
			changed=true;
			FillGrid();
			gridMain.ScrollToEnd();//should change this to scroll to the same place as before.
			for(int i=0;i<table.Rows.Count;i++){//ProviderC.ListLong.Count;i++) {
				if(table.Rows[i]["ProvNum"].ToString()==FormP.ProvCur.ProvNum.ToString()){
					//ProviderC.ListLong[i].ProvNum==FormP.ProvCur.ProvNum) {
					gridMain.SetSelected(i,true);
					break;
				}
			}
		}

		///<summary>Won't be visible if using Dental Schools.  So list will be unfiltered and ItemOrders won't get messed up.</summary>
		private void butUp_Click(object sender, System.EventArgs e) {
			if(gridMain.SelectedIndices.Length!=1) {
				MsgBox.Show(this,"Please select exactly one provider first.");
				return;
			}
			if(gridMain.SelectedIndices[0]==0) {//already at top
				return;
			}
			Provider prov=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString()));
			Provider otherprov=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]-1]["ProvNum"].ToString()));
			prov.ItemOrder--;
			Providers.Update(prov);
			otherprov.ItemOrder++;
			Providers.Update(otherprov);
			changed=true;
			gridMain.SetSelected(false);
			FillGrid();
			gridMain.SetSelected(prov.ItemOrder,true);
		}

		///<summary>Won't be visible if using Dental Schools.  So list will be unfiltered and ItemOrders won't get messed up.</summary>
		private void butDown_Click(object sender, System.EventArgs e) {
			if(gridMain.SelectedIndices.Length!=1) {
				MsgBox.Show(this,"Please select exactly one provider first.");
				return;
			}
			if(gridMain.SelectedIndices[0]==ProviderC.ListLong.Count-1) {//already at bottom
				return;
			}
			Provider prov=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString()));
			Provider otherprov=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]+1]["ProvNum"].ToString()));
			prov.ItemOrder++;
			Providers.Update(prov);
			otherprov.ItemOrder--;
			Providers.Update(otherprov);
			changed=true;
			gridMain.SetSelected(false);
			FillGrid();
			gridMain.SetSelected(prov.ItemOrder,true);
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			FormProvEdit FormP=new FormProvEdit();
			FormP.ProvCur=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString()));
			FormP.ShowDialog();
			if(FormP.DialogResult!=DialogResult.OK) {
				return;
			}
			changed=true;
			FillGrid();
		}

		private void butProvPick_Click(object sender,EventArgs e) {
			//This button is used instead of a dropdown because the order of providers can frequently change in the grid.
			FormProviderPick formPick=new FormProviderPick();
			formPick.ShowDialog();
			if(formPick.DialogResult!=DialogResult.OK) {
				return;
			}
			_provNumMoveTo=formPick.SelectedProvNum;
			Provider provTo=Providers.GetProv(_provNumMoveTo);
			textMoveTo.Text=provTo.GetLongDesc();
		}

		///<summary>Not possible if no security admin.</summary>
		private void butMove_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length!=1) {
				MsgBox.Show(this,"You must select exactly one provider to move patients from.");
				return;
			}
			if(_provNumMoveTo==0){
				MsgBox.Show(this,"You must pick a provider in the box above to move patients to.");
				return;
			}			
			Provider provFrom=Providers.GetProv(PIn.Long(table.Rows[gridMain.SelectedIndices[0]]["ProvNum"].ToString()));
			Provider provTo=Providers.GetProv(_provNumMoveTo);
			string msg=Lan.g(this,"Move all patients from")+" "+provFrom.GetLongDesc()+" "+Lan.g(this,"to")+" "+provTo.GetLongDesc()+"?";
			if(MessageBox.Show(msg,"",MessageBoxButtons.OKCancel)==DialogResult.OK) {
				Patients.ChangeProviders(provFrom.ProvNum,provTo.ProvNum);
			}
			changed=true;
			FillGrid();
		}

		private void butReassign_Click(object sender,EventArgs e) {
			if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Ready to look for possible reassignments.  This will take a few minutes, and may make the program unresponsive on other computers during that time.  You will be given one more chance after this to cancel before changes are made to database.  Continue?")) {
				return;
			}
			Cursor=Cursors.WaitCursor;//On a very large database we have seen this take as long as 106 seconds.  The first loop takes about 80% of the time.
			List<long> provsFrom=new List<long>();
			for(int i=0;i<gridMain.SelectedIndices.Length;i++) {
				provsFrom.Add(PIn.Long(table.Rows[gridMain.SelectedIndices[i]]["ProvNum"].ToString()));
			}
			DataTable tablePats=Patients.GetPatsByPriProvs(provsFrom);//list of all patients who are using the selected providers.
			if(tablePats==null || table.Rows.Count==0) {
				Cursor=Cursors.Default;
				MsgBox.Show(this,"No patients to reassign.");
				return;
			}
			int countPatsToUpdate=0;
			List<long> mostUsedProvs=new List<long>();//1:1 relationship with table.
			for(int i=0;i<tablePats.Rows.Count;i++) {
				long provNumMostUsed=Patients.ReassignProvGetMostUsed(PIn.Long(tablePats.Rows[i]["PatNum"].ToString()));
				mostUsedProvs.Add(provNumMostUsed);
				if(mostUsedProvs[i]==0) {
					continue;
				}
				if(tablePats.Rows[i]["PriProv"].ToString()!=provNumMostUsed.ToString()) {//Provnums don't match.
					countPatsToUpdate++;
				}
			}
			//inform user of count. Continue?
			Cursor=Cursors.Default;
			string msg=Lan.g(this,"You are about to reassign")+" "+countPatsToUpdate.ToString()+" "+Lan.g(this,"patients to different providers.  Continue?");
			if(MessageBox.Show(msg,"",MessageBoxButtons.OKCancel)!=DialogResult.OK) {
				return;
			}
			Cursor=Cursors.WaitCursor;
			for(int i=0;i<tablePats.Rows.Count;i++) {
				if(mostUsedProvs[i]==0) {
					continue;
				}
				if(tablePats.Rows[i]["PriProv"].ToString()!=mostUsedProvs[i].ToString()) {//Provnums don't match, so update
					Patients.ReassignProv(PIn.Long(tablePats.Rows[i]["PatNum"].ToString()),mostUsedProvs[i]);
				}
			}
			Cursor=Cursors.Default;
			//changed=true;//We didn't change any providers
			FillGrid();
		}

		///<summary>Not possible if no security admin.</summary>
		private void butCreateUsers_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length==0){
				MsgBox.Show(this,"Please select one or more providers first.");
				return;
			}
			for(int i=0;i<gridMain.SelectedIndices.Length;i++){
				if(table.Rows[gridMain.SelectedIndices[i]]["UserName"].ToString()!="") {
					MsgBox.Show(this,"Not allowed to create users on providers which already have users.");
					return;
				}
			}
			if(comboUserGroup.SelectedIndex==-1){
				MsgBox.Show(this,"Please select a User Group first.");
				return;
			}
			for(int i=0;i<gridMain.SelectedIndices.Length;i++){
				Userod user=new Userod();
				user.UserGroupNum=UserGroups.List[comboUserGroup.SelectedIndex].UserGroupNum;
				user.ProvNum=PIn.Long(table.Rows[gridMain.SelectedIndices[i]]["ProvNum"].ToString());
				user.UserName=GetUniqueUserName(table.Rows[gridMain.SelectedIndices[i]]["LName"].ToString(),
					table.Rows[gridMain.SelectedIndices[i]]["FName"].ToString());
				user.Password=user.UserName;//this will be enhanced later.
				try{
					Userods.Insert(user);
				}
				catch(ApplicationException ex){
					MessageBox.Show(ex.Message);
					changed=true;
					return;
				}
			}
			changed=true;
			FillGrid();
		}

		private string GetUniqueUserName(string lname,string fname){
			string name=lname;
			if(fname.Length>0){
				name+=fname.Substring(0,1);
			}
			if(Userods.IsUserNameUnique(name,0,false)){
				return name;
			}
			int fnameI=1;
			while(fnameI<fname.Length){
				name+=fname.Substring(fnameI,1);
				if(Userods.IsUserNameUnique(name,0,false)) {
					return name;
				}
				fnameI++;
			}
			//should be entire lname+fname at this point, but still not unique
			do{
				name+="x";
			}
			while(!Userods.IsUserNameUnique(name,0,false));
			return name;
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void FormProviderSelect_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			string duplicates=Providers.GetDuplicateAbbrs();
			if(duplicates!="") {
				if(MessageBox.Show(Lan.g(this,"Warning.  The following abbreviations are duplicates.  Continue anyway?\r\n")+duplicates,
					"",MessageBoxButtons.OKCancel)!=DialogResult.OK)
				{
					e.Cancel=true;
					return;
				}
			}
			if(changed){
				DataValid.SetInvalid(InvalidType.Providers, InvalidType.Security);
			}
			//SecurityLogs.MakeLogEntry("Providers","Altered Providers",user);
		}

		

		

	

		

		

		

	

	}
}
