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

        #region XElementExtensions
        public static T ToEnum<T>(this XElement ele)
        {
            Type enumType = typeof(T);

            return (T)Enum.Parse(enumType, ele.Value);
        }

        public static float ToSingle(this XElement ele)
        {
            return float.Parse(ele.Value);
        }

        public static FormID ToFormID(this XElement ele)
        {
            return uint.Parse(ele.Value, System.Globalization.NumberStyles.HexNumber);
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
            return Convert.FromBase64String(ele.Value);
        }

        public static char[] ToChars(this XElement ele)
        {
            return ele.Value.ToArray();
        }

        public static void AddSimpleSubrecord(this XElement ele, string name, string tag, object value)
        {
            ele.Add(
                new XElement(name,
                    new XAttribute("Tag", tag),
                    value));
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
            return Convert.ToBase64String(bytes);
        }
        public static string ToHex(this byte[] bytes)
        {
            return bytes.ToBase64();
        }
    }
}
