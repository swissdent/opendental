//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScreenPatCrud {
		///<summary>Gets one ScreenPat object from the database using the primary key.  Returns null if not found.</summary>
		public static ScreenPat SelectOne(long screenPatNum){
			string command="SELECT * FROM screenpat "
				+"WHERE ScreenPatNum = "+POut.Long(screenPatNum);
			List<ScreenPat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ScreenPat object from the database using a query.</summary>
		public static ScreenPat SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenPat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ScreenPat objects from the database using a query.</summary>
		public static List<ScreenPat> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenPat> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ScreenPat> TableToList(DataTable table){
			List<ScreenPat> retVal=new List<ScreenPat>();
			ScreenPat screenPat;
			foreach(DataRow row in table.Rows) {
				screenPat=new ScreenPat();
				screenPat.ScreenPatNum  = PIn.Long  (row["ScreenPatNum"].ToString());
				screenPat.PatNum        = PIn.Long  (row["PatNum"].ToString());
				screenPat.ScreenGroupNum= PIn.Long  (row["ScreenGroupNum"].ToString());
				screenPat.SheetNum      = PIn.Long  (row["SheetNum"].ToString());
				retVal.Add(screenPat);
			}
			return retVal;
		}

		///<summary>Inserts one ScreenPat into the database.  Returns the new priKey.</summary>
		public static long Insert(ScreenPat screenPat){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				screenPat.ScreenPatNum=DbHelper.GetNextOracleKey("screenpat","ScreenPatNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(screenPat,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							screenPat.ScreenPatNum++;
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
				return Insert(screenPat,false);
			}
		}

		///<summary>Inserts one ScreenPat into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ScreenPat screenPat,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				screenPat.ScreenPatNum=ReplicationServers.GetKey("screenpat","ScreenPatNum");
			}
			string command="INSERT INTO screenpat (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScreenPatNum,";
			}
			command+="PatNum,ScreenGroupNum,SheetNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(screenPat.ScreenPatNum)+",";
			}
			command+=
				     POut.Long  (screenPat.PatNum)+","
				+    POut.Long  (screenPat.ScreenGroupNum)+","
				+    POut.Long  (screenPat.SheetNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				screenPat.ScreenPatNum=Db.NonQ(command,true);
			}
			return screenPat.ScreenPatNum;
		}

		///<summary>Inserts one ScreenPat into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenPat screenPat){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(screenPat,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					screenPat.ScreenPatNum=DbHelper.GetNextOracleKey("screenpat","ScreenPatNum"); //Cacheless method
				}
				return InsertNoCache(screenPat,true);
			}
		}

		///<summary>Inserts one ScreenPat into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenPat screenPat,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO screenpat (";
			if(!useExistingPK && isRandomKeys) {
				screenPat.ScreenPatNum=ReplicationServers.GetKeyNoCache("screenpat","ScreenPatNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ScreenPatNum,";
			}
			command+="PatNum,ScreenGroupNum,SheetNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(screenPat.ScreenPatNum)+",";
			}
			command+=
				     POut.Long  (screenPat.PatNum)+","
				+    POut.Long  (screenPat.ScreenGroupNum)+","
				+    POut.Long  (screenPat.SheetNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				screenPat.ScreenPatNum=Db.NonQ(command,true);
			}
			return screenPat.ScreenPatNum;
		}

		///<summary>Updates one ScreenPat in the database.</summary>
		public static void Update(ScreenPat screenPat){
			string command="UPDATE screenpat SET "
				+"PatNum        =  "+POut.Long  (screenPat.PatNum)+", "
				+"ScreenGroupNum=  "+POut.Long  (screenPat.ScreenGroupNum)+", "
				+"SheetNum      =  "+POut.Long  (screenPat.SheetNum)+" "
				+"WHERE ScreenPatNum = "+POut.Long(screenPat.ScreenPatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ScreenPat in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ScreenPat screenPat,ScreenPat oldScreenPat){
			string command="";
			if(screenPat.PatNum != oldScreenPat.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(screenPat.PatNum)+"";
			}
			if(screenPat.ScreenGroupNum != oldScreenPat.ScreenGroupNum) {
				if(command!=""){ command+=",";}
				command+="ScreenGroupNum = "+POut.Long(screenPat.ScreenGroupNum)+"";
			}
			if(screenPat.SheetNum != oldScreenPat.SheetNum) {
				if(command!=""){ command+=",";}
				command+="SheetNum = "+POut.Long(screenPat.SheetNum)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE screenpat SET "+command
				+" WHERE ScreenPatNum = "+POut.Long(screenPat.ScreenPatNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ScreenPat from the database.</summary>
		public static void Delete(long screenPatNum){
			string command="DELETE FROM screenpat "
				+"WHERE ScreenPatNum = "+POut.Long(screenPatNum);
			Db.NonQ(command);
		}

	}
}