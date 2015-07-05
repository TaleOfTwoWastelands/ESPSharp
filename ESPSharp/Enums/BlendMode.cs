using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum BlendMode : uint
    {
        Zero = 1,
        One,
        SourceColor,
        SourceInverseColor,
        SourceAlpha,
        SourceInvertedAlpha,
        DestinationAlpha,
        DestinationInvertedAlpha,
        DestinationColor,
        DestinationInverseColor,
        SourceAlphaSAT
    }
}
