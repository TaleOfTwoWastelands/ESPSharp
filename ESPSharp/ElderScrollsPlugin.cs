using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public class ElderScrollsPlugin
    {
        public Record Header;
        public List<Group> Groups = new List<Group>();

        public void WriteXML(string destinationFolder)
        {
            Header.WriteXML(Path.Combine(destinationFolder, "Header.xml"));

            foreach (Group group in Groups.Where(g => g.ToString() != "Interior Cells" && g.ToString() != "Worldspaces" && g.ToString() != "Dialog Topics"))
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir);
            }
        }

        public static ElderScrollsPlugin ReadXML(string sourceFolder)
        {
            ElderScrollsPlugin outPlug = new ElderScrollsPlugin();
            outPlug.Header = Record.ReadXML(Path.Combine(sourceFolder, "Header.xml"));

            foreach (var folder in Directory.EnumerateDirectories(sourceFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                Group newGroup = Group.ReadXML(folder);

                outPlug.Groups.Add(newGroup);
            }

            return outPlug;
        }

        public void WriteBinary(ESPWriter writer)
        {
            Header.WriteBinary(writer);

            foreach (var group in Groups)
                group.WriteBinary(writer);
        }

        public void ReadBinary(ESPReader reader)
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
