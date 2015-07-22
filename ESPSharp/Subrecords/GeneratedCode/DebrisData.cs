
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
	public partial class DebrisData : Subrecord, ICloneable, IComparable<DebrisData>, IEquatable<DebrisData>  
	{
		public Byte Percentage { get; set; }
		public String Model { get; set; }
		public NoYesByte HasCollisionData { get; set; }

		public DebrisData(string Tag = null)
			:base(Tag)
		{
			Percentage = new Byte();
			Model = "";
			HasCollisionData = new NoYesByte();
		}

		public DebrisData(Byte Percentage, String Model, NoYesByte HasCollisionData)
		{
			this.Percentage = Percentage;
			this.Model = Model;
			this.HasCollisionData = HasCollisionData;
		}

		public DebrisData(DebrisData copyObject)
		{
			Percentage = copyObject.Percentage;
			if (copyObject.Model != null)
				Model = (String)copyObject.Model.Clone();
			HasCollisionData = copyObject.HasCollisionData;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Percentage = subReader.ReadByte();
					Model = subReader.ReadString();
					HasCollisionData = subReader.ReadEnum<NoYesByte>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Percentage);
			writer.Write(Model);
			writer.Write((Byte)HasCollisionData);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Percentage", true, out subEle);
			subEle.Value = Percentage.ToString();

			ele.TryPathTo("Model", true, out subEle);
			subEle.Value = Model.ToString();

			ele.TryPathTo("HasCollisionData", true, out subEle);
			subEle.Value = HasCollisionData.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Percentage", false, out subEle))
				Percentage = subEle.ToByte();

			if (ele.TryPathTo("Model", false, out subEle))
				Model = subEle.Value;

			if (ele.TryPathTo("HasCollisionData", false, out subEle))
				HasCollisionData = subEle.ToEnum<NoYesByte>();
		}

		public override object Clone()
		{
			return new DebrisData(this);
		}

        public int CompareTo(DebrisData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(DebrisData objA, DebrisData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DebrisData objA, DebrisData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DebrisData objA, DebrisData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DebrisData objA, DebrisData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DebrisData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Percentage == other.Percentage &&
				Model.SequenceEqual(other.Model) &&
				HasCollisionData == other.HasCollisionData;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DebrisData other = obj as DebrisData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Percentage.GetHashCode();
        }

        public static bool operator ==(DebrisData objA, DebrisData objB)
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

        public static bool operator !=(DebrisData objA, DebrisData objB)
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