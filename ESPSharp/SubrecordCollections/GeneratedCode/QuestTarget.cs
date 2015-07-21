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
	public partial class QuestTarget : SubrecordCollection	{
		public QuestTargetData Target { get; set; }
		public List<Condition> Conditions { get; set; }

		public QuestTarget()
		{
		}

		public QuestTarget(QuestTargetData Target, List<Condition> Conditions)
		{
			this.Target = Target;
			this.Conditions = Conditions;
		}

		public QuestTarget(QuestTarget copyObject)
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
					case "QSTA":
						if (readTags.Contains("QSTA"))
							return;
						if (Target == null)
							Target = new QuestTargetData();

						Target.ReadBinary(reader);
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
			if (Target != null)
				Target.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Target != null)		
			{		
				ele.TryPathTo("Target", true, out subEle);
				Target.WriteXML(subEle, master);
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
			
			if (ele.TryPathTo("Target", false, out subEle))
			{
				if (Target == null)
					Target = new QuestTargetData();
					
				Target.ReadXML(subEle, master);
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

		public QuestTarget Clone()
		{
			return new QuestTarget(this);
		}

	}
}
