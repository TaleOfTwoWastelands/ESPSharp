using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WaterFlags : byte
    {
        CausesDamage = 0x01,
        Reflective = 0x02
    }
}
