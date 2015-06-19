//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ToolButItemCrud {
		///<summary>Gets one ToolButItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ToolButItem SelectOne(long toolButItemNum){
			string command="SELECT * FROM toolbutitem "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItemNum);
			List<ToolButItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ToolButItem object from the database using a query.</summary>
		public static ToolButItem SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ToolButItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ToolButItem objects from the database using a query.</summary>
		public static List<ToolButItem> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ToolButItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ToolButItem> TableToList(DataTable table){
			List<ToolButItem> retVal=new List<ToolButItem>();
			ToolButItem toolButItem;
			for(int i=0;i<table.Rows.Count;i++) {
				toolButItem=new ToolButItem();
				toolButItem.ToolButItemNum= PIn.Long  (table.Rows[i]["ToolButItemNum"].ToString());
				toolButItem.ProgramNum    = PIn.Long  (table.Rows[i]["ProgramNum"].ToString());
				toolButItem.ToolBar       = (OpenDentBusiness.ToolBarsAvail)PIn.Int(table.Rows[i]["ToolBar"].ToString());
				toolButItem.ButtonText    = PIn.String(table.Rows[i]["ButtonText"].ToString());
				retVal.Add(toolButItem);
			}
			return retVal;
		}

		///<summary>Inserts one ToolButItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ToolButItem toolButItem){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				toolButItem.ToolButItemNum=DbHelper.GetNextOracleKey("toolbutitem","ToolButItemNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(toolButItem,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							toolButItem.ToolButItemNum++;
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
				return Insert(toolButItem,false);
			}
		}

		///<summary>Inserts one ToolButItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ToolButItem toolButItem,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				toolButItem.ToolButItemNum=ReplicationServers.GetKey("toolbutitem","ToolButItemNum");
			}
			string command="INSERT INTO toolbutitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ToolButItemNum,";
			}
			command+="ProgramNum,ToolBar,ButtonText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(toolButItem.ToolButItemNum)+",";
			}
			command+=
				     POut.Long  (toolButItem.ProgramNum)+","
				+    POut.Int   ((int)toolButItem.ToolBar)+","
				+"'"+POut.String(toolButItem.ButtonText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				toolButItem.ToolButItemNum=Db.NonQ(command,true);
			}
			return toolButItem.ToolButItemNum;
		}

		///<summary>Inserts one ToolButItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToolButItem toolButItem){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(toolButItem,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					toolButItem.ToolButItemNum=DbHelper.GetNextOracleKey("toolbutitem","ToolButItemNum"); //Cacheless method
				}
				return InsertNoCache(toolButItem,true);
			}
		}

		///<summary>Inserts one ToolButItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToolButItem toolButItem,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO toolbutitem (";
			if(!useExistingPK && isRandomKeys) {
				toolButItem.ToolButItemNum=ReplicationServers.GetKeyNoCache("toolbutitem","ToolButItemNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ToolButItemNum,";
			}
			command+="ProgramNum,ToolBar,ButtonText) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(toolButItem.ToolButItemNum)+",";
			}
			command+=
				     POut.Long  (toolButItem.ProgramNum)+","
				+    POut.Int   ((int)toolButItem.ToolBar)+","
				+"'"+POut.String(toolButItem.ButtonText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				toolButItem.ToolButItemNum=Db.NonQ(command,true);
			}
			return toolButItem.ToolButItemNum;
		}

		///<summary>Updates one ToolButItem in the database.</summary>
		public static void Update(ToolButItem toolButItem){
			string command="UPDATE toolbutitem SET "
				+"ProgramNum    =  "+POut.Long  (toolButItem.ProgramNum)+", "
				+"ToolBar       =  "+POut.Int   ((int)toolButItem.ToolBar)+", "
				+"ButtonText    = '"+POut.String(toolButItem.ButtonText)+"' "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItem.ToolButItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ToolButItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ToolButItem toolButItem,ToolButItem oldToolButItem){
			string command="";
			if(toolButItem.ProgramNum != oldToolButItem.ProgramNum) {
				if(command!=""){ command+=",";}
				command+="ProgramNum = "+POut.Long(toolButItem.ProgramNum)+"";
			}
			if(toolButItem.ToolBar != oldToolButItem.ToolBar) {
				if(command!=""){ command+=",";}
				command+="ToolBar = "+POut.Int   ((int)toolButItem.ToolBar)+"";
			}
			if(toolButItem.ButtonText != oldToolButItem.ButtonText) {
				if(command!=""){ command+=",";}
				command+="ButtonText = '"+POut.String(toolButItem.ButtonText)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE toolbutitem SET "+command
				+" WHERE ToolButItemNum = "+POut.Long(toolButItem.ToolButItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ToolButItem from the database.</summary>
		public static void Delete(long toolButItemNum){
			string command="DELETE FROM toolbutitem "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItemNum);
			Db.NonQ(command);
		}

	}
}