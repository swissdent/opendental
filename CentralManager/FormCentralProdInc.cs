using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental;
using OpenDental.ReportingComplex;
using System.Globalization;
using CodeBase;
using System.Threading;
using System.Linq;

namespace CentralManager {
	public partial class FormCentralProdInc:Form {
		private DateTime _dateFrom;
		private DateTime _dateTo;
		///<summary>Can be set externally when automating.</summary>
		public string DailyMonthlyAnnual;
		///<summary>If set externally, then this sets the date on startup.</summary>
		public DateTime DateStart;
		///<summary>If set externally, then this sets the date on startup.</summary>
		public DateTime DateEnd;
		/// <summary>Must be set externally.</summary>
		public List<CentralConnection> ConnList;
		public byte[] EncryptionKey;
		private Userod _userOld;
		private string _passwordTypedOld;


		public FormCentralProdInc() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormCentralProdInc_Load(object sender,System.EventArgs e) {
			_userOld=Security.CurUser;
			_passwordTypedOld=Security.PasswordTyped;
			textToday.Text=DateTime.Today.ToShortDateString();
			switch(DailyMonthlyAnnual) {
				case "Daily":
					radioDaily.Checked=true;
					break;
				case "Monthly":
					radioMonthly.Checked=true;
					break;
				case "Annual":
					radioAnnual.Checked=true;
					break;
			}
			SetDates();
			//The CM tool runs against many databases thus does not care about default preferences.
			//If we enhance the CM tool to have default preferences, we will need to make sure that  the cache 
			//has been refreshed with the CM's cache instead of the potentially stale cache from an unknown source.
			//if(PrefC.GetBool(PrefName.ReportsPPOwriteoffDefaultToProcDate)) {
			//	radioWriteoffProc.Checked=true;
			//}
			if(DateStart.Year>1880) {
				textDateFrom.Text=DateStart.ToShortDateString();
				textDateTo.Text=DateEnd.ToShortDateString();
				switch(DailyMonthlyAnnual) {
					case "Daily":
						RunDaily();
						break;
					case "Monthly":
						RunMonthly();
						break;
					case "Annual":
						RunAnnual();
						break;
				}
				Close();
			}
		}

		private void radioDaily_Click(object sender,System.EventArgs e) {
			SetDates();
		}

		private void radioMonthly_Click(object sender,System.EventArgs e) {
			SetDates();
		}

		private void radioAnnual_Click(object sender,System.EventArgs e) {
			SetDates();
		}

		private void radioProvider_Click(object sender,EventArgs e) {
			SetDates();
		}

		private void SetDates() {
			if(radioDaily.Checked || radioProvider.Checked) {
				textDateFrom.Text=DateTime.Today.ToShortDateString();
				textDateTo.Text=DateTime.Today.ToShortDateString();
				butThis.Text=Lan.g(this,"Today");
			}
			else if(radioMonthly.Checked) {
				textDateFrom.Text=new DateTime(DateTime.Today.Year,DateTime.Today.Month,1).ToShortDateString();
				textDateTo.Text=new DateTime(DateTime.Today.Year,DateTime.Today.Month
					,DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month)).ToShortDateString();
				butThis.Text=Lan.g(this,"This Month");
			}
			else {//annual
				textDateFrom.Text=new DateTime(DateTime.Today.Year,1,1).ToShortDateString();
				textDateTo.Text=new DateTime(DateTime.Today.Year,12,31).ToShortDateString();
				butThis.Text=Lan.g(this,"This Year");
			}
		}

		private void butThis_Click(object sender,System.EventArgs e) {
			SetDates();
		}

		private void butLeft_Click(object sender,System.EventArgs e) {
			if(textDateFrom.errorProvider1.GetError(textDateFrom)!=""
				|| textDateTo.errorProvider1.GetError(textDateTo)!=""
				) {
				MessageBox.Show(Lan.g(this,"Please fix data entry errors first."));
				return;
			}
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			if(radioDaily.Checked || radioProvider.Checked) {
				textDateFrom.Text=_dateFrom.AddDays(-1).ToShortDateString();
				textDateTo.Text=_dateTo.AddDays(-1).ToShortDateString();
			}
			else if(radioMonthly.Checked) {
				bool toLastDay=false;
				if(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(_dateTo.Year,_dateTo.Month)==_dateTo.Day) {
					toLastDay=true;
				}
				textDateFrom.Text=_dateFrom.AddMonths(-1).ToShortDateString();
				textDateTo.Text=_dateTo.AddMonths(-1).ToShortDateString();
				_dateTo=PIn.Date(textDateTo.Text);
				if(toLastDay) {
					textDateTo.Text=new DateTime(_dateTo.Year,_dateTo.Month,
						CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(_dateTo.Year,_dateTo.Month))
						.ToShortDateString();
				}
			}
			else {//annual
				textDateFrom.Text=_dateFrom.AddYears(-1).ToShortDateString();
				textDateTo.Text=_dateTo.AddYears(-1).ToShortDateString();
			}
		}

		private void butRight_Click(object sender,System.EventArgs e) {
			if(textDateFrom.errorProvider1.GetError(textDateFrom)!=""
				|| textDateTo.errorProvider1.GetError(textDateTo)!=""
				) {
				MessageBox.Show(Lan.g(this,"Please fix data entry errors first."));
				return;
			}
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			if(radioDaily.Checked || radioProvider.Checked) {
				textDateFrom.Text=_dateFrom.AddDays(1).ToShortDateString();
				textDateTo.Text=_dateTo.AddDays(1).ToShortDateString();
			}
			else if(radioMonthly.Checked) {
				bool toLastDay=false;
				if(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(_dateTo.Year,_dateTo.Month)==_dateTo.Day) {
					toLastDay=true;
				}
				textDateFrom.Text=_dateFrom.AddMonths(1).ToShortDateString();
				textDateTo.Text=_dateTo.AddMonths(1).ToShortDateString();
				_dateTo=PIn.Date(textDateTo.Text);
				if(toLastDay) {
					textDateTo.Text=new DateTime(_dateTo.Year,_dateTo.Month,
						CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(_dateTo.Year,_dateTo.Month))
						.ToShortDateString();
				}
			}
			else {//annual
				textDateFrom.Text=_dateFrom.AddYears(1).ToShortDateString();
				textDateTo.Text=_dateTo.AddYears(1).ToShortDateString();
			}
		}

		private void RunDaily() {
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			List<DataSet> listProdData=new List<DataSet>();//A list of all data sets for each connection.
			List<string> listServerNames=new List<string>();
			string stringFailedConns="";
			for(int i=0;i<ConnList.Count;i++) {
				ODThread odThread=new ODThread(ConnectAndRunDailyReport,ConnList[i]);
				odThread.GroupName="ConnectAndReportDaily";
				odThread.Start();
			}
			ODThread.JoinThreadsByGroupName(Timeout.Infinite,"ConnectAndReportDaily");
			List<ODThread> listThreads=ODThread.GetThreadsByGroupName("ConnectAndReportDaily");
			for(int i=0;i<listThreads.Count;i++) {
				object[] obj=(object[])listThreads[i].Tag;
				DataSet data=(DataSet)obj[0];
				string connString=CentralConnections.GetConnectionString((CentralConnection)obj[1]);
				if(data==null) {
					stringFailedConns+=connString+"\r\n";
				}
				else {
					listServerNames.Add(connString);
					listProdData.Add(data);
				}
				listThreads[i].QuitSync(Timeout.Infinite);
			}
			ReportComplex report=new ReportComplex(true,true);
			report.ReportName="DailyP&I";
			report.AddTitle("Title",Lan.g(this,"Daily Production and Income"));
			report.AddSubTitle("PracName",PrefC.GetString(PrefName.PracticeTitle));
			string dateRangeStr=_dateFrom.ToShortDateString()+" - "+_dateTo.ToShortDateString();
			if(_dateFrom.Date==_dateTo.Date) {
				dateRangeStr=_dateFrom.ToShortDateString();//Do not show a date range for the same day...
			}
			report.AddSubTitle("Date",dateRangeStr);
			report.AddSubTitle("Providers",Lan.g(this,"All Providers"));
			report.AddSubTitle("Clinics",Lan.g(this,"All Clinics"));
			QueryObject query=null;
			//Per connection, add each table and split on clinic.  We also need to make a totals table that will be total per clinic per connection.
			DataTable connectionTotals=new DataTable("Totals");
			connectionTotals.Columns.Add(new DataColumn("Connection"));
			connectionTotals.Columns.Add(new DataColumn("Clinic"));
			connectionTotals.Columns.Add(new DataColumn("Production"));
			connectionTotals.Columns.Add(new DataColumn("Adjust"));
			connectionTotals.Columns.Add(new DataColumn("Writeoff"));
			connectionTotals.Columns.Add(new DataColumn("Pt Income"));
			connectionTotals.Columns.Add(new DataColumn("Ins Income"));
			for(int i=0;i<listProdData.Count;i++) {//Per connection
				DataTable tableDailyProdForConn=listProdData[i].Tables["DailyProd"];//Includes multiple clinics.
				if(tableDailyProdForConn.Rows.Count>0) {
					for(int j=0;j<tableDailyProdForConn.Rows.Count;j++) {//Go through the rows
						DataRow connRow=tableDailyProdForConn.Rows[j];
						bool isFound=false;
						for(int k=0;k<connectionTotals.Rows.Count;k++) {//Attempt to find an existing totals row that matches.
							DataRow connTotalsRow=connectionTotals.Rows[k];
							if(connRow["Clinic"]==connTotalsRow["Clinic"] && listServerNames[i]==connTotalsRow["Connection"].ToString()){//Totals row already exists. Add to it.
								DataRow totalRow=connectionTotals.NewRow();//Need to make a new row, can't just modify old table values.  Sadly.
								double prod=PIn.Double(connTotalsRow["Production"].ToString());
								double adjust=PIn.Double(connTotalsRow["Adjust"].ToString());
								double writeoff=PIn.Double(connTotalsRow["Writeoff"].ToString());
								double ptInc=PIn.Double(connTotalsRow["Pt Income"].ToString());
								double insInc=PIn.Double(connTotalsRow["Ins Income"].ToString());
								totalRow[0]=connTotalsRow["Connection"];
								totalRow[1]=connTotalsRow["Clinic"];
								totalRow[2]=(prod+PIn.Double(connRow["Production"].ToString()));
								totalRow[3]=(adjust+PIn.Double(connRow["Adjust"].ToString()));
								totalRow[4]=(writeoff+PIn.Double(connRow["Writeoff"].ToString()));
								totalRow[5]=(ptInc+PIn.Double(connRow["Pt Income"].ToString()));
								totalRow[6]=(insInc+PIn.Double(connRow["Ins Income"].ToString()));
								connectionTotals.Rows.RemoveAt(k);
								connectionTotals.Rows.Add(totalRow);
								isFound=true;
								break;
							}
						}
						if(!isFound){//Totals row for this connection and clinic combination doesn't exist yet.
							DataRow totalRow=connectionTotals.NewRow();
							totalRow[0]=listServerNames[i];
							totalRow[1]=connRow["Clinic"];
							totalRow[2]=connRow["Production"];
							totalRow[3]=connRow["Adjust"];
							totalRow[4]=connRow["Writeoff"];
							totalRow[5]=connRow["Pt Income"];
							totalRow[6]=connRow["Ins Income"];
							connectionTotals.Rows.Add(totalRow);
						}
					}
					query=report.AddQuery(tableDailyProdForConn,listServerNames[i],"Clinic",SplitByKind.Value,1,true);
					// add columns to report
					query.AddColumn("Date",75,FieldValueType.String,new Font("Tahoma",8));
					query.AddColumn("Patient Name",130,FieldValueType.String,new Font("Tahoma",8));
					query.AddColumn("Description",220,FieldValueType.String,new Font("Tahoma",8));
					query.AddColumn("Prov",65,FieldValueType.String,new Font("Tahoma",8));
					query.AddColumn("Clinic",130,FieldValueType.String,new Font("Tahoma",8));
					query.AddColumn("Production",75,FieldValueType.Number,new Font("Tahoma",8));
					query.AddColumn("Adjust",75,FieldValueType.Number,new Font("Tahoma",8));
					query.AddColumn("Writeoff",75,FieldValueType.Number,new Font("Tahoma",8));
					query.AddColumn("Pt Income",75,FieldValueType.Number,new Font("Tahoma",8));
					query.AddColumn("Ins Income",75,FieldValueType.Number,new Font("Tahoma",8));
				}
				else {
					MsgBox.Show(this,"Connection "+listServerNames[i]+" has no results to show.");
				}
			}
			if(connectionTotals.Rows.Count==0) {
				MsgBox.Show(this,"This report returned no values.");
				return;
			}
			connectionTotals=connectionTotals.AsEnumerable().OrderBy(r => r.Field<string>("Connection"))
				.ThenBy(r => r.Field<string>("Clinic")).CopyToDataTable();
			query=report.AddQuery(connectionTotals,"Totals","",SplitByKind.None,2,true);
			query.AddColumn("Connection",250,FieldValueType.String,new Font("Tahoma",8));
			query.AddColumn("Clinic",250,FieldValueType.String,new Font("Tahoma",8));
			query.AddColumn("Production",75,FieldValueType.Number,new Font("Tahoma",8));
			query.AddColumn("Adjust",75,FieldValueType.Number,new Font("Tahoma",8));
			query.AddColumn("Writeoff",75,FieldValueType.Number,new Font("Tahoma",8));
			query.AddColumn("Pt Income",75,FieldValueType.Number,new Font("Tahoma",8));
			query.AddColumn("Ins Income",75,FieldValueType.Number,new Font("Tahoma",8));
			//Calculate the total production and total income and add them to the bottom of the report:
			double totalProduction=0;
			double totalIncome=0;
			for(int i=0;i<connectionTotals.Rows.Count;i++) {
				//Total production is (Production + Adjustments - Writeoffs)
				totalProduction+=PIn.Double(connectionTotals.Rows[i]["Production"].ToString());
				totalProduction+=PIn.Double(connectionTotals.Rows[i]["Adjust"].ToString());
				totalProduction+=PIn.Double(connectionTotals.Rows[i]["Writeoff"].ToString());
				//Total income is (Pt Income + Ins Income)
				totalIncome+=PIn.Double(connectionTotals.Rows[i]["Pt Income"].ToString());
				totalIncome+=PIn.Double(connectionTotals.Rows[i]["Ins Income"].ToString());
			}
			//Add the Total Production and Total Income to the bottom of the report if there were any rows present.
			if(connectionTotals.Rows.Count > 0) {
				//Use a custom table and add it like it is a "query" to the report because using a group summary would be more complicated due
				//to the need to add and subtract from multiple columns at the same time.
				DataTable tableTotals=new DataTable("TotalProdAndInc");
				tableTotals.Columns.Add("Summary");
				tableTotals.Rows.Add(Lan.g(this,"Total Production (Production + Adjustments - Writeoffs):")+" "+totalProduction.ToString("c"));
				tableTotals.Rows.Add(Lan.g(this,"Total Income (Pt Income + Ins Income):")+" "+totalIncome.ToString("c"));
				//Add tableTotals to the report.
				//No column name and no header because we want to display this table to NOT look like a table.
				query=report.AddQuery(tableTotals,"","",SplitByKind.None,2,false);
				query.AddColumn("",785,FieldValueType.String,new Font("Tahoma",8,FontStyle.Bold));
			}
			report.AddPageNum();
			// execute query
			if(!report.SubmitQueries()) {
				return;
			}
			// display report
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		private void RunMonthly() {
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			List<DataSet> listProdData=new List<DataSet>();//A list of all data sets for each connection.
			List<string> listServerNames=new List<string>();
			string stringFailedConns="";
			for(int i=0;i<ConnList.Count;i++) {
				ODThread odThread=new ODThread(ConnectAndRunMonthlyReport,new object[]{ConnList[i]});
				odThread.GroupName="ConnectAndReportMonthly";
				odThread.Start();
			}
			ODThread.JoinThreadsByGroupName(Timeout.Infinite,"ConnectAndReportMonthly");
			List<ODThread> listThreads=ODThread.GetThreadsByGroupName("ConnectAndReportMonthly");
			for(int i=0;i<listThreads.Count;i++) {
				object[] obj=(object[])listThreads[i].Tag;
				DataSet data=(DataSet)obj[0];
				string connString=CentralConnections.GetConnectionString((CentralConnection)obj[1]);
				if(data==null) {
					stringFailedConns+=connString+"\r\n";
				}
				else {
					listServerNames.Add(connString);
					listProdData.Add(data);
				}
				listThreads[i].QuitSync(Timeout.Infinite);
			}
			ReportComplex report=new ReportComplex(true,false);
			report.ReportName="MonthlyP&I";
			report.AddTitle("Title",Lan.g(this,"Monthly Production and Income"));
			report.AddSubTitle("Date",_dateFrom.ToShortDateString()+" - "+_dateTo.ToShortDateString());
			report.AddSubTitle("Clinics",Lan.g(this,"All Clinics"));
			QueryObject query;
			DataSet dsTotal=new DataSet();//Totals dataset for all connections, it contains a totals table per connection.  We use this later for a summary section.
			int queryObjectNum=0;
			for(int i=0;i<listProdData.Count;i++) {
				DataTable dt=listProdData[i].Tables["Clinic"];
				DataTable dtTot=listProdData[i].Tables["Total"].Copy();
				if(dt.Rows.Count>0 && dtTot.Rows.Count>0) {
					queryObjectNum++;
					dtTot.TableName=dtTot.TableName+"_"+i;
					dsTotal.Tables.Add(dtTot);
					query=report.AddQuery(dt,listServerNames[i],"Clinic",SplitByKind.Value,1,true);
					// add columns to report
					Font font=new Font("Tahoma",8,FontStyle.Regular);
					query.AddColumn("Date",70,FieldValueType.String,font);
					query.AddColumn("Weekday",70,FieldValueType.String,font);
					query.AddColumn("Production",80,FieldValueType.Number,font);
					query.AddColumn("Sched",80,FieldValueType.Number,font);
					query.AddColumn("Adj",80,FieldValueType.Number,font);
					query.AddColumn("Writeoff",80,FieldValueType.Number,font);
					query.AddColumn("Tot Prod",80,FieldValueType.Number,font);
					query.AddColumn("Pt Income",80,FieldValueType.Number,font);
					query.AddColumn("Ins Income",80,FieldValueType.Number,font);
					query.AddColumn("Tot Income",80,FieldValueType.Number,font);
				}
				else {
					MsgBox.Show(this,"Connection "+listServerNames[i]+" has no results to show.");
				}
			}
			if(dsTotal.Tables.Count==0) {
				MsgBox.Show(this,"This report returned no values");
				return;
			}
			//setup query
			DataTable dtTotal;
			double production;
			double sched;
			double adjust;
			double writeoff;
			double totprod;
			double ptincome;
			double insincome;
			double totalincome;
			DateTime[] dates=new DateTime[(_dateTo-_dateFrom).Days];
			dtTotal=dsTotal.Tables[0].Clone();
			dtTotal.Rows.Clear();
			for(int i=0;i<dates.Length;i++) {//Per day
				production=0;
				sched=0;
				adjust=0;
				writeoff=0;
				totprod=0;
				ptincome=0;
				insincome=0;
				totalincome=0;
				dates[i]=_dateFrom.AddDays(i);
				DataRow row=dtTotal.NewRow();
				row[0]=dates[i].ToShortDateString();
				row[1]=dates[i].DayOfWeek;//Weekday
				for(int j=0;j<dsTotal.Tables.Count;j++) {//Per totals table
					for(int k=0;k<dsTotal.Tables[j].Rows.Count;k++) {//Per row
						//If it's the correct day, add to the totals.
						if(PIn.Date(dsTotal.Tables[j].Rows[k]["Month"].ToString()).ToShortDateString()==dates[i].ToShortDateString()) {
							DataRow dataRow=dsTotal.Tables[j].Rows[k];
							production+=PIn.Double(dataRow["Production"].ToString());
							sched+=PIn.Double(dataRow["Sched"].ToString());
							adjust+=PIn.Double(dataRow["Adjustments"].ToString());
							writeoff+=PIn.Double(dataRow["Writeoff"].ToString());
							totprod+=PIn.Double(dataRow["Tot Prod"].ToString());
							ptincome+=PIn.Double(dataRow["Pt Income"].ToString());
							insincome+=PIn.Double(dataRow["Ins Income"].ToString());
							totalincome+=PIn.Double(dataRow["Total Income"].ToString());
							break;
						}
					}
				}
				if(production==0 && sched==0 && adjust==0 && writeoff==0 && totprod==0 && ptincome==0 && insincome==0 && totalincome==0) {
					continue;//Don't display this row if there's nothing to show. (Wasn't like this in 14.3 but is now in 15.3)
				}
				row[2]=production.ToString("n");
				row[3]=sched.ToString("n");
				row[4]=adjust.ToString("n");
				row[5]=writeoff.ToString("n");
				row[6]=totprod.ToString("n");
				row[7]=ptincome.ToString("n");
				row[8]=insincome.ToString("n");
				row[9]=totalincome.ToString("n");
				dtTotal.Rows.Add(row);
			}
			query=report.AddQuery(dtTotal,"Totals","",SplitByKind.None,2,true);
			Font font2=new Font("Tahoma",8,FontStyle.Regular);
			query.AddColumn("Date",70,FieldValueType.String,font2);
			query.AddColumn("Weekday",70,FieldValueType.String,font2);
			query.AddColumn("Production",80,FieldValueType.Number,font2);
			query.AddColumn("Sched",80,FieldValueType.Number,font2);
			query.AddColumn("Adj",80,FieldValueType.Number,font2);
			query.AddColumn("Writeoff",80,FieldValueType.Number,font2);
			query.AddColumn("Tot Prod",80,FieldValueType.Number,font2);
			query.AddColumn("Pt Income",80,FieldValueType.Number,font2);
			query.AddColumn("Ins Income",80,FieldValueType.Number,font2);
			query.AddColumn("Tot Income",80,FieldValueType.Number,font2);
			query.AddGroupSummaryField("Total Production (Production + Adjustments - Writeoffs): ","Writeoff","Tot Prod",SummaryOperation.Sum,new List<int>() { queryObjectNum },Color.Black,new Font("Tahoma",9,FontStyle.Bold),104,20);
			query.AddGroupSummaryField("Total Income (Pt Income + Ins Income): ","Writeoff","Total Income",SummaryOperation.Sum,new List<int>() { queryObjectNum },Color.Black,new Font("Tahoma",9,FontStyle.Bold),0,25);
			report.AddPageNum();
			// execute query
			if(!report.SubmitQueries()) {//Does not actually submit queries because we use datatables in the central management tool.
				return;
			}
			if(stringFailedConns!="") {
				stringFailedConns="Failed Connections:\r\n"+stringFailedConns;
				MsgBoxCopyPaste msgBoxCP=new MsgBoxCopyPaste(stringFailedConns);
				msgBoxCP.ShowDialog();
			}
			// display the report
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		private void RunAnnual() {
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			List<DataSet> listProdData=new List<DataSet>();
			List<string> listServerNames=new List<string>();
			string stringFailedConns="";
			for(int i=0;i<ConnList.Count;i++) {
				ODThread odThread=new ODThread(ConnectAndRunAnnualReport,new object[]{ConnList[i]});
				odThread.GroupName="ConnectAndReportAnnual";
				odThread.Start();
			}
			ODThread.JoinThreadsByGroupName(Timeout.Infinite,"ConnectAndReportAnnual");
			List<ODThread> listThreads=ODThread.GetThreadsByGroupName("ConnectAndReportAnnual");
			for(int i=0;i<listThreads.Count;i++) {
				object[] obj=(object[])listThreads[i].Tag;
				DataSet data=(DataSet)obj[0];
				string connString=CentralConnections.GetConnectionString((CentralConnection)obj[1]);
				if(data==null) {
					stringFailedConns+=connString+"\r\n";
				}
				else {
					listServerNames.Add(connString);
					listProdData.Add(data);
				}
				listThreads[i].QuitSync(Timeout.Infinite);
			}
			ReportComplex report=new ReportComplex(true,true);
			report.ReportName="Appointments";
			report.AddTitle("Title",Lan.g(this,"Annual Production and Income"));
			report.AddSubTitle("PracName",PrefC.GetString(PrefName.PracticeTitle));
			report.AddSubTitle("Date",_dateFrom.ToShortDateString()+" - "+_dateTo.ToShortDateString());
			report.AddSubTitle("Providers",Lan.g(this,"All Providers"));
			report.AddSubTitle("Clinics",Lan.g(this,"All Clinics"));
			//setup query
			QueryObject query;
			DataSet dsTotal=new DataSet();
			for(int i=0;i<listProdData.Count;i++) {
				DataTable dt=listProdData[i].Tables["Clinic"];
				DataTable dtTot=listProdData[i].Tables["Total"].Copy();
				dtTot.TableName=dtTot.TableName+"_"+i;
				dsTotal.Tables.Add(dtTot);
				query=report.AddQuery(dt,listServerNames[i],"Clinic",SplitByKind.Value,1,true);
				// add columns to report
				query.AddColumn("Month",75,FieldValueType.String);
				query.AddColumn("Production",120,FieldValueType.Number);
				query.AddColumn("Adjustments",120,FieldValueType.Number);
				query.AddColumn("Writeoff",120,FieldValueType.Number);
				query.AddColumn("Tot Prod",120,FieldValueType.Number);
				query.AddColumn("Pt Income",120,FieldValueType.Number);
				query.AddColumn("Ins Income",120,FieldValueType.Number);
				query.AddColumn("Total Income",120,FieldValueType.Number);
			}
			if(dsTotal.Tables.Count==0) {
				MsgBox.Show(this,"This report returned no values");
				return;
			}
			DataTable dtTotal;
			decimal production;
			decimal adjust;
			decimal inswriteoff;	//spk 5/19/05
			decimal totalproduction;
			decimal ptincome;
			decimal insincome;
			decimal totalincome;
			DateTime[] dates=new DateTime[_dateTo.Month-_dateFrom.Month+1];
			dtTotal=dsTotal.Tables[0].Clone();
			for(int i=0;i<dates.Length;i++) {//usually 12 months in loop
				dates[i]=_dateFrom.AddMonths(i);
				DataRow row=dtTotal.NewRow();
				row[0]=dates[i].ToString("MMM yy");//JAN 14
				production=0;
				adjust=0;
				inswriteoff=0;	//spk 5/19/05
				totalproduction=0;
				ptincome=0;
				insincome=0;
				totalincome=0;
				for(int j=0;j<dsTotal.Tables.Count;j++) {
					for(int k=0;k<dsTotal.Tables[j].Rows.Count;k++) {
						if(dsTotal.Tables[j].Rows[k][0].ToString()==dates[i].ToString("MMM yyyy")) {
							production+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Production"].ToString());
							adjust+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Adjustments"].ToString());
							inswriteoff-=PIn.Decimal(dsTotal.Tables[j].Rows[k]["WriteOff"].ToString());
							ptincome+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Pt Income"].ToString());
							insincome+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Ins Income"].ToString());
						}
					}
				}
				totalproduction=production+adjust+inswriteoff;
				totalincome=ptincome+insincome;
				row[1]=production.ToString("n");
				row[2]=adjust.ToString("n");
				row[3]=inswriteoff.ToString("n");
				row[4]=totalproduction.ToString("n");
				row[5]=ptincome.ToString("n");
				row[6]=insincome.ToString("n");
				row[7]=totalincome.ToString("n");
				dtTotal.Rows.Add(row);
			}
			query=report.AddQuery(dtTotal,"Totals","",SplitByKind.None,2,true);
			query.AddColumn("Month",75,FieldValueType.String);
			query.AddColumn("Production",120,FieldValueType.Number);
			query.AddColumn("Adjustments",120,FieldValueType.Number);
			query.AddColumn("Writeoff",120,FieldValueType.Number);
			query.AddColumn("Tot Prod",120,FieldValueType.Number);
			query.AddColumn("Pt Income",120,FieldValueType.Number);
			query.AddColumn("Ins Income",120,FieldValueType.Number);
			query.AddColumn("Total Income",120,FieldValueType.Number);
			report.AddPageNum();
			// execute query
			if(!report.SubmitQueries()) {//Does not actually submit queries because we use datatables in the central management tool.
				return;
			}
			if(stringFailedConns!="") {
				stringFailedConns="Failed Connections:\r\n"+stringFailedConns;
				MsgBoxCopyPaste msgBoxCP=new MsgBoxCopyPaste(stringFailedConns);
				msgBoxCP.ShowDialog();
			}
			// display the report
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		private void RunProvider() {
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			List<DataSet> listProdData=new List<DataSet>();
			List<Provider> listProvs=new List<Provider>();
			List<string> listServerNames=new List<string>();
			string strFailedConn="";
			for(int i=0;i<ConnList.Count;i++) {
				ODThread odThread=new ODThread(ConnectAndRunProviderReport,new object[] { ConnList[i] });
				odThread.GroupName="ConnectAndReportProvider";
				odThread.Start();
			}
			ODThread.JoinThreadsByGroupName(Timeout.Infinite,"ConnectAndReportProvider");
			List<ODThread> listThreads=ODThread.GetThreadsByGroupName("ConnectAndReportProvider");
			for(int i=0;i<listThreads.Count;i++) {
				object[] obj=(object[])listThreads[i].Tag;
				DataSet data=(DataSet)obj[0];
				string connString=CentralConnections.GetConnectionString((CentralConnection)obj[1]);
				List<Provider> listConnProvs=(List<Provider>)obj[2];
				if(data==null) {
					strFailedConn+=connString+"\r\n";
				}
				else {
					listServerNames.Add(connString);
					listProdData.Add(data);
					listProvs.AddRange(listConnProvs);
				}
				listThreads[i].QuitSync(Timeout.Infinite);
			}
			ReportComplex report=new ReportComplex(true,true);
			report.ReportName="Provider P&I";
			report.AddTitle("Title",Lan.g(this,"Provider Production and Income"));
			report.AddSubTitle("PracName",PrefC.GetString(PrefName.PracticeTitle));
			report.AddSubTitle("Date",_dateFrom.ToShortDateString()+" - "+_dateTo.ToShortDateString());
			report.AddSubTitle("Providers",Lan.g(this,"All Providers"));
			report.AddSubTitle("Clinics",Lan.g(this,"All Clinics"));
			//setup query
			QueryObject query;
			DataSet dsTotal=new DataSet();
			for(int i=0;i<listProdData.Count;i++) {
				DataTable dt=listProdData[i].Tables["Clinic"];
				DataTable dtTot=listProdData[i].Tables["Total"].Copy();
				dtTot.TableName=dtTot.TableName+"_"+i;
				dsTotal.Tables.Add(dtTot);
				query=report.AddQuery(dt,listServerNames[i],"Clinic",SplitByKind.Value,1,true);
				// add columns to report
				query.AddColumn("Provider",75,FieldValueType.String);
				query.AddColumn("Production",120,FieldValueType.Number);
				query.AddColumn("Adjustments",120,FieldValueType.Number);
				query.AddColumn("Writeoff",120,FieldValueType.Number);
				query.AddColumn("Tot Prod",120,FieldValueType.Number);
				query.AddColumn("Pt Income",120,FieldValueType.Number);
				query.AddColumn("Ins Income",120,FieldValueType.Number);
				query.AddColumn("Total Income",120,FieldValueType.Number);
			}
			if(dsTotal.Tables.Count==0) {
				MsgBox.Show(this,"This report returned no values");
				return;
			}
			DataTable dtTotal;
			decimal production;
			decimal adjust;
			decimal inswriteoff;
			decimal totalproduction;
			decimal ptincome;
			decimal insincome;
			decimal totalincome;
			dtTotal=dsTotal.Tables[0].Clone();
			for(int i=0;i<listProvs.Count;i++) {
				Provider provCur=listProvs[i];
				DataRow row=dtTotal.NewRow();
				row[0]=provCur.Abbr;
				production=0;
				adjust=0;
				inswriteoff=0;
				totalproduction=0;
				ptincome=0;
				insincome=0;
				totalincome=0;
				bool hasAnyAmount=false;
				for(int j=0;j<dsTotal.Tables.Count;j++) {
					for(int k=0;k<dsTotal.Tables[j].Rows.Count;k++) {
						if(dsTotal.Tables[j].Rows[k][0].ToString()==provCur.Abbr
							&& (PIn.Decimal(dsTotal.Tables[j].Rows[k]["Production"].ToString())!=0
							|| PIn.Decimal(dsTotal.Tables[j].Rows[k]["Adjustments"].ToString())!=0
							|| PIn.Decimal(dsTotal.Tables[j].Rows[k]["WriteOff"].ToString())!=0
							|| PIn.Decimal(dsTotal.Tables[j].Rows[k]["Pt Income"].ToString())!=0
							|| PIn.Decimal(dsTotal.Tables[j].Rows[k]["Ins Income"].ToString())!=0)) 
						{
							production+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Production"].ToString());
							adjust+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Adjustments"].ToString());
							inswriteoff-=PIn.Decimal(dsTotal.Tables[j].Rows[k]["WriteOff"].ToString());
							ptincome+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Pt Income"].ToString());
							insincome+=PIn.Decimal(dsTotal.Tables[j].Rows[k]["Ins Income"].ToString());
							hasAnyAmount=true;
						}
					}
				}
				totalproduction=production+adjust+inswriteoff;
				totalincome=ptincome+insincome;
				row[1]=production.ToString("n");
				row[2]=adjust.ToString("n");
				row[3]=inswriteoff.ToString("n");
				row[4]=totalproduction.ToString("n");
				row[5]=ptincome.ToString("n");
				row[6]=insincome.ToString("n");
				row[7]=totalincome.ToString("n");
				if(hasAnyAmount) {
					dtTotal.Rows.Add(row);
				}
			}
			query=report.AddQuery(dtTotal,"Totals","",SplitByKind.None,2,true);
			query.AddColumn("Provider",75,FieldValueType.String);
			query.AddColumn("Production",120,FieldValueType.Number);
			query.AddColumn("Adjustments",120,FieldValueType.Number);
			query.AddColumn("Writeoff",120,FieldValueType.Number);
			query.AddColumn("Tot Prod",120,FieldValueType.Number);
			query.AddColumn("Pt Income",120,FieldValueType.Number);
			query.AddColumn("Ins Income",120,FieldValueType.Number);
			query.AddColumn("Total Income",120,FieldValueType.Number);
			report.AddPageNum();
			// execute query
			if(!report.SubmitQueries()) {//Does not actually submit queries because we use datatables in the central management tool.
				return;
			}
			if(strFailedConn!="") {
				MsgBoxCopyPaste msgBoxCP=new MsgBoxCopyPaste(strFailedConn);
				msgBoxCP.ShowDialog();
			}
			// display the report
			FormReportComplex FormR=new FormReportComplex(report);
			FormR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		private void ConnectAndRunAnnualReport(ODThread odThread) {
			CentralConnection conn=(CentralConnection)odThread.Parameters[0];
			DataSet listProdData=null;
			if(!CentralConnectionHelper.UpdateCentralConnection(conn,false)) {
				odThread.Tag=new object[] { listProdData,conn };
				conn.ConnectionStatus="OFFLINE";
				return;
			}
			List<Provider> listProvs=Providers.GetProvsNoCache();
			List<Clinic> listClinics=Clinics.GetClinicsNoCache();
			Clinic unassigned=new Clinic();
			unassigned.ClinicNum=0;
			unassigned.Description="Unassigned";//Is this how we should do this?  Will there always be different clinics? (I assume so, otherwise CEMT is kinda worthless)
			listClinics.Add(unassigned);
			listProdData=RpProdInc.GetAnnualData(_dateFrom,_dateTo,listProvs,listClinics,radioWriteoffPay.Checked,true,true);
			odThread.Tag=new object[] { listProdData,conn };
		}

		private void ConnectAndRunMonthlyReport(ODThread odThread) {
			CentralConnection conn=(CentralConnection)odThread.Parameters[0];
			DataSet listProdData=null;
			if(!CentralConnectionHelper.UpdateCentralConnection(conn,false)) {
				odThread.Tag=new object[] { listProdData,conn };
				conn.ConnectionStatus="OFFLINE";
				return;
			}
			List<Provider> listProvs=Providers.GetProvsNoCache();
			List<Clinic> listClinics=Clinics.GetClinicsNoCache();
			Clinic unassigned=new Clinic();
			unassigned.ClinicNum=0;
			unassigned.Description="Unassigned";//Same issue here as above.
			listClinics.Add(unassigned);
			listProdData=RpProdInc.GetMonthlyData(_dateFrom,_dateTo,listProvs,listClinics,radioWriteoffPay.Checked,true,true);
			odThread.Tag=new object[] { listProdData,conn };
		}

		private void ConnectAndRunDailyReport(ODThread odThread) {
			CentralConnection conn=(CentralConnection)odThread.Parameters[0];
			DataSet dataSetProdData=null;
			if(!CentralConnectionHelper.UpdateCentralConnection(conn,false)) {
				odThread.Tag=new object[] { dataSetProdData,conn };
				conn.ConnectionStatus="OFFLINE";
				return;
			}
			List<Provider> listProvs=Providers.GetProvsNoCache();
			List<Clinic> listClinics=Clinics.GetClinicsNoCache();
			Clinic unassigned=new Clinic();
			unassigned.ClinicNum=0;
			unassigned.Description="Unassigned";//Same issue here as above.
			listClinics.Add(unassigned);
			dataSetProdData=RpProdInc.GetDailyData(_dateFrom,_dateTo,listProvs,listClinics,radioWriteoffPay.Checked,true,true,false);
			odThread.Tag=new object[] { dataSetProdData,conn };
		}

		private void ConnectAndRunProviderReport(ODThread odThread) {
			CentralConnection conn=(CentralConnection)odThread.Parameters[0];
			DataSet listProdData=null;
			if(!CentralConnectionHelper.UpdateCentralConnection(conn,false)) {
				odThread.Tag=new object[] { listProdData,conn };
				conn.ConnectionStatus="OFFLINE";
				return;
			}
			List<Provider> listProvs=Providers.GetProvsNoCache();
			List<Clinic> listClinics=Clinics.GetClinicsNoCache();
			Clinic unassigned=new Clinic();
			unassigned.ClinicNum=0;
			unassigned.Description="Unassigned";//Same issue here as above.
			listClinics.Add(unassigned);
			listProdData=RpProdInc.GetProviderDataForClinics(_dateFrom,_dateTo,listProvs,listClinics,radioWriteoffPay.Checked,true,true);
			odThread.Tag=new object[] { listProdData,conn,listProvs };
		}

		private void butOK_Click(object sender,EventArgs e) {
			if(textDateFrom.errorProvider1.GetError(textDateFrom)!=""
				|| textDateTo.errorProvider1.GetError(textDateTo)!=""
				) {
				MsgBox.Show(this,"Please fix data entry errors first.");
				return;
			}
			_dateFrom=PIn.Date(textDateFrom.Text);
			_dateTo=PIn.Date(textDateTo.Text);
			if(_dateTo<_dateFrom) {
				MsgBox.Show(this,"To date cannot be before From date.");
				return;
			}
			if(radioDaily.Checked) {
				RunDaily();
			}
			else if(radioMonthly.Checked) {
				RunMonthly();
			}
			else if(radioAnnual.Checked) {
				if(_dateFrom.AddYears(1) <= _dateTo || _dateFrom.Year != _dateTo.Year) {
					MsgBox.Show(this,"Date range for annual report cannot be greater than one year and must be within the same year.");
					return;
				}
				Cursor=Cursors.WaitCursor;
				RunAnnual();
				Cursor=Cursors.Default;
			}
			else {//Provider
				Cursor=Cursors.WaitCursor;
				RunProvider();
				Cursor=Cursors.Default;
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		private void FormCentralProdInc_FormClosing(object sender,FormClosingEventArgs e) {
			//This window can potentially change the username and password and we want to put them back to what they were before the window was launched.
			Security.CurUser=_userOld;
			Security.PasswordTyped=_passwordTypedOld;
		}

	}
}