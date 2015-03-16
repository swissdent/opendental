//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ConnectionGroupCrud {
		///<summary>Gets one ConnectionGroup object from the database using the primary key.  Returns null if not found.</summary>
		public static ConnectionGroup SelectOne(long connectionGroupNum){
			string command="SELECT * FROM connectiongroup "
				+"WHERE ConnectionGroupNum = "+POut.Long(connectionGroupNum);
			List<ConnectionGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ConnectionGroup object from the database using a query.</summary>
		public static ConnectionGroup SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ConnectionGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ConnectionGroup objects from the database using a query.</summary>
		public static List<ConnectionGroup> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ConnectionGroup> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ConnectionGroup> TableToList(DataTable table){
			List<ConnectionGroup> retVal=new List<ConnectionGroup>();
			ConnectionGroup connectionGroup;
			for(int i=0;i<table.Rows.Count;i++) {
				connectionGroup=new ConnectionGroup();
				connectionGroup.ConnectionGroupNum= PIn.Long  (table.Rows[i]["ConnectionGroupNum"].ToString());
				connectionGroup.Description       = PIn.String(table.Rows[i]["Description"].ToString());
				retVal.Add(connectionGroup);
			}
			return retVal;
		}

		///<summary>Inserts one ConnectionGroup into the database.  Returns the new priKey.</summary>
		public static long Insert(ConnectionGroup connectionGroup){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				connectionGroup.ConnectionGroupNum=DbHelper.GetNextOracleKey("connectiongroup","ConnectionGroupNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(connectionGroup,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							connectionGroup.ConnectionGroupNum++;
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
				return Insert(connectionGroup,false);
			}
		}

		///<summary>Inserts one ConnectionGroup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ConnectionGroup connectionGroup,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				connectionGroup.ConnectionGroupNum=ReplicationServers.GetKey("connectiongroup","ConnectionGroupNum");
			}
			string command="INSERT INTO connectiongroup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ConnectionGroupNum,";
			}
			command+="Description) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(connectionGroup.ConnectionGroupNum)+",";
			}
			command+=
				 "'"+POut.String(connectionGroup.Description)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				connectionGroup.ConnectionGroupNum=Db.NonQ(command,true);
			}
			return connectionGroup.ConnectionGroupNum;
		}

		///<summary>Updates one ConnectionGroup in the database.</summary>
		public static void Update(ConnectionGroup connectionGroup){
			string command="UPDATE connectiongroup SET "
				+"Description       = '"+POut.String(connectionGroup.Description)+"' "
				+"WHERE ConnectionGroupNum = "+POut.Long(connectionGroup.ConnectionGroupNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ConnectionGroup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ConnectionGroup connectionGroup,ConnectionGroup oldConnectionGroup){
			string command="";
			if(connectionGroup.Description != oldConnectionGroup.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(connectionGroup.Description)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE connectiongroup SET "+command
				+" WHERE ConnectionGroupNum = "+POut.Long(connectionGroup.ConnectionGroupNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ConnectionGroup from the database.</summary>
		public static void Delete(long connectionGroupNum){
			string command="DELETE FROM connectiongroup "
				+"WHERE ConnectionGroupNum = "+POut.Long(connectionGroupNum);
			Db.NonQ(command);
		}

	}
}