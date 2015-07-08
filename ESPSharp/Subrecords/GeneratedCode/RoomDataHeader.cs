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
	public partial class RoomDataHeader : Subrecord, ICloneable<RoomDataHeader>
	{
		public UInt16 LinkedRoomsCount { get; set; }
		public Byte[] Unknown { get; set; }

		public RoomDataHeader()
		{
			LinkedRoomsCount = new UInt16();
			Unknown = new byte[2];
		}

		public RoomDataHeader(UInt16 LinkedRoomsCount, Byte[] Unknown)
		{
			this.LinkedRoomsCount = LinkedRoomsCount;
			this.Unknown = Unknown;
		}

		public RoomDataHeader(RoomDataHeader copyObject)
		{
			LinkedRoomsCount = copyObject.LinkedRoomsCount;
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					LinkedRoomsCount = subReader.ReadUInt16();
					Unknown = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(LinkedRoomsCount);			
			if (Unknown == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("LinkedRoomsCount", true, out subEle);
			subEle.Value = LinkedRoomsCount.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("LinkedRoomsCount", false, out subEle))
			{
				LinkedRoomsCount = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public RoomDataHeader Clone()
		{
			return new RoomDataHeader(this);
		}

	}
}
