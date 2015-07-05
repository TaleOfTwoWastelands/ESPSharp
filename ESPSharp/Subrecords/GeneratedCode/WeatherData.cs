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
	public partial class WeatherData : Subrecord, ICloneable<WeatherData>
	{
		public Byte WindSpeed { get; set; }
		public Byte CloudSpeedLower { get; set; }
		public Byte CloudSpeedUpper { get; set; }
		public Byte TransitionDelta { get; set; }
		public Byte SunGlare { get; set; }
		public Byte SunDamage { get; set; }
		public Byte PrecipitationBeginFadeIn { get; set; }
		public Byte PrecipitationEndFadeOut { get; set; }
		public Byte Thunder_LightningBeginFadeIn { get; set; }
		public Byte Thunder_LightningEndFadeOut { get; set; }
		public Byte Thunder_LightningFrequency { get; set; }
		public WeatherClassification Classification { get; set; }
		public Byte LightningColorRed { get; set; }
		public Byte LightningColorGreen { get; set; }
		public Byte LightningColorBlue { get; set; }

		public WeatherData()
		{
			WindSpeed = new Byte();
			CloudSpeedLower = new Byte();
			CloudSpeedUpper = new Byte();
			TransitionDelta = new Byte();
			SunGlare = new Byte();
			SunDamage = new Byte();
			PrecipitationBeginFadeIn = new Byte();
			PrecipitationEndFadeOut = new Byte();
			Thunder_LightningBeginFadeIn = new Byte();
			Thunder_LightningEndFadeOut = new Byte();
			Thunder_LightningFrequency = new Byte();
			Classification = new WeatherClassification();
			LightningColorRed = new Byte();
			LightningColorGreen = new Byte();
			LightningColorBlue = new Byte();
		}

		public WeatherData(Byte WindSpeed, Byte CloudSpeedLower, Byte CloudSpeedUpper, Byte TransitionDelta, Byte SunGlare, Byte SunDamage, Byte PrecipitationBeginFadeIn, Byte PrecipitationEndFadeOut, Byte Thunder_LightningBeginFadeIn, Byte Thunder_LightningEndFadeOut, Byte Thunder_LightningFrequency, WeatherClassification Classification, Byte LightningColorRed, Byte LightningColorGreen, Byte LightningColorBlue)
		{
			this.WindSpeed = WindSpeed;
			this.CloudSpeedLower = CloudSpeedLower;
			this.CloudSpeedUpper = CloudSpeedUpper;
			this.TransitionDelta = TransitionDelta;
			this.SunGlare = SunGlare;
			this.SunDamage = SunDamage;
			this.PrecipitationBeginFadeIn = PrecipitationBeginFadeIn;
			this.PrecipitationEndFadeOut = PrecipitationEndFadeOut;
			this.Thunder_LightningBeginFadeIn = Thunder_LightningBeginFadeIn;
			this.Thunder_LightningEndFadeOut = Thunder_LightningEndFadeOut;
			this.Thunder_LightningFrequency = Thunder_LightningFrequency;
			this.Classification = Classification;
			this.LightningColorRed = LightningColorRed;
			this.LightningColorGreen = LightningColorGreen;
			this.LightningColorBlue = LightningColorBlue;
		}

		public WeatherData(WeatherData copyObject)
		{
			WindSpeed = copyObject.WindSpeed;
			CloudSpeedLower = copyObject.CloudSpeedLower;
			CloudSpeedUpper = copyObject.CloudSpeedUpper;
			TransitionDelta = copyObject.TransitionDelta;
			SunGlare = copyObject.SunGlare;
			SunDamage = copyObject.SunDamage;
			PrecipitationBeginFadeIn = copyObject.PrecipitationBeginFadeIn;
			PrecipitationEndFadeOut = copyObject.PrecipitationEndFadeOut;
			Thunder_LightningBeginFadeIn = copyObject.Thunder_LightningBeginFadeIn;
			Thunder_LightningEndFadeOut = copyObject.Thunder_LightningEndFadeOut;
			Thunder_LightningFrequency = copyObject.Thunder_LightningFrequency;
			Classification = copyObject.Classification;
			LightningColorRed = copyObject.LightningColorRed;
			LightningColorGreen = copyObject.LightningColorGreen;
			LightningColorBlue = copyObject.LightningColorBlue;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					WindSpeed = subReader.ReadByte();
					CloudSpeedLower = subReader.ReadByte();
					CloudSpeedUpper = subReader.ReadByte();
					TransitionDelta = subReader.ReadByte();
					SunGlare = subReader.ReadByte();
					SunDamage = subReader.ReadByte();
					PrecipitationBeginFadeIn = subReader.ReadByte();
					PrecipitationEndFadeOut = subReader.ReadByte();
					Thunder_LightningBeginFadeIn = subReader.ReadByte();
					Thunder_LightningEndFadeOut = subReader.ReadByte();
					Thunder_LightningFrequency = subReader.ReadByte();
					Classification = subReader.ReadEnum<WeatherClassification>();
					LightningColorRed = subReader.ReadByte();
					LightningColorGreen = subReader.ReadByte();
					LightningColorBlue = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(WindSpeed);			
			writer.Write(CloudSpeedLower);			
			writer.Write(CloudSpeedUpper);			
			writer.Write(TransitionDelta);			
			writer.Write(SunGlare);			
			writer.Write(SunDamage);			
			writer.Write(PrecipitationBeginFadeIn);			
			writer.Write(PrecipitationEndFadeOut);			
			writer.Write(Thunder_LightningBeginFadeIn);			
			writer.Write(Thunder_LightningEndFadeOut);			
			writer.Write(Thunder_LightningFrequency);			
			writer.Write((Byte)Classification);
			writer.Write(LightningColorRed);			
			writer.Write(LightningColorGreen);			
			writer.Write(LightningColorBlue);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("WindSpeed", true, out subEle);
			subEle.Value = WindSpeed.ToString();

			ele.TryPathTo("CloudSpeed/Lower", true, out subEle);
			subEle.Value = CloudSpeedLower.ToString();

			ele.TryPathTo("CloudSpeed/Upper", true, out subEle);
			subEle.Value = CloudSpeedUpper.ToString();

			ele.TryPathTo("TransitionDelta", true, out subEle);
			subEle.Value = TransitionDelta.ToString();

			ele.TryPathTo("SunGlare", true, out subEle);
			subEle.Value = SunGlare.ToString();

			ele.TryPathTo("SunDamage", true, out subEle);
			subEle.Value = SunDamage.ToString();

			ele.TryPathTo("Precipitation/BeginFadeIn", true, out subEle);
			subEle.Value = PrecipitationBeginFadeIn.ToString();

			ele.TryPathTo("Precipitation/EndFadeOut", true, out subEle);
			subEle.Value = PrecipitationEndFadeOut.ToString();

			ele.TryPathTo("Thunder_Lightning/BeginFadeIn", true, out subEle);
			subEle.Value = Thunder_LightningBeginFadeIn.ToString();

			ele.TryPathTo("Thunder_Lightning/EndFadeOut", true, out subEle);
			subEle.Value = Thunder_LightningEndFadeOut.ToString();

			ele.TryPathTo("Thunder_Lightning/Frequency", true, out subEle);
			subEle.Value = Thunder_LightningFrequency.ToString();

			ele.TryPathTo("Classification", true, out subEle);
			subEle.Value = Classification.ToString();

			ele.TryPathTo("LightningColor/Red", true, out subEle);
			subEle.Value = LightningColorRed.ToString();

			ele.TryPathTo("LightningColor/Green", true, out subEle);
			subEle.Value = LightningColorGreen.ToString();

			ele.TryPathTo("LightningColor/Blue", true, out subEle);
			subEle.Value = LightningColorBlue.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("WindSpeed", false, out subEle))
			{
				WindSpeed = subEle.ToByte();
			}

			if (ele.TryPathTo("CloudSpeed/Lower", false, out subEle))
			{
				CloudSpeedLower = subEle.ToByte();
			}

			if (ele.TryPathTo("CloudSpeed/Upper", false, out subEle))
			{
				CloudSpeedUpper = subEle.ToByte();
			}

			if (ele.TryPathTo("TransitionDelta", false, out subEle))
			{
				TransitionDelta = subEle.ToByte();
			}

			if (ele.TryPathTo("SunGlare", false, out subEle))
			{
				SunGlare = subEle.ToByte();
			}

			if (ele.TryPathTo("SunDamage", false, out subEle))
			{
				SunDamage = subEle.ToByte();
			}

			if (ele.TryPathTo("Precipitation/BeginFadeIn", false, out subEle))
			{
				PrecipitationBeginFadeIn = subEle.ToByte();
			}

			if (ele.TryPathTo("Precipitation/EndFadeOut", false, out subEle))
			{
				PrecipitationEndFadeOut = subEle.ToByte();
			}

			if (ele.TryPathTo("Thunder_Lightning/BeginFadeIn", false, out subEle))
			{
				Thunder_LightningBeginFadeIn = subEle.ToByte();
			}

			if (ele.TryPathTo("Thunder_Lightning/EndFadeOut", false, out subEle))
			{
				Thunder_LightningEndFadeOut = subEle.ToByte();
			}

			if (ele.TryPathTo("Thunder_Lightning/Frequency", false, out subEle))
			{
				Thunder_LightningFrequency = subEle.ToByte();
			}

			if (ele.TryPathTo("Classification", false, out subEle))
			{
				Classification = subEle.ToEnum<WeatherClassification>();
			}

			if (ele.TryPathTo("LightningColor/Red", false, out subEle))
			{
				LightningColorRed = subEle.ToByte();
			}

			if (ele.TryPathTo("LightningColor/Green", false, out subEle))
			{
				LightningColorGreen = subEle.ToByte();
			}

			if (ele.TryPathTo("LightningColor/Blue", false, out subEle))
			{
				LightningColorBlue = subEle.ToByte();
			}
		}

		public WeatherData Clone()
		{
			return new WeatherData(this);
		}

	}
}
