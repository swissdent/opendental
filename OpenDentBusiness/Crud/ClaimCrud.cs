//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimCrud {
		///<summary>Gets one Claim object from the database using the primary key.  Returns null if not found.</summary>
		public static Claim SelectOne(long claimNum){
			string command="SELECT * FROM claim "
				+"WHERE ClaimNum = "+POut.Long(claimNum);
			List<Claim> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Claim object from the database using a query.</summary>
		public static Claim SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Claim> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Claim objects from the database using a query.</summary>
		public static List<Claim> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Claim> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Claim> TableToList(DataTable table){
			List<Claim> retVal=new List<Claim>();
			Claim claim;
			for(int i=0;i<table.Rows.Count;i++) {
				claim=new Claim();
				claim.ClaimNum                    = PIn.Long  (table.Rows[i]["ClaimNum"].ToString());
				claim.PatNum                      = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				claim.DateService                 = PIn.Date  (table.Rows[i]["DateService"].ToString());
				claim.DateSent                    = PIn.Date  (table.Rows[i]["DateSent"].ToString());
				claim.ClaimStatus                 = PIn.String(table.Rows[i]["ClaimStatus"].ToString());
				claim.DateReceived                = PIn.Date  (table.Rows[i]["DateReceived"].ToString());
				claim.PlanNum                     = PIn.Long  (table.Rows[i]["PlanNum"].ToString());
				claim.ProvTreat                   = PIn.Long  (table.Rows[i]["ProvTreat"].ToString());
				claim.ClaimFee                    = PIn.Double(table.Rows[i]["ClaimFee"].ToString());
				claim.InsPayEst                   = PIn.Double(table.Rows[i]["InsPayEst"].ToString());
				claim.InsPayAmt                   = PIn.Double(table.Rows[i]["InsPayAmt"].ToString());
				claim.DedApplied                  = PIn.Double(table.Rows[i]["DedApplied"].ToString());
				claim.PreAuthString               = PIn.String(table.Rows[i]["PreAuthString"].ToString());
				claim.IsProsthesis                = PIn.String(table.Rows[i]["IsProsthesis"].ToString());
				claim.PriorDate                   = PIn.Date  (table.Rows[i]["PriorDate"].ToString());
				claim.ReasonUnderPaid             = PIn.String(table.Rows[i]["ReasonUnderPaid"].ToString());
				claim.ClaimNote                   = PIn.String(table.Rows[i]["ClaimNote"].ToString());
				claim.ClaimType                   = PIn.String(table.Rows[i]["ClaimType"].ToString());
				claim.ProvBill                    = PIn.Long  (table.Rows[i]["ProvBill"].ToString());
				claim.ReferringProv               = PIn.Long  (table.Rows[i]["ReferringProv"].ToString());
				claim.RefNumString                = PIn.String(table.Rows[i]["RefNumString"].ToString());
				claim.PlaceService                = (PlaceOfService)PIn.Int(table.Rows[i]["PlaceService"].ToString());
				claim.AccidentRelated             = PIn.String(table.Rows[i]["AccidentRelated"].ToString());
				claim.AccidentDate                = PIn.Date  (table.Rows[i]["AccidentDate"].ToString());
				claim.AccidentST                  = PIn.String(table.Rows[i]["AccidentST"].ToString());
				claim.EmployRelated               = (YN)PIn.Int(table.Rows[i]["EmployRelated"].ToString());
				claim.IsOrtho                     = PIn.Bool  (table.Rows[i]["IsOrtho"].ToString());
				claim.OrthoRemainM                = PIn.Byte  (table.Rows[i]["OrthoRemainM"].ToString());
				claim.OrthoDate                   = PIn.Date  (table.Rows[i]["OrthoDate"].ToString());
				claim.PatRelat                    = (Relat)PIn.Int(table.Rows[i]["PatRelat"].ToString());
				claim.PlanNum2                    = PIn.Long  (table.Rows[i]["PlanNum2"].ToString());
				claim.PatRelat2                   = (Relat)PIn.Int(table.Rows[i]["PatRelat2"].ToString());
				claim.WriteOff                    = PIn.Double(table.Rows[i]["WriteOff"].ToString());
				claim.Radiographs                 = PIn.Byte  (table.Rows[i]["Radiographs"].ToString());
				claim.ClinicNum                   = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				claim.ClaimForm                   = PIn.Long  (table.Rows[i]["ClaimForm"].ToString());
				claim.AttachedImages              = PIn.Int   (table.Rows[i]["AttachedImages"].ToString());
				claim.AttachedModels              = PIn.Int   (table.Rows[i]["AttachedModels"].ToString());
				claim.AttachedFlags               = PIn.String(table.Rows[i]["AttachedFlags"].ToString());
				claim.AttachmentID                = PIn.String(table.Rows[i]["AttachmentID"].ToString());
				claim.CanadianMaterialsForwarded  = PIn.String(table.Rows[i]["CanadianMaterialsForwarded"].ToString());
				claim.CanadianReferralProviderNum = PIn.String(table.Rows[i]["CanadianReferralProviderNum"].ToString());
				claim.CanadianReferralReason      = PIn.Byte  (table.Rows[i]["CanadianReferralReason"].ToString());
				claim.CanadianIsInitialLower      = PIn.String(table.Rows[i]["CanadianIsInitialLower"].ToString());
				claim.CanadianDateInitialLower    = PIn.Date  (table.Rows[i]["CanadianDateInitialLower"].ToString());
				claim.CanadianMandProsthMaterial  = PIn.Byte  (table.Rows[i]["CanadianMandProsthMaterial"].ToString());
				claim.CanadianIsInitialUpper      = PIn.String(table.Rows[i]["CanadianIsInitialUpper"].ToString());
				claim.CanadianDateInitialUpper    = PIn.Date  (table.Rows[i]["CanadianDateInitialUpper"].ToString());
				claim.CanadianMaxProsthMaterial   = PIn.Byte  (table.Rows[i]["CanadianMaxProsthMaterial"].ToString());
				claim.InsSubNum                   = PIn.Long  (table.Rows[i]["InsSubNum"].ToString());
				claim.InsSubNum2                  = PIn.Long  (table.Rows[i]["InsSubNum2"].ToString());
				claim.CanadaTransRefNum           = PIn.String(table.Rows[i]["CanadaTransRefNum"].ToString());
				claim.CanadaEstTreatStartDate     = PIn.Date  (table.Rows[i]["CanadaEstTreatStartDate"].ToString());
				claim.CanadaInitialPayment        = PIn.Double(table.Rows[i]["CanadaInitialPayment"].ToString());
				claim.CanadaPaymentMode           = PIn.Byte  (table.Rows[i]["CanadaPaymentMode"].ToString());
				claim.CanadaTreatDuration         = PIn.Byte  (table.Rows[i]["CanadaTreatDuration"].ToString());
				claim.CanadaNumAnticipatedPayments= PIn.Byte  (table.Rows[i]["CanadaNumAnticipatedPayments"].ToString());
				claim.CanadaAnticipatedPayAmount  = PIn.Double(table.Rows[i]["CanadaAnticipatedPayAmount"].ToString());
				claim.PriorAuthorizationNumber    = PIn.String(table.Rows[i]["PriorAuthorizationNumber"].ToString());
				claim.SpecialProgramCode          = (EnumClaimSpecialProgram)PIn.Int(table.Rows[i]["SpecialProgramCode"].ToString());
				claim.UniformBillType             = PIn.String(table.Rows[i]["UniformBillType"].ToString());
				claim.MedType                     = (EnumClaimMedType)PIn.Int(table.Rows[i]["MedType"].ToString());
				claim.AdmissionTypeCode           = PIn.String(table.Rows[i]["AdmissionTypeCode"].ToString());
				claim.AdmissionSourceCode         = PIn.String(table.Rows[i]["AdmissionSourceCode"].ToString());
				claim.PatientStatusCode           = PIn.String(table.Rows[i]["PatientStatusCode"].ToString());
				claim.CustomTracking              = PIn.Long  (table.Rows[i]["CustomTracking"].ToString());
				claim.DateResent                  = PIn.Date  (table.Rows[i]["DateResent"].ToString());
				claim.CorrectionType              = (ClaimCorrectionType)PIn.Int(table.Rows[i]["CorrectionType"].ToString());
				claim.ClaimIdentifier             = PIn.String(table.Rows[i]["ClaimIdentifier"].ToString());
				claim.OrigRefNum                  = PIn.String(table.Rows[i]["OrigRefNum"].ToString());
				retVal.Add(claim);
			}
			return retVal;
		}

		///<summary>Inserts one Claim into the database.  Returns the new priKey.</summary>
		public static long Insert(Claim claim){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claim.ClaimNum=DbHelper.GetNextOracleKey("claim","ClaimNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claim,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claim.ClaimNum++;
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
				return Insert(claim,false);
			}
		}

		///<summary>Inserts one Claim into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Claim claim,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claim.ClaimNum=ReplicationServers.GetKey("claim","ClaimNum");
			}
			string command="INSERT INTO claim (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimNum,";
			}
			command+="PatNum,DateService,DateSent,ClaimStatus,DateReceived,PlanNum,ProvTreat,ClaimFee,InsPayEst,InsPayAmt,DedApplied,PreAuthString,IsProsthesis,PriorDate,ReasonUnderPaid,ClaimNote,ClaimType,ProvBill,ReferringProv,RefNumString,PlaceService,AccidentRelated,AccidentDate,AccidentST,EmployRelated,IsOrtho,OrthoRemainM,OrthoDate,PatRelat,PlanNum2,PatRelat2,WriteOff,Radiographs,ClinicNum,ClaimForm,AttachedImages,AttachedModels,AttachedFlags,AttachmentID,CanadianMaterialsForwarded,CanadianReferralProviderNum,CanadianReferralReason,CanadianIsInitialLower,CanadianDateInitialLower,CanadianMandProsthMaterial,CanadianIsInitialUpper,CanadianDateInitialUpper,CanadianMaxProsthMaterial,InsSubNum,InsSubNum2,CanadaTransRefNum,CanadaEstTreatStartDate,CanadaInitialPayment,CanadaPaymentMode,CanadaTreatDuration,CanadaNumAnticipatedPayments,CanadaAnticipatedPayAmount,PriorAuthorizationNumber,SpecialProgramCode,UniformBillType,MedType,AdmissionTypeCode,AdmissionSourceCode,PatientStatusCode,CustomTracking,DateResent,CorrectionType,ClaimIdentifier,OrigRefNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claim.ClaimNum)+",";
			}
			command+=
				     POut.Long  (claim.PatNum)+","
				+    POut.Date  (claim.DateService)+","
				+    POut.Date  (claim.DateSent)+","
				+"'"+POut.String(claim.ClaimStatus)+"',"
				+    POut.Date  (claim.DateReceived)+","
				+    POut.Long  (claim.PlanNum)+","
				+    POut.Long  (claim.ProvTreat)+","
				+"'"+POut.Double(claim.ClaimFee)+"',"
				+"'"+POut.Double(claim.InsPayEst)+"',"
				+"'"+POut.Double(claim.InsPayAmt)+"',"
				+"'"+POut.Double(claim.DedApplied)+"',"
				+"'"+POut.String(claim.PreAuthString)+"',"
				+"'"+POut.String(claim.IsProsthesis)+"',"
				+    POut.Date  (claim.PriorDate)+","
				+"'"+POut.String(claim.ReasonUnderPaid)+"',"
				+"'"+POut.String(claim.ClaimNote)+"',"
				+"'"+POut.String(claim.ClaimType)+"',"
				+    POut.Long  (claim.ProvBill)+","
				+    POut.Long  (claim.ReferringProv)+","
				+"'"+POut.String(claim.RefNumString)+"',"
				+    POut.Int   ((int)claim.PlaceService)+","
				+"'"+POut.String(claim.AccidentRelated)+"',"
				+    POut.Date  (claim.AccidentDate)+","
				+"'"+POut.String(claim.AccidentST)+"',"
				+    POut.Int   ((int)claim.EmployRelated)+","
				+    POut.Bool  (claim.IsOrtho)+","
				+    POut.Byte  (claim.OrthoRemainM)+","
				+    POut.Date  (claim.OrthoDate)+","
				+    POut.Int   ((int)claim.PatRelat)+","
				+    POut.Long  (claim.PlanNum2)+","
				+    POut.Int   ((int)claim.PatRelat2)+","
				+"'"+POut.Double(claim.WriteOff)+"',"
				+    POut.Byte  (claim.Radiographs)+","
				+    POut.Long  (claim.ClinicNum)+","
				+    POut.Long  (claim.ClaimForm)+","
				+    POut.Int   (claim.AttachedImages)+","
				+    POut.Int   (claim.AttachedModels)+","
				+"'"+POut.String(claim.AttachedFlags)+"',"
				+"'"+POut.String(claim.AttachmentID)+"',"
				+"'"+POut.String(claim.CanadianMaterialsForwarded)+"',"
				+"'"+POut.String(claim.CanadianReferralProviderNum)+"',"
				+    POut.Byte  (claim.CanadianReferralReason)+","
				+"'"+POut.String(claim.CanadianIsInitialLower)+"',"
				+    POut.Date  (claim.CanadianDateInitialLower)+","
				+    POut.Byte  (claim.CanadianMandProsthMaterial)+","
				+"'"+POut.String(claim.CanadianIsInitialUpper)+"',"
				+    POut.Date  (claim.CanadianDateInitialUpper)+","
				+    POut.Byte  (claim.CanadianMaxProsthMaterial)+","
				+    POut.Long  (claim.InsSubNum)+","
				+    POut.Long  (claim.InsSubNum2)+","
				+"'"+POut.String(claim.CanadaTransRefNum)+"',"
				+    POut.Date  (claim.CanadaEstTreatStartDate)+","
				+"'"+POut.Double(claim.CanadaInitialPayment)+"',"
				+    POut.Byte  (claim.CanadaPaymentMode)+","
				+    POut.Byte  (claim.CanadaTreatDuration)+","
				+    POut.Byte  (claim.CanadaNumAnticipatedPayments)+","
				+"'"+POut.Double(claim.CanadaAnticipatedPayAmount)+"',"
				+"'"+POut.String(claim.PriorAuthorizationNumber)+"',"
				+    POut.Int   ((int)claim.SpecialProgramCode)+","
				+"'"+POut.String(claim.UniformBillType)+"',"
				+    POut.Int   ((int)claim.MedType)+","
				+"'"+POut.String(claim.AdmissionTypeCode)+"',"
				+"'"+POut.String(claim.AdmissionSourceCode)+"',"
				+"'"+POut.String(claim.PatientStatusCode)+"',"
				+    POut.Long  (claim.CustomTracking)+","
				+    POut.Date  (claim.DateResent)+","
				+    POut.Int   ((int)claim.CorrectionType)+","
				+"'"+POut.String(claim.ClaimIdentifier)+"',"
				+"'"+POut.String(claim.OrigRefNum)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claim.ClaimNum=Db.NonQ(command,true);
			}
			return claim.ClaimNum;
		}

		///<summary>Updates one Claim in the database.</summary>
		public static void Update(Claim claim){
			string command="UPDATE claim SET "
				+"PatNum                      =  "+POut.Long  (claim.PatNum)+", "
				+"DateService                 =  "+POut.Date  (claim.DateService)+", "
				+"DateSent                    =  "+POut.Date  (claim.DateSent)+", "
				+"ClaimStatus                 = '"+POut.String(claim.ClaimStatus)+"', "
				+"DateReceived                =  "+POut.Date  (claim.DateReceived)+", "
				+"PlanNum                     =  "+POut.Long  (claim.PlanNum)+", "
				+"ProvTreat                   =  "+POut.Long  (claim.ProvTreat)+", "
				+"ClaimFee                    = '"+POut.Double(claim.ClaimFee)+"', "
				+"InsPayEst                   = '"+POut.Double(claim.InsPayEst)+"', "
				+"InsPayAmt                   = '"+POut.Double(claim.InsPayAmt)+"', "
				+"DedApplied                  = '"+POut.Double(claim.DedApplied)+"', "
				+"PreAuthString               = '"+POut.String(claim.PreAuthString)+"', "
				+"IsProsthesis                = '"+POut.String(claim.IsProsthesis)+"', "
				+"PriorDate                   =  "+POut.Date  (claim.PriorDate)+", "
				+"ReasonUnderPaid             = '"+POut.String(claim.ReasonUnderPaid)+"', "
				+"ClaimNote                   = '"+POut.String(claim.ClaimNote)+"', "
				+"ClaimType                   = '"+POut.String(claim.ClaimType)+"', "
				+"ProvBill                    =  "+POut.Long  (claim.ProvBill)+", "
				+"ReferringProv               =  "+POut.Long  (claim.ReferringProv)+", "
				+"RefNumString                = '"+POut.String(claim.RefNumString)+"', "
				+"PlaceService                =  "+POut.Int   ((int)claim.PlaceService)+", "
				+"AccidentRelated             = '"+POut.String(claim.AccidentRelated)+"', "
				+"AccidentDate                =  "+POut.Date  (claim.AccidentDate)+", "
				+"AccidentST                  = '"+POut.String(claim.AccidentST)+"', "
				+"EmployRelated               =  "+POut.Int   ((int)claim.EmployRelated)+", "
				+"IsOrtho                     =  "+POut.Bool  (claim.IsOrtho)+", "
				+"OrthoRemainM                =  "+POut.Byte  (claim.OrthoRemainM)+", "
				+"OrthoDate                   =  "+POut.Date  (claim.OrthoDate)+", "
				+"PatRelat                    =  "+POut.Int   ((int)claim.PatRelat)+", "
				+"PlanNum2                    =  "+POut.Long  (claim.PlanNum2)+", "
				+"PatRelat2                   =  "+POut.Int   ((int)claim.PatRelat2)+", "
				+"WriteOff                    = '"+POut.Double(claim.WriteOff)+"', "
				+"Radiographs                 =  "+POut.Byte  (claim.Radiographs)+", "
				+"ClinicNum                   =  "+POut.Long  (claim.ClinicNum)+", "
				+"ClaimForm                   =  "+POut.Long  (claim.ClaimForm)+", "
				+"AttachedImages              =  "+POut.Int   (claim.AttachedImages)+", "
				+"AttachedModels              =  "+POut.Int   (claim.AttachedModels)+", "
				+"AttachedFlags               = '"+POut.String(claim.AttachedFlags)+"', "
				+"AttachmentID                = '"+POut.String(claim.AttachmentID)+"', "
				+"CanadianMaterialsForwarded  = '"+POut.String(claim.CanadianMaterialsForwarded)+"', "
				+"CanadianReferralProviderNum = '"+POut.String(claim.CanadianReferralProviderNum)+"', "
				+"CanadianReferralReason      =  "+POut.Byte  (claim.CanadianReferralReason)+", "
				+"CanadianIsInitialLower      = '"+POut.String(claim.CanadianIsInitialLower)+"', "
				+"CanadianDateInitialLower    =  "+POut.Date  (claim.CanadianDateInitialLower)+", "
				+"CanadianMandProsthMaterial  =  "+POut.Byte  (claim.CanadianMandProsthMaterial)+", "
				+"CanadianIsInitialUpper      = '"+POut.String(claim.CanadianIsInitialUpper)+"', "
				+"CanadianDateInitialUpper    =  "+POut.Date  (claim.CanadianDateInitialUpper)+", "
				+"CanadianMaxProsthMaterial   =  "+POut.Byte  (claim.CanadianMaxProsthMaterial)+", "
				+"InsSubNum                   =  "+POut.Long  (claim.InsSubNum)+", "
				+"InsSubNum2                  =  "+POut.Long  (claim.InsSubNum2)+", "
				+"CanadaTransRefNum           = '"+POut.String(claim.CanadaTransRefNum)+"', "
				+"CanadaEstTreatStartDate     =  "+POut.Date  (claim.CanadaEstTreatStartDate)+", "
				+"CanadaInitialPayment        = '"+POut.Double(claim.CanadaInitialPayment)+"', "
				+"CanadaPaymentMode           =  "+POut.Byte  (claim.CanadaPaymentMode)+", "
				+"CanadaTreatDuration         =  "+POut.Byte  (claim.CanadaTreatDuration)+", "
				+"CanadaNumAnticipatedPayments=  "+POut.Byte  (claim.CanadaNumAnticipatedPayments)+", "
				+"CanadaAnticipatedPayAmount  = '"+POut.Double(claim.CanadaAnticipatedPayAmount)+"', "
				+"PriorAuthorizationNumber    = '"+POut.String(claim.PriorAuthorizationNumber)+"', "
				+"SpecialProgramCode          =  "+POut.Int   ((int)claim.SpecialProgramCode)+", "
				+"UniformBillType             = '"+POut.String(claim.UniformBillType)+"', "
				+"MedType                     =  "+POut.Int   ((int)claim.MedType)+", "
				+"AdmissionTypeCode           = '"+POut.String(claim.AdmissionTypeCode)+"', "
				+"AdmissionSourceCode         = '"+POut.String(claim.AdmissionSourceCode)+"', "
				+"PatientStatusCode           = '"+POut.String(claim.PatientStatusCode)+"', "
				+"CustomTracking              =  "+POut.Long  (claim.CustomTracking)+", "
				+"DateResent                  =  "+POut.Date  (claim.DateResent)+", "
				+"CorrectionType              =  "+POut.Int   ((int)claim.CorrectionType)+", "
				+"ClaimIdentifier             = '"+POut.String(claim.ClaimIdentifier)+"', "
				+"OrigRefNum                  = '"+POut.String(claim.OrigRefNum)+"' "
				+"WHERE ClaimNum = "+POut.Long(claim.ClaimNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Claim in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Claim claim,Claim oldClaim){
			string command="";
			if(claim.PatNum != oldClaim.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(claim.PatNum)+"";
			}
			if(claim.DateService != oldClaim.DateService) {
				if(command!=""){ command+=",";}
				command+="DateService = "+POut.Date(claim.DateService)+"";
			}
			if(claim.DateSent != oldClaim.DateSent) {
				if(command!=""){ command+=",";}
				command+="DateSent = "+POut.Date(claim.DateSent)+"";
			}
			if(claim.ClaimStatus != oldClaim.ClaimStatus) {
				if(command!=""){ command+=",";}
				command+="ClaimStatus = '"+POut.String(claim.ClaimStatus)+"'";
			}
			if(claim.DateReceived != oldClaim.DateReceived) {
				if(command!=""){ command+=",";}
				command+="DateReceived = "+POut.Date(claim.DateReceived)+"";
			}
			if(claim.PlanNum != oldClaim.PlanNum) {
				if(command!=""){ command+=",";}
				command+="PlanNum = "+POut.Long(claim.PlanNum)+"";
			}
			if(claim.ProvTreat != oldClaim.ProvTreat) {
				if(command!=""){ command+=",";}
				command+="ProvTreat = "+POut.Long(claim.ProvTreat)+"";
			}
			if(claim.ClaimFee != oldClaim.ClaimFee) {
				if(command!=""){ command+=",";}
				command+="ClaimFee = '"+POut.Double(claim.ClaimFee)+"'";
			}
			if(claim.InsPayEst != oldClaim.InsPayEst) {
				if(command!=""){ command+=",";}
				command+="InsPayEst = '"+POut.Double(claim.InsPayEst)+"'";
			}
			if(claim.InsPayAmt != oldClaim.InsPayAmt) {
				if(command!=""){ command+=",";}
				command+="InsPayAmt = '"+POut.Double(claim.InsPayAmt)+"'";
			}
			if(claim.DedApplied != oldClaim.DedApplied) {
				if(command!=""){ command+=",";}
				command+="DedApplied = '"+POut.Double(claim.DedApplied)+"'";
			}
			if(claim.PreAuthString != oldClaim.PreAuthString) {
				if(command!=""){ command+=",";}
				command+="PreAuthString = '"+POut.String(claim.PreAuthString)+"'";
			}
			if(claim.IsProsthesis != oldClaim.IsProsthesis) {
				if(command!=""){ command+=",";}
				command+="IsProsthesis = '"+POut.String(claim.IsProsthesis)+"'";
			}
			if(claim.PriorDate != oldClaim.PriorDate) {
				if(command!=""){ command+=",";}
				command+="PriorDate = "+POut.Date(claim.PriorDate)+"";
			}
			if(claim.ReasonUnderPaid != oldClaim.ReasonUnderPaid) {
				if(command!=""){ command+=",";}
				command+="ReasonUnderPaid = '"+POut.String(claim.ReasonUnderPaid)+"'";
			}
			if(claim.ClaimNote != oldClaim.ClaimNote) {
				if(command!=""){ command+=",";}
				command+="ClaimNote = '"+POut.String(claim.ClaimNote)+"'";
			}
			if(claim.ClaimType != oldClaim.ClaimType) {
				if(command!=""){ command+=",";}
				command+="ClaimType = '"+POut.String(claim.ClaimType)+"'";
			}
			if(claim.ProvBill != oldClaim.ProvBill) {
				if(command!=""){ command+=",";}
				command+="ProvBill = "+POut.Long(claim.ProvBill)+"";
			}
			if(claim.ReferringProv != oldClaim.ReferringProv) {
				if(command!=""){ command+=",";}
				command+="ReferringProv = "+POut.Long(claim.ReferringProv)+"";
			}
			if(claim.RefNumString != oldClaim.RefNumString) {
				if(command!=""){ command+=",";}
				command+="RefNumString = '"+POut.String(claim.RefNumString)+"'";
			}
			if(claim.PlaceService != oldClaim.PlaceService) {
				if(command!=""){ command+=",";}
				command+="PlaceService = "+POut.Int   ((int)claim.PlaceService)+"";
			}
			if(claim.AccidentRelated != oldClaim.AccidentRelated) {
				if(command!=""){ command+=",";}
				command+="AccidentRelated = '"+POut.String(claim.AccidentRelated)+"'";
			}
			if(claim.AccidentDate != oldClaim.AccidentDate) {
				if(command!=""){ command+=",";}
				command+="AccidentDate = "+POut.Date(claim.AccidentDate)+"";
			}
			if(claim.AccidentST != oldClaim.AccidentST) {
				if(command!=""){ command+=",";}
				command+="AccidentST = '"+POut.String(claim.AccidentST)+"'";
			}
			if(claim.EmployRelated != oldClaim.EmployRelated) {
				if(command!=""){ command+=",";}
				command+="EmployRelated = "+POut.Int   ((int)claim.EmployRelated)+"";
			}
			if(claim.IsOrtho != oldClaim.IsOrtho) {
				if(command!=""){ command+=",";}
				command+="IsOrtho = "+POut.Bool(claim.IsOrtho)+"";
			}
			if(claim.OrthoRemainM != oldClaim.OrthoRemainM) {
				if(command!=""){ command+=",";}
				command+="OrthoRemainM = "+POut.Byte(claim.OrthoRemainM)+"";
			}
			if(claim.OrthoDate != oldClaim.OrthoDate) {
				if(command!=""){ command+=",";}
				command+="OrthoDate = "+POut.Date(claim.OrthoDate)+"";
			}
			if(claim.PatRelat != oldClaim.PatRelat) {
				if(command!=""){ command+=",";}
				command+="PatRelat = "+POut.Int   ((int)claim.PatRelat)+"";
			}
			if(claim.PlanNum2 != oldClaim.PlanNum2) {
				if(command!=""){ command+=",";}
				command+="PlanNum2 = "+POut.Long(claim.PlanNum2)+"";
			}
			if(claim.PatRelat2 != oldClaim.PatRelat2) {
				if(command!=""){ command+=",";}
				command+="PatRelat2 = "+POut.Int   ((int)claim.PatRelat2)+"";
			}
			if(claim.WriteOff != oldClaim.WriteOff) {
				if(command!=""){ command+=",";}
				command+="WriteOff = '"+POut.Double(claim.WriteOff)+"'";
			}
			if(claim.Radiographs != oldClaim.Radiographs) {
				if(command!=""){ command+=",";}
				command+="Radiographs = "+POut.Byte(claim.Radiographs)+"";
			}
			if(claim.ClinicNum != oldClaim.ClinicNum) {
				if(command!=""){ command+=",";}
				command+="ClinicNum = "+POut.Long(claim.ClinicNum)+"";
			}
			if(claim.ClaimForm != oldClaim.ClaimForm) {
				if(command!=""){ command+=",";}
				command+="ClaimForm = "+POut.Long(claim.ClaimForm)+"";
			}
			if(claim.AttachedImages != oldClaim.AttachedImages) {
				if(command!=""){ command+=",";}
				command+="AttachedImages = "+POut.Int(claim.AttachedImages)+"";
			}
			if(claim.AttachedModels != oldClaim.AttachedModels) {
				if(command!=""){ command+=",";}
				command+="AttachedModels = "+POut.Int(claim.AttachedModels)+"";
			}
			if(claim.AttachedFlags != oldClaim.AttachedFlags) {
				if(command!=""){ command+=",";}
				command+="AttachedFlags = '"+POut.String(claim.AttachedFlags)+"'";
			}
			if(claim.AttachmentID != oldClaim.AttachmentID) {
				if(command!=""){ command+=",";}
				command+="AttachmentID = '"+POut.String(claim.AttachmentID)+"'";
			}
			if(claim.CanadianMaterialsForwarded != oldClaim.CanadianMaterialsForwarded) {
				if(command!=""){ command+=",";}
				command+="CanadianMaterialsForwarded = '"+POut.String(claim.CanadianMaterialsForwarded)+"'";
			}
			if(claim.CanadianReferralProviderNum != oldClaim.CanadianReferralProviderNum) {
				if(command!=""){ command+=",";}
				command+="CanadianReferralProviderNum = '"+POut.String(claim.CanadianReferralProviderNum)+"'";
			}
			if(claim.CanadianReferralReason != oldClaim.CanadianReferralReason) {
				if(command!=""){ command+=",";}
				command+="CanadianReferralReason = "+POut.Byte(claim.CanadianReferralReason)+"";
			}
			if(claim.CanadianIsInitialLower != oldClaim.CanadianIsInitialLower) {
				if(command!=""){ command+=",";}
				command+="CanadianIsInitialLower = '"+POut.String(claim.CanadianIsInitialLower)+"'";
			}
			if(claim.CanadianDateInitialLower != oldClaim.CanadianDateInitialLower) {
				if(command!=""){ command+=",";}
				command+="CanadianDateInitialLower = "+POut.Date(claim.CanadianDateInitialLower)+"";
			}
			if(claim.CanadianMandProsthMaterial != oldClaim.CanadianMandProsthMaterial) {
				if(command!=""){ command+=",";}
				command+="CanadianMandProsthMaterial = "+POut.Byte(claim.CanadianMandProsthMaterial)+"";
			}
			if(claim.CanadianIsInitialUpper != oldClaim.CanadianIsInitialUpper) {
				if(command!=""){ command+=",";}
				command+="CanadianIsInitialUpper = '"+POut.String(claim.CanadianIsInitialUpper)+"'";
			}
			if(claim.CanadianDateInitialUpper != oldClaim.CanadianDateInitialUpper) {
				if(command!=""){ command+=",";}
				command+="CanadianDateInitialUpper = "+POut.Date(claim.CanadianDateInitialUpper)+"";
			}
			if(claim.CanadianMaxProsthMaterial != oldClaim.CanadianMaxProsthMaterial) {
				if(command!=""){ command+=",";}
				command+="CanadianMaxProsthMaterial = "+POut.Byte(claim.CanadianMaxProsthMaterial)+"";
			}
			if(claim.InsSubNum != oldClaim.InsSubNum) {
				if(command!=""){ command+=",";}
				command+="InsSubNum = "+POut.Long(claim.InsSubNum)+"";
			}
			if(claim.InsSubNum2 != oldClaim.InsSubNum2) {
				if(command!=""){ command+=",";}
				command+="InsSubNum2 = "+POut.Long(claim.InsSubNum2)+"";
			}
			if(claim.CanadaTransRefNum != oldClaim.CanadaTransRefNum) {
				if(command!=""){ command+=",";}
				command+="CanadaTransRefNum = '"+POut.String(claim.CanadaTransRefNum)+"'";
			}
			if(claim.CanadaEstTreatStartDate != oldClaim.CanadaEstTreatStartDate) {
				if(command!=""){ command+=",";}
				command+="CanadaEstTreatStartDate = "+POut.Date(claim.CanadaEstTreatStartDate)+"";
			}
			if(claim.CanadaInitialPayment != oldClaim.CanadaInitialPayment) {
				if(command!=""){ command+=",";}
				command+="CanadaInitialPayment = '"+POut.Double(claim.CanadaInitialPayment)+"'";
			}
			if(claim.CanadaPaymentMode != oldClaim.CanadaPaymentMode) {
				if(command!=""){ command+=",";}
				command+="CanadaPaymentMode = "+POut.Byte(claim.CanadaPaymentMode)+"";
			}
			if(claim.CanadaTreatDuration != oldClaim.CanadaTreatDuration) {
				if(command!=""){ command+=",";}
				command+="CanadaTreatDuration = "+POut.Byte(claim.CanadaTreatDuration)+"";
			}
			if(claim.CanadaNumAnticipatedPayments != oldClaim.CanadaNumAnticipatedPayments) {
				if(command!=""){ command+=",";}
				command+="CanadaNumAnticipatedPayments = "+POut.Byte(claim.CanadaNumAnticipatedPayments)+"";
			}
			if(claim.CanadaAnticipatedPayAmount != oldClaim.CanadaAnticipatedPayAmount) {
				if(command!=""){ command+=",";}
				command+="CanadaAnticipatedPayAmount = '"+POut.Double(claim.CanadaAnticipatedPayAmount)+"'";
			}
			if(claim.PriorAuthorizationNumber != oldClaim.PriorAuthorizationNumber) {
				if(command!=""){ command+=",";}
				command+="PriorAuthorizationNumber = '"+POut.String(claim.PriorAuthorizationNumber)+"'";
			}
			if(claim.SpecialProgramCode != oldClaim.SpecialProgramCode) {
				if(command!=""){ command+=",";}
				command+="SpecialProgramCode = "+POut.Int   ((int)claim.SpecialProgramCode)+"";
			}
			if(claim.UniformBillType != oldClaim.UniformBillType) {
				if(command!=""){ command+=",";}
				command+="UniformBillType = '"+POut.String(claim.UniformBillType)+"'";
			}
			if(claim.MedType != oldClaim.MedType) {
				if(command!=""){ command+=",";}
				command+="MedType = "+POut.Int   ((int)claim.MedType)+"";
			}
			if(claim.AdmissionTypeCode != oldClaim.AdmissionTypeCode) {
				if(command!=""){ command+=",";}
				command+="AdmissionTypeCode = '"+POut.String(claim.AdmissionTypeCode)+"'";
			}
			if(claim.AdmissionSourceCode != oldClaim.AdmissionSourceCode) {
				if(command!=""){ command+=",";}
				command+="AdmissionSourceCode = '"+POut.String(claim.AdmissionSourceCode)+"'";
			}
			if(claim.PatientStatusCode != oldClaim.PatientStatusCode) {
				if(command!=""){ command+=",";}
				command+="PatientStatusCode = '"+POut.String(claim.PatientStatusCode)+"'";
			}
			if(claim.CustomTracking != oldClaim.CustomTracking) {
				if(command!=""){ command+=",";}
				command+="CustomTracking = "+POut.Long(claim.CustomTracking)+"";
			}
			if(claim.DateResent != oldClaim.DateResent) {
				if(command!=""){ command+=",";}
				command+="DateResent = "+POut.Date(claim.DateResent)+"";
			}
			if(claim.CorrectionType != oldClaim.CorrectionType) {
				if(command!=""){ command+=",";}
				command+="CorrectionType = "+POut.Int   ((int)claim.CorrectionType)+"";
			}
			if(claim.ClaimIdentifier != oldClaim.ClaimIdentifier) {
				if(command!=""){ command+=",";}
				command+="ClaimIdentifier = '"+POut.String(claim.ClaimIdentifier)+"'";
			}
			if(claim.OrigRefNum != oldClaim.OrigRefNum) {
				if(command!=""){ command+=",";}
				command+="OrigRefNum = '"+POut.String(claim.OrigRefNum)+"'";
			}
			if(command==""){
				return false;
			}
			command="UPDATE claim SET "+command
				+" WHERE ClaimNum = "+POut.Long(claim.ClaimNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Deletes one Claim from the database.</summary>
		public static void Delete(long claimNum){
			string command="DELETE FROM claim "
				+"WHERE ClaimNum = "+POut.Long(claimNum);
			Db.NonQ(command);
		}

	}
}