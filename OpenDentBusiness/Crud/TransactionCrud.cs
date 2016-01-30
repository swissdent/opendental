//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TransactionCrud {
		///<summary>Gets one Transaction object from the database using the primary key.  Returns null if not found.</summary>
		public static Transaction SelectOne(long transactionNum){
			string command="SELECT * FROM transaction "
				+"WHERE TransactionNum = "+POut.Long(transactionNum);
			List<Transaction> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Transaction object from the database using a query.</summary>
		public static Transaction SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Transaction> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Transaction objects from the database using a query.</summary>
		public static List<Transaction> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Transaction> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Transaction> TableToList(DataTable table){
			List<Transaction> retVal=new List<Transaction>();
			Transaction transaction;
			foreach(DataRow row in table.Rows) {
				transaction=new Transaction();
				transaction.TransactionNum= PIn.Long  (row["TransactionNum"].ToString());
				transaction.DateTimeEntry = PIn.DateT (row["DateTimeEntry"].ToString());
				transaction.UserNum       = PIn.Long  (row["UserNum"].ToString());
				transaction.DepositNum    = PIn.Long  (row["DepositNum"].ToString());
				transaction.PayNum        = PIn.Long  (row["PayNum"].ToString());
				retVal.Add(transaction);
			}
			return retVal;
		}

		///<summary>Converts a list of Transaction into a DataTable.</summary>
		public static DataTable ListToTable(List<Transaction> listTransactions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Transaction";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TransactionNum");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("UserNum");
			table.Columns.Add("DepositNum");
			table.Columns.Add("PayNum");
			foreach(Transaction transaction in listTransactions) {
				table.Rows.Add(new object[] {
					POut.Long  (transaction.TransactionNum),
					POut.DateT (transaction.DateTimeEntry),
					POut.Long  (transaction.UserNum),
					POut.Long  (transaction.DepositNum),
					POut.Long  (transaction.PayNum),
				});
			}
			return table;
		}

		///<summary>Inserts one Transaction into the database.  Returns the new priKey.</summary>
		public static long Insert(Transaction transaction){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				transaction.TransactionNum=DbHelper.GetNextOracleKey("transaction","TransactionNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(transaction,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							transaction.TransactionNum++;
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
				return Insert(transaction,false);
			}
		}

		///<summary>Inserts one Transaction into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Transaction transaction,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				transaction.TransactionNum=ReplicationServers.GetKey("transaction","TransactionNum");
			}
			string command="INSERT INTO transaction (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TransactionNum,";
			}
			command+="DateTimeEntry,UserNum,DepositNum,PayNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(transaction.TransactionNum)+",";
			}
			command+=
				     DbHelper.Now()+","
				+    POut.Long  (transaction.UserNum)+","
				+    POut.Long  (transaction.DepositNum)+","
				+    POut.Long  (transaction.PayNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				transaction.TransactionNum=Db.NonQ(command,true);
			}
			return transaction.TransactionNum;
		}

		///<summary>Inserts one Transaction into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Transaction transaction){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(transaction,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					transaction.TransactionNum=DbHelper.GetNextOracleKey("transaction","TransactionNum"); //Cacheless method
				}
				return InsertNoCache(transaction,true);
			}
		}

		///<summary>Inserts one Transaction into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Transaction transaction,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO transaction (";
			if(!useExistingPK && isRandomKeys) {
				transaction.TransactionNum=ReplicationServers.GetKeyNoCache("transaction","TransactionNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="TransactionNum,";
			}
			command+="DateTimeEntry,UserNum,DepositNum,PayNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(transaction.TransactionNum)+",";
			}
			command+=
				     DbHelper.Now()+","
				+    POut.Long  (transaction.UserNum)+","
				+    POut.Long  (transaction.DepositNum)+","
				+    POut.Long  (transaction.PayNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				transaction.TransactionNum=Db.NonQ(command,true);
			}
			return transaction.TransactionNum;
		}

		///<summary>Updates one Transaction in the database.</summary>
		public static void Update(Transaction transaction){
			string command="UPDATE transaction SET "
				//DateTimeEntry not allowed to change
				+"UserNum       =  "+POut.Long  (transaction.UserNum)+", "
				+"DepositNum    =  "+POut.Long  (transaction.DepositNum)+", "
				+"PayNum        =  "+POut.Long  (transaction.PayNum)+" "
				+"WHERE TransactionNum = "+POut.Long(transaction.TransactionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Transaction in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Transaction transaction,Transaction oldTransaction){
			string command="";
			//DateTimeEntry not allowed to change
			if(transaction.UserNum != oldTransaction.UserNum) {
				if(command!=""){ command+=",";}
				command+="UserNum = "+POut.Long(transaction.UserNum)+"";
			}
			if(transaction.DepositNum != oldTransaction.DepositNum) {
				if(command!=""){ command+=",";}
				command+="DepositNum = "+POut.Long(transaction.DepositNum)+"";
			}
			if(transaction.PayNum != oldTransaction.PayNum) {
				if(command!=""){ command+=",";}
				command+="PayNum = "+POut.Long(transaction.PayNum)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE transaction SET "+command
				+" WHERE TransactionNum = "+POut.Long(transaction.TransactionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Transaction,Transaction) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Transaction transaction,Transaction oldTransaction) {
			//DateTimeEntry not allowed to change
			if(transaction.UserNum != oldTransaction.UserNum) {
				return true;
			}
			if(transaction.DepositNum != oldTransaction.DepositNum) {
				return true;
			}
			if(transaction.PayNum != oldTransaction.PayNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Transaction from the database.</summary>
		public static void Delete(long transactionNum){
			string command="DELETE FROM transaction "
				+"WHERE TransactionNum = "+POut.Long(transactionNum);
			Db.NonQ(command);
		}

	}
}