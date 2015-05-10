using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public abstract class Group : IESPSerializable
    {
        public string Tag { get; protected set; }
        public uint Size { get; protected set; }
        public ushort DateStamp { get; protected set; }
        public byte[] Unknown { get; protected set; }

        public List<Record> Records = new List<Record>();
        public List<Group> Subgroups = new List<Group>();

        protected GroupType type;

        public void WriteXML(string destinationFolder)
        {
            throw new NotImplementedException();
        }

        public void ReadXML(string sourceFile)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(BinaryWriter writer)
        {
            byte[] writeBytes;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter subWriter = new BinaryWriter(stream))
            {
                foreach (var group in Subgroups)
                    group.WriteBinary(subWriter);

                foreach (var record in Records)
                    record.WriteBinary(subWriter);

                writeBytes = stream.ToArray();
            }

            writer.Write(Tag.ToCharArray());
            writer.Write(writeBytes.Length + 24);
            WriteTypeData(writer);
            writer.Write((uint)type);
            writer.Write(DateStamp);
            writer.Write(Unknown);
            writer.Write(writeBytes);
        }

        public void ReadBinary(BinaryReader reader)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32() - 24;
            ReadTypeData(reader);
            GroupType thisType = (GroupType)reader.ReadUInt32();
            Debug.Assert(thisType == type);
            DateStamp = reader.ReadUInt16();
            Unknown = reader.ReadBytes(6);

            long offset = reader.BaseStream.Position;
            while (reader.BaseStream.Position < offset + Size)
            {
                if (reader.PeekTag() == "GRUP")
                {
                    Group newGroup = Group.CreateGroup(reader);
                    newGroup.ReadBinary(reader);
                    Subgroups.Add(newGroup);
                }
                else
                {
                    Record newRecord = Record.CreateRecord(reader);
                    newRecord.ReadBinary(reader);
                    Records.Add(newRecord);
                }
            }
        }

        public abstract void WriteTypeData(BinaryWriter writer);
        public abstract void ReadTypeData(BinaryReader reader);
        public abstract void WriteTypeDataXML(XElement element);
        public abstract void ReadTypeDataXML(XElement element);

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

        public override abstract string ToString();
    }
}
