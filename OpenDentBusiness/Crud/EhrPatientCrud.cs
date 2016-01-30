//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EhrPatientCrud {
		///<summary>Gets one EhrPatient object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrPatient SelectOne(long patNum){
			string command="SELECT * FROM ehrpatient "
				+"WHERE PatNum = "+POut.Long(patNum);
			List<EhrPatient> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrPatient object from the database using a query.</summary>
		public static EhrPatient SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrPatient> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrPatient objects from the database using a query.</summary>
		public static List<EhrPatient> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrPatient> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrPatient> TableToList(DataTable table){
			List<EhrPatient> retVal=new List<EhrPatient>();
			EhrPatient ehrPatient;
			foreach(DataRow row in table.Rows) {
				ehrPatient=new EhrPatient();
				ehrPatient.PatNum           = PIn.Long  (row["PatNum"].ToString());
				ehrPatient.MotherMaidenFname= PIn.String(row["MotherMaidenFname"].ToString());
				ehrPatient.MotherMaidenLname= PIn.String(row["MotherMaidenLname"].ToString());
				ehrPatient.VacShareOk       = (OpenDentBusiness.YN)PIn.Int(row["VacShareOk"].ToString());
				ehrPatient.MedicaidState    = PIn.String(row["MedicaidState"].ToString());
				retVal.Add(ehrPatient);
			}
			return retVal;
		}

		///<summary>Converts a list of EhrPatient into a DataTable.</summary>
		public static DataTable ListToTable(List<EhrPatient> listEhrPatients,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EhrPatient";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PatNum");
			table.Columns.Add("MotherMaidenFname");
			table.Columns.Add("MotherMaidenLname");
			table.Columns.Add("VacShareOk");
			table.Columns.Add("MedicaidState");
			foreach(EhrPatient ehrPatient in listEhrPatients) {
				table.Rows.Add(new object[] {
					POut.Long  (ehrPatient.PatNum),
					POut.String(ehrPatient.MotherMaidenFname),
					POut.String(ehrPatient.MotherMaidenLname),
					POut.Int   ((int)ehrPatient.VacShareOk),
					POut.String(ehrPatient.MedicaidState),
				});
			}
			return table;
		}

		///<summary>Inserts one EhrPatient into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrPatient ehrPatient){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrPatient.PatNum=DbHelper.GetNextOracleKey("ehrpatient","PatNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrPatient,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrPatient.PatNum++;
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
				return Insert(ehrPatient,false);
			}
		}

		///<summary>Inserts one EhrPatient into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrPatient ehrPatient,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrPatient.PatNum=ReplicationServers.GetKey("ehrpatient","PatNum");
			}
			string command="INSERT INTO ehrpatient (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PatNum,";
			}
			command+="MotherMaidenFname,MotherMaidenLname,VacShareOk,MedicaidState) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrPatient.PatNum)+",";
			}
			command+=
				 "'"+POut.String(ehrPatient.MotherMaidenFname)+"',"
				+"'"+POut.String(ehrPatient.MotherMaidenLname)+"',"
				+    POut.Int   ((int)ehrPatient.VacShareOk)+","
				+"'"+POut.String(ehrPatient.MedicaidState)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrPatient.PatNum=Db.NonQ(command,true);
			}
			return ehrPatient.PatNum;
		}

		///<summary>Inserts one EhrPatient into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrPatient ehrPatient){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(ehrPatient,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					ehrPatient.PatNum=DbHelper.GetNextOracleKey("ehrpatient","PatNum"); //Cacheless method
				}
				return InsertNoCache(ehrPatient,true);
			}
		}

		///<summary>Inserts one EhrPatient into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrPatient ehrPatient,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO ehrpatient (";
			if(!useExistingPK && isRandomKeys) {
				ehrPatient.PatNum=ReplicationServers.GetKeyNoCache("ehrpatient","PatNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PatNum,";
			}
			command+="MotherMaidenFname,MotherMaidenLname,VacShareOk,MedicaidState) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(ehrPatient.PatNum)+",";
			}
			command+=
				 "'"+POut.String(ehrPatient.MotherMaidenFname)+"',"
				+"'"+POut.String(ehrPatient.MotherMaidenLname)+"',"
				+    POut.Int   ((int)ehrPatient.VacShareOk)+","
				+"'"+POut.String(ehrPatient.MedicaidState)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrPatient.PatNum=Db.NonQ(command,true);
			}
			return ehrPatient.PatNum;
		}

		///<summary>Updates one EhrPatient in the database.</summary>
		public static void Update(EhrPatient ehrPatient){
			string command="UPDATE ehrpatient SET "
				+"MotherMaidenFname= '"+POut.String(ehrPatient.MotherMaidenFname)+"', "
				+"MotherMaidenLname= '"+POut.String(ehrPatient.MotherMaidenLname)+"', "
				+"VacShareOk       =  "+POut.Int   ((int)ehrPatient.VacShareOk)+", "
				+"MedicaidState    = '"+POut.String(ehrPatient.MedicaidState)+"' "
				+"WHERE PatNum = "+POut.Long(ehrPatient.PatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrPatient in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrPatient ehrPatient,EhrPatient oldEhrPatient){
			string command="";
			if(ehrPatient.MotherMaidenFname != oldEhrPatient.MotherMaidenFname) {
				if(command!=""){ command+=",";}
				command+="MotherMaidenFname = '"+POut.String(ehrPatient.MotherMaidenFname)+"'";
			}
			if(ehrPatient.MotherMaidenLname != oldEhrPatient.MotherMaidenLname) {
				if(command!=""){ command+=",";}
				command+="MotherMaidenLname = '"+POut.String(ehrPatient.MotherMaidenLname)+"'";
			}
			if(ehrPatient.VacShareOk != oldEhrPatient.VacShareOk) {
				if(command!=""){ command+=",";}
				command+="VacShareOk = "+POut.Int   ((int)ehrPatient.VacShareOk)+"";
			}
			if(ehrPatient.MedicaidState != oldEhrPatient.MedicaidState) {
				if(command!=""){ command+=",";}
				command+="MedicaidState = '"+POut.String(ehrPatient.MedicaidState)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE ehrpatient SET "+command
				+" WHERE PatNum = "+POut.Long(ehrPatient.PatNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(EhrPatient,EhrPatient) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EhrPatient ehrPatient,EhrPatient oldEhrPatient) {
			if(ehrPatient.MotherMaidenFname != oldEhrPatient.MotherMaidenFname) {
				return true;
			}
			if(ehrPatient.MotherMaidenLname != oldEhrPatient.MotherMaidenLname) {
				return true;
			}
			if(ehrPatient.VacShareOk != oldEhrPatient.VacShareOk) {
				return true;
			}
			if(ehrPatient.MedicaidState != oldEhrPatient.MedicaidState) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EhrPatient from the database.</summary>
		public static void Delete(long patNum){
			string command="DELETE FROM ehrpatient "
				+"WHERE PatNum = "+POut.Long(patNum);
			Db.NonQ(command);
		}

	}
}