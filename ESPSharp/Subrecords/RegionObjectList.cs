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
    public class RegionObjectList : Subrecord, IReferenceContainer, ICloneable<RegionObjectList>
    {
        List<RegionObject> Objects { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Objects = new List<RegionObject>();

            for (int i = 0; i < size / 52; i++)
            {
                RegionObject temp = new RegionObject();
                temp.ReadBinary(reader);
                Objects.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Objects)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Objects)
            {
                XElement subEle = new XElement("Object");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Objects = new List<RegionObject>();

            foreach (var subEle in ele.Elements("Object"))
            {
                RegionObject temp = new RegionObject();
                temp.ReadXML(subEle, master);
                Objects.Add(temp);
            }
        }

        public RegionObjectList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
