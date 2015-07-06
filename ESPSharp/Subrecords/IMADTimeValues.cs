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
    public class IMADTimeValues : Subrecord, IReferenceContainer, ICloneable<IMADTimeValues>
    {
        List<IMADTimeValue> Values { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Values = new List<IMADTimeValue>();

            for (int i = 0; i < size / 8; i++)
            {
                IMADTimeValue temp = new IMADTimeValue();
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
            Values = new List<IMADTimeValue>();

            foreach (var subEle in ele.Elements("Value"))
            {
                IMADTimeValue temp = new IMADTimeValue();
                temp.ReadXML(subEle, master);
                Values.Add(temp);
            }
        }

        public IMADTimeValues Clone()
        {
            throw new NotImplementedException();
        }
    }
}
