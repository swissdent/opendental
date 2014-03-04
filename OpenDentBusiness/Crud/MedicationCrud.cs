//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class MedicationCrud {
		///<summary>Gets one Medication object from the database using the primary key.  Returns null if not found.</summary>
		public static Medication SelectOne(long medicationNum){
			string command="SELECT * FROM medication "
				+"WHERE MedicationNum = "+POut.Long(medicationNum);
			List<Medication> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Medication object from the database using a query.</summary>
		public static Medication SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Medication> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Medication objects from the database using a query.</summary>
		public static List<Medication> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Medication> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Medication> TableToList(DataTable table){
			List<Medication> retVal=new List<Medication>();
			Medication medication;
			for(int i=0;i<table.Rows.Count;i++) {
				medication=new Medication();
				medication.MedicationNum= PIn.Long  (table.Rows[i]["MedicationNum"].ToString());
				medication.MedName      = PIn.String(table.Rows[i]["MedName"].ToString());
				medication.GenericNum   = PIn.Long  (table.Rows[i]["GenericNum"].ToString());
				medication.Notes        = PIn.String(table.Rows[i]["Notes"].ToString());
				medication.DateTStamp   = PIn.DateT (table.Rows[i]["DateTStamp"].ToString());
				medication.RxCui        = PIn.Long  (table.Rows[i]["RxCui"].ToString());
				retVal.Add(medication);
			}
			return retVal;
		}

		///<summary>Inserts one Medication into the database.  Returns the new priKey.</summary>
		public static long Insert(Medication medication){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				medication.MedicationNum=DbHelper.GetNextOracleKey("medication","MedicationNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(medication,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							medication.MedicationNum++;
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
				return Insert(medication,false);
			}
		}

		///<summary>Inserts one Medication into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Medication medication,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				medication.MedicationNum=ReplicationServers.GetKey("medication","MedicationNum");
			}
			string command="INSERT INTO medication (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MedicationNum,";
			}
			command+="MedName,GenericNum,Notes,RxCui) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(medication.MedicationNum)+",";
			}
			command+=
				 "'"+POut.String(medication.MedName)+"',"
				+    POut.Long  (medication.GenericNum)+","
				+"'"+POut.String(medication.Notes)+"',"
				//DateTStamp can only be set by MySQL
				+    POut.Long  (medication.RxCui)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				medication.MedicationNum=Db.NonQ(command,true);
			}
			return medication.MedicationNum;
		}

		///<summary>Updates one Medication in the database.</summary>
		public static void Update(Medication medication){
			string command="UPDATE medication SET "
				+"MedName      = '"+POut.String(medication.MedName)+"', "
				+"GenericNum   =  "+POut.Long  (medication.GenericNum)+", "
				+"Notes        = '"+POut.String(medication.Notes)+"', "
				//DateTStamp can only be set by MySQL
				+"RxCui        =  "+POut.Long  (medication.RxCui)+" "
				+"WHERE MedicationNum = "+POut.Long(medication.MedicationNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Medication in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Medication medication,Medication oldMedication){
			string command="";
			if(medication.MedName != oldMedication.MedName) {
				if(command!=""){ command+=",";}
				command+="MedName = '"+POut.String(medication.MedName)+"'";
			}
			if(medication.GenericNum != oldMedication.GenericNum) {
				if(command!=""){ command+=",";}
				command+="GenericNum = "+POut.Long(medication.GenericNum)+"";
			}
			if(medication.Notes != oldMedication.Notes) {
				if(command!=""){ command+=",";}
				command+="Notes = '"+POut.String(medication.Notes)+"'";
			}
			//DateTStamp can only be set by MySQL
			if(medication.RxCui != oldMedication.RxCui) {
				if(command!=""){ command+=",";}
				command+="RxCui = "+POut.Long(medication.RxCui)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE medication SET "+command
				+" WHERE MedicationNum = "+POut.Long(medication.MedicationNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Medication from the database.</summary>
		public static void Delete(long medicationNum){
			string command="DELETE FROM medication "
				+"WHERE MedicationNum = "+POut.Long(medicationNum);
			Db.NonQ(command);
		}

	}
}