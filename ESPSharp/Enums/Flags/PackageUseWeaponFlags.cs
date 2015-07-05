using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum PackageUseWeaponFlags : uint
    {
        AlwaysHit = 0x01,
        DoNoDamage = 0x0100,
        CrouchToReload = 0x010000,
        HoldFireWhenBlocked = 0x01000000
    }
}
