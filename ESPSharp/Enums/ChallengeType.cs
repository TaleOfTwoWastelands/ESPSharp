using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum ChallengeType : uint
    {
        KillFromAFormList,
        KillASpecificFormID,
        KillAnyInACategory,
        HitAnEnemy,
        DiscoverAMapMarker,
        UseAnItem,
        AcquireAnItem,
        UseASkill,
        DoDamage,
        UseAnItemFromAList,
        AcquireAnItemFromAList,
        MiscellaneousStat,
        CraftUsingAnItem,
        ScriptedChallenge
    }
}
