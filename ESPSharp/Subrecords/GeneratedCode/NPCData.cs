
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
	public partial class NPCData : Subrecord, ICloneable, IComparable<NPCData>, IEquatable<NPCData>  
	{
		public Int32 BaseHealth { get; set; }
		public Byte Strength { get; set; }
		public Byte Perception { get; set; }
		public Byte Endurance { get; set; }
		public Byte Charisma { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Agility { get; set; }
		public Byte Luck { get; set; }

		public NPCData(string Tag = null)
			:base(Tag)
		{
			BaseHealth = new Int32();
			Strength = new Byte();
			Perception = new Byte();
			Endurance = new Byte();
			Charisma = new Byte();
			Intelligence = new Byte();
			Agility = new Byte();
			Luck = new Byte();
		}

		public NPCData(Int32 BaseHealth, Byte Strength, Byte Perception, Byte Endurance, Byte Charisma, Byte Intelligence, Byte Agility, Byte Luck)
		{
			this.BaseHealth = BaseHealth;
			this.Strength = Strength;
			this.Perception = Perception;
			this.Endurance = Endurance;
			this.Charisma = Charisma;
			this.Intelligence = Intelligence;
			this.Agility = Agility;
			this.Luck = Luck;
		}

		public NPCData(NPCData copyObject)
		{
			BaseHealth = copyObject.BaseHealth;
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
					BaseHealth = subReader.ReadInt32();
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
			writer.Write(BaseHealth);
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
			
			ele.TryPathTo("BaseHealth", true, out subEle);
			subEle.Value = BaseHealth.ToString();

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
			
			if (ele.TryPathTo("BaseHealth", false, out subEle))
				BaseHealth = subEle.ToInt32();

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
			return new NPCData(this);
		}

        public int CompareTo(NPCData other)
        {
			return BaseHealth.CompareTo(other.BaseHealth);
        }

        public static bool operator >(NPCData objA, NPCData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NPCData objA, NPCData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NPCData objA, NPCData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NPCData objA, NPCData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(NPCData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return BaseHealth == other.BaseHealth &&
				Strength == other.Strength &&
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

            NPCData other = obj as NPCData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return BaseHealth.GetHashCode();
        }

        public static bool operator ==(NPCData objA, NPCData objB)
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

        public static bool operator !=(NPCData objA, NPCData objB)
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