using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WeaponDataFlags1 : byte
    {
        IgnoresNormalWeaponResistance = 0x01,
        IsAutomatic = 0x02,
        HasScope = 0x04,
        CantDrop = 0x08,
        HideBackpack = 0x10,
        EmbeddedWeapon = 0x20,
        DontUse1stPersonIronSightAnimations = 0x40,
        NonPlayable = 0x80
    }
}
