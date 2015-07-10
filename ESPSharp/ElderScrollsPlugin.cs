﻿#define PARALLEL

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
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public class ElderScrollsPlugin : IDisposable
    {
        public static List<ElderScrollsPlugin> LoadedPlugins = new List<ElderScrollsPlugin>();
        public static Dictionary<uint, List<RecordView>> LoadedRecordViews = new Dictionary<uint, List<RecordView>>();

        protected string name = "";
        public List<string> Masters = new List<string>();
        public RecordView Header;
        public List<Group> TopGroups = new List<Group>();
        public List<Group> AllGroups = new List<Group>();
        public HashSet<RecordView> RecordViews = new HashSet<RecordView>();

        protected MemoryMappedFile mmf;

        public string Name
        {
            get
            {
                if (Header.Flags.HasFlag(RecordFlag.IsMasterFile))
                    return name + ".esm";
                else
                    return name + ".esp";
            }
            protected set
            {
                name = Path.GetFileNameWithoutExtension(value);
            }
        }

        public ElderScrollsPlugin()
        {
        }

        public ElderScrollsPlugin(string name)
        {
            Name = name;
        }

        public void Read(string source)
        {
            if (source == "")
                throw new Exception();

            if (File.Exists(source))
                ReadBinary(source);
            else if (Directory.Exists(source))
                ReadXML(source);
        }

        public void WriteXML(string destinationFolder)
        {
            Header.Record.WriteXML(Path.Combine(destinationFolder, "Header.xml"), this);
//.Where(g => g.ToString() != "Interior Cells" && g.ToString() != "Worldspaces" && g.ToString() != "Dialog Topics")
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
            ElderScrollsPlugin outPlug = new ElderScrollsPlugin();
            outPlug.name = Path.GetDirectoryName(sourceFolder);
            outPlug.Header = new RecordView(Path.Combine(sourceFolder, "Header.xml"));

            outPlug.ReadMasters();

            outPlug.Masters.Add(outPlug.Name);

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

            foreach (var group in TopGroups)
                group.WriteBinary(writer, this);
        }

        public void ReadBinary(string file)
        {
            name = Path.GetFileNameWithoutExtension(file);
            FileInfo fi = new FileInfo(file);
            mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open, Path.GetFileNameWithoutExtension(file), fi.Length, MemoryMappedFileAccess.Read);

            using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, fi.Length, MemoryMappedFileAccess.Read))
            using (ESPReader reader = new ESPReader(stream))
            {
                Header = new RecordView(reader, mmf);

                Masters = new List<string>();

                ReadMasters();

                Masters.Add(Name);

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var group = Group.CreateGroup(reader);

                    group.GroupAdded += (g) => AllGroups.Add(g);
                    group.RecordViewAdded += (r) => RecordViews.Add(r);
                    TopGroups.Add(group);
                    AllGroups.Add(group);

                    group.ReadBinary(reader, mmf);
                }
            }

            ElderScrollsPlugin.LoadedPlugins.Add(this);

            foreach (RecordView view in RecordViews)
            {
                LoadOrderFormID loID = new LoadOrderFormID(view.FormID, this);

                List<RecordView> viewList;

                if (!ElderScrollsPlugin.LoadedRecordViews.TryGetValue(loID.RawValue, out viewList))
                {
                    viewList = new List<RecordView>();
                    ElderScrollsPlugin.LoadedRecordViews.Add(loID.RawValue, viewList);
                }

                viewList.Add(view);
            }
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
                    ElderScrollsPlugin master = ElderScrollsPlugin.LoadedPlugins.FirstOrDefault(esp => esp.Name == masterData.FileName.Value);

                    if (master == null)
                    {
                        master = new ElderScrollsPlugin(masterData.FileName.Value);
                        master.Read(masterData.FileName.Value);
                    }

                    Masters.Add(masterData.FileName.Value);
                }
            }
        }
    }
}
