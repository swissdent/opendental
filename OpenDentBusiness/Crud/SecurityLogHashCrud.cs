//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SecurityLogHashCrud {
		///<summary>Gets one SecurityLogHash object from the database using the primary key.  Returns null if not found.</summary>
		public static SecurityLogHash SelectOne(long securityLogHashNum){
			string command="SELECT * FROM securityloghash "
				+"WHERE SecurityLogHashNum = "+POut.Long(securityLogHashNum);
			List<SecurityLogHash> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SecurityLogHash object from the database using a query.</summary>
		public static SecurityLogHash SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SecurityLogHash> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SecurityLogHash objects from the database using a query.</summary>
		public static List<SecurityLogHash> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SecurityLogHash> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SecurityLogHash> TableToList(DataTable table){
			List<SecurityLogHash> retVal=new List<SecurityLogHash>();
			SecurityLogHash securityLogHash;
			for(int i=0;i<table.Rows.Count;i++) {
				securityLogHash=new SecurityLogHash();
				securityLogHash.SecurityLogHashNum= PIn.Long  (table.Rows[i]["SecurityLogHashNum"].ToString());
				securityLogHash.SecurityLogNum    = PIn.Long  (table.Rows[i]["SecurityLogNum"].ToString());
				securityLogHash.LogHash           = PIn.String(table.Rows[i]["LogHash"].ToString());
				retVal.Add(securityLogHash);
			}
			return retVal;
		}

		///<summary>Inserts one SecurityLogHash into the database.  Returns the new priKey.</summary>
		public static long Insert(SecurityLogHash securityLogHash){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				securityLogHash.SecurityLogHashNum=DbHelper.GetNextOracleKey("securityloghash","SecurityLogHashNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(securityLogHash,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							securityLogHash.SecurityLogHashNum++;
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
				return Insert(securityLogHash,false);
			}
		}

		///<summary>Inserts one SecurityLogHash into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SecurityLogHash securityLogHash,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				securityLogHash.SecurityLogHashNum=ReplicationServers.GetKey("securityloghash","SecurityLogHashNum");
			}
			string command="INSERT INTO securityloghash (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SecurityLogHashNum,";
			}
			command+="SecurityLogNum,LogHash) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(securityLogHash.SecurityLogHashNum)+",";
			}
			command+=
				     POut.Long  (securityLogHash.SecurityLogNum)+","
				+"'"+POut.String(securityLogHash.LogHash)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				securityLogHash.SecurityLogHashNum=Db.NonQ(command,true);
			}
			return securityLogHash.SecurityLogHashNum;
		}

		///<summary>Updates one SecurityLogHash in the database.</summary>
		public static void Update(SecurityLogHash securityLogHash){
			string command="UPDATE securityloghash SET "
				+"SecurityLogNum    =  "+POut.Long  (securityLogHash.SecurityLogNum)+", "
				+"LogHash           = '"+POut.String(securityLogHash.LogHash)+"' "
				+"WHERE SecurityLogHashNum = "+POut.Long(securityLogHash.SecurityLogHashNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SecurityLogHash in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SecurityLogHash securityLogHash,SecurityLogHash oldSecurityLogHash){
			string command="";
			if(securityLogHash.SecurityLogNum != oldSecurityLogHash.SecurityLogNum) {
				if(command!=""){ command+=",";}
				command+="SecurityLogNum = "+POut.Long(securityLogHash.SecurityLogNum)+"";
			}
			if(securityLogHash.LogHash != oldSecurityLogHash.LogHash) {
				if(command!=""){ command+=",";}
				command+="LogHash = '"+POut.String(securityLogHash.LogHash)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE securityloghash SET "+command
				+" WHERE SecurityLogHashNum = "+POut.Long(securityLogHash.SecurityLogHashNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one SecurityLogHash from the database.</summary>
		public static void Delete(long securityLogHashNum){
			string command="DELETE FROM securityloghash "
				+"WHERE SecurityLogHashNum = "+POut.Long(securityLogHashNum);
			Db.NonQ(command);
		}

	}
}