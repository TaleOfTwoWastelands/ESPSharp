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
	public partial class EnvironmentalColors : Subrecord, ICloneable<EnvironmentalColors>
	{
		public TimeOfDayColors SkyUpper { get; set; }
		public TimeOfDayColors Fog { get; set; }
		public TimeOfDayColors Unused1 { get; set; }
		public TimeOfDayColors Ambient { get; set; }
		public TimeOfDayColors Sunlight { get; set; }
		public TimeOfDayColors Sun { get; set; }
		public TimeOfDayColors Stars { get; set; }
		public TimeOfDayColors SkyLower { get; set; }
		public TimeOfDayColors Horizon { get; set; }
		public TimeOfDayColors Unused2 { get; set; }

		public EnvironmentalColors()
		{
			SkyUpper = new TimeOfDayColors();
			Fog = new TimeOfDayColors();
			Unused1 = new TimeOfDayColors();
			Ambient = new TimeOfDayColors();
			Sunlight = new TimeOfDayColors();
			Sun = new TimeOfDayColors();
			Stars = new TimeOfDayColors();
			SkyLower = new TimeOfDayColors();
			Horizon = new TimeOfDayColors();
			Unused2 = new TimeOfDayColors();
		}

		public EnvironmentalColors(TimeOfDayColors SkyUpper, TimeOfDayColors Fog, TimeOfDayColors Unused1, TimeOfDayColors Ambient, TimeOfDayColors Sunlight, TimeOfDayColors Sun, TimeOfDayColors Stars, TimeOfDayColors SkyLower, TimeOfDayColors Horizon, TimeOfDayColors Unused2)
		{
			this.SkyUpper = SkyUpper;
			this.Fog = Fog;
			this.Unused1 = Unused1;
			this.Ambient = Ambient;
			this.Sunlight = Sunlight;
			this.Sun = Sun;
			this.Stars = Stars;
			this.SkyLower = SkyLower;
			this.Horizon = Horizon;
			this.Unused2 = Unused2;
		}

		public EnvironmentalColors(EnvironmentalColors copyObject)
		{
			SkyUpper = copyObject.SkyUpper.Clone();
			Fog = copyObject.Fog.Clone();
			Unused1 = copyObject.Unused1.Clone();
			Ambient = copyObject.Ambient.Clone();
			Sunlight = copyObject.Sunlight.Clone();
			Sun = copyObject.Sun.Clone();
			Stars = copyObject.Stars.Clone();
			SkyLower = copyObject.SkyLower.Clone();
			Horizon = copyObject.Horizon.Clone();
			Unused2 = copyObject.Unused2.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					SkyUpper.ReadBinary(subReader);
					Fog.ReadBinary(subReader);
					Unused1.ReadBinary(subReader);
					Ambient.ReadBinary(subReader);
					Sunlight.ReadBinary(subReader);
					Sun.ReadBinary(subReader);
					Stars.ReadBinary(subReader);
					SkyLower.ReadBinary(subReader);
					Horizon.ReadBinary(subReader);
					Unused2.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			SkyUpper.WriteBinary(writer);
			Fog.WriteBinary(writer);
			Unused1.WriteBinary(writer);
			Ambient.WriteBinary(writer);
			Sunlight.WriteBinary(writer);
			Sun.WriteBinary(writer);
			Stars.WriteBinary(writer);
			SkyLower.WriteBinary(writer);
			Horizon.WriteBinary(writer);
			Unused2.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Sky/Upper", true, out subEle);
			SkyUpper.WriteXML(subEle, master);

			ele.TryPathTo("Fog", true, out subEle);
			Fog.WriteXML(subEle, master);

			ele.TryPathTo("Unused1", true, out subEle);
			Unused1.WriteXML(subEle, master);

			ele.TryPathTo("Ambient", true, out subEle);
			Ambient.WriteXML(subEle, master);

			ele.TryPathTo("Sunlight", true, out subEle);
			Sunlight.WriteXML(subEle, master);

			ele.TryPathTo("Sun", true, out subEle);
			Sun.WriteXML(subEle, master);

			ele.TryPathTo("Stars", true, out subEle);
			Stars.WriteXML(subEle, master);

			ele.TryPathTo("Sky/Lower", true, out subEle);
			SkyLower.WriteXML(subEle, master);

			ele.TryPathTo("Horizon", true, out subEle);
			Horizon.WriteXML(subEle, master);

			ele.TryPathTo("Unused2", true, out subEle);
			Unused2.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Sky/Upper", false, out subEle))
			{
				SkyUpper.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Fog", false, out subEle))
			{
				Fog.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Ambient", false, out subEle))
			{
				Ambient.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Sunlight", false, out subEle))
			{
				Sunlight.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Sun", false, out subEle))
			{
				Sun.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Stars", false, out subEle))
			{
				Stars.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Sky/Lower", false, out subEle))
			{
				SkyLower.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Horizon", false, out subEle))
			{
				Horizon.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2.ReadXML(subEle, master);
			}
		}

		public EnvironmentalColors Clone()
		{
			return new EnvironmentalColors(this);
		}

	}
}
