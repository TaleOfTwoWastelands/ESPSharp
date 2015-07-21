
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
	public partial class HavokData : Subrecord, ICloneable, IComparable<HavokData>, IEquatable<HavokData>  
	{
		public MaterialType MaterialType { get; set; }
		public Byte Friction { get; set; }
		public Byte Restitution { get; set; }

		public HavokData(string Tag = null)
			:base(Tag)
		{
			MaterialType = new MaterialType();
			Friction = new Byte();
			Restitution = new Byte();
		}

		public HavokData(MaterialType MaterialType, Byte Friction, Byte Restitution)
		{
			this.MaterialType = MaterialType;
			this.Friction = Friction;
			this.Restitution = Restitution;
		}

		public HavokData(HavokData copyObject)
		{
			MaterialType = copyObject.MaterialType;
			Friction = copyObject.Friction;
			Restitution = copyObject.Restitution;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaterialType = subReader.ReadEnum<MaterialType>();
					Friction = subReader.ReadByte();
					Restitution = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)MaterialType);
			writer.Write(Friction);
			writer.Write(Restitution);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("MaterialType", true, out subEle);
			subEle.Value = MaterialType.ToString();

			ele.TryPathTo("Friction", true, out subEle);
			subEle.Value = Friction.ToString();

			ele.TryPathTo("Restitution", true, out subEle);
			subEle.Value = Restitution.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("MaterialType", false, out subEle))
				MaterialType = subEle.ToEnum<MaterialType>();

			if (ele.TryPathTo("Friction", false, out subEle))
				Friction = subEle.ToByte();

			if (ele.TryPathTo("Restitution", false, out subEle))
				Restitution = subEle.ToByte();
		}

		public override object Clone()
		{
			return new HavokData(this);
		}

        public int CompareTo(HavokData other)
        {
			return MaterialType.CompareTo(other.MaterialType);
        }

        public static bool operator >(HavokData objA, HavokData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(HavokData objA, HavokData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(HavokData objA, HavokData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(HavokData objA, HavokData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(HavokData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MaterialType == other.MaterialType &&
				Friction == other.Friction &&
				Restitution == other.Restitution;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            HavokData other = obj as HavokData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MaterialType.GetHashCode();
        }

        public static bool operator ==(HavokData objA, HavokData objB)
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

        public static bool operator !=(HavokData objA, HavokData objB)
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