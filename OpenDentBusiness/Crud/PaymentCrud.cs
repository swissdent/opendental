//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PaymentCrud {
		///<summary>Gets one Payment object from the database using the primary key.  Returns null if not found.</summary>
		public static Payment SelectOne(long payNum){
			string command="SELECT * FROM payment "
				+"WHERE PayNum = "+POut.Long(payNum);
			List<Payment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Payment object from the database using a query.</summary>
		public static Payment SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Payment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Payment objects from the database using a query.</summary>
		public static List<Payment> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Payment> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Payment> TableToList(DataTable table){
			List<Payment> retVal=new List<Payment>();
			Payment payment;
			foreach(DataRow row in table.Rows) {
				payment=new Payment();
				payment.PayNum         = PIn.Long  (row["PayNum"].ToString());
				payment.PayType        = PIn.Long  (row["PayType"].ToString());
				payment.PayDate        = PIn.Date  (row["PayDate"].ToString());
				payment.PayAmt         = PIn.Double(row["PayAmt"].ToString());
				payment.CheckNum       = PIn.String(row["CheckNum"].ToString());
				payment.BankBranch     = PIn.String(row["BankBranch"].ToString());
				payment.PayNote        = PIn.String(row["PayNote"].ToString());
				payment.IsSplit        = PIn.Bool  (row["IsSplit"].ToString());
				payment.PatNum         = PIn.Long  (row["PatNum"].ToString());
				payment.ClinicNum      = PIn.Long  (row["ClinicNum"].ToString());
				payment.DateEntry      = PIn.Date  (row["DateEntry"].ToString());
				payment.DepositNum     = PIn.Long  (row["DepositNum"].ToString());
				payment.Receipt        = PIn.String(row["Receipt"].ToString());
				payment.IsRecurringCC  = PIn.Bool  (row["IsRecurringCC"].ToString());
				payment.SecUserNumEntry= PIn.Long  (row["SecUserNumEntry"].ToString());
				payment.SecDateTEdit   = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(payment);
			}
			return retVal;
		}

		///<summary>Converts a list of Payment into a DataTable.</summary>
		public static DataTable ListToTable(List<Payment> listPayments,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Payment";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PayNum");
			table.Columns.Add("PayType");
			table.Columns.Add("PayDate");
			table.Columns.Add("PayAmt");
			table.Columns.Add("CheckNum");
			table.Columns.Add("BankBranch");
			table.Columns.Add("PayNote");
			table.Columns.Add("IsSplit");
			table.Columns.Add("PatNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("DateEntry");
			table.Columns.Add("DepositNum");
			table.Columns.Add("Receipt");
			table.Columns.Add("IsRecurringCC");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateTEdit");
			foreach(Payment payment in listPayments) {
				table.Rows.Add(new object[] {
					POut.Long  (payment.PayNum),
					POut.Long  (payment.PayType),
					POut.Date  (payment.PayDate),
					POut.Double(payment.PayAmt),
					POut.String(payment.CheckNum),
					POut.String(payment.BankBranch),
					POut.String(payment.PayNote),
					POut.Bool  (payment.IsSplit),
					POut.Long  (payment.PatNum),
					POut.Long  (payment.ClinicNum),
					POut.Date  (payment.DateEntry),
					POut.Long  (payment.DepositNum),
					POut.String(payment.Receipt),
					POut.Bool  (payment.IsRecurringCC),
					POut.Long  (payment.SecUserNumEntry),
					POut.DateT (payment.SecDateTEdit),
				});
			}
			return table;
		}

		///<summary>Inserts one Payment into the database.  Returns the new priKey.</summary>
		public static long Insert(Payment payment){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				payment.PayNum=DbHelper.GetNextOracleKey("payment","PayNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(payment,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							payment.PayNum++;
							loopcount++;
						}
						else{
							throw ex;
						}
					}
				}
				throw new ApplicationException("Insert failed.  Could not generate primary key.");
			}
			else {
				return Insert(payment,false);
			}
		}

		///<summary>Inserts one Payment into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Payment payment,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				payment.PayNum=ReplicationServers.GetKey("payment","PayNum");
			}
			string command="INSERT INTO payment (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PayNum,";
			}
			command+="PayType,PayDate,PayAmt,CheckNum,BankBranch,PayNote,IsSplit,PatNum,ClinicNum,DateEntry,DepositNum,Receipt,IsRecurringCC,SecUserNumEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(payment.PayNum)+",";
			}
			command+=
				     POut.Long  (payment.PayType)+","
				+    POut.Date  (payment.PayDate)+","
				+"'"+POut.Double(payment.PayAmt)+"',"
				+"'"+POut.String(payment.CheckNum)+"',"
				+"'"+POut.String(payment.BankBranch)+"',"
				+"'"+POut.String(payment.PayNote)+"',"
				+    POut.Bool  (payment.IsSplit)+","
				+    POut.Long  (payment.PatNum)+","
				+    POut.Long  (payment.ClinicNum)+","
				+    DbHelper.Now()+","
				+    POut.Long  (payment.DepositNum)+","
				+    DbHelper.ParamChar+"paramReceipt,"
				+    POut.Bool  (payment.IsRecurringCC)+","
				+    POut.Long  (payment.SecUserNumEntry)+")";
				//SecDateTEdit can only be set by MySQL
			if(payment.Receipt==null) {
				payment.Receipt="";
			}
			OdSqlParameter paramReceipt=new OdSqlParameter("paramReceipt",OdDbType.Text,payment.Receipt);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramReceipt);
			}
			else {
				payment.PayNum=Db.NonQ(command,true,paramReceipt);
			}
			return payment.PayNum;
		}

		///<summary>Inserts one Payment into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Payment payment){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(payment,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					payment.PayNum=DbHelper.GetNextOracleKey("payment","PayNum"); //Cacheless method
				}
				return InsertNoCache(payment,true);
			}
		}

		///<summary>Inserts one Payment into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Payment payment,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO payment (";
			if(!useExistingPK && isRandomKeys) {
				payment.PayNum=ReplicationServers.GetKeyNoCache("payment","PayNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PayNum,";
			}
			command+="PayType,PayDate,PayAmt,CheckNum,BankBranch,PayNote,IsSplit,PatNum,ClinicNum,DateEntry,DepositNum,Receipt,IsRecurringCC,SecUserNumEntry) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(payment.PayNum)+",";
			}
			command+=
				     POut.Long  (payment.PayType)+","
				+    POut.Date  (payment.PayDate)+","
				+"'"+POut.Double(payment.PayAmt)+"',"
				+"'"+POut.String(payment.CheckNum)+"',"
				+"'"+POut.String(payment.BankBranch)+"',"
				+"'"+POut.String(payment.PayNote)+"',"
				+    POut.Bool  (payment.IsSplit)+","
				+    POut.Long  (payment.PatNum)+","
				+    POut.Long  (payment.ClinicNum)+","
				+    DbHelper.Now()+","
				+    POut.Long  (payment.DepositNum)+","
				+    DbHelper.ParamChar+"paramReceipt,"
				+    POut.Bool  (payment.IsRecurringCC)+","
				+    POut.Long  (payment.SecUserNumEntry)+")";
				//SecDateTEdit can only be set by MySQL
			if(payment.Receipt==null) {
				payment.Receipt="";
			}
			OdSqlParameter paramReceipt=new OdSqlParameter("paramReceipt",OdDbType.Text,payment.Receipt);
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramReceipt);
			}
			else {
				payment.PayNum=Db.NonQ(command,true,paramReceipt);
			}
			return payment.PayNum;
		}

		///<summary>Updates one Payment in the database.</summary>
		public static void Update(Payment payment){
			string command="UPDATE payment SET "
				+"PayType        =  "+POut.Long  (payment.PayType)+", "
				+"PayDate        =  "+POut.Date  (payment.PayDate)+", "
				+"PayAmt         = '"+POut.Double(payment.PayAmt)+"', "
				+"CheckNum       = '"+POut.String(payment.CheckNum)+"', "
				+"BankBranch     = '"+POut.String(payment.BankBranch)+"', "
				+"PayNote        = '"+POut.String(payment.PayNote)+"', "
				+"IsSplit        =  "+POut.Bool  (payment.IsSplit)+", "
				+"PatNum         =  "+POut.Long  (payment.PatNum)+", "
				+"ClinicNum      =  "+POut.Long  (payment.ClinicNum)+", "
				//DateEntry not allowed to change
				//DepositNum excluded from update
				+"Receipt        =  "+DbHelper.ParamChar+"paramReceipt, "
				+"IsRecurringCC  =  "+POut.Bool  (payment.IsRecurringCC)+" "
				//SecUserNumEntry excluded from update
				//SecDateTEdit can only be set by MySQL
				+"WHERE PayNum = "+POut.Long(payment.PayNum);
			if(payment.Receipt==null) {
				payment.Receipt="";
			}
			OdSqlParameter paramReceipt=new OdSqlParameter("paramReceipt",OdDbType.Text,payment.Receipt);
			Db.NonQ(command,paramReceipt);
		}

		///<summary>Updates one Payment in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Payment payment,Payment oldPayment){
			string command="";
			if(payment.PayType != oldPayment.PayType) {
				if(command!=""){ command+=",";}
				command+="PayType = "+POut.Long(payment.PayType)+"";
			}
			if(payment.PayDate.Date != oldPayment.PayDate.Date) {
				if(command!=""){ command+=",";}
				command+="PayDate = "+POut.Date(payment.PayDate)+"";
			}
			if(payment.PayAmt != oldPayment.PayAmt) {
				if(command!=""){ command+=",";}
				command+="PayAmt = '"+POut.Double(payment.PayAmt)+"'";
			}
			if(payment.CheckNum != oldPayment.CheckNum) {
				if(command!=""){ command+=",";}
				command+="CheckNum = '"+POut.String(payment.CheckNum)+"'";
			}
			if(payment.BankBranch != oldPayment.BankBranch) {
				if(command!=""){ command+=",";}
				command+="BankBranch = '"+POut.String(payment.BankBranch)+"'";
			}
			if(payment.PayNote != oldPayment.PayNote) {
				if(command!=""){ command+=",";}
				command+="PayNote = '"+POut.String(payment.PayNote)+"'";
			}
			if(payment.IsSplit != oldPayment.IsSplit) {
				if(command!=""){ command+=",";}
				command+="IsSplit = "+POut.Bool(payment.IsSplit)+"";
			}
			if(payment.PatNum != oldPayment.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(payment.PatNum)+"";
			}
			if(payment.ClinicNum != oldPayment.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(payment.ClinicNum)+"";
			}
			//DateEntry not allowed to change
			//DepositNum excluded from update
			if(payment.Receipt != oldPayment.Receipt) {
				if(command!=""){ command+=",";}
				command+="Receipt = "+DbHelper.ParamChar+"paramReceipt";
			}
			if(payment.IsRecurringCC != oldPayment.IsRecurringCC) {
				if(command!=""){ command+=",";}
				command+="IsRecurringCC = "+POut.Bool(payment.IsRecurringCC)+"";
			}
			//SecUserNumEntry excluded from update
			//SecDateTEdit can only be set by MySQL
			if(command==""){
				return false;
			}
			if(payment.Receipt==null) {
				payment.Receipt="";
			}
			OdSqlParameter paramReceipt=new OdSqlParameter("paramReceipt",OdDbType.Text,payment.Receipt);
			command="UPDATE payment SET "+command
				+" WHERE PayNum = "+POut.Long(payment.PayNum);
			Db.NonQ(command,paramReceipt);
			return true;
		}

		///<summary>Deletes one Payment from the database.</summary>
		public static void Delete(long payNum){
			string command="DELETE FROM payment "
				+"WHERE PayNum = "+POut.Long(payNum);
			Db.NonQ(command);
		}

	}
}