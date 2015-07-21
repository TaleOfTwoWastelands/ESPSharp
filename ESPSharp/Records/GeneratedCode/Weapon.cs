
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
	public partial class Weapon : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> ModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> ModelUnknown { get; set; }
		public SimpleSubrecord<Byte[]> ModelTextureFileHash { get; set; }
		public AlternateTextures ModelAlternateTextures { get; set; }
		public SimpleSubrecord<FaceGenModelFlags> FaceGenModelFlags { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public RecordReference Script { get; set; }
		public RecordReference ObjectEffect { get; set; }
		public SimpleSubrecord<UInt16> EnchantmentChargeAmount { get; set; }
		public RecordReference Ammo { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference RepairList { get; set; }
		public SimpleSubrecord<EquipmentType> EquipmentType { get; set; }
		public RecordReference BipedalModelList { get; set; }
		public RecordReference PickUpSound { get; set; }
		public RecordReference DropSound { get; set; }
		public SimpleSubrecord<String> ShellCasingModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> ShellCasingModelTextureFileHash { get; set; }
		public AlternateTextures ShellCasingModelAlternateTextures { get; set; }
		public SimpleSubrecord<String> ScopeModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> ScopeModelTextureFileHash { get; set; }
		public AlternateTextures ScopeModelAlternateTextures { get; set; }
		public RecordReference ScopeEffect { get; set; }
		public SimpleSubrecord<String> ScopeEffectModelFileName { get; set; }
		public SimpleSubrecord<Byte[]> ScopeEffectModelTextureFileHash { get; set; }
		public AlternateTextures ScopeEffectModelAlternateTextures { get; set; }
		public SimpleSubrecord<String> ModelWithMod1 { get; set; }
		public SimpleSubrecord<String> ModelWithMod2 { get; set; }
		public SimpleSubrecord<String> ModelWithMod1_2 { get; set; }
		public SimpleSubrecord<String> ModelWithMod3 { get; set; }
		public SimpleSubrecord<String> ModelWithMod1_3 { get; set; }
		public SimpleSubrecord<String> ModelWithMod2_3 { get; set; }
		public SimpleSubrecord<String> ModelWithMod1_2_3 { get; set; }
		public SimpleSubrecord<String> VATSAttackName { get; set; }
		public SimpleSubrecord<String> EmbeddedWeaponNode { get; set; }
		public RecordReference ImpactDataset { get; set; }
		public RecordReference FirstPersonModel { get; set; }
		public RecordReference FirstPersonModelWithMod1 { get; set; }
		public RecordReference FirstPersonModelWithMod2 { get; set; }
		public RecordReference FirstPersonModelWithMod1_2 { get; set; }
		public RecordReference FirstPersonModelWithMod3 { get; set; }
		public RecordReference FirstPersonModelWithMod1_3 { get; set; }
		public RecordReference FirstPersonModelWithMod2_3 { get; set; }
		public RecordReference FirstPersonModelWithMod1_2_3 { get; set; }
		public RecordReference WeaponMod1 { get; set; }
		public RecordReference WeaponMod2 { get; set; }
		public RecordReference WeaponMod3 { get; set; }
		public List<RecordReference> SoundGunShoot { get; set; }
		public RecordReference SoundGunShoot2D { get; set; }
		public RecordReference SoundGunShoot3DLooping { get; set; }
		public RecordReference SoundMeleeSwing { get; set; }
		public RecordReference SoundMeleeBlock { get; set; }
		public RecordReference SoundIdle { get; set; }
		public RecordReference SoundEquip { get; set; }
		public RecordReference SoundUnequip { get; set; }
		public List<RecordReference> SoundMod1Shoot { get; set; }
		public RecordReference SoundMod1Shoot2D { get; set; }
		public WeaponData Data { get; set; }
		public WeaponExtraData ExtraData { get; set; }
		public WeaponCriticalHitData CriticalHitData { get; set; }
		public WeaponVATSData VATSSpecialAttack { get; set; }
		public SimpleSubrecord<SoundLevel> SoundLevel { get; set; }

		public Weapon()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Data = new WeaponData("DATA");
			ExtraData = new WeaponExtraData("DNAM");
			CriticalHitData = new WeaponCriticalHitData("CRDT");
		}

		public Weapon(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, SimpleSubrecord<String> ModelFileName, SimpleSubrecord<Byte[]> ModelUnknown, SimpleSubrecord<Byte[]> ModelTextureFileHash, AlternateTextures ModelAlternateTextures, SimpleSubrecord<FaceGenModelFlags> FaceGenModelFlags, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, RecordReference Script, RecordReference ObjectEffect, SimpleSubrecord<UInt16> EnchantmentChargeAmount, RecordReference Ammo, Destructable Destructable, RecordReference RepairList, SimpleSubrecord<EquipmentType> EquipmentType, RecordReference BipedalModelList, RecordReference PickUpSound, RecordReference DropSound, SimpleSubrecord<String> ShellCasingModelFileName, SimpleSubrecord<Byte[]> ShellCasingModelTextureFileHash, AlternateTextures ShellCasingModelAlternateTextures, SimpleSubrecord<String> ScopeModelFileName, SimpleSubrecord<Byte[]> ScopeModelTextureFileHash, AlternateTextures ScopeModelAlternateTextures, RecordReference ScopeEffect, SimpleSubrecord<String> ScopeEffectModelFileName, SimpleSubrecord<Byte[]> ScopeEffectModelTextureFileHash, AlternateTextures ScopeEffectModelAlternateTextures, SimpleSubrecord<String> ModelWithMod1, SimpleSubrecord<String> ModelWithMod2, SimpleSubrecord<String> ModelWithMod1_2, SimpleSubrecord<String> ModelWithMod3, SimpleSubrecord<String> ModelWithMod1_3, SimpleSubrecord<String> ModelWithMod2_3, SimpleSubrecord<String> ModelWithMod1_2_3, SimpleSubrecord<String> VATSAttackName, SimpleSubrecord<String> EmbeddedWeaponNode, RecordReference ImpactDataset, RecordReference FirstPersonModel, RecordReference FirstPersonModelWithMod1, RecordReference FirstPersonModelWithMod2, RecordReference FirstPersonModelWithMod1_2, RecordReference FirstPersonModelWithMod3, RecordReference FirstPersonModelWithMod1_3, RecordReference FirstPersonModelWithMod2_3, RecordReference FirstPersonModelWithMod1_2_3, RecordReference WeaponMod1, RecordReference WeaponMod2, RecordReference WeaponMod3, List<RecordReference> SoundGunShoot, RecordReference SoundGunShoot2D, RecordReference SoundGunShoot3DLooping, RecordReference SoundMeleeSwing, RecordReference SoundMeleeBlock, RecordReference SoundIdle, RecordReference SoundEquip, RecordReference SoundUnequip, List<RecordReference> SoundMod1Shoot, RecordReference SoundMod1Shoot2D, WeaponData Data, WeaponExtraData ExtraData, WeaponCriticalHitData CriticalHitData, WeaponVATSData VATSSpecialAttack, SimpleSubrecord<SoundLevel> SoundLevel)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Data = Data;
			this.ExtraData = ExtraData;
			this.CriticalHitData = CriticalHitData;
		}

		public Weapon(Weapon copyObject)
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
						if (ModelFileName == null)
							ModelFileName = new SimpleSubrecord<String>();

						ModelFileName.ReadBinary(reader);
						break;
					case "MODB":
						if (ModelUnknown == null)
							ModelUnknown = new SimpleSubrecord<Byte[]>();

						ModelUnknown.ReadBinary(reader);
						break;
					case "MODT":
						if (ModelTextureFileHash == null)
							ModelTextureFileHash = new SimpleSubrecord<Byte[]>();

						ModelTextureFileHash.ReadBinary(reader);
						break;
					case "MODS":
						if (ModelAlternateTextures == null)
							ModelAlternateTextures = new AlternateTextures();

						ModelAlternateTextures.ReadBinary(reader);
						break;
					case "MODD":
						if (FaceGenModelFlags == null)
							FaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();

						FaceGenModelFlags.ReadBinary(reader);
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
					case "EAMT":
						if (EnchantmentChargeAmount == null)
							EnchantmentChargeAmount = new SimpleSubrecord<UInt16>();

						EnchantmentChargeAmount.ReadBinary(reader);
						break;
					case "NAM0":
						if (Ammo == null)
							Ammo = new RecordReference();

						Ammo.ReadBinary(reader);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "REPL":
						if (RepairList == null)
							RepairList = new RecordReference();

						RepairList.ReadBinary(reader);
						break;
					case "ETYP":
						if (EquipmentType == null)
							EquipmentType = new SimpleSubrecord<EquipmentType>();

						EquipmentType.ReadBinary(reader);
						break;
					case "BIPL":
						if (BipedalModelList == null)
							BipedalModelList = new RecordReference();

						BipedalModelList.ReadBinary(reader);
						break;
					case "YNAM":
						if (PickUpSound == null)
							PickUpSound = new RecordReference();

						PickUpSound.ReadBinary(reader);
						break;
					case "ZNAM":
						if (DropSound == null)
							DropSound = new RecordReference();

						DropSound.ReadBinary(reader);
						break;
					case "MOD2":
						if (ShellCasingModelFileName == null)
							ShellCasingModelFileName = new SimpleSubrecord<String>();

						ShellCasingModelFileName.ReadBinary(reader);
						break;
					case "MO2T":
						if (ShellCasingModelTextureFileHash == null)
							ShellCasingModelTextureFileHash = new SimpleSubrecord<Byte[]>();

						ShellCasingModelTextureFileHash.ReadBinary(reader);
						break;
					case "MO2S":
						if (ShellCasingModelAlternateTextures == null)
							ShellCasingModelAlternateTextures = new AlternateTextures();

						ShellCasingModelAlternateTextures.ReadBinary(reader);
						break;
					case "MOD3":
						if (ScopeModelFileName == null)
							ScopeModelFileName = new SimpleSubrecord<String>();

						ScopeModelFileName.ReadBinary(reader);
						break;
					case "MO3T":
						if (ScopeModelTextureFileHash == null)
							ScopeModelTextureFileHash = new SimpleSubrecord<Byte[]>();

						ScopeModelTextureFileHash.ReadBinary(reader);
						break;
					case "MO3S":
						if (ScopeModelAlternateTextures == null)
							ScopeModelAlternateTextures = new AlternateTextures();

						ScopeModelAlternateTextures.ReadBinary(reader);
						break;
					case "EFSD":
						if (ScopeEffect == null)
							ScopeEffect = new RecordReference();

						ScopeEffect.ReadBinary(reader);
						break;
					case "MOD4":
						if (ScopeEffectModelFileName == null)
							ScopeEffectModelFileName = new SimpleSubrecord<String>();

						ScopeEffectModelFileName.ReadBinary(reader);
						break;
					case "MO4T":
						if (ScopeEffectModelTextureFileHash == null)
							ScopeEffectModelTextureFileHash = new SimpleSubrecord<Byte[]>();

						ScopeEffectModelTextureFileHash.ReadBinary(reader);
						break;
					case "MO4S":
						if (ScopeEffectModelAlternateTextures == null)
							ScopeEffectModelAlternateTextures = new AlternateTextures();

						ScopeEffectModelAlternateTextures.ReadBinary(reader);
						break;
					case "MWD1":
						if (ModelWithMod1 == null)
							ModelWithMod1 = new SimpleSubrecord<String>();

						ModelWithMod1.ReadBinary(reader);
						break;
					case "MWD2":
						if (ModelWithMod2 == null)
							ModelWithMod2 = new SimpleSubrecord<String>();

						ModelWithMod2.ReadBinary(reader);
						break;
					case "MWD3":
						if (ModelWithMod1_2 == null)
							ModelWithMod1_2 = new SimpleSubrecord<String>();

						ModelWithMod1_2.ReadBinary(reader);
						break;
					case "MWD4":
						if (ModelWithMod3 == null)
							ModelWithMod3 = new SimpleSubrecord<String>();

						ModelWithMod3.ReadBinary(reader);
						break;
					case "MWD5":
						if (ModelWithMod1_3 == null)
							ModelWithMod1_3 = new SimpleSubrecord<String>();

						ModelWithMod1_3.ReadBinary(reader);
						break;
					case "MWD6":
						if (ModelWithMod2_3 == null)
							ModelWithMod2_3 = new SimpleSubrecord<String>();

						ModelWithMod2_3.ReadBinary(reader);
						break;
					case "MWD7":
						if (ModelWithMod1_2_3 == null)
							ModelWithMod1_2_3 = new SimpleSubrecord<String>();

						ModelWithMod1_2_3.ReadBinary(reader);
						break;
					case "VANM":
						if (VATSAttackName == null)
							VATSAttackName = new SimpleSubrecord<String>();

						VATSAttackName.ReadBinary(reader);
						break;
					case "NNAM":
						if (EmbeddedWeaponNode == null)
							EmbeddedWeaponNode = new SimpleSubrecord<String>();

						EmbeddedWeaponNode.ReadBinary(reader);
						break;
					case "INAM":
						if (ImpactDataset == null)
							ImpactDataset = new RecordReference();

						ImpactDataset.ReadBinary(reader);
						break;
					case "WNAM":
						if (FirstPersonModel == null)
							FirstPersonModel = new RecordReference();

						FirstPersonModel.ReadBinary(reader);
						break;
					case "WNM1":
						if (FirstPersonModelWithMod1 == null)
							FirstPersonModelWithMod1 = new RecordReference();

						FirstPersonModelWithMod1.ReadBinary(reader);
						break;
					case "WNM2":
						if (FirstPersonModelWithMod2 == null)
							FirstPersonModelWithMod2 = new RecordReference();

						FirstPersonModelWithMod2.ReadBinary(reader);
						break;
					case "WNM3":
						if (FirstPersonModelWithMod1_2 == null)
							FirstPersonModelWithMod1_2 = new RecordReference();

						FirstPersonModelWithMod1_2.ReadBinary(reader);
						break;
					case "WNM4":
						if (FirstPersonModelWithMod3 == null)
							FirstPersonModelWithMod3 = new RecordReference();

						FirstPersonModelWithMod3.ReadBinary(reader);
						break;
					case "WNM5":
						if (FirstPersonModelWithMod1_3 == null)
							FirstPersonModelWithMod1_3 = new RecordReference();

						FirstPersonModelWithMod1_3.ReadBinary(reader);
						break;
					case "WNM6":
						if (FirstPersonModelWithMod2_3 == null)
							FirstPersonModelWithMod2_3 = new RecordReference();

						FirstPersonModelWithMod2_3.ReadBinary(reader);
						break;
					case "WNM7":
						if (FirstPersonModelWithMod1_2_3 == null)
							FirstPersonModelWithMod1_2_3 = new RecordReference();

						FirstPersonModelWithMod1_2_3.ReadBinary(reader);
						break;
					case "WMI1":
						if (WeaponMod1 == null)
							WeaponMod1 = new RecordReference();

						WeaponMod1.ReadBinary(reader);
						break;
					case "WMI2":
						if (WeaponMod2 == null)
							WeaponMod2 = new RecordReference();

						WeaponMod2.ReadBinary(reader);
						break;
					case "WMI3":
						if (WeaponMod3 == null)
							WeaponMod3 = new RecordReference();

						WeaponMod3.ReadBinary(reader);
						break;
					case "SNAM":
						if (SoundGunShoot == null)
							SoundGunShoot = new List<RecordReference>();

						RecordReference tempSNAM = new RecordReference();
						tempSNAM.ReadBinary(reader);
						SoundGunShoot.Add(tempSNAM);
						break;
					case "XNAM":
						if (SoundGunShoot2D == null)
							SoundGunShoot2D = new RecordReference();

						SoundGunShoot2D.ReadBinary(reader);
						break;
					case "NAM7":
						if (SoundGunShoot3DLooping == null)
							SoundGunShoot3DLooping = new RecordReference();

						SoundGunShoot3DLooping.ReadBinary(reader);
						break;
					case "TNAM":
						if (SoundMeleeSwing == null)
							SoundMeleeSwing = new RecordReference();

						SoundMeleeSwing.ReadBinary(reader);
						break;
					case "NAM6":
						if (SoundMeleeBlock == null)
							SoundMeleeBlock = new RecordReference();

						SoundMeleeBlock.ReadBinary(reader);
						break;
					case "UNAM":
						if (SoundIdle == null)
							SoundIdle = new RecordReference();

						SoundIdle.ReadBinary(reader);
						break;
					case "NAM9":
						if (SoundEquip == null)
							SoundEquip = new RecordReference();

						SoundEquip.ReadBinary(reader);
						break;
					case "NAM8":
						if (SoundUnequip == null)
							SoundUnequip = new RecordReference();

						SoundUnequip.ReadBinary(reader);
						break;
					case "WMS1":
						if (SoundMod1Shoot == null)
							SoundMod1Shoot = new List<RecordReference>();

						RecordReference tempWMS1 = new RecordReference();
						tempWMS1.ReadBinary(reader);
						SoundMod1Shoot.Add(tempWMS1);
						break;
					case "WMS2":
						if (SoundMod1Shoot2D == null)
							SoundMod1Shoot2D = new RecordReference();

						SoundMod1Shoot2D.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new WeaponData();

						Data.ReadBinary(reader);
						break;
					case "DNAM":
						if (ExtraData == null)
							ExtraData = new WeaponExtraData();

						ExtraData.ReadBinary(reader);
						break;
					case "CRDT":
						if (CriticalHitData == null)
							CriticalHitData = new WeaponCriticalHitData();

						CriticalHitData.ReadBinary(reader);
						break;
					case "VATS":
						if (VATSSpecialAttack == null)
							VATSSpecialAttack = new WeaponVATSData();

						VATSSpecialAttack.ReadBinary(reader);
						break;
					case "VNAM":
						if (SoundLevel == null)
							SoundLevel = new SimpleSubrecord<SoundLevel>();

						SoundLevel.ReadBinary(reader);
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
			if (ModelFileName != null)
				ModelFileName.WriteBinary(writer);
			if (ModelUnknown != null)
				ModelUnknown.WriteBinary(writer);
			if (ModelTextureFileHash != null)
				ModelTextureFileHash.WriteBinary(writer);
			if (ModelAlternateTextures != null)
				ModelAlternateTextures.WriteBinary(writer);
			if (FaceGenModelFlags != null)
				FaceGenModelFlags.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (ObjectEffect != null)
				ObjectEffect.WriteBinary(writer);
			if (EnchantmentChargeAmount != null)
				EnchantmentChargeAmount.WriteBinary(writer);
			if (Ammo != null)
				Ammo.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (RepairList != null)
				RepairList.WriteBinary(writer);
			if (EquipmentType != null)
				EquipmentType.WriteBinary(writer);
			if (BipedalModelList != null)
				BipedalModelList.WriteBinary(writer);
			if (PickUpSound != null)
				PickUpSound.WriteBinary(writer);
			if (DropSound != null)
				DropSound.WriteBinary(writer);
			if (ShellCasingModelFileName != null)
				ShellCasingModelFileName.WriteBinary(writer);
			if (ShellCasingModelTextureFileHash != null)
				ShellCasingModelTextureFileHash.WriteBinary(writer);
			if (ShellCasingModelAlternateTextures != null)
				ShellCasingModelAlternateTextures.WriteBinary(writer);
			if (ScopeModelFileName != null)
				ScopeModelFileName.WriteBinary(writer);
			if (ScopeModelTextureFileHash != null)
				ScopeModelTextureFileHash.WriteBinary(writer);
			if (ScopeModelAlternateTextures != null)
				ScopeModelAlternateTextures.WriteBinary(writer);
			if (ScopeEffect != null)
				ScopeEffect.WriteBinary(writer);
			if (ScopeEffectModelFileName != null)
				ScopeEffectModelFileName.WriteBinary(writer);
			if (ScopeEffectModelTextureFileHash != null)
				ScopeEffectModelTextureFileHash.WriteBinary(writer);
			if (ScopeEffectModelAlternateTextures != null)
				ScopeEffectModelAlternateTextures.WriteBinary(writer);
			if (ModelWithMod1 != null)
				ModelWithMod1.WriteBinary(writer);
			if (ModelWithMod2 != null)
				ModelWithMod2.WriteBinary(writer);
			if (ModelWithMod1_2 != null)
				ModelWithMod1_2.WriteBinary(writer);
			if (ModelWithMod3 != null)
				ModelWithMod3.WriteBinary(writer);
			if (ModelWithMod1_3 != null)
				ModelWithMod1_3.WriteBinary(writer);
			if (ModelWithMod2_3 != null)
				ModelWithMod2_3.WriteBinary(writer);
			if (ModelWithMod1_2_3 != null)
				ModelWithMod1_2_3.WriteBinary(writer);
			if (VATSAttackName != null)
				VATSAttackName.WriteBinary(writer);
			if (EmbeddedWeaponNode != null)
				EmbeddedWeaponNode.WriteBinary(writer);
			if (ImpactDataset != null)
				ImpactDataset.WriteBinary(writer);
			if (FirstPersonModel != null)
				FirstPersonModel.WriteBinary(writer);
			if (FirstPersonModelWithMod1 != null)
				FirstPersonModelWithMod1.WriteBinary(writer);
			if (FirstPersonModelWithMod2 != null)
				FirstPersonModelWithMod2.WriteBinary(writer);
			if (FirstPersonModelWithMod1_2 != null)
				FirstPersonModelWithMod1_2.WriteBinary(writer);
			if (FirstPersonModelWithMod3 != null)
				FirstPersonModelWithMod3.WriteBinary(writer);
			if (FirstPersonModelWithMod1_3 != null)
				FirstPersonModelWithMod1_3.WriteBinary(writer);
			if (FirstPersonModelWithMod2_3 != null)
				FirstPersonModelWithMod2_3.WriteBinary(writer);
			if (FirstPersonModelWithMod1_2_3 != null)
				FirstPersonModelWithMod1_2_3.WriteBinary(writer);
			if (WeaponMod1 != null)
				WeaponMod1.WriteBinary(writer);
			if (WeaponMod2 != null)
				WeaponMod2.WriteBinary(writer);
			if (WeaponMod3 != null)
				WeaponMod3.WriteBinary(writer);
			if (SoundGunShoot != null)
				foreach (var item in SoundGunShoot)
					item.WriteBinary(writer);
			if (SoundGunShoot2D != null)
				SoundGunShoot2D.WriteBinary(writer);
			if (SoundGunShoot3DLooping != null)
				SoundGunShoot3DLooping.WriteBinary(writer);
			if (SoundMeleeSwing != null)
				SoundMeleeSwing.WriteBinary(writer);
			if (SoundMeleeBlock != null)
				SoundMeleeBlock.WriteBinary(writer);
			if (SoundIdle != null)
				SoundIdle.WriteBinary(writer);
			if (SoundEquip != null)
				SoundEquip.WriteBinary(writer);
			if (SoundUnequip != null)
				SoundUnequip.WriteBinary(writer);
			if (SoundMod1Shoot != null)
				foreach (var item in SoundMod1Shoot)
					item.WriteBinary(writer);
			if (SoundMod1Shoot2D != null)
				SoundMod1Shoot2D.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ExtraData != null)
				ExtraData.WriteBinary(writer);
			if (CriticalHitData != null)
				CriticalHitData.WriteBinary(writer);
			if (VATSSpecialAttack != null)
				VATSSpecialAttack.WriteBinary(writer);
			if (SoundLevel != null)
				SoundLevel.WriteBinary(writer);
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
			if (ModelFileName != null)		
			{		
				ele.TryPathTo("Model/FileName", true, out subEle);
				ModelFileName.WriteXML(subEle, master);
			}
			if (ModelUnknown != null)		
			{		
				ele.TryPathTo("Model/Unknown", true, out subEle);
				ModelUnknown.WriteXML(subEle, master);
			}
			if (ModelTextureFileHash != null)		
			{		
				ele.TryPathTo("Model/TextureFileHash", true, out subEle);
				ModelTextureFileHash.WriteXML(subEle, master);
			}
			if (ModelAlternateTextures != null)		
			{		
				ele.TryPathTo("Model/AlternateTextures", true, out subEle);
				ModelAlternateTextures.WriteXML(subEle, master);
			}
			if (FaceGenModelFlags != null)		
			{		
				ele.TryPathTo("FaceGenModelFlags", true, out subEle);
				FaceGenModelFlags.WriteXML(subEle, master);
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
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (ObjectEffect != null)		
			{		
				ele.TryPathTo("ObjectEffect", true, out subEle);
				ObjectEffect.WriteXML(subEle, master);
			}
			if (EnchantmentChargeAmount != null)		
			{		
				ele.TryPathTo("EnchantmentChargeAmount", true, out subEle);
				EnchantmentChargeAmount.WriteXML(subEle, master);
			}
			if (Ammo != null)		
			{		
				ele.TryPathTo("Ammo", true, out subEle);
				Ammo.WriteXML(subEle, master);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (RepairList != null)		
			{		
				ele.TryPathTo("RepairList", true, out subEle);
				RepairList.WriteXML(subEle, master);
			}
			if (EquipmentType != null)		
			{		
				ele.TryPathTo("EquipmentType", true, out subEle);
				EquipmentType.WriteXML(subEle, master);
			}
			if (BipedalModelList != null)		
			{		
				ele.TryPathTo("BipedalModelList", true, out subEle);
				BipedalModelList.WriteXML(subEle, master);
			}
			if (PickUpSound != null)		
			{		
				ele.TryPathTo("Sound/PickUp", true, out subEle);
				PickUpSound.WriteXML(subEle, master);
			}
			if (DropSound != null)		
			{		
				ele.TryPathTo("Sound/Drop", true, out subEle);
				DropSound.WriteXML(subEle, master);
			}
			if (ShellCasingModelFileName != null)		
			{		
				ele.TryPathTo("ShellCasingModel/FileName", true, out subEle);
				ShellCasingModelFileName.WriteXML(subEle, master);
			}
			if (ShellCasingModelTextureFileHash != null)		
			{		
				ele.TryPathTo("ShellCasingModel/TextureFileHash", true, out subEle);
				ShellCasingModelTextureFileHash.WriteXML(subEle, master);
			}
			if (ShellCasingModelAlternateTextures != null)		
			{		
				ele.TryPathTo("ShellCasingModel/AlternateTextures", true, out subEle);
				ShellCasingModelAlternateTextures.WriteXML(subEle, master);
			}
			if (ScopeModelFileName != null)		
			{		
				ele.TryPathTo("ScopeModel/FileName", true, out subEle);
				ScopeModelFileName.WriteXML(subEle, master);
			}
			if (ScopeModelTextureFileHash != null)		
			{		
				ele.TryPathTo("ScopeModel/TextureFileHash", true, out subEle);
				ScopeModelTextureFileHash.WriteXML(subEle, master);
			}
			if (ScopeModelAlternateTextures != null)		
			{		
				ele.TryPathTo("ScopeModel/AlternateTextures", true, out subEle);
				ScopeModelAlternateTextures.WriteXML(subEle, master);
			}
			if (ScopeEffect != null)		
			{		
				ele.TryPathTo("ScopeEffect", true, out subEle);
				ScopeEffect.WriteXML(subEle, master);
			}
			if (ScopeEffectModelFileName != null)		
			{		
				ele.TryPathTo("ScopeEffectModel/FileName", true, out subEle);
				ScopeEffectModelFileName.WriteXML(subEle, master);
			}
			if (ScopeEffectModelTextureFileHash != null)		
			{		
				ele.TryPathTo("ScopeEffectModel/TextureFileHash", true, out subEle);
				ScopeEffectModelTextureFileHash.WriteXML(subEle, master);
			}
			if (ScopeEffectModelAlternateTextures != null)		
			{		
				ele.TryPathTo("ScopeEffectModel/AlternateTextures", true, out subEle);
				ScopeEffectModelAlternateTextures.WriteXML(subEle, master);
			}
			if (ModelWithMod1 != null)		
			{		
				ele.TryPathTo("ModelWithMod1", true, out subEle);
				ModelWithMod1.WriteXML(subEle, master);
			}
			if (ModelWithMod2 != null)		
			{		
				ele.TryPathTo("ModelWithMod2", true, out subEle);
				ModelWithMod2.WriteXML(subEle, master);
			}
			if (ModelWithMod1_2 != null)		
			{		
				ele.TryPathTo("ModelWithMod1_2", true, out subEle);
				ModelWithMod1_2.WriteXML(subEle, master);
			}
			if (ModelWithMod3 != null)		
			{		
				ele.TryPathTo("ModelWithMod3", true, out subEle);
				ModelWithMod3.WriteXML(subEle, master);
			}
			if (ModelWithMod1_3 != null)		
			{		
				ele.TryPathTo("ModelWithMod1_3", true, out subEle);
				ModelWithMod1_3.WriteXML(subEle, master);
			}
			if (ModelWithMod2_3 != null)		
			{		
				ele.TryPathTo("ModelWithMod2_3", true, out subEle);
				ModelWithMod2_3.WriteXML(subEle, master);
			}
			if (ModelWithMod1_2_3 != null)		
			{		
				ele.TryPathTo("ModelWithMod1_2_3", true, out subEle);
				ModelWithMod1_2_3.WriteXML(subEle, master);
			}
			if (VATSAttackName != null)		
			{		
				ele.TryPathTo("VATSAttackName", true, out subEle);
				VATSAttackName.WriteXML(subEle, master);
			}
			if (EmbeddedWeaponNode != null)		
			{		
				ele.TryPathTo("EmbeddedWeaponNode", true, out subEle);
				EmbeddedWeaponNode.WriteXML(subEle, master);
			}
			if (ImpactDataset != null)		
			{		
				ele.TryPathTo("ImpactDataset", true, out subEle);
				ImpactDataset.WriteXML(subEle, master);
			}
			if (FirstPersonModel != null)		
			{		
				ele.TryPathTo("FirstPersonModel", true, out subEle);
				FirstPersonModel.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod1 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod1", true, out subEle);
				FirstPersonModelWithMod1.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod2 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod2", true, out subEle);
				FirstPersonModelWithMod2.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod1_2 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod1_2", true, out subEle);
				FirstPersonModelWithMod1_2.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod3 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod3", true, out subEle);
				FirstPersonModelWithMod3.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod1_3 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod1_3", true, out subEle);
				FirstPersonModelWithMod1_3.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod2_3 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod2_3", true, out subEle);
				FirstPersonModelWithMod2_3.WriteXML(subEle, master);
			}
			if (FirstPersonModelWithMod1_2_3 != null)		
			{		
				ele.TryPathTo("FirstPersonModelWithMod1_2_3", true, out subEle);
				FirstPersonModelWithMod1_2_3.WriteXML(subEle, master);
			}
			if (WeaponMod1 != null)		
			{		
				ele.TryPathTo("WeaponMod1", true, out subEle);
				WeaponMod1.WriteXML(subEle, master);
			}
			if (WeaponMod2 != null)		
			{		
				ele.TryPathTo("WeaponMod2", true, out subEle);
				WeaponMod2.WriteXML(subEle, master);
			}
			if (WeaponMod3 != null)		
			{		
				ele.TryPathTo("WeaponMod3", true, out subEle);
				WeaponMod3.WriteXML(subEle, master);
			}
			if (SoundGunShoot != null)		
			{		
				ele.TryPathTo("Sound/Gun/Shoot", true, out subEle);
				List<string> xmlNames = new List<string>{"_3D", "Distant"};
				int i = 0;
				foreach (var entry in SoundGunShoot)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (SoundGunShoot2D != null)		
			{		
				ele.TryPathTo("Sound/Gun/Shoot2D", true, out subEle);
				SoundGunShoot2D.WriteXML(subEle, master);
			}
			if (SoundGunShoot3DLooping != null)		
			{		
				ele.TryPathTo("Sound/Gun/Shoot3DLooping", true, out subEle);
				SoundGunShoot3DLooping.WriteXML(subEle, master);
			}
			if (SoundMeleeSwing != null)		
			{		
				ele.TryPathTo("Sound/Melee/Swing", true, out subEle);
				SoundMeleeSwing.WriteXML(subEle, master);
			}
			if (SoundMeleeBlock != null)		
			{		
				ele.TryPathTo("Sound/Melee/Block", true, out subEle);
				SoundMeleeBlock.WriteXML(subEle, master);
			}
			if (SoundIdle != null)		
			{		
				ele.TryPathTo("Sound/Idle", true, out subEle);
				SoundIdle.WriteXML(subEle, master);
			}
			if (SoundEquip != null)		
			{		
				ele.TryPathTo("Sound/Equip", true, out subEle);
				SoundEquip.WriteXML(subEle, master);
			}
			if (SoundUnequip != null)		
			{		
				ele.TryPathTo("Sound/Unequip", true, out subEle);
				SoundUnequip.WriteXML(subEle, master);
			}
			if (SoundMod1Shoot != null)		
			{		
				ele.TryPathTo("Sound/Mod1Shoot", true, out subEle);
				List<string> xmlNames = new List<string>{"_3D", "Distant"};
				int i = 0;
				foreach (var entry in SoundMod1Shoot)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (SoundMod1Shoot2D != null)		
			{		
				ele.TryPathTo("Sound/Mod1/Shoot2D", true, out subEle);
				SoundMod1Shoot2D.WriteXML(subEle, master);
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
			if (CriticalHitData != null)		
			{		
				ele.TryPathTo("CriticalHitData", true, out subEle);
				CriticalHitData.WriteXML(subEle, master);
			}
			if (VATSSpecialAttack != null)		
			{		
				ele.TryPathTo("VATSSpecialAttack", true, out subEle);
				VATSSpecialAttack.WriteXML(subEle, master);
			}
			if (SoundLevel != null)		
			{		
				ele.TryPathTo("SoundLevel", true, out subEle);
				SoundLevel.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Model/FileName", false, out subEle))
			{
				if (ModelFileName == null)
					ModelFileName = new SimpleSubrecord<String>();
					
				ModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model/Unknown", false, out subEle))
			{
				if (ModelUnknown == null)
					ModelUnknown = new SimpleSubrecord<Byte[]>();
					
				ModelUnknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model/TextureFileHash", false, out subEle))
			{
				if (ModelTextureFileHash == null)
					ModelTextureFileHash = new SimpleSubrecord<Byte[]>();
					
				ModelTextureFileHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model/AlternateTextures", false, out subEle))
			{
				if (ModelAlternateTextures == null)
					ModelAlternateTextures = new AlternateTextures();
					
				ModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGenModelFlags", false, out subEle))
			{
				if (FaceGenModelFlags == null)
					FaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				FaceGenModelFlags.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ObjectEffect", false, out subEle))
			{
				if (ObjectEffect == null)
					ObjectEffect = new RecordReference();
					
				ObjectEffect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnchantmentChargeAmount", false, out subEle))
			{
				if (EnchantmentChargeAmount == null)
					EnchantmentChargeAmount = new SimpleSubrecord<UInt16>();
					
				EnchantmentChargeAmount.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Ammo", false, out subEle))
			{
				if (Ammo == null)
					Ammo = new RecordReference();
					
				Ammo.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RepairList", false, out subEle))
			{
				if (RepairList == null)
					RepairList = new RecordReference();
					
				RepairList.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EquipmentType", false, out subEle))
			{
				if (EquipmentType == null)
					EquipmentType = new SimpleSubrecord<EquipmentType>();
					
				EquipmentType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BipedalModelList", false, out subEle))
			{
				if (BipedalModelList == null)
					BipedalModelList = new RecordReference();
					
				BipedalModelList.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/PickUp", false, out subEle))
			{
				if (PickUpSound == null)
					PickUpSound = new RecordReference();
					
				PickUpSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Drop", false, out subEle))
			{
				if (DropSound == null)
					DropSound = new RecordReference();
					
				DropSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ShellCasingModel/FileName", false, out subEle))
			{
				if (ShellCasingModelFileName == null)
					ShellCasingModelFileName = new SimpleSubrecord<String>();
					
				ShellCasingModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ShellCasingModel/TextureFileHash", false, out subEle))
			{
				if (ShellCasingModelTextureFileHash == null)
					ShellCasingModelTextureFileHash = new SimpleSubrecord<Byte[]>();
					
				ShellCasingModelTextureFileHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ShellCasingModel/AlternateTextures", false, out subEle))
			{
				if (ShellCasingModelAlternateTextures == null)
					ShellCasingModelAlternateTextures = new AlternateTextures();
					
				ShellCasingModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeModel/FileName", false, out subEle))
			{
				if (ScopeModelFileName == null)
					ScopeModelFileName = new SimpleSubrecord<String>();
					
				ScopeModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeModel/TextureFileHash", false, out subEle))
			{
				if (ScopeModelTextureFileHash == null)
					ScopeModelTextureFileHash = new SimpleSubrecord<Byte[]>();
					
				ScopeModelTextureFileHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeModel/AlternateTextures", false, out subEle))
			{
				if (ScopeModelAlternateTextures == null)
					ScopeModelAlternateTextures = new AlternateTextures();
					
				ScopeModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeEffect", false, out subEle))
			{
				if (ScopeEffect == null)
					ScopeEffect = new RecordReference();
					
				ScopeEffect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeEffectModel/FileName", false, out subEle))
			{
				if (ScopeEffectModelFileName == null)
					ScopeEffectModelFileName = new SimpleSubrecord<String>();
					
				ScopeEffectModelFileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeEffectModel/TextureFileHash", false, out subEle))
			{
				if (ScopeEffectModelTextureFileHash == null)
					ScopeEffectModelTextureFileHash = new SimpleSubrecord<Byte[]>();
					
				ScopeEffectModelTextureFileHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScopeEffectModel/AlternateTextures", false, out subEle))
			{
				if (ScopeEffectModelAlternateTextures == null)
					ScopeEffectModelAlternateTextures = new AlternateTextures();
					
				ScopeEffectModelAlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod1", false, out subEle))
			{
				if (ModelWithMod1 == null)
					ModelWithMod1 = new SimpleSubrecord<String>();
					
				ModelWithMod1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod2", false, out subEle))
			{
				if (ModelWithMod2 == null)
					ModelWithMod2 = new SimpleSubrecord<String>();
					
				ModelWithMod2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod1_2", false, out subEle))
			{
				if (ModelWithMod1_2 == null)
					ModelWithMod1_2 = new SimpleSubrecord<String>();
					
				ModelWithMod1_2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod3", false, out subEle))
			{
				if (ModelWithMod3 == null)
					ModelWithMod3 = new SimpleSubrecord<String>();
					
				ModelWithMod3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod1_3", false, out subEle))
			{
				if (ModelWithMod1_3 == null)
					ModelWithMod1_3 = new SimpleSubrecord<String>();
					
				ModelWithMod1_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod2_3", false, out subEle))
			{
				if (ModelWithMod2_3 == null)
					ModelWithMod2_3 = new SimpleSubrecord<String>();
					
				ModelWithMod2_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelWithMod1_2_3", false, out subEle))
			{
				if (ModelWithMod1_2_3 == null)
					ModelWithMod1_2_3 = new SimpleSubrecord<String>();
					
				ModelWithMod1_2_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("VATSAttackName", false, out subEle))
			{
				if (VATSAttackName == null)
					VATSAttackName = new SimpleSubrecord<String>();
					
				VATSAttackName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EmbeddedWeaponNode", false, out subEle))
			{
				if (EmbeddedWeaponNode == null)
					EmbeddedWeaponNode = new SimpleSubrecord<String>();
					
				EmbeddedWeaponNode.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImpactDataset", false, out subEle))
			{
				if (ImpactDataset == null)
					ImpactDataset = new RecordReference();
					
				ImpactDataset.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModel", false, out subEle))
			{
				if (FirstPersonModel == null)
					FirstPersonModel = new RecordReference();
					
				FirstPersonModel.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod1", false, out subEle))
			{
				if (FirstPersonModelWithMod1 == null)
					FirstPersonModelWithMod1 = new RecordReference();
					
				FirstPersonModelWithMod1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod2", false, out subEle))
			{
				if (FirstPersonModelWithMod2 == null)
					FirstPersonModelWithMod2 = new RecordReference();
					
				FirstPersonModelWithMod2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod1_2", false, out subEle))
			{
				if (FirstPersonModelWithMod1_2 == null)
					FirstPersonModelWithMod1_2 = new RecordReference();
					
				FirstPersonModelWithMod1_2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod3", false, out subEle))
			{
				if (FirstPersonModelWithMod3 == null)
					FirstPersonModelWithMod3 = new RecordReference();
					
				FirstPersonModelWithMod3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod1_3", false, out subEle))
			{
				if (FirstPersonModelWithMod1_3 == null)
					FirstPersonModelWithMod1_3 = new RecordReference();
					
				FirstPersonModelWithMod1_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod2_3", false, out subEle))
			{
				if (FirstPersonModelWithMod2_3 == null)
					FirstPersonModelWithMod2_3 = new RecordReference();
					
				FirstPersonModelWithMod2_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FirstPersonModelWithMod1_2_3", false, out subEle))
			{
				if (FirstPersonModelWithMod1_2_3 == null)
					FirstPersonModelWithMod1_2_3 = new RecordReference();
					
				FirstPersonModelWithMod1_2_3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WeaponMod1", false, out subEle))
			{
				if (WeaponMod1 == null)
					WeaponMod1 = new RecordReference();
					
				WeaponMod1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WeaponMod2", false, out subEle))
			{
				if (WeaponMod2 == null)
					WeaponMod2 = new RecordReference();
					
				WeaponMod2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WeaponMod3", false, out subEle))
			{
				if (WeaponMod3 == null)
					WeaponMod3 = new RecordReference();
					
				WeaponMod3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Gun/Shoot", false, out subEle))
			{
				if (SoundGunShoot == null)
					SoundGunShoot = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempSNAM = new RecordReference();
					tempSNAM.ReadXML(e, master);
					SoundGunShoot.Add(tempSNAM);
				}
			}
			if (ele.TryPathTo("Sound/Gun/Shoot2D", false, out subEle))
			{
				if (SoundGunShoot2D == null)
					SoundGunShoot2D = new RecordReference();
					
				SoundGunShoot2D.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Gun/Shoot3DLooping", false, out subEle))
			{
				if (SoundGunShoot3DLooping == null)
					SoundGunShoot3DLooping = new RecordReference();
					
				SoundGunShoot3DLooping.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Melee/Swing", false, out subEle))
			{
				if (SoundMeleeSwing == null)
					SoundMeleeSwing = new RecordReference();
					
				SoundMeleeSwing.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Melee/Block", false, out subEle))
			{
				if (SoundMeleeBlock == null)
					SoundMeleeBlock = new RecordReference();
					
				SoundMeleeBlock.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Idle", false, out subEle))
			{
				if (SoundIdle == null)
					SoundIdle = new RecordReference();
					
				SoundIdle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Equip", false, out subEle))
			{
				if (SoundEquip == null)
					SoundEquip = new RecordReference();
					
				SoundEquip.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Unequip", false, out subEle))
			{
				if (SoundUnequip == null)
					SoundUnequip = new RecordReference();
					
				SoundUnequip.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Mod1Shoot", false, out subEle))
			{
				if (SoundMod1Shoot == null)
					SoundMod1Shoot = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempWMS1 = new RecordReference();
					tempWMS1.ReadXML(e, master);
					SoundMod1Shoot.Add(tempWMS1);
				}
			}
			if (ele.TryPathTo("Sound/Mod1/Shoot2D", false, out subEle))
			{
				if (SoundMod1Shoot2D == null)
					SoundMod1Shoot2D = new RecordReference();
					
				SoundMod1Shoot2D.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new WeaponData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExtraData", false, out subEle))
			{
				if (ExtraData == null)
					ExtraData = new WeaponExtraData();
					
				ExtraData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CriticalHitData", false, out subEle))
			{
				if (CriticalHitData == null)
					CriticalHitData = new WeaponCriticalHitData();
					
				CriticalHitData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("VATSSpecialAttack", false, out subEle))
			{
				if (VATSSpecialAttack == null)
					VATSSpecialAttack = new WeaponVATSData();
					
				VATSSpecialAttack.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SoundLevel", false, out subEle))
			{
				if (SoundLevel == null)
					SoundLevel = new SimpleSubrecord<SoundLevel>();
					
				SoundLevel.ReadXML(subEle, master);
			}
		}		

		public Weapon Clone()
		{
			return new Weapon(this);
		}

	}
}