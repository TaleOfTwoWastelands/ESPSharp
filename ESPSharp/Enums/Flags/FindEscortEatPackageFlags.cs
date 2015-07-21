using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum FindEscortEatPackageFlags : ushort
    {
        AllowBuying = 0x0100,
        AllowKilling = 0x0200,
        AllowStealing = 0x0400
    }
}
