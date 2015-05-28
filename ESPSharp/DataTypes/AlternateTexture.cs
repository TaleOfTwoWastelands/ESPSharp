using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp.Interfaces;
using System.Xml.Linq;

namespace ESPSharp
{
    public struct AlternateTexture : IESPToXML
    {
        public string Name;
        public FormID TextureSet;
        public int Index;

        public void WriteXML(XElement ele)
        {
            ele.Add(
                new XElement("Name", Name),
                new XElement("TextureSet", TextureSet),
                new XElement("Index", Index)
                );
        }

        public void ReadXML(XElement ele)
        {
            Name = ele.Element("Name").Value;
            TextureSet.ReadXML(ele.Element("TextureSet"));
            Index = ele.Element("Index").ToInt32();
        }
    }
}
