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

        public T ReadEnum<T>()
        {
            Type enumType = Enum.GetUnderlyingType(typeof(T));

            switch (enumType.FullName)
            {
                case "System.Byte":
                    return (T)(object)ReadByte();
                case "System.SByte":
                    return (T)(object)ReadSByte();
                case "System.UInt16":
                    return (T)(object)ReadUInt16();
                case "System.Int16":
                    return (T)(object)ReadInt16();
                case "System.UInt32":
                    return (T)(object)ReadUInt32();
                case "System.Int32":
                    return (T)(object)ReadInt32();
                case "System.UInt64":
                    return (T)(object)ReadUInt64();
                case "System.Int64":
                    return (T)(object)ReadInt64();
                default:
                    throw new NotImplementedException(enumType + " is not yet implemented.");
            }
        }

        public FormID ReadFormID()
        {
            return (FormID)ReadUInt32();
        }

        public AlternateTexture ReadAlternateTexture()
        {
            AlternateTexture outTex;
            int size = ReadInt32();
            outTex.Name = new String(ReadChars(size));
            outTex.TextureSet = ReadFormID();
            outTex.Index = ReadInt32();

            return outTex;
        }
    }
}
