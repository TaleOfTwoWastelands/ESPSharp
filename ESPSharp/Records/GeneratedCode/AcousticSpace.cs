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
	public partial class AcousticSpace : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public List<RecordReference> Sounds { get; set; }
		public SimpleSubrecord<UInt32> WallaTriggerCount { get; set; }
		public RecordReference UseSoundFromRegion { get; set; }
		public SimpleSubrecord<EnvironmentType> EnvironmentType { get; set; }
		public SimpleSubrecord<IsInteriorEnum> IsInterior { get; set; }
	
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
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "SNAM":
						if (Sounds == null)
							Sounds = new List<RecordReference>();

						RecordReference tempSNAM = new RecordReference();
						tempSNAM.ReadBinary(reader);
						Sounds.Add(tempSNAM);
						break;
					case "WNAM":
						if (WallaTriggerCount == null)
							WallaTriggerCount = new SimpleSubrecord<UInt32>();

						WallaTriggerCount.ReadBinary(reader);
						break;
					case "RDAT":
						if (UseSoundFromRegion == null)
							UseSoundFromRegion = new RecordReference();

						UseSoundFromRegion.ReadBinary(reader);
						break;
					case "ANAM":
						if (EnvironmentType == null)
							EnvironmentType = new SimpleSubrecord<EnvironmentType>();

						EnvironmentType.ReadBinary(reader);
						break;
					case "INAM":
						if (IsInterior == null)
							IsInterior = new SimpleSubrecord<IsInteriorEnum>();

						IsInterior.ReadBinary(reader);
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
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (Sounds != null)
				foreach (var item in Sounds)
					item.WriteBinary(writer);
			if (WallaTriggerCount != null)
				WallaTriggerCount.WriteBinary(writer);
			if (UseSoundFromRegion != null)
				UseSoundFromRegion.WriteBinary(writer);
			if (EnvironmentType != null)
				EnvironmentType.WriteBinary(writer);
			if (IsInterior != null)
				IsInterior.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle, master);
			}
			if (Sounds != null)		
			{		
				ele.TryPathTo("Weathers", true, out subEle);
				List<string> xmlNames = new List<string>{"DawnOrDefaultLoop", "Afternoon", "Dusk", "Night", "Walla"};
				int i = 0;
				foreach (var entry in Sounds)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (WallaTriggerCount != null)		
			{		
				ele.TryPathTo("WallaTriggerCount", true, out subEle);
				WallaTriggerCount.WriteXML(subEle, master);
			}
			if (UseSoundFromRegion != null)		
			{		
				ele.TryPathTo("UseSoundFromRegion", true, out subEle);
				UseSoundFromRegion.WriteXML(subEle, master);
			}
			if (EnvironmentType != null)		
			{		
				ele.TryPathTo("EnvironmentType", true, out subEle);
				EnvironmentType.WriteXML(subEle, master);
			}
			if (IsInterior != null)		
			{		
				ele.TryPathTo("IsInterior", true, out subEle);
				IsInterior.WriteXML(subEle, master);
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
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Weathers", false, out subEle))
			{
				if (Sounds == null)
					Sounds = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempSNAM = new RecordReference();
					tempSNAM.ReadXML(e, master);
					Sounds.Add(tempSNAM);
				}
			}
			if (ele.TryPathTo("WallaTriggerCount", false, out subEle))
			{
				if (WallaTriggerCount == null)
					WallaTriggerCount = new SimpleSubrecord<UInt32>();
					
				WallaTriggerCount.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("UseSoundFromRegion", false, out subEle))
			{
				if (UseSoundFromRegion == null)
					UseSoundFromRegion = new RecordReference();
					
				UseSoundFromRegion.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnvironmentType", false, out subEle))
			{
				if (EnvironmentType == null)
					EnvironmentType = new SimpleSubrecord<EnvironmentType>();
					
				EnvironmentType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IsInterior", false, out subEle))
			{
				if (IsInterior == null)
					IsInterior = new SimpleSubrecord<IsInteriorEnum>();
					
				IsInterior.ReadXML(subEle, master);
			}
		}

	}
}
