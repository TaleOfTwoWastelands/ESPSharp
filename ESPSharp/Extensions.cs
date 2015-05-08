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
        #endregion

        #region BinaryReaderExtensions
        public static char[] PeekTag(this BinaryReader reader)
        {
            char[] peek = reader.ReadTag();
            reader.BaseStream.Seek(-4, SeekOrigin.Current);

            return peek;
        }

        public static char[] ReadTag(this BinaryReader reader)
        {
            return reader.ReadChars(4);
        }
        #endregion

        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
