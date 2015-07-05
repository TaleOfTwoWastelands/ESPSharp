using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ImageSpaceFlags : byte
    {
        Saturation = 0x01,
        Contrast = 0x02,
        Tint = 0x04,
        Brightness = 0x08
    }
}
