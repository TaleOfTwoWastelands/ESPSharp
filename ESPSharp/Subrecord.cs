﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using ESPSharp.Interfaces;

namespace ESPSharp
{
    public abstract class Subrecord : ICloneable
    {
        public string Tag { get; set; }
        protected int size;

        public Subrecord(string Tag = null)
        {
            this.Tag = Tag;
        }

        public virtual void WriteXML(XElement root, ElderScrollsPlugin master)
        {
            root.Add(new XAttribute("Tag", Tag));
            WriteDataXML(root, master);
        }

        public virtual void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            Tag = ele.Attribute("Tag").Value;
            ReadDataXML(ele, master);
        }

        public virtual void WriteBinary(ESPWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());
            writer.Write((ushort)0);

            long dataPoint = writer.BaseStream.Position;
            WriteData(writer);
            long dataEnd = writer.BaseStream.Position;

            if ((dataEnd - dataPoint) <= ushort.MaxValue)
            {
                writer.BaseStream.Seek(dataPoint - 2, SeekOrigin.Begin);
                writer.Write((ushort)(dataEnd - dataPoint));

                writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
            }
        }

        public virtual void ReadBinary(ESPReader reader)
        {
            Tag = reader.ReadTag();
            size = reader.ReadUInt16();

            long endPosition = reader.BaseStream.Position + size;

            ReadData(reader);

            if (reader.BaseStream.Position != endPosition)
                reader.BaseStream.Seek(endPosition, SeekOrigin.Begin);
        }

        protected abstract void ReadData(ESPReader reader);
        protected abstract void WriteData(ESPWriter writer);
        protected abstract void WriteDataXML(XElement ele, ElderScrollsPlugin master);
        protected abstract void ReadDataXML(XElement ele, ElderScrollsPlugin master);
        public abstract object Clone();
    }
}
