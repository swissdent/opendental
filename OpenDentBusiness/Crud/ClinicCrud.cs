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
			foreach(DataRow row in table.Rows) {
				clinic=new Clinic();
				clinic.ClinicNum          = PIn.Long  (row["ClinicNum"].ToString());
				clinic.Description        = PIn.String(row["Description"].ToString());
				clinic.Address            = PIn.String(row["Address"].ToString());
				clinic.Address2           = PIn.String(row["Address2"].ToString());
				clinic.City               = PIn.String(row["City"].ToString());
				clinic.State              = PIn.String(row["State"].ToString());
				clinic.Zip                = PIn.String(row["Zip"].ToString());
				clinic.BillingAddress     = PIn.String(row["BillingAddress"].ToString());
				clinic.BillingAddress2    = PIn.String(row["BillingAddress2"].ToString());
				clinic.BillingCity        = PIn.String(row["BillingCity"].ToString());
				clinic.BillingState       = PIn.String(row["BillingState"].ToString());
				clinic.BillingZip         = PIn.String(row["BillingZip"].ToString());
				clinic.PayToAddress       = PIn.String(row["PayToAddress"].ToString());
				clinic.PayToAddress2      = PIn.String(row["PayToAddress2"].ToString());
				clinic.PayToCity          = PIn.String(row["PayToCity"].ToString());
				clinic.PayToState         = PIn.String(row["PayToState"].ToString());
				clinic.PayToZip           = PIn.String(row["PayToZip"].ToString());
				clinic.Phone              = PIn.String(row["Phone"].ToString());
				clinic.BankNumber         = PIn.String(row["BankNumber"].ToString());
				clinic.DefaultPlaceService= (OpenDentBusiness.PlaceOfService)PIn.Int(row["DefaultPlaceService"].ToString());
				clinic.InsBillingProv     = PIn.Long  (row["InsBillingProv"].ToString());
				clinic.Fax                = PIn.String(row["Fax"].ToString());
				clinic.EmailAddressNum    = PIn.Long  (row["EmailAddressNum"].ToString());
				clinic.DefaultProv        = PIn.Long  (row["DefaultProv"].ToString());
				clinic.SmsContractDate    = PIn.DateT (row["SmsContractDate"].ToString());
				clinic.SmsMonthlyLimit    = PIn.Double(row["SmsMonthlyLimit"].ToString());
				clinic.IsMedicalOnly      = PIn.Bool  (row["IsMedicalOnly"].ToString());
				clinic.UseBillAddrOnClaims= PIn.Bool  (row["UseBillAddrOnClaims"].ToString());
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
			command+="Description,Address,Address2,City,State,Zip,BillingAddress,BillingAddress2,BillingCity,BillingState,BillingZip,PayToAddress,PayToAddress2,PayToCity,PayToState,PayToZip,Phone,BankNumber,DefaultPlaceService,InsBillingProv,Fax,EmailAddressNum,DefaultProv,SmsContractDate,SmsMonthlyLimit,IsMedicalOnly,UseBillAddrOnClaims) VALUES(";
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
				+"'"+POut.String(clinic.BillingAddress)+"',"
				+"'"+POut.String(clinic.BillingAddress2)+"',"
				+"'"+POut.String(clinic.BillingCity)+"',"
				+"'"+POut.String(clinic.BillingState)+"',"
				+"'"+POut.String(clinic.BillingZip)+"',"
				+"'"+POut.String(clinic.PayToAddress)+"',"
				+"'"+POut.String(clinic.PayToAddress2)+"',"
				+"'"+POut.String(clinic.PayToCity)+"',"
				+"'"+POut.String(clinic.PayToState)+"',"
				+"'"+POut.String(clinic.PayToZip)+"',"
				+"'"+POut.String(clinic.Phone)+"',"
				+"'"+POut.String(clinic.BankNumber)+"',"
				+    POut.Int   ((int)clinic.DefaultPlaceService)+","
				+    POut.Long  (clinic.InsBillingProv)+","
				+"'"+POut.String(clinic.Fax)+"',"
				+    POut.Long  (clinic.EmailAddressNum)+","
				+    POut.Long  (clinic.DefaultProv)+","
				+    POut.DateT (clinic.SmsContractDate)+","
				+"'"+POut.Double(clinic.SmsMonthlyLimit)+"',"
				+    POut.Bool  (clinic.IsMedicalOnly)+","
				+    POut.Bool  (clinic.UseBillAddrOnClaims)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				clinic.ClinicNum=Db.NonQ(command,true);
			}
			return clinic.ClinicNum;
		}

		///<summary>Inserts one Clinic into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Clinic clinic){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(clinic,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					clinic.ClinicNum=DbHelper.GetNextOracleKey("clinic","ClinicNum"); //Cacheless method
				}
				return InsertNoCache(clinic,true);
			}
		}

		///<summary>Inserts one Clinic into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Clinic clinic,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO clinic (";
			if(!useExistingPK && isRandomKeys) {
				clinic.ClinicNum=ReplicationServers.GetKeyNoCache("clinic","ClinicNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ClinicNum,";
			}
			command+="Description,Address,Address2,City,State,Zip,BillingAddress,BillingAddress2,BillingCity,BillingState,BillingZip,PayToAddress,PayToAddress2,PayToCity,PayToState,PayToZip,Phone,BankNumber,DefaultPlaceService,InsBillingProv,Fax,EmailAddressNum,DefaultProv,SmsContractDate,SmsMonthlyLimit,IsMedicalOnly,UseBillAddrOnClaims) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(clinic.ClinicNum)+",";
			}
			command+=
				 "'"+POut.String(clinic.Description)+"',"
				+"'"+POut.String(clinic.Address)+"',"
				+"'"+POut.String(clinic.Address2)+"',"
				+"'"+POut.String(clinic.City)+"',"
				+"'"+POut.String(clinic.State)+"',"
				+"'"+POut.String(clinic.Zip)+"',"
				+"'"+POut.String(clinic.BillingAddress)+"',"
				+"'"+POut.String(clinic.BillingAddress2)+"',"
				+"'"+POut.String(clinic.BillingCity)+"',"
				+"'"+POut.String(clinic.BillingState)+"',"
				+"'"+POut.String(clinic.BillingZip)+"',"
				+"'"+POut.String(clinic.PayToAddress)+"',"
				+"'"+POut.String(clinic.PayToAddress2)+"',"
				+"'"+POut.String(clinic.PayToCity)+"',"
				+"'"+POut.String(clinic.PayToState)+"',"
				+"'"+POut.String(clinic.PayToZip)+"',"
				+"'"+POut.String(clinic.Phone)+"',"
				+"'"+POut.String(clinic.BankNumber)+"',"
				+    POut.Int   ((int)clinic.DefaultPlaceService)+","
				+    POut.Long  (clinic.InsBillingProv)+","
				+"'"+POut.String(clinic.Fax)+"',"
				+    POut.Long  (clinic.EmailAddressNum)+","
				+    POut.Long  (clinic.DefaultProv)+","
				+    POut.DateT (clinic.SmsContractDate)+","
				+"'"+POut.Double(clinic.SmsMonthlyLimit)+"',"
				+    POut.Bool  (clinic.IsMedicalOnly)+","
				+    POut.Bool  (clinic.UseBillAddrOnClaims)+")";
			if(useExistingPK || isRandomKeys) {
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
				+"BillingAddress     = '"+POut.String(clinic.BillingAddress)+"', "
				+"BillingAddress2    = '"+POut.String(clinic.BillingAddress2)+"', "
				+"BillingCity        = '"+POut.String(clinic.BillingCity)+"', "
				+"BillingState       = '"+POut.String(clinic.BillingState)+"', "
				+"BillingZip         = '"+POut.String(clinic.BillingZip)+"', "
				+"PayToAddress       = '"+POut.String(clinic.PayToAddress)+"', "
				+"PayToAddress2      = '"+POut.String(clinic.PayToAddress2)+"', "
				+"PayToCity          = '"+POut.String(clinic.PayToCity)+"', "
				+"PayToState         = '"+POut.String(clinic.PayToState)+"', "
				+"PayToZip           = '"+POut.String(clinic.PayToZip)+"', "
				+"Phone              = '"+POut.String(clinic.Phone)+"', "
				+"BankNumber         = '"+POut.String(clinic.BankNumber)+"', "
				+"DefaultPlaceService=  "+POut.Int   ((int)clinic.DefaultPlaceService)+", "
				+"InsBillingProv     =  "+POut.Long  (clinic.InsBillingProv)+", "
				+"Fax                = '"+POut.String(clinic.Fax)+"', "
				+"EmailAddressNum    =  "+POut.Long  (clinic.EmailAddressNum)+", "
				+"DefaultProv        =  "+POut.Long  (clinic.DefaultProv)+", "
				+"SmsContractDate    =  "+POut.DateT (clinic.SmsContractDate)+", "
				+"SmsMonthlyLimit    = '"+POut.Double(clinic.SmsMonthlyLimit)+"', "
				+"IsMedicalOnly      =  "+POut.Bool  (clinic.IsMedicalOnly)+", "
				+"UseBillAddrOnClaims=  "+POut.Bool  (clinic.UseBillAddrOnClaims)+" "
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
			if(clinic.BillingAddress != oldClinic.BillingAddress) {
				if(command!=""){ command+=",";}
				command+="BillingAddress = '"+POut.String(clinic.BillingAddress)+"'";
			}
			if(clinic.BillingAddress2 != oldClinic.BillingAddress2) {
				if(command!=""){ command+=",";}
				command+="BillingAddress2 = '"+POut.String(clinic.BillingAddress2)+"'";
			}
			if(clinic.BillingCity != oldClinic.BillingCity) {
				if(command!=""){ command+=",";}
				command+="BillingCity = '"+POut.String(clinic.BillingCity)+"'";
			}
			if(clinic.BillingState != oldClinic.BillingState) {
				if(command!=""){ command+=",";}
				command+="BillingState = '"+POut.String(clinic.BillingState)+"'";
			}
			if(clinic.BillingZip != oldClinic.BillingZip) {
				if(command!=""){ command+=",";}
				command+="BillingZip = '"+POut.String(clinic.BillingZip)+"'";
			}
			if(clinic.PayToAddress != oldClinic.PayToAddress) {
				if(command!=""){ command+=",";}
				command+="PayToAddress = '"+POut.String(clinic.PayToAddress)+"'";
			}
			if(clinic.PayToAddress2 != oldClinic.PayToAddress2) {
				if(command!=""){ command+=",";}
				command+="PayToAddress2 = '"+POut.String(clinic.PayToAddress2)+"'";
			}
			if(clinic.PayToCity != oldClinic.PayToCity) {
				if(command!=""){ command+=",";}
				command+="PayToCity = '"+POut.String(clinic.PayToCity)+"'";
			}
			if(clinic.PayToState != oldClinic.PayToState) {
				if(command!=""){ command+=",";}
				command+="PayToState = '"+POut.String(clinic.PayToState)+"'";
			}
			if(clinic.PayToZip != oldClinic.PayToZip) {
				if(command!=""){ command+=",";}
				command+="PayToZip = '"+POut.String(clinic.PayToZip)+"'";
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
			if(clinic.DefaultProv != oldClinic.DefaultProv) {
				if(command!=""){ command+=",";}
				command+="DefaultProv = "+POut.Long(clinic.DefaultProv)+"";
			}
			if(clinic.SmsContractDate != oldClinic.SmsContractDate) {
				if(command!=""){ command+=",";}
				command+="SmsContractDate = "+POut.DateT(clinic.SmsContractDate)+"";
			}
			if(clinic.SmsMonthlyLimit != oldClinic.SmsMonthlyLimit) {
				if(command!=""){ command+=",";}
				command+="SmsMonthlyLimit = '"+POut.Double(clinic.SmsMonthlyLimit)+"'";
			}
			if(clinic.IsMedicalOnly != oldClinic.IsMedicalOnly) {
				if(command!=""){ command+=",";}
				command+="IsMedicalOnly = "+POut.Bool(clinic.IsMedicalOnly)+"";
			}
			if(clinic.UseBillAddrOnClaims != oldClinic.UseBillAddrOnClaims) {
				if(command!=""){ command+=",";}
				command+="UseBillAddrOnClaims = "+POut.Bool(clinic.UseBillAddrOnClaims)+"";
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