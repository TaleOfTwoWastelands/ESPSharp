using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.DataTypes
{
    public class MoonData : IESPSerializable, ICloneable<MoonData>, IReferenceContainer
    {
        public MoonFlags Moons { get; set; }
        public byte PhaseLength { get; set; }

        public MoonData()
        {
            Moons = new MoonFlags();
            PhaseLength = 0;
        }

        public MoonData(MoonFlags Moons, byte PhaseLength)
        {
            this.Moons = Moons;
            this.PhaseLength = PhaseLength;
        }

        public MoonData(MoonData copyObject)
        {
            Moons = copyObject.Moons;
            PhaseLength = copyObject.PhaseLength;
        }

        public void ReadBinary(ESPReader reader)
        {
            byte temp = reader.ReadByte();
            Moons = (MoonFlags)(temp >> 6);
            PhaseLength = (byte)(temp & (byte)0x3F);
        }

        public void WriteBinary(ESPWriter writer)
        {
            byte temp = (byte)(PhaseLength | ((byte)Moons << 6));
            writer.Write(temp);
        }

        public void WriteXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Moons", true, out subEle);
            subEle.Value = Moons.ToString();

            ele.TryPathTo("PhaseLength", true, out subEle);
            subEle.Value = PhaseLength.ToString();
        }

        public void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Moons", false, out subEle))
            {
                Moons = subEle.ToEnum<MoonFlags>();
            }

            if (ele.TryPathTo("PhaseLength", false, out subEle))
            {
                PhaseLength = subEle.ToByte();
            }
        }

        public MoonData Clone()
        {
            return new MoonData(this);
        }
    }
}
