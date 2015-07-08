using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    [Flags]
    public enum BodyPartType : byte
    {
        Torso,
        Head1,
        Head2,
        LeftArm1,
        LeftArm2,
        RightArm1,
        RightArm2,
        LeftLeg1,
        LeftLeg2,
        LeftLeg3,
        RightLeg1,
        RightLeg2,
        RightLeg3,
        Brain,
        Weapon
    }
}
