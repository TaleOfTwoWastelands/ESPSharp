
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
	public partial class MapData : Subrecord, ICloneable, IComparable<MapData>, IEquatable<MapData>  
	{
		public Int32 UsableXSize { get; set; }
		public Int32 UsableYSize { get; set; }
		public Int16 MinX { get; set; }
		public Int16 MinY { get; set; }
		public Int16 MaxX { get; set; }
		public Int16 MaxY { get; set; }

		public MapData(string Tag = null)
			:base(Tag)
		{
			UsableXSize = new Int32();
			UsableYSize = new Int32();
			MinX = new Int16();
			MinY = new Int16();
			MaxX = new Int16();
			MaxY = new Int16();
		}

		public MapData(Int32 UsableXSize, Int32 UsableYSize, Int16 MinX, Int16 MinY, Int16 MaxX, Int16 MaxY)
		{
			this.UsableXSize = UsableXSize;
			this.UsableYSize = UsableYSize;
			this.MinX = MinX;
			this.MinY = MinY;
			this.MaxX = MaxX;
			this.MaxY = MaxY;
		}

		public MapData(MapData copyObject)
		{
			UsableXSize = copyObject.UsableXSize;
			UsableYSize = copyObject.UsableYSize;
			MinX = copyObject.MinX;
			MinY = copyObject.MinY;
			MaxX = copyObject.MaxX;
			MaxY = copyObject.MaxY;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					UsableXSize = subReader.ReadInt32();
					UsableYSize = subReader.ReadInt32();
					MinX = subReader.ReadInt16();
					MinY = subReader.ReadInt16();
					MaxX = subReader.ReadInt16();
					MaxY = subReader.ReadInt16();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(UsableXSize);
			writer.Write(UsableYSize);
			writer.Write(MinX);
			writer.Write(MinY);
			writer.Write(MaxX);
			writer.Write(MaxY);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("UsableSize/X", true, out subEle);
			subEle.Value = UsableXSize.ToString();

			ele.TryPathTo("UsableSize/Y", true, out subEle);
			subEle.Value = UsableYSize.ToString();

			ele.TryPathTo("MinX", true, out subEle);
			subEle.Value = MinX.ToString();

			ele.TryPathTo("MinY", true, out subEle);
			subEle.Value = MinY.ToString();

			ele.TryPathTo("MaxX", true, out subEle);
			subEle.Value = MaxX.ToString();

			ele.TryPathTo("MaxY", true, out subEle);
			subEle.Value = MaxY.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("UsableSize/X", false, out subEle))
				UsableXSize = subEle.ToInt32();

			if (ele.TryPathTo("UsableSize/Y", false, out subEle))
				UsableYSize = subEle.ToInt32();

			if (ele.TryPathTo("MinX", false, out subEle))
				MinX = subEle.ToInt16();

			if (ele.TryPathTo("MinY", false, out subEle))
				MinY = subEle.ToInt16();

			if (ele.TryPathTo("MaxX", false, out subEle))
				MaxX = subEle.ToInt16();

			if (ele.TryPathTo("MaxY", false, out subEle))
				MaxY = subEle.ToInt16();
		}

		public override object Clone()
		{
			return new MapData(this);
		}

        public int CompareTo(MapData other)
        {
			return UsableXSize.CompareTo(other.UsableXSize);
        }

        public static bool operator >(MapData objA, MapData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(MapData objA, MapData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(MapData objA, MapData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(MapData objA, MapData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(MapData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return UsableXSize == other.UsableXSize &&
				UsableYSize == other.UsableYSize &&
				MinX == other.MinX &&
				MinY == other.MinY &&
				MaxX == other.MaxX &&
				MaxY == other.MaxY;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            MapData other = obj as MapData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return UsableXSize.GetHashCode();
        }

        public static bool operator ==(MapData objA, MapData objB)
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

        public static bool operator !=(MapData objA, MapData objB)
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