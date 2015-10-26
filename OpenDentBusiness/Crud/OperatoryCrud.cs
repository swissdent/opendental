//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class OperatoryCrud {
		///<summary>Gets one Operatory object from the database using the primary key.  Returns null if not found.</summary>
		public static Operatory SelectOne(long operatoryNum){
			string command="SELECT * FROM operatory "
				+"WHERE OperatoryNum = "+POut.Long(operatoryNum);
			List<Operatory> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Operatory object from the database using a query.</summary>
		public static Operatory SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Operatory> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Operatory objects from the database using a query.</summary>
		public static List<Operatory> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Operatory> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Operatory> TableToList(DataTable table){
			List<Operatory> retVal=new List<Operatory>();
			Operatory operatory;
			foreach(DataRow row in table.Rows) {
				operatory=new Operatory();
				operatory.OperatoryNum  = PIn.Long  (row["OperatoryNum"].ToString());
				operatory.OpName        = PIn.String(row["OpName"].ToString());
				operatory.Abbrev        = PIn.String(row["Abbrev"].ToString());
				operatory.ItemOrder     = PIn.Int   (row["ItemOrder"].ToString());
				operatory.IsHidden      = PIn.Bool  (row["IsHidden"].ToString());
				operatory.ProvDentist   = PIn.Long  (row["ProvDentist"].ToString());
				operatory.ProvHygienist = PIn.Long  (row["ProvHygienist"].ToString());
				operatory.IsHygiene     = PIn.Bool  (row["IsHygiene"].ToString());
				operatory.ClinicNum     = PIn.Long  (row["ClinicNum"].ToString());
				operatory.SetProspective= PIn.Bool  (row["SetProspective"].ToString());
				operatory.IsWebSched    = PIn.Bool  (row["IsWebSched"].ToString());
				retVal.Add(operatory);
			}
			return retVal;
		}

		///<summary>Inserts one Operatory into the database.  Returns the new priKey.</summary>
		public static long Insert(Operatory operatory){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				operatory.OperatoryNum=DbHelper.GetNextOracleKey("operatory","OperatoryNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(operatory,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							operatory.OperatoryNum++;
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
				return Insert(operatory,false);
			}
		}

		///<summary>Inserts one Operatory into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Operatory operatory,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				operatory.OperatoryNum=ReplicationServers.GetKey("operatory","OperatoryNum");
			}
			string command="INSERT INTO operatory (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OperatoryNum,";
			}
			command+="OpName,Abbrev,ItemOrder,IsHidden,ProvDentist,ProvHygienist,IsHygiene,ClinicNum,SetProspective,IsWebSched) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(operatory.OperatoryNum)+",";
			}
			command+=
				 "'"+POut.String(operatory.OpName)+"',"
				+"'"+POut.String(operatory.Abbrev)+"',"
				+    POut.Int   (operatory.ItemOrder)+","
				+    POut.Bool  (operatory.IsHidden)+","
				+    POut.Long  (operatory.ProvDentist)+","
				+    POut.Long  (operatory.ProvHygienist)+","
				+    POut.Bool  (operatory.IsHygiene)+","
				+    POut.Long  (operatory.ClinicNum)+","
				+    POut.Bool  (operatory.SetProspective)+","
				+    POut.Bool  (operatory.IsWebSched)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				operatory.OperatoryNum=Db.NonQ(command,true);
			}
			return operatory.OperatoryNum;
		}

		///<summary>Inserts one Operatory into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Operatory operatory){
			if(DataConnection.DBtype==DatabaseType.MySql) {
				return InsertNoCache(operatory,false);
			}
			else {
				if(DataConnection.DBtype==DatabaseType.Oracle) {
					operatory.OperatoryNum=DbHelper.GetNextOracleKey("operatory","OperatoryNum"); //Cacheless method
				}
				return InsertNoCache(operatory,true);
			}
		}

		///<summary>Inserts one Operatory into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Operatory operatory,bool useExistingPK){
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO operatory (";
			if(!useExistingPK && isRandomKeys) {
				operatory.OperatoryNum=ReplicationServers.GetKeyNoCache("operatory","OperatoryNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="OperatoryNum,";
			}
			command+="OpName,Abbrev,ItemOrder,IsHidden,ProvDentist,ProvHygienist,IsHygiene,ClinicNum,SetProspective,IsWebSched) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(operatory.OperatoryNum)+",";
			}
			command+=
				 "'"+POut.String(operatory.OpName)+"',"
				+"'"+POut.String(operatory.Abbrev)+"',"
				+    POut.Int   (operatory.ItemOrder)+","
				+    POut.Bool  (operatory.IsHidden)+","
				+    POut.Long  (operatory.ProvDentist)+","
				+    POut.Long  (operatory.ProvHygienist)+","
				+    POut.Bool  (operatory.IsHygiene)+","
				+    POut.Long  (operatory.ClinicNum)+","
				+    POut.Bool  (operatory.SetProspective)+","
				+    POut.Bool  (operatory.IsWebSched)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				operatory.OperatoryNum=Db.NonQ(command,true);
			}
			return operatory.OperatoryNum;
		}

		///<summary>Updates one Operatory in the database.</summary>
		public static void Update(Operatory operatory){
			string command="UPDATE operatory SET "
				+"OpName        = '"+POut.String(operatory.OpName)+"', "
				+"Abbrev        = '"+POut.String(operatory.Abbrev)+"', "
				+"ItemOrder     =  "+POut.Int   (operatory.ItemOrder)+", "
				+"IsHidden      =  "+POut.Bool  (operatory.IsHidden)+", "
				+"ProvDentist   =  "+POut.Long  (operatory.ProvDentist)+", "
				+"ProvHygienist =  "+POut.Long  (operatory.ProvHygienist)+", "
				+"IsHygiene     =  "+POut.Bool  (operatory.IsHygiene)+", "
				+"ClinicNum     =  "+POut.Long  (operatory.ClinicNum)+", "
				+"SetProspective=  "+POut.Bool  (operatory.SetProspective)+", "
				+"IsWebSched    =  "+POut.Bool  (operatory.IsWebSched)+" "
				+"WHERE OperatoryNum = "+POut.Long(operatory.OperatoryNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Operatory in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Operatory operatory,Operatory oldOperatory){
			string command="";
			if(operatory.OpName != oldOperatory.OpName) {
				if(command!=""){ command+=",";}
				command+="OpName = '"+POut.String(operatory.OpName)+"'";
			}
			if(operatory.Abbrev != oldOperatory.Abbrev) {
				if(command!=""){ command+=",";}
				command+="Abbrev = '"+POut.String(operatory.Abbrev)+"'";
			}
			if(operatory.ItemOrder != oldOperatory.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(operatory.ItemOrder)+"";
			}
			if(operatory.IsHidden != oldOperatory.IsHidden) {
				if(command!=""){ command+=",";}
				command+="IsHidden = "+POut.Bool(operatory.IsHidden)+"";
			}
			if(operatory.ProvDentist != oldOperatory.ProvDentist) {
				if(command!=""){ command+=",";}
				command+="ProvDentist = "+POut.Long(operatory.ProvDentist)+"";
			}
			if(operatory.ProvHygienist != oldOperatory.ProvHygienist) {
				if(command!=""){ command+=",";}
				command+="ProvHygienist = "+POut.Long(operatory.ProvHygienist)+"";
			}
			if(operatory.IsHygiene != oldOperatory.IsHygiene) {
				if(command!=""){ command+=",";}
				command+="IsHygiene = "+POut.Bool(operatory.IsHygiene)+"";
			}
			if(operatory.ClinicNum != oldOperatory.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(operatory.ClinicNum)+"";
			}
			if(operatory.SetProspective != oldOperatory.SetProspective) {
				if(command!=""){ command+=",";}
				command+="SetProspective = "+POut.Bool(operatory.SetProspective)+"";
			}
			if(operatory.IsWebSched != oldOperatory.IsWebSched) {
				if(command!=""){ command+=",";}
				command+="IsWebSched = "+POut.Bool(operatory.IsWebSched)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE operatory SET "+command
				+" WHERE OperatoryNum = "+POut.Long(operatory.OperatoryNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Operatory from the database.</summary>
		public static void Delete(long operatoryNum){
			string command="DELETE FROM operatory "
				+"WHERE OperatoryNum = "+POut.Long(operatoryNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.</summary>
		public static void Sync(List<Operatory> listNew,List<Operatory> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<Operatory> listIns    =new List<Operatory>();
			List<Operatory> listUpdNew =new List<Operatory>();
			List<Operatory> listUpdDB  =new List<Operatory>();
			List<Operatory> listDel    =new List<Operatory>();
			listNew.Sort((Operatory x,Operatory y) => { return x.OperatoryNum.CompareTo(y.OperatoryNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((Operatory x,Operatory y) => { return x.OperatoryNum.CompareTo(y.OperatoryNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			Operatory fieldNew;
			Operatory fieldDB;
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
				else if(fieldNew.OperatoryNum<fieldDB.OperatoryNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.OperatoryNum>fieldDB.OperatoryNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].OperatoryNum);
			}
		}

	}
}