using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;

namespace OpenDentBusiness {
	public class AccountModuleB {
		public static DataSet GetAll(int patNum,bool viewingInRecall){
			DataSet retVal=new DataSet();
			if (viewingInRecall) {
				retVal.Tables.Add(ChartModuleB.GetProgNotes(patNum, false));
			}
			else {
				retVal.Tables.Add(GetCommLog(patNum));
			}
			return retVal;
		}

		private static DataTable GetCommLog(int patNum) {
			DataConnection dcon=new DataConnection();
			DataTable table=new DataTable("Commlog");
			DataRow row;
			//columns that start with lowercase are altered for display rather than being raw data.
			table.Columns.Add("CommDateTime",typeof(DateTime));
			table.Columns.Add("commDate");
			table.Columns.Add("CommlogNum");
			table.Columns.Add("commType");
			table.Columns.Add("EmailMessageNum");
			table.Columns.Add("FormPatNum");
			table.Columns.Add("mode");
			table.Columns.Add("Note");
			table.Columns.Add("sentOrReceived");			
			//table.Columns.Add("");
			//but we won't actually fill this table with rows until the very end.  It's more useful to use a List<> for now.
			List<DataRow> rows=new List<DataRow>();
			//Commlog------------------------------------------------------------------------------------------
			string command="SELECT CommDateTime,CommType,Mode_,SentOrReceived,Note,CommlogNum "
				+"FROM commlog WHERE PatNum ='"+POut.PInt(patNum)+"' ORDER BY CommDateTime";
			DataTable rawComm=dcon.GetTable(command);
			DateTime dateT;
			for(int i=0;i<rawComm.Rows.Count;i++){
				if((CommItemType)PIn.PInt(rawComm.Rows[i]["CommType"].ToString())==CommItemType.StatementSent){
					continue;
				}
				row=table.NewRow();
				dateT=PIn.PDateT(rawComm.Rows[i]["CommDateTime"].ToString());
				row["CommDateTime"]=dateT;
				row["commDate"]=dateT.ToShortDateString();
				row["CommlogNum"]=rawComm.Rows[i]["CommlogNum"].ToString();
				row["commType"]=Lan.g("enumCommItemType",((CommItemType)PIn.PInt(rawComm.Rows[i]["CommType"].ToString())).ToString());
				row["EmailMessageNum"]="0";
				row["FormPatNum"]="0";
				row["mode"]=Lan.g("enumCommItemMode",((CommItemMode)PIn.PInt(rawComm.Rows[i]["Mode_"].ToString())).ToString());
				row["Note"]=rawComm.Rows[i]["Note"].ToString();
				row["sentOrReceived"]=Lan.g("enumCommSentOrReceived",
					((CommSentOrReceived)PIn.PInt(rawComm.Rows[i]["SentOrReceived"].ToString())).ToString());
				rows.Add(row);
			}
			//emailmessage---------------------------------------------------------------------------------------
			command="SELECT MsgDateTime,SentOrReceived,Subject,EmailMessageNum "
				+"FROM emailmessage WHERE PatNum ='"+POut.PInt(patNum)+"' ORDER BY MsgDateTime";
			DataTable rawEmail=dcon.GetTable(command);
			for(int i=0;i<rawEmail.Rows.Count;i++) {
				row=table.NewRow();
				dateT=PIn.PDateT(rawEmail.Rows[i]["MsgDateTime"].ToString());
				row["CommDateTime"]=dateT;
				row["commDate"]=dateT.ToShortDateString();

				row["CommlogNum"]="0";
				//type
				row["EmailMessageNum"]=rawEmail.Rows[i]["EmailMessageNum"].ToString();
				row["FormPatNum"]="0";
				row["mode"]=Lan.g("enumCommItemMode",CommItemMode.Email.ToString());
				row["Note"]=rawEmail.Rows[i]["Subject"].ToString();
				if(rawEmail.Rows[i]["SentOrReceived"].ToString()=="0") {
					row["sentOrReceived"]=Lan.g("AccountModule","Unsent");
				}
				else {
					row["sentOrReceived"]=Lan.g("enumCommSentOrReceived",
						((CommSentOrReceived)PIn.PInt(rawEmail.Rows[i]["SentOrReceived"].ToString())).ToString());
				}
				rows.Add(row);
			}
			//formpat---------------------------------------------------------------------------------------
			command="SELECT FormDateTime,FormPatNum "
				+"FROM formpat WHERE PatNum ='"+POut.PInt(patNum)+"' ORDER BY FormDateTime";
			DataTable rawForm=dcon.GetTable(command);
			for(int i=0;i<rawForm.Rows.Count;i++) {
				row=table.NewRow();
				dateT=PIn.PDateT(rawForm.Rows[i]["FormDateTime"].ToString());
				row["CommDateTime"]=dateT;
				row["commDate"]=dateT.ToShortDateString();
				row["CommlogNum"]="0";
				row["commType"]=Lan.g("AccountModule","Questionnaire");
				row["EmailMessageNum"]="0";
				row["FormPatNum"]=rawForm.Rows[i]["FormPatNum"].ToString();
				row["mode"]="";
				row["Note"]="";
				row["sentOrReceived"]="";
				rows.Add(row);
			}
			//Sorting
			//rows.Sort(CompareCommRows);
			for(int i=0;i<rows.Count;i++) {
				table.Rows.Add(rows[i]);
			}
			DataView view = table.DefaultView;
			view.Sort = "CommDateTime";
			table = view.ToTable();
			return table;
		}

		///<summary>The supplied DataRows must include the following columns: ProcNum,ProcDate,Priority,ToothRange,ToothNum,ProcCode.
		///This sorts all objects in Chart module based on their dates, times, priority, and toothnum.</summary>
		public static int CompareChartRows(DataRow x, DataRow y) {
			if (x["ProcNum"].ToString() != "0" && y["ProcNum"].ToString() != "0") {//if both are procedures
				if (((DateTime)x["ProcDate"]).Date == ((DateTime)y["ProcDate"]).Date) {//and the dates are the same
					return ProcedureB.CompareProcedures(x, y);
					//IComparer procComparer=new ProcedureComparer();
					//return procComparer.Compare(x,y);//sort by priority, toothnum, procCode
					//return 0;
				}
			}
			//In all other situations, all we care about is the dates.
			return ((DateTime)x["ProcDate"]).Date.CompareTo(((DateTime)y["ProcDate"]).Date);
			//IComparer myComparer = new ObjectDateComparer();
			//return myComparer.Compare(x,y);
		}




	}

	public class DtoAccountModuleGetAll:DtoQueryBase {
		public int PatNum;
		public bool ViewingInRecall;
	}


}
