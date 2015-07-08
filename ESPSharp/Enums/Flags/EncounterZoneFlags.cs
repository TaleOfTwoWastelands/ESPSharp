using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    public enum EncounterZoneFlags : byte
    {
        NeverResets = 0x01,
        MatchPCBelowMinimumLevel = 0x02
    }
}
