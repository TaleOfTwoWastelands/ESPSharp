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
	public partial class WeaponData : Subrecord, ICloneable, IComparable<WeaponData>, IEquatable<WeaponData>  
	{
		public Int32 Value { get; set; }
		public Int32 Health { get; set; }
		public Single Weight { get; set; }
		public Int16 BaseDamage { get; set; }
		public Byte ClipSize { get; set; }


		public WeaponData(string Tag = null)
			:base(Tag)
		{
			Value = new Int32();
			Health = new Int32();
			Weight = new Single();
			BaseDamage = new Int16();
			ClipSize = new Byte();

		}

		public WeaponData(Int32 Value, Int32 Health, Single Weight, Int16 BaseDamage, Byte ClipSize)
		{
			this.Value = Value;
			this.Health = Health;
			this.Weight = Weight;
			this.BaseDamage = BaseDamage;
			this.ClipSize = ClipSize;

		}

		public WeaponData(WeaponData copyObject)
		{
			Value = copyObject.Value;
			Health = copyObject.Health;
			Weight = copyObject.Weight;
			BaseDamage = copyObject.BaseDamage;
			ClipSize = copyObject.ClipSize;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Value = subReader.ReadInt32();
					Health = subReader.ReadInt32();
					Weight = subReader.ReadSingle();
					BaseDamage = subReader.ReadInt16();
					ClipSize = subReader.ReadByte();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Value);
			writer.Write(Health);
			writer.Write(Weight);
			writer.Write(BaseDamage);
			writer.Write(ClipSize);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Health", true, out subEle);
			subEle.Value = Health.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");

			ele.TryPathTo("BaseDamage", true, out subEle);
			subEle.Value = BaseDamage.ToString();

			ele.TryPathTo("ClipSize", true, out subEle);
			subEle.Value = ClipSize.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Value", false, out subEle))
				Value = subEle.ToInt32();

			if (ele.TryPathTo("Health", false, out subEle))
				Health = subEle.ToInt32();

			if (ele.TryPathTo("Weight", false, out subEle))
				Weight = subEle.ToSingle();

			if (ele.TryPathTo("BaseDamage", false, out subEle))
				BaseDamage = subEle.ToInt16();

			if (ele.TryPathTo("ClipSize", false, out subEle))
				ClipSize = subEle.ToByte();

		}

		public override object Clone()
		{
			return new WeaponData(this);
		}


        public int CompareTo(WeaponData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(WeaponData objA, WeaponData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WeaponData objA, WeaponData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WeaponData objA, WeaponData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WeaponData objA, WeaponData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(WeaponData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Value == other.Value &&
				Health == other.Health &&
				Weight == other.Weight &&
				BaseDamage == other.BaseDamage &&
				ClipSize == other.ClipSize;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeaponData other = obj as WeaponData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return BaseDamage.GetHashCode();
        }

        public static bool operator ==(WeaponData objA, WeaponData objB)
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

        public static bool operator !=(WeaponData objA, WeaponData objB)
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