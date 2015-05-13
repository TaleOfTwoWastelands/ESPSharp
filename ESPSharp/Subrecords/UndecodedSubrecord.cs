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
    public class UndecodedSubrecord : Subrecord
    {
        public byte[] Data { get; set; }

        public override void WriteData(ESPWriter writer)
        {
            writer.Write(Data);
        }

        public override void ReadData(ESPReader reader)
        {
            int readSize = size;
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

        public override void WriteDataXML(XElement ele)
        {
            ele.Value = Data.ToBase64();
        }

        public override void ReadDataXML(XElement ele)
        {
            Data = ele.ToBytes();
        }
    }
}
