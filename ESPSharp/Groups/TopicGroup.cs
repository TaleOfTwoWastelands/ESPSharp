using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class TopicGroup : Group
    {
        public FormID Topic { get; protected set; }

        public TopicGroup()
        {
            type = GroupType.TopicGroup;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(Topic);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            Topic = reader.ReadUInt32();
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
            return Topic.ToString();
        }
    }
}
