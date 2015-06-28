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
    public class WeatherList : Subrecord, IReferenceContainer, ICloneable<WeatherList>
    {
        List<WeatherChance> Weathers { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Weathers = new List<WeatherChance>();

            for (int i = 0; i < size / 12; i++)
            {
                var weather = new WeatherChance();
                weather.ReadBinary(reader);
                Weathers.Add(weather);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var weather in Weathers)
                writer.Write(weather);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var weather in Weathers)
            {
                XElement subEle = new XElement("Weather");
                weather.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Weathers = new List<WeatherChance>();

            foreach (var subEle in ele.Elements("Weather"))
            {
                var weather = new WeatherChance();
                weather.ReadXML(subEle, master);
                Weathers.Add(weather);
            }
        }

        WeatherList ICloneable<WeatherList>.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
