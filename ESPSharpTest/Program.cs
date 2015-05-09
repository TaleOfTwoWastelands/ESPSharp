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
        string testFile = "FalloutNV.esm";
        ElderScrollsPlugin pluggy = new ElderScrollsPlugin();

        using (FileStream stream = new FileStream(testFile, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            pluggy.ReadBinary(reader);
        }

        using (FileStream stream = new FileStream("NEW" + testFile, FileMode.Create, FileAccess.ReadWrite))
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            pluggy.WriteBinary(writer);
        }
    }
}
