using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp.Interfaces;
using System.Xml.Linq;

namespace ESPSharp
{
    public class AlternateTexture : IESPSerializable, ICloneable<AlternateTexture>
    {
        public string Name;
        public FormID TextureSet;
        public int Index;

        public AlternateTexture()
        {
            TextureSet = new FormID();
        }

        public AlternateTexture(string Name, FormID TextureSet, int Index)
        {
            this.Name = Name;
            this.TextureSet = TextureSet.Clone();
            this.Index = Index;
        }

        public AlternateTexture(AlternateTexture toCopy)
        {
            Name = toCopy.Name;
            TextureSet = toCopy.TextureSet.Clone();
            Index = toCopy.Index;
        }

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

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write((uint)Name.Length);
            writer.Write(Name.ToCharArray());
            writer.Write(TextureSet);
            writer.Write(Index);
        }

        public void ReadBinary(ESPReader reader)
        {
            int size = reader.ReadInt32();
            Name = new String(reader.ReadChars(size));
            TextureSet = reader.Read<FormID>();
            Index = reader.ReadInt32();
        }

        public AlternateTexture Clone()
        {
            return new AlternateTexture(this);
        }
    }
}
