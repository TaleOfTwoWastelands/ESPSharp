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

namespace ESPSharp.Records
{
    public partial class Challenge : Record, IEditorID
    {
        partial void ReadValue1(ESPReader reader)
        {
            switch (Data.Type)
            {
                case ChallengeType.KillFromAFormList:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.KillASpecificFormID:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.KillAnyInACategory:
                    Value1 = new SimpleSubrecord<byte[]>();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.HitAnEnemy:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.UseAnItem:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.AcquireAnItem:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.UseASkill:
                    Value1 = new SimpleSubrecord<ActorValues>();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.DoDamage:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.UseAnItemFromAList:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.MiscellaneousStat:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.CraftUsingAnItem:
                    Value1 = new RecordReference();
                    Value1.ReadBinary(reader);
                    break;
                case ChallengeType.ScriptedChallenge:
                    Value1 = new SimpleSubrecord<byte[]>();
                    Value1.ReadBinary(reader);
                    break;
            }
        }
        partial void ReadValue2(ESPReader reader)
        {
            switch (Data.Type)
            {
                case ChallengeType.KillFromAFormList:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.KillASpecificFormID:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.KillAnyInACategory:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.HitAnEnemy:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.UseAnItem:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.AcquireAnItem:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.UseASkill:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.DoDamage:
                    Value2 = new RecordReference();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.UseAnItemFromAList:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.MiscellaneousStat:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.CraftUsingAnItem:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
                case ChallengeType.ScriptedChallenge:
                    Value2 = new SimpleSubrecord<byte[]>();
                    Value2.ReadBinary(reader);
                    break;
            }
        }
        partial void WriteValue1(ESPWriter writer)
        {
            if (Value1 != null)
                Value1.WriteBinary(writer);
        }
        partial void WriteValue2(ESPWriter writer)
        {
            if (Value2 != null)
                Value2.WriteBinary(writer);
        }
        partial void WriteValue1XML(XElement ele, ElderScrollsPlugin master)
        {
            if (Value1 != null)
            {
                XElement subEle = new XElement("Dummy");
                switch (Data.Type)
                {
                    case ChallengeType.KillFromAFormList:
                        ele.TryPathTo("FormList", true, out subEle);
                        break;
                    case ChallengeType.KillASpecificFormID:
                        ele.TryPathTo("Actor", true, out subEle);
                        break;
                    case ChallengeType.HitAnEnemy:
                        ele.TryPathTo("Actor", true, out subEle);
                        break;
                    case ChallengeType.DiscoverAMapMarker:
                        ele.TryPathTo("MapMarker", true, out subEle);
                        break;
                    case ChallengeType.UseAnItem:
                        ele.TryPathTo("Ingestible", true, out subEle);
                        break;
                    case ChallengeType.AcquireAnItem:
                        ele.TryPathTo("Object", true, out subEle);
                        break;
                    case ChallengeType.UseASkill:
                        ele.TryPathTo("ActorValue", true, out subEle);
                        break;
                    case ChallengeType.DoDamage:
                        ele.TryPathTo("Creature", true, out subEle);
                        break;
                    case ChallengeType.UseAnItemFromAList:
                        ele.TryPathTo("FormList", true, out subEle);
                        break;
                    case ChallengeType.AcquireAnItemFromAList:
                        ele.TryPathTo("FormList", true, out subEle);
                        break;
                    case ChallengeType.MiscellaneousStat:
                        ele.TryPathTo("Stat", true, out subEle);
                        break;
                    case ChallengeType.CraftUsingAnItem:
                        ele.TryPathTo("Object", true, out subEle);
                        break;
                    default:
                        return;
                }
                Value1.WriteXML(subEle, master);
            }
        }
        partial void WriteValue2XML(XElement ele, ElderScrollsPlugin master)
        {
            if (Value2 != null)
            {
                XElement subEle = new XElement("Dummy");
                switch (Data.Type)
                {
                    case ChallengeType.KillFromAFormList:
                        ele.TryPathTo("WeaponList", true, out subEle);
                        break;
                    case ChallengeType.KillASpecificFormID:
                        ele.TryPathTo("WeaponList", true, out subEle);
                        break;
                    case ChallengeType.KillAnyInACategory:
                        ele.TryPathTo("WeaponList", true, out subEle);
                        break;
                    case ChallengeType.HitAnEnemy:
                        ele.TryPathTo("WeaponList", true, out subEle);
                        break;
                    case ChallengeType.DiscoverAMapMarker:
                        ele.TryPathTo("LocationList", true, out subEle);
                        break;
                    case ChallengeType.DoDamage:
                        ele.TryPathTo("WeaponList", true, out subEle);
                        break;
                    default:
                        return;
                }
                Value2.WriteXML(subEle, master);
            }
        }
        partial void ReadValue1XML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle = new XElement("Dummy");
            switch (Data.Type)
            {
                case ChallengeType.KillFromAFormList:
                    if (ele.TryPathTo("FormList", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.KillASpecificFormID:
                    if (ele.TryPathTo("Actor", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.HitAnEnemy:
                    if (ele.TryPathTo("Actor", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    if (ele.TryPathTo("MapMarker", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.UseAnItem:
                    if (ele.TryPathTo("Ingestible", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.AcquireAnItem:
                    if (ele.TryPathTo("Object", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.UseASkill:
                    if (ele.TryPathTo("ActorValue", false, out subEle))
                        Value1 = new SimpleSubrecord<ActorValues>();
                    else
                        return;
                    break;
                case ChallengeType.DoDamage:
                    if (ele.TryPathTo("Creature", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.UseAnItemFromAList:
                    if (ele.TryPathTo("FormList", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.AcquireAnItemFromAList:
                    if (ele.TryPathTo("FormList", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.MiscellaneousStat:
                    if (ele.TryPathTo("Stat", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.CraftUsingAnItem:
                    if (ele.TryPathTo("Object", false, out subEle))
                        Value1 = new RecordReference();
                    else
                        return;
                    break;
                default:
                    return;
            }
            Value1.ReadXML(subEle, master);
        }
        partial void ReadValue2XML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle = new XElement("Dummy");
            switch (Data.Type)
            {
                case ChallengeType.KillFromAFormList:
                    if (ele.TryPathTo("WeaponList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.KillASpecificFormID:
                    if (ele.TryPathTo("WeaponList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.KillAnyInACategory:
                    if (ele.TryPathTo("WeaponList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.HitAnEnemy:
                    if (ele.TryPathTo("WeaponList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.DiscoverAMapMarker:
                    if (ele.TryPathTo("LocationList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                case ChallengeType.DoDamage:
                    if (ele.TryPathTo("WeaponList", false, out subEle))
                        Value2 = new RecordReference();
                    else
                        return;
                    break;
                default:
                    return;
            }
            Value2.ReadXML(subEle, master);
        }   
    }
}