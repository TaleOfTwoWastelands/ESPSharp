using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp.Interfaces;
using System.Xml.Linq;
using ESPSharp;

namespace ESPSharp
{
    public class FormID : IESPSerializable, ICloneable<FormID>
    {
        uint rawVal;

        public FormID()
        {
            rawVal = 0;
        }

        public FormID(uint inID)
        {
            rawVal = inID;
        }

        public FormID(FormID toCopy)
        {
            rawVal = (uint)toCopy;
        }

        public FormID Clone()
        {
            return new FormID(this);
        }

        public static explicit operator FormID(uint val)
        {
            return new FormID(val);
        }

        public static explicit operator uint(FormID val)
        {
            return val.rawVal;
        }

        public override string ToString()
        {
            return rawVal.ToString("X8");
        }

        public void WriteXML(XElement ele)
        {
            ele.Value = ToString();
        }

        public void ReadXML(XElement ele)
        {
            rawVal = uint.Parse(ele.Value, System.Globalization.NumberStyles.HexNumber);
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write(rawVal);
        }

        public void ReadBinary(ESPReader reader)
        {
            rawVal = reader.ReadUInt32();
        }
    }
}