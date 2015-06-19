//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SheetFieldDefCrud {
		///<summary>Gets one SheetFieldDef object from the database using the primary key.  Returns null if not found.</summary>
		public static SheetFieldDef SelectOne(long sheetFieldDefNum){
			string command="SELECT * FROM sheetfielddef "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDefNum);
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SheetFieldDef object from the database using a query.</summary>
		public static SheetFieldDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SheetFieldDef objects from the database using a query.</summary>
		public static List<SheetFieldDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SheetFieldDef> TableToList(DataTable table){
			List<SheetFieldDef> retVal=new List<SheetFieldDef>();
			SheetFieldDef sheetFieldDef;
			for(int i=0;i<table.Rows.Count;i++) {
				sheetFieldDef=new SheetFieldDef();
				sheetFieldDef.SheetFieldDefNum= PIn.Long  (table.Rows[i]["SheetFieldDefNum"].ToString());
				sheetFieldDef.SheetDefNum     = PIn.Long  (table.Rows[i]["SheetDefNum"].ToString());
				sheetFieldDef.FieldType       = (OpenDentBusiness.SheetFieldType)PIn.Int(table.Rows[i]["FieldType"].ToString());
				sheetFieldDef.FieldName       = PIn.String(table.Rows[i]["FieldName"].ToString());
				sheetFieldDef.FieldValue      = PIn.String(table.Rows[i]["FieldValue"].ToString());
				sheetFieldDef.FontSize        = PIn.Float (table.Rows[i]["FontSize"].ToString());
				sheetFieldDef.FontName        = PIn.String(table.Rows[i]["FontName"].ToString());
				sheetFieldDef.FontIsBold      = PIn.Bool  (table.Rows[i]["FontIsBold"].ToString());
				sheetFieldDef.XPos            = PIn.Int   (table.Rows[i]["XPos"].ToString());
				sheetFieldDef.YPos            = PIn.Int   (table.Rows[i]["YPos"].ToString());
				sheetFieldDef.Width           = PIn.Int   (table.Rows[i]["Width"].ToString());
				sheetFieldDef.Height          = PIn.Int   (table.Rows[i]["Height"].ToString());
				sheetFieldDef.GrowthBehavior  = (OpenDentBusiness.GrowthBehaviorEnum)PIn.Int(table.Rows[i]["GrowthBehavior"].ToString());
				sheetFieldDef.RadioButtonValue= PIn.String(table.Rows[i]["RadioButtonValue"].ToString());
				sheetFieldDef.RadioButtonGroup= PIn.String(table.Rows[i]["RadioButtonGroup"].ToString());
				sheetFieldDef.IsRequired      = PIn.Bool  (table.Rows[i]["IsRequired"].ToString());
				sheetFieldDef.TabOrder        = PIn.Int   (table.Rows[i]["TabOrder"].ToString());
				sheetFieldDef.ReportableName  = PIn.String(table.Rows[i]["ReportableName"].ToString());
				sheetFieldDef.TextAlign       = (System.Windows.Forms.HorizontalAlignment)PIn.Int(table.Rows[i]["TextAlign"].ToString());
				sheetFieldDef.IsPaymentOption = PIn.Bool  (table.Rows[i]["IsPaymentOption"].ToString());
				sheetFieldDef.ItemColor       = Color.FromArgb(PIn.Int(table.Rows[i]["ItemColor"].ToString()));
				retVal.Add(sheetFieldDef);
			}
			return retVal;
		}

		///<summary>Inserts one SheetFieldDef into the database.  Returns the new priKey.</summary>
		public static long Insert(SheetFieldDef sheetFieldDef){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				sheetFieldDef.SheetFieldDefNum=DbHelper.GetNextOracleKey("sheetfielddef","SheetFieldDefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(sheetFieldDef,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							sheetFieldDef.SheetFieldDefNum++;
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
				return Insert(sheetFieldDef,false);
			}
		}

		///<summary>Inserts one SheetFieldDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SheetFieldDef sheetFieldDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				sheetFieldDef.SheetFieldDefNum=ReplicationServers.GetKey("sheetfielddef","SheetFieldDefNum");
			}
			string command="INSERT INTO sheetfielddef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SheetFieldDefNum,";
			}
			command+="SheetDefNum,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,TabOrder,ReportableName,TextAlign,IsPaymentOption,ItemColor) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(sheetFieldDef.SheetFieldDefNum)+",";
			}
			command+=
				     POut.Long  (sheetFieldDef.SheetDefNum)+","
				+    POut.Int   ((int)sheetFieldDef.FieldType)+","
				+"'"+POut.String(sheetFieldDef.FieldName)+"',"
				+    DbHelper.ParamChar+"paramFieldValue,"
				+    POut.Float (sheetFieldDef.FontSize)+","
				+"'"+POut.String(sheetFieldDef.FontName)+"',"
				+    POut.Bool  (sheetFieldDef.FontIsBold)+","
				+    POut.Int   (sheetFieldDef.XPos)+","
				+    POut.Int   (sheetFieldDef.YPos)+","
				+    POut.Int   (sheetFieldDef.Width)+","
				+    POut.Int   (sheetFieldDef.Height)+","
				+    POut.Int   ((int)sheetFieldDef.GrowthBehavior)+","
				+"'"+POut.String(sheetFieldDef.RadioButtonValue)+"',"
				+"'"+POut.String(sheetFieldDef.RadioButtonGroup)+"',"
				+    POut.Bool  (sheetFieldDef.IsRequired)+","
				+    POut.Int   (sheetFieldDef.TabOrder)+","
				+"'"+POut.String(sheetFieldDef.ReportableName)+"',"
				+    POut.Int   ((int)sheetFieldDef.TextAlign)+","
				+    POut.Bool  (sheetFieldDef.IsPaymentOption)+","
				+    POut.Int   (sheetFieldDef.ItemColor.ToArgb())+")";
			if(sheetFieldDef.FieldValue==null) {
				sheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetFieldDef.FieldValue);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramFieldValue);
			}
			else {
				sheetFieldDef.SheetFieldDefNum=Db.NonQ(command,true,paramFieldValue);
			}
			return sheetFieldDef.SheetFieldDefNum;
		}

		///<summary>Inserts one SheetFieldDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetFieldDef sheetFieldDef){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(sheetFieldDef,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					sheetFieldDef.SheetFieldDefNum=DbHelper.GetNextOracleKey("sheetfielddef","SheetFieldDefNum"); //Cacheless method
				}
				return InsertNoCache(sheetFieldDef,true);
			}
		}

		///<summary>Inserts one SheetFieldDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetFieldDef sheetFieldDef,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO sheetfielddef (";
			if(!useExistingPK && isRandomKeys) {
				sheetFieldDef.SheetFieldDefNum=ReplicationServers.GetKeyNoCache("sheetfielddef","SheetFieldDefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SheetFieldDefNum,";
			}
			command+="SheetDefNum,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,TabOrder,ReportableName,TextAlign,IsPaymentOption,ItemColor) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(sheetFieldDef.SheetFieldDefNum)+",";
			}
			command+=
				     POut.Long  (sheetFieldDef.SheetDefNum)+","
				+    POut.Int   ((int)sheetFieldDef.FieldType)+","
				+"'"+POut.String(sheetFieldDef.FieldName)+"',"
				+    DbHelper.ParamChar+"paramFieldValue,"
				+    POut.Float (sheetFieldDef.FontSize)+","
				+"'"+POut.String(sheetFieldDef.FontName)+"',"
				+    POut.Bool  (sheetFieldDef.FontIsBold)+","
				+    POut.Int   (sheetFieldDef.XPos)+","
				+    POut.Int   (sheetFieldDef.YPos)+","
				+    POut.Int   (sheetFieldDef.Width)+","
				+    POut.Int   (sheetFieldDef.Height)+","
				+    POut.Int   ((int)sheetFieldDef.GrowthBehavior)+","
				+"'"+POut.String(sheetFieldDef.RadioButtonValue)+"',"
				+"'"+POut.String(sheetFieldDef.RadioButtonGroup)+"',"
				+    POut.Bool  (sheetFieldDef.IsRequired)+","
				+    POut.Int   (sheetFieldDef.TabOrder)+","
				+"'"+POut.String(sheetFieldDef.ReportableName)+"',"
				+    POut.Int   ((int)sheetFieldDef.TextAlign)+","
				+    POut.Bool  (sheetFieldDef.IsPaymentOption)+","
				+    POut.Int   (sheetFieldDef.ItemColor.ToArgb())+")";
			if(sheetFieldDef.FieldValue==null) {
				sheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetFieldDef.FieldValue);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramFieldValue);
			}
			else {
				sheetFieldDef.SheetFieldDefNum=Db.NonQ(command,true,paramFieldValue);
			}
			return sheetFieldDef.SheetFieldDefNum;
		}

		///<summary>Updates one SheetFieldDef in the database.</summary>
		public static void Update(SheetFieldDef sheetFieldDef){
			string command="UPDATE sheetfielddef SET "
				+"SheetDefNum     =  "+POut.Long  (sheetFieldDef.SheetDefNum)+", "
				+"FieldType       =  "+POut.Int   ((int)sheetFieldDef.FieldType)+", "
				+"FieldName       = '"+POut.String(sheetFieldDef.FieldName)+"', "
				+"FieldValue      =  "+DbHelper.ParamChar+"paramFieldValue, "
				+"FontSize        =  "+POut.Float (sheetFieldDef.FontSize)+", "
				+"FontName        = '"+POut.String(sheetFieldDef.FontName)+"', "
				+"FontIsBold      =  "+POut.Bool  (sheetFieldDef.FontIsBold)+", "
				+"XPos            =  "+POut.Int   (sheetFieldDef.XPos)+", "
				+"YPos            =  "+POut.Int   (sheetFieldDef.YPos)+", "
				+"Width           =  "+POut.Int   (sheetFieldDef.Width)+", "
				+"Height          =  "+POut.Int   (sheetFieldDef.Height)+", "
				+"GrowthBehavior  =  "+POut.Int   ((int)sheetFieldDef.GrowthBehavior)+", "
				+"RadioButtonValue= '"+POut.String(sheetFieldDef.RadioButtonValue)+"', "
				+"RadioButtonGroup= '"+POut.String(sheetFieldDef.RadioButtonGroup)+"', "
				+"IsRequired      =  "+POut.Bool  (sheetFieldDef.IsRequired)+", "
				+"TabOrder        =  "+POut.Int   (sheetFieldDef.TabOrder)+", "
				+"ReportableName  = '"+POut.String(sheetFieldDef.ReportableName)+"', "
				+"TextAlign       =  "+POut.Int   ((int)sheetFieldDef.TextAlign)+", "
				+"IsPaymentOption =  "+POut.Bool  (sheetFieldDef.IsPaymentOption)+", "
				+"ItemColor       =  "+POut.Int   (sheetFieldDef.ItemColor.ToArgb())+" "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDef.SheetFieldDefNum);
			if(sheetFieldDef.FieldValue==null) {
				sheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetFieldDef.FieldValue);
			Db.NonQ(command,paramFieldValue);
		}

		///<summary>Updates one SheetFieldDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SheetFieldDef sheetFieldDef,SheetFieldDef oldSheetFieldDef){
			string command="";
			if(sheetFieldDef.SheetDefNum != oldSheetFieldDef.SheetDefNum) {
				if(command!=""){ command+=",";}
				command+="SheetDefNum = "+POut.Long(sheetFieldDef.SheetDefNum)+"";
			}
			if(sheetFieldDef.FieldType != oldSheetFieldDef.FieldType) {
				if(command!=""){ command+=",";}
				command+="FieldType = "+POut.Int   ((int)sheetFieldDef.FieldType)+"";
			}
			if(sheetFieldDef.FieldName != oldSheetFieldDef.FieldName) {
				if(command!=""){ command+=",";}
				command+="FieldName = '"+POut.String(sheetFieldDef.FieldName)+"'";
			}
			if(sheetFieldDef.FieldValue != oldSheetFieldDef.FieldValue) {
				if(command!=""){ command+=",";}
				command+="FieldValue = "+DbHelper.ParamChar+"paramFieldValue";
			}
			if(sheetFieldDef.FontSize != oldSheetFieldDef.FontSize) {
				if(command!=""){ command+=",";}
				command+="FontSize = "+POut.Float(sheetFieldDef.FontSize)+"";
			}
			if(sheetFieldDef.FontName != oldSheetFieldDef.FontName) {
				if(command!=""){ command+=",";}
				command+="FontName = '"+POut.String(sheetFieldDef.FontName)+"'";
			}
			if(sheetFieldDef.FontIsBold != oldSheetFieldDef.FontIsBold) {
				if(command!=""){ command+=",";}
				command+="FontIsBold = "+POut.Bool(sheetFieldDef.FontIsBold)+"";
			}
			if(sheetFieldDef.XPos != oldSheetFieldDef.XPos) {
				if(command!=""){ command+=",";}
				command+="XPos = "+POut.Int(sheetFieldDef.XPos)+"";
			}
			if(sheetFieldDef.YPos != oldSheetFieldDef.YPos) {
				if(command!=""){ command+=",";}
				command+="YPos = "+POut.Int(sheetFieldDef.YPos)+"";
			}
			if(sheetFieldDef.Width != oldSheetFieldDef.Width) {
				if(command!=""){ command+=",";}
				command+="Width = "+POut.Int(sheetFieldDef.Width)+"";
			}
			if(sheetFieldDef.Height != oldSheetFieldDef.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Int(sheetFieldDef.Height)+"";
			}
			if(sheetFieldDef.GrowthBehavior != oldSheetFieldDef.GrowthBehavior) {
				if(command!=""){ command+=",";}
				command+="GrowthBehavior = "+POut.Int   ((int)sheetFieldDef.GrowthBehavior)+"";
			}
			if(sheetFieldDef.RadioButtonValue != oldSheetFieldDef.RadioButtonValue) {
				if(command!=""){ command+=",";}
				command+="RadioButtonValue = '"+POut.String(sheetFieldDef.RadioButtonValue)+"'";
			}
			if(sheetFieldDef.RadioButtonGroup != oldSheetFieldDef.RadioButtonGroup) {
				if(command!=""){ command+=",";}
				command+="RadioButtonGroup = '"+POut.String(sheetFieldDef.RadioButtonGroup)+"'";
			}
			if(sheetFieldDef.IsRequired != oldSheetFieldDef.IsRequired) {
				if(command!=""){ command+=",";}
				command+="IsRequired = "+POut.Bool(sheetFieldDef.IsRequired)+"";
			}
			if(sheetFieldDef.TabOrder != oldSheetFieldDef.TabOrder) {
				if(command!=""){ command+=",";}
				command+="TabOrder = "+POut.Int(sheetFieldDef.TabOrder)+"";
			}
			if(sheetFieldDef.ReportableName != oldSheetFieldDef.ReportableName) {
				if(command!=""){ command+=",";}
				command+="ReportableName = '"+POut.String(sheetFieldDef.ReportableName)+"'";
			}
			if(sheetFieldDef.TextAlign != oldSheetFieldDef.TextAlign) {
				if(command!=""){ command+=",";}
				command+="TextAlign = "+POut.Int   ((int)sheetFieldDef.TextAlign)+"";
			}
			if(sheetFieldDef.IsPaymentOption != oldSheetFieldDef.IsPaymentOption) {
				if(command!=""){ command+=",";}
				command+="IsPaymentOption = "+POut.Bool(sheetFieldDef.IsPaymentOption)+"";
			}
			if(sheetFieldDef.ItemColor != oldSheetFieldDef.ItemColor) {
				if(command!=""){ command+=",";}
				command+="ItemColor = "+POut.Int(sheetFieldDef.ItemColor.ToArgb())+"";
			}
			if(command==""){
				return false;
			}
			if(sheetFieldDef.FieldValue==null) {
				sheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,sheetFieldDef.FieldValue);
			command="UPDATE sheetfielddef SET "+command
				+" WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDef.SheetFieldDefNum);
			Db.NonQ(command,paramFieldValue);
			return true;
		}

		///<summary>Deletes one SheetFieldDef from the database.</summary>
		public static void Delete(long sheetFieldDefNum){
			string command="DELETE FROM sheetfielddef "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDefNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.</summary>
		public static void Sync(List<SheetFieldDef> listNew,List<SheetFieldDef> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<SheetFieldDef> listIns    =new List<SheetFieldDef>();
			List<SheetFieldDef> listUpdNew =new List<SheetFieldDef>();
			List<SheetFieldDef> listUpdDB  =new List<SheetFieldDef>();
			List<SheetFieldDef> listDel    =new List<SheetFieldDef>();
			listNew.Sort((SheetFieldDef x,SheetFieldDef y) => { return x.SheetFieldDefNum.CompareTo(y.SheetFieldDefNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((SheetFieldDef x,SheetFieldDef y) => { return x.SheetFieldDefNum.CompareTo(y.SheetFieldDefNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			SheetFieldDef fieldNew;
			SheetFieldDef fieldDB;
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
				else if(fieldNew.SheetFieldDefNum<fieldDB.SheetFieldDefNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.SheetFieldDefNum>fieldDB.SheetFieldDefNum) {//dbPK less than newPK, dbItem is 'next'
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
				Update(listUpdNew[i],listUpdDB[i]);
			}
			for(int i=0;i<listDel.Count;i++) {
				Delete(listDel[i].SheetFieldDefNum);
			}
		}

	}
}