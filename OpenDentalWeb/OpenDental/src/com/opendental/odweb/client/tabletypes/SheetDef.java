package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class SheetDef {
		/** Primary key. */
		public int SheetDefNum;
		/** The description of this sheetdef. */
		public String Description;
		/** Enum:SheetTypeEnum */
		public SheetTypeEnum SheetType;
		/** The default fontSize for the sheet.  The actual font must still be saved with each sheetField. */
		public float FontSize;
		/** The default fontName for the sheet.  The actual font must still be saved with each sheetField. */
		public String FontName;
		/** Width of the sheet in pixels, 100 pixels per inch. */
		public int Width;
		/** Height of the sheet in pixels, 100 pixels per inch. */
		public int Height;
		/** Set to true to print landscape. */
		public boolean IsLandscape;

		/** Deep copy of object. */
		public SheetDef Copy() {
			SheetDef sheetdef=new SheetDef();
			sheetdef.SheetDefNum=this.SheetDefNum;
			sheetdef.Description=this.Description;
			sheetdef.SheetType=this.SheetType;
			sheetdef.FontSize=this.FontSize;
			sheetdef.FontName=this.FontName;
			sheetdef.Width=this.Width;
			sheetdef.Height=this.Height;
			sheetdef.IsLandscape=this.IsLandscape;
			return sheetdef;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<SheetDef>");
			sb.append("<SheetDefNum>").append(SheetDefNum).append("</SheetDefNum>");
			sb.append("<Description>").append(Serializing.EscapeForXml(Description)).append("</Description>");
			sb.append("<SheetType>").append(SheetType.ordinal()).append("</SheetType>");
			sb.append("<FontSize>").append(FontSize).append("</FontSize>");
			sb.append("<FontName>").append(Serializing.EscapeForXml(FontName)).append("</FontName>");
			sb.append("<Width>").append(Width).append("</Width>");
			sb.append("<Height>").append(Height).append("</Height>");
			sb.append("<IsLandscape>").append((IsLandscape)?1:0).append("</IsLandscape>");
			sb.append("</SheetDef>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				SheetDefNum=Integer.valueOf(doc.getElementsByTagName("SheetDefNum").item(0).getFirstChild().getNodeValue());
				Description=doc.getElementsByTagName("Description").item(0).getFirstChild().getNodeValue();
				SheetType=SheetTypeEnum.values()[Integer.valueOf(doc.getElementsByTagName("SheetType").item(0).getFirstChild().getNodeValue())];
				FontSize=Float.valueOf(doc.getElementsByTagName("FontSize").item(0).getFirstChild().getNodeValue());
				FontName=doc.getElementsByTagName("FontName").item(0).getFirstChild().getNodeValue();
				Width=Integer.valueOf(doc.getElementsByTagName("Width").item(0).getFirstChild().getNodeValue());
				Height=Integer.valueOf(doc.getElementsByTagName("Height").item(0).getFirstChild().getNodeValue());
				IsLandscape=(doc.getElementsByTagName("IsLandscape").item(0).getFirstChild().getNodeValue()=="0")?false:true;
			}
			catch(Exception e) {
				throw e;
			}
		}

		/**  */
		public enum SheetTypeEnum {
			/**  */
			LabelPatient,
			/**  */
			LabelCarrier,
			/**  */
			LabelReferral,
			/**  */
			ReferralSlip,
			/**  */
			LabelAppointment,
			/**  */
			Rx,
			/** 6-Requires SheetParameter for PatNum. */
			Consent,
			/** 7-Requires SheetParameter for PatNum. */
			PatientLetter,
			/** 8-Requires SheetParameters for PatNum,ReferralNum. */
			ReferralLetter,
			/**  */
			PatientForm,
			/**  */
			RoutingSlip,
			/**  */
			MedicalHistory,
			/**  */
			LabSlip,
			/**  */
			ExamSheet,
			/** 14-Requires SheetParameter for PatNum. */
			DepositSlip
		}


}
