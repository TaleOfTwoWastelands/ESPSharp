
















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
	public partial class MapMarkerData : Subrecord, ICloneable, IComparable<MapMarkerData>, IEquatable<MapMarkerData>  
	{
		public MapMarkerType Type { get; set; }
		public Byte[] Unused { get; set; }


		public MapMarkerData(string Tag = null)
			:base(Tag)
		{
			Type = new MapMarkerType();
			Unused = new byte[1];

		}

		public MapMarkerData(MapMarkerType Type, Byte[] Unused)
		{
			this.Type = Type;
			this.Unused = Unused;

		}

		public MapMarkerData(MapMarkerData copyObject)
		{
			Type = copyObject.Type;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Type = subReader.ReadEnum<MapMarkerType>();
					Unused = subReader.ReadBytes(1);

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
			if (Unused == null)
				writer.Write(new byte[1]);
			else
			writer.Write(Unused);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			WriteUnusedXML(ele, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<MapMarkerType>();

			ReadUnusedXML(ele, master);

		}

		public override object Clone()
		{
			return new MapMarkerData(this);
		}


        public int CompareTo(MapMarkerData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(MapMarkerData objA, MapMarkerData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(MapMarkerData objA, MapMarkerData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(MapMarkerData objA, MapMarkerData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(MapMarkerData objA, MapMarkerData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(MapMarkerData other)
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
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            MapMarkerData other = obj as MapMarkerData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(MapMarkerData objA, MapMarkerData objB)
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

        public static bool operator !=(MapMarkerData objA, MapMarkerData objB)
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