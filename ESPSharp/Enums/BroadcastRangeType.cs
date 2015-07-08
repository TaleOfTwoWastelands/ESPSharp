using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum BroadcastRangeType : uint
    {
        Radius,
        Everywhere,
        WorldspaceAndLinkedInteriors,
        LinkedInteriors,
        CurrentCellOnly
    }
}
