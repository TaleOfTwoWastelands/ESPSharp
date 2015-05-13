using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class GameSetting : Record
    {
        public string EditorID { get; set; }
        public GameSettingType Type { get; set; }
        public string ValueString { get; set; }
        public int ValueInt { get; set; }
        public float ValueFloat { get; set; }

        public override void ReadData(ESPReader reader, long dataEnd)
        {
            throw new NotImplementedException();
        }

        public override void WriteData(ESPWriter writer)
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
