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
	public partial class MapMarkerData : Subrecord, ICloneable<MapMarkerData>
	{
		public MapMarkerType Type { get; set; }
		public Byte[] Unused { get; set; }

		public MapMarkerData()
		{
			Type = new MapMarkerType();
			Unused = new byte[1];
		}

		public MapMarkerData(MapMarkerType Type, Byte[] Unused)
		{
			this.Type = Type;
			this.Unused = Unused;
		}

		public MapMarkerData(MapMarkerData copyObject)
		{
			Type = copyObject.Type;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<MapMarkerType>();
					Unused = subReader.ReadBytes(1);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Type);
			if (Unused == null)
				writer.Write(new byte[1]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<MapMarkerType>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public MapMarkerData Clone()
		{
			return new MapMarkerData(this);
		}

	}
}
