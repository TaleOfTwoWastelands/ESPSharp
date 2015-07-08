using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ChallengeFlags : uint
    {
        StartDisabled = 0x01,
        Recurring = 0x02,
        ShowZeroProgress = 0x04
    }
}
