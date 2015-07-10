
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
	public partial class CombatStyleDecision : Subrecord, ICloneable<CombatStyleDecision>, IComparable<CombatStyleDecision>, IEquatable<CombatStyleDecision>  
	{
		public Byte ManeuverDodgeChance { get; set; }
		public Byte ManeuverSidestepChance { get; set; }
		public Byte[] Unused1 { get; set; }
		public Single ManeuverDodgeLRTimerMin { get; set; }
		public Single ManeuverDodgeLRTimerMax { get; set; }
		public Single ManeuverDodgeForwardTimerMin { get; set; }
		public Single ManeuverDodgeForwardTimerMax { get; set; }
		public Single ManeuverDodgeBackwardTimerMin { get; set; }
		public Single ManeuverDodgeBackwardTimerMax { get; set; }
		public Single ManeuverDodgeIdleTimerMin { get; set; }
		public Single ManeuverDodgeIdleTimerMax { get; set; }
		public Byte MeleeBlockChance { get; set; }
		public Byte MeleeAttackChance { get; set; }
		public Byte[] Unused2 { get; set; }
		public Single MeleeRecoilStaggerBonusToAttack { get; set; }
		public Single MeleeUnconsciousBonusToAttack { get; set; }
		public Single MeleeHandToHandBonusToAttack { get; set; }
		public Byte MeleePowerAttackChance { get; set; }
		public Byte[] Unused3 { get; set; }
		public Single MeleePowerAttackRecoilStaggerBonus { get; set; }
		public Single MeleePowerAttackUnconsciousBonus { get; set; }
		public Byte MeleePowerAttackNormal { get; set; }
		public Byte MeleePowerAttackForward { get; set; }
		public Byte MeleePowerAttackBack { get; set; }
		public Byte MeleePowerAttackLeft { get; set; }
		public Byte MeleePowerAttackRight { get; set; }
		public Byte[] Unused4 { get; set; }
		public Single MeleeHoldTimerMin { get; set; }
		public Single MeleeHoldTimerMax { get; set; }
		public CombatStyleFlags Flags { get; set; }
		public Byte ManeuverAcrobaticDodgeChance { get; set; }
		public Byte MeleeRushingPowerAttackChance { get; set; }
		public Byte[] Unused5 { get; set; }
		public Single MeleeRushingPowerAttackDistanceMult { get; set; }

		public CombatStyleDecision()
		{
			ManeuverDodgeChance = new Byte();
			ManeuverSidestepChance = new Byte();
			Unused1 = new byte[2];
			ManeuverDodgeLRTimerMin = new Single();
			ManeuverDodgeLRTimerMax = new Single();
			ManeuverDodgeForwardTimerMin = new Single();
			ManeuverDodgeForwardTimerMax = new Single();
			ManeuverDodgeBackwardTimerMin = new Single();
			ManeuverDodgeBackwardTimerMax = new Single();
			ManeuverDodgeIdleTimerMin = new Single();
			ManeuverDodgeIdleTimerMax = new Single();
			MeleeBlockChance = new Byte();
			MeleeAttackChance = new Byte();
			Unused2 = new byte[2];
			MeleeRecoilStaggerBonusToAttack = new Single();
			MeleeUnconsciousBonusToAttack = new Single();
			MeleeHandToHandBonusToAttack = new Single();
			MeleePowerAttackChance = new Byte();
			Unused3 = new byte[3];
			MeleePowerAttackRecoilStaggerBonus = new Single();
			MeleePowerAttackUnconsciousBonus = new Single();
			MeleePowerAttackNormal = new Byte();
			MeleePowerAttackForward = new Byte();
			MeleePowerAttackBack = new Byte();
			MeleePowerAttackLeft = new Byte();
			MeleePowerAttackRight = new Byte();
			Unused4 = new byte[3];
			MeleeHoldTimerMin = new Single();
			MeleeHoldTimerMax = new Single();
			Flags = new CombatStyleFlags();
			ManeuverAcrobaticDodgeChance = new Byte();
			MeleeRushingPowerAttackChance = new Byte();
			Unused5 = new byte[2];
			MeleeRushingPowerAttackDistanceMult = new Single();
		}

		public CombatStyleDecision(Byte ManeuverDodgeChance, Byte ManeuverSidestepChance, Byte[] Unused1, Single ManeuverDodgeLRTimerMin, Single ManeuverDodgeLRTimerMax, Single ManeuverDodgeForwardTimerMin, Single ManeuverDodgeForwardTimerMax, Single ManeuverDodgeBackwardTimerMin, Single ManeuverDodgeBackwardTimerMax, Single ManeuverDodgeIdleTimerMin, Single ManeuverDodgeIdleTimerMax, Byte MeleeBlockChance, Byte MeleeAttackChance, Byte[] Unused2, Single MeleeRecoilStaggerBonusToAttack, Single MeleeUnconsciousBonusToAttack, Single MeleeHandToHandBonusToAttack, Byte MeleePowerAttackChance, Byte[] Unused3, Single MeleePowerAttackRecoilStaggerBonus, Single MeleePowerAttackUnconsciousBonus, Byte MeleePowerAttackNormal, Byte MeleePowerAttackForward, Byte MeleePowerAttackBack, Byte MeleePowerAttackLeft, Byte MeleePowerAttackRight, Byte[] Unused4, Single MeleeHoldTimerMin, Single MeleeHoldTimerMax, CombatStyleFlags Flags, Byte ManeuverAcrobaticDodgeChance, Byte MeleeRushingPowerAttackChance, Byte[] Unused5, Single MeleeRushingPowerAttackDistanceMult)
		{
			this.ManeuverDodgeChance = ManeuverDodgeChance;
			this.ManeuverSidestepChance = ManeuverSidestepChance;
			this.Unused1 = Unused1;
			this.ManeuverDodgeLRTimerMin = ManeuverDodgeLRTimerMin;
			this.ManeuverDodgeLRTimerMax = ManeuverDodgeLRTimerMax;
			this.ManeuverDodgeForwardTimerMin = ManeuverDodgeForwardTimerMin;
			this.ManeuverDodgeForwardTimerMax = ManeuverDodgeForwardTimerMax;
			this.ManeuverDodgeBackwardTimerMin = ManeuverDodgeBackwardTimerMin;
			this.ManeuverDodgeBackwardTimerMax = ManeuverDodgeBackwardTimerMax;
			this.ManeuverDodgeIdleTimerMin = ManeuverDodgeIdleTimerMin;
			this.ManeuverDodgeIdleTimerMax = ManeuverDodgeIdleTimerMax;
			this.MeleeBlockChance = MeleeBlockChance;
			this.MeleeAttackChance = MeleeAttackChance;
			this.Unused2 = Unused2;
			this.MeleeRecoilStaggerBonusToAttack = MeleeRecoilStaggerBonusToAttack;
			this.MeleeUnconsciousBonusToAttack = MeleeUnconsciousBonusToAttack;
			this.MeleeHandToHandBonusToAttack = MeleeHandToHandBonusToAttack;
			this.MeleePowerAttackChance = MeleePowerAttackChance;
			this.Unused3 = Unused3;
			this.MeleePowerAttackRecoilStaggerBonus = MeleePowerAttackRecoilStaggerBonus;
			this.MeleePowerAttackUnconsciousBonus = MeleePowerAttackUnconsciousBonus;
			this.MeleePowerAttackNormal = MeleePowerAttackNormal;
			this.MeleePowerAttackForward = MeleePowerAttackForward;
			this.MeleePowerAttackBack = MeleePowerAttackBack;
			this.MeleePowerAttackLeft = MeleePowerAttackLeft;
			this.MeleePowerAttackRight = MeleePowerAttackRight;
			this.Unused4 = Unused4;
			this.MeleeHoldTimerMin = MeleeHoldTimerMin;
			this.MeleeHoldTimerMax = MeleeHoldTimerMax;
			this.Flags = Flags;
			this.ManeuverAcrobaticDodgeChance = ManeuverAcrobaticDodgeChance;
			this.MeleeRushingPowerAttackChance = MeleeRushingPowerAttackChance;
			this.Unused5 = Unused5;
			this.MeleeRushingPowerAttackDistanceMult = MeleeRushingPowerAttackDistanceMult;
		}

		public CombatStyleDecision(CombatStyleDecision copyObject)
		{
			ManeuverDodgeChance = copyObject.ManeuverDodgeChance;
			ManeuverSidestepChance = copyObject.ManeuverSidestepChance;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			ManeuverDodgeLRTimerMin = copyObject.ManeuverDodgeLRTimerMin;
			ManeuverDodgeLRTimerMax = copyObject.ManeuverDodgeLRTimerMax;
			ManeuverDodgeForwardTimerMin = copyObject.ManeuverDodgeForwardTimerMin;
			ManeuverDodgeForwardTimerMax = copyObject.ManeuverDodgeForwardTimerMax;
			ManeuverDodgeBackwardTimerMin = copyObject.ManeuverDodgeBackwardTimerMin;
			ManeuverDodgeBackwardTimerMax = copyObject.ManeuverDodgeBackwardTimerMax;
			ManeuverDodgeIdleTimerMin = copyObject.ManeuverDodgeIdleTimerMin;
			ManeuverDodgeIdleTimerMax = copyObject.ManeuverDodgeIdleTimerMax;
			MeleeBlockChance = copyObject.MeleeBlockChance;
			MeleeAttackChance = copyObject.MeleeAttackChance;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
			MeleeRecoilStaggerBonusToAttack = copyObject.MeleeRecoilStaggerBonusToAttack;
			MeleeUnconsciousBonusToAttack = copyObject.MeleeUnconsciousBonusToAttack;
			MeleeHandToHandBonusToAttack = copyObject.MeleeHandToHandBonusToAttack;
			MeleePowerAttackChance = copyObject.MeleePowerAttackChance;
			Unused3 = (Byte[])copyObject.Unused3.Clone();
			MeleePowerAttackRecoilStaggerBonus = copyObject.MeleePowerAttackRecoilStaggerBonus;
			MeleePowerAttackUnconsciousBonus = copyObject.MeleePowerAttackUnconsciousBonus;
			MeleePowerAttackNormal = copyObject.MeleePowerAttackNormal;
			MeleePowerAttackForward = copyObject.MeleePowerAttackForward;
			MeleePowerAttackBack = copyObject.MeleePowerAttackBack;
			MeleePowerAttackLeft = copyObject.MeleePowerAttackLeft;
			MeleePowerAttackRight = copyObject.MeleePowerAttackRight;
			Unused4 = (Byte[])copyObject.Unused4.Clone();
			MeleeHoldTimerMin = copyObject.MeleeHoldTimerMin;
			MeleeHoldTimerMax = copyObject.MeleeHoldTimerMax;
			Flags = copyObject.Flags;
			ManeuverAcrobaticDodgeChance = copyObject.ManeuverAcrobaticDodgeChance;
			MeleeRushingPowerAttackChance = copyObject.MeleeRushingPowerAttackChance;
			Unused5 = (Byte[])copyObject.Unused5.Clone();
			MeleeRushingPowerAttackDistanceMult = copyObject.MeleeRushingPowerAttackDistanceMult;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					ManeuverDodgeChance = subReader.ReadByte();
					ManeuverSidestepChance = subReader.ReadByte();
					Unused1 = subReader.ReadBytes(2);
					ManeuverDodgeLRTimerMin = subReader.ReadSingle();
					ManeuverDodgeLRTimerMax = subReader.ReadSingle();
					ManeuverDodgeForwardTimerMin = subReader.ReadSingle();
					ManeuverDodgeForwardTimerMax = subReader.ReadSingle();
					ManeuverDodgeBackwardTimerMin = subReader.ReadSingle();
					ManeuverDodgeBackwardTimerMax = subReader.ReadSingle();
					ManeuverDodgeIdleTimerMin = subReader.ReadSingle();
					ManeuverDodgeIdleTimerMax = subReader.ReadSingle();
					MeleeBlockChance = subReader.ReadByte();
					MeleeAttackChance = subReader.ReadByte();
					Unused2 = subReader.ReadBytes(2);
					MeleeRecoilStaggerBonusToAttack = subReader.ReadSingle();
					MeleeUnconsciousBonusToAttack = subReader.ReadSingle();
					MeleeHandToHandBonusToAttack = subReader.ReadSingle();
					MeleePowerAttackChance = subReader.ReadByte();
					Unused3 = subReader.ReadBytes(3);
					MeleePowerAttackRecoilStaggerBonus = subReader.ReadSingle();
					MeleePowerAttackUnconsciousBonus = subReader.ReadSingle();
					MeleePowerAttackNormal = subReader.ReadByte();
					MeleePowerAttackForward = subReader.ReadByte();
					MeleePowerAttackBack = subReader.ReadByte();
					MeleePowerAttackLeft = subReader.ReadByte();
					MeleePowerAttackRight = subReader.ReadByte();
					Unused4 = subReader.ReadBytes(3);
					MeleeHoldTimerMin = subReader.ReadSingle();
					MeleeHoldTimerMax = subReader.ReadSingle();
					Flags = subReader.ReadEnum<CombatStyleFlags>();
					ManeuverAcrobaticDodgeChance = subReader.ReadByte();
					MeleeRushingPowerAttackChance = subReader.ReadByte();
					Unused5 = subReader.ReadBytes(2);
					MeleeRushingPowerAttackDistanceMult = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(ManeuverDodgeChance);
			writer.Write(ManeuverSidestepChance);
			if (Unused1 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused1);
			writer.Write(ManeuverDodgeLRTimerMin);
			writer.Write(ManeuverDodgeLRTimerMax);
			writer.Write(ManeuverDodgeForwardTimerMin);
			writer.Write(ManeuverDodgeForwardTimerMax);
			writer.Write(ManeuverDodgeBackwardTimerMin);
			writer.Write(ManeuverDodgeBackwardTimerMax);
			writer.Write(ManeuverDodgeIdleTimerMin);
			writer.Write(ManeuverDodgeIdleTimerMax);
			writer.Write(MeleeBlockChance);
			writer.Write(MeleeAttackChance);
			if (Unused2 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused2);
			writer.Write(MeleeRecoilStaggerBonusToAttack);
			writer.Write(MeleeUnconsciousBonusToAttack);
			writer.Write(MeleeHandToHandBonusToAttack);
			writer.Write(MeleePowerAttackChance);
			if (Unused3 == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused3);
			writer.Write(MeleePowerAttackRecoilStaggerBonus);
			writer.Write(MeleePowerAttackUnconsciousBonus);
			writer.Write(MeleePowerAttackNormal);
			writer.Write(MeleePowerAttackForward);
			writer.Write(MeleePowerAttackBack);
			writer.Write(MeleePowerAttackLeft);
			writer.Write(MeleePowerAttackRight);
			if (Unused4 == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused4);
			writer.Write(MeleeHoldTimerMin);
			writer.Write(MeleeHoldTimerMax);
			writer.Write((UInt32)Flags);
			writer.Write(ManeuverAcrobaticDodgeChance);
			writer.Write(MeleeRushingPowerAttackChance);
			if (Unused5 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused5);
			writer.Write(MeleeRushingPowerAttackDistanceMult);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Maneuver/DodgeChance", true, out subEle);
			subEle.Value = ManeuverDodgeChance.ToString();

			ele.TryPathTo("Maneuver/SidestepChance", true, out subEle);
			subEle.Value = ManeuverSidestepChance.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("Maneuver/DodgeLRTimer/Min", true, out subEle);
			subEle.Value = ManeuverDodgeLRTimerMin.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeLRTimer/Max", true, out subEle);
			subEle.Value = ManeuverDodgeLRTimerMax.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeForwardTimer/Min", true, out subEle);
			subEle.Value = ManeuverDodgeForwardTimerMin.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeForwardTimer/Max", true, out subEle);
			subEle.Value = ManeuverDodgeForwardTimerMax.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeBackwardTimer/Min", true, out subEle);
			subEle.Value = ManeuverDodgeBackwardTimerMin.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeBackwardTimer/Max", true, out subEle);
			subEle.Value = ManeuverDodgeBackwardTimerMax.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeIdleTimer/Min", true, out subEle);
			subEle.Value = ManeuverDodgeIdleTimerMin.ToString("G15");

			ele.TryPathTo("Maneuver/DodgeIdleTimer/Max", true, out subEle);
			subEle.Value = ManeuverDodgeIdleTimerMax.ToString("G15");

			ele.TryPathTo("Melee/BlockChance", true, out subEle);
			subEle.Value = MeleeBlockChance.ToString();

			ele.TryPathTo("Melee/AttackChance", true, out subEle);
			subEle.Value = MeleeAttackChance.ToString();

			WriteUnused2XML(ele, master);

			ele.TryPathTo("Melee/RecoilStaggerBonusToAttack", true, out subEle);
			subEle.Value = MeleeRecoilStaggerBonusToAttack.ToString("G15");

			ele.TryPathTo("Melee/UnconsciousBonusToAttack", true, out subEle);
			subEle.Value = MeleeUnconsciousBonusToAttack.ToString("G15");

			ele.TryPathTo("Melee/HandToHandBonusToAttack", true, out subEle);
			subEle.Value = MeleeHandToHandBonusToAttack.ToString("G15");

			ele.TryPathTo("Melee/PowerAttack/Chance", true, out subEle);
			subEle.Value = MeleePowerAttackChance.ToString();

			WriteUnused3XML(ele, master);

			ele.TryPathTo("Melee/PowerAttack/RecoilStaggerBonus", true, out subEle);
			subEle.Value = MeleePowerAttackRecoilStaggerBonus.ToString("G15");

			ele.TryPathTo("Melee/PowerAttack/UnconsciousBonus", true, out subEle);
			subEle.Value = MeleePowerAttackUnconsciousBonus.ToString("G15");

			ele.TryPathTo("Melee/PowerAttack/Normal", true, out subEle);
			subEle.Value = MeleePowerAttackNormal.ToString();

			ele.TryPathTo("Melee/PowerAttack/Forward", true, out subEle);
			subEle.Value = MeleePowerAttackForward.ToString();

			ele.TryPathTo("Melee/PowerAttack/Back", true, out subEle);
			subEle.Value = MeleePowerAttackBack.ToString();

			ele.TryPathTo("Melee/PowerAttack/Left", true, out subEle);
			subEle.Value = MeleePowerAttackLeft.ToString();

			ele.TryPathTo("Melee/PowerAttack/Right", true, out subEle);
			subEle.Value = MeleePowerAttackRight.ToString();

			WriteUnused4XML(ele, master);

			ele.TryPathTo("Melee/HoldTimer/Min", true, out subEle);
			subEle.Value = MeleeHoldTimerMin.ToString("G15");

			ele.TryPathTo("Melee/HoldTimer/Max", true, out subEle);
			subEle.Value = MeleeHoldTimerMax.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Maneuver/AcrobaticDodgeChance", true, out subEle);
			subEle.Value = ManeuverAcrobaticDodgeChance.ToString();

			ele.TryPathTo("Melee/PowerAttack/RushingChance", true, out subEle);
			subEle.Value = MeleeRushingPowerAttackChance.ToString();

			WriteUnused5XML(ele, master);

			ele.TryPathTo("Melee/PowerAttack/DistanceMult", true, out subEle);
			subEle.Value = MeleeRushingPowerAttackDistanceMult.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Maneuver/DodgeChance", false, out subEle))
				ManeuverDodgeChance = subEle.ToByte();

			if (ele.TryPathTo("Maneuver/SidestepChance", false, out subEle))
				ManeuverSidestepChance = subEle.ToByte();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("Maneuver/DodgeLRTimer/Min", false, out subEle))
				ManeuverDodgeLRTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeLRTimer/Max", false, out subEle))
				ManeuverDodgeLRTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeForwardTimer/Min", false, out subEle))
				ManeuverDodgeForwardTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeForwardTimer/Max", false, out subEle))
				ManeuverDodgeForwardTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeBackwardTimer/Min", false, out subEle))
				ManeuverDodgeBackwardTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeBackwardTimer/Max", false, out subEle))
				ManeuverDodgeBackwardTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeIdleTimer/Min", false, out subEle))
				ManeuverDodgeIdleTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("Maneuver/DodgeIdleTimer/Max", false, out subEle))
				ManeuverDodgeIdleTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("Melee/BlockChance", false, out subEle))
				MeleeBlockChance = subEle.ToByte();

			if (ele.TryPathTo("Melee/AttackChance", false, out subEle))
				MeleeAttackChance = subEle.ToByte();

			ReadUnused2XML(ele, master);

			if (ele.TryPathTo("Melee/RecoilStaggerBonusToAttack", false, out subEle))
				MeleeRecoilStaggerBonusToAttack = subEle.ToSingle();

			if (ele.TryPathTo("Melee/UnconsciousBonusToAttack", false, out subEle))
				MeleeUnconsciousBonusToAttack = subEle.ToSingle();

			if (ele.TryPathTo("Melee/HandToHandBonusToAttack", false, out subEle))
				MeleeHandToHandBonusToAttack = subEle.ToSingle();

			if (ele.TryPathTo("Melee/PowerAttack/Chance", false, out subEle))
				MeleePowerAttackChance = subEle.ToByte();

			ReadUnused3XML(ele, master);

			if (ele.TryPathTo("Melee/PowerAttack/RecoilStaggerBonus", false, out subEle))
				MeleePowerAttackRecoilStaggerBonus = subEle.ToSingle();

			if (ele.TryPathTo("Melee/PowerAttack/UnconsciousBonus", false, out subEle))
				MeleePowerAttackUnconsciousBonus = subEle.ToSingle();

			if (ele.TryPathTo("Melee/PowerAttack/Normal", false, out subEle))
				MeleePowerAttackNormal = subEle.ToByte();

			if (ele.TryPathTo("Melee/PowerAttack/Forward", false, out subEle))
				MeleePowerAttackForward = subEle.ToByte();

			if (ele.TryPathTo("Melee/PowerAttack/Back", false, out subEle))
				MeleePowerAttackBack = subEle.ToByte();

			if (ele.TryPathTo("Melee/PowerAttack/Left", false, out subEle))
				MeleePowerAttackLeft = subEle.ToByte();

			if (ele.TryPathTo("Melee/PowerAttack/Right", false, out subEle))
				MeleePowerAttackRight = subEle.ToByte();

			ReadUnused4XML(ele, master);

			if (ele.TryPathTo("Melee/HoldTimer/Min", false, out subEle))
				MeleeHoldTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("Melee/HoldTimer/Max", false, out subEle))
				MeleeHoldTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<CombatStyleFlags>();

			if (ele.TryPathTo("Maneuver/AcrobaticDodgeChance", false, out subEle))
				ManeuverAcrobaticDodgeChance = subEle.ToByte();

			if (ele.TryPathTo("Melee/PowerAttack/RushingChance", false, out subEle))
				MeleeRushingPowerAttackChance = subEle.ToByte();

			ReadUnused5XML(ele, master);

			if (ele.TryPathTo("Melee/PowerAttack/DistanceMult", false, out subEle))
				MeleeRushingPowerAttackDistanceMult = subEle.ToSingle();
		}

		public CombatStyleDecision Clone()
		{
			return new CombatStyleDecision(this);
		}

        public int CompareTo(CombatStyleDecision other)
        {
			return ManeuverDodgeChance.CompareTo(other.ManeuverDodgeChance);
        }

        public static bool operator >(CombatStyleDecision objA, CombatStyleDecision objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CombatStyleDecision objA, CombatStyleDecision objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CombatStyleDecision objA, CombatStyleDecision objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CombatStyleDecision objA, CombatStyleDecision objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CombatStyleDecision other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ManeuverDodgeChance == other.ManeuverDodgeChance &&
				ManeuverSidestepChance == other.ManeuverSidestepChance &&
				Unused1.SequenceEqual(other.Unused1) &&
				ManeuverDodgeLRTimerMin == other.ManeuverDodgeLRTimerMin &&
				ManeuverDodgeLRTimerMax == other.ManeuverDodgeLRTimerMax &&
				ManeuverDodgeForwardTimerMin == other.ManeuverDodgeForwardTimerMin &&
				ManeuverDodgeForwardTimerMax == other.ManeuverDodgeForwardTimerMax &&
				ManeuverDodgeBackwardTimerMin == other.ManeuverDodgeBackwardTimerMin &&
				ManeuverDodgeBackwardTimerMax == other.ManeuverDodgeBackwardTimerMax &&
				ManeuverDodgeIdleTimerMin == other.ManeuverDodgeIdleTimerMin &&
				ManeuverDodgeIdleTimerMax == other.ManeuverDodgeIdleTimerMax &&
				MeleeBlockChance == other.MeleeBlockChance &&
				MeleeAttackChance == other.MeleeAttackChance &&
				Unused2.SequenceEqual(other.Unused2) &&
				MeleeRecoilStaggerBonusToAttack == other.MeleeRecoilStaggerBonusToAttack &&
				MeleeUnconsciousBonusToAttack == other.MeleeUnconsciousBonusToAttack &&
				MeleeHandToHandBonusToAttack == other.MeleeHandToHandBonusToAttack &&
				MeleePowerAttackChance == other.MeleePowerAttackChance &&
				Unused3.SequenceEqual(other.Unused3) &&
				MeleePowerAttackRecoilStaggerBonus == other.MeleePowerAttackRecoilStaggerBonus &&
				MeleePowerAttackUnconsciousBonus == other.MeleePowerAttackUnconsciousBonus &&
				MeleePowerAttackNormal == other.MeleePowerAttackNormal &&
				MeleePowerAttackForward == other.MeleePowerAttackForward &&
				MeleePowerAttackBack == other.MeleePowerAttackBack &&
				MeleePowerAttackLeft == other.MeleePowerAttackLeft &&
				MeleePowerAttackRight == other.MeleePowerAttackRight &&
				Unused4.SequenceEqual(other.Unused4) &&
				MeleeHoldTimerMin == other.MeleeHoldTimerMin &&
				MeleeHoldTimerMax == other.MeleeHoldTimerMax &&
				Flags == other.Flags &&
				ManeuverAcrobaticDodgeChance == other.ManeuverAcrobaticDodgeChance &&
				MeleeRushingPowerAttackChance == other.MeleeRushingPowerAttackChance &&
				Unused5.SequenceEqual(other.Unused5) &&
				MeleeRushingPowerAttackDistanceMult == other.MeleeRushingPowerAttackDistanceMult;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CombatStyleDecision other = obj as CombatStyleDecision;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ManeuverDodgeChance.GetHashCode();
        }

        public static bool operator ==(CombatStyleDecision objA, CombatStyleDecision objB)
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

        public static bool operator !=(CombatStyleDecision objA, CombatStyleDecision objB)
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

		partial void ReadUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused3XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused4XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused5XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused3XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused4XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused5XML(XElement ele, ElderScrollsPlugin master);
	}
}