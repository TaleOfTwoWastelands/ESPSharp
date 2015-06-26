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
	public partial class AmmoData : Subrecord, ICloneable<AmmoData>
	{
		public Single Speed { get; set; }
		public WeaponFlags Flags { get; set; }
		public Byte[] Unused { get; set; }
		public Int32 Value { get; set; }
		public Byte ClipRounds { get; set; }

		public AmmoData()
		{
			Speed = new Single();
			Flags = new WeaponFlags();
			Unused = new byte[3];
			Value = new Int32();
			ClipRounds = new Byte();
		}

		public AmmoData(Single Speed, WeaponFlags Flags, Byte[] Unused, Int32 Value, Byte ClipRounds)
		{
			this.Speed = Speed;
			this.Flags = Flags;
			this.Unused = Unused;
			this.Value = Value;
			this.ClipRounds = ClipRounds;
		}

		public AmmoData(AmmoData copyObject)
		{
			Speed = copyObject.Speed;
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
			Value = copyObject.Value;
			ClipRounds = copyObject.ClipRounds;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Speed = subReader.ReadSingle();
					Flags = subReader.ReadEnum<WeaponFlags>();
					Unused = subReader.ReadBytes(3);
					Value = subReader.ReadInt32();
					ClipRounds = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Speed);			
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
			writer.Write(Value);			
			writer.Write(ClipRounds);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Speed", true, out subEle);
			subEle.Value = Speed.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("ClipRounds", true, out subEle);
			subEle.Value = ClipRounds.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Speed", false, out subEle))
			{
				Speed = subEle.ToSingle();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<WeaponFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToInt32();
			}

			if (ele.TryPathTo("ClipRounds", false, out subEle))
			{
				ClipRounds = subEle.ToByte();
			}
		}

		public AmmoData Clone()
		{
			return new AmmoData(this);
		}

	}
}
