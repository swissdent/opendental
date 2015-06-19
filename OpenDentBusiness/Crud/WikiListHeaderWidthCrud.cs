//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class WikiListHeaderWidthCrud {
		///<summary>Gets one WikiListHeaderWidth object from the database using the primary key.  Returns null if not found.</summary>
		public static WikiListHeaderWidth SelectOne(long wikiListHeaderWidthNum){
			string command="SELECT * FROM wikilistheaderwidth "
				+"WHERE WikiListHeaderWidthNum = "+POut.Long(wikiListHeaderWidthNum);
			List<WikiListHeaderWidth> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WikiListHeaderWidth object from the database using a query.</summary>
		public static WikiListHeaderWidth SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WikiListHeaderWidth> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WikiListHeaderWidth objects from the database using a query.</summary>
		public static List<WikiListHeaderWidth> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WikiListHeaderWidth> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WikiListHeaderWidth> TableToList(DataTable table){
			List<WikiListHeaderWidth> retVal=new List<WikiListHeaderWidth>();
			WikiListHeaderWidth wikiListHeaderWidth;
			for(int i=0;i<table.Rows.Count;i++) {
				wikiListHeaderWidth=new WikiListHeaderWidth();
				wikiListHeaderWidth.WikiListHeaderWidthNum= PIn.Long  (table.Rows[i]["WikiListHeaderWidthNum"].ToString());
				wikiListHeaderWidth.ListName              = PIn.String(table.Rows[i]["ListName"].ToString());
				wikiListHeaderWidth.ColName               = PIn.String(table.Rows[i]["ColName"].ToString());
				wikiListHeaderWidth.ColWidth              = PIn.Int   (table.Rows[i]["ColWidth"].ToString());
				retVal.Add(wikiListHeaderWidth);
			}
			return retVal;
		}

		///<summary>Inserts one WikiListHeaderWidth into the database.  Returns the new priKey.</summary>
		public static long Insert(WikiListHeaderWidth wikiListHeaderWidth){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				wikiListHeaderWidth.WikiListHeaderWidthNum=DbHelper.GetNextOracleKey("wikilistheaderwidth","WikiListHeaderWidthNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(wikiListHeaderWidth,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							wikiListHeaderWidth.WikiListHeaderWidthNum++;
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
				return Insert(wikiListHeaderWidth,false);
			}
		}

		///<summary>Inserts one WikiListHeaderWidth into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WikiListHeaderWidth wikiListHeaderWidth,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				wikiListHeaderWidth.WikiListHeaderWidthNum=ReplicationServers.GetKey("wikilistheaderwidth","WikiListHeaderWidthNum");
			}
			string command="INSERT INTO wikilistheaderwidth (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="WikiListHeaderWidthNum,";
			}
			command+="ListName,ColName,ColWidth) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(wikiListHeaderWidth.WikiListHeaderWidthNum)+",";
			}
			command+=
				 "'"+POut.String(wikiListHeaderWidth.ListName)+"',"
				+"'"+POut.String(wikiListHeaderWidth.ColName)+"',"
				+    POut.Int   (wikiListHeaderWidth.ColWidth)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				wikiListHeaderWidth.WikiListHeaderWidthNum=Db.NonQ(command,true);
			}
			return wikiListHeaderWidth.WikiListHeaderWidthNum;
		}

		///<summary>Inserts one WikiListHeaderWidth into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WikiListHeaderWidth wikiListHeaderWidth){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(wikiListHeaderWidth,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					wikiListHeaderWidth.WikiListHeaderWidthNum=DbHelper.GetNextOracleKey("wikilistheaderwidth","WikiListHeaderWidthNum"); //Cacheless method
				}
				return InsertNoCache(wikiListHeaderWidth,true);
			}
		}

		///<summary>Inserts one WikiListHeaderWidth into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WikiListHeaderWidth wikiListHeaderWidth,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO wikilistheaderwidth (";
			if(!useExistingPK && isRandomKeys) {
				wikiListHeaderWidth.WikiListHeaderWidthNum=ReplicationServers.GetKeyNoCache("wikilistheaderwidth","WikiListHeaderWidthNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="WikiListHeaderWidthNum,";
			}
			command+="ListName,ColName,ColWidth) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(wikiListHeaderWidth.WikiListHeaderWidthNum)+",";
			}
			command+=
				 "'"+POut.String(wikiListHeaderWidth.ListName)+"',"
				+"'"+POut.String(wikiListHeaderWidth.ColName)+"',"
				+    POut.Int   (wikiListHeaderWidth.ColWidth)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				wikiListHeaderWidth.WikiListHeaderWidthNum=Db.NonQ(command,true);
			}
			return wikiListHeaderWidth.WikiListHeaderWidthNum;
		}

		///<summary>Updates one WikiListHeaderWidth in the database.</summary>
		public static void Update(WikiListHeaderWidth wikiListHeaderWidth){
			string command="UPDATE wikilistheaderwidth SET "
				+"ListName              = '"+POut.String(wikiListHeaderWidth.ListName)+"', "
				+"ColName               = '"+POut.String(wikiListHeaderWidth.ColName)+"', "
				+"ColWidth              =  "+POut.Int   (wikiListHeaderWidth.ColWidth)+" "
				+"WHERE WikiListHeaderWidthNum = "+POut.Long(wikiListHeaderWidth.WikiListHeaderWidthNum);
			Db.NonQ(command);
		}

		///<summary>Updates one WikiListHeaderWidth in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WikiListHeaderWidth wikiListHeaderWidth,WikiListHeaderWidth oldWikiListHeaderWidth){
			string command="";
			if(wikiListHeaderWidth.ListName != oldWikiListHeaderWidth.ListName) {
				if(command!=""){ command+=",";}
				command+="ListName = '"+POut.String(wikiListHeaderWidth.ListName)+"'";
			}
			if(wikiListHeaderWidth.ColName != oldWikiListHeaderWidth.ColName) {
				if(command!=""){ command+=",";}
				command+="ColName = '"+POut.String(wikiListHeaderWidth.ColName)+"'";
			}
			if(wikiListHeaderWidth.ColWidth != oldWikiListHeaderWidth.ColWidth) {
				if(command!=""){ command+=",";}
				command+="ColWidth = "+POut.Int(wikiListHeaderWidth.ColWidth)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE wikilistheaderwidth SET "+command
				+" WHERE WikiListHeaderWidthNum = "+POut.Long(wikiListHeaderWidth.WikiListHeaderWidthNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one WikiListHeaderWidth from the database.</summary>
		public static void Delete(long wikiListHeaderWidthNum){
			string command="DELETE FROM wikilistheaderwidth "
				+"WHERE WikiListHeaderWidthNum = "+POut.Long(wikiListHeaderWidthNum);
			Db.NonQ(command);
		}

	}
}