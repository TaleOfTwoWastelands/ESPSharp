using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class WorldGroup : Group
    {
        public FormID Worldspace { get; protected set; }

        public WorldGroup()
        {
            type = GroupType.WorldGroup;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(Worldspace);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            Worldspace = reader.ReadUInt32();
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Worldspace", Worldspace.ToString());
        }

        public override void ReadTypeDataXML(XElement element)
        {
            Worldspace = element.Element("Worldspace").ToUInt32();
        }

        public override string ToString()
        {
            return Worldspace.ToString();
        }
    }
}
