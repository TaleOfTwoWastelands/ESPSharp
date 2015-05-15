using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

namespace ESPSharp
{
    public class SimpleSubrecord<T> : Subrecord
    {
        public T Value;

        protected override void ReadData(ESPReader reader)
        {
            string typeT = typeof(T).ToString();

            switch (typeT)
            {
                case "System.Byte":
                    Debug.Assert(size == 1);
                    Value = (T)(object)reader.ReadByte();
                    break;
                case "System.SByte":
                    Debug.Assert(size == 1);
                    Value = (T)(object)reader.ReadSByte();
                    break;
                case "System.Char":
                    Debug.Assert(size == 1);
                    Value = (T)(object)reader.ReadChar();
                    break;
                case "System.UInt16":
                    Debug.Assert(size == 2);
                    Value = (T)(object)reader.ReadUInt16();
                    break;
                case "System.Int16":
                    Debug.Assert(size == 2);
                    Value = (T)(object)reader.ReadInt16();
                    break;
                case "System.UInt32":
                    Debug.Assert(size == 4);
                    Value = (T)(object)reader.ReadUInt32();
                    break;
                case "System.Int32":
                    Debug.Assert(size == 4);
                    Value = (T)(object)reader.ReadInt32();
                    break;
                case "System.Single":
                    Debug.Assert(size == 4);
                    Value = (T)(object)reader.ReadSingle();
                    break;
                case "System.UInt64":
                    Debug.Assert(size == 8);
                    Value = (T)(object)reader.ReadUInt64();
                    break;
                case "System.Int64":
                    Debug.Assert(size == 8);
                    Value = (T)(object)reader.ReadInt64();
                    break;
                case "System.Byte[]":
                    Value = (T)(object)reader.ReadBytes(size);
                    break;
                case "System.Char[]":
                    Value = (T)(object)reader.ReadChars(size);
                    break;
                case "System.String":
                    Value = (T)(object)new String(reader.ReadChars(size - 1));
                    reader.ReadByte();
                    break;
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            string typeT = typeof(T).ToString();

            switch (typeT)
            {
                case "System.Byte":
                    writer.Write((byte)(object)Value);
                    break;
                case "System.SByte":
                    writer.Write((sbyte)(object)Value);
                    break;
                case "System.Char":
                    writer.Write((char)(object)Value);
                    break;
                case "System.UInt16":
                    writer.Write((ushort)(object)Value);
                    break;
                case "System.Int16":
                    writer.Write((short)(object)Value);
                    break;
                case "System.UInt32":
                    writer.Write((uint)(object)Value);
                    break;
                case "System.Int32":
                    writer.Write((int)(object)Value);
                    break;
                case "System.Single":
                    writer.Write((float)(object)Value);
                    break;
                case "System.UInt64":
                    writer.Write((ulong)(object)Value);
                    break;
                case "System.Int64":
                    writer.Write((long)(object)Value);
                    break;
                case "System.Byte[]":
                    writer.Write((byte[])(object)Value);
                    break;
                case "System.Char[]":
                    writer.Write((char[])(object)Value);
                    break;
                case "System.String":
                    writer.Write(((string)(object)Value).ToCharArray());
                    writer.Write((byte)0);
                    break;
            }
        }

        protected override void WriteDataXML(XElement ele)
        {
            string typeT = typeof(T).ToString();

            switch (typeT)
            {
                case "System.Byte":
                    ele.Value = Value.ToString();
                    break;
                case "System.SByte":
                    ele.Value = Value.ToString();
                    break;
                case "System.Char":
                    ele.Value = Value.ToString();
                    break;
                case "System.UInt16":
                    ele.Value = Value.ToString();
                    break;
                case "System.Int16":
                    ele.Value = Value.ToString();
                    break;
                case "System.UInt32":
                    ele.Value = Value.ToString();
                    break;
                case "System.Int32":
                    ele.Value = Value.ToString();
                    break;
                case "System.Single":
                    ele.Value = Value.ToString();
                    break;
                case "System.UInt64":
                    ele.Value = Value.ToString();
                    break;
                case "System.Int64":
                    ele.Value = Value.ToString();
                    break;
                case "System.Byte[]":
                    ele.Value = ((byte[])(object)Value).ToHex();
                    break;
                case "System.Char[]":
                    ele.Value = new string((char[])(object)Value);
                    break;
                case "System.String":
                    ele.Value = Value.ToString();
                    break;
            }
        }

        protected override void ReadDataXML(XElement ele)
        {
            string typeT = typeof(T).ToString();

            switch (typeT)
            {
                case "System.Byte":
                    Value = (T)(object)ele.ToByte();
                    break;
                case "System.SByte":
                    Value = (T)(object)ele.ToSByte();
                    break;
                case "System.Char":
                    Value = (T)(object)ele.ToChar();
                    break;
                case "System.UInt16":
                    Value = (T)(object)ele.ToUInt16();
                    break;
                case "System.Int16":
                    Value = (T)(object)ele.ToInt16();
                    break;
                case "System.UInt32":
                    Value = (T)(object)ele.ToUInt32();
                    break;
                case "System.Int32":
                    Value = (T)(object)ele.ToInt32();
                    break;
                case "System.Single":
                    Value = (T)(object)ele.ToSingle();
                    break;
                case "System.UInt64":
                    Value = (T)(object)ele.ToUInt64();
                    break;
                case "System.Int64":
                    Value = (T)(object)ele.ToInt64();
                    break;
                case "System.Byte[]":
                    Value = (T)(object)ele.ToBytes();
                    break;
                case "System.Char[]":
                    Value = (T)(object)ele.ToChars();
                    break;
                case "System.String":
                    Value = (T)(object)ele.Value;
                    break;
            }
        }
    }
}
