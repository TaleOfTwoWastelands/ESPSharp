
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
	public partial class Quest : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public RecordReference Script { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public QuestData Data { get; set; }
		public List<Condition> Conditions { get; set; }
		public List<QuestStage> Stages { get; set; }
		public List<QuestObjective> Objectives { get; set; }

		public Quest()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Data = new QuestData("DATA");
		}

		public Quest(SimpleSubrecord<String> EditorID, RecordReference Script, SimpleSubrecord<String> Name, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, QuestData Data, List<Condition> Conditions, List<QuestStage> Stages, List<QuestObjective> Objectives)
		{
			this.EditorID = EditorID;
			this.Data = Data;
		}

		public Quest(Quest copyObject)
		{
					}
	
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
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "ICON":
						if (LargeIcon == null)
							LargeIcon = new SimpleSubrecord<String>();

						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();

						SmallIcon.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new QuestData();

						Data.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "INDX":
						if (Stages == null)
							Stages = new List<QuestStage>();

						QuestStage tempINDX = new QuestStage();
						tempINDX.ReadBinary(reader);
						Stages.Add(tempINDX);
						break;
					case "QOBJ":
						if (Objectives == null)
							Objectives = new List<QuestObjective>();

						QuestObjective tempQOBJ = new QuestObjective();
						tempQOBJ.ReadBinary(reader);
						Objectives.Add(tempQOBJ);
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
			if (Script != null)
				Script.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (Stages != null)
				foreach (var item in Stages)
					item.WriteBinary(writer);
			if (Objectives != null)
				foreach (var item in Objectives)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon/Large", true, out subEle);
				LargeIcon.WriteXML(subEle, master);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon/Small", true, out subEle);
				SmallIcon.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				List<string> xmlNames = new List<string>{"Condition"};
				int i = 0;
				foreach (var entry in Conditions)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Stages != null)		
			{		
				ele.TryPathTo("Stages", true, out subEle);
				List<string> xmlNames = new List<string>{"Stage"};
				int i = 0;
				foreach (var entry in Stages)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Objectives != null)		
			{		
				ele.TryPathTo("Objectives", true, out subEle);
				List<string> xmlNames = new List<string>{"Objective"};
				int i = 0;
				foreach (var entry in Objectives)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new QuestData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition tempCTDA = new Condition();
					tempCTDA.ReadXML(e, master);
					Conditions.Add(tempCTDA);
				}
			}
			if (ele.TryPathTo("Stages", false, out subEle))
			{
				if (Stages == null)
					Stages = new List<QuestStage>();
					
				foreach (XElement e in subEle.Elements())
				{
					QuestStage tempINDX = new QuestStage();
					tempINDX.ReadXML(e, master);
					Stages.Add(tempINDX);
				}
			}
			if (ele.TryPathTo("Objectives", false, out subEle))
			{
				if (Objectives == null)
					Objectives = new List<QuestObjective>();
					
				foreach (XElement e in subEle.Elements())
				{
					QuestObjective tempQOBJ = new QuestObjective();
					tempQOBJ.ReadXML(e, master);
					Objectives.Add(tempQOBJ);
				}
			}
		}		

		public Quest Clone()
		{
			return new Quest(this);
		}

	}
}