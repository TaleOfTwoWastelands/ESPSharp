using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace ESPSharp
{
    public static class LocalizedStrings
    {
        /// <summary>
        /// A Dictionary that takes [pluginName][stringType][stringID] and returns a Tuple that is MemoryMappedFile, Offset, Length
        /// </summary>
        private static Dictionary<string, Dictionary<LocalizedStringType, Dictionary<uint, Tuple<MemoryMappedFile, uint, uint>>>> stringMap = new Dictionary<string, Dictionary<LocalizedStringType, Dictionary<uint, Tuple<MemoryMappedFile, uint, uint>>>>();

        private static string locale = "en";

        public static string Locale
        {
            get
            {
                return locale;
            }
            set
            {
                stringMap = new Dictionary<string, Dictionary<LocalizedStringType, Dictionary<uint, Tuple<MemoryMappedFile, uint, uint>>>>();
                locale = value;
            }
        }

        private static string GetStringsFileName(string pluginName, LocalizedStringType type)
        {
            string extension;
            switch (type)
            {
                case LocalizedStringType.Strings:
                    extension = "strings";
                    break;
                case LocalizedStringType.DLStrings:
                    extension = "dlstrings";
                    break;
                case LocalizedStringType.ILStrings:
                    extension = "ilstrings";
                    break;
                default:
                    throw new Exception();
            }
            return String.Format("Strings\\{0}_{1}.{2}", pluginName, Locale, extension);
        }

        public static string GetLocalizedString(uint stringID, string pluginName, LocalizedStringType type)
        {
            MapStrings(pluginName, type);
            if (!stringMap[pluginName][type].ContainsKey(stringID))
                return "UnknownStringID";
            var tuple = stringMap[pluginName][type][stringID];

            using (MemoryMappedViewStream stream = tuple.Item1.CreateViewStream(tuple.Item2, tuple.Item3, MemoryMappedFileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                return new string(reader.ReadChars((int)tuple.Item3));
            }
        }

        private static void MapStrings(string pluginName, LocalizedStringType type)
        {
            foreach (string folder in ElderScrollsPlugin.pluginLocations.Select(s => s.Key))
            {
                string file = Path.Combine(folder, GetStringsFileName(pluginName, type));
                if (File.Exists(file))
                {
                    MapFile(file, type);
                }
            }
        }

        private static void MapFile(string file, LocalizedStringType type)
        {
            string pluginName = Path.GetFileNameWithoutExtension(file).Replace(String.Format("_{0}", Locale), "");

            if (stringMap.ContainsKey(pluginName.ToLower()) && stringMap[pluginName.ToLower()].ContainsKey(type))
                return;

            FileInfo fi = new FileInfo(file);
            MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open, Path.GetFileName(file), fi.Length, MemoryMappedFileAccess.Read);

            uint stringCount;
            uint dataSize;

            uint baseOffset;

            uint ID;
            uint offset;
            uint size;

            long pos;

            var tempDict = new Dictionary<uint, Tuple<MemoryMappedFile, uint, uint>>();

            try
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, fi.Length, MemoryMappedFileAccess.Read))
                using (BinaryReader reader = new BinaryReader(stream, Utility.WesternEncoding))
                {
                    stringCount = reader.ReadUInt32();
                    dataSize = reader.ReadUInt32();

                    baseOffset = 8 * (stringCount + 1);

                    for (int i = 0; i < stringCount; i++)
                    {
                        ID = reader.ReadUInt32();
                        offset = baseOffset + reader.ReadUInt32();

                        pos = stream.Position;
                        stream.Seek(offset, SeekOrigin.Begin);

                        if (type == LocalizedStringType.Strings)
                        {
                            StringBuilder builder = new StringBuilder();

                            char c;

                            do
                            {
                                c = reader.ReadChar();
                                builder.Append(c);
                            } while (c != '\0');

                            size = (uint)builder.Length - 1;
                        }
                        else
                        {
                            size = reader.ReadUInt32() - 1;
                            offset += 4;
                        }

                        stream.Seek(pos, SeekOrigin.Begin);

                        tempDict.Add(ID, new Tuple<MemoryMappedFile, uint, uint>(mmf, offset, size));
                    }
                }
                if (!stringMap.ContainsKey(pluginName))
                    stringMap[pluginName] = new Dictionary<LocalizedStringType, Dictionary<uint, Tuple<MemoryMappedFile, uint, uint>>>();

                stringMap[pluginName][type] = tempDict;
            }
            catch
            {
                return;
            }
        }
    }

    public enum LocalizedStringType
    {
        Strings,
        DLStrings,
        ILStrings
    }
}