//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ProcApptColorCrud {
		///<summary>Gets one ProcApptColor object from the database using the primary key.  Returns null if not found.</summary>
		public static ProcApptColor SelectOne(long procApptColorNum){
			string command="SELECT * FROM procapptcolor "
				+"WHERE ProcApptColorNum = "+POut.Long(procApptColorNum);
			List<ProcApptColor> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProcApptColor object from the database using a query.</summary>
		public static ProcApptColor SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProcApptColor> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProcApptColor objects from the database using a query.</summary>
		public static List<ProcApptColor> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProcApptColor> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProcApptColor> TableToList(DataTable table){
			List<ProcApptColor> retVal=new List<ProcApptColor>();
			ProcApptColor procApptColor;
			for(int i=0;i<table.Rows.Count;i++) {
				procApptColor=new ProcApptColor();
				procApptColor.ProcApptColorNum= PIn.Long  (table.Rows[i]["ProcApptColorNum"].ToString());
				procApptColor.CodeRange       = PIn.String(table.Rows[i]["CodeRange"].ToString());
				procApptColor.ShowPreviousDate= PIn.Bool  (table.Rows[i]["ShowPreviousDate"].ToString());
				procApptColor.ColorText       = Color.FromArgb(PIn.Int(table.Rows[i]["ColorText"].ToString()));
				retVal.Add(procApptColor);
			}
			return retVal;
		}

		///<summary>Inserts one ProcApptColor into the database.  Returns the new priKey.</summary>
		public static long Insert(ProcApptColor procApptColor){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				procApptColor.ProcApptColorNum=DbHelper.GetNextOracleKey("procapptcolor","ProcApptColorNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(procApptColor,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							procApptColor.ProcApptColorNum++;
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
				return Insert(procApptColor,false);
			}
		}

		///<summary>Inserts one ProcApptColor into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProcApptColor procApptColor,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				procApptColor.ProcApptColorNum=ReplicationServers.GetKey("procapptcolor","ProcApptColorNum");
			}
			string command="INSERT INTO procapptcolor (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProcApptColorNum,";
			}
			command+="CodeRange,ShowPreviousDate,ColorText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(procApptColor.ProcApptColorNum)+",";
			}
			command+=
				 "'"+POut.String(procApptColor.CodeRange)+"',"
				+    POut.Bool  (procApptColor.ShowPreviousDate)+","
				+    POut.Int   (procApptColor.ColorText.ToArgb())+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				procApptColor.ProcApptColorNum=Db.NonQ(command,true);
			}
			return procApptColor.ProcApptColorNum;
		}

		///<summary>Inserts one ProcApptColor into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProcApptColor procApptColor){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(procApptColor,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					procApptColor.ProcApptColorNum=DbHelper.GetNextOracleKey("procapptcolor","ProcApptColorNum"); //Cacheless method
				}
				return InsertNoCache(procApptColor,true);
			}
		}

		///<summary>Inserts one ProcApptColor into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProcApptColor procApptColor,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO procapptcolor (";
			if(!useExistingPK && isRandomKeys) {
				procApptColor.ProcApptColorNum=ReplicationServers.GetKeyNoCache("procapptcolor","ProcApptColorNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ProcApptColorNum,";
			}
			command+="CodeRange,ShowPreviousDate,ColorText) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(procApptColor.ProcApptColorNum)+",";
			}
			command+=
				 "'"+POut.String(procApptColor.CodeRange)+"',"
				+    POut.Bool  (procApptColor.ShowPreviousDate)+","
				+    POut.Int   (procApptColor.ColorText.ToArgb())+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				procApptColor.ProcApptColorNum=Db.NonQ(command,true);
			}
			return procApptColor.ProcApptColorNum;
		}

		///<summary>Updates one ProcApptColor in the database.</summary>
		public static void Update(ProcApptColor procApptColor){
			string command="UPDATE procapptcolor SET "
				+"CodeRange       = '"+POut.String(procApptColor.CodeRange)+"', "
				+"ShowPreviousDate=  "+POut.Bool  (procApptColor.ShowPreviousDate)+", "
				+"ColorText       =  "+POut.Int   (procApptColor.ColorText.ToArgb())+" "
				+"WHERE ProcApptColorNum = "+POut.Long(procApptColor.ProcApptColorNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ProcApptColor in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProcApptColor procApptColor,ProcApptColor oldProcApptColor){
			string command="";
			if(procApptColor.CodeRange != oldProcApptColor.CodeRange) {
				if(command!=""){ command+=",";}
				command+="CodeRange = '"+POut.String(procApptColor.CodeRange)+"'";
			}
			if(procApptColor.ShowPreviousDate != oldProcApptColor.ShowPreviousDate) {
				if(command!=""){ command+=",";}
				command+="ShowPreviousDate = "+POut.Bool(procApptColor.ShowPreviousDate)+"";
			}
			if(procApptColor.ColorText != oldProcApptColor.ColorText) {
				if(command!=""){ command+=",";}
				command+="ColorText = "+POut.Int(procApptColor.ColorText.ToArgb())+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE procapptcolor SET "+command
				+" WHERE ProcApptColorNum = "+POut.Long(procApptColor.ProcApptColorNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ProcApptColor from the database.</summary>
		public static void Delete(long procApptColorNum){
			string command="DELETE FROM procapptcolor "
				+"WHERE ProcApptColorNum = "+POut.Long(procApptColorNum);
			Db.NonQ(command);
		}

	}
}