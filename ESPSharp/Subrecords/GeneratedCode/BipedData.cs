
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
	public partial class BipedData : Subrecord, ICloneable<BipedData>, IComparable<BipedData>, IEquatable<BipedData>  
	{
		public BodySlotFlags Slots { get; set; }
		public BipedDataFlags Flags { get; set; }
		public Byte[] Unused { get; set; }

		public BipedData()
		{
			Slots = new BodySlotFlags();
			Flags = new BipedDataFlags();
			Unused = new byte[3];
		}

		public BipedData(BodySlotFlags Slots, BipedDataFlags Flags, Byte[] Unused)
		{
			this.Slots = Slots;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public BipedData(BipedData copyObject)
		{
			Slots = copyObject.Slots;
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Slots = subReader.ReadEnum<BodySlotFlags>();
					Flags = subReader.ReadEnum<BipedDataFlags>();
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
			writer.Write((UInt32)Slots);
			writer.Write((Int32)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Slots", true, out subEle);
			subEle.Value = Slots.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Slots", false, out subEle))
				Slots = subEle.ToEnum<BodySlotFlags>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<BipedDataFlags>();

			ReadUnusedXML(ele, master);
		}

		public BipedData Clone()
		{
			return new BipedData(this);
		}

        public int CompareTo(BipedData other)
        {
			return Slots.CompareTo(other.Slots);
        }

        public static bool operator >(BipedData objA, BipedData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(BipedData objA, BipedData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(BipedData objA, BipedData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(BipedData objA, BipedData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(BipedData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Slots == other.Slots &&
				Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            BipedData other = obj as BipedData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Slots.GetHashCode();
        }

        public static bool operator ==(BipedData objA, BipedData objB)
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

        public static bool operator !=(BipedData objA, BipedData objB)
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