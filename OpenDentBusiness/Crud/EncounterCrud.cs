//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EncounterCrud {
		///<summary>Gets one Encounter object from the database using the primary key.  Returns null if not found.</summary>
		public static Encounter SelectOne(long encounterNum){
			string command="SELECT * FROM encounter "
				+"WHERE EncounterNum = "+POut.Long(encounterNum);
			List<Encounter> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Encounter object from the database using a query.</summary>
		public static Encounter SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Encounter> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Encounter objects from the database using a query.</summary>
		public static List<Encounter> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Encounter> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Encounter> TableToList(DataTable table){
			List<Encounter> retVal=new List<Encounter>();
			Encounter encounter;
			for(int i=0;i<table.Rows.Count;i++) {
				encounter=new Encounter();
				encounter.EncounterNum = PIn.Long  (table.Rows[i]["EncounterNum"].ToString());
				encounter.PatNum       = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				encounter.ProvNum      = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				encounter.CodeValue    = PIn.String(table.Rows[i]["CodeValue"].ToString());
				encounter.CodeSystem   = PIn.String(table.Rows[i]["CodeSystem"].ToString());
				encounter.Note         = PIn.String(table.Rows[i]["Note"].ToString());
				encounter.DateEncounter= PIn.Date  (table.Rows[i]["DateEncounter"].ToString());
				retVal.Add(encounter);
			}
			return retVal;
		}

		///<summary>Inserts one Encounter into the database.  Returns the new priKey.</summary>
		public static long Insert(Encounter encounter){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				encounter.EncounterNum=DbHelper.GetNextOracleKey("encounter","EncounterNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(encounter,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							encounter.EncounterNum++;
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
				return Insert(encounter,false);
			}
		}

		///<summary>Inserts one Encounter into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Encounter encounter,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				encounter.EncounterNum=ReplicationServers.GetKey("encounter","EncounterNum");
			}
			string command="INSERT INTO encounter (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EncounterNum,";
			}
			command+="PatNum,ProvNum,CodeValue,CodeSystem,Note,DateEncounter) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(encounter.EncounterNum)+",";
			}
			command+=
				     POut.Long  (encounter.PatNum)+","
				+    POut.Long  (encounter.ProvNum)+","
				+"'"+POut.String(encounter.CodeValue)+"',"
				+"'"+POut.String(encounter.CodeSystem)+"',"
				+"'"+POut.String(encounter.Note)+"',"
				+    POut.Date  (encounter.DateEncounter)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				encounter.EncounterNum=Db.NonQ(command,true);
			}
			return encounter.EncounterNum;
		}

		///<summary>Updates one Encounter in the database.</summary>
		public static void Update(Encounter encounter){
			string command="UPDATE encounter SET "
				+"PatNum       =  "+POut.Long  (encounter.PatNum)+", "
				+"ProvNum      =  "+POut.Long  (encounter.ProvNum)+", "
				+"CodeValue    = '"+POut.String(encounter.CodeValue)+"', "
				+"CodeSystem   = '"+POut.String(encounter.CodeSystem)+"', "
				+"Note         = '"+POut.String(encounter.Note)+"', "
				+"DateEncounter=  "+POut.Date  (encounter.DateEncounter)+" "
				+"WHERE EncounterNum = "+POut.Long(encounter.EncounterNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Encounter in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Encounter encounter,Encounter oldEncounter){
			string command="";
			if(encounter.PatNum != oldEncounter.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(encounter.PatNum)+"";
			}
			if(encounter.ProvNum != oldEncounter.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(encounter.ProvNum)+"";
			}
			if(encounter.CodeValue != oldEncounter.CodeValue) {
				if(command!=""){ command+=",";}
				command+="CodeValue = '"+POut.String(encounter.CodeValue)+"'";
			}
			if(encounter.CodeSystem != oldEncounter.CodeSystem) {
				if(command!=""){ command+=",";}
				command+="CodeSystem = '"+POut.String(encounter.CodeSystem)+"'";
			}
			if(encounter.Note != oldEncounter.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(encounter.Note)+"'";
			}
			if(encounter.DateEncounter != oldEncounter.DateEncounter) {
				if(command!=""){ command+=",";}
				command+="DateEncounter = "+POut.Date(encounter.DateEncounter)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE encounter SET "+command
				+" WHERE EncounterNum = "+POut.Long(encounter.EncounterNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Encounter from the database.</summary>
		public static void Delete(long encounterNum){
			string command="DELETE FROM encounter "
				+"WHERE EncounterNum = "+POut.Long(encounterNum);
			Db.NonQ(command);
		}

	}
}