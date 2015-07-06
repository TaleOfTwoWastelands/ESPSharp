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

namespace ESPSharp.SubrecordCollections
{
    public partial class PerkEffect : SubrecordCollection, ICloneable<PerkEffect>
    {
        public PerkEffectHeader Header { get; set; }
        public Subrecord EffectData { get; set; }
        public List<PerkCondition> Conditions { get; set; }
        public SimpleSubrecord<EntryPointFunctionType> EntryPointFunctionType { get; set; }
        public Subrecord EntryPointFunctionData { get; set; }
        public SimpleSubrecord<String> ButtonLabel { get; set; }
        public SimpleSubrecord<NoYesShort> RunImmediately { get; set; }
        public EmbeddedScript Script { get; set; }
        public SubMarker EndMarker { get; set; }

        public PerkEffect()
        {
            Header = new PerkEffectHeader();
        }

        public PerkEffect(PerkEffectHeader Header, SimpleSubrecord<Byte[]> EffectData, List<PerkCondition> Conditions, SimpleSubrecord<EntryPointFunctionType> EntryPointFunctionType, SimpleSubrecord<Byte[]> EntryPointFunctionData, SimpleSubrecord<String> ButtonLabel, SimpleSubrecord<NoYesShort> RunImmediately, EmbeddedScript Script, SubMarker EndMarker)
        {
            this.Header = Header;
            this.EffectData = EffectData;
            this.Conditions = Conditions;
            this.EntryPointFunctionType = EntryPointFunctionType;
            this.EntryPointFunctionData = EntryPointFunctionData;
            this.ButtonLabel = ButtonLabel;
            this.RunImmediately = RunImmediately;
            this.Script = Script;
            this.EndMarker = EndMarker;
        }

        public PerkEffect(PerkEffect copyObject)
        {
            Header = copyObject.Header.Clone();
            switch (Header.Type)
            {
                case PerkType.QuestStage:
                    EffectData = (copyObject.EffectData as PerkQuestStageData).Clone();
                    break;
                case PerkType.Ability:
                    EffectData = (copyObject.EffectData as PerkAbilityData).Clone();
                    break;
                case PerkType.EntryPoint:
                    EffectData = (copyObject.EffectData as PerkEntryPointData).Clone();
                    break;
            }
            Conditions = new List<PerkCondition>();
            foreach (var item in copyObject.Conditions)
            {
                Conditions.Add(item.Clone());
            }
            EntryPointFunctionType = copyObject.EntryPointFunctionType.Clone();
            switch (EntryPointFunctionType.Value)
            {
                case Enums.EntryPointFunctionType.None:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as SimpleSubrecord<byte[]>).Clone();
                    break;
                case Enums.EntryPointFunctionType.Float:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as SimpleSubrecord<float>).Clone();
                    break;
                case Enums.EntryPointFunctionType.FloatFloat:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as EntryPointRandRange).Clone();
                    break;
                case Enums.EntryPointFunctionType.LeveledItem:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as RecordReference).Clone();
                    break;
                case Enums.EntryPointFunctionType.Script:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as SimpleSubrecord<byte[]>).Clone();
                    break;
                case Enums.EntryPointFunctionType.ActorValueMult:
                    EntryPointFunctionData = (copyObject.EntryPointFunctionData as EntryPointActorValMult).Clone();
                    break;
            }
            ButtonLabel = copyObject.ButtonLabel.Clone();
            RunImmediately = copyObject.RunImmediately.Clone();
            Script = copyObject.Script.Clone();
            EndMarker = copyObject.EndMarker.Clone();
        }

        public override void ReadBinary(ESPReader reader)
        {
            List<string> readTags = new List<string>();

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                string subTag = reader.PeekTag();

                switch (subTag)
                {
                    case "PRKE":
                        if (readTags.Contains("PRKE"))
                            return;
                        Header.ReadBinary(reader);
                        break;
                    case "DATA":
                        if (readTags.Contains("DATA"))
                            return;

                        switch (Header.Type)
	                    {
                            case PerkType.QuestStage:
                                EffectData = new PerkQuestStageData();
                                break;
                            case PerkType.Ability:
                                EffectData = new PerkAbilityData();
                                break;
                            case PerkType.EntryPoint:
                                EffectData = new PerkEntryPointData();
                                break;
	                    }

                        EffectData.ReadBinary(reader);
                        break;
                    case "PRKC":
                        if (Conditions == null)
                            Conditions = new List<PerkCondition>();

                        PerkCondition tempPRKC = new PerkCondition();
                        tempPRKC.ReadBinary(reader);
                        Conditions.Add(tempPRKC);
                        break;
                    case "EPFT":
                        if (readTags.Contains("EPFT"))
                            return;
                        if (EntryPointFunctionType == null)
                            EntryPointFunctionType = new SimpleSubrecord<EntryPointFunctionType>();

                        EntryPointFunctionType.ReadBinary(reader);
                        break;
                    case "EPFD":
                        if (readTags.Contains("EPFD"))
                            return;
                        switch (EntryPointFunctionType.Value)
	                    {
                            case Enums.EntryPointFunctionType.None:
                                EntryPointFunctionData = new SimpleSubrecord<byte[]>();
                                break;
                            case Enums.EntryPointFunctionType.Float:
                                EntryPointFunctionData = new SimpleSubrecord<float>();
                                break;
                            case Enums.EntryPointFunctionType.FloatFloat:
                                EntryPointFunctionData = new EntryPointRandRange();
                                break;
                            case Enums.EntryPointFunctionType.LeveledItem:
                                EntryPointFunctionData = new RecordReference();
                                break;
                            case Enums.EntryPointFunctionType.Script:
                                EntryPointFunctionData = new SimpleSubrecord<byte[]>();
                                break;
                            case Enums.EntryPointFunctionType.ActorValueMult:
                                EntryPointFunctionData = new EntryPointActorValMult();
                                break;
	                    }

                        EntryPointFunctionData.ReadBinary(reader);
                        break;
                    case "EPF2":
                        if (readTags.Contains("EPF2"))
                            return;
                        if (ButtonLabel == null)
                            ButtonLabel = new SimpleSubrecord<String>();

                        ButtonLabel.ReadBinary(reader);
                        break;
                    case "EPF3":
                        if (readTags.Contains("EPF3"))
                            return;
                        if (RunImmediately == null)
                            RunImmediately = new SimpleSubrecord<NoYesShort>();

                        RunImmediately.ReadBinary(reader);
                        break;
                    case "SCHR":
                        if (readTags.Contains("SCHR"))
                            return;
                        if (Script == null)
                            Script = new EmbeddedScript();

                        Script.ReadBinary(reader);
                        break;
                    case "PRKF":
                        if (readTags.Contains("PRKF"))
                            return;
                        if (EndMarker == null)
                            EndMarker = new SubMarker();

                        EndMarker.ReadBinary(reader);
                        break;
                    default:
                        return;
                }

                readTags.Add(subTag);
            }
        }

        public override void WriteBinary(ESPWriter writer)
        {
            if (Header != null)
                Header.WriteBinary(writer);
            if (EffectData != null)
                EffectData.WriteBinary(writer);
            if (Conditions != null)
                foreach (var item in Conditions)
                    item.WriteBinary(writer);
            if (EntryPointFunctionType != null)
                EntryPointFunctionType.WriteBinary(writer);
            if (EntryPointFunctionData != null)
                EntryPointFunctionData.WriteBinary(writer);
            if (ButtonLabel != null)
                ButtonLabel.WriteBinary(writer);
            if (RunImmediately != null)
                RunImmediately.WriteBinary(writer);
            if (Script != null)
                Script.WriteBinary(writer);
            if (EndMarker != null)
                EndMarker.WriteBinary(writer);
        }

        public override void WriteXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (Header != null)
            {
                ele.TryPathTo("Header", true, out subEle);
                Header.WriteXML(subEle, master);
            }
            if (EffectData != null)
            {
                ele.TryPathTo("EffectData", true, out subEle);
                EffectData.WriteXML(subEle, master);
            }
            if (Conditions != null)
            {
                ele.TryPathTo("Conditions", true, out subEle);
                foreach (var entry in Conditions)
                {
                    XElement newEle = new XElement("Condition");
                    entry.WriteXML(newEle, master);
                    subEle.Add(newEle);
                }
            }
            if (EntryPointFunctionType != null)
            {
                ele.TryPathTo("EntryPoint/FunctionType", true, out subEle);
                EntryPointFunctionType.WriteXML(subEle, master);
            }
            if (EntryPointFunctionData != null)
            {
                ele.TryPathTo("EntryPoint/FunctionData", true, out subEle);
                EntryPointFunctionData.WriteXML(subEle, master);
            }
            if (ButtonLabel != null)
            {
                ele.TryPathTo("ButtonLabel", true, out subEle);
                ButtonLabel.WriteXML(subEle, master);
            }
            if (RunImmediately != null)
            {
                ele.TryPathTo("RunImmediately", true, out subEle);
                RunImmediately.WriteXML(subEle, master);
            }
            if (Script != null)
            {
                ele.TryPathTo("Script", true, out subEle);
                Script.WriteXML(subEle, master);
            }
            if (EndMarker != null)
            {
                ele.TryPathTo("EndMarker", true, out subEle);
                EndMarker.WriteXML(subEle, master);
            }
        }

        public override void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Header", false, out subEle))
            {
                if (Header == null)
                    Header = new PerkEffectHeader();

                Header.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("EffectData", false, out subEle))
            {
                switch (Header.Type)
                {
                    case PerkType.QuestStage:
                        EffectData = new PerkQuestStageData();
                        break;
                    case PerkType.Ability:
                        EffectData = new PerkAbilityData();
                        break;
                    case PerkType.EntryPoint:
                        EffectData = new PerkEntryPointData();
                        break;
                }

                EffectData.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("Conditions", false, out subEle))
            {
                if (Conditions == null)
                    Conditions = new List<PerkCondition>();

                foreach (XElement e in subEle.Elements())
                {
                    PerkCondition temp = new PerkCondition();
                    temp.ReadXML(e, master);
                    Conditions.Add(temp);
                }
            }
            if (ele.TryPathTo("EntryPoint/FunctionType", false, out subEle))
            {
                if (EntryPointFunctionType == null)
                    EntryPointFunctionType = new SimpleSubrecord<EntryPointFunctionType>();

                EntryPointFunctionType.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("EntryPoint/FunctionData", false, out subEle))
            {
                switch (EntryPointFunctionType.Value)
                {
                    case Enums.EntryPointFunctionType.None:
                        EntryPointFunctionData = new SimpleSubrecord<byte[]>();
                        break;
                    case Enums.EntryPointFunctionType.Float:
                        EntryPointFunctionData = new SimpleSubrecord<float>();
                        break;
                    case Enums.EntryPointFunctionType.FloatFloat:
                        EntryPointFunctionData = new EntryPointRandRange();
                        break;
                    case Enums.EntryPointFunctionType.LeveledItem:
                        EntryPointFunctionData = new RecordReference();
                        break;
                    case Enums.EntryPointFunctionType.Script:
                        EntryPointFunctionData = new SimpleSubrecord<byte[]>();
                        break;
                    case Enums.EntryPointFunctionType.ActorValueMult:
                        EntryPointFunctionData = new EntryPointActorValMult();
                        break;
                }

                EntryPointFunctionData.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("ButtonLabel", false, out subEle))
            {
                if (ButtonLabel == null)
                    ButtonLabel = new SimpleSubrecord<String>();

                ButtonLabel.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("RunImmediately", false, out subEle))
            {
                if (RunImmediately == null)
                    RunImmediately = new SimpleSubrecord<NoYesShort>();

                RunImmediately.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("Script", false, out subEle))
            {
                if (Script == null)
                    Script = new EmbeddedScript();

                Script.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("EndMarker", false, out subEle))
            {
                if (EndMarker == null)
                    EndMarker = new SubMarker();

                EndMarker.ReadXML(subEle, master);
            }
        }

        public PerkEffect Clone()
        {
            return new PerkEffect(this);
        }
    }
}
