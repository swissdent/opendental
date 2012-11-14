using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;

namespace OpenDentalWebService {
	///<summary>This file is generated automatically by the crud, do not make any changes to this file because they will get overwritten.</summary>
	public class Equipment {

		///<summary></summary>
		public static string Serialize(OpenDentBusiness.Equipment equipment) {
			StringBuilder sb=new StringBuilder();
			sb.Append("<Equipment>");
			sb.Append("<EquipmentNum>").Append(equipment.EquipmentNum).Append("</EquipmentNum>");
			sb.Append("<Description>").Append(SerializeStringEscapes.EscapeForXml(equipment.Description)).Append("</Description>");
			sb.Append("<SerialNumber>").Append(SerializeStringEscapes.EscapeForXml(equipment.SerialNumber)).Append("</SerialNumber>");
			sb.Append("<ModelYear>").Append(SerializeStringEscapes.EscapeForXml(equipment.ModelYear)).Append("</ModelYear>");
			sb.Append("<DatePurchased>").Append(equipment.DatePurchased.ToString()).Append("</DatePurchased>");
			sb.Append("<DateSold>").Append(equipment.DateSold.ToString()).Append("</DateSold>");
			sb.Append("<PurchaseCost>").Append(equipment.PurchaseCost).Append("</PurchaseCost>");
			sb.Append("<MarketValue>").Append(equipment.MarketValue).Append("</MarketValue>");
			sb.Append("<Location>").Append(SerializeStringEscapes.EscapeForXml(equipment.Location)).Append("</Location>");
			sb.Append("<DateEntry>").Append(equipment.DateEntry.ToString()).Append("</DateEntry>");
			sb.Append("</Equipment>");
			return sb.ToString();
		}

		///<summary></summary>
		public static OpenDentBusiness.Equipment Deserialize(string xml) {
			OpenDentBusiness.Equipment equipment=new OpenDentBusiness.Equipment();
			using(XmlReader reader=XmlReader.Create(new StringReader(xml))) {
				reader.MoveToContent();
				while(reader.Read()) {
					//Only detect start elements.
					if(!reader.IsStartElement()) {
						continue;
					}
					switch(reader.Name) {
						case "EquipmentNum":
							equipment.EquipmentNum=reader.ReadContentAsLong();
							break;
						case "Description":
							equipment.Description=reader.ReadContentAsString();
							break;
						case "SerialNumber":
							equipment.SerialNumber=reader.ReadContentAsString();
							break;
						case "ModelYear":
							equipment.ModelYear=reader.ReadContentAsString();
							break;
						case "DatePurchased":
							equipment.DatePurchased=DateTime.Parse(reader.ReadContentAsString());
							break;
						case "DateSold":
							equipment.DateSold=DateTime.Parse(reader.ReadContentAsString());
							break;
						case "PurchaseCost":
							equipment.PurchaseCost=reader.ReadContentAsDouble();
							break;
						case "MarketValue":
							equipment.MarketValue=reader.ReadContentAsDouble();
							break;
						case "Location":
							equipment.Location=reader.ReadContentAsString();
							break;
						case "DateEntry":
							equipment.DateEntry=DateTime.Parse(reader.ReadContentAsString());
							break;
					}
				}
			}
			return equipment;
		}


	}
}