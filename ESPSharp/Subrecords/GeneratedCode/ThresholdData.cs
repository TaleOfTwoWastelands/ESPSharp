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
	public partial class ThresholdData : Subrecord, ICloneable<ThresholdData>, IReferenceContainer
	{
		public UInt32 TriggerThreshold { get; set; }
		public FormID Effect { get; set; }

		public ThresholdData()
		{
			TriggerThreshold = new UInt32();
			Effect = new FormID();
		}

		public ThresholdData(UInt32 TriggerThreshold, FormID Effect)
		{
			this.TriggerThreshold = TriggerThreshold;
			this.Effect = Effect;
		}

		public ThresholdData(ThresholdData copyObject)
		{
			TriggerThreshold = copyObject.TriggerThreshold;
			Effect = copyObject.Effect.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					TriggerThreshold = subReader.ReadUInt32();
					Effect.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(TriggerThreshold);			
			Effect.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("TriggerThreshold", true, out subEle);
			subEle.Value = TriggerThreshold.ToString();

			ele.TryPathTo("Effect", true, out subEle);
			Effect.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("TriggerThreshold", false, out subEle))
			{
				TriggerThreshold = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Effect", false, out subEle))
			{
				Effect.ReadXML(subEle, master);
			}
		}

		public ThresholdData Clone()
		{
			return new ThresholdData(this);
		}

	}
}
