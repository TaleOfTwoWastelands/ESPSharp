
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
	public partial class DestructableHeader : Subrecord, ICloneable, IComparable<DestructableHeader>, IEquatable<DestructableHeader>  
	{
		public Int32 Health { get; set; }
		public Byte Count { get; set; }
		public DestructableFlags Flags { get; set; }
		public Byte[] Unknown { get; set; }

		public DestructableHeader(string Tag = null)
			:base(Tag)
		{
			Health = new Int32();
			Count = new Byte();
			Flags = new DestructableFlags();
			Unknown = new byte[2];
		}

		public DestructableHeader(Int32 Health, Byte Count, DestructableFlags Flags, Byte[] Unknown)
		{
			this.Health = Health;
			this.Count = Count;
			this.Flags = Flags;
			this.Unknown = Unknown;
		}

		public DestructableHeader(DestructableHeader copyObject)
		{
			Health = copyObject.Health;
			Count = copyObject.Count;
			Flags = copyObject.Flags;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Health = subReader.ReadInt32();
					Count = subReader.ReadByte();
					Flags = subReader.ReadEnum<DestructableFlags>();
					Unknown = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Health);
			writer.Write(Count);
			writer.Write((Byte)Flags);
			if (Unknown == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Health", true, out subEle);
			subEle.Value = Health.ToString();

			ele.TryPathTo("Count", true, out subEle);
			subEle.Value = Count.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Health", false, out subEle))
				Health = subEle.ToInt32();

			if (ele.TryPathTo("Count", false, out subEle))
				Count = subEle.ToByte();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<DestructableFlags>();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();
		}

		public override object Clone()
		{
			return new DestructableHeader(this);
		}

        public int CompareTo(DestructableHeader other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(DestructableHeader objA, DestructableHeader objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DestructableHeader objA, DestructableHeader objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DestructableHeader objA, DestructableHeader objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DestructableHeader objA, DestructableHeader objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DestructableHeader other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Health == other.Health &&
				Count == other.Count &&
				Flags == other.Flags &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DestructableHeader other = obj as DestructableHeader;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Health.GetHashCode();
        }

        public static bool operator ==(DestructableHeader objA, DestructableHeader objB)
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

        public static bool operator !=(DestructableHeader objA, DestructableHeader objB)
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