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
	public partial class BipedData : Subrecord, ICloneable<BipedData>
	{
		public BodySlotFlags Slots { get; set; }
		public BipedDataFlags Flags { get; set; }
		public Byte[] Unused { get; set; }

		public BipedData()
		{
			Slots = new BodySlotFlags();
			Flags = new BipedDataFlags();
			Unused = new byte[3];
		}

		public BipedData(BodySlotFlags Slots, BipedDataFlags Flags, Byte[] Unused)
		{
			this.Slots = Slots;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public BipedData(BipedData copyObject)
		{
			Slots = copyObject.Slots;
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Slots = subReader.ReadEnum<BodySlotFlags>();
					Flags = subReader.ReadEnum<BipedDataFlags>();
					Unused = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Slots);
			writer.Write((Int32)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Slots", true, out subEle);
			subEle.Value = Slots.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Slots", false, out subEle))
			{
				Slots = subEle.ToEnum<BodySlotFlags>();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<BipedDataFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public BipedData Clone()
		{
			return new BipedData(this);
		}
	}
}
