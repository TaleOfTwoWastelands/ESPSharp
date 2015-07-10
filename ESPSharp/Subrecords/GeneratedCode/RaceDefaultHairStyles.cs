
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
	public partial class RaceDefaultHairStyles : Subrecord, ICloneable<RaceDefaultHairStyles>, IComparable<RaceDefaultHairStyles>, IEquatable<RaceDefaultHairStyles>  
	{
		public FormID MaleStyle { get; set; }
		public FormID FemaleStyle { get; set; }

		public RaceDefaultHairStyles()
		{
			MaleStyle = new FormID();
			FemaleStyle = new FormID();
		}

		public RaceDefaultHairStyles(FormID MaleStyle, FormID FemaleStyle)
		{
			this.MaleStyle = MaleStyle;
			this.FemaleStyle = FemaleStyle;
		}

		public RaceDefaultHairStyles(RaceDefaultHairStyles copyObject)
		{
			MaleStyle = copyObject.MaleStyle.Clone();
			FemaleStyle = copyObject.FemaleStyle.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaleStyle.ReadBinary(subReader);
					FemaleStyle.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			MaleStyle.WriteBinary(writer);
			FemaleStyle.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Male", true, out subEle);
			MaleStyle.WriteXML(subEle, master);

			ele.TryPathTo("Female", true, out subEle);
			FemaleStyle.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Male", false, out subEle))
				MaleStyle.ReadXML(subEle, master);

			if (ele.TryPathTo("Female", false, out subEle))
				FemaleStyle.ReadXML(subEle, master);
		}

		public RaceDefaultHairStyles Clone()
		{
			return new RaceDefaultHairStyles(this);
		}

        public int CompareTo(RaceDefaultHairStyles other)
        {
			return MaleStyle.CompareTo(other.MaleStyle);
        }

        public static bool operator >(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RaceDefaultHairStyles other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MaleStyle == other.MaleStyle &&
				FemaleStyle == other.FemaleStyle;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RaceDefaultHairStyles other = obj as RaceDefaultHairStyles;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MaleStyle.GetHashCode();
        }

        public static bool operator ==(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
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

        public static bool operator !=(RaceDefaultHairStyles objA, RaceDefaultHairStyles objB)
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