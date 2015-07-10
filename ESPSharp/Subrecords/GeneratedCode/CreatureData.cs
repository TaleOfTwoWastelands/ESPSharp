
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
	public partial class CreatureData : Subrecord, ICloneable<CreatureData>, IComparable<CreatureData>, IEquatable<CreatureData>  
	{
		public CreatureType CreatureType { get; set; }
		public Byte CombatSkill { get; set; }
		public Byte MagicSkill { get; set; }
		public Byte StealthSkill { get; set; }
		public Int16 Health { get; set; }
		public Byte[] Unused { get; set; }
		public Int16 Damage { get; set; }
		public Byte Strength { get; set; }
		public Byte Perception { get; set; }
		public Byte Endurance { get; set; }
		public Byte Charisma { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Agility { get; set; }
		public Byte Luck { get; set; }

		public CreatureData()
		{
			CreatureType = new CreatureType();
			CombatSkill = new Byte();
			MagicSkill = new Byte();
			StealthSkill = new Byte();
			Health = new Int16();
			Unused = new byte[2];
			Damage = new Int16();
			Strength = new Byte();
			Perception = new Byte();
			Endurance = new Byte();
			Charisma = new Byte();
			Intelligence = new Byte();
			Agility = new Byte();
			Luck = new Byte();
		}

		public CreatureData(CreatureType CreatureType, Byte CombatSkill, Byte MagicSkill, Byte StealthSkill, Int16 Health, Byte[] Unused, Int16 Damage, Byte Strength, Byte Perception, Byte Endurance, Byte Charisma, Byte Intelligence, Byte Agility, Byte Luck)
		{
			this.CreatureType = CreatureType;
			this.CombatSkill = CombatSkill;
			this.MagicSkill = MagicSkill;
			this.StealthSkill = StealthSkill;
			this.Health = Health;
			this.Unused = Unused;
			this.Damage = Damage;
			this.Strength = Strength;
			this.Perception = Perception;
			this.Endurance = Endurance;
			this.Charisma = Charisma;
			this.Intelligence = Intelligence;
			this.Agility = Agility;
			this.Luck = Luck;
		}

		public CreatureData(CreatureData copyObject)
		{
			CreatureType = copyObject.CreatureType;
			CombatSkill = copyObject.CombatSkill;
			MagicSkill = copyObject.MagicSkill;
			StealthSkill = copyObject.StealthSkill;
			Health = copyObject.Health;
			Unused = (Byte[])copyObject.Unused.Clone();
			Damage = copyObject.Damage;
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
					CreatureType = subReader.ReadEnum<CreatureType>();
					CombatSkill = subReader.ReadByte();
					MagicSkill = subReader.ReadByte();
					StealthSkill = subReader.ReadByte();
					Health = subReader.ReadInt16();
					Unused = subReader.ReadBytes(2);
					Damage = subReader.ReadInt16();
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
			writer.Write((Byte)CreatureType);
			writer.Write(CombatSkill);
			writer.Write(MagicSkill);
			writer.Write(StealthSkill);
			writer.Write(Health);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
			writer.Write(Damage);
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
			
			ele.TryPathTo("CreatureType", true, out subEle);
			subEle.Value = CreatureType.ToString();

			ele.TryPathTo("Skill/Combat", true, out subEle);
			subEle.Value = CombatSkill.ToString();

			ele.TryPathTo("Skill/Magic", true, out subEle);
			subEle.Value = MagicSkill.ToString();

			ele.TryPathTo("Skill/Stealth", true, out subEle);
			subEle.Value = StealthSkill.ToString();

			ele.TryPathTo("Health", true, out subEle);
			subEle.Value = Health.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Damage", true, out subEle);
			subEle.Value = Damage.ToString();

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
			
			if (ele.TryPathTo("CreatureType", false, out subEle))
				CreatureType = subEle.ToEnum<CreatureType>();

			if (ele.TryPathTo("Skill/Combat", false, out subEle))
				CombatSkill = subEle.ToByte();

			if (ele.TryPathTo("Skill/Magic", false, out subEle))
				MagicSkill = subEle.ToByte();

			if (ele.TryPathTo("Skill/Stealth", false, out subEle))
				StealthSkill = subEle.ToByte();

			if (ele.TryPathTo("Health", false, out subEle))
				Health = subEle.ToInt16();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Damage", false, out subEle))
				Damage = subEle.ToInt16();

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

		public CreatureData Clone()
		{
			return new CreatureData(this);
		}

        public int CompareTo(CreatureData other)
        {
			return CreatureType.CompareTo(other.CreatureType);
        }

        public static bool operator >(CreatureData objA, CreatureData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CreatureData objA, CreatureData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CreatureData objA, CreatureData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CreatureData objA, CreatureData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CreatureData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return CreatureType == other.CreatureType &&
				CombatSkill == other.CombatSkill &&
				MagicSkill == other.MagicSkill &&
				StealthSkill == other.StealthSkill &&
				Health == other.Health &&
				Unused.SequenceEqual(other.Unused) &&
				Damage == other.Damage &&
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

            CreatureData other = obj as CreatureData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return CreatureType.GetHashCode();
        }

        public static bool operator ==(CreatureData objA, CreatureData objB)
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

        public static bool operator !=(CreatureData objA, CreatureData objB)
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