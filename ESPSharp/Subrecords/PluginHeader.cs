using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class PluginHeader : Subrecord
    {
        public float Version { get; set; }
        public uint RecordCount { get; set; }
        public uint NextFormID { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Version = reader.ReadSingle();
            RecordCount = reader.ReadUInt32();
            NextFormID = reader.ReadUInt32();
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Version);
            writer.Write(RecordCount);
            writer.Write(NextFormID);
        }

        protected override void WriteDataXML(XElement ele)
        {
            ele.Add(
                new XElement("Version", Version),
                new XElement("RecordCount", RecordCount),
                new XElement("NextFormID", NextFormID));
        }

        protected override void ReadDataXML(XElement ele)
        {
            Version = ele.Element("Version").ToSingle();
            RecordCount = ele.Element("RecordCount").ToUInt32();
            NextFormID = ele.Element("NextFormID").ToUInt32();
        }
    }
}
