using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ESPSharp
{
    interface IESPSerializable
    {
        void WriteXML(string destinationFolder);
        void ReadXML(string sourceFile);
        void WriteBinary(BinaryWriter writer);
        void ReadBinary(BinaryReader reader);
    }
}
