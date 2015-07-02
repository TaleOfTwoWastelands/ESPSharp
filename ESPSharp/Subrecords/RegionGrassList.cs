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
    public class RegionGrassList : Subrecord, IReferenceContainer, ICloneable<RegionGrassList>
    {
        List<RegionGrass> Grasses { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Grasses = new List<RegionGrass>();

            for (int i = 0; i < size / 8; i++)
            {
                RegionGrass temp = new RegionGrass();
                temp.ReadBinary(reader);
                Grasses.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Grasses)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Grasses)
            {
                XElement subEle = new XElement("Grass");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Grasses = new List<RegionGrass>();

            foreach (var subEle in ele.Elements("Grass"))
            {
                RegionGrass temp = new RegionGrass();
                temp.ReadXML(subEle, master);
                Grasses.Add(temp);
            }
        }

        public RegionGrassList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
