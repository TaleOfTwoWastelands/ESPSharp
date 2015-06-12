using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum UnitFromWaterType : uint
    {
        Above_AtLeast,
        Above_AtMost,
        Below_AtLeast,
        Below_AtMost,
        Either_AtLeast,
        Either_AtMost,
        Either_AtMostAbove,
        Either_AtMostBelow
    }
}
