using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum DoorFlags : byte
    {
        AutomaticDoor = 0x02,
        Hidden = 0x04,
        MinimalUse = 0x08,
        SlidingDoor = 0x10
    }
}
