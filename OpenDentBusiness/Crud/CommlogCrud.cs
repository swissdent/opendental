//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class CommlogCrud {
		///<summary>Gets one Commlog object from the database using the primary key.  Returns null if not found.</summary>
		public static Commlog SelectOne(long commlogNum){
			string command="SELECT * FROM commlog "
				+"WHERE CommlogNum = "+POut.Long(commlogNum);
			List<Commlog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Commlog object from the database using a query.</summary>
		public static Commlog SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Commlog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Commlog objects from the database using a query.</summary>
		public static List<Commlog> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Commlog> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Commlog> TableToList(DataTable table){
			List<Commlog> retVal=new List<Commlog>();
			Commlog commlog;
			for(int i=0;i<table.Rows.Count;i++) {
				commlog=new Commlog();
				commlog.CommlogNum    = PIn.Long  (table.Rows[i]["CommlogNum"].ToString());
				commlog.PatNum        = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				commlog.CommDateTime  = PIn.DateT (table.Rows[i]["CommDateTime"].ToString());
				commlog.CommType      = PIn.Long  (table.Rows[i]["CommType"].ToString());
				commlog.Note          = PIn.String(table.Rows[i]["Note"].ToString());
				commlog.Mode_         = (CommItemMode)PIn.Int(table.Rows[i]["Mode_"].ToString());
				commlog.SentOrReceived= (CommSentOrReceived)PIn.Int(table.Rows[i]["SentOrReceived"].ToString());
				commlog.UserNum       = PIn.Long  (table.Rows[i]["UserNum"].ToString());
				commlog.Signature     = PIn.String(table.Rows[i]["Signature"].ToString());
				commlog.SigIsTopaz    = PIn.Bool  (table.Rows[i]["SigIsTopaz"].ToString());
				commlog.DateTStamp    = PIn.DateT (table.Rows[i]["DateTStamp"].ToString());
				commlog.DateTimeEnd   = PIn.DateT (table.Rows[i]["DateTimeEnd"].ToString());
				retVal.Add(commlog);
			}
			return retVal;
		}

		///<summary>Inserts one Commlog into the database.  Returns the new priKey.</summary>
		public static long Insert(Commlog commlog){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				commlog.CommlogNum=DbHelper.GetNextOracleKey("commlog","CommlogNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(commlog,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							commlog.CommlogNum++;
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
				return Insert(commlog,false);
			}
		}

		///<summary>Inserts one Commlog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Commlog commlog,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				commlog.CommlogNum=ReplicationServers.GetKey("commlog","CommlogNum");
			}
			string command="INSERT INTO commlog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CommlogNum,";
			}
			command+="PatNum,CommDateTime,CommType,Note,Mode_,SentOrReceived,UserNum,Signature,SigIsTopaz,DateTimeEnd) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(commlog.CommlogNum)+",";
			}
			command+=
				     POut.Long  (commlog.PatNum)+","
				+    POut.DateT (commlog.CommDateTime)+","
				+    POut.Long  (commlog.CommType)+","
				+"'"+POut.String(commlog.Note)+"',"
				+    POut.Int   ((int)commlog.Mode_)+","
				+    POut.Int   ((int)commlog.SentOrReceived)+","
				+    POut.Long  (commlog.UserNum)+","
				+"'"+POut.String(commlog.Signature)+"',"
				+    POut.Bool  (commlog.SigIsTopaz)+","
				//DateTStamp can only be set by MySQL
				+    POut.DateT (commlog.DateTimeEnd)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				commlog.CommlogNum=Db.NonQ(command,true);
			}
			return commlog.CommlogNum;
		}

		///<summary>Updates one Commlog in the database.</summary>
		public static void Update(Commlog commlog){
			string command="UPDATE commlog SET "
				+"PatNum        =  "+POut.Long  (commlog.PatNum)+", "
				+"CommDateTime  =  "+POut.DateT (commlog.CommDateTime)+", "
				+"CommType      =  "+POut.Long  (commlog.CommType)+", "
				+"Note          = '"+POut.String(commlog.Note)+"', "
				+"Mode_         =  "+POut.Int   ((int)commlog.Mode_)+", "
				+"SentOrReceived=  "+POut.Int   ((int)commlog.SentOrReceived)+", "
				+"UserNum       =  "+POut.Long  (commlog.UserNum)+", "
				+"Signature     = '"+POut.String(commlog.Signature)+"', "
				+"SigIsTopaz    =  "+POut.Bool  (commlog.SigIsTopaz)+", "
				//DateTStamp can only be set by MySQL
				+"DateTimeEnd   =  "+POut.DateT (commlog.DateTimeEnd)+" "
				+"WHERE CommlogNum = "+POut.Long(commlog.CommlogNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Commlog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Commlog commlog,Commlog oldCommlog){
			string command="";
			if(commlog.PatNum != oldCommlog.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(commlog.PatNum)+"";
			}
			if(commlog.CommDateTime != oldCommlog.CommDateTime) {
				if(command!=""){ command+=",";}
				command+="CommDateTime = "+POut.DateT(commlog.CommDateTime)+"";
			}
			if(commlog.CommType != oldCommlog.CommType) {
				if(command!=""){ command+=",";}
				command+="CommType = "+POut.Long(commlog.CommType)+"";
			}
			if(commlog.Note != oldCommlog.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(commlog.Note)+"'";
			}
			if(commlog.Mode_ != oldCommlog.Mode_) {
				if(command!=""){ command+=",";}
				command+="Mode_ = "+POut.Int   ((int)commlog.Mode_)+"";
			}
			if(commlog.SentOrReceived != oldCommlog.SentOrReceived) {
				if(command!=""){ command+=",";}
				command+="SentOrReceived = "+POut.Int   ((int)commlog.SentOrReceived)+"";
			}
			if(commlog.UserNum != oldCommlog.UserNum) {
				if(command!=""){ command+=",";}
				command+="UserNum = "+POut.Long(commlog.UserNum)+"";
			}
			if(commlog.Signature != oldCommlog.Signature) {
				if(command!=""){ command+=",";}
				command+="Signature = '"+POut.String(commlog.Signature)+"'";
			}
			if(commlog.SigIsTopaz != oldCommlog.SigIsTopaz) {
				if(command!=""){ command+=",";}
				command+="SigIsTopaz = "+POut.Bool(commlog.SigIsTopaz)+"";
			}
			//DateTStamp can only be set by MySQL
			if(commlog.DateTimeEnd != oldCommlog.DateTimeEnd) {
				if(command!=""){ command+=",";}
				command+="DateTimeEnd = "+POut.DateT(commlog.DateTimeEnd)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE commlog SET "+command
				+" WHERE CommlogNum = "+POut.Long(commlog.CommlogNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Commlog from the database.</summary>
		public static void Delete(long commlogNum){
			string command="DELETE FROM commlog "
				+"WHERE CommlogNum = "+POut.Long(commlogNum);
			Db.NonQ(command);
		}

	}
}