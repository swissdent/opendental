//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class RequiredFieldConditionCrud {
		///<summary>Gets one RequiredFieldCondition object from the database using the primary key.  Returns null if not found.</summary>
		public static RequiredFieldCondition SelectOne(long requiredFieldConditionNum){
			string command="SELECT * FROM requiredfieldcondition "
				+"WHERE RequiredFieldConditionNum = "+POut.Long(requiredFieldConditionNum);
			List<RequiredFieldCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one RequiredFieldCondition object from the database using a query.</summary>
		public static RequiredFieldCondition SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RequiredFieldCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of RequiredFieldCondition objects from the database using a query.</summary>
		public static List<RequiredFieldCondition> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RequiredFieldCondition> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<RequiredFieldCondition> TableToList(DataTable table){
			List<RequiredFieldCondition> retVal=new List<RequiredFieldCondition>();
			RequiredFieldCondition requiredFieldCondition;
			foreach(DataRow row in table.Rows) {
				requiredFieldCondition=new RequiredFieldCondition();
				requiredFieldCondition.RequiredFieldConditionNum= PIn.Long  (row["RequiredFieldConditionNum"].ToString());
				requiredFieldCondition.RequiredFieldNum         = PIn.Long  (row["RequiredFieldNum"].ToString());
				string conditionType=row["ConditionType"].ToString();
				if(conditionType==""){
					requiredFieldCondition.ConditionType          =(RequiredFieldName)0;
				}
				else try{
					requiredFieldCondition.ConditionType          =(RequiredFieldName)Enum.Parse(typeof(RequiredFieldName),conditionType);
				}
				catch{
					requiredFieldCondition.ConditionType          =(RequiredFieldName)0;
				}
				requiredFieldCondition.Operator                 = (OpenDentBusiness.ConditionOperator)PIn.Int(row["Operator"].ToString());
				requiredFieldCondition.ConditionValue           = PIn.String(row["ConditionValue"].ToString());
				requiredFieldCondition.ConditionRelationship    = (OpenDentBusiness.LogicalOperator)PIn.Int(row["ConditionRelationship"].ToString());
				retVal.Add(requiredFieldCondition);
			}
			return retVal;
		}

		///<summary>Converts a list of RequiredFieldCondition into a DataTable.</summary>
		public static DataTable ListToTable(List<RequiredFieldCondition> listRequiredFieldConditions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="RequiredFieldCondition";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("RequiredFieldConditionNum");
			table.Columns.Add("RequiredFieldNum");
			table.Columns.Add("ConditionType");
			table.Columns.Add("Operator");
			table.Columns.Add("ConditionValue");
			table.Columns.Add("ConditionRelationship");
			foreach(RequiredFieldCondition requiredFieldCondition in listRequiredFieldConditions) {
				table.Rows.Add(new object[] {
					POut.Long  (requiredFieldCondition.RequiredFieldConditionNum),
					POut.Long  (requiredFieldCondition.RequiredFieldNum),
					POut.Int   ((int)requiredFieldCondition.ConditionType),
					POut.Int   ((int)requiredFieldCondition.Operator),
					POut.String(requiredFieldCondition.ConditionValue),
					POut.Int   ((int)requiredFieldCondition.ConditionRelationship),
				});
			}
			return table;
		}

		///<summary>Inserts one RequiredFieldCondition into the database.  Returns the new priKey.</summary>
		public static long Insert(RequiredFieldCondition requiredFieldCondition){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				requiredFieldCondition.RequiredFieldConditionNum=DbHelper.GetNextOracleKey("requiredfieldcondition","RequiredFieldConditionNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(requiredFieldCondition,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							requiredFieldCondition.RequiredFieldConditionNum++;
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
				return Insert(requiredFieldCondition,false);
			}
		}

		///<summary>Inserts one RequiredFieldCondition into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(RequiredFieldCondition requiredFieldCondition,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				requiredFieldCondition.RequiredFieldConditionNum=ReplicationServers.GetKey("requiredfieldcondition","RequiredFieldConditionNum");
			}
			string command="INSERT INTO requiredfieldcondition (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="RequiredFieldConditionNum,";
			}
			command+="RequiredFieldNum,ConditionType,Operator,ConditionValue,ConditionRelationship) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(requiredFieldCondition.RequiredFieldConditionNum)+",";
			}
			command+=
				     POut.Long  (requiredFieldCondition.RequiredFieldNum)+","
				+"'"+POut.String(requiredFieldCondition.ConditionType.ToString())+"',"
				+    POut.Int   ((int)requiredFieldCondition.Operator)+","
				+"'"+POut.String(requiredFieldCondition.ConditionValue)+"',"
				+    POut.Int   ((int)requiredFieldCondition.ConditionRelationship)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				requiredFieldCondition.RequiredFieldConditionNum=Db.NonQ(command,true);
			}
			return requiredFieldCondition.RequiredFieldConditionNum;
		}

		///<summary>Inserts one RequiredFieldCondition into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(RequiredFieldCondition requiredFieldCondition){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(requiredFieldCondition,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					requiredFieldCondition.RequiredFieldConditionNum=DbHelper.GetNextOracleKey("requiredfieldcondition","RequiredFieldConditionNum"); //Cacheless method
				}
				return InsertNoCache(requiredFieldCondition,true);
			}
		}

		///<summary>Inserts one RequiredFieldCondition into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(RequiredFieldCondition requiredFieldCondition,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO requiredfieldcondition (";
			if(!useExistingPK && isRandomKeys) {
				requiredFieldCondition.RequiredFieldConditionNum=ReplicationServers.GetKeyNoCache("requiredfieldcondition","RequiredFieldConditionNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="RequiredFieldConditionNum,";
			}
			command+="RequiredFieldNum,ConditionType,Operator,ConditionValue,ConditionRelationship) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(requiredFieldCondition.RequiredFieldConditionNum)+",";
			}
			command+=
				     POut.Long  (requiredFieldCondition.RequiredFieldNum)+","
				+"'"+POut.String(requiredFieldCondition.ConditionType.ToString())+"',"
				+    POut.Int   ((int)requiredFieldCondition.Operator)+","
				+"'"+POut.String(requiredFieldCondition.ConditionValue)+"',"
				+    POut.Int   ((int)requiredFieldCondition.ConditionRelationship)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				requiredFieldCondition.RequiredFieldConditionNum=Db.NonQ(command,true);
			}
			return requiredFieldCondition.RequiredFieldConditionNum;
		}

		///<summary>Updates one RequiredFieldCondition in the database.</summary>
		public static void Update(RequiredFieldCondition requiredFieldCondition){
			string command="UPDATE requiredfieldcondition SET "
				+"RequiredFieldNum         =  "+POut.Long  (requiredFieldCondition.RequiredFieldNum)+", "
				+"ConditionType            = '"+POut.String(requiredFieldCondition.ConditionType.ToString())+"', "
				+"Operator                 =  "+POut.Int   ((int)requiredFieldCondition.Operator)+", "
				+"ConditionValue           = '"+POut.String(requiredFieldCondition.ConditionValue)+"', "
				+"ConditionRelationship    =  "+POut.Int   ((int)requiredFieldCondition.ConditionRelationship)+" "
				+"WHERE RequiredFieldConditionNum = "+POut.Long(requiredFieldCondition.RequiredFieldConditionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one RequiredFieldCondition in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(RequiredFieldCondition requiredFieldCondition,RequiredFieldCondition oldRequiredFieldCondition){
			string command="";
			if(requiredFieldCondition.RequiredFieldNum != oldRequiredFieldCondition.RequiredFieldNum) {
				if(command!=""){ command+=",";}
				command+="RequiredFieldNum = "+POut.Long(requiredFieldCondition.RequiredFieldNum)+"";
			}
			if(requiredFieldCondition.ConditionType != oldRequiredFieldCondition.ConditionType) {
				if(command!=""){ command+=",";}
				command+="ConditionType = '"+POut.String(requiredFieldCondition.ConditionType.ToString())+"'";
			}
			if(requiredFieldCondition.Operator != oldRequiredFieldCondition.Operator) {
				if(command!=""){ command+=",";}
				command+="Operator = "+POut.Int   ((int)requiredFieldCondition.Operator)+"";
			}
			if(requiredFieldCondition.ConditionValue != oldRequiredFieldCondition.ConditionValue) {
				if(command!=""){ command+=",";}
				command+="ConditionValue = '"+POut.String(requiredFieldCondition.ConditionValue)+"'";
			}
			if(requiredFieldCondition.ConditionRelationship != oldRequiredFieldCondition.ConditionRelationship) {
				if(command!=""){ command+=",";}
				command+="ConditionRelationship = "+POut.Int   ((int)requiredFieldCondition.ConditionRelationship)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE requiredfieldcondition SET "+command
				+" WHERE RequiredFieldConditionNum = "+POut.Long(requiredFieldCondition.RequiredFieldConditionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(RequiredFieldCondition,RequiredFieldCondition) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(RequiredFieldCondition requiredFieldCondition,RequiredFieldCondition oldRequiredFieldCondition) {
			if(requiredFieldCondition.RequiredFieldNum != oldRequiredFieldCondition.RequiredFieldNum) {
				return true;
			}
			if(requiredFieldCondition.ConditionType != oldRequiredFieldCondition.ConditionType) {
				return true;
			}
			if(requiredFieldCondition.Operator != oldRequiredFieldCondition.Operator) {
				return true;
			}
			if(requiredFieldCondition.ConditionValue != oldRequiredFieldCondition.ConditionValue) {
				return true;
			}
			if(requiredFieldCondition.ConditionRelationship != oldRequiredFieldCondition.ConditionRelationship) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one RequiredFieldCondition from the database.</summary>
		public static void Delete(long requiredFieldConditionNum){
			string command="DELETE FROM requiredfieldcondition "
				+"WHERE RequiredFieldConditionNum = "+POut.Long(requiredFieldConditionNum);
			Db.NonQ(command);
		}

	}
}