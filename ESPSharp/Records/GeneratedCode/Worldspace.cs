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
	public partial class Worldspace : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public RecordReference EncounterZone { get; set; }
		public RecordReference ParentWorldspace { get; set; }
		public SimpleSubrecord<ParentWorldspaceFlags> ParentWorldspaceFlags { get; set; }
		public RecordReference Climate { get; set; }
		public RecordReference Water { get; set; }
		public RecordReference LODWaterType { get; set; }
		public SimpleSubrecord<Single> LODWaterHeight { get; set; }
		public WorldLandData LandData { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public MapData MapData { get; set; }
		public WorldMapOffsetData WorldMapOffsetData { get; set; }
		public RecordReference ImageSpace { get; set; }
		public SimpleSubrecord<WorldspaceFlags> WorldspaceFlags { get; set; }
		public SimpleSubrecord<XYFloat> MinObjectBounds { get; set; }
		public SimpleSubrecord<XYFloat> MaxObjectBounds { get; set; }
		public RecordReference Music { get; set; }
		public SimpleSubrecord<String> CanopyShadow { get; set; }
		public SimpleSubrecord<String> WaterNoiseTexture { get; set; }
		public List<SwappedImpact> SwappedImpacts { get; set; }
		public FootstepMaterial FootstepMaterial { get; set; }
		public SimpleSubrecord<UInt32> OffsetDataSize { get; set; }
		public SimpleSubrecord<Byte[]> OffsetData { get; set; }
	
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
					case "XEZN":
						if (EncounterZone == null)
							EncounterZone = new RecordReference();

						EncounterZone.ReadBinary(reader);
						break;
					case "WNAM":
						if (ParentWorldspace == null)
							ParentWorldspace = new RecordReference();

						ParentWorldspace.ReadBinary(reader);
						break;
					case "PNAM":
						if (ParentWorldspaceFlags == null)
							ParentWorldspaceFlags = new SimpleSubrecord<ParentWorldspaceFlags>();

						ParentWorldspaceFlags.ReadBinary(reader);
						break;
					case "CNAM":
						if (Climate == null)
							Climate = new RecordReference();

						Climate.ReadBinary(reader);
						break;
					case "NAM2":
						if (Water == null)
							Water = new RecordReference();

						Water.ReadBinary(reader);
						break;
					case "NAM3":
						if (LODWaterType == null)
							LODWaterType = new RecordReference();

						LODWaterType.ReadBinary(reader);
						break;
					case "NAM4":
						if (LODWaterHeight == null)
							LODWaterHeight = new SimpleSubrecord<Single>();

						LODWaterHeight.ReadBinary(reader);
						break;
					case "DNAM":
						if (LandData == null)
							LandData = new WorldLandData();

						LandData.ReadBinary(reader);
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
					case "MNAM":
						if (MapData == null)
							MapData = new MapData();

						MapData.ReadBinary(reader);
						break;
					case "ONAM":
						if (WorldMapOffsetData == null)
							WorldMapOffsetData = new WorldMapOffsetData();

						WorldMapOffsetData.ReadBinary(reader);
						break;
					case "INAM":
						if (ImageSpace == null)
							ImageSpace = new RecordReference();

						ImageSpace.ReadBinary(reader);
						break;
					case "DATA":
						if (WorldspaceFlags == null)
							WorldspaceFlags = new SimpleSubrecord<WorldspaceFlags>();

						WorldspaceFlags.ReadBinary(reader);
						break;
					case "NAM0":
						if (MinObjectBounds == null)
							MinObjectBounds = new SimpleSubrecord<XYFloat>();

						MinObjectBounds.ReadBinary(reader);
						break;
					case "NAM9":
						if (MaxObjectBounds == null)
							MaxObjectBounds = new SimpleSubrecord<XYFloat>();

						MaxObjectBounds.ReadBinary(reader);
						break;
					case "ZNAM":
						if (Music == null)
							Music = new RecordReference();

						Music.ReadBinary(reader);
						break;
					case "NNAM":
						if (CanopyShadow == null)
							CanopyShadow = new SimpleSubrecord<String>();

						CanopyShadow.ReadBinary(reader);
						break;
					case "XNAM":
						if (WaterNoiseTexture == null)
							WaterNoiseTexture = new SimpleSubrecord<String>();

						WaterNoiseTexture.ReadBinary(reader);
						break;
					case "IMPS":
						if (SwappedImpacts == null)
							SwappedImpacts = new List<SwappedImpact>();

						SwappedImpact tempIMPS = new SwappedImpact();
						tempIMPS.ReadBinary(reader);
						SwappedImpacts.Add(tempIMPS);
						break;
					case "IMPF":
						if (FootstepMaterial == null)
							FootstepMaterial = new FootstepMaterial();

						FootstepMaterial.ReadBinary(reader);
						break;
					case "XXXX":
						if (OffsetDataSize == null)
							OffsetDataSize = new SimpleSubrecord<UInt32>();

						OffsetDataSize.ReadBinary(reader);
						break;
					case "OFST":
						ReadOffsetData(reader);
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
			if (EncounterZone != null)
				EncounterZone.WriteBinary(writer);
			if (ParentWorldspace != null)
				ParentWorldspace.WriteBinary(writer);
			if (ParentWorldspaceFlags != null)
				ParentWorldspaceFlags.WriteBinary(writer);
			if (Climate != null)
				Climate.WriteBinary(writer);
			if (Water != null)
				Water.WriteBinary(writer);
			if (LODWaterType != null)
				LODWaterType.WriteBinary(writer);
			if (LODWaterHeight != null)
				LODWaterHeight.WriteBinary(writer);
			if (LandData != null)
				LandData.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (MapData != null)
				MapData.WriteBinary(writer);
			if (WorldMapOffsetData != null)
				WorldMapOffsetData.WriteBinary(writer);
			if (ImageSpace != null)
				ImageSpace.WriteBinary(writer);
			if (WorldspaceFlags != null)
				WorldspaceFlags.WriteBinary(writer);
			if (MinObjectBounds != null)
				MinObjectBounds.WriteBinary(writer);
			if (MaxObjectBounds != null)
				MaxObjectBounds.WriteBinary(writer);
			if (Music != null)
				Music.WriteBinary(writer);
			if (CanopyShadow != null)
				CanopyShadow.WriteBinary(writer);
			if (WaterNoiseTexture != null)
				WaterNoiseTexture.WriteBinary(writer);
			if (SwappedImpacts != null)
				foreach (var item in SwappedImpacts)
					item.WriteBinary(writer);
			if (FootstepMaterial != null)
				FootstepMaterial.WriteBinary(writer);
			if (OffsetDataSize != null)
				OffsetDataSize.WriteBinary(writer);

			WriteOffsetData(writer);
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
			if (EncounterZone != null)		
			{		
				ele.TryPathTo("EncounterZone", true, out subEle);
				EncounterZone.WriteXML(subEle, master);
			}
			if (ParentWorldspace != null)		
			{		
				ele.TryPathTo("ParentWorldspace", true, out subEle);
				ParentWorldspace.WriteXML(subEle, master);
			}
			if (ParentWorldspaceFlags != null)		
			{		
				ele.TryPathTo("ParentWorldspaceFlags", true, out subEle);
				ParentWorldspaceFlags.WriteXML(subEle, master);
			}
			if (Climate != null)		
			{		
				ele.TryPathTo("Climate", true, out subEle);
				Climate.WriteXML(subEle, master);
			}
			if (Water != null)		
			{		
				ele.TryPathTo("Water", true, out subEle);
				Water.WriteXML(subEle, master);
			}
			if (LODWaterType != null)		
			{		
				ele.TryPathTo("LODWater/Type", true, out subEle);
				LODWaterType.WriteXML(subEle, master);
			}
			if (LODWaterHeight != null)		
			{		
				ele.TryPathTo("LODWater/Height", true, out subEle);
				LODWaterHeight.WriteXML(subEle, master);
			}
			if (LandData != null)		
			{		
				ele.TryPathTo("LandData", true, out subEle);
				LandData.WriteXML(subEle, master);
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
			if (MapData != null)		
			{		
				ele.TryPathTo("MapData", true, out subEle);
				MapData.WriteXML(subEle, master);
			}
			if (WorldMapOffsetData != null)		
			{		
				ele.TryPathTo("WorldMapOffsetData", true, out subEle);
				WorldMapOffsetData.WriteXML(subEle, master);
			}
			if (ImageSpace != null)		
			{		
				ele.TryPathTo("ImageSpace", true, out subEle);
				ImageSpace.WriteXML(subEle, master);
			}
			if (WorldspaceFlags != null)		
			{		
				ele.TryPathTo("WorldspaceFlags", true, out subEle);
				WorldspaceFlags.WriteXML(subEle, master);
			}
			if (MinObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds/Min", true, out subEle);
				MinObjectBounds.WriteXML(subEle, master);
			}
			if (MaxObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds/Max", true, out subEle);
				MaxObjectBounds.WriteXML(subEle, master);
			}
			if (Music != null)		
			{		
				ele.TryPathTo("Music", true, out subEle);
				Music.WriteXML(subEle, master);
			}
			if (CanopyShadow != null)		
			{		
				ele.TryPathTo("CanopyShadow", true, out subEle);
				CanopyShadow.WriteXML(subEle, master);
			}
			if (WaterNoiseTexture != null)		
			{		
				ele.TryPathTo("WaterNoiseTexture", true, out subEle);
				WaterNoiseTexture.WriteXML(subEle, master);
			}
			if (SwappedImpacts != null)		
			{		
				ele.TryPathTo("SwappedImpacts", true, out subEle);
				List<string> xmlNames = new List<string>{"SwappedImpact"};
				int i = 0;
				foreach (var entry in SwappedImpacts)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (FootstepMaterial != null)		
			{		
				ele.TryPathTo("FootstepMaterial", true, out subEle);
				FootstepMaterial.WriteXML(subEle, master);
			}
			if (OffsetDataSize != null)		
			{		
				ele.TryPathTo("OffsetDataSize", true, out subEle);
				OffsetDataSize.WriteXML(subEle, master);
			}
			if (OffsetData != null)		
			{		
				ele.TryPathTo("OffsetData", true, out subEle);
				OffsetData.WriteXML(subEle, master);
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
			if (ele.TryPathTo("EncounterZone", false, out subEle))
			{
				if (EncounterZone == null)
					EncounterZone = new RecordReference();
					
				EncounterZone.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ParentWorldspace", false, out subEle))
			{
				if (ParentWorldspace == null)
					ParentWorldspace = new RecordReference();
					
				ParentWorldspace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ParentWorldspaceFlags", false, out subEle))
			{
				if (ParentWorldspaceFlags == null)
					ParentWorldspaceFlags = new SimpleSubrecord<ParentWorldspaceFlags>();
					
				ParentWorldspaceFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Climate", false, out subEle))
			{
				if (Climate == null)
					Climate = new RecordReference();
					
				Climate.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Water", false, out subEle))
			{
				if (Water == null)
					Water = new RecordReference();
					
				Water.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LODWater/Type", false, out subEle))
			{
				if (LODWaterType == null)
					LODWaterType = new RecordReference();
					
				LODWaterType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LODWater/Height", false, out subEle))
			{
				if (LODWaterHeight == null)
					LODWaterHeight = new SimpleSubrecord<Single>();
					
				LODWaterHeight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LandData", false, out subEle))
			{
				if (LandData == null)
					LandData = new WorldLandData();
					
				LandData.ReadXML(subEle, master);
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
			if (ele.TryPathTo("MapData", false, out subEle))
			{
				if (MapData == null)
					MapData = new MapData();
					
				MapData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WorldMapOffsetData", false, out subEle))
			{
				if (WorldMapOffsetData == null)
					WorldMapOffsetData = new WorldMapOffsetData();
					
				WorldMapOffsetData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpace", false, out subEle))
			{
				if (ImageSpace == null)
					ImageSpace = new RecordReference();
					
				ImageSpace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WorldspaceFlags", false, out subEle))
			{
				if (WorldspaceFlags == null)
					WorldspaceFlags = new SimpleSubrecord<WorldspaceFlags>();
					
				WorldspaceFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ObjectBounds/Min", false, out subEle))
			{
				if (MinObjectBounds == null)
					MinObjectBounds = new SimpleSubrecord<XYFloat>();
					
				MinObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ObjectBounds/Max", false, out subEle))
			{
				if (MaxObjectBounds == null)
					MaxObjectBounds = new SimpleSubrecord<XYFloat>();
					
				MaxObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Music", false, out subEle))
			{
				if (Music == null)
					Music = new RecordReference();
					
				Music.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CanopyShadow", false, out subEle))
			{
				if (CanopyShadow == null)
					CanopyShadow = new SimpleSubrecord<String>();
					
				CanopyShadow.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaterNoiseTexture", false, out subEle))
			{
				if (WaterNoiseTexture == null)
					WaterNoiseTexture = new SimpleSubrecord<String>();
					
				WaterNoiseTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SwappedImpacts", false, out subEle))
			{
				if (SwappedImpacts == null)
					SwappedImpacts = new List<SwappedImpact>();
					
				foreach (XElement e in subEle.Elements())
				{
					SwappedImpact tempIMPS = new SwappedImpact();
					tempIMPS.ReadXML(e, master);
					SwappedImpacts.Add(tempIMPS);
				}
			}
			if (ele.TryPathTo("FootstepMaterial", false, out subEle))
			{
				if (FootstepMaterial == null)
					FootstepMaterial = new FootstepMaterial();
					
				FootstepMaterial.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OffsetDataSize", false, out subEle))
			{
				if (OffsetDataSize == null)
					OffsetDataSize = new SimpleSubrecord<UInt32>();
					
				OffsetDataSize.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OffsetData", false, out subEle))
			{
				if (OffsetData == null)
					OffsetData = new SimpleSubrecord<Byte[]>();
					
				OffsetData.ReadXML(subEle, master);
			}
		}

		partial void ReadOffsetData(ESPReader reader);
		partial void WriteOffsetData(ESPWriter writer);
	}
}
