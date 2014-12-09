//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class CovCatCrud {
		///<summary>Gets one CovCat object from the database using the primary key.  Returns null if not found.</summary>
		public static CovCat SelectOne(long covCatNum){
			string command="SELECT * FROM covcat "
				+"WHERE CovCatNum = "+POut.Long(covCatNum);
			List<CovCat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CovCat object from the database using a query.</summary>
		public static CovCat SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovCat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CovCat objects from the database using a query.</summary>
		public static List<CovCat> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovCat> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<CovCat> TableToList(DataTable table){
			List<CovCat> retVal=new List<CovCat>();
			CovCat covCat;
			for(int i=0;i<table.Rows.Count;i++) {
				covCat=new CovCat();
				covCat.CovCatNum     = PIn.Long  (table.Rows[i]["CovCatNum"].ToString());
				covCat.Description   = PIn.String(table.Rows[i]["Description"].ToString());
				covCat.DefaultPercent= PIn.Int   (table.Rows[i]["DefaultPercent"].ToString());
				covCat.CovOrder      = PIn.Byte  (table.Rows[i]["CovOrder"].ToString());
				covCat.IsHidden      = PIn.Bool  (table.Rows[i]["IsHidden"].ToString());
				covCat.EbenefitCat   = (OpenDentBusiness.EbenefitCategory)PIn.Int(table.Rows[i]["EbenefitCat"].ToString());
				retVal.Add(covCat);
			}
			return retVal;
		}

		///<summary>Inserts one CovCat into the database.  Returns the new priKey.</summary>
		public static long Insert(CovCat covCat){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				covCat.CovCatNum=DbHelper.GetNextOracleKey("covcat","CovCatNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(covCat,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							covCat.CovCatNum++;
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
				return Insert(covCat,false);
			}
		}

		///<summary>Inserts one CovCat into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(CovCat covCat,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				covCat.CovCatNum=ReplicationServers.GetKey("covcat","CovCatNum");
			}
			string command="INSERT INTO covcat (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CovCatNum,";
			}
			command+="Description,DefaultPercent,CovOrder,IsHidden,EbenefitCat) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(covCat.CovCatNum)+",";
			}
			command+=
				 "'"+POut.String(covCat.Description)+"',"
				+    POut.Int   (covCat.DefaultPercent)+","
				+    POut.Byte  (covCat.CovOrder)+","
				+    POut.Bool  (covCat.IsHidden)+","
				+    POut.Int   ((int)covCat.EbenefitCat)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				covCat.CovCatNum=Db.NonQ(command,true);
			}
			return covCat.CovCatNum;
		}

		///<summary>Updates one CovCat in the database.</summary>
		public static void Update(CovCat covCat){
			string command="UPDATE covcat SET "
				+"Description   = '"+POut.String(covCat.Description)+"', "
				+"DefaultPercent=  "+POut.Int   (covCat.DefaultPercent)+", "
				+"CovOrder      =  "+POut.Byte  (covCat.CovOrder)+", "
				+"IsHidden      =  "+POut.Bool  (covCat.IsHidden)+", "
				+"EbenefitCat   =  "+POut.Int   ((int)covCat.EbenefitCat)+" "
				+"WHERE CovCatNum = "+POut.Long(covCat.CovCatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CovCat in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(CovCat covCat,CovCat oldCovCat){
			string command="";
			if(covCat.Description != oldCovCat.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(covCat.Description)+"'";
			}
			if(covCat.DefaultPercent != oldCovCat.DefaultPercent) {
				if(command!=""){ command+=",";}
				command+="DefaultPercent = "+POut.Int(covCat.DefaultPercent)+"";
			}
			if(covCat.CovOrder != oldCovCat.CovOrder) {
				if(command!=""){ command+=",";}
				command+="CovOrder = "+POut.Byte(covCat.CovOrder)+"";
			}
			if(covCat.IsHidden != oldCovCat.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(covCat.IsHidden)+"";
			}
			if(covCat.EbenefitCat != oldCovCat.EbenefitCat) {
				if(command!=""){ command+=",";}
				command+="EbenefitCat = "+POut.Int   ((int)covCat.EbenefitCat)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE covcat SET "+command
				+" WHERE CovCatNum = "+POut.Long(covCat.CovCatNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one CovCat from the database.</summary>
		public static void Delete(long covCatNum){
			string command="DELETE FROM covcat "
				+"WHERE CovCatNum = "+POut.Long(covCatNum);
			Db.NonQ(command);
		}

	}
}