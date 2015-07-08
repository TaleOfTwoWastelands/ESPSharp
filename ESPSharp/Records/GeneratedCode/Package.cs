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
	public partial class Package : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public PackageData Data { get; set; }
		public PackageLocation Location1 { get; set; }
		public PackageLocation Location2 { get; set; }
		public PackageScheduleData Schedule { get; set; }
		public PackageTarget Target1 { get; set; }
		public List<Condition> Conditions { get; set; }
		public SimpleSubrecord<PackageIdleFlags> IdleFlags { get; set; }
		public SimpleSubrecord<Byte> IdleCount { get; set; }
		public SimpleSubrecord<Single> IdleTimerSetting { get; set; }
		public FormArray IdleAnimations { get; set; }
		public SimpleSubrecord<Byte[]> Unused { get; set; }
		public RecordReference CombatStyle { get; set; }
		public SubMarker EatMarker { get; set; }
		public SimpleSubrecord<UInt32> EscortDistance { get; set; }
		public SimpleSubrecord<UInt32> FollowDistance_StartLocation_TriggerRadius { get; set; }
		public SimpleSubrecord<NoYesByte> PatrolIsRepeatable { get; set; }
		public PackageUseWeaponData UseWeaponData { get; set; }
		public PackageTarget Target2 { get; set; }
		public SubMarker UseItemMarker { get; set; }
		public SubMarker AmbushMarker { get; set; }
		public PackageDialogData DialogData { get; set; }
		public PackageEvent OnBegin { get; set; }
		public PackageEvent OnEnd { get; set; }
		public PackageEvent OnChange { get; set; }
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "PKDT":
						if (Data == null)
							Data = new PackageData();

						Data.ReadBinary(reader);
						break;
					case "PLDT":
						if (Location1 == null)
							Location1 = new PackageLocation();

						Location1.ReadBinary(reader);
						break;
					case "PLD2":
						if (Location2 == null)
							Location2 = new PackageLocation();

						Location2.ReadBinary(reader);
						break;
					case "PSDT":
						if (Schedule == null)
							Schedule = new PackageScheduleData();

						Schedule.ReadBinary(reader);
						break;
					case "PTDT":
						if (Target1 == null)
							Target1 = new PackageTarget();

						Target1.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "IDLF":
						if (IdleFlags == null)
							IdleFlags = new SimpleSubrecord<PackageIdleFlags>();

						IdleFlags.ReadBinary(reader);
						break;
					case "IDLC":
						if (IdleCount == null)
							IdleCount = new SimpleSubrecord<Byte>();

						IdleCount.ReadBinary(reader);
						break;
					case "IDLT":
						if (IdleTimerSetting == null)
							IdleTimerSetting = new SimpleSubrecord<Single>();

						IdleTimerSetting.ReadBinary(reader);
						break;
					case "IDLA":
						if (IdleAnimations == null)
							IdleAnimations = new FormArray();

						IdleAnimations.ReadBinary(reader);
						break;
					case "IDLB":
						if (Unused == null)
							Unused = new SimpleSubrecord<Byte[]>();

						Unused.ReadBinary(reader);
						break;
					case "CNAM":
						if (CombatStyle == null)
							CombatStyle = new RecordReference();

						CombatStyle.ReadBinary(reader);
						break;
					case "PKED":
						if (EatMarker == null)
							EatMarker = new SubMarker();

						EatMarker.ReadBinary(reader);
						break;
					case "PKE2":
						if (EscortDistance == null)
							EscortDistance = new SimpleSubrecord<UInt32>();

						EscortDistance.ReadBinary(reader);
						break;
					case "PKFD":
						if (FollowDistance_StartLocation_TriggerRadius == null)
							FollowDistance_StartLocation_TriggerRadius = new SimpleSubrecord<UInt32>();

						FollowDistance_StartLocation_TriggerRadius.ReadBinary(reader);
						break;
					case "PKPT":
						if (PatrolIsRepeatable == null)
							PatrolIsRepeatable = new SimpleSubrecord<NoYesByte>();

						PatrolIsRepeatable.ReadBinary(reader);
						break;
					case "PKW3":
						if (UseWeaponData == null)
							UseWeaponData = new PackageUseWeaponData();

						UseWeaponData.ReadBinary(reader);
						break;
					case "PTD2":
						if (Target2 == null)
							Target2 = new PackageTarget();

						Target2.ReadBinary(reader);
						break;
					case "PUID":
						if (UseItemMarker == null)
							UseItemMarker = new SubMarker();

						UseItemMarker.ReadBinary(reader);
						break;
					case "PKAM":
						if (AmbushMarker == null)
							AmbushMarker = new SubMarker();

						AmbushMarker.ReadBinary(reader);
						break;
					case "PKDD":
						if (DialogData == null)
							DialogData = new PackageDialogData();

						DialogData.ReadBinary(reader);
						break;
					case "POBA":
						if (OnBegin == null)
							OnBegin = new PackageEvent();

						OnBegin.ReadBinary(reader);
						break;
					case "POEA":
						if (OnEnd == null)
							OnEnd = new PackageEvent();

						OnEnd.ReadBinary(reader);
						break;
					case "POCA":
						if (OnChange == null)
							OnChange = new PackageEvent();

						OnChange.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Location1 != null)
				Location1.WriteBinary(writer);
			if (Location2 != null)
				Location2.WriteBinary(writer);
			if (Schedule != null)
				Schedule.WriteBinary(writer);
			if (Target1 != null)
				Target1.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (IdleFlags != null)
				IdleFlags.WriteBinary(writer);
			if (IdleCount != null)
				IdleCount.WriteBinary(writer);
			if (IdleTimerSetting != null)
				IdleTimerSetting.WriteBinary(writer);
			if (IdleAnimations != null)
				IdleAnimations.WriteBinary(writer);
			if (Unused != null)
				Unused.WriteBinary(writer);
			if (CombatStyle != null)
				CombatStyle.WriteBinary(writer);
			if (EatMarker != null)
				EatMarker.WriteBinary(writer);
			if (EscortDistance != null)
				EscortDistance.WriteBinary(writer);
			if (FollowDistance_StartLocation_TriggerRadius != null)
				FollowDistance_StartLocation_TriggerRadius.WriteBinary(writer);
			if (PatrolIsRepeatable != null)
				PatrolIsRepeatable.WriteBinary(writer);
			if (UseWeaponData != null)
				UseWeaponData.WriteBinary(writer);
			if (Target2 != null)
				Target2.WriteBinary(writer);
			if (UseItemMarker != null)
				UseItemMarker.WriteBinary(writer);
			if (AmbushMarker != null)
				AmbushMarker.WriteBinary(writer);
			if (DialogData != null)
				DialogData.WriteBinary(writer);
			if (OnBegin != null)
				OnBegin.WriteBinary(writer);
			if (OnEnd != null)
				OnEnd.WriteBinary(writer);
			if (OnChange != null)
				OnChange.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Location1 != null)		
			{		
				ele.TryPathTo("Location1", true, out subEle);
				Location1.WriteXML(subEle, master);
			}
			if (Location2 != null)		
			{		
				ele.TryPathTo("Location2", true, out subEle);
				Location2.WriteXML(subEle, master);
			}
			if (Schedule != null)		
			{		
				ele.TryPathTo("Schedule", true, out subEle);
				Schedule.WriteXML(subEle, master);
			}
			if (Target1 != null)		
			{		
				ele.TryPathTo("Target1", true, out subEle);
				Target1.WriteXML(subEle, master);
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				List<string> xmlNames = new List<string>{"Condition"};
				int i = 0;
				foreach (var entry in Conditions)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (IdleFlags != null)		
			{		
				ele.TryPathTo("Idle/Flags", true, out subEle);
				IdleFlags.WriteXML(subEle, master);
			}
			if (IdleCount != null)		
			{		
				ele.TryPathTo("Idle/Count", true, out subEle);
				IdleCount.WriteXML(subEle, master);
			}
			if (IdleTimerSetting != null)		
			{		
				ele.TryPathTo("Idle/TimerSetting", true, out subEle);
				IdleTimerSetting.WriteXML(subEle, master);
			}
			if (IdleAnimations != null)		
			{		
				ele.TryPathTo("Idle/Animations", true, out subEle);
				IdleAnimations.WriteXML(subEle, master);
			}
			if (Unused != null)		
			{		
				ele.TryPathTo("Unused", true, out subEle);
				Unused.WriteXML(subEle, master);
			}
			if (CombatStyle != null)		
			{		
				ele.TryPathTo("CombatStyle", true, out subEle);
				CombatStyle.WriteXML(subEle, master);
			}
			if (EatMarker != null)		
			{		
				ele.TryPathTo("EatMarker", true, out subEle);
				EatMarker.WriteXML(subEle, master);
			}
			if (EscortDistance != null)		
			{		
				ele.TryPathTo("EscortDistance", true, out subEle);
				EscortDistance.WriteXML(subEle, master);
			}
			if (FollowDistance_StartLocation_TriggerRadius != null)		
			{		
				ele.TryPathTo("FollowDistance_StartLocation_TriggerRadius", true, out subEle);
				FollowDistance_StartLocation_TriggerRadius.WriteXML(subEle, master);
			}
			if (PatrolIsRepeatable != null)		
			{		
				ele.TryPathTo("PatrolIsRepeatable", true, out subEle);
				PatrolIsRepeatable.WriteXML(subEle, master);
			}
			if (UseWeaponData != null)		
			{		
				ele.TryPathTo("UseWeaponData", true, out subEle);
				UseWeaponData.WriteXML(subEle, master);
			}
			if (Target2 != null)		
			{		
				ele.TryPathTo("Target2", true, out subEle);
				Target2.WriteXML(subEle, master);
			}
			if (UseItemMarker != null)		
			{		
				ele.TryPathTo("UseItemMarker", true, out subEle);
				UseItemMarker.WriteXML(subEle, master);
			}
			if (AmbushMarker != null)		
			{		
				ele.TryPathTo("AmbushMarker", true, out subEle);
				AmbushMarker.WriteXML(subEle, master);
			}
			if (DialogData != null)		
			{		
				ele.TryPathTo("DialogData", true, out subEle);
				DialogData.WriteXML(subEle, master);
			}
			if (OnBegin != null)		
			{		
				ele.TryPathTo("OnBegin", true, out subEle);
				OnBegin.WriteXML(subEle, master);
			}
			if (OnEnd != null)		
			{		
				ele.TryPathTo("OnEnd", true, out subEle);
				OnEnd.WriteXML(subEle, master);
			}
			if (OnChange != null)		
			{		
				ele.TryPathTo("OnChange", true, out subEle);
				OnChange.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new PackageData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Location1", false, out subEle))
			{
				if (Location1 == null)
					Location1 = new PackageLocation();
					
				Location1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Location2", false, out subEle))
			{
				if (Location2 == null)
					Location2 = new PackageLocation();
					
				Location2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Schedule", false, out subEle))
			{
				if (Schedule == null)
					Schedule = new PackageScheduleData();
					
				Schedule.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Target1", false, out subEle))
			{
				if (Target1 == null)
					Target1 = new PackageTarget();
					
				Target1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition tempCTDA = new Condition();
					tempCTDA.ReadXML(e, master);
					Conditions.Add(tempCTDA);
				}
			}
			if (ele.TryPathTo("Idle/Flags", false, out subEle))
			{
				if (IdleFlags == null)
					IdleFlags = new SimpleSubrecord<PackageIdleFlags>();
					
				IdleFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Idle/Count", false, out subEle))
			{
				if (IdleCount == null)
					IdleCount = new SimpleSubrecord<Byte>();
					
				IdleCount.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Idle/TimerSetting", false, out subEle))
			{
				if (IdleTimerSetting == null)
					IdleTimerSetting = new SimpleSubrecord<Single>();
					
				IdleTimerSetting.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Idle/Animations", false, out subEle))
			{
				if (IdleAnimations == null)
					IdleAnimations = new FormArray();
					
				IdleAnimations.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused", false, out subEle))
			{
				if (Unused == null)
					Unused = new SimpleSubrecord<Byte[]>();
					
				Unused.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CombatStyle", false, out subEle))
			{
				if (CombatStyle == null)
					CombatStyle = new RecordReference();
					
				CombatStyle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EatMarker", false, out subEle))
			{
				if (EatMarker == null)
					EatMarker = new SubMarker();
					
				EatMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EscortDistance", false, out subEle))
			{
				if (EscortDistance == null)
					EscortDistance = new SimpleSubrecord<UInt32>();
					
				EscortDistance.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FollowDistance_StartLocation_TriggerRadius", false, out subEle))
			{
				if (FollowDistance_StartLocation_TriggerRadius == null)
					FollowDistance_StartLocation_TriggerRadius = new SimpleSubrecord<UInt32>();
					
				FollowDistance_StartLocation_TriggerRadius.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PatrolIsRepeatable", false, out subEle))
			{
				if (PatrolIsRepeatable == null)
					PatrolIsRepeatable = new SimpleSubrecord<NoYesByte>();
					
				PatrolIsRepeatable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("UseWeaponData", false, out subEle))
			{
				if (UseWeaponData == null)
					UseWeaponData = new PackageUseWeaponData();
					
				UseWeaponData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Target2", false, out subEle))
			{
				if (Target2 == null)
					Target2 = new PackageTarget();
					
				Target2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("UseItemMarker", false, out subEle))
			{
				if (UseItemMarker == null)
					UseItemMarker = new SubMarker();
					
				UseItemMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AmbushMarker", false, out subEle))
			{
				if (AmbushMarker == null)
					AmbushMarker = new SubMarker();
					
				AmbushMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DialogData", false, out subEle))
			{
				if (DialogData == null)
					DialogData = new PackageDialogData();
					
				DialogData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OnBegin", false, out subEle))
			{
				if (OnBegin == null)
					OnBegin = new PackageEvent();
					
				OnBegin.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OnEnd", false, out subEle))
			{
				if (OnEnd == null)
					OnEnd = new PackageEvent();
					
				OnEnd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OnChange", false, out subEle))
			{
				if (OnChange == null)
					OnChange = new PackageEvent();
					
				OnChange.ReadXML(subEle, master);
			}
		}

	}
}
