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
    public class SpeedtreeSeeds : Subrecord, ICloneable<SpeedtreeSeeds>
    {
        List<uint> Seeds { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Seeds = new List<uint>();

            for (int i = 0; i < size / 4; i++)
                Seeds.Add(reader.ReadUInt32());
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var id in Seeds)
                writer.Write(id);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var seed in Seeds)
            {
                XElement subEle = new XElement("Seed", seed);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Seeds = new List<uint>();

            foreach (var subEle in ele.Elements("Seed"))
            {
                Seeds.Add(subEle.ToUInt32());
            }
        }

        SpeedtreeSeeds ICloneable<SpeedtreeSeeds>.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
