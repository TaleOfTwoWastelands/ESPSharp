using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum GrassFlags : byte
    {
        VertexLighting = 0x01,
        UniformScaling = 0x02,
        FitToSlope = 0x04
    }
}
