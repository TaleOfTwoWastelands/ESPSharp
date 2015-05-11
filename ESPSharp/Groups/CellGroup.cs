using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class CellGroup : Group, ISubgroup
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

        public override XElement WriteTypeDataXML()
        {
            return new XElement("Cell", Cell.ToString());
        }

        public override void ReadTypeDataXML(XElement element)
        {
            Cell = element.Element("Cell").ToFormID();
        }

        public override string ToString()
        {
            return (Cell.ToString());
        }

        public FormID GetRecordID()
        {
            return Cell;
        }
    }
}
