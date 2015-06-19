//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class InsFilingCodeCrud {
		///<summary>Gets one InsFilingCode object from the database using the primary key.  Returns null if not found.</summary>
		public static InsFilingCode SelectOne(long insFilingCodeNum){
			string command="SELECT * FROM insfilingcode "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCodeNum);
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsFilingCode object from the database using a query.</summary>
		public static InsFilingCode SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsFilingCode objects from the database using a query.</summary>
		public static List<InsFilingCode> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsFilingCode> TableToList(DataTable table){
			List<InsFilingCode> retVal=new List<InsFilingCode>();
			InsFilingCode insFilingCode;
			for(int i=0;i<table.Rows.Count;i++) {
				insFilingCode=new InsFilingCode();
				insFilingCode.InsFilingCodeNum= PIn.Long  (table.Rows[i]["InsFilingCodeNum"].ToString());
				insFilingCode.Descript        = PIn.String(table.Rows[i]["Descript"].ToString());
				insFilingCode.EclaimCode      = PIn.String(table.Rows[i]["EclaimCode"].ToString());
				insFilingCode.ItemOrder       = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				retVal.Add(insFilingCode);
			}
			return retVal;
		}

		///<summary>Inserts one InsFilingCode into the database.  Returns the new priKey.</summary>
		public static long Insert(InsFilingCode insFilingCode){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				insFilingCode.InsFilingCodeNum=DbHelper.GetNextOracleKey("insfilingcode","InsFilingCodeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(insFilingCode,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							insFilingCode.InsFilingCodeNum++;
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
				return Insert(insFilingCode,false);
			}
		}

		///<summary>Inserts one InsFilingCode into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsFilingCode insFilingCode,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				insFilingCode.InsFilingCodeNum=ReplicationServers.GetKey("insfilingcode","InsFilingCodeNum");
			}
			string command="INSERT INTO insfilingcode (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsFilingCodeNum,";
			}
			command+="Descript,EclaimCode,ItemOrder) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insFilingCode.InsFilingCodeNum)+",";
			}
			command+=
				 "'"+POut.String(insFilingCode.Descript)+"',"
				+"'"+POut.String(insFilingCode.EclaimCode)+"',"
				+    POut.Int   (insFilingCode.ItemOrder)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				insFilingCode.InsFilingCodeNum=Db.NonQ(command,true);
			}
			return insFilingCode.InsFilingCodeNum;
		}

		///<summary>Inserts one InsFilingCode into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCode insFilingCode){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(insFilingCode,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					insFilingCode.InsFilingCodeNum=DbHelper.GetNextOracleKey("insfilingcode","InsFilingCodeNum"); //Cacheless method
				}
				return InsertNoCache(insFilingCode,true);
			}
		}

		///<summary>Inserts one InsFilingCode into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCode insFilingCode,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO insfilingcode (";
			if(!useExistingPK && isRandomKeys) {
				insFilingCode.InsFilingCodeNum=ReplicationServers.GetKeyNoCache("insfilingcode","InsFilingCodeNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="InsFilingCodeNum,";
			}
			command+="Descript,EclaimCode,ItemOrder) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(insFilingCode.InsFilingCodeNum)+",";
			}
			command+=
				 "'"+POut.String(insFilingCode.Descript)+"',"
				+"'"+POut.String(insFilingCode.EclaimCode)+"',"
				+    POut.Int   (insFilingCode.ItemOrder)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				insFilingCode.InsFilingCodeNum=Db.NonQ(command,true);
			}
			return insFilingCode.InsFilingCodeNum;
		}

		///<summary>Updates one InsFilingCode in the database.</summary>
		public static void Update(InsFilingCode insFilingCode){
			string command="UPDATE insfilingcode SET "
				+"Descript        = '"+POut.String(insFilingCode.Descript)+"', "
				+"EclaimCode      = '"+POut.String(insFilingCode.EclaimCode)+"', "
				+"ItemOrder       =  "+POut.Int   (insFilingCode.ItemOrder)+" "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCode.InsFilingCodeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one InsFilingCode in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsFilingCode insFilingCode,InsFilingCode oldInsFilingCode){
			string command="";
			if(insFilingCode.Descript != oldInsFilingCode.Descript) {
				if(command!=""){ command+=",";}
				command+="Descript = '"+POut.String(insFilingCode.Descript)+"'";
			}
			if(insFilingCode.EclaimCode != oldInsFilingCode.EclaimCode) {
				if(command!=""){ command+=",";}
				command+="EclaimCode = '"+POut.String(insFilingCode.EclaimCode)+"'";
			}
			if(insFilingCode.ItemOrder != oldInsFilingCode.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(insFilingCode.ItemOrder)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE insfilingcode SET "+command
				+" WHERE InsFilingCodeNum = "+POut.Long(insFilingCode.InsFilingCodeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one InsFilingCode from the database.</summary>
		public static void Delete(long insFilingCodeNum){
			string command="DELETE FROM insfilingcode "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCodeNum);
			Db.NonQ(command);
		}

	}
}