//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ApptFieldDefCrud {
		///<summary>Gets one ApptFieldDef object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptFieldDef SelectOne(long apptFieldDefNum){
			string command="SELECT * FROM apptfielddef "
				+"WHERE ApptFieldDefNum = "+POut.Long(apptFieldDefNum);
			List<ApptFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptFieldDef object from the database using a query.</summary>
		public static ApptFieldDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptFieldDef objects from the database using a query.</summary>
		public static List<ApptFieldDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptFieldDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptFieldDef> TableToList(DataTable table){
			List<ApptFieldDef> retVal=new List<ApptFieldDef>();
			ApptFieldDef apptFieldDef;
			for(int i=0;i<table.Rows.Count;i++) {
				apptFieldDef=new ApptFieldDef();
				apptFieldDef.ApptFieldDefNum= PIn.Long  (table.Rows[i]["ApptFieldDefNum"].ToString());
				apptFieldDef.FieldName      = PIn.String(table.Rows[i]["FieldName"].ToString());
				apptFieldDef.FieldType      = (OpenDentBusiness.ApptFieldType)PIn.Int(table.Rows[i]["FieldType"].ToString());
				apptFieldDef.PickList       = PIn.String(table.Rows[i]["PickList"].ToString());
				retVal.Add(apptFieldDef);
			}
			return retVal;
		}

		///<summary>Inserts one ApptFieldDef into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptFieldDef apptFieldDef){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				apptFieldDef.ApptFieldDefNum=DbHelper.GetNextOracleKey("apptfielddef","ApptFieldDefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(apptFieldDef,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							apptFieldDef.ApptFieldDefNum++;
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
				return Insert(apptFieldDef,false);
			}
		}

		///<summary>Inserts one ApptFieldDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptFieldDef apptFieldDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				apptFieldDef.ApptFieldDefNum=ReplicationServers.GetKey("apptfielddef","ApptFieldDefNum");
			}
			string command="INSERT INTO apptfielddef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptFieldDefNum,";
			}
			command+="FieldName,FieldType,PickList) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptFieldDef.ApptFieldDefNum)+",";
			}
			command+=
				 "'"+POut.String(apptFieldDef.FieldName)+"',"
				+    POut.Int   ((int)apptFieldDef.FieldType)+","
				+"'"+POut.String(apptFieldDef.PickList)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptFieldDef.ApptFieldDefNum=Db.NonQ(command,true);
			}
			return apptFieldDef.ApptFieldDefNum;
		}

		///<summary>Inserts one ApptFieldDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptFieldDef apptFieldDef){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(apptFieldDef,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					apptFieldDef.ApptFieldDefNum=DbHelper.GetNextOracleKey("apptfielddef","ApptFieldDefNum"); //Cacheless method
				}
				return InsertNoCache(apptFieldDef,true);
			}
		}

		///<summary>Inserts one ApptFieldDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptFieldDef apptFieldDef,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO apptfielddef (";
			if(!useExistingPK && isRandomKeys) {
				apptFieldDef.ApptFieldDefNum=ReplicationServers.GetKeyNoCache("apptfielddef","ApptFieldDefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ApptFieldDefNum,";
			}
			command+="FieldName,FieldType,PickList) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(apptFieldDef.ApptFieldDefNum)+",";
			}
			command+=
				 "'"+POut.String(apptFieldDef.FieldName)+"',"
				+    POut.Int   ((int)apptFieldDef.FieldType)+","
				+"'"+POut.String(apptFieldDef.PickList)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptFieldDef.ApptFieldDefNum=Db.NonQ(command,true);
			}
			return apptFieldDef.ApptFieldDefNum;
		}

		///<summary>Updates one ApptFieldDef in the database.</summary>
		public static void Update(ApptFieldDef apptFieldDef){
			string command="UPDATE apptfielddef SET "
				+"FieldName      = '"+POut.String(apptFieldDef.FieldName)+"', "
				+"FieldType      =  "+POut.Int   ((int)apptFieldDef.FieldType)+", "
				+"PickList       = '"+POut.String(apptFieldDef.PickList)+"' "
				+"WHERE ApptFieldDefNum = "+POut.Long(apptFieldDef.ApptFieldDefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ApptFieldDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptFieldDef apptFieldDef,ApptFieldDef oldApptFieldDef){
			string command="";
			if(apptFieldDef.FieldName != oldApptFieldDef.FieldName) {
				if(command!=""){ command+=",";}
				command+="FieldName = '"+POut.String(apptFieldDef.FieldName)+"'";
			}
			if(apptFieldDef.FieldType != oldApptFieldDef.FieldType) {
				if(command!=""){ command+=",";}
				command+="FieldType = "+POut.Int   ((int)apptFieldDef.FieldType)+"";
			}
			if(apptFieldDef.PickList != oldApptFieldDef.PickList) {
				if(command!=""){ command+=",";}
				command+="PickList = '"+POut.String(apptFieldDef.PickList)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE apptfielddef SET "+command
				+" WHERE ApptFieldDefNum = "+POut.Long(apptFieldDef.ApptFieldDefNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ApptFieldDef from the database.</summary>
		public static void Delete(long apptFieldDefNum){
			string command="DELETE FROM apptfielddef "
				+"WHERE ApptFieldDefNum = "+POut.Long(apptFieldDefNum);
			Db.NonQ(command);
		}

	}
}