using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class TopGroup : Group
    {
        public char[] RecordType { get; protected set; }

        public TopGroup()
        {
            type = GroupType.TopGroup;
        }

        public override void WriteTypeData(BinaryWriter writer)
        {
            writer.Write(RecordType);
        }

        public override void ReadTypeData(BinaryReader reader)
        {
            RecordType = reader.ReadChars(4);
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
            return new String(RecordType);
        }
    }
}
