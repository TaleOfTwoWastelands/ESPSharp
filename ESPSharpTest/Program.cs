using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp;
using System.IO;
using System.IO.MemoryMappedFiles;

class Program
{
    static void Main(string[] args)
    {
        string testFile = "LonesomeRoad.esm";
        string outDir = Path.GetFileNameWithoutExtension(testFile);
        ElderScrollsPlugin pluggy = new ElderScrollsPlugin();

        DateTime startTimeAll = DateTime.Now;
        DateTime startTime = startTimeAll;

        Console.WriteLine("Loading binary...");

        pluggy.ReadBinary(testFile);

        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));
        startTime = DateTime.Now;
        Console.WriteLine("Writing XML...");

        Directory.CreateDirectory(outDir);
        pluggy.WriteXML(outDir);

        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));

        ElderScrollsPlugin.Clear();

        startTime = DateTime.Now;
        Console.WriteLine("Loading XML...");

        pluggy = ElderScrollsPlugin.ReadXML(outDir);


        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));
        startTime = DateTime.Now;
        Console.WriteLine("Writing binary...");

        using (FileStream stream = new FileStream("NEW" + testFile, FileMode.Create, FileAccess.ReadWrite))
        using (ESPWriter writer = new ESPWriter(stream))
        {
            pluggy.WriteBinary(writer);
        }

        Console.WriteLine("...Done in: " + (DateTime.Now - startTime).ToString(@"mm\:ss\.ffff"));

        Console.WriteLine("Total Time: " + (DateTime.Now - startTimeAll).ToString(@"mm\:ss\.ffff"));

        Console.ReadLine();
    }
}
