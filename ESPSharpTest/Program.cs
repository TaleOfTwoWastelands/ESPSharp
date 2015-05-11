using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string testFile = "FalloutNV";
        ElderScrollsPlugin pluggy = new ElderScrollsPlugin();

        //using (FileStream stream = new FileStream(testFile + ".esm", FileMode.Open))
        //using (BinaryReader reader = new BinaryReader(stream))
        //{
        //    pluggy.ReadBinary(reader);
        //}

        //Directory.CreateDirectory(testFile);
        //pluggy.WriteXML(testFile);

        pluggy = new ElderScrollsPlugin();
        pluggy.ReadXML(testFile + "\\0.xml");

        using (FileStream stream = new FileStream("NEW" + testFile + ".esm", FileMode.Create, FileAccess.ReadWrite))
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            pluggy.WriteBinary(writer);
        }
    }
}
