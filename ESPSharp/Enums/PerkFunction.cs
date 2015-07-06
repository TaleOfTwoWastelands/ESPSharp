using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESPSharp.Enums
{
    public enum PerkFunction : byte
    {
        SetValue = 1,
        AddValue,
        MultiplyValue,
        AddRangeToValue,
        AddActorValueMult,
        AbsoluteValue,
        NegativeAbsoluteValue,
        AddLeveledList,
        AddActivateChoice
    }
}
