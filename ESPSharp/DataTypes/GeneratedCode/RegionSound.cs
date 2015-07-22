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

namespace ESPSharp.DataTypes
{
	public partial class RegionSound : IESPSerializable, ICloneable, IComparable<RegionSound>, IEquatable<RegionSound>  
	{
		public FormID Sound { get; set; }
		public RegionSoundFlags Flags { get; set; }
		public UInt32 Chance { get; set; }

		public RegionSound()
		{
			Sound = new FormID();
			Flags = new RegionSoundFlags();
			Chance = new UInt32();
		}

		public RegionSound(FormID Sound, RegionSoundFlags Flags, UInt32 Chance)
		{
			this.Sound = Sound;
			this.Flags = Flags;
			this.Chance = Chance;
		}

		public RegionSound(RegionSound copyObject)
		{
			if (copyObject.Sound != null)
				Sound = (FormID)copyObject.Sound.Clone();
			Flags = copyObject.Flags;
			Chance = copyObject.Chance;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Sound.ReadBinary(reader);
					Flags = reader.ReadEnum<RegionSoundFlags>();
					Chance = reader.ReadUInt32();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Sound.WriteBinary(writer);
			writer.Write((UInt32)Flags);
			writer.Write(Chance);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sound", false, out subEle))
				Sound.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<RegionSoundFlags>();

			if (ele.TryPathTo("Chance", false, out subEle))
				Chance = subEle.ToUInt32();
		}

		public object Clone()
		{
			return new RegionSound(this);
		}

        public int CompareTo(RegionSound other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(RegionSound objA, RegionSound objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RegionSound objA, RegionSound objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RegionSound objA, RegionSound objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RegionSound objA, RegionSound objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RegionSound other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Sound == other.Sound &&
				Flags == other.Flags &&
				Chance == other.Chance;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RegionSound other = obj as RegionSound;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Sound.GetHashCode();
        }

        public static bool operator ==(RegionSound objA, RegionSound objB)
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

        public static bool operator !=(RegionSound objA, RegionSound objB)
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