using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum CombatStyleFlags : uint
    {
        ChooseAttackUsingPercentChance = 0x01,
        MeleeAlertOK = 0x02,
        FleeBasedOnPersonalSurvival = 0x04,
        IgnoreThreats = 0x10,
        IgnoreDamagingSelf = 0x20,
        IgnoreDamagingGroup = 0x40,
        IgnoreDamagingSpectators = 0x80,
        CannotUseStealthBoy = 0x0100
    }
}
