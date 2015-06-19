//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EhrLaboratories;

namespace OpenDentBusiness.Crud{
	public class EhrLabSpecimenCrud {
		///<summary>Gets one EhrLabSpecimen object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrLabSpecimen SelectOne(long ehrLabSpecimenNum){
			string command="SELECT * FROM ehrlabspecimen "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenNum);
			List<EhrLabSpecimen> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrLabSpecimen object from the database using a query.</summary>
		public static EhrLabSpecimen SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimen> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrLabSpecimen objects from the database using a query.</summary>
		public static List<EhrLabSpecimen> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimen> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrLabSpecimen> TableToList(DataTable table){
			List<EhrLabSpecimen> retVal=new List<EhrLabSpecimen>();
			EhrLabSpecimen ehrLabSpecimen;
			for(int i=0;i<table.Rows.Count;i++) {
				ehrLabSpecimen=new EhrLabSpecimen();
				ehrLabSpecimen.EhrLabSpecimenNum            = PIn.Long  (table.Rows[i]["EhrLabSpecimenNum"].ToString());
				ehrLabSpecimen.EhrLabNum                    = PIn.Long  (table.Rows[i]["EhrLabNum"].ToString());
				ehrLabSpecimen.SetIdSPM                     = PIn.Long  (table.Rows[i]["SetIdSPM"].ToString());
				ehrLabSpecimen.SpecimenTypeID               = PIn.String(table.Rows[i]["SpecimenTypeID"].ToString());
				ehrLabSpecimen.SpecimenTypeText             = PIn.String(table.Rows[i]["SpecimenTypeText"].ToString());
				ehrLabSpecimen.SpecimenTypeCodeSystemName   = PIn.String(table.Rows[i]["SpecimenTypeCodeSystemName"].ToString());
				ehrLabSpecimen.SpecimenTypeIDAlt            = PIn.String(table.Rows[i]["SpecimenTypeIDAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeTextAlt          = PIn.String(table.Rows[i]["SpecimenTypeTextAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt= PIn.String(table.Rows[i]["SpecimenTypeCodeSystemNameAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeTextOriginal     = PIn.String(table.Rows[i]["SpecimenTypeTextOriginal"].ToString());
				ehrLabSpecimen.CollectionDateTimeStart      = PIn.String(table.Rows[i]["CollectionDateTimeStart"].ToString());
				ehrLabSpecimen.CollectionDateTimeEnd        = PIn.String(table.Rows[i]["CollectionDateTimeEnd"].ToString());
				retVal.Add(ehrLabSpecimen);
			}
			return retVal;
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrLabSpecimen ehrLabSpecimen){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrLabSpecimen.EhrLabSpecimenNum=DbHelper.GetNextOracleKey("ehrlabspecimen","EhrLabSpecimenNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrLabSpecimen,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrLabSpecimen.EhrLabSpecimenNum++;
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
				return Insert(ehrLabSpecimen,false);
			}
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrLabSpecimen ehrLabSpecimen,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrLabSpecimen.EhrLabSpecimenNum=ReplicationServers.GetKey("ehrlabspecimen","EhrLabSpecimenNum");
			}
			string command="INSERT INTO ehrlabspecimen (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrLabSpecimenNum,";
			}
			command+="EhrLabNum,SetIdSPM,SpecimenTypeID,SpecimenTypeText,SpecimenTypeCodeSystemName,SpecimenTypeIDAlt,SpecimenTypeTextAlt,SpecimenTypeCodeSystemNameAlt,SpecimenTypeTextOriginal,CollectionDateTimeStart,CollectionDateTimeEnd) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrLabSpecimen.EhrLabSpecimenNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimen.EhrLabNum)+","
				+    POut.Long  (ehrLabSpecimen.SetIdSPM)+","
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabSpecimen.EhrLabSpecimenNum=Db.NonQ(command,true);
			}
			return ehrLabSpecimen.EhrLabSpecimenNum;
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabSpecimen ehrLabSpecimen){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(ehrLabSpecimen,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					ehrLabSpecimen.EhrLabSpecimenNum=DbHelper.GetNextOracleKey("ehrlabspecimen","EhrLabSpecimenNum"); //Cacheless method
				}
				return InsertNoCache(ehrLabSpecimen,true);
			}
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabSpecimen ehrLabSpecimen,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO ehrlabspecimen (";
			if(!useExistingPK && isRandomKeys) {
				ehrLabSpecimen.EhrLabSpecimenNum=ReplicationServers.GetKeyNoCache("ehrlabspecimen","EhrLabSpecimenNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EhrLabSpecimenNum,";
			}
			command+="EhrLabNum,SetIdSPM,SpecimenTypeID,SpecimenTypeText,SpecimenTypeCodeSystemName,SpecimenTypeIDAlt,SpecimenTypeTextAlt,SpecimenTypeCodeSystemNameAlt,SpecimenTypeTextOriginal,CollectionDateTimeStart,CollectionDateTimeEnd) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(ehrLabSpecimen.EhrLabSpecimenNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimen.EhrLabNum)+","
				+    POut.Long  (ehrLabSpecimen.SetIdSPM)+","
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabSpecimen.EhrLabSpecimenNum=Db.NonQ(command,true);
			}
			return ehrLabSpecimen.EhrLabSpecimenNum;
		}

		///<summary>Updates one EhrLabSpecimen in the database.</summary>
		public static void Update(EhrLabSpecimen ehrLabSpecimen){
			string command="UPDATE ehrlabspecimen SET "
				+"EhrLabNum                    =  "+POut.Long  (ehrLabSpecimen.EhrLabNum)+", "
				+"SetIdSPM                     =  "+POut.Long  (ehrLabSpecimen.SetIdSPM)+", "
				+"SpecimenTypeID               = '"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"', "
				+"SpecimenTypeText             = '"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"', "
				+"SpecimenTypeCodeSystemName   = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"', "
				+"SpecimenTypeIDAlt            = '"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"', "
				+"SpecimenTypeTextAlt          = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"', "
				+"SpecimenTypeCodeSystemNameAlt= '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"', "
				+"SpecimenTypeTextOriginal     = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"', "
				+"CollectionDateTimeStart      = '"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"', "
				+"CollectionDateTimeEnd        = '"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"' "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimen.EhrLabSpecimenNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrLabSpecimen in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrLabSpecimen ehrLabSpecimen,EhrLabSpecimen oldEhrLabSpecimen){
			string command="";
			if(ehrLabSpecimen.EhrLabNum != oldEhrLabSpecimen.EhrLabNum) {
				if(command!=""){ command+=",";}
				command+="EhrLabNum = "+POut.Long(ehrLabSpecimen.EhrLabNum)+"";
			}
			if(ehrLabSpecimen.SetIdSPM != oldEhrLabSpecimen.SetIdSPM) {
				if(command!=""){ command+=",";}
				command+="SetIdSPM = "+POut.Long(ehrLabSpecimen.SetIdSPM)+"";
			}
			if(ehrLabSpecimen.SpecimenTypeID != oldEhrLabSpecimen.SpecimenTypeID) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeID = '"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeText != oldEhrLabSpecimen.SpecimenTypeText) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeText = '"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemName != oldEhrLabSpecimen.SpecimenTypeCodeSystemName) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeCodeSystemName = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeIDAlt != oldEhrLabSpecimen.SpecimenTypeIDAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeIDAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeTextAlt != oldEhrLabSpecimen.SpecimenTypeTextAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeTextAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt != oldEhrLabSpecimen.SpecimenTypeCodeSystemNameAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeCodeSystemNameAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeTextOriginal != oldEhrLabSpecimen.SpecimenTypeTextOriginal) {
				if(command!=""){ command+=",";}
				command+="SpecimenTypeTextOriginal = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"'";
			}
			if(ehrLabSpecimen.CollectionDateTimeStart != oldEhrLabSpecimen.CollectionDateTimeStart) {
				if(command!=""){ command+=",";}
				command+="CollectionDateTimeStart = '"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"'";
			}
			if(ehrLabSpecimen.CollectionDateTimeEnd != oldEhrLabSpecimen.CollectionDateTimeEnd) {
				if(command!=""){ command+=",";}
				command+="CollectionDateTimeEnd = '"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrlabspecimen SET "+command
				+" WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimen.EhrLabSpecimenNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EhrLabSpecimen from the database.</summary>
		public static void Delete(long ehrLabSpecimenNum){
			string command="DELETE FROM ehrlabspecimen "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenNum);
			Db.NonQ(command);
		}

	}
}