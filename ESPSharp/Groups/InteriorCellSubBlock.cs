using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class InteriorCellSubBlock : InteriorCellBlock
    {
        public InteriorCellSubBlock()
        {
            type = GroupType.InteriorCellSubBlock;
        }

        public override string ToString()
        {
            return "Sub-Block " + Index;
        }

        public override XElement WriteTypeDataXML(ElderScrollsPlugin master)
        {
            return new XElement("Sub-Block", Index);
        }

        public override void ReadTypeDataXML(XElement element, ElderScrollsPlugin master)
        {
            Index = element.Element("Sub-Block").ToInt16();
        }
    }
}
