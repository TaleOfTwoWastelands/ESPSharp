
















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
	public partial class ArmorExtraData : Subrecord, ICloneable, IComparable<ArmorExtraData>, IEquatable<ArmorExtraData>  
	{
		public Int16 DamageResistance { get; set; }
		public ArmorFlags Flags { get; set; }
		public Single DamageThreshold { get; set; }
		public Byte[] Unknown { get; set; }


		public ArmorExtraData(string Tag = null)
			:base(Tag)
		{
			DamageResistance = new Int16();
			Flags = new ArmorFlags();
			DamageThreshold = new Single();
			Unknown = new byte[4];

		}

		public ArmorExtraData(Int16 DamageResistance, ArmorFlags Flags, Single DamageThreshold, Byte[] Unknown)
		{
			this.DamageResistance = DamageResistance;
			this.Flags = Flags;
			this.DamageThreshold = DamageThreshold;
			this.Unknown = Unknown;

		}

		public ArmorExtraData(ArmorExtraData copyObject)
		{
			DamageResistance = copyObject.DamageResistance;
			Flags = copyObject.Flags;
			DamageThreshold = copyObject.DamageThreshold;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					DamageResistance = subReader.ReadInt16();
					Flags = subReader.ReadEnum<ArmorFlags>();
					DamageThreshold = subReader.ReadSingle();
					Unknown = subReader.ReadBytes(4);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DamageResistance);
			writer.Write((UInt16)Flags);
			writer.Write(DamageThreshold);
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("DamageResistance", true, out subEle);
			subEle.Value = DamageResistance.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("DamageThreshold", true, out subEle);
			subEle.Value = DamageThreshold.ToString("G15");

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("DamageResistance", false, out subEle))
				DamageResistance = subEle.ToInt16();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<ArmorFlags>();

			if (ele.TryPathTo("DamageThreshold", false, out subEle))
				DamageThreshold = subEle.ToSingle();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();

		}

		public override object Clone()
		{
			return new ArmorExtraData(this);
		}


        public int CompareTo(ArmorExtraData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(ArmorExtraData objA, ArmorExtraData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ArmorExtraData objA, ArmorExtraData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ArmorExtraData objA, ArmorExtraData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ArmorExtraData objA, ArmorExtraData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(ArmorExtraData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DamageResistance == other.DamageResistance &&
				Flags == other.Flags &&
				DamageThreshold == other.DamageThreshold &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ArmorExtraData other = obj as ArmorExtraData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return DamageResistance.GetHashCode();
        }

        public static bool operator ==(ArmorExtraData objA, ArmorExtraData objB)
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

        public static bool operator !=(ArmorExtraData objA, ArmorExtraData objB)
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