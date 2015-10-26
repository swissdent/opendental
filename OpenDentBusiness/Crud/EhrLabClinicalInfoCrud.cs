//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EhrLaboratories;

namespace OpenDentBusiness.Crud{
	public class EhrLabClinicalInfoCrud {
		///<summary>Gets one EhrLabClinicalInfo object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrLabClinicalInfo SelectOne(long ehrLabClinicalInfoNum){
			string command="SELECT * FROM ehrlabclinicalinfo "
				+"WHERE EhrLabClinicalInfoNum = "+POut.Long(ehrLabClinicalInfoNum);
			List<EhrLabClinicalInfo> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrLabClinicalInfo object from the database using a query.</summary>
		public static EhrLabClinicalInfo SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabClinicalInfo> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrLabClinicalInfo objects from the database using a query.</summary>
		public static List<EhrLabClinicalInfo> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabClinicalInfo> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrLabClinicalInfo> TableToList(DataTable table){
			List<EhrLabClinicalInfo> retVal=new List<EhrLabClinicalInfo>();
			EhrLabClinicalInfo ehrLabClinicalInfo;
			foreach(DataRow row in table.Rows) {
				ehrLabClinicalInfo=new EhrLabClinicalInfo();
				ehrLabClinicalInfo.EhrLabClinicalInfoNum        = PIn.Long  (row["EhrLabClinicalInfoNum"].ToString());
				ehrLabClinicalInfo.EhrLabNum                    = PIn.Long  (row["EhrLabNum"].ToString());
				ehrLabClinicalInfo.ClinicalInfoID               = PIn.String(row["ClinicalInfoID"].ToString());
				ehrLabClinicalInfo.ClinicalInfoText             = PIn.String(row["ClinicalInfoText"].ToString());
				ehrLabClinicalInfo.ClinicalInfoCodeSystemName   = PIn.String(row["ClinicalInfoCodeSystemName"].ToString());
				ehrLabClinicalInfo.ClinicalInfoIDAlt            = PIn.String(row["ClinicalInfoIDAlt"].ToString());
				ehrLabClinicalInfo.ClinicalInfoTextAlt          = PIn.String(row["ClinicalInfoTextAlt"].ToString());
				ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt= PIn.String(row["ClinicalInfoCodeSystemNameAlt"].ToString());
				ehrLabClinicalInfo.ClinicalInfoTextOriginal     = PIn.String(row["ClinicalInfoTextOriginal"].ToString());
				retVal.Add(ehrLabClinicalInfo);
			}
			return retVal;
		}

		///<summary>Inserts one EhrLabClinicalInfo into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrLabClinicalInfo ehrLabClinicalInfo){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrLabClinicalInfo.EhrLabClinicalInfoNum=DbHelper.GetNextOracleKey("ehrlabclinicalinfo","EhrLabClinicalInfoNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrLabClinicalInfo,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrLabClinicalInfo.EhrLabClinicalInfoNum++;
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
				return Insert(ehrLabClinicalInfo,false);
			}
		}

		///<summary>Inserts one EhrLabClinicalInfo into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrLabClinicalInfo ehrLabClinicalInfo,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrLabClinicalInfo.EhrLabClinicalInfoNum=ReplicationServers.GetKey("ehrlabclinicalinfo","EhrLabClinicalInfoNum");
			}
			string command="INSERT INTO ehrlabclinicalinfo (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrLabClinicalInfoNum,";
			}
			command+="EhrLabNum,ClinicalInfoID,ClinicalInfoText,ClinicalInfoCodeSystemName,ClinicalInfoIDAlt,ClinicalInfoTextAlt,ClinicalInfoCodeSystemNameAlt,ClinicalInfoTextOriginal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrLabClinicalInfo.EhrLabClinicalInfoNum)+",";
			}
			command+=
				     POut.Long  (ehrLabClinicalInfo.EhrLabNum)+","
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoID)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoText)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemName)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoIDAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextOriginal)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabClinicalInfo.EhrLabClinicalInfoNum=Db.NonQ(command,true);
			}
			return ehrLabClinicalInfo.EhrLabClinicalInfoNum;
		}

		///<summary>Inserts one EhrLabClinicalInfo into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabClinicalInfo ehrLabClinicalInfo){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(ehrLabClinicalInfo,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					ehrLabClinicalInfo.EhrLabClinicalInfoNum=DbHelper.GetNextOracleKey("ehrlabclinicalinfo","EhrLabClinicalInfoNum"); //Cacheless method
				}
				return InsertNoCache(ehrLabClinicalInfo,true);
			}
		}

		///<summary>Inserts one EhrLabClinicalInfo into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabClinicalInfo ehrLabClinicalInfo,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO ehrlabclinicalinfo (";
			if(!useExistingPK && isRandomKeys) {
				ehrLabClinicalInfo.EhrLabClinicalInfoNum=ReplicationServers.GetKeyNoCache("ehrlabclinicalinfo","EhrLabClinicalInfoNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EhrLabClinicalInfoNum,";
			}
			command+="EhrLabNum,ClinicalInfoID,ClinicalInfoText,ClinicalInfoCodeSystemName,ClinicalInfoIDAlt,ClinicalInfoTextAlt,ClinicalInfoCodeSystemNameAlt,ClinicalInfoTextOriginal) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(ehrLabClinicalInfo.EhrLabClinicalInfoNum)+",";
			}
			command+=
				     POut.Long  (ehrLabClinicalInfo.EhrLabNum)+","
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoID)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoText)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemName)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoIDAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextOriginal)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabClinicalInfo.EhrLabClinicalInfoNum=Db.NonQ(command,true);
			}
			return ehrLabClinicalInfo.EhrLabClinicalInfoNum;
		}

		///<summary>Updates one EhrLabClinicalInfo in the database.</summary>
		public static void Update(EhrLabClinicalInfo ehrLabClinicalInfo){
			string command="UPDATE ehrlabclinicalinfo SET "
				+"EhrLabNum                    =  "+POut.Long  (ehrLabClinicalInfo.EhrLabNum)+", "
				+"ClinicalInfoID               = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoID)+"', "
				+"ClinicalInfoText             = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoText)+"', "
				+"ClinicalInfoCodeSystemName   = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemName)+"', "
				+"ClinicalInfoIDAlt            = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoIDAlt)+"', "
				+"ClinicalInfoTextAlt          = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextAlt)+"', "
				+"ClinicalInfoCodeSystemNameAlt= '"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt)+"', "
				+"ClinicalInfoTextOriginal     = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextOriginal)+"' "
				+"WHERE EhrLabClinicalInfoNum = "+POut.Long(ehrLabClinicalInfo.EhrLabClinicalInfoNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrLabClinicalInfo in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrLabClinicalInfo ehrLabClinicalInfo,EhrLabClinicalInfo oldEhrLabClinicalInfo){
			string command="";
			if(ehrLabClinicalInfo.EhrLabNum != oldEhrLabClinicalInfo.EhrLabNum) {
				if(command!=""){ command+=",";}
				command+="EhrLabNum = "+POut.Long(ehrLabClinicalInfo.EhrLabNum)+"";
			}
			if(ehrLabClinicalInfo.ClinicalInfoID != oldEhrLabClinicalInfo.ClinicalInfoID) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoID = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoID)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoText != oldEhrLabClinicalInfo.ClinicalInfoText) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoText = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoText)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoCodeSystemName != oldEhrLabClinicalInfo.ClinicalInfoCodeSystemName) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoCodeSystemName = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemName)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoIDAlt != oldEhrLabClinicalInfo.ClinicalInfoIDAlt) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoIDAlt = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoIDAlt)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoTextAlt != oldEhrLabClinicalInfo.ClinicalInfoTextAlt) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoTextAlt = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextAlt)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt != oldEhrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoCodeSystemNameAlt = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoCodeSystemNameAlt)+"'";
			}
			if(ehrLabClinicalInfo.ClinicalInfoTextOriginal != oldEhrLabClinicalInfo.ClinicalInfoTextOriginal) {
				if(command!=""){ command+=",";}
				command+="ClinicalInfoTextOriginal = '"+POut.String(ehrLabClinicalInfo.ClinicalInfoTextOriginal)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrlabclinicalinfo SET "+command
				+" WHERE EhrLabClinicalInfoNum = "+POut.Long(ehrLabClinicalInfo.EhrLabClinicalInfoNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EhrLabClinicalInfo from the database.</summary>
		public static void Delete(long ehrLabClinicalInfoNum){
			string command="DELETE FROM ehrlabclinicalinfo "
				+"WHERE EhrLabClinicalInfoNum = "+POut.Long(ehrLabClinicalInfoNum);
			Db.NonQ(command);
		}

	}
}