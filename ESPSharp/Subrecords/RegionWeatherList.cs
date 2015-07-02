using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ESPSharp.DataTypes;
using ESPSharp.Interfaces;

namespace ESPSharp.Subrecords
{
    public class RegionWeatherList : Subrecord, IReferenceContainer, ICloneable<RegionWeatherList>
    {
        List<WeatherChance> Weathers { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Weathers = new List<WeatherChance>();

            for (int i = 0; i < size / 12; i++)
            {
                WeatherChance temp = new WeatherChance();
                temp.ReadBinary(reader);
                Weathers.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Weathers)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Weathers)
            {
                XElement subEle = new XElement("Weather");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Weathers = new List<WeatherChance>();

            foreach (var subEle in ele.Elements("Weather"))
            {
                WeatherChance temp = new WeatherChance();
                temp.ReadXML(subEle, master);
                Weathers.Add(temp);
            }
        }

        public RegionWeatherList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
