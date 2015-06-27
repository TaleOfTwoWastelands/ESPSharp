using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum IngestibleFlags : byte
    {
        NoAutoCalc = 0x01,
        FoodItem = 0x02,
        Medicine = 0x04
    }
}
