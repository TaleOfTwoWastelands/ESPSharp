using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum ServicesFlag : uint
    {
        Weapons = 0x01,
        Armor = 0x02,
        Alcohol = 0x04,
        Books = 0x08,
        Food = 0x10,
        Chems = 0x20,
        Stimpacks = 0x40,
        Unk_Lights = 0x80,
        Miscellaneous = 0x400,
        Unk_Potions = 0x2000,
        Training = 0x4000,
        Recharge = 0x10000,
        Repair = 0x20000
    }
}
