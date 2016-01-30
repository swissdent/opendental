//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PopupCrud {
		///<summary>Gets one Popup object from the database using the primary key.  Returns null if not found.</summary>
		public static Popup SelectOne(long popupNum){
			string command="SELECT * FROM popup "
				+"WHERE PopupNum = "+POut.Long(popupNum);
			List<Popup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Popup object from the database using a query.</summary>
		public static Popup SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Popup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Popup objects from the database using a query.</summary>
		public static List<Popup> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Popup> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Popup> TableToList(DataTable table){
			List<Popup> retVal=new List<Popup>();
			Popup popup;
			foreach(DataRow row in table.Rows) {
				popup=new Popup();
				popup.PopupNum       = PIn.Long  (row["PopupNum"].ToString());
				popup.PatNum         = PIn.Long  (row["PatNum"].ToString());
				popup.Description    = PIn.String(row["Description"].ToString());
				popup.IsDisabled     = PIn.Bool  (row["IsDisabled"].ToString());
				popup.PopupLevel     = (OpenDentBusiness.EnumPopupLevel)PIn.Int(row["PopupLevel"].ToString());
				popup.UserNum        = PIn.Long  (row["UserNum"].ToString());
				popup.DateTimeEntry  = PIn.DateT (row["DateTimeEntry"].ToString());
				popup.IsArchived     = PIn.Bool  (row["IsArchived"].ToString());
				popup.PopupNumArchive= PIn.Long  (row["PopupNumArchive"].ToString());
				retVal.Add(popup);
			}
			return retVal;
		}

		///<summary>Converts a list of Popup into a DataTable.</summary>
		public static DataTable ListToTable(List<Popup> listPopups,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Popup";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PopupNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("Description");
			table.Columns.Add("IsDisabled");
			table.Columns.Add("PopupLevel");
			table.Columns.Add("UserNum");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("IsArchived");
			table.Columns.Add("PopupNumArchive");
			foreach(Popup popup in listPopups) {
				table.Rows.Add(new object[] {
					POut.Long  (popup.PopupNum),
					POut.Long  (popup.PatNum),
					POut.String(popup.Description),
					POut.Bool  (popup.IsDisabled),
					POut.Int   ((int)popup.PopupLevel),
					POut.Long  (popup.UserNum),
					POut.DateT (popup.DateTimeEntry),
					POut.Bool  (popup.IsArchived),
					POut.Long  (popup.PopupNumArchive),
				});
			}
			return table;
		}

		///<summary>Inserts one Popup into the database.  Returns the new priKey.</summary>
		public static long Insert(Popup popup){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				popup.PopupNum=DbHelper.GetNextOracleKey("popup","PopupNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(popup,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							popup.PopupNum++;
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
				return Insert(popup,false);
			}
		}

		///<summary>Inserts one Popup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Popup popup,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				popup.PopupNum=ReplicationServers.GetKey("popup","PopupNum");
			}
			string command="INSERT INTO popup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PopupNum,";
			}
			command+="PatNum,Description,IsDisabled,PopupLevel,UserNum,DateTimeEntry,IsArchived,PopupNumArchive) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(popup.PopupNum)+",";
			}
			command+=
				     POut.Long  (popup.PatNum)+","
				+"'"+POut.String(popup.Description)+"',"
				+    POut.Bool  (popup.IsDisabled)+","
				+    POut.Int   ((int)popup.PopupLevel)+","
				+    POut.Long  (popup.UserNum)+","
				+    DbHelper.Now()+","
				+    POut.Bool  (popup.IsArchived)+","
				+    POut.Long  (popup.PopupNumArchive)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				popup.PopupNum=Db.NonQ(command,true);
			}
			return popup.PopupNum;
		}

		///<summary>Inserts one Popup into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Popup popup){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(popup,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					popup.PopupNum=DbHelper.GetNextOracleKey("popup","PopupNum"); //Cacheless method
				}
				return InsertNoCache(popup,true);
			}
		}

		///<summary>Inserts one Popup into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Popup popup,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO popup (";
			if(!useExistingPK && isRandomKeys) {
				popup.PopupNum=ReplicationServers.GetKeyNoCache("popup","PopupNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PopupNum,";
			}
			command+="PatNum,Description,IsDisabled,PopupLevel,UserNum,DateTimeEntry,IsArchived,PopupNumArchive) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(popup.PopupNum)+",";
			}
			command+=
				     POut.Long  (popup.PatNum)+","
				+"'"+POut.String(popup.Description)+"',"
				+    POut.Bool  (popup.IsDisabled)+","
				+    POut.Int   ((int)popup.PopupLevel)+","
				+    POut.Long  (popup.UserNum)+","
				+    DbHelper.Now()+","
				+    POut.Bool  (popup.IsArchived)+","
				+    POut.Long  (popup.PopupNumArchive)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				popup.PopupNum=Db.NonQ(command,true);
			}
			return popup.PopupNum;
		}

		///<summary>Updates one Popup in the database.</summary>
		public static void Update(Popup popup){
			string command="UPDATE popup SET "
				+"PatNum         =  "+POut.Long  (popup.PatNum)+", "
				+"Description    = '"+POut.String(popup.Description)+"', "
				+"IsDisabled     =  "+POut.Bool  (popup.IsDisabled)+", "
				+"PopupLevel     =  "+POut.Int   ((int)popup.PopupLevel)+", "
				+"UserNum        =  "+POut.Long  (popup.UserNum)+", "
				//DateTimeEntry not allowed to change
				+"IsArchived     =  "+POut.Bool  (popup.IsArchived)+", "
				+"PopupNumArchive=  "+POut.Long  (popup.PopupNumArchive)+" "
				+"WHERE PopupNum = "+POut.Long(popup.PopupNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Popup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Popup popup,Popup oldPopup){
			string command="";
			if(popup.PatNum != oldPopup.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(popup.PatNum)+"";
			}
			if(popup.Description != oldPopup.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(popup.Description)+"'";
			}
			if(popup.IsDisabled != oldPopup.IsDisabled) {
				if(command!=""){ command+=",";}
				command+="IsDisabled = "+POut.Bool(popup.IsDisabled)+"";
			}
			if(popup.PopupLevel != oldPopup.PopupLevel) {
				if(command!=""){ command+=",";}
				command+="PopupLevel = "+POut.Int   ((int)popup.PopupLevel)+"";
			}
			if(popup.UserNum != oldPopup.UserNum) {
				if(command!=""){ command+=",";}
				command+="UserNum = "+POut.Long(popup.UserNum)+"";
			}
			//DateTimeEntry not allowed to change
			if(popup.IsArchived != oldPopup.IsArchived) {
				if(command!=""){ command+=",";}
				command+="IsArchived = "+POut.Bool(popup.IsArchived)+"";
			}
			if(popup.PopupNumArchive != oldPopup.PopupNumArchive) {
				if(command!=""){ command+=",";}
				command+="PopupNumArchive = "+POut.Long(popup.PopupNumArchive)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE popup SET "+command
				+" WHERE PopupNum = "+POut.Long(popup.PopupNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Popup,Popup) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Popup popup,Popup oldPopup) {
			if(popup.PatNum != oldPopup.PatNum) {
				return true;
			}
			if(popup.Description != oldPopup.Description) {
				return true;
			}
			if(popup.IsDisabled != oldPopup.IsDisabled) {
				return true;
			}
			if(popup.PopupLevel != oldPopup.PopupLevel) {
				return true;
			}
			if(popup.UserNum != oldPopup.UserNum) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(popup.IsArchived != oldPopup.IsArchived) {
				return true;
			}
			if(popup.PopupNumArchive != oldPopup.PopupNumArchive) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Popup from the database.</summary>
		public static void Delete(long popupNum){
			string command="DELETE FROM popup "
				+"WHERE PopupNum = "+POut.Long(popupNum);
			Db.NonQ(command);
		}

	}
}