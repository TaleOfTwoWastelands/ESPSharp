using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ParentWorldspaceFlags : ushort
    {
        UseLandData = 0x01,
        UseLODData = 0x02,
        UseMapData = 0x04,
        UseWaterData = 0x08,
        UseClimateData = 0x10,
        UseImageSpaceData = 0x20
    }
}
