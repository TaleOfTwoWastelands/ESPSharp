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
        public Header Header = new Header();
        public List<Group> Groups = new List<Group>();

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
            Header.WriteBinary(writer);
            foreach (var group in Groups)
                group.WriteBinary(writer);
        }

        public void ReadBinary(BinaryReader reader)
        {
            Header.ReadBinary(reader);
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var group = Group.CreateGroup(reader);
                group.ReadBinary(reader);

                Groups.Add(group);
            }
        }
    }
}
