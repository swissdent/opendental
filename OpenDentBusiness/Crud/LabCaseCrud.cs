//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LabCaseCrud {
		///<summary>Gets one LabCase object from the database using the primary key.  Returns null if not found.</summary>
		public static LabCase SelectOne(long labCaseNum){
			string command="SELECT * FROM labcase "
				+"WHERE LabCaseNum = "+POut.Long(labCaseNum);
			List<LabCase> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LabCase object from the database using a query.</summary>
		public static LabCase SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LabCase> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LabCase objects from the database using a query.</summary>
		public static List<LabCase> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LabCase> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LabCase> TableToList(DataTable table){
			List<LabCase> retVal=new List<LabCase>();
			LabCase labCase;
			foreach(DataRow row in table.Rows) {
				labCase=new LabCase();
				labCase.LabCaseNum     = PIn.Long  (row["LabCaseNum"].ToString());
				labCase.PatNum         = PIn.Long  (row["PatNum"].ToString());
				labCase.LaboratoryNum  = PIn.Long  (row["LaboratoryNum"].ToString());
				labCase.AptNum         = PIn.Long  (row["AptNum"].ToString());
				labCase.PlannedAptNum  = PIn.Long  (row["PlannedAptNum"].ToString());
				labCase.DateTimeDue    = PIn.DateT (row["DateTimeDue"].ToString());
				labCase.DateTimeCreated= PIn.DateT (row["DateTimeCreated"].ToString());
				labCase.DateTimeSent   = PIn.DateT (row["DateTimeSent"].ToString());
				labCase.DateTimeRecd   = PIn.DateT (row["DateTimeRecd"].ToString());
				labCase.DateTimeChecked= PIn.DateT (row["DateTimeChecked"].ToString());
				labCase.ProvNum        = PIn.Long  (row["ProvNum"].ToString());
				labCase.Instructions   = PIn.String(row["Instructions"].ToString());
				labCase.LabFee         = PIn.Double(row["LabFee"].ToString());
				retVal.Add(labCase);
			}
			return retVal;
		}

		///<summary>Inserts one LabCase into the database.  Returns the new priKey.</summary>
		public static long Insert(LabCase labCase){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				labCase.LabCaseNum=DbHelper.GetNextOracleKey("labcase","LabCaseNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(labCase,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							labCase.LabCaseNum++;
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
				return Insert(labCase,false);
			}
		}

		///<summary>Inserts one LabCase into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LabCase labCase,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				labCase.LabCaseNum=ReplicationServers.GetKey("labcase","LabCaseNum");
			}
			string command="INSERT INTO labcase (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LabCaseNum,";
			}
			command+="PatNum,LaboratoryNum,AptNum,PlannedAptNum,DateTimeDue,DateTimeCreated,DateTimeSent,DateTimeRecd,DateTimeChecked,ProvNum,Instructions,LabFee) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(labCase.LabCaseNum)+",";
			}
			command+=
				     POut.Long  (labCase.PatNum)+","
				+    POut.Long  (labCase.LaboratoryNum)+","
				+    POut.Long  (labCase.AptNum)+","
				+    POut.Long  (labCase.PlannedAptNum)+","
				+    POut.DateT (labCase.DateTimeDue)+","
				+    POut.DateT (labCase.DateTimeCreated)+","
				+    POut.DateT (labCase.DateTimeSent)+","
				+    POut.DateT (labCase.DateTimeRecd)+","
				+    POut.DateT (labCase.DateTimeChecked)+","
				+    POut.Long  (labCase.ProvNum)+","
				+"'"+POut.String(labCase.Instructions)+"',"
				+"'"+POut.Double(labCase.LabFee)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				labCase.LabCaseNum=Db.NonQ(command,true);
			}
			return labCase.LabCaseNum;
		}

		///<summary>Inserts one LabCase into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LabCase labCase){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(labCase,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					labCase.LabCaseNum=DbHelper.GetNextOracleKey("labcase","LabCaseNum"); //Cacheless method
				}
				return InsertNoCache(labCase,true);
			}
		}

		///<summary>Inserts one LabCase into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LabCase labCase,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO labcase (";
			if(!useExistingPK && isRandomKeys) {
				labCase.LabCaseNum=ReplicationServers.GetKeyNoCache("labcase","LabCaseNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="LabCaseNum,";
			}
			command+="PatNum,LaboratoryNum,AptNum,PlannedAptNum,DateTimeDue,DateTimeCreated,DateTimeSent,DateTimeRecd,DateTimeChecked,ProvNum,Instructions,LabFee) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(labCase.LabCaseNum)+",";
			}
			command+=
				     POut.Long  (labCase.PatNum)+","
				+    POut.Long  (labCase.LaboratoryNum)+","
				+    POut.Long  (labCase.AptNum)+","
				+    POut.Long  (labCase.PlannedAptNum)+","
				+    POut.DateT (labCase.DateTimeDue)+","
				+    POut.DateT (labCase.DateTimeCreated)+","
				+    POut.DateT (labCase.DateTimeSent)+","
				+    POut.DateT (labCase.DateTimeRecd)+","
				+    POut.DateT (labCase.DateTimeChecked)+","
				+    POut.Long  (labCase.ProvNum)+","
				+"'"+POut.String(labCase.Instructions)+"',"
				+"'"+POut.Double(labCase.LabFee)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				labCase.LabCaseNum=Db.NonQ(command,true);
			}
			return labCase.LabCaseNum;
		}

		///<summary>Updates one LabCase in the database.</summary>
		public static void Update(LabCase labCase){
			string command="UPDATE labcase SET "
				+"PatNum         =  "+POut.Long  (labCase.PatNum)+", "
				+"LaboratoryNum  =  "+POut.Long  (labCase.LaboratoryNum)+", "
				+"AptNum         =  "+POut.Long  (labCase.AptNum)+", "
				+"PlannedAptNum  =  "+POut.Long  (labCase.PlannedAptNum)+", "
				+"DateTimeDue    =  "+POut.DateT (labCase.DateTimeDue)+", "
				+"DateTimeCreated=  "+POut.DateT (labCase.DateTimeCreated)+", "
				+"DateTimeSent   =  "+POut.DateT (labCase.DateTimeSent)+", "
				+"DateTimeRecd   =  "+POut.DateT (labCase.DateTimeRecd)+", "
				+"DateTimeChecked=  "+POut.DateT (labCase.DateTimeChecked)+", "
				+"ProvNum        =  "+POut.Long  (labCase.ProvNum)+", "
				+"Instructions   = '"+POut.String(labCase.Instructions)+"', "
				+"LabFee         = '"+POut.Double(labCase.LabFee)+"' "
				+"WHERE LabCaseNum = "+POut.Long(labCase.LabCaseNum);
			Db.NonQ(command);
		}

		///<summary>Updates one LabCase in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(LabCase labCase,LabCase oldLabCase){
			string command="";
			if(labCase.PatNum != oldLabCase.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(labCase.PatNum)+"";
			}
			if(labCase.LaboratoryNum != oldLabCase.LaboratoryNum) {
				if(command!=""){ command+=",";}
				command+="LaboratoryNum = "+POut.Long(labCase.LaboratoryNum)+"";
			}
			if(labCase.AptNum != oldLabCase.AptNum) {
				if(command!=""){ command+=",";}
				command+="AptNum = "+POut.Long(labCase.AptNum)+"";
			}
			if(labCase.PlannedAptNum != oldLabCase.PlannedAptNum) {
				if(command!=""){ command+=",";}
				command+="PlannedAptNum = "+POut.Long(labCase.PlannedAptNum)+"";
			}
			if(labCase.DateTimeDue != oldLabCase.DateTimeDue) {
				if(command!=""){ command+=",";}
				command+="DateTimeDue = "+POut.DateT(labCase.DateTimeDue)+"";
			}
			if(labCase.DateTimeCreated != oldLabCase.DateTimeCreated) {
				if(command!=""){ command+=",";}
				command+="DateTimeCreated = "+POut.DateT(labCase.DateTimeCreated)+"";
			}
			if(labCase.DateTimeSent != oldLabCase.DateTimeSent) {
				if(command!=""){ command+=",";}
				command+="DateTimeSent = "+POut.DateT(labCase.DateTimeSent)+"";
			}
			if(labCase.DateTimeRecd != oldLabCase.DateTimeRecd) {
				if(command!=""){ command+=",";}
				command+="DateTimeRecd = "+POut.DateT(labCase.DateTimeRecd)+"";
			}
			if(labCase.DateTimeChecked != oldLabCase.DateTimeChecked) {
				if(command!=""){ command+=",";}
				command+="DateTimeChecked = "+POut.DateT(labCase.DateTimeChecked)+"";
			}
			if(labCase.ProvNum != oldLabCase.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(labCase.ProvNum)+"";
			}
			if(labCase.Instructions != oldLabCase.Instructions) {
				if(command!=""){ command+=",";}
				command+="Instructions = '"+POut.String(labCase.Instructions)+"'";
			}
			if(labCase.LabFee != oldLabCase.LabFee) {
				if(command!=""){ command+=",";}
				command+="LabFee = '"+POut.Double(labCase.LabFee)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE labcase SET "+command
				+" WHERE LabCaseNum = "+POut.Long(labCase.LabCaseNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one LabCase from the database.</summary>
		public static void Delete(long labCaseNum){
			string command="DELETE FROM labcase "
				+"WHERE LabCaseNum = "+POut.Long(labCaseNum);
			Db.NonQ(command);
		}

	}
}