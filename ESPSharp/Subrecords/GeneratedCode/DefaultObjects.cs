﻿using System;
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

namespace ESPSharp.Subrecords
{
	public partial class DefaultObjects : Subrecord, ICloneable<DefaultObjects>, IReferenceContainer
	{
		public FormID Stimpack { get; set; }
		public FormID SuperStimpack { get; set; }
		public FormID RadX { get; set; }
		public FormID RadAway { get; set; }
		public FormID MedX { get; set; }
		public FormID PerkParalysis { get; set; }
		public FormID PlayerFaction { get; set; }
		public FormID MysteriousStrangerNPC { get; set; }
		public FormID MysteriousStrangerFaction { get; set; }
		public FormID DefaultMusic { get; set; }
		public FormID BattleMusic { get; set; }
		public FormID DeathMusic { get; set; }
		public FormID SuccessMusic { get; set; }
		public FormID LevelUpMusic { get; set; }
		public FormID PlayerVoiceMale { get; set; }
		public FormID PlayerVoiceMaleChild { get; set; }
		public FormID PlayerVoiceFemale { get; set; }
		public FormID PlayerVoiceFemaleChild { get; set; }
		public FormID EatPackageDefaultFood { get; set; }
		public FormID EveryActorAbility { get; set; }
		public FormID DrugWearsOffImageSpace { get; set; }
		public FormID DoctorsBag { get; set; }
		public FormID MissFortuneNPC { get; set; }
		public FormID MissFortuneFaction { get; set; }
		public FormID MeltdownExplosion { get; set; }
		public FormID UnarmedPowerAttackForward { get; set; }
		public FormID UnarmedPowerAttackBackward { get; set; }
		public FormID UnarmedPowerAttackLeft { get; set; }
		public FormID UnarmedPowerAttackRight { get; set; }
		public FormID UnarmedPowerAttackCrouch { get; set; }
		public FormID UnarmedPowerAttackCounter { get; set; }
		public FormID SpotterEffect { get; set; }
		public FormID ItemDetectedEffect { get; set; }
		public FormID CateyeMobileEffect { get; set; }

		public DefaultObjects()
		{
			Stimpack = new FormID();
			SuperStimpack = new FormID();
			RadX = new FormID();
			RadAway = new FormID();
			MedX = new FormID();
			PerkParalysis = new FormID();
			PlayerFaction = new FormID();
			MysteriousStrangerNPC = new FormID();
			MysteriousStrangerFaction = new FormID();
			DefaultMusic = new FormID();
			BattleMusic = new FormID();
			DeathMusic = new FormID();
			SuccessMusic = new FormID();
			LevelUpMusic = new FormID();
			PlayerVoiceMale = new FormID();
			PlayerVoiceMaleChild = new FormID();
			PlayerVoiceFemale = new FormID();
			PlayerVoiceFemaleChild = new FormID();
			EatPackageDefaultFood = new FormID();
			EveryActorAbility = new FormID();
			DrugWearsOffImageSpace = new FormID();
			DoctorsBag = new FormID();
			MissFortuneNPC = new FormID();
			MissFortuneFaction = new FormID();
			MeltdownExplosion = new FormID();
			UnarmedPowerAttackForward = new FormID();
			UnarmedPowerAttackBackward = new FormID();
			UnarmedPowerAttackLeft = new FormID();
			UnarmedPowerAttackRight = new FormID();
			UnarmedPowerAttackCrouch = new FormID();
			UnarmedPowerAttackCounter = new FormID();
			SpotterEffect = new FormID();
			ItemDetectedEffect = new FormID();
			CateyeMobileEffect = new FormID();
		}

		public DefaultObjects(FormID Stimpack, FormID SuperStimpack, FormID RadX, FormID RadAway, FormID MedX, FormID PerkParalysis, FormID PlayerFaction, FormID MysteriousStrangerNPC, FormID MysteriousStrangerFaction, FormID DefaultMusic, FormID BattleMusic, FormID DeathMusic, FormID SuccessMusic, FormID LevelUpMusic, FormID PlayerVoiceMale, FormID PlayerVoiceMaleChild, FormID PlayerVoiceFemale, FormID PlayerVoiceFemaleChild, FormID EatPackageDefaultFood, FormID EveryActorAbility, FormID DrugWearsOffImageSpace, FormID DoctorsBag, FormID MissFortuneNPC, FormID MissFortuneFaction, FormID MeltdownExplosion, FormID UnarmedPowerAttackForward, FormID UnarmedPowerAttackBackward, FormID UnarmedPowerAttackLeft, FormID UnarmedPowerAttackRight, FormID UnarmedPowerAttackCrouch, FormID UnarmedPowerAttackCounter, FormID SpotterEffect, FormID ItemDetectedEffect, FormID CateyeMobileEffect)
		{
			this.Stimpack = Stimpack;
			this.SuperStimpack = SuperStimpack;
			this.RadX = RadX;
			this.RadAway = RadAway;
			this.MedX = MedX;
			this.PerkParalysis = PerkParalysis;
			this.PlayerFaction = PlayerFaction;
			this.MysteriousStrangerNPC = MysteriousStrangerNPC;
			this.MysteriousStrangerFaction = MysteriousStrangerFaction;
			this.DefaultMusic = DefaultMusic;
			this.BattleMusic = BattleMusic;
			this.DeathMusic = DeathMusic;
			this.SuccessMusic = SuccessMusic;
			this.LevelUpMusic = LevelUpMusic;
			this.PlayerVoiceMale = PlayerVoiceMale;
			this.PlayerVoiceMaleChild = PlayerVoiceMaleChild;
			this.PlayerVoiceFemale = PlayerVoiceFemale;
			this.PlayerVoiceFemaleChild = PlayerVoiceFemaleChild;
			this.EatPackageDefaultFood = EatPackageDefaultFood;
			this.EveryActorAbility = EveryActorAbility;
			this.DrugWearsOffImageSpace = DrugWearsOffImageSpace;
			this.DoctorsBag = DoctorsBag;
			this.MissFortuneNPC = MissFortuneNPC;
			this.MissFortuneFaction = MissFortuneFaction;
			this.MeltdownExplosion = MeltdownExplosion;
			this.UnarmedPowerAttackForward = UnarmedPowerAttackForward;
			this.UnarmedPowerAttackBackward = UnarmedPowerAttackBackward;
			this.UnarmedPowerAttackLeft = UnarmedPowerAttackLeft;
			this.UnarmedPowerAttackRight = UnarmedPowerAttackRight;
			this.UnarmedPowerAttackCrouch = UnarmedPowerAttackCrouch;
			this.UnarmedPowerAttackCounter = UnarmedPowerAttackCounter;
			this.SpotterEffect = SpotterEffect;
			this.ItemDetectedEffect = ItemDetectedEffect;
			this.CateyeMobileEffect = CateyeMobileEffect;
		}

		public DefaultObjects(DefaultObjects copyObject)
		{
			Stimpack = copyObject.Stimpack.Clone();
			SuperStimpack = copyObject.SuperStimpack.Clone();
			RadX = copyObject.RadX.Clone();
			RadAway = copyObject.RadAway.Clone();
			MedX = copyObject.MedX.Clone();
			PerkParalysis = copyObject.PerkParalysis.Clone();
			PlayerFaction = copyObject.PlayerFaction.Clone();
			MysteriousStrangerNPC = copyObject.MysteriousStrangerNPC.Clone();
			MysteriousStrangerFaction = copyObject.MysteriousStrangerFaction.Clone();
			DefaultMusic = copyObject.DefaultMusic.Clone();
			BattleMusic = copyObject.BattleMusic.Clone();
			DeathMusic = copyObject.DeathMusic.Clone();
			SuccessMusic = copyObject.SuccessMusic.Clone();
			LevelUpMusic = copyObject.LevelUpMusic.Clone();
			PlayerVoiceMale = copyObject.PlayerVoiceMale.Clone();
			PlayerVoiceMaleChild = copyObject.PlayerVoiceMaleChild.Clone();
			PlayerVoiceFemale = copyObject.PlayerVoiceFemale.Clone();
			PlayerVoiceFemaleChild = copyObject.PlayerVoiceFemaleChild.Clone();
			EatPackageDefaultFood = copyObject.EatPackageDefaultFood.Clone();
			EveryActorAbility = copyObject.EveryActorAbility.Clone();
			DrugWearsOffImageSpace = copyObject.DrugWearsOffImageSpace.Clone();
			DoctorsBag = copyObject.DoctorsBag.Clone();
			MissFortuneNPC = copyObject.MissFortuneNPC.Clone();
			MissFortuneFaction = copyObject.MissFortuneFaction.Clone();
			MeltdownExplosion = copyObject.MeltdownExplosion.Clone();
			UnarmedPowerAttackForward = copyObject.UnarmedPowerAttackForward.Clone();
			UnarmedPowerAttackBackward = copyObject.UnarmedPowerAttackBackward.Clone();
			UnarmedPowerAttackLeft = copyObject.UnarmedPowerAttackLeft.Clone();
			UnarmedPowerAttackRight = copyObject.UnarmedPowerAttackRight.Clone();
			UnarmedPowerAttackCrouch = copyObject.UnarmedPowerAttackCrouch.Clone();
			UnarmedPowerAttackCounter = copyObject.UnarmedPowerAttackCounter.Clone();
			SpotterEffect = copyObject.SpotterEffect.Clone();
			ItemDetectedEffect = copyObject.ItemDetectedEffect.Clone();
			CateyeMobileEffect = copyObject.CateyeMobileEffect.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Stimpack.ReadBinary(subReader);
					SuperStimpack.ReadBinary(subReader);
					RadX.ReadBinary(subReader);
					RadAway.ReadBinary(subReader);
					MedX.ReadBinary(subReader);
					PerkParalysis.ReadBinary(subReader);
					PlayerFaction.ReadBinary(subReader);
					MysteriousStrangerNPC.ReadBinary(subReader);
					MysteriousStrangerFaction.ReadBinary(subReader);
					DefaultMusic.ReadBinary(subReader);
					BattleMusic.ReadBinary(subReader);
					DeathMusic.ReadBinary(subReader);
					SuccessMusic.ReadBinary(subReader);
					LevelUpMusic.ReadBinary(subReader);
					PlayerVoiceMale.ReadBinary(subReader);
					PlayerVoiceMaleChild.ReadBinary(subReader);
					PlayerVoiceFemale.ReadBinary(subReader);
					PlayerVoiceFemaleChild.ReadBinary(subReader);
					EatPackageDefaultFood.ReadBinary(subReader);
					EveryActorAbility.ReadBinary(subReader);
					DrugWearsOffImageSpace.ReadBinary(subReader);
					DoctorsBag.ReadBinary(subReader);
					MissFortuneNPC.ReadBinary(subReader);
					MissFortuneFaction.ReadBinary(subReader);
					MeltdownExplosion.ReadBinary(subReader);
					UnarmedPowerAttackForward.ReadBinary(subReader);
					UnarmedPowerAttackBackward.ReadBinary(subReader);
					UnarmedPowerAttackLeft.ReadBinary(subReader);
					UnarmedPowerAttackRight.ReadBinary(subReader);
					UnarmedPowerAttackCrouch.ReadBinary(subReader);
					UnarmedPowerAttackCounter.ReadBinary(subReader);
					SpotterEffect.ReadBinary(subReader);
					ItemDetectedEffect.ReadBinary(subReader);
					CateyeMobileEffect.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Stimpack.WriteBinary(writer);
			SuperStimpack.WriteBinary(writer);
			RadX.WriteBinary(writer);
			RadAway.WriteBinary(writer);
			MedX.WriteBinary(writer);
			PerkParalysis.WriteBinary(writer);
			PlayerFaction.WriteBinary(writer);
			MysteriousStrangerNPC.WriteBinary(writer);
			MysteriousStrangerFaction.WriteBinary(writer);
			DefaultMusic.WriteBinary(writer);
			BattleMusic.WriteBinary(writer);
			DeathMusic.WriteBinary(writer);
			SuccessMusic.WriteBinary(writer);
			LevelUpMusic.WriteBinary(writer);
			PlayerVoiceMale.WriteBinary(writer);
			PlayerVoiceMaleChild.WriteBinary(writer);
			PlayerVoiceFemale.WriteBinary(writer);
			PlayerVoiceFemaleChild.WriteBinary(writer);
			EatPackageDefaultFood.WriteBinary(writer);
			EveryActorAbility.WriteBinary(writer);
			DrugWearsOffImageSpace.WriteBinary(writer);
			DoctorsBag.WriteBinary(writer);
			MissFortuneNPC.WriteBinary(writer);
			MissFortuneFaction.WriteBinary(writer);
			MeltdownExplosion.WriteBinary(writer);
			UnarmedPowerAttackForward.WriteBinary(writer);
			UnarmedPowerAttackBackward.WriteBinary(writer);
			UnarmedPowerAttackLeft.WriteBinary(writer);
			UnarmedPowerAttackRight.WriteBinary(writer);
			UnarmedPowerAttackCrouch.WriteBinary(writer);
			UnarmedPowerAttackCounter.WriteBinary(writer);
			SpotterEffect.WriteBinary(writer);
			ItemDetectedEffect.WriteBinary(writer);
			CateyeMobileEffect.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Stimpack", true, out subEle);
			Stimpack.WriteXML(subEle, master);

			ele.TryPathTo("SuperStimpack", true, out subEle);
			SuperStimpack.WriteXML(subEle, master);

			ele.TryPathTo("RadX", true, out subEle);
			RadX.WriteXML(subEle, master);

			ele.TryPathTo("RadAway", true, out subEle);
			RadAway.WriteXML(subEle, master);

			ele.TryPathTo("MedX", true, out subEle);
			MedX.WriteXML(subEle, master);

			ele.TryPathTo("PerkParalysis", true, out subEle);
			PerkParalysis.WriteXML(subEle, master);

			ele.TryPathTo("PlayerFaction", true, out subEle);
			PlayerFaction.WriteXML(subEle, master);

			ele.TryPathTo("MysteriousStrangerNPC", true, out subEle);
			MysteriousStrangerNPC.WriteXML(subEle, master);

			ele.TryPathTo("MysteriousStrangerFaction", true, out subEle);
			MysteriousStrangerFaction.WriteXML(subEle, master);

			ele.TryPathTo("DefaultMusic", true, out subEle);
			DefaultMusic.WriteXML(subEle, master);

			ele.TryPathTo("BattleMusic", true, out subEle);
			BattleMusic.WriteXML(subEle, master);

			ele.TryPathTo("DeathMusic", true, out subEle);
			DeathMusic.WriteXML(subEle, master);

			ele.TryPathTo("SuccessMusic", true, out subEle);
			SuccessMusic.WriteXML(subEle, master);

			ele.TryPathTo("LevelUpMusic", true, out subEle);
			LevelUpMusic.WriteXML(subEle, master);

			ele.TryPathTo("PlayerVoice/Male", true, out subEle);
			PlayerVoiceMale.WriteXML(subEle, master);

			ele.TryPathTo("PlayerVoice/MaleChild", true, out subEle);
			PlayerVoiceMaleChild.WriteXML(subEle, master);

			ele.TryPathTo("PlayerVoice/Female", true, out subEle);
			PlayerVoiceFemale.WriteXML(subEle, master);

			ele.TryPathTo("PlayerVoice/FemaleChild", true, out subEle);
			PlayerVoiceFemaleChild.WriteXML(subEle, master);

			ele.TryPathTo("EatPackageDefaultFood", true, out subEle);
			EatPackageDefaultFood.WriteXML(subEle, master);

			ele.TryPathTo("EveryActorAbility", true, out subEle);
			EveryActorAbility.WriteXML(subEle, master);

			ele.TryPathTo("DrugWearsOffImageSpace", true, out subEle);
			DrugWearsOffImageSpace.WriteXML(subEle, master);

			ele.TryPathTo("DoctorsBag", true, out subEle);
			DoctorsBag.WriteXML(subEle, master);

			ele.TryPathTo("MissFortuneNPC", true, out subEle);
			MissFortuneNPC.WriteXML(subEle, master);

			ele.TryPathTo("MissFortuneFaction", true, out subEle);
			MissFortuneFaction.WriteXML(subEle, master);

			ele.TryPathTo("MeltdownExplosion", true, out subEle);
			MeltdownExplosion.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Forward", true, out subEle);
			UnarmedPowerAttackForward.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Backward", true, out subEle);
			UnarmedPowerAttackBackward.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Left", true, out subEle);
			UnarmedPowerAttackLeft.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Right", true, out subEle);
			UnarmedPowerAttackRight.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Crouch", true, out subEle);
			UnarmedPowerAttackCrouch.WriteXML(subEle, master);

			ele.TryPathTo("UnarmedPowerAttack/Counter", true, out subEle);
			UnarmedPowerAttackCounter.WriteXML(subEle, master);

			ele.TryPathTo("SpotterEffect", true, out subEle);
			SpotterEffect.WriteXML(subEle, master);

			ele.TryPathTo("ItemDetectedEffect", true, out subEle);
			ItemDetectedEffect.WriteXML(subEle, master);

			ele.TryPathTo("CateyeMobileEffect", true, out subEle);
			CateyeMobileEffect.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Stimpack", false, out subEle))
			{
				Stimpack.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("SuperStimpack", false, out subEle))
			{
				SuperStimpack.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("RadX", false, out subEle))
			{
				RadX.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("RadAway", false, out subEle))
			{
				RadAway.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MedX", false, out subEle))
			{
				MedX.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PerkParalysis", false, out subEle))
			{
				PerkParalysis.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PlayerFaction", false, out subEle))
			{
				PlayerFaction.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MysteriousStrangerNPC", false, out subEle))
			{
				MysteriousStrangerNPC.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MysteriousStrangerFaction", false, out subEle))
			{
				MysteriousStrangerFaction.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("DefaultMusic", false, out subEle))
			{
				DefaultMusic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("BattleMusic", false, out subEle))
			{
				BattleMusic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("DeathMusic", false, out subEle))
			{
				DeathMusic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("SuccessMusic", false, out subEle))
			{
				SuccessMusic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("LevelUpMusic", false, out subEle))
			{
				LevelUpMusic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PlayerVoice/Male", false, out subEle))
			{
				PlayerVoiceMale.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PlayerVoice/MaleChild", false, out subEle))
			{
				PlayerVoiceMaleChild.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PlayerVoice/Female", false, out subEle))
			{
				PlayerVoiceFemale.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PlayerVoice/FemaleChild", false, out subEle))
			{
				PlayerVoiceFemaleChild.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("EatPackageDefaultFood", false, out subEle))
			{
				EatPackageDefaultFood.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("EveryActorAbility", false, out subEle))
			{
				EveryActorAbility.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("DrugWearsOffImageSpace", false, out subEle))
			{
				DrugWearsOffImageSpace.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("DoctorsBag", false, out subEle))
			{
				DoctorsBag.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MissFortuneNPC", false, out subEle))
			{
				MissFortuneNPC.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MissFortuneFaction", false, out subEle))
			{
				MissFortuneFaction.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MeltdownExplosion", false, out subEle))
			{
				MeltdownExplosion.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Forward", false, out subEle))
			{
				UnarmedPowerAttackForward.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Backward", false, out subEle))
			{
				UnarmedPowerAttackBackward.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Left", false, out subEle))
			{
				UnarmedPowerAttackLeft.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Right", false, out subEle))
			{
				UnarmedPowerAttackRight.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Crouch", false, out subEle))
			{
				UnarmedPowerAttackCrouch.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UnarmedPowerAttack/Counter", false, out subEle))
			{
				UnarmedPowerAttackCounter.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("SpotterEffect", false, out subEle))
			{
				SpotterEffect.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("ItemDetectedEffect", false, out subEle))
			{
				ItemDetectedEffect.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("CateyeMobileEffect", false, out subEle))
			{
				CateyeMobileEffect.ReadXML(subEle, master);
			}
		}

		public DefaultObjects Clone()
		{
			return new DefaultObjects(this);
		}

	}
}
