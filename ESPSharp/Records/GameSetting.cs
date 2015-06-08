using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;

namespace ESPSharp.Records
{
    public partial class GameSetting : Record, IEditorID
    {
        partial void ReadValue(ESPReader reader)
        {
            if (Value == null)
                switch (EditorID.Value.First())
                {
                    case 'f':
                        Value = new SimpleSubrecord<float>();
                        break;
                    case 's':
                        Value = new SimpleSubrecord<string>();
                        break;
                    default:
                        Value = new SimpleSubrecord<int>();
                        break;
                }

            Value.ReadBinary(reader);
        }

        partial void WriteValue(ESPWriter writer)
        {
            if (Value != null)
                Value.WriteBinary(writer);
        }

        partial void WriteValueXML(XElement ele)
        {
            XElement subEle;
            if (Value != null)
            {
                ele.TryPathTo("Value", true, out subEle);
                Value.WriteXML(subEle);
            }
        }

        partial void ReadValueXML(XElement ele)
        {
            XElement subEle;

            if (ele.TryPathTo("Value", false, out subEle))
            {
                if (Value == null)
                    switch (EditorID.Value.First())
                    {
                        case 'f':
                            Value = new SimpleSubrecord<float>();
                            break;
                        case 's':
                            Value = new SimpleSubrecord<string>();
                            break;
                        default:
                            Value = new SimpleSubrecord<int>();
                            break;
                    }

                Value.ReadXML(subEle);
            }
        }
    }
}
