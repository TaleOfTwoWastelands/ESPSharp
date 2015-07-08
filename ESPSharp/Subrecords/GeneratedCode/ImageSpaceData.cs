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
	public partial class ImageSpaceData : Subrecord, ICloneable<ImageSpaceData>
	{
		public Single HDREyeAdaptSpeed { get; set; }
		public Single HDRBlurRadius { get; set; }
		public Single HDRBlurPasses { get; set; }
		public Single HDREmissiveMult { get; set; }
		public Single HDRLUMTarget { get; set; }
		public Single HDRLUMUpperClamp { get; set; }
		public Single HDRBrightScale { get; set; }
		public Single HDRBrightClamp { get; set; }
		public Single HDRLUMRampNoTex { get; set; }
		public Single HDRLUMRampMin { get; set; }
		public Single HDRLUMRampMax { get; set; }
		public Single HDRSunlightDimmer { get; set; }
		public Single HDRGrassDimmer { get; set; }
		public Single HDRTreeDimmer { get; set; }
		public Single HDRSkinDimmer { get; set; }
		public Single BloomBlurRadius { get; set; }
		public Single BloomAlphaMultInterior { get; set; }
		public Single BloomAlphaMultExterior { get; set; }
		public Single GetHitBlurRadius { get; set; }
		public Single GetHitBlurDampingConstant { get; set; }
		public Single NightEyeTintColorRed { get; set; }
		public Single NightEyeTintColorGreen { get; set; }
		public Single NightEyeTintColorBlue { get; set; }
		public Single Brightness { get; set; }
		public Single CinematicSaturation { get; set; }
		public Single CinematicContrastAvgLUMValue { get; set; }
		public Single CinematicContrastValue { get; set; }
		public Single CinematicBrightnessTintColorRed { get; set; }
		public Single CinematicBrightnessTintColorGreen { get; set; }
		public Single CinematicBrightnessTintColorBlue { get; set; }
		public Single CinematicBrightnessTintValue { get; set; }
		public Byte[] Unused1 { get; set; }
		public ImageSpaceFlags Flags { get; set; }
		public Byte[] Unused2 { get; set; }

		public ImageSpaceData()
		{
			HDREyeAdaptSpeed = new Single();
			HDRBlurRadius = new Single();
			HDRBlurPasses = new Single();
			HDREmissiveMult = new Single();
			HDRLUMTarget = new Single();
			HDRLUMUpperClamp = new Single();
			HDRBrightScale = new Single();
			HDRBrightClamp = new Single();
			HDRLUMRampNoTex = new Single();
			HDRLUMRampMin = new Single();
			HDRLUMRampMax = new Single();
			HDRSunlightDimmer = new Single();
			HDRGrassDimmer = new Single();
			HDRTreeDimmer = new Single();
			HDRSkinDimmer = new Single();
			BloomBlurRadius = new Single();
			BloomAlphaMultInterior = new Single();
			BloomAlphaMultExterior = new Single();
			GetHitBlurRadius = new Single();
			GetHitBlurDampingConstant = new Single();
			NightEyeTintColorRed = new Single();
			NightEyeTintColorGreen = new Single();
			NightEyeTintColorBlue = new Single();
			Brightness = new Single();
			CinematicSaturation = new Single();
			CinematicContrastAvgLUMValue = new Single();
			CinematicContrastValue = new Single();
			CinematicBrightnessTintColorRed = new Single();
			CinematicBrightnessTintColorGreen = new Single();
			CinematicBrightnessTintColorBlue = new Single();
			CinematicBrightnessTintValue = new Single();
			Unused1 = new byte[16];
			Flags = new ImageSpaceFlags();
			Unused2 = new byte[3];
		}

		public ImageSpaceData(Single HDREyeAdaptSpeed, Single HDRBlurRadius, Single HDRBlurPasses, Single HDREmissiveMult, Single HDRLUMTarget, Single HDRLUMUpperClamp, Single HDRBrightScale, Single HDRBrightClamp, Single HDRLUMRampNoTex, Single HDRLUMRampMin, Single HDRLUMRampMax, Single HDRSunlightDimmer, Single HDRGrassDimmer, Single HDRTreeDimmer, Single HDRSkinDimmer, Single BloomBlurRadius, Single BloomAlphaMultInterior, Single BloomAlphaMultExterior, Single GetHitBlurRadius, Single GetHitBlurDampingConstant, Single NightEyeTintColorRed, Single NightEyeTintColorGreen, Single NightEyeTintColorBlue, Single Brightness, Single CinematicSaturation, Single CinematicContrastAvgLUMValue, Single CinematicContrastValue, Single CinematicBrightnessTintColorRed, Single CinematicBrightnessTintColorGreen, Single CinematicBrightnessTintColorBlue, Single CinematicBrightnessTintValue, Byte[] Unused1, ImageSpaceFlags Flags, Byte[] Unused2)
		{
			this.HDREyeAdaptSpeed = HDREyeAdaptSpeed;
			this.HDRBlurRadius = HDRBlurRadius;
			this.HDRBlurPasses = HDRBlurPasses;
			this.HDREmissiveMult = HDREmissiveMult;
			this.HDRLUMTarget = HDRLUMTarget;
			this.HDRLUMUpperClamp = HDRLUMUpperClamp;
			this.HDRBrightScale = HDRBrightScale;
			this.HDRBrightClamp = HDRBrightClamp;
			this.HDRLUMRampNoTex = HDRLUMRampNoTex;
			this.HDRLUMRampMin = HDRLUMRampMin;
			this.HDRLUMRampMax = HDRLUMRampMax;
			this.HDRSunlightDimmer = HDRSunlightDimmer;
			this.HDRGrassDimmer = HDRGrassDimmer;
			this.HDRTreeDimmer = HDRTreeDimmer;
			this.HDRSkinDimmer = HDRSkinDimmer;
			this.BloomBlurRadius = BloomBlurRadius;
			this.BloomAlphaMultInterior = BloomAlphaMultInterior;
			this.BloomAlphaMultExterior = BloomAlphaMultExterior;
			this.GetHitBlurRadius = GetHitBlurRadius;
			this.GetHitBlurDampingConstant = GetHitBlurDampingConstant;
			this.NightEyeTintColorRed = NightEyeTintColorRed;
			this.NightEyeTintColorGreen = NightEyeTintColorGreen;
			this.NightEyeTintColorBlue = NightEyeTintColorBlue;
			this.Brightness = Brightness;
			this.CinematicSaturation = CinematicSaturation;
			this.CinematicContrastAvgLUMValue = CinematicContrastAvgLUMValue;
			this.CinematicContrastValue = CinematicContrastValue;
			this.CinematicBrightnessTintColorRed = CinematicBrightnessTintColorRed;
			this.CinematicBrightnessTintColorGreen = CinematicBrightnessTintColorGreen;
			this.CinematicBrightnessTintColorBlue = CinematicBrightnessTintColorBlue;
			this.CinematicBrightnessTintValue = CinematicBrightnessTintValue;
			this.Unused1 = Unused1;
			this.Flags = Flags;
			this.Unused2 = Unused2;
		}

		public ImageSpaceData(ImageSpaceData copyObject)
		{
			HDREyeAdaptSpeed = copyObject.HDREyeAdaptSpeed;
			HDRBlurRadius = copyObject.HDRBlurRadius;
			HDRBlurPasses = copyObject.HDRBlurPasses;
			HDREmissiveMult = copyObject.HDREmissiveMult;
			HDRLUMTarget = copyObject.HDRLUMTarget;
			HDRLUMUpperClamp = copyObject.HDRLUMUpperClamp;
			HDRBrightScale = copyObject.HDRBrightScale;
			HDRBrightClamp = copyObject.HDRBrightClamp;
			HDRLUMRampNoTex = copyObject.HDRLUMRampNoTex;
			HDRLUMRampMin = copyObject.HDRLUMRampMin;
			HDRLUMRampMax = copyObject.HDRLUMRampMax;
			HDRSunlightDimmer = copyObject.HDRSunlightDimmer;
			HDRGrassDimmer = copyObject.HDRGrassDimmer;
			HDRTreeDimmer = copyObject.HDRTreeDimmer;
			HDRSkinDimmer = copyObject.HDRSkinDimmer;
			BloomBlurRadius = copyObject.BloomBlurRadius;
			BloomAlphaMultInterior = copyObject.BloomAlphaMultInterior;
			BloomAlphaMultExterior = copyObject.BloomAlphaMultExterior;
			GetHitBlurRadius = copyObject.GetHitBlurRadius;
			GetHitBlurDampingConstant = copyObject.GetHitBlurDampingConstant;
			NightEyeTintColorRed = copyObject.NightEyeTintColorRed;
			NightEyeTintColorGreen = copyObject.NightEyeTintColorGreen;
			NightEyeTintColorBlue = copyObject.NightEyeTintColorBlue;
			Brightness = copyObject.Brightness;
			CinematicSaturation = copyObject.CinematicSaturation;
			CinematicContrastAvgLUMValue = copyObject.CinematicContrastAvgLUMValue;
			CinematicContrastValue = copyObject.CinematicContrastValue;
			CinematicBrightnessTintColorRed = copyObject.CinematicBrightnessTintColorRed;
			CinematicBrightnessTintColorGreen = copyObject.CinematicBrightnessTintColorGreen;
			CinematicBrightnessTintColorBlue = copyObject.CinematicBrightnessTintColorBlue;
			CinematicBrightnessTintValue = copyObject.CinematicBrightnessTintValue;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			Flags = copyObject.Flags;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					HDREyeAdaptSpeed = subReader.ReadSingle();
					HDRBlurRadius = subReader.ReadSingle();
					HDRBlurPasses = subReader.ReadSingle();
					HDREmissiveMult = subReader.ReadSingle();
					HDRLUMTarget = subReader.ReadSingle();
					HDRLUMUpperClamp = subReader.ReadSingle();
					HDRBrightScale = subReader.ReadSingle();
					HDRBrightClamp = subReader.ReadSingle();
					HDRLUMRampNoTex = subReader.ReadSingle();
					HDRLUMRampMin = subReader.ReadSingle();
					HDRLUMRampMax = subReader.ReadSingle();
					HDRSunlightDimmer = subReader.ReadSingle();
					HDRGrassDimmer = subReader.ReadSingle();
					HDRTreeDimmer = subReader.ReadSingle();
					HDRSkinDimmer = subReader.ReadSingle();
					BloomBlurRadius = subReader.ReadSingle();
					BloomAlphaMultInterior = subReader.ReadSingle();
					BloomAlphaMultExterior = subReader.ReadSingle();
					GetHitBlurRadius = subReader.ReadSingle();
					GetHitBlurDampingConstant = subReader.ReadSingle();
					NightEyeTintColorRed = subReader.ReadSingle();
					NightEyeTintColorGreen = subReader.ReadSingle();
					NightEyeTintColorBlue = subReader.ReadSingle();
					Brightness = subReader.ReadSingle();
					CinematicSaturation = subReader.ReadSingle();
					CinematicContrastAvgLUMValue = subReader.ReadSingle();
					CinematicContrastValue = subReader.ReadSingle();
					CinematicBrightnessTintColorRed = subReader.ReadSingle();
					CinematicBrightnessTintColorGreen = subReader.ReadSingle();
					CinematicBrightnessTintColorBlue = subReader.ReadSingle();
					CinematicBrightnessTintValue = subReader.ReadSingle();
					Unused1 = subReader.ReadBytes(16);
					Flags = subReader.ReadEnum<ImageSpaceFlags>();
					Unused2 = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(HDREyeAdaptSpeed);			
			writer.Write(HDRBlurRadius);			
			writer.Write(HDRBlurPasses);			
			writer.Write(HDREmissiveMult);			
			writer.Write(HDRLUMTarget);			
			writer.Write(HDRLUMUpperClamp);			
			writer.Write(HDRBrightScale);			
			writer.Write(HDRBrightClamp);			
			writer.Write(HDRLUMRampNoTex);			
			writer.Write(HDRLUMRampMin);			
			writer.Write(HDRLUMRampMax);			
			writer.Write(HDRSunlightDimmer);			
			writer.Write(HDRGrassDimmer);			
			writer.Write(HDRTreeDimmer);			
			writer.Write(HDRSkinDimmer);			
			writer.Write(BloomBlurRadius);			
			writer.Write(BloomAlphaMultInterior);			
			writer.Write(BloomAlphaMultExterior);			
			writer.Write(GetHitBlurRadius);			
			writer.Write(GetHitBlurDampingConstant);			
			writer.Write(NightEyeTintColorRed);			
			writer.Write(NightEyeTintColorGreen);			
			writer.Write(NightEyeTintColorBlue);			
			writer.Write(Brightness);			
			writer.Write(CinematicSaturation);			
			writer.Write(CinematicContrastAvgLUMValue);			
			writer.Write(CinematicContrastValue);			
			writer.Write(CinematicBrightnessTintColorRed);			
			writer.Write(CinematicBrightnessTintColorGreen);			
			writer.Write(CinematicBrightnessTintColorBlue);			
			writer.Write(CinematicBrightnessTintValue);			
			if (Unused1 == null)
				writer.Write(new byte[16]);
			else
				writer.Write(Unused1);
			writer.Write((Byte)Flags);
			if (Unused2 == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("HDR/EyeAdaptSpeed", true, out subEle);
			subEle.Value = HDREyeAdaptSpeed.ToString("G15");

			ele.TryPathTo("HDR/Blur/Radius", true, out subEle);
			subEle.Value = HDRBlurRadius.ToString("G15");

			ele.TryPathTo("HDR/Blur/Passes", true, out subEle);
			subEle.Value = HDRBlurPasses.ToString("G15");

			ele.TryPathTo("HDR/EmissiveMult", true, out subEle);
			subEle.Value = HDREmissiveMult.ToString("G15");

			ele.TryPathTo("HDR/LUM/Target", true, out subEle);
			subEle.Value = HDRLUMTarget.ToString("G15");

			ele.TryPathTo("HDR/LUM/UpperClamp", true, out subEle);
			subEle.Value = HDRLUMUpperClamp.ToString("G15");

			ele.TryPathTo("HDR/Bright/Scale", true, out subEle);
			subEle.Value = HDRBrightScale.ToString("G15");

			ele.TryPathTo("HDR/Bright/Clamp", true, out subEle);
			subEle.Value = HDRBrightClamp.ToString("G15");

			ele.TryPathTo("HDR/LUM/RampNoTex", true, out subEle);
			subEle.Value = HDRLUMRampNoTex.ToString("G15");

			ele.TryPathTo("HDR/LUM/RampMin", true, out subEle);
			subEle.Value = HDRLUMRampMin.ToString("G15");

			ele.TryPathTo("HDR/LUM/RampMax", true, out subEle);
			subEle.Value = HDRLUMRampMax.ToString("G15");

			ele.TryPathTo("HDR/SunlightDimmer", true, out subEle);
			subEle.Value = HDRSunlightDimmer.ToString("G15");

			ele.TryPathTo("HDR/GrassDimmer", true, out subEle);
			subEle.Value = HDRGrassDimmer.ToString("G15");

			ele.TryPathTo("HDR/TreeDimmer", true, out subEle);
			subEle.Value = HDRTreeDimmer.ToString("G15");

			ele.TryPathTo("HDR/SkinDimmer", true, out subEle);
			subEle.Value = HDRSkinDimmer.ToString("G15");

			ele.TryPathTo("Bloom/BlurRadius", true, out subEle);
			subEle.Value = BloomBlurRadius.ToString("G15");

			ele.TryPathTo("Bloom/AlphaMult/Interior", true, out subEle);
			subEle.Value = BloomAlphaMultInterior.ToString("G15");

			ele.TryPathTo("Bloom/AlphaMult/Exterior", true, out subEle);
			subEle.Value = BloomAlphaMultExterior.ToString("G15");

			ele.TryPathTo("GetHit/Blur/Radius", true, out subEle);
			subEle.Value = GetHitBlurRadius.ToString("G15");

			ele.TryPathTo("GetHit/Blur/DampingConstant", true, out subEle);
			subEle.Value = GetHitBlurDampingConstant.ToString("G15");

			ele.TryPathTo("NightEyeTintColor/Red", true, out subEle);
			subEle.Value = NightEyeTintColorRed.ToString("G15");

			ele.TryPathTo("NightEyeTintColor/Green", true, out subEle);
			subEle.Value = NightEyeTintColorGreen.ToString("G15");

			ele.TryPathTo("NightEyeTintColor/Blue", true, out subEle);
			subEle.Value = NightEyeTintColorBlue.ToString("G15");

			ele.TryPathTo("Brightness", true, out subEle);
			subEle.Value = Brightness.ToString("G15");

			ele.TryPathTo("Cinematic/Saturation", true, out subEle);
			subEle.Value = CinematicSaturation.ToString("G15");

			ele.TryPathTo("Cinematic/Contrast/AvgLUMValue", true, out subEle);
			subEle.Value = CinematicContrastAvgLUMValue.ToString("G15");

			ele.TryPathTo("Cinematic/Contrast/Value", true, out subEle);
			subEle.Value = CinematicContrastValue.ToString("G15");

			ele.TryPathTo("Cinematic/BrightnessTint/Color/Red", true, out subEle);
			subEle.Value = CinematicBrightnessTintColorRed.ToString("G15");

			ele.TryPathTo("Cinematic/BrightnessTint/Color/Green", true, out subEle);
			subEle.Value = CinematicBrightnessTintColorGreen.ToString("G15");

			ele.TryPathTo("Cinematic/BrightnessTint/Color/Blue", true, out subEle);
			subEle.Value = CinematicBrightnessTintColorBlue.ToString("G15");

			ele.TryPathTo("Cinematic/BrightnessTint/Value", true, out subEle);
			subEle.Value = CinematicBrightnessTintValue.ToString("G15");

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("HDR/EyeAdaptSpeed", false, out subEle))
			{
				HDREyeAdaptSpeed = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/Blur/Radius", false, out subEle))
			{
				HDRBlurRadius = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/Blur/Passes", false, out subEle))
			{
				HDRBlurPasses = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/EmissiveMult", false, out subEle))
			{
				HDREmissiveMult = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/LUM/Target", false, out subEle))
			{
				HDRLUMTarget = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/LUM/UpperClamp", false, out subEle))
			{
				HDRLUMUpperClamp = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/Bright/Scale", false, out subEle))
			{
				HDRBrightScale = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/Bright/Clamp", false, out subEle))
			{
				HDRBrightClamp = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/LUM/RampNoTex", false, out subEle))
			{
				HDRLUMRampNoTex = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/LUM/RampMin", false, out subEle))
			{
				HDRLUMRampMin = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/LUM/RampMax", false, out subEle))
			{
				HDRLUMRampMax = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/SunlightDimmer", false, out subEle))
			{
				HDRSunlightDimmer = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/GrassDimmer", false, out subEle))
			{
				HDRGrassDimmer = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/TreeDimmer", false, out subEle))
			{
				HDRTreeDimmer = subEle.ToSingle();
			}

			if (ele.TryPathTo("HDR/SkinDimmer", false, out subEle))
			{
				HDRSkinDimmer = subEle.ToSingle();
			}

			if (ele.TryPathTo("Bloom/BlurRadius", false, out subEle))
			{
				BloomBlurRadius = subEle.ToSingle();
			}

			if (ele.TryPathTo("Bloom/AlphaMult/Interior", false, out subEle))
			{
				BloomAlphaMultInterior = subEle.ToSingle();
			}

			if (ele.TryPathTo("Bloom/AlphaMult/Exterior", false, out subEle))
			{
				BloomAlphaMultExterior = subEle.ToSingle();
			}

			if (ele.TryPathTo("GetHit/Blur/Radius", false, out subEle))
			{
				GetHitBlurRadius = subEle.ToSingle();
			}

			if (ele.TryPathTo("GetHit/Blur/DampingConstant", false, out subEle))
			{
				GetHitBlurDampingConstant = subEle.ToSingle();
			}

			if (ele.TryPathTo("NightEyeTintColor/Red", false, out subEle))
			{
				NightEyeTintColorRed = subEle.ToSingle();
			}

			if (ele.TryPathTo("NightEyeTintColor/Green", false, out subEle))
			{
				NightEyeTintColorGreen = subEle.ToSingle();
			}

			if (ele.TryPathTo("NightEyeTintColor/Blue", false, out subEle))
			{
				NightEyeTintColorBlue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Brightness", false, out subEle))
			{
				Brightness = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/Saturation", false, out subEle))
			{
				CinematicSaturation = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/Contrast/AvgLUMValue", false, out subEle))
			{
				CinematicContrastAvgLUMValue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/Contrast/Value", false, out subEle))
			{
				CinematicContrastValue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/BrightnessTint/Color/Red", false, out subEle))
			{
				CinematicBrightnessTintColorRed = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/BrightnessTint/Color/Green", false, out subEle))
			{
				CinematicBrightnessTintColorGreen = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/BrightnessTint/Color/Blue", false, out subEle))
			{
				CinematicBrightnessTintColorBlue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Cinematic/BrightnessTint/Value", false, out subEle))
			{
				CinematicBrightnessTintValue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<ImageSpaceFlags>();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}
		}

		public ImageSpaceData Clone()
		{
			return new ImageSpaceData(this);
		}

	}
}
