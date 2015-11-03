using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.UI;

namespace OpenDental{
///<summary></summary>
	public class FormRecallSetup : System.Windows.Forms.Form{
		private OpenDental.UI.Button butCancel;
		private OpenDental.UI.Button butOK;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textPostcardsPerSheet;
		private System.Windows.Forms.CheckBox checkReturnAdd;
		private GroupBox groupBox2;
		private ValidDouble textDown;
		private Label label12;
		private ValidDouble textRight;
		private Label label13;
		private CheckBox checkGroupFamilies;
		private Label label14;
		private Label label15;
		private GroupBox groupBox3;
		private Label label25;
		private ComboBox comboStatusMailedRecall;
		private ComboBox comboStatusEmailedRecall;
		private Label label26;
		private ListBox listTypes;
		private Label label1;
		private ValidNumber textDaysPast;
		private ValidNumber textDaysFuture;
		private GroupBox groupBox1;
		private ValidNumber textDaysSecondReminder;
		private ValidNumber textDaysFirstReminder;
		private Label label2;
		private Label label3;
		private OpenDental.UI.ODGrid gridMain;
		private System.ComponentModel.Container components = null;
		private ValidNumber textMaxReminders;
		private Label label4;
		private ComboBox comboStatusEmailedConfirm;
		private Label label5;
		private GroupBox groupBox4;
		private RadioButton radioUseEmailFalse;
		private RadioButton radioUseEmailTrue;
		private Label label6;
		private ComboBox comboStatusTextMessagedConfirm;
		private RadioButton radioExcludeFutureNo;
		private RadioButton radioExcludeFutureYes;
		private TabControl tabControlSetup;
		private TabPage tabRecallConfirmationSetup;
		private TabPage tabConfirmationAutomation;
		private ODGrid gridConfirmationRules;
		private UI.Button butAdd;
		private TabPage tabCommunicationSetup;
		private CheckBox checkSendAll;
		private Label label7;
		private Label label9;
		private UI.Button butDown;
		private UI.Button butUp;
		private ODGrid gridPriorities;
		private Label label10;
		private Label label11;
		private ValidNumber textHourInterval;
		private ValidNumber textDayInterval;
		private bool changed;
		private RichTextBox textDayMsg;
		private RichTextBox textHourMsg;
		private Label label16;
		string[] _priorities;

		///<summary></summary>
		public FormRecallSetup(){
			InitializeComponent();
			Lan.F(this);
			//Lan.C(this, new System.Windows.Forms.Control[] {
				//textBox1,
				//textBox6
			//});
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecallSetup));
			this.textPostcardsPerSheet = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.checkReturnAdd = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textDown = new OpenDental.ValidDouble();
			this.label12 = new System.Windows.Forms.Label();
			this.textRight = new OpenDental.ValidDouble();
			this.label13 = new System.Windows.Forms.Label();
			this.checkGroupFamilies = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textDaysFuture = new OpenDental.ValidNumber();
			this.textDaysPast = new OpenDental.ValidNumber();
			this.label25 = new System.Windows.Forms.Label();
			this.comboStatusMailedRecall = new System.Windows.Forms.ComboBox();
			this.comboStatusEmailedRecall = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.listTypes = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textMaxReminders = new OpenDental.ValidNumber();
			this.label4 = new System.Windows.Forms.Label();
			this.textDaysSecondReminder = new OpenDental.ValidNumber();
			this.textDaysFirstReminder = new OpenDental.ValidNumber();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.butOK = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.comboStatusEmailedConfirm = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioUseEmailFalse = new System.Windows.Forms.RadioButton();
			this.radioUseEmailTrue = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.comboStatusTextMessagedConfirm = new System.Windows.Forms.ComboBox();
			this.radioExcludeFutureNo = new System.Windows.Forms.RadioButton();
			this.radioExcludeFutureYes = new System.Windows.Forms.RadioButton();
			this.tabControlSetup = new System.Windows.Forms.TabControl();
			this.tabRecallConfirmationSetup = new System.Windows.Forms.TabPage();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.tabConfirmationAutomation = new System.Windows.Forms.TabPage();
			this.butAdd = new OpenDental.UI.Button();
			this.gridConfirmationRules = new OpenDental.UI.ODGrid();
			this.tabCommunicationSetup = new System.Windows.Forms.TabPage();
			this.textHourMsg = new System.Windows.Forms.RichTextBox();
			this.textDayMsg = new System.Windows.Forms.RichTextBox();
			this.checkSendAll = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.butDown = new OpenDental.UI.Button();
			this.butUp = new OpenDental.UI.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textHourInterval = new OpenDental.ValidNumber();
			this.textDayInterval = new OpenDental.ValidNumber();
			this.gridPriorities = new OpenDental.UI.ODGrid();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabControlSetup.SuspendLayout();
			this.tabRecallConfirmationSetup.SuspendLayout();
			this.tabConfirmationAutomation.SuspendLayout();
			this.tabCommunicationSetup.SuspendLayout();
			this.SuspendLayout();
			// 
			// textPostcardsPerSheet
			// 
			this.textPostcardsPerSheet.Location = new System.Drawing.Point(223, 485);
			this.textPostcardsPerSheet.Name = "textPostcardsPerSheet";
			this.textPostcardsPerSheet.Size = new System.Drawing.Size(34, 20);
			this.textPostcardsPerSheet.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(47, 488);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(176, 16);
			this.label8.TabIndex = 19;
			this.label8.Text = "Postcards per sheet (1,3,or 4)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkReturnAdd
			// 
			this.checkReturnAdd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkReturnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkReturnAdd.Location = new System.Drawing.Point(89, 506);
			this.checkReturnAdd.Name = "checkReturnAdd";
			this.checkReturnAdd.Size = new System.Drawing.Size(147, 19);
			this.checkReturnAdd.TabIndex = 43;
			this.checkReturnAdd.Text = "Show return address";
			this.checkReturnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textDown);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.textRight);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Location = new System.Drawing.Point(716, 400);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(191, 67);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Adjust Postcard Position in Inches";
			// 
			// textDown
			// 
			this.textDown.Location = new System.Drawing.Point(110, 43);
			this.textDown.MaxVal = 100000000D;
			this.textDown.MinVal = -100000000D;
			this.textDown.Name = "textDown";
			this.textDown.Size = new System.Drawing.Size(73, 20);
			this.textDown.TabIndex = 6;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(48, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 20);
			this.label12.TabIndex = 5;
			this.label12.Text = "Down";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textRight
			// 
			this.textRight.Location = new System.Drawing.Point(110, 18);
			this.textRight.MaxVal = 100000000D;
			this.textRight.MinVal = -100000000D;
			this.textRight.Name = "textRight";
			this.textRight.Size = new System.Drawing.Size(73, 20);
			this.textRight.TabIndex = 4;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(48, 17);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 20);
			this.label13.TabIndex = 4;
			this.label13.Text = "Right";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkGroupFamilies
			// 
			this.checkGroupFamilies.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkGroupFamilies.Location = new System.Drawing.Point(85, 15);
			this.checkGroupFamilies.Name = "checkGroupFamilies";
			this.checkGroupFamilies.Size = new System.Drawing.Size(121, 18);
			this.checkGroupFamilies.TabIndex = 49;
			this.checkGroupFamilies.Text = "Group Families";
			this.checkGroupFamilies.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkGroupFamilies.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 32);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(184, 20);
			this.label14.TabIndex = 50;
			this.label14.Text = "Days Past (e.g. 1095, blank, etc)";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(9, 53);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(181, 20);
			this.label15.TabIndex = 52;
			this.label15.Text = "Days Future (e.g. 7)";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textDaysFuture);
			this.groupBox3.Controls.Add(this.textDaysPast);
			this.groupBox3.Controls.Add(this.checkGroupFamilies);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Location = new System.Drawing.Point(444, 400);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(253, 78);
			this.groupBox3.TabIndex = 54;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Recall List Default View";
			// 
			// textDaysFuture
			// 
			this.textDaysFuture.Location = new System.Drawing.Point(192, 54);
			this.textDaysFuture.MaxVal = 10000;
			this.textDaysFuture.MinVal = 0;
			this.textDaysFuture.Name = "textDaysFuture";
			this.textDaysFuture.Size = new System.Drawing.Size(53, 20);
			this.textDaysFuture.TabIndex = 66;
			// 
			// textDaysPast
			// 
			this.textDaysPast.Location = new System.Drawing.Point(192, 32);
			this.textDaysPast.MaxVal = 10000;
			this.textDaysPast.MinVal = 0;
			this.textDaysPast.Name = "textDaysPast";
			this.textDaysPast.Size = new System.Drawing.Size(53, 20);
			this.textDaysPast.TabIndex = 65;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(64, 399);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(157, 16);
			this.label25.TabIndex = 57;
			this.label25.Text = "Status for mailed recall";
			this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboStatusMailedRecall
			// 
			this.comboStatusMailedRecall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatusMailedRecall.FormattingEnabled = true;
			this.comboStatusMailedRecall.Location = new System.Drawing.Point(223, 395);
			this.comboStatusMailedRecall.MaxDropDownItems = 20;
			this.comboStatusMailedRecall.Name = "comboStatusMailedRecall";
			this.comboStatusMailedRecall.Size = new System.Drawing.Size(206, 21);
			this.comboStatusMailedRecall.TabIndex = 58;
			// 
			// comboStatusEmailedRecall
			// 
			this.comboStatusEmailedRecall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatusEmailedRecall.FormattingEnabled = true;
			this.comboStatusEmailedRecall.Location = new System.Drawing.Point(223, 417);
			this.comboStatusEmailedRecall.MaxDropDownItems = 20;
			this.comboStatusEmailedRecall.Name = "comboStatusEmailedRecall";
			this.comboStatusEmailedRecall.Size = new System.Drawing.Size(206, 21);
			this.comboStatusEmailedRecall.TabIndex = 60;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(64, 421);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(157, 16);
			this.label26.TabIndex = 59;
			this.label26.Text = "Status for e-mailed recall";
			this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// listTypes
			// 
			this.listTypes.FormattingEnabled = true;
			this.listTypes.Location = new System.Drawing.Point(223, 524);
			this.listTypes.Name = "listTypes";
			this.listTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listTypes.Size = new System.Drawing.Size(120, 82);
			this.listTypes.TabIndex = 64;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(66, 524);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 65);
			this.label1.TabIndex = 63;
			this.label1.Text = "Types to show in recall list (typically just prophy, perio, and user-added types)" +
    "";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textMaxReminders);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textDaysSecondReminder);
			this.groupBox1.Controls.Add(this.textDaysFirstReminder);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(444, 518);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(253, 86);
			this.groupBox1.TabIndex = 65;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Also show in list if # of days since";
			// 
			// textMaxReminders
			// 
			this.textMaxReminders.Location = new System.Drawing.Point(192, 60);
			this.textMaxReminders.MaxVal = 10000;
			this.textMaxReminders.MinVal = 0;
			this.textMaxReminders.Name = "textMaxReminders";
			this.textMaxReminders.Size = new System.Drawing.Size(53, 20);
			this.textMaxReminders.TabIndex = 68;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(44, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(146, 20);
			this.label4.TabIndex = 67;
			this.label4.Text = "Max # Reminders (e.g. 4)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDaysSecondReminder
			// 
			this.textDaysSecondReminder.Location = new System.Drawing.Point(192, 38);
			this.textDaysSecondReminder.MaxVal = 10000;
			this.textDaysSecondReminder.MinVal = 0;
			this.textDaysSecondReminder.Name = "textDaysSecondReminder";
			this.textDaysSecondReminder.Size = new System.Drawing.Size(53, 20);
			this.textDaysSecondReminder.TabIndex = 66;
			// 
			// textDaysFirstReminder
			// 
			this.textDaysFirstReminder.Location = new System.Drawing.Point(192, 16);
			this.textDaysFirstReminder.MaxVal = 10000;
			this.textDaysFirstReminder.MinVal = 0;
			this.textDaysFirstReminder.Name = "textDaysFirstReminder";
			this.textDaysFirstReminder.Size = new System.Drawing.Size(53, 20);
			this.textDaysFirstReminder.TabIndex = 65;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(89, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 20);
			this.label2.TabIndex = 50;
			this.label2.Text = "Initial Reminder";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(44, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 20);
			this.label3.TabIndex = 52;
			this.label3.Text = "Second (or more) Reminder";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(806, 659);
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
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(887, 659);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 4;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// comboStatusEmailedConfirm
			// 
			this.comboStatusEmailedConfirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatusEmailedConfirm.FormattingEnabled = true;
			this.comboStatusEmailedConfirm.Location = new System.Drawing.Point(223, 439);
			this.comboStatusEmailedConfirm.MaxDropDownItems = 20;
			this.comboStatusEmailedConfirm.Name = "comboStatusEmailedConfirm";
			this.comboStatusEmailedConfirm.Size = new System.Drawing.Size(206, 21);
			this.comboStatusEmailedConfirm.TabIndex = 69;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 443);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(189, 16);
			this.label5.TabIndex = 68;
			this.label5.Text = "Status for e-mailed confirmation";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioUseEmailFalse);
			this.groupBox4.Controls.Add(this.radioUseEmailTrue);
			this.groupBox4.Location = new System.Drawing.Point(716, 473);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(191, 57);
			this.groupBox4.TabIndex = 70;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Use e-mail if";
			// 
			// radioUseEmailFalse
			// 
			this.radioUseEmailFalse.Location = new System.Drawing.Point(7, 34);
			this.radioUseEmailFalse.Name = "radioUseEmailFalse";
			this.radioUseEmailFalse.Size = new System.Drawing.Size(181, 18);
			this.radioUseEmailFalse.TabIndex = 1;
			this.radioUseEmailFalse.Text = "E-mail is preferred recall method";
			this.radioUseEmailFalse.UseVisualStyleBackColor = true;
			// 
			// radioUseEmailTrue
			// 
			this.radioUseEmailTrue.Location = new System.Drawing.Point(7, 17);
			this.radioUseEmailTrue.Name = "radioUseEmailTrue";
			this.radioUseEmailTrue.Size = new System.Drawing.Size(181, 18);
			this.radioUseEmailTrue.TabIndex = 0;
			this.radioUseEmailTrue.Text = "Has e-mail address";
			this.radioUseEmailTrue.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 465);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(189, 16);
			this.label6.TabIndex = 68;
			this.label6.Text = "Status for text messaged confirmation";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboStatusTextMessagedConfirm
			// 
			this.comboStatusTextMessagedConfirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatusTextMessagedConfirm.FormattingEnabled = true;
			this.comboStatusTextMessagedConfirm.Location = new System.Drawing.Point(223, 461);
			this.comboStatusTextMessagedConfirm.MaxDropDownItems = 20;
			this.comboStatusTextMessagedConfirm.Name = "comboStatusTextMessagedConfirm";
			this.comboStatusTextMessagedConfirm.Size = new System.Drawing.Size(206, 21);
			this.comboStatusTextMessagedConfirm.TabIndex = 69;
			// 
			// radioExcludeFutureNo
			// 
			this.radioExcludeFutureNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioExcludeFutureNo.Location = new System.Drawing.Point(433, 480);
			this.radioExcludeFutureNo.Name = "radioExcludeFutureNo";
			this.radioExcludeFutureNo.Size = new System.Drawing.Size(217, 18);
			this.radioExcludeFutureNo.TabIndex = 71;
			this.radioExcludeFutureNo.Text = "Exclude from list if recall scheduled";
			this.radioExcludeFutureNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioExcludeFutureNo.UseVisualStyleBackColor = true;
			// 
			// radioExcludeFutureYes
			// 
			this.radioExcludeFutureYes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioExcludeFutureYes.Location = new System.Drawing.Point(433, 498);
			this.radioExcludeFutureYes.Name = "radioExcludeFutureYes";
			this.radioExcludeFutureYes.Size = new System.Drawing.Size(217, 18);
			this.radioExcludeFutureYes.TabIndex = 72;
			this.radioExcludeFutureYes.Text = "Exclude from list if any future appt";
			this.radioExcludeFutureYes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioExcludeFutureYes.UseVisualStyleBackColor = true;
			// 
			// tabControlSetup
			// 
			this.tabControlSetup.Controls.Add(this.tabRecallConfirmationSetup);
			this.tabControlSetup.Controls.Add(this.tabConfirmationAutomation);
			this.tabControlSetup.Controls.Add(this.tabCommunicationSetup);
			this.tabControlSetup.Location = new System.Drawing.Point(12, 12);
			this.tabControlSetup.Name = "tabControlSetup";
			this.tabControlSetup.SelectedIndex = 0;
			this.tabControlSetup.Size = new System.Drawing.Size(950, 641);
			this.tabControlSetup.TabIndex = 73;
			// 
			// tabRecallConfirmationSetup
			// 
			this.tabRecallConfirmationSetup.Controls.Add(this.gridMain);
			this.tabRecallConfirmationSetup.Controls.Add(this.radioExcludeFutureYes);
			this.tabRecallConfirmationSetup.Controls.Add(this.label8);
			this.tabRecallConfirmationSetup.Controls.Add(this.radioExcludeFutureNo);
			this.tabRecallConfirmationSetup.Controls.Add(this.textPostcardsPerSheet);
			this.tabRecallConfirmationSetup.Controls.Add(this.groupBox4);
			this.tabRecallConfirmationSetup.Controls.Add(this.checkReturnAdd);
			this.tabRecallConfirmationSetup.Controls.Add(this.comboStatusTextMessagedConfirm);
			this.tabRecallConfirmationSetup.Controls.Add(this.groupBox2);
			this.tabRecallConfirmationSetup.Controls.Add(this.label6);
			this.tabRecallConfirmationSetup.Controls.Add(this.groupBox3);
			this.tabRecallConfirmationSetup.Controls.Add(this.comboStatusEmailedConfirm);
			this.tabRecallConfirmationSetup.Controls.Add(this.label25);
			this.tabRecallConfirmationSetup.Controls.Add(this.label5);
			this.tabRecallConfirmationSetup.Controls.Add(this.comboStatusMailedRecall);
			this.tabRecallConfirmationSetup.Controls.Add(this.label26);
			this.tabRecallConfirmationSetup.Controls.Add(this.groupBox1);
			this.tabRecallConfirmationSetup.Controls.Add(this.comboStatusEmailedRecall);
			this.tabRecallConfirmationSetup.Controls.Add(this.listTypes);
			this.tabRecallConfirmationSetup.Controls.Add(this.label1);
			this.tabRecallConfirmationSetup.Location = new System.Drawing.Point(4, 22);
			this.tabRecallConfirmationSetup.Name = "tabRecallConfirmationSetup";
			this.tabRecallConfirmationSetup.Padding = new System.Windows.Forms.Padding(3);
			this.tabRecallConfirmationSetup.Size = new System.Drawing.Size(942, 615);
			this.tabRecallConfirmationSetup.TabIndex = 0;
			this.tabRecallConfirmationSetup.Text = "Recalls & Confirmations";
			this.tabRecallConfirmationSetup.UseVisualStyleBackColor = true;
			// 
			// gridMain
			// 
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.HasMultilineHeaders = false;
			this.gridMain.HScrollVisible = false;
			this.gridMain.Location = new System.Drawing.Point(35, 14);
			this.gridMain.Name = "gridMain";
			this.gridMain.ScrollValue = 0;
			this.gridMain.Size = new System.Drawing.Size(872, 374);
			this.gridMain.TabIndex = 67;
			this.gridMain.Title = "Messages";
			this.gridMain.TranslationName = "TableRecallMsgs";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// tabConfirmationAutomation
			// 
			this.tabConfirmationAutomation.Controls.Add(this.butAdd);
			this.tabConfirmationAutomation.Controls.Add(this.gridConfirmationRules);
			this.tabConfirmationAutomation.Location = new System.Drawing.Point(4, 22);
			this.tabConfirmationAutomation.Name = "tabConfirmationAutomation";
			this.tabConfirmationAutomation.Padding = new System.Windows.Forms.Padding(3);
			this.tabConfirmationAutomation.Size = new System.Drawing.Size(942, 615);
			this.tabConfirmationAutomation.TabIndex = 1;
			this.tabConfirmationAutomation.Text = "Confirmation Automation";
			this.tabConfirmationAutomation.UseVisualStyleBackColor = true;
			// 
			// butAdd
			// 
			this.butAdd.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAdd.Autosize = true;
			this.butAdd.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAdd.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAdd.CornerRadius = 4F;
			this.butAdd.Image = global::OpenDental.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(35, 394);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(75, 24);
			this.butAdd.TabIndex = 69;
			this.butAdd.Text = "Add";
			this.butAdd.UseVisualStyleBackColor = true;
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// gridConfirmationRules
			// 
			this.gridConfirmationRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridConfirmationRules.HasMultilineHeaders = false;
			this.gridConfirmationRules.HScrollVisible = false;
			this.gridConfirmationRules.Location = new System.Drawing.Point(35, 14);
			this.gridConfirmationRules.Name = "gridConfirmationRules";
			this.gridConfirmationRules.ScrollValue = 0;
			this.gridConfirmationRules.Size = new System.Drawing.Size(872, 374);
			this.gridConfirmationRules.TabIndex = 68;
			this.gridConfirmationRules.Title = "Confirmation Automation Rules";
			this.gridConfirmationRules.TranslationName = "TableConfirmationRules";
			this.gridConfirmationRules.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridConfirmationRules_CellDoubleClick);
			// 
			// tabCommunicationSetup
			// 
			this.tabCommunicationSetup.Controls.Add(this.label16);
			this.tabCommunicationSetup.Controls.Add(this.textHourMsg);
			this.tabCommunicationSetup.Controls.Add(this.textDayMsg);
			this.tabCommunicationSetup.Controls.Add(this.checkSendAll);
			this.tabCommunicationSetup.Controls.Add(this.label7);
			this.tabCommunicationSetup.Controls.Add(this.label9);
			this.tabCommunicationSetup.Controls.Add(this.butDown);
			this.tabCommunicationSetup.Controls.Add(this.butUp);
			this.tabCommunicationSetup.Controls.Add(this.label10);
			this.tabCommunicationSetup.Controls.Add(this.label11);
			this.tabCommunicationSetup.Controls.Add(this.textHourInterval);
			this.tabCommunicationSetup.Controls.Add(this.textDayInterval);
			this.tabCommunicationSetup.Controls.Add(this.gridPriorities);
			this.tabCommunicationSetup.Location = new System.Drawing.Point(4, 22);
			this.tabCommunicationSetup.Name = "tabCommunicationSetup";
			this.tabCommunicationSetup.Padding = new System.Windows.Forms.Padding(3);
			this.tabCommunicationSetup.Size = new System.Drawing.Size(942, 615);
			this.tabCommunicationSetup.TabIndex = 2;
			this.tabCommunicationSetup.Text = "Appt Communication";
			this.tabCommunicationSetup.UseVisualStyleBackColor = true;
			// 
			// textHourMsg
			// 
			this.textHourMsg.Location = new System.Drawing.Point(190, 83);
			this.textHourMsg.Name = "textHourMsg";
			this.textHourMsg.Size = new System.Drawing.Size(167, 171);
			this.textHourMsg.TabIndex = 70;
			this.textHourMsg.Text = "";
			// 
			// textDayMsg
			// 
			this.textDayMsg.Location = new System.Drawing.Point(17, 83);
			this.textDayMsg.Name = "textDayMsg";
			this.textDayMsg.Size = new System.Drawing.Size(167, 171);
			this.textDayMsg.TabIndex = 69;
			this.textDayMsg.Text = "";
			// 
			// checkSendAll
			// 
			this.checkSendAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkSendAll.Location = new System.Drawing.Point(349, 79);
			this.checkSendAll.Name = "checkSendAll";
			this.checkSendAll.Size = new System.Drawing.Size(100, 24);
			this.checkSendAll.TabIndex = 23;
			this.checkSendAll.Text = "Send All";
			this.checkSendAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkSendAll.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(187, 57);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 22;
			this.label7.Text = "Hour Message";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 57);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 21;
			this.label9.Text = "Day Message";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// butDown
			// 
			this.butDown.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDown.Autosize = false;
			this.butDown.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDown.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDown.CornerRadius = 4F;
			this.butDown.Image = global::OpenDental.Properties.Resources.down;
			this.butDown.Location = new System.Drawing.Point(419, 26);
			this.butDown.Name = "butDown";
			this.butDown.Size = new System.Drawing.Size(30, 30);
			this.butDown.TabIndex = 18;
			this.butDown.UseVisualStyleBackColor = true;
			this.butDown.Click += new System.EventHandler(this.butDown_Click);
			// 
			// butUp
			// 
			this.butUp.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butUp.Autosize = false;
			this.butUp.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butUp.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butUp.CornerRadius = 4F;
			this.butUp.Image = global::OpenDental.Properties.Resources.up;
			this.butUp.Location = new System.Drawing.Point(383, 26);
			this.butUp.Name = "butUp";
			this.butUp.Size = new System.Drawing.Size(30, 30);
			this.butUp.TabIndex = 17;
			this.butUp.UseVisualStyleBackColor = true;
			this.butUp.Click += new System.EventHandler(this.butUp_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(187, 10);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 15;
			this.label10.Text = "Hour Interval";
			this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(14, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 14;
			this.label11.Text = "Day Interval";
			this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// textHourInterval
			// 
			this.textHourInterval.Location = new System.Drawing.Point(190, 36);
			this.textHourInterval.MaxVal = 255;
			this.textHourInterval.MinVal = 0;
			this.textHourInterval.Name = "textHourInterval";
			this.textHourInterval.Size = new System.Drawing.Size(167, 20);
			this.textHourInterval.TabIndex = 13;
			// 
			// textDayInterval
			// 
			this.textDayInterval.Location = new System.Drawing.Point(17, 36);
			this.textDayInterval.MaxVal = 255;
			this.textDayInterval.MinVal = 0;
			this.textDayInterval.Name = "textDayInterval";
			this.textDayInterval.Size = new System.Drawing.Size(167, 20);
			this.textDayInterval.TabIndex = 12;
			// 
			// gridPriorities
			// 
			this.gridPriorities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridPriorities.HasMultilineHeaders = false;
			this.gridPriorities.HScrollVisible = false;
			this.gridPriorities.Location = new System.Drawing.Point(455, 26);
			this.gridPriorities.Name = "gridPriorities";
			this.gridPriorities.ScrollValue = 0;
			this.gridPriorities.Size = new System.Drawing.Size(413, 294);
			this.gridPriorities.TabIndex = 68;
			this.gridPriorities.Title = "Communication Priorities";
			this.gridPriorities.TranslationName = null;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(17, 271);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(340, 130);
			this.label16.TabIndex = 71;
			this.label16.Text = resources.GetString("label16.Text");
			// 
			// FormRecallSetup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(974, 695);
			this.Controls.Add(this.tabControlSetup);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.butCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(990, 734);
			this.MinimizeBox = false;
			this.Name = "FormRecallSetup";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Setup Recall and Confirmation";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecallSetup_FormClosing);
			this.Load += new System.EventHandler(this.FormRecallSetup_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.tabControlSetup.ResumeLayout(false);
			this.tabRecallConfirmationSetup.ResumeLayout(false);
			this.tabRecallConfirmationSetup.PerformLayout();
			this.tabConfirmationAutomation.ResumeLayout(false);
			this.tabCommunicationSetup.ResumeLayout(false);
			this.tabCommunicationSetup.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void FormRecallSetup_Load(object sender, System.EventArgs e) {
			FillRecallAndConfirmationTab();
			//TODO: remove DEBUG region when ready to release to the public.
#if DEBUG
			FillConfirmationAutomationTab();
#else
			tabControlSetup.TabPages.Remove(tabConfirmationAutomation);
#endif
			FillPriorityTab();
		}

		#region Recalls & Confirmations

		///<summary>Called on load to initially load the recall and confirmation tab with values from the database.  Calls FillGrid at the end.</summary>
		private void FillRecallAndConfirmationTab() {
			checkGroupFamilies.Checked = PrefC.GetBool(PrefName.RecallGroupByFamily);
			textPostcardsPerSheet.Text=PrefC.GetLong(PrefName.RecallPostcardsPerSheet).ToString();
			checkReturnAdd.Checked=PrefC.GetBool(PrefName.RecallCardsShowReturnAdd);
			checkGroupFamilies.Checked=PrefC.GetBool(PrefName.RecallGroupByFamily);
			if(PrefC.GetLong(PrefName.RecallDaysPast)==-1) {
				textDaysPast.Text="";
			}
			else {
				textDaysPast.Text=PrefC.GetLong(PrefName.RecallDaysPast).ToString();
			}
			if(PrefC.GetLong(PrefName.RecallDaysFuture)==-1) {
				textDaysFuture.Text="";
			}
			else {
				textDaysFuture.Text=PrefC.GetLong(PrefName.RecallDaysFuture).ToString();
			}
			if(PrefC.GetBool(PrefName.RecallExcludeIfAnyFutureAppt)) {
				radioExcludeFutureYes.Checked=true;
			}
			else {
				radioExcludeFutureNo.Checked=true;
			}
			textRight.Text=PrefC.GetDouble(PrefName.RecallAdjustRight).ToString();
			textDown.Text=PrefC.GetDouble(PrefName.RecallAdjustDown).ToString();
			//comboStatusMailedRecall.Items.Clear();
			for(int i=0;i<DefC.Short[(int)DefCat.RecallUnschedStatus].Length;i++) {
				comboStatusMailedRecall.Items.Add(DefC.Short[(int)DefCat.RecallUnschedStatus][i].ItemName);
				comboStatusEmailedRecall.Items.Add(DefC.Short[(int)DefCat.RecallUnschedStatus][i].ItemName);
				if(DefC.Short[(int)DefCat.RecallUnschedStatus][i].DefNum==PrefC.GetLong(PrefName.RecallStatusMailed)) {
					comboStatusMailedRecall.SelectedIndex=i;
				}
				if(DefC.Short[(int)DefCat.RecallUnschedStatus][i].DefNum==PrefC.GetLong(PrefName.RecallStatusEmailed)) {
					comboStatusEmailedRecall.SelectedIndex=i;
				}
			}
			for(int i=0;i<DefC.Short[(int)DefCat.ApptConfirmed].Length;i++) {
				comboStatusEmailedConfirm.Items.Add(DefC.Short[(int)DefCat.ApptConfirmed][i].ItemName);
				if(DefC.Short[(int)DefCat.ApptConfirmed][i].DefNum==PrefC.GetLong(PrefName.ConfirmStatusEmailed)) {
					comboStatusEmailedConfirm.SelectedIndex=i;
				}
			}
			for(int i=0;i<DefC.Short[(int)DefCat.ApptConfirmed].Length;i++) {
				comboStatusTextMessagedConfirm.Items.Add(DefC.Short[(int)DefCat.ApptConfirmed][i].ItemName);
				if(DefC.Short[(int)DefCat.ApptConfirmed][i].DefNum==PrefC.GetLong(PrefName.ConfirmStatusTextMessaged)) {
					comboStatusTextMessagedConfirm.SelectedIndex=i;
				}
			}
			List<long> recalltypes=new List<long>();
			string[] typearray=PrefC.GetString(PrefName.RecallTypesShowingInList).Split(',');
			if(typearray.Length>0) {
				for(int i=0;i<typearray.Length;i++) {
					recalltypes.Add(PIn.Long(typearray[i]));
				}
			}
			for(int i=0;i<RecallTypeC.Listt.Count;i++) {
				listTypes.Items.Add(RecallTypeC.Listt[i].Description);
				if(recalltypes.Contains(RecallTypeC.Listt[i].RecallTypeNum)) {
					listTypes.SetSelected(i,true);
				}
			}
			if(PrefC.GetLong(PrefName.RecallShowIfDaysFirstReminder)==-1) {
				textDaysFirstReminder.Text="";
			}
			else {
				textDaysFirstReminder.Text=PrefC.GetLong(PrefName.RecallShowIfDaysFirstReminder).ToString();
			}
			if(PrefC.GetLong(PrefName.RecallShowIfDaysSecondReminder)==-1) {
				textDaysSecondReminder.Text="";
			}
			else {
				textDaysSecondReminder.Text=PrefC.GetLong(PrefName.RecallShowIfDaysSecondReminder).ToString();
			}
			if(PrefC.GetLong(PrefName.RecallMaxNumberReminders)==-1) {
				textMaxReminders.Text="";
			}
			else {
				textMaxReminders.Text=PrefC.GetLong(PrefName.RecallMaxNumberReminders).ToString();
			}
			if(PrefC.GetBool(PrefName.RecallUseEmailIfHasEmailAddress)) {
				radioUseEmailTrue.Checked=true;
			}
			else {
				radioUseEmailFalse.Checked=true;
			}
			FillGrid();
		}

		private void FillGrid(){
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col;
			col=new ODGridColumn(Lan.g("TableRecallMsgs","Remind#"),50);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableRecallMsgs","Mode"),61);
			gridMain.Columns.Add(col);
			col=new ODGridColumn("",300);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableRecallMsgs","Message"),500);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			#region 1st Reminder
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Subject line"));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailSubject));//old
			row.Tag="RecallEmailSubject";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailMessage));
			row.Tag="RecallEmailMessage";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList] where the list of family members should show."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailFamMsg));
			row.Tag="RecallEmailFamMsg";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardMessage));//old
			row.Tag="RecallPostcardMessage";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList] where the list of family members should show."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardFamMsg));//old
			row.Tag="RecallPostcardFamMsg";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Subject line.  Available variables")+": [NameF]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedSubject));
			row.Tag="WebSchedSubject";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Available variables")+": [NameF], [DueDate], [OfficePhone], [URL]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedMessage));
			row.Tag="WebSchedMessage";
			gridMain.Rows.Add(row);
			#endregion
			#region 2nd Reminder
			//2---------------------------------------------------------------------------------------------
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Subject line"));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailSubject2));
			row.Tag="RecallEmailSubject2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailMessage2));
			row.Tag="RecallEmailMessage2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailFamMsg2));
			row.Tag="RecallEmailFamMsg2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardMessage2));
			row.Tag="RecallPostcardMessage2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardFamMsg2));
			row.Tag="RecallPostcardFamMsg2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Subject line.  Available variables")+": [NameF]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedSubject2));
			row.Tag="WebSchedSubject2";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("2");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Available variables")+": [NameF], [DueDate], [OfficePhone], [URL]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedMessage2));
			row.Tag="WebSchedMessage2";
			gridMain.Rows.Add(row);
			#endregion
			#region 3rd Reminder
			//3---------------------------------------------------------------------------------------------
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Subject line"));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailSubject3));
			row.Tag="RecallEmailSubject3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailMessage3));
			row.Tag="RecallEmailMessage3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailFamMsg3));
			row.Tag="RecallEmailFamMsg3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"Available variables: [DueDate], [NameFL], [NameF]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardMessage3));
			row.Tag="RecallPostcardMessage3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"For multiple patients in one family.  Use [FamilyList]."));
			row.Cells.Add(PrefC.GetString(PrefName.RecallPostcardFamMsg3));
			row.Tag="RecallPostcardFamMsg3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Subject line.  Available variables")+": [NameF]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedSubject3));
			row.Tag="WebSchedSubject3";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("3");
			row.Cells.Add(Lan.g(this,"WebSched"));
			row.Cells.Add(Lan.g(this,"Available variables")+": [NameF], [DueDate], [OfficePhone], [URL]");
			row.Cells.Add(PrefC.GetString(PrefName.WebSchedMessage3));
			row.Tag="WebSchedMessage3";
			gridMain.Rows.Add(row);
			#endregion
			#region Confirmation
			//Confirmation---------------------------------------------------------------------------------------------
			row=new ODGridRow();
			row.Cells.Add("");
			row.Cells.Add(Lan.g(this,"Postcard"));
			row.Cells.Add(Lan.g(this,"Confirmation message.  Use [date]  and [time] where you want those values to be inserted"));
			row.Cells.Add(PrefC.GetString(PrefName.ConfirmPostcardMessage));
			row.Tag="ConfirmPostcardMessage";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Confirmation subject line."));
			row.Cells.Add(PrefC.GetString(PrefName.ConfirmEmailSubject));
			row.Tag="ConfirmEmailSubject";
			gridMain.Rows.Add(row);
			//
			row=new ODGridRow();
			row.Cells.Add("");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Confirmation message.  Available variables: [NameF], [NameFL], [date], and [time]."));
			row.Cells.Add(PrefC.GetString(PrefName.ConfirmEmailMessage));
			row.Tag="ConfirmEmailMessage";
			gridMain.Rows.Add(row);
			#endregion
			#region Text Messaging
			//Text Messaging----------------------------------------------------------------------------------------------
			row=new ODGridRow();
			row.Cells.Add("");
			row.Cells.Add(Lan.g(this,"Text"));
			row.Cells.Add(Lan.g(this,"Confirmation message.  Available variables: [NameF], [NameFL], [date], and [time]."));
			row.Cells.Add(PrefC.GetString(PrefName.ConfirmTextMessage));
			row.Tag="ConfirmTextMessage";
			gridMain.Rows.Add(row);
			#endregion
			gridMain.EndUpdate();
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			PrefName prefName=(PrefName)Enum.Parse(typeof(PrefName),gridMain.Rows[e.Row].Tag.ToString());
			FormRecallMessageEdit FormR=new FormRecallMessageEdit(prefName);
			FormR.MessageVal=PrefC.GetString(prefName);
			FormR.ShowDialog();
			if(FormR.DialogResult!=DialogResult.OK) {
				return;
			}
			Prefs.UpdateString(prefName,FormR.MessageVal);
			//Prefs.RefreshCache();//above line handles it.
			FillGrid();
			changed=true;
		}

		#endregion

		#region Confirmation Automation

		///<summary>Called on load to initially load the Confirmation Automation tab with values from the database.
		///Calls FillGridConfirmationAutomation at the end.</summary>
		private void FillConfirmationAutomationTab() {
			//TODO: prep any text boxes and controls here.
			FillGridConfirmationAutomation();
		}

		private void FillGridConfirmationAutomation() {
			gridConfirmationRules.BeginUpdate();
			gridConfirmationRules.Columns.Clear();
			ODGridColumn col;
			col=new ODGridColumn(Lan.g("TableConfirmationRules","Remind#"),50);
			gridConfirmationRules.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmationRules","Mode"),61);
			gridConfirmationRules.Columns.Add(col);
			col=new ODGridColumn("",300);
			gridConfirmationRules.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableConfirmationRules","Message"),500);
			gridConfirmationRules.Columns.Add(col);
			gridConfirmationRules.Rows.Clear();
			ODGridRow row;
			//TODO: fill correctly with the values from the db
			row=new ODGridRow();
			row.Cells.Add("1");
			row.Cells.Add(Lan.g(this,"E-mail"));
			row.Cells.Add(Lan.g(this,"Subject line"));
			row.Cells.Add(PrefC.GetString(PrefName.RecallEmailSubject));//old
			row.Tag="RecallEmailSubject";
			gridConfirmationRules.Rows.Add(row);
			gridConfirmationRules.EndUpdate();
		}

		private void gridConfirmationRules_CellDoubleClick(object sender,ODGridClickEventArgs e) {

		}

		private void butAdd_Click(object sender,EventArgs e) {

		}

		#endregion

		#region Appt Communication Setup

		private void FillPriorityTab() {
			textDayInterval.Text=PrefC.GetString(PrefName.ApptReminderDayInterval);
			textDayMsg.Text=PrefC.GetString(PrefName.ApptReminderDayMessage);
			textHourInterval.Text=PrefC.GetString(PrefName.ApptReminderHourInterval);
			textHourMsg.Text=PrefC.GetString(PrefName.ApptReminderHourMessage);
			checkSendAll.Checked=PrefC.GetBool(PrefName.ApptReminderSendAll);
			string prefPriority=PrefC.GetString(PrefName.ApptReminderSendOrder);
			_priorities=prefPriority.Split(',');
			FillPriorityGrid();
		}

		private void FillPriorityGrid() {
			gridPriorities.BeginUpdate();
			gridPriorities.Columns.Clear();
			ODGridColumn col;
			col=new ODGridColumn("",0);
			gridPriorities.Columns.Add(col);
			gridPriorities.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<_priorities.Length;i++) {
				row=new ODGridRow();
				int enumNum=PIn.Int(_priorities[i]);
				row.Cells.Add(((CommType)enumNum).ToString());//Adding in the enums in order that the preference was.
				row.Tag=enumNum;
				gridPriorities.Rows.Add(row);
			}
			gridPriorities.EndUpdate();
		}

		private void butUp_Click(object sender,EventArgs e) {
			if(gridPriorities.GetSelectedIndex()==-1) {
				MsgBox.Show(this,"Please select a row to move.");
				return;
			}
			if(gridPriorities.GetSelectedIndex()==0){//Return if it's already at the first position.
				return;
			}
			int selectedIdx=gridPriorities.GetSelectedIndex();
			string destinationString=_priorities[selectedIdx-1];
			_priorities[selectedIdx-1]=_priorities[selectedIdx];
			_priorities[selectedIdx]=destinationString;
			FillPriorityGrid();
			gridPriorities.SetSelected(selectedIdx-1,true);
		}

		private void butDown_Click(object sender,EventArgs e) {
			if(gridPriorities.GetSelectedIndex()==-1) {
				MsgBox.Show(this,"Please select a row to move.");
				return;
			}
			if(gridPriorities.GetSelectedIndex()==gridPriorities.Rows.Count-1) {//Return if it's already at the last position.
				return;
			}
			int selectedIdx=gridPriorities.GetSelectedIndex();
			string destinationString=_priorities[selectedIdx+1];
			_priorities[selectedIdx+1]=_priorities[selectedIdx];
			_priorities[selectedIdx]=destinationString;
			FillPriorityGrid();
			gridPriorities.SetSelected(selectedIdx+1,true);
		}

		#endregion ApptCommunication Setup

		private void butOK_Click(object sender, System.EventArgs e) {
			if(textRight.errorProvider1.GetError(textRight)!=""
				|| textDown.errorProvider1.GetError(textDown)!=""
				|| textDaysPast.errorProvider1.GetError(textDaysPast)!=""
				|| textDaysFuture.errorProvider1.GetError(textDaysFuture)!=""
				|| textDaysFirstReminder.errorProvider1.GetError(textDaysFirstReminder)!=""
				|| textDaysSecondReminder.errorProvider1.GetError(textDaysSecondReminder)!=""
				|| textMaxReminders.errorProvider1.GetError(textMaxReminders)!=""
				|| textDayInterval.errorProvider1.GetError(textDayInterval)!=""
				|| textHourInterval.errorProvider1.GetError(textHourInterval)!="")
			{
				MsgBox.Show(this,"Please fix data entry errors first.");
				return;
			}
			if(textDaysFirstReminder.Text=="") {
				if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Initial Reminder box should not be blank, or the recall list will be blank.")) {
					return;
				}
			}
			if(textPostcardsPerSheet.Text!="1"
				&& textPostcardsPerSheet.Text!="3"
				&& textPostcardsPerSheet.Text!="4")
			{
				MsgBox.Show(this,"The value in postcards per sheet must be 1, 3, or 4");
				return;
			}
			if(comboStatusMailedRecall.SelectedIndex==-1 || comboStatusMailedRecall.SelectedIndex==-1){
				MsgBox.Show(this,"Both status options at the bottom must be set.");
				return; 
			}
			//End of Validation
			if(Prefs.UpdateString(PrefName.RecallPostcardsPerSheet,textPostcardsPerSheet.Text)) {
				if(textPostcardsPerSheet.Text=="1"){
					MsgBox.Show(this,"If using 1 postcard per sheet, you must adjust the position, and also the preview will not work");
				}
			}
			Prefs.UpdateBool(PrefName.RecallCardsShowReturnAdd,checkReturnAdd.Checked);
			Prefs.UpdateBool(PrefName.RecallGroupByFamily,checkGroupFamilies.Checked);
			if(textDaysPast.Text=="") {
				Prefs.UpdateLong(PrefName.RecallDaysPast,-1);
			}
			else {
				Prefs.UpdateLong(PrefName.RecallDaysPast,PIn.Long(textDaysPast.Text));
			}
			if(textDaysFuture.Text=="") {
				Prefs.UpdateLong(PrefName.RecallDaysFuture,-1);
			}
			else {
				Prefs.UpdateLong(PrefName.RecallDaysFuture,PIn.Long(textDaysFuture.Text));
			}
			Prefs.UpdateBool(PrefName.RecallExcludeIfAnyFutureAppt,radioExcludeFutureYes.Checked);
			Prefs.UpdateDouble(PrefName.RecallAdjustRight,PIn.Double(textRight.Text));
			Prefs.UpdateDouble(PrefName.RecallAdjustDown,PIn.Double(textDown.Text));
			if(comboStatusEmailedRecall.SelectedIndex==-1){
				Prefs.UpdateLong(PrefName.RecallStatusEmailed,0);
			}
			else{
				Prefs.UpdateLong(PrefName.RecallStatusEmailed,DefC.Short[(int)DefCat.RecallUnschedStatus][comboStatusEmailedRecall.SelectedIndex].DefNum);
			}
			if(comboStatusMailedRecall.SelectedIndex==-1){
				Prefs.UpdateLong(PrefName.RecallStatusMailed,0);
			}
			else{
				Prefs.UpdateLong(PrefName.RecallStatusMailed,DefC.Short[(int)DefCat.RecallUnschedStatus][comboStatusMailedRecall.SelectedIndex].DefNum);
			}
			if(comboStatusEmailedConfirm.SelectedIndex==-1) {
				Prefs.UpdateLong(PrefName.ConfirmStatusEmailed,0);
			}
			else {
				Prefs.UpdateLong(PrefName.ConfirmStatusEmailed,DefC.Short[(int)DefCat.ApptConfirmed][comboStatusEmailedConfirm.SelectedIndex].DefNum);
			}
			if(comboStatusTextMessagedConfirm.SelectedIndex==-1) {
				Prefs.UpdateLong(PrefName.ConfirmStatusTextMessaged,0);
			}
			else {
				Prefs.UpdateLong(PrefName.ConfirmStatusTextMessaged,DefC.Short[(int)DefCat.ApptConfirmed][comboStatusTextMessagedConfirm.SelectedIndex].DefNum);
			}
			string recalltypes="";
			for(int i=0;i<listTypes.SelectedIndices.Count;i++){
				if(i>0){
					recalltypes+=",";
				}
				recalltypes+=RecallTypeC.Listt[listTypes.SelectedIndices[i]].RecallTypeNum.ToString();
			}
			Prefs.UpdateString(PrefName.RecallTypesShowingInList,recalltypes);
			if(textDaysFirstReminder.Text=="") {
				Prefs.UpdateLong(PrefName.RecallShowIfDaysFirstReminder,-1);
			}
			else {
				Prefs.UpdateLong(PrefName.RecallShowIfDaysFirstReminder,PIn.Long(textDaysFirstReminder.Text));
			}
			if(textDaysSecondReminder.Text=="") {
				Prefs.UpdateLong(PrefName.RecallShowIfDaysSecondReminder,-1);
			}
			else {
				Prefs.UpdateLong(PrefName.RecallShowIfDaysSecondReminder,PIn.Long(textDaysSecondReminder.Text));
			}
			if(textMaxReminders.Text=="") {
				Prefs.UpdateLong(PrefName.RecallMaxNumberReminders,-1);
			}
			else {
				Prefs.UpdateLong(PrefName.RecallMaxNumberReminders,PIn.Long(textMaxReminders.Text));
			}
			if(radioUseEmailTrue.Checked){
				Prefs.UpdateBool(PrefName.RecallUseEmailIfHasEmailAddress,true);
			}
			else{
				Prefs.UpdateBool(PrefName.RecallUseEmailIfHasEmailAddress,false);
			}
			Prefs.UpdateBool(PrefName.ApptReminderSendAll,checkSendAll.Checked);
			Prefs.UpdateInt(PrefName.ApptReminderDayInterval,PIn.Int(textDayInterval.Text));
			Prefs.UpdateInt(PrefName.ApptReminderHourInterval,PIn.Int(textHourInterval.Text));
			Prefs.UpdateString(PrefName.ApptReminderDayMessage,PIn.String(textDayMsg.Text));
			Prefs.UpdateString(PrefName.ApptReminderHourMessage,PIn.String(textHourMsg.Text));
			string sendOrder="";
			for(int i=0;i<gridPriorities.Rows.Count;i++) {
				if(i>0) {
					sendOrder+=",";
				}
				sendOrder+=((int)gridPriorities.Rows[i].Tag).ToString();
			}
			Prefs.UpdateString(PrefName.ApptReminderSendOrder,sendOrder);
			changed=true;
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		private void FormRecallSetup_FormClosing(object sender,FormClosingEventArgs e) {
			if(changed) {
				DataValid.SetInvalid(InvalidType.Prefs);
			}
		}




	}
}
