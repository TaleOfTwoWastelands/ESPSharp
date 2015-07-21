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

namespace ESPSharp.SubrecordCollections
{
    public partial class EmbeddedScript : SubrecordCollection
    {
        partial void ReadLocalReference(ESPReader reader)
        {
            if (References == null)
                References = new List<Subrecord>();

            var localRef = new SimpleSubrecord<uint>();
            localRef.ReadBinary(reader);
            References.Add(localRef);
        }
        partial void ReadGlobalReference(ESPReader reader)
        {
            if (References == null)
                References = new List<Subrecord>();

            var globalRef = new RecordReference();
            globalRef.ReadBinary(reader);
            References.Add(globalRef);
        }
        partial void WriteReferences(ESPWriter writer)
        {
            if (References != null)
                foreach (var reference in References)
                    reference.WriteBinary(writer);
        }
        partial void WriteReferencesXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (References != null)
            {
                ele.TryPathTo("References", true, out subEle);
                foreach (var reference in References)
                {
                    XElement newEle = new XElement("Reference");
                    reference.WriteXML(newEle, master);
                    subEle.Add(newEle);
                }
            }            
        }
        partial void ReadReferencesXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("References", false, out subEle))
            {
                if (References == null)
                    References = new List<Subrecord>();

                foreach (XElement e in subEle.Elements())
                {
                    if (e.Attribute("Tag").Value == "SCRV")
                    {
                        var reference = new SimpleSubrecord<uint>();
                        reference.ReadXML(e, master);
                        References.Add(reference);
                    }
                    else
                    {
                        var reference = new RecordReference();
                        reference.ReadXML(e, master);
                        References.Add(reference);
                    }
                }
            }
        }
    }
}