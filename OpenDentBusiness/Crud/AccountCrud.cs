//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class AccountCrud {
		///<summary>Gets one Account object from the database using the primary key.  Returns null if not found.</summary>
		public static Account SelectOne(long accountNum){
			string command="SELECT * FROM account "
				+"WHERE AccountNum = "+POut.Long(accountNum);
			List<Account> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Account object from the database using a query.</summary>
		public static Account SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Account> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Account objects from the database using a query.</summary>
		public static List<Account> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Account> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Account> TableToList(DataTable table){
			List<Account> retVal=new List<Account>();
			Account account;
			foreach(DataRow row in table.Rows) {
				account=new Account();
				account.AccountNum  = PIn.Long  (row["AccountNum"].ToString());
				account.Description = PIn.String(row["Description"].ToString());
				account.AcctType    = (OpenDentBusiness.AccountType)PIn.Int(row["AcctType"].ToString());
				account.BankNumber  = PIn.String(row["BankNumber"].ToString());
				account.Inactive    = PIn.Bool  (row["Inactive"].ToString());
				account.AccountColor= Color.FromArgb(PIn.Int(row["AccountColor"].ToString()));
				retVal.Add(account);
			}
			return retVal;
		}

		///<summary>Converts a list of Account into a DataTable.</summary>
		public static DataTable ListToTable(List<Account> listAccounts,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Account";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AccountNum");
			table.Columns.Add("Description");
			table.Columns.Add("AcctType");
			table.Columns.Add("BankNumber");
			table.Columns.Add("Inactive");
			table.Columns.Add("AccountColor");
			foreach(Account account in listAccounts) {
				table.Rows.Add(new object[] {
					POut.Long  (account.AccountNum),
					            account.Description,
					POut.Int   ((int)account.AcctType),
					            account.BankNumber,
					POut.Bool  (account.Inactive),
					POut.Int   (account.AccountColor.ToArgb()),
				});
			}
			return table;
		}

		///<summary>Inserts one Account into the database.  Returns the new priKey.</summary>
		public static long Insert(Account account){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				account.AccountNum=DbHelper.GetNextOracleKey("account","AccountNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(account,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							account.AccountNum++;
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
				return Insert(account,false);
			}
		}

		///<summary>Inserts one Account into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Account account,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				account.AccountNum=ReplicationServers.GetKey("account","AccountNum");
			}
			string command="INSERT INTO account (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AccountNum,";
			}
			command+="Description,AcctType,BankNumber,Inactive,AccountColor) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(account.AccountNum)+",";
			}
			command+=
				 "'"+POut.String(account.Description)+"',"
				+    POut.Int   ((int)account.AcctType)+","
				+"'"+POut.String(account.BankNumber)+"',"
				+    POut.Bool  (account.Inactive)+","
				+    POut.Int   (account.AccountColor.ToArgb())+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				account.AccountNum=Db.NonQ(command,true);
			}
			return account.AccountNum;
		}

		///<summary>Inserts one Account into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Account account){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(account,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					account.AccountNum=DbHelper.GetNextOracleKey("account","AccountNum"); //Cacheless method
				}
				return InsertNoCache(account,true);
			}
		}

		///<summary>Inserts one Account into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Account account,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO account (";
			if(!useExistingPK && isRandomKeys) {
				account.AccountNum=ReplicationServers.GetKeyNoCache("account","AccountNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="AccountNum,";
			}
			command+="Description,AcctType,BankNumber,Inactive,AccountColor) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(account.AccountNum)+",";
			}
			command+=
				 "'"+POut.String(account.Description)+"',"
				+    POut.Int   ((int)account.AcctType)+","
				+"'"+POut.String(account.BankNumber)+"',"
				+    POut.Bool  (account.Inactive)+","
				+    POut.Int   (account.AccountColor.ToArgb())+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				account.AccountNum=Db.NonQ(command,true);
			}
			return account.AccountNum;
		}

		///<summary>Updates one Account in the database.</summary>
		public static void Update(Account account){
			string command="UPDATE account SET "
				+"Description = '"+POut.String(account.Description)+"', "
				+"AcctType    =  "+POut.Int   ((int)account.AcctType)+", "
				+"BankNumber  = '"+POut.String(account.BankNumber)+"', "
				+"Inactive    =  "+POut.Bool  (account.Inactive)+", "
				+"AccountColor=  "+POut.Int   (account.AccountColor.ToArgb())+" "
				+"WHERE AccountNum = "+POut.Long(account.AccountNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Account in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Account account,Account oldAccount){
			string command="";
			if(account.Description != oldAccount.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(account.Description)+"'";
			}
			if(account.AcctType != oldAccount.AcctType) {
				if(command!=""){ command+=",";}
				command+="AcctType = "+POut.Int   ((int)account.AcctType)+"";
			}
			if(account.BankNumber != oldAccount.BankNumber) {
				if(command!=""){ command+=",";}
				command+="BankNumber = '"+POut.String(account.BankNumber)+"'";
			}
			if(account.Inactive != oldAccount.Inactive) {
				if(command!=""){ command+=",";}
				command+="Inactive = "+POut.Bool(account.Inactive)+"";
			}
			if(account.AccountColor != oldAccount.AccountColor) {
				if(command!=""){ command+=",";}
				command+="AccountColor = "+POut.Int(account.AccountColor.ToArgb())+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE account SET "+command
				+" WHERE AccountNum = "+POut.Long(account.AccountNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Account,Account) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Account account,Account oldAccount) {
			if(account.Description != oldAccount.Description) {
				return true;
			}
			if(account.AcctType != oldAccount.AcctType) {
				return true;
			}
			if(account.BankNumber != oldAccount.BankNumber) {
				return true;
			}
			if(account.Inactive != oldAccount.Inactive) {
				return true;
			}
			if(account.AccountColor != oldAccount.AccountColor) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Account from the database.</summary>
		public static void Delete(long accountNum){
			string command="DELETE FROM account "
				+"WHERE AccountNum = "+POut.Long(accountNum);
			Db.NonQ(command);
		}

	}
}