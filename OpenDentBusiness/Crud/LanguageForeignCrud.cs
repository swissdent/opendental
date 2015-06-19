//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LanguageForeignCrud {
		///<summary>Gets one LanguageForeign object from the database using the primary key.  Returns null if not found.</summary>
		public static LanguageForeign SelectOne(long languageForeignNum){
			string command="SELECT * FROM languageforeign "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeignNum);
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LanguageForeign object from the database using a query.</summary>
		public static LanguageForeign SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LanguageForeign objects from the database using a query.</summary>
		public static List<LanguageForeign> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LanguageForeign> TableToList(DataTable table){
			List<LanguageForeign> retVal=new List<LanguageForeign>();
			LanguageForeign languageForeign;
			for(int i=0;i<table.Rows.Count;i++) {
				languageForeign=new LanguageForeign();
				languageForeign.LanguageForeignNum= PIn.Long  (table.Rows[i]["LanguageForeignNum"].ToString());
				languageForeign.ClassType         = PIn.String(table.Rows[i]["ClassType"].ToString());
				languageForeign.English           = PIn.String(table.Rows[i]["English"].ToString());
				languageForeign.Culture           = PIn.String(table.Rows[i]["Culture"].ToString());
				languageForeign.Translation       = PIn.String(table.Rows[i]["Translation"].ToString());
				languageForeign.Comments          = PIn.String(table.Rows[i]["Comments"].ToString());
				retVal.Add(languageForeign);
			}
			return retVal;
		}

		///<summary>Inserts one LanguageForeign into the database.  Returns the new priKey.</summary>
		public static long Insert(LanguageForeign languageForeign){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				languageForeign.LanguageForeignNum=DbHelper.GetNextOracleKey("languageforeign","LanguageForeignNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(languageForeign,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							languageForeign.LanguageForeignNum++;
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
				return Insert(languageForeign,false);
			}
		}

		///<summary>Inserts one LanguageForeign into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LanguageForeign languageForeign,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				languageForeign.LanguageForeignNum=ReplicationServers.GetKey("languageforeign","LanguageForeignNum");
			}
			string command="INSERT INTO languageforeign (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LanguageForeignNum,";
			}
			command+="ClassType,English,Culture,Translation,Comments) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(languageForeign.LanguageForeignNum)+",";
			}
			command+=
				 "'"+POut.String(languageForeign.ClassType)+"',"
				+"'"+POut.String(languageForeign.English)+"',"
				+"'"+POut.String(languageForeign.Culture)+"',"
				+"'"+POut.String(languageForeign.Translation)+"',"
				+"'"+POut.String(languageForeign.Comments)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				languageForeign.LanguageForeignNum=Db.NonQ(command,true);
			}
			return languageForeign.LanguageForeignNum;
		}

		///<summary>Inserts one LanguageForeign into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LanguageForeign languageForeign){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(languageForeign,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					languageForeign.LanguageForeignNum=DbHelper.GetNextOracleKey("languageforeign","LanguageForeignNum"); //Cacheless method
				}
				return InsertNoCache(languageForeign,true);
			}
		}

		///<summary>Inserts one LanguageForeign into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LanguageForeign languageForeign,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO languageforeign (";
			if(!useExistingPK && isRandomKeys) {
				languageForeign.LanguageForeignNum=ReplicationServers.GetKeyNoCache("languageforeign","LanguageForeignNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="LanguageForeignNum,";
			}
			command+="ClassType,English,Culture,Translation,Comments) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(languageForeign.LanguageForeignNum)+",";
			}
			command+=
				 "'"+POut.String(languageForeign.ClassType)+"',"
				+"'"+POut.String(languageForeign.English)+"',"
				+"'"+POut.String(languageForeign.Culture)+"',"
				+"'"+POut.String(languageForeign.Translation)+"',"
				+"'"+POut.String(languageForeign.Comments)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				languageForeign.LanguageForeignNum=Db.NonQ(command,true);
			}
			return languageForeign.LanguageForeignNum;
		}

		///<summary>Updates one LanguageForeign in the database.</summary>
		public static void Update(LanguageForeign languageForeign){
			string command="UPDATE languageforeign SET "
				+"ClassType         = '"+POut.String(languageForeign.ClassType)+"', "
				+"English           = '"+POut.String(languageForeign.English)+"', "
				+"Culture           = '"+POut.String(languageForeign.Culture)+"', "
				+"Translation       = '"+POut.String(languageForeign.Translation)+"', "
				+"Comments          = '"+POut.String(languageForeign.Comments)+"' "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeign.LanguageForeignNum);
			Db.NonQ(command);
		}

		///<summary>Updates one LanguageForeign in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(LanguageForeign languageForeign,LanguageForeign oldLanguageForeign){
			string command="";
			if(languageForeign.ClassType != oldLanguageForeign.ClassType) {
				if(command!=""){ command+=",";}
				command+="ClassType = '"+POut.String(languageForeign.ClassType)+"'";
			}
			if(languageForeign.English != oldLanguageForeign.English) {
				if(command!=""){ command+=",";}
				command+="English = '"+POut.String(languageForeign.English)+"'";
			}
			if(languageForeign.Culture != oldLanguageForeign.Culture) {
				if(command!=""){ command+=",";}
				command+="Culture = '"+POut.String(languageForeign.Culture)+"'";
			}
			if(languageForeign.Translation != oldLanguageForeign.Translation) {
				if(command!=""){ command+=",";}
				command+="Translation = '"+POut.String(languageForeign.Translation)+"'";
			}
			if(languageForeign.Comments != oldLanguageForeign.Comments) {
				if(command!=""){ command+=",";}
				command+="Comments = '"+POut.String(languageForeign.Comments)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE languageforeign SET "+command
				+" WHERE LanguageForeignNum = "+POut.Long(languageForeign.LanguageForeignNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one LanguageForeign from the database.</summary>
		public static void Delete(long languageForeignNum){
			string command="DELETE FROM languageforeign "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeignNum);
			Db.NonQ(command);
		}

	}
}