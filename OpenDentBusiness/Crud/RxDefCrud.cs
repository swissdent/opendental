//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class RxDefCrud {
		///<summary>Gets one RxDef object from the database using the primary key.  Returns null if not found.</summary>
		public static RxDef SelectOne(long rxDefNum){
			string command="SELECT * FROM rxdef "
				+"WHERE RxDefNum = "+POut.Long(rxDefNum);
			List<RxDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one RxDef object from the database using a query.</summary>
		public static RxDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RxDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of RxDef objects from the database using a query.</summary>
		public static List<RxDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<RxDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<RxDef> TableToList(DataTable table){
			List<RxDef> retVal=new List<RxDef>();
			RxDef rxDef;
			for(int i=0;i<table.Rows.Count;i++) {
				rxDef=new RxDef();
				rxDef.RxDefNum    = PIn.Long  (table.Rows[i]["RxDefNum"].ToString());
				rxDef.Drug        = PIn.String(table.Rows[i]["Drug"].ToString());
				rxDef.Sig         = PIn.String(table.Rows[i]["Sig"].ToString());
				rxDef.Disp        = PIn.String(table.Rows[i]["Disp"].ToString());
				rxDef.Refills     = PIn.String(table.Rows[i]["Refills"].ToString());
				rxDef.Notes       = PIn.String(table.Rows[i]["Notes"].ToString());
				rxDef.IsControlled= PIn.Bool  (table.Rows[i]["IsControlled"].ToString());
				rxDef.RxCui       = PIn.Long  (table.Rows[i]["RxCui"].ToString());
				retVal.Add(rxDef);
			}
			return retVal;
		}

		///<summary>Inserts one RxDef into the database.  Returns the new priKey.</summary>
		public static long Insert(RxDef rxDef){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				rxDef.RxDefNum=DbHelper.GetNextOracleKey("rxdef","RxDefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(rxDef,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							rxDef.RxDefNum++;
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
				return Insert(rxDef,false);
			}
		}

		///<summary>Inserts one RxDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(RxDef rxDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				rxDef.RxDefNum=ReplicationServers.GetKey("rxdef","RxDefNum");
			}
			string command="INSERT INTO rxdef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="RxDefNum,";
			}
			command+="Drug,Sig,Disp,Refills,Notes,IsControlled,RxCui) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(rxDef.RxDefNum)+",";
			}
			command+=
				 "'"+POut.String(rxDef.Drug)+"',"
				+"'"+POut.String(rxDef.Sig)+"',"
				+"'"+POut.String(rxDef.Disp)+"',"
				+"'"+POut.String(rxDef.Refills)+"',"
				+"'"+POut.String(rxDef.Notes)+"',"
				+    POut.Bool  (rxDef.IsControlled)+","
				+    POut.Long  (rxDef.RxCui)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				rxDef.RxDefNum=Db.NonQ(command,true);
			}
			return rxDef.RxDefNum;
		}

		///<summary>Updates one RxDef in the database.</summary>
		public static void Update(RxDef rxDef){
			string command="UPDATE rxdef SET "
				+"Drug        = '"+POut.String(rxDef.Drug)+"', "
				+"Sig         = '"+POut.String(rxDef.Sig)+"', "
				+"Disp        = '"+POut.String(rxDef.Disp)+"', "
				+"Refills     = '"+POut.String(rxDef.Refills)+"', "
				+"Notes       = '"+POut.String(rxDef.Notes)+"', "
				+"IsControlled=  "+POut.Bool  (rxDef.IsControlled)+", "
				+"RxCui       =  "+POut.Long  (rxDef.RxCui)+" "
				+"WHERE RxDefNum = "+POut.Long(rxDef.RxDefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one RxDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(RxDef rxDef,RxDef oldRxDef){
			string command="";
			if(rxDef.Drug != oldRxDef.Drug) {
				if(command!=""){ command+=",";}
				command+="Drug = '"+POut.String(rxDef.Drug)+"'";
			}
			if(rxDef.Sig != oldRxDef.Sig) {
				if(command!=""){ command+=",";}
				command+="Sig = '"+POut.String(rxDef.Sig)+"'";
			}
			if(rxDef.Disp != oldRxDef.Disp) {
				if(command!=""){ command+=",";}
				command+="Disp = '"+POut.String(rxDef.Disp)+"'";
			}
			if(rxDef.Refills != oldRxDef.Refills) {
				if(command!=""){ command+=",";}
				command+="Refills = '"+POut.String(rxDef.Refills)+"'";
			}
			if(rxDef.Notes != oldRxDef.Notes) {
				if(command!=""){ command+=",";}
				command+="Notes = '"+POut.String(rxDef.Notes)+"'";
			}
			if(rxDef.IsControlled != oldRxDef.IsControlled) {
				if(command!=""){ command+=",";}
				command+="IsControlled = "+POut.Bool(rxDef.IsControlled)+"";
			}
			if(rxDef.RxCui != oldRxDef.RxCui) {
				if(command!=""){ command+=",";}
				command+="RxCui = "+POut.Long(rxDef.RxCui)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE rxdef SET "+command
				+" WHERE RxDefNum = "+POut.Long(rxDef.RxDefNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one RxDef from the database.</summary>
		public static void Delete(long rxDefNum){
			string command="DELETE FROM rxdef "
				+"WHERE RxDefNum = "+POut.Long(rxDefNum);
			Db.NonQ(command);
		}

	}
}