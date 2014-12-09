//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScreenCrud {
		///<summary>Gets one Screen object from the database using the primary key.  Returns null if not found.</summary>
		public static Screen SelectOne(long screenNum){
			string command="SELECT * FROM screen "
				+"WHERE ScreenNum = "+POut.Long(screenNum);
			List<Screen> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Screen object from the database using a query.</summary>
		public static Screen SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Screen> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Screen objects from the database using a query.</summary>
		public static List<Screen> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Screen> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Screen> TableToList(DataTable table){
			List<Screen> retVal=new List<Screen>();
			Screen screen;
			for(int i=0;i<table.Rows.Count;i++) {
				screen=new Screen();
				screen.ScreenNum       = PIn.Long  (table.Rows[i]["ScreenNum"].ToString());
				screen.ScreenDate      = PIn.Date  (table.Rows[i]["ScreenDate"].ToString());
				screen.GradeSchool     = PIn.String(table.Rows[i]["GradeSchool"].ToString());
				screen.County          = PIn.String(table.Rows[i]["County"].ToString());
				screen.PlaceService    = (OpenDentBusiness.PlaceOfService)PIn.Int(table.Rows[i]["PlaceService"].ToString());
				screen.ProvNum         = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				screen.ProvName        = PIn.String(table.Rows[i]["ProvName"].ToString());
				screen.Gender          = (OpenDentBusiness.PatientGender)PIn.Int(table.Rows[i]["Gender"].ToString());
				screen.RaceOld         = (OpenDentBusiness.PatientRaceOld)PIn.Int(table.Rows[i]["RaceOld"].ToString());
				screen.GradeLevel      = (OpenDentBusiness.PatientGrade)PIn.Int(table.Rows[i]["GradeLevel"].ToString());
				screen.Age             = PIn.Byte  (table.Rows[i]["Age"].ToString());
				screen.Urgency         = (OpenDentBusiness.TreatmentUrgency)PIn.Int(table.Rows[i]["Urgency"].ToString());
				screen.HasCaries       = (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["HasCaries"].ToString());
				screen.NeedsSealants   = (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["NeedsSealants"].ToString());
				screen.CariesExperience= (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["CariesExperience"].ToString());
				screen.EarlyChildCaries= (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["EarlyChildCaries"].ToString());
				screen.ExistingSealants= (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["ExistingSealants"].ToString());
				screen.MissingAllTeeth = (OpenDentBusiness.YN)PIn.Int(table.Rows[i]["MissingAllTeeth"].ToString());
				screen.Birthdate       = PIn.Date  (table.Rows[i]["Birthdate"].ToString());
				screen.ScreenGroupNum  = PIn.Long  (table.Rows[i]["ScreenGroupNum"].ToString());
				screen.ScreenGroupOrder= PIn.Int   (table.Rows[i]["ScreenGroupOrder"].ToString());
				screen.Comments        = PIn.String(table.Rows[i]["Comments"].ToString());
				retVal.Add(screen);
			}
			return retVal;
		}

		///<summary>Inserts one Screen into the database.  Returns the new priKey.</summary>
		public static long Insert(Screen screen){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				screen.ScreenNum=DbHelper.GetNextOracleKey("screen","ScreenNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(screen,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							screen.ScreenNum++;
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
				return Insert(screen,false);
			}
		}

		///<summary>Inserts one Screen into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Screen screen,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				screen.ScreenNum=ReplicationServers.GetKey("screen","ScreenNum");
			}
			string command="INSERT INTO screen (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScreenNum,";
			}
			command+="ScreenDate,GradeSchool,County,PlaceService,ProvNum,ProvName,Gender,RaceOld,GradeLevel,Age,Urgency,HasCaries,NeedsSealants,CariesExperience,EarlyChildCaries,ExistingSealants,MissingAllTeeth,Birthdate,ScreenGroupNum,ScreenGroupOrder,Comments) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(screen.ScreenNum)+",";
			}
			command+=
				     POut.Date  (screen.ScreenDate)+","
				+"'"+POut.String(screen.GradeSchool)+"',"
				+"'"+POut.String(screen.County)+"',"
				+    POut.Int   ((int)screen.PlaceService)+","
				+    POut.Long  (screen.ProvNum)+","
				+"'"+POut.String(screen.ProvName)+"',"
				+    POut.Int   ((int)screen.Gender)+","
				+    POut.Int   ((int)screen.RaceOld)+","
				+    POut.Int   ((int)screen.GradeLevel)+","
				+    POut.Byte  (screen.Age)+","
				+    POut.Int   ((int)screen.Urgency)+","
				+    POut.Int   ((int)screen.HasCaries)+","
				+    POut.Int   ((int)screen.NeedsSealants)+","
				+    POut.Int   ((int)screen.CariesExperience)+","
				+    POut.Int   ((int)screen.EarlyChildCaries)+","
				+    POut.Int   ((int)screen.ExistingSealants)+","
				+    POut.Int   ((int)screen.MissingAllTeeth)+","
				+    POut.Date  (screen.Birthdate)+","
				+    POut.Long  (screen.ScreenGroupNum)+","
				+    POut.Int   (screen.ScreenGroupOrder)+","
				+"'"+POut.String(screen.Comments)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				screen.ScreenNum=Db.NonQ(command,true);
			}
			return screen.ScreenNum;
		}

		///<summary>Updates one Screen in the database.</summary>
		public static void Update(Screen screen){
			string command="UPDATE screen SET "
				+"ScreenDate      =  "+POut.Date  (screen.ScreenDate)+", "
				+"GradeSchool     = '"+POut.String(screen.GradeSchool)+"', "
				+"County          = '"+POut.String(screen.County)+"', "
				+"PlaceService    =  "+POut.Int   ((int)screen.PlaceService)+", "
				+"ProvNum         =  "+POut.Long  (screen.ProvNum)+", "
				+"ProvName        = '"+POut.String(screen.ProvName)+"', "
				+"Gender          =  "+POut.Int   ((int)screen.Gender)+", "
				+"RaceOld         =  "+POut.Int   ((int)screen.RaceOld)+", "
				+"GradeLevel      =  "+POut.Int   ((int)screen.GradeLevel)+", "
				+"Age             =  "+POut.Byte  (screen.Age)+", "
				+"Urgency         =  "+POut.Int   ((int)screen.Urgency)+", "
				+"HasCaries       =  "+POut.Int   ((int)screen.HasCaries)+", "
				+"NeedsSealants   =  "+POut.Int   ((int)screen.NeedsSealants)+", "
				+"CariesExperience=  "+POut.Int   ((int)screen.CariesExperience)+", "
				+"EarlyChildCaries=  "+POut.Int   ((int)screen.EarlyChildCaries)+", "
				+"ExistingSealants=  "+POut.Int   ((int)screen.ExistingSealants)+", "
				+"MissingAllTeeth =  "+POut.Int   ((int)screen.MissingAllTeeth)+", "
				+"Birthdate       =  "+POut.Date  (screen.Birthdate)+", "
				+"ScreenGroupNum  =  "+POut.Long  (screen.ScreenGroupNum)+", "
				+"ScreenGroupOrder=  "+POut.Int   (screen.ScreenGroupOrder)+", "
				+"Comments        = '"+POut.String(screen.Comments)+"' "
				+"WHERE ScreenNum = "+POut.Long(screen.ScreenNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Screen in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Screen screen,Screen oldScreen){
			string command="";
			if(screen.ScreenDate != oldScreen.ScreenDate) {
				if(command!=""){ command+=",";}
				command+="ScreenDate = "+POut.Date(screen.ScreenDate)+"";
			}
			if(screen.GradeSchool != oldScreen.GradeSchool) {
				if(command!=""){ command+=",";}
				command+="GradeSchool = '"+POut.String(screen.GradeSchool)+"'";
			}
			if(screen.County != oldScreen.County) {
				if(command!=""){ command+=",";}
				command+="County = '"+POut.String(screen.County)+"'";
			}
			if(screen.PlaceService != oldScreen.PlaceService) {
				if(command!=""){ command+=",";}
				command+="PlaceService = "+POut.Int   ((int)screen.PlaceService)+"";
			}
			if(screen.ProvNum != oldScreen.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(screen.ProvNum)+"";
			}
			if(screen.ProvName != oldScreen.ProvName) {
				if(command!=""){ command+=",";}
				command+="ProvName = '"+POut.String(screen.ProvName)+"'";
			}
			if(screen.Gender != oldScreen.Gender) {
				if(command!=""){ command+=",";}
				command+="Gender = "+POut.Int   ((int)screen.Gender)+"";
			}
			if(screen.RaceOld != oldScreen.RaceOld) {
				if(command!=""){ command+=",";}
				command+="RaceOld = "+POut.Int   ((int)screen.RaceOld)+"";
			}
			if(screen.GradeLevel != oldScreen.GradeLevel) {
				if(command!=""){ command+=",";}
				command+="GradeLevel = "+POut.Int   ((int)screen.GradeLevel)+"";
			}
			if(screen.Age != oldScreen.Age) {
				if(command!=""){ command+=",";}
				command+="Age = "+POut.Byte(screen.Age)+"";
			}
			if(screen.Urgency != oldScreen.Urgency) {
				if(command!=""){ command+=",";}
				command+="Urgency = "+POut.Int   ((int)screen.Urgency)+"";
			}
			if(screen.HasCaries != oldScreen.HasCaries) {
				if(command!=""){ command+=",";}
				command+="HasCaries = "+POut.Int   ((int)screen.HasCaries)+"";
			}
			if(screen.NeedsSealants != oldScreen.NeedsSealants) {
				if(command!=""){ command+=",";}
				command+="NeedsSealants = "+POut.Int   ((int)screen.NeedsSealants)+"";
			}
			if(screen.CariesExperience != oldScreen.CariesExperience) {
				if(command!=""){ command+=",";}
				command+="CariesExperience = "+POut.Int   ((int)screen.CariesExperience)+"";
			}
			if(screen.EarlyChildCaries != oldScreen.EarlyChildCaries) {
				if(command!=""){ command+=",";}
				command+="EarlyChildCaries = "+POut.Int   ((int)screen.EarlyChildCaries)+"";
			}
			if(screen.ExistingSealants != oldScreen.ExistingSealants) {
				if(command!=""){ command+=",";}
				command+="ExistingSealants = "+POut.Int   ((int)screen.ExistingSealants)+"";
			}
			if(screen.MissingAllTeeth != oldScreen.MissingAllTeeth) {
				if(command!=""){ command+=",";}
				command+="MissingAllTeeth = "+POut.Int   ((int)screen.MissingAllTeeth)+"";
			}
			if(screen.Birthdate != oldScreen.Birthdate) {
				if(command!=""){ command+=",";}
				command+="Birthdate = "+POut.Date(screen.Birthdate)+"";
			}
			if(screen.ScreenGroupNum != oldScreen.ScreenGroupNum) {
				if(command!=""){ command+=",";}
				command+="ScreenGroupNum = "+POut.Long(screen.ScreenGroupNum)+"";
			}
			if(screen.ScreenGroupOrder != oldScreen.ScreenGroupOrder) {
				if(command!=""){ command+=",";}
				command+="ScreenGroupOrder = "+POut.Int(screen.ScreenGroupOrder)+"";
			}
			if(screen.Comments != oldScreen.Comments) {
				if(command!=""){ command+=",";}
				command+="Comments = '"+POut.String(screen.Comments)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE screen SET "+command
				+" WHERE ScreenNum = "+POut.Long(screen.ScreenNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Screen from the database.</summary>
		public static void Delete(long screenNum){
			string command="DELETE FROM screen "
				+"WHERE ScreenNum = "+POut.Long(screenNum);
			Db.NonQ(command);
		}

	}
}