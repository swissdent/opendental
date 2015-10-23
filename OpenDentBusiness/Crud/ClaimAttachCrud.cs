//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimAttachCrud {
		///<summary>Gets one ClaimAttach object from the database using the primary key.  Returns null if not found.</summary>
		public static ClaimAttach SelectOne(long claimAttachNum){
			string command="SELECT * FROM claimattach "
				+"WHERE ClaimAttachNum = "+POut.Long(claimAttachNum);
			List<ClaimAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimAttach object from the database using a query.</summary>
		public static ClaimAttach SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimAttach objects from the database using a query.</summary>
		public static List<ClaimAttach> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimAttach> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ClaimAttach> TableToList(DataTable table){
			List<ClaimAttach> retVal=new List<ClaimAttach>();
			ClaimAttach claimAttach;
			for(int i=0;i<table.Rows.Count;i++) {
				claimAttach=new ClaimAttach();
				claimAttach.ClaimAttachNum   = PIn.Long  (table.Rows[i]["ClaimAttachNum"].ToString());
				claimAttach.ClaimNum         = PIn.Long  (table.Rows[i]["ClaimNum"].ToString());
				claimAttach.DisplayedFileName= PIn.String(table.Rows[i]["DisplayedFileName"].ToString());
				claimAttach.ActualFileName   = PIn.String(table.Rows[i]["ActualFileName"].ToString());
				retVal.Add(claimAttach);
			}
			return retVal;
		}

		///<summary>Inserts one ClaimAttach into the database.  Returns the new priKey.</summary>
		public static long Insert(ClaimAttach claimAttach){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claimAttach.ClaimAttachNum=DbHelper.GetNextOracleKey("claimattach","ClaimAttachNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claimAttach,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claimAttach.ClaimAttachNum++;
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
				return Insert(claimAttach,false);
			}
		}

		///<summary>Inserts one ClaimAttach into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ClaimAttach claimAttach,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claimAttach.ClaimAttachNum=ReplicationServers.GetKey("claimattach","ClaimAttachNum");
			}
			string command="INSERT INTO claimattach (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimAttachNum,";
			}
			command+="ClaimNum,DisplayedFileName,ActualFileName) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimAttach.ClaimAttachNum)+",";
			}
			command+=
				     POut.Long  (claimAttach.ClaimNum)+","
				+"'"+POut.String(claimAttach.DisplayedFileName)+"',"
				+"'"+POut.String(claimAttach.ActualFileName)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimAttach.ClaimAttachNum=Db.NonQ(command,true);
			}
			return claimAttach.ClaimAttachNum;
		}

		///<summary>Inserts one ClaimAttach into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimAttach claimAttach){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(claimAttach,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					claimAttach.ClaimAttachNum=DbHelper.GetNextOracleKey("claimattach","ClaimAttachNum"); //Cacheless method
				}
				return InsertNoCache(claimAttach,true);
			}
		}

		///<summary>Inserts one ClaimAttach into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimAttach claimAttach,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO claimattach (";
			if(!useExistingPK && isRandomKeys) {
				claimAttach.ClaimAttachNum=ReplicationServers.GetKeyNoCache("claimattach","ClaimAttachNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ClaimAttachNum,";
			}
			command+="ClaimNum,DisplayedFileName,ActualFileName) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(claimAttach.ClaimAttachNum)+",";
			}
			command+=
				     POut.Long  (claimAttach.ClaimNum)+","
				+"'"+POut.String(claimAttach.DisplayedFileName)+"',"
				+"'"+POut.String(claimAttach.ActualFileName)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimAttach.ClaimAttachNum=Db.NonQ(command,true);
			}
			return claimAttach.ClaimAttachNum;
		}

		///<summary>Updates one ClaimAttach in the database.</summary>
		public static void Update(ClaimAttach claimAttach){
			string command="UPDATE claimattach SET "
				+"ClaimNum         =  "+POut.Long  (claimAttach.ClaimNum)+", "
				+"DisplayedFileName= '"+POut.String(claimAttach.DisplayedFileName)+"', "
				+"ActualFileName   = '"+POut.String(claimAttach.ActualFileName)+"' "
				+"WHERE ClaimAttachNum = "+POut.Long(claimAttach.ClaimAttachNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ClaimAttach in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ClaimAttach claimAttach,ClaimAttach oldClaimAttach){
			string command="";
			if(claimAttach.ClaimNum != oldClaimAttach.ClaimNum) {
				if(command!=""){ command+=",";}
				command+="ClaimNum = "+POut.Long(claimAttach.ClaimNum)+"";
			}
			if(claimAttach.DisplayedFileName != oldClaimAttach.DisplayedFileName) {
				if(command!=""){ command+=",";}
				command+="DisplayedFileName = '"+POut.String(claimAttach.DisplayedFileName)+"'";
			}
			if(claimAttach.ActualFileName != oldClaimAttach.ActualFileName) {
				if(command!=""){ command+=",";}
				command+="ActualFileName = '"+POut.String(claimAttach.ActualFileName)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE claimattach SET "+command
				+" WHERE ClaimAttachNum = "+POut.Long(claimAttach.ClaimAttachNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ClaimAttach from the database.</summary>
		public static void Delete(long claimAttachNum){
			string command="DELETE FROM claimattach "
				+"WHERE ClaimAttachNum = "+POut.Long(claimAttachNum);
			Db.NonQ(command);
		}

	}
}