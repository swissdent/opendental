//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TaskHistCrud {
		///<summary>Gets one TaskHist object from the database using the primary key.  Returns null if not found.</summary>
		public static TaskHist SelectOne(long taskHistNum){
			string command="SELECT * FROM taskhist "
				+"WHERE TaskHistNum = "+POut.Long(taskHistNum);
			List<TaskHist> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TaskHist object from the database using a query.</summary>
		public static TaskHist SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TaskHist> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TaskHist objects from the database using a query.</summary>
		public static List<TaskHist> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TaskHist> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TaskHist> TableToList(DataTable table){
			List<TaskHist> retVal=new List<TaskHist>();
			TaskHist taskHist;
			foreach(DataRow row in table.Rows) {
				taskHist=new TaskHist();
				taskHist.TaskHistNum     = PIn.Long  (row["TaskHistNum"].ToString());
				taskHist.UserNumHist     = PIn.Long  (row["UserNumHist"].ToString());
				taskHist.DateTStamp      = PIn.DateT (row["DateTStamp"].ToString());
				taskHist.IsNoteChange    = PIn.Bool  (row["IsNoteChange"].ToString());
				taskHist.TaskNum         = PIn.Long  (row["TaskNum"].ToString());
				taskHist.TaskListNum     = PIn.Long  (row["TaskListNum"].ToString());
				taskHist.DateTask        = PIn.Date  (row["DateTask"].ToString());
				taskHist.KeyNum          = PIn.Long  (row["KeyNum"].ToString());
				taskHist.Descript        = PIn.String(row["Descript"].ToString());
				taskHist.TaskStatus      = (OpenDentBusiness.TaskStatusEnum)PIn.Int(row["TaskStatus"].ToString());
				taskHist.IsRepeating     = PIn.Bool  (row["IsRepeating"].ToString());
				taskHist.DateType        = (OpenDentBusiness.TaskDateType)PIn.Int(row["DateType"].ToString());
				taskHist.FromNum         = PIn.Long  (row["FromNum"].ToString());
				taskHist.ObjectType      = (OpenDentBusiness.TaskObjectType)PIn.Int(row["ObjectType"].ToString());
				taskHist.DateTimeEntry   = PIn.DateT (row["DateTimeEntry"].ToString());
				taskHist.UserNum         = PIn.Long  (row["UserNum"].ToString());
				taskHist.DateTimeFinished= PIn.DateT (row["DateTimeFinished"].ToString());
				taskHist.PriorityDefNum  = PIn.Long  (row["PriorityDefNum"].ToString());
				retVal.Add(taskHist);
			}
			return retVal;
		}

		///<summary>Converts a list of TaskHist into a DataTable.</summary>
		public static DataTable ListToTable(List<TaskHist> listTaskHists,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TaskHist";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TaskHistNum");
			table.Columns.Add("UserNumHist");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("IsNoteChange");
			table.Columns.Add("TaskNum");
			table.Columns.Add("TaskListNum");
			table.Columns.Add("DateTask");
			table.Columns.Add("KeyNum");
			table.Columns.Add("Descript");
			table.Columns.Add("TaskStatus");
			table.Columns.Add("IsRepeating");
			table.Columns.Add("DateType");
			table.Columns.Add("FromNum");
			table.Columns.Add("ObjectType");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("UserNum");
			table.Columns.Add("DateTimeFinished");
			table.Columns.Add("PriorityDefNum");
			foreach(TaskHist taskHist in listTaskHists) {
				table.Rows.Add(new object[] {
					POut.Long  (taskHist.TaskHistNum),
					POut.Long  (taskHist.UserNumHist),
					POut.DateT (taskHist.DateTStamp),
					POut.Bool  (taskHist.IsNoteChange),
					POut.Long  (taskHist.TaskNum),
					POut.Long  (taskHist.TaskListNum),
					POut.Date  (taskHist.DateTask),
					POut.Long  (taskHist.KeyNum),
					POut.String(taskHist.Descript),
					POut.Int   ((int)taskHist.TaskStatus),
					POut.Bool  (taskHist.IsRepeating),
					POut.Int   ((int)taskHist.DateType),
					POut.Long  (taskHist.FromNum),
					POut.Int   ((int)taskHist.ObjectType),
					POut.DateT (taskHist.DateTimeEntry),
					POut.Long  (taskHist.UserNum),
					POut.DateT (taskHist.DateTimeFinished),
					POut.Long  (taskHist.PriorityDefNum),
				});
			}
			return table;
		}

		///<summary>Inserts one TaskHist into the database.  Returns the new priKey.</summary>
		public static long Insert(TaskHist taskHist){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				taskHist.TaskHistNum=DbHelper.GetNextOracleKey("taskhist","TaskHistNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(taskHist,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							taskHist.TaskHistNum++;
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
				return Insert(taskHist,false);
			}
		}

		///<summary>Inserts one TaskHist into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TaskHist taskHist,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				taskHist.TaskHistNum=ReplicationServers.GetKey("taskhist","TaskHistNum");
			}
			string command="INSERT INTO taskhist (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TaskHistNum,";
			}
			command+="UserNumHist,DateTStamp,IsNoteChange,TaskNum,TaskListNum,DateTask,KeyNum,Descript,TaskStatus,IsRepeating,DateType,FromNum,ObjectType,DateTimeEntry,UserNum,DateTimeFinished,PriorityDefNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(taskHist.TaskHistNum)+",";
			}
			command+=
				     POut.Long  (taskHist.UserNumHist)+","
				+    DbHelper.Now()+","
				+    POut.Bool  (taskHist.IsNoteChange)+","
				+    POut.Long  (taskHist.TaskNum)+","
				+    POut.Long  (taskHist.TaskListNum)+","
				+    POut.Date  (taskHist.DateTask)+","
				+    POut.Long  (taskHist.KeyNum)+","
				+    DbHelper.ParamChar+"paramDescript,"
				+    POut.Int   ((int)taskHist.TaskStatus)+","
				+    POut.Bool  (taskHist.IsRepeating)+","
				+    POut.Int   ((int)taskHist.DateType)+","
				+    POut.Long  (taskHist.FromNum)+","
				+    POut.Int   ((int)taskHist.ObjectType)+","
				+    POut.DateT (taskHist.DateTimeEntry)+","
				+    POut.Long  (taskHist.UserNum)+","
				+    POut.DateT (taskHist.DateTimeFinished)+","
				+    POut.Long  (taskHist.PriorityDefNum)+")";
			if(taskHist.Descript==null) {
				taskHist.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,taskHist.Descript);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDescript);
			}
			else {
				taskHist.TaskHistNum=Db.NonQ(command,true,paramDescript);
			}
			return taskHist.TaskHistNum;
		}

		///<summary>Inserts one TaskHist into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskHist taskHist){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(taskHist,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					taskHist.TaskHistNum=DbHelper.GetNextOracleKey("taskhist","TaskHistNum"); //Cacheless method
				}
				return InsertNoCache(taskHist,true);
			}
		}

		///<summary>Inserts one TaskHist into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskHist taskHist,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO taskhist (";
			if(!useExistingPK && isRandomKeys) {
				taskHist.TaskHistNum=ReplicationServers.GetKeyNoCache("taskhist","TaskHistNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="TaskHistNum,";
			}
			command+="UserNumHist,DateTStamp,IsNoteChange,TaskNum,TaskListNum,DateTask,KeyNum,Descript,TaskStatus,IsRepeating,DateType,FromNum,ObjectType,DateTimeEntry,UserNum,DateTimeFinished,PriorityDefNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(taskHist.TaskHistNum)+",";
			}
			command+=
				     POut.Long  (taskHist.UserNumHist)+","
				+    DbHelper.Now()+","
				+    POut.Bool  (taskHist.IsNoteChange)+","
				+    POut.Long  (taskHist.TaskNum)+","
				+    POut.Long  (taskHist.TaskListNum)+","
				+    POut.Date  (taskHist.DateTask)+","
				+    POut.Long  (taskHist.KeyNum)+","
				+    DbHelper.ParamChar+"paramDescript,"
				+    POut.Int   ((int)taskHist.TaskStatus)+","
				+    POut.Bool  (taskHist.IsRepeating)+","
				+    POut.Int   ((int)taskHist.DateType)+","
				+    POut.Long  (taskHist.FromNum)+","
				+    POut.Int   ((int)taskHist.ObjectType)+","
				+    POut.DateT (taskHist.DateTimeEntry)+","
				+    POut.Long  (taskHist.UserNum)+","
				+    POut.DateT (taskHist.DateTimeFinished)+","
				+    POut.Long  (taskHist.PriorityDefNum)+")";
			if(taskHist.Descript==null) {
				taskHist.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,taskHist.Descript);
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramDescript);
			}
			else {
				taskHist.TaskHistNum=Db.NonQ(command,true,paramDescript);
			}
			return taskHist.TaskHistNum;
		}

		///<summary>Updates one TaskHist in the database.</summary>
		public static void Update(TaskHist taskHist){
			string command="UPDATE taskhist SET "
				+"UserNumHist     =  "+POut.Long  (taskHist.UserNumHist)+", "
				//DateTStamp not allowed to change
				+"IsNoteChange    =  "+POut.Bool  (taskHist.IsNoteChange)+", "
				+"TaskNum         =  "+POut.Long  (taskHist.TaskNum)+", "
				+"TaskListNum     =  "+POut.Long  (taskHist.TaskListNum)+", "
				+"DateTask        =  "+POut.Date  (taskHist.DateTask)+", "
				+"KeyNum          =  "+POut.Long  (taskHist.KeyNum)+", "
				+"Descript        =  "+DbHelper.ParamChar+"paramDescript, "
				+"TaskStatus      =  "+POut.Int   ((int)taskHist.TaskStatus)+", "
				+"IsRepeating     =  "+POut.Bool  (taskHist.IsRepeating)+", "
				+"DateType        =  "+POut.Int   ((int)taskHist.DateType)+", "
				+"FromNum         =  "+POut.Long  (taskHist.FromNum)+", "
				+"ObjectType      =  "+POut.Int   ((int)taskHist.ObjectType)+", "
				+"DateTimeEntry   =  "+POut.DateT (taskHist.DateTimeEntry)+", "
				+"UserNum         =  "+POut.Long  (taskHist.UserNum)+", "
				+"DateTimeFinished=  "+POut.DateT (taskHist.DateTimeFinished)+", "
				+"PriorityDefNum  =  "+POut.Long  (taskHist.PriorityDefNum)+" "
				+"WHERE TaskHistNum = "+POut.Long(taskHist.TaskHistNum);
			if(taskHist.Descript==null) {
				taskHist.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,taskHist.Descript);
			Db.NonQ(command,paramDescript);
		}

		///<summary>Updates one TaskHist in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TaskHist taskHist,TaskHist oldTaskHist){
			string command="";
			if(taskHist.UserNumHist != oldTaskHist.UserNumHist) {
				if(command!=""){ command+=",";}
				command+="UserNumHist = "+POut.Long(taskHist.UserNumHist)+"";
			}
			//DateTStamp not allowed to change
			if(taskHist.IsNoteChange != oldTaskHist.IsNoteChange) {
				if(command!=""){ command+=",";}
				command+="IsNoteChange = "+POut.Bool(taskHist.IsNoteChange)+"";
			}
			if(taskHist.TaskNum != oldTaskHist.TaskNum) {
				if(command!=""){ command+=",";}
				command+="TaskNum = "+POut.Long(taskHist.TaskNum)+"";
			}
			if(taskHist.TaskListNum != oldTaskHist.TaskListNum) {
				if(command!=""){ command+=",";}
				command+="TaskListNum = "+POut.Long(taskHist.TaskListNum)+"";
			}
			if(taskHist.DateTask.Date != oldTaskHist.DateTask.Date) {
				if(command!=""){ command+=",";}
				command+="DateTask = "+POut.Date(taskHist.DateTask)+"";
			}
			if(taskHist.KeyNum != oldTaskHist.KeyNum) {
				if(command!=""){ command+=",";}
				command+="KeyNum = "+POut.Long(taskHist.KeyNum)+"";
			}
			if(taskHist.Descript != oldTaskHist.Descript) {
				if(command!=""){ command+=",";}
				command+="Descript = "+DbHelper.ParamChar+"paramDescript";
			}
			if(taskHist.TaskStatus != oldTaskHist.TaskStatus) {
				if(command!=""){ command+=",";}
				command+="TaskStatus = "+POut.Int   ((int)taskHist.TaskStatus)+"";
			}
			if(taskHist.IsRepeating != oldTaskHist.IsRepeating) {
				if(command!=""){ command+=",";}
				command+="IsRepeating = "+POut.Bool(taskHist.IsRepeating)+"";
			}
			if(taskHist.DateType != oldTaskHist.DateType) {
				if(command!=""){ command+=",";}
				command+="DateType = "+POut.Int   ((int)taskHist.DateType)+"";
			}
			if(taskHist.FromNum != oldTaskHist.FromNum) {
				if(command!=""){ command+=",";}
				command+="FromNum = "+POut.Long(taskHist.FromNum)+"";
			}
			if(taskHist.ObjectType != oldTaskHist.ObjectType) {
				if(command!=""){ command+=",";}
				command+="ObjectType = "+POut.Int   ((int)taskHist.ObjectType)+"";
			}
			if(taskHist.DateTimeEntry != oldTaskHist.DateTimeEntry) {
				if(command!=""){ command+=",";}
				command+="DateTimeEntry = "+POut.DateT(taskHist.DateTimeEntry)+"";
			}
			if(taskHist.UserNum != oldTaskHist.UserNum) {
				if(command!=""){ command+=",";}
				command+="UserNum = "+POut.Long(taskHist.UserNum)+"";
			}
			if(taskHist.DateTimeFinished != oldTaskHist.DateTimeFinished) {
				if(command!=""){ command+=",";}
				command+="DateTimeFinished = "+POut.DateT(taskHist.DateTimeFinished)+"";
			}
			if(taskHist.PriorityDefNum != oldTaskHist.PriorityDefNum) {
				if(command!=""){ command+=",";}
				command+="PriorityDefNum = "+POut.Long(taskHist.PriorityDefNum)+"";
			}
			if(command==""){
				return false;
			}
			if(taskHist.Descript==null) {
				taskHist.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,taskHist.Descript);
			command="UPDATE taskhist SET "+command
				+" WHERE TaskHistNum = "+POut.Long(taskHist.TaskHistNum);
			Db.NonQ(command,paramDescript);
			return true;
		}

		///<summary>Returns true if Update(TaskHist,TaskHist) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TaskHist taskHist,TaskHist oldTaskHist) {
			if(taskHist.UserNumHist != oldTaskHist.UserNumHist) {
				return true;
			}
			//DateTStamp not allowed to change
			if(taskHist.IsNoteChange != oldTaskHist.IsNoteChange) {
				return true;
			}
			if(taskHist.TaskNum != oldTaskHist.TaskNum) {
				return true;
			}
			if(taskHist.TaskListNum != oldTaskHist.TaskListNum) {
				return true;
			}
			if(taskHist.DateTask.Date != oldTaskHist.DateTask.Date) {
				return true;
			}
			if(taskHist.KeyNum != oldTaskHist.KeyNum) {
				return true;
			}
			if(taskHist.Descript != oldTaskHist.Descript) {
				return true;
			}
			if(taskHist.TaskStatus != oldTaskHist.TaskStatus) {
				return true;
			}
			if(taskHist.IsRepeating != oldTaskHist.IsRepeating) {
				return true;
			}
			if(taskHist.DateType != oldTaskHist.DateType) {
				return true;
			}
			if(taskHist.FromNum != oldTaskHist.FromNum) {
				return true;
			}
			if(taskHist.ObjectType != oldTaskHist.ObjectType) {
				return true;
			}
			if(taskHist.DateTimeEntry != oldTaskHist.DateTimeEntry) {
				return true;
			}
			if(taskHist.UserNum != oldTaskHist.UserNum) {
				return true;
			}
			if(taskHist.DateTimeFinished != oldTaskHist.DateTimeFinished) {
				return true;
			}
			if(taskHist.PriorityDefNum != oldTaskHist.PriorityDefNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TaskHist from the database.</summary>
		public static void Delete(long taskHistNum){
			string command="DELETE FROM taskhist "
				+"WHERE TaskHistNum = "+POut.Long(taskHistNum);
			Db.NonQ(command);
		}

	}
}