using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness.Mobile{
	///<summary></summary>
	public class MedicationPatms{
		
		/*
		Only pull out the methods below as you need them.  Otherwise, leave them commented out.

		///<summary></summary>
		public static List<MedicationPatm> Refresh(long patNum){
			string command="SELECT * FROM medicationpatm WHERE PatNum = "+POut.Long(patNum);
			return Crud.MedicationPatmCrud.SelectMany(command);
		}

		///<summary>Gets one MedicationPatm from the db.</summary>
		public static MedicationPatm GetOne(long customerNum,long medicationPatNum){
			return Crud.MedicationPatmCrud.SelectOne(customerNum,medicationPatNum);
		}

		///<summary></summary>
		public static long Insert(MedicationPatm medicationPatm){
			return Crud.MedicationPatmCrud.Insert(medicationPatm,true);
		}

		///<summary></summary>
		public static void Update(MedicationPatm medicationPatm){
			Crud.MedicationPatmCrud.Update(medicationPatm);
		}

		///<summary></summary>
		public static void Delete(long customerNum,long medicationPatNum) {
			string command= "DELETE FROM medicationpatm WHERE CustomerNum = "+POut.Long(customerNum)+" AND MedicationPatNum = "+POut.Long(medicationPatNum);
			Db.NonQ(command);
		}

		///<summary>First use GetChangedSince.  Then, use this to convert the list a list of 'm' objects.</summary>
		public static List<MedicationPatm> ConvertListToM(List<MedicationPat> list) {
			List<MedicationPatm> retVal=new List<MedicationPatm>();
			for(int i=0;i<list.Count;i++){
				retVal.Add(Crud.MedicationPatmCrud.ConvertToM(list[i]));
			}
			return retVal;
		}

		///<summary>Only run on server for mobile.  Takes the list of changes from the dental office and makes updates to those items in the mobile server db.  Also, make sure to run DeletedObjects.DeleteForMobile().</summary>
		public static void UpdateFromChangeList(List<MedicationPatm> list,long customerNum) {
			for(int i=0;i<list.Count;i++){
				list[i].CustomerNum=customerNum;
				MedicationPatm medicationPatm=Crud.MedicationPatmCrud.SelectOne(customerNum,list[i].MedicationPatNum);
				if(medicationPatm==null){//not in db
					Crud.MedicationPatmCrud.Insert(list[i],true);
				}
				else{
					Crud.MedicationPatmCrud.Update(list[i]);
				}
			}
		}
		*/



	}
}