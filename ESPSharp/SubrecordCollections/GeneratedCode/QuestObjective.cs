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
	public partial class QuestObjective : SubrecordCollection, ICloneable<QuestObjective>
	{
		public SimpleSubrecord<Int32> Index { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public List<QuestTarget> Targets { get; set; }

		public QuestObjective()
		{
			Description = new SimpleSubrecord<String>();
		}

		public QuestObjective(SimpleSubrecord<Int32> Index, SimpleSubrecord<String> Description, List<QuestTarget> Targets)
		{
			this.Index = Index;
			this.Description = Description;
			this.Targets = Targets;
		}

		public QuestObjective(QuestObjective copyObject)
		{
			Index = copyObject.Index.Clone();
			Description = copyObject.Description.Clone();
			Targets = new List<QuestTarget>();
			foreach (var item in copyObject.Targets)
			{
				Targets.Add(item.Clone());
			}
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "QOBJ":
						if (readTags.Contains("QOBJ"))
							return;
						if (Index == null)
							Index = new SimpleSubrecord<Int32>();

						Index.ReadBinary(reader);
						break;
					case "NNAM":
						if (readTags.Contains("NNAM"))
							return;
						Description.ReadBinary(reader);
						break;
					case "QSTA":
						if (Targets == null)
							Targets = new List<QuestTarget>();

						QuestTarget tempQSTA = new QuestTarget();
						tempQSTA.ReadBinary(reader);
						Targets.Add(tempQSTA);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Index != null)
				Index.WriteBinary(writer);
			if (Description != null)
				Description.WriteBinary(writer);
			if (Targets != null)
				foreach (var item in Targets)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Index != null)		
			{		
				ele.TryPathTo("Index", true, out subEle);
				Index.WriteXML(subEle, master);
			}
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle, master);
			}
			if (Targets != null)		
			{		
				ele.TryPathTo("Targets", true, out subEle);
				foreach (var entry in Targets)
				{
					XElement newEle = new XElement("Target");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Index", false, out subEle))
			{
				if (Index == null)
					Index = new SimpleSubrecord<Int32>();
					
				Index.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Targets", false, out subEle))
			{
				if (Targets == null)
					Targets = new List<QuestTarget>();
					
				foreach (XElement e in subEle.Elements())
				{
					QuestTarget temp = new QuestTarget();
					temp.ReadXML(e, master);
					Targets.Add(temp);
				}
			}
		}

		public QuestObjective Clone()
		{
			return new QuestObjective(this);
		}

	}
}
