using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp
{
    public class TextureSet : Record, IEditorID
    {
        public string EditorID { get; set; }
        public ObjectBounds ObjectBounds { get; set; }
        public string BaseImage_Transparency { get; set; }
        public string NormalMap_Specular { get; set; }
        public string EnvironmentMapMask { get; set; }
        public string GlowMap { get; set; }
        public string ParallaxMap { get; set; }
        public string EnvironmentMap { get; set; }




        public override void ReadData(ESPReader reader, long dataEnd)
        {
            throw new NotImplementedException();
        }

        public override void WriteData(ESPWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void WriteDataXML(System.Xml.Linq.XElement ele)
        {
            throw new NotImplementedException();
        }

        public override void ReadDataXML(System.Xml.Linq.XElement ele)
        {
            throw new NotImplementedException();
        }
    }
}
