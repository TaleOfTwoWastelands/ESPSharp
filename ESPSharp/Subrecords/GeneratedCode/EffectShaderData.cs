
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
	public partial class EffectShaderData : Subrecord, ICloneable, IComparable<EffectShaderData>, IEquatable<EffectShaderData>  
	{
		public EffectShaderFlags Flags { get; set; }
		public Byte[] Unused { get; set; }
		public BlendMode MembraneShaderSourceBlendMode { get; set; }
		public BlendOperation MembraneShaderBlendOperation { get; set; }
		public ZTestFunction MembraneShaderZTestFunction { get; set; }
		public Color Fill_TextureEffectColor { get; set; }
		public Single Fill_TextureEffectAlphaFadeTimeIn { get; set; }
		public Single Fill_TextureEffectAlphaFadeTimeFull { get; set; }
		public Single Fill_TextureEffectAlphaFadeTimeOut { get; set; }
		public Single Fill_TextureEffectAlphaPersistentRatio { get; set; }
		public Single Fill_TextureEffectAlphaPulseAmplitude { get; set; }
		public Single Fill_TextureEffectAlphaPulseFrequency { get; set; }
		public Single Fill_TextureEffectTextureAnimationSpeedU { get; set; }
		public Single Fill_TextureEffectTextureAnimationSpeedV { get; set; }
		public Single EdgeEffectFallOff { get; set; }
		public Color EdgeEffectColor { get; set; }
		public Single EdgeEffectAlphaFadeTimeIn { get; set; }
		public Single EdgeEffectAlphaFadeTimeFull { get; set; }
		public Single EdgeEffectAlphaFadeTimeOut { get; set; }
		public Single EdgeEffectAlphaPersistentRatio { get; set; }
		public Single EdgeEffectAlphaPulseAmplitude { get; set; }
		public Single EdgeEffectAlphaPulseFrequency { get; set; }
		public Single EdgeEffectFill_TextureEffectFullAlphaRatio { get; set; }
		public Single EdgeEffectFullAlphaRatio { get; set; }
		public BlendMode MembraneShaderDestBlendMode { get; set; }
		public BlendMode ParticleShaderSourceBlendMode { get; set; }
		public BlendOperation ParticleShaderBlendOperation { get; set; }
		public ZTestFunction ParticleShaderZTestFunction { get; set; }
		public BlendMode ParticleShaderDestBlendMode { get; set; }
		public Single ParticleShaderBirthTimeRampUp { get; set; }
		public Single ParticleShaderBirthTimeFull { get; set; }
		public Single ParticleShaderBirthTimeRampDown { get; set; }
		public Single ParticleShaderFullBirthRatio { get; set; }
		public Single ParticleShaderPersistentBirthRatio { get; set; }
		public Single ParticleShaderLifetimeBase { get; set; }
		public Single ParticleShaderLifetimeVariance { get; set; }
		public Single ParticleShaderNormalMovementInitialSpeed { get; set; }
		public Single ParticleShaderNormalMovementAcceleration { get; set; }
		public Single ParticleShaderInitialVelocity1 { get; set; }
		public Single ParticleShaderInitialVelocity2 { get; set; }
		public Single ParticleShaderInitialVelocity3 { get; set; }
		public Single ParticleShaderAcceleration1 { get; set; }
		public Single ParticleShaderAcceleration2 { get; set; }
		public Single ParticleShaderAcceleration3 { get; set; }
		public Single ParticleShaderScaleKey1 { get; set; }
		public Single ParticleShaderScaleKey2 { get; set; }
		public Single ParticleShaderScaleKey1Time { get; set; }
		public Single ParticleShaderScaleKey2Time { get; set; }
		public Color ParticleShaderColorKey1 { get; set; }
		public Color ParticleShaderColorKey2 { get; set; }
		public Color ParticleShaderColorKey3 { get; set; }
		public Single ParticleShaderColorKey1Alpha { get; set; }
		public Single ParticleShaderColorKey2Alpha { get; set; }
		public Single ParticleShaderColorKey3Alpha { get; set; }
		public Single ParticleShaderColorKey1Time { get; set; }
		public Single ParticleShaderColorKey2Time { get; set; }
		public Single ParticleShaderColorKey3Time { get; set; }
		public Single ParticleShaderInitSpeedAlongNormalVariance { get; set; }
		public Single ParticleShaderInitialRotationValue { get; set; }
		public Single ParticleShaderInitialRotationVariance { get; set; }
		public Single ParticleShaderRotationSpeedValue { get; set; }
		public Single ParticleShaderRotationSpeedVariance { get; set; }
		public FormID AddonModelsModel { get; set; }
		public Single HolesTimeStart { get; set; }
		public Single HolesTimeEnd { get; set; }
		public Single HolesValueStart { get; set; }
		public Single HolesValueEnd { get; set; }
		public Single EdgeWidth { get; set; }
		public Color EdgeColor { get; set; }
		public Single ExplosionWindSpeed { get; set; }
		public UInt32 TextureCountU { get; set; }
		public UInt32 TextureCountV { get; set; }
		public Single AddonModelsFadeTimeIn { get; set; }
		public Single AddonModelsFadeTimeOut { get; set; }
		public Single AddonModelsScaleIn { get; set; }
		public Single AddonModelsScaleOut { get; set; }
		public Single AddonModelsScaleTimeIn { get; set; }
		public Single AddonModelsScaleTimeOut { get; set; }

		public EffectShaderData(string Tag = null)
			:base(Tag)
		{
			Flags = new EffectShaderFlags();
			Unused = new byte[3];
			MembraneShaderSourceBlendMode = new BlendMode();
			MembraneShaderBlendOperation = new BlendOperation();
			MembraneShaderZTestFunction = new ZTestFunction();
			Fill_TextureEffectColor = new Color();
			Fill_TextureEffectAlphaFadeTimeIn = new Single();
			Fill_TextureEffectAlphaFadeTimeFull = new Single();
			Fill_TextureEffectAlphaFadeTimeOut = new Single();
			Fill_TextureEffectAlphaPersistentRatio = new Single();
			Fill_TextureEffectAlphaPulseAmplitude = new Single();
			Fill_TextureEffectAlphaPulseFrequency = new Single();
			Fill_TextureEffectTextureAnimationSpeedU = new Single();
			Fill_TextureEffectTextureAnimationSpeedV = new Single();
			EdgeEffectFallOff = new Single();
			EdgeEffectColor = new Color();
			EdgeEffectAlphaFadeTimeIn = new Single();
			EdgeEffectAlphaFadeTimeFull = new Single();
			EdgeEffectAlphaFadeTimeOut = new Single();
			EdgeEffectAlphaPersistentRatio = new Single();
			EdgeEffectAlphaPulseAmplitude = new Single();
			EdgeEffectAlphaPulseFrequency = new Single();
			EdgeEffectFill_TextureEffectFullAlphaRatio = new Single();
			EdgeEffectFullAlphaRatio = new Single();
			MembraneShaderDestBlendMode = new BlendMode();
			ParticleShaderSourceBlendMode = new BlendMode();
			ParticleShaderBlendOperation = new BlendOperation();
			ParticleShaderZTestFunction = new ZTestFunction();
			ParticleShaderDestBlendMode = new BlendMode();
			ParticleShaderBirthTimeRampUp = new Single();
			ParticleShaderBirthTimeFull = new Single();
			ParticleShaderBirthTimeRampDown = new Single();
			ParticleShaderFullBirthRatio = new Single();
			ParticleShaderPersistentBirthRatio = new Single();
			ParticleShaderLifetimeBase = new Single();
			ParticleShaderLifetimeVariance = new Single();
			ParticleShaderNormalMovementInitialSpeed = new Single();
			ParticleShaderNormalMovementAcceleration = new Single();
			ParticleShaderInitialVelocity1 = new Single();
			ParticleShaderInitialVelocity2 = new Single();
			ParticleShaderInitialVelocity3 = new Single();
			ParticleShaderAcceleration1 = new Single();
			ParticleShaderAcceleration2 = new Single();
			ParticleShaderAcceleration3 = new Single();
			ParticleShaderScaleKey1 = new Single();
			ParticleShaderScaleKey2 = new Single();
			ParticleShaderScaleKey1Time = new Single();
			ParticleShaderScaleKey2Time = new Single();
			ParticleShaderColorKey1 = new Color();
			ParticleShaderColorKey2 = new Color();
			ParticleShaderColorKey3 = new Color();
			ParticleShaderColorKey1Alpha = new Single();
			ParticleShaderColorKey2Alpha = new Single();
			ParticleShaderColorKey3Alpha = new Single();
			ParticleShaderColorKey1Time = new Single();
			ParticleShaderColorKey2Time = new Single();
			ParticleShaderColorKey3Time = new Single();
			ParticleShaderInitSpeedAlongNormalVariance = new Single();
			ParticleShaderInitialRotationValue = new Single();
			ParticleShaderInitialRotationVariance = new Single();
			ParticleShaderRotationSpeedValue = new Single();
			ParticleShaderRotationSpeedVariance = new Single();
			AddonModelsModel = new FormID();
			HolesTimeStart = new Single();
			HolesTimeEnd = new Single();
			HolesValueStart = new Single();
			HolesValueEnd = new Single();
			EdgeWidth = new Single();
			EdgeColor = new Color();
			ExplosionWindSpeed = new Single();
			TextureCountU = new UInt32();
			TextureCountV = new UInt32();
			AddonModelsFadeTimeIn = new Single();
			AddonModelsFadeTimeOut = new Single();
			AddonModelsScaleIn = new Single();
			AddonModelsScaleOut = new Single();
			AddonModelsScaleTimeIn = new Single();
			AddonModelsScaleTimeOut = new Single();
		}

		public EffectShaderData(EffectShaderFlags Flags, Byte[] Unused, BlendMode MembraneShaderSourceBlendMode, BlendOperation MembraneShaderBlendOperation, ZTestFunction MembraneShaderZTestFunction, Color Fill_TextureEffectColor, Single Fill_TextureEffectAlphaFadeTimeIn, Single Fill_TextureEffectAlphaFadeTimeFull, Single Fill_TextureEffectAlphaFadeTimeOut, Single Fill_TextureEffectAlphaPersistentRatio, Single Fill_TextureEffectAlphaPulseAmplitude, Single Fill_TextureEffectAlphaPulseFrequency, Single Fill_TextureEffectTextureAnimationSpeedU, Single Fill_TextureEffectTextureAnimationSpeedV, Single EdgeEffectFallOff, Color EdgeEffectColor, Single EdgeEffectAlphaFadeTimeIn, Single EdgeEffectAlphaFadeTimeFull, Single EdgeEffectAlphaFadeTimeOut, Single EdgeEffectAlphaPersistentRatio, Single EdgeEffectAlphaPulseAmplitude, Single EdgeEffectAlphaPulseFrequency, Single EdgeEffectFill_TextureEffectFullAlphaRatio, Single EdgeEffectFullAlphaRatio, BlendMode MembraneShaderDestBlendMode, BlendMode ParticleShaderSourceBlendMode, BlendOperation ParticleShaderBlendOperation, ZTestFunction ParticleShaderZTestFunction, BlendMode ParticleShaderDestBlendMode, Single ParticleShaderBirthTimeRampUp, Single ParticleShaderBirthTimeFull, Single ParticleShaderBirthTimeRampDown, Single ParticleShaderFullBirthRatio, Single ParticleShaderPersistentBirthRatio, Single ParticleShaderLifetimeBase, Single ParticleShaderLifetimeVariance, Single ParticleShaderNormalMovementInitialSpeed, Single ParticleShaderNormalMovementAcceleration, Single ParticleShaderInitialVelocity1, Single ParticleShaderInitialVelocity2, Single ParticleShaderInitialVelocity3, Single ParticleShaderAcceleration1, Single ParticleShaderAcceleration2, Single ParticleShaderAcceleration3, Single ParticleShaderScaleKey1, Single ParticleShaderScaleKey2, Single ParticleShaderScaleKey1Time, Single ParticleShaderScaleKey2Time, Color ParticleShaderColorKey1, Color ParticleShaderColorKey2, Color ParticleShaderColorKey3, Single ParticleShaderColorKey1Alpha, Single ParticleShaderColorKey2Alpha, Single ParticleShaderColorKey3Alpha, Single ParticleShaderColorKey1Time, Single ParticleShaderColorKey2Time, Single ParticleShaderColorKey3Time, Single ParticleShaderInitSpeedAlongNormalVariance, Single ParticleShaderInitialRotationValue, Single ParticleShaderInitialRotationVariance, Single ParticleShaderRotationSpeedValue, Single ParticleShaderRotationSpeedVariance, FormID AddonModelsModel, Single HolesTimeStart, Single HolesTimeEnd, Single HolesValueStart, Single HolesValueEnd, Single EdgeWidth, Color EdgeColor, Single ExplosionWindSpeed, UInt32 TextureCountU, UInt32 TextureCountV, Single AddonModelsFadeTimeIn, Single AddonModelsFadeTimeOut, Single AddonModelsScaleIn, Single AddonModelsScaleOut, Single AddonModelsScaleTimeIn, Single AddonModelsScaleTimeOut)
		{
			this.Flags = Flags;
			this.Unused = Unused;
			this.MembraneShaderSourceBlendMode = MembraneShaderSourceBlendMode;
			this.MembraneShaderBlendOperation = MembraneShaderBlendOperation;
			this.MembraneShaderZTestFunction = MembraneShaderZTestFunction;
			this.Fill_TextureEffectColor = Fill_TextureEffectColor;
			this.Fill_TextureEffectAlphaFadeTimeIn = Fill_TextureEffectAlphaFadeTimeIn;
			this.Fill_TextureEffectAlphaFadeTimeFull = Fill_TextureEffectAlphaFadeTimeFull;
			this.Fill_TextureEffectAlphaFadeTimeOut = Fill_TextureEffectAlphaFadeTimeOut;
			this.Fill_TextureEffectAlphaPersistentRatio = Fill_TextureEffectAlphaPersistentRatio;
			this.Fill_TextureEffectAlphaPulseAmplitude = Fill_TextureEffectAlphaPulseAmplitude;
			this.Fill_TextureEffectAlphaPulseFrequency = Fill_TextureEffectAlphaPulseFrequency;
			this.Fill_TextureEffectTextureAnimationSpeedU = Fill_TextureEffectTextureAnimationSpeedU;
			this.Fill_TextureEffectTextureAnimationSpeedV = Fill_TextureEffectTextureAnimationSpeedV;
			this.EdgeEffectFallOff = EdgeEffectFallOff;
			this.EdgeEffectColor = EdgeEffectColor;
			this.EdgeEffectAlphaFadeTimeIn = EdgeEffectAlphaFadeTimeIn;
			this.EdgeEffectAlphaFadeTimeFull = EdgeEffectAlphaFadeTimeFull;
			this.EdgeEffectAlphaFadeTimeOut = EdgeEffectAlphaFadeTimeOut;
			this.EdgeEffectAlphaPersistentRatio = EdgeEffectAlphaPersistentRatio;
			this.EdgeEffectAlphaPulseAmplitude = EdgeEffectAlphaPulseAmplitude;
			this.EdgeEffectAlphaPulseFrequency = EdgeEffectAlphaPulseFrequency;
			this.EdgeEffectFill_TextureEffectFullAlphaRatio = EdgeEffectFill_TextureEffectFullAlphaRatio;
			this.EdgeEffectFullAlphaRatio = EdgeEffectFullAlphaRatio;
			this.MembraneShaderDestBlendMode = MembraneShaderDestBlendMode;
			this.ParticleShaderSourceBlendMode = ParticleShaderSourceBlendMode;
			this.ParticleShaderBlendOperation = ParticleShaderBlendOperation;
			this.ParticleShaderZTestFunction = ParticleShaderZTestFunction;
			this.ParticleShaderDestBlendMode = ParticleShaderDestBlendMode;
			this.ParticleShaderBirthTimeRampUp = ParticleShaderBirthTimeRampUp;
			this.ParticleShaderBirthTimeFull = ParticleShaderBirthTimeFull;
			this.ParticleShaderBirthTimeRampDown = ParticleShaderBirthTimeRampDown;
			this.ParticleShaderFullBirthRatio = ParticleShaderFullBirthRatio;
			this.ParticleShaderPersistentBirthRatio = ParticleShaderPersistentBirthRatio;
			this.ParticleShaderLifetimeBase = ParticleShaderLifetimeBase;
			this.ParticleShaderLifetimeVariance = ParticleShaderLifetimeVariance;
			this.ParticleShaderNormalMovementInitialSpeed = ParticleShaderNormalMovementInitialSpeed;
			this.ParticleShaderNormalMovementAcceleration = ParticleShaderNormalMovementAcceleration;
			this.ParticleShaderInitialVelocity1 = ParticleShaderInitialVelocity1;
			this.ParticleShaderInitialVelocity2 = ParticleShaderInitialVelocity2;
			this.ParticleShaderInitialVelocity3 = ParticleShaderInitialVelocity3;
			this.ParticleShaderAcceleration1 = ParticleShaderAcceleration1;
			this.ParticleShaderAcceleration2 = ParticleShaderAcceleration2;
			this.ParticleShaderAcceleration3 = ParticleShaderAcceleration3;
			this.ParticleShaderScaleKey1 = ParticleShaderScaleKey1;
			this.ParticleShaderScaleKey2 = ParticleShaderScaleKey2;
			this.ParticleShaderScaleKey1Time = ParticleShaderScaleKey1Time;
			this.ParticleShaderScaleKey2Time = ParticleShaderScaleKey2Time;
			this.ParticleShaderColorKey1 = ParticleShaderColorKey1;
			this.ParticleShaderColorKey2 = ParticleShaderColorKey2;
			this.ParticleShaderColorKey3 = ParticleShaderColorKey3;
			this.ParticleShaderColorKey1Alpha = ParticleShaderColorKey1Alpha;
			this.ParticleShaderColorKey2Alpha = ParticleShaderColorKey2Alpha;
			this.ParticleShaderColorKey3Alpha = ParticleShaderColorKey3Alpha;
			this.ParticleShaderColorKey1Time = ParticleShaderColorKey1Time;
			this.ParticleShaderColorKey2Time = ParticleShaderColorKey2Time;
			this.ParticleShaderColorKey3Time = ParticleShaderColorKey3Time;
			this.ParticleShaderInitSpeedAlongNormalVariance = ParticleShaderInitSpeedAlongNormalVariance;
			this.ParticleShaderInitialRotationValue = ParticleShaderInitialRotationValue;
			this.ParticleShaderInitialRotationVariance = ParticleShaderInitialRotationVariance;
			this.ParticleShaderRotationSpeedValue = ParticleShaderRotationSpeedValue;
			this.ParticleShaderRotationSpeedVariance = ParticleShaderRotationSpeedVariance;
			this.AddonModelsModel = AddonModelsModel;
			this.HolesTimeStart = HolesTimeStart;
			this.HolesTimeEnd = HolesTimeEnd;
			this.HolesValueStart = HolesValueStart;
			this.HolesValueEnd = HolesValueEnd;
			this.EdgeWidth = EdgeWidth;
			this.EdgeColor = EdgeColor;
			this.ExplosionWindSpeed = ExplosionWindSpeed;
			this.TextureCountU = TextureCountU;
			this.TextureCountV = TextureCountV;
			this.AddonModelsFadeTimeIn = AddonModelsFadeTimeIn;
			this.AddonModelsFadeTimeOut = AddonModelsFadeTimeOut;
			this.AddonModelsScaleIn = AddonModelsScaleIn;
			this.AddonModelsScaleOut = AddonModelsScaleOut;
			this.AddonModelsScaleTimeIn = AddonModelsScaleTimeIn;
			this.AddonModelsScaleTimeOut = AddonModelsScaleTimeOut;
		}

		public EffectShaderData(EffectShaderData copyObject)
		{
			Flags = copyObject.Flags;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			MembraneShaderSourceBlendMode = copyObject.MembraneShaderSourceBlendMode;
			MembraneShaderBlendOperation = copyObject.MembraneShaderBlendOperation;
			MembraneShaderZTestFunction = copyObject.MembraneShaderZTestFunction;
			if (copyObject.Fill_TextureEffectColor != null)
				Fill_TextureEffectColor = (Color)copyObject.Fill_TextureEffectColor.Clone();
			Fill_TextureEffectAlphaFadeTimeIn = copyObject.Fill_TextureEffectAlphaFadeTimeIn;
			Fill_TextureEffectAlphaFadeTimeFull = copyObject.Fill_TextureEffectAlphaFadeTimeFull;
			Fill_TextureEffectAlphaFadeTimeOut = copyObject.Fill_TextureEffectAlphaFadeTimeOut;
			Fill_TextureEffectAlphaPersistentRatio = copyObject.Fill_TextureEffectAlphaPersistentRatio;
			Fill_TextureEffectAlphaPulseAmplitude = copyObject.Fill_TextureEffectAlphaPulseAmplitude;
			Fill_TextureEffectAlphaPulseFrequency = copyObject.Fill_TextureEffectAlphaPulseFrequency;
			Fill_TextureEffectTextureAnimationSpeedU = copyObject.Fill_TextureEffectTextureAnimationSpeedU;
			Fill_TextureEffectTextureAnimationSpeedV = copyObject.Fill_TextureEffectTextureAnimationSpeedV;
			EdgeEffectFallOff = copyObject.EdgeEffectFallOff;
			if (copyObject.EdgeEffectColor != null)
				EdgeEffectColor = (Color)copyObject.EdgeEffectColor.Clone();
			EdgeEffectAlphaFadeTimeIn = copyObject.EdgeEffectAlphaFadeTimeIn;
			EdgeEffectAlphaFadeTimeFull = copyObject.EdgeEffectAlphaFadeTimeFull;
			EdgeEffectAlphaFadeTimeOut = copyObject.EdgeEffectAlphaFadeTimeOut;
			EdgeEffectAlphaPersistentRatio = copyObject.EdgeEffectAlphaPersistentRatio;
			EdgeEffectAlphaPulseAmplitude = copyObject.EdgeEffectAlphaPulseAmplitude;
			EdgeEffectAlphaPulseFrequency = copyObject.EdgeEffectAlphaPulseFrequency;
			EdgeEffectFill_TextureEffectFullAlphaRatio = copyObject.EdgeEffectFill_TextureEffectFullAlphaRatio;
			EdgeEffectFullAlphaRatio = copyObject.EdgeEffectFullAlphaRatio;
			MembraneShaderDestBlendMode = copyObject.MembraneShaderDestBlendMode;
			ParticleShaderSourceBlendMode = copyObject.ParticleShaderSourceBlendMode;
			ParticleShaderBlendOperation = copyObject.ParticleShaderBlendOperation;
			ParticleShaderZTestFunction = copyObject.ParticleShaderZTestFunction;
			ParticleShaderDestBlendMode = copyObject.ParticleShaderDestBlendMode;
			ParticleShaderBirthTimeRampUp = copyObject.ParticleShaderBirthTimeRampUp;
			ParticleShaderBirthTimeFull = copyObject.ParticleShaderBirthTimeFull;
			ParticleShaderBirthTimeRampDown = copyObject.ParticleShaderBirthTimeRampDown;
			ParticleShaderFullBirthRatio = copyObject.ParticleShaderFullBirthRatio;
			ParticleShaderPersistentBirthRatio = copyObject.ParticleShaderPersistentBirthRatio;
			ParticleShaderLifetimeBase = copyObject.ParticleShaderLifetimeBase;
			ParticleShaderLifetimeVariance = copyObject.ParticleShaderLifetimeVariance;
			ParticleShaderNormalMovementInitialSpeed = copyObject.ParticleShaderNormalMovementInitialSpeed;
			ParticleShaderNormalMovementAcceleration = copyObject.ParticleShaderNormalMovementAcceleration;
			ParticleShaderInitialVelocity1 = copyObject.ParticleShaderInitialVelocity1;
			ParticleShaderInitialVelocity2 = copyObject.ParticleShaderInitialVelocity2;
			ParticleShaderInitialVelocity3 = copyObject.ParticleShaderInitialVelocity3;
			ParticleShaderAcceleration1 = copyObject.ParticleShaderAcceleration1;
			ParticleShaderAcceleration2 = copyObject.ParticleShaderAcceleration2;
			ParticleShaderAcceleration3 = copyObject.ParticleShaderAcceleration3;
			ParticleShaderScaleKey1 = copyObject.ParticleShaderScaleKey1;
			ParticleShaderScaleKey2 = copyObject.ParticleShaderScaleKey2;
			ParticleShaderScaleKey1Time = copyObject.ParticleShaderScaleKey1Time;
			ParticleShaderScaleKey2Time = copyObject.ParticleShaderScaleKey2Time;
			if (copyObject.ParticleShaderColorKey1 != null)
				ParticleShaderColorKey1 = (Color)copyObject.ParticleShaderColorKey1.Clone();
			if (copyObject.ParticleShaderColorKey2 != null)
				ParticleShaderColorKey2 = (Color)copyObject.ParticleShaderColorKey2.Clone();
			if (copyObject.ParticleShaderColorKey3 != null)
				ParticleShaderColorKey3 = (Color)copyObject.ParticleShaderColorKey3.Clone();
			ParticleShaderColorKey1Alpha = copyObject.ParticleShaderColorKey1Alpha;
			ParticleShaderColorKey2Alpha = copyObject.ParticleShaderColorKey2Alpha;
			ParticleShaderColorKey3Alpha = copyObject.ParticleShaderColorKey3Alpha;
			ParticleShaderColorKey1Time = copyObject.ParticleShaderColorKey1Time;
			ParticleShaderColorKey2Time = copyObject.ParticleShaderColorKey2Time;
			ParticleShaderColorKey3Time = copyObject.ParticleShaderColorKey3Time;
			ParticleShaderInitSpeedAlongNormalVariance = copyObject.ParticleShaderInitSpeedAlongNormalVariance;
			ParticleShaderInitialRotationValue = copyObject.ParticleShaderInitialRotationValue;
			ParticleShaderInitialRotationVariance = copyObject.ParticleShaderInitialRotationVariance;
			ParticleShaderRotationSpeedValue = copyObject.ParticleShaderRotationSpeedValue;
			ParticleShaderRotationSpeedVariance = copyObject.ParticleShaderRotationSpeedVariance;
			if (copyObject.AddonModelsModel != null)
				AddonModelsModel = (FormID)copyObject.AddonModelsModel.Clone();
			HolesTimeStart = copyObject.HolesTimeStart;
			HolesTimeEnd = copyObject.HolesTimeEnd;
			HolesValueStart = copyObject.HolesValueStart;
			HolesValueEnd = copyObject.HolesValueEnd;
			EdgeWidth = copyObject.EdgeWidth;
			if (copyObject.EdgeColor != null)
				EdgeColor = (Color)copyObject.EdgeColor.Clone();
			ExplosionWindSpeed = copyObject.ExplosionWindSpeed;
			TextureCountU = copyObject.TextureCountU;
			TextureCountV = copyObject.TextureCountV;
			AddonModelsFadeTimeIn = copyObject.AddonModelsFadeTimeIn;
			AddonModelsFadeTimeOut = copyObject.AddonModelsFadeTimeOut;
			AddonModelsScaleIn = copyObject.AddonModelsScaleIn;
			AddonModelsScaleOut = copyObject.AddonModelsScaleOut;
			AddonModelsScaleTimeIn = copyObject.AddonModelsScaleTimeIn;
			AddonModelsScaleTimeOut = copyObject.AddonModelsScaleTimeOut;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<EffectShaderFlags>();
					Unused = subReader.ReadBytes(3);
					MembraneShaderSourceBlendMode = subReader.ReadEnum<BlendMode>();
					MembraneShaderBlendOperation = subReader.ReadEnum<BlendOperation>();
					MembraneShaderZTestFunction = subReader.ReadEnum<ZTestFunction>();
					Fill_TextureEffectColor.ReadBinary(subReader);
					Fill_TextureEffectAlphaFadeTimeIn = subReader.ReadSingle();
					Fill_TextureEffectAlphaFadeTimeFull = subReader.ReadSingle();
					Fill_TextureEffectAlphaFadeTimeOut = subReader.ReadSingle();
					Fill_TextureEffectAlphaPersistentRatio = subReader.ReadSingle();
					Fill_TextureEffectAlphaPulseAmplitude = subReader.ReadSingle();
					Fill_TextureEffectAlphaPulseFrequency = subReader.ReadSingle();
					Fill_TextureEffectTextureAnimationSpeedU = subReader.ReadSingle();
					Fill_TextureEffectTextureAnimationSpeedV = subReader.ReadSingle();
					EdgeEffectFallOff = subReader.ReadSingle();
					EdgeEffectColor.ReadBinary(subReader);
					EdgeEffectAlphaFadeTimeIn = subReader.ReadSingle();
					EdgeEffectAlphaFadeTimeFull = subReader.ReadSingle();
					EdgeEffectAlphaFadeTimeOut = subReader.ReadSingle();
					EdgeEffectAlphaPersistentRatio = subReader.ReadSingle();
					EdgeEffectAlphaPulseAmplitude = subReader.ReadSingle();
					EdgeEffectAlphaPulseFrequency = subReader.ReadSingle();
					EdgeEffectFill_TextureEffectFullAlphaRatio = subReader.ReadSingle();
					EdgeEffectFullAlphaRatio = subReader.ReadSingle();
					MembraneShaderDestBlendMode = subReader.ReadEnum<BlendMode>();
					ParticleShaderSourceBlendMode = subReader.ReadEnum<BlendMode>();
					ParticleShaderBlendOperation = subReader.ReadEnum<BlendOperation>();
					ParticleShaderZTestFunction = subReader.ReadEnum<ZTestFunction>();
					ParticleShaderDestBlendMode = subReader.ReadEnum<BlendMode>();
					ParticleShaderBirthTimeRampUp = subReader.ReadSingle();
					ParticleShaderBirthTimeFull = subReader.ReadSingle();
					ParticleShaderBirthTimeRampDown = subReader.ReadSingle();
					ParticleShaderFullBirthRatio = subReader.ReadSingle();
					ParticleShaderPersistentBirthRatio = subReader.ReadSingle();
					ParticleShaderLifetimeBase = subReader.ReadSingle();
					ParticleShaderLifetimeVariance = subReader.ReadSingle();
					ParticleShaderNormalMovementInitialSpeed = subReader.ReadSingle();
					ParticleShaderNormalMovementAcceleration = subReader.ReadSingle();
					ParticleShaderInitialVelocity1 = subReader.ReadSingle();
					ParticleShaderInitialVelocity2 = subReader.ReadSingle();
					ParticleShaderInitialVelocity3 = subReader.ReadSingle();
					ParticleShaderAcceleration1 = subReader.ReadSingle();
					ParticleShaderAcceleration2 = subReader.ReadSingle();
					ParticleShaderAcceleration3 = subReader.ReadSingle();
					ParticleShaderScaleKey1 = subReader.ReadSingle();
					ParticleShaderScaleKey2 = subReader.ReadSingle();
					ParticleShaderScaleKey1Time = subReader.ReadSingle();
					ParticleShaderScaleKey2Time = subReader.ReadSingle();
					ParticleShaderColorKey1.ReadBinary(subReader);
					ParticleShaderColorKey2.ReadBinary(subReader);
					ParticleShaderColorKey3.ReadBinary(subReader);
					ParticleShaderColorKey1Alpha = subReader.ReadSingle();
					ParticleShaderColorKey2Alpha = subReader.ReadSingle();
					ParticleShaderColorKey3Alpha = subReader.ReadSingle();
					ParticleShaderColorKey1Time = subReader.ReadSingle();
					ParticleShaderColorKey2Time = subReader.ReadSingle();
					ParticleShaderColorKey3Time = subReader.ReadSingle();
					ParticleShaderInitSpeedAlongNormalVariance = subReader.ReadSingle();
					ParticleShaderInitialRotationValue = subReader.ReadSingle();
					ParticleShaderInitialRotationVariance = subReader.ReadSingle();
					ParticleShaderRotationSpeedValue = subReader.ReadSingle();
					ParticleShaderRotationSpeedVariance = subReader.ReadSingle();
					AddonModelsModel.ReadBinary(subReader);
					HolesTimeStart = subReader.ReadSingle();
					HolesTimeEnd = subReader.ReadSingle();
					HolesValueStart = subReader.ReadSingle();
					HolesValueEnd = subReader.ReadSingle();
					EdgeWidth = subReader.ReadSingle();
					EdgeColor.ReadBinary(subReader);
					ExplosionWindSpeed = subReader.ReadSingle();
					TextureCountU = subReader.ReadUInt32();
					TextureCountV = subReader.ReadUInt32();
					AddonModelsFadeTimeIn = subReader.ReadSingle();
					AddonModelsFadeTimeOut = subReader.ReadSingle();
					AddonModelsScaleIn = subReader.ReadSingle();
					AddonModelsScaleOut = subReader.ReadSingle();
					AddonModelsScaleTimeIn = subReader.ReadSingle();
					AddonModelsScaleTimeOut = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
			writer.Write((UInt32)MembraneShaderSourceBlendMode);
			writer.Write((UInt32)MembraneShaderBlendOperation);
			writer.Write((UInt32)MembraneShaderZTestFunction);
			Fill_TextureEffectColor.WriteBinary(writer);
			writer.Write(Fill_TextureEffectAlphaFadeTimeIn);
			writer.Write(Fill_TextureEffectAlphaFadeTimeFull);
			writer.Write(Fill_TextureEffectAlphaFadeTimeOut);
			writer.Write(Fill_TextureEffectAlphaPersistentRatio);
			writer.Write(Fill_TextureEffectAlphaPulseAmplitude);
			writer.Write(Fill_TextureEffectAlphaPulseFrequency);
			writer.Write(Fill_TextureEffectTextureAnimationSpeedU);
			writer.Write(Fill_TextureEffectTextureAnimationSpeedV);
			writer.Write(EdgeEffectFallOff);
			EdgeEffectColor.WriteBinary(writer);
			writer.Write(EdgeEffectAlphaFadeTimeIn);
			writer.Write(EdgeEffectAlphaFadeTimeFull);
			writer.Write(EdgeEffectAlphaFadeTimeOut);
			writer.Write(EdgeEffectAlphaPersistentRatio);
			writer.Write(EdgeEffectAlphaPulseAmplitude);
			writer.Write(EdgeEffectAlphaPulseFrequency);
			writer.Write(EdgeEffectFill_TextureEffectFullAlphaRatio);
			writer.Write(EdgeEffectFullAlphaRatio);
			writer.Write((UInt32)MembraneShaderDestBlendMode);
			writer.Write((UInt32)ParticleShaderSourceBlendMode);
			writer.Write((UInt32)ParticleShaderBlendOperation);
			writer.Write((UInt32)ParticleShaderZTestFunction);
			writer.Write((UInt32)ParticleShaderDestBlendMode);
			writer.Write(ParticleShaderBirthTimeRampUp);
			writer.Write(ParticleShaderBirthTimeFull);
			writer.Write(ParticleShaderBirthTimeRampDown);
			writer.Write(ParticleShaderFullBirthRatio);
			writer.Write(ParticleShaderPersistentBirthRatio);
			writer.Write(ParticleShaderLifetimeBase);
			writer.Write(ParticleShaderLifetimeVariance);
			writer.Write(ParticleShaderNormalMovementInitialSpeed);
			writer.Write(ParticleShaderNormalMovementAcceleration);
			writer.Write(ParticleShaderInitialVelocity1);
			writer.Write(ParticleShaderInitialVelocity2);
			writer.Write(ParticleShaderInitialVelocity3);
			writer.Write(ParticleShaderAcceleration1);
			writer.Write(ParticleShaderAcceleration2);
			writer.Write(ParticleShaderAcceleration3);
			writer.Write(ParticleShaderScaleKey1);
			writer.Write(ParticleShaderScaleKey2);
			writer.Write(ParticleShaderScaleKey1Time);
			writer.Write(ParticleShaderScaleKey2Time);
			ParticleShaderColorKey1.WriteBinary(writer);
			ParticleShaderColorKey2.WriteBinary(writer);
			ParticleShaderColorKey3.WriteBinary(writer);
			writer.Write(ParticleShaderColorKey1Alpha);
			writer.Write(ParticleShaderColorKey2Alpha);
			writer.Write(ParticleShaderColorKey3Alpha);
			writer.Write(ParticleShaderColorKey1Time);
			writer.Write(ParticleShaderColorKey2Time);
			writer.Write(ParticleShaderColorKey3Time);
			writer.Write(ParticleShaderInitSpeedAlongNormalVariance);
			writer.Write(ParticleShaderInitialRotationValue);
			writer.Write(ParticleShaderInitialRotationVariance);
			writer.Write(ParticleShaderRotationSpeedValue);
			writer.Write(ParticleShaderRotationSpeedVariance);
			AddonModelsModel.WriteBinary(writer);
			writer.Write(HolesTimeStart);
			writer.Write(HolesTimeEnd);
			writer.Write(HolesValueStart);
			writer.Write(HolesValueEnd);
			writer.Write(EdgeWidth);
			EdgeColor.WriteBinary(writer);
			writer.Write(ExplosionWindSpeed);
			writer.Write(TextureCountU);
			writer.Write(TextureCountV);
			writer.Write(AddonModelsFadeTimeIn);
			writer.Write(AddonModelsFadeTimeOut);
			writer.Write(AddonModelsScaleIn);
			writer.Write(AddonModelsScaleOut);
			writer.Write(AddonModelsScaleTimeIn);
			writer.Write(AddonModelsScaleTimeOut);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("MembraneShader/SourceBlendMode", true, out subEle);
			subEle.Value = MembraneShaderSourceBlendMode.ToString();

			ele.TryPathTo("MembraneShader/BlendOperation", true, out subEle);
			subEle.Value = MembraneShaderBlendOperation.ToString();

			ele.TryPathTo("MembraneShader/ZTestFunction", true, out subEle);
			subEle.Value = MembraneShaderZTestFunction.ToString();

			ele.TryPathTo("Fill_TextureEffect/Color", true, out subEle);
			Fill_TextureEffectColor.WriteXML(subEle, master);

			ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/In", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaFadeTimeIn.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/Full", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaFadeTimeFull.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/Out", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaFadeTimeOut.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/Alpha/PersistentRatio", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaPersistentRatio.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/Alpha/Pulse/Amplitude", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaPulseAmplitude.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/Alpha/Pulse/Frequency", true, out subEle);
			subEle.Value = Fill_TextureEffectAlphaPulseFrequency.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/TextureAnimationSpeed/U", true, out subEle);
			subEle.Value = Fill_TextureEffectTextureAnimationSpeedU.ToString("G15");

			ele.TryPathTo("Fill_TextureEffect/TextureAnimationSpeed/V", true, out subEle);
			subEle.Value = Fill_TextureEffectTextureAnimationSpeedV.ToString("G15");

			ele.TryPathTo("EdgeEffect/FallOff", true, out subEle);
			subEle.Value = EdgeEffectFallOff.ToString("G15");

			ele.TryPathTo("EdgeEffect/Color", true, out subEle);
			EdgeEffectColor.WriteXML(subEle, master);

			ele.TryPathTo("EdgeEffect/Alpha/FadeTime/In", true, out subEle);
			subEle.Value = EdgeEffectAlphaFadeTimeIn.ToString("G15");

			ele.TryPathTo("EdgeEffect/Alpha/FadeTime/Full", true, out subEle);
			subEle.Value = EdgeEffectAlphaFadeTimeFull.ToString("G15");

			ele.TryPathTo("EdgeEffect/Alpha/FadeTime/Out", true, out subEle);
			subEle.Value = EdgeEffectAlphaFadeTimeOut.ToString("G15");

			ele.TryPathTo("EdgeEffect/Alpha/PersistentRatio", true, out subEle);
			subEle.Value = EdgeEffectAlphaPersistentRatio.ToString("G15");

			ele.TryPathTo("EdgeEffect/Alpha/Pulse/Amplitude", true, out subEle);
			subEle.Value = EdgeEffectAlphaPulseAmplitude.ToString("G15");

			ele.TryPathTo("EdgeEffect/Alpha/Pulse/Frequency", true, out subEle);
			subEle.Value = EdgeEffectAlphaPulseFrequency.ToString("G15");

			ele.TryPathTo("EdgeEffect/Fill_TextureEffect/FullAlphaRatio", true, out subEle);
			subEle.Value = EdgeEffectFill_TextureEffectFullAlphaRatio.ToString("G15");

			ele.TryPathTo("EdgeEffect/FullAlphaRatio", true, out subEle);
			subEle.Value = EdgeEffectFullAlphaRatio.ToString("G15");

			ele.TryPathTo("MembraneShader/DestBlendMode", true, out subEle);
			subEle.Value = MembraneShaderDestBlendMode.ToString();

			ele.TryPathTo("ParticleShader/SourceBlendMode", true, out subEle);
			subEle.Value = ParticleShaderSourceBlendMode.ToString();

			ele.TryPathTo("ParticleShader/BlendOperation", true, out subEle);
			subEle.Value = ParticleShaderBlendOperation.ToString();

			ele.TryPathTo("ParticleShader/ZTestFunction", true, out subEle);
			subEle.Value = ParticleShaderZTestFunction.ToString();

			ele.TryPathTo("ParticleShader/DestBlendMode", true, out subEle);
			subEle.Value = ParticleShaderDestBlendMode.ToString();

			ele.TryPathTo("ParticleShader/BirthTime/RampUp", true, out subEle);
			subEle.Value = ParticleShaderBirthTimeRampUp.ToString("G15");

			ele.TryPathTo("ParticleShader/BirthTime/Full", true, out subEle);
			subEle.Value = ParticleShaderBirthTimeFull.ToString("G15");

			ele.TryPathTo("ParticleShader/BirthTime/RampDown", true, out subEle);
			subEle.Value = ParticleShaderBirthTimeRampDown.ToString("G15");

			ele.TryPathTo("ParticleShader/FullBirthRatio", true, out subEle);
			subEle.Value = ParticleShaderFullBirthRatio.ToString("G15");

			ele.TryPathTo("ParticleShader/PersistentBirthRatio", true, out subEle);
			subEle.Value = ParticleShaderPersistentBirthRatio.ToString("G15");

			ele.TryPathTo("ParticleShader/Lifetime/Base", true, out subEle);
			subEle.Value = ParticleShaderLifetimeBase.ToString("G15");

			ele.TryPathTo("ParticleShader/Lifetime/Variance", true, out subEle);
			subEle.Value = ParticleShaderLifetimeVariance.ToString("G15");

			ele.TryPathTo("ParticleShader/NormalMovement/InitialSpeed", true, out subEle);
			subEle.Value = ParticleShaderNormalMovementInitialSpeed.ToString("G15");

			ele.TryPathTo("ParticleShader/NormalMovement/Acceleration", true, out subEle);
			subEle.Value = ParticleShaderNormalMovementAcceleration.ToString("G15");

			ele.TryPathTo("ParticleShader/InitialVelocity/Velocity1", true, out subEle);
			subEle.Value = ParticleShaderInitialVelocity1.ToString("G15");

			ele.TryPathTo("ParticleShader/InitialVelocity/Velocity2", true, out subEle);
			subEle.Value = ParticleShaderInitialVelocity2.ToString("G15");

			ele.TryPathTo("ParticleShader/InitialVelocity/Velocity3", true, out subEle);
			subEle.Value = ParticleShaderInitialVelocity3.ToString("G15");

			ele.TryPathTo("ParticleShader/Acceleration/Acceleration1", true, out subEle);
			subEle.Value = ParticleShaderAcceleration1.ToString("G15");

			ele.TryPathTo("ParticleShader/Acceleration/Acceleration2", true, out subEle);
			subEle.Value = ParticleShaderAcceleration2.ToString("G15");

			ele.TryPathTo("ParticleShader/Acceleration/Acceleration3", true, out subEle);
			subEle.Value = ParticleShaderAcceleration3.ToString("G15");

			ele.TryPathTo("ParticleShader/ScaleKey/Key1/Value", true, out subEle);
			subEle.Value = ParticleShaderScaleKey1.ToString("G15");

			ele.TryPathTo("ParticleShader/ScaleKey/Key2/Value", true, out subEle);
			subEle.Value = ParticleShaderScaleKey2.ToString("G15");

			ele.TryPathTo("ParticleShader/ScaleKey/Key1/Time", true, out subEle);
			subEle.Value = ParticleShaderScaleKey1Time.ToString("G15");

			ele.TryPathTo("ParticleShader/ScaleKey/Key2/Time", true, out subEle);
			subEle.Value = ParticleShaderScaleKey2Time.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key1/Color", true, out subEle);
			ParticleShaderColorKey1.WriteXML(subEle, master);

			ele.TryPathTo("ParticleShader/ColorKey/Key2/Color", true, out subEle);
			ParticleShaderColorKey2.WriteXML(subEle, master);

			ele.TryPathTo("ParticleShader/ColorKey/Key3/Color", true, out subEle);
			ParticleShaderColorKey3.WriteXML(subEle, master);

			ele.TryPathTo("ParticleShader/ColorKey/Key1/Alpha", true, out subEle);
			subEle.Value = ParticleShaderColorKey1Alpha.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key2/Alpha", true, out subEle);
			subEle.Value = ParticleShaderColorKey2Alpha.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key3/Alpha", true, out subEle);
			subEle.Value = ParticleShaderColorKey3Alpha.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key1/Time", true, out subEle);
			subEle.Value = ParticleShaderColorKey1Time.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key2/Time", true, out subEle);
			subEle.Value = ParticleShaderColorKey2Time.ToString("G15");

			ele.TryPathTo("ParticleShader/ColorKey/Key3/Time", true, out subEle);
			subEle.Value = ParticleShaderColorKey3Time.ToString("G15");

			ele.TryPathTo("ParticleShader/InitSpeedAlongNormal/Variance", true, out subEle);
			subEle.Value = ParticleShaderInitSpeedAlongNormalVariance.ToString("G15");

			ele.TryPathTo("ParticleShader/InitialRotation/Value", true, out subEle);
			subEle.Value = ParticleShaderInitialRotationValue.ToString("G15");

			ele.TryPathTo("ParticleShader/InitialRotation/Variance", true, out subEle);
			subEle.Value = ParticleShaderInitialRotationVariance.ToString("G15");

			ele.TryPathTo("ParticleShader/RotationSpeed/Value", true, out subEle);
			subEle.Value = ParticleShaderRotationSpeedValue.ToString("G15");

			ele.TryPathTo("ParticleShader/RotationSpeed/Variance", true, out subEle);
			subEle.Value = ParticleShaderRotationSpeedVariance.ToString("G15");

			ele.TryPathTo("AddonModels/Model", true, out subEle);
			AddonModelsModel.WriteXML(subEle, master);

			ele.TryPathTo("Holes/Time/Start", true, out subEle);
			subEle.Value = HolesTimeStart.ToString("G15");

			ele.TryPathTo("Holes/Time/End", true, out subEle);
			subEle.Value = HolesTimeEnd.ToString("G15");

			ele.TryPathTo("Holes/Value/Start", true, out subEle);
			subEle.Value = HolesValueStart.ToString("G15");

			ele.TryPathTo("Holes/Value/End", true, out subEle);
			subEle.Value = HolesValueEnd.ToString("G15");

			ele.TryPathTo("EdgeWidth", true, out subEle);
			subEle.Value = EdgeWidth.ToString("G15");

			ele.TryPathTo("EdgeColor", true, out subEle);
			EdgeColor.WriteXML(subEle, master);

			ele.TryPathTo("ExplosionWindSpeed", true, out subEle);
			subEle.Value = ExplosionWindSpeed.ToString("G15");

			ele.TryPathTo("TextureCount/U", true, out subEle);
			subEle.Value = TextureCountU.ToString();

			ele.TryPathTo("TextureCount/V", true, out subEle);
			subEle.Value = TextureCountV.ToString();

			ele.TryPathTo("AddonModels/FadeTime/In", true, out subEle);
			subEle.Value = AddonModelsFadeTimeIn.ToString("G15");

			ele.TryPathTo("AddonModels/FadeTime/Out", true, out subEle);
			subEle.Value = AddonModelsFadeTimeOut.ToString("G15");

			ele.TryPathTo("AddonModels/Scale/In", true, out subEle);
			subEle.Value = AddonModelsScaleIn.ToString("G15");

			ele.TryPathTo("AddonModels/Scale/Out", true, out subEle);
			subEle.Value = AddonModelsScaleOut.ToString("G15");

			ele.TryPathTo("AddonModels/ScaleTime/In", true, out subEle);
			subEle.Value = AddonModelsScaleTimeIn.ToString("G15");

			ele.TryPathTo("AddonModels/ScaleTime/Out", true, out subEle);
			subEle.Value = AddonModelsScaleTimeOut.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<EffectShaderFlags>();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("MembraneShader/SourceBlendMode", false, out subEle))
				MembraneShaderSourceBlendMode = subEle.ToEnum<BlendMode>();

			if (ele.TryPathTo("MembraneShader/BlendOperation", false, out subEle))
				MembraneShaderBlendOperation = subEle.ToEnum<BlendOperation>();

			if (ele.TryPathTo("MembraneShader/ZTestFunction", false, out subEle))
				MembraneShaderZTestFunction = subEle.ToEnum<ZTestFunction>();

			if (ele.TryPathTo("Fill_TextureEffect/Color", false, out subEle))
				Fill_TextureEffectColor.ReadXML(subEle, master);

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/In", false, out subEle))
				Fill_TextureEffectAlphaFadeTimeIn = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/Full", false, out subEle))
				Fill_TextureEffectAlphaFadeTimeFull = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/FadeTime/Out", false, out subEle))
				Fill_TextureEffectAlphaFadeTimeOut = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/PersistentRatio", false, out subEle))
				Fill_TextureEffectAlphaPersistentRatio = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/Pulse/Amplitude", false, out subEle))
				Fill_TextureEffectAlphaPulseAmplitude = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/Alpha/Pulse/Frequency", false, out subEle))
				Fill_TextureEffectAlphaPulseFrequency = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/TextureAnimationSpeed/U", false, out subEle))
				Fill_TextureEffectTextureAnimationSpeedU = subEle.ToSingle();

			if (ele.TryPathTo("Fill_TextureEffect/TextureAnimationSpeed/V", false, out subEle))
				Fill_TextureEffectTextureAnimationSpeedV = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/FallOff", false, out subEle))
				EdgeEffectFallOff = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Color", false, out subEle))
				EdgeEffectColor.ReadXML(subEle, master);

			if (ele.TryPathTo("EdgeEffect/Alpha/FadeTime/In", false, out subEle))
				EdgeEffectAlphaFadeTimeIn = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Alpha/FadeTime/Full", false, out subEle))
				EdgeEffectAlphaFadeTimeFull = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Alpha/FadeTime/Out", false, out subEle))
				EdgeEffectAlphaFadeTimeOut = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Alpha/PersistentRatio", false, out subEle))
				EdgeEffectAlphaPersistentRatio = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Alpha/Pulse/Amplitude", false, out subEle))
				EdgeEffectAlphaPulseAmplitude = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Alpha/Pulse/Frequency", false, out subEle))
				EdgeEffectAlphaPulseFrequency = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/Fill_TextureEffect/FullAlphaRatio", false, out subEle))
				EdgeEffectFill_TextureEffectFullAlphaRatio = subEle.ToSingle();

			if (ele.TryPathTo("EdgeEffect/FullAlphaRatio", false, out subEle))
				EdgeEffectFullAlphaRatio = subEle.ToSingle();

			if (ele.TryPathTo("MembraneShader/DestBlendMode", false, out subEle))
				MembraneShaderDestBlendMode = subEle.ToEnum<BlendMode>();

			if (ele.TryPathTo("ParticleShader/SourceBlendMode", false, out subEle))
				ParticleShaderSourceBlendMode = subEle.ToEnum<BlendMode>();

			if (ele.TryPathTo("ParticleShader/BlendOperation", false, out subEle))
				ParticleShaderBlendOperation = subEle.ToEnum<BlendOperation>();

			if (ele.TryPathTo("ParticleShader/ZTestFunction", false, out subEle))
				ParticleShaderZTestFunction = subEle.ToEnum<ZTestFunction>();

			if (ele.TryPathTo("ParticleShader/DestBlendMode", false, out subEle))
				ParticleShaderDestBlendMode = subEle.ToEnum<BlendMode>();

			if (ele.TryPathTo("ParticleShader/BirthTime/RampUp", false, out subEle))
				ParticleShaderBirthTimeRampUp = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/BirthTime/Full", false, out subEle))
				ParticleShaderBirthTimeFull = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/BirthTime/RampDown", false, out subEle))
				ParticleShaderBirthTimeRampDown = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/FullBirthRatio", false, out subEle))
				ParticleShaderFullBirthRatio = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/PersistentBirthRatio", false, out subEle))
				ParticleShaderPersistentBirthRatio = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/Lifetime/Base", false, out subEle))
				ParticleShaderLifetimeBase = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/Lifetime/Variance", false, out subEle))
				ParticleShaderLifetimeVariance = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/NormalMovement/InitialSpeed", false, out subEle))
				ParticleShaderNormalMovementInitialSpeed = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/NormalMovement/Acceleration", false, out subEle))
				ParticleShaderNormalMovementAcceleration = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitialVelocity/Velocity1", false, out subEle))
				ParticleShaderInitialVelocity1 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitialVelocity/Velocity2", false, out subEle))
				ParticleShaderInitialVelocity2 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitialVelocity/Velocity3", false, out subEle))
				ParticleShaderInitialVelocity3 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/Acceleration/Acceleration1", false, out subEle))
				ParticleShaderAcceleration1 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/Acceleration/Acceleration2", false, out subEle))
				ParticleShaderAcceleration2 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/Acceleration/Acceleration3", false, out subEle))
				ParticleShaderAcceleration3 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ScaleKey/Key1/Value", false, out subEle))
				ParticleShaderScaleKey1 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ScaleKey/Key2/Value", false, out subEle))
				ParticleShaderScaleKey2 = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ScaleKey/Key1/Time", false, out subEle))
				ParticleShaderScaleKey1Time = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ScaleKey/Key2/Time", false, out subEle))
				ParticleShaderScaleKey2Time = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key1/Color", false, out subEle))
				ParticleShaderColorKey1.ReadXML(subEle, master);

			if (ele.TryPathTo("ParticleShader/ColorKey/Key2/Color", false, out subEle))
				ParticleShaderColorKey2.ReadXML(subEle, master);

			if (ele.TryPathTo("ParticleShader/ColorKey/Key3/Color", false, out subEle))
				ParticleShaderColorKey3.ReadXML(subEle, master);

			if (ele.TryPathTo("ParticleShader/ColorKey/Key1/Alpha", false, out subEle))
				ParticleShaderColorKey1Alpha = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key2/Alpha", false, out subEle))
				ParticleShaderColorKey2Alpha = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key3/Alpha", false, out subEle))
				ParticleShaderColorKey3Alpha = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key1/Time", false, out subEle))
				ParticleShaderColorKey1Time = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key2/Time", false, out subEle))
				ParticleShaderColorKey2Time = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/ColorKey/Key3/Time", false, out subEle))
				ParticleShaderColorKey3Time = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitSpeedAlongNormal/Variance", false, out subEle))
				ParticleShaderInitSpeedAlongNormalVariance = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitialRotation/Value", false, out subEle))
				ParticleShaderInitialRotationValue = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/InitialRotation/Variance", false, out subEle))
				ParticleShaderInitialRotationVariance = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/RotationSpeed/Value", false, out subEle))
				ParticleShaderRotationSpeedValue = subEle.ToSingle();

			if (ele.TryPathTo("ParticleShader/RotationSpeed/Variance", false, out subEle))
				ParticleShaderRotationSpeedVariance = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/Model", false, out subEle))
				AddonModelsModel.ReadXML(subEle, master);

			if (ele.TryPathTo("Holes/Time/Start", false, out subEle))
				HolesTimeStart = subEle.ToSingle();

			if (ele.TryPathTo("Holes/Time/End", false, out subEle))
				HolesTimeEnd = subEle.ToSingle();

			if (ele.TryPathTo("Holes/Value/Start", false, out subEle))
				HolesValueStart = subEle.ToSingle();

			if (ele.TryPathTo("Holes/Value/End", false, out subEle))
				HolesValueEnd = subEle.ToSingle();

			if (ele.TryPathTo("EdgeWidth", false, out subEle))
				EdgeWidth = subEle.ToSingle();

			if (ele.TryPathTo("EdgeColor", false, out subEle))
				EdgeColor.ReadXML(subEle, master);

			if (ele.TryPathTo("ExplosionWindSpeed", false, out subEle))
				ExplosionWindSpeed = subEle.ToSingle();

			if (ele.TryPathTo("TextureCount/U", false, out subEle))
				TextureCountU = subEle.ToUInt32();

			if (ele.TryPathTo("TextureCount/V", false, out subEle))
				TextureCountV = subEle.ToUInt32();

			if (ele.TryPathTo("AddonModels/FadeTime/In", false, out subEle))
				AddonModelsFadeTimeIn = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/FadeTime/Out", false, out subEle))
				AddonModelsFadeTimeOut = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/Scale/In", false, out subEle))
				AddonModelsScaleIn = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/Scale/Out", false, out subEle))
				AddonModelsScaleOut = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/ScaleTime/In", false, out subEle))
				AddonModelsScaleTimeIn = subEle.ToSingle();

			if (ele.TryPathTo("AddonModels/ScaleTime/Out", false, out subEle))
				AddonModelsScaleTimeOut = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new EffectShaderData(this);
		}

        public int CompareTo(EffectShaderData other)
        {
			return MembraneShaderSourceBlendMode.CompareTo(other.MembraneShaderSourceBlendMode);
        }

        public static bool operator >(EffectShaderData objA, EffectShaderData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EffectShaderData objA, EffectShaderData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EffectShaderData objA, EffectShaderData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EffectShaderData objA, EffectShaderData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(EffectShaderData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused) &&
				MembraneShaderSourceBlendMode == other.MembraneShaderSourceBlendMode &&
				MembraneShaderBlendOperation == other.MembraneShaderBlendOperation &&
				MembraneShaderZTestFunction == other.MembraneShaderZTestFunction &&
				Fill_TextureEffectColor == other.Fill_TextureEffectColor &&
				Fill_TextureEffectAlphaFadeTimeIn == other.Fill_TextureEffectAlphaFadeTimeIn &&
				Fill_TextureEffectAlphaFadeTimeFull == other.Fill_TextureEffectAlphaFadeTimeFull &&
				Fill_TextureEffectAlphaFadeTimeOut == other.Fill_TextureEffectAlphaFadeTimeOut &&
				Fill_TextureEffectAlphaPersistentRatio == other.Fill_TextureEffectAlphaPersistentRatio &&
				Fill_TextureEffectAlphaPulseAmplitude == other.Fill_TextureEffectAlphaPulseAmplitude &&
				Fill_TextureEffectAlphaPulseFrequency == other.Fill_TextureEffectAlphaPulseFrequency &&
				Fill_TextureEffectTextureAnimationSpeedU == other.Fill_TextureEffectTextureAnimationSpeedU &&
				Fill_TextureEffectTextureAnimationSpeedV == other.Fill_TextureEffectTextureAnimationSpeedV &&
				EdgeEffectFallOff == other.EdgeEffectFallOff &&
				EdgeEffectColor == other.EdgeEffectColor &&
				EdgeEffectAlphaFadeTimeIn == other.EdgeEffectAlphaFadeTimeIn &&
				EdgeEffectAlphaFadeTimeFull == other.EdgeEffectAlphaFadeTimeFull &&
				EdgeEffectAlphaFadeTimeOut == other.EdgeEffectAlphaFadeTimeOut &&
				EdgeEffectAlphaPersistentRatio == other.EdgeEffectAlphaPersistentRatio &&
				EdgeEffectAlphaPulseAmplitude == other.EdgeEffectAlphaPulseAmplitude &&
				EdgeEffectAlphaPulseFrequency == other.EdgeEffectAlphaPulseFrequency &&
				EdgeEffectFill_TextureEffectFullAlphaRatio == other.EdgeEffectFill_TextureEffectFullAlphaRatio &&
				EdgeEffectFullAlphaRatio == other.EdgeEffectFullAlphaRatio &&
				MembraneShaderDestBlendMode == other.MembraneShaderDestBlendMode &&
				ParticleShaderSourceBlendMode == other.ParticleShaderSourceBlendMode &&
				ParticleShaderBlendOperation == other.ParticleShaderBlendOperation &&
				ParticleShaderZTestFunction == other.ParticleShaderZTestFunction &&
				ParticleShaderDestBlendMode == other.ParticleShaderDestBlendMode &&
				ParticleShaderBirthTimeRampUp == other.ParticleShaderBirthTimeRampUp &&
				ParticleShaderBirthTimeFull == other.ParticleShaderBirthTimeFull &&
				ParticleShaderBirthTimeRampDown == other.ParticleShaderBirthTimeRampDown &&
				ParticleShaderFullBirthRatio == other.ParticleShaderFullBirthRatio &&
				ParticleShaderPersistentBirthRatio == other.ParticleShaderPersistentBirthRatio &&
				ParticleShaderLifetimeBase == other.ParticleShaderLifetimeBase &&
				ParticleShaderLifetimeVariance == other.ParticleShaderLifetimeVariance &&
				ParticleShaderNormalMovementInitialSpeed == other.ParticleShaderNormalMovementInitialSpeed &&
				ParticleShaderNormalMovementAcceleration == other.ParticleShaderNormalMovementAcceleration &&
				ParticleShaderInitialVelocity1 == other.ParticleShaderInitialVelocity1 &&
				ParticleShaderInitialVelocity2 == other.ParticleShaderInitialVelocity2 &&
				ParticleShaderInitialVelocity3 == other.ParticleShaderInitialVelocity3 &&
				ParticleShaderAcceleration1 == other.ParticleShaderAcceleration1 &&
				ParticleShaderAcceleration2 == other.ParticleShaderAcceleration2 &&
				ParticleShaderAcceleration3 == other.ParticleShaderAcceleration3 &&
				ParticleShaderScaleKey1 == other.ParticleShaderScaleKey1 &&
				ParticleShaderScaleKey2 == other.ParticleShaderScaleKey2 &&
				ParticleShaderScaleKey1Time == other.ParticleShaderScaleKey1Time &&
				ParticleShaderScaleKey2Time == other.ParticleShaderScaleKey2Time &&
				ParticleShaderColorKey1 == other.ParticleShaderColorKey1 &&
				ParticleShaderColorKey2 == other.ParticleShaderColorKey2 &&
				ParticleShaderColorKey3 == other.ParticleShaderColorKey3 &&
				ParticleShaderColorKey1Alpha == other.ParticleShaderColorKey1Alpha &&
				ParticleShaderColorKey2Alpha == other.ParticleShaderColorKey2Alpha &&
				ParticleShaderColorKey3Alpha == other.ParticleShaderColorKey3Alpha &&
				ParticleShaderColorKey1Time == other.ParticleShaderColorKey1Time &&
				ParticleShaderColorKey2Time == other.ParticleShaderColorKey2Time &&
				ParticleShaderColorKey3Time == other.ParticleShaderColorKey3Time &&
				ParticleShaderInitSpeedAlongNormalVariance == other.ParticleShaderInitSpeedAlongNormalVariance &&
				ParticleShaderInitialRotationValue == other.ParticleShaderInitialRotationValue &&
				ParticleShaderInitialRotationVariance == other.ParticleShaderInitialRotationVariance &&
				ParticleShaderRotationSpeedValue == other.ParticleShaderRotationSpeedValue &&
				ParticleShaderRotationSpeedVariance == other.ParticleShaderRotationSpeedVariance &&
				AddonModelsModel == other.AddonModelsModel &&
				HolesTimeStart == other.HolesTimeStart &&
				HolesTimeEnd == other.HolesTimeEnd &&
				HolesValueStart == other.HolesValueStart &&
				HolesValueEnd == other.HolesValueEnd &&
				EdgeWidth == other.EdgeWidth &&
				EdgeColor == other.EdgeColor &&
				ExplosionWindSpeed == other.ExplosionWindSpeed &&
				TextureCountU == other.TextureCountU &&
				TextureCountV == other.TextureCountV &&
				AddonModelsFadeTimeIn == other.AddonModelsFadeTimeIn &&
				AddonModelsFadeTimeOut == other.AddonModelsFadeTimeOut &&
				AddonModelsScaleIn == other.AddonModelsScaleIn &&
				AddonModelsScaleOut == other.AddonModelsScaleOut &&
				AddonModelsScaleTimeIn == other.AddonModelsScaleTimeIn &&
				AddonModelsScaleTimeOut == other.AddonModelsScaleTimeOut;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EffectShaderData other = obj as EffectShaderData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MembraneShaderSourceBlendMode.GetHashCode();
        }

        public static bool operator ==(EffectShaderData objA, EffectShaderData objB)
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

        public static bool operator !=(EffectShaderData objA, EffectShaderData objB)
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

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}