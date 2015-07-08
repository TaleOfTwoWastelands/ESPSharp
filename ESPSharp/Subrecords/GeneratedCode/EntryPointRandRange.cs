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
	public partial class EntryPointRandRange : Subrecord, ICloneable<EntryPointRandRange>
	{
		public Single RandMin { get; set; }
		public Single RandMax { get; set; }

		public EntryPointRandRange()
		{
			RandMin = new Single();
			RandMax = new Single();
		}

		public EntryPointRandRange(Single RandMin, Single RandMax)
		{
			this.RandMin = RandMin;
			this.RandMax = RandMax;
		}

		public EntryPointRandRange(EntryPointRandRange copyObject)
		{
			RandMin = copyObject.RandMin;
			RandMax = copyObject.RandMax;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					RandMin = subReader.ReadSingle();
					RandMax = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(RandMin);			
			writer.Write(RandMax);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("RandMin", true, out subEle);
			subEle.Value = RandMin.ToString("G15");

			ele.TryPathTo("RandMax", true, out subEle);
			subEle.Value = RandMax.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("RandMin", false, out subEle))
			{
				RandMin = subEle.ToSingle();
			}

			if (ele.TryPathTo("RandMax", false, out subEle))
			{
				RandMax = subEle.ToSingle();
			}
		}

		public EntryPointRandRange Clone()
		{
			return new EntryPointRandRange(this);
		}

	}
}
