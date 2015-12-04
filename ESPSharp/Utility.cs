using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ESPSharp
{
    public static class Utility
    {
        public static readonly Encoding WesternEncoding = Encoding.GetEncoding("ISO-8859-1");

        private static Dictionary<char, char> tagSaniDict = new Dictionary<char, char>()
        {
            {(char)0x00, '0'},
            {(char)0x01, '1'},
            {(char)0x02, '2'},
            {(char)0x03, '3'},
            {(char)0x04, '4'},
            {(char)0x05, '5'},
            {(char)0x06, '6'},
            {(char)0x07, '7'},
            {(char)0x08, '8'},
            {(char)0x09, '9'},
            {(char)0x0a, 'a'},
            {(char)0x0b, 'b'},
            {(char)0x0c, 'c'},
            {(char)0x0d, 'd'},
            {(char)0x0e, 'e'},
            {(char)0x0f, 'f'},
            {(char)0x10, 'g'},
            {(char)0x11, 'h'},
            {(char)0x12, 'i'},
            {(char)0x13, 'j'},
            {(char)0x14, 'k'},
            {(char)0x15, 'l'},
            {(char)0x16, 'm'},
            {(char)0x17, 'n'},
            {(char)0x18, 'o'},
            {(char)0x19, 'p'},
            {(char)0x1a, 'q'},
            {(char)0x1b, 'r'},
            {(char)0x1c, 's'},
            {(char)0x1d, 't'},
            {(char)0x1e, 'u'},
            {(char)0x1f, 'v'},
            {(char)0x40, 'z'}
        };

        static Dictionary<char, char> tagDesaniDict;

        public static Dictionary<char, char> TagSaniDict
        {
            get { return Utility.tagSaniDict; }
        }

        public static Dictionary<char, char> TagDesaniDict
        {
            get 
            {
                if (tagDesaniDict == null)
                {
                    tagDesaniDict = new Dictionary<char, char>();
                    foreach (var kvp in TagSaniDict)
                        tagDesaniDict.Add(kvp.Value, kvp.Key);
                }
                return Utility.tagDesaniDict; 
            }
        }


        public static string SanitizeTag(string inString)
        {
            var buf = WesternEncoding.GetBytes(inString);
            for (int i = 0; i < buf.Length; i++)
                if (TagSaniDict.ContainsKey((char)buf[i]))
                    buf[i] = (byte)TagSaniDict[(char)buf[i]];

            return WesternEncoding.GetString(buf);
        }

        public static string DesanitizeTag(string inString)
        {
            string outString = "";

            foreach (byte character in WesternEncoding.GetBytes(inString))
            {
                if (TagDesaniDict.ContainsKey((char)character))
                    outString += TagDesaniDict[(char)character];
                else
                    outString += (char)character;
            }

            return outString;
        }

        public static List<string> PathToStrings(string path)
        {
            return path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToList<string>();
        }

        public static string ToPrivateCase(string inString)
        {
            return string.Format("{0}{1}", inString.Substring(0, 1).ToLowerInvariant(), inString.Substring(1));
        }

        public static string ToPropertyCase(string inString)
        {
            return string.Format("{0}{1}", inString.Substring(0, 1).ToUpperInvariant(), inString.Substring(1));
        }

        public static string GetFriendlyName(Type inType)
        {
            return inType.FriendlyName();
        }
    }
}
