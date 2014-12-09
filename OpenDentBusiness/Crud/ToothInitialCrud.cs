//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ToothInitialCrud {
		///<summary>Gets one ToothInitial object from the database using the primary key.  Returns null if not found.</summary>
		public static ToothInitial SelectOne(long toothInitialNum){
			string command="SELECT * FROM toothinitial "
				+"WHERE ToothInitialNum = "+POut.Long(toothInitialNum);
			List<ToothInitial> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ToothInitial object from the database using a query.</summary>
		public static ToothInitial SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ToothInitial> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ToothInitial objects from the database using a query.</summary>
		public static List<ToothInitial> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ToothInitial> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ToothInitial> TableToList(DataTable table){
			List<ToothInitial> retVal=new List<ToothInitial>();
			ToothInitial toothInitial;
			for(int i=0;i<table.Rows.Count;i++) {
				toothInitial=new ToothInitial();
				toothInitial.ToothInitialNum= PIn.Long  (table.Rows[i]["ToothInitialNum"].ToString());
				toothInitial.PatNum         = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				toothInitial.ToothNum       = PIn.String(table.Rows[i]["ToothNum"].ToString());
				toothInitial.InitialType    = (OpenDentBusiness.ToothInitialType)PIn.Int(table.Rows[i]["InitialType"].ToString());
				toothInitial.Movement       = PIn.Float (table.Rows[i]["Movement"].ToString());
				toothInitial.DrawingSegment = PIn.String(table.Rows[i]["DrawingSegment"].ToString());
				toothInitial.ColorDraw      = Color.FromArgb(PIn.Int(table.Rows[i]["ColorDraw"].ToString()));
				retVal.Add(toothInitial);
			}
			return retVal;
		}

		///<summary>Inserts one ToothInitial into the database.  Returns the new priKey.</summary>
		public static long Insert(ToothInitial toothInitial){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				toothInitial.ToothInitialNum=DbHelper.GetNextOracleKey("toothinitial","ToothInitialNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(toothInitial,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							toothInitial.ToothInitialNum++;
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
				return Insert(toothInitial,false);
			}
		}

		///<summary>Inserts one ToothInitial into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ToothInitial toothInitial,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				toothInitial.ToothInitialNum=ReplicationServers.GetKey("toothinitial","ToothInitialNum");
			}
			string command="INSERT INTO toothinitial (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ToothInitialNum,";
			}
			command+="PatNum,ToothNum,InitialType,Movement,DrawingSegment,ColorDraw) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(toothInitial.ToothInitialNum)+",";
			}
			command+=
				     POut.Long  (toothInitial.PatNum)+","
				+"'"+POut.String(toothInitial.ToothNum)+"',"
				+    POut.Int   ((int)toothInitial.InitialType)+","
				+    POut.Float (toothInitial.Movement)+","
				+"'"+POut.String(toothInitial.DrawingSegment)+"',"
				+    POut.Int   (toothInitial.ColorDraw.ToArgb())+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				toothInitial.ToothInitialNum=Db.NonQ(command,true);
			}
			return toothInitial.ToothInitialNum;
		}

		///<summary>Updates one ToothInitial in the database.</summary>
		public static void Update(ToothInitial toothInitial){
			string command="UPDATE toothinitial SET "
				+"PatNum         =  "+POut.Long  (toothInitial.PatNum)+", "
				+"ToothNum       = '"+POut.String(toothInitial.ToothNum)+"', "
				+"InitialType    =  "+POut.Int   ((int)toothInitial.InitialType)+", "
				+"Movement       =  "+POut.Float (toothInitial.Movement)+", "
				+"DrawingSegment = '"+POut.String(toothInitial.DrawingSegment)+"', "
				+"ColorDraw      =  "+POut.Int   (toothInitial.ColorDraw.ToArgb())+" "
				+"WHERE ToothInitialNum = "+POut.Long(toothInitial.ToothInitialNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ToothInitial in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ToothInitial toothInitial,ToothInitial oldToothInitial){
			string command="";
			if(toothInitial.PatNum != oldToothInitial.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(toothInitial.PatNum)+"";
			}
			if(toothInitial.ToothNum != oldToothInitial.ToothNum) {
				if(command!=""){ command+=",";}
				command+="ToothNum = '"+POut.String(toothInitial.ToothNum)+"'";
			}
			if(toothInitial.InitialType != oldToothInitial.InitialType) {
				if(command!=""){ command+=",";}
				command+="InitialType = "+POut.Int   ((int)toothInitial.InitialType)+"";
			}
			if(toothInitial.Movement != oldToothInitial.Movement) {
				if(command!=""){ command+=",";}
				command+="Movement = "+POut.Float(toothInitial.Movement)+"";
			}
			if(toothInitial.DrawingSegment != oldToothInitial.DrawingSegment) {
				if(command!=""){ command+=",";}
				command+="DrawingSegment = '"+POut.String(toothInitial.DrawingSegment)+"'";
			}
			if(toothInitial.ColorDraw != oldToothInitial.ColorDraw) {
				if(command!=""){ command+=",";}
				command+="ColorDraw = "+POut.Int(toothInitial.ColorDraw.ToArgb())+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE toothinitial SET "+command
				+" WHERE ToothInitialNum = "+POut.Long(toothInitial.ToothInitialNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ToothInitial from the database.</summary>
		public static void Delete(long toothInitialNum){
			string command="DELETE FROM toothinitial "
				+"WHERE ToothInitialNum = "+POut.Long(toothInitialNum);
			Db.NonQ(command);
		}

	}
}