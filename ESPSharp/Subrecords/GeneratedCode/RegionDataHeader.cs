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
	public partial class RegionDataHeader : Subrecord, ICloneable<RegionDataHeader>, IComparable<RegionDataHeader>, IEquatable<RegionDataHeader>  
	{
		public RegionDataType Type { get; set; }
		public RegionDataFlags Flags { get; set; }
		public Byte Unused { get; set; }

		public RegionDataHeader()
		{
			Type = new RegionDataType();
			Flags = new RegionDataFlags();
			Unused = new Byte();
		}

		public RegionDataHeader(RegionDataType Type, RegionDataFlags Flags, Byte Unused)
		{
			this.Type = Type;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public RegionDataHeader(RegionDataHeader copyObject)
		{
			Type = copyObject.Type;
			Flags = copyObject.Flags;
			Unused = copyObject.Unused;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<RegionDataType>();
					Flags = subReader.ReadEnum<RegionDataFlags>();
					Unused = subReader.ReadByte();
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
			writer.Write((Byte)Flags);
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<RegionDataType>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<RegionDataFlags>();

			ReadUnusedXML(ele, master);
		}

		public RegionDataHeader Clone()
		{
			return new RegionDataHeader(this);
		}

        public int CompareTo(RegionDataHeader other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(RegionDataHeader objA, RegionDataHeader objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RegionDataHeader objA, RegionDataHeader objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RegionDataHeader objA, RegionDataHeader objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RegionDataHeader objA, RegionDataHeader objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RegionDataHeader other)
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
				Flags == other.Flags &&
				Unused == other.Unused;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionDataHeader other = obj as RegionDataHeader;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(RegionDataHeader objA, RegionDataHeader objB)
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

        public static bool operator !=(RegionDataHeader objA, RegionDataHeader objB)
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