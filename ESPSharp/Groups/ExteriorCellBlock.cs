using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class ExteriorCellBlock : Group
    {
        public short CoordX { get; protected set; }
        public short CoordY { get; protected set; }

        public ExteriorCellBlock()
        {
            type = GroupType.ExteriorCellBlock;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(CoordY);
            writer.Write(CoordX);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            CoordY = reader.ReadInt16();
            CoordX = reader.ReadInt16();
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Block",
                new XElement("X", CoordX),
                new XElement("Y", CoordY));
        }

        public override void ReadTypeDataXML(XElement element)
        {
            CoordX = element.Element("Block").Element("X").ToInt16();
            CoordY = element.Element("Block").Element("Y").ToInt16();
        }

        public override string ToString()
        {
            return string.Format("Block {0}, {1}", CoordX, CoordY);
        }
    }
}
