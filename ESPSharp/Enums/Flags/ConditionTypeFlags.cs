using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ConditionFlags : byte
    {
        Or = 0x01,
        RunOnTarget = 0x02,
        UseGlobal = 0x04
    }
}
