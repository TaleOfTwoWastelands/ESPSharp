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
	public partial class Armor : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public RecordReference Script { get; set; }
		public RecordReference ObjectEffect { get; set; }
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
		public SimpleSubrecord<String> RagdollConstraintTemplate { get; set; }
		public RecordReference RepairList { get; set; }
		public RecordReference BipedModelList { get; set; }
		public SimpleSubrecord<EquipmentType> EquipmentType { get; set; }
		public RecordReference PickupSound { get; set; }
		public RecordReference DropSound { get; set; }
		public ArmorData Data { get; set; }
		public ArmorExtraData ExtraData { get; set; }
		public SimpleSubrecord<NoYes> OverridesAnimationSounds { get; set; }
		public List<AnimationSound> AnimationSounds { get; set; }
		public RecordReference AnimationSoundsTemplate { get; set; }
	
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
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "EITM":
						if (ObjectEffect == null)
							ObjectEffect = new RecordReference();

						ObjectEffect.ReadBinary(reader);
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
					case "BMCT":
						if (RagdollConstraintTemplate == null)
							RagdollConstraintTemplate = new SimpleSubrecord<String>();

						RagdollConstraintTemplate.ReadBinary(reader);
						break;
					case "REPL":
						if (RepairList == null)
							RepairList = new RecordReference();

						RepairList.ReadBinary(reader);
						break;
					case "BIPL":
						if (BipedModelList == null)
							BipedModelList = new RecordReference();

						BipedModelList.ReadBinary(reader);
						break;
					case "ETYP":
						if (EquipmentType == null)
							EquipmentType = new SimpleSubrecord<EquipmentType>();

						EquipmentType.ReadBinary(reader);
						break;
					case "YNAM":
						if (PickupSound == null)
							PickupSound = new RecordReference();

						PickupSound.ReadBinary(reader);
						break;
					case "ZNAM":
						if (DropSound == null)
							DropSound = new RecordReference();

						DropSound.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new ArmorData();

						Data.ReadBinary(reader);
						break;
					case "DNAM":
						if (ExtraData == null)
							ExtraData = new ArmorExtraData();

						ExtraData.ReadBinary(reader);
						break;
					case "BNAM":
						if (OverridesAnimationSounds == null)
							OverridesAnimationSounds = new SimpleSubrecord<NoYes>();

						OverridesAnimationSounds.ReadBinary(reader);
						break;
					case "SNAM":
						if (AnimationSounds == null)
							AnimationSounds = new List<AnimationSound>();

						AnimationSound tempSNAM = new AnimationSound();
						tempSNAM.ReadBinary(reader);
						AnimationSounds.Add(tempSNAM);
						break;
					case "TNAM":
						if (AnimationSoundsTemplate == null)
							AnimationSoundsTemplate = new RecordReference();

						AnimationSoundsTemplate.ReadBinary(reader);
						break;
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
			if (Script != null)
				Script.WriteBinary(writer);
			if (ObjectEffect != null)
				ObjectEffect.WriteBinary(writer);
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
			if (RagdollConstraintTemplate != null)
				RagdollConstraintTemplate.WriteBinary(writer);
			if (RepairList != null)
				RepairList.WriteBinary(writer);
			if (BipedModelList != null)
				BipedModelList.WriteBinary(writer);
			if (EquipmentType != null)
				EquipmentType.WriteBinary(writer);
			if (PickupSound != null)
				PickupSound.WriteBinary(writer);
			if (DropSound != null)
				DropSound.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ExtraData != null)
				ExtraData.WriteBinary(writer);
			if (OverridesAnimationSounds != null)
				OverridesAnimationSounds.WriteBinary(writer);
			if (AnimationSounds != null)
				foreach (var item in AnimationSounds)
					item.WriteBinary(writer);
			if (AnimationSoundsTemplate != null)
				AnimationSoundsTemplate.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle);
			}
			if (ObjectEffect != null)		
			{		
				ele.TryPathTo("ObjectEffect", true, out subEle);
				ObjectEffect.WriteXML(subEle);
			}
			if (BipedData != null)		
			{		
				ele.TryPathTo("BipedData", true, out subEle);
				BipedData.WriteXML(subEle);
			}
			if (MaleBipedModelFileName != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/FileName", true, out subEle);
				MaleBipedModelFileName.WriteXML(subEle);
			}
			if (MaleBipedModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/TextureHashes", true, out subEle);
				MaleBipedModelTextureHashes.WriteXML(subEle);
			}
			if (MaleBipedModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/AlternateTextures", true, out subEle);
				MaleBipedModelAlternateTextures.WriteXML(subEle);
			}
			if (MaleBipedModelFaceGenModelFlags != null)		
			{		
				ele.TryPathTo("Models/Biped/Male/FaceGenModelFlags", true, out subEle);
				MaleBipedModelFaceGenModelFlags.WriteXML(subEle);
			}
			if (MaleWorldModelFileName != null)		
			{		
				ele.TryPathTo("Models/World/Male/FileName", true, out subEle);
				MaleWorldModelFileName.WriteXML(subEle);
			}
			if (MaleWorldModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/World/Male/TextureHashes", true, out subEle);
				MaleWorldModelTextureHashes.WriteXML(subEle);
			}
			if (MaleWorldModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/World/Male/AlternateTextures", true, out subEle);
				MaleWorldModelAlternateTextures.WriteXML(subEle);
			}
			if (MaleInventoryIcon != null)		
			{		
				ele.TryPathTo("Icon/Inventory/Male", true, out subEle);
				MaleInventoryIcon.WriteXML(subEle);
			}
			if (MaleMessageIcon != null)		
			{		
				ele.TryPathTo("Icon/Message/Male", true, out subEle);
				MaleMessageIcon.WriteXML(subEle);
			}
			if (FemaleBipedModelFileName != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/FileName", true, out subEle);
				FemaleBipedModelFileName.WriteXML(subEle);
			}
			if (FemaleBipedModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/TextureHashes", true, out subEle);
				FemaleBipedModelTextureHashes.WriteXML(subEle);
			}
			if (FemaleBipedModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/AlternateTextures", true, out subEle);
				FemaleBipedModelAlternateTextures.WriteXML(subEle);
			}
			if (FemaleBipedModelFaceGenModelFlags != null)		
			{		
				ele.TryPathTo("Models/Biped/Female/FaceGenModelFlags", true, out subEle);
				FemaleBipedModelFaceGenModelFlags.WriteXML(subEle);
			}
			if (FemaleWorldModelFileName != null)		
			{		
				ele.TryPathTo("Models/World/Female/FileName", true, out subEle);
				FemaleWorldModelFileName.WriteXML(subEle);
			}
			if (FemaleWorldModelTextureHashes != null)		
			{		
				ele.TryPathTo("Models/World/Female/TextureHashes", true, out subEle);
				FemaleWorldModelTextureHashes.WriteXML(subEle);
			}
			if (FemaleWorldModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Models/World/Female/AlternateTextures", true, out subEle);
				FemaleWorldModelAlternateTextures.WriteXML(subEle);
			}
			if (FemaleInventoryIcon != null)		
			{		
				ele.TryPathTo("Icon/Inventory/Female", true, out subEle);
				FemaleInventoryIcon.WriteXML(subEle);
			}
			if (FemaleMessageIcon != null)		
			{		
				ele.TryPathTo("Icon/Message/Female", true, out subEle);
				FemaleMessageIcon.WriteXML(subEle);
			}
			if (RagdollConstraintTemplate != null)		
			{		
				ele.TryPathTo("RagdollConstraintTemplate", true, out subEle);
				RagdollConstraintTemplate.WriteXML(subEle);
			}
			if (RepairList != null)		
			{		
				ele.TryPathTo("RepairList", true, out subEle);
				RepairList.WriteXML(subEle);
			}
			if (BipedModelList != null)		
			{		
				ele.TryPathTo("BipedModelList", true, out subEle);
				BipedModelList.WriteXML(subEle);
			}
			if (EquipmentType != null)		
			{		
				ele.TryPathTo("EquipmentType", true, out subEle);
				EquipmentType.WriteXML(subEle);
			}
			if (PickupSound != null)		
			{		
				ele.TryPathTo("PickupSound", true, out subEle);
				PickupSound.WriteXML(subEle);
			}
			if (DropSound != null)		
			{		
				ele.TryPathTo("DropSound", true, out subEle);
				DropSound.WriteXML(subEle);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (ExtraData != null)		
			{		
				ele.TryPathTo("ExtraData", true, out subEle);
				ExtraData.WriteXML(subEle);
			}
			if (OverridesAnimationSounds != null)		
			{		
				ele.TryPathTo("OverridesAnimationSounds", true, out subEle);
				OverridesAnimationSounds.WriteXML(subEle);
			}
			if (AnimationSounds != null)		
			{		
				ele.TryPathTo("AnimationSounds", true, out subEle);
				List<string> xmlNames = new List<string>{"Sound"};
				int i = 0;
				foreach (var entry in AnimationSounds)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle);
					subEle.Add(newEle);
					i++;
				}
			}
			if (AnimationSoundsTemplate != null)		
			{		
				ele.TryPathTo("AnimationSoundsTemplate", true, out subEle);
				AnimationSoundsTemplate.WriteXML(subEle);
			}
		}

		public override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle);
			}
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle);
			}
			if (ele.TryPathTo("ObjectEffect", false, out subEle))
			{
				if (ObjectEffect == null)
					ObjectEffect = new RecordReference();
					
				ObjectEffect.ReadXML(subEle);
			}
			if (ele.TryPathTo("BipedData", false, out subEle))
			{
				if (BipedData == null)
					BipedData = new BipedData();
					
				BipedData.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Male/FileName", false, out subEle))
			{
				if (MaleBipedModelFileName == null)
					MaleBipedModelFileName = new SimpleSubrecord<String>();
					
				MaleBipedModelFileName.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Male/TextureHashes", false, out subEle))
			{
				if (MaleBipedModelTextureHashes == null)
					MaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				MaleBipedModelTextureHashes.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Male/AlternateTextures", false, out subEle))
			{
				if (MaleBipedModelAlternateTextures == null)
					MaleBipedModelAlternateTextures = new AlternateTextures();
					
				MaleBipedModelAlternateTextures.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Male/FaceGenModelFlags", false, out subEle))
			{
				if (MaleBipedModelFaceGenModelFlags == null)
					MaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				MaleBipedModelFaceGenModelFlags.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Male/FileName", false, out subEle))
			{
				if (MaleWorldModelFileName == null)
					MaleWorldModelFileName = new SimpleSubrecord<String>();
					
				MaleWorldModelFileName.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Male/TextureHashes", false, out subEle))
			{
				if (MaleWorldModelTextureHashes == null)
					MaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				MaleWorldModelTextureHashes.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Male/AlternateTextures", false, out subEle))
			{
				if (MaleWorldModelAlternateTextures == null)
					MaleWorldModelAlternateTextures = new AlternateTextures();
					
				MaleWorldModelAlternateTextures.ReadXML(subEle);
			}
			if (ele.TryPathTo("Icon/Inventory/Male", false, out subEle))
			{
				if (MaleInventoryIcon == null)
					MaleInventoryIcon = new SimpleSubrecord<String>();
					
				MaleInventoryIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("Icon/Message/Male", false, out subEle))
			{
				if (MaleMessageIcon == null)
					MaleMessageIcon = new SimpleSubrecord<String>();
					
				MaleMessageIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Female/FileName", false, out subEle))
			{
				if (FemaleBipedModelFileName == null)
					FemaleBipedModelFileName = new SimpleSubrecord<String>();
					
				FemaleBipedModelFileName.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Female/TextureHashes", false, out subEle))
			{
				if (FemaleBipedModelTextureHashes == null)
					FemaleBipedModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				FemaleBipedModelTextureHashes.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Female/AlternateTextures", false, out subEle))
			{
				if (FemaleBipedModelAlternateTextures == null)
					FemaleBipedModelAlternateTextures = new AlternateTextures();
					
				FemaleBipedModelAlternateTextures.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/Biped/Female/FaceGenModelFlags", false, out subEle))
			{
				if (FemaleBipedModelFaceGenModelFlags == null)
					FemaleBipedModelFaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				FemaleBipedModelFaceGenModelFlags.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Female/FileName", false, out subEle))
			{
				if (FemaleWorldModelFileName == null)
					FemaleWorldModelFileName = new SimpleSubrecord<String>();
					
				FemaleWorldModelFileName.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Female/TextureHashes", false, out subEle))
			{
				if (FemaleWorldModelTextureHashes == null)
					FemaleWorldModelTextureHashes = new SimpleSubrecord<Byte[]>();
					
				FemaleWorldModelTextureHashes.ReadXML(subEle);
			}
			if (ele.TryPathTo("Models/World/Female/AlternateTextures", false, out subEle))
			{
				if (FemaleWorldModelAlternateTextures == null)
					FemaleWorldModelAlternateTextures = new AlternateTextures();
					
				FemaleWorldModelAlternateTextures.ReadXML(subEle);
			}
			if (ele.TryPathTo("Icon/Inventory/Female", false, out subEle))
			{
				if (FemaleInventoryIcon == null)
					FemaleInventoryIcon = new SimpleSubrecord<String>();
					
				FemaleInventoryIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("Icon/Message/Female", false, out subEle))
			{
				if (FemaleMessageIcon == null)
					FemaleMessageIcon = new SimpleSubrecord<String>();
					
				FemaleMessageIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("RagdollConstraintTemplate", false, out subEle))
			{
				if (RagdollConstraintTemplate == null)
					RagdollConstraintTemplate = new SimpleSubrecord<String>();
					
				RagdollConstraintTemplate.ReadXML(subEle);
			}
			if (ele.TryPathTo("RepairList", false, out subEle))
			{
				if (RepairList == null)
					RepairList = new RecordReference();
					
				RepairList.ReadXML(subEle);
			}
			if (ele.TryPathTo("BipedModelList", false, out subEle))
			{
				if (BipedModelList == null)
					BipedModelList = new RecordReference();
					
				BipedModelList.ReadXML(subEle);
			}
			if (ele.TryPathTo("EquipmentType", false, out subEle))
			{
				if (EquipmentType == null)
					EquipmentType = new SimpleSubrecord<EquipmentType>();
					
				EquipmentType.ReadXML(subEle);
			}
			if (ele.TryPathTo("PickupSound", false, out subEle))
			{
				if (PickupSound == null)
					PickupSound = new RecordReference();
					
				PickupSound.ReadXML(subEle);
			}
			if (ele.TryPathTo("DropSound", false, out subEle))
			{
				if (DropSound == null)
					DropSound = new RecordReference();
					
				DropSound.ReadXML(subEle);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ArmorData();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("ExtraData", false, out subEle))
			{
				if (ExtraData == null)
					ExtraData = new ArmorExtraData();
					
				ExtraData.ReadXML(subEle);
			}
			if (ele.TryPathTo("OverridesAnimationSounds", false, out subEle))
			{
				if (OverridesAnimationSounds == null)
					OverridesAnimationSounds = new SimpleSubrecord<NoYes>();
					
				OverridesAnimationSounds.ReadXML(subEle);
			}
			if (ele.TryPathTo("AnimationSounds", false, out subEle))
			{
				if (AnimationSounds == null)
					AnimationSounds = new List<AnimationSound>();
					
				foreach (XElement e in subEle.Elements())
				{
					AnimationSound tempSNAM = new AnimationSound();
					tempSNAM.ReadXML(e);
					AnimationSounds.Add(tempSNAM);
				}
			}
			if (ele.TryPathTo("AnimationSoundsTemplate", false, out subEle))
			{
				if (AnimationSoundsTemplate == null)
					AnimationSoundsTemplate = new RecordReference();
					
				AnimationSoundsTemplate.ReadXML(subEle);
			}
		}

	}
}
