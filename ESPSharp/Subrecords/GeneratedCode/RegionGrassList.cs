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
	public partial class RegionGrassList : Subrecord, ICloneable, IEquatable<RegionGrassList>, IReferenceContainer  
	{
		public List<RegionGrass> Grasses { get; set; }

		public RegionGrassList(string Tag = null)
			:base(Tag)
		{
			Grasses = new List<RegionGrass>();
		}

		public RegionGrassList(List<RegionGrass> Grasses)
		{
			this.Grasses = Grasses;
		}

		public RegionGrassList(RegionGrassList copyObject)
		{
			if (copyObject.Grasses != null)
				foreach(var temp in copyObject.Grasses)
					Grasses.Add((RegionGrass)temp.Clone());
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
						var temp = new RegionGrass();
						temp.ReadBinary(subReader);
						Grasses.Add(temp);
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
			foreach (var temp in Grasses)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Grasses", true, out subEle);
			foreach (var temp in Grasses)
			{
				XElement e = new XElement("Grass");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Grasses", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new RegionGrass();
					temp.ReadXML(e, master);
					Grasses.Add(temp);
				}
		}

		public override object Clone()
		{
			return new RegionGrassList(this);
		}

        public bool Equals(RegionGrassList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Grasses.SequenceEqual(other.Grasses);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionGrassList other = obj as RegionGrassList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Grasses.GetHashCode();
        }

        public static bool operator ==(RegionGrassList objA, RegionGrassList objB)
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

        public static bool operator !=(RegionGrassList objA, RegionGrassList objB)
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