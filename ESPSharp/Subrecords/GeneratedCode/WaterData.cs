
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
	public partial class WaterData : Subrecord, ICloneable, IComparable<WaterData>, IEquatable<WaterData>  
	{
		public Byte[] Unknown { get; set; }
		public Single WaterPropertiesSunPower { get; set; }
		public Single WaterPropertiesReflectivityAmount { get; set; }
		public Single WaterPropertiesFresnelAmount { get; set; }
		public Byte[] Unused1 { get; set; }
		public Single FogPropertiesAboveWaterFogNearPlaneDistance { get; set; }
		public Single FogPropertiesAboveWaterFogFarPlaneDistance { get; set; }
		public Color ColorShallow { get; set; }
		public Color ColorDeep { get; set; }
		public Color ColorReflection { get; set; }
		public Byte[] Unused2 { get; set; }
		public Single RainSimulatorForce { get; set; }
		public Single RainSimulatorVelocity { get; set; }
		public Single RainSimulatorFalloff { get; set; }
		public Single RainSimulatorDampener { get; set; }
		public Single DisplacementSimulatorStartingSize { get; set; }
		public Single DisplacementSimulatorForce { get; set; }
		public Single DisplacementSimulatorVelocity { get; set; }
		public Single DisplacementSimulatorFalloff { get; set; }
		public Single DisplacementSimulatorDampener { get; set; }
		public Single RainSimulatorStartingSize { get; set; }
		public Single NoisePropertiesNormalsNoiseScale { get; set; }
		public Single NoisePropertiesNoiseLayerOneWindDirection { get; set; }
		public Single NoisePropertiesNoiseLayerTwoWindDirection { get; set; }
		public Single NoisePropertiesNoiseLayerThreeWindDirection { get; set; }
		public Single NoisePropertiesNoiseLayerOneWindSpeed { get; set; }
		public Single NoisePropertiesNoiseLayerTwoWindSpeed { get; set; }
		public Single NoisePropertiesNoiseLayerThreeWindSpeed { get; set; }
		public Single NoisePropertiesNormalsDepthFalloffStart { get; set; }
		public Single NoisePropertiesNormalsDepthFalloffEnd { get; set; }
		public Single FogPropertiesAboveWaterFogAmount { get; set; }
		public Single NoisePropertiesNormalsUVScale { get; set; }
		public Single FogPropertiesUnderWaterFogAmount { get; set; }
		public Single FogPropertiesUnderWaterFogNearPlaneDistance { get; set; }
		public Single FogPropertiesUnderWaterFogFarPlaneDistance { get; set; }
		public Single WaterPropertiesDistortionAmount { get; set; }
		public Single WaterPropertiesShininess { get; set; }
		public Single WaterPropertiesReflectionHDRMult { get; set; }
		public Single WaterPropertiesLightRadius { get; set; }
		public Single WaterPropertiesLightBrightness { get; set; }
		public Single NoisePropertiesNoiseLayerOneUVScale { get; set; }
		public Single NoisePropertiesNoiseLayerTwoUVScale { get; set; }
		public Single NoisePropertiesNoiseLayerThreeUVScale { get; set; }
		public Single NoisePropertiesNoiseLayerOneAmplitudeScale { get; set; }
		public Single NoisePropertiesNoiseLayerTwoAmplitudeScale { get; set; }
		public Single NoisePropertiesNoiseLayerThreeAmplitudeScale { get; set; }

		public WaterData(string Tag = null)
			:base(Tag)
		{
			Unknown = new byte[16];
			WaterPropertiesSunPower = new Single();
			WaterPropertiesReflectivityAmount = new Single();
			WaterPropertiesFresnelAmount = new Single();
			Unused1 = new byte[4];
			FogPropertiesAboveWaterFogNearPlaneDistance = new Single();
			FogPropertiesAboveWaterFogFarPlaneDistance = new Single();
			ColorShallow = new Color();
			ColorDeep = new Color();
			ColorReflection = new Color();
			Unused2 = new byte[4];
			RainSimulatorForce = new Single();
			RainSimulatorVelocity = new Single();
			RainSimulatorFalloff = new Single();
			RainSimulatorDampener = new Single();
			DisplacementSimulatorStartingSize = new Single();
			DisplacementSimulatorForce = new Single();
			DisplacementSimulatorVelocity = new Single();
			DisplacementSimulatorFalloff = new Single();
			DisplacementSimulatorDampener = new Single();
			RainSimulatorStartingSize = new Single();
			NoisePropertiesNormalsNoiseScale = new Single();
			NoisePropertiesNoiseLayerOneWindDirection = new Single();
			NoisePropertiesNoiseLayerTwoWindDirection = new Single();
			NoisePropertiesNoiseLayerThreeWindDirection = new Single();
			NoisePropertiesNoiseLayerOneWindSpeed = new Single();
			NoisePropertiesNoiseLayerTwoWindSpeed = new Single();
			NoisePropertiesNoiseLayerThreeWindSpeed = new Single();
			NoisePropertiesNormalsDepthFalloffStart = new Single();
			NoisePropertiesNormalsDepthFalloffEnd = new Single();
			FogPropertiesAboveWaterFogAmount = new Single();
			NoisePropertiesNormalsUVScale = new Single();
			FogPropertiesUnderWaterFogAmount = new Single();
			FogPropertiesUnderWaterFogNearPlaneDistance = new Single();
			FogPropertiesUnderWaterFogFarPlaneDistance = new Single();
			WaterPropertiesDistortionAmount = new Single();
			WaterPropertiesShininess = new Single();
			WaterPropertiesReflectionHDRMult = new Single();
			WaterPropertiesLightRadius = new Single();
			WaterPropertiesLightBrightness = new Single();
			NoisePropertiesNoiseLayerOneUVScale = new Single();
			NoisePropertiesNoiseLayerTwoUVScale = new Single();
			NoisePropertiesNoiseLayerThreeUVScale = new Single();
			NoisePropertiesNoiseLayerOneAmplitudeScale = 1;
			NoisePropertiesNoiseLayerTwoAmplitudeScale = 0.5f;
			NoisePropertiesNoiseLayerThreeAmplitudeScale = 0.25f;
		}

		public WaterData(Byte[] Unknown, Single WaterPropertiesSunPower, Single WaterPropertiesReflectivityAmount, Single WaterPropertiesFresnelAmount, Byte[] Unused1, Single FogPropertiesAboveWaterFogNearPlaneDistance, Single FogPropertiesAboveWaterFogFarPlaneDistance, Color ColorShallow, Color ColorDeep, Color ColorReflection, Byte[] Unused2, Single RainSimulatorForce, Single RainSimulatorVelocity, Single RainSimulatorFalloff, Single RainSimulatorDampener, Single DisplacementSimulatorStartingSize, Single DisplacementSimulatorForce, Single DisplacementSimulatorVelocity, Single DisplacementSimulatorFalloff, Single DisplacementSimulatorDampener, Single RainSimulatorStartingSize, Single NoisePropertiesNormalsNoiseScale, Single NoisePropertiesNoiseLayerOneWindDirection, Single NoisePropertiesNoiseLayerTwoWindDirection, Single NoisePropertiesNoiseLayerThreeWindDirection, Single NoisePropertiesNoiseLayerOneWindSpeed, Single NoisePropertiesNoiseLayerTwoWindSpeed, Single NoisePropertiesNoiseLayerThreeWindSpeed, Single NoisePropertiesNormalsDepthFalloffStart, Single NoisePropertiesNormalsDepthFalloffEnd, Single FogPropertiesAboveWaterFogAmount, Single NoisePropertiesNormalsUVScale, Single FogPropertiesUnderWaterFogAmount, Single FogPropertiesUnderWaterFogNearPlaneDistance, Single FogPropertiesUnderWaterFogFarPlaneDistance, Single WaterPropertiesDistortionAmount, Single WaterPropertiesShininess, Single WaterPropertiesReflectionHDRMult, Single WaterPropertiesLightRadius, Single WaterPropertiesLightBrightness, Single NoisePropertiesNoiseLayerOneUVScale, Single NoisePropertiesNoiseLayerTwoUVScale, Single NoisePropertiesNoiseLayerThreeUVScale, Single NoisePropertiesNoiseLayerOneAmplitudeScale, Single NoisePropertiesNoiseLayerTwoAmplitudeScale, Single NoisePropertiesNoiseLayerThreeAmplitudeScale)
		{
			this.Unknown = Unknown;
			this.WaterPropertiesSunPower = WaterPropertiesSunPower;
			this.WaterPropertiesReflectivityAmount = WaterPropertiesReflectivityAmount;
			this.WaterPropertiesFresnelAmount = WaterPropertiesFresnelAmount;
			this.Unused1 = Unused1;
			this.FogPropertiesAboveWaterFogNearPlaneDistance = FogPropertiesAboveWaterFogNearPlaneDistance;
			this.FogPropertiesAboveWaterFogFarPlaneDistance = FogPropertiesAboveWaterFogFarPlaneDistance;
			this.ColorShallow = ColorShallow;
			this.ColorDeep = ColorDeep;
			this.ColorReflection = ColorReflection;
			this.Unused2 = Unused2;
			this.RainSimulatorForce = RainSimulatorForce;
			this.RainSimulatorVelocity = RainSimulatorVelocity;
			this.RainSimulatorFalloff = RainSimulatorFalloff;
			this.RainSimulatorDampener = RainSimulatorDampener;
			this.DisplacementSimulatorStartingSize = DisplacementSimulatorStartingSize;
			this.DisplacementSimulatorForce = DisplacementSimulatorForce;
			this.DisplacementSimulatorVelocity = DisplacementSimulatorVelocity;
			this.DisplacementSimulatorFalloff = DisplacementSimulatorFalloff;
			this.DisplacementSimulatorDampener = DisplacementSimulatorDampener;
			this.RainSimulatorStartingSize = RainSimulatorStartingSize;
			this.NoisePropertiesNormalsNoiseScale = NoisePropertiesNormalsNoiseScale;
			this.NoisePropertiesNoiseLayerOneWindDirection = NoisePropertiesNoiseLayerOneWindDirection;
			this.NoisePropertiesNoiseLayerTwoWindDirection = NoisePropertiesNoiseLayerTwoWindDirection;
			this.NoisePropertiesNoiseLayerThreeWindDirection = NoisePropertiesNoiseLayerThreeWindDirection;
			this.NoisePropertiesNoiseLayerOneWindSpeed = NoisePropertiesNoiseLayerOneWindSpeed;
			this.NoisePropertiesNoiseLayerTwoWindSpeed = NoisePropertiesNoiseLayerTwoWindSpeed;
			this.NoisePropertiesNoiseLayerThreeWindSpeed = NoisePropertiesNoiseLayerThreeWindSpeed;
			this.NoisePropertiesNormalsDepthFalloffStart = NoisePropertiesNormalsDepthFalloffStart;
			this.NoisePropertiesNormalsDepthFalloffEnd = NoisePropertiesNormalsDepthFalloffEnd;
			this.FogPropertiesAboveWaterFogAmount = FogPropertiesAboveWaterFogAmount;
			this.NoisePropertiesNormalsUVScale = NoisePropertiesNormalsUVScale;
			this.FogPropertiesUnderWaterFogAmount = FogPropertiesUnderWaterFogAmount;
			this.FogPropertiesUnderWaterFogNearPlaneDistance = FogPropertiesUnderWaterFogNearPlaneDistance;
			this.FogPropertiesUnderWaterFogFarPlaneDistance = FogPropertiesUnderWaterFogFarPlaneDistance;
			this.WaterPropertiesDistortionAmount = WaterPropertiesDistortionAmount;
			this.WaterPropertiesShininess = WaterPropertiesShininess;
			this.WaterPropertiesReflectionHDRMult = WaterPropertiesReflectionHDRMult;
			this.WaterPropertiesLightRadius = WaterPropertiesLightRadius;
			this.WaterPropertiesLightBrightness = WaterPropertiesLightBrightness;
			this.NoisePropertiesNoiseLayerOneUVScale = NoisePropertiesNoiseLayerOneUVScale;
			this.NoisePropertiesNoiseLayerTwoUVScale = NoisePropertiesNoiseLayerTwoUVScale;
			this.NoisePropertiesNoiseLayerThreeUVScale = NoisePropertiesNoiseLayerThreeUVScale;
			this.NoisePropertiesNoiseLayerOneAmplitudeScale = NoisePropertiesNoiseLayerOneAmplitudeScale;
			this.NoisePropertiesNoiseLayerTwoAmplitudeScale = NoisePropertiesNoiseLayerTwoAmplitudeScale;
			this.NoisePropertiesNoiseLayerThreeAmplitudeScale = NoisePropertiesNoiseLayerThreeAmplitudeScale;
		}

		public WaterData(WaterData copyObject)
		{
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
			WaterPropertiesSunPower = copyObject.WaterPropertiesSunPower;
			WaterPropertiesReflectivityAmount = copyObject.WaterPropertiesReflectivityAmount;
			WaterPropertiesFresnelAmount = copyObject.WaterPropertiesFresnelAmount;
			if (copyObject.Unused1 != null)
				Unused1 = (Byte[])copyObject.Unused1.Clone();
			FogPropertiesAboveWaterFogNearPlaneDistance = copyObject.FogPropertiesAboveWaterFogNearPlaneDistance;
			FogPropertiesAboveWaterFogFarPlaneDistance = copyObject.FogPropertiesAboveWaterFogFarPlaneDistance;
			if (copyObject.ColorShallow != null)
				ColorShallow = (Color)copyObject.ColorShallow.Clone();
			if (copyObject.ColorDeep != null)
				ColorDeep = (Color)copyObject.ColorDeep.Clone();
			if (copyObject.ColorReflection != null)
				ColorReflection = (Color)copyObject.ColorReflection.Clone();
			if (copyObject.Unused2 != null)
				Unused2 = (Byte[])copyObject.Unused2.Clone();
			RainSimulatorForce = copyObject.RainSimulatorForce;
			RainSimulatorVelocity = copyObject.RainSimulatorVelocity;
			RainSimulatorFalloff = copyObject.RainSimulatorFalloff;
			RainSimulatorDampener = copyObject.RainSimulatorDampener;
			DisplacementSimulatorStartingSize = copyObject.DisplacementSimulatorStartingSize;
			DisplacementSimulatorForce = copyObject.DisplacementSimulatorForce;
			DisplacementSimulatorVelocity = copyObject.DisplacementSimulatorVelocity;
			DisplacementSimulatorFalloff = copyObject.DisplacementSimulatorFalloff;
			DisplacementSimulatorDampener = copyObject.DisplacementSimulatorDampener;
			RainSimulatorStartingSize = copyObject.RainSimulatorStartingSize;
			NoisePropertiesNormalsNoiseScale = copyObject.NoisePropertiesNormalsNoiseScale;
			NoisePropertiesNoiseLayerOneWindDirection = copyObject.NoisePropertiesNoiseLayerOneWindDirection;
			NoisePropertiesNoiseLayerTwoWindDirection = copyObject.NoisePropertiesNoiseLayerTwoWindDirection;
			NoisePropertiesNoiseLayerThreeWindDirection = copyObject.NoisePropertiesNoiseLayerThreeWindDirection;
			NoisePropertiesNoiseLayerOneWindSpeed = copyObject.NoisePropertiesNoiseLayerOneWindSpeed;
			NoisePropertiesNoiseLayerTwoWindSpeed = copyObject.NoisePropertiesNoiseLayerTwoWindSpeed;
			NoisePropertiesNoiseLayerThreeWindSpeed = copyObject.NoisePropertiesNoiseLayerThreeWindSpeed;
			NoisePropertiesNormalsDepthFalloffStart = copyObject.NoisePropertiesNormalsDepthFalloffStart;
			NoisePropertiesNormalsDepthFalloffEnd = copyObject.NoisePropertiesNormalsDepthFalloffEnd;
			FogPropertiesAboveWaterFogAmount = copyObject.FogPropertiesAboveWaterFogAmount;
			NoisePropertiesNormalsUVScale = copyObject.NoisePropertiesNormalsUVScale;
			FogPropertiesUnderWaterFogAmount = copyObject.FogPropertiesUnderWaterFogAmount;
			FogPropertiesUnderWaterFogNearPlaneDistance = copyObject.FogPropertiesUnderWaterFogNearPlaneDistance;
			FogPropertiesUnderWaterFogFarPlaneDistance = copyObject.FogPropertiesUnderWaterFogFarPlaneDistance;
			WaterPropertiesDistortionAmount = copyObject.WaterPropertiesDistortionAmount;
			WaterPropertiesShininess = copyObject.WaterPropertiesShininess;
			WaterPropertiesReflectionHDRMult = copyObject.WaterPropertiesReflectionHDRMult;
			WaterPropertiesLightRadius = copyObject.WaterPropertiesLightRadius;
			WaterPropertiesLightBrightness = copyObject.WaterPropertiesLightBrightness;
			NoisePropertiesNoiseLayerOneUVScale = copyObject.NoisePropertiesNoiseLayerOneUVScale;
			NoisePropertiesNoiseLayerTwoUVScale = copyObject.NoisePropertiesNoiseLayerTwoUVScale;
			NoisePropertiesNoiseLayerThreeUVScale = copyObject.NoisePropertiesNoiseLayerThreeUVScale;
			NoisePropertiesNoiseLayerOneAmplitudeScale = copyObject.NoisePropertiesNoiseLayerOneAmplitudeScale;
			NoisePropertiesNoiseLayerTwoAmplitudeScale = copyObject.NoisePropertiesNoiseLayerTwoAmplitudeScale;
			NoisePropertiesNoiseLayerThreeAmplitudeScale = copyObject.NoisePropertiesNoiseLayerThreeAmplitudeScale;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Unknown = subReader.ReadBytes(16);
					WaterPropertiesSunPower = subReader.ReadSingle();
					WaterPropertiesReflectivityAmount = subReader.ReadSingle();
					WaterPropertiesFresnelAmount = subReader.ReadSingle();
					Unused1 = subReader.ReadBytes(4);
					FogPropertiesAboveWaterFogNearPlaneDistance = subReader.ReadSingle();
					FogPropertiesAboveWaterFogFarPlaneDistance = subReader.ReadSingle();
					ColorShallow.ReadBinary(subReader);
					ColorDeep.ReadBinary(subReader);
					ColorReflection.ReadBinary(subReader);
					Unused2 = subReader.ReadBytes(4);
					RainSimulatorForce = subReader.ReadSingle();
					RainSimulatorVelocity = subReader.ReadSingle();
					RainSimulatorFalloff = subReader.ReadSingle();
					RainSimulatorDampener = subReader.ReadSingle();
					DisplacementSimulatorStartingSize = subReader.ReadSingle();
					DisplacementSimulatorForce = subReader.ReadSingle();
					DisplacementSimulatorVelocity = subReader.ReadSingle();
					DisplacementSimulatorFalloff = subReader.ReadSingle();
					DisplacementSimulatorDampener = subReader.ReadSingle();
					RainSimulatorStartingSize = subReader.ReadSingle();
					NoisePropertiesNormalsNoiseScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerOneWindDirection = subReader.ReadSingle();
					NoisePropertiesNoiseLayerTwoWindDirection = subReader.ReadSingle();
					NoisePropertiesNoiseLayerThreeWindDirection = subReader.ReadSingle();
					NoisePropertiesNoiseLayerOneWindSpeed = subReader.ReadSingle();
					NoisePropertiesNoiseLayerTwoWindSpeed = subReader.ReadSingle();
					NoisePropertiesNoiseLayerThreeWindSpeed = subReader.ReadSingle();
					NoisePropertiesNormalsDepthFalloffStart = subReader.ReadSingle();
					NoisePropertiesNormalsDepthFalloffEnd = subReader.ReadSingle();
					FogPropertiesAboveWaterFogAmount = subReader.ReadSingle();
					NoisePropertiesNormalsUVScale = subReader.ReadSingle();
					FogPropertiesUnderWaterFogAmount = subReader.ReadSingle();
					FogPropertiesUnderWaterFogNearPlaneDistance = subReader.ReadSingle();
					FogPropertiesUnderWaterFogFarPlaneDistance = subReader.ReadSingle();
					WaterPropertiesDistortionAmount = subReader.ReadSingle();
					WaterPropertiesShininess = subReader.ReadSingle();
					WaterPropertiesReflectionHDRMult = subReader.ReadSingle();
					WaterPropertiesLightRadius = subReader.ReadSingle();
					WaterPropertiesLightBrightness = subReader.ReadSingle();
					NoisePropertiesNoiseLayerOneUVScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerTwoUVScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerThreeUVScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerOneAmplitudeScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerTwoAmplitudeScale = subReader.ReadSingle();
					NoisePropertiesNoiseLayerThreeAmplitudeScale = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			if (Unknown == null)
				writer.Write(new byte[16]);
			else
			writer.Write(Unknown);
			writer.Write(WaterPropertiesSunPower);
			writer.Write(WaterPropertiesReflectivityAmount);
			writer.Write(WaterPropertiesFresnelAmount);
			if (Unused1 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused1);
			writer.Write(FogPropertiesAboveWaterFogNearPlaneDistance);
			writer.Write(FogPropertiesAboveWaterFogFarPlaneDistance);
			ColorShallow.WriteBinary(writer);
			ColorDeep.WriteBinary(writer);
			ColorReflection.WriteBinary(writer);
			if (Unused2 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused2);
			writer.Write(RainSimulatorForce);
			writer.Write(RainSimulatorVelocity);
			writer.Write(RainSimulatorFalloff);
			writer.Write(RainSimulatorDampener);
			writer.Write(DisplacementSimulatorStartingSize);
			writer.Write(DisplacementSimulatorForce);
			writer.Write(DisplacementSimulatorVelocity);
			writer.Write(DisplacementSimulatorFalloff);
			writer.Write(DisplacementSimulatorDampener);
			writer.Write(RainSimulatorStartingSize);
			writer.Write(NoisePropertiesNormalsNoiseScale);
			writer.Write(NoisePropertiesNoiseLayerOneWindDirection);
			writer.Write(NoisePropertiesNoiseLayerTwoWindDirection);
			writer.Write(NoisePropertiesNoiseLayerThreeWindDirection);
			writer.Write(NoisePropertiesNoiseLayerOneWindSpeed);
			writer.Write(NoisePropertiesNoiseLayerTwoWindSpeed);
			writer.Write(NoisePropertiesNoiseLayerThreeWindSpeed);
			writer.Write(NoisePropertiesNormalsDepthFalloffStart);
			writer.Write(NoisePropertiesNormalsDepthFalloffEnd);
			writer.Write(FogPropertiesAboveWaterFogAmount);
			writer.Write(NoisePropertiesNormalsUVScale);
			writer.Write(FogPropertiesUnderWaterFogAmount);
			writer.Write(FogPropertiesUnderWaterFogNearPlaneDistance);
			writer.Write(FogPropertiesUnderWaterFogFarPlaneDistance);
			writer.Write(WaterPropertiesDistortionAmount);
			writer.Write(WaterPropertiesShininess);
			writer.Write(WaterPropertiesReflectionHDRMult);
			writer.Write(WaterPropertiesLightRadius);
			writer.Write(WaterPropertiesLightBrightness);
			writer.Write(NoisePropertiesNoiseLayerOneUVScale);
			writer.Write(NoisePropertiesNoiseLayerTwoUVScale);
			writer.Write(NoisePropertiesNoiseLayerThreeUVScale);
			writer.Write(NoisePropertiesNoiseLayerOneAmplitudeScale);
			writer.Write(NoisePropertiesNoiseLayerTwoAmplitudeScale);
			writer.Write(NoisePropertiesNoiseLayerThreeAmplitudeScale);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();

			ele.TryPathTo("WaterProperties/SunPower", true, out subEle);
			subEle.Value = WaterPropertiesSunPower.ToString("G15");

			ele.TryPathTo("WaterProperties/ReflectivityAmount", true, out subEle);
			subEle.Value = WaterPropertiesReflectivityAmount.ToString("G15");

			ele.TryPathTo("WaterProperties/FresnelAmount", true, out subEle);
			subEle.Value = WaterPropertiesFresnelAmount.ToString("G15");

			WriteUnused1XML(ele, master);

			ele.TryPathTo("FogProperties/AboveWater/FogNearPlaneDistance", true, out subEle);
			subEle.Value = FogPropertiesAboveWaterFogNearPlaneDistance.ToString("G15");

			ele.TryPathTo("FogProperties/AboveWater/FogFarPlaneDistance", true, out subEle);
			subEle.Value = FogPropertiesAboveWaterFogFarPlaneDistance.ToString("G15");

			ele.TryPathTo("Color/Shallow", true, out subEle);
			ColorShallow.WriteXML(subEle, master);

			ele.TryPathTo("Color/Deep", true, out subEle);
			ColorDeep.WriteXML(subEle, master);

			ele.TryPathTo("Color/Reflection", true, out subEle);
			ColorReflection.WriteXML(subEle, master);

			WriteUnused2XML(ele, master);

			ele.TryPathTo("RainSimulator/Force", true, out subEle);
			subEle.Value = RainSimulatorForce.ToString("G15");

			ele.TryPathTo("RainSimulator/Velocity", true, out subEle);
			subEle.Value = RainSimulatorVelocity.ToString("G15");

			ele.TryPathTo("RainSimulator/Falloff", true, out subEle);
			subEle.Value = RainSimulatorFalloff.ToString("G15");

			ele.TryPathTo("RainSimulator/Dampener", true, out subEle);
			subEle.Value = RainSimulatorDampener.ToString("G15");

			ele.TryPathTo("DisplacementSimulator/StartingSize", true, out subEle);
			subEle.Value = DisplacementSimulatorStartingSize.ToString("G15");

			ele.TryPathTo("DisplacementSimulator/Force", true, out subEle);
			subEle.Value = DisplacementSimulatorForce.ToString("G15");

			ele.TryPathTo("DisplacementSimulator/Velocity", true, out subEle);
			subEle.Value = DisplacementSimulatorVelocity.ToString("G15");

			ele.TryPathTo("DisplacementSimulator/Falloff", true, out subEle);
			subEle.Value = DisplacementSimulatorFalloff.ToString("G15");

			ele.TryPathTo("DisplacementSimulator/Dampener", true, out subEle);
			subEle.Value = DisplacementSimulatorDampener.ToString("G15");

			ele.TryPathTo("RainSimulator/StartingSize", true, out subEle);
			subEle.Value = RainSimulatorStartingSize.ToString("G15");

			ele.TryPathTo("NoiseProperties/Normals/NoiseScale", true, out subEle);
			subEle.Value = NoisePropertiesNormalsNoiseScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerOne/WindDirection", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerOneWindDirection.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerTwo/WindDirection", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerTwoWindDirection.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerThree/WindDirection", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerThreeWindDirection.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerOne/WindSpeed", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerOneWindSpeed.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerTwo/WindSpeed", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerTwoWindSpeed.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerThree/WindSpeed", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerThreeWindSpeed.ToString("G15");

			ele.TryPathTo("NoiseProperties/Normals/DepthFalloff/Start", true, out subEle);
			subEle.Value = NoisePropertiesNormalsDepthFalloffStart.ToString("G15");

			ele.TryPathTo("NoiseProperties/Normals/DepthFalloff/End", true, out subEle);
			subEle.Value = NoisePropertiesNormalsDepthFalloffEnd.ToString("G15");

			ele.TryPathTo("FogProperties/AboveWater/FogAmount", true, out subEle);
			subEle.Value = FogPropertiesAboveWaterFogAmount.ToString("G15");

			ele.TryPathTo("NoiseProperties/Normals/UVScale", true, out subEle);
			subEle.Value = NoisePropertiesNormalsUVScale.ToString("G15");

			ele.TryPathTo("FogProperties/UnderWater/FogAmount", true, out subEle);
			subEle.Value = FogPropertiesUnderWaterFogAmount.ToString("G15");

			ele.TryPathTo("FogProperties/UnderWater/FogNearPlaneDistance", true, out subEle);
			subEle.Value = FogPropertiesUnderWaterFogNearPlaneDistance.ToString("G15");

			ele.TryPathTo("FogProperties/UnderWater/FogFarPlaneDistance", true, out subEle);
			subEle.Value = FogPropertiesUnderWaterFogFarPlaneDistance.ToString("G15");

			ele.TryPathTo("WaterProperties/DistortionAmount", true, out subEle);
			subEle.Value = WaterPropertiesDistortionAmount.ToString("G15");

			ele.TryPathTo("WaterProperties/Shininess", true, out subEle);
			subEle.Value = WaterPropertiesShininess.ToString("G15");

			ele.TryPathTo("WaterProperties/ReflectionHDRMult", true, out subEle);
			subEle.Value = WaterPropertiesReflectionHDRMult.ToString("G15");

			ele.TryPathTo("WaterProperties/LightRadius", true, out subEle);
			subEle.Value = WaterPropertiesLightRadius.ToString("G15");

			ele.TryPathTo("WaterProperties/LightBrightness", true, out subEle);
			subEle.Value = WaterPropertiesLightBrightness.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerOne/UVScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerOneUVScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerTwo/UVScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerTwoUVScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerThree/UVScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerThreeUVScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerOne/AmplitudeScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerOneAmplitudeScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerTwo/AmplitudeScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerTwoAmplitudeScale.ToString("G15");

			ele.TryPathTo("NoiseProperties/NoiseLayerThree/AmplitudeScale", true, out subEle);
			subEle.Value = NoisePropertiesNoiseLayerThreeAmplitudeScale.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToBytes();

			if (ele.TryPathTo("WaterProperties/SunPower", false, out subEle))
				WaterPropertiesSunPower = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/ReflectivityAmount", false, out subEle))
				WaterPropertiesReflectivityAmount = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/FresnelAmount", false, out subEle))
				WaterPropertiesFresnelAmount = subEle.ToSingle();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("FogProperties/AboveWater/FogNearPlaneDistance", false, out subEle))
				FogPropertiesAboveWaterFogNearPlaneDistance = subEle.ToSingle();

			if (ele.TryPathTo("FogProperties/AboveWater/FogFarPlaneDistance", false, out subEle))
				FogPropertiesAboveWaterFogFarPlaneDistance = subEle.ToSingle();

			if (ele.TryPathTo("Color/Shallow", false, out subEle))
				ColorShallow.ReadXML(subEle, master);

			if (ele.TryPathTo("Color/Deep", false, out subEle))
				ColorDeep.ReadXML(subEle, master);

			if (ele.TryPathTo("Color/Reflection", false, out subEle))
				ColorReflection.ReadXML(subEle, master);

			ReadUnused2XML(ele, master);

			if (ele.TryPathTo("RainSimulator/Force", false, out subEle))
				RainSimulatorForce = subEle.ToSingle();

			if (ele.TryPathTo("RainSimulator/Velocity", false, out subEle))
				RainSimulatorVelocity = subEle.ToSingle();

			if (ele.TryPathTo("RainSimulator/Falloff", false, out subEle))
				RainSimulatorFalloff = subEle.ToSingle();

			if (ele.TryPathTo("RainSimulator/Dampener", false, out subEle))
				RainSimulatorDampener = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementSimulator/StartingSize", false, out subEle))
				DisplacementSimulatorStartingSize = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementSimulator/Force", false, out subEle))
				DisplacementSimulatorForce = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementSimulator/Velocity", false, out subEle))
				DisplacementSimulatorVelocity = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementSimulator/Falloff", false, out subEle))
				DisplacementSimulatorFalloff = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementSimulator/Dampener", false, out subEle))
				DisplacementSimulatorDampener = subEle.ToSingle();

			if (ele.TryPathTo("RainSimulator/StartingSize", false, out subEle))
				RainSimulatorStartingSize = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/Normals/NoiseScale", false, out subEle))
				NoisePropertiesNormalsNoiseScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerOne/WindDirection", false, out subEle))
				NoisePropertiesNoiseLayerOneWindDirection = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerTwo/WindDirection", false, out subEle))
				NoisePropertiesNoiseLayerTwoWindDirection = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerThree/WindDirection", false, out subEle))
				NoisePropertiesNoiseLayerThreeWindDirection = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerOne/WindSpeed", false, out subEle))
				NoisePropertiesNoiseLayerOneWindSpeed = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerTwo/WindSpeed", false, out subEle))
				NoisePropertiesNoiseLayerTwoWindSpeed = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerThree/WindSpeed", false, out subEle))
				NoisePropertiesNoiseLayerThreeWindSpeed = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/Normals/DepthFalloff/Start", false, out subEle))
				NoisePropertiesNormalsDepthFalloffStart = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/Normals/DepthFalloff/End", false, out subEle))
				NoisePropertiesNormalsDepthFalloffEnd = subEle.ToSingle();

			if (ele.TryPathTo("FogProperties/AboveWater/FogAmount", false, out subEle))
				FogPropertiesAboveWaterFogAmount = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/Normals/UVScale", false, out subEle))
				NoisePropertiesNormalsUVScale = subEle.ToSingle();

			if (ele.TryPathTo("FogProperties/UnderWater/FogAmount", false, out subEle))
				FogPropertiesUnderWaterFogAmount = subEle.ToSingle();

			if (ele.TryPathTo("FogProperties/UnderWater/FogNearPlaneDistance", false, out subEle))
				FogPropertiesUnderWaterFogNearPlaneDistance = subEle.ToSingle();

			if (ele.TryPathTo("FogProperties/UnderWater/FogFarPlaneDistance", false, out subEle))
				FogPropertiesUnderWaterFogFarPlaneDistance = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/DistortionAmount", false, out subEle))
				WaterPropertiesDistortionAmount = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/Shininess", false, out subEle))
				WaterPropertiesShininess = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/ReflectionHDRMult", false, out subEle))
				WaterPropertiesReflectionHDRMult = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/LightRadius", false, out subEle))
				WaterPropertiesLightRadius = subEle.ToSingle();

			if (ele.TryPathTo("WaterProperties/LightBrightness", false, out subEle))
				WaterPropertiesLightBrightness = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerOne/UVScale", false, out subEle))
				NoisePropertiesNoiseLayerOneUVScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerTwo/UVScale", false, out subEle))
				NoisePropertiesNoiseLayerTwoUVScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerThree/UVScale", false, out subEle))
				NoisePropertiesNoiseLayerThreeUVScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerOne/AmplitudeScale", false, out subEle))
				NoisePropertiesNoiseLayerOneAmplitudeScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerTwo/AmplitudeScale", false, out subEle))
				NoisePropertiesNoiseLayerTwoAmplitudeScale = subEle.ToSingle();

			if (ele.TryPathTo("NoiseProperties/NoiseLayerThree/AmplitudeScale", false, out subEle))
				NoisePropertiesNoiseLayerThreeAmplitudeScale = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new WaterData(this);
		}

        public int CompareTo(WaterData other)
        {
			return WaterPropertiesSunPower.CompareTo(other.WaterPropertiesSunPower);
        }

        public static bool operator >(WaterData objA, WaterData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WaterData objA, WaterData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WaterData objA, WaterData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WaterData objA, WaterData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(WaterData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Unknown.SequenceEqual(other.Unknown) &&
				WaterPropertiesSunPower == other.WaterPropertiesSunPower &&
				WaterPropertiesReflectivityAmount == other.WaterPropertiesReflectivityAmount &&
				WaterPropertiesFresnelAmount == other.WaterPropertiesFresnelAmount &&
				Unused1.SequenceEqual(other.Unused1) &&
				FogPropertiesAboveWaterFogNearPlaneDistance == other.FogPropertiesAboveWaterFogNearPlaneDistance &&
				FogPropertiesAboveWaterFogFarPlaneDistance == other.FogPropertiesAboveWaterFogFarPlaneDistance &&
				ColorShallow == other.ColorShallow &&
				ColorDeep == other.ColorDeep &&
				ColorReflection == other.ColorReflection &&
				Unused2.SequenceEqual(other.Unused2) &&
				RainSimulatorForce == other.RainSimulatorForce &&
				RainSimulatorVelocity == other.RainSimulatorVelocity &&
				RainSimulatorFalloff == other.RainSimulatorFalloff &&
				RainSimulatorDampener == other.RainSimulatorDampener &&
				DisplacementSimulatorStartingSize == other.DisplacementSimulatorStartingSize &&
				DisplacementSimulatorForce == other.DisplacementSimulatorForce &&
				DisplacementSimulatorVelocity == other.DisplacementSimulatorVelocity &&
				DisplacementSimulatorFalloff == other.DisplacementSimulatorFalloff &&
				DisplacementSimulatorDampener == other.DisplacementSimulatorDampener &&
				RainSimulatorStartingSize == other.RainSimulatorStartingSize &&
				NoisePropertiesNormalsNoiseScale == other.NoisePropertiesNormalsNoiseScale &&
				NoisePropertiesNoiseLayerOneWindDirection == other.NoisePropertiesNoiseLayerOneWindDirection &&
				NoisePropertiesNoiseLayerTwoWindDirection == other.NoisePropertiesNoiseLayerTwoWindDirection &&
				NoisePropertiesNoiseLayerThreeWindDirection == other.NoisePropertiesNoiseLayerThreeWindDirection &&
				NoisePropertiesNoiseLayerOneWindSpeed == other.NoisePropertiesNoiseLayerOneWindSpeed &&
				NoisePropertiesNoiseLayerTwoWindSpeed == other.NoisePropertiesNoiseLayerTwoWindSpeed &&
				NoisePropertiesNoiseLayerThreeWindSpeed == other.NoisePropertiesNoiseLayerThreeWindSpeed &&
				NoisePropertiesNormalsDepthFalloffStart == other.NoisePropertiesNormalsDepthFalloffStart &&
				NoisePropertiesNormalsDepthFalloffEnd == other.NoisePropertiesNormalsDepthFalloffEnd &&
				FogPropertiesAboveWaterFogAmount == other.FogPropertiesAboveWaterFogAmount &&
				NoisePropertiesNormalsUVScale == other.NoisePropertiesNormalsUVScale &&
				FogPropertiesUnderWaterFogAmount == other.FogPropertiesUnderWaterFogAmount &&
				FogPropertiesUnderWaterFogNearPlaneDistance == other.FogPropertiesUnderWaterFogNearPlaneDistance &&
				FogPropertiesUnderWaterFogFarPlaneDistance == other.FogPropertiesUnderWaterFogFarPlaneDistance &&
				WaterPropertiesDistortionAmount == other.WaterPropertiesDistortionAmount &&
				WaterPropertiesShininess == other.WaterPropertiesShininess &&
				WaterPropertiesReflectionHDRMult == other.WaterPropertiesReflectionHDRMult &&
				WaterPropertiesLightRadius == other.WaterPropertiesLightRadius &&
				WaterPropertiesLightBrightness == other.WaterPropertiesLightBrightness &&
				NoisePropertiesNoiseLayerOneUVScale == other.NoisePropertiesNoiseLayerOneUVScale &&
				NoisePropertiesNoiseLayerTwoUVScale == other.NoisePropertiesNoiseLayerTwoUVScale &&
				NoisePropertiesNoiseLayerThreeUVScale == other.NoisePropertiesNoiseLayerThreeUVScale &&
				NoisePropertiesNoiseLayerOneAmplitudeScale == other.NoisePropertiesNoiseLayerOneAmplitudeScale &&
				NoisePropertiesNoiseLayerTwoAmplitudeScale == other.NoisePropertiesNoiseLayerTwoAmplitudeScale &&
				NoisePropertiesNoiseLayerThreeAmplitudeScale == other.NoisePropertiesNoiseLayerThreeAmplitudeScale;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WaterData other = obj as WaterData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return WaterPropertiesSunPower.GetHashCode();
        }

        public static bool operator ==(WaterData objA, WaterData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(WaterData objA, WaterData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }

		partial void ReadUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void ReadUnused2XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused1XML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnused2XML(XElement ele, ElderScrollsPlugin master);
	}
}