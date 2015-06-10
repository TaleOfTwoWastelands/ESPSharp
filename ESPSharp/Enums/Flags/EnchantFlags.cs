using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    public enum EnchantFlags : byte
    {
        NoAutoCalc = 0x01,
        AutoCalc = 0x02,
        HideEffect = 0x04
    }
}
