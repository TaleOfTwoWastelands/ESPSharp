using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.Subrecords
{
    public partial class NavigationMapInfo : Subrecord, ICloneable<NavigationMapInfo>, IReferenceContainer
    {
        partial void ReadUnknown2Binary(ESPReader reader)
        {
            Unknown2 = reader.ReadBytes(size - 16);
        }
    }
}