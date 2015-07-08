using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum LightTemplateInheritFlags : uint
    {
        AmbientColor = 0x01,
        DirectionalColor = 0x02,
        FogColor = 0x04,
        FogNear = 0x08,
        FogFar = 0x10,
        DirectionalRotation = 0x20,
        DirectionalFade = 0x40,
        FogClipDistance = 0x80,
        FogPower = 0x0100
    }
}
