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
	public partial class RaceData : Subrecord, ICloneable<RaceData>
	{
		public ActorValuesByte SkillBonus1 { get; set; }
		public Byte SkillBonus1Amount { get; set; }
		public ActorValuesByte SkillBonus2 { get; set; }
		public Byte SkillBonus2Amount { get; set; }
		public ActorValuesByte SkillBonus3 { get; set; }
		public Byte SkillBonus3Amount { get; set; }
		public ActorValuesByte SkillBonus4 { get; set; }
		public Byte SkillBonus4Amount { get; set; }
		public ActorValuesByte SkillBonus5 { get; set; }
		public Byte SkillBonus5Amount { get; set; }
		public ActorValuesByte SkillBonus6 { get; set; }
		public Byte SkillBonus6Amount { get; set; }
		public ActorValuesByte SkillBonus7 { get; set; }
		public Byte SkillBonus7Amount { get; set; }
		public Byte[] Unused { get; set; }
		public Single MaleHeight { get; set; }
		public Single FemaleHeight { get; set; }
		public Single MaleWeight { get; set; }
		public Single FemaleWeight { get; set; }
		public RaceFlags RaceFlags { get; set; }

		public RaceData()
		{
			SkillBonus1 = new ActorValuesByte();
			SkillBonus1Amount = new Byte();
			SkillBonus2 = new ActorValuesByte();
			SkillBonus2Amount = new Byte();
			SkillBonus3 = new ActorValuesByte();
			SkillBonus3Amount = new Byte();
			SkillBonus4 = new ActorValuesByte();
			SkillBonus4Amount = new Byte();
			SkillBonus5 = new ActorValuesByte();
			SkillBonus5Amount = new Byte();
			SkillBonus6 = new ActorValuesByte();
			SkillBonus6Amount = new Byte();
			SkillBonus7 = new ActorValuesByte();
			SkillBonus7Amount = new Byte();
			Unused = new byte[2];
			MaleHeight = new Single();
			FemaleHeight = new Single();
			MaleWeight = new Single();
			FemaleWeight = new Single();
			RaceFlags = new RaceFlags();
		}

		public RaceData(ActorValuesByte SkillBonus1, Byte SkillBonus1Amount, ActorValuesByte SkillBonus2, Byte SkillBonus2Amount, ActorValuesByte SkillBonus3, Byte SkillBonus3Amount, ActorValuesByte SkillBonus4, Byte SkillBonus4Amount, ActorValuesByte SkillBonus5, Byte SkillBonus5Amount, ActorValuesByte SkillBonus6, Byte SkillBonus6Amount, ActorValuesByte SkillBonus7, Byte SkillBonus7Amount, Byte[] Unused, Single MaleHeight, Single FemaleHeight, Single MaleWeight, Single FemaleWeight, RaceFlags RaceFlags)
		{
			this.SkillBonus1 = SkillBonus1;
			this.SkillBonus1Amount = SkillBonus1Amount;
			this.SkillBonus2 = SkillBonus2;
			this.SkillBonus2Amount = SkillBonus2Amount;
			this.SkillBonus3 = SkillBonus3;
			this.SkillBonus3Amount = SkillBonus3Amount;
			this.SkillBonus4 = SkillBonus4;
			this.SkillBonus4Amount = SkillBonus4Amount;
			this.SkillBonus5 = SkillBonus5;
			this.SkillBonus5Amount = SkillBonus5Amount;
			this.SkillBonus6 = SkillBonus6;
			this.SkillBonus6Amount = SkillBonus6Amount;
			this.SkillBonus7 = SkillBonus7;
			this.SkillBonus7Amount = SkillBonus7Amount;
			this.Unused = Unused;
			this.MaleHeight = MaleHeight;
			this.FemaleHeight = FemaleHeight;
			this.MaleWeight = MaleWeight;
			this.FemaleWeight = FemaleWeight;
			this.RaceFlags = RaceFlags;
		}

		public RaceData(RaceData copyObject)
		{
			SkillBonus1 = copyObject.SkillBonus1;
			SkillBonus1Amount = copyObject.SkillBonus1Amount;
			SkillBonus2 = copyObject.SkillBonus2;
			SkillBonus2Amount = copyObject.SkillBonus2Amount;
			SkillBonus3 = copyObject.SkillBonus3;
			SkillBonus3Amount = copyObject.SkillBonus3Amount;
			SkillBonus4 = copyObject.SkillBonus4;
			SkillBonus4Amount = copyObject.SkillBonus4Amount;
			SkillBonus5 = copyObject.SkillBonus5;
			SkillBonus5Amount = copyObject.SkillBonus5Amount;
			SkillBonus6 = copyObject.SkillBonus6;
			SkillBonus6Amount = copyObject.SkillBonus6Amount;
			SkillBonus7 = copyObject.SkillBonus7;
			SkillBonus7Amount = copyObject.SkillBonus7Amount;
			Unused = (Byte[])copyObject.Unused.Clone();
			MaleHeight = copyObject.MaleHeight;
			FemaleHeight = copyObject.FemaleHeight;
			MaleWeight = copyObject.MaleWeight;
			FemaleWeight = copyObject.FemaleWeight;
			RaceFlags = copyObject.RaceFlags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					SkillBonus1 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus1Amount = subReader.ReadByte();
					SkillBonus2 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus2Amount = subReader.ReadByte();
					SkillBonus3 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus3Amount = subReader.ReadByte();
					SkillBonus4 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus4Amount = subReader.ReadByte();
					SkillBonus5 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus5Amount = subReader.ReadByte();
					SkillBonus6 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus6Amount = subReader.ReadByte();
					SkillBonus7 = subReader.ReadEnum<ActorValuesByte>();
					SkillBonus7Amount = subReader.ReadByte();
					Unused = subReader.ReadBytes(2);
					MaleHeight = subReader.ReadSingle();
					FemaleHeight = subReader.ReadSingle();
					MaleWeight = subReader.ReadSingle();
					FemaleWeight = subReader.ReadSingle();
					RaceFlags = subReader.ReadEnum<RaceFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((SByte)SkillBonus1);
			writer.Write(SkillBonus1Amount);			
			writer.Write((SByte)SkillBonus2);
			writer.Write(SkillBonus2Amount);			
			writer.Write((SByte)SkillBonus3);
			writer.Write(SkillBonus3Amount);			
			writer.Write((SByte)SkillBonus4);
			writer.Write(SkillBonus4Amount);			
			writer.Write((SByte)SkillBonus5);
			writer.Write(SkillBonus5Amount);			
			writer.Write((SByte)SkillBonus6);
			writer.Write(SkillBonus6Amount);			
			writer.Write((SByte)SkillBonus7);
			writer.Write(SkillBonus7Amount);			
			if (Unused == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused);
			writer.Write(MaleHeight);			
			writer.Write(FemaleHeight);			
			writer.Write(MaleWeight);			
			writer.Write(FemaleWeight);			
			writer.Write((UInt32)RaceFlags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("SkillBonuses/Bonus1/Skill", true, out subEle);
			subEle.Value = SkillBonus1.ToString();

			ele.TryPathTo("SkillBonuses/Bonus1/Amount", true, out subEle);
			subEle.Value = SkillBonus1Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus2/Skill", true, out subEle);
			subEle.Value = SkillBonus2.ToString();

			ele.TryPathTo("SkillBonuses/Bonus2/Amount", true, out subEle);
			subEle.Value = SkillBonus2Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus3/Skill", true, out subEle);
			subEle.Value = SkillBonus3.ToString();

			ele.TryPathTo("SkillBonuses/Bonus3/Amount", true, out subEle);
			subEle.Value = SkillBonus3Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus4/Skill", true, out subEle);
			subEle.Value = SkillBonus4.ToString();

			ele.TryPathTo("SkillBonuses/Bonus4/Amount", true, out subEle);
			subEle.Value = SkillBonus4Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus5/Skill", true, out subEle);
			subEle.Value = SkillBonus5.ToString();

			ele.TryPathTo("SkillBonuses/Bonus5/Amount", true, out subEle);
			subEle.Value = SkillBonus5Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus6/Skill", true, out subEle);
			subEle.Value = SkillBonus6.ToString();

			ele.TryPathTo("SkillBonuses/Bonus6/Amount", true, out subEle);
			subEle.Value = SkillBonus6Amount.ToString();

			ele.TryPathTo("SkillBonuses/Bonus7/Skill", true, out subEle);
			subEle.Value = SkillBonus7.ToString();

			ele.TryPathTo("SkillBonuses/Bonus7/Amount", true, out subEle);
			subEle.Value = SkillBonus7Amount.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("Height/Male", true, out subEle);
			subEle.Value = MaleHeight.ToString("G15");

			ele.TryPathTo("Height/Female", true, out subEle);
			subEle.Value = FemaleHeight.ToString("G15");

			ele.TryPathTo("Weight/Male", true, out subEle);
			subEle.Value = MaleWeight.ToString("G15");

			ele.TryPathTo("Weight/Female", true, out subEle);
			subEle.Value = FemaleWeight.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = RaceFlags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("SkillBonuses/Bonus1/Skill", false, out subEle))
			{
				SkillBonus1 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus1/Amount", false, out subEle))
			{
				SkillBonus1Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus2/Skill", false, out subEle))
			{
				SkillBonus2 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus2/Amount", false, out subEle))
			{
				SkillBonus2Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus3/Skill", false, out subEle))
			{
				SkillBonus3 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus3/Amount", false, out subEle))
			{
				SkillBonus3Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus4/Skill", false, out subEle))
			{
				SkillBonus4 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus4/Amount", false, out subEle))
			{
				SkillBonus4Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus5/Skill", false, out subEle))
			{
				SkillBonus5 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus5/Amount", false, out subEle))
			{
				SkillBonus5Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus6/Skill", false, out subEle))
			{
				SkillBonus6 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus6/Amount", false, out subEle))
			{
				SkillBonus6Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus7/Skill", false, out subEle))
			{
				SkillBonus7 = subEle.ToEnum<ActorValuesByte>();
			}

			if (ele.TryPathTo("SkillBonuses/Bonus7/Amount", false, out subEle))
			{
				SkillBonus7Amount = subEle.ToByte();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("Height/Male", false, out subEle))
			{
				MaleHeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("Height/Female", false, out subEle))
			{
				FemaleHeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("Weight/Male", false, out subEle))
			{
				MaleWeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("Weight/Female", false, out subEle))
			{
				FemaleWeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				RaceFlags = subEle.ToEnum<RaceFlags>();
			}
		}

		public RaceData Clone()
		{
			return new RaceData(this);
		}

	}
}
