using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum MediaSetEnableFlags : byte
    {
        DayOuter = 0x01,
        DayMiddle = 0x02,
        DayInner = 0x04,
        NightOuter = 0x08,
        NightMiddle = 0x10,
        NightInner = 0x20
    }
}
