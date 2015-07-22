
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
	public partial class MagicEffectData : Subrecord, ICloneable, IComparable<MagicEffectData>, IEquatable<MagicEffectData>  
	{
		public MagicEffectFlags MagicEffectFlags { get; set; }
		public Single BaseCost { get; set; }
		public FormID AssociatedItem { get; set; }
		public MagicSchool MagicSchool { get; set; }
		public ActorValues ResistanceType { get; set; }
		public UInt16 Unknown { get; set; }
		public Byte[] Unused { get; set; }
		public FormID Light { get; set; }
		public Single ProjectileSpeed { get; set; }
		public FormID EffectShader { get; set; }
		public FormID ObjectDisplayShader { get; set; }
		public FormID EffectSound { get; set; }
		public FormID BoltSound { get; set; }
		public FormID HitSound { get; set; }
		public FormID AreaSound { get; set; }
		public Single ConstantEffectEnchantmentFactor { get; set; }
		public Single ConstantEffectBarterFactor { get; set; }
		public MagicEffectArchetype Archetype { get; set; }
		public ActorValues ActorValue { get; set; }

		public MagicEffectData(string Tag = null)
			:base(Tag)
		{
			MagicEffectFlags = new MagicEffectFlags();
			BaseCost = new Single();
			AssociatedItem = new FormID();
			MagicSchool = new MagicSchool();
			ResistanceType = new ActorValues();
			Unknown = new UInt16();
			Unused = new byte[2];
			Light = new FormID();
			ProjectileSpeed = new Single();
			EffectShader = new FormID();
			ObjectDisplayShader = new FormID();
			EffectSound = new FormID();
			BoltSound = new FormID();
			HitSound = new FormID();
			AreaSound = new FormID();
			ConstantEffectEnchantmentFactor = new Single();
			ConstantEffectBarterFactor = new Single();
			Archetype = new MagicEffectArchetype();
			ActorValue = new ActorValues();
		}

		public MagicEffectData(MagicEffectFlags MagicEffectFlags, Single BaseCost, FormID AssociatedItem, MagicSchool MagicSchool, ActorValues ResistanceType, UInt16 Unknown, Byte[] Unused, FormID Light, Single ProjectileSpeed, FormID EffectShader, FormID ObjectDisplayShader, FormID EffectSound, FormID BoltSound, FormID HitSound, FormID AreaSound, Single ConstantEffectEnchantmentFactor, Single ConstantEffectBarterFactor, MagicEffectArchetype Archetype, ActorValues ActorValue)
		{
			this.MagicEffectFlags = MagicEffectFlags;
			this.BaseCost = BaseCost;
			this.AssociatedItem = AssociatedItem;
			this.MagicSchool = MagicSchool;
			this.ResistanceType = ResistanceType;
			this.Unknown = Unknown;
			this.Unused = Unused;
			this.Light = Light;
			this.ProjectileSpeed = ProjectileSpeed;
			this.EffectShader = EffectShader;
			this.ObjectDisplayShader = ObjectDisplayShader;
			this.EffectSound = EffectSound;
			this.BoltSound = BoltSound;
			this.HitSound = HitSound;
			this.AreaSound = AreaSound;
			this.ConstantEffectEnchantmentFactor = ConstantEffectEnchantmentFactor;
			this.ConstantEffectBarterFactor = ConstantEffectBarterFactor;
			this.Archetype = Archetype;
			this.ActorValue = ActorValue;
		}

		public MagicEffectData(MagicEffectData copyObject)
		{
			MagicEffectFlags = copyObject.MagicEffectFlags;
			BaseCost = copyObject.BaseCost;
			if (copyObject.AssociatedItem != null)
				AssociatedItem = (FormID)copyObject.AssociatedItem.Clone();
			MagicSchool = copyObject.MagicSchool;
			ResistanceType = copyObject.ResistanceType;
			Unknown = copyObject.Unknown;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			if (copyObject.Light != null)
				Light = (FormID)copyObject.Light.Clone();
			ProjectileSpeed = copyObject.ProjectileSpeed;
			if (copyObject.EffectShader != null)
				EffectShader = (FormID)copyObject.EffectShader.Clone();
			if (copyObject.ObjectDisplayShader != null)
				ObjectDisplayShader = (FormID)copyObject.ObjectDisplayShader.Clone();
			if (copyObject.EffectSound != null)
				EffectSound = (FormID)copyObject.EffectSound.Clone();
			if (copyObject.BoltSound != null)
				BoltSound = (FormID)copyObject.BoltSound.Clone();
			if (copyObject.HitSound != null)
				HitSound = (FormID)copyObject.HitSound.Clone();
			if (copyObject.AreaSound != null)
				AreaSound = (FormID)copyObject.AreaSound.Clone();
			ConstantEffectEnchantmentFactor = copyObject.ConstantEffectEnchantmentFactor;
			ConstantEffectBarterFactor = copyObject.ConstantEffectBarterFactor;
			Archetype = copyObject.Archetype;
			ActorValue = copyObject.ActorValue;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MagicEffectFlags = subReader.ReadEnum<MagicEffectFlags>();
					BaseCost = subReader.ReadSingle();
					AssociatedItem.ReadBinary(subReader);
					MagicSchool = subReader.ReadEnum<MagicSchool>();
					ResistanceType = subReader.ReadEnum<ActorValues>();
					Unknown = subReader.ReadUInt16();
					Unused = subReader.ReadBytes(2);
					Light.ReadBinary(subReader);
					ProjectileSpeed = subReader.ReadSingle();
					EffectShader.ReadBinary(subReader);
					ObjectDisplayShader.ReadBinary(subReader);
					EffectSound.ReadBinary(subReader);
					BoltSound.ReadBinary(subReader);
					HitSound.ReadBinary(subReader);
					AreaSound.ReadBinary(subReader);
					ConstantEffectEnchantmentFactor = subReader.ReadSingle();
					ConstantEffectBarterFactor = subReader.ReadSingle();
					Archetype = subReader.ReadEnum<MagicEffectArchetype>();
					ActorValue = subReader.ReadEnum<ActorValues>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)MagicEffectFlags);
			writer.Write(BaseCost);
			AssociatedItem.WriteBinary(writer);
			writer.Write((Int32)MagicSchool);
			writer.Write((Int32)ResistanceType);
			writer.Write(Unknown);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
			Light.WriteBinary(writer);
			writer.Write(ProjectileSpeed);
			EffectShader.WriteBinary(writer);
			ObjectDisplayShader.WriteBinary(writer);
			EffectSound.WriteBinary(writer);
			BoltSound.WriteBinary(writer);
			HitSound.WriteBinary(writer);
			AreaSound.WriteBinary(writer);
			writer.Write(ConstantEffectEnchantmentFactor);
			writer.Write(ConstantEffectBarterFactor);
			writer.Write((UInt32)Archetype);
			writer.Write((Int32)ActorValue);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = MagicEffectFlags.ToString();

			ele.TryPathTo("BaseCost", true, out subEle);
			subEle.Value = BaseCost.ToString("G15");

			ele.TryPathTo("AssociatedItem", true, out subEle);
			AssociatedItem.WriteXML(subEle, master);

			ele.TryPathTo("MagicSchool", true, out subEle);
			subEle.Value = MagicSchool.ToString();

			ele.TryPathTo("ResistanceType", true, out subEle);
			subEle.Value = ResistanceType.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Light", true, out subEle);
			Light.WriteXML(subEle, master);

			ele.TryPathTo("ProjectileSpeed", true, out subEle);
			subEle.Value = ProjectileSpeed.ToString("G15");

			ele.TryPathTo("EffectShader", true, out subEle);
			EffectShader.WriteXML(subEle, master);

			ele.TryPathTo("ObjectDisplayShader", true, out subEle);
			ObjectDisplayShader.WriteXML(subEle, master);

			ele.TryPathTo("EffectSound", true, out subEle);
			EffectSound.WriteXML(subEle, master);

			ele.TryPathTo("BoltSound", true, out subEle);
			BoltSound.WriteXML(subEle, master);

			ele.TryPathTo("HitSound", true, out subEle);
			HitSound.WriteXML(subEle, master);

			ele.TryPathTo("AreaSound", true, out subEle);
			AreaSound.WriteXML(subEle, master);

			ele.TryPathTo("ConstantEffectEnchantmentFactor", true, out subEle);
			subEle.Value = ConstantEffectEnchantmentFactor.ToString("G15");

			ele.TryPathTo("ConstantEffectBarterFactor", true, out subEle);
			subEle.Value = ConstantEffectBarterFactor.ToString("G15");

			ele.TryPathTo("Archetype", true, out subEle);
			subEle.Value = Archetype.ToString();

			ele.TryPathTo("ActorValue", true, out subEle);
			subEle.Value = ActorValue.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				MagicEffectFlags = subEle.ToEnum<MagicEffectFlags>();

			if (ele.TryPathTo("BaseCost", false, out subEle))
				BaseCost = subEle.ToSingle();

			if (ele.TryPathTo("AssociatedItem", false, out subEle))
				AssociatedItem.ReadXML(subEle, master);

			if (ele.TryPathTo("MagicSchool", false, out subEle))
				MagicSchool = subEle.ToEnum<MagicSchool>();

			if (ele.TryPathTo("ResistanceType", false, out subEle))
				ResistanceType = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToUInt16();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Light", false, out subEle))
				Light.ReadXML(subEle, master);

			if (ele.TryPathTo("ProjectileSpeed", false, out subEle))
				ProjectileSpeed = subEle.ToSingle();

			if (ele.TryPathTo("EffectShader", false, out subEle))
				EffectShader.ReadXML(subEle, master);

			if (ele.TryPathTo("ObjectDisplayShader", false, out subEle))
				ObjectDisplayShader.ReadXML(subEle, master);

			if (ele.TryPathTo("EffectSound", false, out subEle))
				EffectSound.ReadXML(subEle, master);

			if (ele.TryPathTo("BoltSound", false, out subEle))
				BoltSound.ReadXML(subEle, master);

			if (ele.TryPathTo("HitSound", false, out subEle))
				HitSound.ReadXML(subEle, master);

			if (ele.TryPathTo("AreaSound", false, out subEle))
				AreaSound.ReadXML(subEle, master);

			if (ele.TryPathTo("ConstantEffectEnchantmentFactor", false, out subEle))
				ConstantEffectEnchantmentFactor = subEle.ToSingle();

			if (ele.TryPathTo("ConstantEffectBarterFactor", false, out subEle))
				ConstantEffectBarterFactor = subEle.ToSingle();

			if (ele.TryPathTo("Archetype", false, out subEle))
				Archetype = subEle.ToEnum<MagicEffectArchetype>();

			if (ele.TryPathTo("ActorValue", false, out subEle))
				ActorValue = subEle.ToEnum<ActorValues>();
		}

		public override object Clone()
		{
			return new MagicEffectData(this);
		}

        public int CompareTo(MagicEffectData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(MagicEffectData objA, MagicEffectData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(MagicEffectData objA, MagicEffectData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(MagicEffectData objA, MagicEffectData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(MagicEffectData objA, MagicEffectData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(MagicEffectData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MagicEffectFlags == other.MagicEffectFlags &&
				BaseCost == other.BaseCost &&
				AssociatedItem == other.AssociatedItem &&
				MagicSchool == other.MagicSchool &&
				ResistanceType == other.ResistanceType &&
				Unknown == other.Unknown &&
				Unused.SequenceEqual(other.Unused) &&
				Light == other.Light &&
				ProjectileSpeed == other.ProjectileSpeed &&
				EffectShader == other.EffectShader &&
				ObjectDisplayShader == other.ObjectDisplayShader &&
				EffectSound == other.EffectSound &&
				BoltSound == other.BoltSound &&
				HitSound == other.HitSound &&
				AreaSound == other.AreaSound &&
				ConstantEffectEnchantmentFactor == other.ConstantEffectEnchantmentFactor &&
				ConstantEffectBarterFactor == other.ConstantEffectBarterFactor &&
				Archetype == other.Archetype &&
				ActorValue == other.ActorValue;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            MagicEffectData other = obj as MagicEffectData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return AssociatedItem.GetHashCode();
        }

        public static bool operator ==(MagicEffectData objA, MagicEffectData objB)
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

        public static bool operator !=(MagicEffectData objA, MagicEffectData objB)
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