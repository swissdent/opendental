//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class QuickPasteNoteCrud {
		///<summary>Gets one QuickPasteNote object from the database using the primary key.  Returns null if not found.</summary>
		public static QuickPasteNote SelectOne(long quickPasteNoteNum){
			string command="SELECT * FROM quickpastenote "
				+"WHERE QuickPasteNoteNum = "+POut.Long(quickPasteNoteNum);
			List<QuickPasteNote> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one QuickPasteNote object from the database using a query.</summary>
		public static QuickPasteNote SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<QuickPasteNote> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of QuickPasteNote objects from the database using a query.</summary>
		public static List<QuickPasteNote> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<QuickPasteNote> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<QuickPasteNote> TableToList(DataTable table){
			List<QuickPasteNote> retVal=new List<QuickPasteNote>();
			QuickPasteNote quickPasteNote;
			foreach(DataRow row in table.Rows) {
				quickPasteNote=new QuickPasteNote();
				quickPasteNote.QuickPasteNoteNum= PIn.Long  (row["QuickPasteNoteNum"].ToString());
				quickPasteNote.QuickPasteCatNum = PIn.Long  (row["QuickPasteCatNum"].ToString());
				quickPasteNote.ItemOrder        = PIn.Int   (row["ItemOrder"].ToString());
				quickPasteNote.Note             = PIn.String(row["Note"].ToString());
				quickPasteNote.Abbreviation     = PIn.String(row["Abbreviation"].ToString());
				retVal.Add(quickPasteNote);
			}
			return retVal;
		}

		///<summary>Converts a list of QuickPasteNote into a DataTable.</summary>
		public static DataTable ListToTable(List<QuickPasteNote> listQuickPasteNotes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="QuickPasteNote";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("QuickPasteNoteNum");
			table.Columns.Add("QuickPasteCatNum");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("Note");
			table.Columns.Add("Abbreviation");
			foreach(QuickPasteNote quickPasteNote in listQuickPasteNotes) {
				table.Rows.Add(new object[] {
					POut.Long  (quickPasteNote.QuickPasteNoteNum),
					POut.Long  (quickPasteNote.QuickPasteCatNum),
					POut.Int   (quickPasteNote.ItemOrder),
					            quickPasteNote.Note,
					            quickPasteNote.Abbreviation,
				});
			}
			return table;
		}

		///<summary>Inserts one QuickPasteNote into the database.  Returns the new priKey.</summary>
		public static long Insert(QuickPasteNote quickPasteNote){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				quickPasteNote.QuickPasteNoteNum=DbHelper.GetNextOracleKey("quickpastenote","QuickPasteNoteNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(quickPasteNote,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							quickPasteNote.QuickPasteNoteNum++;
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
				return Insert(quickPasteNote,false);
			}
		}

		///<summary>Inserts one QuickPasteNote into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(QuickPasteNote quickPasteNote,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				quickPasteNote.QuickPasteNoteNum=ReplicationServers.GetKey("quickpastenote","QuickPasteNoteNum");
			}
			string command="INSERT INTO quickpastenote (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="QuickPasteNoteNum,";
			}
			command+="QuickPasteCatNum,ItemOrder,Note,Abbreviation) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(quickPasteNote.QuickPasteNoteNum)+",";
			}
			command+=
				     POut.Long  (quickPasteNote.QuickPasteCatNum)+","
				+    POut.Int   (quickPasteNote.ItemOrder)+","
				+"'"+POut.String(quickPasteNote.Note)+"',"
				+"'"+POut.String(quickPasteNote.Abbreviation)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				quickPasteNote.QuickPasteNoteNum=Db.NonQ(command,true);
			}
			return quickPasteNote.QuickPasteNoteNum;
		}

		///<summary>Inserts one QuickPasteNote into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(QuickPasteNote quickPasteNote){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(quickPasteNote,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					quickPasteNote.QuickPasteNoteNum=DbHelper.GetNextOracleKey("quickpastenote","QuickPasteNoteNum"); //Cacheless method
				}
				return InsertNoCache(quickPasteNote,true);
			}
		}

		///<summary>Inserts one QuickPasteNote into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(QuickPasteNote quickPasteNote,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO quickpastenote (";
			if(!useExistingPK && isRandomKeys) {
				quickPasteNote.QuickPasteNoteNum=ReplicationServers.GetKeyNoCache("quickpastenote","QuickPasteNoteNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="QuickPasteNoteNum,";
			}
			command+="QuickPasteCatNum,ItemOrder,Note,Abbreviation) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(quickPasteNote.QuickPasteNoteNum)+",";
			}
			command+=
				     POut.Long  (quickPasteNote.QuickPasteCatNum)+","
				+    POut.Int   (quickPasteNote.ItemOrder)+","
				+"'"+POut.String(quickPasteNote.Note)+"',"
				+"'"+POut.String(quickPasteNote.Abbreviation)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				quickPasteNote.QuickPasteNoteNum=Db.NonQ(command,true);
			}
			return quickPasteNote.QuickPasteNoteNum;
		}

		///<summary>Updates one QuickPasteNote in the database.</summary>
		public static void Update(QuickPasteNote quickPasteNote){
			string command="UPDATE quickpastenote SET "
				+"QuickPasteCatNum =  "+POut.Long  (quickPasteNote.QuickPasteCatNum)+", "
				+"ItemOrder        =  "+POut.Int   (quickPasteNote.ItemOrder)+", "
				+"Note             = '"+POut.String(quickPasteNote.Note)+"', "
				+"Abbreviation     = '"+POut.String(quickPasteNote.Abbreviation)+"' "
				+"WHERE QuickPasteNoteNum = "+POut.Long(quickPasteNote.QuickPasteNoteNum);
			Db.NonQ(command);
		}

		///<summary>Updates one QuickPasteNote in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(QuickPasteNote quickPasteNote,QuickPasteNote oldQuickPasteNote){
			string command="";
			if(quickPasteNote.QuickPasteCatNum != oldQuickPasteNote.QuickPasteCatNum) {
				if(command!=""){ command+=",";}
				command+="QuickPasteCatNum = "+POut.Long(quickPasteNote.QuickPasteCatNum)+"";
			}
			if(quickPasteNote.ItemOrder != oldQuickPasteNote.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(quickPasteNote.ItemOrder)+"";
			}
			if(quickPasteNote.Note != oldQuickPasteNote.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(quickPasteNote.Note)+"'";
			}
			if(quickPasteNote.Abbreviation != oldQuickPasteNote.Abbreviation) {
				if(command!=""){ command+=",";}
				command+="Abbreviation = '"+POut.String(quickPasteNote.Abbreviation)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE quickpastenote SET "+command
				+" WHERE QuickPasteNoteNum = "+POut.Long(quickPasteNote.QuickPasteNoteNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(QuickPasteNote,QuickPasteNote) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(QuickPasteNote quickPasteNote,QuickPasteNote oldQuickPasteNote) {
			if(quickPasteNote.QuickPasteCatNum != oldQuickPasteNote.QuickPasteCatNum) {
				return true;
			}
			if(quickPasteNote.ItemOrder != oldQuickPasteNote.ItemOrder) {
				return true;
			}
			if(quickPasteNote.Note != oldQuickPasteNote.Note) {
				return true;
			}
			if(quickPasteNote.Abbreviation != oldQuickPasteNote.Abbreviation) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one QuickPasteNote from the database.</summary>
		public static void Delete(long quickPasteNoteNum){
			string command="DELETE FROM quickpastenote "
				+"WHERE QuickPasteNoteNum = "+POut.Long(quickPasteNoteNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<QuickPasteNote> listNew,List<QuickPasteNote> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<QuickPasteNote> listIns    =new List<QuickPasteNote>();
			List<QuickPasteNote> listUpdNew =new List<QuickPasteNote>();
			List<QuickPasteNote> listUpdDB  =new List<QuickPasteNote>();
			List<QuickPasteNote> listDel    =new List<QuickPasteNote>();
			listNew.Sort((QuickPasteNote x,QuickPasteNote y) => { return x.QuickPasteNoteNum.CompareTo(y.QuickPasteNoteNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((QuickPasteNote x,QuickPasteNote y) => { return x.QuickPasteNoteNum.CompareTo(y.QuickPasteNoteNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			QuickPasteNote fieldNew;
			QuickPasteNote fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.QuickPasteNoteNum<fieldDB.QuickPasteNoteNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.QuickPasteNoteNum>fieldDB.QuickPasteNoteNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])){
					rowsUpdatedCount++;
				}
			}
			for(int i=0;i<listDel.Count;i++) {
				Delete(listDel[i].QuickPasteNoteNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}