
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
	public partial class IdleAnimationData : Subrecord, ICloneable<IdleAnimationData>, IComparable<IdleAnimationData>, IEquatable<IdleAnimationData>  
	{
		public AnimationGroupSection AnimationGroupSection { get; set; }
		public Byte LoopingMin { get; set; }
		public Byte LoopingMax { get; set; }
		public Byte Unused1 { get; set; }
		public Int16 ReplayDelay { get; set; }
		public IdleAnimationFlags Flags { get; set; }
		public Byte Unused2 { get; set; }

		public IdleAnimationData()
		{
			AnimationGroupSection = new AnimationGroupSection();
			LoopingMin = new Byte();
			LoopingMax = new Byte();
			Unused1 = new Byte();
			ReplayDelay = new Int16();
			Flags = new IdleAnimationFlags();
			Unused2 = new Byte();
		}

		public IdleAnimationData(AnimationGroupSection AnimationGroupSection, Byte LoopingMin, Byte LoopingMax, Byte Unused1, Int16 ReplayDelay, IdleAnimationFlags Flags, Byte Unused2)
		{
			this.AnimationGroupSection = AnimationGroupSection;
			this.LoopingMin = LoopingMin;
			this.LoopingMax = LoopingMax;
			this.Unused1 = Unused1;
			this.ReplayDelay = ReplayDelay;
			this.Flags = Flags;
			this.Unused2 = Unused2;
		}

		public IdleAnimationData(IdleAnimationData copyObject)
		{
			AnimationGroupSection = copyObject.AnimationGroupSection;
			LoopingMin = copyObject.LoopingMin;
			LoopingMax = copyObject.LoopingMax;
			Unused1 = copyObject.Unused1;
			ReplayDelay = copyObject.ReplayDelay;
			Flags = copyObject.Flags;
			Unused2 = copyObject.Unused2;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					AnimationGroupSection = subReader.ReadEnum<AnimationGroupSection>();
					LoopingMin = subReader.ReadByte();
					LoopingMax = subReader.ReadByte();
					Unused1 = subReader.ReadByte();
					ReplayDelay = subReader.ReadInt16();
					Flags = subReader.ReadEnum<IdleAnimationFlags>();
					Unused2 = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)AnimationGroupSection);
			writer.Write(LoopingMin);
			writer.Write(LoopingMax);
			writer.Write(Unused1);
			writer.Write(ReplayDelay);
			writer.Write((Byte)Flags);
			writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("AnimationGroupSection", true, out subEle);
			subEle.Value = AnimationGroupSection.ToString();

			ele.TryPathTo("Looping/Min", true, out subEle);
			subEle.Value = LoopingMin.ToString();

			ele.TryPathTo("Looping/Max", true, out subEle);
			subEle.Value = LoopingMax.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("ReplayDelay", true, out subEle);
			subEle.Value = ReplayDelay.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnused2XML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("AnimationGroupSection", false, out subEle))
				AnimationGroupSection = subEle.ToEnum<AnimationGroupSection>();

			if (ele.TryPathTo("Looping/Min", false, out subEle))
				LoopingMin = subEle.ToByte();

			if (ele.TryPathTo("Looping/Max", false, out subEle))
				LoopingMax = subEle.ToByte();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("ReplayDelay", false, out subEle))
				ReplayDelay = subEle.ToInt16();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<IdleAnimationFlags>();

			ReadUnused2XML(ele, master);
		}

		public IdleAnimationData Clone()
		{
			return new IdleAnimationData(this);
		}

        public int CompareTo(IdleAnimationData other)
        {
			return AnimationGroupSection.CompareTo(other.AnimationGroupSection);
        }

        public static bool operator >(IdleAnimationData objA, IdleAnimationData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(IdleAnimationData objA, IdleAnimationData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(IdleAnimationData objA, IdleAnimationData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(IdleAnimationData objA, IdleAnimationData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(IdleAnimationData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return AnimationGroupSection == other.AnimationGroupSection &&
				LoopingMin == other.LoopingMin &&
				LoopingMax == other.LoopingMax &&
				Unused1 == other.Unused1 &&
				ReplayDelay == other.ReplayDelay &&
				Flags == other.Flags &&
				Unused2 == other.Unused2;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            IdleAnimationData other = obj as IdleAnimationData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return AnimationGroupSection.GetHashCode();
        }

        public static bool operator ==(IdleAnimationData objA, IdleAnimationData objB)
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

        public static bool operator !=(IdleAnimationData objA, IdleAnimationData objB)
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

		partial void ReadUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);
	}
}