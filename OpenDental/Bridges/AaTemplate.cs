using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental.Bridges{
	///<summary>This class is just an example template that we use when we build a new bridge.  Start with a copy of this.</summary>
	public class AaTemplate {

		///<summary></summary>
		public AaTemplate(){
			
		}

		///<summary></summary>
		public static void SendData(Program ProgramCur,Patient pat) {
			string path=Programs.GetProgramPath(ProgramCur);
			if(pat==null) {
				//There are two options here, depending on the bridge
				//1. Launch program without any patient.
				try {
					Process.Start(path);//should start AaTemplate without bringing up a pt.
				}
				catch {
					MessageBox.Show(path+" is not available.");
				}
				//2. Tell user to pick a patient first.
				MsgBox.Show("AaTemplate","Please select a patient first.");
				//return in both cases
				return;
			}
			//It's common to build a string
			string str="";
			//ProgramProperties.GetPropVal() is the way to get program properties.
			if(ProgramProperties.GetPropVal(ProgramCur.ProgramNum,"Enter 0 to use PatientNum, or 1 to use ChartNum")=="0"){
				str+="Id="+pat.PatNum.ToString()+" ";
			}
			else{
				str+="Id="+Tidy(pat.ChartNumber)+" ";
			}
			//Nearly always tidy the names in one way or another
			str+=Tidy(pat.LName)+" ";
			//If birthdates are optional, only send them if they are valid.
			if(pat.Birthdate.Year>1880) {
				str+=pat.Birthdate.ToString("MM/dd/yyyy");
			}
			//This patterns shows a way to handle gender unknown when gender is optional.
			if(pat.Gender==PatientGender.Female) {
				str+="F ";
			}
			else if(pat.Gender==PatientGender.Male) {
				str+="M ";
			}
			try {
				Process.Start(path,str);
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		///<summary>Removes semicolons and spaces.</summary>
		private static string Tidy(string input) {
			string retVal=input.Replace(";","");//get rid of any semicolons.
			retVal=retVal.Replace(" ","");
			return retVal;
		}

	}
}







