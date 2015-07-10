using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Xml.Linq;
using System.Diagnostics;
using ESPSharp.Records;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public abstract class Group
    {
        public string Tag { get; protected set; }
        public uint Size { get; protected set; }
        public DateStamp LastModified { get; protected set; }
        public byte[] Unknown { get; protected set; }

        public HashSet<RecordView> ChildRecordViews = new HashSet<RecordView>();
        public HashSet<RecordView> AllRecordViews = new HashSet<RecordView>();
        public List<Group> Children = new List<Group>();
        public List<Group> AllSubgroups = new List<Group>();

        protected GroupType type;

        public delegate void GroupAddedHandler(Group group);
        public event GroupAddedHandler GroupAdded;

        public delegate void RecordViewAddedHandler(RecordView record);
        public event RecordViewAddedHandler RecordViewAdded;

        public void WriteXML(string destinationFolder, ElderScrollsPlugin master)
        {
            XDocument header = new XDocument();
            XElement root = new XElement("GroupInfo");
            header.Add(root);

            root.Add(
                new XElement("Type", type.ToString()),
                WriteTypeDataXML(master)
                );

            header.Save(Path.Combine(destinationFolder, "GroupHeader.metadata"));

            foreach (var group in Children)
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir, master);
            }

            foreach (var view in ChildRecordViews)
            {
                var record = view.Record;
                record.WriteXML(Path.Combine(destinationFolder, record.ToString() + ".xml"), master);
            }
        }

        public void ReadXML(string sourceFolder, ElderScrollsPlugin master)
        {
            XDocument doc = XDocument.Load(Path.Combine(sourceFolder, "GroupHeader.metadata"));
            XElement headerRoot = (XElement)doc.FirstNode;

            Tag = "GRUP";
            ReadTypeDataXML(headerRoot, master);

            foreach (var folder in Directory.EnumerateDirectories(sourceFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                Group newGroup = Group.CreateGroup(folder);

                if (GroupAdded != null)
                    GroupAdded(newGroup);

                newGroup.GroupAdded += (g) =>
                {
                    AllSubgroups.Add(g);

                    if (GroupAdded != null)
                        GroupAdded(g);
                };

                newGroup.RecordViewAdded += (r) =>
                {
                    AllRecordViews.Add(r);

                    if (RecordViewAdded != null)
                        RecordViewAdded(r);
                };

                Children.Add(newGroup);
                AllSubgroups.Add(newGroup);

                newGroup.ReadXML(folder, master);
            }

            foreach (var file in Directory.EnumerateFiles(sourceFolder, "*.xml", SearchOption.TopDirectoryOnly).Where(f => Path.GetFileName(f) != "GroupHeader.metadata"))
            {
                RecordView newView = new RecordView(file);
                ChildRecordViews.Add(newView);
                AllRecordViews.Add(newView);

                if (RecordViewAdded != null)
                    RecordViewAdded(newView);
            }
        }

        public void WriteBinary(ESPWriter writer, ElderScrollsPlugin master)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());

            long sizePoint = writer.BaseStream.Position;
            writer.Write((uint)0);
            WriteTypeData(writer);
            writer.Write((uint)type);
            DateStamp.Now.WriteBinary(writer);
            writer.Write(new byte[6]);

            long dataStart = writer.BaseStream.Position;

            List<Group> groups = new List<Group>(Children);

            foreach (var view in ChildRecordViews)
            {
                var record = view.Record;
                record.WriteBinary(writer);
                Group recordGroup = groups.FirstOrDefault(g => g is ISubgroup && ((uint)(g as ISubgroup).GetRecordID()) == ((uint)record.FormID));

                if (recordGroup != null)
                {
                    groups.Remove(recordGroup);
                    recordGroup.WriteBinary(writer, master);
                }
            }

            foreach (var group in groups)
                group.WriteBinary(writer, master);

            long dataEnd = writer.BaseStream.Position;

            writer.BaseStream.Seek(sizePoint, SeekOrigin.Begin);
            writer.Write((uint)(dataEnd - dataStart + 24));
            writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
        }

        public void ReadBinary(ESPReader reader, MemoryMappedFile source)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32() - 24;
            ReadTypeData(reader);
            GroupType thisType = (GroupType)reader.ReadUInt32();
            Debug.Assert(thisType == type);
            LastModified = new DateStamp();
            LastModified.ReadBinary(reader);
            Unknown = reader.ReadBytes(6);

            long offset = reader.BaseStream.Position;
            while (reader.BaseStream.Position < offset + Size)
            {
                if (reader.PeekTag() == "GRUP")
                {
                    Group newGroup = Group.CreateGroup(reader);

                    if (GroupAdded != null)
                        GroupAdded(newGroup);

                    newGroup.GroupAdded += (g) =>
                    {
                        AllSubgroups.Add(g);

                        if (GroupAdded != null)
                            GroupAdded(g);
                    };

                    newGroup.RecordViewAdded += (r) =>
                    {
                        AllRecordViews.Add(r);

                        if (RecordViewAdded != null)
                            RecordViewAdded(r);
                    };

                    Children.Add(newGroup);
                    AllSubgroups.Add(newGroup);

                    newGroup.ReadBinary(reader, source);
                }
                else
                {
                    RecordView newView = new RecordView(reader, source);
                    ChildRecordViews.Add(newView);
                    AllRecordViews.Add(newView);

                    if (RecordViewAdded != null)
                        RecordViewAdded(newView);
                }
            }
        }

        public abstract void WriteTypeData(ESPWriter writer);
        public abstract void ReadTypeData(ESPReader reader);
        public abstract XElement WriteTypeDataXML(ElderScrollsPlugin master);
        public abstract void ReadTypeDataXML(XElement element, ElderScrollsPlugin master);

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

        public static Group CreateGroup(ESPReader reader)
        {
            reader.BaseStream.Seek(12, SeekOrigin.Current);

            Group outGroup = Group.CreateGroup((GroupType)reader.ReadUInt32());

            reader.BaseStream.Seek(-16, SeekOrigin.Current);

            return outGroup;
        }

        public static Group CreateGroup(string sourceFolder)
        {
            XDocument doc = XDocument.Load(Path.Combine(sourceFolder, "GroupHeader.metadata"));
            XElement headerRoot = (XElement)doc.FirstNode;
            Group outGroup = Group.CreateGroup(headerRoot.Element("Type").ToEnum<GroupType>());

            return outGroup;
        }

        public override abstract string ToString();
    }
}
