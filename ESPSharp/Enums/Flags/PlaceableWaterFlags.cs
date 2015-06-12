using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    public enum PlaceableWaterFlags : uint
    {
        Reflects = 0x01,
        ReflectsActors = 0x02,
        ReflectsLand = 0x04,
        ReflectsLODLand = 0x08,
        RelfectsLODBuildings = 0x10,
        ReflectsTrees = 0x20,
        ReflectsSky = 0x40,
        ReflectsDynamicObjects = 0x80,
        ReflectsDeadBodies = 0x0100,
        Refracts = 0x0200,
        RefractsActors = 0x0400,
        RefractsLand = 0x0800,
        RefractsDynamicObjects = 0x010000,
        RefractsDeadBodies = 0x020000,
        SilhouetteReflections = 0x040000,
        Depth = 0x10000000,
        ObjectTextureCoordinates = 0x20000000,
        NoUnderwaterFog = 0x80000000
    }
}
