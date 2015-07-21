
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
	public partial class PerkData : Subrecord, ICloneable, IComparable<PerkData>, IEquatable<PerkData>  
	{
		public NoYesByte IsTrait { get; set; }
		public Byte MinLevel { get; set; }
		public Byte Ranks { get; set; }
		public NoYesByte IsPlayable { get; set; }
		public NoYesByte IsHidden { get; set; }

		public PerkData(string Tag = null)
			:base(Tag)
		{
			IsTrait = new NoYesByte();
			MinLevel = new Byte();
			Ranks = new Byte();
			IsPlayable = new NoYesByte();
			IsHidden = new NoYesByte();
		}

		public PerkData(NoYesByte IsTrait, Byte MinLevel, Byte Ranks, NoYesByte IsPlayable, NoYesByte IsHidden)
		{
			this.IsTrait = IsTrait;
			this.MinLevel = MinLevel;
			this.Ranks = Ranks;
			this.IsPlayable = IsPlayable;
			this.IsHidden = IsHidden;
		}

		public PerkData(PerkData copyObject)
		{
			IsTrait = copyObject.IsTrait;
			MinLevel = copyObject.MinLevel;
			Ranks = copyObject.Ranks;
			IsPlayable = copyObject.IsPlayable;
			IsHidden = copyObject.IsHidden;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					IsTrait = subReader.ReadEnum<NoYesByte>();
					MinLevel = subReader.ReadByte();
					Ranks = subReader.ReadByte();
					IsPlayable = subReader.ReadEnum<NoYesByte>();
					IsHidden = subReader.ReadEnum<NoYesByte>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)IsTrait);
			writer.Write(MinLevel);
			writer.Write(Ranks);
			writer.Write((Byte)IsPlayable);
			writer.Write((Byte)IsHidden);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("IsTrait", true, out subEle);
			subEle.Value = IsTrait.ToString();

			ele.TryPathTo("MinLevel", true, out subEle);
			subEle.Value = MinLevel.ToString();

			ele.TryPathTo("Ranks", true, out subEle);
			subEle.Value = Ranks.ToString();

			ele.TryPathTo("IsPlayable", true, out subEle);
			subEle.Value = IsPlayable.ToString();

			ele.TryPathTo("IsHidden", true, out subEle);
			subEle.Value = IsHidden.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("IsTrait", false, out subEle))
				IsTrait = subEle.ToEnum<NoYesByte>();

			if (ele.TryPathTo("MinLevel", false, out subEle))
				MinLevel = subEle.ToByte();

			if (ele.TryPathTo("Ranks", false, out subEle))
				Ranks = subEle.ToByte();

			if (ele.TryPathTo("IsPlayable", false, out subEle))
				IsPlayable = subEle.ToEnum<NoYesByte>();

			if (ele.TryPathTo("IsHidden", false, out subEle))
				IsHidden = subEle.ToEnum<NoYesByte>();
		}

		public override object Clone()
		{
			return new PerkData(this);
		}

        public int CompareTo(PerkData other)
        {
			return MinLevel.CompareTo(other.MinLevel);
        }

        public static bool operator >(PerkData objA, PerkData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PerkData objA, PerkData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PerkData objA, PerkData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PerkData objA, PerkData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PerkData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return IsTrait == other.IsTrait &&
				MinLevel == other.MinLevel &&
				Ranks == other.Ranks &&
				IsPlayable == other.IsPlayable &&
				IsHidden == other.IsHidden;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PerkData other = obj as PerkData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MinLevel.GetHashCode();
        }

        public static bool operator ==(PerkData objA, PerkData objB)
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

        public static bool operator !=(PerkData objA, PerkData objB)
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