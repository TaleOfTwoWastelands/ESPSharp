
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
	public partial class RelatedWaters : Subrecord, ICloneable<RelatedWaters>, IComparable<RelatedWaters>, IEquatable<RelatedWaters>  
	{
		public FormID Daytime { get; set; }
		public FormID Nighttime { get; set; }
		public FormID Underwater { get; set; }

		public RelatedWaters()
		{
			Daytime = new FormID();
			Nighttime = new FormID();
			Underwater = new FormID();
		}

		public RelatedWaters(FormID Daytime, FormID Nighttime, FormID Underwater)
		{
			this.Daytime = Daytime;
			this.Nighttime = Nighttime;
			this.Underwater = Underwater;
		}

		public RelatedWaters(RelatedWaters copyObject)
		{
			Daytime = copyObject.Daytime.Clone();
			Nighttime = copyObject.Nighttime.Clone();
			Underwater = copyObject.Underwater.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Daytime.ReadBinary(subReader);
					Nighttime.ReadBinary(subReader);
					Underwater.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Daytime.WriteBinary(writer);
			Nighttime.WriteBinary(writer);
			Underwater.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Daytime", true, out subEle);
			Daytime.WriteXML(subEle, master);

			ele.TryPathTo("Nighttime", true, out subEle);
			Nighttime.WriteXML(subEle, master);

			ele.TryPathTo("Underwater", true, out subEle);
			Underwater.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Daytime", false, out subEle))
				Daytime.ReadXML(subEle, master);

			if (ele.TryPathTo("Nighttime", false, out subEle))
				Nighttime.ReadXML(subEle, master);

			if (ele.TryPathTo("Underwater", false, out subEle))
				Underwater.ReadXML(subEle, master);
		}

		public RelatedWaters Clone()
		{
			return new RelatedWaters(this);
		}

        public int CompareTo(RelatedWaters other)
        {
			return Daytime.CompareTo(other.Daytime);
        }

        public static bool operator >(RelatedWaters objA, RelatedWaters objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RelatedWaters objA, RelatedWaters objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RelatedWaters objA, RelatedWaters objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RelatedWaters objA, RelatedWaters objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RelatedWaters other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Daytime == other.Daytime &&
				Nighttime == other.Nighttime &&
				Underwater == other.Underwater;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RelatedWaters other = obj as RelatedWaters;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Daytime.GetHashCode();
        }

        public static bool operator ==(RelatedWaters objA, RelatedWaters objB)
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

        public static bool operator !=(RelatedWaters objA, RelatedWaters objB)
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