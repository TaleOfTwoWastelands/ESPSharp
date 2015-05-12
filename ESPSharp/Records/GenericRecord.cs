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
        public List<UndecodedSubrecord> Subrecords = new List<UndecodedSubrecord>();

        public override void ReadData(BinaryReader reader, long dataEnd)
        {
            while (reader.BaseStream.Position < dataEnd)
            {
                UndecodedSubrecord sub = new UndecodedSubrecord();
                sub.ReadBinary(reader);
                Subrecords.Add(sub);
            }
        }

        public override void WriteData(BinaryWriter writer)
        {
            foreach (Subrecord sub in Subrecords)
                sub.WriteBinary(writer);
        }

        public override void WriteDataXML(XElement ele)
        {
            XElement subRecRoot = new XElement("Subrecords");
            ele.Add(subRecRoot);

            foreach (UndecodedSubrecord sub in Subrecords)
                sub.WriteXML(subRecRoot);
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach(XElement subEle in ele.Element("Subrecords").Elements())
            {
                UndecodedSubrecord sub = new UndecodedSubrecord();
                sub.ReadXML(subEle);
                Subrecords.Add(sub);
            }
        }
    }
}
