
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
	public partial class FactionMembership : Subrecord, ICloneable<FactionMembership>, IComparable<FactionMembership>, IEquatable<FactionMembership>  
	{
		public FormID Faction { get; set; }
		public Byte Rank { get; set; }
		public Byte[] Unused { get; set; }

		public FactionMembership()
		{
			Faction = new FormID();
			Rank = new Byte();
			Unused = new byte[3];
		}

		public FactionMembership(FormID Faction, Byte Rank, Byte[] Unused)
		{
			this.Faction = Faction;
			this.Rank = Rank;
			this.Unused = Unused;
		}

		public FactionMembership(FactionMembership copyObject)
		{
			Faction = copyObject.Faction.Clone();
			Rank = copyObject.Rank;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Faction.ReadBinary(subReader);
					Rank = subReader.ReadByte();
					Unused = subReader.ReadBytes(3);
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
			writer.Write(Rank);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Faction", true, out subEle);
			Faction.WriteXML(subEle, master);

			ele.TryPathTo("Rank", true, out subEle);
			subEle.Value = Rank.ToString();

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Faction", false, out subEle))
				Faction.ReadXML(subEle, master);

			if (ele.TryPathTo("Rank", false, out subEle))
				Rank = subEle.ToByte();

			ReadUnusedXML(ele, master);
		}

		public FactionMembership Clone()
		{
			return new FactionMembership(this);
		}

        public int CompareTo(FactionMembership other)
        {
			return Faction.CompareTo(other.Faction);
        }

        public static bool operator >(FactionMembership objA, FactionMembership objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(FactionMembership objA, FactionMembership objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(FactionMembership objA, FactionMembership objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(FactionMembership objA, FactionMembership objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(FactionMembership other)
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
				Rank == other.Rank &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            FactionMembership other = obj as FactionMembership;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Faction.GetHashCode();
        }

        public static bool operator ==(FactionMembership objA, FactionMembership objB)
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

        public static bool operator !=(FactionMembership objA, FactionMembership objB)
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