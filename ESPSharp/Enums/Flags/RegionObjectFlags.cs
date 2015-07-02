using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum RegionObjectFlags : byte
    {
        ConformToSlope = 0x01,
        PaintVertices = 0x02,
        SizeVariancePlusOrMinus = 0x04,
        XAngleVariancePlusOrMinus = 0x08,
        YAngleVariancePlusOrMinus = 0x10,
        ZAngleVariancePlusOrMinus = 0x20,
        Tree = 0x40,
        HugeRock = 0x80
    }
}
