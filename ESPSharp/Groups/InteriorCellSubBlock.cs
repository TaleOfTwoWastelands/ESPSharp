using System;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    class InteriorCellSubBlock : InteriorCellBlock
    {
        public InteriorCellSubBlock()
        {
            type = GroupType.InteriorCellSubBlock;
        }

        public override string ToString()
        {
            return "Sub-Block " + Index;
        }
    }
}
