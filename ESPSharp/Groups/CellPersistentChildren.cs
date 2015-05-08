using System;
using System.IO;
using System.Xml.Linq;

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
