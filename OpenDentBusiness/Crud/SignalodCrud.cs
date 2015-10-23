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
			for(int i=0;i<table.Rows.Count;i++) {
				signalod=new Signalod();
				signalod.SignalNum  = PIn.Long  (table.Rows[i]["SignalNum"].ToString());
				signalod.FromUser   = PIn.String(table.Rows[i]["FromUser"].ToString());
				signalod.ITypes     = PIn.String(table.Rows[i]["ITypes"].ToString());
				signalod.DateViewing= PIn.Date  (table.Rows[i]["DateViewing"].ToString());
				signalod.SigType    = (OpenDentBusiness.SignalType)PIn.Int(table.Rows[i]["SigType"].ToString());
				signalod.SigText    = PIn.String(table.Rows[i]["SigText"].ToString());
				signalod.SigDateTime= PIn.DateT (table.Rows[i]["SigDateTime"].ToString());
				signalod.ToUser     = PIn.String(table.Rows[i]["ToUser"].ToString());
				signalod.AckTime    = PIn.DateT (table.Rows[i]["AckTime"].ToString());
				signalod.TaskNum    = PIn.Long  (table.Rows[i]["TaskNum"].ToString());
				retVal.Add(signalod);
			}
			return retVal;
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
			command+="FromUser,ITypes,DateViewing,SigType,SigText,SigDateTime,ToUser,AckTime,TaskNum) VALUES(";
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
				+    POut.Long  (signalod.TaskNum)+")";
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
			command+="FromUser,ITypes,DateViewing,SigType,SigText,SigDateTime,ToUser,AckTime,TaskNum) VALUES(";
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
				+    POut.Long  (signalod.TaskNum)+")";
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
				+"TaskNum    =  "+POut.Long  (signalod.TaskNum)+" "
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
			if(signalod.DateViewing != oldSignalod.DateViewing) {
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
			if(command==""){
				return false;
			}
			command="UPDATE signalod SET "+command
				+" WHERE SignalNum = "+POut.Long(signalod.SignalNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Signalod from the database.</summary>
		public static void Delete(long signalNum){
			string command="DELETE FROM signalod "
				+"WHERE SignalNum = "+POut.Long(signalNum);
			Db.NonQ(command);
		}

	}
}