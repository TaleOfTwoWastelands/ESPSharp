
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
	public partial class FactionData : Subrecord, ICloneable, IComparable<FactionData>, IEquatable<FactionData>  
	{
		public FactionFlags1 Flags1 { get; set; }
		public FactionFlags2 Flags2 { get; set; }
		public Byte[] Unused { get; set; }

		public FactionData(string Tag = null)
			:base(Tag)
		{
			Flags1 = new FactionFlags1();
			Flags2 = new FactionFlags2();
			Unused = new byte[2];
		}

		public FactionData(FactionFlags1 Flags1, FactionFlags2 Flags2, Byte[] Unused)
		{
			this.Flags1 = Flags1;
			this.Flags2 = Flags2;
			this.Unused = Unused;
		}

		public FactionData(FactionData copyObject)
		{
			Flags1 = copyObject.Flags1;
			Flags2 = copyObject.Flags2;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags1 = subReader.ReadEnum<FactionFlags1>();
					Flags2 = subReader.ReadEnum<FactionFlags2>();
					Unused = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Flags1);
			writer.Write((Byte)Flags2);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags1", true, out subEle);
			subEle.Value = Flags1.ToString();

			ele.TryPathTo("Flags2", true, out subEle);
			subEle.Value = Flags2.ToString();

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags1", false, out subEle))
				Flags1 = subEle.ToEnum<FactionFlags1>();

			if (ele.TryPathTo("Flags2", false, out subEle))
				Flags2 = subEle.ToEnum<FactionFlags2>();

			ReadUnusedXML(ele, master);
		}

		public override object Clone()
		{
			return new FactionData(this);
		}

        public int CompareTo(FactionData other)
        {
			return Flags1.CompareTo(other.Flags1);
        }

        public static bool operator >(FactionData objA, FactionData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(FactionData objA, FactionData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(FactionData objA, FactionData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(FactionData objA, FactionData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(FactionData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags1 == other.Flags1 &&
				Flags2 == other.Flags2 &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            FactionData other = obj as FactionData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Flags1.GetHashCode();
        }

        public static bool operator ==(FactionData objA, FactionData objB)
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

        public static bool operator !=(FactionData objA, FactionData objB)
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