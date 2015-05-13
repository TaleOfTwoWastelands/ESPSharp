using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            throw new NotImplementedException();
        }
    }
}
