
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
	public partial class ArmorAddonData : Subrecord, ICloneable, IComparable<ArmorAddonData>, IEquatable<ArmorAddonData>  
	{
		public Int16 ArmorRating { get; set; }
		public NoYesShort ModulatesVoice { get; set; }
		public Byte[] Unknown { get; set; }

		public ArmorAddonData(string Tag = null)
			:base(Tag)
		{
			ArmorRating = new Int16();
			ModulatesVoice = new NoYesShort();
			Unknown = new byte[8];
		}

		public ArmorAddonData(Int16 ArmorRating, NoYesShort ModulatesVoice, Byte[] Unknown)
		{
			this.ArmorRating = ArmorRating;
			this.ModulatesVoice = ModulatesVoice;
			this.Unknown = Unknown;
		}

		public ArmorAddonData(ArmorAddonData copyObject)
		{
			ArmorRating = copyObject.ArmorRating;
			ModulatesVoice = copyObject.ModulatesVoice;
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
					ArmorRating = subReader.ReadInt16();
					ModulatesVoice = subReader.ReadEnum<NoYesShort>();
					Unknown = subReader.ReadBytes(8);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(ArmorRating);
			writer.Write((UInt16)ModulatesVoice);
			if (Unknown == null)
				writer.Write(new byte[8]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("ArmorRating", true, out subEle);
			subEle.Value = ArmorRating.ToString();

			ele.TryPathTo("ModulatesVoice", true, out subEle);
			subEle.Value = ModulatesVoice.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ArmorRating", false, out subEle))
				ArmorRating = subEle.ToInt16();

			if (ele.TryPathTo("ModulatesVoice", false, out subEle))
				ModulatesVoice = subEle.ToEnum<NoYesShort>();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();
		}

		public override object Clone()
		{
			return new ArmorAddonData(this);
		}

        public int CompareTo(ArmorAddonData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(ArmorAddonData objA, ArmorAddonData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ArmorAddonData objA, ArmorAddonData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ArmorAddonData objA, ArmorAddonData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ArmorAddonData objA, ArmorAddonData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ArmorAddonData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ArmorRating == other.ArmorRating &&
				ModulatesVoice == other.ModulatesVoice &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ArmorAddonData other = obj as ArmorAddonData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ArmorRating.GetHashCode();
        }

        public static bool operator ==(ArmorAddonData objA, ArmorAddonData objB)
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

        public static bool operator !=(ArmorAddonData objA, ArmorAddonData objB)
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