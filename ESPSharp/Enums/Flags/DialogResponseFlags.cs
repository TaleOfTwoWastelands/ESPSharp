using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum DialogResponseFlags : ushort
    {
        Goodbye = 0x01,
        Random = 0x02,
        SayOnce = 0x04,
        RunImmediately = 0x08,
        InfoRefusal = 0x10,
        RandomEnd = 0x20,
        RunForRumors = 0x40,
        SpeechChallenge = 0x80,
        SayOnceADay = 0x0100,
        AlwaysDarken = 0x0200,
        LowIntelligence = 0x1000,
        HighIntelligence = 0x2000
    }
}
