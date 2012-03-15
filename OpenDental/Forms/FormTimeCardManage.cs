using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormTimeCardManage:Form {
		private int SelectedPayPeriod;
		private DateTime DateStart;
		private DateTime DateStop;
		private DataTable MainTable; 

		public FormTimeCardManage() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormTimeCardManage_Load(object sender,EventArgs e) {
			SelectedPayPeriod=PayPeriods.GetForDate(DateTime.Today);
			FillPayPeriod();
			FillMain();
		}

		private void FillMain() {
			MainTable=ClockEvents.GetTimeCardManage(DateStart,DateStop);
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g(this,"Employee"),140);
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"Total Hrs"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"Regular Hrs"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"O/Time Hrs"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"Adjustments"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"Reg Adjustments"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"OT Adjustments"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			col=new ODGridColumn(Lan.g(this,"Breaks?"),100);
			col.TextAlign=HorizontalAlignment.Center;
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<MainTable.Rows.Count;i++) {
				row=new ODGridRow();
				row.Cells.Add(Employees.GetNameFL(PIn.Long(MainTable.Rows[i]["EmployeeNum"].ToString())));
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["tempTotalTime"].ToString()).ToStringHmm());
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["tempRegHrs"].ToString()).ToStringHmm());
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["tempOverTime"].ToString()).ToStringHmm());
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["Adjustments"].ToString()).ToStringHmm());
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["AdjReg"].ToString()).ToStringHmm());
				row.Cells.Add(PIn.Time(MainTable.Rows[i]["AdjOTime"].ToString()).ToStringHmm());
				row.Cells.Add("");
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
		}

		///<summary>SelectedPayPeriod should already be set.  This simply fills the screen with that data.</summary>
		private void FillPayPeriod() {
			DateStart=PayPeriods.List[SelectedPayPeriod].DateStart;
			DateStop=PayPeriods.List[SelectedPayPeriod].DateStop;
			textDateStart.Text=DateStart.ToShortDateString();
			textDateStop.Text=DateStop.ToShortDateString();
			if(PayPeriods.List[SelectedPayPeriod].DatePaycheck.Year<1880) {
				textDatePaycheck.Text="";
			}
			else {
				textDatePaycheck.Text=PayPeriods.List[SelectedPayPeriod].DatePaycheck.ToShortDateString();
			}
		}

		private void gridMain_CellDoubleClick(object sender,UI.ODGridClickEventArgs e) {
			FormTimeCard FormTC=new FormTimeCard();
			FormTC.EmployeeCur=Employees.GetEmp(PIn.Long(MainTable.Rows[e.Row]["EmployeeNum"].ToString()));
			FormTC.ShowDialog();
			FillMain();
		}

		private void butLeft_Click(object sender,EventArgs e) {
			if(SelectedPayPeriod==0){
				return;
			}
			SelectedPayPeriod--;
			FillPayPeriod();
			FillMain();
		}

		private void butRight_Click(object sender,EventArgs e) {
			if(SelectedPayPeriod==PayPeriods.List.Length-1) {
				return;
			}
			SelectedPayPeriod++;
			FillPayPeriod();
			FillMain();
		}

		private void butReport_Click(object sender,EventArgs e) {
			//Basically a preview of gridMain (every employee on one page), allow user to export as excel sheet or print it.
		}

		private void butPrint_Click(object sender,EventArgs e) {
			//A preview of every single emp on their own page will show up. User will print from there.
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}