using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp.Interfaces;
using System.Xml.Linq;

namespace ESPSharp
{
    public struct FormID : IESPToXML
    {
        uint rawVal;

        public FormID(uint inID)
        {
            rawVal = inID;
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
    }
}