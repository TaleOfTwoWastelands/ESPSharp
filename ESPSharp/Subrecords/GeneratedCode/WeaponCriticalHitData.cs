﻿
















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
	public partial class WeaponCriticalHitData : Subrecord, ICloneable, IComparable<WeaponCriticalHitData>, IEquatable<WeaponCriticalHitData>  
	{
		public UInt16 Damage { get; set; }
		public Byte[] Unused1 { get; set; }
		public Single ChanceMult { get; set; }
		public WeaponCritFlags Flags { get; set; }
		public Byte[] Unused2 { get; set; }
		public FormID Effect { get; set; }


		public WeaponCriticalHitData(string Tag = null)
			:base(Tag)
		{
			Damage = new UInt16();
			Unused1 = new byte[2];
			ChanceMult = new Single();
			Flags = new WeaponCritFlags();
			Unused2 = new byte[3];
			Effect = new FormID();

		}

		public WeaponCriticalHitData(UInt16 Damage, Byte[] Unused1, Single ChanceMult, WeaponCritFlags Flags, Byte[] Unused2, FormID Effect)
		{
			this.Damage = Damage;
			this.Unused1 = Unused1;
			this.ChanceMult = ChanceMult;
			this.Flags = Flags;
			this.Unused2 = Unused2;
			this.Effect = Effect;

		}

		public WeaponCriticalHitData(WeaponCriticalHitData copyObject)
		{
			Damage = copyObject.Damage;
			if (copyObject.Unused1 != null)
				Unused1 = (Byte[])copyObject.Unused1.Clone();
			ChanceMult = copyObject.ChanceMult;
			Flags = copyObject.Flags;
			if (copyObject.Unused2 != null)
				Unused2 = (Byte[])copyObject.Unused2.Clone();
			if (copyObject.Effect != null)
				Effect = (FormID)copyObject.Effect.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Damage = subReader.ReadUInt16();
					Unused1 = subReader.ReadBytes(2);
					ChanceMult = subReader.ReadSingle();
					Flags = subReader.ReadEnum<WeaponCritFlags>();
					Unused2 = subReader.ReadBytes(3);
					Effect.ReadBinary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Damage);
			if (Unused1 == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused1);
			writer.Write(ChanceMult);
			writer.Write((Byte)Flags);
			if (Unused2 == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused2);
			Effect.WriteBinary(writer);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Damage", true, out subEle);
			subEle.Value = Damage.ToString();

			WriteUnused1XML(ele, master);

			ele.TryPathTo("ChanceMult", true, out subEle);
			subEle.Value = ChanceMult.ToString("G15");

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnused2XML(ele, master);

			ele.TryPathTo("Effect", true, out subEle);
			Effect.WriteXML(subEle, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Damage", false, out subEle))
				Damage = subEle.ToUInt16();

			ReadUnused1XML(ele, master);

			if (ele.TryPathTo("ChanceMult", false, out subEle))
				ChanceMult = subEle.ToSingle();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<WeaponCritFlags>();

			ReadUnused2XML(ele, master);

			if (ele.TryPathTo("Effect", false, out subEle))
				Effect.ReadXML(subEle, master);

		}

		public override object Clone()
		{
			return new WeaponCriticalHitData(this);
		}


        public int CompareTo(WeaponCriticalHitData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(WeaponCriticalHitData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Damage == other.Damage &&
				Unused1.SequenceEqual(other.Unused1) &&
				ChanceMult == other.ChanceMult &&
				Flags == other.Flags &&
				Unused2.SequenceEqual(other.Unused2) &&
				Effect == other.Effect;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeaponCriticalHitData other = obj as WeaponCriticalHitData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Damage.GetHashCode();
        }

        public static bool operator ==(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
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

        public static bool operator !=(WeaponCriticalHitData objA, WeaponCriticalHitData objB)
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