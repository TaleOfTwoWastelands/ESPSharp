
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
	public partial class PlaceableWaterData : Subrecord, ICloneable<PlaceableWaterData>, IComparable<PlaceableWaterData>, IEquatable<PlaceableWaterData>  
	{
		public PlaceableWaterFlags Flags { get; set; }
		public FormID WaterType { get; set; }

		public PlaceableWaterData()
		{
			Flags = new PlaceableWaterFlags();
			WaterType = new FormID();
		}

		public PlaceableWaterData(PlaceableWaterFlags Flags, FormID WaterType)
		{
			this.Flags = Flags;
			this.WaterType = WaterType;
		}

		public PlaceableWaterData(PlaceableWaterData copyObject)
		{
			Flags = copyObject.Flags;
			WaterType = copyObject.WaterType.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<PlaceableWaterFlags>();
					WaterType.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Flags);
			WaterType.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("WaterType", true, out subEle);
			WaterType.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<PlaceableWaterFlags>();

			if (ele.TryPathTo("WaterType", false, out subEle))
				WaterType.ReadXML(subEle, master);
		}

		public PlaceableWaterData Clone()
		{
			return new PlaceableWaterData(this);
		}

        public int CompareTo(PlaceableWaterData other)
        {
			return WaterType.CompareTo(other.WaterType);
        }

        public static bool operator >(PlaceableWaterData objA, PlaceableWaterData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PlaceableWaterData objA, PlaceableWaterData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PlaceableWaterData objA, PlaceableWaterData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PlaceableWaterData objA, PlaceableWaterData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PlaceableWaterData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				WaterType == other.WaterType;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PlaceableWaterData other = obj as PlaceableWaterData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return WaterType.GetHashCode();
        }

        public static bool operator ==(PlaceableWaterData objA, PlaceableWaterData objB)
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

        public static bool operator !=(PlaceableWaterData objA, PlaceableWaterData objB)
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