//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class DunningCrud {
		///<summary>Gets one Dunning object from the database using the primary key.  Returns null if not found.</summary>
		public static Dunning SelectOne(long dunningNum){
			string command="SELECT * FROM dunning "
				+"WHERE DunningNum = "+POut.Long(dunningNum);
			List<Dunning> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Dunning object from the database using a query.</summary>
		public static Dunning SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Dunning> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Dunning objects from the database using a query.</summary>
		public static List<Dunning> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Dunning> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Dunning> TableToList(DataTable table){
			List<Dunning> retVal=new List<Dunning>();
			Dunning dunning;
			for(int i=0;i<table.Rows.Count;i++) {
				dunning=new Dunning();
				dunning.DunningNum  = PIn.Long  (table.Rows[i]["DunningNum"].ToString());
				dunning.DunMessage  = PIn.String(table.Rows[i]["DunMessage"].ToString());
				dunning.BillingType = PIn.Long  (table.Rows[i]["BillingType"].ToString());
				dunning.AgeAccount  = PIn.Byte  (table.Rows[i]["AgeAccount"].ToString());
				dunning.InsIsPending= (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["InsIsPending"].ToString());
				dunning.MessageBold = PIn.String(table.Rows[i]["MessageBold"].ToString());
				dunning.EmailSubject= PIn.String(table.Rows[i]["EmailSubject"].ToString());
				dunning.EmailBody   = PIn.String(table.Rows[i]["EmailBody"].ToString());
				retVal.Add(dunning);
			}
			return retVal;
		}

		///<summary>Inserts one Dunning into the database.  Returns the new priKey.</summary>
		public static long Insert(Dunning dunning){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				dunning.DunningNum=DbHelper.GetNextOracleKey("dunning","DunningNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(dunning,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							dunning.DunningNum++;
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
				return Insert(dunning,false);
			}
		}

		///<summary>Inserts one Dunning into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Dunning dunning,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				dunning.DunningNum=ReplicationServers.GetKey("dunning","DunningNum");
			}
			string command="INSERT INTO dunning (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DunningNum,";
			}
			command+="DunMessage,BillingType,AgeAccount,InsIsPending,MessageBold,EmailSubject,EmailBody) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(dunning.DunningNum)+",";
			}
			command+=
				 "'"+POut.String(dunning.DunMessage)+"',"
				+    POut.Long  (dunning.BillingType)+","
				+    POut.Byte  (dunning.AgeAccount)+","
				+    POut.Int   ((int)dunning.InsIsPending)+","
				+"'"+POut.String(dunning.MessageBold)+"',"
				+"'"+POut.String(dunning.EmailSubject)+"',"
				+    DbHelper.ParamChar+"paramEmailBody)";
			if(dunning.EmailBody==null) {
				dunning.EmailBody="";
			}
			OdSqlParameter paramEmailBody=new OdSqlParameter("paramEmailBody",OdDbType.Text,dunning.EmailBody);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramEmailBody);
			}
			else {
				dunning.DunningNum=Db.NonQ(command,true,paramEmailBody);
			}
			return dunning.DunningNum;
		}

		///<summary>Updates one Dunning in the database.</summary>
		public static void Update(Dunning dunning){
			string command="UPDATE dunning SET "
				+"DunMessage  = '"+POut.String(dunning.DunMessage)+"', "
				+"BillingType =  "+POut.Long  (dunning.BillingType)+", "
				+"AgeAccount  =  "+POut.Byte  (dunning.AgeAccount)+", "
				+"InsIsPending=  "+POut.Int   ((int)dunning.InsIsPending)+", "
				+"MessageBold = '"+POut.String(dunning.MessageBold)+"', "
				+"EmailSubject= '"+POut.String(dunning.EmailSubject)+"', "
				+"EmailBody   =  "+DbHelper.ParamChar+"paramEmailBody "
				+"WHERE DunningNum = "+POut.Long(dunning.DunningNum);
			if(dunning.EmailBody==null) {
				dunning.EmailBody="";
			}
			OdSqlParameter paramEmailBody=new OdSqlParameter("paramEmailBody",OdDbType.Text,dunning.EmailBody);
			Db.NonQ(command,paramEmailBody);
		}

		///<summary>Updates one Dunning in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Dunning dunning,Dunning oldDunning){
			string command="";
			if(dunning.DunMessage != oldDunning.DunMessage) {
				if(command!=""){ command+=",";}
				command+="DunMessage = '"+POut.String(dunning.DunMessage)+"'";
			}
			if(dunning.BillingType != oldDunning.BillingType) {
				if(command!=""){ command+=",";}
				command+="BillingType = "+POut.Long(dunning.BillingType)+"";
			}
			if(dunning.AgeAccount != oldDunning.AgeAccount) {
				if(command!=""){ command+=",";}
				command+="AgeAccount = "+POut.Byte(dunning.AgeAccount)+"";
			}
			if(dunning.InsIsPending != oldDunning.InsIsPending) {
				if(command!=""){ command+=",";}
				command+="InsIsPending = "+POut.Int   ((int)dunning.InsIsPending)+"";
			}
			if(dunning.MessageBold != oldDunning.MessageBold) {
				if(command!=""){ command+=",";}
				command+="MessageBold = '"+POut.String(dunning.MessageBold)+"'";
			}
			if(dunning.EmailSubject != oldDunning.EmailSubject) {
				if(command!=""){ command+=",";}
				command+="EmailSubject = '"+POut.String(dunning.EmailSubject)+"'";
			}
			if(dunning.EmailBody != oldDunning.EmailBody) {
				if(command!=""){ command+=",";}
				command+="EmailBody = "+DbHelper.ParamChar+"paramEmailBody";
			}
			if(command==""){
				return false;
			}
			if(dunning.EmailBody==null) {
				dunning.EmailBody="";
			}
			OdSqlParameter paramEmailBody=new OdSqlParameter("paramEmailBody",OdDbType.Text,dunning.EmailBody);
			command="UPDATE dunning SET "+command
				+" WHERE DunningNum = "+POut.Long(dunning.DunningNum);
			Db.NonQ(command,paramEmailBody);
			return true;
		}

		///<summary>Deletes one Dunning from the database.</summary>
		public static void Delete(long dunningNum){
			string command="DELETE FROM dunning "
				+"WHERE DunningNum = "+POut.Long(dunningNum);
			Db.NonQ(command);
		}

	}
}