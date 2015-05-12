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

        DateTime startTimeAll = DateTime.Now;
        DateTime startTime = startTimeAll;

        //Console.WriteLine("Loading binary...");

        //using (FileStream stream = new FileStream(testFile + ".esm", FileMode.Open))
        //using (BinaryReader reader = new BinaryReader(stream, Encoding.GetEncoding("ISO-8859-1")))
        //{
        //    pluggy.ReadBinary(reader);
        //}

        //Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));
        //startTime = DateTime.Now;
        //Console.WriteLine("Writing XML...");

        //Directory.CreateDirectory(testFile);
        //pluggy.WriteXML(testFile);

        //Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));
        //startTime = DateTime.Now;
        Console.WriteLine("Loading XML...");

        pluggy = ElderScrollsPlugin.ReadXML(testFile);


        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));
        startTime = DateTime.Now;
        Console.WriteLine("Writing binary...");

        using (FileStream stream = new FileStream("NEW" + testFile + ".esm", FileMode.Create, FileAccess.ReadWrite))
        using (BinaryWriter writer = new BinaryWriter(stream, Encoding.GetEncoding("ISO-8859-1")))
        {
            pluggy.WriteBinary(writer);
        }

        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));

        Console.WriteLine("Total Time: " + (DateTime.Now - startTimeAll).ToString(@"mm\:ss\.ffff"));

        Console.ReadLine();
    }
}
