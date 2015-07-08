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
	public partial class WorldMapOffsetData : Subrecord, ICloneable<WorldMapOffsetData>
	{
		public Single WorldMapScale { get; set; }
		public Single CellXOffset { get; set; }
		public Single CellYOffset { get; set; }

		public WorldMapOffsetData()
		{
			WorldMapScale = new Single();
			CellXOffset = new Single();
			CellYOffset = new Single();
		}

		public WorldMapOffsetData(Single WorldMapScale, Single CellXOffset, Single CellYOffset)
		{
			this.WorldMapScale = WorldMapScale;
			this.CellXOffset = CellXOffset;
			this.CellYOffset = CellYOffset;
		}

		public WorldMapOffsetData(WorldMapOffsetData copyObject)
		{
			WorldMapScale = copyObject.WorldMapScale;
			CellXOffset = copyObject.CellXOffset;
			CellYOffset = copyObject.CellYOffset;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					WorldMapScale = subReader.ReadSingle();
					CellXOffset = subReader.ReadSingle();
					CellYOffset = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(WorldMapScale);			
			writer.Write(CellXOffset);			
			writer.Write(CellYOffset);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("WorldMapScale", true, out subEle);
			subEle.Value = WorldMapScale.ToString("G15");

			ele.TryPathTo("Offset/CellX", true, out subEle);
			subEle.Value = CellXOffset.ToString("G15");

			ele.TryPathTo("Offset/CellY", true, out subEle);
			subEle.Value = CellYOffset.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("WorldMapScale", false, out subEle))
			{
				WorldMapScale = subEle.ToSingle();
			}

			if (ele.TryPathTo("Offset/CellX", false, out subEle))
			{
				CellXOffset = subEle.ToSingle();
			}

			if (ele.TryPathTo("Offset/CellY", false, out subEle))
			{
				CellYOffset = subEle.ToSingle();
			}
		}

		public WorldMapOffsetData Clone()
		{
			return new WorldMapOffsetData(this);
		}

	}
}
