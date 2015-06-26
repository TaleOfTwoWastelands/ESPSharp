using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WeaponDataFlags2 : uint
    {
        PlayerOnly = 0x01,
        NPCsUseAmmo = 0x02,
        NoJamAfterReload = 0x04,
        OverrideActionPointCost = 0x08,
        MinorCrime = 0x10,
        FixedRange = 0x20,
        NotUsedInNormalCombat = 0x40,
        OverrideDamageToWeaponMult = 0x80,
        DontUse3rdPersonIronSightAnimations = 0x0100,
        ShortBurst = 0x0200,
        RumbleAlternate = 0x0400,
        LongBurst = 0x0800,
        ScopeHasNightVision = 0x1000,
        ScopeFromMod = 0x2000
    }
}
