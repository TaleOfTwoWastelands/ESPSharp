















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
	public partial class RegionObjectList : Subrecord, ICloneable, IEquatable<RegionObjectList>, IReferenceContainer  
	{
		public List<RegionObject> Objects { get; set; }


		public RegionObjectList(string Tag = null)
			:base(Tag)
		{
			Objects = new List<RegionObject>();

		}

		public RegionObjectList(List<RegionObject> Objects)
		{
			this.Objects = Objects;

		}

		public RegionObjectList(RegionObjectList copyObject)
		{
			if (copyObject.Objects != null)
				foreach(var temp in copyObject.Objects)
					Objects.Add((RegionObject)temp.Clone());

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/52; i++)
					{
						var temp = new RegionObject();
						temp.ReadBinary(subReader);
						Objects.Add(temp);
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
			foreach (var temp in Objects)
			{
				temp.WriteBinary(writer);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Objects", true, out subEle);
			foreach (var temp in Objects)
			{
				XElement e = new XElement("Object");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Objects", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new RegionObject();
					temp.ReadXML(e, master);
					Objects.Add(temp);
				}

		}

		public override object Clone()
		{
			return new RegionObjectList(this);
		}



        public bool Equals(RegionObjectList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Objects.SequenceEqual(other.Objects);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionObjectList other = obj as RegionObjectList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Objects.GetHashCode();
        }

        public static bool operator ==(RegionObjectList objA, RegionObjectList objB)
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

        public static bool operator !=(RegionObjectList objA, RegionObjectList objB)
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