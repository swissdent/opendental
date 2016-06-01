//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ConfirmationRequestCrud {
		///<summary>Gets one ConfirmationRequest object from the database using the primary key.  Returns null if not found.</summary>
		public static ConfirmationRequest SelectOne(long confirmationRequestNum){
			string command="SELECT * FROM confirmationrequest "
				+"WHERE ConfirmationRequestNum = "+POut.Long(confirmationRequestNum);
			List<ConfirmationRequest> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ConfirmationRequest object from the database using a query.</summary>
		public static ConfirmationRequest SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ConfirmationRequest> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ConfirmationRequest objects from the database using a query.</summary>
		public static List<ConfirmationRequest> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ConfirmationRequest> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ConfirmationRequest> TableToList(DataTable table){
			List<ConfirmationRequest> retVal=new List<ConfirmationRequest>();
			ConfirmationRequest confirmationRequest;
			foreach(DataRow row in table.Rows) {
				confirmationRequest=new ConfirmationRequest();
				confirmationRequest.ConfirmationRequestNum  = PIn.Long  (row["ConfirmationRequestNum"].ToString());
				confirmationRequest.ClinicNum               = PIn.Long  (row["ClinicNum"].ToString());
				confirmationRequest.IsForSms                = PIn.Bool  (row["IsForSms"].ToString());
				confirmationRequest.PatNum                  = PIn.Long  (row["PatNum"].ToString());
				confirmationRequest.ApptNum                 = PIn.Long  (row["ApptNum"].ToString());
				confirmationRequest.PhonePat                = PIn.String(row["PhonePat"].ToString());
				confirmationRequest.DateTimeConfirmExpire   = PIn.DateT (row["DateTimeConfirmExpire"].ToString());
				confirmationRequest.SecondsFromEntryToExpire= PIn.Int   (row["SecondsFromEntryToExpire"].ToString());
				confirmationRequest.ShortGUID               = PIn.String(row["ShortGUID"].ToString());
				confirmationRequest.ConfirmCode             = PIn.String(row["ConfirmCode"].ToString());
				confirmationRequest.MsgTextToMobileTemplate = PIn.String(row["MsgTextToMobileTemplate"].ToString());
				confirmationRequest.MsgTextToMobile         = PIn.String(row["MsgTextToMobile"].ToString());
				confirmationRequest.DateTimeEntry           = PIn.DateT (row["DateTimeEntry"].ToString());
				confirmationRequest.DateTimeConfirmTransmit = PIn.DateT (row["DateTimeConfirmTransmit"].ToString());
				confirmationRequest.DateTimeRSVP            = PIn.DateT (row["DateTimeRSVP"].ToString());
				confirmationRequest.RSVPStatus              = (OpenDentBusiness.RSVPStatusCodes)PIn.Int(row["RSVPStatus"].ToString());
				confirmationRequest.ResponseDescript        = PIn.String(row["ResponseDescript"].ToString());
				confirmationRequest.GuidMessageToMobile     = PIn.String(row["GuidMessageToMobile"].ToString());
				retVal.Add(confirmationRequest);
			}
			return retVal;
		}

		///<summary>Converts a list of ConfirmationRequest into a DataTable.</summary>
		public static DataTable ListToTable(List<ConfirmationRequest> listConfirmationRequests,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ConfirmationRequest";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ConfirmationRequestNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("IsForSms");
			table.Columns.Add("PatNum");
			table.Columns.Add("ApptNum");
			table.Columns.Add("PhonePat");
			table.Columns.Add("DateTimeConfirmExpire");
			table.Columns.Add("SecondsFromEntryToExpire");
			table.Columns.Add("ShortGUID");
			table.Columns.Add("ConfirmCode");
			table.Columns.Add("MsgTextToMobileTemplate");
			table.Columns.Add("MsgTextToMobile");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("DateTimeConfirmTransmit");
			table.Columns.Add("DateTimeRSVP");
			table.Columns.Add("RSVPStatus");
			table.Columns.Add("ResponseDescript");
			table.Columns.Add("GuidMessageToMobile");
			foreach(ConfirmationRequest confirmationRequest in listConfirmationRequests) {
				table.Rows.Add(new object[] {
					POut.Long  (confirmationRequest.ConfirmationRequestNum),
					POut.Long  (confirmationRequest.ClinicNum),
					POut.Bool  (confirmationRequest.IsForSms),
					POut.Long  (confirmationRequest.PatNum),
					POut.Long  (confirmationRequest.ApptNum),
					            confirmationRequest.PhonePat,
					POut.DateT (confirmationRequest.DateTimeConfirmExpire,false),
					POut.Int   (confirmationRequest.SecondsFromEntryToExpire),
					            confirmationRequest.ShortGUID,
					            confirmationRequest.ConfirmCode,
					            confirmationRequest.MsgTextToMobileTemplate,
					            confirmationRequest.MsgTextToMobile,
					POut.DateT (confirmationRequest.DateTimeEntry,false),
					POut.DateT (confirmationRequest.DateTimeConfirmTransmit,false),
					POut.DateT (confirmationRequest.DateTimeRSVP,false),
					POut.Int   ((int)confirmationRequest.RSVPStatus),
					            confirmationRequest.ResponseDescript,
					            confirmationRequest.GuidMessageToMobile,
				});
			}
			return table;
		}

		///<summary>Inserts one ConfirmationRequest into the database.  Returns the new priKey.</summary>
		public static long Insert(ConfirmationRequest confirmationRequest){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				confirmationRequest.ConfirmationRequestNum=DbHelper.GetNextOracleKey("confirmationrequest","ConfirmationRequestNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(confirmationRequest,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							confirmationRequest.ConfirmationRequestNum++;
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
				return Insert(confirmationRequest,false);
			}
		}

		///<summary>Inserts one ConfirmationRequest into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ConfirmationRequest confirmationRequest,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				confirmationRequest.ConfirmationRequestNum=ReplicationServers.GetKey("confirmationrequest","ConfirmationRequestNum");
			}
			string command="INSERT INTO confirmationrequest (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ConfirmationRequestNum,";
			}
			command+="ClinicNum,IsForSms,PatNum,ApptNum,PhonePat,DateTimeConfirmExpire,SecondsFromEntryToExpire,ShortGUID,ConfirmCode,MsgTextToMobileTemplate,MsgTextToMobile,DateTimeEntry,DateTimeConfirmTransmit,DateTimeRSVP,RSVPStatus,ResponseDescript,GuidMessageToMobile) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(confirmationRequest.ConfirmationRequestNum)+",";
			}
			command+=
				     POut.Long  (confirmationRequest.ClinicNum)+","
				+    POut.Bool  (confirmationRequest.IsForSms)+","
				+    POut.Long  (confirmationRequest.PatNum)+","
				+    POut.Long  (confirmationRequest.ApptNum)+","
				+"'"+POut.String(confirmationRequest.PhonePat)+"',"
				+    POut.DateT (confirmationRequest.DateTimeConfirmExpire)+","
				+    POut.Int   (confirmationRequest.SecondsFromEntryToExpire)+","
				+"'"+POut.String(confirmationRequest.ShortGUID)+"',"
				+"'"+POut.String(confirmationRequest.ConfirmCode)+"',"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.Now()+","
				+    POut.DateT (confirmationRequest.DateTimeConfirmTransmit)+","
				+    POut.DateT (confirmationRequest.DateTimeRSVP)+","
				+    POut.Int   ((int)confirmationRequest.RSVPStatus)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile)";
			if(confirmationRequest.MsgTextToMobileTemplate==null) {
				confirmationRequest.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,confirmationRequest.MsgTextToMobileTemplate);
			if(confirmationRequest.MsgTextToMobile==null) {
				confirmationRequest.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,confirmationRequest.MsgTextToMobile);
			if(confirmationRequest.ResponseDescript==null) {
				confirmationRequest.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,confirmationRequest.ResponseDescript);
			if(confirmationRequest.GuidMessageToMobile==null) {
				confirmationRequest.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringNote(confirmationRequest.GuidMessageToMobile));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
			}
			else {
				confirmationRequest.ConfirmationRequestNum=Db.NonQ(command,true,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
			}
			return confirmationRequest.ConfirmationRequestNum;
		}

		///<summary>Inserts one ConfirmationRequest into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ConfirmationRequest confirmationRequest){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(confirmationRequest,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					confirmationRequest.ConfirmationRequestNum=DbHelper.GetNextOracleKey("confirmationrequest","ConfirmationRequestNum"); //Cacheless method
				}
				return InsertNoCache(confirmationRequest,true);
			}
		}

		///<summary>Inserts one ConfirmationRequest into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ConfirmationRequest confirmationRequest,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO confirmationrequest (";
			if(!useExistingPK && isRandomKeys) {
				confirmationRequest.ConfirmationRequestNum=ReplicationServers.GetKeyNoCache("confirmationrequest","ConfirmationRequestNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ConfirmationRequestNum,";
			}
			command+="ClinicNum,IsForSms,PatNum,ApptNum,PhonePat,DateTimeConfirmExpire,SecondsFromEntryToExpire,ShortGUID,ConfirmCode,MsgTextToMobileTemplate,MsgTextToMobile,DateTimeEntry,DateTimeConfirmTransmit,DateTimeRSVP,RSVPStatus,ResponseDescript,GuidMessageToMobile) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(confirmationRequest.ConfirmationRequestNum)+",";
			}
			command+=
				     POut.Long  (confirmationRequest.ClinicNum)+","
				+    POut.Bool  (confirmationRequest.IsForSms)+","
				+    POut.Long  (confirmationRequest.PatNum)+","
				+    POut.Long  (confirmationRequest.ApptNum)+","
				+"'"+POut.String(confirmationRequest.PhonePat)+"',"
				+    POut.DateT (confirmationRequest.DateTimeConfirmExpire)+","
				+    POut.Int   (confirmationRequest.SecondsFromEntryToExpire)+","
				+"'"+POut.String(confirmationRequest.ShortGUID)+"',"
				+"'"+POut.String(confirmationRequest.ConfirmCode)+"',"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.Now()+","
				+    POut.DateT (confirmationRequest.DateTimeConfirmTransmit)+","
				+    POut.DateT (confirmationRequest.DateTimeRSVP)+","
				+    POut.Int   ((int)confirmationRequest.RSVPStatus)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile)";
			if(confirmationRequest.MsgTextToMobileTemplate==null) {
				confirmationRequest.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,confirmationRequest.MsgTextToMobileTemplate);
			if(confirmationRequest.MsgTextToMobile==null) {
				confirmationRequest.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,confirmationRequest.MsgTextToMobile);
			if(confirmationRequest.ResponseDescript==null) {
				confirmationRequest.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,confirmationRequest.ResponseDescript);
			if(confirmationRequest.GuidMessageToMobile==null) {
				confirmationRequest.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringNote(confirmationRequest.GuidMessageToMobile));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
			}
			else {
				confirmationRequest.ConfirmationRequestNum=Db.NonQ(command,true,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
			}
			return confirmationRequest.ConfirmationRequestNum;
		}

		///<summary>Updates one ConfirmationRequest in the database.</summary>
		public static void Update(ConfirmationRequest confirmationRequest){
			string command="UPDATE confirmationrequest SET "
				+"ClinicNum               =  "+POut.Long  (confirmationRequest.ClinicNum)+", "
				+"IsForSms                =  "+POut.Bool  (confirmationRequest.IsForSms)+", "
				+"PatNum                  =  "+POut.Long  (confirmationRequest.PatNum)+", "
				+"ApptNum                 =  "+POut.Long  (confirmationRequest.ApptNum)+", "
				+"PhonePat                = '"+POut.String(confirmationRequest.PhonePat)+"', "
				+"DateTimeConfirmExpire   =  "+POut.DateT (confirmationRequest.DateTimeConfirmExpire)+", "
				+"SecondsFromEntryToExpire=  "+POut.Int   (confirmationRequest.SecondsFromEntryToExpire)+", "
				+"ShortGUID               = '"+POut.String(confirmationRequest.ShortGUID)+"', "
				+"ConfirmCode             = '"+POut.String(confirmationRequest.ConfirmCode)+"', "
				+"MsgTextToMobileTemplate =  "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate, "
				+"MsgTextToMobile         =  "+DbHelper.ParamChar+"paramMsgTextToMobile, "
				//DateTimeEntry not allowed to change
				+"DateTimeConfirmTransmit =  "+POut.DateT (confirmationRequest.DateTimeConfirmTransmit)+", "
				+"DateTimeRSVP            =  "+POut.DateT (confirmationRequest.DateTimeRSVP)+", "
				+"RSVPStatus              =  "+POut.Int   ((int)confirmationRequest.RSVPStatus)+", "
				+"ResponseDescript        =  "+DbHelper.ParamChar+"paramResponseDescript, "
				+"GuidMessageToMobile     =  "+DbHelper.ParamChar+"paramGuidMessageToMobile "
				+"WHERE ConfirmationRequestNum = "+POut.Long(confirmationRequest.ConfirmationRequestNum);
			if(confirmationRequest.MsgTextToMobileTemplate==null) {
				confirmationRequest.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,confirmationRequest.MsgTextToMobileTemplate);
			if(confirmationRequest.MsgTextToMobile==null) {
				confirmationRequest.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,confirmationRequest.MsgTextToMobile);
			if(confirmationRequest.ResponseDescript==null) {
				confirmationRequest.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,confirmationRequest.ResponseDescript);
			if(confirmationRequest.GuidMessageToMobile==null) {
				confirmationRequest.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringNote(confirmationRequest.GuidMessageToMobile));
			Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
		}

		///<summary>Updates one ConfirmationRequest in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ConfirmationRequest confirmationRequest,ConfirmationRequest oldConfirmationRequest){
			string command="";
			if(confirmationRequest.ClinicNum != oldConfirmationRequest.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(confirmationRequest.ClinicNum)+"";
			}
			if(confirmationRequest.IsForSms != oldConfirmationRequest.IsForSms) {
				if(command!=""){ command+=",";}
				command+="IsForSms = "+POut.Bool(confirmationRequest.IsForSms)+"";
			}
			if(confirmationRequest.PatNum != oldConfirmationRequest.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(confirmationRequest.PatNum)+"";
			}
			if(confirmationRequest.ApptNum != oldConfirmationRequest.ApptNum) {
				if(command!=""){ command+=",";}
				command+="ApptNum = "+POut.Long(confirmationRequest.ApptNum)+"";
			}
			if(confirmationRequest.PhonePat != oldConfirmationRequest.PhonePat) {
				if(command!=""){ command+=",";}
				command+="PhonePat = '"+POut.String(confirmationRequest.PhonePat)+"'";
			}
			if(confirmationRequest.DateTimeConfirmExpire != oldConfirmationRequest.DateTimeConfirmExpire) {
				if(command!=""){ command+=",";}
				command+="DateTimeConfirmExpire = "+POut.DateT(confirmationRequest.DateTimeConfirmExpire)+"";
			}
			if(confirmationRequest.SecondsFromEntryToExpire != oldConfirmationRequest.SecondsFromEntryToExpire) {
				if(command!=""){ command+=",";}
				command+="SecondsFromEntryToExpire = "+POut.Int(confirmationRequest.SecondsFromEntryToExpire)+"";
			}
			if(confirmationRequest.ShortGUID != oldConfirmationRequest.ShortGUID) {
				if(command!=""){ command+=",";}
				command+="ShortGUID = '"+POut.String(confirmationRequest.ShortGUID)+"'";
			}
			if(confirmationRequest.ConfirmCode != oldConfirmationRequest.ConfirmCode) {
				if(command!=""){ command+=",";}
				command+="ConfirmCode = '"+POut.String(confirmationRequest.ConfirmCode)+"'";
			}
			if(confirmationRequest.MsgTextToMobileTemplate != oldConfirmationRequest.MsgTextToMobileTemplate) {
				if(command!=""){ command+=",";}
				command+="MsgTextToMobileTemplate = "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate";
			}
			if(confirmationRequest.MsgTextToMobile != oldConfirmationRequest.MsgTextToMobile) {
				if(command!=""){ command+=",";}
				command+="MsgTextToMobile = "+DbHelper.ParamChar+"paramMsgTextToMobile";
			}
			//DateTimeEntry not allowed to change
			if(confirmationRequest.DateTimeConfirmTransmit != oldConfirmationRequest.DateTimeConfirmTransmit) {
				if(command!=""){ command+=",";}
				command+="DateTimeConfirmTransmit = "+POut.DateT(confirmationRequest.DateTimeConfirmTransmit)+"";
			}
			if(confirmationRequest.DateTimeRSVP != oldConfirmationRequest.DateTimeRSVP) {
				if(command!=""){ command+=",";}
				command+="DateTimeRSVP = "+POut.DateT(confirmationRequest.DateTimeRSVP)+"";
			}
			if(confirmationRequest.RSVPStatus != oldConfirmationRequest.RSVPStatus) {
				if(command!=""){ command+=",";}
				command+="RSVPStatus = "+POut.Int   ((int)confirmationRequest.RSVPStatus)+"";
			}
			if(confirmationRequest.ResponseDescript != oldConfirmationRequest.ResponseDescript) {
				if(command!=""){ command+=",";}
				command+="ResponseDescript = "+DbHelper.ParamChar+"paramResponseDescript";
			}
			if(confirmationRequest.GuidMessageToMobile != oldConfirmationRequest.GuidMessageToMobile) {
				if(command!=""){ command+=",";}
				command+="GuidMessageToMobile = "+DbHelper.ParamChar+"paramGuidMessageToMobile";
			}
			if(command==""){
				return false;
			}
			if(confirmationRequest.MsgTextToMobileTemplate==null) {
				confirmationRequest.MsgTextToMobileTemplate="";
			}
			OdSqlParameter paramMsgTextToMobileTemplate=new OdSqlParameter("paramMsgTextToMobileTemplate",OdDbType.Text,confirmationRequest.MsgTextToMobileTemplate);
			if(confirmationRequest.MsgTextToMobile==null) {
				confirmationRequest.MsgTextToMobile="";
			}
			OdSqlParameter paramMsgTextToMobile=new OdSqlParameter("paramMsgTextToMobile",OdDbType.Text,confirmationRequest.MsgTextToMobile);
			if(confirmationRequest.ResponseDescript==null) {
				confirmationRequest.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,confirmationRequest.ResponseDescript);
			if(confirmationRequest.GuidMessageToMobile==null) {
				confirmationRequest.GuidMessageToMobile="";
			}
			OdSqlParameter paramGuidMessageToMobile=new OdSqlParameter("paramGuidMessageToMobile",OdDbType.Text,POut.StringNote(confirmationRequest.GuidMessageToMobile));
			command="UPDATE confirmationrequest SET "+command
				+" WHERE ConfirmationRequestNum = "+POut.Long(confirmationRequest.ConfirmationRequestNum);
			Db.NonQ(command,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramResponseDescript,paramGuidMessageToMobile);
			return true;
		}

		///<summary>Returns true if Update(ConfirmationRequest,ConfirmationRequest) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ConfirmationRequest confirmationRequest,ConfirmationRequest oldConfirmationRequest) {
			if(confirmationRequest.ClinicNum != oldConfirmationRequest.ClinicNum) {
				return true;
			}
			if(confirmationRequest.IsForSms != oldConfirmationRequest.IsForSms) {
				return true;
			}
			if(confirmationRequest.PatNum != oldConfirmationRequest.PatNum) {
				return true;
			}
			if(confirmationRequest.ApptNum != oldConfirmationRequest.ApptNum) {
				return true;
			}
			if(confirmationRequest.PhonePat != oldConfirmationRequest.PhonePat) {
				return true;
			}
			if(confirmationRequest.DateTimeConfirmExpire != oldConfirmationRequest.DateTimeConfirmExpire) {
				return true;
			}
			if(confirmationRequest.SecondsFromEntryToExpire != oldConfirmationRequest.SecondsFromEntryToExpire) {
				return true;
			}
			if(confirmationRequest.ShortGUID != oldConfirmationRequest.ShortGUID) {
				return true;
			}
			if(confirmationRequest.ConfirmCode != oldConfirmationRequest.ConfirmCode) {
				return true;
			}
			if(confirmationRequest.MsgTextToMobileTemplate != oldConfirmationRequest.MsgTextToMobileTemplate) {
				return true;
			}
			if(confirmationRequest.MsgTextToMobile != oldConfirmationRequest.MsgTextToMobile) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(confirmationRequest.DateTimeConfirmTransmit != oldConfirmationRequest.DateTimeConfirmTransmit) {
				return true;
			}
			if(confirmationRequest.DateTimeRSVP != oldConfirmationRequest.DateTimeRSVP) {
				return true;
			}
			if(confirmationRequest.RSVPStatus != oldConfirmationRequest.RSVPStatus) {
				return true;
			}
			if(confirmationRequest.ResponseDescript != oldConfirmationRequest.ResponseDescript) {
				return true;
			}
			if(confirmationRequest.GuidMessageToMobile != oldConfirmationRequest.GuidMessageToMobile) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ConfirmationRequest from the database.</summary>
		public static void Delete(long confirmationRequestNum){
			string command="DELETE FROM confirmationrequest "
				+"WHERE ConfirmationRequestNum = "+POut.Long(confirmationRequestNum);
			Db.NonQ(command);
		}

	}
}