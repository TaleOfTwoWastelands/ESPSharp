
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
	public partial class PerkEffectHeader : Subrecord, ICloneable, IComparable<PerkEffectHeader>, IEquatable<PerkEffectHeader>  
	{
		public PerkType Type { get; set; }
		public Byte Rank { get; set; }
		public Byte Priority { get; set; }

		public PerkEffectHeader(string Tag = null)
			:base(Tag)
		{
			Type = new PerkType();
			Rank = new Byte();
			Priority = new Byte();
		}

		public PerkEffectHeader(PerkType Type, Byte Rank, Byte Priority)
		{
			this.Type = Type;
			this.Rank = Rank;
			this.Priority = Priority;
		}

		public PerkEffectHeader(PerkEffectHeader copyObject)
		{
			Type = copyObject.Type;
			Rank = copyObject.Rank;
			Priority = copyObject.Priority;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<PerkType>();
					Rank = subReader.ReadByte();
					Priority = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Type);
			writer.Write(Rank);
			writer.Write(Priority);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Rank", true, out subEle);
			subEle.Value = Rank.ToString();

			ele.TryPathTo("Priority", true, out subEle);
			subEle.Value = Priority.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<PerkType>();

			if (ele.TryPathTo("Rank", false, out subEle))
				Rank = subEle.ToByte();

			if (ele.TryPathTo("Priority", false, out subEle))
				Priority = subEle.ToByte();
		}

		public override object Clone()
		{
			return new PerkEffectHeader(this);
		}

        public int CompareTo(PerkEffectHeader other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(PerkEffectHeader objA, PerkEffectHeader objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PerkEffectHeader objA, PerkEffectHeader objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PerkEffectHeader objA, PerkEffectHeader objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PerkEffectHeader objA, PerkEffectHeader objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PerkEffectHeader other)
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
				Rank == other.Rank &&
				Priority == other.Priority;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PerkEffectHeader other = obj as PerkEffectHeader;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(PerkEffectHeader objA, PerkEffectHeader objB)
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

        public static bool operator !=(PerkEffectHeader objA, PerkEffectHeader objB)
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