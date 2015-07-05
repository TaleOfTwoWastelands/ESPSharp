using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum FalloutBehaviorFlags : ushort
    {
        HellosToPlayer = 0x01,
        RandomConversations = 0x02,
        ObserveCombatBehavior = 0x04,
        ReactionToPlayerActions = 0x10,
        FriendlyFireComments = 0x20,
        AggroRadiusBehavior = 0x40,
        AllowIdleChatter = 0x80,
        AvoidRadiation = 0x0100
    }
}
