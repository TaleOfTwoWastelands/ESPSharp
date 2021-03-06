﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;

namespace ESPSharp.Records
{
    public class GenericRecord : Record
    {
        public List<UndecodedSubrecord> Subrecords = new List<UndecodedSubrecord>();

        public override void ReadData(ESPReader reader, long dataEnd)
        {
            while (reader.BaseStream.Position < dataEnd)
            {
                UndecodedSubrecord sub = new UndecodedSubrecord();
                sub.ReadBinary(reader);
                Subrecords.Add(sub);
            }
        }

        public override void WriteData(ESPWriter writer)
        {
            foreach (Subrecord sub in Subrecords)
                sub.WriteBinary(writer);
        }

        public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (UndecodedSubrecord sub in Subrecords)
            {
                XElement subEle = new XElement("Subrecord");
                sub.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach(XElement subEle in ele.Elements("Subrecord"))
            {
                UndecodedSubrecord sub = new UndecodedSubrecord();
                sub.ReadXML(subEle, master);
                Subrecords.Add(sub);
            }
        }
    }
}
