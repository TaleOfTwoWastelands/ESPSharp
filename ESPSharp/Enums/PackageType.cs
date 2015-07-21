using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum PackageType : byte
    {
        Find,
        Follow,
        Escort,
        Eat,
        Sleep,
        Wander,
        Travel,
        Accompany,
        UseItemAt,
        Ambush,
        FleeNotCombat,
        Sandbox = 12,
        Patrol,
        Guard,
        Dialog,
        UseWeapon
    }
}
