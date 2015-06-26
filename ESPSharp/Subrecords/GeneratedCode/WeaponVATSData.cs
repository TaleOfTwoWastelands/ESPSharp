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
	public partial class WeaponVATSData : Subrecord, ICloneable<WeaponVATSData>, IReferenceContainer
	{
		public FormID Effect { get; set; }
		public Single SkillRequirement { get; set; }
		public Single DamageMult { get; set; }
		public Single APCost { get; set; }
		public NoYesByte IsSilent { get; set; }
		public NoYesByte RequiresMod { get; set; }
		public Byte[] Unused { get; set; }

		public WeaponVATSData()
		{
			Effect = new FormID();
			SkillRequirement = new Single();
			DamageMult = new Single();
			APCost = new Single();
			IsSilent = new NoYesByte();
			RequiresMod = new NoYesByte();
			Unused = new byte[2];
		}

		public WeaponVATSData(FormID Effect, Single SkillRequirement, Single DamageMult, Single APCost, NoYesByte IsSilent, NoYesByte RequiresMod, Byte[] Unused)
		{
			this.Effect = Effect;
			this.SkillRequirement = SkillRequirement;
			this.DamageMult = DamageMult;
			this.APCost = APCost;
			this.IsSilent = IsSilent;
			this.RequiresMod = RequiresMod;
			this.Unused = Unused;
		}

		public WeaponVATSData(WeaponVATSData copyObject)
		{
			Effect = copyObject.Effect.Clone();
			SkillRequirement = copyObject.SkillRequirement;
			DamageMult = copyObject.DamageMult;
			APCost = copyObject.APCost;
			IsSilent = copyObject.IsSilent;
			RequiresMod = copyObject.RequiresMod;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Effect.ReadBinary(subReader);
					SkillRequirement = subReader.ReadSingle();
					DamageMult = subReader.ReadSingle();
					APCost = subReader.ReadSingle();
					IsSilent = subReader.ReadEnum<NoYesByte>();
					RequiresMod = subReader.ReadEnum<NoYesByte>();
					Unused = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Effect.WriteBinary(writer);
			writer.Write(SkillRequirement);			
			writer.Write(DamageMult);			
			writer.Write(APCost);			
			writer.Write((Byte)IsSilent);
			writer.Write((Byte)RequiresMod);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Effect", true, out subEle);
			Effect.WriteXML(subEle, master);

			ele.TryPathTo("SkillRequirement", true, out subEle);
			subEle.Value = SkillRequirement.ToString();

			ele.TryPathTo("DamageMult", true, out subEle);
			subEle.Value = DamageMult.ToString();

			ele.TryPathTo("APCost", true, out subEle);
			subEle.Value = APCost.ToString();

			ele.TryPathTo("IsSilent", true, out subEle);
			subEle.Value = IsSilent.ToString();

			ele.TryPathTo("RequiresMod", true, out subEle);
			subEle.Value = RequiresMod.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Effect", false, out subEle))
			{
				Effect.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("SkillRequirement", false, out subEle))
			{
				SkillRequirement = subEle.ToSingle();
			}

			if (ele.TryPathTo("DamageMult", false, out subEle))
			{
				DamageMult = subEle.ToSingle();
			}

			if (ele.TryPathTo("APCost", false, out subEle))
			{
				APCost = subEle.ToSingle();
			}

			if (ele.TryPathTo("IsSilent", false, out subEle))
			{
				IsSilent = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("RequiresMod", false, out subEle))
			{
				RequiresMod = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public WeaponVATSData Clone()
		{
			return new WeaponVATSData(this);
		}

	}
}
