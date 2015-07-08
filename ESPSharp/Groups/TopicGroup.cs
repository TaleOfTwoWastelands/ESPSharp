using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    class TopicGroup : Group, ISubgroup
    {
        public FormID Topic { get; protected set; }

        public TopicGroup()
        {
            type = GroupType.TopicGroup;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(Topic);
        }

        public override void ReadTypeData(ESPReader reader)
        {
            Topic = reader.Read<FormID>();
        }

        public override XElement WriteTypeDataXML(ElderScrollsPlugin master)
        {
            XElement ele = new XElement("Topic");
            Topic.WriteXML(ele, master);
            return ele;
        }

        public override void ReadTypeDataXML(XElement element, ElderScrollsPlugin master)
        {
            Topic = new FormID();
            Topic.ReadXML(element.Element("Topic"), master);
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
