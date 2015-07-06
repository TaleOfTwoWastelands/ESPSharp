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
    public class IMADTimeColors : Subrecord, IReferenceContainer, ICloneable<IMADTimeColors>
    {
        List<IMADTimeColor> Values { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Values = new List<IMADTimeColor>();

            for (int i = 0; i < size / 20; i++)
            {
                IMADTimeColor temp = new IMADTimeColor();
                temp.ReadBinary(reader);
                Values.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Values)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Values)
            {
                XElement subEle = new XElement("Value");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Values = new List<IMADTimeColor>();

            foreach (var subEle in ele.Elements("Value"))
            {
                IMADTimeColor temp = new IMADTimeColor();
                temp.ReadXML(subEle, master);
                Values.Add(temp);
            }
        }

        public IMADTimeColors Clone()
        {
            throw new NotImplementedException();
        }
    }
}
