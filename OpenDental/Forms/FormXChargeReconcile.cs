using System;
using System.Windows.Forms;
using OpenDentBusiness;
using System.IO;

namespace OpenDental {
	public partial class FormXChargeReconcile:Form {

		public FormXChargeReconcile() {
			InitializeComponent();
			Lan.F(this);
		}

		private void butImport_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			OpenFileDialog Dlg=new OpenFileDialog();
			if(Directory.Exists(@"C:\X-Charge\")) {
				Dlg.InitialDirectory=@"C:\X-Charge\";
			}
			else if(Directory.Exists(@"C:\")) {
				Dlg.InitialDirectory=@"C:\";
			}
			if(Dlg.ShowDialog()!=DialogResult.OK) {
				Cursor=Cursors.Default;
				return;
			}
			if(!File.Exists(Dlg.FileName)) {
				Cursor=Cursors.Default;
				MsgBox.Show(this,"File not found");
				return;
			}
			XChargeTransaction trans=new XChargeTransaction();
			string[] fields;
			XChargeTransaction transCheck;
			using(StreamReader sr=new StreamReader(Dlg.FileName)) {
				Cursor=Cursors.WaitCursor;
				string line=sr.ReadLine();
				while(line!=null) {
					fields=line.Split(new string[1] { "," },StringSplitOptions.None);
					if(fields.Length<16){
						continue;
					}
					trans.TransType=fields[0];
					fields[1]=fields[1].Replace("$","");
					if(fields[1].Contains("(")) {
						fields[1]=fields[1].TrimStart('(');
						fields[1]=fields[1].TrimEnd(')');
						fields[1]=fields[1].Insert(0,"-");
					}
					trans.Amount=PIn.Double(fields[1]);
					trans.CCEntry=fields[2];
					trans.PatNum=0;
					if(!String.IsNullOrWhiteSpace(fields[3])) {
						trans.PatNum=PIn.Long(fields[3].Substring(3));//remove "PAT" from the beginning of the string
					}
					trans.Result=fields[4];
					trans.ClerkID=fields[5];
					trans.ResultCode=fields[7];
					trans.Expiration=fields[8];
					trans.CCType=fields[9];
					trans.CreditCardNum=fields[10];
					trans.BatchNum=fields[11];
					trans.ItemNum=fields[12];
					trans.ApprCode=fields[13];
					trans.TransactionDateTime=PIn.Date(fields[14]).AddHours(PIn.Double(fields[15].Substring(0,2))).AddMinutes(PIn.Double(fields[15].Substring(3,2)));
					//Code removed in 14.2 so all transactions are allowed historically.
					//if(trans.BatchNum=="" || trans.ItemNum=="") {
					//	line=sr.ReadLine();
					//	continue;
					//}
					transCheck=XChargeTransactions.GetOneByBatchItem(trans.BatchNum,trans.ItemNum);
					if(transCheck!=null && trans.Result!="AP DUPE") {
						XChargeTransactions.Delete(transCheck.XChargeTransactionNum);
						XChargeTransactions.Insert(trans);
					}
					else {
						XChargeTransactions.Insert(trans);
					}
					line=sr.ReadLine();
				}
			}
			Cursor=Cursors.Default;
			MsgBox.Show(this,"Done.");
		}

		private void butViewImported_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			ReportSimpleGrid report=new ReportSimpleGrid();
			report.Query="SELECT TransactionDateTime,TransType,ClerkID,ItemNum,PatNum,CreditCardNum,Expiration,Result,CASE WHEN ResultCode='000' OR ResultCode='010' THEN Amount ELSE Amount=0 END AS Amount "
				+"FROM xchargetransaction "
				+"WHERE DATE(TransactionDateTime) BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)+" "
				+"AND TransType!='CCVoid'";
			FormQuery FormQuery2=new FormQuery(report);
			FormQuery2.IsReport=true;
			FormQuery2.SubmitReportQuery();
			report.Title="XCharge Transactions From "+date1.SelectionStart.ToShortDateString()+" To "+date2.SelectionStart.ToShortDateString();
			report.SubTitle.Add(PrefC.GetString(PrefName.PracticeTitle));
			report.SetColumn(this,0,"Transaction Date/Time",170);
			report.SetColumn(this,1,"Transaction Type",120);
			report.SetColumn(this,2,"Clerk ID",80);
			report.SetColumn(this,3,"Item#",50);
			report.SetColumn(this,4,"Pat",50);//This name is used to ensure FormQuery does not replace the patnum with the patient name.
			report.SetColumn(this,5,"Credit Card Num",140);
			report.SetColumn(this,6,"Exp",50);
			report.SetColumn(this,7,"Result",50);
			report.SetColumn(this,8,"Amount",60,HorizontalAlignment.Right);
			Cursor=Cursors.Default;
			FormQuery2.ShowDialog();
		}

		private void butPayments_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			string paymentType=ProgramProperties.GetPropVal(Programs.GetCur(ProgramName.Xcharge).ProgramNum,"PaymentType");
			ReportSimpleGrid report=new ReportSimpleGrid();
			report.Query="SET @pos=0; "
				+"SELECT @pos:=@pos+1 AS 'Count',patient.PatNum,LName,FName,DateEntry,PayDate,PayNote,PayAmt,PayType "
				+"FROM patient INNER JOIN payment ON payment.PatNum=patient.PatNum "
				//Must be DateEntry here. PayDate will not work with recurring charges
				+"WHERE PayType="+paymentType+" AND (DateEntry BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)+") "
				+"ORDER BY Count ASC";
			FormQuery FormQuery2=new FormQuery(report);
			FormQuery2.IsReport=true;
			FormQuery2.SubmitReportQuery();
			report.Title="Payments From "+date1.SelectionStart.ToShortDateString()+" To "+date2.SelectionStart.ToShortDateString();
			report.SubTitle.Add(PrefC.GetString(PrefName.PracticeTitle));
			report.SetColumn(this,0,"Count",50);
			report.SetColumn(this,1,"Pat",50);//This name is used to ensure FormQuery does not replace the patnum with the patient name.
			report.SetColumn(this,2,"LName",100);
			report.SetColumn(this,3,"FName",100);
			report.SetColumn(this,4,"DateEntry",100);
			report.SetColumn(this,5,"PayDate",100);
			report.SetColumn(this,6,"PayNote",150);
			report.SetColumn(this,7,"PayAmt",70,HorizontalAlignment.Right);
			Cursor=Cursors.Default;
			FormQuery2.ShowDialog();
		}

		private void butMissing_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			string programNum=ProgramProperties.GetPropVal(Programs.GetCur(ProgramName.Xcharge).ProgramNum,"PaymentType");
			ReportSimpleGrid report=new ReportSimpleGrid();
			report.Query="SELECT TransactionDateTime,TransType,ClerkID,ItemNum,xchargetransaction.PatNum,CreditCardNum,Expiration,Result,Amount "
				+" FROM xchargetransaction LEFT JOIN ("
					+" SELECT patient.PatNum,LName,FName,DateEntry,PayDate,PayAmt,PayNote"
					+" FROM patient INNER JOIN payment ON payment.PatNum=patient.PatNum"
					+" WHERE PayType="+programNum+" AND DateEntry BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)
				+" ) AS P ON xchargetransaction.PatNum=P.PatNum AND DATE(xchargetransaction.TransactionDateTime)=P.DateEntry AND xchargetransaction.Amount=P.PayAmt "
				+" WHERE DATE(TransactionDateTime) BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)
				+" AND P.PatNum IS NULL"
				+" AND xchargetransaction.ResultCode=0;";//Valid entries to count have result code 0
			FormQuery FormQuery2=new FormQuery(report);
			FormQuery2.IsReport=true;
			FormQuery2.SubmitReportQuery();
			report.Title="XCharge Transactions From "+date1.SelectionStart.ToShortDateString()+" To "+date2.SelectionStart.ToShortDateString();
			report.SubTitle.Add("No Matching Transaction Found in Open Dental");
			report.SetColumn(this,0,"Transaction Date/Time",170);
			report.SetColumn(this,1,"Transaction Type",120);
			report.SetColumn(this,2,"Clerk ID",80);
			report.SetColumn(this,3,"Item#",50);
			report.SetColumn(this,4,"Pat",50);//This name is used to ensure FormQuery does not replace the patnum with the patient name.
			report.SetColumn(this,5,"Credit Card Num",140);
			report.SetColumn(this,6,"Exp",50);
			report.SetColumn(this,7,"Result",50);
			report.SetColumn(this,8,"Amount",60,HorizontalAlignment.Right);
			Cursor=Cursors.Default;
			FormQuery2.ShowDialog();
		}

		private void butExtra_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			string programNum=ProgramProperties.GetPropVal(Programs.GetCur(ProgramName.Xcharge).ProgramNum,"PaymentType");
			ReportSimpleGrid report=new ReportSimpleGrid();
			report.Query="SELECT payment.PatNum, LName, FName, payment.DateEntry,payment.PayDate, payment.PayNote,payment.PayAmt "
				+"FROM patient INNER JOIN payment ON payment.PatNum=patient.PatNum "
				+"LEFT JOIN (SELECT TransactionDateTime,ClerkID,BatchNum,ItemNum,PatNum,CCType,CreditCardNum,Expiration,Result,Amount FROM xchargetransaction "
					+"WHERE (DATE(TransactionDateTime) BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)+") "
						+"AND ResultCode=0 "+@") AS X "
				+"ON X.PatNum=payment.PatNum AND DATE(X.TransactionDateTime)=payment.DateEntry AND X.Amount=payment.PayAmt "
				+"WHERE PayType="+programNum+" AND DateEntry BETWEEN "+POut.Date(date1.SelectionStart)+" AND "+POut.Date(date2.SelectionStart)+" "
				+"AND X.TransactionDateTime IS NULL "
				+"ORDER BY PayDate ASC, patient.LName";
			FormQuery FormQuery2=new FormQuery(report);
			FormQuery2.IsReport=true;
			FormQuery2.SubmitReportQuery();
			report.Title="Payments From "+date1.SelectionStart.ToShortDateString()+" To "+date2.SelectionStart.ToShortDateString();
			report.SubTitle.Add("No Matching X-Charge Transactions for these Payments");
			report.SetColumn(this,0,"Pat",50);//This name is used to ensure FormQuery does not replace the patnum with the patient name.
			report.SetColumn(this,1,"LName",100);
			report.SetColumn(this,2,"FName",100);
			report.SetColumn(this,3,"DateEntry",100);
			report.SetColumn(this,4,"PayDate",100);
			report.SetColumn(this,5,"PayNote",150);
			report.SetColumn(this,6,"PayAmt",70,HorizontalAlignment.Right);
			Cursor=Cursors.Default;
			FormQuery2.ShowDialog();
		}

		private void butClose_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

	}
}