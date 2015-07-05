using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum AmbushPackageFlags : uint
    {
        HideWhileAmbushing = 0x01
    }
}
