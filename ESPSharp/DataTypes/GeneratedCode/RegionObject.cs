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
	public partial class RegionObject : IESPSerializable, ICloneable<RegionObject>, IReferenceContainer
	{
		public FormID Object { get; set; }
		public UInt16 ParentIndex { get; set; }
		public Byte[] Unused { get; set; }
		public Single Density { get; set; }
		public Byte Clustering { get; set; }
		public Byte MinSlope { get; set; }
		public Byte MaxSlope { get; set; }
		public RegionObjectFlags Flags { get; set; }
		public UInt16 RadiusWithRespectToParent { get; set; }
		public UInt16 Radius { get; set; }
		public Byte[] Unknown1 { get; set; }
		public Single MaxHeight { get; set; }
		public Single Sink { get; set; }
		public Single SinkVariance { get; set; }
		public Single SizeVariance { get; set; }
		public UInt16 XAngleVariance { get; set; }
		public UInt16 YAngleVariance { get; set; }
		public UInt16 ZAngleVariance { get; set; }
		public Byte[] Unknown2 { get; set; }

		public RegionObject()
		{
			Object = new FormID();
			ParentIndex = new UInt16();
			Unused = new byte[2];
			Density = new Single();
			Clustering = new Byte();
			MinSlope = new Byte();
			MaxSlope = new Byte();
			Flags = new RegionObjectFlags();
			RadiusWithRespectToParent = new UInt16();
			Radius = new UInt16();
			Unknown1 = new byte[4];
			MaxHeight = new Single();
			Sink = new Single();
			SinkVariance = new Single();
			SizeVariance = new Single();
			XAngleVariance = new UInt16();
			YAngleVariance = new UInt16();
			ZAngleVariance = new UInt16();
			Unknown2 = new byte[6];
		}

		public RegionObject(FormID Object, UInt16 ParentIndex, Byte[] Unused, Single Density, Byte Clustering, Byte MinSlope, Byte MaxSlope, RegionObjectFlags Flags, UInt16 RadiusWithRespectToParent, UInt16 Radius, Byte[] Unknown1, Single MaxHeight, Single Sink, Single SinkVariance, Single SizeVariance, UInt16 XAngleVariance, UInt16 YAngleVariance, UInt16 ZAngleVariance, Byte[] Unknown2)
		{
			this.Object = Object;
			this.ParentIndex = ParentIndex;
			this.Unused = Unused;
			this.Density = Density;
			this.Clustering = Clustering;
			this.MinSlope = MinSlope;
			this.MaxSlope = MaxSlope;
			this.Flags = Flags;
			this.RadiusWithRespectToParent = RadiusWithRespectToParent;
			this.Radius = Radius;
			this.Unknown1 = Unknown1;
			this.MaxHeight = MaxHeight;
			this.Sink = Sink;
			this.SinkVariance = SinkVariance;
			this.SizeVariance = SizeVariance;
			this.XAngleVariance = XAngleVariance;
			this.YAngleVariance = YAngleVariance;
			this.ZAngleVariance = ZAngleVariance;
			this.Unknown2 = Unknown2;
		}

		public RegionObject(RegionObject copyObject)
		{
			Object = copyObject.Object.Clone();
			ParentIndex = copyObject.ParentIndex;
			Unused = (Byte[])copyObject.Unused.Clone();
			Density = copyObject.Density;
			Clustering = copyObject.Clustering;
			MinSlope = copyObject.MinSlope;
			MaxSlope = copyObject.MaxSlope;
			Flags = copyObject.Flags;
			RadiusWithRespectToParent = copyObject.RadiusWithRespectToParent;
			Radius = copyObject.Radius;
			Unknown1 = (Byte[])copyObject.Unknown1.Clone();
			MaxHeight = copyObject.MaxHeight;
			Sink = copyObject.Sink;
			SinkVariance = copyObject.SinkVariance;
			SizeVariance = copyObject.SizeVariance;
			XAngleVariance = copyObject.XAngleVariance;
			YAngleVariance = copyObject.YAngleVariance;
			ZAngleVariance = copyObject.ZAngleVariance;
			Unknown2 = (Byte[])copyObject.Unknown2.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Object.ReadBinary(reader);
				ParentIndex = reader.ReadUInt16();
				Unused = reader.ReadBytes(2);
				Density = reader.ReadSingle();
				Clustering = reader.ReadByte();
				MinSlope = reader.ReadByte();
				MaxSlope = reader.ReadByte();
				Flags = reader.ReadEnum<RegionObjectFlags>();
				RadiusWithRespectToParent = reader.ReadUInt16();
				Radius = reader.ReadUInt16();
				Unknown1 = reader.ReadBytes(4);
				MaxHeight = reader.ReadSingle();
				Sink = reader.ReadSingle();
				SinkVariance = reader.ReadSingle();
				SizeVariance = reader.ReadSingle();
				XAngleVariance = reader.ReadUInt16();
				YAngleVariance = reader.ReadUInt16();
				ZAngleVariance = reader.ReadUInt16();
				Unknown2 = reader.ReadBytes(6);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Object.WriteBinary(writer);
			writer.Write(ParentIndex);			
			if (Unused == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused);
			writer.Write(Density);			
			writer.Write(Clustering);			
			writer.Write(MinSlope);			
			writer.Write(MaxSlope);			
			writer.Write((Byte)Flags);
			writer.Write(RadiusWithRespectToParent);			
			writer.Write(Radius);			
			if (Unknown1 == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unknown1);
			writer.Write(MaxHeight);			
			writer.Write(Sink);			
			writer.Write(SinkVariance);			
			writer.Write(SizeVariance);			
			writer.Write(XAngleVariance);			
			writer.Write(YAngleVariance);			
			writer.Write(ZAngleVariance);			
			if (Unknown2 == null)
				writer.Write(new byte[6]);
			else
				writer.Write(Unknown2);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Object", true, out subEle);
			Object.WriteXML(subEle, master);

			ele.TryPathTo("ParentIndex", true, out subEle);
			subEle.Value = ParentIndex.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("Density", true, out subEle);
			subEle.Value = Density.ToString("G15");

			ele.TryPathTo("Clustering", true, out subEle);
			subEle.Value = Clustering.ToString();

			ele.TryPathTo("Slope/Min", true, out subEle);
			subEle.Value = MinSlope.ToString();

			ele.TryPathTo("Slope/Max", true, out subEle);
			subEle.Value = MaxSlope.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("RadiusWithRespectToParent", true, out subEle);
			subEle.Value = RadiusWithRespectToParent.ToString();

			ele.TryPathTo("Radius", true, out subEle);
			subEle.Value = Radius.ToString();

			ele.TryPathTo("Unknown1", true, out subEle);
			subEle.Value = Unknown1.ToHex();

			ele.TryPathTo("MaxHeight", true, out subEle);
			subEle.Value = MaxHeight.ToString("G15");

			ele.TryPathTo("Sink", true, out subEle);
			subEle.Value = Sink.ToString("G15");

			ele.TryPathTo("SinkVariance", true, out subEle);
			subEle.Value = SinkVariance.ToString("G15");

			ele.TryPathTo("SizeVariance", true, out subEle);
			subEle.Value = SizeVariance.ToString("G15");

			ele.TryPathTo("XAngleVariance", true, out subEle);
			subEle.Value = XAngleVariance.ToString();

			ele.TryPathTo("YAngleVariance", true, out subEle);
			subEle.Value = YAngleVariance.ToString();

			ele.TryPathTo("ZAngleVariance", true, out subEle);
			subEle.Value = ZAngleVariance.ToString();

			ele.TryPathTo("Unknown2", true, out subEle);
			subEle.Value = Unknown2.ToHex();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Object", false, out subEle))
			{
				Object.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("ParentIndex", false, out subEle))
			{
				ParentIndex = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("Density", false, out subEle))
			{
				Density = subEle.ToSingle();
			}

			if (ele.TryPathTo("Clustering", false, out subEle))
			{
				Clustering = subEle.ToByte();
			}

			if (ele.TryPathTo("Slope/Min", false, out subEle))
			{
				MinSlope = subEle.ToByte();
			}

			if (ele.TryPathTo("Slope/Max", false, out subEle))
			{
				MaxSlope = subEle.ToByte();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<RegionObjectFlags>();
			}

			if (ele.TryPathTo("RadiusWithRespectToParent", false, out subEle))
			{
				RadiusWithRespectToParent = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Radius", false, out subEle))
			{
				Radius = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				Unknown1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("MaxHeight", false, out subEle))
			{
				MaxHeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("Sink", false, out subEle))
			{
				Sink = subEle.ToSingle();
			}

			if (ele.TryPathTo("SinkVariance", false, out subEle))
			{
				SinkVariance = subEle.ToSingle();
			}

			if (ele.TryPathTo("SizeVariance", false, out subEle))
			{
				SizeVariance = subEle.ToSingle();
			}

			if (ele.TryPathTo("XAngleVariance", false, out subEle))
			{
				XAngleVariance = subEle.ToUInt16();
			}

			if (ele.TryPathTo("YAngleVariance", false, out subEle))
			{
				YAngleVariance = subEle.ToUInt16();
			}

			if (ele.TryPathTo("ZAngleVariance", false, out subEle))
			{
				ZAngleVariance = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				Unknown2 = subEle.ToBytes();
			}
		}

		public RegionObject Clone()
		{
			return new RegionObject(this);
		}
	}
}
