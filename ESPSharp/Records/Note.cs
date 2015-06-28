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
    public partial class Note : Record, IEditorID
    {
        partial void ReadEntryData(ESPReader reader)
        {
            switch (Type.Value)
            {
                case NoteType.Sound:
                    EntryData = new SimpleSubrecord<string>();
                    (EntryData as SimpleSubrecord<string>).ReadBinary(reader);
                    break;
                case NoteType.Text:
                    EntryData = new SimpleSubrecord<string>();
                    (EntryData as SimpleSubrecord<string>).ReadBinary(reader);
                    break;
                case NoteType.Image:
                    EntryData = new SimpleSubrecord<string>();
                    (EntryData as SimpleSubrecord<string>).ReadBinary(reader);
                    break;
                case NoteType.Voice:
                    EntryData = new RecordReference();
                    (EntryData as RecordReference).ReadBinary(reader);
                    break;
                default:
                    throw new Exception();
            }
        }

        partial void WriteEntryData(ESPWriter writer)
        {
            if (EntryData == null)
                return;

            EntryData.WriteBinary(writer);
        }

        partial void WriteEntryDataXML(XElement ele, ElderScrollsPlugin master)
        {
            if (EntryData == null)
                return;

            XElement subEle;

             switch (Type.Value)
            {
                case NoteType.Sound:
                    ele.TryPathTo("Text", true, out subEle);
                    (EntryData as SimpleSubrecord<string>).WriteXML(subEle, master);
                    break;
                case NoteType.Text:
                    ele.TryPathTo("Text", true, out subEle);
                    (EntryData as SimpleSubrecord<string>).WriteXML(subEle, master);
                    break;
                case NoteType.Image:
                    ele.TryPathTo("Text", true, out subEle);
                    (EntryData as SimpleSubrecord<string>).WriteXML(subEle, master);
                    break;
                case NoteType.Voice:
                    ele.TryPathTo("Topic", true, out subEle);
                    (EntryData as RecordReference).WriteXML(subEle, master);
                    break;
            }
        }

        partial void ReadEntryDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            switch (Type.Value)
            {
                case NoteType.Sound:
                    if (ele.TryPathTo("Text", false, out subEle))
                    {
                        EntryData = new SimpleSubrecord<string>();
                        (EntryData as SimpleSubrecord<string>).ReadXML(subEle, master);
                    }
                    break;
                case NoteType.Text:
                    if (ele.TryPathTo("Text", false, out subEle))
                    {
                        EntryData = new SimpleSubrecord<string>();
                        (EntryData as SimpleSubrecord<string>).ReadXML(subEle, master);
                    }
                    break;
                case NoteType.Image:
                    if (ele.TryPathTo("Text", false, out subEle))
                    {
                        EntryData = new SimpleSubrecord<string>();
                        (EntryData as SimpleSubrecord<string>).ReadXML(subEle, master);
                    }
                    break;
                case NoteType.Voice:
                    if (ele.TryPathTo("Topic", false, out subEle))
                    {
                        EntryData = new RecordReference();
                        (EntryData as RecordReference).ReadXML(subEle, master);
                    }
                    break;
            }
        }
    }
}