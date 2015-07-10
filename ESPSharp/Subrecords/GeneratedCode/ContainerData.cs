
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
	public partial class ContainerData : Subrecord, ICloneable<ContainerData>, IComparable<ContainerData>, IEquatable<ContainerData>  
	{
		public ContainerFlags Flags { get; set; }
		public Single Weight { get; set; }

		public ContainerData()
		{
			Flags = new ContainerFlags();
			Weight = new Single();
		}

		public ContainerData(ContainerFlags Flags, Single Weight)
		{
			this.Flags = Flags;
			this.Weight = Weight;
		}

		public ContainerData(ContainerData copyObject)
		{
			Flags = copyObject.Flags;
			Weight = copyObject.Weight;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<ContainerFlags>();
					Weight = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Flags);
			writer.Write(Weight);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<ContainerFlags>();

			if (ele.TryPathTo("Weight", false, out subEle))
				Weight = subEle.ToSingle();
		}

		public ContainerData Clone()
		{
			return new ContainerData(this);
		}

        public int CompareTo(ContainerData other)
        {
			return Flags.CompareTo(other.Flags);
        }

        public static bool operator >(ContainerData objA, ContainerData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ContainerData objA, ContainerData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ContainerData objA, ContainerData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ContainerData objA, ContainerData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ContainerData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				Weight == other.Weight;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ContainerData other = obj as ContainerData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Flags.GetHashCode();
        }

        public static bool operator ==(ContainerData objA, ContainerData objB)
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

        public static bool operator !=(ContainerData objA, ContainerData objB)
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