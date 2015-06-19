//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class BenefitCrud {
		///<summary>Gets one Benefit object from the database using the primary key.  Returns null if not found.</summary>
		public static Benefit SelectOne(long benefitNum){
			string command="SELECT * FROM benefit "
				+"WHERE BenefitNum = "+POut.Long(benefitNum);
			List<Benefit> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Benefit object from the database using a query.</summary>
		public static Benefit SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Benefit> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Benefit objects from the database using a query.</summary>
		public static List<Benefit> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Benefit> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Benefit> TableToList(DataTable table){
			List<Benefit> retVal=new List<Benefit>();
			Benefit benefit;
			for(int i=0;i<table.Rows.Count;i++) {
				benefit=new Benefit();
				benefit.BenefitNum       = PIn.Long  (table.Rows[i]["BenefitNum"].ToString());
				benefit.PlanNum          = PIn.Long  (table.Rows[i]["PlanNum"].ToString());
				benefit.PatPlanNum       = PIn.Long  (table.Rows[i]["PatPlanNum"].ToString());
				benefit.CovCatNum        = PIn.Long  (table.Rows[i]["CovCatNum"].ToString());
				benefit.BenefitType      = (OpenDentBusiness.InsBenefitType)PIn.Int(table.Rows[i]["BenefitType"].ToString());
				benefit.Percent          = PIn.Int   (table.Rows[i]["Percent"].ToString());
				benefit.MonetaryAmt      = PIn.Double(table.Rows[i]["MonetaryAmt"].ToString());
				benefit.TimePeriod       = (OpenDentBusiness.BenefitTimePeriod)PIn.Int(table.Rows[i]["TimePeriod"].ToString());
				benefit.QuantityQualifier= (OpenDentBusiness.BenefitQuantity)PIn.Int(table.Rows[i]["QuantityQualifier"].ToString());
				benefit.Quantity         = PIn.Byte  (table.Rows[i]["Quantity"].ToString());
				benefit.CodeNum          = PIn.Long  (table.Rows[i]["CodeNum"].ToString());
				benefit.CoverageLevel    = (OpenDentBusiness.BenefitCoverageLevel)PIn.Int(table.Rows[i]["CoverageLevel"].ToString());
				retVal.Add(benefit);
			}
			return retVal;
		}

		///<summary>Inserts one Benefit into the database.  Returns the new priKey.</summary>
		public static long Insert(Benefit benefit){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				benefit.BenefitNum=DbHelper.GetNextOracleKey("benefit","BenefitNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(benefit,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							benefit.BenefitNum++;
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
				return Insert(benefit,false);
			}
		}

		///<summary>Inserts one Benefit into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Benefit benefit,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				benefit.BenefitNum=ReplicationServers.GetKey("benefit","BenefitNum");
			}
			string command="INSERT INTO benefit (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="BenefitNum,";
			}
			command+="PlanNum,PatPlanNum,CovCatNum,BenefitType,Percent,MonetaryAmt,TimePeriod,QuantityQualifier,Quantity,CodeNum,CoverageLevel) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(benefit.BenefitNum)+",";
			}
			command+=
				     POut.Long  (benefit.PlanNum)+","
				+    POut.Long  (benefit.PatPlanNum)+","
				+    POut.Long  (benefit.CovCatNum)+","
				+    POut.Int   ((int)benefit.BenefitType)+","
				+    POut.Int   (benefit.Percent)+","
				+"'"+POut.Double(benefit.MonetaryAmt)+"',"
				+    POut.Int   ((int)benefit.TimePeriod)+","
				+    POut.Int   ((int)benefit.QuantityQualifier)+","
				+    POut.Byte  (benefit.Quantity)+","
				+    POut.Long  (benefit.CodeNum)+","
				+    POut.Int   ((int)benefit.CoverageLevel)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				benefit.BenefitNum=Db.NonQ(command,true);
			}
			return benefit.BenefitNum;
		}

		///<summary>Inserts one Benefit into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Benefit benefit){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(benefit,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					benefit.BenefitNum=DbHelper.GetNextOracleKey("benefit","BenefitNum"); //Cacheless method
				}
				return InsertNoCache(benefit,true);
			}
		}

		///<summary>Inserts one Benefit into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Benefit benefit,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO benefit (";
			if(!useExistingPK && isRandomKeys) {
				benefit.BenefitNum=ReplicationServers.GetKeyNoCache("benefit","BenefitNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="BenefitNum,";
			}
			command+="PlanNum,PatPlanNum,CovCatNum,BenefitType,Percent,MonetaryAmt,TimePeriod,QuantityQualifier,Quantity,CodeNum,CoverageLevel) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(benefit.BenefitNum)+",";
			}
			command+=
				     POut.Long  (benefit.PlanNum)+","
				+    POut.Long  (benefit.PatPlanNum)+","
				+    POut.Long  (benefit.CovCatNum)+","
				+    POut.Int   ((int)benefit.BenefitType)+","
				+    POut.Int   (benefit.Percent)+","
				+"'"+POut.Double(benefit.MonetaryAmt)+"',"
				+    POut.Int   ((int)benefit.TimePeriod)+","
				+    POut.Int   ((int)benefit.QuantityQualifier)+","
				+    POut.Byte  (benefit.Quantity)+","
				+    POut.Long  (benefit.CodeNum)+","
				+    POut.Int   ((int)benefit.CoverageLevel)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				benefit.BenefitNum=Db.NonQ(command,true);
			}
			return benefit.BenefitNum;
		}

		///<summary>Updates one Benefit in the database.</summary>
		public static void Update(Benefit benefit){
			string command="UPDATE benefit SET "
				+"PlanNum          =  "+POut.Long  (benefit.PlanNum)+", "
				+"PatPlanNum       =  "+POut.Long  (benefit.PatPlanNum)+", "
				+"CovCatNum        =  "+POut.Long  (benefit.CovCatNum)+", "
				+"BenefitType      =  "+POut.Int   ((int)benefit.BenefitType)+", "
				+"Percent          =  "+POut.Int   (benefit.Percent)+", "
				+"MonetaryAmt      = '"+POut.Double(benefit.MonetaryAmt)+"', "
				+"TimePeriod       =  "+POut.Int   ((int)benefit.TimePeriod)+", "
				+"QuantityQualifier=  "+POut.Int   ((int)benefit.QuantityQualifier)+", "
				+"Quantity         =  "+POut.Byte  (benefit.Quantity)+", "
				+"CodeNum          =  "+POut.Long  (benefit.CodeNum)+", "
				+"CoverageLevel    =  "+POut.Int   ((int)benefit.CoverageLevel)+" "
				+"WHERE BenefitNum = "+POut.Long(benefit.BenefitNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Benefit in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Benefit benefit,Benefit oldBenefit){
			string command="";
			if(benefit.PlanNum != oldBenefit.PlanNum) {
				if(command!=""){ command+=",";}
				command+="PlanNum = "+POut.Long(benefit.PlanNum)+"";
			}
			if(benefit.PatPlanNum != oldBenefit.PatPlanNum) {
				if(command!=""){ command+=",";}
				command+="PatPlanNum = "+POut.Long(benefit.PatPlanNum)+"";
			}
			if(benefit.CovCatNum != oldBenefit.CovCatNum) {
				if(command!=""){ command+=",";}
				command+="CovCatNum = "+POut.Long(benefit.CovCatNum)+"";
			}
			if(benefit.BenefitType != oldBenefit.BenefitType) {
				if(command!=""){ command+=",";}
				command+="BenefitType = "+POut.Int   ((int)benefit.BenefitType)+"";
			}
			if(benefit.Percent != oldBenefit.Percent) {
				if(command!=""){ command+=",";}
				command+="Percent = "+POut.Int(benefit.Percent)+"";
			}
			if(benefit.MonetaryAmt != oldBenefit.MonetaryAmt) {
				if(command!=""){ command+=",";}
				command+="MonetaryAmt = '"+POut.Double(benefit.MonetaryAmt)+"'";
			}
			if(benefit.TimePeriod != oldBenefit.TimePeriod) {
				if(command!=""){ command+=",";}
				command+="TimePeriod = "+POut.Int   ((int)benefit.TimePeriod)+"";
			}
			if(benefit.QuantityQualifier != oldBenefit.QuantityQualifier) {
				if(command!=""){ command+=",";}
				command+="QuantityQualifier = "+POut.Int   ((int)benefit.QuantityQualifier)+"";
			}
			if(benefit.Quantity != oldBenefit.Quantity) {
				if(command!=""){ command+=",";}
				command+="Quantity = "+POut.Byte(benefit.Quantity)+"";
			}
			if(benefit.CodeNum != oldBenefit.CodeNum) {
				if(command!=""){ command+=",";}
				command+="CodeNum = "+POut.Long(benefit.CodeNum)+"";
			}
			if(benefit.CoverageLevel != oldBenefit.CoverageLevel) {
				if(command!=""){ command+=",";}
				command+="CoverageLevel = "+POut.Int   ((int)benefit.CoverageLevel)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE benefit SET "+command
				+" WHERE BenefitNum = "+POut.Long(benefit.BenefitNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Benefit from the database.</summary>
		public static void Delete(long benefitNum){
			string command="DELETE FROM benefit "
				+"WHERE BenefitNum = "+POut.Long(benefitNum);
			Db.NonQ(command);
		}

	}
}