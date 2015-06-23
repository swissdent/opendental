//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SmsBillingCrud {
		///<summary>Gets one SmsBilling object from the database using the primary key.  Returns null if not found.</summary>
		public static SmsBilling SelectOne(long smsBillingNum){
			string command="SELECT * FROM smsbilling "
				+"WHERE SmsBillingNum = "+POut.Long(smsBillingNum);
			List<SmsBilling> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SmsBilling object from the database using a query.</summary>
		public static SmsBilling SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SmsBilling> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SmsBilling objects from the database using a query.</summary>
		public static List<SmsBilling> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SmsBilling> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SmsBilling> TableToList(DataTable table){
			List<SmsBilling> retVal=new List<SmsBilling>();
			SmsBilling smsBilling;
			for(int i=0;i<table.Rows.Count;i++) {
				smsBilling=new SmsBilling();
				smsBilling.SmsBillingNum     = PIn.Long  (table.Rows[i]["SmsBillingNum"].ToString());
				smsBilling.RegistrationKeyNum= PIn.Long  (table.Rows[i]["RegistrationKeyNum"].ToString());
				smsBilling.CustPatNum        = PIn.Long  (table.Rows[i]["CustPatNum"].ToString());
				smsBilling.DateUsage         = PIn.Date  (table.Rows[i]["DateUsage"].ToString());
				smsBilling.MsgChargeTotalUSD = PIn.Float (table.Rows[i]["MsgChargeTotalUSD"].ToString());
				smsBilling.ClinicsTotal      = PIn.Int   (table.Rows[i]["ClinicsTotal"].ToString());
				smsBilling.ClinicsActive     = PIn.Int   (table.Rows[i]["ClinicsActive"].ToString());
				smsBilling.ClinicsWithUsage  = PIn.Int   (table.Rows[i]["ClinicsWithUsage"].ToString());
				smsBilling.PhonesTotal       = PIn.Int   (table.Rows[i]["PhonesTotal"].ToString());
				smsBilling.PhonesActive      = PIn.Int   (table.Rows[i]["PhonesActive"].ToString());
				smsBilling.PhonesWithUsage   = PIn.Int   (table.Rows[i]["PhonesWithUsage"].ToString());
				retVal.Add(smsBilling);
			}
			return retVal;
		}

		///<summary>Inserts one SmsBilling into the database.  Returns the new priKey.</summary>
		public static long Insert(SmsBilling smsBilling){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				smsBilling.SmsBillingNum=DbHelper.GetNextOracleKey("smsbilling","SmsBillingNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(smsBilling,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							smsBilling.SmsBillingNum++;
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
				return Insert(smsBilling,false);
			}
		}

		///<summary>Inserts one SmsBilling into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SmsBilling smsBilling,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				smsBilling.SmsBillingNum=ReplicationServers.GetKey("smsbilling","SmsBillingNum");
			}
			string command="INSERT INTO smsbilling (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SmsBillingNum,";
			}
			command+="RegistrationKeyNum,CustPatNum,DateUsage,MsgChargeTotalUSD,ClinicsTotal,ClinicsActive,ClinicsInactive,ClinicsWithUsage,PhonesTotal,PhonesActive,PhonesInactive,PhonesWithUsage) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(smsBilling.SmsBillingNum)+",";
			}
			command+=
				     POut.Long  (smsBilling.RegistrationKeyNum)+","
				+    POut.Long  (smsBilling.CustPatNum)+","
				+    POut.Date  (smsBilling.DateUsage)+","
				+    POut.Float (smsBilling.MsgChargeTotalUSD)+","
				+    POut.Int   (smsBilling.ClinicsTotal)+","
				+    POut.Int   (smsBilling.ClinicsActive)+","
				+    POut.Int   (smsBilling.ClinicsWithUsage)+","
				+    POut.Int   (smsBilling.PhonesTotal)+","
				+    POut.Int   (smsBilling.PhonesActive)+","
				+    POut.Int   (smsBilling.PhonesWithUsage)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				smsBilling.SmsBillingNum=Db.NonQ(command,true);
			}
			return smsBilling.SmsBillingNum;
		}

		///<summary>Inserts one SmsBilling into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SmsBilling smsBilling){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(smsBilling,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					smsBilling.SmsBillingNum=DbHelper.GetNextOracleKey("smsbilling","SmsBillingNum"); //Cacheless method
				}
				return InsertNoCache(smsBilling,true);
			}
		}

		///<summary>Inserts one SmsBilling into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SmsBilling smsBilling,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO smsbilling (";
			if(!useExistingPK && isRandomKeys) {
				smsBilling.SmsBillingNum=ReplicationServers.GetKeyNoCache("smsbilling","SmsBillingNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SmsBillingNum,";
			}
			command+="RegistrationKeyNum,CustPatNum,DateUsage,MsgChargeTotalUSD,ClinicsTotal,ClinicsActive,ClinicsInactive,ClinicsWithUsage,PhonesTotal,PhonesActive,PhonesInactive,PhonesWithUsage) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(smsBilling.SmsBillingNum)+",";
			}
			command+=
				     POut.Long  (smsBilling.RegistrationKeyNum)+","
				+    POut.Long  (smsBilling.CustPatNum)+","
				+    POut.Date  (smsBilling.DateUsage)+","
				+    POut.Float (smsBilling.MsgChargeTotalUSD)+","
				+    POut.Int   (smsBilling.ClinicsTotal)+","
				+    POut.Int   (smsBilling.ClinicsActive)+","
				+    POut.Int   (smsBilling.ClinicsWithUsage)+","
				+    POut.Int   (smsBilling.PhonesTotal)+","
				+    POut.Int   (smsBilling.PhonesActive)+","
				+    POut.Int   (smsBilling.PhonesWithUsage)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				smsBilling.SmsBillingNum=Db.NonQ(command,true);
			}
			return smsBilling.SmsBillingNum;
		}

		///<summary>Updates one SmsBilling in the database.</summary>
		public static void Update(SmsBilling smsBilling){
			string command="UPDATE smsbilling SET "
				+"RegistrationKeyNum=  "+POut.Long  (smsBilling.RegistrationKeyNum)+", "
				+"CustPatNum        =  "+POut.Long  (smsBilling.CustPatNum)+", "
				+"DateUsage         =  "+POut.Date  (smsBilling.DateUsage)+", "
				+"MsgChargeTotalUSD =  "+POut.Float (smsBilling.MsgChargeTotalUSD)+", "
				+"ClinicsTotal      =  "+POut.Int   (smsBilling.ClinicsTotal)+", "
				+"ClinicsActive     =  "+POut.Int   (smsBilling.ClinicsActive)+", "
				+"ClinicsWithUsage  =  "+POut.Int   (smsBilling.ClinicsWithUsage)+", "
				+"PhonesTotal       =  "+POut.Int   (smsBilling.PhonesTotal)+", "
				+"PhonesActive      =  "+POut.Int   (smsBilling.PhonesActive)+", "
				+"PhonesWithUsage   =  "+POut.Int   (smsBilling.PhonesWithUsage)+" "
				+"WHERE SmsBillingNum = "+POut.Long(smsBilling.SmsBillingNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SmsBilling in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SmsBilling smsBilling,SmsBilling oldSmsBilling){
			string command="";
			if(smsBilling.RegistrationKeyNum != oldSmsBilling.RegistrationKeyNum) {
				if(command!=""){ command+=",";}
				command+="RegistrationKeyNum = "+POut.Long(smsBilling.RegistrationKeyNum)+"";
			}
			if(smsBilling.CustPatNum != oldSmsBilling.CustPatNum) {
				if(command!=""){ command+=",";}
				command+="CustPatNum = "+POut.Long(smsBilling.CustPatNum)+"";
			}
			if(smsBilling.DateUsage != oldSmsBilling.DateUsage) {
				if(command!=""){ command+=",";}
				command+="DateUsage = "+POut.Date(smsBilling.DateUsage)+"";
			}
			if(smsBilling.MsgChargeTotalUSD != oldSmsBilling.MsgChargeTotalUSD) {
				if(command!=""){ command+=",";}
				command+="MsgChargeTotalUSD = "+POut.Float(smsBilling.MsgChargeTotalUSD)+"";
			}
			if(smsBilling.ClinicsTotal != oldSmsBilling.ClinicsTotal) {
				if(command!=""){ command+=",";}
				command+="ClinicsTotal = "+POut.Int(smsBilling.ClinicsTotal)+"";
			}
			if(smsBilling.ClinicsActive != oldSmsBilling.ClinicsActive) {
				if(command!=""){ command+=",";}
				command+="ClinicsActive = "+POut.Int(smsBilling.ClinicsActive)+"";
			}
			if(smsBilling.ClinicsWithUsage != oldSmsBilling.ClinicsWithUsage) {
				if(command!=""){ command+=",";}
				command+="ClinicsWithUsage = "+POut.Int(smsBilling.ClinicsWithUsage)+"";
			}
			if(smsBilling.PhonesTotal != oldSmsBilling.PhonesTotal) {
				if(command!=""){ command+=",";}
				command+="PhonesTotal = "+POut.Int(smsBilling.PhonesTotal)+"";
			}
			if(smsBilling.PhonesActive != oldSmsBilling.PhonesActive) {
				if(command!=""){ command+=",";}
				command+="PhonesActive = "+POut.Int(smsBilling.PhonesActive)+"";
			}
			if(smsBilling.PhonesWithUsage != oldSmsBilling.PhonesWithUsage) {
				if(command!=""){ command+=",";}
				command+="PhonesWithUsage = "+POut.Int(smsBilling.PhonesWithUsage)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE smsbilling SET "+command
				+" WHERE SmsBillingNum = "+POut.Long(smsBilling.SmsBillingNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one SmsBilling from the database.</summary>
		public static void Delete(long smsBillingNum){
			string command="DELETE FROM smsbilling "
				+"WHERE SmsBillingNum = "+POut.Long(smsBillingNum);
			Db.NonQ(command);
		}

	}
}