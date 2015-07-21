
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
	public partial class LeveledObjectData : Subrecord, ICloneable, IComparable<LeveledObjectData>, IEquatable<LeveledObjectData>  
	{
		public Int16 Level { get; set; }
		public Byte[] Unused1 { get; set; }
		public FormID Reference { get; set; }
		public Int16 Count { get; set; }
		public Byte[] Unused2 { get; set; }

		public LeveledObjectData(string Tag = null)
			:base(Tag)
		{
			Level = new Int16();
			Unused1 = new byte[2];
			Reference = new FormID();
			Count = new Int16();
			Unused2 = new byte[2];
		}

		public LeveledObjectData(Int16 Level, Byte[] Unused1, FormID Reference, Int16 Count, Byte[] Unused2)
		{
			this.Level = Level;
			this.Unused1 = Unused1;
			this.Reference = Reference;
			this.Count = Count;
			this.Unused2 = Unused2;
		}

		public LeveledObjectData(LeveledObjectData copyObject)
		{
			Level = copyObject.Level;
			if (copyObject.Unused1 != null)
				Unused1 = (Byte[])copyObject.Unused1.Clone();
			if (copyObject.Reference != null)
				Reference = (FormID)copyObject.Reference.Clone();
			Count = copyObject.Count;
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
					Level = subReader.ReadInt16();
					Unused1 = subReader.ReadBytes(2);
					Reference.ReadBinary(subReader);
					Count = subReader.ReadInt16();
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
			writer.Write(Level);
			if (Unused1 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused1);
			Reference.WriteBinary(writer);
			writer.Write(Count);
			if (Unused2 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("Reference", true, out subEle);
			Reference.WriteXML(subEle, master);

			ele.TryPathTo("Count", true, out subEle);
			subEle.Value = Count.ToString();

			WriteUnused2XML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Level", false, out subEle))
				Level = subEle.ToInt16();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("Reference", false, out subEle))
				Reference.ReadXML(subEle, master);

			if (ele.TryPathTo("Count", false, out subEle))
				Count = subEle.ToInt16();

			ReadUnused2XML(ele, master);
		}

		public override object Clone()
		{
			return new LeveledObjectData(this);
		}

        public int CompareTo(LeveledObjectData other)
        {
			return Level.CompareTo(other.Level);
        }

        public static bool operator >(LeveledObjectData objA, LeveledObjectData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LeveledObjectData objA, LeveledObjectData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LeveledObjectData objA, LeveledObjectData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LeveledObjectData objA, LeveledObjectData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LeveledObjectData other)
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
				Unused1.SequenceEqual(other.Unused1) &&
				Reference == other.Reference &&
				Count == other.Count &&
				Unused2.SequenceEqual(other.Unused2);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LeveledObjectData other = obj as LeveledObjectData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Level.GetHashCode();
        }

        public static bool operator ==(LeveledObjectData objA, LeveledObjectData objB)
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

        public static bool operator !=(LeveledObjectData objA, LeveledObjectData objB)
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

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);
	}
}