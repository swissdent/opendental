//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class VitalsignCrud {
		///<summary>Gets one Vitalsign object from the database using the primary key.  Returns null if not found.</summary>
		public static Vitalsign SelectOne(long vitalsignNum){
			string command="SELECT * FROM vitalsign "
				+"WHERE VitalsignNum = "+POut.Long(vitalsignNum);
			List<Vitalsign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Vitalsign object from the database using a query.</summary>
		public static Vitalsign SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Vitalsign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Vitalsign objects from the database using a query.</summary>
		public static List<Vitalsign> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Vitalsign> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Vitalsign> TableToList(DataTable table){
			List<Vitalsign> retVal=new List<Vitalsign>();
			Vitalsign vitalsign;
			for(int i=0;i<table.Rows.Count;i++) {
				vitalsign=new Vitalsign();
				vitalsign.VitalsignNum      = PIn.Long  (table.Rows[i]["VitalsignNum"].ToString());
				vitalsign.PatNum            = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				vitalsign.Height            = PIn.Float (table.Rows[i]["Height"].ToString());
				vitalsign.Weight            = PIn.Float (table.Rows[i]["Weight"].ToString());
				vitalsign.BpSystolic        = PIn.Int   (table.Rows[i]["BpSystolic"].ToString());
				vitalsign.BpDiastolic       = PIn.Int   (table.Rows[i]["BpDiastolic"].ToString());
				vitalsign.DateTaken         = PIn.Date  (table.Rows[i]["DateTaken"].ToString());
				vitalsign.HasFollowupPlan   = PIn.Bool  (table.Rows[i]["HasFollowupPlan"].ToString());
				vitalsign.IsIneligible      = PIn.Bool  (table.Rows[i]["IsIneligible"].ToString());
				vitalsign.Documentation     = PIn.String(table.Rows[i]["Documentation"].ToString());
				vitalsign.ChildGotNutrition = PIn.Bool  (table.Rows[i]["ChildGotNutrition"].ToString());
				vitalsign.ChildGotPhysCouns = PIn.Bool  (table.Rows[i]["ChildGotPhysCouns"].ToString());
				vitalsign.WeightCode        = PIn.String(table.Rows[i]["WeightCode"].ToString());
				vitalsign.HeightExamCode    = PIn.String(table.Rows[i]["HeightExamCode"].ToString());
				vitalsign.WeightExamCode    = PIn.String(table.Rows[i]["WeightExamCode"].ToString());
				vitalsign.BMIExamCode       = PIn.String(table.Rows[i]["BMIExamCode"].ToString());
				vitalsign.EhrNotPerformedNum= PIn.Long  (table.Rows[i]["EhrNotPerformedNum"].ToString());
				vitalsign.PregDiseaseNum    = PIn.Long  (table.Rows[i]["PregDiseaseNum"].ToString());
				vitalsign.BMIPercentile     = PIn.Int   (table.Rows[i]["BMIPercentile"].ToString());
				retVal.Add(vitalsign);
			}
			return retVal;
		}

		///<summary>Inserts one Vitalsign into the database.  Returns the new priKey.</summary>
		public static long Insert(Vitalsign vitalsign){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				vitalsign.VitalsignNum=DbHelper.GetNextOracleKey("vitalsign","VitalsignNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(vitalsign,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							vitalsign.VitalsignNum++;
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
				return Insert(vitalsign,false);
			}
		}

		///<summary>Inserts one Vitalsign into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Vitalsign vitalsign,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				vitalsign.VitalsignNum=ReplicationServers.GetKey("vitalsign","VitalsignNum");
			}
			string command="INSERT INTO vitalsign (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="VitalsignNum,";
			}
			command+="PatNum,Height,Weight,BpSystolic,BpDiastolic,DateTaken,HasFollowupPlan,IsIneligible,Documentation,ChildGotNutrition,ChildGotPhysCouns,WeightCode,HeightExamCode,WeightExamCode,BMIExamCode,EhrNotPerformedNum,PregDiseaseNum,BMIPercentile) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(vitalsign.VitalsignNum)+",";
			}
			command+=
				     POut.Long  (vitalsign.PatNum)+","
				+    POut.Float (vitalsign.Height)+","
				+    POut.Float (vitalsign.Weight)+","
				+    POut.Int   (vitalsign.BpSystolic)+","
				+    POut.Int   (vitalsign.BpDiastolic)+","
				+    POut.Date  (vitalsign.DateTaken)+","
				+    POut.Bool  (vitalsign.HasFollowupPlan)+","
				+    POut.Bool  (vitalsign.IsIneligible)+","
				+"'"+POut.String(vitalsign.Documentation)+"',"
				+    POut.Bool  (vitalsign.ChildGotNutrition)+","
				+    POut.Bool  (vitalsign.ChildGotPhysCouns)+","
				+"'"+POut.String(vitalsign.WeightCode)+"',"
				+"'"+POut.String(vitalsign.HeightExamCode)+"',"
				+"'"+POut.String(vitalsign.WeightExamCode)+"',"
				+"'"+POut.String(vitalsign.BMIExamCode)+"',"
				+    POut.Long  (vitalsign.EhrNotPerformedNum)+","
				+    POut.Long  (vitalsign.PregDiseaseNum)+","
				+    POut.Int   (vitalsign.BMIPercentile)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				vitalsign.VitalsignNum=Db.NonQ(command,true);
			}
			return vitalsign.VitalsignNum;
		}

		///<summary>Inserts one Vitalsign into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Vitalsign vitalsign){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(vitalsign,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					vitalsign.VitalsignNum=DbHelper.GetNextOracleKey("vitalsign","VitalsignNum"); //Cacheless method
				}
				return InsertNoCache(vitalsign,true);
			}
		}

		///<summary>Inserts one Vitalsign into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Vitalsign vitalsign,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO vitalsign (";
			if(!useExistingPK && isRandomKeys) {
				vitalsign.VitalsignNum=ReplicationServers.GetKeyNoCache("vitalsign","VitalsignNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="VitalsignNum,";
			}
			command+="PatNum,Height,Weight,BpSystolic,BpDiastolic,DateTaken,HasFollowupPlan,IsIneligible,Documentation,ChildGotNutrition,ChildGotPhysCouns,WeightCode,HeightExamCode,WeightExamCode,BMIExamCode,EhrNotPerformedNum,PregDiseaseNum,BMIPercentile) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(vitalsign.VitalsignNum)+",";
			}
			command+=
				     POut.Long  (vitalsign.PatNum)+","
				+    POut.Float (vitalsign.Height)+","
				+    POut.Float (vitalsign.Weight)+","
				+    POut.Int   (vitalsign.BpSystolic)+","
				+    POut.Int   (vitalsign.BpDiastolic)+","
				+    POut.Date  (vitalsign.DateTaken)+","
				+    POut.Bool  (vitalsign.HasFollowupPlan)+","
				+    POut.Bool  (vitalsign.IsIneligible)+","
				+"'"+POut.String(vitalsign.Documentation)+"',"
				+    POut.Bool  (vitalsign.ChildGotNutrition)+","
				+    POut.Bool  (vitalsign.ChildGotPhysCouns)+","
				+"'"+POut.String(vitalsign.WeightCode)+"',"
				+"'"+POut.String(vitalsign.HeightExamCode)+"',"
				+"'"+POut.String(vitalsign.WeightExamCode)+"',"
				+"'"+POut.String(vitalsign.BMIExamCode)+"',"
				+    POut.Long  (vitalsign.EhrNotPerformedNum)+","
				+    POut.Long  (vitalsign.PregDiseaseNum)+","
				+    POut.Int   (vitalsign.BMIPercentile)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				vitalsign.VitalsignNum=Db.NonQ(command,true);
			}
			return vitalsign.VitalsignNum;
		}

		///<summary>Updates one Vitalsign in the database.</summary>
		public static void Update(Vitalsign vitalsign){
			string command="UPDATE vitalsign SET "
				+"PatNum            =  "+POut.Long  (vitalsign.PatNum)+", "
				+"Height            =  "+POut.Float (vitalsign.Height)+", "
				+"Weight            =  "+POut.Float (vitalsign.Weight)+", "
				+"BpSystolic        =  "+POut.Int   (vitalsign.BpSystolic)+", "
				+"BpDiastolic       =  "+POut.Int   (vitalsign.BpDiastolic)+", "
				+"DateTaken         =  "+POut.Date  (vitalsign.DateTaken)+", "
				+"HasFollowupPlan   =  "+POut.Bool  (vitalsign.HasFollowupPlan)+", "
				+"IsIneligible      =  "+POut.Bool  (vitalsign.IsIneligible)+", "
				+"Documentation     = '"+POut.String(vitalsign.Documentation)+"', "
				+"ChildGotNutrition =  "+POut.Bool  (vitalsign.ChildGotNutrition)+", "
				+"ChildGotPhysCouns =  "+POut.Bool  (vitalsign.ChildGotPhysCouns)+", "
				+"WeightCode        = '"+POut.String(vitalsign.WeightCode)+"', "
				+"HeightExamCode    = '"+POut.String(vitalsign.HeightExamCode)+"', "
				+"WeightExamCode    = '"+POut.String(vitalsign.WeightExamCode)+"', "
				+"BMIExamCode       = '"+POut.String(vitalsign.BMIExamCode)+"', "
				+"EhrNotPerformedNum=  "+POut.Long  (vitalsign.EhrNotPerformedNum)+", "
				+"PregDiseaseNum    =  "+POut.Long  (vitalsign.PregDiseaseNum)+", "
				+"BMIPercentile     =  "+POut.Int   (vitalsign.BMIPercentile)+" "
				+"WHERE VitalsignNum = "+POut.Long(vitalsign.VitalsignNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Vitalsign in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Vitalsign vitalsign,Vitalsign oldVitalsign){
			string command="";
			if(vitalsign.PatNum != oldVitalsign.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(vitalsign.PatNum)+"";
			}
			if(vitalsign.Height != oldVitalsign.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Float(vitalsign.Height)+"";
			}
			if(vitalsign.Weight != oldVitalsign.Weight) {
				if(command!=""){ command+=",";}
				command+="Weight = "+POut.Float(vitalsign.Weight)+"";
			}
			if(vitalsign.BpSystolic != oldVitalsign.BpSystolic) {
				if(command!=""){ command+=",";}
				command+="BpSystolic = "+POut.Int(vitalsign.BpSystolic)+"";
			}
			if(vitalsign.BpDiastolic != oldVitalsign.BpDiastolic) {
				if(command!=""){ command+=",";}
				command+="BpDiastolic = "+POut.Int(vitalsign.BpDiastolic)+"";
			}
			if(vitalsign.DateTaken != oldVitalsign.DateTaken) {
				if(command!=""){ command+=",";}
				command+="DateTaken = "+POut.Date(vitalsign.DateTaken)+"";
			}
			if(vitalsign.HasFollowupPlan != oldVitalsign.HasFollowupPlan) {
				if(command!=""){ command+=",";}
				command+="HasFollowupPlan = "+POut.Bool(vitalsign.HasFollowupPlan)+"";
			}
			if(vitalsign.IsIneligible != oldVitalsign.IsIneligible) {
				if(command!=""){ command+=",";}
				command+="IsIneligible = "+POut.Bool(vitalsign.IsIneligible)+"";
			}
			if(vitalsign.Documentation != oldVitalsign.Documentation) {
				if(command!=""){ command+=",";}
				command+="Documentation = '"+POut.String(vitalsign.Documentation)+"'";
			}
			if(vitalsign.ChildGotNutrition != oldVitalsign.ChildGotNutrition) {
				if(command!=""){ command+=",";}
				command+="ChildGotNutrition = "+POut.Bool(vitalsign.ChildGotNutrition)+"";
			}
			if(vitalsign.ChildGotPhysCouns != oldVitalsign.ChildGotPhysCouns) {
				if(command!=""){ command+=",";}
				command+="ChildGotPhysCouns = "+POut.Bool(vitalsign.ChildGotPhysCouns)+"";
			}
			if(vitalsign.WeightCode != oldVitalsign.WeightCode) {
				if(command!=""){ command+=",";}
				command+="WeightCode = '"+POut.String(vitalsign.WeightCode)+"'";
			}
			if(vitalsign.HeightExamCode != oldVitalsign.HeightExamCode) {
				if(command!=""){ command+=",";}
				command+="HeightExamCode = '"+POut.String(vitalsign.HeightExamCode)+"'";
			}
			if(vitalsign.WeightExamCode != oldVitalsign.WeightExamCode) {
				if(command!=""){ command+=",";}
				command+="WeightExamCode = '"+POut.String(vitalsign.WeightExamCode)+"'";
			}
			if(vitalsign.BMIExamCode != oldVitalsign.BMIExamCode) {
				if(command!=""){ command+=",";}
				command+="BMIExamCode = '"+POut.String(vitalsign.BMIExamCode)+"'";
			}
			if(vitalsign.EhrNotPerformedNum != oldVitalsign.EhrNotPerformedNum) {
				if(command!=""){ command+=",";}
				command+="EhrNotPerformedNum = "+POut.Long(vitalsign.EhrNotPerformedNum)+"";
			}
			if(vitalsign.PregDiseaseNum != oldVitalsign.PregDiseaseNum) {
				if(command!=""){ command+=",";}
				command+="PregDiseaseNum = "+POut.Long(vitalsign.PregDiseaseNum)+"";
			}
			if(vitalsign.BMIPercentile != oldVitalsign.BMIPercentile) {
				if(command!=""){ command+=",";}
				command+="BMIPercentile = "+POut.Int(vitalsign.BMIPercentile)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE vitalsign SET "+command
				+" WHERE VitalsignNum = "+POut.Long(vitalsign.VitalsignNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Vitalsign from the database.</summary>
		public static void Delete(long vitalsignNum){
			string command="DELETE FROM vitalsign "
				+"WHERE VitalsignNum = "+POut.Long(vitalsignNum);
			Db.NonQ(command);
		}

	}
}