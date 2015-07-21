
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
	public partial class GrassData : Subrecord, ICloneable, IComparable<GrassData>, IEquatable<GrassData>  
	{
		public Byte Density { get; set; }
		public Byte MinSlope { get; set; }
		public Byte MaxSlope { get; set; }
		public Byte Unused1 { get; set; }
		public UInt16 UnitFromWaterAmount { get; set; }
		public Byte[] Unused2 { get; set; }
		public UnitFromWaterType UnitFromWaterType { get; set; }
		public Single PositionRange { get; set; }
		public Single HeightRange { get; set; }
		public Single ColorRange { get; set; }
		public Single WavePeriod { get; set; }
		public GrassFlags Flags { get; set; }
		public Byte[] Unused3 { get; set; }

		public GrassData(string Tag = null)
			:base(Tag)
		{
			Density = new Byte();
			MinSlope = new Byte();
			MaxSlope = new Byte();
			Unused1 = new Byte();
			UnitFromWaterAmount = new UInt16();
			Unused2 = new byte[2];
			UnitFromWaterType = new UnitFromWaterType();
			PositionRange = new Single();
			HeightRange = new Single();
			ColorRange = new Single();
			WavePeriod = new Single();
			Flags = new GrassFlags();
			Unused3 = new byte[3];
		}

		public GrassData(Byte Density, Byte MinSlope, Byte MaxSlope, Byte Unused1, UInt16 UnitFromWaterAmount, Byte[] Unused2, UnitFromWaterType UnitFromWaterType, Single PositionRange, Single HeightRange, Single ColorRange, Single WavePeriod, GrassFlags Flags, Byte[] Unused3)
		{
			this.Density = Density;
			this.MinSlope = MinSlope;
			this.MaxSlope = MaxSlope;
			this.Unused1 = Unused1;
			this.UnitFromWaterAmount = UnitFromWaterAmount;
			this.Unused2 = Unused2;
			this.UnitFromWaterType = UnitFromWaterType;
			this.PositionRange = PositionRange;
			this.HeightRange = HeightRange;
			this.ColorRange = ColorRange;
			this.WavePeriod = WavePeriod;
			this.Flags = Flags;
			this.Unused3 = Unused3;
		}

		public GrassData(GrassData copyObject)
		{
			Density = copyObject.Density;
			MinSlope = copyObject.MinSlope;
			MaxSlope = copyObject.MaxSlope;
			Unused1 = copyObject.Unused1;
			UnitFromWaterAmount = copyObject.UnitFromWaterAmount;
			if (copyObject.Unused2 != null)
				Unused2 = (Byte[])copyObject.Unused2.Clone();
			UnitFromWaterType = copyObject.UnitFromWaterType;
			PositionRange = copyObject.PositionRange;
			HeightRange = copyObject.HeightRange;
			ColorRange = copyObject.ColorRange;
			WavePeriod = copyObject.WavePeriod;
			Flags = copyObject.Flags;
			if (copyObject.Unused3 != null)
				Unused3 = (Byte[])copyObject.Unused3.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Density = subReader.ReadByte();
					MinSlope = subReader.ReadByte();
					MaxSlope = subReader.ReadByte();
					Unused1 = subReader.ReadByte();
					UnitFromWaterAmount = subReader.ReadUInt16();
					Unused2 = subReader.ReadBytes(2);
					UnitFromWaterType = subReader.ReadEnum<UnitFromWaterType>();
					PositionRange = subReader.ReadSingle();
					HeightRange = subReader.ReadSingle();
					ColorRange = subReader.ReadSingle();
					WavePeriod = subReader.ReadSingle();
					Flags = subReader.ReadEnum<GrassFlags>();
					Unused3 = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Density);
			writer.Write(MinSlope);
			writer.Write(MaxSlope);
			writer.Write(Unused1);
			writer.Write(UnitFromWaterAmount);
			if (Unused2 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused2);
			writer.Write((UInt32)UnitFromWaterType);
			writer.Write(PositionRange);
			writer.Write(HeightRange);
			writer.Write(ColorRange);
			writer.Write(WavePeriod);
			writer.Write((Byte)Flags);
			if (Unused3 == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused3);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Density", true, out subEle);
			subEle.Value = Density.ToString();

			ele.TryPathTo("Slope/Min", true, out subEle);
			subEle.Value = MinSlope.ToString();

			ele.TryPathTo("Slope/Max", true, out subEle);
			subEle.Value = MaxSlope.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("UnitFromWater/Amount", true, out subEle);
			subEle.Value = UnitFromWaterAmount.ToString();

			WriteUnused2XML(ele, master);

			ele.TryPathTo("UnitFromWater/Type", true, out subEle);
			subEle.Value = UnitFromWaterType.ToString();

			ele.TryPathTo("PositionRange", true, out subEle);
			subEle.Value = PositionRange.ToString("G15");

			ele.TryPathTo("HeightRange", true, out subEle);
			subEle.Value = HeightRange.ToString("G15");

			ele.TryPathTo("ColorRange", true, out subEle);
			subEle.Value = ColorRange.ToString("G15");

			ele.TryPathTo("WavePeriod", true, out subEle);
			subEle.Value = WavePeriod.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnused3XML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Density", false, out subEle))
				Density = subEle.ToByte();

			if (ele.TryPathTo("Slope/Min", false, out subEle))
				MinSlope = subEle.ToByte();

			if (ele.TryPathTo("Slope/Max", false, out subEle))
				MaxSlope = subEle.ToByte();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("UnitFromWater/Amount", false, out subEle))
				UnitFromWaterAmount = subEle.ToUInt16();

			ReadUnused2XML(ele, master);

			if (ele.TryPathTo("UnitFromWater/Type", false, out subEle))
				UnitFromWaterType = subEle.ToEnum<UnitFromWaterType>();

			if (ele.TryPathTo("PositionRange", false, out subEle))
				PositionRange = subEle.ToSingle();

			if (ele.TryPathTo("HeightRange", false, out subEle))
				HeightRange = subEle.ToSingle();

			if (ele.TryPathTo("ColorRange", false, out subEle))
				ColorRange = subEle.ToSingle();

			if (ele.TryPathTo("WavePeriod", false, out subEle))
				WavePeriod = subEle.ToSingle();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<GrassFlags>();

			ReadUnused3XML(ele, master);
		}

		public override object Clone()
		{
			return new GrassData(this);
		}

        public int CompareTo(GrassData other)
        {
			return Density.CompareTo(other.Density);
        }

        public static bool operator >(GrassData objA, GrassData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(GrassData objA, GrassData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(GrassData objA, GrassData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(GrassData objA, GrassData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(GrassData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Density == other.Density &&
				MinSlope == other.MinSlope &&
				MaxSlope == other.MaxSlope &&
				Unused1 == other.Unused1 &&
				UnitFromWaterAmount == other.UnitFromWaterAmount &&
				Unused2.SequenceEqual(other.Unused2) &&
				UnitFromWaterType == other.UnitFromWaterType &&
				PositionRange == other.PositionRange &&
				HeightRange == other.HeightRange &&
				ColorRange == other.ColorRange &&
				WavePeriod == other.WavePeriod &&
				Flags == other.Flags &&
				Unused3.SequenceEqual(other.Unused3);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            GrassData other = obj as GrassData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Density.GetHashCode();
        }

        public static bool operator ==(GrassData objA, GrassData objB)
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

        public static bool operator !=(GrassData objA, GrassData objB)
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

		partial void ReadUnused3XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused3XML(XElement ele, ElderScrollsPlugin master);
	}
}