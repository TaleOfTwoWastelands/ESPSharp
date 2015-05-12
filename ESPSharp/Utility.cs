using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp
{
    public static class Utility
    {
        public static readonly Encoding WesternEncoding = Encoding.GetEncoding("ISO-8859-1");

        public static string SanitizeTag(string inString)
        {
            var buf = WesternEncoding.GetBytes(inString);
            for (int i = 0; i < buf.Length; i++)
                if (buf[i] == 0x40)
                    buf[i] = 0x7A;
                else if (buf[i] < 0x18)
                    buf[i] += 0x61;

            return WesternEncoding.GetString(buf);
        }

        public static string DesanitizeTag(string inString)
        {
            string outString = "";

            foreach (byte character in WesternEncoding.GetBytes(inString))
            {
                if (character == 0x7A)
                    outString += Convert.ToChar(0x40);
                else if (character < 0x7A && character >= 0x61)
                    outString += Convert.ToChar(character - 0x61);
                else
                    outString += Convert.ToChar(character);
            }

            return outString;
        }
    }
}
