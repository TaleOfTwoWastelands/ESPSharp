using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp.Interfaces
{
    public interface IESPSerializable
    {
        void WriteXML(XElement ele);
        void ReadXML(XElement ele);
        void WriteBinary(ESPWriter writer);
        void ReadBinary(ESPReader reader);
    }
}
