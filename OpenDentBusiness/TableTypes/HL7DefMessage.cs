﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenDentBusiness {
	///<summary>There is no field for MessageStructureHL7 (ADT_A01), because that will be inferred. Defined in HL7 specs, section 2.16.3.</summary>
	[Serializable]
	public class HL7DefMessage:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long HL7DefMessageNum;
		///<summary>FK to HL7Def.HL7DefNum</summary>
		public long HL7DefNum;
		///<summary>Stored in db as string, but used in OD as enum MessageTypeHL7. Example: ADT</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.EnumAsString)]
		public MessageTypeHL7 MessageType;
		///<summary>Stored in db as string, but used in OD as enum EventTypeHL7. Example: A04, which is only used iwth ADT/ACK.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.EnumAsString)]
		public EventTypeHL7 EventType;
		///<summary>Enum:InOutHL7 Incoming, Outgoing</summary>
		public InOutHL7 InOrOut;
		///<summary>The only purpose of this column is to let you change the order in the HL7 Def windows.  It's just for convenience.</summary>
		public int ItemOrder;
		///<summary>text</summary>
//TODO: This column may need to be changed to the TextIsClobNote attribute to remove more than 50 consecutive new line characters.
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string Note;
//VendorCustomized, an enumeration.  Example: PDF TPs.

		///<Summary>List of segments associated with this hierarchical definition.  Use items in this list to get to items lower in the hierarchy.</Summary>
		[CrudColumn(IsNotDbColumn=true)]
		[XmlIgnore]
		public List<HL7DefSegment> hl7DefSegments;

		///<summary></summary>
		public HL7DefMessage Clone() {
			return (HL7DefMessage)this.MemberwiseClone();
		}

		public void AddSegment(HL7DefSegment seg,int itemOrder,bool canRepeat,bool isOptional,SegmentNameHL7 segmentName,string note) {
			if(hl7DefSegments==null) {
				hl7DefSegments=new List<HL7DefSegment>();
			}
			seg.ItemOrder=itemOrder;
			seg.CanRepeat=canRepeat;
			seg.IsOptional=isOptional;
			seg.SegmentName=segmentName;
			seg.Note=note;
			this.hl7DefSegments.Add(seg);
		}

		public void AddSegment(HL7DefSegment seg,int itemOrder,bool canRepeat,bool isOptional,SegmentNameHL7 segmentName) {
			AddSegment(seg,itemOrder,canRepeat,isOptional,segmentName,"");
		}

		public void AddSegment(HL7DefSegment seg,int itemOrder,SegmentNameHL7 segmentName) {
			AddSegment(seg,itemOrder,false,false,segmentName,"");
		}

	}

	///<summary>The items in this enumeration can be freely rearranged without damaging the database.  But can't change spelling or remove existing item.</summary>
	public enum MessageTypeHL7 {
		///<summary>Use this for unsupported message types</summary>
		NotDefined,
		///<summary>Message Acknowledgment</summary>
		ACK,
		///<summary>Demographics - A01,A04,A08,A28,A31</summary>
		ADT,
		///<summary>Detailed Financial Transaction - P03</summary>
		DFT,
		///<summary>Unsolicited Observation Message - R01</summary>
		ORU,
		///<summary>Patient Problem - PC1,PC2,PC3</summary>
		PPR,
		///<summary>Schedule Information Unsolicited - Event types S12 through S26.  Currently only S12, S14, S15, and S17 events are supported.  Inbound for eCW, outbound for other interfaces.</summary>
		SIU,
		///<summary>Schedule Request Message - Event types S01 through S11.  Currently only S03 and S04 events are supported.  Not used for eCW, inbound for other interfaces.</summary>
		SRM,
		///<summary>Unsolicited Vaccination Record Update - V04</summary>
		VXU
	}

	///<summary>The items in this enumeration can be freely rearranged without damaging the database.  But can't change spelling or remove existing item.</summary>
	public enum EventTypeHL7 {
		///<summary>Use this for unsupported event types</summary>
		NotDefined,
		///<summary>Only used with ADT/ACK.
		///<para>A04 - Register a Patient, A08 - Update Patient Info</para>
		///<para>For eCW, the A04 and A08 are inbound messages and are processed the same.  We attempt to locate the patient, if not found we insert one.</para>
		///<para>For other interfaces, the same method of locating a patient and if not found inserting one will be used for inbound ADT^A04 and ADT^A08 messages.</para>
		///<para>Outbound messages will have an A04 event type if a new patient is added, A08 if a current patient's info is updated.</para></summary>
		A04,
		///<summary>Only used with ADT/ACK.
		///<para>A08 - Update Patient Info</para>
		///<para>A04 and A08 inbound are processed the same, but we will send the A08 event type if updating a patient in an outbound ADT.</para></summary>
		A08,
		/////<summary>Not currently supported, but would be very useful. Only used with ADT/ACK.
		/////<para>Not used for eCW.</para>
		/////<para>A40 - Merge Patient - Patient Identifier List.  Two PID.3 ID's have been merged into one.</para></summary>
		//A40,
		///<summary>Only used with DFT/Ack.</summary>
		P03,
		///<summary>Only used with PPR/Ack (Patient Problem messages).
		///<para>Not used for eCW.</para>
		///<para>These are inbound messages for adding/updating patient problems.</para>
		///<para>PC1 is the Add event, PC2 is the Update event.  Add and Update events will be handled the same for now.</para></summary>
		PC1_PC2,
		/////<summary>Only used with PPR/Ack (Patient Problem messages).  PC3 is the Delete event.  Not currently supported.</summary>
		//PC3,
		/////<summary>S01, S02, and S05-S11 are not currently supported.</summary>
		//S01_S02,
		//S05_S11,
		///<summary>Only used with SRM/ACK.  S03 - Request Appointment Modification, S04 - Request Appointment Cancellation.
		///<para>Not used for eCW.</para>
		///<para>These will be inbound and are used for updating a limited amount of information for an existing appointment.</para>
		///<para>S03 messages are used to update appointments.  S04 messages are used to set an appointment.AptStatus to ApptStatus.Broken.</para></summary>
		S03_S04,
		///<summary>Only used with SIU/ACK.
		///<para>S12 - New Appt</para>
		///<para>For eCW, these are inbound, OD is considered an auxiliary application, and S12 and S14 messages are processed the same.</para>
		///<para>For interfaces that require outbound SIU messages, OD is considered the filler application since OD has control over the operatories and schedules.</para>
		///<para>As the filler application, events S12-S26 are the message events and they all have the same structure defined by HL7.</para>
		///<para>Different actions in OD will cause a different outbound event type to be inserted, but the defined segments and fields will otherwise be the same.</para></summary>
		S12,
		///<summary>Only used with SIU/ACK.
		///<para>S13 - Appt Rescheduling</para></summary>
		S13,
		///<summary>Only used with SIU/ACK.
		///<para>S14 - Appt Modification</para></summary>
		S14,
		///<summary>Only used with SIU/ACK.
		///<para>S15 - Appt Cancellation</para></summary>
		S15,
		///<summary>Only used with SIU/ACK.
		///<para>S17 - Appt Deletion</para></summary>
		S17//,
		/////<summary>Not currently supported as inbound or outbound message events.</summary>
		//S18_S26
	}

	public enum InOutHL7 {
		///<summary>0</summary>
		Incoming,
		///<summary>1</summary>
		Outgoing
	}

}
