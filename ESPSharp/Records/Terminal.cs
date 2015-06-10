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
    public partial class Terminal : Record, IEditorID
    {
        protected override void XMLPreProcessing(XElement root, string sourceFile)
        {
        }

        protected override void XMLPostProcessing(XElement root, string destinationFile)
        {
        }
    }
}