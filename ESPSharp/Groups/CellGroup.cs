using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    class CellGroup : Group, ISubgroup
    {
        public FormID Cell { get; protected set; }

        public CellGroup()
        {
            type = GroupType.CellGroup;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(Cell);
        }

        public override void ReadTypeData(ESPReader reader)
        {
            Cell = reader.Read<FormID>();
        }

        public override XElement WriteTypeDataXML(ElderScrollsPlugin master)
        {
            XElement ele = new XElement("Cell");
            Cell.WriteXML(ele, master);
            return ele;
        }

        public override void ReadTypeDataXML(XElement element, ElderScrollsPlugin master)
        {
            Cell = new FormID();
            Cell.ReadXML(element.Element("Cell"), master);
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
