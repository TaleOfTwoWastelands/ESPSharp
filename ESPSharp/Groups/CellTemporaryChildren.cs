using System;
using System.IO;
using System.Xml.Linq;

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
