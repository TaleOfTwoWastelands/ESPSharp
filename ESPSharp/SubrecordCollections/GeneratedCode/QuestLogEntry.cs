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
	public partial class QuestLogEntry : SubrecordCollection	{
		public SimpleSubrecord<QuestStageFlags> StageFlags { get; set; }
		public List<Condition> Conditions { get; set; }
		public SimpleSubrecord<String> LogEntry { get; set; }
		public EmbeddedScript Script { get; set; }
		public RecordReference NextQuest { get; set; }

		public QuestLogEntry()
		{
			Script = new EmbeddedScript();
		}

		public QuestLogEntry(SimpleSubrecord<QuestStageFlags> StageFlags, List<Condition> Conditions, SimpleSubrecord<String> LogEntry, EmbeddedScript Script, RecordReference NextQuest)
		{
			this.StageFlags = StageFlags;
			this.Conditions = Conditions;
			this.LogEntry = LogEntry;
			this.Script = Script;
			this.NextQuest = NextQuest;
		}

		public QuestLogEntry(QuestLogEntry copyObject)
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
					case "QSDT":
						if (readTags.Contains("QSDT"))
							return;
						if (StageFlags == null)
							StageFlags = new SimpleSubrecord<QuestStageFlags>();

						StageFlags.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "CNAM":
						if (readTags.Contains("CNAM"))
							return;
						if (LogEntry == null)
							LogEntry = new SimpleSubrecord<String>();

						LogEntry.ReadBinary(reader);
						break;
					case "SCHR":
						if (readTags.Contains("SCHR"))
							return;
						Script.ReadBinary(reader);
						break;
					case "NAM0":
						if (readTags.Contains("NAM0"))
							return;
						if (NextQuest == null)
							NextQuest = new RecordReference();

						NextQuest.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (StageFlags != null)
				StageFlags.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (LogEntry != null)
				LogEntry.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (NextQuest != null)
				NextQuest.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (StageFlags != null)		
			{		
				ele.TryPathTo("StageFlags", true, out subEle);
				StageFlags.WriteXML(subEle, master);
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
			if (LogEntry != null)		
			{		
				ele.TryPathTo("LogEntry", true, out subEle);
				LogEntry.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (NextQuest != null)		
			{		
				ele.TryPathTo("NextQuest", true, out subEle);
				NextQuest.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("StageFlags", false, out subEle))
			{
				if (StageFlags == null)
					StageFlags = new SimpleSubrecord<QuestStageFlags>();
					
				StageFlags.ReadXML(subEle, master);
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
			if (ele.TryPathTo("LogEntry", false, out subEle))
			{
				if (LogEntry == null)
					LogEntry = new SimpleSubrecord<String>();
					
				LogEntry.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new EmbeddedScript();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NextQuest", false, out subEle))
			{
				if (NextQuest == null)
					NextQuest = new RecordReference();
					
				NextQuest.ReadXML(subEle, master);
			}
		}

		public QuestLogEntry Clone()
		{
			return new QuestLogEntry(this);
		}

	}
}
