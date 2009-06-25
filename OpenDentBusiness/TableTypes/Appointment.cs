using System;
using System.Collections;

namespace OpenDentBusiness{
	
	///<summary>Appointments can show in the Appointments module, or they can be on the unscheduled list.  An appointment object is also used to store the Planned appointment.  The planned appointment never gets scheduled, but instead gets copied.</summary>
	public class Appointment{
		///<summary>Primary key.</summary>
		public int AptNum;
		///<summary>FK to patient.PatNum.  The patient that the appointment is for.</summary>
		public int PatNum;
		///<summary>Enum:ApptStatus .</summary>
		public ApptStatus AptStatus;
		///<summary>Time pattern, X for Dr time, / for assist time. Stored in 5 minute increments.  Converted as needed to 10 or 15 minute representations for display.</summary>
		public string Pattern;
		///<summary>FK to definition.DefNum.  This field can also be used to show patient arrived, in chair, etc.  The Category column in the definition table is DefCat.ApptConfirmed.</summary>
		public int Confirmed;
		///<summary>If true, then the program will not attempt to reset the user's time pattern and length when adding or removing procedures.</summary>
		public bool TimeLocked;
		///<summary>FK to operatory.OperatoryNum.</summary>
		public int Op;
		///<summary>Note.</summary>
		public string Note;
		///<summary>FK to provider.ProvNum.</summary>
		public int ProvNum;
		///<summary>FK to provider.ProvNum.  Optional.  Only used if a hygienist is assigned to this appt.</summary>
		public int ProvHyg;
		///<summary>Appointment Date and time.  If you need just the date or time for an SQL query, you can use DATE(AptDateTime) and TIME(AptDateTime) in your query.</summary>
		public DateTime AptDateTime;
		///<summary>FK to appointment.AptNum.  A better description of this field would be PlannedAptNum.  Only used to show that this apt is derived from specified planned apt. Otherwise, 0.</summary>
		public int NextAptNum;
		///<summary>FK to definition.DefNum.  The definition.Category in the definition table is DefCat.RecallUnschedStatus.  Only used if this is an Unsched or Planned appt.</summary>
		public int UnschedStatus;
		///<summary>Do not use.  See the labcase table instead.</summary>
		public int LabOld;
		///<summary>This is the first appoinment this patient has had at this office.  Somewhat automated.</summary>
		public bool IsNewPatient;
		///<summary>A one line summary of all procedures.  Can be used in various reports, Unscheduled list, and Planned appointment tracker.  Not user editable right now, so it doesn't show on the screen.</summary>
		public string ProcDescript;
		///<summary>FK to employee.EmployeeNum.  You can assign an assistant to the appointment.</summary>
		public int Assistant;
		///<summary>Not used.</summary>
		public int InstructorNum;
		///<summary>Not used</summary>
		public int SchoolClassNum;
		///<summary>Not used.</summary>
		public int SchoolCourseNum;
		///<summary>Not used.</summary>
		public float GradePoint;
		///<summary>FK to clinic.ClinicNum.  0 if no clinic.</summary>
		public int ClinicNum;
		///<summary>Set true if this is a hygiene appt.  The hygiene provider's color will show.</summary>
		public bool IsHygiene;
		//DateTStamp
		///<summary>The date and time that the patient checked in.  Date is largely ignored since it should be the same as the appt.</summary>
		public DateTime DateTimeArrived;
		///<summary>The date and time that the patient was seated in the chair in the operatory.</summary>
		public DateTime DateTimeSeated;
		///<summary>The date and time that the patient got up out of the chair</summary>
		public DateTime DateTimeDismissed;
		///<summary>FK to insplan.PlanNum for the primary insurance plan at the time the appointment is set complete. May be 0.</summary>
		public int InsPlan1;
		///<summary>FK to insplan.PlanNum for the secoondary insurance plan at the time the appointment is set complete. May be 0.</summary>
		public int InsPlan2;

		///<summary>Returns a copy of the appointment.</summary>
    public Appointment Copy(){
			return (Appointment)this.MemberwiseClone();
		}

		
	}
	
	


}









