















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
	public partial class StaticCollectionPartData : Subrecord, ICloneable, IEquatable<StaticCollectionPartData>, IReferenceContainer  
	{
		public List<StaticPlacement> Placements { get; set; }


		public StaticCollectionPartData(string Tag = null)
			:base(Tag)
		{
			Placements = new List<StaticPlacement>();

		}

		public StaticCollectionPartData(List<StaticPlacement> Placements)
		{
			this.Placements = Placements;

		}

		public StaticCollectionPartData(StaticCollectionPartData copyObject)
		{
			if (copyObject.Placements != null)
				foreach(var temp in copyObject.Placements)
					Placements.Add((StaticPlacement)temp.Clone());

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/28; i++)
					{
						var temp = new StaticPlacement();
						temp.ReadBinary(subReader);
						Placements.Add(temp);
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
			Placements.Sort();
			foreach (var temp in Placements)
			{
				temp.WriteBinary(writer);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Placements", true, out subEle);
			Placements.Sort();
			foreach (var temp in Placements)
			{
				XElement e = new XElement("Placement");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Placements", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new StaticPlacement();
					temp.ReadXML(e, master);
					Placements.Add(temp);
				}

		}

		public override object Clone()
		{
			return new StaticCollectionPartData(this);
		}



        public bool Equals(StaticCollectionPartData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Placements.SequenceEqual(other.Placements);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            StaticCollectionPartData other = obj as StaticCollectionPartData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Placements.GetHashCode();
        }

        public static bool operator ==(StaticCollectionPartData objA, StaticCollectionPartData objB)
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

        public static bool operator !=(StaticCollectionPartData objA, StaticCollectionPartData objB)
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