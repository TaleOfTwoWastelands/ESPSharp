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
	public partial class IngestibleData : Subrecord, ICloneable<IngestibleData>, IReferenceContainer
	{
		public Int32 Value { get; set; }
		public IngestibleFlags Flags { get; set; }
		public Byte[] Unused { get; set; }
		public FormID WithdrawalEffect { get; set; }
		public Single AddictionChance { get; set; }
		public FormID SoundConsume { get; set; }

		public IngestibleData()
		{
			Value = new Int32();
			Flags = new IngestibleFlags();
			Unused = new byte[3];
			WithdrawalEffect = new FormID();
			AddictionChance = new Single();
			SoundConsume = new FormID();
		}

		public IngestibleData(Int32 Value, IngestibleFlags Flags, Byte[] Unused, FormID WithdrawalEffect, Single AddictionChance, FormID SoundConsume)
		{
			this.Value = Value;
			this.Flags = Flags;
			this.Unused = Unused;
			this.WithdrawalEffect = WithdrawalEffect;
			this.AddictionChance = AddictionChance;
			this.SoundConsume = SoundConsume;
		}

		public IngestibleData(IngestibleData copyObject)
		{
			Value = copyObject.Value;
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
			WithdrawalEffect = copyObject.WithdrawalEffect.Clone();
			AddictionChance = copyObject.AddictionChance;
			SoundConsume = copyObject.SoundConsume.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Value = subReader.ReadInt32();
					Flags = subReader.ReadEnum<IngestibleFlags>();
					Unused = subReader.ReadBytes(3);
					WithdrawalEffect.ReadBinary(subReader);
					AddictionChance = subReader.ReadSingle();
					SoundConsume.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Value);			
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
			WithdrawalEffect.WriteBinary(writer);
			writer.Write(AddictionChance);			
			SoundConsume.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("WithdrawalEffect", true, out subEle);
			WithdrawalEffect.WriteXML(subEle, master);

			ele.TryPathTo("AddictionChance", true, out subEle);
			subEle.Value = AddictionChance.ToString("G15");

			ele.TryPathTo("ConsumeSound", true, out subEle);
			SoundConsume.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToInt32();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<IngestibleFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("WithdrawalEffect", false, out subEle))
			{
				WithdrawalEffect.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("AddictionChance", false, out subEle))
			{
				AddictionChance = subEle.ToSingle();
			}

			if (ele.TryPathTo("ConsumeSound", false, out subEle))
			{
				SoundConsume.ReadXML(subEle, master);
			}
		}

		public IngestibleData Clone()
		{
			return new IngestibleData(this);
		}

	}
}
