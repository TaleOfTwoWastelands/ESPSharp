
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
	public partial class LoadScreenTypeData : Subrecord, ICloneable<LoadScreenTypeData>, IComparable<LoadScreenTypeData>, IEquatable<LoadScreenTypeData>  
	{
		public LoadScreenTypeEnum Type { get; set; }
		public UInt32 X { get; set; }
		public UInt32 Y { get; set; }
		public UInt32 Width { get; set; }
		public UInt32 Height { get; set; }
		public Single Orientation { get; set; }
		public FontType Font1 { get; set; }
		public Single Font1Red { get; set; }
		public Single Font1Green { get; set; }
		public Single Font1Blue { get; set; }
		public FontAlignment Font1Alignment { get; set; }
		public Byte[] Unknown1 { get; set; }
		public FontType Font2 { get; set; }
		public Single Font2Red { get; set; }
		public Single Font2Green { get; set; }
		public Single Font2Blue { get; set; }
		public Byte[] Unknown2 { get; set; }
		public UInt32 Stats { get; set; }

		public LoadScreenTypeData()
		{
			Type = new LoadScreenTypeEnum();
			X = new UInt32();
			Y = new UInt32();
			Width = new UInt32();
			Height = new UInt32();
			Orientation = new Single();
			Font1 = new FontType();
			Font1Red = new Single();
			Font1Green = new Single();
			Font1Blue = new Single();
			Font1Alignment = new FontAlignment();
			Unknown1 = new byte[20];
			Font2 = new FontType();
			Font2Red = new Single();
			Font2Green = new Single();
			Font2Blue = new Single();
			Unknown2 = new byte[4];
			Stats = new UInt32();
		}

		public LoadScreenTypeData(LoadScreenTypeEnum Type, UInt32 X, UInt32 Y, UInt32 Width, UInt32 Height, Single Orientation, FontType Font1, Single Font1Red, Single Font1Green, Single Font1Blue, FontAlignment Font1Alignment, Byte[] Unknown1, FontType Font2, Single Font2Red, Single Font2Green, Single Font2Blue, Byte[] Unknown2, UInt32 Stats)
		{
			this.Type = Type;
			this.X = X;
			this.Y = Y;
			this.Width = Width;
			this.Height = Height;
			this.Orientation = Orientation;
			this.Font1 = Font1;
			this.Font1Red = Font1Red;
			this.Font1Green = Font1Green;
			this.Font1Blue = Font1Blue;
			this.Font1Alignment = Font1Alignment;
			this.Unknown1 = Unknown1;
			this.Font2 = Font2;
			this.Font2Red = Font2Red;
			this.Font2Green = Font2Green;
			this.Font2Blue = Font2Blue;
			this.Unknown2 = Unknown2;
			this.Stats = Stats;
		}

		public LoadScreenTypeData(LoadScreenTypeData copyObject)
		{
			Type = copyObject.Type;
			X = copyObject.X;
			Y = copyObject.Y;
			Width = copyObject.Width;
			Height = copyObject.Height;
			Orientation = copyObject.Orientation;
			Font1 = copyObject.Font1;
			Font1Red = copyObject.Font1Red;
			Font1Green = copyObject.Font1Green;
			Font1Blue = copyObject.Font1Blue;
			Font1Alignment = copyObject.Font1Alignment;
			Unknown1 = (Byte[])copyObject.Unknown1.Clone();
			Font2 = copyObject.Font2;
			Font2Red = copyObject.Font2Red;
			Font2Green = copyObject.Font2Green;
			Font2Blue = copyObject.Font2Blue;
			Unknown2 = (Byte[])copyObject.Unknown2.Clone();
			Stats = copyObject.Stats;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<LoadScreenTypeEnum>();
					X = subReader.ReadUInt32();
					Y = subReader.ReadUInt32();
					Width = subReader.ReadUInt32();
					Height = subReader.ReadUInt32();
					Orientation = subReader.ReadSingle();
					Font1 = subReader.ReadEnum<FontType>();
					Font1Red = subReader.ReadSingle();
					Font1Green = subReader.ReadSingle();
					Font1Blue = subReader.ReadSingle();
					Font1Alignment = subReader.ReadEnum<FontAlignment>();
					Unknown1 = subReader.ReadBytes(20);
					Font2 = subReader.ReadEnum<FontType>();
					Font2Red = subReader.ReadSingle();
					Font2Green = subReader.ReadSingle();
					Font2Blue = subReader.ReadSingle();
					Unknown2 = subReader.ReadBytes(4);
					Stats = subReader.ReadUInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Type);
			writer.Write(X);
			writer.Write(Y);
			writer.Write(Width);
			writer.Write(Height);
			writer.Write(Orientation);
			writer.Write((UInt32)Font1);
			writer.Write(Font1Red);
			writer.Write(Font1Green);
			writer.Write(Font1Blue);
			writer.Write((UInt32)Font1Alignment);
			if (Unknown1 == null)
				writer.Write(new byte[20]);
			else
			writer.Write(Unknown1);
			writer.Write((UInt32)Font2);
			writer.Write(Font2Red);
			writer.Write(Font2Green);
			writer.Write(Font2Blue);
			if (Unknown2 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown2);
			writer.Write(Stats);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString();

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString();

			ele.TryPathTo("Width", true, out subEle);
			subEle.Value = Width.ToString();

			ele.TryPathTo("Height", true, out subEle);
			subEle.Value = Height.ToString();

			ele.TryPathTo("Orientation", true, out subEle);
			subEle.Value = Orientation.ToString("G15");

			ele.TryPathTo("Font1/Font", true, out subEle);
			subEle.Value = Font1.ToString();

			ele.TryPathTo("Font1/Color/Red", true, out subEle);
			subEle.Value = Font1Red.ToString("G15");

			ele.TryPathTo("Font1/Color/Green", true, out subEle);
			subEle.Value = Font1Green.ToString("G15");

			ele.TryPathTo("Font1/Color/Blue", true, out subEle);
			subEle.Value = Font1Blue.ToString("G15");

			ele.TryPathTo("Font1/Alignment", true, out subEle);
			subEle.Value = Font1Alignment.ToString();

			ele.TryPathTo("Unknown1", true, out subEle);
			subEle.Value = Unknown1.ToHex();

			ele.TryPathTo("Font2/Font", true, out subEle);
			subEle.Value = Font2.ToString();

			ele.TryPathTo("Font2/Color/Red", true, out subEle);
			subEle.Value = Font2Red.ToString("G15");

			ele.TryPathTo("Font2/Color/Green", true, out subEle);
			subEle.Value = Font2Green.ToString("G15");

			ele.TryPathTo("Font2/Color/Blue", true, out subEle);
			subEle.Value = Font2Blue.ToString("G15");

			ele.TryPathTo("Unknown2", true, out subEle);
			subEle.Value = Unknown2.ToHex();

			ele.TryPathTo("Stats", true, out subEle);
			subEle.Value = Stats.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<LoadScreenTypeEnum>();

			if (ele.TryPathTo("X", false, out subEle))
				X = subEle.ToUInt32();

			if (ele.TryPathTo("Y", false, out subEle))
				Y = subEle.ToUInt32();

			if (ele.TryPathTo("Width", false, out subEle))
				Width = subEle.ToUInt32();

			if (ele.TryPathTo("Height", false, out subEle))
				Height = subEle.ToUInt32();

			if (ele.TryPathTo("Orientation", false, out subEle))
				Orientation = subEle.ToSingle();

			if (ele.TryPathTo("Font1/Font", false, out subEle))
				Font1 = subEle.ToEnum<FontType>();

			if (ele.TryPathTo("Font1/Color/Red", false, out subEle))
				Font1Red = subEle.ToSingle();

			if (ele.TryPathTo("Font1/Color/Green", false, out subEle))
				Font1Green = subEle.ToSingle();

			if (ele.TryPathTo("Font1/Color/Blue", false, out subEle))
				Font1Blue = subEle.ToSingle();

			if (ele.TryPathTo("Font1/Alignment", false, out subEle))
				Font1Alignment = subEle.ToEnum<FontAlignment>();

			if (ele.TryPathTo("Unknown1", false, out subEle))
				Unknown1 = subEle.ToBytes();

			if (ele.TryPathTo("Font2/Font", false, out subEle))
				Font2 = subEle.ToEnum<FontType>();

			if (ele.TryPathTo("Font2/Color/Red", false, out subEle))
				Font2Red = subEle.ToSingle();

			if (ele.TryPathTo("Font2/Color/Green", false, out subEle))
				Font2Green = subEle.ToSingle();

			if (ele.TryPathTo("Font2/Color/Blue", false, out subEle))
				Font2Blue = subEle.ToSingle();

			if (ele.TryPathTo("Unknown2", false, out subEle))
				Unknown2 = subEle.ToBytes();

			if (ele.TryPathTo("Stats", false, out subEle))
				Stats = subEle.ToUInt32();
		}

		public LoadScreenTypeData Clone()
		{
			return new LoadScreenTypeData(this);
		}

        public int CompareTo(LoadScreenTypeData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(LoadScreenTypeData objA, LoadScreenTypeData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LoadScreenTypeData objA, LoadScreenTypeData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LoadScreenTypeData objA, LoadScreenTypeData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LoadScreenTypeData objA, LoadScreenTypeData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LoadScreenTypeData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Type == other.Type &&
				X == other.X &&
				Y == other.Y &&
				Width == other.Width &&
				Height == other.Height &&
				Orientation == other.Orientation &&
				Font1 == other.Font1 &&
				Font1Red == other.Font1Red &&
				Font1Green == other.Font1Green &&
				Font1Blue == other.Font1Blue &&
				Font1Alignment == other.Font1Alignment &&
				Unknown1.SequenceEqual(other.Unknown1) &&
				Font2 == other.Font2 &&
				Font2Red == other.Font2Red &&
				Font2Green == other.Font2Green &&
				Font2Blue == other.Font2Blue &&
				Unknown2.SequenceEqual(other.Unknown2) &&
				Stats == other.Stats;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LoadScreenTypeData other = obj as LoadScreenTypeData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(LoadScreenTypeData objA, LoadScreenTypeData objB)
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

        public static bool operator !=(LoadScreenTypeData objA, LoadScreenTypeData objB)
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