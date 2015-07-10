
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
	public partial class CombatStyleSimple : Subrecord, ICloneable<CombatStyleSimple>, IComparable<CombatStyleSimple>, IEquatable<CombatStyleSimple>  
	{
		public Single CoverSearchRadius { get; set; }
		public Single TakeCoverChance { get; set; }
		public Single WaitTimerMin { get; set; }
		public Single WaitTimerMax { get; set; }
		public Single WaitToFireTimerMin { get; set; }
		public Single WaitToFireTimerMax { get; set; }
		public Single FireTimerMin { get; set; }
		public Single FireTimerMax { get; set; }
		public Single RangedWeaponRangeMultMin { get; set; }
		public Byte[] Unused { get; set; }
		public WeaponRestrictions WeaponRestrictions { get; set; }
		public Single RangedWeaponRangeMultMax { get; set; }
		public Single MaxTargetingFOV { get; set; }
		public Single CombatRadius { get; set; }
		public Single SemiAutoFiringDelayMultMin { get; set; }
		public Single SemiAutoFiringDelayMultMax { get; set; }

		public CombatStyleSimple()
		{
			CoverSearchRadius = new Single();
			TakeCoverChance = new Single();
			WaitTimerMin = new Single();
			WaitTimerMax = new Single();
			WaitToFireTimerMin = new Single();
			WaitToFireTimerMax = new Single();
			FireTimerMin = new Single();
			FireTimerMax = new Single();
			RangedWeaponRangeMultMin = new Single();
			Unused = new byte[4];
			WeaponRestrictions = new WeaponRestrictions();
			RangedWeaponRangeMultMax = new Single();
			MaxTargetingFOV = new Single();
			CombatRadius = new Single();
			SemiAutoFiringDelayMultMin = new Single();
			SemiAutoFiringDelayMultMax = new Single();
		}

		public CombatStyleSimple(Single CoverSearchRadius, Single TakeCoverChance, Single WaitTimerMin, Single WaitTimerMax, Single WaitToFireTimerMin, Single WaitToFireTimerMax, Single FireTimerMin, Single FireTimerMax, Single RangedWeaponRangeMultMin, Byte[] Unused, WeaponRestrictions WeaponRestrictions, Single RangedWeaponRangeMultMax, Single MaxTargetingFOV, Single CombatRadius, Single SemiAutoFiringDelayMultMin, Single SemiAutoFiringDelayMultMax)
		{
			this.CoverSearchRadius = CoverSearchRadius;
			this.TakeCoverChance = TakeCoverChance;
			this.WaitTimerMin = WaitTimerMin;
			this.WaitTimerMax = WaitTimerMax;
			this.WaitToFireTimerMin = WaitToFireTimerMin;
			this.WaitToFireTimerMax = WaitToFireTimerMax;
			this.FireTimerMin = FireTimerMin;
			this.FireTimerMax = FireTimerMax;
			this.RangedWeaponRangeMultMin = RangedWeaponRangeMultMin;
			this.Unused = Unused;
			this.WeaponRestrictions = WeaponRestrictions;
			this.RangedWeaponRangeMultMax = RangedWeaponRangeMultMax;
			this.MaxTargetingFOV = MaxTargetingFOV;
			this.CombatRadius = CombatRadius;
			this.SemiAutoFiringDelayMultMin = SemiAutoFiringDelayMultMin;
			this.SemiAutoFiringDelayMultMax = SemiAutoFiringDelayMultMax;
		}

		public CombatStyleSimple(CombatStyleSimple copyObject)
		{
			CoverSearchRadius = copyObject.CoverSearchRadius;
			TakeCoverChance = copyObject.TakeCoverChance;
			WaitTimerMin = copyObject.WaitTimerMin;
			WaitTimerMax = copyObject.WaitTimerMax;
			WaitToFireTimerMin = copyObject.WaitToFireTimerMin;
			WaitToFireTimerMax = copyObject.WaitToFireTimerMax;
			FireTimerMin = copyObject.FireTimerMin;
			FireTimerMax = copyObject.FireTimerMax;
			RangedWeaponRangeMultMin = copyObject.RangedWeaponRangeMultMin;
			Unused = (Byte[])copyObject.Unused.Clone();
			WeaponRestrictions = copyObject.WeaponRestrictions;
			RangedWeaponRangeMultMax = copyObject.RangedWeaponRangeMultMax;
			MaxTargetingFOV = copyObject.MaxTargetingFOV;
			CombatRadius = copyObject.CombatRadius;
			SemiAutoFiringDelayMultMin = copyObject.SemiAutoFiringDelayMultMin;
			SemiAutoFiringDelayMultMax = copyObject.SemiAutoFiringDelayMultMax;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					CoverSearchRadius = subReader.ReadSingle();
					TakeCoverChance = subReader.ReadSingle();
					WaitTimerMin = subReader.ReadSingle();
					WaitTimerMax = subReader.ReadSingle();
					WaitToFireTimerMin = subReader.ReadSingle();
					WaitToFireTimerMax = subReader.ReadSingle();
					FireTimerMin = subReader.ReadSingle();
					FireTimerMax = subReader.ReadSingle();
					RangedWeaponRangeMultMin = subReader.ReadSingle();
					Unused = subReader.ReadBytes(4);
					WeaponRestrictions = subReader.ReadEnum<WeaponRestrictions>();
					RangedWeaponRangeMultMax = subReader.ReadSingle();
					MaxTargetingFOV = subReader.ReadSingle();
					CombatRadius = subReader.ReadSingle();
					SemiAutoFiringDelayMultMin = subReader.ReadSingle();
					SemiAutoFiringDelayMultMax = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(CoverSearchRadius);
			writer.Write(TakeCoverChance);
			writer.Write(WaitTimerMin);
			writer.Write(WaitTimerMax);
			writer.Write(WaitToFireTimerMin);
			writer.Write(WaitToFireTimerMax);
			writer.Write(FireTimerMin);
			writer.Write(FireTimerMax);
			writer.Write(RangedWeaponRangeMultMin);
			if (Unused == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused);
			writer.Write((UInt32)WeaponRestrictions);
			writer.Write(RangedWeaponRangeMultMax);
			writer.Write(MaxTargetingFOV);
			writer.Write(CombatRadius);
			writer.Write(SemiAutoFiringDelayMultMin);
			writer.Write(SemiAutoFiringDelayMultMax);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("CoverSearchRadius", true, out subEle);
			subEle.Value = CoverSearchRadius.ToString("G15");

			ele.TryPathTo("TakeCoverChance", true, out subEle);
			subEle.Value = TakeCoverChance.ToString("G15");

			ele.TryPathTo("WaitTimer/Min", true, out subEle);
			subEle.Value = WaitTimerMin.ToString("G15");

			ele.TryPathTo("WaitTimer/Max", true, out subEle);
			subEle.Value = WaitTimerMax.ToString("G15");

			ele.TryPathTo("WaitToFireTimer/Min", true, out subEle);
			subEle.Value = WaitToFireTimerMin.ToString("G15");

			ele.TryPathTo("WaitToFireTimer/Max", true, out subEle);
			subEle.Value = WaitToFireTimerMax.ToString("G15");

			ele.TryPathTo("FireTimer/Min", true, out subEle);
			subEle.Value = FireTimerMin.ToString("G15");

			ele.TryPathTo("FireTimer/Max", true, out subEle);
			subEle.Value = FireTimerMax.ToString("G15");

			ele.TryPathTo("RangedWeaponRangeMult/Min", true, out subEle);
			subEle.Value = RangedWeaponRangeMultMin.ToString("G15");

			WriteUnusedXML(ele, master);

			ele.TryPathTo("WeaponRestrictions", true, out subEle);
			subEle.Value = WeaponRestrictions.ToString();

			ele.TryPathTo("RangedWeaponRangeMult/Max", true, out subEle);
			subEle.Value = RangedWeaponRangeMultMax.ToString("G15");

			ele.TryPathTo("MaxTargetingFOV", true, out subEle);
			subEle.Value = MaxTargetingFOV.ToString("G15");

			ele.TryPathTo("CombatRadius", true, out subEle);
			subEle.Value = CombatRadius.ToString("G15");

			ele.TryPathTo("SemiAutoFiringDelayMult/Min", true, out subEle);
			subEle.Value = SemiAutoFiringDelayMultMin.ToString("G15");

			ele.TryPathTo("SemiAutoFiringDelayMult/Max", true, out subEle);
			subEle.Value = SemiAutoFiringDelayMultMax.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("CoverSearchRadius", false, out subEle))
				CoverSearchRadius = subEle.ToSingle();

			if (ele.TryPathTo("TakeCoverChance", false, out subEle))
				TakeCoverChance = subEle.ToSingle();

			if (ele.TryPathTo("WaitTimer/Min", false, out subEle))
				WaitTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("WaitTimer/Max", false, out subEle))
				WaitTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("WaitToFireTimer/Min", false, out subEle))
				WaitToFireTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("WaitToFireTimer/Max", false, out subEle))
				WaitToFireTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("FireTimer/Min", false, out subEle))
				FireTimerMin = subEle.ToSingle();

			if (ele.TryPathTo("FireTimer/Max", false, out subEle))
				FireTimerMax = subEle.ToSingle();

			if (ele.TryPathTo("RangedWeaponRangeMult/Min", false, out subEle))
				RangedWeaponRangeMultMin = subEle.ToSingle();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("WeaponRestrictions", false, out subEle))
				WeaponRestrictions = subEle.ToEnum<WeaponRestrictions>();

			if (ele.TryPathTo("RangedWeaponRangeMult/Max", false, out subEle))
				RangedWeaponRangeMultMax = subEle.ToSingle();

			if (ele.TryPathTo("MaxTargetingFOV", false, out subEle))
				MaxTargetingFOV = subEle.ToSingle();

			if (ele.TryPathTo("CombatRadius", false, out subEle))
				CombatRadius = subEle.ToSingle();

			if (ele.TryPathTo("SemiAutoFiringDelayMult/Min", false, out subEle))
				SemiAutoFiringDelayMultMin = subEle.ToSingle();

			if (ele.TryPathTo("SemiAutoFiringDelayMult/Max", false, out subEle))
				SemiAutoFiringDelayMultMax = subEle.ToSingle();
		}

		public CombatStyleSimple Clone()
		{
			return new CombatStyleSimple(this);
		}

        public int CompareTo(CombatStyleSimple other)
        {
			return CoverSearchRadius.CompareTo(other.CoverSearchRadius);
        }

        public static bool operator >(CombatStyleSimple objA, CombatStyleSimple objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CombatStyleSimple objA, CombatStyleSimple objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CombatStyleSimple objA, CombatStyleSimple objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CombatStyleSimple objA, CombatStyleSimple objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CombatStyleSimple other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return CoverSearchRadius == other.CoverSearchRadius &&
				TakeCoverChance == other.TakeCoverChance &&
				WaitTimerMin == other.WaitTimerMin &&
				WaitTimerMax == other.WaitTimerMax &&
				WaitToFireTimerMin == other.WaitToFireTimerMin &&
				WaitToFireTimerMax == other.WaitToFireTimerMax &&
				FireTimerMin == other.FireTimerMin &&
				FireTimerMax == other.FireTimerMax &&
				RangedWeaponRangeMultMin == other.RangedWeaponRangeMultMin &&
				Unused.SequenceEqual(other.Unused) &&
				WeaponRestrictions == other.WeaponRestrictions &&
				RangedWeaponRangeMultMax == other.RangedWeaponRangeMultMax &&
				MaxTargetingFOV == other.MaxTargetingFOV &&
				CombatRadius == other.CombatRadius &&
				SemiAutoFiringDelayMultMin == other.SemiAutoFiringDelayMultMin &&
				SemiAutoFiringDelayMultMax == other.SemiAutoFiringDelayMultMax;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CombatStyleSimple other = obj as CombatStyleSimple;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return CoverSearchRadius.GetHashCode();
        }

        public static bool operator ==(CombatStyleSimple objA, CombatStyleSimple objB)
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

        public static bool operator !=(CombatStyleSimple objA, CombatStyleSimple objB)
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

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}