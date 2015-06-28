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
	public partial class WeatherSound : Subrecord, ICloneable<WeatherSound>, IReferenceContainer
	{
		public FormID Sound { get; set; }
		public WeatherType Type { get; set; }

		public WeatherSound()
		{
			Sound = new FormID();
			Type = new WeatherType();
		}

		public WeatherSound(FormID Sound, WeatherType Type)
		{
			this.Sound = Sound;
			this.Type = Type;
		}

		public WeatherSound(WeatherSound copyObject)
		{
			Sound = copyObject.Sound.Clone();
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
					Type = subReader.ReadEnum<WeatherType>();
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
			writer.Write((UInt32)Type);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Sound", false, out subEle))
			{
				Sound.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<WeatherType>();
			}
		}

		public WeatherSound Clone()
		{
			return new WeatherSound(this);
		}

	}
}
