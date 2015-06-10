using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum VATSAction : uint
    {
        UnarmedAttack = 0,
        _1HandMeleeAttack,
        _2HandMeleeAttack,
        FirePistol,
        FireRifle,
        FireHandleWeapon,
        FireLauncher,
        ThrowGrenade,
        PlaceMine,
        Reload,
        Crouch,
        Stand,
        SwitchWeapon,
        ToggleWeaponDrawn,
        Heal,
        PlayerDeath,
        SpecialWeaponAttack,
        SpecialUnarmedAttack,
        KillCameraShot,
        ThrowWeapon
    }
}
