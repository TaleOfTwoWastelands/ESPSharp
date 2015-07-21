using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.SubrecordCollections
{
	public partial class MessageButton : SubrecordCollection	{
		public SimpleSubrecord<String> ButtonText { get; set; }
		public List<Condition> Conditions { get; set; }

		public MessageButton()
		{
		}

		public MessageButton(SimpleSubrecord<String> ButtonText, List<Condition> Conditions)
		{
			this.ButtonText = ButtonText;
			this.Conditions = Conditions;
		}

		public MessageButton(MessageButton copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "ITXT":
						if (readTags.Contains("ITXT"))
							return;
						if (ButtonText == null)
							ButtonText = new SimpleSubrecord<String>();

						ButtonText.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (ButtonText != null)
				ButtonText.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ButtonText != null)		
			{		
				ele.TryPathTo("ButtonText", true, out subEle);
				ButtonText.WriteXML(subEle, master);
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				foreach (var entry in Conditions)
				{
					XElement newEle = new XElement("Condition");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ButtonText", false, out subEle))
			{
				if (ButtonText == null)
					ButtonText = new SimpleSubrecord<String>();
					
				ButtonText.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition temp = new Condition();
					temp.ReadXML(e, master);
					Conditions.Add(temp);
				}
			}
		}

		public MessageButton Clone()
		{
			return new MessageButton(this);
		}

	}
}
