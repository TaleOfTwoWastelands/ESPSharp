using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum PackageFlags : uint
    {
        OffersServices = 0x01,
        MustReachLocation = 0x02,
        MustComplete = 0x04,
        LockDoorsAtPackageStart = 0x08,
        LockDoorsAtPackageEnd = 0x10,
        LockDoorsAtLocation = 0x20,
        UnlockDoorsAtPackageStart = 0x40,
        UnlockDoorsAtPackageEnd = 0x80,
        UnlockDoorsAtLocation = 0x0100,
        ContinueIfPCNear = 0x0200,
        OncePerDay = 0x0400,
        SkipFalloutBehavior = 0x1000,
        AlwaysRun = 0x2000,
        AlwaysSneak = 0x020000,
        AllowSwimming = 0x040000,
        AllowFalls = 0x080000,
        HeadTrackingOff = 0x100000,
        WeaponsUnequipped = 0x200000,
        DefensiveCombat = 0x400000,
        WeaponDrawn = 0x800000,
        NoIdleAnims = 0x01000000,
        PretendInCombat = 0x02000000,
        ContinueDuringCombat = 0x04000000,
        NoCombatAlert = 0x08000000,
        NoWarn_AttackBehavior = 0x10000000
    }
}
