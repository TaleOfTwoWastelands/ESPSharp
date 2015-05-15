using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp
{
    public abstract class SubrecordCollection
    {
        public abstract void ReadBinary(ESPReader reader);
        public abstract void WriteBinary(ESPWriter writer);
        public abstract void WriteXML(XElement root);
        public abstract void ReadXML(XElement ele);
    }
}
