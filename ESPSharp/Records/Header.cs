using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public class Header : Record
    {
        public PluginHeader PluginHeader { get; set; }

        public byte[] OffsetData {
            get
            {
                return offsetData.Value;
            }
            set
            {
                offsetData.Value = value;
            }
        }
        protected SimpleSubrecord<byte[]> offsetData;
        public byte[] DeletionsData
        {
            get
            {
                return deletionsData.Value;
            }
            set
            {
                deletionsData.Value = value;
            }
        }
        protected SimpleSubrecord<byte[]> deletionsData;
        public string Author
        {
            get
            {
                return author.Value;
            }
            set
            {
                author.Value = value;
            }
        }
        protected SimpleSubrecord<string> author;
        public string Description
        {
            get
            {
                return description.Value;
            }
            set
            {
                description.Value = value;
            }
        }
        protected SimpleSubrecord<string> description;
        public Dictionary<string, ulong> MasterFileData { get; set; }
        public List<FormID> OverriddenRecords { get; set; }
        public byte[] ScreenshotData
        {
            get
            {
                return screenshotData.Value;
            }
            set
            {
                screenshotData.Value = value;
            }
        }
        protected SimpleSubrecord<byte[]> screenshotData;

        public override void ReadData(ESPReader reader, long dataEnd)
        {
            while (reader.BaseStream.Position < dataEnd)
            {
                string subTag = reader.PeekTag();

                switch (subTag)
                {
                    case "HEDR":
                        if (PluginHeader == null)
                            PluginHeader = new PluginHeader();

                        PluginHeader.ReadBinary(reader);
                        break;
                    case "OFST":
                        if (offsetData == null)
                            offsetData = new SimpleSubrecord<byte[]>();

                        offsetData.ReadBinary(reader);
                        break;
                    case "DELE":
                        if (deletionsData == null)
                            deletionsData = new SimpleSubrecord<byte[]>();

                        deletionsData.ReadBinary(reader);
                        break;
                    case "CNAM":
                        if (author == null)
                            author = new SimpleSubrecord<string>();

                        author.ReadBinary(reader);
                        break;
                    case "SNAM":
                        if (description == null)
                            description = new SimpleSubrecord<string>();

                        description.ReadBinary(reader);
                        break;
                    case "MAST":
                        reader.ReadTag();

                        if (MasterFileData == null)
                            MasterFileData = new Dictionary<string, ulong>();

                        string fileName = reader.ReadNullTermString(reader.ReadUInt16());
                        ulong size = 0;

                        if (reader.PeekTag() == "DATA")
                        {
                            reader.ReadTag();
                            reader.ReadUInt16();
                            size = reader.ReadUInt64();
                        }

                        MasterFileData.Add(fileName, size);
                        break;
                    case "ONAM":
                        reader.ReadTag();

                        if (OverriddenRecords == null)
                            OverriddenRecords = new List<FormID>();

                        int count = reader.ReadUInt16() / 4;

                        for (int i = 0; i < count; i++ )
                            OverriddenRecords.Add(reader.ReadUInt32());

                        break;
                    case "SCRN":
                        if (screenshotData == null)
                            screenshotData = new SimpleSubrecord<byte[]>();

                        screenshotData.ReadBinary(reader);
                        break;
                }
            }
        }

        public override void WriteData(ESPWriter writer)
        {
            if (PluginHeader != null) PluginHeader.WriteBinary(writer);
            if (offsetData != null) offsetData.WriteBinary(writer);
            if (deletionsData != null) deletionsData.WriteBinary(writer);
            if (author != null) author.WriteBinary(writer);
            if (description != null) description.WriteBinary(writer);
            if (MasterFileData != null)
            {
                foreach (var kvp in MasterFileData)
                {
                    writer.WriteTag("MAST");
                    writer.Write((ushort)(kvp.Key.Length + 1));
                    writer.Write(kvp.Key.ToCharArray());
                    writer.Write((byte)0);

                    writer.WriteTag("DATA");
                    writer.Write((ushort)8);
                    writer.Write(kvp.Value);
                }
            }
            if (OverriddenRecords != null)
            {
                writer.WriteTag("ONAM");
                writer.Write((ushort)OverriddenRecords.Count * 4);

                foreach (var rec in OverriddenRecords)
                    writer.Write(rec);
            }
            if (screenshotData != null) screenshotData.WriteBinary(writer);
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach (var subEle in ele.Elements().Where(e => e.Attribute("Tag") != null))
            {
                switch (subEle.Attribute("Tag").Value)
                {
                    case "HEDR":
                        if (PluginHeader == null)
                            PluginHeader = new PluginHeader();

                        PluginHeader.ReadXML(subEle);
                        break;
                    case "OFST":
                        if (offsetData == null)
                            offsetData = new SimpleSubrecord<byte[]>();

                        offsetData.ReadXML(subEle);
                        break;
                    case "DELE":
                        if (deletionsData == null)
                            deletionsData = new SimpleSubrecord<byte[]>();

                        deletionsData.ReadXML(subEle);
                        break;
                    case "CNAM":
                        if (author == null)
                            author = new SimpleSubrecord<string>();

                        author.ReadXML(subEle);
                        break;
                    case "SNAM":
                        if (description == null)
                            description = new SimpleSubrecord<string>();

                        description.ReadXML(subEle);
                        break;
                    case "MAST":
                        if (MasterFileData == null)
                            MasterFileData = new Dictionary<string,ulong>();

                        string fileName = subEle.Value;
                        ulong fileSize = subEle.Element("FileSize").ToUInt64();

                        MasterFileData[fileName] = fileSize;
                        break;
                    case "ONAM":
                        if (OverriddenRecords == null)
                            OverriddenRecords = new List<FormID>();

                        foreach (var subSubEle in subEle.Elements())
                            OverriddenRecords.Add(subSubEle.ToFormID());
                        break;
                    case "SCRN":
                        if (screenshotData == null)
                            screenshotData = new SimpleSubrecord<byte[]>();

                        screenshotData.ReadXML(subEle);
                        break;
                }
            }
        }

        public override void WriteDataXML(XElement ele)
        {
            if (PluginHeader != null) 
            {
                XElement subEle = new XElement("PluginHeader");
                PluginHeader.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (offsetData != null)
            {
                XElement subEle = new XElement("OffsetData");
                offsetData.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (deletionsData != null)
            {
                XElement subEle = new XElement("DeletionsData");
                deletionsData.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (author != null)
            {
                XElement subEle = new XElement("Author");
                author.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (description != null)
            {
                XElement subEle = new XElement("Description");
                description.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (MasterFileData != null)
            {
                foreach (var kvp in MasterFileData)
                {
                    XElement subEle = new XElement("MasterFile");

                    subEle.Add(
                        new XAttribute("Tag", "MAST"),
                        new XElement("FileName", kvp.Key),
                        new XElement("FileSize", kvp.Value));

                    ele.Add(subEle);
                }
            }

            if (OverriddenRecords != null)
            {
                XElement subEle = new XElement("ParentOverrides");
                subEle.Add(new XAttribute("Tag", "ONAM"));

                foreach (var form in OverriddenRecords)
                    subEle.Add(new XElement("Override", form));

                ele.Add(subEle);
            }

            if (screenshotData != null)
            {
                XElement subEle = new XElement("ScreenshotData");
                screenshotData.WriteXML(subEle);
                ele.Add(subEle);
            }
        }
    }
}
