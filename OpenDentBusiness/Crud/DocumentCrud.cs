//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class DocumentCrud {
		///<summary>Gets one Document object from the database using the primary key.  Returns null if not found.</summary>
		public static Document SelectOne(long docNum){
			string command="SELECT * FROM document "
				+"WHERE DocNum = "+POut.Long(docNum);
			List<Document> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Document object from the database using a query.</summary>
		public static Document SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Document> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Document objects from the database using a query.</summary>
		public static List<Document> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Document> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Document> TableToList(DataTable table){
			List<Document> retVal=new List<Document>();
			Document document;
			foreach(DataRow row in table.Rows) {
				document=new Document();
				document.DocNum        = PIn.Long  (row["DocNum"].ToString());
				document.Description   = PIn.String(row["Description"].ToString());
				document.DateCreated   = PIn.DateT (row["DateCreated"].ToString());
				document.DocCategory   = PIn.Long  (row["DocCategory"].ToString());
				document.PatNum        = PIn.Long  (row["PatNum"].ToString());
				document.FileName      = PIn.String(row["FileName"].ToString());
				document.ImgType       = (OpenDentBusiness.ImageType)PIn.Int(row["ImgType"].ToString());
				document.IsFlipped     = PIn.Bool  (row["IsFlipped"].ToString());
				document.DegreesRotated= PIn.Int   (row["DegreesRotated"].ToString());
				document.ToothNumbers  = PIn.String(row["ToothNumbers"].ToString());
				document.Note          = PIn.String(row["Note"].ToString());
				document.SigIsTopaz    = PIn.Bool  (row["SigIsTopaz"].ToString());
				document.Signature     = PIn.String(row["Signature"].ToString());
				document.CropX         = PIn.Int   (row["CropX"].ToString());
				document.CropY         = PIn.Int   (row["CropY"].ToString());
				document.CropW         = PIn.Int   (row["CropW"].ToString());
				document.CropH         = PIn.Int   (row["CropH"].ToString());
				document.WindowingMin  = PIn.Int   (row["WindowingMin"].ToString());
				document.WindowingMax  = PIn.Int   (row["WindowingMax"].ToString());
				document.MountItemNum  = PIn.Long  (row["MountItemNum"].ToString());
				document.DateTStamp    = PIn.DateT (row["DateTStamp"].ToString());
				document.RawBase64     = PIn.String(row["RawBase64"].ToString());
				document.Thumbnail     = PIn.String(row["Thumbnail"].ToString());
				retVal.Add(document);
			}
			return retVal;
		}

		///<summary>Inserts one Document into the database.  Returns the new priKey.</summary>
		public static long Insert(Document document){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				document.DocNum=DbHelper.GetNextOracleKey("document","DocNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(document,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							document.DocNum++;
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
				return Insert(document,false);
			}
		}

		///<summary>Inserts one Document into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Document document,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				document.DocNum=ReplicationServers.GetKey("document","DocNum");
			}
			string command="INSERT INTO document (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DocNum,";
			}
			command+="Description,DateCreated,DocCategory,PatNum,FileName,ImgType,IsFlipped,DegreesRotated,ToothNumbers,Note,SigIsTopaz,Signature,CropX,CropY,CropW,CropH,WindowingMin,WindowingMax,MountItemNum,RawBase64,Thumbnail) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(document.DocNum)+",";
			}
			command+=
				 "'"+POut.String(document.Description)+"',"
				+    POut.DateT (document.DateCreated)+","
				+    POut.Long  (document.DocCategory)+","
				+    POut.Long  (document.PatNum)+","
				+"'"+POut.String(document.FileName)+"',"
				+    POut.Int   ((int)document.ImgType)+","
				+    POut.Bool  (document.IsFlipped)+","
				+    POut.Int   (document.DegreesRotated)+","
				+"'"+POut.String(document.ToothNumbers)+"',"
				+"'"+POut.String(document.Note)+"',"
				+    POut.Bool  (document.SigIsTopaz)+","
				+"'"+POut.String(document.Signature)+"',"
				+    POut.Int   (document.CropX)+","
				+    POut.Int   (document.CropY)+","
				+    POut.Int   (document.CropW)+","
				+    POut.Int   (document.CropH)+","
				+    POut.Int   (document.WindowingMin)+","
				+    POut.Int   (document.WindowingMax)+","
				+    POut.Long  (document.MountItemNum)+","
				//DateTStamp can only be set by MySQL
				+    DbHelper.ParamChar+"paramRawBase64,"
				+    DbHelper.ParamChar+"paramThumbnail)";
			if(document.RawBase64==null) {
				document.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,document.RawBase64);
			if(document.Thumbnail==null) {
				document.Thumbnail="";
			}
			OdSqlParameter paramThumbnail=new OdSqlParameter("paramThumbnail",OdDbType.Text,document.Thumbnail);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramRawBase64,paramThumbnail);
			}
			else {
				document.DocNum=Db.NonQ(command,true,paramRawBase64,paramThumbnail);
			}
			return document.DocNum;
		}

		///<summary>Inserts one Document into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Document document){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(document,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					document.DocNum=DbHelper.GetNextOracleKey("document","DocNum"); //Cacheless method
				}
				return InsertNoCache(document,true);
			}
		}

		///<summary>Inserts one Document into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Document document,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO document (";
			if(!useExistingPK && isRandomKeys) {
				document.DocNum=ReplicationServers.GetKeyNoCache("document","DocNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="DocNum,";
			}
			command+="Description,DateCreated,DocCategory,PatNum,FileName,ImgType,IsFlipped,DegreesRotated,ToothNumbers,Note,SigIsTopaz,Signature,CropX,CropY,CropW,CropH,WindowingMin,WindowingMax,MountItemNum,RawBase64,Thumbnail) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(document.DocNum)+",";
			}
			command+=
				 "'"+POut.String(document.Description)+"',"
				+    POut.DateT (document.DateCreated)+","
				+    POut.Long  (document.DocCategory)+","
				+    POut.Long  (document.PatNum)+","
				+"'"+POut.String(document.FileName)+"',"
				+    POut.Int   ((int)document.ImgType)+","
				+    POut.Bool  (document.IsFlipped)+","
				+    POut.Int   (document.DegreesRotated)+","
				+"'"+POut.String(document.ToothNumbers)+"',"
				+"'"+POut.String(document.Note)+"',"
				+    POut.Bool  (document.SigIsTopaz)+","
				+"'"+POut.String(document.Signature)+"',"
				+    POut.Int   (document.CropX)+","
				+    POut.Int   (document.CropY)+","
				+    POut.Int   (document.CropW)+","
				+    POut.Int   (document.CropH)+","
				+    POut.Int   (document.WindowingMin)+","
				+    POut.Int   (document.WindowingMax)+","
				+    POut.Long  (document.MountItemNum)+","
				//DateTStamp can only be set by MySQL
				+    DbHelper.ParamChar+"paramRawBase64,"
				+    DbHelper.ParamChar+"paramThumbnail)";
			if(document.RawBase64==null) {
				document.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,document.RawBase64);
			if(document.Thumbnail==null) {
				document.Thumbnail="";
			}
			OdSqlParameter paramThumbnail=new OdSqlParameter("paramThumbnail",OdDbType.Text,document.Thumbnail);
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramRawBase64,paramThumbnail);
			}
			else {
				document.DocNum=Db.NonQ(command,true,paramRawBase64,paramThumbnail);
			}
			return document.DocNum;
		}

		///<summary>Updates one Document in the database.</summary>
		public static void Update(Document document){
			string command="UPDATE document SET "
				+"Description   = '"+POut.String(document.Description)+"', "
				+"DateCreated   =  "+POut.DateT (document.DateCreated)+", "
				+"DocCategory   =  "+POut.Long  (document.DocCategory)+", "
				+"PatNum        =  "+POut.Long  (document.PatNum)+", "
				+"FileName      = '"+POut.String(document.FileName)+"', "
				+"ImgType       =  "+POut.Int   ((int)document.ImgType)+", "
				+"IsFlipped     =  "+POut.Bool  (document.IsFlipped)+", "
				+"DegreesRotated=  "+POut.Int   (document.DegreesRotated)+", "
				+"ToothNumbers  = '"+POut.String(document.ToothNumbers)+"', "
				+"Note          = '"+POut.String(document.Note)+"', "
				+"SigIsTopaz    =  "+POut.Bool  (document.SigIsTopaz)+", "
				+"Signature     = '"+POut.String(document.Signature)+"', "
				+"CropX         =  "+POut.Int   (document.CropX)+", "
				+"CropY         =  "+POut.Int   (document.CropY)+", "
				+"CropW         =  "+POut.Int   (document.CropW)+", "
				+"CropH         =  "+POut.Int   (document.CropH)+", "
				+"WindowingMin  =  "+POut.Int   (document.WindowingMin)+", "
				+"WindowingMax  =  "+POut.Int   (document.WindowingMax)+", "
				+"MountItemNum  =  "+POut.Long  (document.MountItemNum)+", "
				//DateTStamp can only be set by MySQL
				+"RawBase64     =  "+DbHelper.ParamChar+"paramRawBase64, "
				+"Thumbnail     =  "+DbHelper.ParamChar+"paramThumbnail "
				+"WHERE DocNum = "+POut.Long(document.DocNum);
			if(document.RawBase64==null) {
				document.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,document.RawBase64);
			if(document.Thumbnail==null) {
				document.Thumbnail="";
			}
			OdSqlParameter paramThumbnail=new OdSqlParameter("paramThumbnail",OdDbType.Text,document.Thumbnail);
			Db.NonQ(command,paramRawBase64,paramThumbnail);
		}

		///<summary>Updates one Document in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Document document,Document oldDocument){
			string command="";
			if(document.Description != oldDocument.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(document.Description)+"'";
			}
			if(document.DateCreated != oldDocument.DateCreated) {
				if(command!=""){ command+=",";}
				command+="DateCreated = "+POut.DateT(document.DateCreated)+"";
			}
			if(document.DocCategory != oldDocument.DocCategory) {
				if(command!=""){ command+=",";}
				command+="DocCategory = "+POut.Long(document.DocCategory)+"";
			}
			if(document.PatNum != oldDocument.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(document.PatNum)+"";
			}
			if(document.FileName != oldDocument.FileName) {
				if(command!=""){ command+=",";}
				command+="FileName = '"+POut.String(document.FileName)+"'";
			}
			if(document.ImgType != oldDocument.ImgType) {
				if(command!=""){ command+=",";}
				command+="ImgType = "+POut.Int   ((int)document.ImgType)+"";
			}
			if(document.IsFlipped != oldDocument.IsFlipped) {
				if(command!=""){ command+=",";}
				command+="IsFlipped = "+POut.Bool(document.IsFlipped)+"";
			}
			if(document.DegreesRotated != oldDocument.DegreesRotated) {
				if(command!=""){ command+=",";}
				command+="DegreesRotated = "+POut.Int(document.DegreesRotated)+"";
			}
			if(document.ToothNumbers != oldDocument.ToothNumbers) {
				if(command!=""){ command+=",";}
				command+="ToothNumbers = '"+POut.String(document.ToothNumbers)+"'";
			}
			if(document.Note != oldDocument.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(document.Note)+"'";
			}
			if(document.SigIsTopaz != oldDocument.SigIsTopaz) {
				if(command!=""){ command+=",";}
				command+="SigIsTopaz = "+POut.Bool(document.SigIsTopaz)+"";
			}
			if(document.Signature != oldDocument.Signature) {
				if(command!=""){ command+=",";}
				command+="Signature = '"+POut.String(document.Signature)+"'";
			}
			if(document.CropX != oldDocument.CropX) {
				if(command!=""){ command+=",";}
				command+="CropX = "+POut.Int(document.CropX)+"";
			}
			if(document.CropY != oldDocument.CropY) {
				if(command!=""){ command+=",";}
				command+="CropY = "+POut.Int(document.CropY)+"";
			}
			if(document.CropW != oldDocument.CropW) {
				if(command!=""){ command+=",";}
				command+="CropW = "+POut.Int(document.CropW)+"";
			}
			if(document.CropH != oldDocument.CropH) {
				if(command!=""){ command+=",";}
				command+="CropH = "+POut.Int(document.CropH)+"";
			}
			if(document.WindowingMin != oldDocument.WindowingMin) {
				if(command!=""){ command+=",";}
				command+="WindowingMin = "+POut.Int(document.WindowingMin)+"";
			}
			if(document.WindowingMax != oldDocument.WindowingMax) {
				if(command!=""){ command+=",";}
				command+="WindowingMax = "+POut.Int(document.WindowingMax)+"";
			}
			if(document.MountItemNum != oldDocument.MountItemNum) {
				if(command!=""){ command+=",";}
				command+="MountItemNum = "+POut.Long(document.MountItemNum)+"";
			}
			//DateTStamp can only be set by MySQL
			if(document.RawBase64 != oldDocument.RawBase64) {
				if(command!=""){ command+=",";}
				command+="RawBase64 = "+DbHelper.ParamChar+"paramRawBase64";
			}
			if(document.Thumbnail != oldDocument.Thumbnail) {
				if(command!=""){ command+=",";}
				command+="Thumbnail = "+DbHelper.ParamChar+"paramThumbnail";
			}
			if(command==""){
				return false;
			}
			if(document.RawBase64==null) {
				document.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,document.RawBase64);
			if(document.Thumbnail==null) {
				document.Thumbnail="";
			}
			OdSqlParameter paramThumbnail=new OdSqlParameter("paramThumbnail",OdDbType.Text,document.Thumbnail);
			command="UPDATE document SET "+command
				+" WHERE DocNum = "+POut.Long(document.DocNum);
			Db.NonQ(command,paramRawBase64,paramThumbnail);
			return true;
		}

		///<summary>Deletes one Document from the database.</summary>
		public static void Delete(long docNum){
			ClearFkey(docNum);
			string command="DELETE FROM document "
				+"WHERE DocNum = "+POut.Long(docNum);
			Db.NonQ(command);
		}

		///<summary>Zeros securitylog FKey column for rows that are using the matching docNum as FKey and are related to Document.
		///Permtypes are generated from the AuditPerms property of the CrudTableAttribute within the Document table type.</summary>
		public static void ClearFkey(long docNum) {
			string command="UPDATE securitylog SET FKey=0 WHERE FKey="+POut.Long(docNum)+" AND PermType IN (44,89)";
			Db.NonQ(command);
		}

	}
}