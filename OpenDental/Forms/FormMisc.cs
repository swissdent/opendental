using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDentBusiness;
using System.IO;

namespace OpenDental{
///<summary></summary>
	public class FormMisc : System.Windows.Forms.Form{
		private OpenDental.UI.Button butOK;
		private OpenDental.UI.Button butCancel;
		private IContainer components;
		private System.Windows.Forms.TextBox textTreatNote;
		private System.Windows.Forms.CheckBox checkShowCC;
		private System.Windows.Forms.TextBox textMainWindowTitle;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox checkITooth;
		private System.Windows.Forms.CheckBox checkTreatPlanShowGraphics;
		private System.Windows.Forms.CheckBox checkTreatPlanShowCompleted;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label2;
		private OpenDental.ValidNumber textStatementsCalcDueDate;
		private System.Windows.Forms.CheckBox checkEclaimsSeparateTreatProv;
		private System.Windows.Forms.CheckBox checkRandomPrimaryKeys;
		private System.Windows.Forms.CheckBox checkBalancesDontSubtractIns;
		private System.Windows.Forms.Label label3;
		private OpenDental.ValidNumber textSigInterval;
		private System.Windows.Forms.CheckBox checkInsurancePlansShared;
		private CheckBox checkMedicalEclaimsEnabled;
		private CheckBox checkStatementShowReturnAddress;
		private OpenDental.UI.Button butLanguages;
		private Label label4;
    private CheckBox checkSolidBlockouts;
		private CheckBox checkAgingMonthly;
		private GroupBox groupBox4;
		private CheckBox checkBoldBalance;
		private CheckBox checkShowAccountNotes;
		private CheckBox checkSimpleStatement;
		private CheckBox checkBrokenApptNote;
		private GroupBox groupBox7;
		private Label label5;
		private TextBox textBoxStationary;
		private TextBox textBoxLogo;
		private Label label6;
		private Label label8;
		private TextBox textBoxDocPath;
		private ToolTip toolTip1;
		private PictureBox pictureBox1;
		private Label label9;
		private CheckBox checkApptBubbleDelay;
		private CheckBox checkStoreCCnumbers;
		private CheckBox checkAppointmentBubblesDisabled;
		private CheckBox checkDeductibleBeforePercent;
		private ComboBox comboUseChartNum;
		private Label label10;
		private Label label11;
		private ComboBox comboShowID;
		private Label label7;
		private ComboBox comboBrokenApptAdjType;
		private Label label12;
		private ComboBox comboFinanceChargeAdjType;
		private System.Windows.Forms.Label label1;
		private CheckBox checkTaskListAlwaysShow;
		private CheckBox checkTasksCheckOnStartup;
		private CheckBox checkApptExclamation;
		private CheckBox checkProviderIncomeShows;
		private CheckBox checkBoxTaskKeepListHidden;
		private ComputerPref computerPref;
		private ValidNumber validNumX;
		private Label labelX;
		private GroupBox groupBox2;
		private GroupBox groupBoxTaskDefaults;
		private ValidNumber validNumY;
		private Label labelY;
		private RadioButton radioRight;
		private RadioButton radioBottom;
		private TextBox textClaimAttachPath;
		private Label label13;
		private GroupBox groupBox3;
		private CheckBox checkAutoClearEntryStatus;
		private CheckBox checkShowFamilyCommByDefault;
		private List<Def> posAdjTypes;

		///<summary></summary>
		public FormMisc(){
			InitializeComponent();
			Lan.F(this);
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
			this.components=new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(FormMisc));
			this.textTreatNote=new System.Windows.Forms.TextBox();
			this.label1=new System.Windows.Forms.Label();
			this.checkShowCC=new System.Windows.Forms.CheckBox();
			this.textMainWindowTitle=new System.Windows.Forms.TextBox();
			this.label14=new System.Windows.Forms.Label();
			this.checkITooth=new System.Windows.Forms.CheckBox();
			this.checkTreatPlanShowGraphics=new System.Windows.Forms.CheckBox();
			this.checkTreatPlanShowCompleted=new System.Windows.Forms.CheckBox();
			this.groupBox1=new System.Windows.Forms.GroupBox();
			this.groupBox5=new System.Windows.Forms.GroupBox();
			this.checkProviderIncomeShows=new System.Windows.Forms.CheckBox();
			this.label12=new System.Windows.Forms.Label();
			this.comboFinanceChargeAdjType=new System.Windows.Forms.ComboBox();
			this.label10=new System.Windows.Forms.Label();
			this.checkStoreCCnumbers=new System.Windows.Forms.CheckBox();
			this.comboUseChartNum=new System.Windows.Forms.ComboBox();
			this.checkSimpleStatement=new System.Windows.Forms.CheckBox();
			this.checkAgingMonthly=new System.Windows.Forms.CheckBox();
			this.checkStatementShowReturnAddress=new System.Windows.Forms.CheckBox();
			this.checkBoldBalance=new System.Windows.Forms.CheckBox();
			this.checkBalancesDontSubtractIns=new System.Windows.Forms.CheckBox();
			this.checkShowAccountNotes=new System.Windows.Forms.CheckBox();
			this.textStatementsCalcDueDate=new OpenDental.ValidNumber();
			this.label2=new System.Windows.Forms.Label();
			this.checkEclaimsSeparateTreatProv=new System.Windows.Forms.CheckBox();
			this.checkRandomPrimaryKeys=new System.Windows.Forms.CheckBox();
			this.label3=new System.Windows.Forms.Label();
			this.checkInsurancePlansShared=new System.Windows.Forms.CheckBox();
			this.checkMedicalEclaimsEnabled=new System.Windows.Forms.CheckBox();
			this.label4=new System.Windows.Forms.Label();
			this.checkSolidBlockouts=new System.Windows.Forms.CheckBox();
			this.groupBox4=new System.Windows.Forms.GroupBox();
			this.checkApptExclamation=new System.Windows.Forms.CheckBox();
			this.label7=new System.Windows.Forms.Label();
			this.checkBrokenApptNote=new System.Windows.Forms.CheckBox();
			this.comboBrokenApptAdjType=new System.Windows.Forms.ComboBox();
			this.checkApptBubbleDelay=new System.Windows.Forms.CheckBox();
			this.checkAppointmentBubblesDisabled=new System.Windows.Forms.CheckBox();
			this.checkDeductibleBeforePercent=new System.Windows.Forms.CheckBox();
			this.groupBox7=new System.Windows.Forms.GroupBox();
			this.label9=new System.Windows.Forms.Label();
			this.textBoxDocPath=new System.Windows.Forms.TextBox();
			this.label8=new System.Windows.Forms.Label();
			this.textBoxStationary=new System.Windows.Forms.TextBox();
			this.textBoxLogo=new System.Windows.Forms.TextBox();
			this.label6=new System.Windows.Forms.Label();
			this.label5=new System.Windows.Forms.Label();
			this.toolTip1=new System.Windows.Forms.ToolTip(this.components);
			this.radioBottom=new System.Windows.Forms.RadioButton();
			this.radioRight=new System.Windows.Forms.RadioButton();
			this.checkTaskListAlwaysShow=new System.Windows.Forms.CheckBox();
			this.checkTasksCheckOnStartup=new System.Windows.Forms.CheckBox();
			this.checkBoxTaskKeepListHidden=new System.Windows.Forms.CheckBox();
			this.validNumY=new OpenDental.ValidNumber();
			this.validNumX=new OpenDental.ValidNumber();
			this.labelX=new System.Windows.Forms.Label();
			this.labelY=new System.Windows.Forms.Label();
			this.pictureBox1=new System.Windows.Forms.PictureBox();
			this.label11=new System.Windows.Forms.Label();
			this.comboShowID=new System.Windows.Forms.ComboBox();
			this.groupBox2=new System.Windows.Forms.GroupBox();
			this.groupBoxTaskDefaults=new System.Windows.Forms.GroupBox();
			this.textClaimAttachPath=new System.Windows.Forms.TextBox();
			this.label13=new System.Windows.Forms.Label();
			this.groupBox3=new System.Windows.Forms.GroupBox();
			this.checkAutoClearEntryStatus=new System.Windows.Forms.CheckBox();
			this.butLanguages=new OpenDental.UI.Button();
			this.textSigInterval=new OpenDental.ValidNumber();
			this.butCancel=new OpenDental.UI.Button();
			this.butOK=new OpenDental.UI.Button();
			this.checkShowFamilyCommByDefault=new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBoxTaskDefaults.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// textTreatNote
			// 
			this.textTreatNote.AcceptsReturn=true;
			this.textTreatNote.Location=new System.Drawing.Point(16,28);
			this.textTreatNote.Multiline=true;
			this.textTreatNote.Name="textTreatNote";
			this.textTreatNote.Size=new System.Drawing.Size(371,53);
			this.textTreatNote.TabIndex=3;
			// 
			// label1
			// 
			this.label1.Location=new System.Drawing.Point(225,10);
			this.label1.Name="label1";
			this.label1.Size=new System.Drawing.Size(163,15);
			this.label1.TabIndex=35;
			this.label1.Text="Default Note";
			this.label1.TextAlign=System.Drawing.ContentAlignment.BottomRight;
			// 
			// checkShowCC
			// 
			this.checkShowCC.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkShowCC.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkShowCC.Location=new System.Drawing.Point(19,32);
			this.checkShowCC.Name="checkShowCC";
			this.checkShowCC.Size=new System.Drawing.Size(368,17);
			this.checkShowCC.TabIndex=36;
			this.checkShowCC.Text="Show credit card info on statements";
			this.checkShowCC.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textMainWindowTitle
			// 
			this.textMainWindowTitle.Location=new System.Drawing.Point(416,342);
			this.textMainWindowTitle.Name="textMainWindowTitle";
			this.textMainWindowTitle.Size=new System.Drawing.Size(431,20);
			this.textMainWindowTitle.TabIndex=38;
			// 
			// label14
			// 
			this.label14.Location=new System.Drawing.Point(265,345);
			this.label14.Name="label14";
			this.label14.Size=new System.Drawing.Size(149,17);
			this.label14.TabIndex=39;
			this.label14.Text="Main Window Title";
			this.label14.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// checkITooth
			// 
			this.checkITooth.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkITooth.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkITooth.Location=new System.Drawing.Point(500,425);
			this.checkITooth.Name="checkITooth";
			this.checkITooth.Size=new System.Drawing.Size(346,17);
			this.checkITooth.TabIndex=42;
			this.checkITooth.Text="Use International Tooth Numbers (11-48)";
			this.checkITooth.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkTreatPlanShowGraphics
			// 
			this.checkTreatPlanShowGraphics.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkTreatPlanShowGraphics.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkTreatPlanShowGraphics.Location=new System.Drawing.Point(28,83);
			this.checkTreatPlanShowGraphics.Name="checkTreatPlanShowGraphics";
			this.checkTreatPlanShowGraphics.Size=new System.Drawing.Size(359,17);
			this.checkTreatPlanShowGraphics.TabIndex=46;
			this.checkTreatPlanShowGraphics.Text="Show Graphical Tooth Chart";
			this.checkTreatPlanShowGraphics.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkTreatPlanShowCompleted
			// 
			this.checkTreatPlanShowCompleted.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkTreatPlanShowCompleted.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkTreatPlanShowCompleted.Location=new System.Drawing.Point(28,100);
			this.checkTreatPlanShowCompleted.Name="checkTreatPlanShowCompleted";
			this.checkTreatPlanShowCompleted.Size=new System.Drawing.Size(359,17);
			this.checkTreatPlanShowCompleted.TabIndex=47;
			this.checkTreatPlanShowCompleted.Text="Show Completed Work on Graphical Tooth Chart";
			this.checkTreatPlanShowCompleted.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textTreatNote);
			this.groupBox1.Controls.Add(this.checkTreatPlanShowGraphics);
			this.groupBox1.Controls.Add(this.checkTreatPlanShowCompleted);
			this.groupBox1.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location=new System.Drawing.Point(26,9);
			this.groupBox1.Name="groupBox1";
			this.groupBox1.Size=new System.Drawing.Size(408,122);
			this.groupBox1.TabIndex=48;
			this.groupBox1.TabStop=false;
			this.groupBox1.Text="Treatment Plan module";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.checkShowFamilyCommByDefault);
			this.groupBox5.Controls.Add(this.checkProviderIncomeShows);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.comboFinanceChargeAdjType);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.checkStoreCCnumbers);
			this.groupBox5.Controls.Add(this.comboUseChartNum);
			this.groupBox5.Controls.Add(this.checkSimpleStatement);
			this.groupBox5.Controls.Add(this.checkAgingMonthly);
			this.groupBox5.Controls.Add(this.checkStatementShowReturnAddress);
			this.groupBox5.Controls.Add(this.checkBoldBalance);
			this.groupBox5.Controls.Add(this.checkBalancesDontSubtractIns);
			this.groupBox5.Controls.Add(this.checkShowAccountNotes);
			this.groupBox5.Controls.Add(this.textStatementsCalcDueDate);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.checkShowCC);
			this.groupBox5.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.groupBox5.Location=new System.Drawing.Point(459,9);
			this.groupBox5.Name="groupBox5";
			this.groupBox5.Size=new System.Drawing.Size(408,297);
			this.groupBox5.TabIndex=52;
			this.groupBox5.TabStop=false;
			this.groupBox5.Text="Account module";
			// 
			// checkProviderIncomeShows
			// 
			this.checkProviderIncomeShows.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkProviderIncomeShows.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkProviderIncomeShows.Location=new System.Drawing.Point(6,238);
			this.checkProviderIncomeShows.Name="checkProviderIncomeShows";
			this.checkProviderIncomeShows.Size=new System.Drawing.Size(381,17);
			this.checkProviderIncomeShows.TabIndex=74;
			this.checkProviderIncomeShows.Text="Show provider income transfer window after entering insurance payment";
			this.checkProviderIncomeShows.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkProviderIncomeShows,"Generally used with \"Balances don\'t subtract insurance estimate\"\r\nchecked to the "+
							"upper right of this option in the \"Statements\" section.\r\nHowever, it will work w"+
							"ell either way.");
			// 
			// label12
			// 
			this.label12.Location=new System.Drawing.Point(3,219);
			this.label12.Name="label12";
			this.label12.Size=new System.Drawing.Size(221,15);
			this.label12.TabIndex=73;
			this.label12.Text="Finance charge adj type";
			this.label12.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// comboFinanceChargeAdjType
			// 
			this.comboFinanceChargeAdjType.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboFinanceChargeAdjType.FormattingEnabled=true;
			this.comboFinanceChargeAdjType.Location=new System.Drawing.Point(225,215);
			this.comboFinanceChargeAdjType.MaxDropDownItems=30;
			this.comboFinanceChargeAdjType.Name="comboFinanceChargeAdjType";
			this.comboFinanceChargeAdjType.Size=new System.Drawing.Size(163,21);
			this.comboFinanceChargeAdjType.TabIndex=72;
			// 
			// label10
			// 
			this.label10.Location=new System.Drawing.Point(61,57);
			this.label10.Name="label10";
			this.label10.Size=new System.Drawing.Size(195,15);
			this.label10.TabIndex=69;
			this.label10.Text="Account Numbers use";
			this.label10.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// checkStoreCCnumbers
			// 
			this.checkStoreCCnumbers.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkStoreCCnumbers.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkStoreCCnumbers.Location=new System.Drawing.Point(19,195);
			this.checkStoreCCnumbers.Name="checkStoreCCnumbers";
			this.checkStoreCCnumbers.Size=new System.Drawing.Size(368,17);
			this.checkStoreCCnumbers.TabIndex=67;
			this.checkStoreCCnumbers.Text="Allow storing credit card numbers (this is a security risk)";
			this.checkStoreCCnumbers.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkStoreCCnumbers.UseVisualStyleBackColor=true;
			// 
			// comboUseChartNum
			// 
			this.comboUseChartNum.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUseChartNum.FormattingEnabled=true;
			this.comboUseChartNum.Location=new System.Drawing.Point(258,53);
			this.comboUseChartNum.Name="comboUseChartNum";
			this.comboUseChartNum.Size=new System.Drawing.Size(130,21);
			this.comboUseChartNum.TabIndex=68;
			// 
			// checkSimpleStatement
			// 
			this.checkSimpleStatement.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkSimpleStatement.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkSimpleStatement.Location=new System.Drawing.Point(19,110);
			this.checkSimpleStatement.Name="checkSimpleStatement";
			this.checkSimpleStatement.Size=new System.Drawing.Size(368,17);
			this.checkSimpleStatement.TabIndex=58;
			this.checkSimpleStatement.Text="Print simple statements with less detail ";
			this.checkSimpleStatement.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkAgingMonthly
			// 
			this.checkAgingMonthly.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkAgingMonthly.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkAgingMonthly.Location=new System.Drawing.Point(19,144);
			this.checkAgingMonthly.Name="checkAgingMonthly";
			this.checkAgingMonthly.Size=new System.Drawing.Size(368,17);
			this.checkAgingMonthly.TabIndex=57;
			this.checkAgingMonthly.Text="Aging calculated monthly instead of daily";
			this.checkAgingMonthly.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkStatementShowReturnAddress
			// 
			this.checkStatementShowReturnAddress.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkStatementShowReturnAddress.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkStatementShowReturnAddress.Location=new System.Drawing.Point(19,15);
			this.checkStatementShowReturnAddress.Name="checkStatementShowReturnAddress";
			this.checkStatementShowReturnAddress.Size=new System.Drawing.Size(368,17);
			this.checkStatementShowReturnAddress.TabIndex=56;
			this.checkStatementShowReturnAddress.Text="Show return address on statements";
			this.checkStatementShowReturnAddress.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoldBalance
			// 
			this.checkBoldBalance.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoldBalance.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkBoldBalance.Location=new System.Drawing.Point(19,178);
			this.checkBoldBalance.Name="checkBoldBalance";
			this.checkBoldBalance.Size=new System.Drawing.Size(368,17);
			this.checkBoldBalance.TabIndex=57;
			this.checkBoldBalance.Text="Use bold balance view";
			this.checkBoldBalance.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkBoldBalance,"Generally used with \"Balances don\'t subtract insurance estimate\"\r\nchecked to the "+
							"upper right of this option in the \"Statements\" section.\r\nHowever, it will work w"+
							"ell either way.");
			// 
			// checkBalancesDontSubtractIns
			// 
			this.checkBalancesDontSubtractIns.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkBalancesDontSubtractIns.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkBalancesDontSubtractIns.Location=new System.Drawing.Point(19,127);
			this.checkBalancesDontSubtractIns.Name="checkBalancesDontSubtractIns";
			this.checkBalancesDontSubtractIns.Size=new System.Drawing.Size(368,17);
			this.checkBalancesDontSubtractIns.TabIndex=55;
			this.checkBalancesDontSubtractIns.Text="Balances don\'t subtract insurance estimate";
			this.checkBalancesDontSubtractIns.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkShowAccountNotes
			// 
			this.checkShowAccountNotes.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkShowAccountNotes.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkShowAccountNotes.Location=new System.Drawing.Point(19,161);
			this.checkShowAccountNotes.Name="checkShowAccountNotes";
			this.checkShowAccountNotes.Size=new System.Drawing.Size(368,17);
			this.checkShowAccountNotes.TabIndex=56;
			this.checkShowAccountNotes.Text="Show item notes in main grid ";
			this.checkShowAccountNotes.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textStatementsCalcDueDate
			// 
			this.textStatementsCalcDueDate.Location=new System.Drawing.Point(328,80);
			this.textStatementsCalcDueDate.MaxVal=255;
			this.textStatementsCalcDueDate.MinVal=0;
			this.textStatementsCalcDueDate.Name="textStatementsCalcDueDate";
			this.textStatementsCalcDueDate.Size=new System.Drawing.Size(60,20);
			this.textStatementsCalcDueDate.TabIndex=54;
			this.textStatementsCalcDueDate.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location=new System.Drawing.Point(7,80);
			this.label2.Name="label2";
			this.label2.Size=new System.Drawing.Size(318,27);
			this.label2.TabIndex=53;
			this.label2.Text="Days to calculate due date.  Usually 10 or 15.  Leave blank to show \"Due on Recei"+
					"pt\"";
			this.label2.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// checkEclaimsSeparateTreatProv
			// 
			this.checkEclaimsSeparateTreatProv.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkEclaimsSeparateTreatProv.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkEclaimsSeparateTreatProv.Location=new System.Drawing.Point(500,442);
			this.checkEclaimsSeparateTreatProv.Name="checkEclaimsSeparateTreatProv";
			this.checkEclaimsSeparateTreatProv.Size=new System.Drawing.Size(346,17);
			this.checkEclaimsSeparateTreatProv.TabIndex=53;
			this.checkEclaimsSeparateTreatProv.Text="On e-claims, send treating provider info for each separate procedure";
			this.checkEclaimsSeparateTreatProv.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkRandomPrimaryKeys
			// 
			this.checkRandomPrimaryKeys.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkRandomPrimaryKeys.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkRandomPrimaryKeys.Location=new System.Drawing.Point(500,476);
			this.checkRandomPrimaryKeys.Name="checkRandomPrimaryKeys";
			this.checkRandomPrimaryKeys.Size=new System.Drawing.Size(346,17);
			this.checkRandomPrimaryKeys.TabIndex=55;
			this.checkRandomPrimaryKeys.Text="Use Random Primary Keys (BE VERY CAREFUL.  IRREVERSIBLE)";
			this.checkRandomPrimaryKeys.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkRandomPrimaryKeys.Click+=new System.EventHandler(this.checkRandomPrimaryKeys_Click);
			// 
			// label3
			// 
			this.label3.Location=new System.Drawing.Point(214,387);
			this.label3.Name="label3";
			this.label3.Size=new System.Drawing.Size(558,18);
			this.label3.TabIndex=56;
			this.label3.Text="Process Signal Interval in seconds.  Usually every 6 to 20 seconds.  Leave blank "+
					"to disable autorefresh";
			this.label3.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkInsurancePlansShared
			// 
			this.checkInsurancePlansShared.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsurancePlansShared.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkInsurancePlansShared.Location=new System.Drawing.Point(217,493);
			this.checkInsurancePlansShared.Name="checkInsurancePlansShared";
			this.checkInsurancePlansShared.Size=new System.Drawing.Size(629,17);
			this.checkInsurancePlansShared.TabIndex=58;
			this.checkInsurancePlansShared.Text="Many patients have identical insurance plans.  Change behavior of program slightl"+
					"y to optimize for identical plans.";
			this.checkInsurancePlansShared.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkMedicalEclaimsEnabled
			// 
			this.checkMedicalEclaimsEnabled.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkMedicalEclaimsEnabled.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkMedicalEclaimsEnabled.Location=new System.Drawing.Point(500,408);
			this.checkMedicalEclaimsEnabled.Name="checkMedicalEclaimsEnabled";
			this.checkMedicalEclaimsEnabled.Size=new System.Drawing.Size(346,17);
			this.checkMedicalEclaimsEnabled.TabIndex=60;
			this.checkMedicalEclaimsEnabled.Text="Enable medical e-claims";
			this.checkMedicalEclaimsEnabled.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location=new System.Drawing.Point(457,523);
			this.label4.Name="label4";
			this.label4.Size=new System.Drawing.Size(298,17);
			this.label4.TabIndex=64;
			this.label4.Text="Languages used by patients.";
			this.label4.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkSolidBlockouts
			// 
			this.checkSolidBlockouts.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkSolidBlockouts.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkSolidBlockouts.Location=new System.Drawing.Point(25,49);
			this.checkSolidBlockouts.Name="checkSolidBlockouts";
			this.checkSolidBlockouts.Size=new System.Drawing.Size(362,17);
			this.checkSolidBlockouts.TabIndex=66;
			this.checkSolidBlockouts.Text="Use solid blockouts instead of outlines on the appointment book";
			this.checkSolidBlockouts.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkSolidBlockouts.UseVisualStyleBackColor=true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkApptExclamation);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.checkBrokenApptNote);
			this.groupBox4.Controls.Add(this.comboBrokenApptAdjType);
			this.groupBox4.Controls.Add(this.checkApptBubbleDelay);
			this.groupBox4.Controls.Add(this.checkAppointmentBubblesDisabled);
			this.groupBox4.Controls.Add(this.checkSolidBlockouts);
			this.groupBox4.Location=new System.Drawing.Point(26,135);
			this.groupBox4.Name="groupBox4";
			this.groupBox4.Size=new System.Drawing.Size(408,129);
			this.groupBox4.TabIndex=67;
			this.groupBox4.TabStop=false;
			this.groupBox4.Text="Appointment module";
			// 
			// checkApptExclamation
			// 
			this.checkApptExclamation.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkApptExclamation.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkApptExclamation.Location=new System.Drawing.Point(2,107);
			this.checkApptExclamation.Name="checkApptExclamation";
			this.checkApptExclamation.Size=new System.Drawing.Size(385,17);
			this.checkApptExclamation.TabIndex=72;
			this.checkApptExclamation.Text="Show ! at upper right of appts for ins not sent (might cause slowdown)";
			this.checkApptExclamation.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkApptExclamation.UseVisualStyleBackColor=true;
			// 
			// label7
			// 
			this.label7.Location=new System.Drawing.Point(3,89);
			this.label7.Name="label7";
			this.label7.Size=new System.Drawing.Size(221,15);
			this.label7.TabIndex=71;
			this.label7.Text="Broken appt default adj type";
			this.label7.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// checkBrokenApptNote
			// 
			this.checkBrokenApptNote.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkBrokenApptNote.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkBrokenApptNote.Location=new System.Drawing.Point(25,66);
			this.checkBrokenApptNote.Name="checkBrokenApptNote";
			this.checkBrokenApptNote.Size=new System.Drawing.Size(362,17);
			this.checkBrokenApptNote.TabIndex=67;
			this.checkBrokenApptNote.Text="Put broken appt note in Commlog instead of Adj (not recommended)";
			this.checkBrokenApptNote.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkBrokenApptNote.UseVisualStyleBackColor=true;
			// 
			// comboBrokenApptAdjType
			// 
			this.comboBrokenApptAdjType.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBrokenApptAdjType.FormattingEnabled=true;
			this.comboBrokenApptAdjType.Location=new System.Drawing.Point(225,85);
			this.comboBrokenApptAdjType.MaxDropDownItems=30;
			this.comboBrokenApptAdjType.Name="comboBrokenApptAdjType";
			this.comboBrokenApptAdjType.Size=new System.Drawing.Size(163,21);
			this.comboBrokenApptAdjType.TabIndex=70;
			// 
			// checkApptBubbleDelay
			// 
			this.checkApptBubbleDelay.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkApptBubbleDelay.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkApptBubbleDelay.Location=new System.Drawing.Point(25,32);
			this.checkApptBubbleDelay.Name="checkApptBubbleDelay";
			this.checkApptBubbleDelay.Size=new System.Drawing.Size(362,17);
			this.checkApptBubbleDelay.TabIndex=69;
			this.checkApptBubbleDelay.Text="Appointment bubble popup delay";
			this.checkApptBubbleDelay.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkApptBubbleDelay.UseVisualStyleBackColor=true;
			// 
			// checkAppointmentBubblesDisabled
			// 
			this.checkAppointmentBubblesDisabled.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkAppointmentBubblesDisabled.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkAppointmentBubblesDisabled.Location=new System.Drawing.Point(25,15);
			this.checkAppointmentBubblesDisabled.Name="checkAppointmentBubblesDisabled";
			this.checkAppointmentBubblesDisabled.Size=new System.Drawing.Size(362,17);
			this.checkAppointmentBubblesDisabled.TabIndex=70;
			this.checkAppointmentBubblesDisabled.Text="Appointment bubble popup disabled";
			this.checkAppointmentBubblesDisabled.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkAppointmentBubblesDisabled.UseVisualStyleBackColor=true;
			// 
			// checkDeductibleBeforePercent
			// 
			this.checkDeductibleBeforePercent.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkDeductibleBeforePercent.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkDeductibleBeforePercent.Location=new System.Drawing.Point(500,459);
			this.checkDeductibleBeforePercent.Name="checkDeductibleBeforePercent";
			this.checkDeductibleBeforePercent.Size=new System.Drawing.Size(346,17);
			this.checkDeductibleBeforePercent.TabIndex=68;
			this.checkDeductibleBeforePercent.Text="Ins Plans default to apply deductible before percent.";
			this.checkDeductibleBeforePercent.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkDeductibleBeforePercent.UseVisualStyleBackColor=true;
			this.checkDeductibleBeforePercent.Click+=new System.EventHandler(this.checkDeductibleBeforePercent_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label9);
			this.groupBox7.Controls.Add(this.textBoxDocPath);
			this.groupBox7.Controls.Add(this.label8);
			this.groupBox7.Controls.Add(this.textBoxStationary);
			this.groupBox7.Controls.Add(this.textBoxLogo);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.label5);
			this.groupBox7.Location=new System.Drawing.Point(275,551);
			this.groupBox7.Name="groupBox7";
			this.groupBox7.Size=new System.Drawing.Size(346,124);
			this.groupBox7.TabIndex=69;
			this.groupBox7.TabStop=false;
			this.groupBox7.Text="Communications Files (located in document path A-Z folder)";
			// 
			// label9
			// 
			this.label9.Location=new System.Drawing.Point(321,49);
			this.label9.Name="label9";
			this.label9.Size=new System.Drawing.Size(22,18);
			this.label9.TabIndex=63;
			this.label9.Text="-->";
			this.label9.TextAlign=System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDocPath
			// 
			this.textBoxDocPath.Location=new System.Drawing.Point(82,21);
			this.textBoxDocPath.Name="textBoxDocPath";
			this.textBoxDocPath.ReadOnly=true;
			this.textBoxDocPath.Size=new System.Drawing.Size(236,20);
			this.textBoxDocPath.TabIndex=62;
			this.toolTip1.SetToolTip(this.textBoxDocPath,"This shows you where you have your document path setup and where you should place"+
							" your files specified below.");
			// 
			// label8
			// 
			this.label8.Location=new System.Drawing.Point(6,22);
			this.label8.Name="label8";
			this.label8.Size=new System.Drawing.Size(70,20);
			this.label8.TabIndex=61;
			this.label8.Text="A-Z path";
			this.label8.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.label8,"This shows you where you have your document path setup and where you should place"+
							" your files specified below.");
			// 
			// textBoxStationary
			// 
			this.textBoxStationary.Location=new System.Drawing.Point(172,73);
			this.textBoxStationary.Name="textBoxStationary";
			this.textBoxStationary.Size=new System.Drawing.Size(146,20);
			this.textBoxStationary.TabIndex=60;
			this.toolTip1.SetToolTip(this.textBoxStationary,resources.GetString("textBoxStationary.ToolTip"));
			// 
			// textBoxLogo
			// 
			this.textBoxLogo.Location=new System.Drawing.Point(172,47);
			this.textBoxLogo.Name="textBoxLogo";
			this.textBoxLogo.Size=new System.Drawing.Size(146,20);
			this.textBoxLogo.TabIndex=59;
			this.toolTip1.SetToolTip(this.textBoxLogo,resources.GetString("textBoxLogo.ToolTip"));
			// 
			// label6
			// 
			this.label6.Location=new System.Drawing.Point(10,69);
			this.label6.Name="label6";
			this.label6.Size=new System.Drawing.Size(156,17);
			this.label6.TabIndex=58;
			this.label6.Text="Stationery Document (*.doc)";
			this.label6.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.label6,resources.GetString("label6.ToolTip"));
			// 
			// label5
			// 
			this.label5.Location=new System.Drawing.Point(10,49);
			this.label5.Name="label5";
			this.label5.Size=new System.Drawing.Size(156,18);
			this.label5.TabIndex=57;
			this.label5.Text="Letter Background (*.jpg)";
			this.label5.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.label5,resources.GetString("label5.ToolTip"));
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay=0;
			this.toolTip1.AutoPopDelay=600000;
			this.toolTip1.InitialDelay=0;
			this.toolTip1.IsBalloon=true;
			this.toolTip1.ReshowDelay=0;
			this.toolTip1.ToolTipIcon=System.Windows.Forms.ToolTipIcon.Info;
			this.toolTip1.ToolTipTitle="Open Dental Help";
			// 
			// radioBottom
			// 
			this.radioBottom.AutoSize=true;
			this.radioBottom.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.radioBottom.Location=new System.Drawing.Point(151,43);
			this.radioBottom.Name="radioBottom";
			this.radioBottom.Size=new System.Drawing.Size(87,17);
			this.radioBottom.TabIndex=190;
			this.radioBottom.TabStop=true;
			this.radioBottom.Text="Dock Bottom";
			this.toolTip1.SetToolTip(this.radioBottom,"Will show task list on the bottom of the main screen.\r\nYou can also change this s"+
							"etting by right clicking on the splitter bar between the task list and main prog"+
							"ram.");
			this.radioBottom.UseVisualStyleBackColor=true;
			// 
			// radioRight
			// 
			this.radioRight.AutoSize=true;
			this.radioRight.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.radioRight.Location=new System.Drawing.Point(40,43);
			this.radioRight.Name="radioRight";
			this.radioRight.Size=new System.Drawing.Size(79,17);
			this.radioRight.TabIndex=191;
			this.radioRight.TabStop=true;
			this.radioRight.Text="Dock Right";
			this.toolTip1.SetToolTip(this.radioRight,"Will show task list on the right side of the main screen.\r\nYou can also change th"+
							"is setting by right clicking on the splitter bar between the task list and main "+
							"program.");
			this.radioRight.UseVisualStyleBackColor=true;
			// 
			// checkTaskListAlwaysShow
			// 
			this.checkTaskListAlwaysShow.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkTaskListAlwaysShow.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkTaskListAlwaysShow.Location=new System.Drawing.Point(55,35);
			this.checkTaskListAlwaysShow.Name="checkTaskListAlwaysShow";
			this.checkTaskListAlwaysShow.Size=new System.Drawing.Size(190,14);
			this.checkTaskListAlwaysShow.TabIndex=74;
			this.checkTaskListAlwaysShow.Text="Global - Always show Task List";
			this.checkTaskListAlwaysShow.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkTaskListAlwaysShow,resources.GetString("checkTaskListAlwaysShow.ToolTip"));
			this.checkTaskListAlwaysShow.CheckedChanged+=new System.EventHandler(this.checkTaskListAlwaysShow_CheckedChanged);
			// 
			// checkTasksCheckOnStartup
			// 
			this.checkTasksCheckOnStartup.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkTasksCheckOnStartup.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkTasksCheckOnStartup.Location=new System.Drawing.Point(15,13);
			this.checkTasksCheckOnStartup.Name="checkTasksCheckOnStartup";
			this.checkTasksCheckOnStartup.Size=new System.Drawing.Size(230,19);
			this.checkTasksCheckOnStartup.TabIndex=75;
			this.checkTasksCheckOnStartup.Text="Check for new user tasks on startup";
			this.checkTasksCheckOnStartup.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkTasksCheckOnStartup,"This will alert you to new tasks when you log in.");
			// 
			// checkBoxTaskKeepListHidden
			// 
			this.checkBoxTaskKeepListHidden.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxTaskKeepListHidden.Location=new System.Drawing.Point(20,17);
			this.checkBoxTaskKeepListHidden.Name="checkBoxTaskKeepListHidden";
			this.checkBoxTaskKeepListHidden.Size=new System.Drawing.Size(218,20);
			this.checkBoxTaskKeepListHidden.TabIndex=185;
			this.checkBoxTaskKeepListHidden.Text="Don\'t show on this computer";
			this.checkBoxTaskKeepListHidden.TextAlign=System.Drawing.ContentAlignment.TopRight;
			this.toolTip1.SetToolTip(this.checkBoxTaskKeepListHidden,resources.GetString("checkBoxTaskKeepListHidden.ToolTip"));
			this.checkBoxTaskKeepListHidden.UseVisualStyleBackColor=true;
			this.checkBoxTaskKeepListHidden.CheckedChanged+=new System.EventHandler(this.checkBoxTaskKeepListHidden_CheckedChanged);
			// 
			// validNumY
			// 
			this.validNumY.Location=new System.Drawing.Point(192,75);
			this.validNumY.MaxLength=4;
			this.validNumY.MaxVal=1200;
			this.validNumY.MinVal=300;
			this.validNumY.Name="validNumY";
			this.validNumY.Size=new System.Drawing.Size(47,20);
			this.validNumY.TabIndex=188;
			this.validNumY.Text="542";
			this.validNumY.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.validNumY,resources.GetString("validNumY.ToolTip"));
			// 
			// validNumX
			// 
			this.validNumX.Location=new System.Drawing.Point(72,75);
			this.validNumX.MaxLength=4;
			this.validNumX.MaxVal=1200;
			this.validNumX.MinVal=300;
			this.validNumX.Name="validNumX";
			this.validNumX.Size=new System.Drawing.Size(47,20);
			this.validNumX.TabIndex=186;
			this.validNumX.Text="542";
			this.validNumX.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.validNumX,resources.GetString("validNumX.ToolTip"));
			// 
			// labelX
			// 
			this.labelX.Location=new System.Drawing.Point(4,75);
			this.labelX.Name="labelX";
			this.labelX.Size=new System.Drawing.Size(62,18);
			this.labelX.TabIndex=187;
			this.labelX.Text="X Default";
			this.labelX.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelY
			// 
			this.labelY.Location=new System.Drawing.Point(124,75);
			this.labelY.Name="labelY";
			this.labelY.Size=new System.Drawing.Size(62,18);
			this.labelY.TabIndex=189;
			this.labelY.Text="Y Default";
			this.labelY.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage=global::OpenDental.Properties.Resources.stationary_sample1;
			this.pictureBox1.BackgroundImageLayout=System.Windows.Forms.ImageLayout.None;
			this.pictureBox1.Location=new System.Drawing.Point(627,551);
			this.pictureBox1.Name="pictureBox1";
			this.pictureBox1.Size=new System.Drawing.Size(101,124);
			this.pictureBox1.TabIndex=71;
			this.pictureBox1.TabStop=false;
			// 
			// label11
			// 
			this.label11.Location=new System.Drawing.Point(520,368);
			this.label11.Name="label11";
			this.label11.Size=new System.Drawing.Size(195,15);
			this.label11.TabIndex=73;
			this.label11.Text="Show ID in title bar";
			this.label11.TextAlign=System.Drawing.ContentAlignment.TopRight;
			// 
			// comboShowID
			// 
			this.comboShowID.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboShowID.FormattingEnabled=true;
			this.comboShowID.Location=new System.Drawing.Point(717,364);
			this.comboShowID.Name="comboShowID";
			this.comboShowID.Size=new System.Drawing.Size(130,21);
			this.comboShowID.TabIndex=72;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBoxTaskDefaults);
			this.groupBox2.Controls.Add(this.checkTaskListAlwaysShow);
			this.groupBox2.Controls.Add(this.checkTasksCheckOnStartup);
			this.groupBox2.Location=new System.Drawing.Point(12,509);
			this.groupBox2.Name="groupBox2";
			this.groupBox2.Size=new System.Drawing.Size(257,166);
			this.groupBox2.TabIndex=188;
			this.groupBox2.TabStop=false;
			this.groupBox2.Text="Task List";
			// 
			// groupBoxTaskDefaults
			// 
			this.groupBoxTaskDefaults.Controls.Add(this.radioRight);
			this.groupBoxTaskDefaults.Controls.Add(this.radioBottom);
			this.groupBoxTaskDefaults.Controls.Add(this.validNumY);
			this.groupBoxTaskDefaults.Controls.Add(this.labelY);
			this.groupBoxTaskDefaults.Controls.Add(this.validNumX);
			this.groupBoxTaskDefaults.Controls.Add(this.labelX);
			this.groupBoxTaskDefaults.Controls.Add(this.checkBoxTaskKeepListHidden);
			this.groupBoxTaskDefaults.Enabled=false;
			this.groupBoxTaskDefaults.Location=new System.Drawing.Point(6,59);
			this.groupBoxTaskDefaults.Name="groupBoxTaskDefaults";
			this.groupBoxTaskDefaults.Size=new System.Drawing.Size(245,101);
			this.groupBoxTaskDefaults.TabIndex=76;
			this.groupBoxTaskDefaults.TabStop=false;
			this.groupBoxTaskDefaults.Text="Local Computer Default Settings";
			// 
			// textClaimAttachPath
			// 
			this.textClaimAttachPath.Location=new System.Drawing.Point(416,319);
			this.textClaimAttachPath.Name="textClaimAttachPath";
			this.textClaimAttachPath.Size=new System.Drawing.Size(431,20);
			this.textClaimAttachPath.TabIndex=189;
			// 
			// label13
			// 
			this.label13.AutoSize=true;
			this.label13.Location=new System.Drawing.Point(264,322);
			this.label13.Name="label13";
			this.label13.Size=new System.Drawing.Size(147,13);
			this.label13.TabIndex=190;
			this.label13.Text="Claim Attachment Export Path";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkAutoClearEntryStatus);
			this.groupBox3.Location=new System.Drawing.Point(25,266);
			this.groupBox3.Name="groupBox3";
			this.groupBox3.Size=new System.Drawing.Size(409,40);
			this.groupBox3.TabIndex=191;
			this.groupBox3.TabStop=false;
			this.groupBox3.Text="Chart module";
			// 
			// checkAutoClearEntryStatus
			// 
			this.checkAutoClearEntryStatus.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkAutoClearEntryStatus.Checked=true;
			this.checkAutoClearEntryStatus.CheckState=System.Windows.Forms.CheckState.Checked;
			this.checkAutoClearEntryStatus.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkAutoClearEntryStatus.Location=new System.Drawing.Point(17,19);
			this.checkAutoClearEntryStatus.Name="checkAutoClearEntryStatus";
			this.checkAutoClearEntryStatus.Size=new System.Drawing.Size(372,15);
			this.checkAutoClearEntryStatus.TabIndex=73;
			this.checkAutoClearEntryStatus.Text="Automatically reset entry stats to TreatPlan after selecting a different patient";
			this.checkAutoClearEntryStatus.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkAutoClearEntryStatus.UseVisualStyleBackColor=true;
			// 
			// butLanguages
			// 
			this.butLanguages.AdjustImageLocation=new System.Drawing.Point(0,0);
			this.butLanguages.Autosize=true;
			this.butLanguages.BtnShape=OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLanguages.BtnStyle=OpenDental.UI.enumType.XPStyle.Silver;
			this.butLanguages.CornerRadius=4F;
			this.butLanguages.Location=new System.Drawing.Point(758,520);
			this.butLanguages.Name="butLanguages";
			this.butLanguages.Size=new System.Drawing.Size(88,23);
			this.butLanguages.TabIndex=63;
			this.butLanguages.Text="Edit Languages";
			this.butLanguages.Click+=new System.EventHandler(this.butLanguages_Click);
			// 
			// textSigInterval
			// 
			this.textSigInterval.Location=new System.Drawing.Point(773,386);
			this.textSigInterval.MaxVal=1000000;
			this.textSigInterval.MinVal=1;
			this.textSigInterval.Name="textSigInterval";
			this.textSigInterval.Size=new System.Drawing.Size(74,20);
			this.textSigInterval.TabIndex=57;
			this.textSigInterval.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation=new System.Drawing.Point(0,0);
			this.butCancel.Anchor=((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize=true;
			this.butCancel.BtnShape=OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle=OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius=4F;
			this.butCancel.DialogResult=System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location=new System.Drawing.Point(771,649);
			this.butCancel.Name="butCancel";
			this.butCancel.Size=new System.Drawing.Size(75,26);
			this.butCancel.TabIndex=8;
			this.butCancel.Text="&Cancel";
			this.butCancel.Click+=new System.EventHandler(this.butCancel_Click);
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation=new System.Drawing.Point(0,0);
			this.butOK.Anchor=((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize=true;
			this.butOK.BtnShape=OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle=OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius=4F;
			this.butOK.Location=new System.Drawing.Point(771,611);
			this.butOK.Name="butOK";
			this.butOK.Size=new System.Drawing.Size(75,26);
			this.butOK.TabIndex=7;
			this.butOK.Text="&OK";
			this.butOK.Click+=new System.EventHandler(this.butOK_Click);
			// 
			// checkShowFamilyCommByDefault
			// 
			this.checkShowFamilyCommByDefault.CheckAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.checkShowFamilyCommByDefault.FlatStyle=System.Windows.Forms.FlatStyle.System;
			this.checkShowFamilyCommByDefault.Location=new System.Drawing.Point(6,257);
			this.checkShowFamilyCommByDefault.Name="checkShowFamilyCommByDefault";
			this.checkShowFamilyCommByDefault.Size=new System.Drawing.Size(381,17);
			this.checkShowFamilyCommByDefault.TabIndex=75;
			this.checkShowFamilyCommByDefault.Text="Show Family Comm Entries By Default";
			this.checkShowFamilyCommByDefault.TextAlign=System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkShowFamilyCommByDefault,"Generally used with \"Balances don\'t subtract insurance estimate\"\r\nchecked to the "+
							"upper right of this option in the \"Statements\" section.\r\nHowever, it will work w"+
							"ell either way.");
			// 
			// FormMisc
			// 
			this.AutoScaleBaseSize=new System.Drawing.Size(5,13);
			this.ClientSize=new System.Drawing.Size(893,699);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.textClaimAttachPath);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.comboShowID);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkDeductibleBeforePercent);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.butLanguages);
			this.Controls.Add(this.checkMedicalEclaimsEnabled);
			this.Controls.Add(this.checkInsurancePlansShared);
			this.Controls.Add(this.textSigInterval);
			this.Controls.Add(this.textMainWindowTitle);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkRandomPrimaryKeys);
			this.Controls.Add(this.checkEclaimsSeparateTreatProv);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkITooth);
			this.Controls.Add(this.label14);
			this.Icon=((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox=false;
			this.MinimizeBox=false;
			this.Name="FormMisc";
			this.ShowInTaskbar=false;
			this.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text="Miscellaneous Setup";
			this.Load+=new System.EventHandler(this.FormMisc_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBoxTaskDefaults.ResumeLayout(false);
			this.groupBoxTaskDefaults.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormMisc_Load(object sender, System.EventArgs e) {
			textTreatNote.Text=PrefB.GetString("TreatmentPlanNote");
			checkTreatPlanShowGraphics.Checked=PrefB.GetBool("TreatPlanShowGraphics");
			checkTreatPlanShowCompleted.Checked=PrefB.GetBool("TreatPlanShowCompleted");
			//checkTreatPlanShowIns.Checked=PrefB.GetBool("TreatPlanShowIns");
			//checkTreatPlanShowDiscount.Checked=PrefB.GetBool("TreatPlanShowDiscount");
			checkStatementShowReturnAddress.Checked=PrefB.GetBool("StatementShowReturnAddress");
			checkShowCC.Checked=PrefB.GetBool("StatementShowCreditCard");
			comboUseChartNum.Items.Add(Lan.g(this,"PatNum"));
			comboUseChartNum.Items.Add(Lan.g(this,"ChartNumber"));
			if(PrefB.GetBool("StatementAccountsUseChartNumber")){
				comboUseChartNum.SelectedIndex=1;
			}
			else{
				comboUseChartNum.SelectedIndex=0;
			}
			if(PrefB.GetInt("StatementsCalcDueDate")!=-1){
				textStatementsCalcDueDate.Text=PrefB.GetInt("StatementsCalcDueDate").ToString();
			}
			checkBalancesDontSubtractIns.Checked=PrefB.GetBool("BalancesDontSubtractIns");
			checkAgingMonthly.Checked=PrefB.GetBool("AgingCalculatedMonthlyInsteadOfDaily");
			if(PrefB.GetInt("ProcessSigsIntervalInSecs")==0){
				textSigInterval.Text="";
			}
			else{
				textSigInterval.Text=PrefB.GetInt("ProcessSigsIntervalInSecs").ToString();
			}
			checkRandomPrimaryKeys.Checked=PrefB.GetBool("RandomPrimaryKeys");
			if(checkRandomPrimaryKeys.Checked){
				//not allowed to uncheck it
				checkRandomPrimaryKeys.Enabled=false;
			}
			textMainWindowTitle.Text=PrefB.GetString("MainWindowTitle");
			comboShowID.Items.Add(Lan.g(this,"None"));
			comboShowID.Items.Add(Lan.g(this,"PatNum"));
			comboShowID.Items.Add(Lan.g(this,"ChartNumber"));
			comboShowID.SelectedIndex=PrefB.GetInt("ShowIDinTitleBar");
			checkEclaimsSeparateTreatProv.Checked=PrefB.GetBool("EclaimsSeparateTreatProv");
			checkMedicalEclaimsEnabled.Checked=PrefB.GetBool("MedicalEclaimsEnabled");
			checkITooth.Checked=PrefB.GetBool("UseInternationalToothNumbers");
			checkInsurancePlansShared.Checked=PrefB.GetBool("InsurancePlansShared");
			checkSolidBlockouts.Checked=PrefB.GetBool("SolidBlockouts");
			checkStoreCCnumbers.Checked=PrefB.GetBool("StoreCCnumbers");
			checkDeductibleBeforePercent.Checked=PrefB.GetBool("DeductibleBeforePercentAsDefault");
			checkBoldBalance.Checked=PrefB.GetBool("BoldFamilyAccountBalanceView");
			checkShowAccountNotes.Checked=PrefB.GetBool("ShowNotesInAccount");
			checkSimpleStatement.Checked=PrefB.GetBool("PrintSimpleStatements");
			checkBrokenApptNote.Checked=PrefB.GetBool("BrokenApptCommLogNotAdjustment");
			textClaimAttachPath.Text=PrefB.GetString("ClaimAttachExportPath");
			string AZpath=FormPath.GetPreferredImagePath();
			if(AZpath!=null){
				textBoxDocPath.Text =AZpath;
			}
			textBoxLogo.Text = PrefB.GetString("StationaryImage");
			textBoxStationary.Text = PrefB.GetString("StationaryDocument");
			checkApptBubbleDelay.Checked = PrefB.GetBool("ApptBubbleDelay");
			checkAppointmentBubblesDisabled.Checked=PrefB.GetBool("AppointmentBubblesDisabled");
			posAdjTypes=DefB.GetPositiveAdjTypes();
			for(int i=0;i<posAdjTypes.Count;i++){
				comboFinanceChargeAdjType.Items.Add(posAdjTypes[i].ItemName);
				if(PrefB.GetInt("FinanceChargeAdjustmentType")==posAdjTypes[i].DefNum){
					comboFinanceChargeAdjType.SelectedIndex=i;
				}
				comboBrokenApptAdjType.Items.Add(posAdjTypes[i].ItemName);
				if(PrefB.GetInt("BrokenAppointmentAdjustmentType")==posAdjTypes[i].DefNum) {
					comboBrokenApptAdjType.SelectedIndex=i;
				}
			}
			checkTasksCheckOnStartup.Checked=PrefB.GetBool("TasksCheckOnStartup");
			checkTaskListAlwaysShow.Checked=PrefB.GetBool("TaskListAlwaysShowsAtBottom");
			if(checkTaskListAlwaysShow.Checked) {
				groupBoxTaskDefaults.Enabled=true;
			}
			else {
				groupBoxTaskDefaults.Enabled=false;
			}
			computerPref=ComputerPrefs.GetForLocalComputer();
			checkBoxTaskKeepListHidden.Checked=computerPref.TaskKeepListHidden;
			if(computerPref.TaskDock==0) {
				radioBottom.Checked=true;
			}
			else {
				radioRight.Checked=true;
			}
			validNumX.Text=computerPref.TaskX.ToString();
			validNumY.Text=computerPref.TaskY.ToString();
				/*for(int i=0;i<DefB.Short[(int)DefCat.TxPriorities].Length;i++){
					comboPriority.Items.Add(DefB.Short[(int)DefCat.TxPriorities][i].ItemName);
					if(PrefB.GetInt("TreatPlanPriorityForDeclined")==DefB.Short[(int)DefCat.TxPriorities][i].DefNum){
						comboPriority.SelectedIndex=i;
					}
				}*/
			checkApptExclamation.Checked=PrefB.GetBool("ApptExclamationShowForUnsentIns");
			checkProviderIncomeShows.Checked=PrefB.GetBool("ProviderIncomeTransferShows");
			checkAutoClearEntryStatus.Checked=PrefB.GetBool("AutoResetTPEntryStatus");
			checkShowFamilyCommByDefault.Checked=PrefB.GetBool("ShowAccountFamilyCommEntries");
		}

		private void checkRandomPrimaryKeys_Click(object sender, System.EventArgs e) {
			if(MessageBox.Show("Are you absolutely sure you want to enable random primary keys?\r\n"
				+"Advantages:\r\n"
				+"Multiple servers can stay synchronized using merge replication.\r\n"
				+"Realtime connection between servers not required.\r\n"
				+"Data can be entered on all servers and synchronized later.\r\n"
				+"Disadvantages:\r\n"
				+"Slightly slower.\r\n"
				+"Difficult to set up.\r\n"
				+"Primary keys much longer, so not as user friendly.","",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
			{
				checkRandomPrimaryKeys.Checked=false;
			}
		}

		private void butLanguages_Click(object sender,EventArgs e) {
			FormLanguagesUsed FormL=new FormLanguagesUsed();
			FormL.ShowDialog();
			if(FormL.DialogResult==DialogResult.OK){
				DataValid.SetInvalid(InvalidTypes.Prefs);
			}
		}

		private void checkDeductibleBeforePercent_Click(object sender,EventArgs e) {
			if(!MsgBox.Show(this,true,"Change all insurance plans right now?")){
				return;
			}
			string command="UPDATE insplan SET DedBeforePerc=";
			if(checkDeductibleBeforePercent.Checked){
				command+="1";
			}
			else{
				command+="0";
			}
			int result=General.NonQ(command);
			MessageBox.Show(Lan.g(this,"Plans changed: ")+result.ToString());
		}
		private void checkTaskListAlwaysShow_CheckedChanged(object sender,EventArgs e) {
			if(checkTaskListAlwaysShow.Checked) {
				groupBoxTaskDefaults.Enabled=true;
			}
			else {
				groupBoxTaskDefaults.Enabled=false;
			}
		}

		private void checkBoxTaskKeepListHidden_CheckedChanged(object sender,EventArgs e) {
			if(checkBoxTaskKeepListHidden.Checked) {
				radioBottom.Enabled=false;
				radioRight.Enabled=false;
				labelX.Enabled=false;
				labelY.Enabled=false;
				validNumX.Enabled=false;
				validNumY.Enabled=false;
			}
			else {
				radioBottom.Enabled=true;
				radioRight.Enabled=true;
				labelX.Enabled=true;
				labelY.Enabled=true;
				validNumX.Enabled=true;
				validNumY.Enabled=true;

			}
		}
		private void butOK_Click(object sender, System.EventArgs e) {
			if(comboBrokenApptAdjType.SelectedIndex==-1){
				MsgBox.Show(this,"Please enter an adjustment type for broken appointments.");
				return;
			}
			if(comboFinanceChargeAdjType.SelectedIndex==-1) {
				MsgBox.Show(this,"Please enter an adjustment type for finance charges.");
				return;
			}
			if(!Directory.Exists(this.textClaimAttachPath.Text)) {
				MsgBox.Show(this,"Please enter a valid claim attachment path.");
				return;
			}
			//if(comboPriority.SelectedIndex==-1) {
			//	MsgBox.Show(this,"Please enter priority for declined treatment.");
			//	return;
			//}
			if(textStatementsCalcDueDate.errorProvider1.GetError(textStatementsCalcDueDate)!="")
			{
				MessageBox.Show(Lan.g(this,"Please fix data entry errors first."));
				return;
			}
			bool changed=false;
			if( Prefs.UpdateString("TreatmentPlanNote",textTreatNote.Text)
				| Prefs.UpdateBool("TreatPlanShowGraphics",checkTreatPlanShowGraphics.Checked)
				| Prefs.UpdateBool("TreatPlanShowCompleted",checkTreatPlanShowCompleted.Checked)
				//| Prefs.UpdateBool("TreatPlanShowIns",checkTreatPlanShowIns.Checked)
				//| Prefs.UpdateBool("TreatPlanShowDiscount",checkTreatPlanShowDiscount.Checked)
				| Prefs.UpdateBool("StatementShowReturnAddress",checkStatementShowReturnAddress.Checked)
				| Prefs.UpdateBool("StatementShowCreditCard",checkShowCC.Checked)
				| Prefs.UpdateBool("StatementAccountsUseChartNumber",comboUseChartNum.SelectedIndex==1)
				| Prefs.UpdateBool("BalancesDontSubtractIns",checkBalancesDontSubtractIns.Checked)
				| Prefs.UpdateBool("AgingCalculatedMonthlyInsteadOfDaily",checkAgingMonthly.Checked)
				| Prefs.UpdateBool("RandomPrimaryKeys",checkRandomPrimaryKeys.Checked)
				| Prefs.UpdateString("MainWindowTitle",textMainWindowTitle.Text)
				| Prefs.UpdateBool("EclaimsSeparateTreatProv",checkEclaimsSeparateTreatProv.Checked)
				| Prefs.UpdateBool("MedicalEclaimsEnabled",checkMedicalEclaimsEnabled.Checked)
				| Prefs.UpdateBool("UseInternationalToothNumbers",checkITooth.Checked)
				| Prefs.UpdateBool("InsurancePlansShared",checkInsurancePlansShared.Checked)
				| Prefs.UpdateBool("SolidBlockouts", checkSolidBlockouts.Checked)
				| Prefs.UpdateBool("StoreCCnumbers", checkStoreCCnumbers.Checked)
				| Prefs.UpdateBool("DeductibleBeforePercentAsDefault",checkDeductibleBeforePercent.Checked)
				| Prefs.UpdateBool("BoldFamilyAccountBalanceView", checkBoldBalance.Checked)
				| Prefs.UpdateBool("ShowNotesInAccount", checkShowAccountNotes.Checked)
				| Prefs.UpdateBool("PrintSimpleStatements", checkSimpleStatement.Checked)
				| Prefs.UpdateBool("BrokenApptCommLogNotAdjustment", checkBrokenApptNote.Checked)
				| Prefs.UpdateString("StationaryImage", textBoxLogo.Text)
				| Prefs.UpdateString("StationaryDocument", textBoxStationary.Text)
				| Prefs.UpdateBool("ApptBubbleDelay", checkApptBubbleDelay.Checked)
				| Prefs.UpdateBool("AppointmentBubblesDisabled", checkAppointmentBubblesDisabled.Checked)
				| Prefs.UpdateInt("ShowIDinTitleBar",comboShowID.SelectedIndex)
				| Prefs.UpdateInt("FinanceChargeAdjustmentType",posAdjTypes[comboFinanceChargeAdjType.SelectedIndex].DefNum)
				| Prefs.UpdateInt("BrokenAppointmentAdjustmentType",posAdjTypes[comboBrokenApptAdjType.SelectedIndex].DefNum)
				| Prefs.UpdateBool("TaskListAlwaysShowsAtBottom", checkTaskListAlwaysShow.Checked)
				| Prefs.UpdateBool("TasksCheckOnStartup", checkTasksCheckOnStartup.Checked)
				//| Prefs.UpdateInt("TreatPlanPriorityForDeclined",DefB.Short[(int)DefCat.TxPriorities][comboPriority.SelectedIndex].DefNum)
				| Prefs.UpdateBool("ApptExclamationShowForUnsentIns", checkApptExclamation.Checked)
				| Prefs.UpdateBool("ProviderIncomeTransferShows", checkProviderIncomeShows.Checked)
				| Prefs.UpdateString("ClaimAttachExportPath",textClaimAttachPath.Text)
				| Prefs.UpdateBool("AutoResetTPEntryStatus",checkAutoClearEntryStatus.Checked)
				| Prefs.UpdateBool("ShowAccountFamilyCommEntries",checkShowFamilyCommByDefault.Checked)
				)
			{
				changed=true;
			}
			//task list
			computerPref.TaskKeepListHidden=checkBoxTaskKeepListHidden.Checked;
			if(radioBottom.Checked){	
				computerPref.TaskDock=0;
			}
			else{
				computerPref.TaskDock=1;
			}
			computerPref.TaskX=Convert.ToInt32(validNumX.Text);
			computerPref.TaskY=Convert.ToInt32(validNumY.Text);
			ComputerPrefs.Update(computerPref);
				changed=true;
			
			if(textStatementsCalcDueDate.Text==""){
				if(Prefs.UpdateInt("StatementsCalcDueDate",-1)){
					changed=true;
				}
			}
			else{
				if(Prefs.UpdateInt("StatementsCalcDueDate",PIn.PInt(textStatementsCalcDueDate.Text))){
					changed=true;
				}
			}
			if(textSigInterval.Text==""){
				if(Prefs.UpdateInt("ProcessSigsIntervalInSecs",0)){
					changed=true;
				}
			}
			else{
				if(Prefs.UpdateInt("ProcessSigsIntervalInSecs",PIn.PInt(textSigInterval.Text))){
					changed=true;
				}
			}
			if(changed){
				DataValid.SetInvalid(InvalidTypes.Prefs);
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}




