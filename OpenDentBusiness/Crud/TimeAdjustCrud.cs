//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class TimeAdjustCrud {
		///<summary>Gets one TimeAdjust object from the database using the primary key.  Returns null if not found.</summary>
		internal static TimeAdjust SelectOne(long timeAdjustNum){
			string command="SELECT * FROM timeadjust "
				+"WHERE TimeAdjustNum = "+POut.Long(timeAdjustNum)+" LIMIT 1";
			List<TimeAdjust> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TimeAdjust object from the database using a query.</summary>
		internal static TimeAdjust SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeAdjust> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TimeAdjust objects from the database using a query.</summary>
		internal static List<TimeAdjust> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeAdjust> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<TimeAdjust> TableToList(DataTable table){
			List<TimeAdjust> retVal=new List<TimeAdjust>();
			TimeAdjust timeAdjust;
			for(int i=0;i<table.Rows.Count;i++) {
				timeAdjust=new TimeAdjust();
				timeAdjust.TimeAdjustNum= PIn.Long  (table.Rows[i]["TimeAdjustNum"].ToString());
				timeAdjust.EmployeeNum  = PIn.Long  (table.Rows[i]["EmployeeNum"].ToString());
				timeAdjust.TimeEntry    = PIn.DateT (table.Rows[i]["TimeEntry"].ToString());
				timeAdjust.RegHours     = PIn.TimeSpan(table.Rows[i]["RegHours"].ToString());
				timeAdjust.OTimeHours   = PIn.TimeSpan(table.Rows[i]["OTimeHours"].ToString());
				timeAdjust.Note         = PIn.String(table.Rows[i]["Note"].ToString());
				timeAdjust.IsAuto       = PIn.Bool  (table.Rows[i]["IsAuto"].ToString());
				retVal.Add(timeAdjust);
			}
			return retVal;
		}

		///<summary>Inserts one TimeAdjust into the database.  Returns the new priKey.</summary>
		internal static long Insert(TimeAdjust timeAdjust){
			return Insert(timeAdjust,false);
		}

		///<summary>Inserts one TimeAdjust into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(TimeAdjust timeAdjust,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				timeAdjust.TimeAdjustNum=ReplicationServers.GetKey("timeadjust","TimeAdjustNum");
			}
			string command="INSERT INTO timeadjust (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TimeAdjustNum,";
			}
			command+="EmployeeNum,TimeEntry,RegHours,OTimeHours,Note,IsAuto) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(timeAdjust.TimeAdjustNum)+",";
			}
			command+=
				     POut.Long  (timeAdjust.EmployeeNum)+","
				+    POut.DateT (timeAdjust.TimeEntry)+","
				+"'"+POut.TSpan (timeAdjust.RegHours)+"',"
				+"'"+POut.TSpan (timeAdjust.OTimeHours)+"',"
				+"'"+POut.String(timeAdjust.Note)+"',"
				+    POut.Bool  (timeAdjust.IsAuto)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				timeAdjust.TimeAdjustNum=Db.NonQ(command,true);
			}
			return timeAdjust.TimeAdjustNum;
		}

		///<summary>Updates one TimeAdjust in the database.</summary>
		internal static void Update(TimeAdjust timeAdjust){
			string command="UPDATE timeadjust SET "
				+"EmployeeNum  =  "+POut.Long  (timeAdjust.EmployeeNum)+", "
				+"TimeEntry    =  "+POut.DateT (timeAdjust.TimeEntry)+", "
				+"RegHours     = '"+POut.TSpan (timeAdjust.RegHours)+"', "
				+"OTimeHours   = '"+POut.TSpan (timeAdjust.OTimeHours)+"', "
				+"Note         = '"+POut.String(timeAdjust.Note)+"', "
				+"IsAuto       =  "+POut.Bool  (timeAdjust.IsAuto)+" "
				+"WHERE TimeAdjustNum = "+POut.Long(timeAdjust.TimeAdjustNum)+" LIMIT 1";
			Db.NonQ(command);
		}

		///<summary>Updates one TimeAdjust in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(TimeAdjust timeAdjust,TimeAdjust oldTimeAdjust){
			string command="";
			if(timeAdjust.EmployeeNum != oldTimeAdjust.EmployeeNum) {
				if(command!=""){ command+=",";}
				command+="EmployeeNum = "+POut.Long(timeAdjust.EmployeeNum)+"";
			}
			if(timeAdjust.TimeEntry != oldTimeAdjust.TimeEntry) {
				if(command!=""){ command+=",";}
				command+="TimeEntry = "+POut.DateT(timeAdjust.TimeEntry)+"";
			}
			if(timeAdjust.RegHours != oldTimeAdjust.RegHours) {
				if(command!=""){ command+=",";}
				command+="RegHours = '"+POut.TSpan (timeAdjust.RegHours)+"'";
			}
			if(timeAdjust.OTimeHours != oldTimeAdjust.OTimeHours) {
				if(command!=""){ command+=",";}
				command+="OTimeHours = '"+POut.TSpan (timeAdjust.OTimeHours)+"'";
			}
			if(timeAdjust.Note != oldTimeAdjust.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(timeAdjust.Note)+"'";
			}
			if(timeAdjust.IsAuto != oldTimeAdjust.IsAuto) {
				if(command!=""){ command+=",";}
				command+="IsAuto = "+POut.Bool(timeAdjust.IsAuto)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE timeadjust SET "+command
				+" WHERE TimeAdjustNum = "+POut.Long(timeAdjust.TimeAdjustNum)+" LIMIT 1";
			Db.NonQ(command);
		}

		///<summary>Deletes one TimeAdjust from the database.</summary>
		internal static void Delete(long timeAdjustNum){
			string command="DELETE FROM timeadjust "
				+"WHERE TimeAdjustNum = "+POut.Long(timeAdjustNum)+" LIMIT 1";
			Db.NonQ(command);
		}

	}
}