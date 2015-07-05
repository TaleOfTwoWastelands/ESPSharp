using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ExplosionFlags : uint
    {
        AlwaysUsesWorldOrientation = 0x02,
        KnockDownAlways = 0x04,
        KnockDownByFormula = 0x08,
        IgnoreLOSCheck = 0x10,
        PushExplosionSourceRefOnly = 0x20,
        IgnoreImageSpaceSwap = 0x40
    }
}
