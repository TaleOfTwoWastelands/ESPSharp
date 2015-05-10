using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class ElderScrollsPlugin : IESPSerializable
    {
        public Record Header;
        public List<Group> Groups = new List<Group>();

        public void WriteXML(string destinationFolder)
        {
            Header.WriteXML(destinationFolder);

            foreach (Group group in Groups)
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir);
            }
        }

        public void ReadXML(string sourceFile)
        {
            Header = Record.CreateRecord(XDocument.Load(sourceFile));
            Header.ReadXML(sourceFile);

            foreach (var folder in Directory.EnumerateDirectories(Path.GetDirectoryName(sourceFile), "*.*", SearchOption.TopDirectoryOnly))
            {
                string xmlLocation = Path.Combine(folder, "GroupHeader.metadata");
                Group newGroup = Group.CreateGroup(XDocument.Load(xmlLocation));
                newGroup.ReadXML(xmlLocation);

                Groups.Add(newGroup);
            }
        }

        public void WriteBinary(BinaryWriter writer)
        {
            Header.WriteBinary(writer);

            foreach (var group in Groups)
                group.WriteBinary(writer);
        }

        public void ReadBinary(BinaryReader reader)
        {
            Header = Record.CreateRecord(reader);
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
