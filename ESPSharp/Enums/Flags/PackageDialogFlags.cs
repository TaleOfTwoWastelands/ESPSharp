using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum PackageDialogFlags : uint
    {
        NoHeadtracking = 0x01,
        DontControlTargetMovement = 0x0100
    }
}
