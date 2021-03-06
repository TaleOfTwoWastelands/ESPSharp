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

namespace ESPSharp.Subrecords
{
	public partial class CombatStyleAdvanced : Subrecord, ICloneable, IComparable<CombatStyleAdvanced>, IEquatable<CombatStyleAdvanced>  
	{
		public Single DodgeFatigueModMult { get; set; }
		public Single DodgeFatigueModBase { get; set; }
		public Single EncumbSpeedModBase { get; set; }
		public Single EncumbSpeedModMult { get; set; }
		public Single DodgeWhileUnderAttackMult { get; set; }
		public Single DodgeNotUnderAttackMult { get; set; }
		public Single DodgeBackWhileUnderAttackMult { get; set; }
		public Single DodgeBackNotUnderAttackMult { get; set; }
		public Single DodgeForwardWhileAttackingMult { get; set; }
		public Single DodgeForwardNotAttackingMult { get; set; }
		public Single BlockSkillModifierMult { get; set; }
		public Single BlockSkillModifierBase { get; set; }
		public Single BlockWhileUnderAttackMult { get; set; }
		public Single BlockNotUnderAttackMult { get; set; }
		public Single AttackSkillModifierMult { get; set; }
		public Single AttackSkillModifierBase { get; set; }
		public Single AttackWhileUnderAttackMult { get; set; }
		public Single AttackNotUnderAttackMult { get; set; }
		public Single AttackDuringBlockMult { get; set; }
		public Single PowerAttackFatigueModBase { get; set; }
		public Single PowerAttackFatigueModMult { get; set; }


		public CombatStyleAdvanced(string Tag = null)
			:base(Tag)
		{
			DodgeFatigueModMult = new Single();
			DodgeFatigueModBase = new Single();
			EncumbSpeedModBase = new Single();
			EncumbSpeedModMult = new Single();
			DodgeWhileUnderAttackMult = new Single();
			DodgeNotUnderAttackMult = new Single();
			DodgeBackWhileUnderAttackMult = new Single();
			DodgeBackNotUnderAttackMult = new Single();
			DodgeForwardWhileAttackingMult = new Single();
			DodgeForwardNotAttackingMult = new Single();
			BlockSkillModifierMult = new Single();
			BlockSkillModifierBase = new Single();
			BlockWhileUnderAttackMult = new Single();
			BlockNotUnderAttackMult = new Single();
			AttackSkillModifierMult = new Single();
			AttackSkillModifierBase = new Single();
			AttackWhileUnderAttackMult = new Single();
			AttackNotUnderAttackMult = new Single();
			AttackDuringBlockMult = new Single();
			PowerAttackFatigueModBase = new Single();
			PowerAttackFatigueModMult = new Single();

		}

		public CombatStyleAdvanced(Single DodgeFatigueModMult, Single DodgeFatigueModBase, Single EncumbSpeedModBase, Single EncumbSpeedModMult, Single DodgeWhileUnderAttackMult, Single DodgeNotUnderAttackMult, Single DodgeBackWhileUnderAttackMult, Single DodgeBackNotUnderAttackMult, Single DodgeForwardWhileAttackingMult, Single DodgeForwardNotAttackingMult, Single BlockSkillModifierMult, Single BlockSkillModifierBase, Single BlockWhileUnderAttackMult, Single BlockNotUnderAttackMult, Single AttackSkillModifierMult, Single AttackSkillModifierBase, Single AttackWhileUnderAttackMult, Single AttackNotUnderAttackMult, Single AttackDuringBlockMult, Single PowerAttackFatigueModBase, Single PowerAttackFatigueModMult)
		{
			this.DodgeFatigueModMult = DodgeFatigueModMult;
			this.DodgeFatigueModBase = DodgeFatigueModBase;
			this.EncumbSpeedModBase = EncumbSpeedModBase;
			this.EncumbSpeedModMult = EncumbSpeedModMult;
			this.DodgeWhileUnderAttackMult = DodgeWhileUnderAttackMult;
			this.DodgeNotUnderAttackMult = DodgeNotUnderAttackMult;
			this.DodgeBackWhileUnderAttackMult = DodgeBackWhileUnderAttackMult;
			this.DodgeBackNotUnderAttackMult = DodgeBackNotUnderAttackMult;
			this.DodgeForwardWhileAttackingMult = DodgeForwardWhileAttackingMult;
			this.DodgeForwardNotAttackingMult = DodgeForwardNotAttackingMult;
			this.BlockSkillModifierMult = BlockSkillModifierMult;
			this.BlockSkillModifierBase = BlockSkillModifierBase;
			this.BlockWhileUnderAttackMult = BlockWhileUnderAttackMult;
			this.BlockNotUnderAttackMult = BlockNotUnderAttackMult;
			this.AttackSkillModifierMult = AttackSkillModifierMult;
			this.AttackSkillModifierBase = AttackSkillModifierBase;
			this.AttackWhileUnderAttackMult = AttackWhileUnderAttackMult;
			this.AttackNotUnderAttackMult = AttackNotUnderAttackMult;
			this.AttackDuringBlockMult = AttackDuringBlockMult;
			this.PowerAttackFatigueModBase = PowerAttackFatigueModBase;
			this.PowerAttackFatigueModMult = PowerAttackFatigueModMult;

		}

		public CombatStyleAdvanced(CombatStyleAdvanced copyObject)
		{
			DodgeFatigueModMult = copyObject.DodgeFatigueModMult;
			DodgeFatigueModBase = copyObject.DodgeFatigueModBase;
			EncumbSpeedModBase = copyObject.EncumbSpeedModBase;
			EncumbSpeedModMult = copyObject.EncumbSpeedModMult;
			DodgeWhileUnderAttackMult = copyObject.DodgeWhileUnderAttackMult;
			DodgeNotUnderAttackMult = copyObject.DodgeNotUnderAttackMult;
			DodgeBackWhileUnderAttackMult = copyObject.DodgeBackWhileUnderAttackMult;
			DodgeBackNotUnderAttackMult = copyObject.DodgeBackNotUnderAttackMult;
			DodgeForwardWhileAttackingMult = copyObject.DodgeForwardWhileAttackingMult;
			DodgeForwardNotAttackingMult = copyObject.DodgeForwardNotAttackingMult;
			BlockSkillModifierMult = copyObject.BlockSkillModifierMult;
			BlockSkillModifierBase = copyObject.BlockSkillModifierBase;
			BlockWhileUnderAttackMult = copyObject.BlockWhileUnderAttackMult;
			BlockNotUnderAttackMult = copyObject.BlockNotUnderAttackMult;
			AttackSkillModifierMult = copyObject.AttackSkillModifierMult;
			AttackSkillModifierBase = copyObject.AttackSkillModifierBase;
			AttackWhileUnderAttackMult = copyObject.AttackWhileUnderAttackMult;
			AttackNotUnderAttackMult = copyObject.AttackNotUnderAttackMult;
			AttackDuringBlockMult = copyObject.AttackDuringBlockMult;
			PowerAttackFatigueModBase = copyObject.PowerAttackFatigueModBase;
			PowerAttackFatigueModMult = copyObject.PowerAttackFatigueModMult;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					DodgeFatigueModMult = subReader.ReadSingle();
					DodgeFatigueModBase = subReader.ReadSingle();
					EncumbSpeedModBase = subReader.ReadSingle();
					EncumbSpeedModMult = subReader.ReadSingle();
					DodgeWhileUnderAttackMult = subReader.ReadSingle();
					DodgeNotUnderAttackMult = subReader.ReadSingle();
					DodgeBackWhileUnderAttackMult = subReader.ReadSingle();
					DodgeBackNotUnderAttackMult = subReader.ReadSingle();
					DodgeForwardWhileAttackingMult = subReader.ReadSingle();
					DodgeForwardNotAttackingMult = subReader.ReadSingle();
					BlockSkillModifierMult = subReader.ReadSingle();
					BlockSkillModifierBase = subReader.ReadSingle();
					BlockWhileUnderAttackMult = subReader.ReadSingle();
					BlockNotUnderAttackMult = subReader.ReadSingle();
					AttackSkillModifierMult = subReader.ReadSingle();
					AttackSkillModifierBase = subReader.ReadSingle();
					AttackWhileUnderAttackMult = subReader.ReadSingle();
					AttackNotUnderAttackMult = subReader.ReadSingle();
					AttackDuringBlockMult = subReader.ReadSingle();
					PowerAttackFatigueModBase = subReader.ReadSingle();
					PowerAttackFatigueModMult = subReader.ReadSingle();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DodgeFatigueModMult);
			writer.Write(DodgeFatigueModBase);
			writer.Write(EncumbSpeedModBase);
			writer.Write(EncumbSpeedModMult);
			writer.Write(DodgeWhileUnderAttackMult);
			writer.Write(DodgeNotUnderAttackMult);
			writer.Write(DodgeBackWhileUnderAttackMult);
			writer.Write(DodgeBackNotUnderAttackMult);
			writer.Write(DodgeForwardWhileAttackingMult);
			writer.Write(DodgeForwardNotAttackingMult);
			writer.Write(BlockSkillModifierMult);
			writer.Write(BlockSkillModifierBase);
			writer.Write(BlockWhileUnderAttackMult);
			writer.Write(BlockNotUnderAttackMult);
			writer.Write(AttackSkillModifierMult);
			writer.Write(AttackSkillModifierBase);
			writer.Write(AttackWhileUnderAttackMult);
			writer.Write(AttackNotUnderAttackMult);
			writer.Write(AttackDuringBlockMult);
			writer.Write(PowerAttackFatigueModBase);
			writer.Write(PowerAttackFatigueModMult);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("DodgeFatigueMod/Mult", true, out subEle);
			subEle.Value = DodgeFatigueModMult.ToString("G15");

			ele.TryPathTo("DodgeFatigueMod/Base", true, out subEle);
			subEle.Value = DodgeFatigueModBase.ToString("G15");

			ele.TryPathTo("EncumbSpeedMod/Base", true, out subEle);
			subEle.Value = EncumbSpeedModBase.ToString("G15");

			ele.TryPathTo("EncumbSpeedMod/Mult", true, out subEle);
			subEle.Value = EncumbSpeedModMult.ToString("G15");

			ele.TryPathTo("DodgeWhileUnderAttackMult", true, out subEle);
			subEle.Value = DodgeWhileUnderAttackMult.ToString("G15");

			ele.TryPathTo("DodgeNotUnderAttackMult", true, out subEle);
			subEle.Value = DodgeNotUnderAttackMult.ToString("G15");

			ele.TryPathTo("DodgeBackWhileUnderAttackMult", true, out subEle);
			subEle.Value = DodgeBackWhileUnderAttackMult.ToString("G15");

			ele.TryPathTo("DodgeBackNotUnderAttackMult", true, out subEle);
			subEle.Value = DodgeBackNotUnderAttackMult.ToString("G15");

			ele.TryPathTo("DodgeForwardWhileAttackingMult", true, out subEle);
			subEle.Value = DodgeForwardWhileAttackingMult.ToString("G15");

			ele.TryPathTo("DodgeForwardNotAttackingMult", true, out subEle);
			subEle.Value = DodgeForwardNotAttackingMult.ToString("G15");

			ele.TryPathTo("BlockSkillModifier/Mult", true, out subEle);
			subEle.Value = BlockSkillModifierMult.ToString("G15");

			ele.TryPathTo("BlockSkillModifier/Base", true, out subEle);
			subEle.Value = BlockSkillModifierBase.ToString("G15");

			ele.TryPathTo("BlockWhileUnderAttackMult", true, out subEle);
			subEle.Value = BlockWhileUnderAttackMult.ToString("G15");

			ele.TryPathTo("BlockNotUnderAttackMult", true, out subEle);
			subEle.Value = BlockNotUnderAttackMult.ToString("G15");

			ele.TryPathTo("AttackSkillModifier/Mult", true, out subEle);
			subEle.Value = AttackSkillModifierMult.ToString("G15");

			ele.TryPathTo("AttackSkillModifier/Base", true, out subEle);
			subEle.Value = AttackSkillModifierBase.ToString("G15");

			ele.TryPathTo("AttackWhileUnderAttackMult", true, out subEle);
			subEle.Value = AttackWhileUnderAttackMult.ToString("G15");

			ele.TryPathTo("AttackNotUnderAttackMult", true, out subEle);
			subEle.Value = AttackNotUnderAttackMult.ToString("G15");

			ele.TryPathTo("AttackDuringBlockMult", true, out subEle);
			subEle.Value = AttackDuringBlockMult.ToString("G15");

			ele.TryPathTo("PowerAttackFatigueMod/Base", true, out subEle);
			subEle.Value = PowerAttackFatigueModBase.ToString("G15");

			ele.TryPathTo("PowerAttackFatigueMod/Mult", true, out subEle);
			subEle.Value = PowerAttackFatigueModMult.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("DodgeFatigueMod/Mult", false, out subEle))
				DodgeFatigueModMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeFatigueMod/Base", false, out subEle))
				DodgeFatigueModBase = subEle.ToSingle();

			if (ele.TryPathTo("EncumbSpeedMod/Base", false, out subEle))
				EncumbSpeedModBase = subEle.ToSingle();

			if (ele.TryPathTo("EncumbSpeedMod/Mult", false, out subEle))
				EncumbSpeedModMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeWhileUnderAttackMult", false, out subEle))
				DodgeWhileUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeNotUnderAttackMult", false, out subEle))
				DodgeNotUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeBackWhileUnderAttackMult", false, out subEle))
				DodgeBackWhileUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeBackNotUnderAttackMult", false, out subEle))
				DodgeBackNotUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeForwardWhileAttackingMult", false, out subEle))
				DodgeForwardWhileAttackingMult = subEle.ToSingle();

			if (ele.TryPathTo("DodgeForwardNotAttackingMult", false, out subEle))
				DodgeForwardNotAttackingMult = subEle.ToSingle();

			if (ele.TryPathTo("BlockSkillModifier/Mult", false, out subEle))
				BlockSkillModifierMult = subEle.ToSingle();

			if (ele.TryPathTo("BlockSkillModifier/Base", false, out subEle))
				BlockSkillModifierBase = subEle.ToSingle();

			if (ele.TryPathTo("BlockWhileUnderAttackMult", false, out subEle))
				BlockWhileUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("BlockNotUnderAttackMult", false, out subEle))
				BlockNotUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("AttackSkillModifier/Mult", false, out subEle))
				AttackSkillModifierMult = subEle.ToSingle();

			if (ele.TryPathTo("AttackSkillModifier/Base", false, out subEle))
				AttackSkillModifierBase = subEle.ToSingle();

			if (ele.TryPathTo("AttackWhileUnderAttackMult", false, out subEle))
				AttackWhileUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("AttackNotUnderAttackMult", false, out subEle))
				AttackNotUnderAttackMult = subEle.ToSingle();

			if (ele.TryPathTo("AttackDuringBlockMult", false, out subEle))
				AttackDuringBlockMult = subEle.ToSingle();

			if (ele.TryPathTo("PowerAttackFatigueMod/Base", false, out subEle))
				PowerAttackFatigueModBase = subEle.ToSingle();

			if (ele.TryPathTo("PowerAttackFatigueMod/Mult", false, out subEle))
				PowerAttackFatigueModMult = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new CombatStyleAdvanced(this);
		}


        public int CompareTo(CombatStyleAdvanced other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(CombatStyleAdvanced other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DodgeFatigueModMult == other.DodgeFatigueModMult &&
				DodgeFatigueModBase == other.DodgeFatigueModBase &&
				EncumbSpeedModBase == other.EncumbSpeedModBase &&
				EncumbSpeedModMult == other.EncumbSpeedModMult &&
				DodgeWhileUnderAttackMult == other.DodgeWhileUnderAttackMult &&
				DodgeNotUnderAttackMult == other.DodgeNotUnderAttackMult &&
				DodgeBackWhileUnderAttackMult == other.DodgeBackWhileUnderAttackMult &&
				DodgeBackNotUnderAttackMult == other.DodgeBackNotUnderAttackMult &&
				DodgeForwardWhileAttackingMult == other.DodgeForwardWhileAttackingMult &&
				DodgeForwardNotAttackingMult == other.DodgeForwardNotAttackingMult &&
				BlockSkillModifierMult == other.BlockSkillModifierMult &&
				BlockSkillModifierBase == other.BlockSkillModifierBase &&
				BlockWhileUnderAttackMult == other.BlockWhileUnderAttackMult &&
				BlockNotUnderAttackMult == other.BlockNotUnderAttackMult &&
				AttackSkillModifierMult == other.AttackSkillModifierMult &&
				AttackSkillModifierBase == other.AttackSkillModifierBase &&
				AttackWhileUnderAttackMult == other.AttackWhileUnderAttackMult &&
				AttackNotUnderAttackMult == other.AttackNotUnderAttackMult &&
				AttackDuringBlockMult == other.AttackDuringBlockMult &&
				PowerAttackFatigueModBase == other.PowerAttackFatigueModBase &&
				PowerAttackFatigueModMult == other.PowerAttackFatigueModMult;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CombatStyleAdvanced other = obj as CombatStyleAdvanced;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return DodgeFatigueModMult.GetHashCode();
        }

        public static bool operator ==(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
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

        public static bool operator !=(CombatStyleAdvanced objA, CombatStyleAdvanced objB)
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