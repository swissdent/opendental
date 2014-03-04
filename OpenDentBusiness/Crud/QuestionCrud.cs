//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class QuestionCrud {
		///<summary>Gets one Question object from the database using the primary key.  Returns null if not found.</summary>
		public static Question SelectOne(long questionNum){
			string command="SELECT * FROM question "
				+"WHERE QuestionNum = "+POut.Long(questionNum);
			List<Question> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Question object from the database using a query.</summary>
		public static Question SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Question> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Question objects from the database using a query.</summary>
		public static List<Question> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Question> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Question> TableToList(DataTable table){
			List<Question> retVal=new List<Question>();
			Question question;
			for(int i=0;i<table.Rows.Count;i++) {
				question=new Question();
				question.QuestionNum= PIn.Long  (table.Rows[i]["QuestionNum"].ToString());
				question.PatNum     = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				question.ItemOrder  = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				question.Description= PIn.String(table.Rows[i]["Description"].ToString());
				question.Answer     = PIn.String(table.Rows[i]["Answer"].ToString());
				question.FormPatNum = PIn.Long  (table.Rows[i]["FormPatNum"].ToString());
				retVal.Add(question);
			}
			return retVal;
		}

		///<summary>Inserts one Question into the database.  Returns the new priKey.</summary>
		public static long Insert(Question question){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				question.QuestionNum=DbHelper.GetNextOracleKey("question","QuestionNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(question,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							question.QuestionNum++;
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
				return Insert(question,false);
			}
		}

		///<summary>Inserts one Question into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Question question,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				question.QuestionNum=ReplicationServers.GetKey("question","QuestionNum");
			}
			string command="INSERT INTO question (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="QuestionNum,";
			}
			command+="PatNum,ItemOrder,Description,Answer,FormPatNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(question.QuestionNum)+",";
			}
			command+=
				     POut.Long  (question.PatNum)+","
				+    POut.Int   (question.ItemOrder)+","
				+"'"+POut.String(question.Description)+"',"
				+"'"+POut.String(question.Answer)+"',"
				+    POut.Long  (question.FormPatNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				question.QuestionNum=Db.NonQ(command,true);
			}
			return question.QuestionNum;
		}

		///<summary>Updates one Question in the database.</summary>
		public static void Update(Question question){
			string command="UPDATE question SET "
				+"PatNum     =  "+POut.Long  (question.PatNum)+", "
				+"ItemOrder  =  "+POut.Int   (question.ItemOrder)+", "
				+"Description= '"+POut.String(question.Description)+"', "
				+"Answer     = '"+POut.String(question.Answer)+"', "
				+"FormPatNum =  "+POut.Long  (question.FormPatNum)+" "
				+"WHERE QuestionNum = "+POut.Long(question.QuestionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Question in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Question question,Question oldQuestion){
			string command="";
			if(question.PatNum != oldQuestion.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(question.PatNum)+"";
			}
			if(question.ItemOrder != oldQuestion.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(question.ItemOrder)+"";
			}
			if(question.Description != oldQuestion.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(question.Description)+"'";
			}
			if(question.Answer != oldQuestion.Answer) {
				if(command!=""){ command+=",";}
				command+="Answer = '"+POut.String(question.Answer)+"'";
			}
			if(question.FormPatNum != oldQuestion.FormPatNum) {
				if(command!=""){ command+=",";}
				command+="FormPatNum = "+POut.Long(question.FormPatNum)+"";
			}
			if(command==""){
				return false;
			}
			command="UPDATE question SET "+command
				+" WHERE QuestionNum = "+POut.Long(question.QuestionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Question from the database.</summary>
		public static void Delete(long questionNum){
			string command="DELETE FROM question "
				+"WHERE QuestionNum = "+POut.Long(questionNum);
			Db.NonQ(command);
		}

	}
}