package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class Recall {
		/** Primary key. */
		public int RecallNum;
		/** FK to patient.PatNum. */
		public int PatNum;
		/** Not editable.  The calculated date due. Generated by the program and subject to change anytime the conditions change. It can be blank (0001-01-01) if no appropriate triggers.  */
		public String DateDueCalc;
		/** This is the date that is actually used when doing reports for recall. It will usually be the same as DateDueCalc unless user has changed it. System will only update this field if it is the same as DateDueCalc.  Otherwise, it will be left alone.  Gets cleared along with DateDueCalc when resetting recall.  When setting disabled, this field will also be cleared.  This is the field to use if converting from another software. */
		public String DateDue;
		/** Not editable. Previous date that procedures were done to trigger this recall. It is calculated and enforced automatically.  If you want to affect this date, add a procedure to the chart with a status of C, EC, or EO. */
		public String DatePrevious;
		/** The interval between recalls.  The Interval struct combines years, months, weeks, and days into a single integer value. */
		public int RecallInterval;
		/** FK to definition.DefNum, or 0 for none. */
		public int RecallStatus;
		/** An administrative note for staff use. */
		public String Note;
		/** If true, this recall type will be disabled (there's only one type right now). This is usually used rather than deleting the recall type from the patient because the program must enforce the trigger conditions for all patients. */
		public boolean IsDisabled;
		/** Last datetime that this row was inserted or updated. */
		public String DateTStamp;
		/** FK to recalltype.RecallTypeNum. */
		public int RecallTypeNum;
		/** Default is 0.  If a positive number is entered, then the family balance must be less in order for this recall to show in the recall list. */
		public double DisableUntilBalance;
		/** If a date is entered, then this recall will be disabled until that date. */
		public String DisableUntilDate;
		/** This will only have a value if a recall is scheduled. */
		public String DateScheduled;

		/** Deep copy of object. */
		public Recall Copy() {
			Recall recall=new Recall();
			recall.RecallNum=this.RecallNum;
			recall.PatNum=this.PatNum;
			recall.DateDueCalc=this.DateDueCalc;
			recall.DateDue=this.DateDue;
			recall.DatePrevious=this.DatePrevious;
			recall.RecallInterval=this.RecallInterval;
			recall.RecallStatus=this.RecallStatus;
			recall.Note=this.Note;
			recall.IsDisabled=this.IsDisabled;
			recall.DateTStamp=this.DateTStamp;
			recall.RecallTypeNum=this.RecallTypeNum;
			recall.DisableUntilBalance=this.DisableUntilBalance;
			recall.DisableUntilDate=this.DisableUntilDate;
			recall.DateScheduled=this.DateScheduled;
			return recall;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<Recall>");
			sb.append("<RecallNum>").append(RecallNum).append("</RecallNum>");
			sb.append("<PatNum>").append(PatNum).append("</PatNum>");
			sb.append("<DateDueCalc>").append(Serializing.EscapeForXml(DateDueCalc)).append("</DateDueCalc>");
			sb.append("<DateDue>").append(Serializing.EscapeForXml(DateDue)).append("</DateDue>");
			sb.append("<DatePrevious>").append(Serializing.EscapeForXml(DatePrevious)).append("</DatePrevious>");
			sb.append("<RecallInterval>").append(RecallInterval).append("</RecallInterval>");
			sb.append("<RecallStatus>").append(RecallStatus).append("</RecallStatus>");
			sb.append("<Note>").append(Serializing.EscapeForXml(Note)).append("</Note>");
			sb.append("<IsDisabled>").append((IsDisabled)?1:0).append("</IsDisabled>");
			sb.append("<DateTStamp>").append(Serializing.EscapeForXml(DateTStamp)).append("</DateTStamp>");
			sb.append("<RecallTypeNum>").append(RecallTypeNum).append("</RecallTypeNum>");
			sb.append("<DisableUntilBalance>").append(DisableUntilBalance).append("</DisableUntilBalance>");
			sb.append("<DisableUntilDate>").append(Serializing.EscapeForXml(DisableUntilDate)).append("</DisableUntilDate>");
			sb.append("<DateScheduled>").append(Serializing.EscapeForXml(DateScheduled)).append("</DateScheduled>");
			sb.append("</Recall>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				RecallNum=Integer.valueOf(doc.getElementsByTagName("RecallNum").item(0).getFirstChild().getNodeValue());
				PatNum=Integer.valueOf(doc.getElementsByTagName("PatNum").item(0).getFirstChild().getNodeValue());
				DateDueCalc=doc.getElementsByTagName("DateDueCalc").item(0).getFirstChild().getNodeValue();
				DateDue=doc.getElementsByTagName("DateDue").item(0).getFirstChild().getNodeValue();
				DatePrevious=doc.getElementsByTagName("DatePrevious").item(0).getFirstChild().getNodeValue();
				RecallInterval=Integer.valueOf(doc.getElementsByTagName("RecallInterval").item(0).getFirstChild().getNodeValue());
				RecallStatus=Integer.valueOf(doc.getElementsByTagName("RecallStatus").item(0).getFirstChild().getNodeValue());
				Note=doc.getElementsByTagName("Note").item(0).getFirstChild().getNodeValue();
				IsDisabled=(doc.getElementsByTagName("IsDisabled").item(0).getFirstChild().getNodeValue()=="0")?false:true;
				DateTStamp=doc.getElementsByTagName("DateTStamp").item(0).getFirstChild().getNodeValue();
				RecallTypeNum=Integer.valueOf(doc.getElementsByTagName("RecallTypeNum").item(0).getFirstChild().getNodeValue());
				DisableUntilBalance=Double.valueOf(doc.getElementsByTagName("DisableUntilBalance").item(0).getFirstChild().getNodeValue());
				DisableUntilDate=doc.getElementsByTagName("DisableUntilDate").item(0).getFirstChild().getNodeValue();
				DateScheduled=doc.getElementsByTagName("DateScheduled").item(0).getFirstChild().getNodeValue();
			}
			catch(Exception e) {
				throw e;
			}
		}


}
