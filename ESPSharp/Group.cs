using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public abstract class Group : IESPSerializable
    {
        public char[] Tag { get; protected set; }
        public uint Size { get; protected set; }
        public ushort DateStamp { get; protected set; }
        public byte[] Unknown { get; protected set; }

        public abstract void WriteXML(string destinationFolder);

        public abstract void ReadXML(string sourceFile);

        public abstract void WriteBinary(BinaryWriter writer);

        public abstract void ReadBinary(BinaryReader reader);

        public static Group CreateGroup(GroupType type)
        {
            Group outGroup;

            switch (type)
            {
                case GroupType.TopGroup:
                    outGroup = new TopGroup();
                    break;
                case GroupType.WorldGroup:
                    outGroup = new WorldGroup();
                    break;
                case GroupType.InteriorCellBlock:
                    outGroup = new InteriorCellBlock();
                    break;
                case GroupType.InteriorCellSubBlock:
                    outGroup = new InteriorCellSubBlock();
                    break;
                case GroupType.ExteriorCellBlock:
                    outGroup = new ExteriorCellBlock();
                    break;
                case GroupType.ExteriorCellSubBlock:
                    outGroup = new ExteriorCellSubBlock();
                    break;
                case GroupType.CellGroup:
                    outGroup = new CellGroup();
                    break;
                case GroupType.TopicGroup:
                    outGroup = new TopicGroup();
                    break;
                case GroupType.CellPersistentChildren:
                    outGroup = new CellPersistentChildren();
                    break;
                case GroupType.CellTemporaryChildren:
                    outGroup = new CellTemporaryChildren();
                    break;
                case GroupType.CellVisibleDistantChildren:
                    outGroup = new CellVisibleDistantChildren();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(type + " is unknown type of group");
            }

            return outGroup;
        }

        public static Group CreateGroup(BinaryReader reader)
        {
            reader.BaseStream.Seek(12, SeekOrigin.Current);

            Group outGroup = Group.CreateGroup((GroupType)reader.ReadUInt32());

            reader.BaseStream.Seek(-16, SeekOrigin.Current);

            return outGroup;
        }

        public static Group CreateGroup(XDocument doc)
        {
            throw new NotImplementedException();
        }
    }
}
