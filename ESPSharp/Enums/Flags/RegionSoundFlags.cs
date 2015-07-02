using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum RegionSoundFlags : uint
    {
        Pleasant = 0x01,
        Cloudy = 0x02,
        Rainy = 0x04,
        Snowy = 0x08
    }
}
