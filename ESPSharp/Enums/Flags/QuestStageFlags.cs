using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum QuestStageFlags : byte
    {
        CompleteQuest = 0x01,
        FailQuest = 0x02
    }
}
