//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScreenGroupCrud {
		///<summary>Gets one ScreenGroup object from the database using the primary key.  Returns null if not found.</summary>
		public static ScreenGroup SelectOne(long screenGroupNum){
			string command="SELECT * FROM screengroup "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroupNum);
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ScreenGroup object from the database using a query.</summary>
		public static ScreenGroup SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ScreenGroup objects from the database using a query.</summary>
		public static List<ScreenGroup> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ScreenGroup> TableToList(DataTable table){
			List<ScreenGroup> retVal=new List<ScreenGroup>();
			ScreenGroup screenGroup;
			foreach(DataRow row in table.Rows) {
				screenGroup=new ScreenGroup();
				screenGroup.ScreenGroupNum= PIn.Long  (row["ScreenGroupNum"].ToString());
				screenGroup.Description   = PIn.String(row["Description"].ToString());
				screenGroup.SGDate        = PIn.Date  (row["SGDate"].ToString());
				screenGroup.ProvName      = PIn.String(row["ProvName"].ToString());
				screenGroup.ProvNum       = PIn.Long  (row["ProvNum"].ToString());
				screenGroup.PlaceService  = (OpenDentBusiness.PlaceOfService)PIn.Int(row["PlaceService"].ToString());
				screenGroup.County        = PIn.String(row["County"].ToString());
				screenGroup.GradeSchool   = PIn.String(row["GradeSchool"].ToString());
				retVal.Add(screenGroup);
			}
			return retVal;
		}

		///<summary>Converts a list of ScreenGroup into a DataTable.</summary>
		public static DataTable ListToTable(List<ScreenGroup> listScreenGroups,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ScreenGroup";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ScreenGroupNum");
			table.Columns.Add("Description");
			table.Columns.Add("SGDate");
			table.Columns.Add("ProvName");
			table.Columns.Add("ProvNum");
			table.Columns.Add("PlaceService");
			table.Columns.Add("County");
			table.Columns.Add("GradeSchool");
			foreach(ScreenGroup screenGroup in listScreenGroups) {
				table.Rows.Add(new object[] {
					POut.Long  (screenGroup.ScreenGroupNum),
					POut.String(screenGroup.Description),
					POut.Date  (screenGroup.SGDate),
					POut.String(screenGroup.ProvName),
					POut.Long  (screenGroup.ProvNum),
					POut.Int   ((int)screenGroup.PlaceService),
					POut.String(screenGroup.County),
					POut.String(screenGroup.GradeSchool),
				});
			}
			return table;
		}

		///<summary>Inserts one ScreenGroup into the database.  Returns the new priKey.</summary>
		public static long Insert(ScreenGroup screenGroup){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				screenGroup.ScreenGroupNum=DbHelper.GetNextOracleKey("screengroup","ScreenGroupNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(screenGroup,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							screenGroup.ScreenGroupNum++;
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
				return Insert(screenGroup,false);
			}
		}

		///<summary>Inserts one ScreenGroup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ScreenGroup screenGroup,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				screenGroup.ScreenGroupNum=ReplicationServers.GetKey("screengroup","ScreenGroupNum");
			}
			string command="INSERT INTO screengroup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScreenGroupNum,";
			}
			command+="Description,SGDate,ProvName,ProvNum,PlaceService,County,GradeSchool) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(screenGroup.ScreenGroupNum)+",";
			}
			command+=
				 "'"+POut.String(screenGroup.Description)+"',"
				+    POut.Date  (screenGroup.SGDate)+","
				+"'"+POut.String(screenGroup.ProvName)+"',"
				+    POut.Long  (screenGroup.ProvNum)+","
				+    POut.Int   ((int)screenGroup.PlaceService)+","
				+"'"+POut.String(screenGroup.County)+"',"
				+"'"+POut.String(screenGroup.GradeSchool)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				screenGroup.ScreenGroupNum=Db.NonQ(command,true);
			}
			return screenGroup.ScreenGroupNum;
		}

		///<summary>Inserts one ScreenGroup into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenGroup screenGroup){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(screenGroup,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					screenGroup.ScreenGroupNum=DbHelper.GetNextOracleKey("screengroup","ScreenGroupNum"); //Cacheless method
				}
				return InsertNoCache(screenGroup,true);
			}
		}

		///<summary>Inserts one ScreenGroup into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenGroup screenGroup,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO screengroup (";
			if(!useExistingPK && isRandomKeys) {
				screenGroup.ScreenGroupNum=ReplicationServers.GetKeyNoCache("screengroup","ScreenGroupNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ScreenGroupNum,";
			}
			command+="Description,SGDate,ProvName,ProvNum,PlaceService,County,GradeSchool) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(screenGroup.ScreenGroupNum)+",";
			}
			command+=
				 "'"+POut.String(screenGroup.Description)+"',"
				+    POut.Date  (screenGroup.SGDate)+","
				+"'"+POut.String(screenGroup.ProvName)+"',"
				+    POut.Long  (screenGroup.ProvNum)+","
				+    POut.Int   ((int)screenGroup.PlaceService)+","
				+"'"+POut.String(screenGroup.County)+"',"
				+"'"+POut.String(screenGroup.GradeSchool)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				screenGroup.ScreenGroupNum=Db.NonQ(command,true);
			}
			return screenGroup.ScreenGroupNum;
		}

		///<summary>Updates one ScreenGroup in the database.</summary>
		public static void Update(ScreenGroup screenGroup){
			string command="UPDATE screengroup SET "
				+"Description   = '"+POut.String(screenGroup.Description)+"', "
				+"SGDate        =  "+POut.Date  (screenGroup.SGDate)+", "
				+"ProvName      = '"+POut.String(screenGroup.ProvName)+"', "
				+"ProvNum       =  "+POut.Long  (screenGroup.ProvNum)+", "
				+"PlaceService  =  "+POut.Int   ((int)screenGroup.PlaceService)+", "
				+"County        = '"+POut.String(screenGroup.County)+"', "
				+"GradeSchool   = '"+POut.String(screenGroup.GradeSchool)+"' "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroup.ScreenGroupNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ScreenGroup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ScreenGroup screenGroup,ScreenGroup oldScreenGroup){
			string command="";
			if(screenGroup.Description != oldScreenGroup.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(screenGroup.Description)+"'";
			}
			if(screenGroup.SGDate.Date != oldScreenGroup.SGDate.Date) {
				if(command!=""){ command+=",";}
				command+="SGDate = "+POut.Date(screenGroup.SGDate)+"";
			}
			if(screenGroup.ProvName != oldScreenGroup.ProvName) {
				if(command!=""){ command+=",";}
				command+="ProvName = '"+POut.String(screenGroup.ProvName)+"'";
			}
			if(screenGroup.ProvNum != oldScreenGroup.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(screenGroup.ProvNum)+"";
			}
			if(screenGroup.PlaceService != oldScreenGroup.PlaceService) {
				if(command!=""){ command+=",";}
				command+="PlaceService = "+POut.Int   ((int)screenGroup.PlaceService)+"";
			}
			if(screenGroup.County != oldScreenGroup.County) {
				if(command!=""){ command+=",";}
				command+="County = '"+POut.String(screenGroup.County)+"'";
			}
			if(screenGroup.GradeSchool != oldScreenGroup.GradeSchool) {
				if(command!=""){ command+=",";}
				command+="GradeSchool = '"+POut.String(screenGroup.GradeSchool)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE screengroup SET "+command
				+" WHERE ScreenGroupNum = "+POut.Long(screenGroup.ScreenGroupNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ScreenGroup,ScreenGroup) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ScreenGroup screenGroup,ScreenGroup oldScreenGroup) {
			if(screenGroup.Description != oldScreenGroup.Description) {
				return true;
			}
			if(screenGroup.SGDate.Date != oldScreenGroup.SGDate.Date) {
				return true;
			}
			if(screenGroup.ProvName != oldScreenGroup.ProvName) {
				return true;
			}
			if(screenGroup.ProvNum != oldScreenGroup.ProvNum) {
				return true;
			}
			if(screenGroup.PlaceService != oldScreenGroup.PlaceService) {
				return true;
			}
			if(screenGroup.County != oldScreenGroup.County) {
				return true;
			}
			if(screenGroup.GradeSchool != oldScreenGroup.GradeSchool) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ScreenGroup from the database.</summary>
		public static void Delete(long screenGroupNum){
			string command="DELETE FROM screengroup "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroupNum);
			Db.NonQ(command);
		}

	}
}