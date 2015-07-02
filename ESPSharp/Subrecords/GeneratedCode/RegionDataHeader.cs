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
	public partial class RegionDataHeader : Subrecord, ICloneable<RegionDataHeader>
	{
		public RegionDataType Type { get; set; }
		public RegionDataFlags Flags { get; set; }
		public Byte Unused { get; set; }

		public RegionDataHeader()
		{
			Type = new RegionDataType();
			Flags = new RegionDataFlags();
			Unused = new Byte();
		}

		public RegionDataHeader(RegionDataType Type, RegionDataFlags Flags, Byte Unused)
		{
			this.Type = Type;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public RegionDataHeader(RegionDataHeader copyObject)
		{
			Type = copyObject.Type;
			Flags = copyObject.Flags;
			Unused = copyObject.Unused;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<RegionDataType>();
					Flags = subReader.ReadEnum<RegionDataFlags>();
					Unused = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Type);
			writer.Write((Byte)Flags);
			writer.Write(Unused);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<RegionDataType>();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<RegionDataFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToByte();
			}
		}

		public RegionDataHeader Clone()
		{
			return new RegionDataHeader(this);
		}

	}
}
