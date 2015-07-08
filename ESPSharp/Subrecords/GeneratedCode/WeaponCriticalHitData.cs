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
	public partial class WeaponCriticalHitData : Subrecord, ICloneable<WeaponCriticalHitData>, IReferenceContainer
	{
		public UInt16 Damage { get; set; }
		public Byte[] Unused1 { get; set; }
		public Single ChanceMult { get; set; }
		public WeaponCritFlags Flags { get; set; }
		public Byte[] Unused2 { get; set; }
		public FormID Effect { get; set; }

		public WeaponCriticalHitData()
		{
			Damage = new UInt16();
			Unused1 = new byte[2];
			ChanceMult = new Single();
			Flags = new WeaponCritFlags();
			Unused2 = new byte[3];
			Effect = new FormID();
		}

		public WeaponCriticalHitData(UInt16 Damage, Byte[] Unused1, Single ChanceMult, WeaponCritFlags Flags, Byte[] Unused2, FormID Effect)
		{
			this.Damage = Damage;
			this.Unused1 = Unused1;
			this.ChanceMult = ChanceMult;
			this.Flags = Flags;
			this.Unused2 = Unused2;
			this.Effect = Effect;
		}

		public WeaponCriticalHitData(WeaponCriticalHitData copyObject)
		{
			Damage = copyObject.Damage;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			ChanceMult = copyObject.ChanceMult;
			Flags = copyObject.Flags;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
			Effect = copyObject.Effect.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Damage = subReader.ReadUInt16();
					Unused1 = subReader.ReadBytes(2);
					ChanceMult = subReader.ReadSingle();
					Flags = subReader.ReadEnum<WeaponCritFlags>();
					Unused2 = subReader.ReadBytes(3);
					Effect.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Damage);			
			if (Unused1 == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused1);
			writer.Write(ChanceMult);			
			writer.Write((Byte)Flags);
			if (Unused2 == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused2);
			Effect.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Damage", true, out subEle);
			subEle.Value = Damage.ToString();

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("ChanceMult", true, out subEle);
			subEle.Value = ChanceMult.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();

			ele.TryPathTo("Effect", true, out subEle);
			Effect.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Damage", false, out subEle))
			{
				Damage = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("ChanceMult", false, out subEle))
			{
				ChanceMult = subEle.ToSingle();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<WeaponCritFlags>();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Effect", false, out subEle))
			{
				Effect.ReadXML(subEle, master);
			}
		}

		public WeaponCriticalHitData Clone()
		{
			return new WeaponCriticalHitData(this);
		}

	}
}
