
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

namespace ESPSharp.Records
{
	public partial class ImageSpaceAdapter : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ImageSpaceAdapterData Data { get; set; }
		public IMADTimeValues BlurRadius { get; set; }
		public IMADTimeValues DoubleVisionStrength { get; set; }
		public IMADTimeColors TintColor { get; set; }
		public IMADTimeColors FadeColor { get; set; }
		public IMADTimeValues RadialBlurStrength { get; set; }
		public IMADTimeValues RadialBlurRampUp { get; set; }
		public IMADTimeValues RadialBlurStart { get; set; }
		public IMADTimeValues RadialBlurRampDown { get; set; }
		public IMADTimeValues RadialBlurDownStart { get; set; }
		public IMADTimeValues DoFStrength { get; set; }
		public IMADTimeValues DoFDistance { get; set; }
		public IMADTimeValues DoFRange { get; set; }
		public IMADTimeValues MotionBlurStrength { get; set; }
		public IMADTimeValues HDREyeAdaptSpeedMult { get; set; }
		public IMADTimeValues HDREyeAdaptSpeedAdd { get; set; }
		public IMADTimeValues HDRBloomBlurRadiusMult { get; set; }
		public IMADTimeValues HDRBloomBlurRadiusAdd { get; set; }
		public IMADTimeValues HDRBloomThresholdMult { get; set; }
		public IMADTimeValues HDRBloomThresholdAdd { get; set; }
		public IMADTimeValues HDRBloomScaleMult { get; set; }
		public IMADTimeValues HDRBloomScaleAdd { get; set; }
		public IMADTimeValues HDRTargetLUMMinMult { get; set; }
		public IMADTimeValues HDRTargetLUMMinAdd { get; set; }
		public IMADTimeValues HDRTargetLUMMaxMult { get; set; }
		public IMADTimeValues HDRTargetLUMMaxAdd { get; set; }
		public IMADTimeValues HDRSunlightScaleMult { get; set; }
		public IMADTimeValues HDRSunlightScaleAdd { get; set; }
		public IMADTimeValues HDRSkyScaleMult { get; set; }
		public IMADTimeValues HDRSkyScaleAdd { get; set; }
		public IMADTimeValues Unknown1 { get; set; }
		public IMADTimeValues Unknown2 { get; set; }
		public IMADTimeValues Unknown3 { get; set; }
		public IMADTimeValues Unknown4 { get; set; }
		public IMADTimeValues Unknown5 { get; set; }
		public IMADTimeValues Unknown6 { get; set; }
		public IMADTimeValues Unknown7 { get; set; }
		public IMADTimeValues Unknown8 { get; set; }
		public IMADTimeValues Unknown9 { get; set; }
		public IMADTimeValues Unknown10 { get; set; }
		public IMADTimeValues Unknown11 { get; set; }
		public IMADTimeValues Unknown12 { get; set; }
		public IMADTimeValues Unknown13 { get; set; }
		public IMADTimeValues Unknown14 { get; set; }
		public IMADTimeValues Unknown15 { get; set; }
		public IMADTimeValues Unknown16 { get; set; }
		public IMADTimeValues Unknown17 { get; set; }
		public IMADTimeValues Unknown18 { get; set; }
		public IMADTimeValues CinematicSaturationMult { get; set; }
		public IMADTimeValues CinematicSaturationAdd { get; set; }
		public IMADTimeValues CinematicBrightnessMult { get; set; }
		public IMADTimeValues CinematicBrightnessAdd { get; set; }
		public IMADTimeValues CinematicContrastMult { get; set; }
		public IMADTimeValues CinematicContrastAdd { get; set; }
		public IMADTimeValues Unknown19 { get; set; }
		public IMADTimeValues Unknown20 { get; set; }
		public RecordReference SoundIntro { get; set; }
		public RecordReference SoundOutro { get; set; }

		public ImageSpaceAdapter()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public ImageSpaceAdapter(SimpleSubrecord<String> EditorID, ImageSpaceAdapterData Data, IMADTimeValues BlurRadius, IMADTimeValues DoubleVisionStrength, IMADTimeColors TintColor, IMADTimeColors FadeColor, IMADTimeValues RadialBlurStrength, IMADTimeValues RadialBlurRampUp, IMADTimeValues RadialBlurStart, IMADTimeValues RadialBlurRampDown, IMADTimeValues RadialBlurDownStart, IMADTimeValues DoFStrength, IMADTimeValues DoFDistance, IMADTimeValues DoFRange, IMADTimeValues MotionBlurStrength, IMADTimeValues HDREyeAdaptSpeedMult, IMADTimeValues HDREyeAdaptSpeedAdd, IMADTimeValues HDRBloomBlurRadiusMult, IMADTimeValues HDRBloomBlurRadiusAdd, IMADTimeValues HDRBloomThresholdMult, IMADTimeValues HDRBloomThresholdAdd, IMADTimeValues HDRBloomScaleMult, IMADTimeValues HDRBloomScaleAdd, IMADTimeValues HDRTargetLUMMinMult, IMADTimeValues HDRTargetLUMMinAdd, IMADTimeValues HDRTargetLUMMaxMult, IMADTimeValues HDRTargetLUMMaxAdd, IMADTimeValues HDRSunlightScaleMult, IMADTimeValues HDRSunlightScaleAdd, IMADTimeValues HDRSkyScaleMult, IMADTimeValues HDRSkyScaleAdd, IMADTimeValues Unknown1, IMADTimeValues Unknown2, IMADTimeValues Unknown3, IMADTimeValues Unknown4, IMADTimeValues Unknown5, IMADTimeValues Unknown6, IMADTimeValues Unknown7, IMADTimeValues Unknown8, IMADTimeValues Unknown9, IMADTimeValues Unknown10, IMADTimeValues Unknown11, IMADTimeValues Unknown12, IMADTimeValues Unknown13, IMADTimeValues Unknown14, IMADTimeValues Unknown15, IMADTimeValues Unknown16, IMADTimeValues Unknown17, IMADTimeValues Unknown18, IMADTimeValues CinematicSaturationMult, IMADTimeValues CinematicSaturationAdd, IMADTimeValues CinematicBrightnessMult, IMADTimeValues CinematicBrightnessAdd, IMADTimeValues CinematicContrastMult, IMADTimeValues CinematicContrastAdd, IMADTimeValues Unknown19, IMADTimeValues Unknown20, RecordReference SoundIntro, RecordReference SoundOutro)
		{
			this.EditorID = EditorID;
		}

		public ImageSpaceAdapter(ImageSpaceAdapter copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "DNAM":
						if (Data == null)
							Data = new ImageSpaceAdapterData();

						Data.ReadBinary(reader);
						break;
					case "BNAM":
						if (BlurRadius == null)
							BlurRadius = new IMADTimeValues();

						BlurRadius.ReadBinary(reader);
						break;
					case "VNAM":
						if (DoubleVisionStrength == null)
							DoubleVisionStrength = new IMADTimeValues();

						DoubleVisionStrength.ReadBinary(reader);
						break;
					case "TNAM":
						if (TintColor == null)
							TintColor = new IMADTimeColors();

						TintColor.ReadBinary(reader);
						break;
					case "NAM3":
						if (FadeColor == null)
							FadeColor = new IMADTimeColors();

						FadeColor.ReadBinary(reader);
						break;
					case "RNAM":
						if (RadialBlurStrength == null)
							RadialBlurStrength = new IMADTimeValues();

						RadialBlurStrength.ReadBinary(reader);
						break;
					case "SNAM":
						if (RadialBlurRampUp == null)
							RadialBlurRampUp = new IMADTimeValues();

						RadialBlurRampUp.ReadBinary(reader);
						break;
					case "UNAM":
						if (RadialBlurStart == null)
							RadialBlurStart = new IMADTimeValues();

						RadialBlurStart.ReadBinary(reader);
						break;
					case "NAM1":
						if (RadialBlurRampDown == null)
							RadialBlurRampDown = new IMADTimeValues();

						RadialBlurRampDown.ReadBinary(reader);
						break;
					case "NAM2":
						if (RadialBlurDownStart == null)
							RadialBlurDownStart = new IMADTimeValues();

						RadialBlurDownStart.ReadBinary(reader);
						break;
					case "WNAM":
						if (DoFStrength == null)
							DoFStrength = new IMADTimeValues();

						DoFStrength.ReadBinary(reader);
						break;
					case "XNAM":
						if (DoFDistance == null)
							DoFDistance = new IMADTimeValues();

						DoFDistance.ReadBinary(reader);
						break;
					case "YNAM":
						if (DoFRange == null)
							DoFRange = new IMADTimeValues();

						DoFRange.ReadBinary(reader);
						break;
					case "NAM4":
						if (MotionBlurStrength == null)
							MotionBlurStrength = new IMADTimeValues();

						MotionBlurStrength.ReadBinary(reader);
						break;
					case "aIAD":
						if (HDREyeAdaptSpeedMult == null)
							HDREyeAdaptSpeedMult = new IMADTimeValues();

						HDREyeAdaptSpeedMult.ReadBinary(reader);
						break;
					case "zIAD":
						if (HDREyeAdaptSpeedAdd == null)
							HDREyeAdaptSpeedAdd = new IMADTimeValues();

						HDREyeAdaptSpeedAdd.ReadBinary(reader);
						break;
					case "bIAD":
						if (HDRBloomBlurRadiusMult == null)
							HDRBloomBlurRadiusMult = new IMADTimeValues();

						HDRBloomBlurRadiusMult.ReadBinary(reader);
						break;
					case "AIAD":
						if (HDRBloomBlurRadiusAdd == null)
							HDRBloomBlurRadiusAdd = new IMADTimeValues();

						HDRBloomBlurRadiusAdd.ReadBinary(reader);
						break;
					case "cIAD":
						if (HDRBloomThresholdMult == null)
							HDRBloomThresholdMult = new IMADTimeValues();

						HDRBloomThresholdMult.ReadBinary(reader);
						break;
					case "BIAD":
						if (HDRBloomThresholdAdd == null)
							HDRBloomThresholdAdd = new IMADTimeValues();

						HDRBloomThresholdAdd.ReadBinary(reader);
						break;
					case "dIAD":
						if (HDRBloomScaleMult == null)
							HDRBloomScaleMult = new IMADTimeValues();

						HDRBloomScaleMult.ReadBinary(reader);
						break;
					case "CIAD":
						if (HDRBloomScaleAdd == null)
							HDRBloomScaleAdd = new IMADTimeValues();

						HDRBloomScaleAdd.ReadBinary(reader);
						break;
					case "eIAD":
						if (HDRTargetLUMMinMult == null)
							HDRTargetLUMMinMult = new IMADTimeValues();

						HDRTargetLUMMinMult.ReadBinary(reader);
						break;
					case "DIAD":
						if (HDRTargetLUMMinAdd == null)
							HDRTargetLUMMinAdd = new IMADTimeValues();

						HDRTargetLUMMinAdd.ReadBinary(reader);
						break;
					case "fIAD":
						if (HDRTargetLUMMaxMult == null)
							HDRTargetLUMMaxMult = new IMADTimeValues();

						HDRTargetLUMMaxMult.ReadBinary(reader);
						break;
					case "EIAD":
						if (HDRTargetLUMMaxAdd == null)
							HDRTargetLUMMaxAdd = new IMADTimeValues();

						HDRTargetLUMMaxAdd.ReadBinary(reader);
						break;
					case "gIAD":
						if (HDRSunlightScaleMult == null)
							HDRSunlightScaleMult = new IMADTimeValues();

						HDRSunlightScaleMult.ReadBinary(reader);
						break;
					case "FIAD":
						if (HDRSunlightScaleAdd == null)
							HDRSunlightScaleAdd = new IMADTimeValues();

						HDRSunlightScaleAdd.ReadBinary(reader);
						break;
					case "hIAD":
						if (HDRSkyScaleMult == null)
							HDRSkyScaleMult = new IMADTimeValues();

						HDRSkyScaleMult.ReadBinary(reader);
						break;
					case "GIAD":
						if (HDRSkyScaleAdd == null)
							HDRSkyScaleAdd = new IMADTimeValues();

						HDRSkyScaleAdd.ReadBinary(reader);
						break;
					case "iIAD":
						if (Unknown1 == null)
							Unknown1 = new IMADTimeValues();

						Unknown1.ReadBinary(reader);
						break;
					case "HIAD":
						if (Unknown2 == null)
							Unknown2 = new IMADTimeValues();

						Unknown2.ReadBinary(reader);
						break;
					case "jIAD":
						if (Unknown3 == null)
							Unknown3 = new IMADTimeValues();

						Unknown3.ReadBinary(reader);
						break;
					case "IIAD":
						if (Unknown4 == null)
							Unknown4 = new IMADTimeValues();

						Unknown4.ReadBinary(reader);
						break;
					case "kIAD":
						if (Unknown5 == null)
							Unknown5 = new IMADTimeValues();

						Unknown5.ReadBinary(reader);
						break;
					case "JIAD":
						if (Unknown6 == null)
							Unknown6 = new IMADTimeValues();

						Unknown6.ReadBinary(reader);
						break;
					case "lIAD":
						if (Unknown7 == null)
							Unknown7 = new IMADTimeValues();

						Unknown7.ReadBinary(reader);
						break;
					case "KIAD":
						if (Unknown8 == null)
							Unknown8 = new IMADTimeValues();

						Unknown8.ReadBinary(reader);
						break;
					case "mIAD":
						if (Unknown9 == null)
							Unknown9 = new IMADTimeValues();

						Unknown9.ReadBinary(reader);
						break;
					case "LIAD":
						if (Unknown10 == null)
							Unknown10 = new IMADTimeValues();

						Unknown10.ReadBinary(reader);
						break;
					case "nIAD":
						if (Unknown11 == null)
							Unknown11 = new IMADTimeValues();

						Unknown11.ReadBinary(reader);
						break;
					case "MIAD":
						if (Unknown12 == null)
							Unknown12 = new IMADTimeValues();

						Unknown12.ReadBinary(reader);
						break;
					case "oIAD":
						if (Unknown13 == null)
							Unknown13 = new IMADTimeValues();

						Unknown13.ReadBinary(reader);
						break;
					case "NIAD":
						if (Unknown14 == null)
							Unknown14 = new IMADTimeValues();

						Unknown14.ReadBinary(reader);
						break;
					case "pIAD":
						if (Unknown15 == null)
							Unknown15 = new IMADTimeValues();

						Unknown15.ReadBinary(reader);
						break;
					case "OIAD":
						if (Unknown16 == null)
							Unknown16 = new IMADTimeValues();

						Unknown16.ReadBinary(reader);
						break;
					case "qIAD":
						if (Unknown17 == null)
							Unknown17 = new IMADTimeValues();

						Unknown17.ReadBinary(reader);
						break;
					case "PIAD":
						if (Unknown18 == null)
							Unknown18 = new IMADTimeValues();

						Unknown18.ReadBinary(reader);
						break;
					case "rIAD":
						if (CinematicSaturationMult == null)
							CinematicSaturationMult = new IMADTimeValues();

						CinematicSaturationMult.ReadBinary(reader);
						break;
					case "QIAD":
						if (CinematicSaturationAdd == null)
							CinematicSaturationAdd = new IMADTimeValues();

						CinematicSaturationAdd.ReadBinary(reader);
						break;
					case "sIAD":
						if (CinematicBrightnessMult == null)
							CinematicBrightnessMult = new IMADTimeValues();

						CinematicBrightnessMult.ReadBinary(reader);
						break;
					case "RIAD":
						if (CinematicBrightnessAdd == null)
							CinematicBrightnessAdd = new IMADTimeValues();

						CinematicBrightnessAdd.ReadBinary(reader);
						break;
					case "tIAD":
						if (CinematicContrastMult == null)
							CinematicContrastMult = new IMADTimeValues();

						CinematicContrastMult.ReadBinary(reader);
						break;
					case "SIAD":
						if (CinematicContrastAdd == null)
							CinematicContrastAdd = new IMADTimeValues();

						CinematicContrastAdd.ReadBinary(reader);
						break;
					case "uIAD":
						if (Unknown19 == null)
							Unknown19 = new IMADTimeValues();

						Unknown19.ReadBinary(reader);
						break;
					case "TIAD":
						if (Unknown20 == null)
							Unknown20 = new IMADTimeValues();

						Unknown20.ReadBinary(reader);
						break;
					case "RDSD":
						if (SoundIntro == null)
							SoundIntro = new RecordReference();

						SoundIntro.ReadBinary(reader);
						break;
					case "RDSI":
						if (SoundOutro == null)
							SoundOutro = new RecordReference();

						SoundOutro.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (BlurRadius != null)
				BlurRadius.WriteBinary(writer);
			if (DoubleVisionStrength != null)
				DoubleVisionStrength.WriteBinary(writer);
			if (TintColor != null)
				TintColor.WriteBinary(writer);
			if (FadeColor != null)
				FadeColor.WriteBinary(writer);
			if (RadialBlurStrength != null)
				RadialBlurStrength.WriteBinary(writer);
			if (RadialBlurRampUp != null)
				RadialBlurRampUp.WriteBinary(writer);
			if (RadialBlurStart != null)
				RadialBlurStart.WriteBinary(writer);
			if (RadialBlurRampDown != null)
				RadialBlurRampDown.WriteBinary(writer);
			if (RadialBlurDownStart != null)
				RadialBlurDownStart.WriteBinary(writer);
			if (DoFStrength != null)
				DoFStrength.WriteBinary(writer);
			if (DoFDistance != null)
				DoFDistance.WriteBinary(writer);
			if (DoFRange != null)
				DoFRange.WriteBinary(writer);
			if (MotionBlurStrength != null)
				MotionBlurStrength.WriteBinary(writer);
			if (HDREyeAdaptSpeedMult != null)
				HDREyeAdaptSpeedMult.WriteBinary(writer);
			if (HDREyeAdaptSpeedAdd != null)
				HDREyeAdaptSpeedAdd.WriteBinary(writer);
			if (HDRBloomBlurRadiusMult != null)
				HDRBloomBlurRadiusMult.WriteBinary(writer);
			if (HDRBloomBlurRadiusAdd != null)
				HDRBloomBlurRadiusAdd.WriteBinary(writer);
			if (HDRBloomThresholdMult != null)
				HDRBloomThresholdMult.WriteBinary(writer);
			if (HDRBloomThresholdAdd != null)
				HDRBloomThresholdAdd.WriteBinary(writer);
			if (HDRBloomScaleMult != null)
				HDRBloomScaleMult.WriteBinary(writer);
			if (HDRBloomScaleAdd != null)
				HDRBloomScaleAdd.WriteBinary(writer);
			if (HDRTargetLUMMinMult != null)
				HDRTargetLUMMinMult.WriteBinary(writer);
			if (HDRTargetLUMMinAdd != null)
				HDRTargetLUMMinAdd.WriteBinary(writer);
			if (HDRTargetLUMMaxMult != null)
				HDRTargetLUMMaxMult.WriteBinary(writer);
			if (HDRTargetLUMMaxAdd != null)
				HDRTargetLUMMaxAdd.WriteBinary(writer);
			if (HDRSunlightScaleMult != null)
				HDRSunlightScaleMult.WriteBinary(writer);
			if (HDRSunlightScaleAdd != null)
				HDRSunlightScaleAdd.WriteBinary(writer);
			if (HDRSkyScaleMult != null)
				HDRSkyScaleMult.WriteBinary(writer);
			if (HDRSkyScaleAdd != null)
				HDRSkyScaleAdd.WriteBinary(writer);
			if (Unknown1 != null)
				Unknown1.WriteBinary(writer);
			if (Unknown2 != null)
				Unknown2.WriteBinary(writer);
			if (Unknown3 != null)
				Unknown3.WriteBinary(writer);
			if (Unknown4 != null)
				Unknown4.WriteBinary(writer);
			if (Unknown5 != null)
				Unknown5.WriteBinary(writer);
			if (Unknown6 != null)
				Unknown6.WriteBinary(writer);
			if (Unknown7 != null)
				Unknown7.WriteBinary(writer);
			if (Unknown8 != null)
				Unknown8.WriteBinary(writer);
			if (Unknown9 != null)
				Unknown9.WriteBinary(writer);
			if (Unknown10 != null)
				Unknown10.WriteBinary(writer);
			if (Unknown11 != null)
				Unknown11.WriteBinary(writer);
			if (Unknown12 != null)
				Unknown12.WriteBinary(writer);
			if (Unknown13 != null)
				Unknown13.WriteBinary(writer);
			if (Unknown14 != null)
				Unknown14.WriteBinary(writer);
			if (Unknown15 != null)
				Unknown15.WriteBinary(writer);
			if (Unknown16 != null)
				Unknown16.WriteBinary(writer);
			if (Unknown17 != null)
				Unknown17.WriteBinary(writer);
			if (Unknown18 != null)
				Unknown18.WriteBinary(writer);
			if (CinematicSaturationMult != null)
				CinematicSaturationMult.WriteBinary(writer);
			if (CinematicSaturationAdd != null)
				CinematicSaturationAdd.WriteBinary(writer);
			if (CinematicBrightnessMult != null)
				CinematicBrightnessMult.WriteBinary(writer);
			if (CinematicBrightnessAdd != null)
				CinematicBrightnessAdd.WriteBinary(writer);
			if (CinematicContrastMult != null)
				CinematicContrastMult.WriteBinary(writer);
			if (CinematicContrastAdd != null)
				CinematicContrastAdd.WriteBinary(writer);
			if (Unknown19 != null)
				Unknown19.WriteBinary(writer);
			if (Unknown20 != null)
				Unknown20.WriteBinary(writer);
			if (SoundIntro != null)
				SoundIntro.WriteBinary(writer);
			if (SoundOutro != null)
				SoundOutro.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (BlurRadius != null)		
			{		
				ele.TryPathTo("BlurRadius", true, out subEle);
				BlurRadius.WriteXML(subEle, master);
			}
			if (DoubleVisionStrength != null)		
			{		
				ele.TryPathTo("DoubleVisionStrength", true, out subEle);
				DoubleVisionStrength.WriteXML(subEle, master);
			}
			if (TintColor != null)		
			{		
				ele.TryPathTo("TintColor", true, out subEle);
				TintColor.WriteXML(subEle, master);
			}
			if (FadeColor != null)		
			{		
				ele.TryPathTo("FadeColor", true, out subEle);
				FadeColor.WriteXML(subEle, master);
			}
			if (RadialBlurStrength != null)		
			{		
				ele.TryPathTo("RadialBlur/Strength", true, out subEle);
				RadialBlurStrength.WriteXML(subEle, master);
			}
			if (RadialBlurRampUp != null)		
			{		
				ele.TryPathTo("RadialBlur/RampUp", true, out subEle);
				RadialBlurRampUp.WriteXML(subEle, master);
			}
			if (RadialBlurStart != null)		
			{		
				ele.TryPathTo("RadialBlur/Start", true, out subEle);
				RadialBlurStart.WriteXML(subEle, master);
			}
			if (RadialBlurRampDown != null)		
			{		
				ele.TryPathTo("RadialBlur/RampDown", true, out subEle);
				RadialBlurRampDown.WriteXML(subEle, master);
			}
			if (RadialBlurDownStart != null)		
			{		
				ele.TryPathTo("RadialBlur/DownStart", true, out subEle);
				RadialBlurDownStart.WriteXML(subEle, master);
			}
			if (DoFStrength != null)		
			{		
				ele.TryPathTo("DoF/Strength", true, out subEle);
				DoFStrength.WriteXML(subEle, master);
			}
			if (DoFDistance != null)		
			{		
				ele.TryPathTo("DoF/Distance", true, out subEle);
				DoFDistance.WriteXML(subEle, master);
			}
			if (DoFRange != null)		
			{		
				ele.TryPathTo("DoF/Range", true, out subEle);
				DoFRange.WriteXML(subEle, master);
			}
			if (MotionBlurStrength != null)		
			{		
				ele.TryPathTo("MotionBlurStrength", true, out subEle);
				MotionBlurStrength.WriteXML(subEle, master);
			}
			if (HDREyeAdaptSpeedMult != null)		
			{		
				ele.TryPathTo("HDR/EyeAdaptSpeed/Mult", true, out subEle);
				HDREyeAdaptSpeedMult.WriteXML(subEle, master);
			}
			if (HDREyeAdaptSpeedAdd != null)		
			{		
				ele.TryPathTo("HDR/EyeAdaptSpeed/Add", true, out subEle);
				HDREyeAdaptSpeedAdd.WriteXML(subEle, master);
			}
			if (HDRBloomBlurRadiusMult != null)		
			{		
				ele.TryPathTo("HDR/Bloom/BlurRadius/Mult", true, out subEle);
				HDRBloomBlurRadiusMult.WriteXML(subEle, master);
			}
			if (HDRBloomBlurRadiusAdd != null)		
			{		
				ele.TryPathTo("HDR/Bloom/BlurRadius/Add", true, out subEle);
				HDRBloomBlurRadiusAdd.WriteXML(subEle, master);
			}
			if (HDRBloomThresholdMult != null)		
			{		
				ele.TryPathTo("HDR/Bloom/Threshold/Mult", true, out subEle);
				HDRBloomThresholdMult.WriteXML(subEle, master);
			}
			if (HDRBloomThresholdAdd != null)		
			{		
				ele.TryPathTo("HDR/Bloom/Threshold/Add", true, out subEle);
				HDRBloomThresholdAdd.WriteXML(subEle, master);
			}
			if (HDRBloomScaleMult != null)		
			{		
				ele.TryPathTo("HDR/Bloom/Scale/Mult", true, out subEle);
				HDRBloomScaleMult.WriteXML(subEle, master);
			}
			if (HDRBloomScaleAdd != null)		
			{		
				ele.TryPathTo("HDR/Bloom/Scale/Add", true, out subEle);
				HDRBloomScaleAdd.WriteXML(subEle, master);
			}
			if (HDRTargetLUMMinMult != null)		
			{		
				ele.TryPathTo("HDR/TargetLUM/Min/Mult", true, out subEle);
				HDRTargetLUMMinMult.WriteXML(subEle, master);
			}
			if (HDRTargetLUMMinAdd != null)		
			{		
				ele.TryPathTo("HDR/TargetLUM/Min/Add", true, out subEle);
				HDRTargetLUMMinAdd.WriteXML(subEle, master);
			}
			if (HDRTargetLUMMaxMult != null)		
			{		
				ele.TryPathTo("HDR/TargetLUM/Max/Mult", true, out subEle);
				HDRTargetLUMMaxMult.WriteXML(subEle, master);
			}
			if (HDRTargetLUMMaxAdd != null)		
			{		
				ele.TryPathTo("HDR/TargetLUM/Max/Add", true, out subEle);
				HDRTargetLUMMaxAdd.WriteXML(subEle, master);
			}
			if (HDRSunlightScaleMult != null)		
			{		
				ele.TryPathTo("HDR/SunlightScale/Mult", true, out subEle);
				HDRSunlightScaleMult.WriteXML(subEle, master);
			}
			if (HDRSunlightScaleAdd != null)		
			{		
				ele.TryPathTo("HDR/SunlightScale/Add", true, out subEle);
				HDRSunlightScaleAdd.WriteXML(subEle, master);
			}
			if (HDRSkyScaleMult != null)		
			{		
				ele.TryPathTo("HDR/SkyScale/Mult", true, out subEle);
				HDRSkyScaleMult.WriteXML(subEle, master);
			}
			if (HDRSkyScaleAdd != null)		
			{		
				ele.TryPathTo("HDR/SkyScale/Add", true, out subEle);
				HDRSkyScaleAdd.WriteXML(subEle, master);
			}
			if (Unknown1 != null)		
			{		
				ele.TryPathTo("Unknown1", true, out subEle);
				Unknown1.WriteXML(subEle, master);
			}
			if (Unknown2 != null)		
			{		
				ele.TryPathTo("Unknown2", true, out subEle);
				Unknown2.WriteXML(subEle, master);
			}
			if (Unknown3 != null)		
			{		
				ele.TryPathTo("Unknown3", true, out subEle);
				Unknown3.WriteXML(subEle, master);
			}
			if (Unknown4 != null)		
			{		
				ele.TryPathTo("Unknown4", true, out subEle);
				Unknown4.WriteXML(subEle, master);
			}
			if (Unknown5 != null)		
			{		
				ele.TryPathTo("Unknown5", true, out subEle);
				Unknown5.WriteXML(subEle, master);
			}
			if (Unknown6 != null)		
			{		
				ele.TryPathTo("Unknown6", true, out subEle);
				Unknown6.WriteXML(subEle, master);
			}
			if (Unknown7 != null)		
			{		
				ele.TryPathTo("Unknown7", true, out subEle);
				Unknown7.WriteXML(subEle, master);
			}
			if (Unknown8 != null)		
			{		
				ele.TryPathTo("Unknown8", true, out subEle);
				Unknown8.WriteXML(subEle, master);
			}
			if (Unknown9 != null)		
			{		
				ele.TryPathTo("Unknown9", true, out subEle);
				Unknown9.WriteXML(subEle, master);
			}
			if (Unknown10 != null)		
			{		
				ele.TryPathTo("Unknown10", true, out subEle);
				Unknown10.WriteXML(subEle, master);
			}
			if (Unknown11 != null)		
			{		
				ele.TryPathTo("Unknown11", true, out subEle);
				Unknown11.WriteXML(subEle, master);
			}
			if (Unknown12 != null)		
			{		
				ele.TryPathTo("Unknown12", true, out subEle);
				Unknown12.WriteXML(subEle, master);
			}
			if (Unknown13 != null)		
			{		
				ele.TryPathTo("Unknown13", true, out subEle);
				Unknown13.WriteXML(subEle, master);
			}
			if (Unknown14 != null)		
			{		
				ele.TryPathTo("Unknown14", true, out subEle);
				Unknown14.WriteXML(subEle, master);
			}
			if (Unknown15 != null)		
			{		
				ele.TryPathTo("Unknown15", true, out subEle);
				Unknown15.WriteXML(subEle, master);
			}
			if (Unknown16 != null)		
			{		
				ele.TryPathTo("Unknown16", true, out subEle);
				Unknown16.WriteXML(subEle, master);
			}
			if (Unknown17 != null)		
			{		
				ele.TryPathTo("Unknown17", true, out subEle);
				Unknown17.WriteXML(subEle, master);
			}
			if (Unknown18 != null)		
			{		
				ele.TryPathTo("Unknown18", true, out subEle);
				Unknown18.WriteXML(subEle, master);
			}
			if (CinematicSaturationMult != null)		
			{		
				ele.TryPathTo("Cinematic/Saturation/Mult", true, out subEle);
				CinematicSaturationMult.WriteXML(subEle, master);
			}
			if (CinematicSaturationAdd != null)		
			{		
				ele.TryPathTo("Cinematic/Saturation/Add", true, out subEle);
				CinematicSaturationAdd.WriteXML(subEle, master);
			}
			if (CinematicBrightnessMult != null)		
			{		
				ele.TryPathTo("Cinematic/Brightness/Mult", true, out subEle);
				CinematicBrightnessMult.WriteXML(subEle, master);
			}
			if (CinematicBrightnessAdd != null)		
			{		
				ele.TryPathTo("Cinematic/Brightness/Add", true, out subEle);
				CinematicBrightnessAdd.WriteXML(subEle, master);
			}
			if (CinematicContrastMult != null)		
			{		
				ele.TryPathTo("Cinematic/Contrast/Mult", true, out subEle);
				CinematicContrastMult.WriteXML(subEle, master);
			}
			if (CinematicContrastAdd != null)		
			{		
				ele.TryPathTo("Cinematic/Contrast/Add", true, out subEle);
				CinematicContrastAdd.WriteXML(subEle, master);
			}
			if (Unknown19 != null)		
			{		
				ele.TryPathTo("Unknown19", true, out subEle);
				Unknown19.WriteXML(subEle, master);
			}
			if (Unknown20 != null)		
			{		
				ele.TryPathTo("Unknown20", true, out subEle);
				Unknown20.WriteXML(subEle, master);
			}
			if (SoundIntro != null)		
			{		
				ele.TryPathTo("Sound/Intro", true, out subEle);
				SoundIntro.WriteXML(subEle, master);
			}
			if (SoundOutro != null)		
			{		
				ele.TryPathTo("Sound/Outro", true, out subEle);
				SoundOutro.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ImageSpaceAdapterData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BlurRadius", false, out subEle))
			{
				if (BlurRadius == null)
					BlurRadius = new IMADTimeValues();
					
				BlurRadius.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DoubleVisionStrength", false, out subEle))
			{
				if (DoubleVisionStrength == null)
					DoubleVisionStrength = new IMADTimeValues();
					
				DoubleVisionStrength.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TintColor", false, out subEle))
			{
				if (TintColor == null)
					TintColor = new IMADTimeColors();
					
				TintColor.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FadeColor", false, out subEle))
			{
				if (FadeColor == null)
					FadeColor = new IMADTimeColors();
					
				FadeColor.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadialBlur/Strength", false, out subEle))
			{
				if (RadialBlurStrength == null)
					RadialBlurStrength = new IMADTimeValues();
					
				RadialBlurStrength.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadialBlur/RampUp", false, out subEle))
			{
				if (RadialBlurRampUp == null)
					RadialBlurRampUp = new IMADTimeValues();
					
				RadialBlurRampUp.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadialBlur/Start", false, out subEle))
			{
				if (RadialBlurStart == null)
					RadialBlurStart = new IMADTimeValues();
					
				RadialBlurStart.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadialBlur/RampDown", false, out subEle))
			{
				if (RadialBlurRampDown == null)
					RadialBlurRampDown = new IMADTimeValues();
					
				RadialBlurRampDown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadialBlur/DownStart", false, out subEle))
			{
				if (RadialBlurDownStart == null)
					RadialBlurDownStart = new IMADTimeValues();
					
				RadialBlurDownStart.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DoF/Strength", false, out subEle))
			{
				if (DoFStrength == null)
					DoFStrength = new IMADTimeValues();
					
				DoFStrength.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DoF/Distance", false, out subEle))
			{
				if (DoFDistance == null)
					DoFDistance = new IMADTimeValues();
					
				DoFDistance.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DoF/Range", false, out subEle))
			{
				if (DoFRange == null)
					DoFRange = new IMADTimeValues();
					
				DoFRange.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MotionBlurStrength", false, out subEle))
			{
				if (MotionBlurStrength == null)
					MotionBlurStrength = new IMADTimeValues();
					
				MotionBlurStrength.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/EyeAdaptSpeed/Mult", false, out subEle))
			{
				if (HDREyeAdaptSpeedMult == null)
					HDREyeAdaptSpeedMult = new IMADTimeValues();
					
				HDREyeAdaptSpeedMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/EyeAdaptSpeed/Add", false, out subEle))
			{
				if (HDREyeAdaptSpeedAdd == null)
					HDREyeAdaptSpeedAdd = new IMADTimeValues();
					
				HDREyeAdaptSpeedAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/BlurRadius/Mult", false, out subEle))
			{
				if (HDRBloomBlurRadiusMult == null)
					HDRBloomBlurRadiusMult = new IMADTimeValues();
					
				HDRBloomBlurRadiusMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/BlurRadius/Add", false, out subEle))
			{
				if (HDRBloomBlurRadiusAdd == null)
					HDRBloomBlurRadiusAdd = new IMADTimeValues();
					
				HDRBloomBlurRadiusAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/Threshold/Mult", false, out subEle))
			{
				if (HDRBloomThresholdMult == null)
					HDRBloomThresholdMult = new IMADTimeValues();
					
				HDRBloomThresholdMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/Threshold/Add", false, out subEle))
			{
				if (HDRBloomThresholdAdd == null)
					HDRBloomThresholdAdd = new IMADTimeValues();
					
				HDRBloomThresholdAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/Scale/Mult", false, out subEle))
			{
				if (HDRBloomScaleMult == null)
					HDRBloomScaleMult = new IMADTimeValues();
					
				HDRBloomScaleMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/Bloom/Scale/Add", false, out subEle))
			{
				if (HDRBloomScaleAdd == null)
					HDRBloomScaleAdd = new IMADTimeValues();
					
				HDRBloomScaleAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/TargetLUM/Min/Mult", false, out subEle))
			{
				if (HDRTargetLUMMinMult == null)
					HDRTargetLUMMinMult = new IMADTimeValues();
					
				HDRTargetLUMMinMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/TargetLUM/Min/Add", false, out subEle))
			{
				if (HDRTargetLUMMinAdd == null)
					HDRTargetLUMMinAdd = new IMADTimeValues();
					
				HDRTargetLUMMinAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/TargetLUM/Max/Mult", false, out subEle))
			{
				if (HDRTargetLUMMaxMult == null)
					HDRTargetLUMMaxMult = new IMADTimeValues();
					
				HDRTargetLUMMaxMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/TargetLUM/Max/Add", false, out subEle))
			{
				if (HDRTargetLUMMaxAdd == null)
					HDRTargetLUMMaxAdd = new IMADTimeValues();
					
				HDRTargetLUMMaxAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/SunlightScale/Mult", false, out subEle))
			{
				if (HDRSunlightScaleMult == null)
					HDRSunlightScaleMult = new IMADTimeValues();
					
				HDRSunlightScaleMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/SunlightScale/Add", false, out subEle))
			{
				if (HDRSunlightScaleAdd == null)
					HDRSunlightScaleAdd = new IMADTimeValues();
					
				HDRSunlightScaleAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/SkyScale/Mult", false, out subEle))
			{
				if (HDRSkyScaleMult == null)
					HDRSkyScaleMult = new IMADTimeValues();
					
				HDRSkyScaleMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HDR/SkyScale/Add", false, out subEle))
			{
				if (HDRSkyScaleAdd == null)
					HDRSkyScaleAdd = new IMADTimeValues();
					
				HDRSkyScaleAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				if (Unknown1 == null)
					Unknown1 = new IMADTimeValues();
					
				Unknown1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				if (Unknown2 == null)
					Unknown2 = new IMADTimeValues();
					
				Unknown2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown3", false, out subEle))
			{
				if (Unknown3 == null)
					Unknown3 = new IMADTimeValues();
					
				Unknown3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown4", false, out subEle))
			{
				if (Unknown4 == null)
					Unknown4 = new IMADTimeValues();
					
				Unknown4.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown5", false, out subEle))
			{
				if (Unknown5 == null)
					Unknown5 = new IMADTimeValues();
					
				Unknown5.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown6", false, out subEle))
			{
				if (Unknown6 == null)
					Unknown6 = new IMADTimeValues();
					
				Unknown6.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown7", false, out subEle))
			{
				if (Unknown7 == null)
					Unknown7 = new IMADTimeValues();
					
				Unknown7.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown8", false, out subEle))
			{
				if (Unknown8 == null)
					Unknown8 = new IMADTimeValues();
					
				Unknown8.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown9", false, out subEle))
			{
				if (Unknown9 == null)
					Unknown9 = new IMADTimeValues();
					
				Unknown9.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown10", false, out subEle))
			{
				if (Unknown10 == null)
					Unknown10 = new IMADTimeValues();
					
				Unknown10.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown11", false, out subEle))
			{
				if (Unknown11 == null)
					Unknown11 = new IMADTimeValues();
					
				Unknown11.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown12", false, out subEle))
			{
				if (Unknown12 == null)
					Unknown12 = new IMADTimeValues();
					
				Unknown12.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown13", false, out subEle))
			{
				if (Unknown13 == null)
					Unknown13 = new IMADTimeValues();
					
				Unknown13.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown14", false, out subEle))
			{
				if (Unknown14 == null)
					Unknown14 = new IMADTimeValues();
					
				Unknown14.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown15", false, out subEle))
			{
				if (Unknown15 == null)
					Unknown15 = new IMADTimeValues();
					
				Unknown15.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown16", false, out subEle))
			{
				if (Unknown16 == null)
					Unknown16 = new IMADTimeValues();
					
				Unknown16.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown17", false, out subEle))
			{
				if (Unknown17 == null)
					Unknown17 = new IMADTimeValues();
					
				Unknown17.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown18", false, out subEle))
			{
				if (Unknown18 == null)
					Unknown18 = new IMADTimeValues();
					
				Unknown18.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Saturation/Mult", false, out subEle))
			{
				if (CinematicSaturationMult == null)
					CinematicSaturationMult = new IMADTimeValues();
					
				CinematicSaturationMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Saturation/Add", false, out subEle))
			{
				if (CinematicSaturationAdd == null)
					CinematicSaturationAdd = new IMADTimeValues();
					
				CinematicSaturationAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Brightness/Mult", false, out subEle))
			{
				if (CinematicBrightnessMult == null)
					CinematicBrightnessMult = new IMADTimeValues();
					
				CinematicBrightnessMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Brightness/Add", false, out subEle))
			{
				if (CinematicBrightnessAdd == null)
					CinematicBrightnessAdd = new IMADTimeValues();
					
				CinematicBrightnessAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Contrast/Mult", false, out subEle))
			{
				if (CinematicContrastMult == null)
					CinematicContrastMult = new IMADTimeValues();
					
				CinematicContrastMult.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Cinematic/Contrast/Add", false, out subEle))
			{
				if (CinematicContrastAdd == null)
					CinematicContrastAdd = new IMADTimeValues();
					
				CinematicContrastAdd.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown19", false, out subEle))
			{
				if (Unknown19 == null)
					Unknown19 = new IMADTimeValues();
					
				Unknown19.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown20", false, out subEle))
			{
				if (Unknown20 == null)
					Unknown20 = new IMADTimeValues();
					
				Unknown20.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Intro", false, out subEle))
			{
				if (SoundIntro == null)
					SoundIntro = new RecordReference();
					
				SoundIntro.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound/Outro", false, out subEle))
			{
				if (SoundOutro == null)
					SoundOutro = new RecordReference();
					
				SoundOutro.ReadXML(subEle, master);
			}
		}		

		public ImageSpaceAdapter Clone()
		{
			return new ImageSpaceAdapter(this);
		}

	}
}