using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    class WorldGroup : Group, ISubgroup
    {
        public FormID Worldspace { get; protected set; }

        public WorldGroup()
        {
            type = GroupType.WorldGroup;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(Worldspace);
        }

        public override void ReadTypeData(ESPReader reader)
        {
            Worldspace = reader.Read<FormID>();
        }

        public override XElement WriteTypeDataXML(ElderScrollsPlugin master)
        {
            XElement ele = new XElement("Worldspace");
            Worldspace.WriteXML(ele, master);
            return ele;
        }

        public override void ReadTypeDataXML(XElement element, ElderScrollsPlugin master)
        {
            Worldspace = new FormID();
            Worldspace.ReadXML(element.Element("Worldspace"), master);
        }

        public override string ToString()
        {
            return Worldspace.ToString();
        }

        public FormID GetRecordID()
        {
            return Worldspace;
        }
    }
}
