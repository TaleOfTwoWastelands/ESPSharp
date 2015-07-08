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
	public partial class RadioData : Subrecord, ICloneable<RadioData>, IReferenceContainer
	{
		public Single RangeRadius { get; set; }
		public BroadcastRangeType BroadcastRange { get; set; }
		public Single StaticPercentage { get; set; }
		public FormID PositionReference { get; set; }

		public RadioData()
		{
			RangeRadius = new Single();
			BroadcastRange = new BroadcastRangeType();
			StaticPercentage = new Single();
			PositionReference = new FormID();
		}

		public RadioData(Single RangeRadius, BroadcastRangeType BroadcastRange, Single StaticPercentage, FormID PositionReference)
		{
			this.RangeRadius = RangeRadius;
			this.BroadcastRange = BroadcastRange;
			this.StaticPercentage = StaticPercentage;
			this.PositionReference = PositionReference;
		}

		public RadioData(RadioData copyObject)
		{
			RangeRadius = copyObject.RangeRadius;
			BroadcastRange = copyObject.BroadcastRange;
			StaticPercentage = copyObject.StaticPercentage;
			PositionReference = copyObject.PositionReference.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					RangeRadius = subReader.ReadSingle();
					BroadcastRange = subReader.ReadEnum<BroadcastRangeType>();
					StaticPercentage = subReader.ReadSingle();
					PositionReference.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(RangeRadius);			
			writer.Write((UInt32)BroadcastRange);
			writer.Write(StaticPercentage);			
			PositionReference.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("RangeRadius", true, out subEle);
			subEle.Value = RangeRadius.ToString("G15");

			ele.TryPathTo("BroadcastRange", true, out subEle);
			subEle.Value = BroadcastRange.ToString();

			ele.TryPathTo("StaticPercentage", true, out subEle);
			subEle.Value = StaticPercentage.ToString("G15");

			ele.TryPathTo("PositionReference", true, out subEle);
			PositionReference.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("RangeRadius", false, out subEle))
			{
				RangeRadius = subEle.ToSingle();
			}

			if (ele.TryPathTo("BroadcastRange", false, out subEle))
			{
				BroadcastRange = subEle.ToEnum<BroadcastRangeType>();
			}

			if (ele.TryPathTo("StaticPercentage", false, out subEle))
			{
				StaticPercentage = subEle.ToSingle();
			}

			if (ele.TryPathTo("PositionReference", false, out subEle))
			{
				PositionReference.ReadXML(subEle, master);
			}
		}

		public RadioData Clone()
		{
			return new RadioData(this);
		}

	}
}
