using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp
{
    public struct FormID
    {
        uint rawVal;

        public FormID(uint inID)
        {
            rawVal = inID;
        }

        public static implicit operator FormID(uint val)
        {
            return new FormID(val);
        }

        public static implicit operator uint(FormID val)
        {
            return val.rawVal;
        }
    }
}