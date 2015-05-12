using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class Header : Record
    {
        PluginHeader PluginHeader { get; set; }
        byte[] OffsetData { get; set; }
        byte[] DeletionsData { get; set; }
        string Author { get; set; }
        string Description { get; set; }
        Dictionary<string, long> MasterFileData { get; set; }
        List<FormID> OverriddenRecords { get; set; }
        byte[] ScreenshotData { get; set; }

        public override void ReadData(BinaryReader reader, long dataEnd)
        {
            throw new NotImplementedException();
        }

        public override void WriteData(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void ReadDataXML(XElement ele)
        {
            throw new NotImplementedException();
        }

        public override void WriteDataXML(XElement ele)
        {
            throw new NotImplementedException();
        }
    }
}
