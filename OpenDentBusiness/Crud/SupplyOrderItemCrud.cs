//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SupplyOrderItemCrud {
		///<summary>Gets one SupplyOrderItem object from the database using the primary key.  Returns null if not found.</summary>
		public static SupplyOrderItem SelectOne(long supplyOrderItemNum){
			string command="SELECT * FROM supplyorderitem "
				+"WHERE SupplyOrderItemNum = "+POut.Long(supplyOrderItemNum);
			List<SupplyOrderItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SupplyOrderItem object from the database using a query.</summary>
		public static SupplyOrderItem SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SupplyOrderItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SupplyOrderItem objects from the database using a query.</summary>
		public static List<SupplyOrderItem> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SupplyOrderItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SupplyOrderItem> TableToList(DataTable table){
			List<SupplyOrderItem> retVal=new List<SupplyOrderItem>();
			SupplyOrderItem supplyOrderItem;
			for(int i=0;i<table.Rows.Count;i++) {
				supplyOrderItem=new SupplyOrderItem();
				supplyOrderItem.SupplyOrderItemNum= PIn.Long  (table.Rows[i]["SupplyOrderItemNum"].ToString());
				supplyOrderItem.SupplyOrderNum    = PIn.Long  (table.Rows[i]["SupplyOrderNum"].ToString());
				supplyOrderItem.SupplyNum         = PIn.Long  (table.Rows[i]["SupplyNum"].ToString());
				supplyOrderItem.Qty               = PIn.Int   (table.Rows[i]["Qty"].ToString());
				supplyOrderItem.Price             = PIn.Double(table.Rows[i]["Price"].ToString());
				retVal.Add(supplyOrderItem);
			}
			return retVal;
		}

		///<summary>Inserts one SupplyOrderItem into the database.  Returns the new priKey.</summary>
		public static long Insert(SupplyOrderItem supplyOrderItem){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				supplyOrderItem.SupplyOrderItemNum=DbHelper.GetNextOracleKey("supplyorderitem","SupplyOrderItemNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(supplyOrderItem,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							supplyOrderItem.SupplyOrderItemNum++;
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
				return Insert(supplyOrderItem,false);
			}
		}

		///<summary>Inserts one SupplyOrderItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SupplyOrderItem supplyOrderItem,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				supplyOrderItem.SupplyOrderItemNum=ReplicationServers.GetKey("supplyorderitem","SupplyOrderItemNum");
			}
			string command="INSERT INTO supplyorderitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SupplyOrderItemNum,";
			}
			command+="SupplyOrderNum,SupplyNum,Qty,Price) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(supplyOrderItem.SupplyOrderItemNum)+",";
			}
			command+=
				     POut.Long  (supplyOrderItem.SupplyOrderNum)+","
				+    POut.Long  (supplyOrderItem.SupplyNum)+","
				+    POut.Int   (supplyOrderItem.Qty)+","
				+"'"+POut.Double(supplyOrderItem.Price)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				supplyOrderItem.SupplyOrderItemNum=Db.NonQ(command,true);
			}
			return supplyOrderItem.SupplyOrderItemNum;
		}

		///<summary>Inserts one SupplyOrderItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SupplyOrderItem supplyOrderItem){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(supplyOrderItem,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					supplyOrderItem.SupplyOrderItemNum=DbHelper.GetNextOracleKey("supplyorderitem","SupplyOrderItemNum"); //Cacheless method
				}
				return InsertNoCache(supplyOrderItem,true);
			}
		}

		///<summary>Inserts one SupplyOrderItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SupplyOrderItem supplyOrderItem,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO supplyorderitem (";
			if(!useExistingPK && isRandomKeys) {
				supplyOrderItem.SupplyOrderItemNum=ReplicationServers.GetKeyNoCache("supplyorderitem","SupplyOrderItemNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SupplyOrderItemNum,";
			}
			command+="SupplyOrderNum,SupplyNum,Qty,Price) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(supplyOrderItem.SupplyOrderItemNum)+",";
			}
			command+=
				     POut.Long  (supplyOrderItem.SupplyOrderNum)+","
				+    POut.Long  (supplyOrderItem.SupplyNum)+","
				+    POut.Int   (supplyOrderItem.Qty)+","
				+"'"+POut.Double(supplyOrderItem.Price)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				supplyOrderItem.SupplyOrderItemNum=Db.NonQ(command,true);
			}
			return supplyOrderItem.SupplyOrderItemNum;
		}

		///<summary>Updates one SupplyOrderItem in the database.</summary>
		public static void Update(SupplyOrderItem supplyOrderItem){
			string command="UPDATE supplyorderitem SET "
				+"SupplyOrderNum    =  "+POut.Long  (supplyOrderItem.SupplyOrderNum)+", "
				+"SupplyNum         =  "+POut.Long  (supplyOrderItem.SupplyNum)+", "
				+"Qty               =  "+POut.Int   (supplyOrderItem.Qty)+", "
				+"Price             = '"+POut.Double(supplyOrderItem.Price)+"' "
				+"WHERE SupplyOrderItemNum = "+POut.Long(supplyOrderItem.SupplyOrderItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SupplyOrderItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SupplyOrderItem supplyOrderItem,SupplyOrderItem oldSupplyOrderItem){
			string command="";
			if(supplyOrderItem.SupplyOrderNum != oldSupplyOrderItem.SupplyOrderNum) {
				if(command!=""){ command+=",";}
				command+="SupplyOrderNum = "+POut.Long(supplyOrderItem.SupplyOrderNum)+"";
			}
			if(supplyOrderItem.SupplyNum != oldSupplyOrderItem.SupplyNum) {
				if(command!=""){ command+=",";}
				command+="SupplyNum = "+POut.Long(supplyOrderItem.SupplyNum)+"";
			}
			if(supplyOrderItem.Qty != oldSupplyOrderItem.Qty) {
				if(command!=""){ command+=",";}
				command+="Qty = "+POut.Int(supplyOrderItem.Qty)+"";
			}
			if(supplyOrderItem.Price != oldSupplyOrderItem.Price) {
				if(command!=""){ command+=",";}
				command+="Price = '"+POut.Double(supplyOrderItem.Price)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE supplyorderitem SET "+command
				+" WHERE SupplyOrderItemNum = "+POut.Long(supplyOrderItem.SupplyOrderItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one SupplyOrderItem from the database.</summary>
		public static void Delete(long supplyOrderItemNum){
			string command="DELETE FROM supplyorderitem "
				+"WHERE SupplyOrderItemNum = "+POut.Long(supplyOrderItemNum);
			Db.NonQ(command);
		}

	}
}