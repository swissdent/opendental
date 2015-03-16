﻿using System;

namespace OpenDentBusiness {
	///<summary>The EHRLab table is structured to tightly with the HL7 standard and should have names that more reflect how the user will
	///consume the data and for that reason for actual implementation we are using these medlab tables.
	///Medical lab observation order.  This table is currently only used for LabCorp, but may be utilized by other third party lab
	///services in the future.  These are the fields required for the LabCorp result report, used to link the order to the result(s),
	///specimen(s), place(s) of service, or for linking parent and child results.
	///This table contains data from the PID, ORC, OBR, and applicable NTE segments
	///
	/// </summary>
	[Serializable]
	public class MedLab:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long MedLabNum;
		#region MSH Fields
		///<summary>MSH-2 - Sending Application.  Used to identify the LabCorp Lab System sending the results.
		///Possible values for LabCorp (as of their v10.7 specs): '1100' - LabCorp Lab System, 'DIANON' - DIANON Systems,
		///'ADL' - Acupath Diagnostic Laboratories, 'EGL' - Esoterix Genetic Laboratories.
		///For backward compatibility only: 'CMBP', 'LITHOLINK', 'USLABS'</summary>
		public string SendingApp;
		///<summary>MSH-3 - Sending Facility.  Identifies the LabCorp laboratory responsible for the client.
		///It could be a LabCorp assigned 'Responsible Lab Code' representing the responsible laboratory or it could be a CLIA number.</summary>
		public string SendingFacility;
		#endregion MSH Fields
		#region PID Fields
		///<summary>FK to patient.PatNum.  PID.2 - External Patient ID. LabCorp report field "Client Alt. Pat ID".</summary>
		public long PatNum;
		///<summary>FK to provider.ProvNum.  Can be 0. Attempt to match ordering prov external IDs to internal provnum.</summary>
		public long ProvNum;
		///<summary>PID.3 - Lab Assigned Patient Id.  LabCorp report field "Specimen Number".  LabCorp assigned, alpha numeric specimen number.</summary>
		public string PatIDLab;
		///<summary>PID.4 - Alternate Patient ID.  LabCorp report field "Patient ID".  Alternate patient ID.</summary>
		public string PatIDAlt;
		///<summary>PID.7.2/7.3/7.4 - Patient Age Years/Months/Days.  LabCorp report field "Age (Y/M/D)".  YYY/MM/DD format.  Three chars for years,
		///2 each for months and days.  Some tests require age for calculation of result.  This will be the age at the time of the test, so we will use
		///the values in the message instead of re-calculating..</summary>
		public string PatAge;
		///<summary>PID.18.1 - Account Number.  LabCorp report field "Account Number".  LabCorp Client ID, 8 digit account number.</summary>
		public string PatAccountNum;
		///<summary>PID.18.7 - Fasting.  LabCorp report field "Fasting".  Y, N, or blank.
		///A blank component will be stored as 0 - Unknown, the result report fasting field will be blank.</summary>
		public YN PatFasting;
		#endregion PID Fields
		#region OBR Fields
		///<summary>ORC.2.1 and OBR.2.1 - Unique Foreign Accession or Specimen ID.  LabCorp report field "Client Accession (ACC)".
		///ID sent on the specimen container.</summary>
		public string SpecimenID;
		///<summary>OBR.4.1 - Observation Battery Identifier.  Reflex result will have this value in OBR.29 to link the reflex to the parent.</summary>
		public string ObsTestID;
		///<summary>OBR.4.2 - Observation Battery Text.  LabCorp report field "Tests Ordered".</summary>
		public string ObsTestDescript;
		///<summary>OBR.4.4 - Alternate Battery Identifier (LOINC).  This is the LOINC code for the test performed.
		///When displaying the results, LabCorp requires OBR.4.2, the text name of the test to be displayed, not the LOINC code.
		///But we will store it so we can link to the LOINC code table for reporting purposes.</summary>
		public string ObsTestLoinc;
		///<summary>OBR.4.5 - Alternate Observation Battery Text (LOINC Description).  The LOINC code description for the test performed.
		///We will display OBR.4.2 per LabCorp requirements, but we will store this description for reporting purposes.</summary>
		public string ObsTestLoincText;
		///<summary>OBR.7 - Observation/Specimen Collection Date/Time.  LabCorp report field "Date &amp; Time Collected".
		///yyyyMMddHHmm format in the message, no seconds.  May be blank.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeCollected;
		///<summary>OBR.9 - Collection/Urine Volume (Quantity/Field Value).  LabCorp report field "Total Volume".
		///The LabCorp document says this field is "Numeric Characters", but the HL7 documentation data type as CQ, which is a number with units
		///in the form of Quantity^Units.  The Units component has subcomponents: ID&amp;Text&amp;Name of Coding System&amp;Alt ID&amp;Alt Text&amp;
		///Name of Alt Coding System&amp;Coding System Version ID&amp;Alt Coding System Version ID&amp;Original Text.
		///We will make this a string column and store the Quantity with the Units ID subcomponent if present.
		///The default unit of measurement is ML, so if the field is a number only we will add ML.</summary>
		public string TotalVolume;
		///<summary>OBR.11 - Action Code.  Blank for normal result, "G" for reflex result.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.EnumAsString)]
		public ResultAction ActionCode;
		///<summary>OBR.13.1 - Relevant Clinical Information.  LabCorp report field "Additional Information".  The report field will be filled with this
		///value from the first OBR record in the message.  The message limits this field to 64 characters, the rest is truncated.</summary>
		public string ClinicalInfo;
		///<summary>OBR.14 - Date/Time of Specimen Receipt in Lab.  LabCorp report field "Date Entered".  yyyyMMddHHmm format in the message, no seconds.
		///Date and time the order was entered in the Lab System.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeEntered;
		///<summary>ORC.12.1 and OBR.16.1 - Ordering Provider ID Number.  LabCorp report field "NPI".  ORC.12.* and OBR.16.* are repeatable, the eighth
		///component identifies the source of the ID in the first component.  Component 8 possible values: "U"-UPIN,
		///"P"-Provider Number (Medicaid or Commercial Ins Provider ID), "N"-NPI (Required for third party billing), "L"-Local (Physician ID).</summary>
		public string OrderingProvNPI;
		///<summary>ORC.12.1 and OBR.16.1 - Ordering Provider ID Number.  LabCorp report field "Physician ID".  ORC.12.* and OBR.16.* are repeatable,
		///the eighth component identifies the source of the ID in the first component.  Component 8 possible values: "U"-UPIN,
		///"P"-Provider Number (Medicaid or Commercial Ins Provider ID), "N"-NPI (Required for third party billing), "L"-Local (Physician ID).</summary>
		public string OrderingProvLocalID;
		///<summary>ORC.12.2 and OBR.16.2 - Ordering Provider Last Name.  LabCorp report field "Physician Name".  Last, First.</summary>
		public string OrderingProvLName;
		///<summary>ORC.12.3 and OBR.16.3 - Ordering Provider First Initial.  LabCorp report field "Physician Name".  Last, First.</summary>
		public string OrderingProvFName;
		///<summary>OBR.18 - Alternate Unique Foreign Accession / Specimen ID.  LabCorp report field "Control Number".</summary>
		public string SpecimenIDAlt;
		///<summary>OBR.22 - Date/Time Observations Reported.  LabCorp report field "Date &amp; Time Reported".  yyyyMMddHHmm format in the message, no secs.
		///Date and time the results were released from the Lab System.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeReported;
		///<summary>OBR.25 - Order Result Status.  LabCorp possible values: "F" - Final, "P" - Preliminary, "X" - Cancelled, "C" - Corrected.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.EnumAsString)]
		public ResultStatus ResultStatus;
		///<summary>OBR.26.1 - Link to Parent Result or Organism Link to Susceptibility.
		///A reflex test will have the parent's OBX.3.1 value here for linking.</summary>
		public string ParentObsID;
		///<summary>OBR.29 - Link to Parent Order.  A reflex test will have the value from OBR.4.1 of the original order in this field for linking.</summary>
		public string ParentObsTestID;
		#endregion OBR Fields
		///<summary>NTE.3 - Comment Text, PID Level.  The NTE segment is repeatable and the Comment Text component is limited to 78 characters.  Multiple
		///NTE segments can be used for longer comments.  All NTE segments at the PID level will be concatenated and stored in this one field.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string NotePat;
		///<summary>NTE.3 - Comment Text, OBR level.  The NTE segment is repeatable and the Comment Text component is limited to 78 characters.  Multiple
		///NTE segments can be used for longer comments.  All NTE segments at the OBR level will be concatenated and stored in this one field.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string NoteLab;
		///<summary>Not unique. More than one MedLab object can point to the same FileName, so deleting the MedLab object does not necessarily mean
		///the file can also be deleted.  This is the filename of the original archived message that was processed to create this medlab object as
		///well as associated medlabresult, medlabspecimen, and medlabfacility obects.  The files will be stored in the OpenDentImages folder in a
		///sub-folder called LabCorpHL7Msgs. If the option to store images directly in the database is chosen, this will be an empty field and there
		///will not be the option to display the original HL7 message.</summary>
		public string FileName;
		///<summary>The PID Segment from the HL7 message used to generate this MedLab object.</summary>
		public string OriginalPIDSegment;

		///<summary></summary>
		public MedLab Copy() {
			return (MedLab)MemberwiseClone();
		}

	}

	///<summary>Order Result Action Code.  To identify the type of result being returned.</summary>
	public enum ResultAction {
		///<summary>0 - None.  Standard results will be blank.</summary>
		None,
		///<summary>1 - Add On.  Limited usage and not applicable for all add on tests.</summary>
		A,
		///<summary>2 - Reflex.  Lab generated result for test not on the original order.</summary>
		G
	}

	///<summary>Order Result Status.  Identification of status of results at the ordered item level.</summary>
	public enum ResultStatus {
		///<summary>0 - Corrected Result.</summary>
		C,
		///<summary>1 - Final.  Result complete and verified.</summary>
		F,
		///<summary>2 - Incomplete.  For Discrete Microbiology Testing.</summary>
		I,
		///<summary>3 - Preliminary.  Final not yet obtained.</summary>
		P,
		///<summary>4 - Canceled.  Procedure cannot be done.  Result canceled due to Non-Performance.</summary>
		X
	}


}