using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ESPSharp
{
    public class ElderScrollsPlugin : IESPSerializable
    {
        public Header Header;
        public List<Group> Groups;

        public void WriteXML(string destinationFolder)
        {
            throw new NotImplementedException();
        }

        public void ReadXML(string sourceFile)
        {
            throw new NotImplementedException();
        }

        public void WriteBinary(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public void ReadBinary(BinaryReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
