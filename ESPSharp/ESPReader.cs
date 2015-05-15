using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ESPSharp
{
    public class ESPReader : BinaryReader
    {
        public ESPReader(Stream stream)
            : base(stream, Utility.WesternEncoding) { }

        public string ReadTag()
        {
            return Utility.SanitizeTag(new string(ReadChars(4)));
        }

        public string PeekTag()
        {
            string peek = ReadTag();
            BaseStream.Seek(-4, SeekOrigin.Current);

            return peek;
        }

        public string ReadNullTermString(int length)
        {
            string outString = new string(ReadChars(length - 1));
            ReadByte();
            return outString;
        }

        public T ReadSimpleSubrecord<T>()
        {
            string Tag = ReadTag();
            int size = ReadUInt16();

            string typeT = typeof(T).ToString();

            switch (typeT)
            {
                case "System.Byte":
                    Debug.Assert(size == 1);
                    return (T)(object)ReadByte();
                case "System.SByte":
                    Debug.Assert(size == 1);
                    return (T)(object)ReadSByte();
                case "System.Char":
                    Debug.Assert(size == 1);
                    return (T)(object)ReadChar();
                case "System.UInt16":
                    Debug.Assert(size == 2);
                    return (T)(object)ReadUInt16();
                case "System.Int16":
                    Debug.Assert(size == 2);
                    return (T)(object)ReadInt16();
                case "System.UInt32":
                    Debug.Assert(size == 4);
                    return (T)(object)ReadUInt32();
                case "System.Int32":
                    Debug.Assert(size == 4);
                    return (T)(object)ReadInt32();
                case "System.Single":
                    Debug.Assert(size == 4);
                    return (T)(object)ReadSingle();
                case "System.UInt64":
                    Debug.Assert(size == 8);
                    return (T)(object)ReadUInt64();
                case "System.Int64":
                    Debug.Assert(size == 8);
                    return (T)(object)ReadInt64();
                case "System.Byte[]":
                    return (T)(object)ReadBytes(size);
                case "System.Char[]":
                    return (T)(object)ReadChars(size);
                case "System.String":
                    string outString = new String(ReadChars(size - 1));
                    ReadByte();
                    return (T)(object)outString;
                default:
                    throw new NotImplementedException(typeT + " is not yet implemented.");
            }
        }
    }
}
