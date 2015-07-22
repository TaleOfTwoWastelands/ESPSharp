
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
	public partial class PerkAbilityData : Subrecord, ICloneable, IComparable<PerkAbilityData>, IEquatable<PerkAbilityData>  
	{
		public FormID Ability { get; set; }

		public PerkAbilityData(string Tag = null)
			:base(Tag)
		{
			Ability = new FormID();
		}

		public PerkAbilityData(FormID Ability)
		{
			this.Ability = Ability;
		}

		public PerkAbilityData(PerkAbilityData copyObject)
		{
			if (copyObject.Ability != null)
				Ability = (FormID)copyObject.Ability.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Ability.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Ability.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Ability", true, out subEle);
			Ability.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Ability", false, out subEle))
				Ability.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new PerkAbilityData(this);
		}

        public int CompareTo(PerkAbilityData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(PerkAbilityData objA, PerkAbilityData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PerkAbilityData objA, PerkAbilityData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PerkAbilityData objA, PerkAbilityData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PerkAbilityData objA, PerkAbilityData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PerkAbilityData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Ability == other.Ability;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PerkAbilityData other = obj as PerkAbilityData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Ability.GetHashCode();
        }

        public static bool operator ==(PerkAbilityData objA, PerkAbilityData objB)
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

        public static bool operator !=(PerkAbilityData objA, PerkAbilityData objB)
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