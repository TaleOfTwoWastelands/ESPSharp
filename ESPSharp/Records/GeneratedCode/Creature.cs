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
	public partial class Creature : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public List<RecordReference> ActorEffects { get; set; }
		public RecordReference UnarmedAttackEffect { get; set; }
		public SimpleSubrecord<UInt16> UnarmedAttackAnimation { get; set; }
		public SubNullStringList Models { get; set; }
		public SimpleSubrecord<Byte[]> TextureHashes { get; set; }
		public CreatureBaseStats BaseStats { get; set; }
		public List<FactionMembership> Factions { get; set; }
		public RecordReference DeathItem { get; set; }
		public RecordReference VoiceType { get; set; }
		public RecordReference Template { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference Script { get; set; }
		public List<InventoryItem> Contents { get; set; }
		public AIData AIData { get; set; }
		public List<RecordReference> Packages { get; set; }
		public SubNullStringList Animations { get; set; }
		public CreatureData Data { get; set; }
		public SimpleSubrecord<Byte> AttackReach { get; set; }
		public RecordReference CombatStyle { get; set; }
		public RecordReference BodyPartData { get; set; }
		public SimpleSubrecord<Single> TurningSpeed { get; set; }
		public SimpleSubrecord<Single> BaseScale { get; set; }
		public SimpleSubrecord<Single> FootWeight { get; set; }
		public SimpleSubrecord<MaterialTypeUInt> ImpactMaterialType { get; set; }
		public SimpleSubrecord<SoundLevel> SoundLevel { get; set; }
		public RecordReference SoundTemplate { get; set; }
		public List<CreatureSoundData> SoundData { get; set; }
		public RecordReference ImpactDataset { get; set; }
		public RecordReference MeleeWeaponList { get; set; }
	
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "SPLO":
						if (ActorEffects == null)
							ActorEffects = new List<RecordReference>();

						RecordReference tempSPLO = new RecordReference();
						tempSPLO.ReadBinary(reader);
						ActorEffects.Add(tempSPLO);
						break;
					case "EITM":
						if (UnarmedAttackEffect == null)
							UnarmedAttackEffect = new RecordReference();

						UnarmedAttackEffect.ReadBinary(reader);
						break;
					case "EAMT":
						if (UnarmedAttackAnimation == null)
							UnarmedAttackAnimation = new SimpleSubrecord<UInt16>();

						UnarmedAttackAnimation.ReadBinary(reader);
						break;
					case "NIFZ":
						if (Models == null)
							Models = new SubNullStringList();

						Models.ReadBinary(reader);
						break;
					case "NIFT":
						if (TextureHashes == null)
							TextureHashes = new SimpleSubrecord<Byte[]>();

						TextureHashes.ReadBinary(reader);
						break;
					case "ACBS":
						if (BaseStats == null)
							BaseStats = new CreatureBaseStats();

						BaseStats.ReadBinary(reader);
						break;
					case "SNAM":
						if (Factions == null)
							Factions = new List<FactionMembership>();

						FactionMembership tempSNAM = new FactionMembership();
						tempSNAM.ReadBinary(reader);
						Factions.Add(tempSNAM);
						break;
					case "INAM":
						if (DeathItem == null)
							DeathItem = new RecordReference();

						DeathItem.ReadBinary(reader);
						break;
					case "VTCK":
						if (VoiceType == null)
							VoiceType = new RecordReference();

						VoiceType.ReadBinary(reader);
						break;
					case "TPLT":
						if (Template == null)
							Template = new RecordReference();

						Template.ReadBinary(reader);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "CNTO":
						if (Contents == null)
							Contents = new List<InventoryItem>();

						InventoryItem tempCNTO = new InventoryItem();
						tempCNTO.ReadBinary(reader);
						Contents.Add(tempCNTO);
						break;
					case "AIDT":
						if (AIData == null)
							AIData = new AIData();

						AIData.ReadBinary(reader);
						break;
					case "PKID":
						if (Packages == null)
							Packages = new List<RecordReference>();

						RecordReference tempPKID = new RecordReference();
						tempPKID.ReadBinary(reader);
						Packages.Add(tempPKID);
						break;
					case "KFFZ":
						if (Animations == null)
							Animations = new SubNullStringList();

						Animations.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new CreatureData();

						Data.ReadBinary(reader);
						break;
					case "RNAM":
						if (AttackReach == null)
							AttackReach = new SimpleSubrecord<Byte>();

						AttackReach.ReadBinary(reader);
						break;
					case "ZNAM":
						if (CombatStyle == null)
							CombatStyle = new RecordReference();

						CombatStyle.ReadBinary(reader);
						break;
					case "PNAM":
						if (BodyPartData == null)
							BodyPartData = new RecordReference();

						BodyPartData.ReadBinary(reader);
						break;
					case "TNAM":
						if (TurningSpeed == null)
							TurningSpeed = new SimpleSubrecord<Single>();

						TurningSpeed.ReadBinary(reader);
						break;
					case "BNAM":
						if (BaseScale == null)
							BaseScale = new SimpleSubrecord<Single>();

						BaseScale.ReadBinary(reader);
						break;
					case "WNAM":
						if (FootWeight == null)
							FootWeight = new SimpleSubrecord<Single>();

						FootWeight.ReadBinary(reader);
						break;
					case "NAM4":
						if (ImpactMaterialType == null)
							ImpactMaterialType = new SimpleSubrecord<MaterialTypeUInt>();

						ImpactMaterialType.ReadBinary(reader);
						break;
					case "NAM5":
						if (SoundLevel == null)
							SoundLevel = new SimpleSubrecord<SoundLevel>();

						SoundLevel.ReadBinary(reader);
						break;
					case "CSCR":
						if (SoundTemplate == null)
							SoundTemplate = new RecordReference();

						SoundTemplate.ReadBinary(reader);
						break;
					case "CSDT":
						if (SoundData == null)
							SoundData = new List<CreatureSoundData>();

						CreatureSoundData tempCSDT = new CreatureSoundData();
						tempCSDT.ReadBinary(reader);
						SoundData.Add(tempCSDT);
						break;
					case "CNAM":
						if (ImpactDataset == null)
							ImpactDataset = new RecordReference();

						ImpactDataset.ReadBinary(reader);
						break;
					case "LNAM":
						if (MeleeWeaponList == null)
							MeleeWeaponList = new RecordReference();

						MeleeWeaponList.ReadBinary(reader);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (ActorEffects != null)
				foreach (var item in ActorEffects)
					item.WriteBinary(writer);
			if (UnarmedAttackEffect != null)
				UnarmedAttackEffect.WriteBinary(writer);
			if (UnarmedAttackAnimation != null)
				UnarmedAttackAnimation.WriteBinary(writer);
			if (Models != null)
				Models.WriteBinary(writer);
			if (TextureHashes != null)
				TextureHashes.WriteBinary(writer);
			if (BaseStats != null)
				BaseStats.WriteBinary(writer);
			if (Factions != null)
				foreach (var item in Factions)
					item.WriteBinary(writer);
			if (DeathItem != null)
				DeathItem.WriteBinary(writer);
			if (VoiceType != null)
				VoiceType.WriteBinary(writer);
			if (Template != null)
				Template.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Contents != null)
				foreach (var item in Contents)
					item.WriteBinary(writer);
			if (AIData != null)
				AIData.WriteBinary(writer);
			if (Packages != null)
				foreach (var item in Packages)
					item.WriteBinary(writer);
			if (Animations != null)
				Animations.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (AttackReach != null)
				AttackReach.WriteBinary(writer);
			if (CombatStyle != null)
				CombatStyle.WriteBinary(writer);
			if (BodyPartData != null)
				BodyPartData.WriteBinary(writer);
			if (TurningSpeed != null)
				TurningSpeed.WriteBinary(writer);
			if (BaseScale != null)
				BaseScale.WriteBinary(writer);
			if (FootWeight != null)
				FootWeight.WriteBinary(writer);
			if (ImpactMaterialType != null)
				ImpactMaterialType.WriteBinary(writer);
			if (SoundLevel != null)
				SoundLevel.WriteBinary(writer);
			if (SoundTemplate != null)
				SoundTemplate.WriteBinary(writer);
			if (SoundData != null)
				foreach (var item in SoundData)
					item.WriteBinary(writer);
			if (ImpactDataset != null)
				ImpactDataset.WriteBinary(writer);
			if (MeleeWeaponList != null)
				MeleeWeaponList.WriteBinary(writer);
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
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (ActorEffects != null)		
			{		
				ele.TryPathTo("ActorEffects", true, out subEle);
				List<string> xmlNames = new List<string>{"ActorEffect"};
				int i = 0;
				foreach (var entry in ActorEffects)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (UnarmedAttackEffect != null)		
			{		
				ele.TryPathTo("Unarmed/AttackEffect", true, out subEle);
				UnarmedAttackEffect.WriteXML(subEle, master);
			}
			if (UnarmedAttackAnimation != null)		
			{		
				ele.TryPathTo("Unarmed/AttackAnimation", true, out subEle);
				UnarmedAttackAnimation.WriteXML(subEle, master);
			}
			if (Models != null)		
			{		
				ele.TryPathTo("Models", true, out subEle);
				Models.WriteXML(subEle, master);
			}
			if (TextureHashes != null)		
			{		
				ele.TryPathTo("TextureHashes", true, out subEle);
				TextureHashes.WriteXML(subEle, master);
			}
			if (BaseStats != null)		
			{		
				ele.TryPathTo("BaseStats", true, out subEle);
				BaseStats.WriteXML(subEle, master);
			}
			if (Factions != null)		
			{		
				ele.TryPathTo("Factions", true, out subEle);
				List<string> xmlNames = new List<string>{"Faction"};
				int i = 0;
				foreach (var entry in Factions)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (DeathItem != null)		
			{		
				ele.TryPathTo("DeathItem", true, out subEle);
				DeathItem.WriteXML(subEle, master);
			}
			if (VoiceType != null)		
			{		
				ele.TryPathTo("VoiceType", true, out subEle);
				VoiceType.WriteXML(subEle, master);
			}
			if (Template != null)		
			{		
				ele.TryPathTo("Template", true, out subEle);
				Template.WriteXML(subEle, master);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Contents != null)		
			{		
				ele.TryPathTo("Contents", true, out subEle);
				List<string> xmlNames = new List<string>{"Item"};
				int i = 0;
				foreach (var entry in Contents)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (AIData != null)		
			{		
				ele.TryPathTo("AIData", true, out subEle);
				AIData.WriteXML(subEle, master);
			}
			if (Packages != null)		
			{		
				ele.TryPathTo("Packages", true, out subEle);
				List<string> xmlNames = new List<string>{"Package"};
				int i = 0;
				foreach (var entry in Packages)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Animations != null)		
			{		
				ele.TryPathTo("Animations", true, out subEle);
				Animations.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (AttackReach != null)		
			{		
				ele.TryPathTo("AttackReach", true, out subEle);
				AttackReach.WriteXML(subEle, master);
			}
			if (CombatStyle != null)		
			{		
				ele.TryPathTo("CombatStyle", true, out subEle);
				CombatStyle.WriteXML(subEle, master);
			}
			if (BodyPartData != null)		
			{		
				ele.TryPathTo("BodyPartData", true, out subEle);
				BodyPartData.WriteXML(subEle, master);
			}
			if (TurningSpeed != null)		
			{		
				ele.TryPathTo("TurningSpeed", true, out subEle);
				TurningSpeed.WriteXML(subEle, master);
			}
			if (BaseScale != null)		
			{		
				ele.TryPathTo("BaseScale", true, out subEle);
				BaseScale.WriteXML(subEle, master);
			}
			if (FootWeight != null)		
			{		
				ele.TryPathTo("FootWeight", true, out subEle);
				FootWeight.WriteXML(subEle, master);
			}
			if (ImpactMaterialType != null)		
			{		
				ele.TryPathTo("ImpactMaterialType", true, out subEle);
				ImpactMaterialType.WriteXML(subEle, master);
			}
			if (SoundLevel != null)		
			{		
				ele.TryPathTo("SoundLevel", true, out subEle);
				SoundLevel.WriteXML(subEle, master);
			}
			if (SoundTemplate != null)		
			{		
				ele.TryPathTo("SoundTemplate", true, out subEle);
				SoundTemplate.WriteXML(subEle, master);
			}
			if (SoundData != null)		
			{		
				ele.TryPathTo("SoundData", true, out subEle);
				List<string> xmlNames = new List<string>{"Sound"};
				int i = 0;
				foreach (var entry in SoundData)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (ImpactDataset != null)		
			{		
				ele.TryPathTo("ImpactDataset", true, out subEle);
				ImpactDataset.WriteXML(subEle, master);
			}
			if (MeleeWeaponList != null)		
			{		
				ele.TryPathTo("MeleeWeaponList", true, out subEle);
				MeleeWeaponList.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ActorEffects", false, out subEle))
			{
				if (ActorEffects == null)
					ActorEffects = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempSPLO = new RecordReference();
					tempSPLO.ReadXML(e, master);
					ActorEffects.Add(tempSPLO);
				}
			}
			if (ele.TryPathTo("Unarmed/AttackEffect", false, out subEle))
			{
				if (UnarmedAttackEffect == null)
					UnarmedAttackEffect = new RecordReference();
					
				UnarmedAttackEffect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unarmed/AttackAnimation", false, out subEle))
			{
				if (UnarmedAttackAnimation == null)
					UnarmedAttackAnimation = new SimpleSubrecord<UInt16>();
					
				UnarmedAttackAnimation.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models", false, out subEle))
			{
				if (Models == null)
					Models = new SubNullStringList();
					
				Models.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureHashes", false, out subEle))
			{
				if (TextureHashes == null)
					TextureHashes = new SimpleSubrecord<Byte[]>();
					
				TextureHashes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BaseStats", false, out subEle))
			{
				if (BaseStats == null)
					BaseStats = new CreatureBaseStats();
					
				BaseStats.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Factions", false, out subEle))
			{
				if (Factions == null)
					Factions = new List<FactionMembership>();
					
				foreach (XElement e in subEle.Elements())
				{
					FactionMembership tempSNAM = new FactionMembership();
					tempSNAM.ReadXML(e, master);
					Factions.Add(tempSNAM);
				}
			}
			if (ele.TryPathTo("DeathItem", false, out subEle))
			{
				if (DeathItem == null)
					DeathItem = new RecordReference();
					
				DeathItem.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("VoiceType", false, out subEle))
			{
				if (VoiceType == null)
					VoiceType = new RecordReference();
					
				VoiceType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Template", false, out subEle))
			{
				if (Template == null)
					Template = new RecordReference();
					
				Template.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Contents", false, out subEle))
			{
				if (Contents == null)
					Contents = new List<InventoryItem>();
					
				foreach (XElement e in subEle.Elements())
				{
					InventoryItem tempCNTO = new InventoryItem();
					tempCNTO.ReadXML(e, master);
					Contents.Add(tempCNTO);
				}
			}
			if (ele.TryPathTo("AIData", false, out subEle))
			{
				if (AIData == null)
					AIData = new AIData();
					
				AIData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Packages", false, out subEle))
			{
				if (Packages == null)
					Packages = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempPKID = new RecordReference();
					tempPKID.ReadXML(e, master);
					Packages.Add(tempPKID);
				}
			}
			if (ele.TryPathTo("Animations", false, out subEle))
			{
				if (Animations == null)
					Animations = new SubNullStringList();
					
				Animations.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new CreatureData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AttackReach", false, out subEle))
			{
				if (AttackReach == null)
					AttackReach = new SimpleSubrecord<Byte>();
					
				AttackReach.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CombatStyle", false, out subEle))
			{
				if (CombatStyle == null)
					CombatStyle = new RecordReference();
					
				CombatStyle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BodyPartData", false, out subEle))
			{
				if (BodyPartData == null)
					BodyPartData = new RecordReference();
					
				BodyPartData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TurningSpeed", false, out subEle))
			{
				if (TurningSpeed == null)
					TurningSpeed = new SimpleSubrecord<Single>();
					
				TurningSpeed.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BaseScale", false, out subEle))
			{
				if (BaseScale == null)
					BaseScale = new SimpleSubrecord<Single>();
					
				BaseScale.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FootWeight", false, out subEle))
			{
				if (FootWeight == null)
					FootWeight = new SimpleSubrecord<Single>();
					
				FootWeight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImpactMaterialType", false, out subEle))
			{
				if (ImpactMaterialType == null)
					ImpactMaterialType = new SimpleSubrecord<MaterialTypeUInt>();
					
				ImpactMaterialType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SoundLevel", false, out subEle))
			{
				if (SoundLevel == null)
					SoundLevel = new SimpleSubrecord<SoundLevel>();
					
				SoundLevel.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SoundTemplate", false, out subEle))
			{
				if (SoundTemplate == null)
					SoundTemplate = new RecordReference();
					
				SoundTemplate.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SoundData", false, out subEle))
			{
				if (SoundData == null)
					SoundData = new List<CreatureSoundData>();
					
				foreach (XElement e in subEle.Elements())
				{
					CreatureSoundData tempCSDT = new CreatureSoundData();
					tempCSDT.ReadXML(e, master);
					SoundData.Add(tempCSDT);
				}
			}
			if (ele.TryPathTo("ImpactDataset", false, out subEle))
			{
				if (ImpactDataset == null)
					ImpactDataset = new RecordReference();
					
				ImpactDataset.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MeleeWeaponList", false, out subEle))
			{
				if (MeleeWeaponList == null)
					MeleeWeaponList = new RecordReference();
					
				MeleeWeaponList.ReadXML(subEle, master);
			}
		}

	}
}
