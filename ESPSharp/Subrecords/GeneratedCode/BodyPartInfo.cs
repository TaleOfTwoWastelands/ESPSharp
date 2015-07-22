
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
	public partial class BodyPartInfo : Subrecord, ICloneable, IComparable<BodyPartInfo>, IEquatable<BodyPartInfo>  
	{
		public Single DamageMultiplier { get; set; }
		public BodyPartDataFlags Flags { get; set; }
		public BodyPartType Type { get; set; }
		public Byte HealthPercent { get; set; }
		public ActorValuesByte ActorValue { get; set; }
		public Byte ToHitChance { get; set; }
		public Byte ExplosionChance { get; set; }
		public UInt16 ExplosionDebrisCount { get; set; }
		public FormID ExplosionDebris { get; set; }
		public FormID Explosion { get; set; }
		public Single TrackingMaxAngle { get; set; }
		public Single ExplosionDebrisScale { get; set; }
		public Int32 SeverableDebrisCount { get; set; }
		public FormID SeverableDebris { get; set; }
		public FormID SeverableExplosion { get; set; }
		public Single SeverableDebrisScale { get; set; }
		public Single GoreEffectsTranslateX { get; set; }
		public Single GoreEffectsTranslateY { get; set; }
		public Single GoreEffectsTranslateZ { get; set; }
		public Single GoreEffectsRotationX { get; set; }
		public Single GoreEffectsRotationY { get; set; }
		public Single GoreEffectsRotationZ { get; set; }
		public FormID SeverableImpactDataSet { get; set; }
		public FormID ExplosionImpactDataSet { get; set; }
		public Byte SeverableDecalCount { get; set; }
		public Byte ExplosionDecalCount { get; set; }
		public Byte[] Unused { get; set; }
		public Single LimbReplacementScale { get; set; }

		public BodyPartInfo(string Tag = null)
			:base(Tag)
		{
			DamageMultiplier = new Single();
			Flags = new BodyPartDataFlags();
			Type = new BodyPartType();
			HealthPercent = new Byte();
			ActorValue = new ActorValuesByte();
			ToHitChance = new Byte();
			ExplosionChance = new Byte();
			ExplosionDebrisCount = new UInt16();
			ExplosionDebris = new FormID();
			Explosion = new FormID();
			TrackingMaxAngle = new Single();
			ExplosionDebrisScale = new Single();
			SeverableDebrisCount = new Int32();
			SeverableDebris = new FormID();
			SeverableExplosion = new FormID();
			SeverableDebrisScale = new Single();
			GoreEffectsTranslateX = new Single();
			GoreEffectsTranslateY = new Single();
			GoreEffectsTranslateZ = new Single();
			GoreEffectsRotationX = new Single();
			GoreEffectsRotationY = new Single();
			GoreEffectsRotationZ = new Single();
			SeverableImpactDataSet = new FormID();
			ExplosionImpactDataSet = new FormID();
			SeverableDecalCount = new Byte();
			ExplosionDecalCount = new Byte();
			Unused = new byte[2];
			LimbReplacementScale = new Single();
		}

		public BodyPartInfo(Single DamageMultiplier, BodyPartDataFlags Flags, BodyPartType Type, Byte HealthPercent, ActorValuesByte ActorValue, Byte ToHitChance, Byte ExplosionChance, UInt16 ExplosionDebrisCount, FormID ExplosionDebris, FormID Explosion, Single TrackingMaxAngle, Single ExplosionDebrisScale, Int32 SeverableDebrisCount, FormID SeverableDebris, FormID SeverableExplosion, Single SeverableDebrisScale, Single GoreEffectsTranslateX, Single GoreEffectsTranslateY, Single GoreEffectsTranslateZ, Single GoreEffectsRotationX, Single GoreEffectsRotationY, Single GoreEffectsRotationZ, FormID SeverableImpactDataSet, FormID ExplosionImpactDataSet, Byte SeverableDecalCount, Byte ExplosionDecalCount, Byte[] Unused, Single LimbReplacementScale)
		{
			this.DamageMultiplier = DamageMultiplier;
			this.Flags = Flags;
			this.Type = Type;
			this.HealthPercent = HealthPercent;
			this.ActorValue = ActorValue;
			this.ToHitChance = ToHitChance;
			this.ExplosionChance = ExplosionChance;
			this.ExplosionDebrisCount = ExplosionDebrisCount;
			this.ExplosionDebris = ExplosionDebris;
			this.Explosion = Explosion;
			this.TrackingMaxAngle = TrackingMaxAngle;
			this.ExplosionDebrisScale = ExplosionDebrisScale;
			this.SeverableDebrisCount = SeverableDebrisCount;
			this.SeverableDebris = SeverableDebris;
			this.SeverableExplosion = SeverableExplosion;
			this.SeverableDebrisScale = SeverableDebrisScale;
			this.GoreEffectsTranslateX = GoreEffectsTranslateX;
			this.GoreEffectsTranslateY = GoreEffectsTranslateY;
			this.GoreEffectsTranslateZ = GoreEffectsTranslateZ;
			this.GoreEffectsRotationX = GoreEffectsRotationX;
			this.GoreEffectsRotationY = GoreEffectsRotationY;
			this.GoreEffectsRotationZ = GoreEffectsRotationZ;
			this.SeverableImpactDataSet = SeverableImpactDataSet;
			this.ExplosionImpactDataSet = ExplosionImpactDataSet;
			this.SeverableDecalCount = SeverableDecalCount;
			this.ExplosionDecalCount = ExplosionDecalCount;
			this.Unused = Unused;
			this.LimbReplacementScale = LimbReplacementScale;
		}

		public BodyPartInfo(BodyPartInfo copyObject)
		{
			DamageMultiplier = copyObject.DamageMultiplier;
			Flags = copyObject.Flags;
			Type = copyObject.Type;
			HealthPercent = copyObject.HealthPercent;
			ActorValue = copyObject.ActorValue;
			ToHitChance = copyObject.ToHitChance;
			ExplosionChance = copyObject.ExplosionChance;
			ExplosionDebrisCount = copyObject.ExplosionDebrisCount;
			if (copyObject.ExplosionDebris != null)
				ExplosionDebris = (FormID)copyObject.ExplosionDebris.Clone();
			if (copyObject.Explosion != null)
				Explosion = (FormID)copyObject.Explosion.Clone();
			TrackingMaxAngle = copyObject.TrackingMaxAngle;
			ExplosionDebrisScale = copyObject.ExplosionDebrisScale;
			SeverableDebrisCount = copyObject.SeverableDebrisCount;
			if (copyObject.SeverableDebris != null)
				SeverableDebris = (FormID)copyObject.SeverableDebris.Clone();
			if (copyObject.SeverableExplosion != null)
				SeverableExplosion = (FormID)copyObject.SeverableExplosion.Clone();
			SeverableDebrisScale = copyObject.SeverableDebrisScale;
			GoreEffectsTranslateX = copyObject.GoreEffectsTranslateX;
			GoreEffectsTranslateY = copyObject.GoreEffectsTranslateY;
			GoreEffectsTranslateZ = copyObject.GoreEffectsTranslateZ;
			GoreEffectsRotationX = copyObject.GoreEffectsRotationX;
			GoreEffectsRotationY = copyObject.GoreEffectsRotationY;
			GoreEffectsRotationZ = copyObject.GoreEffectsRotationZ;
			if (copyObject.SeverableImpactDataSet != null)
				SeverableImpactDataSet = (FormID)copyObject.SeverableImpactDataSet.Clone();
			if (copyObject.ExplosionImpactDataSet != null)
				ExplosionImpactDataSet = (FormID)copyObject.ExplosionImpactDataSet.Clone();
			SeverableDecalCount = copyObject.SeverableDecalCount;
			ExplosionDecalCount = copyObject.ExplosionDecalCount;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			LimbReplacementScale = copyObject.LimbReplacementScale;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					DamageMultiplier = subReader.ReadSingle();
					Flags = subReader.ReadEnum<BodyPartDataFlags>();
					Type = subReader.ReadEnum<BodyPartType>();
					HealthPercent = subReader.ReadByte();
					ActorValue = subReader.ReadEnum<ActorValuesByte>();
					ToHitChance = subReader.ReadByte();
					ExplosionChance = subReader.ReadByte();
					ExplosionDebrisCount = subReader.ReadUInt16();
					ExplosionDebris.ReadBinary(subReader);
					Explosion.ReadBinary(subReader);
					TrackingMaxAngle = subReader.ReadSingle();
					ExplosionDebrisScale = subReader.ReadSingle();
					SeverableDebrisCount = subReader.ReadInt32();
					SeverableDebris.ReadBinary(subReader);
					SeverableExplosion.ReadBinary(subReader);
					SeverableDebrisScale = subReader.ReadSingle();
					GoreEffectsTranslateX = subReader.ReadSingle();
					GoreEffectsTranslateY = subReader.ReadSingle();
					GoreEffectsTranslateZ = subReader.ReadSingle();
					GoreEffectsRotationX = subReader.ReadSingle();
					GoreEffectsRotationY = subReader.ReadSingle();
					GoreEffectsRotationZ = subReader.ReadSingle();
					SeverableImpactDataSet.ReadBinary(subReader);
					ExplosionImpactDataSet.ReadBinary(subReader);
					SeverableDecalCount = subReader.ReadByte();
					ExplosionDecalCount = subReader.ReadByte();
					Unused = subReader.ReadBytes(2);
					LimbReplacementScale = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DamageMultiplier);
			writer.Write((Byte)Flags);
			writer.Write((Byte)Type);
			writer.Write(HealthPercent);
			writer.Write((SByte)ActorValue);
			writer.Write(ToHitChance);
			writer.Write(ExplosionChance);
			writer.Write(ExplosionDebrisCount);
			ExplosionDebris.WriteBinary(writer);
			Explosion.WriteBinary(writer);
			writer.Write(TrackingMaxAngle);
			writer.Write(ExplosionDebrisScale);
			writer.Write(SeverableDebrisCount);
			SeverableDebris.WriteBinary(writer);
			SeverableExplosion.WriteBinary(writer);
			writer.Write(SeverableDebrisScale);
			writer.Write(GoreEffectsTranslateX);
			writer.Write(GoreEffectsTranslateY);
			writer.Write(GoreEffectsTranslateZ);
			writer.Write(GoreEffectsRotationX);
			writer.Write(GoreEffectsRotationY);
			writer.Write(GoreEffectsRotationZ);
			SeverableImpactDataSet.WriteBinary(writer);
			ExplosionImpactDataSet.WriteBinary(writer);
			writer.Write(SeverableDecalCount);
			writer.Write(ExplosionDecalCount);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
			writer.Write(LimbReplacementScale);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("DamageMultiplier", true, out subEle);
			subEle.Value = DamageMultiplier.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("HealthPercent", true, out subEle);
			subEle.Value = HealthPercent.ToString();

			ele.TryPathTo("ActorValue", true, out subEle);
			subEle.Value = ActorValue.ToString();

			ele.TryPathTo("ToHitChance", true, out subEle);
			subEle.Value = ToHitChance.ToString();

			ele.TryPathTo("Explodable/ExplosionChance", true, out subEle);
			subEle.Value = ExplosionChance.ToString();

			ele.TryPathTo("Explodable/DebrisCount", true, out subEle);
			subEle.Value = ExplosionDebrisCount.ToString();

			ele.TryPathTo("Explodable/Debris", true, out subEle);
			ExplosionDebris.WriteXML(subEle, master);

			ele.TryPathTo("Explodable/Explosion", true, out subEle);
			Explosion.WriteXML(subEle, master);

			ele.TryPathTo("TrackingMaxAngle", true, out subEle);
			subEle.Value = TrackingMaxAngle.ToString("G15");

			ele.TryPathTo("Explodable/DebrisScale", true, out subEle);
			subEle.Value = ExplosionDebrisScale.ToString("G15");

			ele.TryPathTo("Severable/DebrisCount", true, out subEle);
			subEle.Value = SeverableDebrisCount.ToString();

			ele.TryPathTo("Severable/Debris", true, out subEle);
			SeverableDebris.WriteXML(subEle, master);

			ele.TryPathTo("Severable/Explosion", true, out subEle);
			SeverableExplosion.WriteXML(subEle, master);

			ele.TryPathTo("Severable/DebrisScale", true, out subEle);
			subEle.Value = SeverableDebrisScale.ToString("G15");

			ele.TryPathTo("GoreEffects/Translate/X", true, out subEle);
			subEle.Value = GoreEffectsTranslateX.ToString("G15");

			ele.TryPathTo("GoreEffects/Translate/Y", true, out subEle);
			subEle.Value = GoreEffectsTranslateY.ToString("G15");

			ele.TryPathTo("GoreEffects/Translate/Z", true, out subEle);
			subEle.Value = GoreEffectsTranslateZ.ToString("G15");

			ele.TryPathTo("GoreEffects/Rotation/X", true, out subEle);
			subEle.Value = GoreEffectsRotationX.ToString("G15");

			ele.TryPathTo("GoreEffects/Rotation/Y", true, out subEle);
			subEle.Value = GoreEffectsRotationY.ToString("G15");

			ele.TryPathTo("GoreEffects/Rotation/Z", true, out subEle);
			subEle.Value = GoreEffectsRotationZ.ToString("G15");

			ele.TryPathTo("Severable/ImpactDataSet", true, out subEle);
			SeverableImpactDataSet.WriteXML(subEle, master);

			ele.TryPathTo("Explodable/ImpactDataSet", true, out subEle);
			ExplosionImpactDataSet.WriteXML(subEle, master);

			ele.TryPathTo("Severable/DecalCount", true, out subEle);
			subEle.Value = SeverableDecalCount.ToString();

			ele.TryPathTo("Explodable/DecalCount", true, out subEle);
			subEle.Value = ExplosionDecalCount.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("LimbReplacementScale", true, out subEle);
			subEle.Value = LimbReplacementScale.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("DamageMultiplier", false, out subEle))
				DamageMultiplier = subEle.ToSingle();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<BodyPartDataFlags>();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<BodyPartType>();

			if (ele.TryPathTo("HealthPercent", false, out subEle))
				HealthPercent = subEle.ToByte();

			if (ele.TryPathTo("ActorValue", false, out subEle))
				ActorValue = subEle.ToEnum<ActorValuesByte>();

			if (ele.TryPathTo("ToHitChance", false, out subEle))
				ToHitChance = subEle.ToByte();

			if (ele.TryPathTo("Explodable/ExplosionChance", false, out subEle))
				ExplosionChance = subEle.ToByte();

			if (ele.TryPathTo("Explodable/DebrisCount", false, out subEle))
				ExplosionDebrisCount = subEle.ToUInt16();

			if (ele.TryPathTo("Explodable/Debris", false, out subEle))
				ExplosionDebris.ReadXML(subEle, master);

			if (ele.TryPathTo("Explodable/Explosion", false, out subEle))
				Explosion.ReadXML(subEle, master);

			if (ele.TryPathTo("TrackingMaxAngle", false, out subEle))
				TrackingMaxAngle = subEle.ToSingle();

			if (ele.TryPathTo("Explodable/DebrisScale", false, out subEle))
				ExplosionDebrisScale = subEle.ToSingle();

			if (ele.TryPathTo("Severable/DebrisCount", false, out subEle))
				SeverableDebrisCount = subEle.ToInt32();

			if (ele.TryPathTo("Severable/Debris", false, out subEle))
				SeverableDebris.ReadXML(subEle, master);

			if (ele.TryPathTo("Severable/Explosion", false, out subEle))
				SeverableExplosion.ReadXML(subEle, master);

			if (ele.TryPathTo("Severable/DebrisScale", false, out subEle))
				SeverableDebrisScale = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Translate/X", false, out subEle))
				GoreEffectsTranslateX = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Translate/Y", false, out subEle))
				GoreEffectsTranslateY = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Translate/Z", false, out subEle))
				GoreEffectsTranslateZ = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Rotation/X", false, out subEle))
				GoreEffectsRotationX = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Rotation/Y", false, out subEle))
				GoreEffectsRotationY = subEle.ToSingle();

			if (ele.TryPathTo("GoreEffects/Rotation/Z", false, out subEle))
				GoreEffectsRotationZ = subEle.ToSingle();

			if (ele.TryPathTo("Severable/ImpactDataSet", false, out subEle))
				SeverableImpactDataSet.ReadXML(subEle, master);

			if (ele.TryPathTo("Explodable/ImpactDataSet", false, out subEle))
				ExplosionImpactDataSet.ReadXML(subEle, master);

			if (ele.TryPathTo("Severable/DecalCount", false, out subEle))
				SeverableDecalCount = subEle.ToByte();

			if (ele.TryPathTo("Explodable/DecalCount", false, out subEle))
				ExplosionDecalCount = subEle.ToByte();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("LimbReplacementScale", false, out subEle))
				LimbReplacementScale = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new BodyPartInfo(this);
		}

        public int CompareTo(BodyPartInfo other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(BodyPartInfo objA, BodyPartInfo objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(BodyPartInfo objA, BodyPartInfo objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(BodyPartInfo objA, BodyPartInfo objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(BodyPartInfo objA, BodyPartInfo objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(BodyPartInfo other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DamageMultiplier == other.DamageMultiplier &&
				Flags == other.Flags &&
				Type == other.Type &&
				HealthPercent == other.HealthPercent &&
				ActorValue == other.ActorValue &&
				ToHitChance == other.ToHitChance &&
				ExplosionChance == other.ExplosionChance &&
				ExplosionDebrisCount == other.ExplosionDebrisCount &&
				ExplosionDebris == other.ExplosionDebris &&
				Explosion == other.Explosion &&
				TrackingMaxAngle == other.TrackingMaxAngle &&
				ExplosionDebrisScale == other.ExplosionDebrisScale &&
				SeverableDebrisCount == other.SeverableDebrisCount &&
				SeverableDebris == other.SeverableDebris &&
				SeverableExplosion == other.SeverableExplosion &&
				SeverableDebrisScale == other.SeverableDebrisScale &&
				GoreEffectsTranslateX == other.GoreEffectsTranslateX &&
				GoreEffectsTranslateY == other.GoreEffectsTranslateY &&
				GoreEffectsTranslateZ == other.GoreEffectsTranslateZ &&
				GoreEffectsRotationX == other.GoreEffectsRotationX &&
				GoreEffectsRotationY == other.GoreEffectsRotationY &&
				GoreEffectsRotationZ == other.GoreEffectsRotationZ &&
				SeverableImpactDataSet == other.SeverableImpactDataSet &&
				ExplosionImpactDataSet == other.ExplosionImpactDataSet &&
				SeverableDecalCount == other.SeverableDecalCount &&
				ExplosionDecalCount == other.ExplosionDecalCount &&
				Unused.SequenceEqual(other.Unused) &&
				LimbReplacementScale == other.LimbReplacementScale;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            BodyPartInfo other = obj as BodyPartInfo;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(BodyPartInfo objA, BodyPartInfo objB)
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

        public static bool operator !=(BodyPartInfo objA, BodyPartInfo objB)
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