
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
	public partial class BillboardDimensions : Subrecord, ICloneable, IComparable<BillboardDimensions>, IEquatable<BillboardDimensions>  
	{
		public Single Width { get; set; }
		public Single Height { get; set; }

		public BillboardDimensions(string Tag = null)
			:base(Tag)
		{
			Width = new Single();
			Height = new Single();
		}

		public BillboardDimensions(Single Width, Single Height)
		{
			this.Width = Width;
			this.Height = Height;
		}

		public BillboardDimensions(BillboardDimensions copyObject)
		{
			Width = copyObject.Width;
			Height = copyObject.Height;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Width = subReader.ReadSingle();
					Height = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Width);
			writer.Write(Height);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Width", true, out subEle);
			subEle.Value = Width.ToString("G15");

			ele.TryPathTo("Height", true, out subEle);
			subEle.Value = Height.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Width", false, out subEle))
				Width = subEle.ToSingle();

			if (ele.TryPathTo("Height", false, out subEle))
				Height = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new BillboardDimensions(this);
		}

        public int CompareTo(BillboardDimensions other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(BillboardDimensions objA, BillboardDimensions objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(BillboardDimensions objA, BillboardDimensions objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(BillboardDimensions objA, BillboardDimensions objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(BillboardDimensions objA, BillboardDimensions objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(BillboardDimensions other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Width == other.Width &&
				Height == other.Height;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            BillboardDimensions other = obj as BillboardDimensions;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode();
        }

        public static bool operator ==(BillboardDimensions objA, BillboardDimensions objB)
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

        public static bool operator !=(BillboardDimensions objA, BillboardDimensions objB)
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