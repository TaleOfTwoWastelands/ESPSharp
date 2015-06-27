using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum CreatureFlags : uint
    {
        Biped = 0x01,
        Essential = 0x02,
        WeaponAndShield = 0x04,
        Respawn = 0x08,
        Swims = 0x10,
        Flies = 0x20,
        Walks = 0x40,
        PCLevelMult = 0x80,
        NoLowLevelProcessing = 0x0200,
        NoBloodSpray = 0x0800,
        NoBloodDecal = 0x1000,
        NoHead = 0x8000,
        NoRightArm = 0x010000,
        NoLeftArm = 0x020000,
        NoCombatInWater = 0x040000,
        NoShadow = 0x080000,
        NoVATSMelee = 0x100000,
        AllowPCDialogue = 0x200000,
        CannotOpenDoors = 0x400000,
        Immobile = 0x800000,
        TiltFrontBack = 0x01000000,
        TiltLeftRight = 0x02000000,
        NoKnockdowns = 0x03000000,
        NotPushable = 0x08000000,
        AllowPickpocket = 0x10000000,
        IsGhost = 0x20000000,
        NoRotatingToHeadTrack = 0x40000000,
        Invulnerable = 0x80000000
    }
}
