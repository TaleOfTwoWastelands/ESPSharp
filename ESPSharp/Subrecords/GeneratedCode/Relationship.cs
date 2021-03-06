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
	public partial class Relationship : Subrecord, ICloneable, IComparable<Relationship>, IEquatable<Relationship>  
	{
		public FormID Faction { get; set; }
		public Int32 Modifier { get; set; }
		public RelationshipCombatReaction CombatReaction { get; set; }


		public Relationship(string Tag = null)
			:base(Tag)
		{
			Faction = new FormID();
			Modifier = new Int32();
			CombatReaction = new RelationshipCombatReaction();

		}

		public Relationship(FormID Faction, Int32 Modifier, RelationshipCombatReaction CombatReaction)
		{
			this.Faction = Faction;
			this.Modifier = Modifier;
			this.CombatReaction = CombatReaction;

		}

		public Relationship(Relationship copyObject)
		{
			if (copyObject.Faction != null)
				Faction = (FormID)copyObject.Faction.Clone();
			Modifier = copyObject.Modifier;
			CombatReaction = copyObject.CombatReaction;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Faction.ReadBinary(subReader);
					Modifier = subReader.ReadInt32();
					CombatReaction = subReader.ReadEnum<RelationshipCombatReaction>();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Faction.WriteBinary(writer);
			writer.Write(Modifier);
			writer.Write((UInt32)CombatReaction);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Faction", true, out subEle);
			Faction.WriteXML(subEle, master);

			ele.TryPathTo("Modifier", true, out subEle);
			subEle.Value = Modifier.ToString();

			ele.TryPathTo("CombatReaction", true, out subEle);
			subEle.Value = CombatReaction.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Faction", false, out subEle))
				Faction.ReadXML(subEle, master);

			if (ele.TryPathTo("Modifier", false, out subEle))
				Modifier = subEle.ToInt32();

			if (ele.TryPathTo("CombatReaction", false, out subEle))
				CombatReaction = subEle.ToEnum<RelationshipCombatReaction>();

		}

		public override object Clone()
		{
			return new Relationship(this);
		}


        public int CompareTo(Relationship other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(Relationship objA, Relationship objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(Relationship objA, Relationship objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(Relationship objA, Relationship objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(Relationship objA, Relationship objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(Relationship other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Faction == other.Faction &&
				Modifier == other.Modifier &&
				CombatReaction == other.CombatReaction;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            Relationship other = obj as Relationship;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Faction.GetHashCode();
        }

        public static bool operator ==(Relationship objA, Relationship objB)
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

        public static bool operator !=(Relationship objA, Relationship objB)
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