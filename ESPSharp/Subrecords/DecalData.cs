using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp.Subrecords
{
    public class DecalData : Subrecord
    {
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public float Depth { get; set; }
        public float Shininess { get; set; }
        public float ParallaxScale { get; set; }
        public byte ParallaxPasses { get; set; }
        public DecalDataFlags Flags { get; set; }
        public byte[] Unused { get; set; }
        public Color Color;

        protected override void ReadData(ESPReader reader)
        {
            MinWidth = reader.ReadSingle();
            MaxWidth = reader.ReadSingle();
            MinHeight = reader.ReadSingle();
            MaxHeight = reader.ReadSingle();
            Depth = reader.ReadSingle();
            Shininess = reader.ReadSingle();
            ParallaxScale = reader.ReadSingle();
            ParallaxPasses = reader.ReadByte();
            Flags = (DecalDataFlags)reader.ReadByte();
            Unused = reader.ReadBytes(2);
            Color.Red = reader.ReadByte();
            Color.Green = reader.ReadByte();
            Color.Blue = reader.ReadByte();
            Color.Alpha = reader.ReadByte();
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(MinWidth);
            writer.Write(MaxWidth);
            writer.Write(MinHeight);
            writer.Write(MaxHeight);
            writer.Write(Depth);
            writer.Write(Shininess);
            writer.Write(ParallaxScale);
            writer.Write(ParallaxPasses);
            writer.Write((byte)Flags);
            writer.Write(Unused);
            writer.Write(Color.Red);
            writer.Write(Color.Green);
            writer.Write(Color.Blue);
            writer.Write(Color.Alpha);
        }

        protected override void WriteDataXML(XElement ele)
        {
            ele.Add(
                new XElement("Width",
                    new XElement("Min", MinWidth),
                    new XElement("Max", MaxWidth)),
                new XElement("Height",
                    new XElement("Min", MinHeight),
                    new XElement("Max", MaxHeight)),
                new XElement("Depth", Depth),
                new XElement("Shininess", Shininess),
                new XElement("ParallaxScale", ParallaxScale),
                new XElement("ParallaxPasses", ParallaxPasses),
                new XElement("Flags", Flags),
                new XElement("Unused", Unused.ToHex()),
                new XElement("Color",
                    new XElement("Red", Color.Red),
                    new XElement("Green", Color.Green),
                    new XElement("Blue", Color.Blue),
                    new XElement("Alpha", Color.Alpha)));
        }

        protected override void ReadDataXML(XElement ele)
        {
            MinWidth = ele.Element("Width").Element("Min").ToSingle();
            MaxWidth = ele.Element("Width").Element("Max").ToSingle();
            MinHeight = ele.Element("Height").Element("Min").ToSingle();
            MaxHeight = ele.Element("Height").Element("Max").ToSingle();
            Depth = ele.Element("Depth").ToSingle();
            Shininess = ele.Element("Shininess").ToSingle();
            ParallaxScale = ele.Element("ParallaxScale").ToSingle();
            ParallaxPasses = ele.Element("ParallaxPasses").ToByte();
            Flags = ele.Element("Flags").ToEnum<DecalDataFlags>();
            Unused = ele.Element("Unused").ToBytes();
            Color.Red = ele.Element("Color").Element("Red").ToByte();
            Color.Green = ele.Element("Color").Element("Green").ToByte();
            Color.Blue = ele.Element("Color").Element("Blue").ToByte();
            Color.Alpha = ele.Element("Color").Element("Alpha").ToByte();
        }
    }

    [Flags]
    public enum DecalDataFlags : byte
    {
        Parallax = 0x00000001,
        AlphaBlending = 0x00000002,
        AlphaTesting = 0x00000004,
        Unknown8 = 0x00000008,
        Unknown10 = 0x00000010,
        Unknown20 = 0x00000020,
        Unknown40 = 0x00000040,
        Unknown80 = 0x00000080
    }
}
