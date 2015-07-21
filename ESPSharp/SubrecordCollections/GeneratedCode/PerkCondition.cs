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
	public partial class PerkCondition : SubrecordCollection	{
		public SimpleSubrecord<PerkRunOn> RunOn { get; set; }
		public List<Condition> Conditions { get; set; }

		public PerkCondition()
		{
			RunOn = new SimpleSubrecord<PerkRunOn>();
			Conditions = new List<Condition>();
		}

		public PerkCondition(SimpleSubrecord<PerkRunOn> RunOn, List<Condition> Conditions)
		{
			this.RunOn = RunOn;
			this.Conditions = Conditions;
		}

		public PerkCondition(PerkCondition copyObject)
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
					case "PRKC":
						if (readTags.Contains("PRKC"))
							return;
						RunOn.ReadBinary(reader);
						break;
					case "CTDA":
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
			if (RunOn != null)
				RunOn.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (RunOn != null)		
			{		
				ele.TryPathTo("RunOn", true, out subEle);
				RunOn.WriteXML(subEle, master);
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
			
			if (ele.TryPathTo("RunOn", false, out subEle))
			{
				if (RunOn == null)
					RunOn = new SimpleSubrecord<PerkRunOn>();
					
				RunOn.ReadXML(subEle, master);
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

		public PerkCondition Clone()
		{
			return new PerkCondition(this);
		}

	}
}
