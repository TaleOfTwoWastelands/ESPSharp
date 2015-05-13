using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public abstract class Subrecord
    {
        public string Tag { get; set; }
        protected int size;


        public virtual void WriteXML(XElement root)
        {
            root.Add(new XAttribute("Tag", Tag));
            WriteDataXML(root);
        }

        public virtual void ReadXML(XElement ele)
        {
            Tag = ele.Attribute("Tag").Value;
            ReadDataXML(ele);
        }

        public virtual void WriteBinary(ESPWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());
            writer.Write((ushort)0);

            long dataPoint = writer.BaseStream.Position;
            WriteData(writer);
            long dataEnd = writer.BaseStream.Position;

            if ((dataEnd - dataPoint) <= ushort.MaxValue)
            {
                writer.BaseStream.Seek(dataPoint - 2, SeekOrigin.Begin);
                writer.Write((ushort)(dataEnd - dataPoint));

                writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
            }
        }

        public virtual void ReadBinary(ESPReader reader)
        {
            Tag = reader.ReadTag();
            size = reader.ReadUInt16();

            ReadData(reader);
        }

        public abstract void ReadData(ESPReader reader);
        public abstract void WriteData(ESPWriter writer);
        public abstract void WriteDataXML(XElement ele);
        public abstract void ReadDataXML(XElement ele);
    }
}
