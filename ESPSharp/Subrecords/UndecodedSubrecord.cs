using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using ESPSharp.Interfaces;

namespace ESPSharp.Subrecords
{
    public class UndecodedSubrecord : Subrecord, ICloneable<UndecodedSubrecord>
    {
        public byte[] Data { get; set; }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Data);
        }

        protected override void ReadData(ESPReader reader)
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

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            ele.Value = Data.ToHex();
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Data = ele.ToBytes();
        }

        public UndecodedSubrecord Clone()
        {
            throw new NotImplementedException();
        }
    }
}
