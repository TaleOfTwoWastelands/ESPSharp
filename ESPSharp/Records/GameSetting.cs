using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ESPSharp
{
    public class GameSetting : Record
    {
        public string EditorID { get; set; }
        public GameSettingType Type { get; set; }
        public string ValueString { get; set; }
        public int ValueInt { get; set; }
        public float ValueFloat { get; set; }

        public override void ReadData(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public override byte[] WriteData()
        {
            throw new NotImplementedException();
        }

        public override void ReadDataXML(System.Xml.Linq.XElement ele)
        {
            throw new NotImplementedException();
        }

        public override void WriteDataXML(System.Xml.Linq.XElement ele)
        {
            throw new NotImplementedException();
        }
    }
}
