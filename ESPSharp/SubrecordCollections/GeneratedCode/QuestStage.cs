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
	public partial class QuestStage : SubrecordCollection, ICloneable<QuestStage>
	{
		public SimpleSubrecord<Int16> Index { get; set; }
		public List<QuestLogEntry> LogEntries { get; set; }

		public QuestStage()
		{
		}

		public QuestStage(SimpleSubrecord<Int16> Index, List<QuestLogEntry> LogEntries)
		{
			this.Index = Index;
			this.LogEntries = LogEntries;
		}

		public QuestStage(QuestStage copyObject)
		{
			Index = copyObject.Index.Clone();
			LogEntries = new List<QuestLogEntry>();
			foreach (var item in copyObject.LogEntries)
			{
				LogEntries.Add(item.Clone());
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
					case "INDX":
						if (readTags.Contains("INDX"))
							return;
						if (Index == null)
							Index = new SimpleSubrecord<Int16>();

						Index.ReadBinary(reader);
						break;
					case "QSDT":
						if (LogEntries == null)
							LogEntries = new List<QuestLogEntry>();

						QuestLogEntry tempQSDT = new QuestLogEntry();
						tempQSDT.ReadBinary(reader);
						LogEntries.Add(tempQSDT);
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
			if (LogEntries != null)
				foreach (var item in LogEntries)
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
			if (LogEntries != null)		
			{		
				ele.TryPathTo("LogEntries", true, out subEle);
				foreach (var entry in LogEntries)
				{
					XElement newEle = new XElement("Entry");
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
					Index = new SimpleSubrecord<Int16>();
					
				Index.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LogEntries", false, out subEle))
			{
				if (LogEntries == null)
					LogEntries = new List<QuestLogEntry>();
					
				foreach (XElement e in subEle.Elements())
				{
					QuestLogEntry temp = new QuestLogEntry();
					temp.ReadXML(e, master);
					LogEntries.Add(temp);
				}
			}
		}

		public QuestStage Clone()
		{
			return new QuestStage(this);
		}

	}
}
