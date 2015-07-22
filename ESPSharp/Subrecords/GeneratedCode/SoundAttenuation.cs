
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
	public partial class SoundAttenuation : Subrecord, ICloneable, IComparable<SoundAttenuation>, IEquatable<SoundAttenuation>  
	{
		public Int16 Point1 { get; set; }
		public Int16 Point2 { get; set; }
		public Int16 Point3 { get; set; }
		public Int16 Point4 { get; set; }
		public Int16 Point5 { get; set; }

		public SoundAttenuation(string Tag = null)
			:base(Tag)
		{
			Point1 = new Int16();
			Point2 = new Int16();
			Point3 = new Int16();
			Point4 = new Int16();
			Point5 = new Int16();
		}

		public SoundAttenuation(Int16 Point1, Int16 Point2, Int16 Point3, Int16 Point4, Int16 Point5)
		{
			this.Point1 = Point1;
			this.Point2 = Point2;
			this.Point3 = Point3;
			this.Point4 = Point4;
			this.Point5 = Point5;
		}

		public SoundAttenuation(SoundAttenuation copyObject)
		{
			Point1 = copyObject.Point1;
			Point2 = copyObject.Point2;
			Point3 = copyObject.Point3;
			Point4 = copyObject.Point4;
			Point5 = copyObject.Point5;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Point1 = subReader.ReadInt16();
					Point2 = subReader.ReadInt16();
					Point3 = subReader.ReadInt16();
					Point4 = subReader.ReadInt16();
					Point5 = subReader.ReadInt16();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Point1);
			writer.Write(Point2);
			writer.Write(Point3);
			writer.Write(Point4);
			writer.Write(Point5);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Point1", true, out subEle);
			subEle.Value = Point1.ToString();

			ele.TryPathTo("Point2", true, out subEle);
			subEle.Value = Point2.ToString();

			ele.TryPathTo("Point3", true, out subEle);
			subEle.Value = Point3.ToString();

			ele.TryPathTo("Point4", true, out subEle);
			subEle.Value = Point4.ToString();

			ele.TryPathTo("Point5", true, out subEle);
			subEle.Value = Point5.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Point1", false, out subEle))
				Point1 = subEle.ToInt16();

			if (ele.TryPathTo("Point2", false, out subEle))
				Point2 = subEle.ToInt16();

			if (ele.TryPathTo("Point3", false, out subEle))
				Point3 = subEle.ToInt16();

			if (ele.TryPathTo("Point4", false, out subEle))
				Point4 = subEle.ToInt16();

			if (ele.TryPathTo("Point5", false, out subEle))
				Point5 = subEle.ToInt16();
		}

		public override object Clone()
		{
			return new SoundAttenuation(this);
		}

        public int CompareTo(SoundAttenuation other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(SoundAttenuation objA, SoundAttenuation objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(SoundAttenuation objA, SoundAttenuation objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(SoundAttenuation objA, SoundAttenuation objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(SoundAttenuation objA, SoundAttenuation objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(SoundAttenuation other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Point1 == other.Point1 &&
				Point2 == other.Point2 &&
				Point3 == other.Point3 &&
				Point4 == other.Point4 &&
				Point5 == other.Point5;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            SoundAttenuation other = obj as SoundAttenuation;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Point1.GetHashCode();
        }

        public static bool operator ==(SoundAttenuation objA, SoundAttenuation objB)
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

        public static bool operator !=(SoundAttenuation objA, SoundAttenuation objB)
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