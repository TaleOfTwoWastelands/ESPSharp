using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ActorTemplateFlags : ushort
    {
        UseTraits = 0x01,
        UseStats = 0x02,
        UseFactions = 0x04,
        UseActorEffectList = 0x08,
        UseAIData = 0x10,
        UseAIPackages = 0x20,
        UseModelAnimation = 0x40,
        UseBaseData = 0x80,
        UseInventory = 0x0100,
        UseScript = 0x0200
    }
}
