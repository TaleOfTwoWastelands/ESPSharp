
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
	public partial class DecalData : Subrecord, ICloneable, IComparable<DecalData>, IEquatable<DecalData>  
	{
		public Single MinWidth { get; set; }
		public Single MaxWidth { get; set; }
		public Single MinHeight { get; set; }
		public Single MaxHeight { get; set; }
		public Single Depth { get; set; }
		public Single Shininess { get; set; }
		public Single ParallaxScale { get; set; }
		public Byte ParallaxPasses { get; set; }
		public DecalDataFlags DecalFlags { get; set; }
		public Byte[] Unused { get; set; }
		public Color Color { get; set; }

		public DecalData(string Tag = null)
			:base(Tag)
		{
			MinWidth = new Single();
			MaxWidth = new Single();
			MinHeight = new Single();
			MaxHeight = new Single();
			Depth = new Single();
			Shininess = new Single();
			ParallaxScale = new Single();
			ParallaxPasses = new Byte();
			DecalFlags = new DecalDataFlags();
			Unused = new byte[2];
			Color = new Color();
		}

		public DecalData(Single MinWidth, Single MaxWidth, Single MinHeight, Single MaxHeight, Single Depth, Single Shininess, Single ParallaxScale, Byte ParallaxPasses, DecalDataFlags DecalFlags, Byte[] Unused, Color Color)
		{
			this.MinWidth = MinWidth;
			this.MaxWidth = MaxWidth;
			this.MinHeight = MinHeight;
			this.MaxHeight = MaxHeight;
			this.Depth = Depth;
			this.Shininess = Shininess;
			this.ParallaxScale = ParallaxScale;
			this.ParallaxPasses = ParallaxPasses;
			this.DecalFlags = DecalFlags;
			this.Unused = Unused;
			this.Color = Color;
		}

		public DecalData(DecalData copyObject)
		{
			MinWidth = copyObject.MinWidth;
			MaxWidth = copyObject.MaxWidth;
			MinHeight = copyObject.MinHeight;
			MaxHeight = copyObject.MaxHeight;
			Depth = copyObject.Depth;
			Shininess = copyObject.Shininess;
			ParallaxScale = copyObject.ParallaxScale;
			ParallaxPasses = copyObject.ParallaxPasses;
			DecalFlags = copyObject.DecalFlags;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			if (copyObject.Color != null)
				Color = (Color)copyObject.Color.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MinWidth = subReader.ReadSingle();
					MaxWidth = subReader.ReadSingle();
					MinHeight = subReader.ReadSingle();
					MaxHeight = subReader.ReadSingle();
					Depth = subReader.ReadSingle();
					Shininess = subReader.ReadSingle();
					ParallaxScale = subReader.ReadSingle();
					ParallaxPasses = subReader.ReadByte();
					DecalFlags = subReader.ReadEnum<DecalDataFlags>();
					Unused = subReader.ReadBytes(2);
					Color.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(MinWidth);
			writer.Write(MaxWidth);
			writer.Write(MinHeight);
			writer.Write(MaxHeight);
			writer.Write(Depth);
			writer.Write(Shininess);
			writer.Write(ParallaxScale);
			writer.Write(ParallaxPasses);
			writer.Write((Byte)DecalFlags);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
			Color.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Width/Min", true, out subEle);
			subEle.Value = MinWidth.ToString("G15");

			ele.TryPathTo("Width/Max", true, out subEle);
			subEle.Value = MaxWidth.ToString("G15");

			ele.TryPathTo("Height/Min", true, out subEle);
			subEle.Value = MinHeight.ToString("G15");

			ele.TryPathTo("Height/Max", true, out subEle);
			subEle.Value = MaxHeight.ToString("G15");

			ele.TryPathTo("Depth", true, out subEle);
			subEle.Value = Depth.ToString("G15");

			ele.TryPathTo("Shininess", true, out subEle);
			subEle.Value = Shininess.ToString("G15");

			ele.TryPathTo("Parallax/Scale", true, out subEle);
			subEle.Value = ParallaxScale.ToString("G15");

			ele.TryPathTo("Parallax/Passes", true, out subEle);
			subEle.Value = ParallaxPasses.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = DecalFlags.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Color", true, out subEle);
			Color.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Width/Min", false, out subEle))
				MinWidth = subEle.ToSingle();

			if (ele.TryPathTo("Width/Max", false, out subEle))
				MaxWidth = subEle.ToSingle();

			if (ele.TryPathTo("Height/Min", false, out subEle))
				MinHeight = subEle.ToSingle();

			if (ele.TryPathTo("Height/Max", false, out subEle))
				MaxHeight = subEle.ToSingle();

			if (ele.TryPathTo("Depth", false, out subEle))
				Depth = subEle.ToSingle();

			if (ele.TryPathTo("Shininess", false, out subEle))
				Shininess = subEle.ToSingle();

			if (ele.TryPathTo("Parallax/Scale", false, out subEle))
				ParallaxScale = subEle.ToSingle();

			if (ele.TryPathTo("Parallax/Passes", false, out subEle))
				ParallaxPasses = subEle.ToByte();

			if (ele.TryPathTo("Flags", false, out subEle))
				DecalFlags = subEle.ToEnum<DecalDataFlags>();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Color", false, out subEle))
				Color.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new DecalData(this);
		}

        public int CompareTo(DecalData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(DecalData objA, DecalData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DecalData objA, DecalData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DecalData objA, DecalData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DecalData objA, DecalData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DecalData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MinWidth == other.MinWidth &&
				MaxWidth == other.MaxWidth &&
				MinHeight == other.MinHeight &&
				MaxHeight == other.MaxHeight &&
				Depth == other.Depth &&
				Shininess == other.Shininess &&
				ParallaxScale == other.ParallaxScale &&
				ParallaxPasses == other.ParallaxPasses &&
				DecalFlags == other.DecalFlags &&
				Unused.SequenceEqual(other.Unused) &&
				Color == other.Color;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DecalData other = obj as DecalData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Depth.GetHashCode();
        }

        public static bool operator ==(DecalData objA, DecalData objB)
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

        public static bool operator !=(DecalData objA, DecalData objB)
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