
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
	public partial class RaceDefaultHairColors : Subrecord, ICloneable, IComparable<RaceDefaultHairColors>, IEquatable<RaceDefaultHairColors>  
	{
		public HairColor MaleColor { get; set; }
		public HairColor FemaleColor { get; set; }

		public RaceDefaultHairColors(string Tag = null)
			:base(Tag)
		{
			MaleColor = new HairColor();
			FemaleColor = new HairColor();
		}

		public RaceDefaultHairColors(HairColor MaleColor, HairColor FemaleColor)
		{
			this.MaleColor = MaleColor;
			this.FemaleColor = FemaleColor;
		}

		public RaceDefaultHairColors(RaceDefaultHairColors copyObject)
		{
			MaleColor = copyObject.MaleColor;
			FemaleColor = copyObject.FemaleColor;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaleColor = subReader.ReadEnum<HairColor>();
					FemaleColor = subReader.ReadEnum<HairColor>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)MaleColor);
			writer.Write((Byte)FemaleColor);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Male", true, out subEle);
			subEle.Value = MaleColor.ToString();

			ele.TryPathTo("Female", true, out subEle);
			subEle.Value = FemaleColor.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Male", false, out subEle))
				MaleColor = subEle.ToEnum<HairColor>();

			if (ele.TryPathTo("Female", false, out subEle))
				FemaleColor = subEle.ToEnum<HairColor>();
		}

		public override object Clone()
		{
			return new RaceDefaultHairColors(this);
		}

        public int CompareTo(RaceDefaultHairColors other)
        {
			return MaleColor.CompareTo(other.MaleColor);
        }

        public static bool operator >(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RaceDefaultHairColors other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MaleColor == other.MaleColor &&
				FemaleColor == other.FemaleColor;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RaceDefaultHairColors other = obj as RaceDefaultHairColors;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MaleColor.GetHashCode();
        }

        public static bool operator ==(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
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

        public static bool operator !=(RaceDefaultHairColors objA, RaceDefaultHairColors objB)
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