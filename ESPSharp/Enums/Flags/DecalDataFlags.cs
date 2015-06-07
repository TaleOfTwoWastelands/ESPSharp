using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum DecalDataFlags : byte
    {
        Parallax = 0x00000001,
        AlphaBlending = 0x00000002,
        AlphaTesting = 0x00000004,
        Unknown8 = 0x00000008,
        Unknown10 = 0x00000010,
        Unknown20 = 0x00000020,
        Unknown40 = 0x00000040,
        Unknown80 = 0x00000080
    }
}
