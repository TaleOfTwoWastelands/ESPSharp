using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum MessageFlags : uint
    {
        MessageBox = 0x01,
        AutoDisplay = 0x02
    }
}
