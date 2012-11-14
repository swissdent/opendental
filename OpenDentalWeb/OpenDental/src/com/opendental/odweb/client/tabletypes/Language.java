package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class Language {
		/** Primary key. */
		public int LanguageNum;
		/** No longer used. */
		public String EnglishComments;
		/** A string representing the class where the translation is used. Maximum length is 25 characters. */
		public String ClassType;
		/** The English version of the phrase, case sensitive. */
		public String English;
		/** As this gets more sophisticated, we will use this field to mark some phrases obsolete instead of just deleting them outright.  That way, translators will still have access to them.  For now, this is not used at all. */
		public boolean IsObsolete;

		/** Deep copy of object. */
		public Language Copy() {
			Language language=new Language();
			language.LanguageNum=this.LanguageNum;
			language.EnglishComments=this.EnglishComments;
			language.ClassType=this.ClassType;
			language.English=this.English;
			language.IsObsolete=this.IsObsolete;
			return language;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<Language>");
			sb.append("<LanguageNum>").append(LanguageNum).append("</LanguageNum>");
			sb.append("<EnglishComments>").append(Serializing.EscapeForXml(EnglishComments)).append("</EnglishComments>");
			sb.append("<ClassType>").append(Serializing.EscapeForXml(ClassType)).append("</ClassType>");
			sb.append("<English>").append(Serializing.EscapeForXml(English)).append("</English>");
			sb.append("<IsObsolete>").append((IsObsolete)?1:0).append("</IsObsolete>");
			sb.append("</Language>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				LanguageNum=Integer.valueOf(doc.getElementsByTagName("LanguageNum").item(0).getFirstChild().getNodeValue());
				EnglishComments=doc.getElementsByTagName("EnglishComments").item(0).getFirstChild().getNodeValue();
				ClassType=doc.getElementsByTagName("ClassType").item(0).getFirstChild().getNodeValue();
				English=doc.getElementsByTagName("English").item(0).getFirstChild().getNodeValue();
				IsObsolete=(doc.getElementsByTagName("IsObsolete").item(0).getFirstChild().getNodeValue()=="0")?false:true;
			}
			catch(Exception e) {
				throw e;
			}
		}


}
