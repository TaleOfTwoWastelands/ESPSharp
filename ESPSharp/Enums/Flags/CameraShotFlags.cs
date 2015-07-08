using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum CameraShotFlags : uint
    {
        PositionFollowsLocation = 0x01,
        RotationFollowsTarget = 0x02,
        DoNotFollowBone = 0x04,
        FirstPersonCamera = 0x08,
        NoTracer = 0x10,
        StartAtTimeZero = 0x20
    }
}
