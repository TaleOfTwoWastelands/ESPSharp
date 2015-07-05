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
    public partial class Water : Record, IEditorID
    {
        partial void ReadDamage(ESPReader reader)
        {
            var tag = reader.ReadTag();
            var size = reader.ReadUInt16();
            reader.BaseStream.Seek(-6, SeekOrigin.Current);

            if (size == 2)
            {
                Damage = new SimpleSubrecord<ushort>();
                Damage.ReadBinary(reader);
            }
            else
            {
                Data = new WaterData();
                Data.ReadBinary(reader);
                Data.Tag = "DNAM";

                reader.BaseStream.Seek(-2, SeekOrigin.Current);

                Damage = new SimpleSubrecord<ushort>();
                Damage.Tag = "DATA";
                Damage.Value = reader.ReadUInt16();
            }
        }
    }
}