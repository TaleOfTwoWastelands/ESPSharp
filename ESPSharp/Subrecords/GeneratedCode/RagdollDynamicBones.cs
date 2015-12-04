















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
	public partial class RagdollDynamicBones : Subrecord, ICloneable, IEquatable<RagdollDynamicBones>  
	{
		public List<UInt16> Bones { get; set; }


		public RagdollDynamicBones(string Tag = null)
			:base(Tag)
		{
			Bones = new List<UInt16>();

		}

		public RagdollDynamicBones(List<UInt16> Bones)
		{
			this.Bones = Bones;

		}

		public RagdollDynamicBones(RagdollDynamicBones copyObject)
		{
			if (copyObject.Bones != null)
				foreach(var temp in copyObject.Bones)
					Bones.Add(temp);

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/2; i++)
					{
						Bones.Add(subReader.ReadUInt16());
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
			foreach (var temp in Bones)
			{
				writer.Write(temp);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Bones", true, out subEle);
			foreach (var temp in Bones)
			{
				subEle.Add(new XElement("Bone", temp));
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Bones", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					Bones.Add(e.ToUInt16());
				}

		}

		public override object Clone()
		{
			return new RagdollDynamicBones(this);
		}



        public bool Equals(RagdollDynamicBones other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Bones.SequenceEqual(other.Bones);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RagdollDynamicBones other = obj as RagdollDynamicBones;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Bones.GetHashCode();
        }

        public static bool operator ==(RagdollDynamicBones objA, RagdollDynamicBones objB)
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

        public static bool operator !=(RagdollDynamicBones objA, RagdollDynamicBones objB)
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