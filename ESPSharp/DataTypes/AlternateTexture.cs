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

namespace ESPSharp.DataTypes
{
    public partial class AlternateTexture : IESPSerializable, ICloneable, IReferenceContainer
    {
        partial void ReadNameBinary(ESPReader reader)
        {
            int length = reader.ReadInt32();
            Name = new String(reader.ReadChars(length));
        }

        partial void WriteNameBinary(ESPWriter writer)
        {
            writer.Write(Name.Length);
            writer.Write(Name.ToCharArray());
        }
    }
}