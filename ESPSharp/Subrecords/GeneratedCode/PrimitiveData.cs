
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
	public partial class PrimitiveData : Subrecord, ICloneable, IComparable<PrimitiveData>, IEquatable<PrimitiveData>  
	{
		public Single XBound { get; set; }
		public Single YBound { get; set; }
		public Single ZBound { get; set; }
		public Single Red { get; set; }
		public Single Green { get; set; }
		public Single Blue { get; set; }
		public Byte[] Unknown { get; set; }
		public PrimitiveType Type { get; set; }

		public PrimitiveData(string Tag = null)
			:base(Tag)
		{
			XBound = new Single();
			YBound = new Single();
			ZBound = new Single();
			Red = new Single();
			Green = new Single();
			Blue = new Single();
			Unknown = new byte[4];
			Type = new PrimitiveType();
		}

		public PrimitiveData(Single XBound, Single YBound, Single ZBound, Single Red, Single Green, Single Blue, Byte[] Unknown, PrimitiveType Type)
		{
			this.XBound = XBound;
			this.YBound = YBound;
			this.ZBound = ZBound;
			this.Red = Red;
			this.Green = Green;
			this.Blue = Blue;
			this.Unknown = Unknown;
			this.Type = Type;
		}

		public PrimitiveData(PrimitiveData copyObject)
		{
			XBound = copyObject.XBound;
			YBound = copyObject.YBound;
			ZBound = copyObject.ZBound;
			Red = copyObject.Red;
			Green = copyObject.Green;
			Blue = copyObject.Blue;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
			Type = copyObject.Type;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					XBound = subReader.ReadSingle();
					YBound = subReader.ReadSingle();
					ZBound = subReader.ReadSingle();
					Red = subReader.ReadSingle();
					Green = subReader.ReadSingle();
					Blue = subReader.ReadSingle();
					Unknown = subReader.ReadBytes(4);
					Type = subReader.ReadEnum<PrimitiveType>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(XBound);
			writer.Write(YBound);
			writer.Write(ZBound);
			writer.Write(Red);
			writer.Write(Green);
			writer.Write(Blue);
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown);
			writer.Write((UInt32)Type);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Bounds/X", true, out subEle);
			subEle.Value = XBound.ToString("G15");

			ele.TryPathTo("Bounds/Y", true, out subEle);
			subEle.Value = YBound.ToString("G15");

			ele.TryPathTo("Bounds/Z", true, out subEle);
			subEle.Value = ZBound.ToString("G15");

			ele.TryPathTo("Color/Red", true, out subEle);
			subEle.Value = Red.ToString("G15");

			ele.TryPathTo("Color/Green", true, out subEle);
			subEle.Value = Green.ToString("G15");

			ele.TryPathTo("Color/Blue", true, out subEle);
			subEle.Value = Blue.ToString("G15");

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Bounds/X", false, out subEle))
				XBound = subEle.ToSingle();

			if (ele.TryPathTo("Bounds/Y", false, out subEle))
				YBound = subEle.ToSingle();

			if (ele.TryPathTo("Bounds/Z", false, out subEle))
				ZBound = subEle.ToSingle();

			if (ele.TryPathTo("Color/Red", false, out subEle))
				Red = subEle.ToSingle();

			if (ele.TryPathTo("Color/Green", false, out subEle))
				Green = subEle.ToSingle();

			if (ele.TryPathTo("Color/Blue", false, out subEle))
				Blue = subEle.ToSingle();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<PrimitiveType>();
		}

		public override object Clone()
		{
			return new PrimitiveData(this);
		}

        public int CompareTo(PrimitiveData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(PrimitiveData objA, PrimitiveData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PrimitiveData objA, PrimitiveData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PrimitiveData objA, PrimitiveData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PrimitiveData objA, PrimitiveData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PrimitiveData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return XBound == other.XBound &&
				YBound == other.YBound &&
				ZBound == other.ZBound &&
				Red == other.Red &&
				Green == other.Green &&
				Blue == other.Blue &&
				Unknown.SequenceEqual(other.Unknown) &&
				Type == other.Type;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PrimitiveData other = obj as PrimitiveData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return XBound.GetHashCode();
        }

        public static bool operator ==(PrimitiveData objA, PrimitiveData objB)
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

        public static bool operator !=(PrimitiveData objA, PrimitiveData objB)
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