//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LetterMergeCrud {
		///<summary>Gets one LetterMerge object from the database using the primary key.  Returns null if not found.</summary>
		public static LetterMerge SelectOne(long letterMergeNum){
			string command="SELECT * FROM lettermerge "
				+"WHERE LetterMergeNum = "+POut.Long(letterMergeNum);
			List<LetterMerge> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LetterMerge object from the database using a query.</summary>
		public static LetterMerge SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LetterMerge> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LetterMerge objects from the database using a query.</summary>
		public static List<LetterMerge> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LetterMerge> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LetterMerge> TableToList(DataTable table){
			List<LetterMerge> retVal=new List<LetterMerge>();
			LetterMerge letterMerge;
			for(int i=0;i<table.Rows.Count;i++) {
				letterMerge=new LetterMerge();
				letterMerge.LetterMergeNum= PIn.Long  (table.Rows[i]["LetterMergeNum"].ToString());
				letterMerge.Description   = PIn.String(table.Rows[i]["Description"].ToString());
				letterMerge.TemplateName  = PIn.String(table.Rows[i]["TemplateName"].ToString());
				letterMerge.DataFileName  = PIn.String(table.Rows[i]["DataFileName"].ToString());
				letterMerge.Category      = PIn.Long  (table.Rows[i]["Category"].ToString());
				retVal.Add(letterMerge);
			}
			return retVal;
		}

		///<summary>Inserts one LetterMerge into the database.  Returns the new priKey.</summary>
		public static long Insert(LetterMerge letterMerge){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				letterMerge.LetterMergeNum=DbHelper.GetNextOracleKey("lettermerge","LetterMergeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(letterMerge,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							letterMerge.LetterMergeNum++;
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
				return Insert(letterMerge,false);
			}
		}

		///<summary>Inserts one LetterMerge into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LetterMerge letterMerge,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				letterMerge.LetterMergeNum=ReplicationServers.GetKey("lettermerge","LetterMergeNum");
			}
			string command="INSERT INTO lettermerge (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LetterMergeNum,";
			}
			command+="Description,TemplateName,DataFileName,Category) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(letterMerge.LetterMergeNum)+",";
			}
			command+=
				 "'"+POut.String(letterMerge.Description)+"',"
				+"'"+POut.String(letterMerge.TemplateName)+"',"
				+"'"+POut.String(letterMerge.DataFileName)+"',"
				+    POut.Long  (letterMerge.Category)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				letterMerge.LetterMergeNum=Db.NonQ(command,true);
			}
			return letterMerge.LetterMergeNum;
		}

		///<summary>Updates one LetterMerge in the database.</summary>
		public static void Update(LetterMerge letterMerge){
			string command="UPDATE lettermerge SET "
				+"Description   = '"+POut.String(letterMerge.Description)+"', "
				+"TemplateName  = '"+POut.String(letterMerge.TemplateName)+"', "
				+"DataFileName  = '"+POut.String(letterMerge.DataFileName)+"', "
				+"Category      =  "+POut.Long  (letterMerge.Category)+" "
				+"WHERE LetterMergeNum = "+POut.Long(letterMerge.LetterMergeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one LetterMerge in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(LetterMerge letterMerge,LetterMerge oldLetterMerge){
			string command="";
			if(letterMerge.Description != oldLetterMerge.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(letterMerge.Description)+"'";
			}
			if(letterMerge.TemplateName != oldLetterMerge.TemplateName) {
				if(command!=""){ command+=",";}
				command+="TemplateName = '"+POut.String(letterMerge.TemplateName)+"'";
			}
			if(letterMerge.DataFileName != oldLetterMerge.DataFileName) {
				if(command!=""){ command+=",";}
				command+="DataFileName = '"+POut.String(letterMerge.DataFileName)+"'";
			}
			if(letterMerge.Category != oldLetterMerge.Category) {
				if(command!=""){ command+=",";}
				command+="Category = "+POut.Long(letterMerge.Category)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE lettermerge SET "+command
				+" WHERE LetterMergeNum = "+POut.Long(letterMerge.LetterMergeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one LetterMerge from the database.</summary>
		public static void Delete(long letterMergeNum){
			string command="DELETE FROM lettermerge "
				+"WHERE LetterMergeNum = "+POut.Long(letterMergeNum);
			Db.NonQ(command);
		}

	}
}