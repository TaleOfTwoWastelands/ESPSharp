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
	public partial class WeatherChance : IESPSerializable, ICloneable<WeatherChance>, IReferenceContainer
	{
		public FormID Weather { get; set; }
		public Int32 Chance { get; set; }
		public FormID Global { get; set; }

		public WeatherChance()
		{
			Weather = new FormID();
			Chance = new Int32();
			Global = new FormID();
		}

		public WeatherChance(FormID Weather, Int32 Chance, FormID Global)
		{
			this.Weather = Weather;
			this.Chance = Chance;
			this.Global = Global;
		}

		public WeatherChance(WeatherChance copyObject)
		{
			Weather = copyObject.Weather.Clone();
			Chance = copyObject.Chance;
			Global = copyObject.Global.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Weather.ReadBinary(reader);
				Chance = reader.ReadInt32();
				Global.ReadBinary(reader);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Weather.WriteBinary(writer);
			writer.Write(Chance);			
			Global.WriteBinary(writer);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Weather", true, out subEle);
			Weather.WriteXML(subEle, master);

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();

			ele.TryPathTo("Global", true, out subEle);
			Global.WriteXML(subEle, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Weather", false, out subEle))
			{
				Weather.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Chance", false, out subEle))
			{
				Chance = subEle.ToInt32();
			}

			if (ele.TryPathTo("Global", false, out subEle))
			{
				Global.ReadXML(subEle, master);
			}
		}

		public WeatherChance Clone()
		{
			return new WeatherChance(this);
		}
	}
}
