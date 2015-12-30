#define PARALLEL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Records;
using ESPSharp.Subrecords;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public class ElderScrollsPlugin : IDisposable
    {
        public static List<ElderScrollsPlugin> LoadedPlugins = new List<ElderScrollsPlugin>();
        public static Dictionary<uint, List<RecordView>> LoadedRecordViews = new Dictionary<uint, List<RecordView>>();
        public static Dictionary<string, Dictionary<uint, List<RecordView>>> RecordViewsByType = new Dictionary<string, Dictionary<uint, List<RecordView>>>();
        public static List<KeyValuePair<string, bool>> pluginLocations = new List<KeyValuePair<string, bool>>();
        public List<string> Masters = new List<string>();
        public RecordView Header;
        public List<Group> TopGroups = new List<Group>();
        public List<Group> AllGroups = new List<Group>();
        public HashSet<RecordView> RecordViews = new HashSet<RecordView>();

		public delegate void ProgressUpdate(string msg, LogLevel level);
	    public static event ProgressUpdate OnProgressUpdate;

		public delegate void ProgressUpdateError(string msg, LogLevel level);
		public static event ProgressUpdateError OnProgressUpdateError;

		protected MemoryMappedFile mmf;

        public string ProperName
        {
            get
            {
                if (Header.Flags.HasFlag(RecordFlag.IsMasterFile))
                    return Name + ".esm";
                else
                    return Name + ".esp";
            }
        }

        public string Name { get; protected set; }

        public string FileName { get; protected set; }

        /// <summary>
        /// Create a new, empty plugin
        /// </summary>
        /// <param name="name">The name of the plugin. </param>
        /// <param name="author">The author of the plugin</param>
        /// <param name="description">The description embedded in the plugin</param>
        //Sorry this is hideous, only way to link the two constructors
        public ElderScrollsPlugin(string name, string author = "", string description = "")
            :this(name, 
                 new Header(
                    new PluginHeader(1.34f, 0, 0x800),
                    null,
                    null,
                    new SimpleSubrecord<string>("CNAM", author),
                    new SimpleSubrecord<string>("SNAM", description),
                    null,
                    null,
                    null
                ))
        {
        }

        /// <summary>
        /// Creates a new plugin using the given header
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="header">The header for the plugin</param>
        public ElderScrollsPlugin(string name, Header header)
            :this(name, new RecordView(header))
        {
        }

        /// <summary>
        /// Creates a new plugin using the given RecordView that is assumed to contain a Header record
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="header">The RecordView for the plugin, MUST be a view to a Header record</param>
        public ElderScrollsPlugin(string name, RecordView header)
        {
            if (header.Record is Header)
            {
                Name = name;
                Header = header;
            }
            else throw new ArgumentException("header must be a RecordView to a Header record");
        }

        public void Read(string source)
        {
            if (source == "")
                throw new Exception();

	        try
	        {
				if (File.Exists(source))
					ReadBinary(source);
				else if (Directory.Exists(source))
					ReadXML(source);
			}
	        catch (IOException)
	        {
				throw new IOException("Failed to load the source file " + source + Environment.NewLine + "Check to make sure it exists and isn't open in another program.");
	        }
        }

        public void WriteXML(string destinationFolder)
        {
            var headerLocation = Path.Combine(destinationFolder, "Header.xml");
            Header.Record.WriteXML(headerLocation, this);
//.Where(g => g.ToString() != "Interior Cells" && g.ToString() != "Worldspaces" && g.ToString() != "Dialog Topics")
            var xml = XDocument.Load(headerLocation);
            xml.Element("Record").Add(new XElement("FileName", FileName));
            xml.Save(headerLocation);
#if PARALLEL
            Parallel.ForEach(TopGroups, group =>
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir, this);
            });
#else
            foreach (Group group in TopGroups)
            {
                string newDir = Path.Combine(destinationFolder, group.ToString());
                Directory.CreateDirectory(newDir);
                group.WriteXML(newDir, this);
            }
#endif
        }

        public static ElderScrollsPlugin ReadXML(string sourceFolder)
        {
			var headerLocation = Path.Combine(sourceFolder, "Header.xml");
            var xml = XDocument.Load(headerLocation);
            ElderScrollsPlugin outPlug = new ElderScrollsPlugin(Path.GetDirectoryName(sourceFolder), new RecordView(headerLocation));
            outPlug.FileName = xml.Element("Record").Element("FileName").Value;

            outPlug.ReadMasters();

            outPlug.Masters.Add(outPlug.FileName);

            foreach (var folder in Directory.EnumerateDirectories(sourceFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                Group newGroup = Group.CreateGroup(folder);

                newGroup.GroupAdded += (g) => outPlug.AllGroups.Add(g);
                newGroup.RecordViewAdded += (r) => outPlug.RecordViews.Add(r);
                outPlug.TopGroups.Add(newGroup);
                outPlug.AllGroups.Add(newGroup);

                newGroup.ReadXML(folder, outPlug);
            }

            ElderScrollsPlugin.LoadedPlugins.Add(outPlug);

            return outPlug;
        }

        public void WriteBinary(ESPWriter writer)
        {
            Header.Record.WriteBinary(writer);

            foreach (var kvp in TopGroup.tagToNameDictionary)
            {
                Group group = TopGroups.FirstOrDefault(g => (g as TopGroup).RecordType == kvp.Key);
                if (group != null)
                    group.WriteBinary(writer, this);
            }
        }

        public static ElderScrollsPlugin ReadBinary(string file)
        {
            ElderScrollsPlugin outPlug = new ElderScrollsPlugin(Path.GetFileNameWithoutExtension(file), new Header());
            outPlug.FileName = Path.GetFileName(file);
            FileInfo fi = new FileInfo(file);
            outPlug.mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open, Path.GetFileNameWithoutExtension(file), fi.Length, MemoryMappedFileAccess.Read);

            using (MemoryMappedViewStream stream = outPlug.mmf.CreateViewStream(0, fi.Length, MemoryMappedFileAccess.Read))
            using (ESPReader reader = new ESPReader(stream, outPlug))
            {
                outPlug.Header = new RecordView(reader, outPlug.mmf);

                outPlug.Masters = new List<string>();

                outPlug.ReadMasters();

                outPlug.Masters.Add(outPlug.FileName);

				Log("Beginning loading plugin " + outPlug.FileName, LogLevel.Plugin);

				while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var group = Group.CreateGroup(reader);

                    group.GroupAdded += (g) => outPlug.AllGroups.Add(g);
                    group.RecordViewAdded += (r) => outPlug.RecordViews.Add(r);

                    group.ReadBinary(reader, outPlug.mmf);

					var index = outPlug.TopGroups.FindIndex(g => ((TopGroup)g).RecordType.Equals(((TopGroup)group).RecordType));
					if (index > 0)
						group.MergeGroup(outPlug.TopGroups[index]);
					else
					{
                        outPlug.TopGroups.Add(group);
                        outPlug.AllGroups.Add(group);
					}

					
				}
				Log("Finished loading plugin " + outPlug.FileName, LogLevel.Plugin);
            }

            ElderScrollsPlugin.LoadedPlugins.Add(outPlug);

            foreach (RecordView view in outPlug.RecordViews)
            {
                LoadOrderFormID loID = new LoadOrderFormID(view.FormID, outPlug);

                Dictionary<uint, List<RecordView>> typeDict;
                List<RecordView> viewList;

                //add view to collection of all views
                if (!ElderScrollsPlugin.LoadedRecordViews.TryGetValue(loID.RawValue, out viewList))
                {
                    viewList = new List<RecordView>();
                    ElderScrollsPlugin.LoadedRecordViews.Add(loID.RawValue, viewList);
                }
                viewList.Add(view);

                //add view to categorized collection of all views
                string tag = view.Tag;
                if (!ElderScrollsPlugin.RecordViewsByType.TryGetValue(tag, out typeDict))
                {
                    typeDict = new Dictionary<uint, List<RecordView>>();
                    ElderScrollsPlugin.RecordViewsByType.Add(tag, typeDict);
                }
                if (!ElderScrollsPlugin.RecordViewsByType[tag].TryGetValue(loID.RawValue, out viewList))
                {
                    viewList = new List<RecordView>();
                    ElderScrollsPlugin.RecordViewsByType[tag].Add(loID.RawValue, viewList);
                }
                viewList.Add(view);
            }
            return outPlug;
        }

        public static void Clear()
        {
            foreach (ElderScrollsPlugin plugin in LoadedPlugins)
            {
                plugin.Dispose();
            }

            LoadedPlugins = new List<ElderScrollsPlugin>();
            LoadedRecordViews = new Dictionary<uint, List<RecordView>>();
        }

        public void Dispose()
        {
            if (mmf != null)
                mmf.Dispose();
        }

        protected void ReadMasters()
        {
            ESPSharp.Records.Header headRec = Header.Record as ESPSharp.Records.Header;

            if (headRec.MasterFiles != null)
            {
                foreach (var masterData in headRec.MasterFiles)
                {
                    ElderScrollsPlugin master = ElderScrollsPlugin.LoadedPlugins.FirstOrDefault(esp => esp.FileName == masterData.FileName.Value);

                    if (master == null)
                    {
                        string masterFile = FindMaster(masterData.FileName.Value);

                        if (masterFile == null) throw new FileNotFoundException(masterData.FileName.Value + " could not be found.");

                        master = new ElderScrollsPlugin(masterData.FileName.Value);
                        master.Read(masterFile);
                    }

                    Masters.Add(masterData.FileName.Value);
                }
            }
        }

        protected string FindMaster(string masterToFind)
        {
            if (File.Exists(masterToFind))
                return masterToFind;

            foreach (var kvp in pluginLocations)
            {
                string directory = kvp.Key;
                bool recursive = kvp.Value;

                var file = Directory.EnumerateFiles(directory, masterToFind, recursive ? SearchOption.AllDirectories : SearchOption.AllDirectories).FirstOrDefault();

                if (file != null)
                    return file;
            }

            return null;
        }


		#region Logging
		public static void Log(string msg, LogLevel level)
		{
			OnProgressUpdate?.Invoke(msg, level);
		}

		public static void LogError(string msg, LogLevel level)
		{
			OnProgressUpdateError?.Invoke(msg, level);
		}
		#endregion
	}

    public enum LogLevel
    {
        Plugin,
        Group,
        Record,
        SubrecordCollection,
        Subrecord,
        DataStructure
    }
}
