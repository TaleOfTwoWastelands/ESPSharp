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
        string testFile = "GunRunnersArsenal.esm";
        string outFile = "NEWGunRunnersArsenal.esm";
        ElderScrollsPlugin pluggy = new ElderScrollsPlugin();

        using (FileStream stream = new FileStream(testFile, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            pluggy.ReadBinary(reader);
        }

        Directory.CreateDirectory("GunRunnersArsenal");
        pluggy.WriteXML("GunRunnersArsenal");

        pluggy = new ElderScrollsPlugin();
        pluggy.ReadXML("GunRunnersArsenal\\0.xml");

        using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite))
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            pluggy.WriteBinary(writer);
        }
    }
}
