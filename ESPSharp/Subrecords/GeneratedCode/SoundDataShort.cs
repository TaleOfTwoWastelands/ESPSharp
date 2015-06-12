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
	public partial class SoundDataShort : Subrecord, ICloneable<SoundDataShort>
	{
		public Byte MinAttenuationDistance { get; set; }
		public Byte MaxAttenuationDistance { get; set; }
		public SByte FrequencyAdjustmentPercentage { get; set; }
		public Byte Unused { get; set; }
		public SoundDataFlags SoundDataFlags { get; set; }
		public Int16 StaticAttenuationcdB { get; set; }
		public Byte StopTime { get; set; }
		public Byte StartTime { get; set; }

		public SoundDataShort()
		{
			MinAttenuationDistance = new Byte();
			MaxAttenuationDistance = new Byte();
			FrequencyAdjustmentPercentage = new SByte();
			Unused = new Byte();
			SoundDataFlags = new SoundDataFlags();
			StaticAttenuationcdB = new Int16();
			StopTime = new Byte();
			StartTime = new Byte();
		}

		public SoundDataShort(Byte MinAttenuationDistance, Byte MaxAttenuationDistance, SByte FrequencyAdjustmentPercentage, Byte Unused, SoundDataFlags SoundDataFlags, Int16 StaticAttenuationcdB, Byte StopTime, Byte StartTime)
		{
			this.MinAttenuationDistance = MinAttenuationDistance;
			this.MaxAttenuationDistance = MaxAttenuationDistance;
			this.FrequencyAdjustmentPercentage = FrequencyAdjustmentPercentage;
			this.Unused = Unused;
			this.SoundDataFlags = SoundDataFlags;
			this.StaticAttenuationcdB = StaticAttenuationcdB;
			this.StopTime = StopTime;
			this.StartTime = StartTime;
		}

		public SoundDataShort(SoundDataShort copyObject)
		{
			MinAttenuationDistance = copyObject.MinAttenuationDistance;
			MaxAttenuationDistance = copyObject.MaxAttenuationDistance;
			FrequencyAdjustmentPercentage = copyObject.FrequencyAdjustmentPercentage;
			Unused = copyObject.Unused;
			SoundDataFlags = copyObject.SoundDataFlags;
			StaticAttenuationcdB = copyObject.StaticAttenuationcdB;
			StopTime = copyObject.StopTime;
			StartTime = copyObject.StartTime;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Master))
			{
				try
				{
					MinAttenuationDistance = subReader.ReadByte();
					MaxAttenuationDistance = subReader.ReadByte();
					FrequencyAdjustmentPercentage = subReader.ReadSByte();
					Unused = subReader.ReadByte();
					SoundDataFlags = subReader.ReadEnum<SoundDataFlags>();
					StaticAttenuationcdB = subReader.ReadInt16();
					StopTime = subReader.ReadByte();
					StartTime = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(MinAttenuationDistance);			
			writer.Write(MaxAttenuationDistance);			
			writer.Write(FrequencyAdjustmentPercentage);			
			writer.Write(Unused);			
			writer.Write((UInt32)SoundDataFlags);
			writer.Write(StaticAttenuationcdB);			
			writer.Write(StopTime);			
			writer.Write(StartTime);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Attenuation/Distance/Min", true, out subEle);
			subEle.Value = MinAttenuationDistance.ToString();

			ele.TryPathTo("Attenuation/Distance/Max", true, out subEle);
			subEle.Value = MaxAttenuationDistance.ToString();

			ele.TryPathTo("FrequencyAdjustmentPercentage", true, out subEle);
			subEle.Value = FrequencyAdjustmentPercentage.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = SoundDataFlags.ToString();

			ele.TryPathTo("Attenuation/StaticAttenuationcdB", true, out subEle);
			subEle.Value = StaticAttenuationcdB.ToString();

			ele.TryPathTo("Time/Stop", true, out subEle);
			subEle.Value = StopTime.ToString();

			ele.TryPathTo("Time/Start", true, out subEle);
			subEle.Value = StartTime.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Attenuation/Distance/Min", false, out subEle))
			{
				MinAttenuationDistance = subEle.ToByte();
			}

			if (ele.TryPathTo("Attenuation/Distance/Max", false, out subEle))
			{
				MaxAttenuationDistance = subEle.ToByte();
			}

			if (ele.TryPathTo("FrequencyAdjustmentPercentage", false, out subEle))
			{
				FrequencyAdjustmentPercentage = subEle.ToSByte();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToByte();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				SoundDataFlags = subEle.ToEnum<SoundDataFlags>();
			}

			if (ele.TryPathTo("Attenuation/StaticAttenuationcdB", false, out subEle))
			{
				StaticAttenuationcdB = subEle.ToInt16();
			}

			if (ele.TryPathTo("Time/Stop", false, out subEle))
			{
				StopTime = subEle.ToByte();
			}

			if (ele.TryPathTo("Time/Start", false, out subEle))
			{
				StartTime = subEle.ToByte();
			}
		}

		public SoundDataShort Clone()
		{
			return new SoundDataShort(this);
		}
	}
}
