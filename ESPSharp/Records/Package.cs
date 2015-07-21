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

namespace ESPSharp.Records
{
    public partial class Package : Record, IEditorID
    {
        partial void WriteDummyIgnore(ESPWriter writer)
        {
            if (Location2 != null)
                Location2.WriteBinary(writer);
        }
    }
}