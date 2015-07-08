using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ForceHideLandFlags : uint
    {
        Quad1 = 0x01,
        Quad2 = 0x02,
        Quad3 = 0x04,
        Quad4 = 0x08
    }
}
