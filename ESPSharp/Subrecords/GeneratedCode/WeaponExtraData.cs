
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

namespace ESPSharp.Subrecords
{
	public partial class WeaponExtraData : Subrecord, ICloneable, IComparable<WeaponExtraData>, IEquatable<WeaponExtraData>  
	{
		public WeaponAnimationType AnimationType { get; set; }
		public Single AnimationMultiplier { get; set; }
		public Single Reach { get; set; }
		public WeaponDataFlags1 Flags1 { get; set; }
		public WeaponGripAnimationType GripAnimation { get; set; }
		public Byte AmmoUse { get; set; }
		public WeaponReloadAnimationType ReloadAnimation { get; set; }
		public Single MinSpread { get; set; }
		public Single Spread { get; set; }
		public Byte[] Unknown { get; set; }
		public Single SightFOV { get; set; }
		public Single Unknown2 { get; set; }
		public FormID Projectile { get; set; }
		public Byte BaseVATSToHitChance { get; set; }
		public WeaponAttackAnimationType AttackAnimation { get; set; }
		public Byte ProjectileCount { get; set; }
		public EmbeddedWeaponActorValue EmbeddedWeaponActorValue { get; set; }
		public Single MinRange { get; set; }
		public Single MaxRange { get; set; }
		public LimbKillBehavior LimbKillBehavior { get; set; }
		public WeaponDataFlags2 Flags2 { get; set; }
		public Single AttackAnimationMultiplier { get; set; }
		public Single FireRate { get; set; }
		public Single ActionPointCost { get; set; }
		public Single RumbleLeftMotorStrength { get; set; }
		public Single RumbleRightMotorStrength { get; set; }
		public Single RumbleDuration { get; set; }
		public Single DamageToWeaponMult { get; set; }
		public Single AttackShotsPerSecond { get; set; }
		public Single ReloadTime { get; set; }
		public Single JamTime { get; set; }
		public Single AimArc { get; set; }
		public ActorValues Skill { get; set; }
		public WeaponRumblePattern RumblePattern { get; set; }
		public Single RumbleWavelength { get; set; }
		public Single LimbDamageMult { get; set; }
		public ActorValues ResistanceType { get; set; }
		public Single SightUsage { get; set; }
		public Single SemiAutomaticFireDelayMin { get; set; }
		public Single SemiAutomaticFireDelayMax { get; set; }
		public Single Unknown3 { get; set; }
		public WeaponModEffect Mod1Effect { get; set; }
		public WeaponModEffect Mod2Effect { get; set; }
		public WeaponModEffect Mod3Effect { get; set; }
		public Single Mod1ValueA { get; set; }
		public Single Mod2ValueA { get; set; }
		public Single Mod3ValueA { get; set; }
		public WeaponPowerAttackAnimation PowerAttackAnimation { get; set; }
		public UInt32 StrengthRequirement { get; set; }
		public Byte Unknown4 { get; set; }
		public WeaponReloadAnimationType Mod1ReloadAnimation { get; set; }
		public Byte[] Unknown5 { get; set; }
		public Single AmmoRegenRate { get; set; }
		public Single KillImpulse { get; set; }
		public Single Mod1ValueB { get; set; }
		public Single Mod2ValueB { get; set; }
		public Single Mod3ValueB { get; set; }
		public Single ImpulseDistance { get; set; }
		public UInt32 SkillRequirement { get; set; }

		public WeaponExtraData(string Tag = null)
			:base(Tag)
		{
			AnimationType = new WeaponAnimationType();
			AnimationMultiplier = new Single();
			Reach = new Single();
			Flags1 = new WeaponDataFlags1();
			GripAnimation = new WeaponGripAnimationType();
			AmmoUse = new Byte();
			ReloadAnimation = new WeaponReloadAnimationType();
			MinSpread = new Single();
			Spread = new Single();
			Unknown = new byte[4];
			SightFOV = new Single();
			Unknown2 = new Single();
			Projectile = new FormID();
			BaseVATSToHitChance = new Byte();
			AttackAnimation = new WeaponAttackAnimationType();
			ProjectileCount = new Byte();
			EmbeddedWeaponActorValue = new EmbeddedWeaponActorValue();
			MinRange = new Single();
			MaxRange = new Single();
			LimbKillBehavior = new LimbKillBehavior();
			Flags2 = new WeaponDataFlags2();
			AttackAnimationMultiplier = new Single();
			FireRate = new Single();
			ActionPointCost = new Single();
			RumbleLeftMotorStrength = new Single();
			RumbleRightMotorStrength = new Single();
			RumbleDuration = new Single();
			DamageToWeaponMult = new Single();
			AttackShotsPerSecond = new Single();
			ReloadTime = new Single();
			JamTime = new Single();
			AimArc = new Single();
			Skill = new ActorValues();
			RumblePattern = new WeaponRumblePattern();
			RumbleWavelength = new Single();
			LimbDamageMult = new Single();
			ResistanceType = new ActorValues();
			SightUsage = new Single();
			SemiAutomaticFireDelayMin = new Single();
			SemiAutomaticFireDelayMax = new Single();
			Unknown3 = new Single();
			Mod1Effect = new WeaponModEffect();
			Mod2Effect = new WeaponModEffect();
			Mod3Effect = new WeaponModEffect();
			Mod1ValueA = new Single();
			Mod2ValueA = new Single();
			Mod3ValueA = new Single();
			PowerAttackAnimation = new WeaponPowerAttackAnimation();
			StrengthRequirement = new UInt32();
			Unknown4 = new Byte();
			Mod1ReloadAnimation = new WeaponReloadAnimationType();
			Unknown5 = new byte[2];
			AmmoRegenRate = new Single();
			KillImpulse = new Single();
			Mod1ValueB = new Single();
			Mod2ValueB = new Single();
			Mod3ValueB = new Single();
			ImpulseDistance = new Single();
			SkillRequirement = new UInt32();
		}

		public WeaponExtraData(WeaponAnimationType AnimationType, Single AnimationMultiplier, Single Reach, WeaponDataFlags1 Flags1, WeaponGripAnimationType GripAnimation, Byte AmmoUse, WeaponReloadAnimationType ReloadAnimation, Single MinSpread, Single Spread, Byte[] Unknown, Single SightFOV, Single Unknown2, FormID Projectile, Byte BaseVATSToHitChance, WeaponAttackAnimationType AttackAnimation, Byte ProjectileCount, EmbeddedWeaponActorValue EmbeddedWeaponActorValue, Single MinRange, Single MaxRange, LimbKillBehavior LimbKillBehavior, WeaponDataFlags2 Flags2, Single AttackAnimationMultiplier, Single FireRate, Single ActionPointCost, Single RumbleLeftMotorStrength, Single RumbleRightMotorStrength, Single RumbleDuration, Single DamageToWeaponMult, Single AttackShotsPerSecond, Single ReloadTime, Single JamTime, Single AimArc, ActorValues Skill, WeaponRumblePattern RumblePattern, Single RumbleWavelength, Single LimbDamageMult, ActorValues ResistanceType, Single SightUsage, Single SemiAutomaticFireDelayMin, Single SemiAutomaticFireDelayMax, Single Unknown3, WeaponModEffect Mod1Effect, WeaponModEffect Mod2Effect, WeaponModEffect Mod3Effect, Single Mod1ValueA, Single Mod2ValueA, Single Mod3ValueA, WeaponPowerAttackAnimation PowerAttackAnimation, UInt32 StrengthRequirement, Byte Unknown4, WeaponReloadAnimationType Mod1ReloadAnimation, Byte[] Unknown5, Single AmmoRegenRate, Single KillImpulse, Single Mod1ValueB, Single Mod2ValueB, Single Mod3ValueB, Single ImpulseDistance, UInt32 SkillRequirement)
		{
			this.AnimationType = AnimationType;
			this.AnimationMultiplier = AnimationMultiplier;
			this.Reach = Reach;
			this.Flags1 = Flags1;
			this.GripAnimation = GripAnimation;
			this.AmmoUse = AmmoUse;
			this.ReloadAnimation = ReloadAnimation;
			this.MinSpread = MinSpread;
			this.Spread = Spread;
			this.Unknown = Unknown;
			this.SightFOV = SightFOV;
			this.Unknown2 = Unknown2;
			this.Projectile = Projectile;
			this.BaseVATSToHitChance = BaseVATSToHitChance;
			this.AttackAnimation = AttackAnimation;
			this.ProjectileCount = ProjectileCount;
			this.EmbeddedWeaponActorValue = EmbeddedWeaponActorValue;
			this.MinRange = MinRange;
			this.MaxRange = MaxRange;
			this.LimbKillBehavior = LimbKillBehavior;
			this.Flags2 = Flags2;
			this.AttackAnimationMultiplier = AttackAnimationMultiplier;
			this.FireRate = FireRate;
			this.ActionPointCost = ActionPointCost;
			this.RumbleLeftMotorStrength = RumbleLeftMotorStrength;
			this.RumbleRightMotorStrength = RumbleRightMotorStrength;
			this.RumbleDuration = RumbleDuration;
			this.DamageToWeaponMult = DamageToWeaponMult;
			this.AttackShotsPerSecond = AttackShotsPerSecond;
			this.ReloadTime = ReloadTime;
			this.JamTime = JamTime;
			this.AimArc = AimArc;
			this.Skill = Skill;
			this.RumblePattern = RumblePattern;
			this.RumbleWavelength = RumbleWavelength;
			this.LimbDamageMult = LimbDamageMult;
			this.ResistanceType = ResistanceType;
			this.SightUsage = SightUsage;
			this.SemiAutomaticFireDelayMin = SemiAutomaticFireDelayMin;
			this.SemiAutomaticFireDelayMax = SemiAutomaticFireDelayMax;
			this.Unknown3 = Unknown3;
			this.Mod1Effect = Mod1Effect;
			this.Mod2Effect = Mod2Effect;
			this.Mod3Effect = Mod3Effect;
			this.Mod1ValueA = Mod1ValueA;
			this.Mod2ValueA = Mod2ValueA;
			this.Mod3ValueA = Mod3ValueA;
			this.PowerAttackAnimation = PowerAttackAnimation;
			this.StrengthRequirement = StrengthRequirement;
			this.Unknown4 = Unknown4;
			this.Mod1ReloadAnimation = Mod1ReloadAnimation;
			this.Unknown5 = Unknown5;
			this.AmmoRegenRate = AmmoRegenRate;
			this.KillImpulse = KillImpulse;
			this.Mod1ValueB = Mod1ValueB;
			this.Mod2ValueB = Mod2ValueB;
			this.Mod3ValueB = Mod3ValueB;
			this.ImpulseDistance = ImpulseDistance;
			this.SkillRequirement = SkillRequirement;
		}

		public WeaponExtraData(WeaponExtraData copyObject)
		{
			AnimationType = copyObject.AnimationType;
			AnimationMultiplier = copyObject.AnimationMultiplier;
			Reach = copyObject.Reach;
			Flags1 = copyObject.Flags1;
			GripAnimation = copyObject.GripAnimation;
			AmmoUse = copyObject.AmmoUse;
			ReloadAnimation = copyObject.ReloadAnimation;
			MinSpread = copyObject.MinSpread;
			Spread = copyObject.Spread;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
			SightFOV = copyObject.SightFOV;
			Unknown2 = copyObject.Unknown2;
			if (copyObject.Projectile != null)
				Projectile = (FormID)copyObject.Projectile.Clone();
			BaseVATSToHitChance = copyObject.BaseVATSToHitChance;
			AttackAnimation = copyObject.AttackAnimation;
			ProjectileCount = copyObject.ProjectileCount;
			EmbeddedWeaponActorValue = copyObject.EmbeddedWeaponActorValue;
			MinRange = copyObject.MinRange;
			MaxRange = copyObject.MaxRange;
			LimbKillBehavior = copyObject.LimbKillBehavior;
			Flags2 = copyObject.Flags2;
			AttackAnimationMultiplier = copyObject.AttackAnimationMultiplier;
			FireRate = copyObject.FireRate;
			ActionPointCost = copyObject.ActionPointCost;
			RumbleLeftMotorStrength = copyObject.RumbleLeftMotorStrength;
			RumbleRightMotorStrength = copyObject.RumbleRightMotorStrength;
			RumbleDuration = copyObject.RumbleDuration;
			DamageToWeaponMult = copyObject.DamageToWeaponMult;
			AttackShotsPerSecond = copyObject.AttackShotsPerSecond;
			ReloadTime = copyObject.ReloadTime;
			JamTime = copyObject.JamTime;
			AimArc = copyObject.AimArc;
			Skill = copyObject.Skill;
			RumblePattern = copyObject.RumblePattern;
			RumbleWavelength = copyObject.RumbleWavelength;
			LimbDamageMult = copyObject.LimbDamageMult;
			ResistanceType = copyObject.ResistanceType;
			SightUsage = copyObject.SightUsage;
			SemiAutomaticFireDelayMin = copyObject.SemiAutomaticFireDelayMin;
			SemiAutomaticFireDelayMax = copyObject.SemiAutomaticFireDelayMax;
			Unknown3 = copyObject.Unknown3;
			Mod1Effect = copyObject.Mod1Effect;
			Mod2Effect = copyObject.Mod2Effect;
			Mod3Effect = copyObject.Mod3Effect;
			Mod1ValueA = copyObject.Mod1ValueA;
			Mod2ValueA = copyObject.Mod2ValueA;
			Mod3ValueA = copyObject.Mod3ValueA;
			PowerAttackAnimation = copyObject.PowerAttackAnimation;
			StrengthRequirement = copyObject.StrengthRequirement;
			Unknown4 = copyObject.Unknown4;
			Mod1ReloadAnimation = copyObject.Mod1ReloadAnimation;
			if (copyObject.Unknown5 != null)
				Unknown5 = (Byte[])copyObject.Unknown5.Clone();
			AmmoRegenRate = copyObject.AmmoRegenRate;
			KillImpulse = copyObject.KillImpulse;
			Mod1ValueB = copyObject.Mod1ValueB;
			Mod2ValueB = copyObject.Mod2ValueB;
			Mod3ValueB = copyObject.Mod3ValueB;
			ImpulseDistance = copyObject.ImpulseDistance;
			SkillRequirement = copyObject.SkillRequirement;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					AnimationType = subReader.ReadEnum<WeaponAnimationType>();
					AnimationMultiplier = subReader.ReadSingle();
					Reach = subReader.ReadSingle();
					Flags1 = subReader.ReadEnum<WeaponDataFlags1>();
					GripAnimation = subReader.ReadEnum<WeaponGripAnimationType>();
					AmmoUse = subReader.ReadByte();
					ReloadAnimation = subReader.ReadEnum<WeaponReloadAnimationType>();
					MinSpread = subReader.ReadSingle();
					Spread = subReader.ReadSingle();
					Unknown = subReader.ReadBytes(4);
					SightFOV = subReader.ReadSingle();
					Unknown2 = subReader.ReadSingle();
					Projectile.ReadBinary(subReader);
					BaseVATSToHitChance = subReader.ReadByte();
					AttackAnimation = subReader.ReadEnum<WeaponAttackAnimationType>();
					ProjectileCount = subReader.ReadByte();
					EmbeddedWeaponActorValue = subReader.ReadEnum<EmbeddedWeaponActorValue>();
					MinRange = subReader.ReadSingle();
					MaxRange = subReader.ReadSingle();
					LimbKillBehavior = subReader.ReadEnum<LimbKillBehavior>();
					Flags2 = subReader.ReadEnum<WeaponDataFlags2>();
					AttackAnimationMultiplier = subReader.ReadSingle();
					FireRate = subReader.ReadSingle();
					ActionPointCost = subReader.ReadSingle();
					RumbleLeftMotorStrength = subReader.ReadSingle();
					RumbleRightMotorStrength = subReader.ReadSingle();
					RumbleDuration = subReader.ReadSingle();
					DamageToWeaponMult = subReader.ReadSingle();
					AttackShotsPerSecond = subReader.ReadSingle();
					ReloadTime = subReader.ReadSingle();
					JamTime = subReader.ReadSingle();
					AimArc = subReader.ReadSingle();
					Skill = subReader.ReadEnum<ActorValues>();
					RumblePattern = subReader.ReadEnum<WeaponRumblePattern>();
					RumbleWavelength = subReader.ReadSingle();
					LimbDamageMult = subReader.ReadSingle();
					ResistanceType = subReader.ReadEnum<ActorValues>();
					SightUsage = subReader.ReadSingle();
					SemiAutomaticFireDelayMin = subReader.ReadSingle();
					SemiAutomaticFireDelayMax = subReader.ReadSingle();
					Unknown3 = subReader.ReadSingle();
					Mod1Effect = subReader.ReadEnum<WeaponModEffect>();
					Mod2Effect = subReader.ReadEnum<WeaponModEffect>();
					Mod3Effect = subReader.ReadEnum<WeaponModEffect>();
					Mod1ValueA = subReader.ReadSingle();
					Mod2ValueA = subReader.ReadSingle();
					Mod3ValueA = subReader.ReadSingle();
					PowerAttackAnimation = subReader.ReadEnum<WeaponPowerAttackAnimation>();
					StrengthRequirement = subReader.ReadUInt32();
					Unknown4 = subReader.ReadByte();
					Mod1ReloadAnimation = subReader.ReadEnum<WeaponReloadAnimationType>();
					Unknown5 = subReader.ReadBytes(2);
					AmmoRegenRate = subReader.ReadSingle();
					KillImpulse = subReader.ReadSingle();
					Mod1ValueB = subReader.ReadSingle();
					Mod2ValueB = subReader.ReadSingle();
					Mod3ValueB = subReader.ReadSingle();
					ImpulseDistance = subReader.ReadSingle();
					SkillRequirement = subReader.ReadUInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)AnimationType);
			writer.Write(AnimationMultiplier);
			writer.Write(Reach);
			writer.Write((Byte)Flags1);
			writer.Write((Byte)GripAnimation);
			writer.Write(AmmoUse);
			writer.Write((Byte)ReloadAnimation);
			writer.Write(MinSpread);
			writer.Write(Spread);
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown);
			writer.Write(SightFOV);
			writer.Write(Unknown2);
			Projectile.WriteBinary(writer);
			writer.Write(BaseVATSToHitChance);
			writer.Write((Byte)AttackAnimation);
			writer.Write(ProjectileCount);
			writer.Write((Byte)EmbeddedWeaponActorValue);
			writer.Write(MinRange);
			writer.Write(MaxRange);
			writer.Write((UInt32)LimbKillBehavior);
			writer.Write((UInt32)Flags2);
			writer.Write(AttackAnimationMultiplier);
			writer.Write(FireRate);
			writer.Write(ActionPointCost);
			writer.Write(RumbleLeftMotorStrength);
			writer.Write(RumbleRightMotorStrength);
			writer.Write(RumbleDuration);
			writer.Write(DamageToWeaponMult);
			writer.Write(AttackShotsPerSecond);
			writer.Write(ReloadTime);
			writer.Write(JamTime);
			writer.Write(AimArc);
			writer.Write((Int32)Skill);
			writer.Write((UInt32)RumblePattern);
			writer.Write(RumbleWavelength);
			writer.Write(LimbDamageMult);
			writer.Write((Int32)ResistanceType);
			writer.Write(SightUsage);
			writer.Write(SemiAutomaticFireDelayMin);
			writer.Write(SemiAutomaticFireDelayMax);
			writer.Write(Unknown3);
			writer.Write((UInt32)Mod1Effect);
			writer.Write((UInt32)Mod2Effect);
			writer.Write((UInt32)Mod3Effect);
			writer.Write(Mod1ValueA);
			writer.Write(Mod2ValueA);
			writer.Write(Mod3ValueA);
			writer.Write((UInt32)PowerAttackAnimation);
			writer.Write(StrengthRequirement);
			writer.Write(Unknown4);
			writer.Write((Byte)Mod1ReloadAnimation);
			if (Unknown5 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unknown5);
			writer.Write(AmmoRegenRate);
			writer.Write(KillImpulse);
			writer.Write(Mod1ValueB);
			writer.Write(Mod2ValueB);
			writer.Write(Mod3ValueB);
			writer.Write(ImpulseDistance);
			writer.Write(SkillRequirement);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("AnimationType", true, out subEle);
			subEle.Value = AnimationType.ToString();

			ele.TryPathTo("AnimationMultiplier", true, out subEle);
			subEle.Value = AnimationMultiplier.ToString("G15");

			ele.TryPathTo("Reach", true, out subEle);
			subEle.Value = Reach.ToString("G15");

			ele.TryPathTo("Flags1", true, out subEle);
			subEle.Value = Flags1.ToString();

			ele.TryPathTo("GripAnimation", true, out subEle);
			subEle.Value = GripAnimation.ToString();

			ele.TryPathTo("AmmoUse", true, out subEle);
			subEle.Value = AmmoUse.ToString();

			ele.TryPathTo("ReloadAnimation", true, out subEle);
			subEle.Value = ReloadAnimation.ToString();

			ele.TryPathTo("MinSpread", true, out subEle);
			subEle.Value = MinSpread.ToString("G15");

			ele.TryPathTo("Spread", true, out subEle);
			subEle.Value = Spread.ToString("G15");

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();

			ele.TryPathTo("SightFOV", true, out subEle);
			subEle.Value = SightFOV.ToString("G15");

			ele.TryPathTo("Unknown2", true, out subEle);
			subEle.Value = Unknown2.ToString("G15");

			ele.TryPathTo("Projectile", true, out subEle);
			Projectile.WriteXML(subEle, master);

			ele.TryPathTo("BaseVATSToHitChance", true, out subEle);
			subEle.Value = BaseVATSToHitChance.ToString();

			ele.TryPathTo("AttackAnimation", true, out subEle);
			subEle.Value = AttackAnimation.ToString();

			ele.TryPathTo("ProjectileCount", true, out subEle);
			subEle.Value = ProjectileCount.ToString();

			ele.TryPathTo("EmbeddedWeaponActorValue", true, out subEle);
			subEle.Value = EmbeddedWeaponActorValue.ToString();

			ele.TryPathTo("Range/Min", true, out subEle);
			subEle.Value = MinRange.ToString("G15");

			ele.TryPathTo("Range/Max", true, out subEle);
			subEle.Value = MaxRange.ToString("G15");

			ele.TryPathTo("LimbKillBehavior", true, out subEle);
			subEle.Value = LimbKillBehavior.ToString();

			ele.TryPathTo("Flags2", true, out subEle);
			subEle.Value = Flags2.ToString();

			ele.TryPathTo("AttackAnimationMultiplier", true, out subEle);
			subEle.Value = AttackAnimationMultiplier.ToString("G15");

			ele.TryPathTo("FireRate", true, out subEle);
			subEle.Value = FireRate.ToString("G15");

			ele.TryPathTo("ActionPointCost", true, out subEle);
			subEle.Value = ActionPointCost.ToString("G15");

			ele.TryPathTo("Rumble/LeftMotorStrength", true, out subEle);
			subEle.Value = RumbleLeftMotorStrength.ToString("G15");

			ele.TryPathTo("Rumble/RightMotorStrength", true, out subEle);
			subEle.Value = RumbleRightMotorStrength.ToString("G15");

			ele.TryPathTo("Rumble/Duration", true, out subEle);
			subEle.Value = RumbleDuration.ToString("G15");

			ele.TryPathTo("DamageToWeaponMult", true, out subEle);
			subEle.Value = DamageToWeaponMult.ToString("G15");

			ele.TryPathTo("AttackShotsPerSecond", true, out subEle);
			subEle.Value = AttackShotsPerSecond.ToString("G15");

			ele.TryPathTo("ReloadTime", true, out subEle);
			subEle.Value = ReloadTime.ToString("G15");

			ele.TryPathTo("JamTime", true, out subEle);
			subEle.Value = JamTime.ToString("G15");

			ele.TryPathTo("AimArc", true, out subEle);
			subEle.Value = AimArc.ToString("G15");

			ele.TryPathTo("Skill", true, out subEle);
			subEle.Value = Skill.ToString();

			ele.TryPathTo("Rumble/Pattern", true, out subEle);
			subEle.Value = RumblePattern.ToString();

			ele.TryPathTo("Rumble/Wavelength", true, out subEle);
			subEle.Value = RumbleWavelength.ToString("G15");

			ele.TryPathTo("LimbDamageMult", true, out subEle);
			subEle.Value = LimbDamageMult.ToString("G15");

			ele.TryPathTo("ResistanceType", true, out subEle);
			subEle.Value = ResistanceType.ToString();

			ele.TryPathTo("SightUsage", true, out subEle);
			subEle.Value = SightUsage.ToString("G15");

			ele.TryPathTo("SemiAutomaticFireDelay/Min", true, out subEle);
			subEle.Value = SemiAutomaticFireDelayMin.ToString("G15");

			ele.TryPathTo("SemiAutomaticFireDelay/Max", true, out subEle);
			subEle.Value = SemiAutomaticFireDelayMax.ToString("G15");

			ele.TryPathTo("Unknown3", true, out subEle);
			subEle.Value = Unknown3.ToString("G15");

			ele.TryPathTo("Mods/Mod1/Effect", true, out subEle);
			subEle.Value = Mod1Effect.ToString();

			ele.TryPathTo("Mods/Mod2/Effect", true, out subEle);
			subEle.Value = Mod2Effect.ToString();

			ele.TryPathTo("Mods/Mod3/Effect", true, out subEle);
			subEle.Value = Mod3Effect.ToString();

			ele.TryPathTo("Mods/Mod1/ValueA", true, out subEle);
			subEle.Value = Mod1ValueA.ToString("G15");

			ele.TryPathTo("Mods/Mod2/ValueA", true, out subEle);
			subEle.Value = Mod2ValueA.ToString("G15");

			ele.TryPathTo("Mods/Mod3/ValueA", true, out subEle);
			subEle.Value = Mod3ValueA.ToString("G15");

			ele.TryPathTo("PowerAttackAnimation", true, out subEle);
			subEle.Value = PowerAttackAnimation.ToString();

			ele.TryPathTo("StrengthRequirement", true, out subEle);
			subEle.Value = StrengthRequirement.ToString();

			ele.TryPathTo("Unknown4", true, out subEle);
			subEle.Value = Unknown4.ToString();

			ele.TryPathTo("Mods/Mod1/ReloadAnimation", true, out subEle);
			subEle.Value = Mod1ReloadAnimation.ToString();

			ele.TryPathTo("Unknown5", true, out subEle);
			subEle.Value = Unknown5.ToHex();

			ele.TryPathTo("AmmoRegenRate", true, out subEle);
			subEle.Value = AmmoRegenRate.ToString("G15");

			ele.TryPathTo("KillImpulse", true, out subEle);
			subEle.Value = KillImpulse.ToString("G15");

			ele.TryPathTo("Mods/Mod1/ValueB", true, out subEle);
			subEle.Value = Mod1ValueB.ToString("G15");

			ele.TryPathTo("Mods/Mod2/ValueB", true, out subEle);
			subEle.Value = Mod2ValueB.ToString("G15");

			ele.TryPathTo("Mods/Mod3/ValueB", true, out subEle);
			subEle.Value = Mod3ValueB.ToString("G15");

			ele.TryPathTo("ImpulseDistance", true, out subEle);
			subEle.Value = ImpulseDistance.ToString("G15");

			ele.TryPathTo("SkillRequirement", true, out subEle);
			subEle.Value = SkillRequirement.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("AnimationType", false, out subEle))
				AnimationType = subEle.ToEnum<WeaponAnimationType>();

			if (ele.TryPathTo("AnimationMultiplier", false, out subEle))
				AnimationMultiplier = subEle.ToSingle();

			if (ele.TryPathTo("Reach", false, out subEle))
				Reach = subEle.ToSingle();

			if (ele.TryPathTo("Flags1", false, out subEle))
				Flags1 = subEle.ToEnum<WeaponDataFlags1>();

			if (ele.TryPathTo("GripAnimation", false, out subEle))
				GripAnimation = subEle.ToEnum<WeaponGripAnimationType>();

			if (ele.TryPathTo("AmmoUse", false, out subEle))
				AmmoUse = subEle.ToByte();

			if (ele.TryPathTo("ReloadAnimation", false, out subEle))
				ReloadAnimation = subEle.ToEnum<WeaponReloadAnimationType>();

			if (ele.TryPathTo("MinSpread", false, out subEle))
				MinSpread = subEle.ToSingle();

			if (ele.TryPathTo("Spread", false, out subEle))
				Spread = subEle.ToSingle();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();

			if (ele.TryPathTo("SightFOV", false, out subEle))
				SightFOV = subEle.ToSingle();

			if (ele.TryPathTo("Unknown2", false, out subEle))
				Unknown2 = subEle.ToSingle();

			if (ele.TryPathTo("Projectile", false, out subEle))
				Projectile.ReadXML(subEle, master);

			if (ele.TryPathTo("BaseVATSToHitChance", false, out subEle))
				BaseVATSToHitChance = subEle.ToByte();

			if (ele.TryPathTo("AttackAnimation", false, out subEle))
				AttackAnimation = subEle.ToEnum<WeaponAttackAnimationType>();

			if (ele.TryPathTo("ProjectileCount", false, out subEle))
				ProjectileCount = subEle.ToByte();

			if (ele.TryPathTo("EmbeddedWeaponActorValue", false, out subEle))
				EmbeddedWeaponActorValue = subEle.ToEnum<EmbeddedWeaponActorValue>();

			if (ele.TryPathTo("Range/Min", false, out subEle))
				MinRange = subEle.ToSingle();

			if (ele.TryPathTo("Range/Max", false, out subEle))
				MaxRange = subEle.ToSingle();

			if (ele.TryPathTo("LimbKillBehavior", false, out subEle))
				LimbKillBehavior = subEle.ToEnum<LimbKillBehavior>();

			if (ele.TryPathTo("Flags2", false, out subEle))
				Flags2 = subEle.ToEnum<WeaponDataFlags2>();

			if (ele.TryPathTo("AttackAnimationMultiplier", false, out subEle))
				AttackAnimationMultiplier = subEle.ToSingle();

			if (ele.TryPathTo("FireRate", false, out subEle))
				FireRate = subEle.ToSingle();

			if (ele.TryPathTo("ActionPointCost", false, out subEle))
				ActionPointCost = subEle.ToSingle();

			if (ele.TryPathTo("Rumble/LeftMotorStrength", false, out subEle))
				RumbleLeftMotorStrength = subEle.ToSingle();

			if (ele.TryPathTo("Rumble/RightMotorStrength", false, out subEle))
				RumbleRightMotorStrength = subEle.ToSingle();

			if (ele.TryPathTo("Rumble/Duration", false, out subEle))
				RumbleDuration = subEle.ToSingle();

			if (ele.TryPathTo("DamageToWeaponMult", false, out subEle))
				DamageToWeaponMult = subEle.ToSingle();

			if (ele.TryPathTo("AttackShotsPerSecond", false, out subEle))
				AttackShotsPerSecond = subEle.ToSingle();

			if (ele.TryPathTo("ReloadTime", false, out subEle))
				ReloadTime = subEle.ToSingle();

			if (ele.TryPathTo("JamTime", false, out subEle))
				JamTime = subEle.ToSingle();

			if (ele.TryPathTo("AimArc", false, out subEle))
				AimArc = subEle.ToSingle();

			if (ele.TryPathTo("Skill", false, out subEle))
				Skill = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("Rumble/Pattern", false, out subEle))
				RumblePattern = subEle.ToEnum<WeaponRumblePattern>();

			if (ele.TryPathTo("Rumble/Wavelength", false, out subEle))
				RumbleWavelength = subEle.ToSingle();

			if (ele.TryPathTo("LimbDamageMult", false, out subEle))
				LimbDamageMult = subEle.ToSingle();

			if (ele.TryPathTo("ResistanceType", false, out subEle))
				ResistanceType = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("SightUsage", false, out subEle))
				SightUsage = subEle.ToSingle();

			if (ele.TryPathTo("SemiAutomaticFireDelay/Min", false, out subEle))
				SemiAutomaticFireDelayMin = subEle.ToSingle();

			if (ele.TryPathTo("SemiAutomaticFireDelay/Max", false, out subEle))
				SemiAutomaticFireDelayMax = subEle.ToSingle();

			if (ele.TryPathTo("Unknown3", false, out subEle))
				Unknown3 = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod1/Effect", false, out subEle))
				Mod1Effect = subEle.ToEnum<WeaponModEffect>();

			if (ele.TryPathTo("Mods/Mod2/Effect", false, out subEle))
				Mod2Effect = subEle.ToEnum<WeaponModEffect>();

			if (ele.TryPathTo("Mods/Mod3/Effect", false, out subEle))
				Mod3Effect = subEle.ToEnum<WeaponModEffect>();

			if (ele.TryPathTo("Mods/Mod1/ValueA", false, out subEle))
				Mod1ValueA = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod2/ValueA", false, out subEle))
				Mod2ValueA = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod3/ValueA", false, out subEle))
				Mod3ValueA = subEle.ToSingle();

			if (ele.TryPathTo("PowerAttackAnimation", false, out subEle))
				PowerAttackAnimation = subEle.ToEnum<WeaponPowerAttackAnimation>();

			if (ele.TryPathTo("StrengthRequirement", false, out subEle))
				StrengthRequirement = subEle.ToUInt32();

			if (ele.TryPathTo("Unknown4", false, out subEle))
				Unknown4 = subEle.ToByte();

			if (ele.TryPathTo("Mods/Mod1/ReloadAnimation", false, out subEle))
				Mod1ReloadAnimation = subEle.ToEnum<WeaponReloadAnimationType>();

			if (ele.TryPathTo("Unknown5", false, out subEle))
				Unknown5 = subEle.ToBytes();

			if (ele.TryPathTo("AmmoRegenRate", false, out subEle))
				AmmoRegenRate = subEle.ToSingle();

			if (ele.TryPathTo("KillImpulse", false, out subEle))
				KillImpulse = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod1/ValueB", false, out subEle))
				Mod1ValueB = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod2/ValueB", false, out subEle))
				Mod2ValueB = subEle.ToSingle();

			if (ele.TryPathTo("Mods/Mod3/ValueB", false, out subEle))
				Mod3ValueB = subEle.ToSingle();

			if (ele.TryPathTo("ImpulseDistance", false, out subEle))
				ImpulseDistance = subEle.ToSingle();

			if (ele.TryPathTo("SkillRequirement", false, out subEle))
				SkillRequirement = subEle.ToUInt32();
		}

		public override object Clone()
		{
			return new WeaponExtraData(this);
		}

        public int CompareTo(WeaponExtraData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(WeaponExtraData objA, WeaponExtraData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WeaponExtraData objA, WeaponExtraData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WeaponExtraData objA, WeaponExtraData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WeaponExtraData objA, WeaponExtraData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(WeaponExtraData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return AnimationType == other.AnimationType &&
				AnimationMultiplier == other.AnimationMultiplier &&
				Reach == other.Reach &&
				Flags1 == other.Flags1 &&
				GripAnimation == other.GripAnimation &&
				AmmoUse == other.AmmoUse &&
				ReloadAnimation == other.ReloadAnimation &&
				MinSpread == other.MinSpread &&
				Spread == other.Spread &&
				Unknown.SequenceEqual(other.Unknown) &&
				SightFOV == other.SightFOV &&
				Unknown2 == other.Unknown2 &&
				Projectile == other.Projectile &&
				BaseVATSToHitChance == other.BaseVATSToHitChance &&
				AttackAnimation == other.AttackAnimation &&
				ProjectileCount == other.ProjectileCount &&
				EmbeddedWeaponActorValue == other.EmbeddedWeaponActorValue &&
				MinRange == other.MinRange &&
				MaxRange == other.MaxRange &&
				LimbKillBehavior == other.LimbKillBehavior &&
				Flags2 == other.Flags2 &&
				AttackAnimationMultiplier == other.AttackAnimationMultiplier &&
				FireRate == other.FireRate &&
				ActionPointCost == other.ActionPointCost &&
				RumbleLeftMotorStrength == other.RumbleLeftMotorStrength &&
				RumbleRightMotorStrength == other.RumbleRightMotorStrength &&
				RumbleDuration == other.RumbleDuration &&
				DamageToWeaponMult == other.DamageToWeaponMult &&
				AttackShotsPerSecond == other.AttackShotsPerSecond &&
				ReloadTime == other.ReloadTime &&
				JamTime == other.JamTime &&
				AimArc == other.AimArc &&
				Skill == other.Skill &&
				RumblePattern == other.RumblePattern &&
				RumbleWavelength == other.RumbleWavelength &&
				LimbDamageMult == other.LimbDamageMult &&
				ResistanceType == other.ResistanceType &&
				SightUsage == other.SightUsage &&
				SemiAutomaticFireDelayMin == other.SemiAutomaticFireDelayMin &&
				SemiAutomaticFireDelayMax == other.SemiAutomaticFireDelayMax &&
				Unknown3 == other.Unknown3 &&
				Mod1Effect == other.Mod1Effect &&
				Mod2Effect == other.Mod2Effect &&
				Mod3Effect == other.Mod3Effect &&
				Mod1ValueA == other.Mod1ValueA &&
				Mod2ValueA == other.Mod2ValueA &&
				Mod3ValueA == other.Mod3ValueA &&
				PowerAttackAnimation == other.PowerAttackAnimation &&
				StrengthRequirement == other.StrengthRequirement &&
				Unknown4 == other.Unknown4 &&
				Mod1ReloadAnimation == other.Mod1ReloadAnimation &&
				Unknown5.SequenceEqual(other.Unknown5) &&
				AmmoRegenRate == other.AmmoRegenRate &&
				KillImpulse == other.KillImpulse &&
				Mod1ValueB == other.Mod1ValueB &&
				Mod2ValueB == other.Mod2ValueB &&
				Mod3ValueB == other.Mod3ValueB &&
				ImpulseDistance == other.ImpulseDistance &&
				SkillRequirement == other.SkillRequirement;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeaponExtraData other = obj as WeaponExtraData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Skill.GetHashCode();
        }

        public static bool operator ==(WeaponExtraData objA, WeaponExtraData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(WeaponExtraData objA, WeaponExtraData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }
	}
}