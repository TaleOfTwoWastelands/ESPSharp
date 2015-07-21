using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ESPSharp.DataTypes;
using ESPSharp.Interfaces;

namespace ESPSharp.Subrecords
{
    public class SubNullStringList : Subrecord, ICloneable
    {
        List<string> Strings { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            string data = new string(reader.ReadChars(size));

            Strings = data.Split(new char[] {'\0'}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        protected override void WriteData(ESPWriter writer)
        {
            string data = String.Join("\0", Strings);

            writer.Write(data.ToCharArray());
            writer.Write((byte)0);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var entry in Strings)
                ele.Add(new XElement("Entry", entry));
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Strings = new List<string>();

            foreach (var subEle in ele.Elements("Entry"))
            {
                Strings.Add(subEle.Value);
            }
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
