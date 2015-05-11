using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public abstract class Record : IESPSerializable
    {
        public string Tag { get; protected set; }
        public uint Size { get; protected set; }
        public RecordFlag Flags { get; set; }
        public FormID FormID { get; set; }
        public uint VersionControlInfo1 { get; set; }
        public ushort FormVersion { get; protected set; }
        public ushort VersionControlInfo2 { get; set; }

        protected bool compressionCorrupted = false;
        protected byte[] corruptedBytes;

        public void WriteXML(string destinationfolder)
        {
            XDocument doc = new XDocument();

            XElement root = new XElement("Record", 
                                new XAttribute("Tag", Tag));

            doc.Add(root);

            root.Add(
                new XElement("Flags", Flags),
                new XElement("FormID", FormID),
                new XElement("FormVersion", FormVersion),
                new XElement("VersionControlInfo",
                    new XElement("Info1", VersionControlInfo1),
                    new XElement("Info2", VersionControlInfo2)),
                new XElement("CompressionCorrupted", compressionCorrupted)
                );

            if (compressionCorrupted)
                root.Add(new XElement("CorruptedBytes"), corruptedBytes.ToBase64());
            else
                WriteDataXML(root);

            doc.Save(Path.ChangeExtension(Path.Combine(destinationfolder, this.ToString()), "xml"));
        }

        public void ReadXML(string sourceFile)
        {
            XDocument doc = XDocument.Load(sourceFile);
            XElement root = (XElement)doc.FirstNode;

            Tag = root.Attribute("Tag").Value;
            Flags = root.Element("Flags").ToEnum<RecordFlag>();
            FormID = root.Element("FormID").ToFormID();
            FormVersion = root.Element("FormVersion").ToUInt16();
            VersionControlInfo1 = root.Element("VersionControlInfo").Element("Info1").ToUInt32();
            VersionControlInfo2 = root.Element("VersionControlInfo").Element("Info2").ToUInt16();
            compressionCorrupted = root.Element("CompressionCorrupted").ToBoolean();

            if (compressionCorrupted)
                corruptedBytes = root.Element("CorruptedBytes").ToBytes();
            else
                ReadDataXML(root);

        }

        public void WriteBinary(BinaryWriter writer)
        {
            byte[] dataBytes;

            if (Flags.HasFlag(RecordFlag.Compressed))
            {
                if (compressionCorrupted)
                    dataBytes = corruptedBytes;
                else
                    dataBytes = CompressData(WriteData());
            }
            else
                dataBytes = WriteData();

            writer.Write(Tag.ToCharArray());
            writer.Write(dataBytes.Length);
            writer.Write((uint)Flags);
            writer.Write(FormID);
            writer.Write(VersionControlInfo1);
            writer.Write(FormVersion);
            writer.Write(VersionControlInfo2);
            writer.Write(dataBytes);
        }

        public void ReadBinary(BinaryReader reader)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32();
            Flags = (RecordFlag)reader.ReadUInt32();
            FormID = reader.ReadUInt32();
            VersionControlInfo1 = reader.ReadUInt32();
            FormVersion = reader.ReadUInt16();
            VersionControlInfo2 = reader.ReadUInt16();

            if (Flags.HasFlag(RecordFlag.Compressed))
            {
                byte[] outBytes;
                compressionCorrupted = !TryDecompressData(reader, out outBytes);

                if (compressionCorrupted)
                    corruptedBytes = outBytes;
                else
                    ReadData(outBytes);
            }
            else
            {
                ReadData(reader.ReadBytes((int)Size));
            }
        }

        bool TryDecompressData(BinaryReader reader, out byte[] outBytes)
        {
            uint origSize = reader.ReadUInt32();
            byte[] compressedBytes = reader.ReadBytes((int)Size - 4);

            try
            {
                using (MemoryStream stream = new MemoryStream(compressedBytes))
                    outBytes = Zlib.Decompress(stream, origSize - 4);

                return true;
            }
            catch
            {
                List<byte> temp = BitConverter.GetBytes(origSize).ToList();
                temp.AddRange(compressedBytes);
                outBytes = temp.ToArray();

                return false;
            }
        }

        byte[] CompressData(byte[] data)
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(data.Length));

            byteList.AddRange(Zlib.Compress(data));

            return byteList.ToArray();
        }

        public abstract void ReadData(byte[] bytes);

        public abstract byte[] WriteData();

        public abstract void ReadDataXML(XElement ele);

        public abstract void WriteDataXML(XElement ele);

        public static Record CreateRecord(string Tag)
        {
            switch (Tag)
            {
                default:
                    return new GenericRecord();
            }
        }

        public static Record CreateRecord(BinaryReader reader)
        {
            return CreateRecord(reader.PeekTag());
        }

        public static Record CreateRecord(XDocument doc)
        {
            return Record.CreateRecord(doc.Element("Record").Attribute("Tag").Value);
        }

        public override string ToString()
        {
            return FormID.ToString();
        }
    }
}
