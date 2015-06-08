using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum MagicEffectFlags : uint
    {
        Hostile = 0x01,
        Recover = 0x02,
        Detrimental = 0x04,
        Self = 0x10,
        Touch = 0x20,
        Target = 0x40,
        NoDuration = 0x80,
        NoMagnitude = 0x0100,
        NoArea = 0x0200,
        FXPersist = 0x0400,
        GoryVisuals = 0x1000,
        DisplayNameOnly = 0x2000,
        RadioBroadcast = 0x8000,
        UseSkill = 0x080000,
        UseAttribute = 0x100000,
        Painless = 0x01000000,
        SprayProjectile = 0x02000000,
        BoltProjectile = 0x04000000,
        NoHitEffect = 0x08000000,
        NoDeathDispel = 0x10000000
    }
}
