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

        public override void WriteTypeDataXML(XElement element)
        {
            throw new NotImplementedException();
        }

        public override void ReadTypeDataXML(XElement element)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Worldspace.ToString();
        }
    }
}
