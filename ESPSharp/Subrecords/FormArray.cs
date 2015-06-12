using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ESPSharp.DataTypes;
using ESPSharp.Interfaces;

namespace ESPSharp.Subrecords
{
    public class FormArray : Subrecord, IReferenceContainer, ICloneable<FormArray>
    {
        List<FormID> Forms { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Forms = new List<FormID>();

            for (int i = 0; i < size / 4; i++)
                Forms.Add(reader.Read<FormID>());
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var id in Forms)
                writer.Write(id);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var id in Forms)
            {
                XElement subEle = new XElement("Form");
                id.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Forms = new List<FormID>();

            foreach (var subEle in ele.Elements("Form"))
            {
                FormID id = new FormID();
                id.ReadXML(subEle, master);
                Forms.Add(id);
            }
        }

        FormArray ICloneable<FormArray>.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
