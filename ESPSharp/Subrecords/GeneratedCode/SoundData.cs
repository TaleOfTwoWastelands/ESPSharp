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
	public partial class SoundData : Subrecord, ICloneable<SoundData>
	{
		public Byte MinAttenuationDistance { get; set; }
		public Byte MaxAttenuationDistance { get; set; }
		public SByte FrequencyAdjustmentPercentage { get; set; }
		public Byte Unused { get; set; }
		public SoundDataFlags SoundDataFlags { get; set; }
		public Int16 StaticAttenuationcdB { get; set; }
		public Byte StopTime { get; set; }
		public Byte StartTime { get; set; }
		public Int16 AttenuationCurvePoint1 { get; set; }
		public Int16 AttenuationCurvePoint2 { get; set; }
		public Int16 AttenuationCurvePoint3 { get; set; }
		public Int16 AttenuationCurvePoint4 { get; set; }
		public Int16 AttenuationCurvePoint5 { get; set; }
		public Int16 ReverbAttenuationControl { get; set; }
		public Int32 Priority { get; set; }
		public Byte[] Unknown { get; set; }

		public SoundData()
		{
			MinAttenuationDistance = new Byte();
			MaxAttenuationDistance = new Byte();
			FrequencyAdjustmentPercentage = new SByte();
			Unused = new Byte();
			SoundDataFlags = new SoundDataFlags();
			StaticAttenuationcdB = new Int16();
			StopTime = new Byte();
			StartTime = new Byte();
			AttenuationCurvePoint1 = new Int16();
			AttenuationCurvePoint2 = new Int16();
			AttenuationCurvePoint3 = new Int16();
			AttenuationCurvePoint4 = new Int16();
			AttenuationCurvePoint5 = new Int16();
			ReverbAttenuationControl = new Int16();
			Priority = new Int32();
			Unknown = new byte[8];
		}

		public SoundData(Byte MinAttenuationDistance, Byte MaxAttenuationDistance, SByte FrequencyAdjustmentPercentage, Byte Unused, SoundDataFlags SoundDataFlags, Int16 StaticAttenuationcdB, Byte StopTime, Byte StartTime, Int16 AttenuationCurvePoint1, Int16 AttenuationCurvePoint2, Int16 AttenuationCurvePoint3, Int16 AttenuationCurvePoint4, Int16 AttenuationCurvePoint5, Int16 ReverbAttenuationControl, Int32 Priority, Byte[] Unknown)
		{
			this.MinAttenuationDistance = MinAttenuationDistance;
			this.MaxAttenuationDistance = MaxAttenuationDistance;
			this.FrequencyAdjustmentPercentage = FrequencyAdjustmentPercentage;
			this.Unused = Unused;
			this.SoundDataFlags = SoundDataFlags;
			this.StaticAttenuationcdB = StaticAttenuationcdB;
			this.StopTime = StopTime;
			this.StartTime = StartTime;
			this.AttenuationCurvePoint1 = AttenuationCurvePoint1;
			this.AttenuationCurvePoint2 = AttenuationCurvePoint2;
			this.AttenuationCurvePoint3 = AttenuationCurvePoint3;
			this.AttenuationCurvePoint4 = AttenuationCurvePoint4;
			this.AttenuationCurvePoint5 = AttenuationCurvePoint5;
			this.ReverbAttenuationControl = ReverbAttenuationControl;
			this.Priority = Priority;
			this.Unknown = Unknown;
		}

		public SoundData(SoundData copyObject)
		{
			MinAttenuationDistance = copyObject.MinAttenuationDistance;
			MaxAttenuationDistance = copyObject.MaxAttenuationDistance;
			FrequencyAdjustmentPercentage = copyObject.FrequencyAdjustmentPercentage;
			Unused = copyObject.Unused;
			SoundDataFlags = copyObject.SoundDataFlags;
			StaticAttenuationcdB = copyObject.StaticAttenuationcdB;
			StopTime = copyObject.StopTime;
			StartTime = copyObject.StartTime;
			AttenuationCurvePoint1 = copyObject.AttenuationCurvePoint1;
			AttenuationCurvePoint2 = copyObject.AttenuationCurvePoint2;
			AttenuationCurvePoint3 = copyObject.AttenuationCurvePoint3;
			AttenuationCurvePoint4 = copyObject.AttenuationCurvePoint4;
			AttenuationCurvePoint5 = copyObject.AttenuationCurvePoint5;
			ReverbAttenuationControl = copyObject.ReverbAttenuationControl;
			Priority = copyObject.Priority;
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
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
					AttenuationCurvePoint1 = subReader.ReadInt16();
					AttenuationCurvePoint2 = subReader.ReadInt16();
					AttenuationCurvePoint3 = subReader.ReadInt16();
					AttenuationCurvePoint4 = subReader.ReadInt16();
					AttenuationCurvePoint5 = subReader.ReadInt16();
					ReverbAttenuationControl = subReader.ReadInt16();
					Priority = subReader.ReadInt32();
					Unknown = subReader.ReadBytes(8);
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
			writer.Write(AttenuationCurvePoint1);			
			writer.Write(AttenuationCurvePoint2);			
			writer.Write(AttenuationCurvePoint3);			
			writer.Write(AttenuationCurvePoint4);			
			writer.Write(AttenuationCurvePoint5);			
			writer.Write(ReverbAttenuationControl);			
			writer.Write(Priority);			
			if (Unknown == null)
				writer.Write(new byte[8]);
			else
				writer.Write(Unknown);
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

			ele.TryPathTo("Attenuation/Curve/Point1", true, out subEle);
			subEle.Value = AttenuationCurvePoint1.ToString();

			ele.TryPathTo("Attenuation/Curve/Point2", true, out subEle);
			subEle.Value = AttenuationCurvePoint2.ToString();

			ele.TryPathTo("Attenuation/Curve/Point3", true, out subEle);
			subEle.Value = AttenuationCurvePoint3.ToString();

			ele.TryPathTo("Attenuation/Curve/Point4", true, out subEle);
			subEle.Value = AttenuationCurvePoint4.ToString();

			ele.TryPathTo("Attenuation/Curve/Point5", true, out subEle);
			subEle.Value = AttenuationCurvePoint5.ToString();

			ele.TryPathTo("Attenuation/ReverbAttenuationControl", true, out subEle);
			subEle.Value = ReverbAttenuationControl.ToString();

			ele.TryPathTo("Priority", true, out subEle);
			subEle.Value = Priority.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
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

			if (ele.TryPathTo("Attenuation/Curve/Point1", false, out subEle))
			{
				AttenuationCurvePoint1 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Attenuation/Curve/Point2", false, out subEle))
			{
				AttenuationCurvePoint2 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Attenuation/Curve/Point3", false, out subEle))
			{
				AttenuationCurvePoint3 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Attenuation/Curve/Point4", false, out subEle))
			{
				AttenuationCurvePoint4 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Attenuation/Curve/Point5", false, out subEle))
			{
				AttenuationCurvePoint5 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Attenuation/ReverbAttenuationControl", false, out subEle))
			{
				ReverbAttenuationControl = subEle.ToInt16();
			}

			if (ele.TryPathTo("Priority", false, out subEle))
			{
				Priority = subEle.ToInt32();
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public SoundData Clone()
		{
			return new SoundData(this);
		}

	}
}
