using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum LightFlags : uint
    {
        Dynamic = 0x01,
        CanBeCarried = 0x02,
        Negative = 0x04,
        Flicker = 0x08,
        OffByDefault = 0x20,
        FlickerSlow = 0x40,
        Pulse = 0x80,
        PulseSlow = 0x0100,
        SpotLight = 0x0200,
        SpotShadow = 0x0400
    }
}
