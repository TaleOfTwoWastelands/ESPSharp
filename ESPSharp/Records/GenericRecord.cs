using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class GenericRecord : Record
    {
        public byte[] Bytes { get; protected set; }

        public override void ReadData(byte[] bytes)
        {
            Bytes = bytes;
        }

        public override byte[] WriteData()
        {
            return Bytes;
        }

        public override void ReadDataXML(XElement ele)
        {
            Bytes = ele.Element("Bytes").ToBytes();
        }

        public override void WriteDataXML(XElement ele)
        {
            ele.Add(new XElement("Bytes", Bytes.ToBase64()));
        }
    }
}
