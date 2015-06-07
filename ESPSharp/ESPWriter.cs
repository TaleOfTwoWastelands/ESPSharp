using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ESPSharp.Interfaces;

namespace ESPSharp
{
    public class ESPWriter : BinaryWriter
    {
        public ESPWriter(Stream stream)
            :base(stream, Utility.WesternEncoding){}

        public void WriteTag(string Tag)
        {
            Write(Utility.DesanitizeTag(Tag).ToCharArray());
        }

        public void Write(IESPSerializable writeObject)
        {
            writeObject.WriteBinary(this);
        }
    }
}
