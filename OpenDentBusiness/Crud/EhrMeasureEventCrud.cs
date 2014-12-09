//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EhrMeasureEventCrud {
		///<summary>Gets one EhrMeasureEvent object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrMeasureEvent SelectOne(long ehrMeasureEventNum){
			string command="SELECT * FROM ehrmeasureevent "
				+"WHERE EhrMeasureEventNum = "+POut.Long(ehrMeasureEventNum);
			List<EhrMeasureEvent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrMeasureEvent object from the database using a query.</summary>
		public static EhrMeasureEvent SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrMeasureEvent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrMeasureEvent objects from the database using a query.</summary>
		public static List<EhrMeasureEvent> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrMeasureEvent> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrMeasureEvent> TableToList(DataTable table){
			List<EhrMeasureEvent> retVal=new List<EhrMeasureEvent>();
			EhrMeasureEvent ehrMeasureEvent;
			for(int i=0;i<table.Rows.Count;i++) {
				ehrMeasureEvent=new EhrMeasureEvent();
				ehrMeasureEvent.EhrMeasureEventNum= PIn.Long  (table.Rows[i]["EhrMeasureEventNum"].ToString());
				ehrMeasureEvent.DateTEvent        = PIn.DateT (table.Rows[i]["DateTEvent"].ToString());
				ehrMeasureEvent.EventType         = (OpenDentBusiness.EhrMeasureEventType)PIn.Int(table.Rows[i]["EventType"].ToString());
				ehrMeasureEvent.PatNum            = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				ehrMeasureEvent.MoreInfo          = PIn.String(table.Rows[i]["MoreInfo"].ToString());
				ehrMeasureEvent.CodeValueEvent    = PIn.String(table.Rows[i]["CodeValueEvent"].ToString());
				ehrMeasureEvent.CodeSystemEvent   = PIn.String(table.Rows[i]["CodeSystemEvent"].ToString());
				ehrMeasureEvent.CodeValueResult   = PIn.String(table.Rows[i]["CodeValueResult"].ToString());
				ehrMeasureEvent.CodeSystemResult  = PIn.String(table.Rows[i]["CodeSystemResult"].ToString());
				ehrMeasureEvent.FKey              = PIn.Long  (table.Rows[i]["FKey"].ToString());
				retVal.Add(ehrMeasureEvent);
			}
			return retVal;
		}

		///<summary>Inserts one EhrMeasureEvent into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrMeasureEvent ehrMeasureEvent){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrMeasureEvent.EhrMeasureEventNum=DbHelper.GetNextOracleKey("ehrmeasureevent","EhrMeasureEventNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrMeasureEvent,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrMeasureEvent.EhrMeasureEventNum++;
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
				return Insert(ehrMeasureEvent,false);
			}
		}

		///<summary>Inserts one EhrMeasureEvent into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrMeasureEvent ehrMeasureEvent,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrMeasureEvent.EhrMeasureEventNum=ReplicationServers.GetKey("ehrmeasureevent","EhrMeasureEventNum");
			}
			string command="INSERT INTO ehrmeasureevent (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrMeasureEventNum,";
			}
			command+="DateTEvent,EventType,PatNum,MoreInfo,CodeValueEvent,CodeSystemEvent,CodeValueResult,CodeSystemResult,FKey) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrMeasureEvent.EhrMeasureEventNum)+",";
			}
			command+=
				     POut.DateT (ehrMeasureEvent.DateTEvent)+","
				+    POut.Int   ((int)ehrMeasureEvent.EventType)+","
				+    POut.Long  (ehrMeasureEvent.PatNum)+","
				+"'"+POut.String(ehrMeasureEvent.MoreInfo)+"',"
				+"'"+POut.String(ehrMeasureEvent.CodeValueEvent)+"',"
				+"'"+POut.String(ehrMeasureEvent.CodeSystemEvent)+"',"
				+"'"+POut.String(ehrMeasureEvent.CodeValueResult)+"',"
				+"'"+POut.String(ehrMeasureEvent.CodeSystemResult)+"',"
				+    POut.Long  (ehrMeasureEvent.FKey)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrMeasureEvent.EhrMeasureEventNum=Db.NonQ(command,true);
			}
			return ehrMeasureEvent.EhrMeasureEventNum;
		}

		///<summary>Updates one EhrMeasureEvent in the database.</summary>
		public static void Update(EhrMeasureEvent ehrMeasureEvent){
			string command="UPDATE ehrmeasureevent SET "
				+"DateTEvent        =  "+POut.DateT (ehrMeasureEvent.DateTEvent)+", "
				+"EventType         =  "+POut.Int   ((int)ehrMeasureEvent.EventType)+", "
				+"PatNum            =  "+POut.Long  (ehrMeasureEvent.PatNum)+", "
				+"MoreInfo          = '"+POut.String(ehrMeasureEvent.MoreInfo)+"', "
				+"CodeValueEvent    = '"+POut.String(ehrMeasureEvent.CodeValueEvent)+"', "
				+"CodeSystemEvent   = '"+POut.String(ehrMeasureEvent.CodeSystemEvent)+"', "
				+"CodeValueResult   = '"+POut.String(ehrMeasureEvent.CodeValueResult)+"', "
				+"CodeSystemResult  = '"+POut.String(ehrMeasureEvent.CodeSystemResult)+"', "
				+"FKey              =  "+POut.Long  (ehrMeasureEvent.FKey)+" "
				+"WHERE EhrMeasureEventNum = "+POut.Long(ehrMeasureEvent.EhrMeasureEventNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrMeasureEvent in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrMeasureEvent ehrMeasureEvent,EhrMeasureEvent oldEhrMeasureEvent){
			string command="";
			if(ehrMeasureEvent.DateTEvent != oldEhrMeasureEvent.DateTEvent) {
				if(command!=""){ command+=",";}
				command+="DateTEvent = "+POut.DateT(ehrMeasureEvent.DateTEvent)+"";
			}
			if(ehrMeasureEvent.EventType != oldEhrMeasureEvent.EventType) {
				if(command!=""){ command+=",";}
				command+="EventType = "+POut.Int   ((int)ehrMeasureEvent.EventType)+"";
			}
			if(ehrMeasureEvent.PatNum != oldEhrMeasureEvent.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(ehrMeasureEvent.PatNum)+"";
			}
			if(ehrMeasureEvent.MoreInfo != oldEhrMeasureEvent.MoreInfo) {
				if(command!=""){ command+=",";}
				command+="MoreInfo = '"+POut.String(ehrMeasureEvent.MoreInfo)+"'";
			}
			if(ehrMeasureEvent.CodeValueEvent != oldEhrMeasureEvent.CodeValueEvent) {
				if(command!=""){ command+=",";}
				command+="CodeValueEvent = '"+POut.String(ehrMeasureEvent.CodeValueEvent)+"'";
			}
			if(ehrMeasureEvent.CodeSystemEvent != oldEhrMeasureEvent.CodeSystemEvent) {
				if(command!=""){ command+=",";}
				command+="CodeSystemEvent = '"+POut.String(ehrMeasureEvent.CodeSystemEvent)+"'";
			}
			if(ehrMeasureEvent.CodeValueResult != oldEhrMeasureEvent.CodeValueResult) {
				if(command!=""){ command+=",";}
				command+="CodeValueResult = '"+POut.String(ehrMeasureEvent.CodeValueResult)+"'";
			}
			if(ehrMeasureEvent.CodeSystemResult != oldEhrMeasureEvent.CodeSystemResult) {
				if(command!=""){ command+=",";}
				command+="CodeSystemResult = '"+POut.String(ehrMeasureEvent.CodeSystemResult)+"'";
			}
			if(ehrMeasureEvent.FKey != oldEhrMeasureEvent.FKey) {
				if(command!=""){ command+=",";}
				command+="FKey = "+POut.Long(ehrMeasureEvent.FKey)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrmeasureevent SET "+command
				+" WHERE EhrMeasureEventNum = "+POut.Long(ehrMeasureEvent.EhrMeasureEventNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EhrMeasureEvent from the database.</summary>
		public static void Delete(long ehrMeasureEventNum){
			string command="DELETE FROM ehrmeasureevent "
				+"WHERE EhrMeasureEventNum = "+POut.Long(ehrMeasureEventNum);
			Db.NonQ(command);
		}

	}
}