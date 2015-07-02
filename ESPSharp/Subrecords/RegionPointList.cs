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
    public class RegionPointList : Subrecord, IReferenceContainer, ICloneable<RegionPointList>
    {
        List<XYFloat> Points { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Points = new List<XYFloat>();

            for (int i = 0; i < size / 8; i++)
            {
                XYFloat temp = new XYFloat();
                temp.ReadBinary(reader);
                Points.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Points)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Points)
            {
                XElement subEle = new XElement("Point");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Points = new List<XYFloat>();

            foreach (var subEle in ele.Elements("Point"))
            {
                XYFloat temp = new XYFloat();
                temp.ReadXML(subEle, master);
                Points.Add(temp);
            }
        }

        public RegionPointList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
