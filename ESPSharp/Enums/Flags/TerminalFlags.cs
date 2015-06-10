using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum TerminalFlags : byte
    {
        Leveled = 0x01,
        Unlocked = 0x02,
        AlternateColors = 0x04,
        HideWelcomeText = 0x08
    }
}
