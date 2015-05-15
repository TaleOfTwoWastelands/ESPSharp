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
    public class Header : Record, IReferenceContainer
    {
        public PluginHeader PluginHeader { get; set; }

        public byte[] OffsetData { get; set; }
        public byte[] DeletionsData { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public List<MasterFileData> MasterFiles { get; set; }
        public FormArray OverriddenRecords { get; set; }
        public byte[] ScreenshotData { get; set; }

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
                        OffsetData = reader.ReadSimpleSubrecord<byte[]>();
                        break;
                    case "DELE":
                        DeletionsData = reader.ReadSimpleSubrecord<byte[]>();
                        break;
                    case "CNAM":
                        Author = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "SNAM":
                        Description = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "MAST":
                        if (MasterFiles == null)
                            MasterFiles = new List<MasterFileData>();

                        MasterFileData data = new MasterFileData();
                        data.ReadBinary(reader);

                        MasterFiles.Add(data);
                        break;
                    case "ONAM":
                        OverriddenRecords = new FormArray();

                        OverriddenRecords.ReadBinary(reader);
                        break;
                    case "SCRN":
                        ScreenshotData = reader.ReadSimpleSubrecord<byte[]>();
                        break;
                }
            }
        }

        public override void WriteData(ESPWriter writer)
        {
            if (PluginHeader != null) PluginHeader.WriteBinary(writer);
            if (OffsetData != null) writer.WriteSimpleSubrecord<byte[]>(OffsetData, "OFST");
            if (DeletionsData != null) writer.WriteSimpleSubrecord<byte[]>(DeletionsData, "DELE");
            if (Author != null) writer.WriteSimpleSubrecord<string>(Author, "CNAM");
            if (Description != null) writer.WriteSimpleSubrecord<string>(Description, "SNAM");
            if (MasterFiles != null)
            {
                foreach (var data in MasterFiles)
                    data.WriteBinary(writer);
            }
            if (OverriddenRecords != null) OverriddenRecords.WriteBinary(writer);
            if (ScreenshotData != null) writer.WriteSimpleSubrecord<byte[]>(ScreenshotData, "SCRN");
        }

        public override void WriteDataXML(XElement ele)
        {
            if (PluginHeader != null)
            {
                XElement subEle = new XElement("PluginHeader");
                PluginHeader.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (OffsetData != null)
                ele.AddSimpleSubrecord("OffsetData", "OFST", OffsetData.ToHex());

            if (DeletionsData != null)
                ele.AddSimpleSubrecord("DeletionsData", "DELE", DeletionsData.ToHex());

            if (Author != null)
                ele.AddSimpleSubrecord("Author", "CNAM", Author);

            if (Description != null)
                ele.AddSimpleSubrecord("Description", "SNAM", Description);

            if (MasterFiles != null)
            {
                XElement subEle = new XElement("MasterFiles");

                foreach (var data in MasterFiles)
                    data.WriteXML(subEle);

                ele.Add(subEle);
            }

            if (OverriddenRecords != null)
                OverriddenRecords.WriteXML(ele);

            if (ScreenshotData != null)
                ele.AddSimpleSubrecord("ScreenshotData", "SCRN", ScreenshotData.ToHex());
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach (var subEle in ele.Elements())
            {
                string switchString;

                if (subEle.Attribute("Tag") != null) 
                    switchString = subEle.Attribute("Tag").Value;
                else 
                    switchString = subEle.Name.ToString();

                switch (switchString)
                {
                    case "HEDR":
                        if (PluginHeader == null)
                            PluginHeader = new PluginHeader();

                        PluginHeader.ReadXML(subEle);
                        break;
                    case "OFST":
                        OffsetData = subEle.ToBytes();
                        break;
                    case "DELE":
                        DeletionsData = subEle.ToBytes();
                        break;
                    case "CNAM":
                        Author = subEle.Value;
                        break;
                    case "SNAM":
                        Description = subEle.Value;
                        break;
                    case "MasterFiles":
                        if (MasterFiles == null)
                            MasterFiles = new List<MasterFileData>();

                        foreach (XElement e in subEle.Elements())
                        {
                            MasterFileData data = new MasterFileData();
                            data.ReadXML(e);
                            MasterFiles.Add(data);
                        }
                        break;
                    case "ONAM":
                        if (OverriddenRecords == null)
                            OverriddenRecords = new FormArray();

                        OverriddenRecords.ReadXML(subEle);
                        break;
                    case "SCRN":
                        ScreenshotData = subEle.ToBytes();
                        break;
                }
            }
        }

        public override string ToString()
        {
            return "Header";
        }
    }
}
