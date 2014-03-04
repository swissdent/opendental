//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EhrLaboratories;

namespace OpenDentBusiness.Crud{
	public class EhrLabSpecimenRejectReasonCrud {
		///<summary>Gets one EhrLabSpecimenRejectReason object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrLabSpecimenRejectReason SelectOne(long ehrLabSpecimenRejectReasonNum){
			string command="SELECT * FROM ehrlabspecimenrejectreason "
				+"WHERE EhrLabSpecimenRejectReasonNum = "+POut.Long(ehrLabSpecimenRejectReasonNum);
			List<EhrLabSpecimenRejectReason> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrLabSpecimenRejectReason object from the database using a query.</summary>
		public static EhrLabSpecimenRejectReason SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimenRejectReason> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrLabSpecimenRejectReason objects from the database using a query.</summary>
		public static List<EhrLabSpecimenRejectReason> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrLabSpecimenRejectReason> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrLabSpecimenRejectReason> TableToList(DataTable table){
			List<EhrLabSpecimenRejectReason> retVal=new List<EhrLabSpecimenRejectReason>();
			EhrLabSpecimenRejectReason ehrLabSpecimenRejectReason;
			for(int i=0;i<table.Rows.Count;i++) {
				ehrLabSpecimenRejectReason=new EhrLabSpecimenRejectReason();
				ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum        = PIn.Long  (table.Rows[i]["EhrLabSpecimenRejectReasonNum"].ToString());
				ehrLabSpecimenRejectReason.EhrLabSpecimenNum                    = PIn.Long  (table.Rows[i]["EhrLabSpecimenNum"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonID               = PIn.String(table.Rows[i]["SpecimenRejectReasonID"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonText             = PIn.String(table.Rows[i]["SpecimenRejectReasonText"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName   = PIn.String(table.Rows[i]["SpecimenRejectReasonCodeSystemName"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt            = PIn.String(table.Rows[i]["SpecimenRejectReasonIDAlt"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt          = PIn.String(table.Rows[i]["SpecimenRejectReasonTextAlt"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt= PIn.String(table.Rows[i]["SpecimenRejectReasonCodeSystemNameAlt"].ToString());
				ehrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal     = PIn.String(table.Rows[i]["SpecimenRejectReasonTextOriginal"].ToString());
				retVal.Add(ehrLabSpecimenRejectReason);
			}
			return retVal;
		}

		///<summary>Inserts one EhrLabSpecimenRejectReason into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrLabSpecimenRejectReason ehrLabSpecimenRejectReason){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum=DbHelper.GetNextOracleKey("ehrlabspecimenrejectreason","EhrLabSpecimenRejectReasonNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrLabSpecimenRejectReason,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum++;
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
				return Insert(ehrLabSpecimenRejectReason,false);
			}
		}

		///<summary>Inserts one EhrLabSpecimenRejectReason into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrLabSpecimenRejectReason ehrLabSpecimenRejectReason,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum=ReplicationServers.GetKey("ehrlabspecimenrejectreason","EhrLabSpecimenRejectReasonNum");
			}
			string command="INSERT INTO ehrlabspecimenrejectreason (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrLabSpecimenRejectReasonNum,";
			}
			command+="EhrLabSpecimenNum,SpecimenRejectReasonID,SpecimenRejectReasonText,SpecimenRejectReasonCodeSystemName,SpecimenRejectReasonIDAlt,SpecimenRejectReasonTextAlt,SpecimenRejectReasonCodeSystemNameAlt,SpecimenRejectReasonTextOriginal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimenRejectReason.EhrLabSpecimenNum)+","
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonID)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonText)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum=Db.NonQ(command,true);
			}
			return ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum;
		}

		///<summary>Updates one EhrLabSpecimenRejectReason in the database.</summary>
		public static void Update(EhrLabSpecimenRejectReason ehrLabSpecimenRejectReason){
			string command="UPDATE ehrlabspecimenrejectreason SET "
				+"EhrLabSpecimenNum                    =  "+POut.Long  (ehrLabSpecimenRejectReason.EhrLabSpecimenNum)+", "
				+"SpecimenRejectReasonID               = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonID)+"', "
				+"SpecimenRejectReasonText             = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonText)+"', "
				+"SpecimenRejectReasonCodeSystemName   = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName)+"', "
				+"SpecimenRejectReasonIDAlt            = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt)+"', "
				+"SpecimenRejectReasonTextAlt          = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt)+"', "
				+"SpecimenRejectReasonCodeSystemNameAlt= '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt)+"', "
				+"SpecimenRejectReasonTextOriginal     = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal)+"' "
				+"WHERE EhrLabSpecimenRejectReasonNum = "+POut.Long(ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrLabSpecimenRejectReason in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrLabSpecimenRejectReason ehrLabSpecimenRejectReason,EhrLabSpecimenRejectReason oldEhrLabSpecimenRejectReason){
			string command="";
			if(ehrLabSpecimenRejectReason.EhrLabSpecimenNum != oldEhrLabSpecimenRejectReason.EhrLabSpecimenNum) {
				if(command!=""){ command+=",";}
				command+="EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenRejectReason.EhrLabSpecimenNum)+"";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonID != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonID) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonID = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonID)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonText != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonText) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonText = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonText)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonCodeSystemName = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemName)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonIDAlt = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonIDAlt)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonTextAlt = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextAlt)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonCodeSystemNameAlt = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonCodeSystemNameAlt)+"'";
			}
			if(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal != oldEhrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal) {
				if(command!=""){ command+=",";}
				command+="SpecimenRejectReasonTextOriginal = '"+POut.String(ehrLabSpecimenRejectReason.SpecimenRejectReasonTextOriginal)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrlabspecimenrejectreason SET "+command
				+" WHERE EhrLabSpecimenRejectReasonNum = "+POut.Long(ehrLabSpecimenRejectReason.EhrLabSpecimenRejectReasonNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EhrLabSpecimenRejectReason from the database.</summary>
		public static void Delete(long ehrLabSpecimenRejectReasonNum){
			string command="DELETE FROM ehrlabspecimenrejectreason "
				+"WHERE EhrLabSpecimenRejectReasonNum = "+POut.Long(ehrLabSpecimenRejectReasonNum);
			Db.NonQ(command);
		}

	}
}