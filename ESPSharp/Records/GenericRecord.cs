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
        public List<Subrecord> Subrecords = new List<Subrecord>();

        public override void ReadData(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            using (BinaryReader reader = new BinaryReader(stream, Encoding.GetEncoding("ISO-8859-1")))
            {
                while (stream.Position < stream.Length)
                {
                    Subrecord sub = new Subrecord();
                    sub.ReadBinary(reader);
                    Subrecords.Add(sub);
                }
            }
        }

        public override byte[] WriteData()
        {
            byte[] outBytes;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.GetEncoding("ISO-8859-1")))
            {
                foreach (Subrecord sub in Subrecords)
                    sub.WriteBinary(writer);

                outBytes = stream.ToArray();
            }

            return outBytes;
        }

        public override void WriteDataXML(XElement ele)
        {
            XElement subRecRoot = new XElement("Subrecords");
            ele.Add(subRecRoot);

            foreach (Subrecord sub in Subrecords)
                sub.WriteXML(subRecRoot);
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach(XElement subEle in ele.Element("Subrecords").Elements())
            {
                Subrecord sub = new Subrecord();
                sub.ReadXML(subEle);
                Subrecords.Add(sub);
            }
        }
    }
}
