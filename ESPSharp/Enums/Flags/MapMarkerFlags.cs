using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum MapMarkerFlags : byte
    {
        Visible = 0x01,
        CanTravelTo = 0x02,
        HiddenFromShowAll = 0x04
    }
}
