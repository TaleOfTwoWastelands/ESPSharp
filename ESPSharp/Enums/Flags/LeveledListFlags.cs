using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum LeveledListFlags : byte
    {
        CalcAllLessThanPlayer = 0x01,
        CalcForEachItemInCount = 0x02,
        UseAll = 0x04
    }
}
