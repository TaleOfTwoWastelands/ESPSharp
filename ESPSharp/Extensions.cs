using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ESPSharp
{
    public static class Extensions
    {
        public static Dictionary<int, char> HexDict = new Dictionary<int, char>()
        {
            {0, '0'},
            {1, '1'},
            {2, '2'},
            {3, '3'},
            {4, '4'},
            {5, '5'},
            {6, '6'},
            {7, '7'},
            {8, '8'},
            {9, '9'},
            {10, 'A'},
            {11, 'B'},
            {12, 'C'},
            {13, 'D'},
            {14, 'E'},
            {15, 'F'}
        };

        public static Dictionary<char, byte> ReverseHexDict = new Dictionary<char, byte>()
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'A', 10},
            {'B', 11},
            {'C', 12},
            {'D', 13},
            {'E', 14},
            {'F', 15}
        };

        #region XElementExtensions
        public static T ToEnum<T>(this XElement ele)
        {
            Type enumType = typeof(T);

            return (T)Enum.Parse(enumType, ele.Value);
        }

        public static float ToSingle(this XElement ele)
        {
            return (float)(double.Parse(ele.Value));
        }

        public static ulong ToUInt64(this XElement ele)
        {
            return ulong.Parse(ele.Value);
        }

        public static long ToInt64(this XElement ele)
        {
            return long.Parse(ele.Value);
        }

        public static uint ToUInt32(this XElement ele)
        {
            return uint.Parse(ele.Value);
        }

        public static int ToInt32(this XElement ele)
        {
            return int.Parse(ele.Value);
        }

        public static ushort ToUInt16(this XElement ele)
        {
            return ushort.Parse(ele.Value);
        }

        public static short ToInt16(this XElement ele)
        {
            return short.Parse(ele.Value);
        }

        public static byte ToByte(this XElement ele)
        {
            return byte.Parse(ele.Value);
        }

        public static char ToChar(this XElement ele)
        {
            return char.Parse(ele.Value);
        }

        public static sbyte ToSByte(this XElement ele)
        {
            return sbyte.Parse(ele.Value);
        }

        public static bool ToBoolean(this XElement ele)
        {
            return bool.Parse(ele.Value);
        }

        public static byte[] ToBytes(this XElement ele)
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                byte b;
                foreach (string hex in ele.Value.Split(' '))
                {
                    b = ReverseHexDict[hex[1]];
                    b += (byte)(ReverseHexDict[hex[0]] << 4);

                    writer.Write(b);
                }

                return stream.ToArray();
            }
        }

        public static char[] ToChars(this XElement ele)
        {
            return ele.Value.ToArray();
        }

        public static bool TryPathTo(this XElement ele, string path, bool createPath, out XElement outEle)
        {
            List<string> nodes = Utility.PathToStrings(path);
            return ele.TryPathTo(nodes, createPath, out outEle);
        }

        public static bool TryPathTo(this XElement ele, List<string> nodes, bool createPath, out XElement outEle)
        {
            XElement curEle = ele;

            foreach (var node in nodes)
            {
                XElement nextEle = curEle.Element(node);
                if (nextEle != null)
                    curEle = nextEle;
                else if (createPath)
                {
                    nextEle = new XElement(node);
                    curEle.Add(nextEle);
                    curEle = nextEle;
                }
                else
                {
                    outEle = curEle;
                    return false;
                }
            }

            outEle = curEle;

            return true;
        }
        #endregion

        public static string ToBase64(this byte[] bytes)
        {
            if (bytes != null)
                return Convert.ToBase64String(bytes);
            else
                return "";
        }

        public static string ToHex(this byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var b in bytes)
            {
                builder.Append(HexDict[(b & 0xf0) >> 4]);
                builder.Append(HexDict[b & 0x0f]);
                builder.Append(" ");
            }

            return builder.ToString();
        }

        public static string FriendlyName(this Type type)
        {
            if (type.IsConstructedGenericType)
            {
                string name = type.Name.Substring(0, type.Name.IndexOf('`'));
                string args = string.Join(", ", type.GenericTypeArguments.Select<Type, string>(t => t.FriendlyName()));

                return name + "<" + args + ">";
            }
            else if (type == typeof(object))
                return "dynamic";
            else
                return type.Name;
        }

        public static string GetCloneText(this Type type, string name)
        {
            if (type.IsValueType)
                return name;
            else if (type.GetInterface("ICloneable") != null)
                return String.Format("({0}){1}.Clone()", Utility.GetFriendlyName(type), name);
            else
                throw new Exception();
        }
    }
}
