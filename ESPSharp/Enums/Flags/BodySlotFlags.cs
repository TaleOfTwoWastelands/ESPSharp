using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum BodySlotFlags : uint
    {
        Head = 0x00000001,
        Hair = 0x00000002,
        UpperBody = 0x00000004,
        LeftHand = 0x00000008,
        RightHand = 0x00000010,
        Weapon = 0x00000020,
        PipBoy = 0x00000040,
        Backpack = 0x00000080,
        Necklace = 0x00000100,
        Headband = 0x00000200,
        Hat = 0x00000400,
        Eyeglasses = 0x00000800,
        NoseRing = 0x00001000,
        Earrings = 0x00002000,
        Mask = 0x00004000,
        Choker = 0x00008000,
        MouthObject = 0x00010000,
        BodyAddon1 = 0x00020000,
        BodyAddon2 = 0x00040000,
        BodyAddon3 = 0x00080000
    }
}
