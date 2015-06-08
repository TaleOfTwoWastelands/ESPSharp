using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum SoundDataFlags : uint
    {
        RandomFrequencyShift = 0x01,
        PlayAtRandom = 0x02,
        EnvironmentIgnored = 0x04,
        RandomLocation = 0x08,
        Loop = 0x10,
        MenuSound = 0x20,
        _2D = 0x40,
        _360LFE = 0x80,
        DialogueSound = 0x0100,
        EnvelopeFast = 0x0200,
        EnvelopeSlow = 0x0400,
        _2DRadius = 0x0800,
        MuteWhenSubmerged = 0x1000,
        StartAtRandomPosition = 0x2000
    }
}
