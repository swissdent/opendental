//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EmailMessageCrud {
		///<summary>Gets one EmailMessage object from the database using the primary key.  Returns null if not found.</summary>
		public static EmailMessage SelectOne(long emailMessageNum){
			string command="SELECT * FROM emailmessage "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessageNum);
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EmailMessage object from the database using a query.</summary>
		public static EmailMessage SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EmailMessage objects from the database using a query.</summary>
		public static List<EmailMessage> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EmailMessage> TableToList(DataTable table){
			List<EmailMessage> retVal=new List<EmailMessage>();
			EmailMessage emailMessage;
			foreach(DataRow row in table.Rows) {
				emailMessage=new EmailMessage();
				emailMessage.EmailMessageNum = PIn.Long  (row["EmailMessageNum"].ToString());
				emailMessage.PatNum          = PIn.Long  (row["PatNum"].ToString());
				emailMessage.ToAddress       = PIn.String(row["ToAddress"].ToString());
				emailMessage.FromAddress     = PIn.String(row["FromAddress"].ToString());
				emailMessage.Subject         = PIn.String(row["Subject"].ToString());
				emailMessage.BodyText        = PIn.String(row["BodyText"].ToString());
				emailMessage.MsgDateTime     = PIn.DateT (row["MsgDateTime"].ToString());
				emailMessage.SentOrReceived  = (OpenDentBusiness.EmailSentOrReceived)PIn.Int(row["SentOrReceived"].ToString());
				emailMessage.RecipientAddress= PIn.String(row["RecipientAddress"].ToString());
				emailMessage.RawEmailIn      = PIn.String(row["RawEmailIn"].ToString());
				emailMessage.ProvNumWebMail  = PIn.Long  (row["ProvNumWebMail"].ToString());
				emailMessage.PatNumSubj      = PIn.Long  (row["PatNumSubj"].ToString());
				emailMessage.CcAddress       = PIn.String(row["CcAddress"].ToString());
				emailMessage.BccAddress      = PIn.String(row["BccAddress"].ToString());
				retVal.Add(emailMessage);
			}
			return retVal;
		}

		///<summary>Inserts one EmailMessage into the database.  Returns the new priKey.</summary>
		public static long Insert(EmailMessage emailMessage){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				emailMessage.EmailMessageNum=DbHelper.GetNextOracleKey("emailmessage","EmailMessageNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(emailMessage,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							emailMessage.EmailMessageNum++;
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
				return Insert(emailMessage,false);
			}
		}

		///<summary>Inserts one EmailMessage into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EmailMessage emailMessage,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				emailMessage.EmailMessageNum=ReplicationServers.GetKey("emailmessage","EmailMessageNum");
			}
			string command="INSERT INTO emailmessage (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmailMessageNum,";
			}
			command+="PatNum,ToAddress,FromAddress,Subject,BodyText,MsgDateTime,SentOrReceived,RecipientAddress,RawEmailIn,ProvNumWebMail,PatNumSubj,CcAddress,BccAddress) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(emailMessage.EmailMessageNum)+",";
			}
			command+=
				     POut.Long  (emailMessage.PatNum)+","
				+"'"+POut.String(emailMessage.ToAddress)+"',"
				+"'"+POut.String(emailMessage.FromAddress)+"',"
				+"'"+POut.String(emailMessage.Subject)+"',"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    POut.DateT (emailMessage.MsgDateTime)+","
				+    POut.Int   ((int)emailMessage.SentOrReceived)+","
				+"'"+POut.String(emailMessage.RecipientAddress)+"',"
				+    DbHelper.ParamChar+"paramRawEmailIn,"
				+    POut.Long  (emailMessage.ProvNumWebMail)+","
				+    POut.Long  (emailMessage.PatNumSubj)+","
				+"'"+POut.String(emailMessage.CcAddress)+"',"
				+"'"+POut.String(emailMessage.BccAddress)+"')";
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,emailMessage.BodyText);
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,emailMessage.RawEmailIn);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramBodyText,paramRawEmailIn);
			}
			else {
				emailMessage.EmailMessageNum=Db.NonQ(command,true,paramBodyText,paramRawEmailIn);
			}
			return emailMessage.EmailMessageNum;
		}

		///<summary>Inserts one EmailMessage into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailMessage emailMessage){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(emailMessage,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					emailMessage.EmailMessageNum=DbHelper.GetNextOracleKey("emailmessage","EmailMessageNum"); //Cacheless method
				}
				return InsertNoCache(emailMessage,true);
			}
		}

		///<summary>Inserts one EmailMessage into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailMessage emailMessage,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO emailmessage (";
			if(!useExistingPK && isRandomKeys) {
				emailMessage.EmailMessageNum=ReplicationServers.GetKeyNoCache("emailmessage","EmailMessageNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EmailMessageNum,";
			}
			command+="PatNum,ToAddress,FromAddress,Subject,BodyText,MsgDateTime,SentOrReceived,RecipientAddress,RawEmailIn,ProvNumWebMail,PatNumSubj,CcAddress,BccAddress) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(emailMessage.EmailMessageNum)+",";
			}
			command+=
				     POut.Long  (emailMessage.PatNum)+","
				+"'"+POut.String(emailMessage.ToAddress)+"',"
				+"'"+POut.String(emailMessage.FromAddress)+"',"
				+"'"+POut.String(emailMessage.Subject)+"',"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    POut.DateT (emailMessage.MsgDateTime)+","
				+    POut.Int   ((int)emailMessage.SentOrReceived)+","
				+"'"+POut.String(emailMessage.RecipientAddress)+"',"
				+    DbHelper.ParamChar+"paramRawEmailIn,"
				+    POut.Long  (emailMessage.ProvNumWebMail)+","
				+    POut.Long  (emailMessage.PatNumSubj)+","
				+"'"+POut.String(emailMessage.CcAddress)+"',"
				+"'"+POut.String(emailMessage.BccAddress)+"')";
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,emailMessage.BodyText);
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,emailMessage.RawEmailIn);
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramBodyText,paramRawEmailIn);
			}
			else {
				emailMessage.EmailMessageNum=Db.NonQ(command,true,paramBodyText,paramRawEmailIn);
			}
			return emailMessage.EmailMessageNum;
		}

		///<summary>Updates one EmailMessage in the database.</summary>
		public static void Update(EmailMessage emailMessage){
			string command="UPDATE emailmessage SET "
				+"PatNum          =  "+POut.Long  (emailMessage.PatNum)+", "
				+"ToAddress       = '"+POut.String(emailMessage.ToAddress)+"', "
				+"FromAddress     = '"+POut.String(emailMessage.FromAddress)+"', "
				+"Subject         = '"+POut.String(emailMessage.Subject)+"', "
				+"BodyText        =  "+DbHelper.ParamChar+"paramBodyText, "
				+"MsgDateTime     =  "+POut.DateT (emailMessage.MsgDateTime)+", "
				+"SentOrReceived  =  "+POut.Int   ((int)emailMessage.SentOrReceived)+", "
				+"RecipientAddress= '"+POut.String(emailMessage.RecipientAddress)+"', "
				+"RawEmailIn      =  "+DbHelper.ParamChar+"paramRawEmailIn, "
				+"ProvNumWebMail  =  "+POut.Long  (emailMessage.ProvNumWebMail)+", "
				+"PatNumSubj      =  "+POut.Long  (emailMessage.PatNumSubj)+", "
				+"CcAddress       = '"+POut.String(emailMessage.CcAddress)+"', "
				+"BccAddress      = '"+POut.String(emailMessage.BccAddress)+"' "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessage.EmailMessageNum);
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,emailMessage.BodyText);
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,emailMessage.RawEmailIn);
			Db.NonQ(command,paramBodyText,paramRawEmailIn);
		}

		///<summary>Updates one EmailMessage in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EmailMessage emailMessage,EmailMessage oldEmailMessage){
			string command="";
			if(emailMessage.PatNum != oldEmailMessage.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(emailMessage.PatNum)+"";
			}
			if(emailMessage.ToAddress != oldEmailMessage.ToAddress) {
				if(command!=""){ command+=",";}
				command+="ToAddress = '"+POut.String(emailMessage.ToAddress)+"'";
			}
			if(emailMessage.FromAddress != oldEmailMessage.FromAddress) {
				if(command!=""){ command+=",";}
				command+="FromAddress = '"+POut.String(emailMessage.FromAddress)+"'";
			}
			if(emailMessage.Subject != oldEmailMessage.Subject) {
				if(command!=""){ command+=",";}
				command+="Subject = '"+POut.String(emailMessage.Subject)+"'";
			}
			if(emailMessage.BodyText != oldEmailMessage.BodyText) {
				if(command!=""){ command+=",";}
				command+="BodyText = "+DbHelper.ParamChar+"paramBodyText";
			}
			if(emailMessage.MsgDateTime != oldEmailMessage.MsgDateTime) {
				if(command!=""){ command+=",";}
				command+="MsgDateTime = "+POut.DateT(emailMessage.MsgDateTime)+"";
			}
			if(emailMessage.SentOrReceived != oldEmailMessage.SentOrReceived) {
				if(command!=""){ command+=",";}
				command+="SentOrReceived = "+POut.Int   ((int)emailMessage.SentOrReceived)+"";
			}
			if(emailMessage.RecipientAddress != oldEmailMessage.RecipientAddress) {
				if(command!=""){ command+=",";}
				command+="RecipientAddress = '"+POut.String(emailMessage.RecipientAddress)+"'";
			}
			if(emailMessage.RawEmailIn != oldEmailMessage.RawEmailIn) {
				if(command!=""){ command+=",";}
				command+="RawEmailIn = "+DbHelper.ParamChar+"paramRawEmailIn";
			}
			if(emailMessage.ProvNumWebMail != oldEmailMessage.ProvNumWebMail) {
				if(command!=""){ command+=",";}
				command+="ProvNumWebMail = "+POut.Long(emailMessage.ProvNumWebMail)+"";
			}
			if(emailMessage.PatNumSubj != oldEmailMessage.PatNumSubj) {
				if(command!=""){ command+=",";}
				command+="PatNumSubj = "+POut.Long(emailMessage.PatNumSubj)+"";
			}
			if(emailMessage.CcAddress != oldEmailMessage.CcAddress) {
				if(command!=""){ command+=",";}
				command+="CcAddress = '"+POut.String(emailMessage.CcAddress)+"'";
			}
			if(emailMessage.BccAddress != oldEmailMessage.BccAddress) {
				if(command!=""){ command+=",";}
				command+="BccAddress = '"+POut.String(emailMessage.BccAddress)+"'";
			}
			if(command==""){
				return false;
			}
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,emailMessage.BodyText);
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,emailMessage.RawEmailIn);
			command="UPDATE emailmessage SET "+command
				+" WHERE EmailMessageNum = "+POut.Long(emailMessage.EmailMessageNum);
			Db.NonQ(command,paramBodyText,paramRawEmailIn);
			return true;
		}

		///<summary>Returns true if Update(EmailMessage,EmailMessage) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EmailMessage emailMessage,EmailMessage oldEmailMessage) {
			if(emailMessage.PatNum != oldEmailMessage.PatNum) {
				return true;
			}
			if(emailMessage.ToAddress != oldEmailMessage.ToAddress) {
				return true;
			}
			if(emailMessage.FromAddress != oldEmailMessage.FromAddress) {
				return true;
			}
			if(emailMessage.Subject != oldEmailMessage.Subject) {
				return true;
			}
			if(emailMessage.BodyText != oldEmailMessage.BodyText) {
				return true;
			}
			if(emailMessage.MsgDateTime != oldEmailMessage.MsgDateTime) {
				return true;
			}
			if(emailMessage.SentOrReceived != oldEmailMessage.SentOrReceived) {
				return true;
			}
			if(emailMessage.RecipientAddress != oldEmailMessage.RecipientAddress) {
				return true;
			}
			if(emailMessage.RawEmailIn != oldEmailMessage.RawEmailIn) {
				return true;
			}
			if(emailMessage.ProvNumWebMail != oldEmailMessage.ProvNumWebMail) {
				return true;
			}
			if(emailMessage.PatNumSubj != oldEmailMessage.PatNumSubj) {
				return true;
			}
			if(emailMessage.CcAddress != oldEmailMessage.CcAddress) {
				return true;
			}
			if(emailMessage.BccAddress != oldEmailMessage.BccAddress) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EmailMessage from the database.</summary>
		public static void Delete(long emailMessageNum){
			string command="DELETE FROM emailmessage "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessageNum);
			Db.NonQ(command);
		}

	}
}