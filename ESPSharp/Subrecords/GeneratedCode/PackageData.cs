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
	public partial class PackageData : Subrecord, ICloneable, IComparable<PackageData>, IEquatable<PackageData>  
	{
		public PackageFlags Flags { get; set; }
		public PackageType Type { get; set; }
		public Byte[] Unused1 { get; set; }
		public FalloutBehaviorFlags FalloutBehaviorFlags { get; set; }
		public dynamic TypeFlags { get; set; }
		public Byte[] Unused2 { get; set; }

		public PackageData(string Tag = null)
			:base(Tag)
		{
			Flags = new PackageFlags();
			Type = new PackageType();
			Unused1 = new byte[1];
			FalloutBehaviorFlags = new FalloutBehaviorFlags();
			TypeFlags = 0;
			Unused2 = new byte[2];
		}

		public PackageData(PackageFlags Flags, PackageType Type, Byte[] Unused1, FalloutBehaviorFlags FalloutBehaviorFlags, dynamic TypeFlags, Byte[] Unused2)
		{
			this.Flags = Flags;
			this.Type = Type;
			this.Unused1 = Unused1;
			this.FalloutBehaviorFlags = FalloutBehaviorFlags;
			this.TypeFlags = TypeFlags;
			this.Unused2 = Unused2;
		}

		public PackageData(PackageData copyObject)
		{
			Flags = copyObject.Flags;
			Type = copyObject.Type;
			if (copyObject.Unused1 != null)
				Unused1 = (Byte[])copyObject.Unused1.Clone();
			FalloutBehaviorFlags = copyObject.FalloutBehaviorFlags;
			TypeFlags = copyObject.TypeFlags;
			if (copyObject.Unused2 != null)
				Unused2 = (Byte[])copyObject.Unused2.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<PackageFlags>();
					Type = subReader.ReadEnum<PackageType>();
					Unused1 = subReader.ReadBytes(1);
					FalloutBehaviorFlags = subReader.ReadEnum<FalloutBehaviorFlags>();
					ReadTypeFlagsBinary(subReader);
					Unused2 = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Flags);
			writer.Write((Byte)Type);
			if (Unused1 == null)
				writer.Write(new byte[1]);
			else
			writer.Write(Unused1);
			writer.Write((UInt16)FalloutBehaviorFlags);
			WriteTypeFlagsBinary(writer);
			if (Unused2 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("FalloutBehaviorFlags", true, out subEle);
			subEle.Value = FalloutBehaviorFlags.ToString();

			WriteTypeFlagsXML(ele, master);

			WriteUnused2XML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<PackageFlags>();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<PackageType>();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("FalloutBehaviorFlags", false, out subEle))
				FalloutBehaviorFlags = subEle.ToEnum<FalloutBehaviorFlags>();

			ReadTypeFlagsXML(ele, master);

			ReadUnused2XML(ele, master);
		}

		public override object Clone()
		{
			return new PackageData(this);
		}

        public int CompareTo(PackageData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(PackageData objA, PackageData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PackageData objA, PackageData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PackageData objA, PackageData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PackageData objA, PackageData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PackageData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				Type == other.Type &&
				Unused1.SequenceEqual(other.Unused1) &&
				FalloutBehaviorFlags == other.FalloutBehaviorFlags &&
				TypeFlags == other.TypeFlags &&
				Unused2.SequenceEqual(other.Unused2);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PackageData other = obj as PackageData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(PackageData objA, PackageData objB)
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

        public static bool operator !=(PackageData objA, PackageData objB)
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

		partial void ReadTypeFlagsBinary(ESPReader reader);

		partial void WriteTypeFlagsBinary(ESPWriter writer);

		partial void ReadUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadTypeFlagsXML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteTypeFlagsXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);
	}
}