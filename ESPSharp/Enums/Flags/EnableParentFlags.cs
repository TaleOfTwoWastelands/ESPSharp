using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum EnableParentFlags : byte
    {
        EnableStateOppositeParent = 0x01,
        PopIn = 0x02
    }
}
