//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PrefCrud {
		///<summary>Gets one Pref object from the database using the primary key.  Returns null if not found.</summary>
		public static Pref SelectOne(long prefNum){
			string command="SELECT * FROM preference "
				+"WHERE PrefNum = "+POut.Long(prefNum);
			List<Pref> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Pref object from the database using a query.</summary>
		public static Pref SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Pref> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Pref objects from the database using a query.</summary>
		public static List<Pref> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Pref> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Pref> TableToList(DataTable table){
			List<Pref> retVal=new List<Pref>();
			Pref pref;
			for(int i=0;i<table.Rows.Count;i++) {
				pref=new Pref();
				pref.PrefNum    = PIn.Long  (table.Rows[i]["PrefNum"].ToString());
				pref.PrefName   = PIn.String(table.Rows[i]["PrefName"].ToString());
				pref.ValueString= PIn.String(table.Rows[i]["ValueString"].ToString());
				pref.Comments   = PIn.String(table.Rows[i]["Comments"].ToString());
				retVal.Add(pref);
			}
			return retVal;
		}

		///<summary>Inserts one Pref into the database.  Returns the new priKey.</summary>
		public static long Insert(Pref pref){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				pref.PrefNum=DbHelper.GetNextOracleKey("preference","PrefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(pref,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							pref.PrefNum++;
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
				return Insert(pref,false);
			}
		}

		///<summary>Inserts one Pref into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Pref pref,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				pref.PrefNum=ReplicationServers.GetKey("preference","PrefNum");
			}
			string command="INSERT INTO preference (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PrefNum,";
			}
			command+="PrefName,ValueString,Comments) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(pref.PrefNum)+",";
			}
			command+=
				 "'"+POut.String(pref.PrefName)+"',"
				+"'"+POut.String(pref.ValueString)+"',"
				+"'"+POut.String(pref.Comments)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				pref.PrefNum=Db.NonQ(command,true);
			}
			return pref.PrefNum;
		}

		///<summary>Updates one Pref in the database.</summary>
		public static void Update(Pref pref){
			string command="UPDATE preference SET "
				+"PrefName   = '"+POut.String(pref.PrefName)+"', "
				+"ValueString= '"+POut.String(pref.ValueString)+"', "
				+"Comments   = '"+POut.String(pref.Comments)+"' "
				+"WHERE PrefNum = "+POut.Long(pref.PrefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Pref in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Pref pref,Pref oldPref){
			string command="";
			if(pref.PrefName != oldPref.PrefName) {
				if(command!=""){ command+=",";}
				command+="PrefName = '"+POut.String(pref.PrefName)+"'";
			}
			if(pref.ValueString != oldPref.ValueString) {
				if(command!=""){ command+=",";}
				command+="ValueString = '"+POut.String(pref.ValueString)+"'";
			}
			if(pref.Comments != oldPref.Comments) {
				if(command!=""){ command+=",";}
				command+="Comments = '"+POut.String(pref.Comments)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE preference SET "+command
				+" WHERE PrefNum = "+POut.Long(pref.PrefNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Pref from the database.</summary>
		public static void Delete(long prefNum){
			string command="DELETE FROM preference "
				+"WHERE PrefNum = "+POut.Long(prefNum);
			Db.NonQ(command);
		}

	}
}