using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
  ///<summary></summary>
	public class Counties{
		///<summary>This list is only refreshed as needed rather than being part of the local data.</summary>
		public static County[] List;
		///<summary>Used in screening window. Simpler interface.</summary>
		public static string[] ListNames;

		///<summary></summary>
		public static void Refresh(string name){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),name);
				return;
			}
			string command=
				"SELECT * from county "
				+"WHERE CountyName LIKE '"+name+"%' "
				+"ORDER BY CountyName";
			DataTable table=Db.GetTable(command);
			List=new County[table.Rows.Count];
			for(int i=0;i<List.Length;i++){
				List[i]=new County();
				List[i].CountyName    =PIn.PString(table.Rows[i][0].ToString());
				List[i].CountyCode    =PIn.PString(table.Rows[i][1].ToString());
				List[i].OldCountyName =PIn.PString(table.Rows[i][0].ToString());
			}
		}

		///<summary></summary>
		public static void Refresh(){
			//No need to check RemotingRole; no call to db.
			Refresh("");
		}

		///<summary>Gets an array of strings containing all the counties in alphabetical order.  Used for the screening interface which must be simpler than the usual interface.</summary>
		public static void GetListNames(){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod());
				return;
			}
			string command =
				"SELECT CountyName from county "
				+"ORDER BY CountyName";
			DataTable table=Db.GetTable(command);
			ListNames=new string[table.Rows.Count];
			for(int i=0;i<ListNames.Length;i++){
				ListNames[i]=PIn.PString(table.Rows[i][0].ToString());
			}
		}

		///<summary>Need to make sure Countyname not already in db.</summary>
		public static void Insert(County Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),Cur);
				return;
			}
			string command= "INSERT INTO county (CountyName,CountyCode) "
				+"VALUES ("
				+"'"+POut.PString(Cur.CountyName)+"', "
				+"'"+POut.PString(Cur.CountyCode)+"')";
			//MessageBox.Show(string command);
			Db.NonQ(command);
			//Cur.ZipCodeNum=InsertID;
		}

		///<summary>Updates the Countyname and code in the County table, and also updates all patients that were using the oldCounty name.</summary>
		public static void Update(County Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),Cur);
				return;
			}
			string command = "UPDATE county SET "
				+"CountyName ='"  +POut.PString(Cur.CountyName)+"'"
				+",CountyCode ='" +POut.PString(Cur.CountyCode)+"'"
				+" WHERE CountyName = '"+POut.PString(Cur.OldCountyName)+"'";
			Db.NonQ(command);
			//then, update all patients using that County
			command = "UPDATE patient SET "
				+"County ='"  +POut.PString(Cur.CountyName)+"'"
				+" WHERE County = '"+POut.PString(Cur.OldCountyName)+"'";
			Db.NonQ(command);
		}

		///<summary>Must run UsedBy before running this.</summary>
		public static void Delete(County Cur){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),Cur);
				return;
			}
			string command= "DELETE from county WHERE CountyName = '"+POut.PString(Cur.CountyName)+"'";
			Db.NonQ(command);
		}

		///<summary>Use before DeleteCur to determine if this County name is in use. Returns a formatted string that can be used to quickly display the names of all patients using the Countyname.</summary>
		public static string UsedBy(string countyName){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetString(MethodBase.GetCurrentMethod(),countyName);
			}
			string command=
				"SELECT LName,FName from patient "
				+"WHERE County = '"+POut.PString(countyName)+"' ";
			DataTable table=Db.GetTable(command);
			if(table.Rows.Count==0)
				return "";
			string retVal="";
			for(int i=0;i<table.Rows.Count;i++){
				retVal+=PIn.PString(table.Rows[i][0].ToString())+", "
					+PIn.PString(table.Rows[i][1].ToString());
				if(i<table.Rows.Count-1){//if not the last row
					retVal+="\r";
				}
			}
			return retVal;
		}

		///<summary>Use before InsertCur to determine if this County name already exists. Also used when closing patient edit window to validate that the Countyname exists.</summary>
		public static bool DoesExist(string countyName){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetBool(MethodBase.GetCurrentMethod(),countyName);
			}
			string command =
				"SELECT * from county "
				+"WHERE CountyName = '"+POut.PString(countyName)+"' ";
			DataTable table=Db.GetTable(command);
			if(table.Rows.Count==0)
				return false;
			else
				return true;
		}

	}

	

}













