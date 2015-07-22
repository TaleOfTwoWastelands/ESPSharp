
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
	public partial class Attributes : Subrecord, ICloneable, IComparable<Attributes>, IEquatable<Attributes>  
	{
		public Byte Strength { get; set; }
		public Byte Perception { get; set; }
		public Byte Endurance { get; set; }
		public Byte Charisma { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Agility { get; set; }
		public Byte Luck { get; set; }

		public Attributes(string Tag = null)
			:base(Tag)
		{
			Strength = new Byte();
			Perception = new Byte();
			Endurance = new Byte();
			Charisma = new Byte();
			Intelligence = new Byte();
			Agility = new Byte();
			Luck = new Byte();
		}

		public Attributes(Byte Strength, Byte Perception, Byte Endurance, Byte Charisma, Byte Intelligence, Byte Agility, Byte Luck)
		{
			this.Strength = Strength;
			this.Perception = Perception;
			this.Endurance = Endurance;
			this.Charisma = Charisma;
			this.Intelligence = Intelligence;
			this.Agility = Agility;
			this.Luck = Luck;
		}

		public Attributes(Attributes copyObject)
		{
			Strength = copyObject.Strength;
			Perception = copyObject.Perception;
			Endurance = copyObject.Endurance;
			Charisma = copyObject.Charisma;
			Intelligence = copyObject.Intelligence;
			Agility = copyObject.Agility;
			Luck = copyObject.Luck;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Strength = subReader.ReadByte();
					Perception = subReader.ReadByte();
					Endurance = subReader.ReadByte();
					Charisma = subReader.ReadByte();
					Intelligence = subReader.ReadByte();
					Agility = subReader.ReadByte();
					Luck = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Strength);
			writer.Write(Perception);
			writer.Write(Endurance);
			writer.Write(Charisma);
			writer.Write(Intelligence);
			writer.Write(Agility);
			writer.Write(Luck);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Strength", true, out subEle);
			subEle.Value = Strength.ToString();

			ele.TryPathTo("Perception", true, out subEle);
			subEle.Value = Perception.ToString();

			ele.TryPathTo("Endurance", true, out subEle);
			subEle.Value = Endurance.ToString();

			ele.TryPathTo("Charisma", true, out subEle);
			subEle.Value = Charisma.ToString();

			ele.TryPathTo("Intelligence", true, out subEle);
			subEle.Value = Intelligence.ToString();

			ele.TryPathTo("Agility", true, out subEle);
			subEle.Value = Agility.ToString();

			ele.TryPathTo("Luck", true, out subEle);
			subEle.Value = Luck.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Strength", false, out subEle))
				Strength = subEle.ToByte();

			if (ele.TryPathTo("Perception", false, out subEle))
				Perception = subEle.ToByte();

			if (ele.TryPathTo("Endurance", false, out subEle))
				Endurance = subEle.ToByte();

			if (ele.TryPathTo("Charisma", false, out subEle))
				Charisma = subEle.ToByte();

			if (ele.TryPathTo("Intelligence", false, out subEle))
				Intelligence = subEle.ToByte();

			if (ele.TryPathTo("Agility", false, out subEle))
				Agility = subEle.ToByte();

			if (ele.TryPathTo("Luck", false, out subEle))
				Luck = subEle.ToByte();
		}

		public override object Clone()
		{
			return new Attributes(this);
		}

        public int CompareTo(Attributes other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(Attributes objA, Attributes objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(Attributes objA, Attributes objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(Attributes objA, Attributes objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(Attributes objA, Attributes objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(Attributes other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Strength == other.Strength &&
				Perception == other.Perception &&
				Endurance == other.Endurance &&
				Charisma == other.Charisma &&
				Intelligence == other.Intelligence &&
				Agility == other.Agility &&
				Luck == other.Luck;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            Attributes other = obj as Attributes;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Strength.GetHashCode();
        }

        public static bool operator ==(Attributes objA, Attributes objB)
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

        public static bool operator !=(Attributes objA, Attributes objB)
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