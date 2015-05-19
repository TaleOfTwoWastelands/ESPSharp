using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class InteriorCellBlock : Group
    {
        public int Index { get; protected set; }

        public InteriorCellBlock()
        {
            type = GroupType.InteriorCellBlock;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(Index);
        }

        public override void ReadTypeData(ESPReader reader)
        {
            Index = reader.ReadInt32();
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Index", Index);
        }

        public override void ReadTypeDataXML(XElement element)
        {
            Index = element.Element("Index").ToInt16();
        }

        public override string ToString()
        {
            return "Block " + Index;
        }
    }
}
