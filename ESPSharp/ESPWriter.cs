using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void WriteSimpleSubrecord<T>(T Value, string Tag)
        {
            string typeT = typeof(T).ToString();

            WriteTag(Tag);

            switch (typeT)
            {
                case "System.Byte":
                    Write((ushort)1);
                    Write((byte)(object)Value);
                    break;
                case "System.SByte":
                    Write((ushort)1);
                    Write((sbyte)(object)Value);
                    break;
                case "System.Char":
                    Write((ushort)1);
                    Write((char)(object)Value);
                    break;
                case "System.UInt16":
                    Write((ushort)2);
                    Write((ushort)(object)Value);
                    break;
                case "System.Int16":
                    Write((ushort)2);
                    Write((short)(object)Value);
                    break;
                case "System.UInt32":
                    Write((ushort)4);
                    Write((uint)(object)Value);
                    break;
                case "System.Int32":
                    Write((ushort)4);
                    Write((int)(object)Value);
                    break;
                case "System.Single":
                    Write((ushort)4);
                    Write((float)(object)Value);
                    break;
                case "System.UInt64":
                    Write((ushort)8);
                    Write((ulong)(object)Value);
                    break;
                case "System.Int64":
                    Write((ushort)8);
                    Write((long)(object)Value);
                    break;
                case "System.Byte[]":
                    Write((ushort)((byte[])(object)Value).Length);
                    Write((byte[])(object)Value);
                    break;
                case "System.Char[]":
                    Write((ushort)((char[])(object)Value).Length);
                    Write((char[])(object)Value);
                    break;
                case "System.String":
                    Write((ushort)(((string)(object)Value).Length + 1));
                    Write(((string)(object)Value).ToCharArray());
                    Write((byte)0);
                    break;
            }
        }
    }
}
