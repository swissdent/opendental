using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.DataAccess;

namespace OpenDental{
	///<summary></summary>
	public class Supplies {

		///<summary>Gets all Supplies, ordered by category and itemOrder.  Optionally hides those marked IsHidden.  FindText must only include alphanumeric characters.</summary>
		public static List<Supply> CreateObjects(bool includeHidden,int supplierNum,string findText) {
			string command="SELECT supply.* FROM supply,definition "
				+"WHERE definition.DefNum=supply.Category "
				+"AND supply.SupplierNum="+POut.PInt(supplierNum)+" ";
			if(findText!=""){
				command+="AND (supply.CatalogNumber REGEXP '"+POut.PString(findText)+"' OR supply.Descript REGEXP '"+POut.PString(findText)+"') ";
			}
			if(!includeHidden){
				command+="AND supply.IsHidden=0 ";
			}
			command+="ORDER BY definition.ItemOrder,supply.ItemOrder";
			return new List<Supply>(DataObjectFactory<Supply>.CreateObjects(command));
		}

		///<summary></summary>
		public static void WriteObject(Supply supp){
			DataObjectFactory<Supply>.WriteObject(supp);
		}

		///<summary>Surround with try-catch.</summary>
		public static void DeleteObject(Supply supp){
			//validate that not already in use.

			DataObjectFactory<Supply>.DeleteObject(supp);
		}

		///<Summary>Loops through the supplied list and verifies that the ItemOrders are not corrupted.  If they are, then it fixes them.  Returns true if fix was required.  It makes a few assumptions about the quality of the list supplied.  Specifically, that there are no missing items, and that categories are grouped and sorted.</Summary>
		public static bool CleanupItemOrders(List<Supply> listSupply){
			int catCur=-1;
			int previousOrder=-1;
			bool retVal=false;
			for(int i=0;i<listSupply.Count;i++){
				if(listSupply[i].Category!=catCur){//start of new category
					catCur=listSupply[i].Category;
					previousOrder=-1;
				}
				if(listSupply[i].ItemOrder!=previousOrder+1){
					listSupply[i].ItemOrder=previousOrder+1;
					WriteObject(listSupply[i]);
					retVal=true;
				}
				previousOrder++;
			}
			return retVal;
		}

		

		
		


	}

	


	


}









