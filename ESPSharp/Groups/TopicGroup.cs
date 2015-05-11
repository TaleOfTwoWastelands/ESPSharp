using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class TopicGroup : Group, ISubgroup
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

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Topic", Topic.ToString());
        }

        public override void ReadTypeDataXML(XElement element)
        {
            Topic = element.Element("Topic").ToFormID();
        }

        public override string ToString()
        {
            return Topic.ToString();
        }

        public FormID GetRecordID()
        {
            return Topic;
        }
    }
}
