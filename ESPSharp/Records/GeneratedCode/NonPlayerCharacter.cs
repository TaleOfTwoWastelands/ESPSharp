
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
	public partial class NonPlayerCharacter : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public NPCBaseStats BaseStats { get; set; }
		public List<FactionMembership> Factions { get; set; }
		public RecordReference DeathItem { get; set; }
		public RecordReference VoiceType { get; set; }
		public RecordReference Template { get; set; }
		public RecordReference Race { get; set; }
		public List<RecordReference> ActorEffects { get; set; }
		public RecordReference UnarmedAttackEffect { get; set; }
		public SimpleSubrecord<UInt16> UnarmedAttackAnimation { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference Script { get; set; }
		public List<InventoryItem> Contents { get; set; }
		public AIData AIData { get; set; }
		public List<RecordReference> Packages { get; set; }
		public RecordReference Class { get; set; }
		public NPCData Data { get; set; }
		public NPCSkills Skills { get; set; }
		public List<RecordReference> HeadParts { get; set; }
		public RecordReference HairType { get; set; }
		public SimpleSubrecord<Single> HairLength { get; set; }
		public RecordReference Eyes { get; set; }
		public SimpleSubrecord<Color> HairColor { get; set; }
		public RecordReference CombatStyle { get; set; }
		public SimpleSubrecord<MaterialTypeUInt> ImpactMaterialType { get; set; }
		public SimpleSubrecord<Byte[]> FaceGenGeometrySymmetric { get; set; }
		public SimpleSubrecord<Byte[]> FaceGenGeometryAsymmetric { get; set; }
		public SimpleSubrecord<Byte[]> FaceGenTexture { get; set; }
		public SimpleSubrecord<UInt16> Unknown { get; set; }
		public SimpleSubrecord<Single> Height { get; set; }
		public SimpleSubrecord<Single> Weight { get; set; }

		public NonPlayerCharacter()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
			BaseStats = new NPCBaseStats("ACBS");
			VoiceType = new RecordReference("VTCK");
			Race = new RecordReference("RNAM");
			UnarmedAttackAnimation = new SimpleSubrecord<UInt16>("EAMT");
			AIData = new AIData("AIDT");
			Class = new RecordReference("CNAM");
			Data = new NPCData("DATA");
			HairColor = new SimpleSubrecord<Color>("HCLR");
			ImpactMaterialType = new SimpleSubrecord<MaterialTypeUInt>("NAM4");
			FaceGenGeometrySymmetric = new SimpleSubrecord<byte[]>("FGGS", new byte[4]);
			FaceGenGeometryAsymmetric = new SimpleSubrecord<byte[]>("FGGA", new byte[4]);
			FaceGenTexture = new SimpleSubrecord<byte[]>("FGTS", new byte[4]);
			Unknown = new SimpleSubrecord<UInt16>("NAM5");
			Height = new SimpleSubrecord<Single>("NAM6");
			Weight = new SimpleSubrecord<Single>("NAM7");
		}

		public NonPlayerCharacter(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, NPCBaseStats BaseStats, List<FactionMembership> Factions, RecordReference DeathItem, RecordReference VoiceType, RecordReference Template, RecordReference Race, List<RecordReference> ActorEffects, RecordReference UnarmedAttackEffect, SimpleSubrecord<UInt16> UnarmedAttackAnimation, Destructable Destructable, RecordReference Script, List<InventoryItem> Contents, AIData AIData, List<RecordReference> Packages, RecordReference Class, NPCData Data, NPCSkills Skills, List<RecordReference> HeadParts, RecordReference HairType, SimpleSubrecord<Single> HairLength, RecordReference Eyes, SimpleSubrecord<Color> HairColor, RecordReference CombatStyle, SimpleSubrecord<MaterialTypeUInt> ImpactMaterialType, SimpleSubrecord<Byte[]> FaceGenGeometrySymmetric, SimpleSubrecord<Byte[]> FaceGenGeometryAsymmetric, SimpleSubrecord<Byte[]> FaceGenTexture, SimpleSubrecord<UInt16> Unknown, SimpleSubrecord<Single> Height, SimpleSubrecord<Single> Weight)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
			this.BaseStats = BaseStats;
			this.VoiceType = VoiceType;
			this.Race = Race;
			this.UnarmedAttackAnimation = UnarmedAttackAnimation;
			this.AIData = AIData;
			this.Class = Class;
			this.Data = Data;
			this.HairColor = HairColor;
			this.ImpactMaterialType = ImpactMaterialType;
			this.FaceGenGeometrySymmetric = FaceGenGeometrySymmetric;
			this.FaceGenGeometryAsymmetric = FaceGenGeometryAsymmetric;
			this.FaceGenTexture = FaceGenTexture;
			this.Unknown = Unknown;
			this.Height = Height;
			this.Weight = Weight;
		}

		public NonPlayerCharacter(NonPlayerCharacter copyObject)
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "ACBS":
						if (BaseStats == null)
							BaseStats = new NPCBaseStats();

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
					case "RNAM":
						if (Race == null)
							Race = new RecordReference();

						Race.ReadBinary(reader);
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
					case "CNAM":
						if (Class == null)
							Class = new RecordReference();

						Class.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new NPCData();

						Data.ReadBinary(reader);
						break;
					case "DNAM":
						if (Skills == null)
							Skills = new NPCSkills();

						Skills.ReadBinary(reader);
						break;
					case "PNAM":
						if (HeadParts == null)
							HeadParts = new List<RecordReference>();

						RecordReference tempPNAM = new RecordReference();
						tempPNAM.ReadBinary(reader);
						HeadParts.Add(tempPNAM);
						break;
					case "HNAM":
						if (HairType == null)
							HairType = new RecordReference();

						HairType.ReadBinary(reader);
						break;
					case "LNAM":
						if (HairLength == null)
							HairLength = new SimpleSubrecord<Single>();

						HairLength.ReadBinary(reader);
						break;
					case "ENAM":
						if (Eyes == null)
							Eyes = new RecordReference();

						Eyes.ReadBinary(reader);
						break;
					case "HCLR":
						if (HairColor == null)
							HairColor = new SimpleSubrecord<Color>();

						HairColor.ReadBinary(reader);
						break;
					case "ZNAM":
						if (CombatStyle == null)
							CombatStyle = new RecordReference();

						CombatStyle.ReadBinary(reader);
						break;
					case "NAM4":
						if (ImpactMaterialType == null)
							ImpactMaterialType = new SimpleSubrecord<MaterialTypeUInt>();

						ImpactMaterialType.ReadBinary(reader);
						break;
					case "FGGS":
						if (FaceGenGeometrySymmetric == null)
							FaceGenGeometrySymmetric = new SimpleSubrecord<Byte[]>();

						FaceGenGeometrySymmetric.ReadBinary(reader);
						break;
					case "FGGA":
						if (FaceGenGeometryAsymmetric == null)
							FaceGenGeometryAsymmetric = new SimpleSubrecord<Byte[]>();

						FaceGenGeometryAsymmetric.ReadBinary(reader);
						break;
					case "FGTS":
						if (FaceGenTexture == null)
							FaceGenTexture = new SimpleSubrecord<Byte[]>();

						FaceGenTexture.ReadBinary(reader);
						break;
					case "NAM5":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<UInt16>();

						Unknown.ReadBinary(reader);
						break;
					case "NAM6":
						if (Height == null)
							Height = new SimpleSubrecord<Single>();

						Height.ReadBinary(reader);
						break;
					case "NAM7":
						if (Weight == null)
							Weight = new SimpleSubrecord<Single>();

						Weight.ReadBinary(reader);
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
			if (BaseStats != null)
				BaseStats.WriteBinary(writer);
			if (Factions != null)
			{
				Factions.Sort();
				foreach (var item in Factions)
					item.WriteBinary(writer);
			}
			if (DeathItem != null)
				DeathItem.WriteBinary(writer);
			if (VoiceType != null)
				VoiceType.WriteBinary(writer);
			if (Template != null)
				Template.WriteBinary(writer);
			if (Race != null)
				Race.WriteBinary(writer);
			if (ActorEffects != null)
			{
				ActorEffects.Sort();
				foreach (var item in ActorEffects)
					item.WriteBinary(writer);
			}
			if (UnarmedAttackEffect != null)
				UnarmedAttackEffect.WriteBinary(writer);
			if (UnarmedAttackAnimation != null)
				UnarmedAttackAnimation.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Contents != null)
			{
				Contents.Sort();
				foreach (var item in Contents)
					item.WriteBinary(writer);
			}
			if (AIData != null)
				AIData.WriteBinary(writer);
			if (Packages != null)
				foreach (var item in Packages)
					item.WriteBinary(writer);
			if (Class != null)
				Class.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Skills != null)
				Skills.WriteBinary(writer);
			if (HeadParts != null)
			{
				HeadParts.Sort();
				foreach (var item in HeadParts)
					item.WriteBinary(writer);
			}
			if (HairType != null)
				HairType.WriteBinary(writer);
			if (HairLength != null)
				HairLength.WriteBinary(writer);
			if (Eyes != null)
				Eyes.WriteBinary(writer);
			if (HairColor != null)
				HairColor.WriteBinary(writer);
			if (CombatStyle != null)
				CombatStyle.WriteBinary(writer);
			if (ImpactMaterialType != null)
				ImpactMaterialType.WriteBinary(writer);
			if (FaceGenGeometrySymmetric != null)
				FaceGenGeometrySymmetric.WriteBinary(writer);
			if (FaceGenGeometryAsymmetric != null)
				FaceGenGeometryAsymmetric.WriteBinary(writer);
			if (FaceGenTexture != null)
				FaceGenTexture.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (Height != null)
				Height.WriteBinary(writer);
			if (Weight != null)
				Weight.WriteBinary(writer);
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
				Factions.Sort();
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
			if (Race != null)		
			{		
				ele.TryPathTo("Race", true, out subEle);
				Race.WriteXML(subEle, master);
			}
			if (ActorEffects != null)		
			{		
				ele.TryPathTo("ActorEffects", true, out subEle);
				List<string> xmlNames = new List<string>{"ActorEffect"};
				int i = 0;
				ActorEffects.Sort();
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
				Contents.Sort();
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
			if (Class != null)		
			{		
				ele.TryPathTo("Class", true, out subEle);
				Class.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Skills != null)		
			{		
				ele.TryPathTo("Skills", true, out subEle);
				Skills.WriteXML(subEle, master);
			}
			if (HeadParts != null)		
			{		
				ele.TryPathTo("HeadParts", true, out subEle);
				List<string> xmlNames = new List<string>{"HeadPart"};
				int i = 0;
				HeadParts.Sort();
				foreach (var entry in HeadParts)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (HairType != null)		
			{		
				ele.TryPathTo("Hair/Type", true, out subEle);
				HairType.WriteXML(subEle, master);
			}
			if (HairLength != null)		
			{		
				ele.TryPathTo("Hair/Length", true, out subEle);
				HairLength.WriteXML(subEle, master);
			}
			if (Eyes != null)		
			{		
				ele.TryPathTo("Eyes", true, out subEle);
				Eyes.WriteXML(subEle, master);
			}
			if (HairColor != null)		
			{		
				ele.TryPathTo("Hair/Color", true, out subEle);
				HairColor.WriteXML(subEle, master);
			}
			if (CombatStyle != null)		
			{		
				ele.TryPathTo("CombatStyle", true, out subEle);
				CombatStyle.WriteXML(subEle, master);
			}
			if (ImpactMaterialType != null)		
			{		
				ele.TryPathTo("ImpactMaterialType", true, out subEle);
				ImpactMaterialType.WriteXML(subEle, master);
			}
			if (FaceGenGeometrySymmetric != null)		
			{		
				ele.TryPathTo("FaceGen/Geometry/Symmetric", true, out subEle);
				FaceGenGeometrySymmetric.WriteXML(subEle, master);
			}
			if (FaceGenGeometryAsymmetric != null)		
			{		
				ele.TryPathTo("FaceGen/Geometry/Asymmetric", true, out subEle);
				FaceGenGeometryAsymmetric.WriteXML(subEle, master);
			}
			if (FaceGenTexture != null)		
			{		
				ele.TryPathTo("FaceGen/Texture", true, out subEle);
				FaceGenTexture.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (Height != null)		
			{		
				ele.TryPathTo("Height", true, out subEle);
				Height.WriteXML(subEle, master);
			}
			if (Weight != null)		
			{		
				ele.TryPathTo("Weight", true, out subEle);
				Weight.WriteXML(subEle, master);
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
			if (ele.TryPathTo("BaseStats", false, out subEle))
			{
				if (BaseStats == null)
					BaseStats = new NPCBaseStats();
					
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
			if (ele.TryPathTo("Race", false, out subEle))
			{
				if (Race == null)
					Race = new RecordReference();
					
				Race.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Class", false, out subEle))
			{
				if (Class == null)
					Class = new RecordReference();
					
				Class.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new NPCData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Skills", false, out subEle))
			{
				if (Skills == null)
					Skills = new NPCSkills();
					
				Skills.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HeadParts", false, out subEle))
			{
				if (HeadParts == null)
					HeadParts = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempPNAM = new RecordReference();
					tempPNAM.ReadXML(e, master);
					HeadParts.Add(tempPNAM);
				}
			}
			if (ele.TryPathTo("Hair/Type", false, out subEle))
			{
				if (HairType == null)
					HairType = new RecordReference();
					
				HairType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Hair/Length", false, out subEle))
			{
				if (HairLength == null)
					HairLength = new SimpleSubrecord<Single>();
					
				HairLength.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Eyes", false, out subEle))
			{
				if (Eyes == null)
					Eyes = new RecordReference();
					
				Eyes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Hair/Color", false, out subEle))
			{
				if (HairColor == null)
					HairColor = new SimpleSubrecord<Color>();
					
				HairColor.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CombatStyle", false, out subEle))
			{
				if (CombatStyle == null)
					CombatStyle = new RecordReference();
					
				CombatStyle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImpactMaterialType", false, out subEle))
			{
				if (ImpactMaterialType == null)
					ImpactMaterialType = new SimpleSubrecord<MaterialTypeUInt>();
					
				ImpactMaterialType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Geometry/Symmetric", false, out subEle))
			{
				if (FaceGenGeometrySymmetric == null)
					FaceGenGeometrySymmetric = new SimpleSubrecord<Byte[]>();
					
				FaceGenGeometrySymmetric.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Geometry/Asymmetric", false, out subEle))
			{
				if (FaceGenGeometryAsymmetric == null)
					FaceGenGeometryAsymmetric = new SimpleSubrecord<Byte[]>();
					
				FaceGenGeometryAsymmetric.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Texture", false, out subEle))
			{
				if (FaceGenTexture == null)
					FaceGenTexture = new SimpleSubrecord<Byte[]>();
					
				FaceGenTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<UInt16>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Height", false, out subEle))
			{
				if (Height == null)
					Height = new SimpleSubrecord<Single>();
					
				Height.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Weight", false, out subEle))
			{
				if (Weight == null)
					Weight = new SimpleSubrecord<Single>();
					
				Weight.ReadXML(subEle, master);
			}
		}		

		public NonPlayerCharacter Clone()
		{
			return new NonPlayerCharacter(this);
		}

	}
}