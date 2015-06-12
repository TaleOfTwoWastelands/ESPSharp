﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Records;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public abstract class Record
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

        public Record()
        {
            FormID = new FormID();
        }

        public void WriteXML(string destinationFile, ElderScrollsPlugin master)
        {
            XDocument doc = new XDocument();

            XElement root = new XElement("Record", 
                                new XAttribute("Tag", Tag));

            doc.Add(root);

            root.Add(
                new XElement("Flags", Flags),
                new XElement("FormID"),
                new XElement("FormVersion", FormVersion),
                new XElement("VersionControlInfo",
                    new XElement("Info1", VersionControlInfo1),
                    new XElement("Info2", VersionControlInfo2)),
                new XElement("CompressionCorrupted", compressionCorrupted)
                );

            FormID.WriteXML(root.Element("FormID"), master);

            if (compressionCorrupted)
                root.Add(new XElement("CorruptedBytes"), corruptedBytes.ToBase64());
            else
            {
                XElement ele = new XElement("Subrecords");
                root.Add(ele);
                WriteDataXML(ele, master);
            }

            XMLPostProcessing(root, destinationFile);

            doc.Save(destinationFile);
        }

        public static Record ReadXML(string sourceFile, ElderScrollsPlugin master)
        {
            XDocument doc = XDocument.Load(sourceFile);
            XElement root = (XElement)doc.FirstNode;

            Record outRecord = Record.CreateRecord(root.Attribute("Tag").Value);

            outRecord.Flags = root.Element("Flags").ToEnum<RecordFlag>();
            outRecord.FormID.ReadXML(root.Element("FormID"), master);
            outRecord.FormVersion = root.Element("FormVersion").ToUInt16();
            outRecord.VersionControlInfo1 = root.Element("VersionControlInfo").Element("Info1").ToUInt32();
            outRecord.VersionControlInfo2 = root.Element("VersionControlInfo").Element("Info2").ToUInt16();
            outRecord.compressionCorrupted = root.Element("CompressionCorrupted").ToBoolean();

            if (outRecord.compressionCorrupted)
                outRecord.corruptedBytes = root.Element("CorruptedBytes").ToBytes();
            else
            {
                outRecord.XMLPreProcessing(root, sourceFile);
                outRecord.ReadDataXML(root.Element("Subrecords"), master);
            }

            return outRecord;
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());
            writer.Write((uint)0);
            writer.Write((uint)Flags);
            writer.Write(FormID);
            writer.Write(VersionControlInfo1);
            writer.Write(FormVersion);
            writer.Write(VersionControlInfo2);

            long dataStart = writer.BaseStream.Position;

            if (Flags.HasFlag(RecordFlag.Compressed))
            {
                if (compressionCorrupted)
                    writer.Write(corruptedBytes);
                else
                {
                    using (MemoryStream stream = new MemoryStream())
                    using (ESPWriter subWriter = new ESPWriter(stream))
                    {
                        WriteData(subWriter);
                        stream.Position = 0;
                        writer.Write((uint)stream.Length);
                        writer.Write(Zlib.Compress(stream));
                    }
                }
            }
            else
                WriteData(writer);

            long dataEnd = writer.BaseStream.Position;

            writer.BaseStream.Seek(dataStart - 20, SeekOrigin.Begin);
            writer.Write((uint)(dataEnd - dataStart));
            writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
        }

        public void ReadBinary(ESPReader reader)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32();
            Flags = (RecordFlag)reader.ReadUInt32();
            FormID = reader.Read<FormID>();
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
                    using (MemoryStream stream = new MemoryStream(outBytes))
                    using (ESPReader subReader = new ESPReader(stream))
                        ReadData(subReader, stream.Length);
            }
            else
            {
                ReadData(reader, reader.BaseStream.Position + Size);
            }
        }

        bool TryDecompressData(ESPReader reader, out byte[] outBytes)
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

        public abstract void ReadData(ESPReader reader, long dataEnd);

        public abstract void WriteData(ESPWriter writer);

        public abstract void WriteDataXML(XElement ele, ElderScrollsPlugin master);

        public abstract void ReadDataXML(XElement ele, ElderScrollsPlugin master);

        protected virtual void XMLPreProcessing(XElement root, string sourceFile) { }
        protected virtual void XMLPostProcessing(XElement root, string destinationFile) { }

        public static Record CreateRecord(string Tag)
        {
            Record outRecord;

            switch (Tag)
            {
                case "TES4":
                    outRecord = new Header();
                    break;
                case "GMST":
                    outRecord = new GameSetting();
                    break;
                case "TXST":
                    outRecord = new TextureSet();
                    break;
                case "MICN":
                    outRecord = new MenuIcon();
                    break;
                case "GLOB":
                    outRecord = new GlobalVariable();
                    break;
                case "CLAS":
                    outRecord = new Class();
                    break;
                case "FACT":
                    outRecord = new Faction();
                    break;
                case "HDPT":
                    outRecord = new HeadPart();
                    break;
                case "HAIR":
                    outRecord = new Hair();
                    break;
                case "RACE":
                    outRecord = new Race();
                    break;
                case "SOUN":
                    outRecord = new Sound();
                    break;
                case "ASPC":
                    outRecord = new AcousticSpace();
                    break;
                case "MGEF":
                    outRecord = new MagicEffect();
                    break;
                case "SCPT":
                    outRecord = new Script();
                    break;
                case "LTEX":
                    outRecord = new LandscapeTexture();
                    break;
                case "ENCH":
                    outRecord = new ObjectEffect();
                    break;
                case "SPEL":
                    outRecord = new ActorEffect();
                    break;
                case "ACTI":
                    outRecord = new ESPSharp.Records.Activator();
                    break;
                case "TACT":
                    outRecord = new TalkingActivator();
                    break;
                case "TERM":
                    outRecord = new Terminal();
                    break;
                case "ARMO":
                    outRecord = new Armor();
                    break;
                case "BOOK":
                    outRecord = new Book();
                    break;
                default:
                    outRecord = new GenericRecord();
                    break;
            }

            outRecord.Tag = Tag;

            return outRecord;
        }

        public static Record CreateRecord(ESPReader reader)
        {
            return CreateRecord(reader.PeekTag());
        }

        public static Record CreateRecord(XDocument doc)
        {
            return Record.CreateRecord(doc.Element("Record").Attribute("Tag").Value);
        }

        public override string ToString()
        {
            if (this is IEditorID)
                return (this as IEditorID).EditorID.Value;
            else
                return String.Format("{0} - {1}", Tag, FormID.ToString());
        }
    }
}
