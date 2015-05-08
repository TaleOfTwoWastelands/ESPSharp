using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class ExteriorCellSubBlock : ExteriorCellBlock
    {
        public ExteriorCellSubBlock()
        {
            type = GroupType.ExteriorCellSubBlock;
        }

        public override string ToString()
        {
            return string.Format("Sub-Block {0}, {1}", CoordX, CoordY);
        }
    }
}
