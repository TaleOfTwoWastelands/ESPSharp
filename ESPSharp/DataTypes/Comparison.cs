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
    public class Comparison : IESPSerializable, ICloneable<Comparison>, IReferenceContainer
    {
        public ConditionFlags Flags { get; set; }
        public ConditionComparisonType Operator { get; set; }
        public byte[] Unused { get; set; }
        public dynamic ComparisonValue { get; set; }

        public Comparison()
        {
            Flags = new ConditionFlags();
            Operator = new ConditionComparisonType();
            Unused = new byte[3];
            ComparisonValue = 0;
        }

        public Comparison(ConditionFlags Flags, ConditionComparisonType Operator, byte[] Unused, FormID ComparisonValue)
        {
            this.Flags = Flags;
            this.Operator = Operator;
            this.Unused = Unused;
            this.ComparisonValue = ComparisonValue.Clone();
        }

        public Comparison(ConditionFlags Flags, ConditionComparisonType Operator, byte[] Unused, float ComparisonValue)
        {
            this.Flags = Flags;
            this.Operator = Operator;
            this.Unused = Unused;
            this.ComparisonValue = ComparisonValue;
        }

        public Comparison(Comparison copyObject)
        {
            Flags = copyObject.Flags;
            Operator = copyObject.Operator;
            Unused = (byte[])copyObject.Unused.Clone();
            if (copyObject.ComparisonValue is FormID)
                ComparisonValue = copyObject.ComparisonValue.Clone();
            else
                ComparisonValue = copyObject.ComparisonValue;
        }

        public void ReadBinary(ESPReader reader)
        {
            byte temp = reader.ReadByte();
            Flags = (ConditionFlags)(temp & (byte)0x0F);
            Operator = (ConditionComparisonType)(temp & (byte)0xF0);
            Unused = reader.ReadBytes(3);
            if (Flags.HasFlag(ConditionFlags.UseGlobal))
                ComparisonValue = new FormID(reader.ReadUInt32());
            else
                ComparisonValue = reader.ReadSingle();
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write((byte)((byte)Flags | (byte)Operator));
            writer.Write(Unused);
            if (Flags.HasFlag(ConditionFlags.UseGlobal))
                ComparisonValue.WriteBinary(writer);
            else
                writer.Write((Single)ComparisonValue);
        }

        public void WriteXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Flags", true, out subEle);
            subEle.Value = Flags.ToString();

            ele.TryPathTo("Operator", true, out subEle);
            subEle.Value = Operator.ToString();

            ele.TryPathTo("Unused", true, out subEle);
            subEle.Value = Unused.ToHex();

            ele.TryPathTo("ComparisonValue", true, out subEle);
            if (Flags.HasFlag(ConditionFlags.UseGlobal))
                ComparisonValue.WriteXML(subEle, master);
            else
                subEle.Value = ComparisonValue.ToString("G15");
        }

        public void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Flags", false, out subEle))
            {
                Flags = subEle.ToEnum<ConditionFlags>();
            }

            if (ele.TryPathTo("Operator", false, out subEle))
            {
                Operator = subEle.ToEnum<ConditionComparisonType>();
            }

            if (ele.TryPathTo("Unused", false, out subEle))
            {
                Unused = subEle.ToBytes();
            }

            if (ele.TryPathTo("ComparisonValue", false, out subEle))
            {
                if (Flags.HasFlag(ConditionFlags.UseGlobal))
                {
                    ComparisonValue = new FormID();
                    ComparisonValue.ReadXML(subEle, master);
                }
                else
                    ComparisonValue = subEle.ToSingle();
            }
        }

        public Comparison Clone()
        {
            return new Comparison(this);
        }
    }
}
