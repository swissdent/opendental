//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class FeeCrud {
		///<summary>Gets one Fee object from the database using the primary key.  Returns null if not found.</summary>
		public static Fee SelectOne(long feeNum){
			string command="SELECT * FROM fee "
				+"WHERE FeeNum = "+POut.Long(feeNum);
			List<Fee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Fee object from the database using a query.</summary>
		public static Fee SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Fee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Fee objects from the database using a query.</summary>
		public static List<Fee> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Fee> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Fee> TableToList(DataTable table){
			List<Fee> retVal=new List<Fee>();
			Fee fee;
			foreach(DataRow row in table.Rows) {
				fee=new Fee();
				fee.FeeNum         = PIn.Long  (row["FeeNum"].ToString());
				fee.Amount         = PIn.Double(row["Amount"].ToString());
				fee.OldCode        = PIn.String(row["OldCode"].ToString());
				fee.FeeSched       = PIn.Long  (row["FeeSched"].ToString());
				fee.UseDefaultFee  = PIn.Bool  (row["UseDefaultFee"].ToString());
				fee.UseDefaultCov  = PIn.Bool  (row["UseDefaultCov"].ToString());
				fee.CodeNum        = PIn.Long  (row["CodeNum"].ToString());
				fee.ClinicNum      = PIn.Long  (row["ClinicNum"].ToString());
				fee.ProvNum        = PIn.Long  (row["ProvNum"].ToString());
				fee.SecUserNumEntry= PIn.Long  (row["SecUserNumEntry"].ToString());
				fee.SecDateEntry   = PIn.Date  (row["SecDateEntry"].ToString());
				fee.SecDateTEdit   = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(fee);
			}
			return retVal;
		}

		///<summary>Converts a list of Fee into a DataTable.</summary>
		public static DataTable ListToTable(List<Fee> listFees,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Fee";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("FeeNum");
			table.Columns.Add("Amount");
			table.Columns.Add("OldCode");
			table.Columns.Add("FeeSched");
			table.Columns.Add("UseDefaultFee");
			table.Columns.Add("UseDefaultCov");
			table.Columns.Add("CodeNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateEntry");
			table.Columns.Add("SecDateTEdit");
			foreach(Fee fee in listFees) {
				table.Rows.Add(new object[] {
					POut.Long  (fee.FeeNum),
					POut.Double(fee.Amount),
					            fee.OldCode,
					POut.Long  (fee.FeeSched),
					POut.Bool  (fee.UseDefaultFee),
					POut.Bool  (fee.UseDefaultCov),
					POut.Long  (fee.CodeNum),
					POut.Long  (fee.ClinicNum),
					POut.Long  (fee.ProvNum),
					POut.Long  (fee.SecUserNumEntry),
					POut.Date  (fee.SecDateEntry),
					POut.DateT (fee.SecDateTEdit),
				});
			}
			return table;
		}

		///<summary>Inserts one Fee into the database.  Returns the new priKey.</summary>
		public static long Insert(Fee fee){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				fee.FeeNum=DbHelper.GetNextOracleKey("fee","FeeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(fee,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							fee.FeeNum++;
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
				return Insert(fee,false);
			}
		}

		///<summary>Inserts one Fee into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Fee fee,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				fee.FeeNum=ReplicationServers.GetKey("fee","FeeNum");
			}
			string command="INSERT INTO fee (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="FeeNum,";
			}
			command+="Amount,OldCode,FeeSched,UseDefaultFee,UseDefaultCov,CodeNum,ClinicNum,ProvNum,SecUserNumEntry,SecDateEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(fee.FeeNum)+",";
			}
			command+=
				 "'"+POut.Double(fee.Amount)+"',"
				+"'"+POut.String(fee.OldCode)+"',"
				+    POut.Long  (fee.FeeSched)+","
				+    POut.Bool  (fee.UseDefaultFee)+","
				+    POut.Bool  (fee.UseDefaultCov)+","
				+    POut.Long  (fee.CodeNum)+","
				+    POut.Long  (fee.ClinicNum)+","
				+    POut.Long  (fee.ProvNum)+","
				+    POut.Long  (fee.SecUserNumEntry)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				fee.FeeNum=Db.NonQ(command,true);
			}
			return fee.FeeNum;
		}

		///<summary>Inserts one Fee into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Fee fee){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(fee,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					fee.FeeNum=DbHelper.GetNextOracleKey("fee","FeeNum"); //Cacheless method
				}
				return InsertNoCache(fee,true);
			}
		}

		///<summary>Inserts one Fee into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Fee fee,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO fee (";
			if(!useExistingPK && isRandomKeys) {
				fee.FeeNum=ReplicationServers.GetKeyNoCache("fee","FeeNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="FeeNum,";
			}
			command+="Amount,OldCode,FeeSched,UseDefaultFee,UseDefaultCov,CodeNum,ClinicNum,ProvNum,SecUserNumEntry,SecDateEntry) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(fee.FeeNum)+",";
			}
			command+=
				 "'"+POut.Double(fee.Amount)+"',"
				+"'"+POut.String(fee.OldCode)+"',"
				+    POut.Long  (fee.FeeSched)+","
				+    POut.Bool  (fee.UseDefaultFee)+","
				+    POut.Bool  (fee.UseDefaultCov)+","
				+    POut.Long  (fee.CodeNum)+","
				+    POut.Long  (fee.ClinicNum)+","
				+    POut.Long  (fee.ProvNum)+","
				+    POut.Long  (fee.SecUserNumEntry)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				fee.FeeNum=Db.NonQ(command,true);
			}
			return fee.FeeNum;
		}

		///<summary>Updates one Fee in the database.</summary>
		public static void Update(Fee fee){
			string command="UPDATE fee SET "
				+"Amount         = '"+POut.Double(fee.Amount)+"', "
				+"OldCode        = '"+POut.String(fee.OldCode)+"', "
				+"FeeSched       =  "+POut.Long  (fee.FeeSched)+", "
				+"UseDefaultFee  =  "+POut.Bool  (fee.UseDefaultFee)+", "
				+"UseDefaultCov  =  "+POut.Bool  (fee.UseDefaultCov)+", "
				+"CodeNum        =  "+POut.Long  (fee.CodeNum)+", "
				+"ClinicNum      =  "+POut.Long  (fee.ClinicNum)+", "
				+"ProvNum        =  "+POut.Long  (fee.ProvNum)+" "
				//SecUserNumEntry excluded from update
				//SecDateEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"WHERE FeeNum = "+POut.Long(fee.FeeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Fee in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Fee fee,Fee oldFee){
			string command="";
			if(fee.Amount != oldFee.Amount) {
				if(command!=""){ command+=",";}
				command+="Amount = '"+POut.Double(fee.Amount)+"'";
			}
			if(fee.OldCode != oldFee.OldCode) {
				if(command!=""){ command+=",";}
				command+="OldCode = '"+POut.String(fee.OldCode)+"'";
			}
			if(fee.FeeSched != oldFee.FeeSched) {
				if(command!=""){ command+=",";}
				command+="FeeSched = "+POut.Long(fee.FeeSched)+"";
			}
			if(fee.UseDefaultFee != oldFee.UseDefaultFee) {
				if(command!=""){ command+=",";}
				command+="UseDefaultFee = "+POut.Bool(fee.UseDefaultFee)+"";
			}
			if(fee.UseDefaultCov != oldFee.UseDefaultCov) {
				if(command!=""){ command+=",";}
				command+="UseDefaultCov = "+POut.Bool(fee.UseDefaultCov)+"";
			}
			if(fee.CodeNum != oldFee.CodeNum) {
				if(command!=""){ command+=",";}
				command+="CodeNum = "+POut.Long(fee.CodeNum)+"";
			}
			if(fee.ClinicNum != oldFee.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(fee.ClinicNum)+"";
			}
			if(fee.ProvNum != oldFee.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(fee.ProvNum)+"";
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(command==""){
				return false;
			}
			command="UPDATE fee SET "+command
				+" WHERE FeeNum = "+POut.Long(fee.FeeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Fee,Fee) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Fee fee,Fee oldFee) {
			if(fee.Amount != oldFee.Amount) {
				return true;
			}
			if(fee.OldCode != oldFee.OldCode) {
				return true;
			}
			if(fee.FeeSched != oldFee.FeeSched) {
				return true;
			}
			if(fee.UseDefaultFee != oldFee.UseDefaultFee) {
				return true;
			}
			if(fee.UseDefaultCov != oldFee.UseDefaultCov) {
				return true;
			}
			if(fee.CodeNum != oldFee.CodeNum) {
				return true;
			}
			if(fee.ClinicNum != oldFee.ClinicNum) {
				return true;
			}
			if(fee.ProvNum != oldFee.ProvNum) {
				return true;
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one Fee from the database.</summary>
		public static void Delete(long feeNum){
			string command="DELETE FROM fee "
				+"WHERE FeeNum = "+POut.Long(feeNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.
		///Supply Security.CurUser.UserNum, used to set the SecUserNumEntry field for Inserts.</summary>
		public static bool Sync(List<Fee> listNew,List<Fee> listDB,long userNum) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<Fee> listIns    =new List<Fee>();
			List<Fee> listUpdNew =new List<Fee>();
			List<Fee> listUpdDB  =new List<Fee>();
			List<Fee> listDel    =new List<Fee>();
			listNew.Sort((Fee x,Fee y) => { return x.FeeNum.CompareTo(y.FeeNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((Fee x,Fee y) => { return x.FeeNum.CompareTo(y.FeeNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			Fee fieldNew;
			Fee fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.FeeNum<fieldDB.FeeNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.FeeNum>fieldDB.FeeNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				listIns[i].SecUserNumEntry=userNum;
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])){
					rowsUpdatedCount++;
				}
			}
			for(int i=0;i<listDel.Count;i++) {
				Delete(listDel[i].FeeNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}