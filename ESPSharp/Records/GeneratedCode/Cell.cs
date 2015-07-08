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
	public partial class Cell : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<CellFlags> CellFlags { get; set; }
		public CellGrid Grid { get; set; }
		public CellLighting Lighting { get; set; }
		public FootstepMaterial FootstepMaterial { get; set; }
		public RecordReference LightTemplate { get; set; }
		public SimpleSubrecord<LightTemplateInheritFlags> LightTemplateInherit { get; set; }
		public SimpleSubrecord<Single> WaterHeight { get; set; }
		public SimpleSubrecord<String> WaterNoiseTexture { get; set; }
		public FormArray Regions { get; set; }
		public RecordReference ImageSpace { get; set; }
		public SimpleSubrecord<Byte> Unknown { get; set; }
		public RecordReference EncounterZone { get; set; }
		public RecordReference Climate { get; set; }
		public RecordReference Water { get; set; }
		public RecordReference Owner { get; set; }
		public SimpleSubrecord<Int32> FactionRank { get; set; }
		public RecordReference AcousticSpace { get; set; }
		public SimpleSubrecord<Byte> Unused { get; set; }
		public RecordReference MusicType { get; set; }
	
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
					case "DATA":
						if (CellFlags == null)
							CellFlags = new SimpleSubrecord<CellFlags>();

						CellFlags.ReadBinary(reader);
						break;
					case "XCLC":
						if (Grid == null)
							Grid = new CellGrid();

						Grid.ReadBinary(reader);
						break;
					case "XCLL":
						if (Lighting == null)
							Lighting = new CellLighting();

						Lighting.ReadBinary(reader);
						break;
					case "IMPF":
						if (FootstepMaterial == null)
							FootstepMaterial = new FootstepMaterial();

						FootstepMaterial.ReadBinary(reader);
						break;
					case "LTMP":
						if (LightTemplate == null)
							LightTemplate = new RecordReference();

						LightTemplate.ReadBinary(reader);
						break;
					case "LNAM":
						if (LightTemplateInherit == null)
							LightTemplateInherit = new SimpleSubrecord<LightTemplateInheritFlags>();

						LightTemplateInherit.ReadBinary(reader);
						break;
					case "XCLW":
						if (WaterHeight == null)
							WaterHeight = new SimpleSubrecord<Single>();

						WaterHeight.ReadBinary(reader);
						break;
					case "XNAM":
						if (WaterNoiseTexture == null)
							WaterNoiseTexture = new SimpleSubrecord<String>();

						WaterNoiseTexture.ReadBinary(reader);
						break;
					case "XCLR":
						if (Regions == null)
							Regions = new FormArray();

						Regions.ReadBinary(reader);
						break;
					case "XCIM":
						if (ImageSpace == null)
							ImageSpace = new RecordReference();

						ImageSpace.ReadBinary(reader);
						break;
					case "XCET":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte>();

						Unknown.ReadBinary(reader);
						break;
					case "XEZN":
						if (EncounterZone == null)
							EncounterZone = new RecordReference();

						EncounterZone.ReadBinary(reader);
						break;
					case "XCCM":
						if (Climate == null)
							Climate = new RecordReference();

						Climate.ReadBinary(reader);
						break;
					case "XCWT":
						if (Water == null)
							Water = new RecordReference();

						Water.ReadBinary(reader);
						break;
					case "XOWN":
						if (Owner == null)
							Owner = new RecordReference();

						Owner.ReadBinary(reader);
						break;
					case "XRNK":
						if (FactionRank == null)
							FactionRank = new SimpleSubrecord<Int32>();

						FactionRank.ReadBinary(reader);
						break;
					case "XCAS":
						if (AcousticSpace == null)
							AcousticSpace = new RecordReference();

						AcousticSpace.ReadBinary(reader);
						break;
					case "XCMT":
						if (Unused == null)
							Unused = new SimpleSubrecord<Byte>();

						Unused.ReadBinary(reader);
						break;
					case "XCMO":
						if (MusicType == null)
							MusicType = new RecordReference();

						MusicType.ReadBinary(reader);
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
			if (CellFlags != null)
				CellFlags.WriteBinary(writer);
			if (Grid != null)
				Grid.WriteBinary(writer);
			if (Lighting != null)
				Lighting.WriteBinary(writer);
			if (FootstepMaterial != null)
				FootstepMaterial.WriteBinary(writer);
			if (LightTemplate != null)
				LightTemplate.WriteBinary(writer);
			if (LightTemplateInherit != null)
				LightTemplateInherit.WriteBinary(writer);
			if (WaterHeight != null)
				WaterHeight.WriteBinary(writer);
			if (WaterNoiseTexture != null)
				WaterNoiseTexture.WriteBinary(writer);
			if (Regions != null)
				Regions.WriteBinary(writer);
			if (ImageSpace != null)
				ImageSpace.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (EncounterZone != null)
				EncounterZone.WriteBinary(writer);
			if (Climate != null)
				Climate.WriteBinary(writer);
			if (Water != null)
				Water.WriteBinary(writer);
			if (Owner != null)
				Owner.WriteBinary(writer);
			if (FactionRank != null)
				FactionRank.WriteBinary(writer);
			if (AcousticSpace != null)
				AcousticSpace.WriteBinary(writer);
			if (Unused != null)
				Unused.WriteBinary(writer);
			if (MusicType != null)
				MusicType.WriteBinary(writer);
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
			if (CellFlags != null)		
			{		
				ele.TryPathTo("CellFlags", true, out subEle);
				CellFlags.WriteXML(subEle, master);
			}
			if (Grid != null)		
			{		
				ele.TryPathTo("Grid", true, out subEle);
				Grid.WriteXML(subEle, master);
			}
			if (Lighting != null)		
			{		
				ele.TryPathTo("Lighting", true, out subEle);
				Lighting.WriteXML(subEle, master);
			}
			if (FootstepMaterial != null)		
			{		
				ele.TryPathTo("FootstepMaterial", true, out subEle);
				FootstepMaterial.WriteXML(subEle, master);
			}
			if (LightTemplate != null)		
			{		
				ele.TryPathTo("LightTemplate", true, out subEle);
				LightTemplate.WriteXML(subEle, master);
			}
			if (LightTemplateInherit != null)		
			{		
				ele.TryPathTo("LightTemplateInherit", true, out subEle);
				LightTemplateInherit.WriteXML(subEle, master);
			}
			if (WaterHeight != null)		
			{		
				ele.TryPathTo("WaterHeight", true, out subEle);
				WaterHeight.WriteXML(subEle, master);
			}
			if (WaterNoiseTexture != null)		
			{		
				ele.TryPathTo("WaterNoiseTexture", true, out subEle);
				WaterNoiseTexture.WriteXML(subEle, master);
			}
			if (Regions != null)		
			{		
				ele.TryPathTo("Regions", true, out subEle);
				Regions.WriteXML(subEle, master);
			}
			if (ImageSpace != null)		
			{		
				ele.TryPathTo("ImageSpace", true, out subEle);
				ImageSpace.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (EncounterZone != null)		
			{		
				ele.TryPathTo("EncounterZone", true, out subEle);
				EncounterZone.WriteXML(subEle, master);
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
			if (Owner != null)		
			{		
				ele.TryPathTo("Owner", true, out subEle);
				Owner.WriteXML(subEle, master);
			}
			if (FactionRank != null)		
			{		
				ele.TryPathTo("FactionRank", true, out subEle);
				FactionRank.WriteXML(subEle, master);
			}
			if (AcousticSpace != null)		
			{		
				ele.TryPathTo("AcousticSpace", true, out subEle);
				AcousticSpace.WriteXML(subEle, master);
			}
			if (Unused != null)		
			{		
				ele.TryPathTo("Unused", true, out subEle);
				Unused.WriteXML(subEle, master);
			}
			if (MusicType != null)		
			{		
				ele.TryPathTo("MusicType", true, out subEle);
				MusicType.WriteXML(subEle, master);
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
			if (ele.TryPathTo("CellFlags", false, out subEle))
			{
				if (CellFlags == null)
					CellFlags = new SimpleSubrecord<CellFlags>();
					
				CellFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Grid", false, out subEle))
			{
				if (Grid == null)
					Grid = new CellGrid();
					
				Grid.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Lighting", false, out subEle))
			{
				if (Lighting == null)
					Lighting = new CellLighting();
					
				Lighting.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FootstepMaterial", false, out subEle))
			{
				if (FootstepMaterial == null)
					FootstepMaterial = new FootstepMaterial();
					
				FootstepMaterial.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LightTemplate", false, out subEle))
			{
				if (LightTemplate == null)
					LightTemplate = new RecordReference();
					
				LightTemplate.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LightTemplateInherit", false, out subEle))
			{
				if (LightTemplateInherit == null)
					LightTemplateInherit = new SimpleSubrecord<LightTemplateInheritFlags>();
					
				LightTemplateInherit.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaterHeight", false, out subEle))
			{
				if (WaterHeight == null)
					WaterHeight = new SimpleSubrecord<Single>();
					
				WaterHeight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaterNoiseTexture", false, out subEle))
			{
				if (WaterNoiseTexture == null)
					WaterNoiseTexture = new SimpleSubrecord<String>();
					
				WaterNoiseTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Regions", false, out subEle))
			{
				if (Regions == null)
					Regions = new FormArray();
					
				Regions.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpace", false, out subEle))
			{
				if (ImageSpace == null)
					ImageSpace = new RecordReference();
					
				ImageSpace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EncounterZone", false, out subEle))
			{
				if (EncounterZone == null)
					EncounterZone = new RecordReference();
					
				EncounterZone.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Owner", false, out subEle))
			{
				if (Owner == null)
					Owner = new RecordReference();
					
				Owner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FactionRank", false, out subEle))
			{
				if (FactionRank == null)
					FactionRank = new SimpleSubrecord<Int32>();
					
				FactionRank.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AcousticSpace", false, out subEle))
			{
				if (AcousticSpace == null)
					AcousticSpace = new RecordReference();
					
				AcousticSpace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused", false, out subEle))
			{
				if (Unused == null)
					Unused = new SimpleSubrecord<Byte>();
					
				Unused.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MusicType", false, out subEle))
			{
				if (MusicType == null)
					MusicType = new RecordReference();
					
				MusicType.ReadXML(subEle, master);
			}
		}

	}
}
