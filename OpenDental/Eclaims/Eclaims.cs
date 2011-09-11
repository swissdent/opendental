using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental.Eclaims
{
	/// <summary>
	/// Summary description for Eclaims.
	/// </summary>
	public class Eclaims{
		/// <summary></summary>
		public Eclaims()
		{
			
		}

		///<summary>Supply a list of ClaimSendQueueItems. Called from FormClaimSend.  Used to be able to send to multiple clearinghouses simultaneously.  Can also just send one claim.  Cannot include Canadian.</summary>
		public static void SendBatches(List<ClaimSendQueueItem> queueItems,Clearinghouse clearhouse,EnumClaimMedType medType){
			//List<ClaimSendQueueItem>[] claimsByCHouse=new List<ClaimSendQueueItem>[Clearinghouses.Listt.Length];
			//for(int i=0;i<claimsByCHouse.Length;i++){
			//	claimsByCHouse[i]=new List<ClaimSendQueueItem>();
			//}
			//divide the items by clearinghouse:
			//for(int i=0;i<queueItems.Count;i++){
			//	claimsByCHouse[ClearinghouseL.GetIndex(queueItems[i].ClearinghouseNum)].Add(queueItems[i]);
			//}
			//for any clearinghouses with claims, send them:
			//batchNum;
			string messageText="";
			//for(int i=0;i<claimsByCHouse.Length;i++){
			//if(claimsByCHouse[i].Count==0){
			//	continue;
			//}
			if(clearhouse.Eformat==ElectronicClaimFormat.Canadian){
				MsgBox.Show("Eclaims","Cannot send Canadian claims as part of SendBatches.");
				return;
			}
			//get next batch number for this clearinghouse
			int batchNum=Clearinghouses.GetNextBatchNumber(clearhouse);
			//---------------------------------------------------------------------------------------
			//Create the claim file(s) for this clearinghouse
			if(clearhouse.Eformat==ElectronicClaimFormat.x837D_4010
				|| clearhouse.Eformat==ElectronicClaimFormat.x837D_5010_dental
				|| clearhouse.Eformat==ElectronicClaimFormat.x837I_5010_institut
				|| clearhouse.Eformat==ElectronicClaimFormat.x837P_5010_medical) 
			{
				messageText=x837Controller.SendBatch(queueItems,batchNum,clearhouse,medType);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Renaissance){
				messageText=Renaissance.SendBatch(queueItems,batchNum);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Dutch) {
				messageText=Dutch.SendBatch(queueItems,batchNum);
			}
			else{
				messageText="";//(ElectronicClaimFormat.None does not get sent)
			}
			if(messageText==""){//if failed to create claim file properly,
				return;//don't launch program or change claim status
			}
			//----------------------------------------------------------------------------------------
			//Launch Client Program for this clearinghouse if applicable
			if(clearhouse.CommBridge==EclaimsCommBridge.None){
				AttemptLaunch(clearhouse,batchNum);
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.WebMD){
				if(!WebMD.Launch(clearhouse,batchNum)){
					MessageBox.Show(Lan.g("Eclaims","Error sending."));
					return;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.BCBSGA){
				if(!BCBSGA.Launch(clearhouse,batchNum)){
					MessageBox.Show(Lan.g("Eclaims","Error sending."));
					return;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.Renaissance){
				AttemptLaunch(clearhouse,batchNum);
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.ClaimConnect){
				if(!ClaimConnect.Launch(clearhouse,batchNum)){
					MessageBox.Show(Lan.g("Eclaims","Error sending."));
					return;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.RECS){
				if(!RECS.Launch(clearhouse,batchNum)){
					MessageBox.Show("Claim file created, but could not launch RECS client.");
					//continue;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.Inmediata){
				if(!Inmediata.Launch(clearhouse,batchNum)){
					MessageBox.Show("Claim file created, but could not launch Inmediata client.");
					//continue;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.AOS){ // added by SPK 7/13/05
				if(!AOS.Launch(clearhouse,batchNum)){
					MessageBox.Show("Claim file created, but could not launch AOS Communicator.");
					//continue;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.PostnTrack){
				AttemptLaunch(clearhouse,batchNum);
				//if(!PostnTrack.Launch(Clearinghouses.List[i],batchNum)){
				//	MessageBox.Show("Claim file created, but could not launch AOS Communicator.");
					//continue;
				//}
			}
			/*else if(Clearinghouses.List[i].CommBridge==EclaimsCommBridge.Tesia) {
				if(!Tesia.Launch(Clearinghouses.List[i],batchNum)) {
					MessageBox.Show(Lan.g("Eclaims","Error sending."));
					continue;
				}
			}*/
			else if(clearhouse.CommBridge==EclaimsCommBridge.MercuryDE){
				if(!MercuryDE.Launch(clearhouse,batchNum)){
					MsgBox.Show("Eclaims","Error sending.");
					return;
				}
			}
			else if(clearhouse.CommBridge==EclaimsCommBridge.ClaimX) {
				if(!ClaimX.Launch(clearhouse,batchNum)) {
					MessageBox.Show("Claim file created, but encountered an error while launching ClaimX Client.");
					//continue;
				}
			}
			//----------------------------------------------------------------------------------------
			//finally, mark the claims sent. (only if not Canadian)
			EtransType etype=EtransType.ClaimSent;
			if(clearhouse.Eformat==ElectronicClaimFormat.Renaissance){
				etype=EtransType.Claim_Ren;
			}
			if(clearhouse.Eformat!=ElectronicClaimFormat.Canadian){
				for(int j=0;j<queueItems.Count;j++){
					Etrans etrans=Etranss.SetClaimSentOrPrinted(queueItems[j].ClaimNum,queueItems[j].PatNum,clearhouse.ClearinghouseNum,etype,batchNum);
					Etranss.SetMessage(etrans.EtransNum,messageText);
				}
			}
			//}//for(int i=0;i<claimsByCHouse.Length;i++){
		}

		///<summary>If no comm bridge is selected for a clearinghouse, this launches any client program the user has entered.  We do not want to cause a rollback, so no return value.</summary>
		private static void AttemptLaunch(Clearinghouse clearhouse,int batchNum){
			if(clearhouse.ClientProgram==""){
				return;
			}
			if(!File.Exists(clearhouse.ClientProgram)){
				MessageBox.Show(clearhouse.ClientProgram+" "+Lan.g("Eclaims","does not exist."));
				return;
			}
			try{
				Process.Start(clearhouse.ClientProgram);
			}
			catch{
				MessageBox.Show(Lan.g("Eclaims","Client program could not be started.  It may already be running. You must open your client program to finish sending claims."));
			}
		}

		///<summary>Returns a string describing all missing data on this claim.  Claim will not be allowed to be sent electronically unless this string comes back empty.</summary>
		public static string GetMissingData(ClaimSendQueueItem queueItem, out string warnings){
			warnings="";
			Clearinghouse clearhouse=ClearinghouseL.GetClearinghouse(queueItem.ClearinghouseNum);
			if(clearhouse==null){
				return "";
			}
			if(clearhouse.Eformat==ElectronicClaimFormat.x837D_4010){
				string retVal=X837_4010.Validate(queueItem,out warnings);
				return retVal;
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Renaissance){
				return Renaissance.GetMissingData(queueItem);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Canadian) {
				return Canadian.GetMissingData(queueItem);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Dutch) {
				return Dutch.GetMissingData(queueItem,out warnings);
			}
			return "";
		}

	


	}
}



























