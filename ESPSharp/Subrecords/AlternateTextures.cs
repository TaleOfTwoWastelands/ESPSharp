using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Subrecords
{
    public partial class AlternateTextures : Subrecord
    {
        public List<AlternateTexture> Textures { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Textures = new List<AlternateTexture>();
            uint Count = reader.ReadUInt32();
            for (int i = 0; i < Count; i++)
                Textures.Add(reader.ReadAlternateTexture());
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Textures.Count);
            foreach (var texture in Textures)
                writer.Write(texture);
        }

        protected override void WriteDataXML(XElement ele)
        {
            foreach (var texture in Textures)
                ele.Add("AlternateTexture", texture);
        }

        protected override void ReadDataXML(XElement ele)
        {
            Textures = new List<AlternateTexture>();

            foreach (var subEle in ele.Elements())
                Textures.Add(subEle.ToAlternateTexture());
        }
    }
}
