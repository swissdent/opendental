//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EhrLaboratories;

namespace OpenDentBusiness.Crud{
	public class EhrLabSpecimenConditionCrud {
		///<summary>Gets one EhrLabSpecimenCondition object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrLabSpecimenCondition SelectOne(long ehrLabSpecimenConditionNum){
			string command="SELECT * FROM ehrlabspecimencondition "
				+"WHERE EhrLabSpecimenConditionNum = "+POut.Long(ehrLabSpecimenConditionNum);
			List<EhrLabSpecimenCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrLabSpecimenCondition object from the database using a query.</summary>
		public static EhrLabSpecimenCondition SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimenCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrLabSpecimenCondition objects from the database using a query.</summary>
		public static List<EhrLabSpecimenCondition> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimenCondition> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrLabSpecimenCondition> TableToList(DataTable table){
			List<EhrLabSpecimenCondition> retVal=new List<EhrLabSpecimenCondition>();
			EhrLabSpecimenCondition ehrLabSpecimenCondition;
			for(int i=0;i<table.Rows.Count;i++) {
				ehrLabSpecimenCondition=new EhrLabSpecimenCondition();
				ehrLabSpecimenCondition.EhrLabSpecimenConditionNum        = PIn.Long  (table.Rows[i]["EhrLabSpecimenConditionNum"].ToString());
				ehrLabSpecimenCondition.EhrLabSpecimenNum                 = PIn.Long  (table.Rows[i]["EhrLabSpecimenNum"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionID               = PIn.String(table.Rows[i]["SpecimenConditionID"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionText             = PIn.String(table.Rows[i]["SpecimenConditionText"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionCodeSystemName   = PIn.String(table.Rows[i]["SpecimenConditionCodeSystemName"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionIDAlt            = PIn.String(table.Rows[i]["SpecimenConditionIDAlt"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionTextAlt          = PIn.String(table.Rows[i]["SpecimenConditionTextAlt"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt= PIn.String(table.Rows[i]["SpecimenConditionCodeSystemNameAlt"].ToString());
				ehrLabSpecimenCondition.SpecimenConditionTextOriginal     = PIn.String(table.Rows[i]["SpecimenConditionTextOriginal"].ToString());
				retVal.Add(ehrLabSpecimenCondition);
			}
			return retVal;
		}

		///<summary>Inserts one EhrLabSpecimenCondition into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrLabSpecimenCondition ehrLabSpecimenCondition){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrLabSpecimenCondition.EhrLabSpecimenConditionNum=DbHelper.GetNextOracleKey("ehrlabspecimencondition","EhrLabSpecimenConditionNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrLabSpecimenCondition,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrLabSpecimenCondition.EhrLabSpecimenConditionNum++;
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
				return Insert(ehrLabSpecimenCondition,false);
			}
		}

		///<summary>Inserts one EhrLabSpecimenCondition into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrLabSpecimenCondition ehrLabSpecimenCondition,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrLabSpecimenCondition.EhrLabSpecimenConditionNum=ReplicationServers.GetKey("ehrlabspecimencondition","EhrLabSpecimenConditionNum");
			}
			string command="INSERT INTO ehrlabspecimencondition (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrLabSpecimenConditionNum,";
			}
			command+="EhrLabSpecimenNum,SpecimenConditionID,SpecimenConditionText,SpecimenConditionCodeSystemName,SpecimenConditionIDAlt,SpecimenConditionTextAlt,SpecimenConditionCodeSystemNameAlt,SpecimenConditionTextOriginal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrLabSpecimenCondition.EhrLabSpecimenConditionNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimenCondition.EhrLabSpecimenNum)+","
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionID)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionText)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextOriginal)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabSpecimenCondition.EhrLabSpecimenConditionNum=Db.NonQ(command,true);
			}
			return ehrLabSpecimenCondition.EhrLabSpecimenConditionNum;
		}

		///<summary>Updates one EhrLabSpecimenCondition in the database.</summary>
		public static void Update(EhrLabSpecimenCondition ehrLabSpecimenCondition){
			string command="UPDATE ehrlabspecimencondition SET "
				+"EhrLabSpecimenNum                 =  "+POut.Long  (ehrLabSpecimenCondition.EhrLabSpecimenNum)+", "
				+"SpecimenConditionID               = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionID)+"', "
				+"SpecimenConditionText             = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionText)+"', "
				+"SpecimenConditionCodeSystemName   = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemName)+"', "
				+"SpecimenConditionIDAlt            = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionIDAlt)+"', "
				+"SpecimenConditionTextAlt          = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextAlt)+"', "
				+"SpecimenConditionCodeSystemNameAlt= '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt)+"', "
				+"SpecimenConditionTextOriginal     = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextOriginal)+"' "
				+"WHERE EhrLabSpecimenConditionNum = "+POut.Long(ehrLabSpecimenCondition.EhrLabSpecimenConditionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrLabSpecimenCondition in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrLabSpecimenCondition ehrLabSpecimenCondition,EhrLabSpecimenCondition oldEhrLabSpecimenCondition){
			string command="";
			if(ehrLabSpecimenCondition.EhrLabSpecimenNum != oldEhrLabSpecimenCondition.EhrLabSpecimenNum) {
				if(command!=""){ command+=",";}
				command+="EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenCondition.EhrLabSpecimenNum)+"";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionID != oldEhrLabSpecimenCondition.SpecimenConditionID) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionID = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionID)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionText != oldEhrLabSpecimenCondition.SpecimenConditionText) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionText = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionText)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionCodeSystemName != oldEhrLabSpecimenCondition.SpecimenConditionCodeSystemName) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionCodeSystemName = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemName)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionIDAlt != oldEhrLabSpecimenCondition.SpecimenConditionIDAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionIDAlt = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionIDAlt)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionTextAlt != oldEhrLabSpecimenCondition.SpecimenConditionTextAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionTextAlt = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextAlt)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt != oldEhrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionCodeSystemNameAlt = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionCodeSystemNameAlt)+"'";
			}
			if(ehrLabSpecimenCondition.SpecimenConditionTextOriginal != oldEhrLabSpecimenCondition.SpecimenConditionTextOriginal) {
				if(command!=""){ command+=",";}
				command+="SpecimenConditionTextOriginal = '"+POut.String(ehrLabSpecimenCondition.SpecimenConditionTextOriginal)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrlabspecimencondition SET "+command
				+" WHERE EhrLabSpecimenConditionNum = "+POut.Long(ehrLabSpecimenCondition.EhrLabSpecimenConditionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EhrLabSpecimenCondition from the database.</summary>
		public static void Delete(long ehrLabSpecimenConditionNum){
			string command="DELETE FROM ehrlabspecimencondition "
				+"WHERE EhrLabSpecimenConditionNum = "+POut.Long(ehrLabSpecimenConditionNum);
			Db.NonQ(command);
		}

	}
}