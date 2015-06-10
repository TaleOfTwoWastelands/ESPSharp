using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum SpellType : uint
    {
        ActorEffect = 0,
        Disease,
        Power,
        LesserPower,
        Ability,
        Poison,
        Addiction = 10
    }
}
