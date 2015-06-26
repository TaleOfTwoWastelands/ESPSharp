using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum WeaponModEffect : uint
    {
        None,
        IncreaseWeaponDamage,
        IncreaseClipCapacity,
        DecreaseSpread,
        DecreaseWeight,
        RegenerateAmmoEveryXShots,
        ModifyAmmoRechargeTimeXSeconds,
        DecreaseEquipTime,
        IncreaseRateOfFire,
        IncreaseProjectileSpeed,
        IncreaseMaxCondition,
        Silence,
        SplitBeam,
        VATSBonus,
        IncreaseZoom,
        DecreaseEquipTime2,
        Suppressor
    }
}
