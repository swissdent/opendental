//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class HL7DefCrud {
		///<summary>Gets one HL7Def object from the database using the primary key.  Returns null if not found.</summary>
		public static HL7Def SelectOne(long hL7DefNum){
			string command="SELECT * FROM hl7def "
				+"WHERE HL7DefNum = "+POut.Long(hL7DefNum);
			List<HL7Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one HL7Def object from the database using a query.</summary>
		public static HL7Def SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<HL7Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of HL7Def objects from the database using a query.</summary>
		public static List<HL7Def> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<HL7Def> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<HL7Def> TableToList(DataTable table){
			List<HL7Def> retVal=new List<HL7Def>();
			HL7Def hL7Def;
			for(int i=0;i<table.Rows.Count;i++) {
				hL7Def=new HL7Def();
				hL7Def.HL7DefNum            = PIn.Long  (table.Rows[i]["HL7DefNum"].ToString());
				hL7Def.Description          = PIn.String(table.Rows[i]["Description"].ToString());
				hL7Def.ModeTx               = (OpenDentBusiness.ModeTxHL7)PIn.Int(table.Rows[i]["ModeTx"].ToString());
				hL7Def.IncomingFolder       = PIn.String(table.Rows[i]["IncomingFolder"].ToString());
				hL7Def.OutgoingFolder       = PIn.String(table.Rows[i]["OutgoingFolder"].ToString());
				hL7Def.IncomingPort         = PIn.String(table.Rows[i]["IncomingPort"].ToString());
				hL7Def.OutgoingIpPort       = PIn.String(table.Rows[i]["OutgoingIpPort"].ToString());
				hL7Def.FieldSeparator       = PIn.String(table.Rows[i]["FieldSeparator"].ToString());
				hL7Def.ComponentSeparator   = PIn.String(table.Rows[i]["ComponentSeparator"].ToString());
				hL7Def.SubcomponentSeparator= PIn.String(table.Rows[i]["SubcomponentSeparator"].ToString());
				hL7Def.RepetitionSeparator  = PIn.String(table.Rows[i]["RepetitionSeparator"].ToString());
				hL7Def.EscapeCharacter      = PIn.String(table.Rows[i]["EscapeCharacter"].ToString());
				hL7Def.IsInternal           = PIn.Bool  (table.Rows[i]["IsInternal"].ToString());
				string internalType=table.Rows[i]["InternalType"].ToString();
				if(internalType==""){
					hL7Def.InternalType       =(HL7InternalType)0;
				}
				else try{
					hL7Def.InternalType       =(HL7InternalType)Enum.Parse(typeof(HL7InternalType),internalType);
				}
				catch{
					hL7Def.InternalType       =(HL7InternalType)0;
				}
				hL7Def.InternalTypeVersion  = PIn.String(table.Rows[i]["InternalTypeVersion"].ToString());
				hL7Def.IsEnabled            = PIn.Bool  (table.Rows[i]["IsEnabled"].ToString());
				hL7Def.Note                 = PIn.String(table.Rows[i]["Note"].ToString());
				hL7Def.HL7Server            = PIn.String(table.Rows[i]["HL7Server"].ToString());
				hL7Def.HL7ServiceName       = PIn.String(table.Rows[i]["HL7ServiceName"].ToString());
				hL7Def.ShowDemographics     = (OpenDentBusiness.HL7ShowDemographics)PIn.Int(table.Rows[i]["ShowDemographics"].ToString());
				hL7Def.ShowAppts            = PIn.Bool  (table.Rows[i]["ShowAppts"].ToString());
				hL7Def.ShowAccount          = PIn.Bool  (table.Rows[i]["ShowAccount"].ToString());
				hL7Def.IsQuadAsToothNum     = PIn.Bool  (table.Rows[i]["IsQuadAsToothNum"].ToString());
				hL7Def.LabResultImageCat    = PIn.Long  (table.Rows[i]["LabResultImageCat"].ToString());
				retVal.Add(hL7Def);
			}
			return retVal;
		}

		///<summary>Inserts one HL7Def into the database.  Returns the new priKey.</summary>
		public static long Insert(HL7Def hL7Def){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				hL7Def.HL7DefNum=DbHelper.GetNextOracleKey("hl7def","HL7DefNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(hL7Def,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							hL7Def.HL7DefNum++;
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
				return Insert(hL7Def,false);
			}
		}

		///<summary>Inserts one HL7Def into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(HL7Def hL7Def,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				hL7Def.HL7DefNum=ReplicationServers.GetKey("hl7def","HL7DefNum");
			}
			string command="INSERT INTO hl7def (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="HL7DefNum,";
			}
			command+="Description,ModeTx,IncomingFolder,OutgoingFolder,IncomingPort,OutgoingIpPort,FieldSeparator,ComponentSeparator,SubcomponentSeparator,RepetitionSeparator,EscapeCharacter,IsInternal,InternalType,InternalTypeVersion,IsEnabled,Note,HL7Server,HL7ServiceName,ShowDemographics,ShowAppts,ShowAccount,IsQuadAsToothNum,LabResultImageCat) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(hL7Def.HL7DefNum)+",";
			}
			command+=
				 "'"+POut.String(hL7Def.Description)+"',"
				+    POut.Int   ((int)hL7Def.ModeTx)+","
				+"'"+POut.String(hL7Def.IncomingFolder)+"',"
				+"'"+POut.String(hL7Def.OutgoingFolder)+"',"
				+"'"+POut.String(hL7Def.IncomingPort)+"',"
				+"'"+POut.String(hL7Def.OutgoingIpPort)+"',"
				+"'"+POut.String(hL7Def.FieldSeparator)+"',"
				+"'"+POut.String(hL7Def.ComponentSeparator)+"',"
				+"'"+POut.String(hL7Def.SubcomponentSeparator)+"',"
				+"'"+POut.String(hL7Def.RepetitionSeparator)+"',"
				+"'"+POut.String(hL7Def.EscapeCharacter)+"',"
				+    POut.Bool  (hL7Def.IsInternal)+","
				+"'"+POut.String(hL7Def.InternalType.ToString())+"',"
				+"'"+POut.String(hL7Def.InternalTypeVersion)+"',"
				+    POut.Bool  (hL7Def.IsEnabled)+","
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(hL7Def.HL7Server)+"',"
				+"'"+POut.String(hL7Def.HL7ServiceName)+"',"
				+    POut.Int   ((int)hL7Def.ShowDemographics)+","
				+    POut.Bool  (hL7Def.ShowAppts)+","
				+    POut.Bool  (hL7Def.ShowAccount)+","
				+    POut.Bool  (hL7Def.IsQuadAsToothNum)+","
				+    POut.Long  (hL7Def.LabResultImageCat)+")";
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,hL7Def.Note);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNote);
			}
			else {
				hL7Def.HL7DefNum=Db.NonQ(command,true,paramNote);
			}
			return hL7Def.HL7DefNum;
		}

		///<summary>Updates one HL7Def in the database.</summary>
		public static void Update(HL7Def hL7Def){
			string command="UPDATE hl7def SET "
				+"Description          = '"+POut.String(hL7Def.Description)+"', "
				+"ModeTx               =  "+POut.Int   ((int)hL7Def.ModeTx)+", "
				+"IncomingFolder       = '"+POut.String(hL7Def.IncomingFolder)+"', "
				+"OutgoingFolder       = '"+POut.String(hL7Def.OutgoingFolder)+"', "
				+"IncomingPort         = '"+POut.String(hL7Def.IncomingPort)+"', "
				+"OutgoingIpPort       = '"+POut.String(hL7Def.OutgoingIpPort)+"', "
				+"FieldSeparator       = '"+POut.String(hL7Def.FieldSeparator)+"', "
				+"ComponentSeparator   = '"+POut.String(hL7Def.ComponentSeparator)+"', "
				+"SubcomponentSeparator= '"+POut.String(hL7Def.SubcomponentSeparator)+"', "
				+"RepetitionSeparator  = '"+POut.String(hL7Def.RepetitionSeparator)+"', "
				+"EscapeCharacter      = '"+POut.String(hL7Def.EscapeCharacter)+"', "
				+"IsInternal           =  "+POut.Bool  (hL7Def.IsInternal)+", "
				+"InternalType         = '"+POut.String(hL7Def.InternalType.ToString())+"', "
				+"InternalTypeVersion  = '"+POut.String(hL7Def.InternalTypeVersion)+"', "
				+"IsEnabled            =  "+POut.Bool  (hL7Def.IsEnabled)+", "
				+"Note                 =  "+DbHelper.ParamChar+"paramNote, "
				+"HL7Server            = '"+POut.String(hL7Def.HL7Server)+"', "
				+"HL7ServiceName       = '"+POut.String(hL7Def.HL7ServiceName)+"', "
				+"ShowDemographics     =  "+POut.Int   ((int)hL7Def.ShowDemographics)+", "
				+"ShowAppts            =  "+POut.Bool  (hL7Def.ShowAppts)+", "
				+"ShowAccount          =  "+POut.Bool  (hL7Def.ShowAccount)+", "
				+"IsQuadAsToothNum     =  "+POut.Bool  (hL7Def.IsQuadAsToothNum)+", "
				+"LabResultImageCat    =  "+POut.Long  (hL7Def.LabResultImageCat)+" "
				+"WHERE HL7DefNum = "+POut.Long(hL7Def.HL7DefNum);
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,hL7Def.Note);
			Db.NonQ(command,paramNote);
		}

		///<summary>Updates one HL7Def in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(HL7Def hL7Def,HL7Def oldHL7Def){
			string command="";
			if(hL7Def.Description != oldHL7Def.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(hL7Def.Description)+"'";
			}
			if(hL7Def.ModeTx != oldHL7Def.ModeTx) {
				if(command!=""){ command+=",";}
				command+="ModeTx = "+POut.Int   ((int)hL7Def.ModeTx)+"";
			}
			if(hL7Def.IncomingFolder != oldHL7Def.IncomingFolder) {
				if(command!=""){ command+=",";}
				command+="IncomingFolder = '"+POut.String(hL7Def.IncomingFolder)+"'";
			}
			if(hL7Def.OutgoingFolder != oldHL7Def.OutgoingFolder) {
				if(command!=""){ command+=",";}
				command+="OutgoingFolder = '"+POut.String(hL7Def.OutgoingFolder)+"'";
			}
			if(hL7Def.IncomingPort != oldHL7Def.IncomingPort) {
				if(command!=""){ command+=",";}
				command+="IncomingPort = '"+POut.String(hL7Def.IncomingPort)+"'";
			}
			if(hL7Def.OutgoingIpPort != oldHL7Def.OutgoingIpPort) {
				if(command!=""){ command+=",";}
				command+="OutgoingIpPort = '"+POut.String(hL7Def.OutgoingIpPort)+"'";
			}
			if(hL7Def.FieldSeparator != oldHL7Def.FieldSeparator) {
				if(command!=""){ command+=",";}
				command+="FieldSeparator = '"+POut.String(hL7Def.FieldSeparator)+"'";
			}
			if(hL7Def.ComponentSeparator != oldHL7Def.ComponentSeparator) {
				if(command!=""){ command+=",";}
				command+="ComponentSeparator = '"+POut.String(hL7Def.ComponentSeparator)+"'";
			}
			if(hL7Def.SubcomponentSeparator != oldHL7Def.SubcomponentSeparator) {
				if(command!=""){ command+=",";}
				command+="SubcomponentSeparator = '"+POut.String(hL7Def.SubcomponentSeparator)+"'";
			}
			if(hL7Def.RepetitionSeparator != oldHL7Def.RepetitionSeparator) {
				if(command!=""){ command+=",";}
				command+="RepetitionSeparator = '"+POut.String(hL7Def.RepetitionSeparator)+"'";
			}
			if(hL7Def.EscapeCharacter != oldHL7Def.EscapeCharacter) {
				if(command!=""){ command+=",";}
				command+="EscapeCharacter = '"+POut.String(hL7Def.EscapeCharacter)+"'";
			}
			if(hL7Def.IsInternal != oldHL7Def.IsInternal) {
				if(command!=""){ command+=",";}
				command+="IsInternal = "+POut.Bool(hL7Def.IsInternal)+"";
			}
			if(hL7Def.InternalType != oldHL7Def.InternalType) {
				if(command!=""){ command+=",";}
				command+="InternalType = '"+POut.String(hL7Def.InternalType.ToString())+"'";
			}
			if(hL7Def.InternalTypeVersion != oldHL7Def.InternalTypeVersion) {
				if(command!=""){ command+=",";}
				command+="InternalTypeVersion = '"+POut.String(hL7Def.InternalTypeVersion)+"'";
			}
			if(hL7Def.IsEnabled != oldHL7Def.IsEnabled) {
				if(command!=""){ command+=",";}
				command+="IsEnabled = "+POut.Bool(hL7Def.IsEnabled)+"";
			}
			if(hL7Def.Note != oldHL7Def.Note) {
				if(command!=""){ command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(hL7Def.HL7Server != oldHL7Def.HL7Server) {
				if(command!=""){ command+=",";}
				command+="HL7Server = '"+POut.String(hL7Def.HL7Server)+"'";
			}
			if(hL7Def.HL7ServiceName != oldHL7Def.HL7ServiceName) {
				if(command!=""){ command+=",";}
				command+="HL7ServiceName = '"+POut.String(hL7Def.HL7ServiceName)+"'";
			}
			if(hL7Def.ShowDemographics != oldHL7Def.ShowDemographics) {
				if(command!=""){ command+=",";}
				command+="ShowDemographics = "+POut.Int   ((int)hL7Def.ShowDemographics)+"";
			}
			if(hL7Def.ShowAppts != oldHL7Def.ShowAppts) {
				if(command!=""){ command+=",";}
				command+="ShowAppts = "+POut.Bool(hL7Def.ShowAppts)+"";
			}
			if(hL7Def.ShowAccount != oldHL7Def.ShowAccount) {
				if(command!=""){ command+=",";}
				command+="ShowAccount = "+POut.Bool(hL7Def.ShowAccount)+"";
			}
			if(hL7Def.IsQuadAsToothNum != oldHL7Def.IsQuadAsToothNum) {
				if(command!=""){ command+=",";}
				command+="IsQuadAsToothNum = "+POut.Bool(hL7Def.IsQuadAsToothNum)+"";
			}
			if(hL7Def.LabResultImageCat != oldHL7Def.LabResultImageCat) {
				if(command!=""){ command+=",";}
				command+="LabResultImageCat = "+POut.Long(hL7Def.LabResultImageCat)+"";
			}
			if(command==""){
				return false;
			}
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,hL7Def.Note);
			command="UPDATE hl7def SET "+command
				+" WHERE HL7DefNum = "+POut.Long(hL7Def.HL7DefNum);
			Db.NonQ(command,paramNote);
			return true;
		}

		///<summary>Deletes one HL7Def from the database.</summary>
		public static void Delete(long hL7DefNum){
			string command="DELETE FROM hl7def "
				+"WHERE HL7DefNum = "+POut.Long(hL7DefNum);
			Db.NonQ(command);
		}

	}
}