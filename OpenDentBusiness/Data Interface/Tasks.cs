using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
	///<summary>Not part of cache refresh.</summary>
	public class Tasks {
		///<summary>Only used from UI.</summary>
		public static ArrayList LastOpenList;
		///<summary>Only used from UI.  The index of the last open tab.</summary>
		public static int LastOpenGroup;
		///<summary>Only used from UI.</summary>
		public static DateTime LastOpenDate;

		///<summary>This is needed because of the extra column that is not part of the database.</summary>
		private static List<Task> TableToList(DataTable table) {
			//No need to check RemotingRole; no call to db.
			List<Task> retVal=Crud.TaskCrud.TableToList(table);
			for(int i=0;i<retVal.Count;i++) {
				if(table.Columns.Contains("IsUnread")) {
					retVal[i].IsUnread=PIn.Bool(table.Rows[i]["IsUnread"].ToString());//1 or more will result in true.
				}
				if(table.Columns.Contains("ParentDesc")) {
					retVal[i].ParentDesc=PIn.String(table.Rows[i]["ParentDesc"].ToString());
				}
				if(table.Columns.Contains("LName")
					&& table.Columns.Contains("FName")
					&& table.Columns.Contains("Preferred")
					) 
				{
					string lname=PIn.String(table.Rows[i]["LName"].ToString());
					string fname=PIn.String(table.Rows[i]["FName"].ToString());
					string preferred=PIn.String(table.Rows[i]["Preferred"].ToString());
					retVal[i].PatientName=Patients.GetNameLF(lname,fname,preferred,"");
				}
			}
			return retVal;
		}

		/*
		///<summary>There are NO tasks on the user trunk, so this is not needed.</summary>
		public static List<Task> RefreshUserTrunk(int userNum) {
			string command="SELECT task.* FROM tasksubscription "
				+"LEFT JOIN task ON task.TaskNum=tasksubscription.TaskNum "
				+"WHERE tasksubscription.UserNum="+POut.PInt(userNum)
				+" AND tasksubscription.TaskNum!=0 "
				+"ORDER BY DateTimeEntry";
			return RefreshAndFill(command);
		}*/

		///<summary>Gets one Task from database.</summary>
		public static Task GetOne(long TaskNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<Task>(MethodBase.GetCurrentMethod(),TaskNum);
			}
			string command="SELECT * FROM task WHERE TaskNum = "+POut.Long(TaskNum);
			return Crud.TaskCrud.SelectOne(command);
		}

		///<summary>Gets all tasks for the main trunk.</summary>
		public static List<Task> RefreshMainTrunk(bool showDone,DateTime startDate,long currentUserNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),showDone,startDate,currentUserNum);
			}
			//startDate only applies if showing Done tasks.
			string command="SELECT task.*,"
					+"(SELECT COUNT(*) FROM taskunread WHERE task.TaskNum=taskunread.TaskNum AND taskunread.UserNum="+POut.Long(currentUserNum)+") IsUnread, "
					+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE TaskListNum=0 "
				+"AND DateTask < "+POut.Date(new DateTime(1880,01,01))+" "
				+"AND IsRepeating=0";
			if(showDone){
				command+=" AND (TaskStatus !="+POut.Long((int)TaskStatusEnum.Done)
					+" OR DateTimeFinished > "+POut.Date(startDate)+")";//of if done, then restrict date
			}
			else{
				command+=" AND TaskStatus !="+POut.Long((int)TaskStatusEnum.Done);
			}
			command+=" ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>Gets all 'new' tasks for a user.</summary>
		public static List<Task> RefreshUserNew(long userNum){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),userNum);
			}
			string command="";
			if(DataConnection.DBtype==DatabaseType.MySql) {
				command="SELECT task.*,1 AS IsUnread,";//we fill the IsUnread column with 1's because we already know that they are all unread
			}
			else {//Oracle
				//Since this statement has a GROUP BY clause and the table has a clob column, we have to do some Oracle magic with the descript column.
				command="SELECT task.TaskNum,task.TaskListNum,task.DateTask,task.KeyNum,(SELECT Descript FROM task taskdesc WHERE task.TaskNum=taskdesc.TaskNum) Descript,task.TaskStatus"
					+",task.IsRepeating,task.DateType,task.FromNum,task.ObjectType,task.DateTimeEntry,task.UserNum,task.DateTimeFinished"
					+",1 AS IsUnread,";//we fill the IsUnread column with 1's because we already know that they are all unread
			}
			command+="tasklist.Descript ParentDesc, "	/*Renamed to keep same column name as old query*/
					+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"INNER JOIN taskunread ON task.TaskNum=taskunread.TaskNum "
					+"AND taskunread.UserNum = "+POut.Long(userNum)+" "
				+"LEFT JOIN tasklist ON task.TaskListNum=tasklist.TaskListNum "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum "
					+"AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" ";
			if(DataConnection.DBtype==DatabaseType.MySql) {
				command+="GROUP BY task.TaskNum ";//in case there are duplicate unreads
			}
			else {//Oracle
				//in case there are duplicate unreads
				command+="GROUP BY task.TaskNum,task.TaskListNum,task.DateTask,task.KeyNum,task.TaskStatus,task.IsRepeating"
					+",task.DateType,task.FromNum,task.ObjectType,task.DateTimeEntry,task.UserNum,task.DateTimeFinished "
					+",tasklist.Descript, patient.LName, patient.FName, patient.Preferred ";
			}
			command+="ORDER BY task.DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>Gets all 'open ticket' tasks for a user.  An open ticket is a task that was created by this user, is attached to a patient, and is not done.</summary>
		public static List<Task> RefreshOpenTickets(long userNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),userNum);
			}
			string command="SELECT task.*, "
				+"(SELECT COUNT(*) FROM taskunread WHERE task.TaskNum=taskunread.TaskNum "
				+"AND taskunread.UserNum="+POut.Long(userNum)+") AS IsUnread, "
				+"tasklist.Descript AS ParentDesc, "
				+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"LEFT JOIN tasklist ON task.TaskListNum=tasklist.TaskListNum "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum "
					+"AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE NOT EXISTS( "
					+"SELECT * FROM taskancestor "
					+"LEFT JOIN tasklist ON tasklist.TaskListNum=taskancestor.TaskListNum "
					+"WHERE taskancestor.TaskNum=task.TaskNum "
					+"AND tasklist.DateType!=0) "//if any ancestor is a dated list, then we don't want that task
				+"AND task.DateType=0 "//this only handles tasks directly in the dated trunks
				+"AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"AND task.IsRepeating=0 "
				+"AND task.UserNum="+POut.Long(userNum)+" "
				+"AND TaskStatus!="+POut.Int((int)TaskStatusEnum.Done)+" "
				+"ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>Gets all tasks for the repeating trunk.  Always includes "done".</summary>
		public static List<Task> RefreshRepeatingTrunk() {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod());
			}
			string command="SELECT task.*, "
				+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE TaskListNum=0 "
				+"AND DateTask < "+POut.Date(new DateTime(1880,01,01))+" "
				+"AND IsRepeating=1 "
				+"ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>0 is not allowed, because that would be a trunk.  Also, if this is in someone's inbox, then pass in the userNum whose inbox it is in.  If not in an inbox, pass in 0.</summary>
		public static List<Task> RefreshChildren(long listNum,bool showDone,DateTime startDate,long currentUserNum,long userNumInbox) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),listNum,showDone,startDate,currentUserNum,userNumInbox);
			}
			//startDate only applies if showing Done tasks.
			string command=
				"SELECT task.*, "
				+"(SELECT COUNT(*) FROM taskunread WHERE task.TaskNum=taskunread.TaskNum ";//the count turns into a bool
			//if(PrefC.GetBool(PrefName.TasksNewTrackedByUser)) {//we don't bother with this.  Always get IsUnread
			//if a task is someone's inbox,
			if(userNumInbox>0) {
				//then restrict by that user
				command+="AND taskunread.UserNum="+POut.Long(userNumInbox)+") IsUnread, ";
			}
			else {
				//otherwise, restrict by current user
				command+="AND taskunread.UserNum="+POut.Long(currentUserNum)+") IsUnread, ";
			}
			command+="patient.LName,patient.FName,patient.Preferred ";
			command+="FROM task "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE TaskListNum="+POut.Long(listNum);
			if(showDone){
				command+=" AND (TaskStatus !="+POut.Long((int)TaskStatusEnum.Done)
					+" OR DateTimeFinished > "+POut.Date(startDate)+")";//of if done, then restrict date
			}
			else{
				command+=" AND TaskStatus !="+POut.Long((int)TaskStatusEnum.Done);
			}
			command+=" ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			List<Task> taskList=TableToList(table);
			if(listNum==1697 && PrefC.GetBool(PrefName.DockPhonePanelShow)) {
				taskList.Sort(new TaskComparer());
			}
			return taskList;
		}

		///<summary>All repeating items for one date type with no heirarchy.</summary>
		public static List<Task> RefreshRepeating(TaskDateType dateType,long currentUserNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),dateType,currentUserNum);
			}
			string command=
				"SELECT task.*, "
				+"(SELECT COUNT(*) FROM taskunread WHERE task.TaskNum=taskunread.TaskNum "
					+"AND taskunread.UserNum="+POut.Long(currentUserNum)+") IsUnread, "//Not sure if this makes sense here
				+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE IsRepeating=1 "
				+"AND DateType="+POut.Long((int)dateType)+" "
				+"ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>Gets all tasks for one of the 3 dated trunks. startDate only applies if showing Done.</summary>
		public static List<Task> RefreshDatedTrunk(DateTime date,TaskDateType dateType,bool showDone,DateTime startDate,long currentUserNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod(),date,dateType,showDone,startDate,currentUserNum);
			}
			DateTime dateFrom=DateTime.MinValue;
			DateTime dateTo=DateTime.MaxValue;
			if(dateType==TaskDateType.Day) {
				dateFrom=date;
				dateTo=date;
			}
			else if(dateType==TaskDateType.Week) {
				dateFrom=date.AddDays(-(int)date.DayOfWeek);
				dateTo=dateFrom.AddDays(6);
			}
			else if(dateType==TaskDateType.Month) {
				dateFrom=new DateTime(date.Year,date.Month,1);
				dateTo=dateFrom.AddMonths(1).AddDays(-1);
			}
			string command=
				"SELECT task.*, "
				+"(SELECT COUNT(*) FROM taskunread WHERE task.TaskNum=taskunread.TaskNum "
					+"AND taskunread.UserNum="+POut.Long(currentUserNum)+") IsUnread, "//Not sure if this makes sense here
				+"patient.LName,patient.FName,patient.Preferred "
				+"FROM task "
				+"LEFT JOIN patient ON task.KeyNum=patient.PatNum AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"WHERE DateTask >= "+POut.Date(dateFrom)
				+" AND DateTask <= "+POut.Date(dateTo)
				+" AND DateType="+POut.Long((int)dateType);
			if(showDone){
				command+=" AND (TaskStatus !="+POut.Long((int)TaskStatusEnum.Done)
					+" OR DateTimeFinished > "+POut.Date(startDate)+")";//of if done, then restrict date
			}
			else{
				command+=" AND TaskStatus !="+POut.Long((int)TaskStatusEnum.Done);
			}
			command+=" ORDER BY DateTimeEntry";
			DataTable table=Db.GetTable(command);
			return TableToList(table);
		}

		///<summary>The full refresh is only used once when first synching all the tasks for taskAncestors.</summary>
		public static List<Task> RefreshAll(){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Task>>(MethodBase.GetCurrentMethod());
			}
			string command="SELECT * FROM task WHERE TaskListNum != 0";
			return Crud.TaskCrud.SelectMany(command);
		}

		/*
		public static List<Task> RefreshAndFill(DataTable table){
			//No need to check RemotingRole; no call to db.
			List<Task> retVal=new List<Task>();
			Task task;
			for(int i=0;i<table.Rows.Count;i++) {
				task=new Task();
				task.TaskNum        = PIn.Long(table.Rows[i][0].ToString());
				task.TaskListNum    = PIn.Long(table.Rows[i][1].ToString());
				task.DateTask       = PIn.Date(table.Rows[i][2].ToString());
				task.KeyNum         = PIn.Long(table.Rows[i][3].ToString());
				task.Descript       = PIn.String(table.Rows[i][4].ToString());
				task.TaskStatus     = (TaskStatusEnum)PIn.Long(table.Rows[i][5].ToString());
				task.IsRepeating    = PIn.Bool(table.Rows[i][6].ToString());
				task.DateType       = (TaskDateType)PIn.Long(table.Rows[i][7].ToString());
				task.FromNum        = PIn.Long(table.Rows[i][8].ToString());
				task.ObjectType     = (TaskObjectType)PIn.Long(table.Rows[i][9].ToString());
				task.DateTimeEntry  = PIn.DateT(table.Rows[i][10].ToString());
				task.UserNum        = PIn.Long(table.Rows[i][11].ToString());
				task.DateTimeFinished= PIn.DateT(table.Rows[i][12].ToString());
				retVal.Add(task);
			}
			return retVal;
		}*/

		///<summary>Must supply the supposedly unaltered oldTask.  The update will fail if oldTask does not exactly match the database state.  Keeps users from overwriting each other's changes.</summary>
		public static void Update(Task task,Task oldTask){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),task,oldTask);
				return;
			}
			if(task.IsRepeating && task.DateTask.Year>1880) {
				throw new Exception(Lans.g("Tasks","Task cannot be tagged repeating and also have a date."));
			}
			if(task.IsRepeating && task.TaskStatus!=TaskStatusEnum.New) {//and any status but new
				throw new Exception(Lans.g("Tasks","Tasks that are repeating must have a status of New."));
			}
			if(task.IsRepeating && task.TaskListNum!=0 && task.DateType!=TaskDateType.None) {//In repeating, children not allowed to repeat.
				throw new Exception(Lans.g("Tasks","In repeating tasks, only the main parents can have a task status."));
			}
			if(WasTaskAltered(oldTask)){
				throw new Exception(Lans.g("Tasks","Not allowed to save changes because the task has been altered by someone else."));
			}
			if(task.IsNew) {
				TaskEditCreateLog(Lans.g("Tasks","New task added"),task);
				task.IsNew=false;
			}
			else {
				if(task.TaskStatus!=oldTask.TaskStatus) {
					if(task.TaskStatus==TaskStatusEnum.Done) {
						TaskEditCreateLog(Lans.g("Tasks","Task marked done"),task);
					}
					if(task.TaskStatus==TaskStatusEnum.New) {
						TaskEditCreateLog(Lans.g("Tasks","Task marked new"),task);
					}
					//Nothinng for case when Not New and Not Done. Put here in future is wanted
				}
				if(task.Descript!=oldTask.Descript) {
					TaskEditCreateLog(Lans.g("Tasks","Task description edited"),task);
				}
				if(task.UserNum!=oldTask.UserNum) {
					TaskEditCreateLog(Lans.g("Tasks","Changed user from")+" "+Userods.GetName(oldTask.UserNum),task);//+" To "+Userods.GetName(task.UserNum)),task);
				}
				if(task.KeyNum!=oldTask.KeyNum) {
					long newPat=(task.ObjectType==TaskObjectType.Patient?task.KeyNum:Appointments.GetOneApt(task.KeyNum).PatNum);
					long oldPat=(oldTask.ObjectType==TaskObjectType.Patient?oldTask.KeyNum:Appointments.GetOneApt(oldTask.KeyNum).PatNum);
					if(newPat!=oldPat){
						TaskEditCreateLog(Lans.g("tasks","Attached patient changed from")+" "+oldPat.ToString(),task);//+" to "+newPat.ToString()),task);					
					}
				}
				if(task.TaskListNum!=oldTask.TaskListNum) {
					TaskEditCreateLog(Lans.g("tasks","Task moved from "+TaskLists.GetOne(oldTask.TaskListNum).Descript),task);
				}
			}
			Crud.TaskCrud.Update(task);
			if(task.TaskListNum!=oldTask.TaskListNum) {
				TaskAncestors.Synch(task);
			}
		}

		///<summary></summary>
		public static long Insert(Task task) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				task.TaskNum=Meth.GetLong(MethodBase.GetCurrentMethod(),task);
				return task.TaskNum;
			}
			if(task.IsRepeating && task.DateTask.Year>1880) {
				throw new Exception(Lans.g("Tasks","Task cannot be tagged repeating and also have a date."));
			}
			if(task.IsRepeating && task.TaskStatus!=TaskStatusEnum.New) {//and any status but new
				throw new Exception(Lans.g("Tasks","Tasks that are repeating must have a status of New."));
			}
			if(task.IsRepeating && task.TaskListNum!=0 && task.DateType!=TaskDateType.None) {//In repeating, children not allowed to repeat.
				throw new Exception(Lans.g("Tasks","In repeating tasks, only the main parents can have a task status."));
			}
			Crud.TaskCrud.Insert(task);
			TaskAncestors.Synch(task);
			return task.TaskNum;
		}

		///<summary></summary>
		public static bool WasTaskAltered(Task task){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetBool(MethodBase.GetCurrentMethod(),task);
			}
			string command="SELECT * FROM task WHERE TaskNum="+POut.Long(task.TaskNum);
			Task oldtask=Crud.TaskCrud.SelectOne(command);
			if(oldtask==null
				|| oldtask.DateTask!=task.DateTask
				|| oldtask.DateType!=task.DateType
				|| oldtask.Descript!=task.Descript
				|| oldtask.FromNum!=task.FromNum
				|| oldtask.IsRepeating!=task.IsRepeating
				|| oldtask.KeyNum!=task.KeyNum
				|| oldtask.ObjectType!=task.ObjectType
				|| oldtask.TaskListNum!=task.TaskListNum
				|| oldtask.TaskStatus!=task.TaskStatus
				|| oldtask.UserNum!=task.UserNum
				|| oldtask.DateTimeEntry!=task.DateTimeEntry
				|| oldtask.DateTimeFinished!=task.DateTimeFinished)
			{
				return true;
			}
			return false;
		}

		///<summary>Deleting a task never causes a problem, so no dependencies are checked.</summary>
		public static void Delete(long taskNum){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),taskNum);
				return;
			}
			string command= "DELETE from task WHERE TaskNum = "+POut.Long(taskNum);
 			Db.NonQ(command);
			command="DELETE from taskancestor WHERE TaskNum = "+POut.Long(taskNum);
			Db.NonQ(command);
			command="DELETE from tasknote WHERE TaskNum = "+POut.Long(taskNum);
			Db.NonQ(command);
		}

		///<summary>Gets a count of unread tasks to notify user when first logging in.</summary>
		public static int UserTasksCount(long userNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetInt(MethodBase.GetCurrentMethod(),userNum);
			}
			string command="SELECT task.TaskNum FROM task,taskunread "
				+"WHERE task.TaskNum=taskunread.TaskNum "
				+"AND taskunread.UserNum = "+POut.Long(userNum)+" "
				+"GROUP BY task.TaskNum";//this handles duplicate taskunread entries.
			/*
			string command="SELECT COUNT(*) FROM taskancestor,task,tasklist,tasksubscription "
				+"WHERE taskancestor.TaskListNum=tasklist.TaskListNum "
				+"AND task.TaskNum=taskancestor.TaskNum "
				+"AND tasksubscription.TaskListNum=tasklist.TaskListNum "
				+"AND tasksubscription.UserNum="+POut.Long(userNum)
				+" AND task.TaskStatus="+POut.Long((int)TaskStatusEnum.New);*/
			DataTable table=Db.GetTable(command);
			return table.Rows.Count;
			//return PIn.Int(Db.GetScalar(command));//GetCount failed if no new tasks.
		}

		/*
		///<summary>Appends a carriage return as well as the text to any task.  If a taskListNum is specified, then it also changes the taskList.</summary>
		public static void Append(long taskNum,string text) {
			//No need to check RemotingRole; no call to db.
			Append(taskNum,text,-1);
		}

		///<summary>Appends a carriage return as well as the text to any task.  If a taskListNum is specified, then it also changes the taskList.    Must call TaskAncestors.Synch after this.</summary>
		public static void Append(long taskNum,string text,long taskListNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),taskNum,text,taskListNum);
				return;
			}
			string command;
			if(taskListNum==-1) {
				command="UPDATE task SET Descript=CONCAT(Descript,'"+POut.String("\r\n"+text)+"') WHERE TaskNum="+POut.Long(taskNum);
			}
			else {
				command="UPDATE task SET Descript=CONCAT(Descript,'"+POut.String("\r\n"+text)+"'), "
					+"TaskListNum="+POut.Long(taskListNum)+" "
					+"WHERE TaskNum="+POut.Long(taskNum);
			}
			Db.NonQ(command);
		}*/

		public static int GetCountOpenTickets(long userNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetInt(MethodBase.GetCurrentMethod(),userNum);
			}
			string command="SELECT COUNT(*) "
				+"FROM task "
				+"WHERE NOT EXISTS(SELECT * FROM taskancestor,tasklist "
				+"WHERE taskancestor.TaskNum=task.TaskNum "
				+"AND tasklist.TaskListNum=taskancestor.TaskListNum "
				+"AND tasklist.DateType!=0) "//if any ancestor is a dated list, then we don't want that task
				+"AND task.DateType=0 "//this only handles tasks directly in the dated trunks
				+"AND task.ObjectType="+POut.Int((int)TaskObjectType.Patient)+" "
				+"AND task.IsRepeating=0 "
				+"AND task.UserNum="+POut.Long(userNum)+" "
				+"AND TaskStatus != "+POut.Int((int)TaskStatusEnum.Done);
			return PIn.Int(Db.GetCount(command));
		}

		public static void TaskEditCreateLog(string logText,Task task) {
			long patNum=0;//Task type of none defaults to 0.
			if(task.ObjectType==TaskObjectType.Patient) {//Task type of patient we can use the task.KeyNum for patNum
				patNum=task.KeyNum;
				//logText+=". Attached patient: "+task.PatientName;
			}
			else if(task.ObjectType==TaskObjectType.Appointment) {//Task type of appointment we have to look up the patient from the apt.
				Appointment AptCur=Appointments.GetOneApt(task.KeyNum);
				patNum=AptCur.PatNum;
				//logText+=". Attached patient: "+task.PatientName+" from an appointment";
			}
			SecurityLogs.MakeLogEntry(Permissions.TaskEdit,patNum,logText,task.TaskNum);
		}	
	}

	///<summary>Takes two tasks and compares which needs to be higher or lower based first on their coloration, then on their date.</summary>
	public class TaskComparer:IComparer<Task> {
		public int Compare(Task x,Task y) {
			int xTaskColor=FindTaskColor(x);
			int yTaskColor=FindTaskColor(y);
			if(xTaskColor==yTaskColor) {//Case 1: Tasks have same colors, sort by date.
				return CompareTimes(x,y);
			}
			else {//Case 2: Tasks have different colors, sort by priority.
				if(xTaskColor>yTaskColor) {
					return -1;
				}
				else {
					return 1;
				}
			}
		}

		///<summary>Figures out what the current color of the task passed is and returns an int based on color priority.  0 = white, 1 = blue, 2 = red</summary>
		public int FindTaskColor(Task task) {
			int taskColor=0;//Default white
			List<TaskNote> taskNoteList=new List<TaskNote>();
			taskNoteList=TaskNotes.GetForTask(task.TaskNum);
			if(task.Descript.Contains("CUSTOMER")
				|| task.Descript.Contains("DOWN")
				|| task.Descript.Contains("URGENT")
				|| task.Descript.Contains("CONFERENCE")
				|| task.Descript.Contains("!!"))
			{
				taskColor=2;//red
			}
			else if(taskNoteList.Count==0 || task.Descript.Contains("@@")) 
			{
				taskColor=1;//blue
			}
			return taskColor;
		}

		public int CompareTimes(Task x,Task y) {
			if(x.DateTimeEntry<y.DateTimeEntry) {
				return -1;
			}
			else if(x.DateTimeEntry>y.DateTimeEntry) {
				return 1;
			}
			else {
				return 0;
			}
		}
	}
}
