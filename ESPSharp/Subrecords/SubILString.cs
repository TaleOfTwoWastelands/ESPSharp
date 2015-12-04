
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
    public class SubILString : SubString
    {
        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
            {
                try
                {
                    if (false)//subReader.Plugin.Header.Flags.HasFlag(RecordFlag.Localized) && size == 4)
                    {
                        LocalizedID = subReader.ReadUInt32();
                        if (LocalizedID == 0)
                            Value = "";
                        else
                            Value = LocalizedStrings.GetLocalizedString(LocalizedID, subReader.Plugin.Name.ToLower(), LocalizedStringType.ILStrings);
                    }
                    else
                    {
                        Value = subReader.ReadString();
                    }
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
