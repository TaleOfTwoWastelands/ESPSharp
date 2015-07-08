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
	public partial class WorldLandData : Subrecord, ICloneable<WorldLandData>
	{
		public Single DefaultLandHeight { get; set; }
		public Single DefaultWaterHeight { get; set; }

		public WorldLandData()
		{
			DefaultLandHeight = new Single();
			DefaultWaterHeight = new Single();
		}

		public WorldLandData(Single DefaultLandHeight, Single DefaultWaterHeight)
		{
			this.DefaultLandHeight = DefaultLandHeight;
			this.DefaultWaterHeight = DefaultWaterHeight;
		}

		public WorldLandData(WorldLandData copyObject)
		{
			DefaultLandHeight = copyObject.DefaultLandHeight;
			DefaultWaterHeight = copyObject.DefaultWaterHeight;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					DefaultLandHeight = subReader.ReadSingle();
					DefaultWaterHeight = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DefaultLandHeight);			
			writer.Write(DefaultWaterHeight);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("DefaultLandHeight", true, out subEle);
			subEle.Value = DefaultLandHeight.ToString("G15");

			ele.TryPathTo("DefaultWaterHeight", true, out subEle);
			subEle.Value = DefaultWaterHeight.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("DefaultLandHeight", false, out subEle))
			{
				DefaultLandHeight = subEle.ToSingle();
			}

			if (ele.TryPathTo("DefaultWaterHeight", false, out subEle))
			{
				DefaultWaterHeight = subEle.ToSingle();
			}
		}

		public WorldLandData Clone()
		{
			return new WorldLandData(this);
		}

	}
}
