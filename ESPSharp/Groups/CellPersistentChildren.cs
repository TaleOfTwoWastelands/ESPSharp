using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class CellPersistentChildren : CellGroup
    {
        public CellPersistentChildren()
        {
            type = GroupType.CellPersistentChildren;
        }

        public override string ToString()
        {
            return (base.ToString() + " - Persistent Children");
        }
    }
}
