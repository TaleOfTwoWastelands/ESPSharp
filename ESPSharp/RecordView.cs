using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public class RecordView
    {
        protected ElderScrollsPlugin master;
        public DataSource Source { get; protected set; }
        public string Tag { get; protected set; }
        public RecordFlag Flags { get; set; }
        public FormID FormID { get; set; }
        public uint VersionControlInfo1 { get; set; }
        public ushort FormVersion { get; protected set; }
        public ushort VersionControlInfo2 { get; set; }

        //only for XML source
        public string FilePath { get; protected set; }

        //only for binary source
        protected MemoryMappedFile file;
        public long Offset { get; protected set; }
        public long Size { get; protected set; }

        //only for memory source
        protected Record record;

        public Record Record
        {
            get
            {
                Record outRecord;

                switch (Source)
                {
                    case DataSource.XML:
                        XDocument doc = XDocument.Load(FilePath);
                        outRecord = Record.ReadXML(FilePath, master);
                        break;
                    case DataSource.Binary:

                        using (MemoryMappedViewStream stream = file.CreateViewStream(Offset, Size, MemoryMappedFileAccess.Read))
                        using (ESPReader reader = new ESPReader(stream))
                        {
                            outRecord = Record.CreateRecord(reader);
                            outRecord.ReadBinary(reader);
                        }
                        break;
                    case DataSource.Memory:
                        outRecord = record;
                        break;
                    default:
                        throw new NotImplementedException(Source.ToString());
                }

                return outRecord;
            }
        }

        private RecordView()
        {

        }

        public RecordView(Record record)
        {
            Source = DataSource.Memory;
            this.record = record;
        }

        public RecordView(string XMLFilePath)
        {
            Source = DataSource.XML;
            FilePath = XMLFilePath;

            XDocument doc = XDocument.Load(XMLFilePath);
            FormID = new FormID();
            FormID.ReadXML((doc.Root as XElement).Element("FormID"), master);
        }

        public RecordView(MemoryMappedFile file, long offset, long size)
        {
            Source = DataSource.Binary;
            this.file = file;
            Offset = offset;
            Size = size;
        }

        public RecordView(ESPReader reader, MemoryMappedFile file)
        {
            Source = DataSource.Binary;
            this.file = file;

            Offset = reader.BaseStream.Position;

            Tag = reader.ReadTag();
            Size = reader.ReadUInt32() + 24;
            Flags = (RecordFlag)reader.ReadUInt32();
            FormID = reader.Read<FormID>();
            VersionControlInfo1 = reader.ReadUInt32();
            FormVersion = reader.ReadUInt16();
            VersionControlInfo2 = reader.ReadUInt16();

            reader.BaseStream.Seek(Offset + Size, SeekOrigin.Begin);
        }

        public static RecordView LoadFromBinary(BinaryReader reader, MemoryMappedFile mmf = null)
        {
            RecordView newView = new RecordView();

            newView.Source = (DataSource)reader.ReadByte();
            newView.FormID = new FormID(reader.ReadUInt32());

            switch (newView.Source)
            {
                case DataSource.XML:
                    newView.FilePath = reader.ReadString();
                    break;
                case DataSource.Binary:
                    newView.file = mmf;
                    newView.Offset = reader.ReadInt64();
                    newView.Size = reader.ReadInt64();
                    break;
                default:
                    throw new NotImplementedException(newView.Source.ToString());
            }

            return newView;
        }

        public void WriteToBinary(BinaryWriter writer)
        {
            writer.Write((byte)Source);
            writer.Write((uint)FormID);

            switch (Source)
            {
                case DataSource.XML:
                    writer.Write(FilePath);
                    break;
                case DataSource.Binary:
                    writer.Write(Offset);
                    writer.Write(Size);
                    break;
                default:
                    throw new NotImplementedException(Source.ToString());
            }
        }

        public override int GetHashCode()
        {
            return (int)(uint)FormID;
        }
    }
}
