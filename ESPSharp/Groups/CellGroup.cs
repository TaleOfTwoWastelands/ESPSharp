using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class CellGroup : Group
    {
        public FormID Cell { get; protected set; }

        public CellGroup()
        {
            type = GroupType.CellGroup;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(Cell);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            Cell = reader.ReadUInt32();
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
            return (Cell.ToString());
        }
    }
}
