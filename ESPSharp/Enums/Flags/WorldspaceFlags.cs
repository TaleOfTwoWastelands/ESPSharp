using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WorldspaceFlags : byte
    {
        SmallWorld = 0x01,
        CannotFastTravel = 0x02,
        NoLODWater = 0x10,
        NoLODNoise = 0x20,
        DoNotAllowNPCFallDamage = 0x40,
        NeedsWaterAdjustment = 0x80
    }
}
