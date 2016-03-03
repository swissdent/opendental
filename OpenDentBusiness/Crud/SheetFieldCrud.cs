//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SheetFieldCrud {
		///<summary>Gets one SheetField object from the database using the primary key.  Returns null if not found.</summary>
		public static SheetField SelectOne(long sheetFieldNum){
			string command="SELECT * FROM sheetfield "
				+"WHERE SheetFieldNum = "+POut.Long(sheetFieldNum);
			List<SheetField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SheetField object from the database using a query.</summary>
		public static SheetField SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SheetField objects from the database using a query.</summary>
		public static List<SheetField> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetField> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SheetField> TableToList(DataTable table){
			List<SheetField> retVal=new List<SheetField>();
			SheetField sheetField;
			foreach(DataRow row in table.Rows) {
				sheetField=new SheetField();
				sheetField.SheetFieldNum   = PIn.Long  (row["SheetFieldNum"].ToString());
				sheetField.SheetNum        = PIn.Long  (row["SheetNum"].ToString());
				sheetField.FieldType       = (OpenDentBusiness.SheetFieldType)PIn.Int(row["FieldType"].ToString());
				sheetField.FieldName       = PIn.String(row["FieldName"].ToString());
				sheetField.FieldValue      = PIn.String(row["FieldValue"].ToString());
				sheetField.FontSize        = PIn.Float (row["FontSize"].ToString());
				sheetField.FontName        = PIn.String(row["FontName"].ToString());
				sheetField.FontIsBold      = PIn.Bool  (row["FontIsBold"].ToString());
				sheetField.XPos            = PIn.Int   (row["XPos"].ToString());
				sheetField.YPos            = PIn.Int   (row["YPos"].ToString());
				sheetField.Width           = PIn.Int   (row["Width"].ToString());
				sheetField.Height          = PIn.Int   (row["Height"].ToString());
				sheetField.GrowthBehavior  = (OpenDentBusiness.GrowthBehaviorEnum)PIn.Int(row["GrowthBehavior"].ToString());
				sheetField.RadioButtonValue= PIn.String(row["RadioButtonValue"].ToString());
				sheetField.RadioButtonGroup= PIn.String(row["RadioButtonGroup"].ToString());
				sheetField.IsRequired      = PIn.Bool  (row["IsRequired"].ToString());
				sheetField.TabOrder        = PIn.Int   (row["TabOrder"].ToString());
				sheetField.ReportableName  = PIn.String(row["ReportableName"].ToString());
				sheetField.TextAlign       = (System.Windows.Forms.HorizontalAlignment)PIn.Int(row["TextAlign"].ToString());
				sheetField.ItemColor       = Color.FromArgb(PIn.Int(row["ItemColor"].ToString()));
				retVal.Add(sheetField);
			}
			return retVal;
		}

		///<summary>Converts a list of SheetField into a DataTable.</summary>
		public static DataTable ListToTable(List<SheetField> listSheetFields,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="SheetField";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SheetFieldNum");
			table.Columns.Add("SheetNum");
			table.Columns.Add("FieldType");
			table.Columns.Add("FieldName");
			table.Columns.Add("FieldValue");
			table.Columns.Add("FontSize");
			table.Columns.Add("FontName");
			table.Columns.Add("FontIsBold");
			table.Columns.Add("XPos");
			table.Columns.Add("YPos");
			table.Columns.Add("Width");
			table.Columns.Add("Height");
			table.Columns.Add("GrowthBehavior");
			table.Columns.Add("RadioButtonValue");
			table.Columns.Add("RadioButtonGroup");
			table.Columns.Add("IsRequired");
			table.Columns.Add("TabOrder");
			table.Columns.Add("ReportableName");
			table.Columns.Add("TextAlign");
			table.Columns.Add("ItemColor");
			foreach(SheetField sheetField in listSheetFields) {
				table.Rows.Add(new object[] {
					POut.Long  (sheetField.SheetFieldNum),
					POut.Long  (sheetField.SheetNum),
					POut.Int   ((int)sheetField.FieldType),
					            sheetField.FieldName,
					            sheetField.FieldValue,
					POut.Float (sheetField.FontSize),
					            sheetField.FontName,
					POut.Bool  (sheetField.FontIsBold),
					POut.Int   (sheetField.XPos),
					POut.Int   (sheetField.YPos),
					POut.Int   (sheetField.Width),
					POut.Int   (sheetField.Height),
					POut.Int   ((int)sheetField.GrowthBehavior),
					            sheetField.RadioButtonValue,
					            sheetField.RadioButtonGroup,
					POut.Bool  (sheetField.IsRequired),
					POut.Int   (sheetField.TabOrder),
					            sheetField.ReportableName,
					POut.Int   ((int)sheetField.TextAlign),
					POut.Int   (sheetField.ItemColor.ToArgb()),
				});
			}
			return table;
		}

		///<summary>Inserts one SheetField into the database.  Returns the new priKey.</summary>
		public static long Insert(SheetField sheetField){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				sheetField.SheetFieldNum=DbHelper.GetNextOracleKey("sheetfield","SheetFieldNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(sheetField,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							sheetField.SheetFieldNum++;
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
				return Insert(sheetField,false);
			}
		}

		///<summary>Inserts one SheetField into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SheetField sheetField,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				sheetField.SheetFieldNum=ReplicationServers.GetKey("sheetfield","SheetFieldNum");
			}
			string command="INSERT INTO sheetfield (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SheetFieldNum,";
			}
			command+="SheetNum,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,TabOrder,ReportableName,TextAlign,ItemColor) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(sheetField.SheetFieldNum)+",";
			}
			command+=
				     POut.Long  (sheetField.SheetNum)+","
				+    POut.Int   ((int)sheetField.FieldType)+","
				+"'"+POut.String(sheetField.FieldName)+"',"
				+    DbHelper.ParamChar+"paramFieldValue,"
				+    POut.Float (sheetField.FontSize)+","
				+"'"+POut.String(sheetField.FontName)+"',"
				+    POut.Bool  (sheetField.FontIsBold)+","
				+    POut.Int   (sheetField.XPos)+","
				+    POut.Int   (sheetField.YPos)+","
				+    POut.Int   (sheetField.Width)+","
				+    POut.Int   (sheetField.Height)+","
				+    POut.Int   ((int)sheetField.GrowthBehavior)+","
				+"'"+POut.String(sheetField.RadioButtonValue)+"',"
				+"'"+POut.String(sheetField.RadioButtonGroup)+"',"
				+    POut.Bool  (sheetField.IsRequired)+","
				+    POut.Int   (sheetField.TabOrder)+","
				+"'"+POut.String(sheetField.ReportableName)+"',"
				+    POut.Int   ((int)sheetField.TextAlign)+","
				+    POut.Int   (sheetField.ItemColor.ToArgb())+")";
			if(sheetField.FieldValue==null) {
				sheetField.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetField.FieldValue);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramFieldValue);
			}
			else {
				sheetField.SheetFieldNum=Db.NonQ(command,true,paramFieldValue);
			}
			return sheetField.SheetFieldNum;
		}

		///<summary>Inserts one SheetField into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetField sheetField){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(sheetField,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					sheetField.SheetFieldNum=DbHelper.GetNextOracleKey("sheetfield","SheetFieldNum"); //Cacheless method
				}
				return InsertNoCache(sheetField,true);
			}
		}

		///<summary>Inserts one SheetField into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetField sheetField,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO sheetfield (";
			if(!useExistingPK && isRandomKeys) {
				sheetField.SheetFieldNum=ReplicationServers.GetKeyNoCache("sheetfield","SheetFieldNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SheetFieldNum,";
			}
			command+="SheetNum,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,TabOrder,ReportableName,TextAlign,ItemColor) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(sheetField.SheetFieldNum)+",";
			}
			command+=
				     POut.Long  (sheetField.SheetNum)+","
				+    POut.Int   ((int)sheetField.FieldType)+","
				+"'"+POut.String(sheetField.FieldName)+"',"
				+    DbHelper.ParamChar+"paramFieldValue,"
				+    POut.Float (sheetField.FontSize)+","
				+"'"+POut.String(sheetField.FontName)+"',"
				+    POut.Bool  (sheetField.FontIsBold)+","
				+    POut.Int   (sheetField.XPos)+","
				+    POut.Int   (sheetField.YPos)+","
				+    POut.Int   (sheetField.Width)+","
				+    POut.Int   (sheetField.Height)+","
				+    POut.Int   ((int)sheetField.GrowthBehavior)+","
				+"'"+POut.String(sheetField.RadioButtonValue)+"',"
				+"'"+POut.String(sheetField.RadioButtonGroup)+"',"
				+    POut.Bool  (sheetField.IsRequired)+","
				+    POut.Int   (sheetField.TabOrder)+","
				+"'"+POut.String(sheetField.ReportableName)+"',"
				+    POut.Int   ((int)sheetField.TextAlign)+","
				+    POut.Int   (sheetField.ItemColor.ToArgb())+")";
			if(sheetField.FieldValue==null) {
				sheetField.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetField.FieldValue);
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramFieldValue);
			}
			else {
				sheetField.SheetFieldNum=Db.NonQ(command,true,paramFieldValue);
			}
			return sheetField.SheetFieldNum;
		}

		///<summary>Updates one SheetField in the database.</summary>
		public static void Update(SheetField sheetField){
			string command="UPDATE sheetfield SET "
				+"SheetNum        =  "+POut.Long  (sheetField.SheetNum)+", "
				+"FieldType       =  "+POut.Int   ((int)sheetField.FieldType)+", "
				+"FieldName       = '"+POut.String(sheetField.FieldName)+"', "
				+"FieldValue      =  "+DbHelper.ParamChar+"paramFieldValue, "
				+"FontSize        =  "+POut.Float (sheetField.FontSize)+", "
				+"FontName        = '"+POut.String(sheetField.FontName)+"', "
				+"FontIsBold      =  "+POut.Bool  (sheetField.FontIsBold)+", "
				+"XPos            =  "+POut.Int   (sheetField.XPos)+", "
				+"YPos            =  "+POut.Int   (sheetField.YPos)+", "
				+"Width           =  "+POut.Int   (sheetField.Width)+", "
				+"Height          =  "+POut.Int   (sheetField.Height)+", "
				+"GrowthBehavior  =  "+POut.Int   ((int)sheetField.GrowthBehavior)+", "
				+"RadioButtonValue= '"+POut.String(sheetField.RadioButtonValue)+"', "
				+"RadioButtonGroup= '"+POut.String(sheetField.RadioButtonGroup)+"', "
				+"IsRequired      =  "+POut.Bool  (sheetField.IsRequired)+", "
				+"TabOrder        =  "+POut.Int   (sheetField.TabOrder)+", "
				+"ReportableName  = '"+POut.String(sheetField.ReportableName)+"', "
				+"TextAlign       =  "+POut.Int   ((int)sheetField.TextAlign)+", "
				+"ItemColor       =  "+POut.Int   (sheetField.ItemColor.ToArgb())+" "
				+"WHERE SheetFieldNum = "+POut.Long(sheetField.SheetFieldNum);
			if(sheetField.FieldValue==null) {
				sheetField.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetField.FieldValue);
			Db.NonQ(command,paramFieldValue);
		}

		///<summary>Updates one SheetField in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SheetField sheetField,SheetField oldSheetField){
			string command="";
			if(sheetField.SheetNum != oldSheetField.SheetNum) {
				if(command!=""){ command+=",";}
				command+="SheetNum = "+POut.Long(sheetField.SheetNum)+"";
			}
			if(sheetField.FieldType != oldSheetField.FieldType) {
				if(command!=""){ command+=",";}
				command+="FieldType = "+POut.Int   ((int)sheetField.FieldType)+"";
			}
			if(sheetField.FieldName != oldSheetField.FieldName) {
				if(command!=""){ command+=",";}
				command+="FieldName = '"+POut.String(sheetField.FieldName)+"'";
			}
			if(sheetField.FieldValue != oldSheetField.FieldValue) {
				if(command!=""){ command+=",";}
				command+="FieldValue = "+DbHelper.ParamChar+"paramFieldValue";
			}
			if(sheetField.FontSize != oldSheetField.FontSize) {
				if(command!=""){ command+=",";}
				command+="FontSize = "+POut.Float(sheetField.FontSize)+"";
			}
			if(sheetField.FontName != oldSheetField.FontName) {
				if(command!=""){ command+=",";}
				command+="FontName = '"+POut.String(sheetField.FontName)+"'";
			}
			if(sheetField.FontIsBold != oldSheetField.FontIsBold) {
				if(command!=""){ command+=",";}
				command+="FontIsBold = "+POut.Bool(sheetField.FontIsBold)+"";
			}
			if(sheetField.XPos != oldSheetField.XPos) {
				if(command!=""){ command+=",";}
				command+="XPos = "+POut.Int(sheetField.XPos)+"";
			}
			if(sheetField.YPos != oldSheetField.YPos) {
				if(command!=""){ command+=",";}
				command+="YPos = "+POut.Int(sheetField.YPos)+"";
			}
			if(sheetField.Width != oldSheetField.Width) {
				if(command!=""){ command+=",";}
				command+="Width = "+POut.Int(sheetField.Width)+"";
			}
			if(sheetField.Height != oldSheetField.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Int(sheetField.Height)+"";
			}
			if(sheetField.GrowthBehavior != oldSheetField.GrowthBehavior) {
				if(command!=""){ command+=",";}
				command+="GrowthBehavior = "+POut.Int   ((int)sheetField.GrowthBehavior)+"";
			}
			if(sheetField.RadioButtonValue != oldSheetField.RadioButtonValue) {
				if(command!=""){ command+=",";}
				command+="RadioButtonValue = '"+POut.String(sheetField.RadioButtonValue)+"'";
			}
			if(sheetField.RadioButtonGroup != oldSheetField.RadioButtonGroup) {
				if(command!=""){ command+=",";}
				command+="RadioButtonGroup = '"+POut.String(sheetField.RadioButtonGroup)+"'";
			}
			if(sheetField.IsRequired != oldSheetField.IsRequired) {
				if(command!=""){ command+=",";}
				command+="IsRequired = "+POut.Bool(sheetField.IsRequired)+"";
			}
			if(sheetField.TabOrder != oldSheetField.TabOrder) {
				if(command!=""){ command+=",";}
				command+="TabOrder = "+POut.Int(sheetField.TabOrder)+"";
			}
			if(sheetField.ReportableName != oldSheetField.ReportableName) {
				if(command!=""){ command+=",";}
				command+="ReportableName = '"+POut.String(sheetField.ReportableName)+"'";
			}
			if(sheetField.TextAlign != oldSheetField.TextAlign) {
				if(command!=""){ command+=",";}
				command+="TextAlign = "+POut.Int   ((int)sheetField.TextAlign)+"";
			}
			if(sheetField.ItemColor != oldSheetField.ItemColor) {
				if(command!=""){ command+=",";}
				command+="ItemColor = "+POut.Int(sheetField.ItemColor.ToArgb())+"";
			}
			if(command==""){
				return false;
			}
			if(sheetField.FieldValue==null) {
				sheetField.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetField.FieldValue);
			command="UPDATE sheetfield SET "+command
				+" WHERE SheetFieldNum = "+POut.Long(sheetField.SheetFieldNum);
			Db.NonQ(command,paramFieldValue);
			return true;
		}

		///<summary>Returns true if Update(SheetField,SheetField) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(SheetField sheetField,SheetField oldSheetField) {
			if(sheetField.SheetNum != oldSheetField.SheetNum) {
				return true;
			}
			if(sheetField.FieldType != oldSheetField.FieldType) {
				return true;
			}
			if(sheetField.FieldName != oldSheetField.FieldName) {
				return true;
			}
			if(sheetField.FieldValue != oldSheetField.FieldValue) {
				return true;
			}
			if(sheetField.FontSize != oldSheetField.FontSize) {
				return true;
			}
			if(sheetField.FontName != oldSheetField.FontName) {
				return true;
			}
			if(sheetField.FontIsBold != oldSheetField.FontIsBold) {
				return true;
			}
			if(sheetField.XPos != oldSheetField.XPos) {
				return true;
			}
			if(sheetField.YPos != oldSheetField.YPos) {
				return true;
			}
			if(sheetField.Width != oldSheetField.Width) {
				return true;
			}
			if(sheetField.Height != oldSheetField.Height) {
				return true;
			}
			if(sheetField.GrowthBehavior != oldSheetField.GrowthBehavior) {
				return true;
			}
			if(sheetField.RadioButtonValue != oldSheetField.RadioButtonValue) {
				return true;
			}
			if(sheetField.RadioButtonGroup != oldSheetField.RadioButtonGroup) {
				return true;
			}
			if(sheetField.IsRequired != oldSheetField.IsRequired) {
				return true;
			}
			if(sheetField.TabOrder != oldSheetField.TabOrder) {
				return true;
			}
			if(sheetField.ReportableName != oldSheetField.ReportableName) {
				return true;
			}
			if(sheetField.TextAlign != oldSheetField.TextAlign) {
				return true;
			}
			if(sheetField.ItemColor != oldSheetField.ItemColor) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one SheetField from the database.</summary>
		public static void Delete(long sheetFieldNum){
			string command="DELETE FROM sheetfield "
				+"WHERE SheetFieldNum = "+POut.Long(sheetFieldNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<SheetField> listNew,List<SheetField> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<SheetField> listIns    =new List<SheetField>();
			List<SheetField> listUpdNew =new List<SheetField>();
			List<SheetField> listUpdDB  =new List<SheetField>();
			List<SheetField> listDel    =new List<SheetField>();
			listNew.Sort((SheetField x,SheetField y) => { return x.SheetFieldNum.CompareTo(y.SheetFieldNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((SheetField x,SheetField y) => { return x.SheetFieldNum.CompareTo(y.SheetFieldNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			SheetField fieldNew;
			SheetField fieldDB;
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
				else if(fieldNew.SheetFieldNum<fieldDB.SheetFieldNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.SheetFieldNum>fieldDB.SheetFieldNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].SheetFieldNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}