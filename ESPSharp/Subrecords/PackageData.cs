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
    public partial class PackageData : Subrecord, ICloneable<PackageData>
    {
        public PackageFlags Flags { get; set; }
        public PackageType Type { get; set; }
        public FalloutBehaviorFlags FalloutBehaviorFlags { get; set; }
        public dynamic TypeFlags { get; set; }

        public PackageData()
        {
            Flags = new PackageFlags();
            Type = new PackageType();
            FalloutBehaviorFlags = new FalloutBehaviorFlags();
            TypeFlags = new UInt32();
        }

        public PackageData(PackageFlags Flags, PackageType Type, FalloutBehaviorFlags FalloutBehaviorFlags, dynamic TypeFlags)
        {
            this.Flags = Flags;
            this.Type = Type;
            this.FalloutBehaviorFlags = FalloutBehaviorFlags;
            this.TypeFlags = TypeFlags;
        }

        public PackageData(PackageData copyObject)
        {
            Flags = copyObject.Flags;
            Type = copyObject.Type;
            FalloutBehaviorFlags = copyObject.FalloutBehaviorFlags;
            TypeFlags = copyObject.TypeFlags;
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream))
            {
                try
                {
                    Flags = subReader.ReadEnum<PackageFlags>();
                    Type = subReader.ReadEnum<PackageType>();
                    FalloutBehaviorFlags = subReader.ReadEnum<FalloutBehaviorFlags>();

                    switch (Type)
                    {
                        case PackageType.Find:
                            TypeFlags = subReader.ReadEnum<FindEscortEatPackageFlags>();
                            break;
                        case PackageType.Follow:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.Escort:
                            TypeFlags = subReader.ReadEnum<FindEscortEatPackageFlags>();
                            break;
                        case PackageType.Eat:
                            TypeFlags = subReader.ReadEnum<FindEscortEatPackageFlags>();
                            break;
                        case PackageType.Sleep:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.Wander:
                            TypeFlags = subReader.ReadEnum<WanderSandboxPackageFlags>();
                            break;
                        case PackageType.Travel:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.Accompany:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.UseItemAt:
                            TypeFlags = subReader.ReadEnum<UseItemAtPackageFlags>();
                            break;
                        case PackageType.Ambush:
                            TypeFlags = subReader.ReadEnum<AmbushPackageFlags>();
                            break;
                        case PackageType.FleeNotCombat:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.Sandbox:
                            TypeFlags = subReader.ReadEnum<WanderSandboxPackageFlags>();
                            break;
                        case PackageType.Patrol:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.Guard:
                            TypeFlags = subReader.ReadEnum<GuardPackageFlags>();
                            break;
                        case PackageType.Dialog:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                        case PackageType.UseWeapon:
                            TypeFlags = subReader.ReadBytes(4);
                            break;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write((UInt32)Flags);
            writer.Write((UInt16)Type);
            writer.Write((UInt16)FalloutBehaviorFlags);

            switch (Type)
            {
                case PackageType.Find:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Follow:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Escort:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Eat:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Sleep:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Wander:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Travel:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Accompany:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.UseItemAt:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Ambush:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.FleeNotCombat:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Sandbox:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Patrol:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Guard:
                    writer.Write((uint)TypeFlags);
                    break;
                case PackageType.Dialog:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.UseWeapon:
                    writer.Write(TypeFlags);
                    break;
            }
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Flags", true, out subEle);
            subEle.Value = Flags.ToString();

            ele.TryPathTo("Type", true, out subEle);
            subEle.Value = Type.ToString();

            ele.TryPathTo("FalloutBehaviorFlags", true, out subEle);
            subEle.Value = FalloutBehaviorFlags.ToString();

            ele.TryPathTo("TypeFlags", true, out subEle);

            switch (Type)
            {
                case PackageType.Find:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Follow:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.Escort:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Eat:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Sleep:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.Wander:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Travel:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.Accompany:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.UseItemAt:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Ambush:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.FleeNotCombat:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.Sandbox:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Patrol:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.Guard:
                    subEle.Value = TypeFlags.ToString();
                    break;
                case PackageType.Dialog:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                case PackageType.UseWeapon:
                    subEle.Value = ((byte[])TypeFlags).ToBase64();
                    break;
                default:
                    break;
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Flags", false, out subEle))
            {
                Flags = subEle.ToEnum<PackageFlags>();
            }

            if (ele.TryPathTo("Type", false, out subEle))
            {
                Type = subEle.ToEnum<PackageType>();
            }

            if (ele.TryPathTo("FalloutBehaviorFlags", false, out subEle))
            {
                FalloutBehaviorFlags = subEle.ToEnum<FalloutBehaviorFlags>();
            }

            if (ele.TryPathTo("TypeFlags", false, out subEle))
            {
                switch (Type)
                {
                    case PackageType.Find:
                        TypeFlags = subEle.ToEnum<FindEscortEatPackageFlags>();
                        break;
                    case PackageType.Follow:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.Escort:
                        TypeFlags = subEle.ToEnum<FindEscortEatPackageFlags>();
                        break;
                    case PackageType.Eat:
                        TypeFlags = subEle.ToEnum<FindEscortEatPackageFlags>();
                        break;
                    case PackageType.Sleep:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.Wander:
                        TypeFlags = subEle.ToEnum<WanderSandboxPackageFlags>();
                        break;
                    case PackageType.Travel:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.Accompany:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.UseItemAt:
                        TypeFlags = subEle.ToEnum<UseItemAtPackageFlags>();
                        break;
                    case PackageType.Ambush:
                        TypeFlags = subEle.ToEnum<AmbushPackageFlags>();
                        break;
                    case PackageType.FleeNotCombat:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.Sandbox:
                        TypeFlags = subEle.ToEnum<WanderSandboxPackageFlags>();
                        break;
                    case PackageType.Patrol:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.Guard:
                        TypeFlags = subEle.ToEnum<GuardPackageFlags>();
                        break;
                    case PackageType.Dialog:
                        TypeFlags = subEle.ToBytes();
                        break;
                    case PackageType.UseWeapon:
                        TypeFlags = subEle.ToBytes();
                        break;
                }
            }
        }

        public PackageData Clone()
        {
            return new PackageData(this);
        }

    }
}