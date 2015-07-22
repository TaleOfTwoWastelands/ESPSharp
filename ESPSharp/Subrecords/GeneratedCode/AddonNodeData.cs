
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
	public partial class AddonNodeData : Subrecord, ICloneable, IComparable<AddonNodeData>, IEquatable<AddonNodeData>  
	{
		public UInt16 MasterParticleSystemCap { get; set; }
		public Byte[] Unknown { get; set; }

		public AddonNodeData(string Tag = null)
			:base(Tag)
		{
			MasterParticleSystemCap = new UInt16();
			Unknown = new byte[2];
		}

		public AddonNodeData(UInt16 MasterParticleSystemCap, Byte[] Unknown)
		{
			this.MasterParticleSystemCap = MasterParticleSystemCap;
			this.Unknown = Unknown;
		}

		public AddonNodeData(AddonNodeData copyObject)
		{
			MasterParticleSystemCap = copyObject.MasterParticleSystemCap;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MasterParticleSystemCap = subReader.ReadUInt16();
					Unknown = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(MasterParticleSystemCap);
			if (Unknown == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("MasterParticleSystemCap", true, out subEle);
			subEle.Value = MasterParticleSystemCap.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("MasterParticleSystemCap", false, out subEle))
				MasterParticleSystemCap = subEle.ToUInt16();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();
		}

		public override object Clone()
		{
			return new AddonNodeData(this);
		}

        public int CompareTo(AddonNodeData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(AddonNodeData objA, AddonNodeData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AddonNodeData objA, AddonNodeData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AddonNodeData objA, AddonNodeData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AddonNodeData objA, AddonNodeData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(AddonNodeData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MasterParticleSystemCap == other.MasterParticleSystemCap &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AddonNodeData other = obj as AddonNodeData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MasterParticleSystemCap.GetHashCode();
        }

        public static bool operator ==(AddonNodeData objA, AddonNodeData objB)
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

        public static bool operator !=(AddonNodeData objA, AddonNodeData objB)
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