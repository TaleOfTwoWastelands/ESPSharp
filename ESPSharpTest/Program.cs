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
        DateTime pluginStart, operationStart;
        TimeSpan span;

        foreach (string file in args)
        {
            string logFile = Path.GetFileNameWithoutExtension(file) + "Log.txt";
            if (File.Exists(logFile))
                File.Delete(logFile);

            if (Path.GetExtension(file) == "")
            {
                WriteLog(logFile,String.Format("Skipping {0}, please use plugins only, no folders/XML.", file));
                return;
            }
            WriteLog(logFile,String.Format("Starting {0}...", file));
            string outDir = Path.GetFileNameWithoutExtension(file);
            ElderScrollsPlugin plugin = new ElderScrollsPlugin();

            operationStart = DateTime.Now;
            pluginStart = operationStart;
            WriteLog(logFile,String.Format("{0} - Reading {1} binary...", operationStart.ToLongTimeString(), file));
            plugin.ReadBinary(file);
            span = DateTime.Now - operationStart;
            WriteLog(logFile,String.Format("\tFinished in {0}.\n", span.ToString(@"hh\:mm\:ss\.ffff")));

            if (Directory.Exists(outDir))
            {
                operationStart = DateTime.Now;
                WriteLog(logFile,String.Format("{0} - Clearing directory {1}...", operationStart.ToLongTimeString(), outDir));
                Directory.Delete(outDir, true);
                span = DateTime.Now - operationStart;
                WriteLog(logFile,String.Format("\tFinished in {0}.\n", span.ToString(@"hh\:mm\:ss\.ffff")));
            }
            Directory.CreateDirectory(outDir);

            operationStart = DateTime.Now;
            WriteLog(logFile,String.Format("{0} - Writing {1} XML...", operationStart.ToLongTimeString(), file));
            plugin.WriteXML(outDir);
            span = DateTime.Now - operationStart;
            WriteLog(logFile,String.Format("\tFinished in {0}.\n", span.ToString(@"hh\:mm\:ss\.ffff")));

            operationStart = DateTime.Now;
            WriteLog(logFile,String.Format("{0} - Reading {1} XML...", operationStart.ToLongTimeString(), file));
            plugin = ElderScrollsPlugin.ReadXML(outDir);
            span = DateTime.Now - operationStart;
            WriteLog(logFile,String.Format("\tFinished in {0}.\n", span.ToString(@"hh\:mm\:ss\.ffff")));

            operationStart = DateTime.Now;
            WriteLog(logFile,String.Format("{0} - Writing {1} binary...", operationStart.ToLongTimeString(), file));
            using (FileStream stream = new FileStream("NEW" + file, FileMode.Create, FileAccess.ReadWrite))
            using (ESPWriter writer = new ESPWriter(stream))
            {
                plugin.WriteBinary(writer);
            }
            span = DateTime.Now - operationStart;
            WriteLog(logFile,String.Format("\tFinished in {0}.\n", span.ToString(@"hh\:mm\:ss\.ffff")));
            span = DateTime.Now - pluginStart;
            WriteLog(logFile,String.Format("Total Time: {0}", span.ToString(@"hh\:mm\:ss\.ffff")));
        }
    }

    public static void WriteLog(string logName, string contents)
    {
        using (FileStream stream = new FileStream(logName, FileMode.Append, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.WriteLine(contents);
            Console.WriteLine(contents);
        }
    }
}
