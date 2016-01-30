//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SignalodCrud {
		///<summary>Gets one Signalod object from the database using the primary key.  Returns null if not found.</summary>
		public static Signalod SelectOne(long signalNum){
			string command="SELECT * FROM signalod "
				+"WHERE SignalNum = "+POut.Long(signalNum);
			List<Signalod> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Signalod object from the database using a query.</summary>
		public static Signalod SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Signalod> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Signalod objects from the database using a query.</summary>
		public static List<Signalod> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Signalod> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Signalod> TableToList(DataTable table){
			List<Signalod> retVal=new List<Signalod>();
			Signalod signalod;
			foreach(DataRow row in table.Rows) {
				signalod=new Signalod();
				signalod.SignalNum  = PIn.Long  (row["SignalNum"].ToString());
				signalod.FromUser   = PIn.String(row["FromUser"].ToString());
				signalod.ITypes     = PIn.String(row["ITypes"].ToString());
				signalod.DateViewing= PIn.Date  (row["DateViewing"].ToString());
				signalod.SigType    = (OpenDentBusiness.SignalType)PIn.Int(row["SigType"].ToString());
				signalod.SigText    = PIn.String(row["SigText"].ToString());
				signalod.SigDateTime= PIn.DateT (row["SigDateTime"].ToString());
				signalod.ToUser     = PIn.String(row["ToUser"].ToString());
				signalod.AckTime    = PIn.DateT (row["AckTime"].ToString());
				signalod.TaskNum    = PIn.Long  (row["TaskNum"].ToString());
				signalod.FKey       = PIn.Long  (row["FKey"].ToString());
				string fKeyType=row["FKeyType"].ToString();
				if(fKeyType==""){
					signalod.FKeyType =(KeyType)0;
				}
				else try{
					signalod.FKeyType =(KeyType)Enum.Parse(typeof(KeyType),fKeyType);
				}
				catch{
					signalod.FKeyType =(KeyType)0;
				}
				retVal.Add(signalod);
			}
			return retVal;
		}

		///<summary>Converts a list of Signalod into a DataTable.</summary>
		public static DataTable ListToTable(List<Signalod> listSignalods,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Signalod";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SignalNum");
			table.Columns.Add("FromUser");
			table.Columns.Add("ITypes");
			table.Columns.Add("DateViewing");
			table.Columns.Add("SigType");
			table.Columns.Add("SigText");
			table.Columns.Add("SigDateTime");
			table.Columns.Add("ToUser");
			table.Columns.Add("AckTime");
			table.Columns.Add("TaskNum");
			table.Columns.Add("FKey");
			table.Columns.Add("FKeyType");
			foreach(Signalod signalod in listSignalods) {
				table.Rows.Add(new object[] {
					POut.Long  (signalod.SignalNum),
					POut.String(signalod.FromUser),
					POut.String(signalod.ITypes),
					POut.Date  (signalod.DateViewing),
					POut.Int   ((int)signalod.SigType),
					POut.String(signalod.SigText),
					POut.DateT (signalod.SigDateTime),
					POut.String(signalod.ToUser),
					POut.DateT (signalod.AckTime),
					POut.Long  (signalod.TaskNum),
					POut.Long  (signalod.FKey),
					POut.Int   ((int)signalod.FKeyType),
				});
			}
			return table;
		}

		///<summary>Inserts one Signalod into the database.  Returns the new priKey.</summary>
		public static long Insert(Signalod signalod){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				signalod.SignalNum=DbHelper.GetNextOracleKey("signalod","SignalNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(signalod,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							signalod.SignalNum++;
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
				return Insert(signalod,false);
			}
		}

		///<summary>Inserts one Signalod into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Signalod signalod,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				signalod.SignalNum=ReplicationServers.GetKey("signalod","SignalNum");
			}
			string command="INSERT INTO signalod (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SignalNum,";
			}
			command+="FromUser,ITypes,DateViewing,SigType,SigText,SigDateTime,ToUser,AckTime,TaskNum,FKey,FKeyType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(signalod.SignalNum)+",";
			}
			command+=
				 "'"+POut.String(signalod.FromUser)+"',"
				+"'"+POut.String(signalod.ITypes)+"',"
				+    POut.Date  (signalod.DateViewing)+","
				+    POut.Int   ((int)signalod.SigType)+","
				+"'"+POut.String(signalod.SigText)+"',"
				+    POut.DateT (signalod.SigDateTime)+","
				+"'"+POut.String(signalod.ToUser)+"',"
				+    POut.DateT (signalod.AckTime)+","
				+    POut.Long  (signalod.TaskNum)+","
				+    POut.Long  (signalod.FKey)+","
				+"'"+POut.String(signalod.FKeyType.ToString())+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				signalod.SignalNum=Db.NonQ(command,true);
			}
			return signalod.SignalNum;
		}

		///<summary>Inserts one Signalod into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Signalod signalod){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(signalod,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					signalod.SignalNum=DbHelper.GetNextOracleKey("signalod","SignalNum"); //Cacheless method
				}
				return InsertNoCache(signalod,true);
			}
		}

		///<summary>Inserts one Signalod into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Signalod signalod,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO signalod (";
			if(!useExistingPK && isRandomKeys) {
				signalod.SignalNum=ReplicationServers.GetKeyNoCache("signalod","SignalNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SignalNum,";
			}
			command+="FromUser,ITypes,DateViewing,SigType,SigText,SigDateTime,ToUser,AckTime,TaskNum,FKey,FKeyType) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(signalod.SignalNum)+",";
			}
			command+=
				 "'"+POut.String(signalod.FromUser)+"',"
				+"'"+POut.String(signalod.ITypes)+"',"
				+    POut.Date  (signalod.DateViewing)+","
				+    POut.Int   ((int)signalod.SigType)+","
				+"'"+POut.String(signalod.SigText)+"',"
				+    POut.DateT (signalod.SigDateTime)+","
				+"'"+POut.String(signalod.ToUser)+"',"
				+    POut.DateT (signalod.AckTime)+","
				+    POut.Long  (signalod.TaskNum)+","
				+    POut.Long  (signalod.FKey)+","
				+"'"+POut.String(signalod.FKeyType.ToString())+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				signalod.SignalNum=Db.NonQ(command,true);
			}
			return signalod.SignalNum;
		}

		///<summary>Updates one Signalod in the database.</summary>
		public static void Update(Signalod signalod){
			string command="UPDATE signalod SET "
				+"FromUser   = '"+POut.String(signalod.FromUser)+"', "
				+"ITypes     = '"+POut.String(signalod.ITypes)+"', "
				+"DateViewing=  "+POut.Date  (signalod.DateViewing)+", "
				+"SigType    =  "+POut.Int   ((int)signalod.SigType)+", "
				+"SigText    = '"+POut.String(signalod.SigText)+"', "
				+"SigDateTime=  "+POut.DateT (signalod.SigDateTime)+", "
				+"ToUser     = '"+POut.String(signalod.ToUser)+"', "
				+"AckTime    =  "+POut.DateT (signalod.AckTime)+", "
				+"TaskNum    =  "+POut.Long  (signalod.TaskNum)+", "
				+"FKey       =  "+POut.Long  (signalod.FKey)+", "
				+"FKeyType   = '"+POut.String(signalod.FKeyType.ToString())+"' "
				+"WHERE SignalNum = "+POut.Long(signalod.SignalNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Signalod in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Signalod signalod,Signalod oldSignalod){
			string command="";
			if(signalod.FromUser != oldSignalod.FromUser) {
				if(command!=""){ command+=",";}
				command+="FromUser = '"+POut.String(signalod.FromUser)+"'";
			}
			if(signalod.ITypes != oldSignalod.ITypes) {
				if(command!=""){ command+=",";}
				command+="ITypes = '"+POut.String(signalod.ITypes)+"'";
			}
			if(signalod.DateViewing.Date != oldSignalod.DateViewing.Date) {
				if(command!=""){ command+=",";}
				command+="DateViewing = "+POut.Date(signalod.DateViewing)+"";
			}
			if(signalod.SigType != oldSignalod.SigType) {
				if(command!=""){ command+=",";}
				command+="SigType = "+POut.Int   ((int)signalod.SigType)+"";
			}
			if(signalod.SigText != oldSignalod.SigText) {
				if(command!=""){ command+=",";}
				command+="SigText = '"+POut.String(signalod.SigText)+"'";
			}
			if(signalod.SigDateTime != oldSignalod.SigDateTime) {
				if(command!=""){ command+=",";}
				command+="SigDateTime = "+POut.DateT(signalod.SigDateTime)+"";
			}
			if(signalod.ToUser != oldSignalod.ToUser) {
				if(command!=""){ command+=",";}
				command+="ToUser = '"+POut.String(signalod.ToUser)+"'";
			}
			if(signalod.AckTime != oldSignalod.AckTime) {
				if(command!=""){ command+=",";}
				command+="AckTime = "+POut.DateT(signalod.AckTime)+"";
			}
			if(signalod.TaskNum != oldSignalod.TaskNum) {
				if(command!=""){ command+=",";}
				command+="TaskNum = "+POut.Long(signalod.TaskNum)+"";
			}
			if(signalod.FKey != oldSignalod.FKey) {
				if(command!=""){ command+=",";}
				command+="FKey = "+POut.Long(signalod.FKey)+"";
			}
			if(signalod.FKeyType != oldSignalod.FKeyType) {
				if(command!=""){ command+=",";}
				command+="FKeyType = '"+POut.String(signalod.FKeyType.ToString())+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE signalod SET "+command
				+" WHERE SignalNum = "+POut.Long(signalod.SignalNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Signalod,Signalod) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Signalod signalod,Signalod oldSignalod) {
			if(signalod.FromUser != oldSignalod.FromUser) {
				return true;
			}
			if(signalod.ITypes != oldSignalod.ITypes) {
				return true;
			}
			if(signalod.DateViewing.Date != oldSignalod.DateViewing.Date) {
				return true;
			}
			if(signalod.SigType != oldSignalod.SigType) {
				return true;
			}
			if(signalod.SigText != oldSignalod.SigText) {
				return true;
			}
			if(signalod.SigDateTime != oldSignalod.SigDateTime) {
				return true;
			}
			if(signalod.ToUser != oldSignalod.ToUser) {
				return true;
			}
			if(signalod.AckTime != oldSignalod.AckTime) {
				return true;
			}
			if(signalod.TaskNum != oldSignalod.TaskNum) {
				return true;
			}
			if(signalod.FKey != oldSignalod.FKey) {
				return true;
			}
			if(signalod.FKeyType != oldSignalod.FKeyType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Signalod from the database.</summary>
		public static void Delete(long signalNum){
			string command="DELETE FROM signalod "
				+"WHERE SignalNum = "+POut.Long(signalNum);
			Db.NonQ(command);
		}

	}
}