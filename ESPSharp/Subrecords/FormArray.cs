using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp.Subrecords
{
    public class FormArray : Subrecord, IReferenceContainer
    {
        List<FormID> Forms { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Forms = new List<FormID>();

            for (int i = 0; i < size/4; i++)
                Forms.Add(reader.ReadFormID());
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var id in Forms)
                writer.Write(id);
        }

        protected override void WriteDataXML(XElement ele)
        {
            foreach (var id in Forms)
                ele.Add(new XElement("Form", id));
        }

        protected override void ReadDataXML(XElement ele)
        {
            Forms = new List<FormID>();

            foreach (var subEle in ele.Elements("Form"))
            {
                FormID id = new FormID();
                id.ReadXML(subEle);
                Forms.Add(id);
            }
        }
    }
}
