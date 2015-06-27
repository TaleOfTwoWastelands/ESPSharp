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
	public partial class NPCSkills : Subrecord, ICloneable<NPCSkills>
	{
		public Byte BarterValue { get; set; }
		public Byte BigGunsValue { get; set; }
		public Byte EnergyWeaponsValue { get; set; }
		public Byte ExplosivesValue { get; set; }
		public Byte LockpickValue { get; set; }
		public Byte MedicineValue { get; set; }
		public Byte MeleeWeaponsValue { get; set; }
		public Byte RepairValue { get; set; }
		public Byte ScienceValue { get; set; }
		public Byte GunsValue { get; set; }
		public Byte SneakValue { get; set; }
		public Byte SpeechValue { get; set; }
		public Byte SurvivalValue { get; set; }
		public Byte UnarmedValue { get; set; }
		public Byte BarterOffset { get; set; }
		public Byte BigGunsOffset { get; set; }
		public Byte EnergyWeaponsOffset { get; set; }
		public Byte ExplosivesOffset { get; set; }
		public Byte LockpickOffset { get; set; }
		public Byte MedicineOffset { get; set; }
		public Byte MeleeWeaponsOffset { get; set; }
		public Byte RepairOffset { get; set; }
		public Byte ScienceOffset { get; set; }
		public Byte GunsOffset { get; set; }
		public Byte SneakOffset { get; set; }
		public Byte SpeechOffset { get; set; }
		public Byte SurvivalOffset { get; set; }
		public Byte UnarmedOffset { get; set; }

		public NPCSkills()
		{
			BarterValue = new Byte();
			BigGunsValue = new Byte();
			EnergyWeaponsValue = new Byte();
			ExplosivesValue = new Byte();
			LockpickValue = new Byte();
			MedicineValue = new Byte();
			MeleeWeaponsValue = new Byte();
			RepairValue = new Byte();
			ScienceValue = new Byte();
			GunsValue = new Byte();
			SneakValue = new Byte();
			SpeechValue = new Byte();
			SurvivalValue = new Byte();
			UnarmedValue = new Byte();
			BarterOffset = new Byte();
			BigGunsOffset = new Byte();
			EnergyWeaponsOffset = new Byte();
			ExplosivesOffset = new Byte();
			LockpickOffset = new Byte();
			MedicineOffset = new Byte();
			MeleeWeaponsOffset = new Byte();
			RepairOffset = new Byte();
			ScienceOffset = new Byte();
			GunsOffset = new Byte();
			SneakOffset = new Byte();
			SpeechOffset = new Byte();
			SurvivalOffset = new Byte();
			UnarmedOffset = new Byte();
		}

		public NPCSkills(Byte BarterValue, Byte BigGunsValue, Byte EnergyWeaponsValue, Byte ExplosivesValue, Byte LockpickValue, Byte MedicineValue, Byte MeleeWeaponsValue, Byte RepairValue, Byte ScienceValue, Byte GunsValue, Byte SneakValue, Byte SpeechValue, Byte SurvivalValue, Byte UnarmedValue, Byte BarterOffset, Byte BigGunsOffset, Byte EnergyWeaponsOffset, Byte ExplosivesOffset, Byte LockpickOffset, Byte MedicineOffset, Byte MeleeWeaponsOffset, Byte RepairOffset, Byte ScienceOffset, Byte GunsOffset, Byte SneakOffset, Byte SpeechOffset, Byte SurvivalOffset, Byte UnarmedOffset)
		{
			this.BarterValue = BarterValue;
			this.BigGunsValue = BigGunsValue;
			this.EnergyWeaponsValue = EnergyWeaponsValue;
			this.ExplosivesValue = ExplosivesValue;
			this.LockpickValue = LockpickValue;
			this.MedicineValue = MedicineValue;
			this.MeleeWeaponsValue = MeleeWeaponsValue;
			this.RepairValue = RepairValue;
			this.ScienceValue = ScienceValue;
			this.GunsValue = GunsValue;
			this.SneakValue = SneakValue;
			this.SpeechValue = SpeechValue;
			this.SurvivalValue = SurvivalValue;
			this.UnarmedValue = UnarmedValue;
			this.BarterOffset = BarterOffset;
			this.BigGunsOffset = BigGunsOffset;
			this.EnergyWeaponsOffset = EnergyWeaponsOffset;
			this.ExplosivesOffset = ExplosivesOffset;
			this.LockpickOffset = LockpickOffset;
			this.MedicineOffset = MedicineOffset;
			this.MeleeWeaponsOffset = MeleeWeaponsOffset;
			this.RepairOffset = RepairOffset;
			this.ScienceOffset = ScienceOffset;
			this.GunsOffset = GunsOffset;
			this.SneakOffset = SneakOffset;
			this.SpeechOffset = SpeechOffset;
			this.SurvivalOffset = SurvivalOffset;
			this.UnarmedOffset = UnarmedOffset;
		}

		public NPCSkills(NPCSkills copyObject)
		{
			BarterValue = copyObject.BarterValue;
			BigGunsValue = copyObject.BigGunsValue;
			EnergyWeaponsValue = copyObject.EnergyWeaponsValue;
			ExplosivesValue = copyObject.ExplosivesValue;
			LockpickValue = copyObject.LockpickValue;
			MedicineValue = copyObject.MedicineValue;
			MeleeWeaponsValue = copyObject.MeleeWeaponsValue;
			RepairValue = copyObject.RepairValue;
			ScienceValue = copyObject.ScienceValue;
			GunsValue = copyObject.GunsValue;
			SneakValue = copyObject.SneakValue;
			SpeechValue = copyObject.SpeechValue;
			SurvivalValue = copyObject.SurvivalValue;
			UnarmedValue = copyObject.UnarmedValue;
			BarterOffset = copyObject.BarterOffset;
			BigGunsOffset = copyObject.BigGunsOffset;
			EnergyWeaponsOffset = copyObject.EnergyWeaponsOffset;
			ExplosivesOffset = copyObject.ExplosivesOffset;
			LockpickOffset = copyObject.LockpickOffset;
			MedicineOffset = copyObject.MedicineOffset;
			MeleeWeaponsOffset = copyObject.MeleeWeaponsOffset;
			RepairOffset = copyObject.RepairOffset;
			ScienceOffset = copyObject.ScienceOffset;
			GunsOffset = copyObject.GunsOffset;
			SneakOffset = copyObject.SneakOffset;
			SpeechOffset = copyObject.SpeechOffset;
			SurvivalOffset = copyObject.SurvivalOffset;
			UnarmedOffset = copyObject.UnarmedOffset;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					BarterValue = subReader.ReadByte();
					BigGunsValue = subReader.ReadByte();
					EnergyWeaponsValue = subReader.ReadByte();
					ExplosivesValue = subReader.ReadByte();
					LockpickValue = subReader.ReadByte();
					MedicineValue = subReader.ReadByte();
					MeleeWeaponsValue = subReader.ReadByte();
					RepairValue = subReader.ReadByte();
					ScienceValue = subReader.ReadByte();
					GunsValue = subReader.ReadByte();
					SneakValue = subReader.ReadByte();
					SpeechValue = subReader.ReadByte();
					SurvivalValue = subReader.ReadByte();
					UnarmedValue = subReader.ReadByte();
					BarterOffset = subReader.ReadByte();
					BigGunsOffset = subReader.ReadByte();
					EnergyWeaponsOffset = subReader.ReadByte();
					ExplosivesOffset = subReader.ReadByte();
					LockpickOffset = subReader.ReadByte();
					MedicineOffset = subReader.ReadByte();
					MeleeWeaponsOffset = subReader.ReadByte();
					RepairOffset = subReader.ReadByte();
					ScienceOffset = subReader.ReadByte();
					GunsOffset = subReader.ReadByte();
					SneakOffset = subReader.ReadByte();
					SpeechOffset = subReader.ReadByte();
					SurvivalOffset = subReader.ReadByte();
					UnarmedOffset = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(BarterValue);			
			writer.Write(BigGunsValue);			
			writer.Write(EnergyWeaponsValue);			
			writer.Write(ExplosivesValue);			
			writer.Write(LockpickValue);			
			writer.Write(MedicineValue);			
			writer.Write(MeleeWeaponsValue);			
			writer.Write(RepairValue);			
			writer.Write(ScienceValue);			
			writer.Write(GunsValue);			
			writer.Write(SneakValue);			
			writer.Write(SpeechValue);			
			writer.Write(SurvivalValue);			
			writer.Write(UnarmedValue);			
			writer.Write(BarterOffset);			
			writer.Write(BigGunsOffset);			
			writer.Write(EnergyWeaponsOffset);			
			writer.Write(ExplosivesOffset);			
			writer.Write(LockpickOffset);			
			writer.Write(MedicineOffset);			
			writer.Write(MeleeWeaponsOffset);			
			writer.Write(RepairOffset);			
			writer.Write(ScienceOffset);			
			writer.Write(GunsOffset);			
			writer.Write(SneakOffset);			
			writer.Write(SpeechOffset);			
			writer.Write(SurvivalOffset);			
			writer.Write(UnarmedOffset);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Barter/Value", true, out subEle);
			subEle.Value = BarterValue.ToString();

			ele.TryPathTo("BigGuns/Value", true, out subEle);
			subEle.Value = BigGunsValue.ToString();

			ele.TryPathTo("EnergyWeapons/Value", true, out subEle);
			subEle.Value = EnergyWeaponsValue.ToString();

			ele.TryPathTo("Explosives/Value", true, out subEle);
			subEle.Value = ExplosivesValue.ToString();

			ele.TryPathTo("Lockpick/Value", true, out subEle);
			subEle.Value = LockpickValue.ToString();

			ele.TryPathTo("Medicine/Value", true, out subEle);
			subEle.Value = MedicineValue.ToString();

			ele.TryPathTo("MeleeWeapons/Value", true, out subEle);
			subEle.Value = MeleeWeaponsValue.ToString();

			ele.TryPathTo("Repair/Value", true, out subEle);
			subEle.Value = RepairValue.ToString();

			ele.TryPathTo("Science/Value", true, out subEle);
			subEle.Value = ScienceValue.ToString();

			ele.TryPathTo("Guns/Value", true, out subEle);
			subEle.Value = GunsValue.ToString();

			ele.TryPathTo("Sneak/Value", true, out subEle);
			subEle.Value = SneakValue.ToString();

			ele.TryPathTo("Speech/Value", true, out subEle);
			subEle.Value = SpeechValue.ToString();

			ele.TryPathTo("Survival/Value", true, out subEle);
			subEle.Value = SurvivalValue.ToString();

			ele.TryPathTo("Unarmed/Value", true, out subEle);
			subEle.Value = UnarmedValue.ToString();

			ele.TryPathTo("Barter/Offset", true, out subEle);
			subEle.Value = BarterOffset.ToString();

			ele.TryPathTo("BigGuns/Offset", true, out subEle);
			subEle.Value = BigGunsOffset.ToString();

			ele.TryPathTo("EnergyWeapons/Offset", true, out subEle);
			subEle.Value = EnergyWeaponsOffset.ToString();

			ele.TryPathTo("Explosives/Offset", true, out subEle);
			subEle.Value = ExplosivesOffset.ToString();

			ele.TryPathTo("Lockpick/Offset", true, out subEle);
			subEle.Value = LockpickOffset.ToString();

			ele.TryPathTo("Medicine/Offset", true, out subEle);
			subEle.Value = MedicineOffset.ToString();

			ele.TryPathTo("MeleeWeapons/Offset", true, out subEle);
			subEle.Value = MeleeWeaponsOffset.ToString();

			ele.TryPathTo("Repair/Offset", true, out subEle);
			subEle.Value = RepairOffset.ToString();

			ele.TryPathTo("Science/Offset", true, out subEle);
			subEle.Value = ScienceOffset.ToString();

			ele.TryPathTo("Guns/Offset", true, out subEle);
			subEle.Value = GunsOffset.ToString();

			ele.TryPathTo("Sneak/Offset", true, out subEle);
			subEle.Value = SneakOffset.ToString();

			ele.TryPathTo("Speech/Offset", true, out subEle);
			subEle.Value = SpeechOffset.ToString();

			ele.TryPathTo("Survival/Offset", true, out subEle);
			subEle.Value = SurvivalOffset.ToString();

			ele.TryPathTo("Unarmed/Offset", true, out subEle);
			subEle.Value = UnarmedOffset.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Barter/Value", false, out subEle))
			{
				BarterValue = subEle.ToByte();
			}

			if (ele.TryPathTo("BigGuns/Value", false, out subEle))
			{
				BigGunsValue = subEle.ToByte();
			}

			if (ele.TryPathTo("EnergyWeapons/Value", false, out subEle))
			{
				EnergyWeaponsValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Explosives/Value", false, out subEle))
			{
				ExplosivesValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Lockpick/Value", false, out subEle))
			{
				LockpickValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Medicine/Value", false, out subEle))
			{
				MedicineValue = subEle.ToByte();
			}

			if (ele.TryPathTo("MeleeWeapons/Value", false, out subEle))
			{
				MeleeWeaponsValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Repair/Value", false, out subEle))
			{
				RepairValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Science/Value", false, out subEle))
			{
				ScienceValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Guns/Value", false, out subEle))
			{
				GunsValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Sneak/Value", false, out subEle))
			{
				SneakValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Speech/Value", false, out subEle))
			{
				SpeechValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Survival/Value", false, out subEle))
			{
				SurvivalValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Unarmed/Value", false, out subEle))
			{
				UnarmedValue = subEle.ToByte();
			}

			if (ele.TryPathTo("Barter/Offset", false, out subEle))
			{
				BarterOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("BigGuns/Offset", false, out subEle))
			{
				BigGunsOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("EnergyWeapons/Offset", false, out subEle))
			{
				EnergyWeaponsOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Explosives/Offset", false, out subEle))
			{
				ExplosivesOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Lockpick/Offset", false, out subEle))
			{
				LockpickOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Medicine/Offset", false, out subEle))
			{
				MedicineOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("MeleeWeapons/Offset", false, out subEle))
			{
				MeleeWeaponsOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Repair/Offset", false, out subEle))
			{
				RepairOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Science/Offset", false, out subEle))
			{
				ScienceOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Guns/Offset", false, out subEle))
			{
				GunsOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Sneak/Offset", false, out subEle))
			{
				SneakOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Speech/Offset", false, out subEle))
			{
				SpeechOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Survival/Offset", false, out subEle))
			{
				SurvivalOffset = subEle.ToByte();
			}

			if (ele.TryPathTo("Unarmed/Offset", false, out subEle))
			{
				UnarmedOffset = subEle.ToByte();
			}
		}

		public NPCSkills Clone()
		{
			return new NPCSkills(this);
		}

	}
}
