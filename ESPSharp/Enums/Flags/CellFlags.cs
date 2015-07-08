using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum CellFlags : byte
    {
        IsInteriorCell = 0x01,
        HasWater = 0x02,
        InvertFastTravelBehaviour = 0x04,
        NoLODWater = 0x08,
        PublicPlace = 0x20,
        HandChanged = 0x40,
        BehaveLikeExterior = 0x80
    }
}
