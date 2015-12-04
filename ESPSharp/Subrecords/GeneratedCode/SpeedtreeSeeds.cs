















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
	public partial class SpeedtreeSeeds : Subrecord, ICloneable, IEquatable<SpeedtreeSeeds>  
	{
		public List<UInt32> Seeds { get; set; }


		public SpeedtreeSeeds(string Tag = null)
			:base(Tag)
		{
			Seeds = new List<UInt32>();

		}

		public SpeedtreeSeeds(List<UInt32> Seeds)
		{
			this.Seeds = Seeds;

		}

		public SpeedtreeSeeds(SpeedtreeSeeds copyObject)
		{
			if (copyObject.Seeds != null)
				foreach(var temp in copyObject.Seeds)
					Seeds.Add(temp);

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/4; i++)
					{
						Seeds.Add(subReader.ReadUInt32());
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
			foreach (var temp in Seeds)
			{
				writer.Write(temp);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Seeds", true, out subEle);
			foreach (var temp in Seeds)
			{
				subEle.Add(new XElement("Seed", temp));
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Seeds", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					Seeds.Add(e.ToUInt32());
				}

		}

		public override object Clone()
		{
			return new SpeedtreeSeeds(this);
		}



        public bool Equals(SpeedtreeSeeds other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Seeds.SequenceEqual(other.Seeds);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            SpeedtreeSeeds other = obj as SpeedtreeSeeds;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Seeds.GetHashCode();
        }

        public static bool operator ==(SpeedtreeSeeds objA, SpeedtreeSeeds objB)
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

        public static bool operator !=(SpeedtreeSeeds objA, SpeedtreeSeeds objB)
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