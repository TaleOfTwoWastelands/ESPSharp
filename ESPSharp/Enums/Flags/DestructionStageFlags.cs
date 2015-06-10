using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum DestructionStageFlags : byte
    {
        CapDamage = 0x01,
        Disable = 0x02,
        Destroy = 0x04
    }
}
