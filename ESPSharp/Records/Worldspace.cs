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
    public partial class Worldspace : Record, IEditorID
    {
        partial void ReadOffsetData(ESPReader reader)
        {
            OffsetData = new SimpleSubrecord<byte[]>();
            if (OffsetDataSize == null)
                OffsetData.ReadBinary(reader);
            else
            {
                OffsetData.Tag = reader.ReadTag();
                reader.ReadUInt16();
                OffsetData.Value = reader.ReadBytes((int)OffsetDataSize.Value);
            }

        }

        partial void WriteOffsetData(ESPWriter writer)
        {
            if (OffsetDataSize == null)
                OffsetData.WriteBinary(writer);
            else
            {
                writer.Write(Utility.DesanitizeTag(OffsetData.Tag).ToCharArray());
                writer.Write((ushort)0);
                writer.Write(OffsetData.Value);
            }
        }
    }
}