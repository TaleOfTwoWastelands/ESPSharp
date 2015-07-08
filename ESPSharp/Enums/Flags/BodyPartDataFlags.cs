using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum BodyPartDataFlags : byte
    {
        Severable = 0x01,
        IKData = 0x02,
        IKData_BipedData = 0x04,
        Explodable = 0x08,
        IKData_IsHead = 0x10,
        IKData_Headtracking = 0x20,
        ToHitChance_Absolute = 0x40
    }
}
