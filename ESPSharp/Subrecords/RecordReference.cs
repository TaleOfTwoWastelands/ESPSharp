using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp.Subrecords
{
    public class RecordReference : Subrecord, IReferenceContainer
    {
        FormID Reference { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Reference = reader.Read<FormID>();
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Reference);
        }

        protected override void WriteDataXML(XElement ele)
        {
            Reference.WriteXML(ele);
        }

        protected override void ReadDataXML(XElement ele)
        {
            Reference = new FormID();
            Reference.ReadXML(ele);
        }
    }
}