//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimValCodeLogCrud {
		///<summary>Gets one ClaimValCodeLog object from the database using the primary key.  Returns null if not found.</summary>
		public static ClaimValCodeLog SelectOne(long claimValCodeLogNum){
			string command="SELECT * FROM claimvalcodelog "
				+"WHERE ClaimValCodeLogNum = "+POut.Long(claimValCodeLogNum);
			List<ClaimValCodeLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimValCodeLog object from the database using a query.</summary>
		public static ClaimValCodeLog SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimValCodeLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimValCodeLog objects from the database using a query.</summary>
		public static List<ClaimValCodeLog> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimValCodeLog> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ClaimValCodeLog> TableToList(DataTable table){
			List<ClaimValCodeLog> retVal=new List<ClaimValCodeLog>();
			ClaimValCodeLog claimValCodeLog;
			for(int i=0;i<table.Rows.Count;i++) {
				claimValCodeLog=new ClaimValCodeLog();
				claimValCodeLog.ClaimValCodeLogNum= PIn.Long  (table.Rows[i]["ClaimValCodeLogNum"].ToString());
				claimValCodeLog.ClaimNum          = PIn.Long  (table.Rows[i]["ClaimNum"].ToString());
				claimValCodeLog.ClaimField        = PIn.String(table.Rows[i]["ClaimField"].ToString());
				claimValCodeLog.ValCode           = PIn.String(table.Rows[i]["ValCode"].ToString());
				claimValCodeLog.ValAmount         = PIn.Double(table.Rows[i]["ValAmount"].ToString());
				claimValCodeLog.Ordinal           = PIn.Int   (table.Rows[i]["Ordinal"].ToString());
				retVal.Add(claimValCodeLog);
			}
			return retVal;
		}

		///<summary>Inserts one ClaimValCodeLog into the database.  Returns the new priKey.</summary>
		public static long Insert(ClaimValCodeLog claimValCodeLog){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claimValCodeLog.ClaimValCodeLogNum=DbHelper.GetNextOracleKey("claimvalcodelog","ClaimValCodeLogNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claimValCodeLog,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claimValCodeLog.ClaimValCodeLogNum++;
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
				return Insert(claimValCodeLog,false);
			}
		}

		///<summary>Inserts one ClaimValCodeLog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ClaimValCodeLog claimValCodeLog,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claimValCodeLog.ClaimValCodeLogNum=ReplicationServers.GetKey("claimvalcodelog","ClaimValCodeLogNum");
			}
			string command="INSERT INTO claimvalcodelog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimValCodeLogNum,";
			}
			command+="ClaimNum,ClaimField,ValCode,ValAmount,Ordinal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimValCodeLog.ClaimValCodeLogNum)+",";
			}
			command+=
				     POut.Long  (claimValCodeLog.ClaimNum)+","
				+"'"+POut.String(claimValCodeLog.ClaimField)+"',"
				+"'"+POut.String(claimValCodeLog.ValCode)+"',"
				+"'"+POut.Double(claimValCodeLog.ValAmount)+"',"
				+    POut.Int   (claimValCodeLog.Ordinal)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimValCodeLog.ClaimValCodeLogNum=Db.NonQ(command,true);
			}
			return claimValCodeLog.ClaimValCodeLogNum;
		}

		///<summary>Inserts one ClaimValCodeLog into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimValCodeLog claimValCodeLog){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(claimValCodeLog,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					claimValCodeLog.ClaimValCodeLogNum=DbHelper.GetNextOracleKey("claimvalcodelog","ClaimValCodeLogNum"); //Cacheless method
				}
				return InsertNoCache(claimValCodeLog,true);
			}
		}

		///<summary>Inserts one ClaimValCodeLog into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimValCodeLog claimValCodeLog,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO claimvalcodelog (";
			if(!useExistingPK && isRandomKeys) {
				claimValCodeLog.ClaimValCodeLogNum=ReplicationServers.GetKeyNoCache("claimvalcodelog","ClaimValCodeLogNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ClaimValCodeLogNum,";
			}
			command+="ClaimNum,ClaimField,ValCode,ValAmount,Ordinal) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(claimValCodeLog.ClaimValCodeLogNum)+",";
			}
			command+=
				     POut.Long  (claimValCodeLog.ClaimNum)+","
				+"'"+POut.String(claimValCodeLog.ClaimField)+"',"
				+"'"+POut.String(claimValCodeLog.ValCode)+"',"
				+"'"+POut.Double(claimValCodeLog.ValAmount)+"',"
				+    POut.Int   (claimValCodeLog.Ordinal)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimValCodeLog.ClaimValCodeLogNum=Db.NonQ(command,true);
			}
			return claimValCodeLog.ClaimValCodeLogNum;
		}

		///<summary>Updates one ClaimValCodeLog in the database.</summary>
		public static void Update(ClaimValCodeLog claimValCodeLog){
			string command="UPDATE claimvalcodelog SET "
				+"ClaimNum          =  "+POut.Long  (claimValCodeLog.ClaimNum)+", "
				+"ClaimField        = '"+POut.String(claimValCodeLog.ClaimField)+"', "
				+"ValCode           = '"+POut.String(claimValCodeLog.ValCode)+"', "
				+"ValAmount         = '"+POut.Double(claimValCodeLog.ValAmount)+"', "
				+"Ordinal           =  "+POut.Int   (claimValCodeLog.Ordinal)+" "
				+"WHERE ClaimValCodeLogNum = "+POut.Long(claimValCodeLog.ClaimValCodeLogNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ClaimValCodeLog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ClaimValCodeLog claimValCodeLog,ClaimValCodeLog oldClaimValCodeLog){
			string command="";
			if(claimValCodeLog.ClaimNum != oldClaimValCodeLog.ClaimNum) {
				if(command!=""){ command+=",";}
				command+="ClaimNum = "+POut.Long(claimValCodeLog.ClaimNum)+"";
			}
			if(claimValCodeLog.ClaimField != oldClaimValCodeLog.ClaimField) {
				if(command!=""){ command+=",";}
				command+="ClaimField = '"+POut.String(claimValCodeLog.ClaimField)+"'";
			}
			if(claimValCodeLog.ValCode != oldClaimValCodeLog.ValCode) {
				if(command!=""){ command+=",";}
				command+="ValCode = '"+POut.String(claimValCodeLog.ValCode)+"'";
			}
			if(claimValCodeLog.ValAmount != oldClaimValCodeLog.ValAmount) {
				if(command!=""){ command+=",";}
				command+="ValAmount = '"+POut.Double(claimValCodeLog.ValAmount)+"'";
			}
			if(claimValCodeLog.Ordinal != oldClaimValCodeLog.Ordinal) {
				if(command!=""){ command+=",";}
				command+="Ordinal = "+POut.Int(claimValCodeLog.Ordinal)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE claimvalcodelog SET "+command
				+" WHERE ClaimValCodeLogNum = "+POut.Long(claimValCodeLog.ClaimValCodeLogNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ClaimValCodeLog from the database.</summary>
		public static void Delete(long claimValCodeLogNum){
			string command="DELETE FROM claimvalcodelog "
				+"WHERE ClaimValCodeLogNum = "+POut.Long(claimValCodeLogNum);
			Db.NonQ(command);
		}

	}
}