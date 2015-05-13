using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class TopGroup : Group
    {
        public string RecordType { get; protected set; }

        public TopGroup()
        {
            type = GroupType.TopGroup;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(RecordType.ToCharArray());
        }

        public override void ReadTypeData(ESPReader reader)
        {
            RecordType = reader.ReadTag();
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("RecordType", RecordType);
        }

        public override void ReadTypeDataXML(XElement element)
        {
            RecordType = element.Element("RecordType").Value;
        }

        public override string ToString()
        {
            return RecordType;
        }
    }
}
