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
    public partial class AlternateTexture : IESPSerializable, ICloneable<AlternateTexture>, IReferenceContainer
    {
        partial void ReadData(ESPReader reader)
        {
            int length = reader.ReadInt32();
            Name = new String(reader.ReadChars(length));
            TextureSet.ReadBinary(reader);
            Index = reader.ReadInt32();
        }

        partial void WriteData(ESPWriter writer)
        {
            writer.Write(Name.Length);
            writer.Write(Name.ToCharArray());
            TextureSet.WriteBinary(writer);
            writer.Write(Index);
        }
    }
}