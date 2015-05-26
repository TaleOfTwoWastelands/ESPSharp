using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Subrecords
{
	public partial class FactionData : Subrecord
	{
		public FactionFlags1 Flags1 { get; set; }
		public FactionFlags2 Flags2 { get; set; }
		public Byte[] Unused { get; set; }
	
		protected override void ReadData(ESPReader reader)
		{
			Flags1 = reader.ReadEnum<FactionFlags1>();
			Flags2 = reader.ReadEnum<FactionFlags2>();
			Unused = reader.ReadBytes(2);
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Flags1);
			writer.Write((Byte)Flags2);
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

			ele.TryPathTo("Flags1", false, out subEle);
			Flags1 = subEle.ToEnum<FactionFlags1>();

			ele.TryPathTo("Flags2", false, out subEle);
			Flags2 = subEle.ToEnum<FactionFlags2>();

			ele.TryPathTo("Unused", false, out subEle);
			Unused = subEle.ToBytes();
		}
	}
}
