using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ActionFlags : uint
    {
        UseDefault = 0x01,
        Activate = 0x02,
        Open = 0x04,
        OpenByDefault = 0x08
    }
}
