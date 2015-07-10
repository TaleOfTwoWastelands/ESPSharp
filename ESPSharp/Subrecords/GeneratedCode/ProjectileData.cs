
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
	public partial class ProjectileData : Subrecord, ICloneable<ProjectileData>, IComparable<ProjectileData>, IEquatable<ProjectileData>  
	{
		public ProjectileFlags Flags { get; set; }
		public ProjectileType Type { get; set; }
		public Single Gravity { get; set; }
		public Single Speed { get; set; }
		public Single Range { get; set; }
		public FormID Light { get; set; }
		public FormID MuzzleFlashLight { get; set; }
		public Single TracerChance { get; set; }
		public Single ExplosionAltTriggerProximity { get; set; }
		public Single ExplosionAltTriggerTimer { get; set; }
		public FormID Explosion { get; set; }
		public FormID Sound { get; set; }
		public Single MuzzleFlashDuration { get; set; }
		public Single FadeDuration { get; set; }
		public Single ImpactForce { get; set; }
		public FormID SoundCountdown { get; set; }
		public FormID Sounddisable { get; set; }
		public FormID DefaultWeaponSource { get; set; }
		public Single XRotation { get; set; }
		public Single YRotation { get; set; }
		public Single ZRotation { get; set; }
		public Single BouncyMult { get; set; }

		public ProjectileData()
		{
			Flags = new ProjectileFlags();
			Type = new ProjectileType();
			Gravity = new Single();
			Speed = new Single();
			Range = new Single();
			Light = new FormID();
			MuzzleFlashLight = new FormID();
			TracerChance = new Single();
			ExplosionAltTriggerProximity = new Single();
			ExplosionAltTriggerTimer = new Single();
			Explosion = new FormID();
			Sound = new FormID();
			MuzzleFlashDuration = new Single();
			FadeDuration = new Single();
			ImpactForce = new Single();
			SoundCountdown = new FormID();
			Sounddisable = new FormID();
			DefaultWeaponSource = new FormID();
			XRotation = new Single();
			YRotation = new Single();
			ZRotation = new Single();
			BouncyMult = new Single();
		}

		public ProjectileData(ProjectileFlags Flags, ProjectileType Type, Single Gravity, Single Speed, Single Range, FormID Light, FormID MuzzleFlashLight, Single TracerChance, Single ExplosionAltTriggerProximity, Single ExplosionAltTriggerTimer, FormID Explosion, FormID Sound, Single MuzzleFlashDuration, Single FadeDuration, Single ImpactForce, FormID SoundCountdown, FormID Sounddisable, FormID DefaultWeaponSource, Single XRotation, Single YRotation, Single ZRotation, Single BouncyMult)
		{
			this.Flags = Flags;
			this.Type = Type;
			this.Gravity = Gravity;
			this.Speed = Speed;
			this.Range = Range;
			this.Light = Light;
			this.MuzzleFlashLight = MuzzleFlashLight;
			this.TracerChance = TracerChance;
			this.ExplosionAltTriggerProximity = ExplosionAltTriggerProximity;
			this.ExplosionAltTriggerTimer = ExplosionAltTriggerTimer;
			this.Explosion = Explosion;
			this.Sound = Sound;
			this.MuzzleFlashDuration = MuzzleFlashDuration;
			this.FadeDuration = FadeDuration;
			this.ImpactForce = ImpactForce;
			this.SoundCountdown = SoundCountdown;
			this.Sounddisable = Sounddisable;
			this.DefaultWeaponSource = DefaultWeaponSource;
			this.XRotation = XRotation;
			this.YRotation = YRotation;
			this.ZRotation = ZRotation;
			this.BouncyMult = BouncyMult;
		}

		public ProjectileData(ProjectileData copyObject)
		{
			Flags = copyObject.Flags;
			Type = copyObject.Type;
			Gravity = copyObject.Gravity;
			Speed = copyObject.Speed;
			Range = copyObject.Range;
			Light = copyObject.Light.Clone();
			MuzzleFlashLight = copyObject.MuzzleFlashLight.Clone();
			TracerChance = copyObject.TracerChance;
			ExplosionAltTriggerProximity = copyObject.ExplosionAltTriggerProximity;
			ExplosionAltTriggerTimer = copyObject.ExplosionAltTriggerTimer;
			Explosion = copyObject.Explosion.Clone();
			Sound = copyObject.Sound.Clone();
			MuzzleFlashDuration = copyObject.MuzzleFlashDuration;
			FadeDuration = copyObject.FadeDuration;
			ImpactForce = copyObject.ImpactForce;
			SoundCountdown = copyObject.SoundCountdown.Clone();
			Sounddisable = copyObject.Sounddisable.Clone();
			DefaultWeaponSource = copyObject.DefaultWeaponSource.Clone();
			XRotation = copyObject.XRotation;
			YRotation = copyObject.YRotation;
			ZRotation = copyObject.ZRotation;
			BouncyMult = copyObject.BouncyMult;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<ProjectileFlags>();
					Type = subReader.ReadEnum<ProjectileType>();
					Gravity = subReader.ReadSingle();
					Speed = subReader.ReadSingle();
					Range = subReader.ReadSingle();
					Light.ReadBinary(subReader);
					MuzzleFlashLight.ReadBinary(subReader);
					TracerChance = subReader.ReadSingle();
					ExplosionAltTriggerProximity = subReader.ReadSingle();
					ExplosionAltTriggerTimer = subReader.ReadSingle();
					Explosion.ReadBinary(subReader);
					Sound.ReadBinary(subReader);
					MuzzleFlashDuration = subReader.ReadSingle();
					FadeDuration = subReader.ReadSingle();
					ImpactForce = subReader.ReadSingle();
					SoundCountdown.ReadBinary(subReader);
					Sounddisable.ReadBinary(subReader);
					DefaultWeaponSource.ReadBinary(subReader);
					XRotation = subReader.ReadSingle();
					YRotation = subReader.ReadSingle();
					ZRotation = subReader.ReadSingle();
					BouncyMult = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt16)Flags);
			writer.Write((UInt16)Type);
			writer.Write(Gravity);
			writer.Write(Speed);
			writer.Write(Range);
			Light.WriteBinary(writer);
			MuzzleFlashLight.WriteBinary(writer);
			writer.Write(TracerChance);
			writer.Write(ExplosionAltTriggerProximity);
			writer.Write(ExplosionAltTriggerTimer);
			Explosion.WriteBinary(writer);
			Sound.WriteBinary(writer);
			writer.Write(MuzzleFlashDuration);
			writer.Write(FadeDuration);
			writer.Write(ImpactForce);
			SoundCountdown.WriteBinary(writer);
			Sounddisable.WriteBinary(writer);
			DefaultWeaponSource.WriteBinary(writer);
			writer.Write(XRotation);
			writer.Write(YRotation);
			writer.Write(ZRotation);
			writer.Write(BouncyMult);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Gravity", true, out subEle);
			subEle.Value = Gravity.ToString("G15");

			ele.TryPathTo("Speed", true, out subEle);
			subEle.Value = Speed.ToString("G15");

			ele.TryPathTo("Range", true, out subEle);
			subEle.Value = Range.ToString("G15");

			ele.TryPathTo("Light", true, out subEle);
			Light.WriteXML(subEle, master);

			ele.TryPathTo("MuzzleFlash/Light", true, out subEle);
			MuzzleFlashLight.WriteXML(subEle, master);

			ele.TryPathTo("TracerChance", true, out subEle);
			subEle.Value = TracerChance.ToString("G15");

			ele.TryPathTo("Explosion/AltTrigger/Proximity", true, out subEle);
			subEle.Value = ExplosionAltTriggerProximity.ToString("G15");

			ele.TryPathTo("Explosion/AltTrigger/Timer", true, out subEle);
			subEle.Value = ExplosionAltTriggerTimer.ToString("G15");

			ele.TryPathTo("Explosion/Form", true, out subEle);
			Explosion.WriteXML(subEle, master);

			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("MuzzleFlash/Duration", true, out subEle);
			subEle.Value = MuzzleFlashDuration.ToString("G15");

			ele.TryPathTo("FadeDuration", true, out subEle);
			subEle.Value = FadeDuration.ToString("G15");

			ele.TryPathTo("ImpactForce", true, out subEle);
			subEle.Value = ImpactForce.ToString("G15");

			ele.TryPathTo("Sound/Countdown", true, out subEle);
			SoundCountdown.WriteXML(subEle, master);

			ele.TryPathTo("Sound/Disable", true, out subEle);
			Sounddisable.WriteXML(subEle, master);

			ele.TryPathTo("DefaultWeaponSource", true, out subEle);
			DefaultWeaponSource.WriteXML(subEle, master);

			ele.TryPathTo("XRotation", true, out subEle);
			subEle.Value = XRotation.ToString("G15");

			ele.TryPathTo("YRotation", true, out subEle);
			subEle.Value = YRotation.ToString("G15");

			ele.TryPathTo("ZRotation", true, out subEle);
			subEle.Value = ZRotation.ToString("G15");

			ele.TryPathTo("BouncyMult", true, out subEle);
			subEle.Value = BouncyMult.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<ProjectileFlags>();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<ProjectileType>();

			if (ele.TryPathTo("Gravity", false, out subEle))
				Gravity = subEle.ToSingle();

			if (ele.TryPathTo("Speed", false, out subEle))
				Speed = subEle.ToSingle();

			if (ele.TryPathTo("Range", false, out subEle))
				Range = subEle.ToSingle();

			if (ele.TryPathTo("Light", false, out subEle))
				Light.ReadXML(subEle, master);

			if (ele.TryPathTo("MuzzleFlash/Light", false, out subEle))
				MuzzleFlashLight.ReadXML(subEle, master);

			if (ele.TryPathTo("TracerChance", false, out subEle))
				TracerChance = subEle.ToSingle();

			if (ele.TryPathTo("Explosion/AltTrigger/Proximity", false, out subEle))
				ExplosionAltTriggerProximity = subEle.ToSingle();

			if (ele.TryPathTo("Explosion/AltTrigger/Timer", false, out subEle))
				ExplosionAltTriggerTimer = subEle.ToSingle();

			if (ele.TryPathTo("Explosion/Form", false, out subEle))
				Explosion.ReadXML(subEle, master);

			if (ele.TryPathTo("Sound", false, out subEle))
				Sound.ReadXML(subEle, master);

			if (ele.TryPathTo("MuzzleFlash/Duration", false, out subEle))
				MuzzleFlashDuration = subEle.ToSingle();

			if (ele.TryPathTo("FadeDuration", false, out subEle))
				FadeDuration = subEle.ToSingle();

			if (ele.TryPathTo("ImpactForce", false, out subEle))
				ImpactForce = subEle.ToSingle();

			if (ele.TryPathTo("Sound/Countdown", false, out subEle))
				SoundCountdown.ReadXML(subEle, master);

			if (ele.TryPathTo("Sound/Disable", false, out subEle))
				Sounddisable.ReadXML(subEle, master);

			if (ele.TryPathTo("DefaultWeaponSource", false, out subEle))
				DefaultWeaponSource.ReadXML(subEle, master);

			if (ele.TryPathTo("XRotation", false, out subEle))
				XRotation = subEle.ToSingle();

			if (ele.TryPathTo("YRotation", false, out subEle))
				YRotation = subEle.ToSingle();

			if (ele.TryPathTo("ZRotation", false, out subEle))
				ZRotation = subEle.ToSingle();

			if (ele.TryPathTo("BouncyMult", false, out subEle))
				BouncyMult = subEle.ToSingle();
		}

		public ProjectileData Clone()
		{
			return new ProjectileData(this);
		}

        public int CompareTo(ProjectileData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(ProjectileData objA, ProjectileData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ProjectileData objA, ProjectileData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ProjectileData objA, ProjectileData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ProjectileData objA, ProjectileData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ProjectileData other)
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
				Type == other.Type &&
				Gravity == other.Gravity &&
				Speed == other.Speed &&
				Range == other.Range &&
				Light == other.Light &&
				MuzzleFlashLight == other.MuzzleFlashLight &&
				TracerChance == other.TracerChance &&
				ExplosionAltTriggerProximity == other.ExplosionAltTriggerProximity &&
				ExplosionAltTriggerTimer == other.ExplosionAltTriggerTimer &&
				Explosion == other.Explosion &&
				Sound == other.Sound &&
				MuzzleFlashDuration == other.MuzzleFlashDuration &&
				FadeDuration == other.FadeDuration &&
				ImpactForce == other.ImpactForce &&
				SoundCountdown == other.SoundCountdown &&
				Sounddisable == other.Sounddisable &&
				DefaultWeaponSource == other.DefaultWeaponSource &&
				XRotation == other.XRotation &&
				YRotation == other.YRotation &&
				ZRotation == other.ZRotation &&
				BouncyMult == other.BouncyMult;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ProjectileData other = obj as ProjectileData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(ProjectileData objA, ProjectileData objB)
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

        public static bool operator !=(ProjectileData objA, ProjectileData objB)
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
	}
}