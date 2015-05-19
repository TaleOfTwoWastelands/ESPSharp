using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ClassDataFlag : uint
    {
        Playable = 0x01,
        Guard = 0x02
    }
}
