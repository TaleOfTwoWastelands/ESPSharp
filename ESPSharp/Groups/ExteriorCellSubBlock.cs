using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class ExteriorCellSubBlock : ExteriorCellBlock
    {
        public ExteriorCellSubBlock()
        {
            type = GroupType.ExteriorCellSubBlock;
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Sub-Block",
                new XElement("X", CoordX),
                new XElement("Y", CoordY));
        }

        public override void ReadTypeDataXML(XElement element)
        {
            CoordX = element.Element("Sub-Block").Element("X").ToInt16();
            CoordY = element.Element("Sub-Block").Element("Y").ToInt16();
        }

        public override string ToString()
        {
            return string.Format("Sub-Block {0}, {1}", CoordX, CoordY);
        }
    }
}
