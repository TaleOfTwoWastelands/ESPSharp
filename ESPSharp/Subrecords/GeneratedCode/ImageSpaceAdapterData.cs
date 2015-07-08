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
	public partial class ImageSpaceAdapterData : Subrecord, ICloneable<ImageSpaceAdapterData>
	{
		public NoYes IsAnimatable { get; set; }
		public Single Duration { get; set; }
		public UInt32 HDREyeAdaptSpeedMult { get; set; }
		public UInt32 HDREyeAdaptSpeedAdd { get; set; }
		public UInt32 HDRBloomBlurRadiusMult { get; set; }
		public UInt32 HDRBloomBlurRadiusAdd { get; set; }
		public UInt32 HDRBloomThresholdMult { get; set; }
		public UInt32 HDRBloomThresholdAdd { get; set; }
		public UInt32 HDRBloomScaleMult { get; set; }
		public UInt32 HDRBloomScaleAdd { get; set; }
		public UInt32 HDRTargetLumMinMult { get; set; }
		public UInt32 HDRTargetLumMinAdd { get; set; }
		public UInt32 HDRTargetLumMaxMult { get; set; }
		public UInt32 HDRTargetLumMaxAdd { get; set; }
		public UInt32 HDRSunlightScaleMult { get; set; }
		public UInt32 HDRSunlightScaleAdd { get; set; }
		public UInt32 HDRSkyScaleMult { get; set; }
		public UInt32 HDRSkyScaleAdd { get; set; }
		public Byte[] Unknown1 { get; set; }
		public UInt32 CinematicSaturationMult { get; set; }
		public UInt32 CinematicSaturationAdd { get; set; }
		public UInt32 CinematicBrightnessMult { get; set; }
		public UInt32 CinematicBrightnessAdd { get; set; }
		public UInt32 CinematicContrastMult { get; set; }
		public UInt32 CinematicContrastAdd { get; set; }
		public Byte[] Unknown2 { get; set; }
		public Color TintColor { get; set; }
		public UInt32 BlurRadius { get; set; }
		public UInt32 DoubleVisionStrength { get; set; }
		public UInt32 RadialBlurStrength { get; set; }
		public UInt32 RadialBlurRampUp { get; set; }
		public UInt32 RadialBlurStart { get; set; }
		public NoYes RadialBlurUseTarget { get; set; }
		public UInt32 RadialBlurCenterX { get; set; }
		public UInt32 RadialBlurCenterY { get; set; }
		public UInt32 DepthOfFieldStrength { get; set; }
		public UInt32 DepthOfFieldDistance { get; set; }
		public UInt32 DepthOfFieldRange { get; set; }
		public NoYes DepthOfFieldUseTarget { get; set; }
		public UInt32 RadialBlurRampDown { get; set; }
		public UInt32 RadialBlurDownStart { get; set; }
		public Color FadeColor { get; set; }
		public NoYes MotionBlurStrength { get; set; }

		public ImageSpaceAdapterData()
		{
			IsAnimatable = new NoYes();
			Duration = new Single();
			HDREyeAdaptSpeedMult = new UInt32();
			HDREyeAdaptSpeedAdd = new UInt32();
			HDRBloomBlurRadiusMult = new UInt32();
			HDRBloomBlurRadiusAdd = new UInt32();
			HDRBloomThresholdMult = new UInt32();
			HDRBloomThresholdAdd = new UInt32();
			HDRBloomScaleMult = new UInt32();
			HDRBloomScaleAdd = new UInt32();
			HDRTargetLumMinMult = new UInt32();
			HDRTargetLumMinAdd = new UInt32();
			HDRTargetLumMaxMult = new UInt32();
			HDRTargetLumMaxAdd = new UInt32();
			HDRSunlightScaleMult = new UInt32();
			HDRSunlightScaleAdd = new UInt32();
			HDRSkyScaleMult = new UInt32();
			HDRSkyScaleAdd = new UInt32();
			Unknown1 = new byte[72];
			CinematicSaturationMult = new UInt32();
			CinematicSaturationAdd = new UInt32();
			CinematicBrightnessMult = new UInt32();
			CinematicBrightnessAdd = new UInt32();
			CinematicContrastMult = new UInt32();
			CinematicContrastAdd = new UInt32();
			Unknown2 = new byte[8];
			TintColor = new Color();
			BlurRadius = new UInt32();
			DoubleVisionStrength = new UInt32();
			RadialBlurStrength = new UInt32();
			RadialBlurRampUp = new UInt32();
			RadialBlurStart = new UInt32();
			RadialBlurUseTarget = new NoYes();
			RadialBlurCenterX = new UInt32();
			RadialBlurCenterY = new UInt32();
			DepthOfFieldStrength = new UInt32();
			DepthOfFieldDistance = new UInt32();
			DepthOfFieldRange = new UInt32();
			DepthOfFieldUseTarget = new NoYes();
			RadialBlurRampDown = new UInt32();
			RadialBlurDownStart = new UInt32();
			FadeColor = new Color();
			MotionBlurStrength = new NoYes();
		}

		public ImageSpaceAdapterData(NoYes IsAnimatable, Single Duration, UInt32 HDREyeAdaptSpeedMult, UInt32 HDREyeAdaptSpeedAdd, UInt32 HDRBloomBlurRadiusMult, UInt32 HDRBloomBlurRadiusAdd, UInt32 HDRBloomThresholdMult, UInt32 HDRBloomThresholdAdd, UInt32 HDRBloomScaleMult, UInt32 HDRBloomScaleAdd, UInt32 HDRTargetLumMinMult, UInt32 HDRTargetLumMinAdd, UInt32 HDRTargetLumMaxMult, UInt32 HDRTargetLumMaxAdd, UInt32 HDRSunlightScaleMult, UInt32 HDRSunlightScaleAdd, UInt32 HDRSkyScaleMult, UInt32 HDRSkyScaleAdd, Byte[] Unknown1, UInt32 CinematicSaturationMult, UInt32 CinematicSaturationAdd, UInt32 CinematicBrightnessMult, UInt32 CinematicBrightnessAdd, UInt32 CinematicContrastMult, UInt32 CinematicContrastAdd, Byte[] Unknown2, Color TintColor, UInt32 BlurRadius, UInt32 DoubleVisionStrength, UInt32 RadialBlurStrength, UInt32 RadialBlurRampUp, UInt32 RadialBlurStart, NoYes RadialBlurUseTarget, UInt32 RadialBlurCenterX, UInt32 RadialBlurCenterY, UInt32 DepthOfFieldStrength, UInt32 DepthOfFieldDistance, UInt32 DepthOfFieldRange, NoYes DepthOfFieldUseTarget, UInt32 RadialBlurRampDown, UInt32 RadialBlurDownStart, Color FadeColor, NoYes MotionBlurStrength)
		{
			this.IsAnimatable = IsAnimatable;
			this.Duration = Duration;
			this.HDREyeAdaptSpeedMult = HDREyeAdaptSpeedMult;
			this.HDREyeAdaptSpeedAdd = HDREyeAdaptSpeedAdd;
			this.HDRBloomBlurRadiusMult = HDRBloomBlurRadiusMult;
			this.HDRBloomBlurRadiusAdd = HDRBloomBlurRadiusAdd;
			this.HDRBloomThresholdMult = HDRBloomThresholdMult;
			this.HDRBloomThresholdAdd = HDRBloomThresholdAdd;
			this.HDRBloomScaleMult = HDRBloomScaleMult;
			this.HDRBloomScaleAdd = HDRBloomScaleAdd;
			this.HDRTargetLumMinMult = HDRTargetLumMinMult;
			this.HDRTargetLumMinAdd = HDRTargetLumMinAdd;
			this.HDRTargetLumMaxMult = HDRTargetLumMaxMult;
			this.HDRTargetLumMaxAdd = HDRTargetLumMaxAdd;
			this.HDRSunlightScaleMult = HDRSunlightScaleMult;
			this.HDRSunlightScaleAdd = HDRSunlightScaleAdd;
			this.HDRSkyScaleMult = HDRSkyScaleMult;
			this.HDRSkyScaleAdd = HDRSkyScaleAdd;
			this.Unknown1 = Unknown1;
			this.CinematicSaturationMult = CinematicSaturationMult;
			this.CinematicSaturationAdd = CinematicSaturationAdd;
			this.CinematicBrightnessMult = CinematicBrightnessMult;
			this.CinematicBrightnessAdd = CinematicBrightnessAdd;
			this.CinematicContrastMult = CinematicContrastMult;
			this.CinematicContrastAdd = CinematicContrastAdd;
			this.Unknown2 = Unknown2;
			this.TintColor = TintColor;
			this.BlurRadius = BlurRadius;
			this.DoubleVisionStrength = DoubleVisionStrength;
			this.RadialBlurStrength = RadialBlurStrength;
			this.RadialBlurRampUp = RadialBlurRampUp;
			this.RadialBlurStart = RadialBlurStart;
			this.RadialBlurUseTarget = RadialBlurUseTarget;
			this.RadialBlurCenterX = RadialBlurCenterX;
			this.RadialBlurCenterY = RadialBlurCenterY;
			this.DepthOfFieldStrength = DepthOfFieldStrength;
			this.DepthOfFieldDistance = DepthOfFieldDistance;
			this.DepthOfFieldRange = DepthOfFieldRange;
			this.DepthOfFieldUseTarget = DepthOfFieldUseTarget;
			this.RadialBlurRampDown = RadialBlurRampDown;
			this.RadialBlurDownStart = RadialBlurDownStart;
			this.FadeColor = FadeColor;
			this.MotionBlurStrength = MotionBlurStrength;
		}

		public ImageSpaceAdapterData(ImageSpaceAdapterData copyObject)
		{
			IsAnimatable = copyObject.IsAnimatable;
			Duration = copyObject.Duration;
			HDREyeAdaptSpeedMult = copyObject.HDREyeAdaptSpeedMult;
			HDREyeAdaptSpeedAdd = copyObject.HDREyeAdaptSpeedAdd;
			HDRBloomBlurRadiusMult = copyObject.HDRBloomBlurRadiusMult;
			HDRBloomBlurRadiusAdd = copyObject.HDRBloomBlurRadiusAdd;
			HDRBloomThresholdMult = copyObject.HDRBloomThresholdMult;
			HDRBloomThresholdAdd = copyObject.HDRBloomThresholdAdd;
			HDRBloomScaleMult = copyObject.HDRBloomScaleMult;
			HDRBloomScaleAdd = copyObject.HDRBloomScaleAdd;
			HDRTargetLumMinMult = copyObject.HDRTargetLumMinMult;
			HDRTargetLumMinAdd = copyObject.HDRTargetLumMinAdd;
			HDRTargetLumMaxMult = copyObject.HDRTargetLumMaxMult;
			HDRTargetLumMaxAdd = copyObject.HDRTargetLumMaxAdd;
			HDRSunlightScaleMult = copyObject.HDRSunlightScaleMult;
			HDRSunlightScaleAdd = copyObject.HDRSunlightScaleAdd;
			HDRSkyScaleMult = copyObject.HDRSkyScaleMult;
			HDRSkyScaleAdd = copyObject.HDRSkyScaleAdd;
			Unknown1 = (Byte[])copyObject.Unknown1.Clone();
			CinematicSaturationMult = copyObject.CinematicSaturationMult;
			CinematicSaturationAdd = copyObject.CinematicSaturationAdd;
			CinematicBrightnessMult = copyObject.CinematicBrightnessMult;
			CinematicBrightnessAdd = copyObject.CinematicBrightnessAdd;
			CinematicContrastMult = copyObject.CinematicContrastMult;
			CinematicContrastAdd = copyObject.CinematicContrastAdd;
			Unknown2 = (Byte[])copyObject.Unknown2.Clone();
			TintColor = copyObject.TintColor.Clone();
			BlurRadius = copyObject.BlurRadius;
			DoubleVisionStrength = copyObject.DoubleVisionStrength;
			RadialBlurStrength = copyObject.RadialBlurStrength;
			RadialBlurRampUp = copyObject.RadialBlurRampUp;
			RadialBlurStart = copyObject.RadialBlurStart;
			RadialBlurUseTarget = copyObject.RadialBlurUseTarget;
			RadialBlurCenterX = copyObject.RadialBlurCenterX;
			RadialBlurCenterY = copyObject.RadialBlurCenterY;
			DepthOfFieldStrength = copyObject.DepthOfFieldStrength;
			DepthOfFieldDistance = copyObject.DepthOfFieldDistance;
			DepthOfFieldRange = copyObject.DepthOfFieldRange;
			DepthOfFieldUseTarget = copyObject.DepthOfFieldUseTarget;
			RadialBlurRampDown = copyObject.RadialBlurRampDown;
			RadialBlurDownStart = copyObject.RadialBlurDownStart;
			FadeColor = copyObject.FadeColor.Clone();
			MotionBlurStrength = copyObject.MotionBlurStrength;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					IsAnimatable = subReader.ReadEnum<NoYes>();
					Duration = subReader.ReadSingle();
					HDREyeAdaptSpeedMult = subReader.ReadUInt32();
					HDREyeAdaptSpeedAdd = subReader.ReadUInt32();
					HDRBloomBlurRadiusMult = subReader.ReadUInt32();
					HDRBloomBlurRadiusAdd = subReader.ReadUInt32();
					HDRBloomThresholdMult = subReader.ReadUInt32();
					HDRBloomThresholdAdd = subReader.ReadUInt32();
					HDRBloomScaleMult = subReader.ReadUInt32();
					HDRBloomScaleAdd = subReader.ReadUInt32();
					HDRTargetLumMinMult = subReader.ReadUInt32();
					HDRTargetLumMinAdd = subReader.ReadUInt32();
					HDRTargetLumMaxMult = subReader.ReadUInt32();
					HDRTargetLumMaxAdd = subReader.ReadUInt32();
					HDRSunlightScaleMult = subReader.ReadUInt32();
					HDRSunlightScaleAdd = subReader.ReadUInt32();
					HDRSkyScaleMult = subReader.ReadUInt32();
					HDRSkyScaleAdd = subReader.ReadUInt32();
					Unknown1 = subReader.ReadBytes(72);
					CinematicSaturationMult = subReader.ReadUInt32();
					CinematicSaturationAdd = subReader.ReadUInt32();
					CinematicBrightnessMult = subReader.ReadUInt32();
					CinematicBrightnessAdd = subReader.ReadUInt32();
					CinematicContrastMult = subReader.ReadUInt32();
					CinematicContrastAdd = subReader.ReadUInt32();
					Unknown2 = subReader.ReadBytes(8);
					TintColor.ReadBinary(subReader);
					BlurRadius = subReader.ReadUInt32();
					DoubleVisionStrength = subReader.ReadUInt32();
					RadialBlurStrength = subReader.ReadUInt32();
					RadialBlurRampUp = subReader.ReadUInt32();
					RadialBlurStart = subReader.ReadUInt32();
					RadialBlurUseTarget = subReader.ReadEnum<NoYes>();
					RadialBlurCenterX = subReader.ReadUInt32();
					RadialBlurCenterY = subReader.ReadUInt32();
					DepthOfFieldStrength = subReader.ReadUInt32();
					DepthOfFieldDistance = subReader.ReadUInt32();
					DepthOfFieldRange = subReader.ReadUInt32();
					DepthOfFieldUseTarget = subReader.ReadEnum<NoYes>();
					RadialBlurRampDown = subReader.ReadUInt32();
					RadialBlurDownStart = subReader.ReadUInt32();
					FadeColor.ReadBinary(subReader);
					MotionBlurStrength = subReader.ReadEnum<NoYes>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)IsAnimatable);
			writer.Write(Duration);			
			writer.Write(HDREyeAdaptSpeedMult);			
			writer.Write(HDREyeAdaptSpeedAdd);			
			writer.Write(HDRBloomBlurRadiusMult);			
			writer.Write(HDRBloomBlurRadiusAdd);			
			writer.Write(HDRBloomThresholdMult);			
			writer.Write(HDRBloomThresholdAdd);			
			writer.Write(HDRBloomScaleMult);			
			writer.Write(HDRBloomScaleAdd);			
			writer.Write(HDRTargetLumMinMult);			
			writer.Write(HDRTargetLumMinAdd);			
			writer.Write(HDRTargetLumMaxMult);			
			writer.Write(HDRTargetLumMaxAdd);			
			writer.Write(HDRSunlightScaleMult);			
			writer.Write(HDRSunlightScaleAdd);			
			writer.Write(HDRSkyScaleMult);			
			writer.Write(HDRSkyScaleAdd);			
			if (Unknown1 == null)
				writer.Write(new byte[72]);
			else
				writer.Write(Unknown1);
			writer.Write(CinematicSaturationMult);			
			writer.Write(CinematicSaturationAdd);			
			writer.Write(CinematicBrightnessMult);			
			writer.Write(CinematicBrightnessAdd);			
			writer.Write(CinematicContrastMult);			
			writer.Write(CinematicContrastAdd);			
			if (Unknown2 == null)
				writer.Write(new byte[8]);
			else
				writer.Write(Unknown2);
			TintColor.WriteBinary(writer);
			writer.Write(BlurRadius);			
			writer.Write(DoubleVisionStrength);			
			writer.Write(RadialBlurStrength);			
			writer.Write(RadialBlurRampUp);			
			writer.Write(RadialBlurStart);			
			writer.Write((UInt32)RadialBlurUseTarget);
			writer.Write(RadialBlurCenterX);			
			writer.Write(RadialBlurCenterY);			
			writer.Write(DepthOfFieldStrength);			
			writer.Write(DepthOfFieldDistance);			
			writer.Write(DepthOfFieldRange);			
			writer.Write((UInt32)DepthOfFieldUseTarget);
			writer.Write(RadialBlurRampDown);			
			writer.Write(RadialBlurDownStart);			
			FadeColor.WriteBinary(writer);
			writer.Write((UInt32)MotionBlurStrength);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("IsAnimatable", true, out subEle);
			subEle.Value = IsAnimatable.ToString();

			ele.TryPathTo("Duration", true, out subEle);
			subEle.Value = Duration.ToString("G15");

			ele.TryPathTo("HDR/EyeAdaptSpeed/Mult", true, out subEle);
			subEle.Value = HDREyeAdaptSpeedMult.ToString();

			ele.TryPathTo("HDR/EyeAdaptSpeed/Add", true, out subEle);
			subEle.Value = HDREyeAdaptSpeedAdd.ToString();

			ele.TryPathTo("HDR/Bloom/BlurRadius/Mult", true, out subEle);
			subEle.Value = HDRBloomBlurRadiusMult.ToString();

			ele.TryPathTo("HDR/Bloom/BlurRadius/Add", true, out subEle);
			subEle.Value = HDRBloomBlurRadiusAdd.ToString();

			ele.TryPathTo("HDR/Bloom/Threshold/Mult", true, out subEle);
			subEle.Value = HDRBloomThresholdMult.ToString();

			ele.TryPathTo("HDR/Bloom/Threshold/Add", true, out subEle);
			subEle.Value = HDRBloomThresholdAdd.ToString();

			ele.TryPathTo("HDR/Bloom/Scale/Mult", true, out subEle);
			subEle.Value = HDRBloomScaleMult.ToString();

			ele.TryPathTo("HDR/Bloom/Scale/Add", true, out subEle);
			subEle.Value = HDRBloomScaleAdd.ToString();

			ele.TryPathTo("HDR/TargetLum/Min/Mult", true, out subEle);
			subEle.Value = HDRTargetLumMinMult.ToString();

			ele.TryPathTo("HDR/TargetLum/Min/Add", true, out subEle);
			subEle.Value = HDRTargetLumMinAdd.ToString();

			ele.TryPathTo("HDR/TargetLum/Max/Mult", true, out subEle);
			subEle.Value = HDRTargetLumMaxMult.ToString();

			ele.TryPathTo("HDR/TargetLum/Max/Add", true, out subEle);
			subEle.Value = HDRTargetLumMaxAdd.ToString();

			ele.TryPathTo("HDR/SunlightScale/Mult", true, out subEle);
			subEle.Value = HDRSunlightScaleMult.ToString();

			ele.TryPathTo("HDR/SunlightScale/Add", true, out subEle);
			subEle.Value = HDRSunlightScaleAdd.ToString();

			ele.TryPathTo("HDR/SkyScale/Mult", true, out subEle);
			subEle.Value = HDRSkyScaleMult.ToString();

			ele.TryPathTo("HDR/SkyScale/Add", true, out subEle);
			subEle.Value = HDRSkyScaleAdd.ToString();

			ele.TryPathTo("Unknown1", true, out subEle);
			subEle.Value = Unknown1.ToHex();

			ele.TryPathTo("Cinematic/Saturation/Mult", true, out subEle);
			subEle.Value = CinematicSaturationMult.ToString();

			ele.TryPathTo("Cinematic/Saturation/Add", true, out subEle);
			subEle.Value = CinematicSaturationAdd.ToString();

			ele.TryPathTo("Cinematic/Brightness/Mult", true, out subEle);
			subEle.Value = CinematicBrightnessMult.ToString();

			ele.TryPathTo("Cinematic/Brightness/Add", true, out subEle);
			subEle.Value = CinematicBrightnessAdd.ToString();

			ele.TryPathTo("Cinematic/Contrast/Mult", true, out subEle);
			subEle.Value = CinematicContrastMult.ToString();

			ele.TryPathTo("Cinematic/Contrast/Add", true, out subEle);
			subEle.Value = CinematicContrastAdd.ToString();

			ele.TryPathTo("Unknown2", true, out subEle);
			subEle.Value = Unknown2.ToHex();

			ele.TryPathTo("TintColor", true, out subEle);
			TintColor.WriteXML(subEle, master);

			ele.TryPathTo("BlurRadius", true, out subEle);
			subEle.Value = BlurRadius.ToString();

			ele.TryPathTo("DoubleVisionStrength", true, out subEle);
			subEle.Value = DoubleVisionStrength.ToString();

			ele.TryPathTo("RadialBlur/Strength", true, out subEle);
			subEle.Value = RadialBlurStrength.ToString();

			ele.TryPathTo("RadialBlur/RampUp", true, out subEle);
			subEle.Value = RadialBlurRampUp.ToString();

			ele.TryPathTo("RadialBlur/Start", true, out subEle);
			subEle.Value = RadialBlurStart.ToString();

			ele.TryPathTo("RadialBlur/UseTarget", true, out subEle);
			subEle.Value = RadialBlurUseTarget.ToString();

			ele.TryPathTo("RadialBlur/Center/X", true, out subEle);
			subEle.Value = RadialBlurCenterX.ToString();

			ele.TryPathTo("RadialBlur/Center/Y", true, out subEle);
			subEle.Value = RadialBlurCenterY.ToString();

			ele.TryPathTo("DepthOfField/Strength", true, out subEle);
			subEle.Value = DepthOfFieldStrength.ToString();

			ele.TryPathTo("DepthOfField/Distance", true, out subEle);
			subEle.Value = DepthOfFieldDistance.ToString();

			ele.TryPathTo("DepthOfField/Range", true, out subEle);
			subEle.Value = DepthOfFieldRange.ToString();

			ele.TryPathTo("DepthOfField/UseTarget", true, out subEle);
			subEle.Value = DepthOfFieldUseTarget.ToString();

			ele.TryPathTo("RadialBlur/RampDown", true, out subEle);
			subEle.Value = RadialBlurRampDown.ToString();

			ele.TryPathTo("RadialBlur/DownStart", true, out subEle);
			subEle.Value = RadialBlurDownStart.ToString();

			ele.TryPathTo("FadeColor", true, out subEle);
			FadeColor.WriteXML(subEle, master);

			ele.TryPathTo("MotionBlurStrength", true, out subEle);
			subEle.Value = MotionBlurStrength.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("IsAnimatable", false, out subEle))
			{
				IsAnimatable = subEle.ToEnum<NoYes>();
			}

			if (ele.TryPathTo("Duration", false, out subEle))
			{
				Duration = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/EyeAdaptSpeed/Mult", false, out subEle))
			{
				HDREyeAdaptSpeedMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/EyeAdaptSpeed/Add", false, out subEle))
			{
				HDREyeAdaptSpeedAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/BlurRadius/Mult", false, out subEle))
			{
				HDRBloomBlurRadiusMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/BlurRadius/Add", false, out subEle))
			{
				HDRBloomBlurRadiusAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/Threshold/Mult", false, out subEle))
			{
				HDRBloomThresholdMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/Threshold/Add", false, out subEle))
			{
				HDRBloomThresholdAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/Scale/Mult", false, out subEle))
			{
				HDRBloomScaleMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/Bloom/Scale/Add", false, out subEle))
			{
				HDRBloomScaleAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/TargetLum/Min/Mult", false, out subEle))
			{
				HDRTargetLumMinMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/TargetLum/Min/Add", false, out subEle))
			{
				HDRTargetLumMinAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/TargetLum/Max/Mult", false, out subEle))
			{
				HDRTargetLumMaxMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/TargetLum/Max/Add", false, out subEle))
			{
				HDRTargetLumMaxAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/SunlightScale/Mult", false, out subEle))
			{
				HDRSunlightScaleMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/SunlightScale/Add", false, out subEle))
			{
				HDRSunlightScaleAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/SkyScale/Mult", false, out subEle))
			{
				HDRSkyScaleMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("HDR/SkyScale/Add", false, out subEle))
			{
				HDRSkyScaleAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				Unknown1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Cinematic/Saturation/Mult", false, out subEle))
			{
				CinematicSaturationMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Cinematic/Saturation/Add", false, out subEle))
			{
				CinematicSaturationAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Cinematic/Brightness/Mult", false, out subEle))
			{
				CinematicBrightnessMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Cinematic/Brightness/Add", false, out subEle))
			{
				CinematicBrightnessAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Cinematic/Contrast/Mult", false, out subEle))
			{
				CinematicContrastMult = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Cinematic/Contrast/Add", false, out subEle))
			{
				CinematicContrastAdd = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				Unknown2 = subEle.ToBytes();
			}

			if (ele.TryPathTo("TintColor", false, out subEle))
			{
				TintColor.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("BlurRadius", false, out subEle))
			{
				BlurRadius = subEle.ToUInt32();
			}

			if (ele.TryPathTo("DoubleVisionStrength", false, out subEle))
			{
				DoubleVisionStrength = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/Strength", false, out subEle))
			{
				RadialBlurStrength = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/RampUp", false, out subEle))
			{
				RadialBlurRampUp = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/Start", false, out subEle))
			{
				RadialBlurStart = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/UseTarget", false, out subEle))
			{
				RadialBlurUseTarget = subEle.ToEnum<NoYes>();
			}

			if (ele.TryPathTo("RadialBlur/Center/X", false, out subEle))
			{
				RadialBlurCenterX = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/Center/Y", false, out subEle))
			{
				RadialBlurCenterY = subEle.ToUInt32();
			}

			if (ele.TryPathTo("DepthOfField/Strength", false, out subEle))
			{
				DepthOfFieldStrength = subEle.ToUInt32();
			}

			if (ele.TryPathTo("DepthOfField/Distance", false, out subEle))
			{
				DepthOfFieldDistance = subEle.ToUInt32();
			}

			if (ele.TryPathTo("DepthOfField/Range", false, out subEle))
			{
				DepthOfFieldRange = subEle.ToUInt32();
			}

			if (ele.TryPathTo("DepthOfField/UseTarget", false, out subEle))
			{
				DepthOfFieldUseTarget = subEle.ToEnum<NoYes>();
			}

			if (ele.TryPathTo("RadialBlur/RampDown", false, out subEle))
			{
				RadialBlurRampDown = subEle.ToUInt32();
			}

			if (ele.TryPathTo("RadialBlur/DownStart", false, out subEle))
			{
				RadialBlurDownStart = subEle.ToUInt32();
			}

			if (ele.TryPathTo("FadeColor", false, out subEle))
			{
				FadeColor.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("MotionBlurStrength", false, out subEle))
			{
				MotionBlurStrength = subEle.ToEnum<NoYes>();
			}
		}

		public ImageSpaceAdapterData Clone()
		{
			return new ImageSpaceAdapterData(this);
		}

	}
}
