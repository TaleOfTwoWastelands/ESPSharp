using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum ScriptType : ushort
    {
        Object,
        Quest,
        Effect = 0x0100
    }
}
