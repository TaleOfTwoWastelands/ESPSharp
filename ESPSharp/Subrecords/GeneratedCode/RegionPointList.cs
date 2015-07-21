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
	public partial class RegionPointList : Subrecord, ICloneable, IEquatable<RegionPointList>  
	{
		public List<XYFloat> Points { get; set; }

		public RegionPointList(string Tag = null)
			:base(Tag)
		{
			Points = new List<XYFloat>();
		}

		public RegionPointList(List<XYFloat> Points)
		{
			this.Points = Points;
		}

		public RegionPointList(RegionPointList copyObject)
		{
			if (copyObject.Points != null)
				foreach(var temp in copyObject.Points)
					Points.Add((XYFloat)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/8; i++)
					{
						var temp = new XYFloat();
						temp.ReadBinary(subReader);
						Points.Add(temp);
					}
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			foreach (var temp in Points)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Points", true, out subEle);
			foreach (var temp in Points)
			{
				XElement e = new XElement("Point");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Points", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new XYFloat();
					temp.ReadXML(e, master);
					Points.Add(temp);
				}
		}

		public override object Clone()
		{
			return new RegionPointList(this);
		}

        public bool Equals(RegionPointList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Points.SequenceEqual(other.Points);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionPointList other = obj as RegionPointList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Points.GetHashCode();
        }

        public static bool operator ==(RegionPointList objA, RegionPointList objB)
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

        public static bool operator !=(RegionPointList objA, RegionPointList objB)
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