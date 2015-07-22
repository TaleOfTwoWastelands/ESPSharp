
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
	public partial class RoomDataHeader : Subrecord, ICloneable, IComparable<RoomDataHeader>, IEquatable<RoomDataHeader>  
	{
		public UInt16 LinkedRoomsCount { get; set; }
		public Byte[] Unknown { get; set; }

		public RoomDataHeader(string Tag = null)
			:base(Tag)
		{
			LinkedRoomsCount = new UInt16();
			Unknown = new byte[2];
		}

		public RoomDataHeader(UInt16 LinkedRoomsCount, Byte[] Unknown)
		{
			this.LinkedRoomsCount = LinkedRoomsCount;
			this.Unknown = Unknown;
		}

		public RoomDataHeader(RoomDataHeader copyObject)
		{
			LinkedRoomsCount = copyObject.LinkedRoomsCount;
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
					LinkedRoomsCount = subReader.ReadUInt16();
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
			writer.Write(LinkedRoomsCount);
			if (Unknown == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("LinkedRoomsCount", true, out subEle);
			subEle.Value = LinkedRoomsCount.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("LinkedRoomsCount", false, out subEle))
				LinkedRoomsCount = subEle.ToUInt16();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();
		}

		public override object Clone()
		{
			return new RoomDataHeader(this);
		}

        public int CompareTo(RoomDataHeader other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(RoomDataHeader objA, RoomDataHeader objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RoomDataHeader objA, RoomDataHeader objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RoomDataHeader objA, RoomDataHeader objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RoomDataHeader objA, RoomDataHeader objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RoomDataHeader other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return LinkedRoomsCount == other.LinkedRoomsCount &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RoomDataHeader other = obj as RoomDataHeader;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return LinkedRoomsCount.GetHashCode();
        }

        public static bool operator ==(RoomDataHeader objA, RoomDataHeader objB)
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

        public static bool operator !=(RoomDataHeader objA, RoomDataHeader objB)
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