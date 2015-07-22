
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
	public partial class EnchantData : Subrecord, ICloneable, IComparable<EnchantData>, IEquatable<EnchantData>  
	{
		public EnchantType Type { get; set; }
		public Byte[] Unused1 { get; set; }
		public Byte[] Unused2 { get; set; }
		public EnchantFlags Flags { get; set; }
		public Byte[] Unused3 { get; set; }

		public EnchantData(string Tag = null)
			:base(Tag)
		{
			Type = new EnchantType();
			Unused1 = new byte[4];
			Unused2 = new byte[4];
			Flags = new EnchantFlags();
			Unused3 = new byte[3];
		}

		public EnchantData(EnchantType Type, Byte[] Unused1, Byte[] Unused2, EnchantFlags Flags, Byte[] Unused3)
		{
			this.Type = Type;
			this.Unused1 = Unused1;
			this.Unused2 = Unused2;
			this.Flags = Flags;
			this.Unused3 = Unused3;
		}

		public EnchantData(EnchantData copyObject)
		{
			Type = copyObject.Type;
			if (copyObject.Unused1 != null)
				Unused1 = (Byte[])copyObject.Unused1.Clone();
			if (copyObject.Unused2 != null)
				Unused2 = (Byte[])copyObject.Unused2.Clone();
			Flags = copyObject.Flags;
			if (copyObject.Unused3 != null)
				Unused3 = (Byte[])copyObject.Unused3.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<EnchantType>();
					Unused1 = subReader.ReadBytes(4);
					Unused2 = subReader.ReadBytes(4);
					Flags = subReader.ReadEnum<EnchantFlags>();
					Unused3 = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Type);
			if (Unused1 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused1);
			if (Unused2 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused2);
			writer.Write((Byte)Flags);
			if (Unused3 == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused3);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			WriteUnused1XML(ele, master);

			WriteUnused2XML(ele, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnused3XML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<EnchantType>();

			ReadUnused1XML(ele, master);

			ReadUnused2XML(ele, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<EnchantFlags>();

			ReadUnused3XML(ele, master);
		}

		public override object Clone()
		{
			return new EnchantData(this);
		}

        public int CompareTo(EnchantData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(EnchantData objA, EnchantData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EnchantData objA, EnchantData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EnchantData objA, EnchantData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EnchantData objA, EnchantData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(EnchantData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Type == other.Type &&
				Unused1.SequenceEqual(other.Unused1) &&
				Unused2.SequenceEqual(other.Unused2) &&
				Flags == other.Flags &&
				Unused3.SequenceEqual(other.Unused3);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EnchantData other = obj as EnchantData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(EnchantData objA, EnchantData objB)
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

        public static bool operator !=(EnchantData objA, EnchantData objB)
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

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused3XML(XElement ele, ElderScrollsPlugin master);
	}
}