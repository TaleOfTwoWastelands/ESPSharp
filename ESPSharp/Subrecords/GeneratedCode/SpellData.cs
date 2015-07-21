
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
	public partial class SpellData : Subrecord, ICloneable, IComparable<SpellData>, IEquatable<SpellData>  
	{
		public SpellType Type { get; set; }
		public UInt32 Cost { get; set; }
		public UInt32 Level { get; set; }
		public SpellFlags Flags { get; set; }
		public Byte[] Unused { get; set; }

		public SpellData(string Tag = null)
			:base(Tag)
		{
			Type = new SpellType();
			Cost = new UInt32();
			Level = new UInt32();
			Flags = new SpellFlags();
			Unused = new byte[3];
		}

		public SpellData(SpellType Type, UInt32 Cost, UInt32 Level, SpellFlags Flags, Byte[] Unused)
		{
			this.Type = Type;
			this.Cost = Cost;
			this.Level = Level;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public SpellData(SpellData copyObject)
		{
			Type = copyObject.Type;
			Cost = copyObject.Cost;
			Level = copyObject.Level;
			Flags = copyObject.Flags;
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
					Type = subReader.ReadEnum<SpellType>();
					Cost = subReader.ReadUInt32();
					Level = subReader.ReadUInt32();
					Flags = subReader.ReadEnum<SpellFlags>();
					Unused = subReader.ReadBytes(3);
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
			writer.Write(Cost);
			writer.Write(Level);
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Cost", true, out subEle);
			subEle.Value = Cost.ToString();

			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<SpellType>();

			if (ele.TryPathTo("Cost", false, out subEle))
				Cost = subEle.ToUInt32();

			if (ele.TryPathTo("Level", false, out subEle))
				Level = subEle.ToUInt32();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<SpellFlags>();

			ReadUnusedXML(ele, master);
		}

		public override object Clone()
		{
			return new SpellData(this);
		}

        public int CompareTo(SpellData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(SpellData objA, SpellData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(SpellData objA, SpellData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(SpellData objA, SpellData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(SpellData objA, SpellData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(SpellData other)
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
				Cost == other.Cost &&
				Level == other.Level &&
				Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            SpellData other = obj as SpellData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(SpellData objA, SpellData objB)
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

        public static bool operator !=(SpellData objA, SpellData objB)
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