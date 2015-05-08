using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class InteriorCellBlock : Group
    {
        public int Index { get; protected set; }

        public InteriorCellBlock()
        {
            type = GroupType.InteriorCellBlock;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(Index);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            Index = reader.ReadInt32();
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
            return "Block " + Index;
        }
    }
}
