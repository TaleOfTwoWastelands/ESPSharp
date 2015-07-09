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
    public partial class NavigationConnectionInfo : Subrecord, ICloneable<NavigationConnectionInfo>, IReferenceContainer
    {
        public FormID Unknown1 { get; set; }
        public List<FormID> Unknown2 { get; set; }
        public List<FormID> Unknown3 { get; set; }
        public List<FormID> Doors { get; set; }

        public NavigationConnectionInfo()
        {
            Unknown1 = new FormID();
            Unknown2 = new List<FormID>();
            Unknown3 = new List<FormID>();
            Doors = new List<FormID>();
        }

        public NavigationConnectionInfo(FormID Unknown1, List<FormID> Unknown2, List<FormID> Unknown3, List<FormID> Unknown4)
        {
            this.Unknown1 = Unknown1;
            this.Unknown2 = Unknown2;
            this.Unknown3 = Unknown3;
            this.Doors = Unknown4;
        }

        public NavigationConnectionInfo(NavigationConnectionInfo copyObject)
        {
            Unknown1 = copyObject.Unknown1.Clone();

            Unknown2 = new List<FormID>();
            foreach (var form in copyObject.Unknown2)
                Unknown2.Add(form.Clone());

            Unknown3 = new List<FormID>();
            foreach (var form in copyObject.Unknown3)
                Unknown3.Add(form.Clone());

            Doors = new List<FormID>();
            foreach (var form in copyObject.Doors)
                Doors.Add(form.Clone());
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream))
            {
                try
                {
                    uint count;
                    FormID form;

                    Unknown1.ReadBinary(subReader);

                    count = subReader.ReadUInt32();
                    for (int i = 0; i < count; i++)
                    {
                        form = new FormID();
                        form.ReadBinary(subReader);
                        Unknown2.Add(form);
                    }

                    count = subReader.ReadUInt32();
                    for (int i = 0; i < count; i++)
                    {
                        form = new FormID();
                        form.ReadBinary(subReader);
                        Unknown3.Add(form);
                    }

                    count = subReader.ReadUInt32();
                    for (int i = 0; i < count; i++)
                    {
                        form = new FormID();
                        form.ReadBinary(subReader);
                        Doors.Add(form);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            Unknown1.WriteBinary(writer);

            writer.Write(Unknown2.Count);
            foreach (var form in Unknown2)
                form.WriteBinary(writer);

            writer.Write(Unknown3.Count);
            foreach (var form in Unknown3)
                form.WriteBinary(writer);

            writer.Write(Doors.Count);
            foreach (var form in Doors)
                form.WriteBinary(writer);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;
            XElement e;

            ele.TryPathTo("Unknown1", true, out subEle);
            Unknown1.WriteXML(subEle, master);

            ele.TryPathTo("Unknown2", true, out subEle);
            foreach (var form in Unknown2)
            {
                e = new XElement("Form");
                form.WriteXML(e, master);
                subEle.Add(e);
            }

            ele.TryPathTo("Unknown3", true, out subEle);
            foreach (var form in Unknown3)
            {
                e = new XElement("Form");
                form.WriteXML(e, master);
                subEle.Add(e);
            }

            ele.TryPathTo("Doors", true, out subEle);
            foreach (var form in Doors)
            {
                e = new XElement("Door");
                form.WriteXML(e, master);
                subEle.Add(e);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;
            FormID form;

            if (ele.TryPathTo("Unknown1", false, out subEle))
            {
                Unknown1.ReadXML(subEle, master);
            }

            if (ele.TryPathTo("Unknown2", false, out subEle))
            {
                foreach(var e in subEle.Elements())
                {
                    form = new FormID();
                    form.ReadXML(e, master);
                    Unknown2.Add(form);
                }
            }

            if (ele.TryPathTo("Unknown3", false, out subEle))
            {
                foreach (var e in subEle.Elements())
                {
                    form = new FormID();
                    form.ReadXML(e, master);
                    Unknown3.Add(form);
                }
            }

            if (ele.TryPathTo("Doors", false, out subEle))
            {
                foreach (var e in subEle.Elements())
                {
                    form = new FormID();
                    form.ReadXML(e, master);
                    Doors.Add(form);
                }
            }
        }

        public NavigationConnectionInfo Clone()
        {
            return new NavigationConnectionInfo(this);
        }

    }
}
