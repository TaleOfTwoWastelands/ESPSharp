using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum SpellFlags : byte
    {
        NoAutoCalc = 0x01,
        ImmuneToSilence1 = 0x02,
        PCStartEffect = 0x04,
        ImmuneToSilence2 = 0x08,
        AreaEffectIgnoresLOS = 0x10,
        ScriptEffectAlwaysApplies = 0x20,
        DisableAbsorbReflect = 0x40,
        ForceTouchExplode = 0x80
    }
}
