
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
	public partial class AnimationSound : Subrecord, ICloneable, IComparable<AnimationSound>, IEquatable<AnimationSound>  
	{
		public FormID Sound { get; set; }
		public Byte Chance { get; set; }
		public Byte[] Unused { get; set; }
		public AnimationSoundType Type { get; set; }

		public AnimationSound(string Tag = null)
			:base(Tag)
		{
			Sound = new FormID();
			Chance = new Byte();
			Unused = new byte[3];
			Type = new AnimationSoundType();
		}

		public AnimationSound(FormID Sound, Byte Chance, Byte[] Unused, AnimationSoundType Type)
		{
			this.Sound = Sound;
			this.Chance = Chance;
			this.Unused = Unused;
			this.Type = Type;
		}

		public AnimationSound(AnimationSound copyObject)
		{
			if (copyObject.Sound != null)
				Sound = (FormID)copyObject.Sound.Clone();
			Chance = copyObject.Chance;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			Type = copyObject.Type;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Sound.ReadBinary(subReader);
					Chance = subReader.ReadByte();
					Unused = subReader.ReadBytes(3);
					Type = subReader.ReadEnum<AnimationSoundType>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Sound.WriteBinary(writer);
			writer.Write(Chance);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
			writer.Write((UInt32)Type);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sound", false, out subEle))
				Sound.ReadXML(subEle, master);

			if (ele.TryPathTo("Chance", false, out subEle))
				Chance = subEle.ToByte();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<AnimationSoundType>();
		}

		public override object Clone()
		{
			return new AnimationSound(this);
		}

        public int CompareTo(AnimationSound other)
        {
			return Sound.CompareTo(other.Sound);
        }

        public static bool operator >(AnimationSound objA, AnimationSound objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AnimationSound objA, AnimationSound objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AnimationSound objA, AnimationSound objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AnimationSound objA, AnimationSound objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(AnimationSound other)
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
				Chance == other.Chance &&
				Unused.SequenceEqual(other.Unused) &&
				Type == other.Type;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AnimationSound other = obj as AnimationSound;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Sound.GetHashCode();
        }

        public static bool operator ==(AnimationSound objA, AnimationSound objB)
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

        public static bool operator !=(AnimationSound objA, AnimationSound objB)
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

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}