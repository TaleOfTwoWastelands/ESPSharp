
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
	public partial class LockData : Subrecord, ICloneable, IComparable<LockData>, IEquatable<LockData>  
	{
		public Byte Level { get; set; }
		public Byte[] Unused { get; set; }
		public FormID Key { get; set; }
		public LockFlags Flags { get; set; }
		public Byte[] Unknown { get; set; }

		public LockData(string Tag = null)
			:base(Tag)
		{
			Level = new Byte();
			Unused = new byte[3];
			Key = new FormID();
			Flags = new LockFlags();
			Unknown = new byte[11];
		}

		public LockData(Byte Level, Byte[] Unused, FormID Key, LockFlags Flags, Byte[] Unknown)
		{
			this.Level = Level;
			this.Unused = Unused;
			this.Key = Key;
			this.Flags = Flags;
			this.Unknown = Unknown;
		}

		public LockData(LockData copyObject)
		{
			Level = copyObject.Level;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			if (copyObject.Key != null)
				Key = (FormID)copyObject.Key.Clone();
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
					Level = subReader.ReadByte();
					Unused = subReader.ReadBytes(3);
					Key.ReadBinary(subReader);
					Flags = subReader.ReadEnum<LockFlags>();
					Unknown = subReader.ReadBytes(11);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Level);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
			Key.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unknown == null)
				writer.Write(new byte[11]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Key", true, out subEle);
			Key.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnknownXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Level", false, out subEle))
				Level = subEle.ToByte();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Key", false, out subEle))
				Key.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<LockFlags>();

			ReadUnknownXML(ele, master);
		}

		public override object Clone()
		{
			return new LockData(this);
		}

        public int CompareTo(LockData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(LockData objA, LockData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LockData objA, LockData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LockData objA, LockData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LockData objA, LockData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LockData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Level == other.Level &&
				Unused.SequenceEqual(other.Unused) &&
				Key == other.Key &&
				Flags == other.Flags &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LockData other = obj as LockData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Level.GetHashCode();
        }

        public static bool operator ==(LockData objA, LockData objB)
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

        public static bool operator !=(LockData objA, LockData objB)
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

		partial void ReadUnknownXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnknownXML(XElement ele, ElderScrollsPlugin master);
	}
}