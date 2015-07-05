using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum EffectShaderFlags : byte
    {
        NoMembraneShader = 0x01,
        NoParticleShader = 0x08,
        EdgeEffectInverse = 0x10,
        MembraneShaderAffectsSkinOnly = 0x20
    }
}
