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
    public class Subrecord
    {
        public string Tag { get; set; }
        private int size;
        public byte[] Data { get; set; }


        public void WriteXML(XElement root)
        {
            XElement ele = new XElement(Tag,
                                new XElement("Size", size),
                                new XElement("Data", Data.ToBase64()));

            root.Add(ele);
        }

        public void ReadXML(XElement ele)
        {
            Tag = ele.Name.ToString();
            size = ele.Element("Size").ToInt32();
            Data = ele.Element("Data").ToBytes();
        }

        public void WriteBinary(BinaryWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());
            writer.Write((ushort)size);
            writer.Write(Data);
        }

        public void ReadBinary(BinaryReader reader)
        {
            Tag = reader.ReadTag();
            int readSize = size = reader.ReadUInt16();

            if (size == 0)
            {
                reader.BaseStream.Seek(-16, SeekOrigin.Current);
                if (reader.ReadTag() == "XXXX")
                {
                    Debug.Assert(reader.ReadUInt16() == 4);
                    readSize = reader.ReadInt32();
                    reader.BaseStream.Seek(6, SeekOrigin.Current);
                }
                else
                {
                    reader.BaseStream.Seek(12, SeekOrigin.Current);
                }
            }

            Data = reader.ReadBytes(readSize);
        }
    }
}
