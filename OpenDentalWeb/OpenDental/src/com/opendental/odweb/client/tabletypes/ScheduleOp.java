package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class ScheduleOp {
		/** Primary key. */
		public int ScheduleOpNum;
		/** FK to schedule.ScheduleNum. */
		public int ScheduleNum;
		/** FK to operatory.OperatoryNum. */
		public int OperatoryNum;

		/** Deep copy of object. */
		public ScheduleOp Copy() {
			ScheduleOp scheduleop=new ScheduleOp();
			scheduleop.ScheduleOpNum=this.ScheduleOpNum;
			scheduleop.ScheduleNum=this.ScheduleNum;
			scheduleop.OperatoryNum=this.OperatoryNum;
			return scheduleop;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<ScheduleOp>");
			sb.append("<ScheduleOpNum>").append(ScheduleOpNum).append("</ScheduleOpNum>");
			sb.append("<ScheduleNum>").append(ScheduleNum).append("</ScheduleNum>");
			sb.append("<OperatoryNum>").append(OperatoryNum).append("</OperatoryNum>");
			sb.append("</ScheduleOp>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				ScheduleOpNum=Integer.valueOf(doc.getElementsByTagName("ScheduleOpNum").item(0).getFirstChild().getNodeValue());
				ScheduleNum=Integer.valueOf(doc.getElementsByTagName("ScheduleNum").item(0).getFirstChild().getNodeValue());
				OperatoryNum=Integer.valueOf(doc.getElementsByTagName("OperatoryNum").item(0).getFirstChild().getNodeValue());
			}
			catch(Exception e) {
				throw e;
			}
		}


}
