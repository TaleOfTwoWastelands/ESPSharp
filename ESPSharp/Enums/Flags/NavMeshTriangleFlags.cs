using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum NavMeshTriangleFlags : uint
    {
        Triangle0IsExternal = 0x01,
        Triangle1IsExternal = 0x02,
        Triangle2IsExternal = 0x04,
        PreferredPathing = 0x40,
        Water = 0x200,
        ContainsDoor = 0x400
    }
}
