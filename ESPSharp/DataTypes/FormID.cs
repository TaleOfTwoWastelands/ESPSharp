using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.DataTypes
{
    public partial class FormID
    {
        public static explicit operator FormID(uint val)
        {
            return new FormID(val);
        }

        public static explicit operator uint(FormID val)
        {
            return val.RawValue;
        }

        public override string ToString()
        {
            return RawValue.ToString("X8");
        }

        partial void WriteDataXML(XElement ele)
        {
            ele.Value = ToString();
        }

        partial void ReadDataXML(XElement ele)
        {
            RawValue = uint.Parse(ele.Value, System.Globalization.NumberStyles.HexNumber);
        }
    }
}