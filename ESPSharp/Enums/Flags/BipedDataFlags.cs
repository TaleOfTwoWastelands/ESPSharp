using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum BipedDataFlags
    {
        Unknown0 = 0x01,
        Unknown1 = 0x02,
        HasBackpack = 0x04,
        Medium = 0x08,
        Unknown4 = 0x10,
        PowerArmor = 0x20,
        NonPlayable = 0x40,
        Heavy = 0x80
    }
}
