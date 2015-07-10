
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
	public partial class CloudLayerColors : Subrecord, ICloneable<CloudLayerColors>, IComparable<CloudLayerColors>, IEquatable<CloudLayerColors>  
	{
		public TimeOfDayColors Layer0 { get; set; }
		public TimeOfDayColors Layer1 { get; set; }
		public TimeOfDayColors Layer2 { get; set; }
		public TimeOfDayColors Layer3 { get; set; }

		public CloudLayerColors()
		{
			Layer0 = new TimeOfDayColors();
			Layer1 = new TimeOfDayColors();
			Layer2 = new TimeOfDayColors();
			Layer3 = new TimeOfDayColors();
		}

		public CloudLayerColors(TimeOfDayColors Layer0, TimeOfDayColors Layer1, TimeOfDayColors Layer2, TimeOfDayColors Layer3)
		{
			this.Layer0 = Layer0;
			this.Layer1 = Layer1;
			this.Layer2 = Layer2;
			this.Layer3 = Layer3;
		}

		public CloudLayerColors(CloudLayerColors copyObject)
		{
			Layer0 = copyObject.Layer0.Clone();
			Layer1 = copyObject.Layer1.Clone();
			Layer2 = copyObject.Layer2.Clone();
			Layer3 = copyObject.Layer3.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Layer0.ReadBinary(subReader);
					Layer1.ReadBinary(subReader);
					Layer2.ReadBinary(subReader);
					Layer3.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Layer0.WriteBinary(writer);
			Layer1.WriteBinary(writer);
			Layer2.WriteBinary(writer);
			Layer3.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Layer0", true, out subEle);
			Layer0.WriteXML(subEle, master);

			ele.TryPathTo("Layer1", true, out subEle);
			Layer1.WriteXML(subEle, master);

			ele.TryPathTo("Layer2", true, out subEle);
			Layer2.WriteXML(subEle, master);

			ele.TryPathTo("Layer3", true, out subEle);
			Layer3.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Layer0", false, out subEle))
				Layer0.ReadXML(subEle, master);

			if (ele.TryPathTo("Layer1", false, out subEle))
				Layer1.ReadXML(subEle, master);

			if (ele.TryPathTo("Layer2", false, out subEle))
				Layer2.ReadXML(subEle, master);

			if (ele.TryPathTo("Layer3", false, out subEle))
				Layer3.ReadXML(subEle, master);
		}

		public CloudLayerColors Clone()
		{
			return new CloudLayerColors(this);
		}

        public int CompareTo(CloudLayerColors other)
        {
			return Layer0.CompareTo(other.Layer0);
        }

        public static bool operator >(CloudLayerColors objA, CloudLayerColors objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CloudLayerColors objA, CloudLayerColors objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CloudLayerColors objA, CloudLayerColors objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CloudLayerColors objA, CloudLayerColors objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CloudLayerColors other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Layer0 == other.Layer0 &&
				Layer1 == other.Layer1 &&
				Layer2 == other.Layer2 &&
				Layer3 == other.Layer3;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CloudLayerColors other = obj as CloudLayerColors;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Layer0.GetHashCode();
        }

        public static bool operator ==(CloudLayerColors objA, CloudLayerColors objB)
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

        public static bool operator !=(CloudLayerColors objA, CloudLayerColors objB)
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