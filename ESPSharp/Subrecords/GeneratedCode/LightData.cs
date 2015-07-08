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
	public partial class LightData : Subrecord, ICloneable<LightData>
	{
		public Int32 Time { get; set; }
		public UInt32 Radius { get; set; }
		public Color Color { get; set; }
		public LightFlags Flags { get; set; }
		public Single FalloffExponent { get; set; }
		public Single FOV { get; set; }
		public UInt32 Value { get; set; }
		public Single Weight { get; set; }

		public LightData()
		{
			Time = new Int32();
			Radius = new UInt32();
			Color = new Color();
			Flags = new LightFlags();
			FalloffExponent = new Single();
			FOV = new Single();
			Value = new UInt32();
			Weight = new Single();
		}

		public LightData(Int32 Time, UInt32 Radius, Color Color, LightFlags Flags, Single FalloffExponent, Single FOV, UInt32 Value, Single Weight)
		{
			this.Time = Time;
			this.Radius = Radius;
			this.Color = Color;
			this.Flags = Flags;
			this.FalloffExponent = FalloffExponent;
			this.FOV = FOV;
			this.Value = Value;
			this.Weight = Weight;
		}

		public LightData(LightData copyObject)
		{
			Time = copyObject.Time;
			Radius = copyObject.Radius;
			Color = copyObject.Color.Clone();
			Flags = copyObject.Flags;
			FalloffExponent = copyObject.FalloffExponent;
			FOV = copyObject.FOV;
			Value = copyObject.Value;
			Weight = copyObject.Weight;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Time = subReader.ReadInt32();
					Radius = subReader.ReadUInt32();
					Color.ReadBinary(subReader);
					Flags = subReader.ReadEnum<LightFlags>();
					FalloffExponent = subReader.ReadSingle();
					FOV = subReader.ReadSingle();
					Value = subReader.ReadUInt32();
					Weight = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Time);			
			writer.Write(Radius);			
			Color.WriteBinary(writer);
			writer.Write((UInt32)Flags);
			writer.Write(FalloffExponent);			
			writer.Write(FOV);			
			writer.Write(Value);			
			writer.Write(Weight);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Time", true, out subEle);
			subEle.Value = Time.ToString();

			ele.TryPathTo("Radius", true, out subEle);
			subEle.Value = Radius.ToString();

			ele.TryPathTo("Color", true, out subEle);
			Color.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("FalloffExponent", true, out subEle);
			subEle.Value = FalloffExponent.ToString("G15");

			ele.TryPathTo("FOV", true, out subEle);
			subEle.Value = FOV.ToString("G15");

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Time", false, out subEle))
			{
				Time = subEle.ToInt32();
			}

			if (ele.TryPathTo("Radius", false, out subEle))
			{
				Radius = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Color", false, out subEle))
			{
				Color.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<LightFlags>();
			}

			if (ele.TryPathTo("FalloffExponent", false, out subEle))
			{
				FalloffExponent = subEle.ToSingle();
			}

			if (ele.TryPathTo("FOV", false, out subEle))
			{
				FOV = subEle.ToSingle();
			}

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Weight", false, out subEle))
			{
				Weight = subEle.ToSingle();
			}
		}

		public LightData Clone()
		{
			return new LightData(this);
		}

	}
}
