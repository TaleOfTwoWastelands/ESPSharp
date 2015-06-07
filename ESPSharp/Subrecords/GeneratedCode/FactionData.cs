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

namespace ESPSharp.Subrecords
{
	public partial class FactionData : Subrecord, ICloneable<FactionData>	{
		public FactionFlags1 Flags1 { get; set; }
		public FactionFlags2 Flags2 { get; set; }
		public Byte[] Unused { get; set; }

		public FactionData()
		{
			Flags1 = new FactionFlags1();
			Flags2 = new FactionFlags2();
			Unused = new byte[2];
		}

		public FactionData(FactionFlags1 Flags1, FactionFlags2 Flags2, Byte[] Unused)
		{
			this.Flags1 = Flags1;
			this.Flags2 = Flags2;
			this.Unused = Unused;
		}

		public FactionData(FactionData copyObject)
		{
			Flags1 = copyObject.Flags1;
			Flags2 = copyObject.Flags2;
			Unused = (byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags1 = subReader.ReadEnum<FactionFlags1>();
					Flags2 = subReader.ReadEnum<FactionFlags2>();
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
			writer.Write((Byte)Flags1);
			writer.Write((Byte)Flags2);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Flags1", true, out subEle);
			subEle.Value = Flags1.ToString();

			ele.TryPathTo("Flags2", true, out subEle);
			subEle.Value = Flags2.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Flags1", false, out subEle))
			{
				Flags1 = subEle.ToEnum<FactionFlags1>();
			}

			if (ele.TryPathTo("Flags2", false, out subEle))
			{
				Flags2 = subEle.ToEnum<FactionFlags2>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public FactionData Clone()
		{
			return new FactionData(this);
		}
	}
}
