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

namespace ESPSharp.Records
{
	public partial class MediaLocationController : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<Byte[]> Unknown1 { get; set; }
		public SimpleSubrecord<Byte[]> Unknown2 { get; set; }
		public SimpleSubrecord<Byte[]> Unknown3 { get; set; }
		public SimpleSubrecord<Single> LocationDelay { get; set; }
		public SimpleSubrecord<UInt32> DayStart { get; set; }
		public SimpleSubrecord<UInt32> NightStart { get; set; }
		public SimpleSubrecord<Single> RetriggerDelay { get; set; }
		public List<RecordReference> MediaSetsNeutral { get; set; }
		public List<RecordReference> MediaSetsAlly { get; set; }
		public List<RecordReference> MediaSetsFriend { get; set; }
		public List<RecordReference> MediaSetsEnemy { get; set; }
		public List<RecordReference> MediaSetsLocation { get; set; }
		public List<RecordReference> MediaSetsBattle { get; set; }
		public RecordReference ConditionalFaction { get; set; }
		public SimpleSubrecord<Byte[]> Unknown4 { get; set; }
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "NAM1":
						if (Unknown1 == null)
							Unknown1 = new SimpleSubrecord<Byte[]>();

						Unknown1.ReadBinary(reader);
						break;
					case "NAM2":
						if (Unknown2 == null)
							Unknown2 = new SimpleSubrecord<Byte[]>();

						Unknown2.ReadBinary(reader);
						break;
					case "NAM3":
						if (Unknown3 == null)
							Unknown3 = new SimpleSubrecord<Byte[]>();

						Unknown3.ReadBinary(reader);
						break;
					case "NAM4":
						if (LocationDelay == null)
							LocationDelay = new SimpleSubrecord<Single>();

						LocationDelay.ReadBinary(reader);
						break;
					case "NAM5":
						if (DayStart == null)
							DayStart = new SimpleSubrecord<UInt32>();

						DayStart.ReadBinary(reader);
						break;
					case "NAM6":
						if (NightStart == null)
							NightStart = new SimpleSubrecord<UInt32>();

						NightStart.ReadBinary(reader);
						break;
					case "NAM7":
						if (RetriggerDelay == null)
							RetriggerDelay = new SimpleSubrecord<Single>();

						RetriggerDelay.ReadBinary(reader);
						break;
					case "HNAM":
						if (MediaSetsNeutral == null)
							MediaSetsNeutral = new List<RecordReference>();

						RecordReference tempHNAM = new RecordReference();
						tempHNAM.ReadBinary(reader);
						MediaSetsNeutral.Add(tempHNAM);
						break;
					case "ZNAM":
						if (MediaSetsAlly == null)
							MediaSetsAlly = new List<RecordReference>();

						RecordReference tempZNAM = new RecordReference();
						tempZNAM.ReadBinary(reader);
						MediaSetsAlly.Add(tempZNAM);
						break;
					case "XNAM":
						if (MediaSetsFriend == null)
							MediaSetsFriend = new List<RecordReference>();

						RecordReference tempXNAM = new RecordReference();
						tempXNAM.ReadBinary(reader);
						MediaSetsFriend.Add(tempXNAM);
						break;
					case "YNAM":
						if (MediaSetsEnemy == null)
							MediaSetsEnemy = new List<RecordReference>();

						RecordReference tempYNAM = new RecordReference();
						tempYNAM.ReadBinary(reader);
						MediaSetsEnemy.Add(tempYNAM);
						break;
					case "LNAM":
						if (MediaSetsLocation == null)
							MediaSetsLocation = new List<RecordReference>();

						RecordReference tempLNAM = new RecordReference();
						tempLNAM.ReadBinary(reader);
						MediaSetsLocation.Add(tempLNAM);
						break;
					case "GNAM":
						if (MediaSetsBattle == null)
							MediaSetsBattle = new List<RecordReference>();

						RecordReference tempGNAM = new RecordReference();
						tempGNAM.ReadBinary(reader);
						MediaSetsBattle.Add(tempGNAM);
						break;
					case "RNAM":
						if (ConditionalFaction == null)
							ConditionalFaction = new RecordReference();

						ConditionalFaction.ReadBinary(reader);
						break;
					case "FNAM":
						if (Unknown4 == null)
							Unknown4 = new SimpleSubrecord<Byte[]>();

						Unknown4.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Unknown1 != null)
				Unknown1.WriteBinary(writer);
			if (Unknown2 != null)
				Unknown2.WriteBinary(writer);
			if (Unknown3 != null)
				Unknown3.WriteBinary(writer);
			if (LocationDelay != null)
				LocationDelay.WriteBinary(writer);
			if (DayStart != null)
				DayStart.WriteBinary(writer);
			if (NightStart != null)
				NightStart.WriteBinary(writer);
			if (RetriggerDelay != null)
				RetriggerDelay.WriteBinary(writer);
			if (MediaSetsNeutral != null)
				foreach (var item in MediaSetsNeutral)
					item.WriteBinary(writer);
			if (MediaSetsAlly != null)
				foreach (var item in MediaSetsAlly)
					item.WriteBinary(writer);
			if (MediaSetsFriend != null)
				foreach (var item in MediaSetsFriend)
					item.WriteBinary(writer);
			if (MediaSetsEnemy != null)
				foreach (var item in MediaSetsEnemy)
					item.WriteBinary(writer);
			if (MediaSetsLocation != null)
				foreach (var item in MediaSetsLocation)
					item.WriteBinary(writer);
			if (MediaSetsBattle != null)
				foreach (var item in MediaSetsBattle)
					item.WriteBinary(writer);
			if (ConditionalFaction != null)
				ConditionalFaction.WriteBinary(writer);
			if (Unknown4 != null)
				Unknown4.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Unknown1 != null)		
			{		
				ele.TryPathTo("Unknown1", true, out subEle);
				Unknown1.WriteXML(subEle, master);
			}
			if (Unknown2 != null)		
			{		
				ele.TryPathTo("Unknown2", true, out subEle);
				Unknown2.WriteXML(subEle, master);
			}
			if (Unknown3 != null)		
			{		
				ele.TryPathTo("Unknown3", true, out subEle);
				Unknown3.WriteXML(subEle, master);
			}
			if (LocationDelay != null)		
			{		
				ele.TryPathTo("LocationDelay", true, out subEle);
				LocationDelay.WriteXML(subEle, master);
			}
			if (DayStart != null)		
			{		
				ele.TryPathTo("DayStart", true, out subEle);
				DayStart.WriteXML(subEle, master);
			}
			if (NightStart != null)		
			{		
				ele.TryPathTo("NightStart", true, out subEle);
				NightStart.WriteXML(subEle, master);
			}
			if (RetriggerDelay != null)		
			{		
				ele.TryPathTo("RetriggerDelay", true, out subEle);
				RetriggerDelay.WriteXML(subEle, master);
			}
			if (MediaSetsNeutral != null)		
			{		
				ele.TryPathTo("MediaSets/Neutral", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsNeutral)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (MediaSetsAlly != null)		
			{		
				ele.TryPathTo("MediaSets/Ally", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsAlly)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (MediaSetsFriend != null)		
			{		
				ele.TryPathTo("MediaSets/Friend", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsFriend)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (MediaSetsEnemy != null)		
			{		
				ele.TryPathTo("MediaSets/Enemy", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsEnemy)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (MediaSetsLocation != null)		
			{		
				ele.TryPathTo("MediaSets/Location", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsLocation)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (MediaSetsBattle != null)		
			{		
				ele.TryPathTo("MediaSets/Battle", true, out subEle);
				List<string> xmlNames = new List<string>{"MediaSet"};
				int i = 0;
				foreach (var entry in MediaSetsBattle)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (ConditionalFaction != null)		
			{		
				ele.TryPathTo("ConditionalFaction", true, out subEle);
				ConditionalFaction.WriteXML(subEle, master);
			}
			if (Unknown4 != null)		
			{		
				ele.TryPathTo("Unknown4", true, out subEle);
				Unknown4.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				if (Unknown1 == null)
					Unknown1 = new SimpleSubrecord<Byte[]>();
					
				Unknown1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				if (Unknown2 == null)
					Unknown2 = new SimpleSubrecord<Byte[]>();
					
				Unknown2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown3", false, out subEle))
			{
				if (Unknown3 == null)
					Unknown3 = new SimpleSubrecord<Byte[]>();
					
				Unknown3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LocationDelay", false, out subEle))
			{
				if (LocationDelay == null)
					LocationDelay = new SimpleSubrecord<Single>();
					
				LocationDelay.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DayStart", false, out subEle))
			{
				if (DayStart == null)
					DayStart = new SimpleSubrecord<UInt32>();
					
				DayStart.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NightStart", false, out subEle))
			{
				if (NightStart == null)
					NightStart = new SimpleSubrecord<UInt32>();
					
				NightStart.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RetriggerDelay", false, out subEle))
			{
				if (RetriggerDelay == null)
					RetriggerDelay = new SimpleSubrecord<Single>();
					
				RetriggerDelay.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MediaSets/Neutral", false, out subEle))
			{
				if (MediaSetsNeutral == null)
					MediaSetsNeutral = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempHNAM = new RecordReference();
					tempHNAM.ReadXML(e, master);
					MediaSetsNeutral.Add(tempHNAM);
				}
			}
			if (ele.TryPathTo("MediaSets/Ally", false, out subEle))
			{
				if (MediaSetsAlly == null)
					MediaSetsAlly = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempZNAM = new RecordReference();
					tempZNAM.ReadXML(e, master);
					MediaSetsAlly.Add(tempZNAM);
				}
			}
			if (ele.TryPathTo("MediaSets/Friend", false, out subEle))
			{
				if (MediaSetsFriend == null)
					MediaSetsFriend = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempXNAM = new RecordReference();
					tempXNAM.ReadXML(e, master);
					MediaSetsFriend.Add(tempXNAM);
				}
			}
			if (ele.TryPathTo("MediaSets/Enemy", false, out subEle))
			{
				if (MediaSetsEnemy == null)
					MediaSetsEnemy = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempYNAM = new RecordReference();
					tempYNAM.ReadXML(e, master);
					MediaSetsEnemy.Add(tempYNAM);
				}
			}
			if (ele.TryPathTo("MediaSets/Location", false, out subEle))
			{
				if (MediaSetsLocation == null)
					MediaSetsLocation = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempLNAM = new RecordReference();
					tempLNAM.ReadXML(e, master);
					MediaSetsLocation.Add(tempLNAM);
				}
			}
			if (ele.TryPathTo("MediaSets/Battle", false, out subEle))
			{
				if (MediaSetsBattle == null)
					MediaSetsBattle = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempGNAM = new RecordReference();
					tempGNAM.ReadXML(e, master);
					MediaSetsBattle.Add(tempGNAM);
				}
			}
			if (ele.TryPathTo("ConditionalFaction", false, out subEle))
			{
				if (ConditionalFaction == null)
					ConditionalFaction = new RecordReference();
					
				ConditionalFaction.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown4", false, out subEle))
			{
				if (Unknown4 == null)
					Unknown4 = new SimpleSubrecord<Byte[]>();
					
				Unknown4.ReadXML(subEle, master);
			}
		}

	}
}
