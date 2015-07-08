using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum WaterReflectionFlags : uint
    {
        Reflection = 0x01,
        Refraction = 0x02
    }
}
