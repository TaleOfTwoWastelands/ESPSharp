using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ProjectileFlags : ushort
    {
        Hitscan = 0x01,
        Explosion = 0x02,
        AltTrigger = 0x04,
        MuzzleFlash = 0x08,
        CanBeDisabled = 0x20,
        CanBePickedUp = 0x40,
        Supersonic = 0x80,
        PinsLimbs = 0x0100,
        PassThroughSmallTransparent = 0x0200,
        Detonates = 0x0400,
        Rotation = 0x0800
    }
}
