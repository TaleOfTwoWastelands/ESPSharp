using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class CellVisibleDistantChildren : CellGroup
    {
        public CellVisibleDistantChildren()
        {
            type = GroupType.CellVisibleDistantChildren;
        }

        public override string ToString()
        {
            return (base.ToString() + " - Visible When Distant Children");
        }
    }
}
