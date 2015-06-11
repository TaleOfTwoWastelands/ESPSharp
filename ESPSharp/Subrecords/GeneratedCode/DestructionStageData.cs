﻿using System;
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
	public partial class DestructionStageData : Subrecord, ICloneable<DestructionStageData>, IReferenceContainer
	{
		public Byte HealthPercentage { get; set; }
		public Byte Index { get; set; }
		public Byte Stage { get; set; }
		public DestructionStageFlags Flags { get; set; }
		public Int32 SelfDamagePerSecond { get; set; }
		public FormID Explosion { get; set; }
		public FormID Debris { get; set; }
		public Int32 DebrisCount { get; set; }

		public DestructionStageData()
		{
			HealthPercentage = new Byte();
			Index = new Byte();
			Stage = new Byte();
			Flags = new DestructionStageFlags();
			SelfDamagePerSecond = new Int32();
			Explosion = new FormID();
			Debris = new FormID();
			DebrisCount = new Int32();
		}

		public DestructionStageData(Byte HealthPercentage, Byte Index, Byte Stage, DestructionStageFlags Flags, Int32 SelfDamagePerSecond, FormID Explosion, FormID Debris, Int32 DebrisCount)
		{
			this.HealthPercentage = HealthPercentage;
			this.Index = Index;
			this.Stage = Stage;
			this.Flags = Flags;
			this.SelfDamagePerSecond = SelfDamagePerSecond;
			this.Explosion = Explosion;
			this.Debris = Debris;
			this.DebrisCount = DebrisCount;
		}

		public DestructionStageData(DestructionStageData copyObject)
		{
			HealthPercentage = copyObject.HealthPercentage;
			Index = copyObject.Index;
			Stage = copyObject.Stage;
			Flags = copyObject.Flags;
			SelfDamagePerSecond = copyObject.SelfDamagePerSecond;
			Explosion = copyObject.Explosion.Clone();
			Debris = copyObject.Debris.Clone();
			DebrisCount = copyObject.DebrisCount;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					HealthPercentage = subReader.ReadByte();
					Index = subReader.ReadByte();
					Stage = subReader.ReadByte();
					Flags = subReader.ReadEnum<DestructionStageFlags>();
					SelfDamagePerSecond = subReader.ReadInt32();
					Explosion.ReadBinary(subReader);
					Debris.ReadBinary(subReader);
					DebrisCount = subReader.ReadInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(HealthPercentage);			
			writer.Write(Index);			
			writer.Write(Stage);			
			writer.Write((Byte)Flags);
			writer.Write(SelfDamagePerSecond);			
			Explosion.WriteBinary(writer);
			Debris.WriteBinary(writer);
			writer.Write(DebrisCount);			
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("HealthPercentage", true, out subEle);
			subEle.Value = HealthPercentage.ToString();

			ele.TryPathTo("Index", true, out subEle);
			subEle.Value = Index.ToString();

			ele.TryPathTo("Stage", true, out subEle);
			subEle.Value = Stage.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("SelfDamagePerSecond", true, out subEle);
			subEle.Value = SelfDamagePerSecond.ToString();

			ele.TryPathTo("Explosion", true, out subEle);
			Explosion.WriteXML(subEle);

			ele.TryPathTo("Debris", true, out subEle);
			Debris.WriteXML(subEle);

			ele.TryPathTo("DebrisCount", true, out subEle);
			subEle.Value = DebrisCount.ToString();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("HealthPercentage", false, out subEle))
			{
				HealthPercentage = subEle.ToByte();
			}

			if (ele.TryPathTo("Index", false, out subEle))
			{
				Index = subEle.ToByte();
			}

			if (ele.TryPathTo("Stage", false, out subEle))
			{
				Stage = subEle.ToByte();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<DestructionStageFlags>();
			}

			if (ele.TryPathTo("SelfDamagePerSecond", false, out subEle))
			{
				SelfDamagePerSecond = subEle.ToInt32();
			}

			if (ele.TryPathTo("Explosion", false, out subEle))
			{
				Explosion.ReadXML(subEle);
			}

			if (ele.TryPathTo("Debris", false, out subEle))
			{
				Debris.ReadXML(subEle);
			}

			if (ele.TryPathTo("DebrisCount", false, out subEle))
			{
				DebrisCount = subEle.ToInt32();
			}
		}

		public DestructionStageData Clone()
		{
			return new DestructionStageData(this);
		}
	}
}