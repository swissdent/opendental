//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimSnapshotCrud {
		///<summary>Gets one ClaimSnapshot object from the database using the primary key.  Returns null if not found.</summary>
		public static ClaimSnapshot SelectOne(long claimSnapshotNum){
			string command="SELECT * FROM claimsnapshot "
				+"WHERE ClaimSnapshotNum = "+POut.Long(claimSnapshotNum);
			List<ClaimSnapshot> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimSnapshot object from the database using a query.</summary>
		public static ClaimSnapshot SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimSnapshot> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimSnapshot objects from the database using a query.</summary>
		public static List<ClaimSnapshot> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimSnapshot> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ClaimSnapshot> TableToList(DataTable table){
			List<ClaimSnapshot> retVal=new List<ClaimSnapshot>();
			ClaimSnapshot claimSnapshot;
			for(int i=0;i<table.Rows.Count;i++) {
				claimSnapshot=new ClaimSnapshot();
				claimSnapshot.ClaimSnapshotNum= PIn.Long  (table.Rows[i]["ClaimSnapshotNum"].ToString());
				claimSnapshot.ProcNum         = PIn.Long  (table.Rows[i]["ProcNum"].ToString());
				claimSnapshot.ClaimType       = PIn.String(table.Rows[i]["ClaimType"].ToString());
				claimSnapshot.Writeoff        = PIn.Double(table.Rows[i]["Writeoff"].ToString());
				claimSnapshot.InsPayEst  = PIn.Double(table.Rows[i]["InsPayEst"].ToString());
				claimSnapshot.Fee             = PIn.Double(table.Rows[i]["Fee"].ToString());
				claimSnapshot.DateTEntry      = PIn.DateT (table.Rows[i]["DateTEntry"].ToString());
				retVal.Add(claimSnapshot);
			}
			return retVal;
		}

		///<summary>Inserts one ClaimSnapshot into the database.  Returns the new priKey.</summary>
		public static long Insert(ClaimSnapshot claimSnapshot){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claimSnapshot.ClaimSnapshotNum=DbHelper.GetNextOracleKey("claimsnapshot","ClaimSnapshotNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claimSnapshot,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claimSnapshot.ClaimSnapshotNum++;
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
				return Insert(claimSnapshot,false);
			}
		}

		///<summary>Inserts one ClaimSnapshot into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ClaimSnapshot claimSnapshot,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claimSnapshot.ClaimSnapshotNum=ReplicationServers.GetKey("claimsnapshot","ClaimSnapshotNum");
			}
			string command="INSERT INTO claimsnapshot (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimSnapshotNum,";
			}
			command+="ProcNum,ClaimType,Writeoff,InsPayEst,Fee,DateTEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimSnapshot.ClaimSnapshotNum)+",";
			}
			command+=
				     POut.Long  (claimSnapshot.ProcNum)+","
				+"'"+POut.String(claimSnapshot.ClaimType)+"',"
				+"'"+POut.Double(claimSnapshot.Writeoff)+"',"
				+"'"+POut.Double(claimSnapshot.InsPayEst)+"',"
				+"'"+POut.Double(claimSnapshot.Fee)+"',"
				+    DbHelper.Now()+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimSnapshot.ClaimSnapshotNum=Db.NonQ(command,true);
			}
			return claimSnapshot.ClaimSnapshotNum;
		}

		///<summary>Inserts one ClaimSnapshot into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimSnapshot claimSnapshot){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(claimSnapshot,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					claimSnapshot.ClaimSnapshotNum=DbHelper.GetNextOracleKey("claimsnapshot","ClaimSnapshotNum"); //Cacheless method
				}
				return InsertNoCache(claimSnapshot,true);
			}
		}

		///<summary>Inserts one ClaimSnapshot into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimSnapshot claimSnapshot,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO claimsnapshot (";
			if(!useExistingPK && isRandomKeys) {
				claimSnapshot.ClaimSnapshotNum=ReplicationServers.GetKeyNoCache("claimsnapshot","ClaimSnapshotNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ClaimSnapshotNum,";
			}
			command+="ProcNum,ClaimType,Writeoff,InsPayEst,Fee,DateTEntry) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(claimSnapshot.ClaimSnapshotNum)+",";
			}
			command+=
				     POut.Long  (claimSnapshot.ProcNum)+","
				+"'"+POut.String(claimSnapshot.ClaimType)+"',"
				+"'"+POut.Double(claimSnapshot.Writeoff)+"',"
				+"'"+POut.Double(claimSnapshot.InsPayEst)+"',"
				+"'"+POut.Double(claimSnapshot.Fee)+"',"
				+    DbHelper.Now()+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimSnapshot.ClaimSnapshotNum=Db.NonQ(command,true);
			}
			return claimSnapshot.ClaimSnapshotNum;
		}

		///<summary>Updates one ClaimSnapshot in the database.</summary>
		public static void Update(ClaimSnapshot claimSnapshot){
			string command="UPDATE claimsnapshot SET "
				+"ProcNum         =  "+POut.Long  (claimSnapshot.ProcNum)+", "
				+"ClaimType       = '"+POut.String(claimSnapshot.ClaimType)+"', "
				+"Writeoff        = '"+POut.Double(claimSnapshot.Writeoff)+"', "
				+"InsPayEst  = '"+POut.Double(claimSnapshot.InsPayEst)+"', "
				+"Fee             = '"+POut.Double(claimSnapshot.Fee)+"', "
				//DateTEntry not allowed to change
				+"WHERE ClaimSnapshotNum = "+POut.Long(claimSnapshot.ClaimSnapshotNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ClaimSnapshot in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ClaimSnapshot claimSnapshot,ClaimSnapshot oldClaimSnapshot){
			string command="";
			if(claimSnapshot.ProcNum != oldClaimSnapshot.ProcNum) {
				if(command!=""){ command+=",";}
				command+="ProcNum = "+POut.Long(claimSnapshot.ProcNum)+"";
			}
			if(claimSnapshot.ClaimType != oldClaimSnapshot.ClaimType) {
				if(command!=""){ command+=",";}
				command+="ClaimType = '"+POut.String(claimSnapshot.ClaimType)+"'";
			}
			if(claimSnapshot.Writeoff != oldClaimSnapshot.Writeoff) {
				if(command!=""){ command+=",";}
				command+="Writeoff = '"+POut.Double(claimSnapshot.Writeoff)+"'";
			}
			if(claimSnapshot.InsPayEst != oldClaimSnapshot.InsPayEst) {
				if(command!=""){ command+=",";}
				command+="InsPayEst = '"+POut.Double(claimSnapshot.InsPayEst)+"'";
			}
			if(claimSnapshot.Fee != oldClaimSnapshot.Fee) {
				if(command!=""){ command+=",";}
				command+="Fee = '"+POut.Double(claimSnapshot.Fee)+"'";
			}
			//DateTEntry not allowed to change
			if(command==""){
				return false;
			}
			command="UPDATE claimsnapshot SET "+command
				+" WHERE ClaimSnapshotNum = "+POut.Long(claimSnapshot.ClaimSnapshotNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ClaimSnapshot from the database.</summary>
		public static void Delete(long claimSnapshotNum){
			string command="DELETE FROM claimsnapshot "
				+"WHERE ClaimSnapshotNum = "+POut.Long(claimSnapshotNum);
			Db.NonQ(command);
		}

	}
}