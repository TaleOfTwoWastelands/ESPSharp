using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public abstract class Group
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
            XDocument header = new XDocument();
            XElement root = new XElement("GroupInfo");
            header.Add(root);

            root.Add(
                new XElement("Type", type.ToString()),
                WriteTypeDataXML(),
                new XElement("DateStamp", DateStamp),
                new XElement("Unknown", Unknown.ToBase64())
                );

            header.Save(Path.Combine(destinationFolder, "GroupHeader.metadata"));

            foreach (var group in Subgroups)
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir);
            }

            foreach (var record in Records)
                record.WriteXML(Path.Combine(destinationFolder, record.ToString() + ".xml"));
        }

        public static Group ReadXML(string sourceFolder)
        {
            XDocument doc = XDocument.Load(Path.Combine(sourceFolder, "GroupHeader.metadata"));
            XElement headerRoot = (XElement)doc.FirstNode;
            Group outGroup = Group.CreateGroup(headerRoot.Element("Type").ToEnum<GroupType>());

            outGroup.Tag = "GRUP";
            outGroup.ReadTypeDataXML(headerRoot);
            outGroup.DateStamp = headerRoot.Element("DateStamp").ToUInt16();
            outGroup.Unknown = headerRoot.Element("Unknown").ToBytes();

            foreach (var folder in Directory.EnumerateDirectories(sourceFolder, "*.*", SearchOption.TopDirectoryOnly))
                outGroup.Subgroups.Add(Group.ReadXML(folder));

            foreach (var file in Directory.EnumerateFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly).Where(f => Path.GetFileName(f) != "GroupHeader.metadata"))
                outGroup.Records.Add(Record.ReadXML(file));

            return outGroup;
        }

        public void WriteBinary(BinaryWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());

            long sizePoint = writer.BaseStream.Position;
            writer.Write((uint)0);
            WriteTypeData(writer);
            writer.Write((uint)type);
            writer.Write(DateStamp);
            writer.Write(Unknown);

            long dataStart = writer.BaseStream.Position;

            List<Group> groups = new List<Group>(Subgroups);

            foreach (var record in Records)
            {
                record.WriteBinary(writer);
                Group recordGroup = groups.FirstOrDefault(g => g is ISubgroup && (g as ISubgroup).GetRecordID() == record.FormID);

                if (recordGroup != null)
                {
                    groups.Remove(recordGroup);
                    recordGroup.WriteBinary(writer);
                }
            }

            foreach (var group in groups)
                group.WriteBinary(writer);

            long dataEnd = writer.BaseStream.Position;

            writer.BaseStream.Seek(sizePoint, SeekOrigin.Begin);
            writer.Write((uint)(dataEnd - dataStart + 24));
            writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
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
        public abstract XElement WriteTypeDataXML();
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

            outGroup.type = type;
            return outGroup;
        }

        public static Group CreateGroup(BinaryReader reader)
        {
            reader.BaseStream.Seek(12, SeekOrigin.Current);

            Group outGroup = Group.CreateGroup((GroupType)reader.ReadUInt32());

            reader.BaseStream.Seek(-16, SeekOrigin.Current);

            return outGroup;
        }

        public override abstract string ToString();
    }
}
