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
	public partial class DialogTopic : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public List<AddedQuest> AddedQuests { get; set; }
		public List<RecordReference> RemovedQuests { get; set; }
		public List<SharedInfo> UnusedInfos { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<Single> Priority { get; set; }
		public SimpleSubrecord<String> Unknown { get; set; }
		public DialogTopicData Data { get; set; }
	
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
					case "QSTI":
						if (AddedQuests == null)
							AddedQuests = new List<AddedQuest>();

						AddedQuest tempQSTI = new AddedQuest();
						tempQSTI.ReadBinary(reader);
						AddedQuests.Add(tempQSTI);
						break;
					case "QSTR":
						if (RemovedQuests == null)
							RemovedQuests = new List<RecordReference>();

						RecordReference tempQSTR = new RecordReference();
						tempQSTR.ReadBinary(reader);
						RemovedQuests.Add(tempQSTR);
						break;
					case "INFC":
						if (UnusedInfos == null)
							UnusedInfos = new List<SharedInfo>();

						SharedInfo tempINFC = new SharedInfo();
						tempINFC.ReadBinary(reader);
						UnusedInfos.Add(tempINFC);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "PNAM":
						if (Priority == null)
							Priority = new SimpleSubrecord<Single>();

						Priority.ReadBinary(reader);
						break;
					case "TDUM":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<String>();

						Unknown.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new DialogTopicData();

						Data.ReadBinary(reader);
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
			if (AddedQuests != null)
				foreach (var item in AddedQuests)
					item.WriteBinary(writer);
			if (RemovedQuests != null)
				foreach (var item in RemovedQuests)
					item.WriteBinary(writer);
			if (UnusedInfos != null)
				foreach (var item in UnusedInfos)
					item.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Priority != null)
				Priority.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (AddedQuests != null)		
			{		
				ele.TryPathTo("AddedQuests", true, out subEle);
				List<string> xmlNames = new List<string>{"AddedQuest"};
				int i = 0;
				foreach (var entry in AddedQuests)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (RemovedQuests != null)		
			{		
				ele.TryPathTo("RemovedQuests", true, out subEle);
				List<string> xmlNames = new List<string>{"RemovedQuest"};
				int i = 0;
				foreach (var entry in RemovedQuests)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (UnusedInfos != null)		
			{		
				ele.TryPathTo("UnusedInfos", true, out subEle);
				List<string> xmlNames = new List<string>{"Unused"};
				int i = 0;
				foreach (var entry in UnusedInfos)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Priority != null)		
			{		
				ele.TryPathTo("Priority", true, out subEle);
				Priority.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
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
			if (ele.TryPathTo("AddedQuests", false, out subEle))
			{
				if (AddedQuests == null)
					AddedQuests = new List<AddedQuest>();
					
				foreach (XElement e in subEle.Elements())
				{
					AddedQuest tempQSTI = new AddedQuest();
					tempQSTI.ReadXML(e, master);
					AddedQuests.Add(tempQSTI);
				}
			}
			if (ele.TryPathTo("RemovedQuests", false, out subEle))
			{
				if (RemovedQuests == null)
					RemovedQuests = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempQSTR = new RecordReference();
					tempQSTR.ReadXML(e, master);
					RemovedQuests.Add(tempQSTR);
				}
			}
			if (ele.TryPathTo("UnusedInfos", false, out subEle))
			{
				if (UnusedInfos == null)
					UnusedInfos = new List<SharedInfo>();
					
				foreach (XElement e in subEle.Elements())
				{
					SharedInfo tempINFC = new SharedInfo();
					tempINFC.ReadXML(e, master);
					UnusedInfos.Add(tempINFC);
				}
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Priority", false, out subEle))
			{
				if (Priority == null)
					Priority = new SimpleSubrecord<Single>();
					
				Priority.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<String>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new DialogTopicData();
					
				Data.ReadXML(subEle, master);
			}
		}

	}
}
