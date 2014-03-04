//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ProgramPropertyCrud {
		///<summary>Gets one ProgramProperty object from the database using the primary key.  Returns null if not found.</summary>
		public static ProgramProperty SelectOne(long programPropertyNum){
			string command="SELECT * FROM programproperty "
				+"WHERE ProgramPropertyNum = "+POut.Long(programPropertyNum);
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProgramProperty object from the database using a query.</summary>
		public static ProgramProperty SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProgramProperty objects from the database using a query.</summary>
		public static List<ProgramProperty> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProgramProperty> TableToList(DataTable table){
			List<ProgramProperty> retVal=new List<ProgramProperty>();
			ProgramProperty programProperty;
			for(int i=0;i<table.Rows.Count;i++) {
				programProperty=new ProgramProperty();
				programProperty.ProgramPropertyNum= PIn.Long  (table.Rows[i]["ProgramPropertyNum"].ToString());
				programProperty.ProgramNum        = PIn.Long  (table.Rows[i]["ProgramNum"].ToString());
				programProperty.PropertyDesc      = PIn.String(table.Rows[i]["PropertyDesc"].ToString());
				programProperty.PropertyValue     = PIn.String(table.Rows[i]["PropertyValue"].ToString());
				programProperty.ComputerName      = PIn.String(table.Rows[i]["ComputerName"].ToString());
				retVal.Add(programProperty);
			}
			return retVal;
		}

		///<summary>Inserts one ProgramProperty into the database.  Returns the new priKey.</summary>
		public static long Insert(ProgramProperty programProperty){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				programProperty.ProgramPropertyNum=DbHelper.GetNextOracleKey("programproperty","ProgramPropertyNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(programProperty,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							programProperty.ProgramPropertyNum++;
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
				return Insert(programProperty,false);
			}
		}

		///<summary>Inserts one ProgramProperty into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProgramProperty programProperty,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				programProperty.ProgramPropertyNum=ReplicationServers.GetKey("programproperty","ProgramPropertyNum");
			}
			string command="INSERT INTO programproperty (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProgramPropertyNum,";
			}
			command+="ProgramNum,PropertyDesc,PropertyValue,ComputerName) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(programProperty.ProgramPropertyNum)+",";
			}
			command+=
				     POut.Long  (programProperty.ProgramNum)+","
				+"'"+POut.String(programProperty.PropertyDesc)+"',"
				+"'"+POut.String(programProperty.PropertyValue)+"',"
				+"'"+POut.String(programProperty.ComputerName)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				programProperty.ProgramPropertyNum=Db.NonQ(command,true);
			}
			return programProperty.ProgramPropertyNum;
		}

		///<summary>Updates one ProgramProperty in the database.</summary>
		public static void Update(ProgramProperty programProperty){
			string command="UPDATE programproperty SET "
				+"ProgramNum        =  "+POut.Long  (programProperty.ProgramNum)+", "
				+"PropertyDesc      = '"+POut.String(programProperty.PropertyDesc)+"', "
				+"PropertyValue     = '"+POut.String(programProperty.PropertyValue)+"', "
				+"ComputerName      = '"+POut.String(programProperty.ComputerName)+"' "
				+"WHERE ProgramPropertyNum = "+POut.Long(programProperty.ProgramPropertyNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ProgramProperty in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProgramProperty programProperty,ProgramProperty oldProgramProperty){
			string command="";
			if(programProperty.ProgramNum != oldProgramProperty.ProgramNum) {
				if(command!=""){ command+=",";}
				command+="ProgramNum = "+POut.Long(programProperty.ProgramNum)+"";
			}
			if(programProperty.PropertyDesc != oldProgramProperty.PropertyDesc) {
				if(command!=""){ command+=",";}
				command+="PropertyDesc = '"+POut.String(programProperty.PropertyDesc)+"'";
			}
			if(programProperty.PropertyValue != oldProgramProperty.PropertyValue) {
				if(command!=""){ command+=",";}
				command+="PropertyValue = '"+POut.String(programProperty.PropertyValue)+"'";
			}
			if(programProperty.ComputerName != oldProgramProperty.ComputerName) {
				if(command!=""){ command+=",";}
				command+="ComputerName = '"+POut.String(programProperty.ComputerName)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE programproperty SET "+command
				+" WHERE ProgramPropertyNum = "+POut.Long(programProperty.ProgramPropertyNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ProgramProperty from the database.</summary>
		public static void Delete(long programPropertyNum){
			string command="DELETE FROM programproperty "
				+"WHERE ProgramPropertyNum = "+POut.Long(programPropertyNum);
			Db.NonQ(command);
		}

	}
}