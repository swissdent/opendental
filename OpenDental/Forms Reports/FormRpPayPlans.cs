using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.Drawing.Printing;
using System.Windows.Forms;
using OpenDental.ReportingComplex;
using OpenDental.UI;
using OpenDentBusiness;
using CodeBase;

namespace OpenDental
{
	/// <summary>
	/// Summary description for FormRpApptWithPhones.
	/// </summary>
	public class FormRpPayPlans:System.Windows.Forms.Form {
		private OpenDental.UI.Button butCancel;
		private OpenDental.UI.Button butOK;
		private CheckBox checkHideCompletePlans;
		//private int pagesPrinted;
		private ErrorProvider errorProvider1=new ErrorProvider();
		//private DataTable BirthdayTable;
		//private int patientsPrinted;
		//private PrintDocument pd;
		//private OpenDental.UI.PrintPreview printPreview;

		///<summary></summary>
		public FormRpPayPlans()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Lan.F(this);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRpPayPlans));
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.checkHideCompletePlans = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
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
			this.butCancel.Location = new System.Drawing.Point(546, 216);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 44;
			this.butCancel.Text = "&Cancel";
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(546, 176);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 43;
			this.butOK.Text = "Report";
			this.butOK.Click += new System.EventHandler(this.butReport_Click);
			// 
			// checkHideCompletePlans
			// 
			this.checkHideCompletePlans.AutoSize = true;
			this.checkHideCompletePlans.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkHideCompletePlans.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkHideCompletePlans.Location = new System.Drawing.Point(167, 216);
			this.checkHideCompletePlans.Name = "checkHideCompletePlans";
			this.checkHideCompletePlans.Size = new System.Drawing.Size(180, 18);
			this.checkHideCompletePlans.TabIndex = 45;
			this.checkHideCompletePlans.Text = "Hide Completed Payment Plans";
			this.checkHideCompletePlans.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkHideCompletePlans.UseVisualStyleBackColor = true;
			// 
			// FormRpPayPlans
			// 
			this.AcceptButton = this.butOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butCancel;
			this.ClientSize = new System.Drawing.Size(660, 264);
			this.Controls.Add(this.checkHideCompletePlans);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormRpPayPlans";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payment Plans Report";
			this.Load += new System.EventHandler(this.FormRpPayPlans_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormRpPayPlans_Load(object sender, System.EventArgs e){
			checkHideCompletePlans.Checked=true;
		}

		private void butReport_Click(object sender, System.EventArgs e){
			//if(errorProvider1.GetError(textDateFrom) != ""
			//	|| errorProvider1.GetError(textDateTo) != "") 
			//{
			//	MsgBox.Show(this,"Please fix data entry errors first.");
			//	return;
			//}
			//DateTime dateFrom=PIn.PDate(textDateFrom.Text);
			//DateTime dateTo=PIn.PDate(textDateTo.Text);
			//if(dateTo < dateFrom) 
			//{
			//	MsgBox.Show(this,"To date cannot be before From date.");
			//	return;
			//}
			Font font=new Font("Tahoma",9);
			Font fontTitle=new Font("Tahoma",17,FontStyle.Bold);
			Font fontSubTitle=new Font("Tahoma",10,FontStyle.Bold);
			ReportComplex report=new ReportComplex(true,false);
			report.ReportName=Lan.g(this,"PaymentPlans");
			report.AddTitle("Title",Lan.g(this,"Payment Plans"),fontTitle);
			report.AddSubTitle("PracticeTitle",PrefC.GetString(PrefName.PracticeTitle),fontSubTitle);
			report.AddSubTitle("Date SubTitle",DateTime.Today.ToShortDateString(),fontSubTitle);
			DataTable table=new DataTable();
			table.Columns.Add("guarantor");
			table.Columns.Add("ins");
			table.Columns.Add("princ");
			table.Columns.Add("paid");
			table.Columns.Add("due");
			table.Columns.Add("dueTen");
			DataRow row;
			string datesql="CURDATE()";
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				datesql="(SELECT CURRENT_DATE FROM dual)";
			}
			//Oracle TODO:  Either put entire query without GROUP BY in SUBSELECT and then GROUP BY outside, or rewrite query to use joins instead of subselects.
			string command="SELECT FName,LName,MiddleI,PlanNum,Preferred,PlanNum, "
				+"COALESCE((SELECT SUM(Principal+Interest) FROM payplancharge WHERE payplancharge.PayPlanNum=payplan.PayPlanNum "
					+"AND ChargeDate <= "+datesql+@"),0) '_accumDue', "
				+"COALESCE((SELECT SUM(Principal+Interest) FROM payplancharge WHERE payplancharge.PayPlanNum=payplan.PayPlanNum "
					+"AND ChargeDate <= "+DbHelper.DateAddDay(datesql,POut.Long(PrefC.GetLong(PrefName.PayPlansBillInAdvanceDays)))+@"),0) '_dueTen', "
				+"COALESCE((SELECT SUM(SplitAmt) FROM paysplit WHERE paysplit.PayPlanNum=payplan.PayPlanNum AND paysplit.PayPlanNum!=0),0) '_paid', "
				+"COALESCE((SELECT SUM(InsPayAmt) FROM claimproc WHERE claimproc.PayPlanNum=payplan.PayPlanNum AND claimproc.Status IN(1,4,5) AND claimproc.PayPlanNum!=0),0) '_insPaid', "
				+"COALESCE((SELECT SUM(Principal) FROM payplancharge WHERE payplancharge.PayPlanNum=payplan.PayPlanNum),0) '_principal' "
				+"FROM payplan "
				+"LEFT JOIN patient ON patient.PatNum=payplan.Guarantor "
				//WHERE SUBSTRING(Birthdate,6,5) >= '"+dateFrom.ToString("MM-dd")+"' "
				//+"AND SUBSTRING(Birthdate,6,5) <= '"+dateTo.ToString("MM-dd")+"' "
				+"GROUP BY FName,LName,MiddleI,Preferred,payplan.PayPlanNum ";
			if(checkHideCompletePlans.Checked) {
				command+="HAVING _paid+_insPaid < _principal ";
			}
			command+="ORDER BY LName,FName";
			DataTable raw=Reports.GetTable(command);
			//DateTime payplanDate;
			Patient pat;
			double princ;
			double paid;
			double accumDue;
			double dueTen;
			for(int i=0;i<raw.Rows.Count;i++) {
				princ=PIn.Double(raw.Rows[i]["_principal"].ToString());
				if(raw.Rows[i]["PlanNum"].ToString()=="0") {//pat payplan
					paid=PIn.Double(raw.Rows[i]["_paid"].ToString());
				}
				else {//ins payplan
					paid=PIn.Double(raw.Rows[i]["_insPaid"].ToString());
				}
				accumDue=PIn.Double(raw.Rows[i]["_accumDue"].ToString());
				dueTen=PIn.Double(raw.Rows[i]["_dueTen"].ToString());
				row=table.NewRow();
				//payplanDate=PIn.PDate(raw.Rows[i]["PayPlanDate"].ToString());
				//row["date"]=raw.Rows[i]["PayPlanDate"].ToString();//payplanDate.ToShortDateString();
				pat=new Patient();
				pat.LName=raw.Rows[i]["LName"].ToString();
				pat.FName=raw.Rows[i]["FName"].ToString();
				pat.MiddleI=raw.Rows[i]["MiddleI"].ToString();
				pat.Preferred=raw.Rows[i]["Preferred"].ToString();
				row["guarantor"]=pat.GetNameLF();
				if(raw.Rows[i]["PlanNum"].ToString()=="0") {
					row["ins"]="";
				}
				else {
					row["ins"]="X";
				}
				row["princ"]=princ.ToString("f");
				row["paid"]=paid.ToString("f");
				row["due"]=(accumDue-paid).ToString("f");
				row["dueTen"]=(dueTen-paid).ToString("f");
				table.Rows.Add(row);
			}
			QueryObject query=report.AddQuery(table,"","",SplitByKind.None,1,true);
			query.AddColumn("Guarantor",160,FieldValueType.String,font);
			query.AddColumn("Ins",40,FieldValueType.String,font);
			query.GetColumnHeader("Ins").ContentAlignment=ContentAlignment.MiddleCenter;
			query.GetColumnDetail("Ins").ContentAlignment=ContentAlignment.MiddleCenter;
			query.AddColumn("Princ",100,FieldValueType.String,font);
			query.GetColumnHeader("Princ").ContentAlignment=ContentAlignment.MiddleRight;
			query.GetColumnDetail("Princ").ContentAlignment=ContentAlignment.MiddleRight;
			query.AddColumn("Paid",100,FieldValueType.String,font);
			query.GetColumnHeader("Paid").ContentAlignment=ContentAlignment.MiddleRight;
			query.GetColumnDetail("Paid").ContentAlignment=ContentAlignment.MiddleRight;
			query.AddColumn("Due Now",100,FieldValueType.String,font);
			query.GetColumnHeader("Due Now").ContentAlignment=ContentAlignment.MiddleRight;
			query.GetColumnDetail("Due Now").ContentAlignment=ContentAlignment.MiddleRight;
			query.AddColumn("Due in "+PrefC.GetLong(PrefName.PayPlansBillInAdvanceDays).ToString()
				+" Days",100,FieldValueType.String,font);
			query.GetColumnHeader("Due in "+PrefC.GetLong(PrefName.PayPlansBillInAdvanceDays).ToString()
				+" Days").ContentAlignment=ContentAlignment.MiddleRight;
			query.GetColumnDetail("Due in "+PrefC.GetLong(PrefName.PayPlansBillInAdvanceDays).ToString()
				+" Days").ContentAlignment=ContentAlignment.MiddleRight;
			if(!report.SubmitQueries()) {
				return;
			}
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		

		













		

		

		
	}
}
