using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum MagicEffectArchetype : uint
    {
        ValueModifier,
        Script,
        Dispel,
        CureDisease,
        Invisibility = 11,
        Chameleon,
        Light,
        Lock = 16,
        Open,
        BoundItem,
        SummonCreature,
        Paralysis = 24,
        CureParalysis = 30,
        CureAddiction,
        CurePoison,
        Concussion,
        ValueAndParts,
        LimbCondition,
        Turbo
    }
}
