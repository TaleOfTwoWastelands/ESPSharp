using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class GameSetting : Record, IEditorID
    {
        public string EditorID { get; set; }
        public dynamic Value { get; set; }

        public override void ReadData(ESPReader reader, long dataEnd)
        {
            while (reader.BaseStream.Position < dataEnd)
            {
                string subTag = reader.PeekTag();

                switch (subTag)
                {
                    case "EDID":
                        EditorID = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "DATA":
                        switch (EditorID.First())
                        {
                            case 's':
                                Value = reader.ReadSimpleSubrecord<string>();
                                break;
                            case 'f':
                                Value = reader.ReadSimpleSubrecord<float>();
                                break;
                            default:
                                Value = reader.ReadSimpleSubrecord<int>();
                                break;
                        }
                        break;
                }
            }
        }

        public override void WriteData(ESPWriter writer)
        {
            writer.WriteSimpleSubrecord<string>(EditorID, "EDID");

            switch (EditorID.First())
            {
                case 's':
                    writer.WriteSimpleSubrecord<string>(Value, "DATA");
                    break;
                case 'f':
                    writer.WriteSimpleSubrecord<float>(Value, "DATA");
                    break;
                default:
                    writer.WriteSimpleSubrecord<int>(Value, "DATA");
                    break;
            }
        }

        public override void WriteDataXML(XElement ele)
        {
            if (EditorID != null)
                ele.AddSimpleSubrecord("EditorID", "EDID", EditorID);

            if (Value != null)
                switch (EditorID.First())
                {
                    case 's':
                        ele.AddSimpleSubrecord("Value", "DATA", (string)Value);
                        break;
                    case 'f':
                        ele.AddSimpleSubrecord("Value", "DATA", ((float)Value).ToString());
                        break;
                    default:
                        ele.AddSimpleSubrecord("Value", "DATA", ((int)Value).ToString());
                        break;
                }
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach (var subEle in ele.Elements())
            {
                switch (subEle.Attribute("Tag").Value)
                {
                    case "EDID":
                        EditorID = subEle.Value;
                        break;
                    case "DATA":
                        switch (EditorID.First())
                        {
                            case 's':
                                Value = subEle.Value;
                                break;
                            case 'f':
                                Value = subEle.ToSingle();
                                break;
                            default:
                                Value = subEle.ToInt32();
                                break;
                        }
                        break;
                }
            }
        }
    }
}
