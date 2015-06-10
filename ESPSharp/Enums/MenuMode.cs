using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum MenuMode : uint
    {
        CharacterInterface = 1,
        Other,
        Console,
        Message = 1001,
        Inventory,
        Stats,
        HUDMainMenu,
        Loading = 1007,
        Container,
        Dialog,
        SleepWait = 1012,
        Pause,
        Lockpick,
        Quantity = 1016,
        LevelUp = 1027,
        PipboyRepair = 1035,
        RaceSex,
        Credits = 1047,
        CharGen,
        TextEdit,
        Barter,
        Surgery,
        Hacking,
        VATS,
        Computers,
        VendorRepair,
        Tutorial,
        SPECIALBook
    }
}
