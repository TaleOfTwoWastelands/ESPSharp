﻿
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
	public partial class ArmorAddon : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public BipedData BipedData { get; set; }
		public SimpleSubrecord<String> MaleBipedModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> MaleBipedModelTextureHashes { get; set; }
		public AlternateTextures MaleBipedModelAlternateTextures { get; set; }
		public SimpleSubrecord<FaceGenModelFlags> MaleBipedModelFaceGenModelFlags { get; set; }
		public SimpleSubrecord<String> MaleWorldModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> MaleWorldModelTextureHashes { get; set; }
		public AlternateTextures MaleWorldModelAlternateTextures { get; set; }
		public SimpleSubrecord<String> MaleInventoryIcon { get; set; }
		public SimpleSubrecord<String> MaleMessageIcon { get; set; }
		public SimpleSubrecord<String> FemaleBipedModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> FemaleBipedModelTextureHashes { get; set; }
		public AlternateTextures FemaleBipedModelAlternateTextures { get; set; }
		public SimpleSubrecord<FaceGenModelFlags> FemaleBipedModelFaceGenModelFlags { get; set; }
		public SimpleSubrecord<String> FemaleWorldModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> FemaleWorldModelTextureHashes { get; set; }
		public AlternateTextures FemaleWorldModelAlternateTextures { get; set; }
		public SimpleSubrecord<String> FemaleInventoryIcon { get; set; }
		public SimpleSubrecord<String> FemaleMessageIcon { get; set; }
		public SimpleSubrecord<EquipmentType> EquipmentType { get; set; }
		public ArmorData Data { get; set; }
		public ArmorAddonData ExtraData { get; set; }

		public ArmorAddon()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			BipedData = new BipedData("BMDT");
			MaleBipedModelFileName = new SimpleSubrecord<String>("MODL");
			MaleWorldModelFileName = new SimpleSubrecord<String>("MOD2");
			FemaleBipedModelFileName = new SimpleSubrecord<String>("MOD3");
			FemaleWorldModelFileName = new SimpleSubrecord<String>("MOD4");
			EquipmentType = new SimpleSubrecord<EquipmentType>("ETYP");
			Data = new ArmorData("DATA");
			ExtraData = new ArmorAddonData("DNAM");
		}

		public ArmorAddon(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, BipedData BipedData, SimpleSubrecord<String> MaleBipedModelFileName, SimpleSubrecord<Byte[]> MaleBipedModelTextureHashes, AlternateTextures MaleBipedModelAlternateTextures, SimpleSubrecord<FaceGenModelFlags> MaleBipedModelFaceGenModelFlags, SimpleSubrecord<String> MaleWorldModelFileName, SimpleSubrecord<Byte[]> MaleWorldModelTextureHashes, AlternateTextures MaleWorldModelAlternateTextures, SimpleSubrecord<String> MaleInventoryIcon, SimpleSubrecord<String> MaleMessageIcon, SimpleSubrecord<String> FemaleBipedModelFileName, SimpleSubrecord<Byte[]> FemaleBipedModelTextureHashes, AlternateTextures FemaleBipedModelAlternateTextures, SimpleSubrecord<FaceGenModelFlags> FemaleBipedModelFaceGenModelFlags, SimpleSubrecord<String> FemaleWorldModelFileName, SimpleSubrecord<Byte[]> FemaleWorldModelTextureHashes, AlternateTextures FemaleWorldModelAlternateTextures, SimpleSubrecord<String> FemaleInventoryIcon, SimpleSubrecord<String> FemaleMessageIcon, SimpleSubrecord<EquipmentType> EquipmentType, ArmorData Data, ArmorAddonData ExtraData)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.BipedData = BipedData;
			this.MaleBipedModelFileName = MaleBipedModelFileName;
			this.MaleWorldModelFileName = MaleWorldModelFileName;
			this.FemaleBipedModelFileName = FemaleBipedModelFileName;
			this.FemaleWorldModelFileName = FemaleWorldModelFileName;
			this.EquipmentType = EquipmentType;
			this.Data = Data;
			this.ExtraData = ExtraData;
		}

		public ArmorAddon(ArmorAddon copyObject)
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
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "BMDT":
						if (BipedData == null)
							BipedData = new BipedData();

						BipedData.ReadBinary(reader);
						break;
					case "MODL":
						if (MaleBipedModelFileName == null)
							MaleBipedModelFileName = new SimpleSubrecord<String>();

						MaleBipedModelFileName.ReadBinary(reader);
						break;
					case "MODT":
						if (MaleBipedModelTextureHashes == null)
							MaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();

						MaleBipedModelTextureHashes.ReadBinary(reader);
						break;
					case "MODS":
						if (MaleBipedModelAlternateTextures == null)
							MaleBipedModelAlternateTextures = new AlternateTextures();

						MaleBipedModelAlternateTextures.ReadBinary(reader);
						break;
					case "MODD":
						if (MaleBipedModelFaceGenModelFlags == null)
							MaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();

						MaleBipedModelFaceGenModelFlags.ReadBinary(reader);
						break;
					case "MOD2":
						if (MaleWorldModelFileName == null)
							MaleWorldModelFileName = new SimpleSubrecord<String>();

						MaleWorldModelFileName.ReadBinary(reader);
						break;
					case "MO2T":
						if (MaleWorldModelTextureHashes == null)
							MaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();

						MaleWorldModelTextureHashes.ReadBinary(reader);
						break;
					case "MO2S":
						if (MaleWorldModelAlternateTextures == null)
							MaleWorldModelAlternateTextures = new AlternateTextures();

						MaleWorldModelAlternateTextures.ReadBinary(reader);
						break;
					case "ICON":
						if (MaleInventoryIcon == null)
							MaleInventoryIcon = new SimpleSubrecord<String>();

						MaleInventoryIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (MaleMessageIcon == null)
							MaleMessageIcon = new SimpleSubrecord<String>();

						MaleMessageIcon.ReadBinary(reader);
						break;
					case "MOD3":
						if (FemaleBipedModelFileName == null)
							FemaleBipedModelFileName = new SimpleSubrecord<String>();

						FemaleBipedModelFileName.ReadBinary(reader);
						break;
					case "MO3T":
						if (FemaleBipedModelTextureHashes == null)
							FemaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();

						FemaleBipedModelTextureHashes.ReadBinary(reader);
						break;
					case "MO3S":
						if (FemaleBipedModelAlternateTextures == null)
							FemaleBipedModelAlternateTextures = new AlternateTextures();

						FemaleBipedModelAlternateTextures.ReadBinary(reader);
						break;
					case "MOSD":
						if (FemaleBipedModelFaceGenModelFlags == null)
							FemaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();

						FemaleBipedModelFaceGenModelFlags.ReadBinary(reader);
						break;
					case "MOD4":
						if (FemaleWorldModelFileName == null)
							FemaleWorldModelFileName = new SimpleSubrecord<String>();

						FemaleWorldModelFileName.ReadBinary(reader);
						break;
					case "MO4T":
						if (FemaleWorldModelTextureHashes == null)
							FemaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();

						FemaleWorldModelTextureHashes.ReadBinary(reader);
						break;
					case "MO4S":
						if (FemaleWorldModelAlternateTextures == null)
							FemaleWorldModelAlternateTextures = new AlternateTextures();

						FemaleWorldModelAlternateTextures.ReadBinary(reader);
						break;
					case "ICO2":
						if (FemaleInventoryIcon == null)
							FemaleInventoryIcon = new SimpleSubrecord<String>();

						FemaleInventoryIcon.ReadBinary(reader);
						break;
					case "MIC2":
						if (FemaleMessageIcon == null)
							FemaleMessageIcon = new SimpleSubrecord<String>();

						FemaleMessageIcon.ReadBinary(reader);
						break;
					case "ETYP":
						if (EquipmentType == null)
							EquipmentType = new SimpleSubrecord<EquipmentType>();

						EquipmentType.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new ArmorData();

						Data.ReadBinary(reader);
						break;
					case "DNAM":
						if (ExtraData == null)
							ExtraData = new ArmorAddonData();

						ExtraData.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (BipedData != null)
				BipedData.WriteBinary(writer);
			if (MaleBipedModelFileName != null)
				MaleBipedModelFileName.WriteBinary(writer);
			if (MaleBipedModelTextureHashes != null)
				MaleBipedModelTextureHashes.WriteBinary(writer);
			if (MaleBipedModelAlternateTextures != null)
				MaleBipedModelAlternateTextures.WriteBinary(writer);
			if (MaleBipedModelFaceGenModelFlags != null)
				MaleBipedModelFaceGenModelFlags.WriteBinary(writer);
			if (MaleWorldModelFileName != null)
				MaleWorldModelFileName.WriteBinary(writer);
			if (MaleWorldModelTextureHashes != null)
				MaleWorldModelTextureHashes.WriteBinary(writer);
			if (MaleWorldModelAlternateTextures != null)
				MaleWorldModelAlternateTextures.WriteBinary(writer);
			if (MaleInventoryIcon != null)
				MaleInventoryIcon.WriteBinary(writer);
			if (MaleMessageIcon != null)
				MaleMessageIcon.WriteBinary(writer);
			if (FemaleBipedModelFileName != null)
				FemaleBipedModelFileName.WriteBinary(writer);
			if (FemaleBipedModelTextureHashes != null)
				FemaleBipedModelTextureHashes.WriteBinary(writer);
			if (FemaleBipedModelAlternateTextures != null)
				FemaleBipedModelAlternateTextures.WriteBinary(writer);
			if (FemaleBipedModelFaceGenModelFlags != null)
				FemaleBipedModelFaceGenModelFlags.WriteBinary(writer);
			if (FemaleWorldModelFileName != null)
				FemaleWorldModelFileName.WriteBinary(writer);
			if (FemaleWorldModelTextureHashes != null)
				FemaleWorldModelTextureHashes.WriteBinary(writer);
			if (FemaleWorldModelAlternateTextures != null)
				FemaleWorldModelAlternateTextures.WriteBinary(writer);
			if (FemaleInventoryIcon != null)
				FemaleInventoryIcon.WriteBinary(writer);
			if (FemaleMessageIcon != null)
				FemaleMessageIcon.WriteBinary(writer);
			if (EquipmentType != null)
				EquipmentType.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ExtraData != null)
				ExtraData.WriteBinary(writer);
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
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (BipedData != null)		
			{		
				ele.TryPathTo("BipedData", true, out subEle);
				BipedData.WriteXML(subEle, master);
			}
			if (MaleBipedModelFileName != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/FileName", true, out subEle);
				MaleBipedModelFileName.WriteXML(subEle, master);
			}
			if (MaleBipedModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/TextureHashes", true, out subEle);
				MaleBipedModelTextureHashes.WriteXML(subEle, master);
			}
			if (MaleBipedModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/AlternateTextures", true, out subEle);
				MaleBipedModelAlternateTextures.WriteXML(subEle, master);
			}
			if (MaleBipedModelFaceGenModelFlags != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/FaceGenModelFlags", true, out subEle);
				MaleBipedModelFaceGenModelFlags.WriteXML(subEle, master);
			}
			if (MaleWorldModelFileName != null)		
			{		
				ele.TryPathTo("Models/World/Male/FileName", true, out subEle);
				MaleWorldModelFileName.WriteXML(subEle, master);
			}
			if (MaleWorldModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/World/Male/TextureHashes", true, out subEle);
				MaleWorldModelTextureHashes.WriteXML(subEle, master);
			}
			if (MaleWorldModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/World/Male/AlternateTextures", true, out subEle);
				MaleWorldModelAlternateTextures.WriteXML(subEle, master);
			}
			if (MaleInventoryIcon != null)		
			{		
				ele.TryPathTo("Icon/Inventory/Male", true, out subEle);
				MaleInventoryIcon.WriteXML(subEle, master);
			}
			if (MaleMessageIcon != null)		
			{		
				ele.TryPathTo("Icon/Message/Male", true, out subEle);
				MaleMessageIcon.WriteXML(subEle, master);
			}
			if (FemaleBipedModelFileName != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/FileName", true, out subEle);
				FemaleBipedModelFileName.WriteXML(subEle, master);
			}
			if (FemaleBipedModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/TextureHashes", true, out subEle);
				FemaleBipedModelTextureHashes.WriteXML(subEle, master);
			}
			if (FemaleBipedModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/AlternateTextures", true, out subEle);
				FemaleBipedModelAlternateTextures.WriteXML(subEle, master);
			}
			if (FemaleBipedModelFaceGenModelFlags != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/FaceGenModelFlags", true, out subEle);
				FemaleBipedModelFaceGenModelFlags.WriteXML(subEle, master);
			}
			if (FemaleWorldModelFileName != null)		
			{		
				ele.TryPathTo("Models/World/Female/FileName", true, out subEle);
				FemaleWorldModelFileName.WriteXML(subEle, master);
			}
			if (FemaleWorldModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/World/Female/TextureHashes", true, out subEle);
				FemaleWorldModelTextureHashes.WriteXML(subEle, master);
			}
			if (FemaleWorldModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/World/Female/AlternateTextures", true, out subEle);
				FemaleWorldModelAlternateTextures.WriteXML(subEle, master);
			}
			if (FemaleInventoryIcon != null)		
			{		
				ele.TryPathTo("Icon/Inventory/Female", true, out subEle);
				FemaleInventoryIcon.WriteXML(subEle, master);
			}
			if (FemaleMessageIcon != null)		
			{		
				ele.TryPathTo("Icon/Message/Female", true, out subEle);
				FemaleMessageIcon.WriteXML(subEle, master);
			}
			if (EquipmentType != null)		
			{		
				ele.TryPathTo("EquipmentType", true, out subEle);
				EquipmentType.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (ExtraData != null)		
			{		
				ele.TryPathTo("ExtraData", true, out subEle);
				ExtraData.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BipedData", false, out subEle))
			{
				if (BipedData == null)
					BipedData = new BipedData();
					
				BipedData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Male/FileName", false, out subEle))
			{
				if (MaleBipedModelFileName == null)
					MaleBipedModelFileName = new SimpleSubrecord<String>();
					
				MaleBipedModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Male/TextureHashes", false, out subEle))
			{
				if (MaleBipedModelTextureHashes == null)
					MaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				MaleBipedModelTextureHashes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Male/AlternateTextures", false, out subEle))
			{
				if (MaleBipedModelAlternateTextures == null)
					MaleBipedModelAlternateTextures = new AlternateTextures();
					
				MaleBipedModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Male/FaceGenModelFlags", false, out subEle))
			{
				if (MaleBipedModelFaceGenModelFlags == null)
					MaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				MaleBipedModelFaceGenModelFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Male/FileName", false, out subEle))
			{
				if (MaleWorldModelFileName == null)
					MaleWorldModelFileName = new SimpleSubrecord<String>();
					
				MaleWorldModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Male/TextureHashes", false, out subEle))
			{
				if (MaleWorldModelTextureHashes == null)
					MaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				MaleWorldModelTextureHashes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Male/AlternateTextures", false, out subEle))
			{
				if (MaleWorldModelAlternateTextures == null)
					MaleWorldModelAlternateTextures = new AlternateTextures();
					
				MaleWorldModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Inventory/Male", false, out subEle))
			{
				if (MaleInventoryIcon == null)
					MaleInventoryIcon = new SimpleSubrecord<String>();
					
				MaleInventoryIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Message/Male", false, out subEle))
			{
				if (MaleMessageIcon == null)
					MaleMessageIcon = new SimpleSubrecord<String>();
					
				MaleMessageIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Female/FileName", false, out subEle))
			{
				if (FemaleBipedModelFileName == null)
					FemaleBipedModelFileName = new SimpleSubrecord<String>();
					
				FemaleBipedModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Female/TextureHashes", false, out subEle))
			{
				if (FemaleBipedModelTextureHashes == null)
					FemaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				FemaleBipedModelTextureHashes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Female/AlternateTextures", false, out subEle))
			{
				if (FemaleBipedModelAlternateTextures == null)
					FemaleBipedModelAlternateTextures = new AlternateTextures();
					
				FemaleBipedModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/Biped/Female/FaceGenModelFlags", false, out subEle))
			{
				if (FemaleBipedModelFaceGenModelFlags == null)
					FemaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				FemaleBipedModelFaceGenModelFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Female/FileName", false, out subEle))
			{
				if (FemaleWorldModelFileName == null)
					FemaleWorldModelFileName = new SimpleSubrecord<String>();
					
				FemaleWorldModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Female/TextureHashes", false, out subEle))
			{
				if (FemaleWorldModelTextureHashes == null)
					FemaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				FemaleWorldModelTextureHashes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models/World/Female/AlternateTextures", false, out subEle))
			{
				if (FemaleWorldModelAlternateTextures == null)
					FemaleWorldModelAlternateTextures = new AlternateTextures();
					
				FemaleWorldModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Inventory/Female", false, out subEle))
			{
				if (FemaleInventoryIcon == null)
					FemaleInventoryIcon = new SimpleSubrecord<String>();
					
				FemaleInventoryIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Message/Female", false, out subEle))
			{
				if (FemaleMessageIcon == null)
					FemaleMessageIcon = new SimpleSubrecord<String>();
					
				FemaleMessageIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EquipmentType", false, out subEle))
			{
				if (EquipmentType == null)
					EquipmentType = new SimpleSubrecord<EquipmentType>();
					
				EquipmentType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ArmorData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExtraData", false, out subEle))
			{
				if (ExtraData == null)
					ExtraData = new ArmorAddonData();
					
				ExtraData.ReadXML(subEle, master);
			}
		}		

		public ArmorAddon Clone()
		{
			return new ArmorAddon(this);
		}

	}
}