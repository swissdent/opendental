//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PhoneConfCrud {
		///<summary>Gets one PhoneConf object from the database using the primary key.  Returns null if not found.</summary>
		public static PhoneConf SelectOne(long phoneConfNum){
			string command="SELECT * FROM phoneconf "
				+"WHERE PhoneConfNum = "+POut.Long(phoneConfNum);
			List<PhoneConf> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PhoneConf object from the database using a query.</summary>
		public static PhoneConf SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneConf> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PhoneConf objects from the database using a query.</summary>
		public static List<PhoneConf> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneConf> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<PhoneConf> TableToList(DataTable table){
			List<PhoneConf> retVal=new List<PhoneConf>();
			PhoneConf phoneConf;
			for(int i=0;i<table.Rows.Count;i++) {
				phoneConf=new PhoneConf();
				phoneConf.PhoneConfNum= PIn.Long  (table.Rows[i]["PhoneConfNum"].ToString());
				phoneConf.ButtonIndex = PIn.Int   (table.Rows[i]["ButtonIndex"].ToString());
				phoneConf.Occupants   = PIn.Int   (table.Rows[i]["Occupants"].ToString());
				phoneConf.Extension   = PIn.Int   (table.Rows[i]["Extension"].ToString());
				retVal.Add(phoneConf);
			}
			return retVal;
		}

		///<summary>Inserts one PhoneConf into the database.  Returns the new priKey.</summary>
		public static long Insert(PhoneConf phoneConf){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				phoneConf.PhoneConfNum=DbHelper.GetNextOracleKey("phoneconf","PhoneConfNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(phoneConf,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							phoneConf.PhoneConfNum++;
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
				return Insert(phoneConf,false);
			}
		}

		///<summary>Inserts one PhoneConf into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(PhoneConf phoneConf,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				phoneConf.PhoneConfNum=ReplicationServers.GetKey("phoneconf","PhoneConfNum");
			}
			string command="INSERT INTO phoneconf (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PhoneConfNum,";
			}
			command+="ButtonIndex,Occupants,Extension) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(phoneConf.PhoneConfNum)+",";
			}
			command+=
				     POut.Int   (phoneConf.ButtonIndex)+","
				+    POut.Int   (phoneConf.Occupants)+","
				+    POut.Int   (phoneConf.Extension)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				phoneConf.PhoneConfNum=Db.NonQ(command,true);
			}
			return phoneConf.PhoneConfNum;
		}

		///<summary>Inserts one PhoneConf into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PhoneConf phoneConf){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(phoneConf,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					phoneConf.PhoneConfNum=DbHelper.GetNextOracleKey("phoneconf","PhoneConfNum"); //Cacheless method
				}
				return InsertNoCache(phoneConf,true);
			}
		}

		///<summary>Inserts one PhoneConf into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PhoneConf phoneConf,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO phoneconf (";
			if(!useExistingPK && isRandomKeys) {
				phoneConf.PhoneConfNum=ReplicationServers.GetKeyNoCache("phoneconf","PhoneConfNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PhoneConfNum,";
			}
			command+="ButtonIndex,Occupants,Extension) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(phoneConf.PhoneConfNum)+",";
			}
			command+=
				     POut.Int   (phoneConf.ButtonIndex)+","
				+    POut.Int   (phoneConf.Occupants)+","
				+    POut.Int   (phoneConf.Extension)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				phoneConf.PhoneConfNum=Db.NonQ(command,true);
			}
			return phoneConf.PhoneConfNum;
		}

		///<summary>Updates one PhoneConf in the database.</summary>
		public static void Update(PhoneConf phoneConf){
			string command="UPDATE phoneconf SET "
				+"ButtonIndex =  "+POut.Int   (phoneConf.ButtonIndex)+", "
				+"Occupants   =  "+POut.Int   (phoneConf.Occupants)+", "
				+"Extension   =  "+POut.Int   (phoneConf.Extension)+" "
				+"WHERE PhoneConfNum = "+POut.Long(phoneConf.PhoneConfNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PhoneConf in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(PhoneConf phoneConf,PhoneConf oldPhoneConf){
			string command="";
			if(phoneConf.ButtonIndex != oldPhoneConf.ButtonIndex) {
				if(command!=""){ command+=",";}
				command+="ButtonIndex = "+POut.Int(phoneConf.ButtonIndex)+"";
			}
			if(phoneConf.Occupants != oldPhoneConf.Occupants) {
				if(command!=""){ command+=",";}
				command+="Occupants = "+POut.Int(phoneConf.Occupants)+"";
			}
			if(phoneConf.Extension != oldPhoneConf.Extension) {
				if(command!=""){ command+=",";}
				command+="Extension = "+POut.Int(phoneConf.Extension)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE phoneconf SET "+command
				+" WHERE PhoneConfNum = "+POut.Long(phoneConf.PhoneConfNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one PhoneConf from the database.</summary>
		public static void Delete(long phoneConfNum){
			string command="DELETE FROM phoneconf "
				+"WHERE PhoneConfNum = "+POut.Long(phoneConfNum);
			Db.NonQ(command);
		}

	}
}