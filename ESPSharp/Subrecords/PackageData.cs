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
    public partial class PackageData : Subrecord, ICloneable
    {
        partial void ReadTypeFlagsBinary(ESPReader reader)
        {
            switch (Type)
            {
                case PackageType.Find:
                    TypeFlags = reader.ReadEnum<FindEscortEatPackageFlags>();
                    break;
                case PackageType.Follow:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.Escort:
                    TypeFlags = reader.ReadEnum<FindEscortEatPackageFlags>();
                    break;
                case PackageType.Eat:
                    TypeFlags = reader.ReadEnum<FindEscortEatPackageFlags>();
                    break;
                case PackageType.Sleep:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.Wander:
                    TypeFlags = reader.ReadEnum<WanderSandboxPackageFlags>();
                    break;
                case PackageType.Travel:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.Accompany:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.UseItemAt:
                    TypeFlags = reader.ReadEnum<UseItemAtPackageFlags>();
                    break;
                case PackageType.Ambush:
                    TypeFlags = reader.ReadEnum<AmbushPackageFlags>();
                    break;
                case PackageType.FleeNotCombat:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.Sandbox:
                    TypeFlags = reader.ReadEnum<WanderSandboxPackageFlags>();
                    break;
                case PackageType.Patrol:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.Guard:
                    TypeFlags = reader.ReadEnum<GuardPackageFlags>();
                    break;
                case PackageType.Dialog:
                    TypeFlags = reader.ReadBytes(2);
                    break;
                case PackageType.UseWeapon:
                    TypeFlags = reader.ReadBytes(2);
                    break;
            }
        }

        partial void WriteTypeFlagsBinary(ESPWriter writer)
        {
            switch (Type)
            {
                case PackageType.Find:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Follow:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Escort:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Eat:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Sleep:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Wander:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Travel:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Accompany:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.UseItemAt:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Ambush:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.FleeNotCombat:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Sandbox:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Patrol:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.Guard:
                    writer.Write((ushort)TypeFlags);
                    break;
                case PackageType.Dialog:
                    writer.Write(TypeFlags);
                    break;
                case PackageType.UseWeapon:
                    writer.Write(TypeFlags);
                    break;
            }
        }

        partial void WriteTypeFlagsXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

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

        partial void ReadTypeFlagsXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

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
    }
}