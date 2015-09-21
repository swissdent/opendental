//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EmailAutographCrud {
		///<summary>Gets one EmailAutograph object from the database using the primary key.  Returns null if not found.</summary>
		public static EmailAutograph SelectOne(long emailAutographNum){
			string command="SELECT * FROM emailautograph "
				+"WHERE EmailAutographNum = "+POut.Long(emailAutographNum);
			List<EmailAutograph> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EmailAutograph object from the database using a query.</summary>
		public static EmailAutograph SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailAutograph> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EmailAutograph objects from the database using a query.</summary>
		public static List<EmailAutograph> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailAutograph> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EmailAutograph> TableToList(DataTable table){
			List<EmailAutograph> retVal=new List<EmailAutograph>();
			EmailAutograph emailAutograph;
			for(int i=0;i<table.Rows.Count;i++) {
				emailAutograph=new EmailAutograph();
				emailAutograph.EmailAutographNum= PIn.Long  (table.Rows[i]["EmailAutographNum"].ToString());
				emailAutograph.Description      = PIn.String(table.Rows[i]["Description"].ToString());
				emailAutograph.EmailAddress     = PIn.String(table.Rows[i]["EmailAddress"].ToString());
				emailAutograph.AutographText    = PIn.String(table.Rows[i]["AutographText"].ToString());
				retVal.Add(emailAutograph);
			}
			return retVal;
		}

		///<summary>Inserts one EmailAutograph into the database.  Returns the new priKey.</summary>
		public static long Insert(EmailAutograph emailAutograph){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				emailAutograph.EmailAutographNum=DbHelper.GetNextOracleKey("emailautograph","EmailAutographNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(emailAutograph,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							emailAutograph.EmailAutographNum++;
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
				return Insert(emailAutograph,false);
			}
		}

		///<summary>Inserts one EmailAutograph into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EmailAutograph emailAutograph,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				emailAutograph.EmailAutographNum=ReplicationServers.GetKey("emailautograph","EmailAutographNum");
			}
			string command="INSERT INTO emailautograph (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmailAutographNum,";
			}
			command+="Description,EmailAddress,AutographText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(emailAutograph.EmailAutographNum)+",";
			}
			command+=
				 "'"+POut.String(emailAutograph.Description)+"',"
				+"'"+POut.String(emailAutograph.EmailAddress)+"',"
				+"'"+POut.String(emailAutograph.AutographText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				emailAutograph.EmailAutographNum=Db.NonQ(command,true);
			}
			return emailAutograph.EmailAutographNum;
		}

		///<summary>Inserts one EmailAutograph into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailAutograph emailAutograph){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(emailAutograph,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					emailAutograph.EmailAutographNum=DbHelper.GetNextOracleKey("emailautograph","EmailAutographNum"); //Cacheless method
				}
				return InsertNoCache(emailAutograph,true);
			}
		}

		///<summary>Inserts one EmailAutograph into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailAutograph emailAutograph,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO emailautograph (";
			if(!useExistingPK && isRandomKeys) {
				emailAutograph.EmailAutographNum=ReplicationServers.GetKeyNoCache("emailautograph","EmailAutographNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EmailAutographNum,";
			}
			command+="Description,EmailAddress,AutographText) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(emailAutograph.EmailAutographNum)+",";
			}
			command+=
				 "'"+POut.String(emailAutograph.Description)+"',"
				+"'"+POut.String(emailAutograph.EmailAddress)+"',"
				+"'"+POut.String(emailAutograph.AutographText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				emailAutograph.EmailAutographNum=Db.NonQ(command,true);
			}
			return emailAutograph.EmailAutographNum;
		}

		///<summary>Updates one EmailAutograph in the database.</summary>
		public static void Update(EmailAutograph emailAutograph){
			string command="UPDATE emailautograph SET "
				+"Description      = '"+POut.String(emailAutograph.Description)+"', "
				+"EmailAddress     = '"+POut.String(emailAutograph.EmailAddress)+"', "
				+"AutographText    = '"+POut.String(emailAutograph.AutographText)+"' "
				+"WHERE EmailAutographNum = "+POut.Long(emailAutograph.EmailAutographNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EmailAutograph in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EmailAutograph emailAutograph,EmailAutograph oldEmailAutograph){
			string command="";
			if(emailAutograph.Description != oldEmailAutograph.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(emailAutograph.Description)+"'";
			}
			if(emailAutograph.EmailAddress != oldEmailAutograph.EmailAddress) {
				if(command!=""){ command+=",";}
				command+="EmailAddress = '"+POut.String(emailAutograph.EmailAddress)+"'";
			}
			if(emailAutograph.AutographText != oldEmailAutograph.AutographText) {
				if(command!=""){ command+=",";}
				command+="AutographText = '"+POut.String(emailAutograph.AutographText)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE emailautograph SET "+command
				+" WHERE EmailAutographNum = "+POut.Long(emailAutograph.EmailAutographNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one EmailAutograph from the database.</summary>
		public static void Delete(long emailAutographNum){
			string command="DELETE FROM emailautograph "
				+"WHERE EmailAutographNum = "+POut.Long(emailAutographNum);
			Db.NonQ(command);
		}

	}
}