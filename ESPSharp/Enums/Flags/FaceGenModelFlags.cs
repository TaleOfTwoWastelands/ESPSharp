using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum FaceGenModelFlags : byte
    {
        Head = 0x01,
        Torso = 0x02,
        RightHand = 0x04,
        LeftHand = 0x08
    }
}
