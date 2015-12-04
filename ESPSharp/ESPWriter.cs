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
        public ElderScrollsPlugin Plugin { get; set; }

        public ESPWriter(Stream stream, ElderScrollsPlugin plugin)
            :base(stream, Utility.WesternEncoding)
        {
            Plugin = plugin;
        }

        public void WriteTag(string Tag)
        {
            Write(Utility.DesanitizeTag(Tag).ToCharArray());
        }

        public void Write(IESPSerializable writeObject)
        {
            writeObject.WriteBinary(this);
        }

        public override void Write(string value)
        {
            var chars = value.ToCharArray();

            Write(chars);
            Write('\0');
        }
    }
}
