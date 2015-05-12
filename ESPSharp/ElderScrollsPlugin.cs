﻿using System;
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
            Header.WriteXML(Path.Combine(destinationFolder, "0.xml"));

            foreach (Group group in Groups)
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir);
            }
        }

        public static ElderScrollsPlugin ReadXML(string sourceFolder)
        {
            ElderScrollsPlugin outPlug = new ElderScrollsPlugin();
            outPlug.Header = Record.ReadXML(Path.Combine(sourceFolder, "0.xml"));

            foreach (var folder in Directory.EnumerateDirectories(sourceFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                Group newGroup = Group.ReadXML(folder);

                outPlug.Groups.Add(newGroup);
            }

            return outPlug;
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
