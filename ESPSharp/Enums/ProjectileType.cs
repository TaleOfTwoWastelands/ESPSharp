using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum ProjectileType : ushort
    {
        Missile = 1,
        Lobber,
        Beam = 4,
        Flame = 8,
        ContinuousBeam = 16
    }
}
