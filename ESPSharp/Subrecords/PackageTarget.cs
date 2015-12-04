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

namespace ESPSharp.Subrecords
{
    public class PackageTarget : Subrecord, ICloneable
    {
        public PackageTargetType Type { get; set; }
        public dynamic Target { get; set; }
        public Int32 Value { get; set; }
        public Single Unknown { get; set; }

        public PackageTarget()
        {
            Type = new PackageTargetType();
            Target = new UInt32();
            Value = new Int32();
            Unknown = new Single();
        }

        public PackageTarget(PackageTargetType Type, dynamic Target, Int32 Value, Single Unknown)
        {
            this.Type = Type;
            this.Target = Target;
            this.Value = Value;
            this.Unknown = Unknown;
        }

        public PackageTarget(PackageTarget copyObject)
        {
            Type = copyObject.Type;
            Target = copyObject.Target;
            Value = copyObject.Value;
            Unknown = copyObject.Unknown;
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
            {
                try
                {
                    Type = subReader.ReadEnum< PackageTargetType>();

                    switch (Type)
                    {
                        case PackageTargetType.SpecificReference:
                            Target = new FormID(subReader.ReadUInt32());
                            break;
                        case PackageTargetType.ObjectID:
                            Target = new FormID(subReader.ReadUInt32());
                            break;
                        case PackageTargetType.ObjectType:
                            Target = (ObjectType)subReader.ReadUInt32();
                            break;
                        case PackageTargetType.LinkedReference:
                            Target = subReader.ReadBytes(4);
                            break;
                    }

                    Value = subReader.ReadInt32();
                    Unknown = subReader.ReadSingle();
                }
                catch
                {
                    return;
                }
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write((uint)Type);

            switch (Type)
            {
                case PackageTargetType.SpecificReference:
                    (Target as FormID).WriteBinary(writer);
                    break;
                case PackageTargetType.ObjectID:
                    (Target as FormID).WriteBinary(writer);
                    break;
                case PackageTargetType.ObjectType:
                    writer.Write((uint)Target);
                    break;
                case PackageTargetType.LinkedReference:
                    writer.Write(Target);
                    break;
            }

            writer.Write(Value);
            writer.Write(Unknown);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Type", true, out subEle);
            subEle.Value = Type.ToString();

            ele.TryPathTo("Target", true, out subEle);
            switch (Type)
            {
                case PackageTargetType.SpecificReference:
                    (Target as FormID).WriteXML(subEle, master);
                    break;
                case PackageTargetType.ObjectID:
                    (Target as FormID).WriteXML(subEle, master);
                    break;
                case PackageTargetType.ObjectType:
                    subEle.Value = Target.ToString();
                    break;
                case PackageTargetType.LinkedReference:
                    subEle.Value = ((byte[])Target).ToBase64();
                    break;
            }

            ele.TryPathTo("Value", true, out subEle);
            subEle.Value = Value.ToString();

            ele.TryPathTo("Unknown", true, out subEle);
            subEle.Value = Unknown.ToString("G15");
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Type", false, out subEle))
            {
                Type = subEle.ToEnum<PackageTargetType>();
            }

            if (ele.TryPathTo("Target", false, out subEle))
            {
                switch (Type)
                {
                    case PackageTargetType.SpecificReference:
                        Target = new FormID();
                        (Target as FormID).ReadXML(subEle, master);
                        break;
                    case PackageTargetType.ObjectID:
                        Target = new FormID();
                        (Target as FormID).ReadXML(subEle, master);
                        break;
                    case PackageTargetType.ObjectType:
                        Target = subEle.ToEnum<ObjectType>();
                        break;
                    case PackageTargetType.LinkedReference:
                        Target = subEle.ToBytes();
                        break;
                }
            }

            if (ele.TryPathTo("Value", false, out subEle))
            {
                Value = subEle.ToInt32();
            }

            if (ele.TryPathTo("Unknown", false, out subEle))
            {
                Unknown = subEle.ToSingle();
            }
        }

        public override object Clone()
        {
            return new PackageTarget(this);
        }

    }
}
