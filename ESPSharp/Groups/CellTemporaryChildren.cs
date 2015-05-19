using System;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class CellTemporaryChildren : CellGroup
    {
        public CellTemporaryChildren()
        {
            type = GroupType.CellTemporaryChildren;
        }

        public override string ToString()
        {
            return (base.ToString() + " - Temporary Children");
        }
    }
}
