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
    public partial class ChallengeData : Subrecord, ICloneable<ChallengeData>
    {
        public ChallengeType Type { get; set; }
        public UInt32 Threshold { get; set; }
        public ChallengeFlags Flags { get; set; }
        public UInt32 Interval { get; set; }
        public dynamic Value1 { get; set; }
        public dynamic Value2 { get; set; }
        public dynamic Value3 { get; set; }

        public ChallengeData()
        {
            Type = new ChallengeType();
            Threshold = new UInt32();
            Flags = new ChallengeFlags();
            Interval = new UInt32();
            Value1 = new Int16();
            Value2 = new Int16();
            Value3 = new Int32();
        }

        public ChallengeData(ChallengeType Type, UInt32 Threshold, ChallengeFlags Flags, UInt32 Interval, dynamic Value1, dynamic Value2, dynamic Value3)
        {
            this.Type = Type;
            this.Threshold = Threshold;
            this.Flags = Flags;
            this.Interval = Interval;
            this.Value1 = Value1;
            this.Value2 = Value2;
            this.Value3 = Value3;
        }

        public ChallengeData(ChallengeData copyObject)
        {
            Type = copyObject.Type;
            Threshold = copyObject.Threshold;
            Flags = copyObject.Flags;
            Interval = copyObject.Interval;
            Value1 = copyObject.Value1;
            Value2 = copyObject.Value2;
            Value3 = copyObject.Value3;
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream))
            {
                try
                {
                    Type = subReader.ReadEnum<ChallengeType>();
                    Threshold = subReader.ReadUInt32();
                    Flags = subReader.ReadEnum<ChallengeFlags>();
                    Interval = subReader.ReadUInt32();

                    switch (Type)
                    {
                        case ChallengeType.KillFromAFormList:
                            Value1 = (ChallengeBodyPart)subReader.ReadInt16();
                            Value2 = (ActorValues)subReader.ReadInt16();
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.KillASpecificFormID:
                            Value1 = (ChallengeBodyPart)subReader.ReadInt16();
                            Value2 = (ActorValues)subReader.ReadInt16();
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.KillAnyInACategory:
                            Value1 = (ChallengeBodyPart)subReader.ReadInt16();
                            Value2 = (CreatureType)subReader.ReadInt16();
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.HitAnEnemy:
                            Value1 = (ChallengeBodyPart)subReader.ReadInt16();
                            Value2 = (ChallengeHitType)subReader.ReadInt16();
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.DiscoverAMapMarker:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.UseAnItem:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.AcquireAnItem:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.UseASkill:
                            Value1 = (ChallengeSkillResult)subReader.ReadInt16();
                            Value2 = (SpeechChallengeType)subReader.ReadInt16();
                            Value3 = subReader.ReadBytes(4);                            
                            break;
                        case ChallengeType.DoDamage:
                            Value1 = (ChallengeBodyPart)subReader.ReadInt16();
                            Value2 = (ActorValues)subReader.ReadInt16();
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.UseAnItemFromAList:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.AcquireAnItemFromAList:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.MiscellaneousStat:
                            Value1 = (MiscStat)subReader.ReadInt16();
                            Value2 = subReader.ReadBytes(2);
                            Value3 = (WeaponCategory)subReader.ReadInt32();
                            break;
                        case ChallengeType.CraftUsingAnItem:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
                            break;
                        case ChallengeType.ScriptedChallenge:
                            Value1 = subReader.ReadBytes(2);
                            Value2 = subReader.ReadBytes(2);
                            Value3 = subReader.ReadBytes(4);
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
            writer.Write((UInt32)Type);
            writer.Write(Threshold);
            writer.Write((UInt32)Flags);
            writer.Write(Interval);

            switch (Type)
            {
                case ChallengeType.KillFromAFormList:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.KillASpecificFormID:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.KillAnyInACategory:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.HitAnEnemy:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.UseAnItem:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.AcquireAnItem:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.UseASkill:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write(Value3);     
                    break;
                case ChallengeType.DoDamage:
                    writer.Write((ushort)Value1);
                    writer.Write((ushort)Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.UseAnItemFromAList:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.MiscellaneousStat:
                    writer.Write((ushort)Value1);
                    writer.Write(Value2);
                    writer.Write((uint)Value3);
                    break;
                case ChallengeType.CraftUsingAnItem:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
                case ChallengeType.ScriptedChallenge:
                    writer.Write(Value1);
                    writer.Write(Value2);
                    writer.Write(Value3);
                    break;
            }
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Type", true, out subEle);
            subEle.Value = Type.ToString();

            ele.TryPathTo("Threshold", true, out subEle);
            subEle.Value = Threshold.ToString();

            ele.TryPathTo("Flags", true, out subEle);
            subEle.Value = Flags.ToString();

            ele.TryPathTo("Interval", true, out subEle);
            subEle.Value = Interval.ToString();

            switch (Type)
            {
                case ChallengeType.KillFromAFormList:
                    ele.TryPathTo("BodyPart", true, out subEle);
                    subEle.Value = Value1.ToString();
                    
                    ele.TryPathTo("WeaponActorValue", true, out subEle);
                    subEle.Value = Value2.ToString();
                    
                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.KillASpecificFormID:
                    ele.TryPathTo("BodyPart", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("WeaponActorValue", true, out subEle);
                    subEle.Value = Value2.ToString();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.KillAnyInACategory:
                    ele.TryPathTo("BodyPart", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("CreatureType", true, out subEle);
                    subEle.Value = Value2.ToString();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.HitAnEnemy:
                    ele.TryPathTo("BodyPart", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("TypeOfHit", true, out subEle);
                    subEle.Value = Value2.ToString();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.UseAnItem:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.AcquireAnItem:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.UseASkill:
                    ele.TryPathTo("Result", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("Difficulty", true, out subEle);
                    subEle.Value = Value2.ToString();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.DoDamage:
                    ele.TryPathTo("BodyPart", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("WeaponActorValue", true, out subEle);
                    subEle.Value = Value2.ToString();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.UseAnItemFromAList:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.MiscellaneousStat:
                    ele.TryPathTo("MiscStat", true, out subEle);
                    subEle.Value = Value1.ToString();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    subEle.Value = Value3.ToString();
                    break;
                case ChallengeType.CraftUsingAnItem:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
                case ChallengeType.ScriptedChallenge:
                    ele.TryPathTo("Unused1", true, out subEle);
                    subEle.Value = (Value1 as byte[]).ToBase64();

                    ele.TryPathTo("Unused2", true, out subEle);
                    subEle.Value = (Value2 as byte[]).ToBase64();

                    ele.TryPathTo("Unused3", true, out subEle);
                    subEle.Value = (Value3 as byte[]).ToBase64();
                    break;
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Type", false, out subEle))
            {
                Type = subEle.ToEnum<ChallengeType>();
            }

            if (ele.TryPathTo("Threshold", false, out subEle))
            {
                Threshold = subEle.ToUInt32();
            }

            if (ele.TryPathTo("Flags", false, out subEle))
            {
                Flags = subEle.ToEnum<ChallengeFlags>();
            }

            if (ele.TryPathTo("Interval", false, out subEle))
            {
                Interval = subEle.ToUInt32();
            }

            switch (Type)
            {
                case ChallengeType.KillFromAFormList:
                    ele.TryPathTo("BodyPart", false, out subEle);
                    Value1 = subEle.ToEnum<ChallengeBodyPart>();

                    ele.TryPathTo("WeaponActorValue", false, out subEle);
                    Value2 = subEle.ToEnum<ActorValues>();

                    ele.TryPathTo("WeaponCategory", false, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.KillASpecificFormID:
                    ele.TryPathTo("BodyPart", false, out subEle);
                    Value1 = subEle.ToEnum<ChallengeBodyPart>();

                    ele.TryPathTo("WeaponActorValue", false, out subEle);
                    Value2 = subEle.ToEnum<ActorValues>();

                    ele.TryPathTo("WeaponCategory", false, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.KillAnyInACategory:
                    ele.TryPathTo("BodyPart", false, out subEle);
                    Value1 = subEle.ToEnum<ChallengeBodyPart>();

                    ele.TryPathTo("CreatureType", true, out subEle);
                    Value2 = subEle.ToEnum<CreatureType>();

                    ele.TryPathTo("WeaponCategory", false, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.HitAnEnemy:
                    ele.TryPathTo("BodyPart", false, out subEle);
                    Value1 = subEle.ToEnum<ChallengeBodyPart>();

                    ele.TryPathTo("TypeOfHit", true, out subEle);
                    Value2 = subEle.ToEnum<ChallengeHitType>();

                    ele.TryPathTo("WeaponCategory", false, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.UseAnItem:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.AcquireAnItem:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.UseASkill:
                    ele.TryPathTo("Result", true, out subEle);
                    Value1 = subEle.ToEnum<ChallengeSkillResult>();

                    ele.TryPathTo("Difficulty", true, out subEle);
                    Value2 = subEle.ToEnum<SpeechChallengeType>();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.DoDamage:
                    ele.TryPathTo("BodyPart", false, out subEle);
                    Value1 = subEle.ToEnum<ChallengeBodyPart>();

                    ele.TryPathTo("WeaponActorValue", false, out subEle);
                    Value2 = subEle.ToEnum<ActorValues>();

                    ele.TryPathTo("WeaponCategory", false, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.UseAnItemFromAList:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.MiscellaneousStat:
                    ele.TryPathTo("MiscStat", true, out subEle);
                    Value1 = subEle.ToEnum<MiscStat>();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("WeaponCategory", true, out subEle);
                    Value3 = subEle.ToEnum<WeaponCategory>();
                    break;
                case ChallengeType.CraftUsingAnItem:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
                case ChallengeType.ScriptedChallenge:
                    ele.TryPathTo("Unused1", false, out subEle);
                    Value1 = subEle.ToBytes();

                    ele.TryPathTo("Unused2", false, out subEle);
                    Value2 = subEle.ToBytes();

                    ele.TryPathTo("Unused3", false, out subEle);
                    Value3 = subEle.ToBytes();
                    break;
            }
        }

        public ChallengeData Clone()
        {
            return new ChallengeData(this);
        }

    }
}
