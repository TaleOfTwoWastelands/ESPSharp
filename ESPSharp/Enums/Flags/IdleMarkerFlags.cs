using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum IdleMarkerFlags : byte
    {
        RunInSequence = 0x01,
        DoOnce = 0x04
    }
}
