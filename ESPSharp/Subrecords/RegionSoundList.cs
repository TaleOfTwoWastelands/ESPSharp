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
    public class RegionSoundList : Subrecord, IReferenceContainer, ICloneable<RegionSoundList>
    {
        List<RegionSound> Sounds { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Sounds = new List<RegionSound>();

            for (int i = 0; i < size / 12; i++)
            {
                RegionSound temp = new RegionSound();
                temp.ReadBinary(reader);
                Sounds.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Sounds)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Sounds)
            {
                XElement subEle = new XElement("Sound");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Sounds = new List<RegionSound>();

            foreach (var subEle in ele.Elements("Sound"))
            {
                RegionSound temp = new RegionSound();
                temp.ReadXML(subEle, master);
                Sounds.Add(temp);
            }
        }

        public RegionSoundList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
