//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class CdcrecCrud {
		///<summary>Gets one Cdcrec object from the database using the primary key.  Returns null if not found.</summary>
		public static Cdcrec SelectOne(long cdcrecNum){
			string command="SELECT * FROM cdcrec "
				+"WHERE CdcrecNum = "+POut.Long(cdcrecNum);
			List<Cdcrec> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Cdcrec object from the database using a query.</summary>
		public static Cdcrec SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Cdcrec> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Cdcrec objects from the database using a query.</summary>
		public static List<Cdcrec> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Cdcrec> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Cdcrec> TableToList(DataTable table){
			List<Cdcrec> retVal=new List<Cdcrec>();
			Cdcrec cdcrec;
			for(int i=0;i<table.Rows.Count;i++) {
				cdcrec=new Cdcrec();
				cdcrec.CdcrecNum       = PIn.Long  (table.Rows[i]["CdcrecNum"].ToString());
				cdcrec.CdcrecCode      = PIn.String(table.Rows[i]["CdcrecCode"].ToString());
				cdcrec.HeirarchicalCode= PIn.String(table.Rows[i]["HeirarchicalCode"].ToString());
				cdcrec.Description     = PIn.String(table.Rows[i]["Description"].ToString());
				retVal.Add(cdcrec);
			}
			return retVal;
		}

		///<summary>Inserts one Cdcrec into the database.  Returns the new priKey.</summary>
		public static long Insert(Cdcrec cdcrec){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				cdcrec.CdcrecNum=DbHelper.GetNextOracleKey("cdcrec","CdcrecNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(cdcrec,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							cdcrec.CdcrecNum++;
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
				return Insert(cdcrec,false);
			}
		}

		///<summary>Inserts one Cdcrec into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Cdcrec cdcrec,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				cdcrec.CdcrecNum=ReplicationServers.GetKey("cdcrec","CdcrecNum");
			}
			string command="INSERT INTO cdcrec (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CdcrecNum,";
			}
			command+="CdcrecCode,HeirarchicalCode,Description) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(cdcrec.CdcrecNum)+",";
			}
			command+=
				 "'"+POut.String(cdcrec.CdcrecCode)+"',"
				+"'"+POut.String(cdcrec.HeirarchicalCode)+"',"
				+"'"+POut.String(cdcrec.Description)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				cdcrec.CdcrecNum=Db.NonQ(command,true);
			}
			return cdcrec.CdcrecNum;
		}

		///<summary>Inserts one Cdcrec into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Cdcrec cdcrec){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(cdcrec,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					cdcrec.CdcrecNum=DbHelper.GetNextOracleKey("cdcrec","CdcrecNum"); //Cacheless method
				}
				return InsertNoCache(cdcrec,true);
			}
		}

		///<summary>Inserts one Cdcrec into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Cdcrec cdcrec,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO cdcrec (";
			if(!useExistingPK && isRandomKeys) {
				cdcrec.CdcrecNum=ReplicationServers.GetKeyNoCache("cdcrec","CdcrecNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CdcrecNum,";
			}
			command+="CdcrecCode,HeirarchicalCode,Description) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(cdcrec.CdcrecNum)+",";
			}
			command+=
				 "'"+POut.String(cdcrec.CdcrecCode)+"',"
				+"'"+POut.String(cdcrec.HeirarchicalCode)+"',"
				+"'"+POut.String(cdcrec.Description)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				cdcrec.CdcrecNum=Db.NonQ(command,true);
			}
			return cdcrec.CdcrecNum;
		}

		///<summary>Updates one Cdcrec in the database.</summary>
		public static void Update(Cdcrec cdcrec){
			string command="UPDATE cdcrec SET "
				+"CdcrecCode      = '"+POut.String(cdcrec.CdcrecCode)+"', "
				+"HeirarchicalCode= '"+POut.String(cdcrec.HeirarchicalCode)+"', "
				+"Description     = '"+POut.String(cdcrec.Description)+"' "
				+"WHERE CdcrecNum = "+POut.Long(cdcrec.CdcrecNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Cdcrec in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Cdcrec cdcrec,Cdcrec oldCdcrec){
			string command="";
			if(cdcrec.CdcrecCode != oldCdcrec.CdcrecCode) {
				if(command!=""){ command+=",";}
				command+="CdcrecCode = '"+POut.String(cdcrec.CdcrecCode)+"'";
			}
			if(cdcrec.HeirarchicalCode != oldCdcrec.HeirarchicalCode) {
				if(command!=""){ command+=",";}
				command+="HeirarchicalCode = '"+POut.String(cdcrec.HeirarchicalCode)+"'";
			}
			if(cdcrec.Description != oldCdcrec.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(cdcrec.Description)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE cdcrec SET "+command
				+" WHERE CdcrecNum = "+POut.Long(cdcrec.CdcrecNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Cdcrec from the database.</summary>
		public static void Delete(long cdcrecNum){
			string command="DELETE FROM cdcrec "
				+"WHERE CdcrecNum = "+POut.Long(cdcrecNum);
			Db.NonQ(command);
		}

	}
}