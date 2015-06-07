using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPSharp.Interfaces;
using System.Xml.Linq;

namespace ESPSharp
{
    public class Color : IESPSerializable, ICloneable<Color>
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha_Unused;

        public Color()
        {
            Red = new byte();
            Green = new byte();
            Blue = new byte();
            Alpha_Unused = new byte();
        }

        public Color(byte Red, byte Green, byte Blue, byte Alpha_Unused)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
            this.Alpha_Unused = Alpha_Unused;
        }

        public Color(Color toCopy)
        {
            Red = toCopy.Red;
            Green = toCopy.Green;
            Blue = toCopy.Blue;
            Alpha_Unused = toCopy.Alpha_Unused;
        }

        public void WriteXML(XElement ele)
        {
            ele.Add(
                new XElement("Red", Red),
                new XElement("Green", Green),
                new XElement("Blue", Blue),
                new XElement("Alpha_Unused", Alpha_Unused)
                );
        }

        public void ReadXML(XElement ele)
        {
            Red = ele.Element("Red").ToByte();
            Green = ele.Element("Green").ToByte();
            Blue = ele.Element("Blue").ToByte();
            Alpha_Unused = ele.Element("Alpha_Unused").ToByte();
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write(Red);
            writer.Write(Green);
            writer.Write(Blue);
            writer.Write(Alpha_Unused);
        }

        public void ReadBinary(ESPReader reader)
        {
            Red = reader.ReadByte();
            Green = reader.ReadByte();
            Blue = reader.ReadByte();
            Alpha_Unused = reader.ReadByte();
        }

        public Color Clone()
        {
            return new Color(this);
        }
    }
}
