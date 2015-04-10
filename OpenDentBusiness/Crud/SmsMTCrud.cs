//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SmsMTCrud {
		///<summary>Gets one SmsMT object from the database using the primary key.  Returns null if not found.</summary>
		public static SmsMT SelectOne(long smsMTNum){
			string command="SELECT * FROM smsmt "
				+"WHERE SmsMTNum = "+POut.Long(smsMTNum);
			List<SmsMT> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SmsMT object from the database using a query.</summary>
		public static SmsMT SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SmsMT> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SmsMT objects from the database using a query.</summary>
		public static List<SmsMT> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SmsMT> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SmsMT> TableToList(DataTable table){
			List<SmsMT> retVal=new List<SmsMT>();
			SmsMT smsMT;
			for(int i=0;i<table.Rows.Count;i++) {
				smsMT=new SmsMT();
				smsMT.SmsMTNum          = PIn.Long  (table.Rows[i]["SmsMTNum"].ToString());
				smsMT.PatNum            = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				smsMT.GuidMessage       = PIn.String(table.Rows[i]["GuidMessage"].ToString());
				smsMT.GuidBatch         = PIn.String(table.Rows[i]["GuidBatch"].ToString());
				smsMT.VlnNumber         = PIn.String(table.Rows[i]["VlnNumber"].ToString());
				smsMT.PhonePat          = PIn.String(table.Rows[i]["PhonePat"].ToString());
				smsMT.IsTimeSensitive   = PIn.Bool  (table.Rows[i]["IsTimeSensitive"].ToString());
				smsMT.MsgType           = (OpenDentBusiness.SMSMessageSource)PIn.Int(table.Rows[i]["MsgType"].ToString());
				smsMT.MsgText           = PIn.String(table.Rows[i]["MsgText"].ToString());
				smsMT.Status            = (OpenDentBusiness.SMSDeliveryStatus)PIn.Int(table.Rows[i]["Status"].ToString());
				smsMT.MsgParts          = PIn.Int   (table.Rows[i]["MsgParts"].ToString());
				smsMT.MsgCost           = PIn.Double(table.Rows[i]["MsgCost"].ToString());
				smsMT.ClinicNum         = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				smsMT.FailCode          = PIn.String(table.Rows[i]["FailCode"].ToString());
				smsMT.DateTimeSent      = PIn.DateT (table.Rows[i]["DateTimeSent"].ToString());
				smsMT.DateTimeTerminated= PIn.DateT (table.Rows[i]["DateTimeTerminated"].ToString());
				retVal.Add(smsMT);
			}
			return retVal;
		}

		///<summary>Inserts one SmsMT into the database.  Returns the new priKey.</summary>
		public static long Insert(SmsMT smsMT){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				smsMT.SmsMTNum=DbHelper.GetNextOracleKey("smsmt","SmsMTNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(smsMT,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							smsMT.SmsMTNum++;
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
				return Insert(smsMT,false);
			}
		}

		///<summary>Inserts one SmsMT into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SmsMT smsMT,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				smsMT.SmsMTNum=ReplicationServers.GetKey("smsmt","SmsMTNum");
			}
			string command="INSERT INTO smsmt (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SmsMTNum,";
			}
			command+="PatNum,GuidMessage,GuidBatch,VlnNumber,PhonePat,IsTimeSensitive,MsgType,MsgText,Status,MsgParts,MsgCost,ClinicNum,FailCode,DateTimeSent,DateTimeTerminated) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(smsMT.SmsMTNum)+",";
			}
			command+=
				     POut.Long  (smsMT.PatNum)+","
				+"'"+POut.String(smsMT.GuidMessage)+"',"
				+"'"+POut.String(smsMT.GuidBatch)+"',"
				+"'"+POut.String(smsMT.VlnNumber)+"',"
				+"'"+POut.String(smsMT.PhonePat)+"',"
				+    POut.Bool  (smsMT.IsTimeSensitive)+","
				+    POut.Int   ((int)smsMT.MsgType)+","
				+    DbHelper.ParamChar+"paramMsgText,"
				+    POut.Int   ((int)smsMT.Status)+","
				+    POut.Int   (smsMT.MsgParts)+","
				+"'"+POut.Double(smsMT.MsgCost)+"',"
				+    POut.Long  (smsMT.ClinicNum)+","
				+"'"+POut.String(smsMT.FailCode)+"',"
				+    POut.DateT (smsMT.DateTimeSent)+","
				+    POut.DateT (smsMT.DateTimeTerminated)+")";
			if(smsMT.MsgText==null) {
				smsMT.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsMT.MsgText));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramMsgText);
			}
			else {
				smsMT.SmsMTNum=Db.NonQ(command,true,paramMsgText);
			}
			return smsMT.SmsMTNum;
		}

		///<summary>Updates one SmsMT in the database.</summary>
		public static void Update(SmsMT smsMT){
			string command="UPDATE smsmt SET "
				+"PatNum            =  "+POut.Long  (smsMT.PatNum)+", "
				+"GuidMessage       = '"+POut.String(smsMT.GuidMessage)+"', "
				+"GuidBatch         = '"+POut.String(smsMT.GuidBatch)+"', "
				+"VlnNumber         = '"+POut.String(smsMT.VlnNumber)+"', "
				+"PhonePat          = '"+POut.String(smsMT.PhonePat)+"', "
				+"IsTimeSensitive   =  "+POut.Bool  (smsMT.IsTimeSensitive)+", "
				+"MsgType           =  "+POut.Int   ((int)smsMT.MsgType)+", "
				+"MsgText           =  "+DbHelper.ParamChar+"paramMsgText, "
				+"Status            =  "+POut.Int   ((int)smsMT.Status)+", "
				+"MsgParts          =  "+POut.Int   (smsMT.MsgParts)+", "
				+"MsgCost           = '"+POut.Double(smsMT.MsgCost)+"', "
				+"ClinicNum         =  "+POut.Long  (smsMT.ClinicNum)+", "
				+"FailCode          = '"+POut.String(smsMT.FailCode)+"', "
				+"DateTimeSent      =  "+POut.DateT (smsMT.DateTimeSent)+", "
				+"DateTimeTerminated=  "+POut.DateT (smsMT.DateTimeTerminated)+" "
				+"WHERE SmsMTNum = "+POut.Long(smsMT.SmsMTNum);
			if(smsMT.MsgText==null) {
				smsMT.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsMT.MsgText));
			Db.NonQ(command,paramMsgText);
		}

		///<summary>Updates one SmsMT in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SmsMT smsMT,SmsMT oldSmsMT){
			string command="";
			if(smsMT.PatNum != oldSmsMT.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(smsMT.PatNum)+"";
			}
			if(smsMT.GuidMessage != oldSmsMT.GuidMessage) {
				if(command!=""){ command+=",";}
				command+="GuidMessage = '"+POut.String(smsMT.GuidMessage)+"'";
			}
			if(smsMT.GuidBatch != oldSmsMT.GuidBatch) {
				if(command!=""){ command+=",";}
				command+="GuidBatch = '"+POut.String(smsMT.GuidBatch)+"'";
			}
			if(smsMT.VlnNumber != oldSmsMT.VlnNumber) {
				if(command!=""){ command+=",";}
				command+="VlnNumber = '"+POut.String(smsMT.VlnNumber)+"'";
			}
			if(smsMT.PhonePat != oldSmsMT.PhonePat) {
				if(command!=""){ command+=",";}
				command+="PhonePat = '"+POut.String(smsMT.PhonePat)+"'";
			}
			if(smsMT.IsTimeSensitive != oldSmsMT.IsTimeSensitive) {
				if(command!=""){ command+=",";}
				command+="IsTimeSensitive = "+POut.Bool(smsMT.IsTimeSensitive)+"";
			}
			if(smsMT.MsgType != oldSmsMT.MsgType) {
				if(command!=""){ command+=",";}
				command+="MsgType = "+POut.Int   ((int)smsMT.MsgType)+"";
			}
			if(smsMT.MsgText != oldSmsMT.MsgText) {
				if(command!=""){ command+=",";}
				command+="MsgText = "+DbHelper.ParamChar+"paramMsgText";
			}
			if(smsMT.Status != oldSmsMT.Status) {
				if(command!=""){ command+=",";}
				command+="Status = "+POut.Int   ((int)smsMT.Status)+"";
			}
			if(smsMT.MsgParts != oldSmsMT.MsgParts) {
				if(command!=""){ command+=",";}
				command+="MsgParts = "+POut.Int(smsMT.MsgParts)+"";
			}
			if(smsMT.MsgCost != oldSmsMT.MsgCost) {
				if(command!=""){ command+=",";}
				command+="MsgCost = '"+POut.Double(smsMT.MsgCost)+"'";
			}
			if(smsMT.ClinicNum != oldSmsMT.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(smsMT.ClinicNum)+"";
			}
			if(smsMT.FailCode != oldSmsMT.FailCode) {
				if(command!=""){ command+=",";}
				command+="FailCode = '"+POut.String(smsMT.FailCode)+"'";
			}
			if(smsMT.DateTimeSent != oldSmsMT.DateTimeSent) {
				if(command!=""){ command+=",";}
				command+="DateTimeSent = "+POut.DateT(smsMT.DateTimeSent)+"";
			}
			if(smsMT.DateTimeTerminated != oldSmsMT.DateTimeTerminated) {
				if(command!=""){ command+=",";}
				command+="DateTimeTerminated = "+POut.DateT(smsMT.DateTimeTerminated)+"";
			}
			if(command==""){
				return false;
			}
			if(smsMT.MsgText==null) {
				smsMT.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsMT.MsgText));
			command="UPDATE smsmt SET "+command
				+" WHERE SmsMTNum = "+POut.Long(smsMT.SmsMTNum);
			Db.NonQ(command,paramMsgText);
			return true;
		}

		///<summary>Deletes one SmsMT from the database.</summary>
		public static void Delete(long smsMTNum){
			string command="DELETE FROM smsmt "
				+"WHERE SmsMTNum = "+POut.Long(smsMTNum);
			Db.NonQ(command);
		}

	}
}