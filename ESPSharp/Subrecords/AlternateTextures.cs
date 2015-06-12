using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.DataTypes;
using ESPSharp.Enums;
using ESPSharp.Interfaces;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Subrecords
{
    public partial class AlternateTextures : Subrecord, IReferenceContainer, ICloneable<AlternateTextures>
    {
        public List<AlternateTexture> Textures { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Textures = new List<AlternateTexture>();
            uint Count = reader.ReadUInt32();
            for (int i = 0; i < Count; i++)
                Textures.Add(reader.Read<AlternateTexture>());
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Textures.Count);
            foreach (var texture in Textures)
                writer.Write(texture);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var texture in Textures)
            {
                XElement subEle = new XElement("AlternateTexture");
                texture.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Textures = new List<AlternateTexture>();

            foreach (var subEle in ele.Elements())
            {
                AlternateTexture tex = new AlternateTexture();
                tex.ReadXML(subEle, master);
                Textures.Add(tex);
            }
        }

        public AlternateTextures Clone()
        {
            throw new NotImplementedException();
        }
    }
}
