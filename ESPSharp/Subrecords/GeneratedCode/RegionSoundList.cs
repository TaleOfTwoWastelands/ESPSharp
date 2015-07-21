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
	public partial class RegionSoundList : Subrecord, ICloneable, IEquatable<RegionSoundList>, IReferenceContainer  
	{
		public List<RegionSound> Sounds { get; set; }

		public RegionSoundList(string Tag = null)
			:base(Tag)
		{
			Sounds = new List<RegionSound>();
		}

		public RegionSoundList(List<RegionSound> Sounds)
		{
			this.Sounds = Sounds;
		}

		public RegionSoundList(RegionSoundList copyObject)
		{
			if (copyObject.Sounds != null)
				foreach(var temp in copyObject.Sounds)
					Sounds.Add((RegionSound)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/12; i++)
					{
						var temp = new RegionSound();
						temp.ReadBinary(subReader);
						Sounds.Add(temp);
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
			foreach (var temp in Sounds)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sounds", true, out subEle);
			foreach (var temp in Sounds)
			{
				XElement e = new XElement("Sound");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sounds", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new RegionSound();
					temp.ReadXML(e, master);
					Sounds.Add(temp);
				}
		}

		public override object Clone()
		{
			return new RegionSoundList(this);
		}

        public bool Equals(RegionSoundList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Sounds.SequenceEqual(other.Sounds);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionSoundList other = obj as RegionSoundList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Sounds.GetHashCode();
        }

        public static bool operator ==(RegionSoundList objA, RegionSoundList objB)
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

        public static bool operator !=(RegionSoundList objA, RegionSoundList objB)
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