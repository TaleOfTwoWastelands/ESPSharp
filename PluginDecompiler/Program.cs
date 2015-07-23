using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp;
using System.IO;
using System.IO.MemoryMappedFiles;
using Microsoft.Win32;

class Program
{
    static void Main(string[] args)
    {
        if (File.Exists("PluginSearchLocations.csv"))
        {
            using (FileStream stream = new FileStream("PluginSearchLocations.csv", FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                string file;
                bool recursive;

                while(!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var split = line.Split(',');
                    if (split.Count() > 0)
                    {
                        file = split[0];
                        if (split.Count() > 1)
                            recursive = Boolean.Parse(split[1]);
                        else
                            recursive = false;

                        ElderScrollsPlugin.pluginLocations.Add(new KeyValuePair<string, bool>(file, recursive));
                    }
                }
            }
        }

        foreach (string file in args)
        {
            string outDir = Path.GetFileNameWithoutExtension(file);
            ElderScrollsPlugin plugin = new ElderScrollsPlugin();
            if (outDir == Path.GetFileName(file))
            {
                plugin = ElderScrollsPlugin.ReadXML(file);

                string outFile;
                if (plugin.Header.Record.Flags.HasFlag(ESPSharp.Enums.Flags.RecordFlag.IsMasterFile))
                    outFile = Path.ChangeExtension(file, "esm");
                else
                    outFile = Path.ChangeExtension(file, "esp");

                using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite))
                using (ESPWriter writer = new ESPWriter(stream))
                {
                    plugin.WriteBinary(writer);
                }
            }
            else
            {
                plugin.ReadBinary(file);

                if (Directory.Exists(outDir))
                    Directory.Delete(outDir, true);
                Directory.CreateDirectory(outDir);

                plugin.WriteXML(outDir);
            }
        }
    }
}
