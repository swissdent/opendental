//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ApptViewItemCrud {
		///<summary>Gets one ApptViewItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptViewItem SelectOne(long apptViewItemNum){
			string command="SELECT * FROM apptviewitem "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItemNum);
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptViewItem object from the database using a query.</summary>
		public static ApptViewItem SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptViewItem objects from the database using a query.</summary>
		public static List<ApptViewItem> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptViewItem> TableToList(DataTable table){
			List<ApptViewItem> retVal=new List<ApptViewItem>();
			ApptViewItem apptViewItem;
			for(int i=0;i<table.Rows.Count;i++) {
				apptViewItem=new ApptViewItem();
				apptViewItem.ApptViewItemNum = PIn.Long  (table.Rows[i]["ApptViewItemNum"].ToString());
				apptViewItem.ApptViewNum     = PIn.Long  (table.Rows[i]["ApptViewNum"].ToString());
				apptViewItem.OpNum           = PIn.Long  (table.Rows[i]["OpNum"].ToString());
				apptViewItem.ProvNum         = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				apptViewItem.ElementDesc     = PIn.String(table.Rows[i]["ElementDesc"].ToString());
				apptViewItem.ElementOrder    = PIn.Byte  (table.Rows[i]["ElementOrder"].ToString());
				apptViewItem.ElementColor    = Color.FromArgb(PIn.Int(table.Rows[i]["ElementColor"].ToString()));
				apptViewItem.ElementAlignment= (OpenDentBusiness.ApptViewAlignment)PIn.Int(table.Rows[i]["ElementAlignment"].ToString());
				apptViewItem.ApptFieldDefNum = PIn.Long  (table.Rows[i]["ApptFieldDefNum"].ToString());
				apptViewItem.PatFieldDefNum  = PIn.Long  (table.Rows[i]["PatFieldDefNum"].ToString());
				retVal.Add(apptViewItem);
			}
			return retVal;
		}

		///<summary>Inserts one ApptViewItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptViewItem apptViewItem){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				apptViewItem.ApptViewItemNum=DbHelper.GetNextOracleKey("apptviewitem","ApptViewItemNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(apptViewItem,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							apptViewItem.ApptViewItemNum++;
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
				return Insert(apptViewItem,false);
			}
		}

		///<summary>Inserts one ApptViewItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptViewItem apptViewItem,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				apptViewItem.ApptViewItemNum=ReplicationServers.GetKey("apptviewitem","ApptViewItemNum");
			}
			string command="INSERT INTO apptviewitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptViewItemNum,";
			}
			command+="ApptViewNum,OpNum,ProvNum,ElementDesc,ElementOrder,ElementColor,ElementAlignment,ApptFieldDefNum,PatFieldDefNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptViewItem.ApptViewItemNum)+",";
			}
			command+=
				     POut.Long  (apptViewItem.ApptViewNum)+","
				+    POut.Long  (apptViewItem.OpNum)+","
				+    POut.Long  (apptViewItem.ProvNum)+","
				+"'"+POut.String(apptViewItem.ElementDesc)+"',"
				+    POut.Byte  (apptViewItem.ElementOrder)+","
				+    POut.Int   (apptViewItem.ElementColor.ToArgb())+","
				+    POut.Int   ((int)apptViewItem.ElementAlignment)+","
				+    POut.Long  (apptViewItem.ApptFieldDefNum)+","
				+    POut.Long  (apptViewItem.PatFieldDefNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptViewItem.ApptViewItemNum=Db.NonQ(command,true);
			}
			return apptViewItem.ApptViewItemNum;
		}

		///<summary>Inserts one ApptViewItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptViewItem apptViewItem){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(apptViewItem,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					apptViewItem.ApptViewItemNum=DbHelper.GetNextOracleKey("apptviewitem","ApptViewItemNum"); //Cacheless method
				}
				return InsertNoCache(apptViewItem,true);
			}
		}

		///<summary>Inserts one ApptViewItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptViewItem apptViewItem,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO apptviewitem (";
			if(!useExistingPK && isRandomKeys) {
				apptViewItem.ApptViewItemNum=ReplicationServers.GetKeyNoCache("apptviewitem","ApptViewItemNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ApptViewItemNum,";
			}
			command+="ApptViewNum,OpNum,ProvNum,ElementDesc,ElementOrder,ElementColor,ElementAlignment,ApptFieldDefNum,PatFieldDefNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(apptViewItem.ApptViewItemNum)+",";
			}
			command+=
				     POut.Long  (apptViewItem.ApptViewNum)+","
				+    POut.Long  (apptViewItem.OpNum)+","
				+    POut.Long  (apptViewItem.ProvNum)+","
				+"'"+POut.String(apptViewItem.ElementDesc)+"',"
				+    POut.Byte  (apptViewItem.ElementOrder)+","
				+    POut.Int   (apptViewItem.ElementColor.ToArgb())+","
				+    POut.Int   ((int)apptViewItem.ElementAlignment)+","
				+    POut.Long  (apptViewItem.ApptFieldDefNum)+","
				+    POut.Long  (apptViewItem.PatFieldDefNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptViewItem.ApptViewItemNum=Db.NonQ(command,true);
			}
			return apptViewItem.ApptViewItemNum;
		}

		///<summary>Updates one ApptViewItem in the database.</summary>
		public static void Update(ApptViewItem apptViewItem){
			string command="UPDATE apptviewitem SET "
				+"ApptViewNum     =  "+POut.Long  (apptViewItem.ApptViewNum)+", "
				+"OpNum           =  "+POut.Long  (apptViewItem.OpNum)+", "
				+"ProvNum         =  "+POut.Long  (apptViewItem.ProvNum)+", "
				+"ElementDesc     = '"+POut.String(apptViewItem.ElementDesc)+"', "
				+"ElementOrder    =  "+POut.Byte  (apptViewItem.ElementOrder)+", "
				+"ElementColor    =  "+POut.Int   (apptViewItem.ElementColor.ToArgb())+", "
				+"ElementAlignment=  "+POut.Int   ((int)apptViewItem.ElementAlignment)+", "
				+"ApptFieldDefNum =  "+POut.Long  (apptViewItem.ApptFieldDefNum)+", "
				+"PatFieldDefNum  =  "+POut.Long  (apptViewItem.PatFieldDefNum)+" "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItem.ApptViewItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ApptViewItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptViewItem apptViewItem,ApptViewItem oldApptViewItem){
			string command="";
			if(apptViewItem.ApptViewNum != oldApptViewItem.ApptViewNum) {
				if(command!=""){ command+=",";}
				command+="ApptViewNum = "+POut.Long(apptViewItem.ApptViewNum)+"";
			}
			if(apptViewItem.OpNum != oldApptViewItem.OpNum) {
				if(command!=""){ command+=",";}
				command+="OpNum = "+POut.Long(apptViewItem.OpNum)+"";
			}
			if(apptViewItem.ProvNum != oldApptViewItem.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(apptViewItem.ProvNum)+"";
			}
			if(apptViewItem.ElementDesc != oldApptViewItem.ElementDesc) {
				if(command!=""){ command+=",";}
				command+="ElementDesc = '"+POut.String(apptViewItem.ElementDesc)+"'";
			}
			if(apptViewItem.ElementOrder != oldApptViewItem.ElementOrder) {
				if(command!=""){ command+=",";}
				command+="ElementOrder = "+POut.Byte(apptViewItem.ElementOrder)+"";
			}
			if(apptViewItem.ElementColor != oldApptViewItem.ElementColor) {
				if(command!=""){ command+=",";}
				command+="ElementColor = "+POut.Int(apptViewItem.ElementColor.ToArgb())+"";
			}
			if(apptViewItem.ElementAlignment != oldApptViewItem.ElementAlignment) {
				if(command!=""){ command+=",";}
				command+="ElementAlignment = "+POut.Int   ((int)apptViewItem.ElementAlignment)+"";
			}
			if(apptViewItem.ApptFieldDefNum != oldApptViewItem.ApptFieldDefNum) {
				if(command!=""){ command+=",";}
				command+="ApptFieldDefNum = "+POut.Long(apptViewItem.ApptFieldDefNum)+"";
			}
			if(apptViewItem.PatFieldDefNum != oldApptViewItem.PatFieldDefNum) {
				if(command!=""){ command+=",";}
				command+="PatFieldDefNum = "+POut.Long(apptViewItem.PatFieldDefNum)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE apptviewitem SET "+command
				+" WHERE ApptViewItemNum = "+POut.Long(apptViewItem.ApptViewItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one ApptViewItem from the database.</summary>
		public static void Delete(long apptViewItemNum){
			string command="DELETE FROM apptviewitem "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItemNum);
			Db.NonQ(command);
		}

	}
}