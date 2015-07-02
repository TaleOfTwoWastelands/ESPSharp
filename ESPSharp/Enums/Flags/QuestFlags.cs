using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum QuestFlags : byte
    {
        StartGameEnabled = 0x01,
        AllowRepeatedConversationTopics = 0x04,
        AllowRepeatedStages = 0x08
    }
}
