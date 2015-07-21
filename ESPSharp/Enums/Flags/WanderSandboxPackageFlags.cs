using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WanderSandboxPackageFlags : ushort
    {
        NoEating = 0x01,
        NoSleeping = 0x02,
        NoConversation = 0x04,
        NoIdleMarkers = 0x08,
        NoFurniture = 0x10,
        NoWandering = 0x20
    }
}
