using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum ConditionComparisonType : byte
    {
        EqualTo = 0x00,
        NotEqualTo = 0x20,
        GreaterThan = 0x40,
        GreaterThanOrEqualTo = 0x60,
        Lessthan = 0x80,
        LessThanOrEqualTo = 0xA0
    }
}
