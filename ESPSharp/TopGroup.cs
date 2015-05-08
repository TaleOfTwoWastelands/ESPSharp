using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ESPSharp
{
    class TopGroup : Group
    {
        private GroupType type = GroupType.TopGroup;
        public char[] RecordType { get; protected set; }
        public List<Record> Records = new List<Record>();
        public List<Group> Subgroups = new List<Group>();

        public override void WriteXML(string destinationFolder)
        {
            throw new NotImplementedException();
        }

        public override void ReadXML(string sourceFile)
        {
            throw new NotImplementedException();
        }

        public override void WriteBinary(BinaryWriter writer)
        {
            byte[] writeBytes;

            //calculate writeBytes

            writer.Write(Tag);
            writer.Write(writeBytes.Length + 24);
            writer.Write(RecordType);
            writer.Write((uint)type);
            writer.Write(DateStamp);
            writer.Write(Unknown);
            writer.Write(writeBytes);
        }

        public override void ReadBinary(BinaryReader reader)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32() - 24;
            RecordType = reader.ReadChars(4);
            Debug.Assert((GroupType)reader.ReadUInt32() == type);
            DateStamp = reader.ReadUInt16();
            Unknown = reader.ReadBytes(6);

            while (reader.PeekTag().ToString() == "GRUP")
            {

            }
        }
    }
}
