//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClinicCrud {
		///<summary>Gets one Clinic object from the database using the primary key.  Returns null if not found.</summary>
		public static Clinic SelectOne(long clinicNum){
			string command="SELECT * FROM clinic "
				+"WHERE ClinicNum = "+POut.Long(clinicNum);
			List<Clinic> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Clinic object from the database using a query.</summary>
		public static Clinic SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Clinic> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Clinic objects from the database using a query.</summary>
		public static List<Clinic> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Clinic> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Clinic> TableToList(DataTable table){
			List<Clinic> retVal=new List<Clinic>();
			Clinic clinic;
			for(int i=0;i<table.Rows.Count;i++) {
				clinic=new Clinic();
				clinic.ClinicNum          = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				clinic.Description        = PIn.String(table.Rows[i]["Description"].ToString());
				clinic.Address            = PIn.String(table.Rows[i]["Address"].ToString());
				clinic.Address2           = PIn.String(table.Rows[i]["Address2"].ToString());
				clinic.City               = PIn.String(table.Rows[i]["City"].ToString());
				clinic.State              = PIn.String(table.Rows[i]["State"].ToString());
				clinic.Zip                = PIn.String(table.Rows[i]["Zip"].ToString());
				clinic.Phone              = PIn.String(table.Rows[i]["Phone"].ToString());
				clinic.BankNumber         = PIn.String(table.Rows[i]["BankNumber"].ToString());
				clinic.DefaultPlaceService= (OpenDentBusiness.PlaceOfService)PIn.Int(table.Rows[i]["DefaultPlaceService"].ToString());
				clinic.InsBillingProv     = PIn.Long  (table.Rows[i]["InsBillingProv"].ToString());
				clinic.Fax                = PIn.String(table.Rows[i]["Fax"].ToString());
				clinic.EmailAddressNum    = PIn.Long  (table.Rows[i]["EmailAddressNum"].ToString());
				retVal.Add(clinic);
			}
			return retVal;
		}

		///<summary>Inserts one Clinic into the database.  Returns the new priKey.</summary>
		public static long Insert(Clinic clinic){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				clinic.ClinicNum=DbHelper.GetNextOracleKey("clinic","ClinicNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(clinic,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							clinic.ClinicNum++;
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
				return Insert(clinic,false);
			}
		}

		///<summary>Inserts one Clinic into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Clinic clinic,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				clinic.ClinicNum=ReplicationServers.GetKey("clinic","ClinicNum");
			}
			string command="INSERT INTO clinic (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClinicNum,";
			}
			command+="Description,Address,Address2,City,State,Zip,Phone,BankNumber,DefaultPlaceService,InsBillingProv,Fax,EmailAddressNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(clinic.ClinicNum)+",";
			}
			command+=
				 "'"+POut.String(clinic.Description)+"',"
				+"'"+POut.String(clinic.Address)+"',"
				+"'"+POut.String(clinic.Address2)+"',"
				+"'"+POut.String(clinic.City)+"',"
				+"'"+POut.String(clinic.State)+"',"
				+"'"+POut.String(clinic.Zip)+"',"
				+"'"+POut.String(clinic.Phone)+"',"
				+"'"+POut.String(clinic.BankNumber)+"',"
				+    POut.Int   ((int)clinic.DefaultPlaceService)+","
				+    POut.Long  (clinic.InsBillingProv)+","
				+"'"+POut.String(clinic.Fax)+"',"
				+    POut.Long  (clinic.EmailAddressNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				clinic.ClinicNum=Db.NonQ(command,true);
			}
			return clinic.ClinicNum;
		}

		///<summary>Updates one Clinic in the database.</summary>
		public static void Update(Clinic clinic){
			string command="UPDATE clinic SET "
				+"Description        = '"+POut.String(clinic.Description)+"', "
				+"Address            = '"+POut.String(clinic.Address)+"', "
				+"Address2           = '"+POut.String(clinic.Address2)+"', "
				+"City               = '"+POut.String(clinic.City)+"', "
				+"State              = '"+POut.String(clinic.State)+"', "
				+"Zip                = '"+POut.String(clinic.Zip)+"', "
				+"Phone              = '"+POut.String(clinic.Phone)+"', "
				+"BankNumber         = '"+POut.String(clinic.BankNumber)+"', "
				+"DefaultPlaceService=  "+POut.Int   ((int)clinic.DefaultPlaceService)+", "
				+"InsBillingProv     =  "+POut.Long  (clinic.InsBillingProv)+", "
				+"Fax                = '"+POut.String(clinic.Fax)+"', "
				+"EmailAddressNum    =  "+POut.Long  (clinic.EmailAddressNum)+" "
				+"WHERE ClinicNum = "+POut.Long(clinic.ClinicNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Clinic in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Clinic clinic,Clinic oldClinic){
			string command="";
			if(clinic.Description != oldClinic.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(clinic.Description)+"'";
			}
			if(clinic.Address != oldClinic.Address) {
				if(command!=""){ command+=",";}
				command+="Address = '"+POut.String(clinic.Address)+"'";
			}
			if(clinic.Address2 != oldClinic.Address2) {
				if(command!=""){ command+=",";}
				command+="Address2 = '"+POut.String(clinic.Address2)+"'";
			}
			if(clinic.City != oldClinic.City) {
				if(command!=""){ command+=",";}
				command+="City = '"+POut.String(clinic.City)+"'";
			}
			if(clinic.State != oldClinic.State) {
				if(command!=""){ command+=",";}
				command+="State = '"+POut.String(clinic.State)+"'";
			}
			if(clinic.Zip != oldClinic.Zip) {
				if(command!=""){ command+=",";}
				command+="Zip = '"+POut.String(clinic.Zip)+"'";
			}
			if(clinic.Phone != oldClinic.Phone) {
				if(command!=""){ command+=",";}
				command+="Phone = '"+POut.String(clinic.Phone)+"'";
			}
			if(clinic.BankNumber != oldClinic.BankNumber) {
				if(command!=""){ command+=",";}
				command+="BankNumber = '"+POut.String(clinic.BankNumber)+"'";
			}
			if(clinic.DefaultPlaceService != oldClinic.DefaultPlaceService) {
				if(command!=""){ command+=",";}
				command+="DefaultPlaceService = "+POut.Int   ((int)clinic.DefaultPlaceService)+"";
			}
			if(clinic.InsBillingProv != oldClinic.InsBillingProv) {
				if(command!=""){ command+=",";}
				command+="InsBillingProv = "+POut.Long(clinic.InsBillingProv)+"";
			}
			if(clinic.Fax != oldClinic.Fax) {
				if(command!=""){ command+=",";}
				command+="Fax = '"+POut.String(clinic.Fax)+"'";
			}
			if(clinic.EmailAddressNum != oldClinic.EmailAddressNum) {
				if(command!=""){ command+=",";}
				command+="EmailAddressNum = "+POut.Long(clinic.EmailAddressNum)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE clinic SET "+command
				+" WHERE ClinicNum = "+POut.Long(clinic.ClinicNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Clinic from the database.</summary>
		public static void Delete(long clinicNum){
			string command="DELETE FROM clinic "
				+"WHERE ClinicNum = "+POut.Long(clinicNum);
			Db.NonQ(command);
		}

	}
}