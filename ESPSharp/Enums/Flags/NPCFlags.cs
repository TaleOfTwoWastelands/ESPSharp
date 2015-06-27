using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum NPCFlags : uint
    {
        Female = 0x01,
        Essential = 0x02,
        IsCharGenFacePreset = 0x04,
        Respawn = 0x08,
        AutoCalcStats = 0x10,
        PCLevelMult = 0x80,
        UseTemplate = 0x0100,
        NoLowLevelProcessing = 0x0200,
        NoBloodSpray = 0x0800,
        NoBloodDecal = 0x1000,
        NoVATSMelee = 0x100000,
        CanBeAllRaces = 0x400000,
        AutocalcService = 0x800000,
        NoKnockdowns = 0x03000000,
        NotPushable = 0x08000000,
        NoRotatingToHeadTrack = 0x40000000
    }
}
