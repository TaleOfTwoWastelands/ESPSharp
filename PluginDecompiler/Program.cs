using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp;
using System.IO;
using System.IO.MemoryMappedFiles;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        bool useFormIDStartPoint = false;
        uint formIDStartPoint = 0;

        if (!File.Exists("PluginDecompilerConfig.xml"))
        {
            XDocument configXML = new XDocument();
            XElement settingsRoot = new XElement("Settings");
            XElement ele;
            string localDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ElderScrollsPlugin.pluginLocations.Add(new KeyValuePair<string, bool>(localDirectory, false));

            configXML.Add(settingsRoot);

            ele = new XElement("PluginSearchLocations");
            ele.Add(new XComment("A list of places where PluginDecompiler should search for parent plugins."));
            ele.Add(new XComment("Element (\"LocalDirectory\" in the example below) name does not matter."));
            ele.Add(new XComment("Directory is an absoulte file path, Recursive (true/false) is whether or not it should search sub folders for plugins (great for Mod Organizer users)."));
            ele.Add(new XElement("LocalDirectory", new XElement("Directory", localDirectory), new XElement("Recursive", false)));
            settingsRoot.Add(ele);

            ele = new XElement("FormIDStartPoint");
            ele.Add(new XComment("PluginDecompiler can tell the GECK and FNVEdit to start numbering formIDs at a specific point."));
            ele.Add(new XComment("This is good for collaboration and group projects to minimize formID conflicts when adding new forms."));
            ele.Add(new XComment("Enabled is a simple true/false value. StartPoint is read as a hexidecimal number, limited to 6 digits."));
            ele.Add(new XElement("Enabled", false));
            ele.Add(new XElement("StartPoint", "000000"));
            settingsRoot.Add(ele);

            configXML.Save("PluginDecompilerConfig.xml");
        }
        else
        {
            XDocument configXML = XDocument.Load("PluginDecompilerConfig.xml");

            foreach (XElement ele in configXML.Element("Settings").Element("PluginSearchLocations").Elements())
            {
                if (ele.Element("Directory") != null && ele.Element("Recursive") != null)
                    ElderScrollsPlugin.pluginLocations.Add(new KeyValuePair<string, bool>(ele.Element("Directory").Value, ele.Element("Recursive").ToBoolean()));
            }

            useFormIDStartPoint = configXML.Element("Settings").Element("FormIDStartPoint").Element("Enabled").ToBoolean();
            formIDStartPoint = UInt32.Parse(configXML.Element("Settings").Element("FormIDStartPoint").Element("StartPoint").Value, System.Globalization.NumberStyles.HexNumber);
        }

        foreach (string file in args)
        {
            string outDir = Path.GetFileNameWithoutExtension(file);
            ElderScrollsPlugin plugin;

            if (outDir == Path.GetFileName(file))
            {
                if (ElderScrollsPlugin.LoadedPlugins.Any(esp => esp.FileName == file))
                    plugin = ElderScrollsPlugin.LoadedPlugins.First(esp => esp.FileName == file);
                else
                    plugin = ElderScrollsPlugin.ReadXML(file);

                string outFile;
                if (plugin.Header.Record.Flags.HasFlag(ESPSharp.Enums.Flags.RecordFlag.IsMasterFile))
                    outFile = Path.ChangeExtension(file, "esm");
                else
                    outFile = Path.ChangeExtension(file, "esp");

                if (useFormIDStartPoint)
                {
                    var header = plugin.Header.Record as ESPSharp.Records.Header;
                    header.FileHeader.NextObjectID = formIDStartPoint;
                    plugin.Header = new RecordView(header);
                }

                using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite))
                using (ESPWriter writer = new ESPWriter(stream, plugin))
                {
                    plugin.WriteBinary(writer);
                }
            }
            else
            {
                if (ElderScrollsPlugin.LoadedPlugins.Any(esp => esp.FileName == file))
                    plugin = ElderScrollsPlugin.LoadedPlugins.First(esp => esp.FileName == file);
                else
                    plugin = ElderScrollsPlugin.ReadBinary(file);

                if (Directory.Exists(outDir))
                    Directory.Delete(outDir, true);

                Directory.CreateDirectory(outDir);

                plugin.WriteXML(outDir);
            }
        }
        ;
    }
}
