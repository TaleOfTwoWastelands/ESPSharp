using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp
{
    public class DecalData : Subrecord
    {
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public float Depth { get; set; }
        public float Shininess { get; set; }
        public float ParallaxScale { get; set; }
        public byte ParallaxPasses { get; set; }
        protected override void ReadData(ESPReader reader)
        {
            throw new NotImplementedException();
        }

        protected override void WriteData(ESPWriter writer)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDataXML(XElement ele)
        {
            throw new NotImplementedException();
        }

        protected override void ReadDataXML(XElement ele)
        {
            throw new NotImplementedException();
        }
    }

    public enum DecalDataFlags : ushort
    {

    }
}
