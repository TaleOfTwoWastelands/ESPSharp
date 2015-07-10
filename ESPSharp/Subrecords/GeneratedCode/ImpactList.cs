
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
	public partial class ImpactList : Subrecord, ICloneable<ImpactList>, IComparable<ImpactList>, IEquatable<ImpactList>  
	{
		public FormID Stone { get; set; }
		public FormID Dirt { get; set; }
		public FormID Grass { get; set; }
		public FormID Glass { get; set; }
		public FormID Metal { get; set; }
		public FormID Wood { get; set; }
		public FormID Organic { get; set; }
		public FormID Cloth { get; set; }
		public FormID Water { get; set; }
		public FormID HollowMetal { get; set; }
		public FormID OrganicBug { get; set; }
		public FormID OrganicGlow { get; set; }

		public ImpactList()
		{
			Stone = new FormID();
			Dirt = new FormID();
			Grass = new FormID();
			Glass = new FormID();
			Metal = new FormID();
			Wood = new FormID();
			Organic = new FormID();
			Cloth = new FormID();
			Water = new FormID();
			HollowMetal = new FormID();
			OrganicBug = new FormID();
			OrganicGlow = new FormID();
		}

		public ImpactList(FormID Stone, FormID Dirt, FormID Grass, FormID Glass, FormID Metal, FormID Wood, FormID Organic, FormID Cloth, FormID Water, FormID HollowMetal, FormID OrganicBug, FormID OrganicGlow)
		{
			this.Stone = Stone;
			this.Dirt = Dirt;
			this.Grass = Grass;
			this.Glass = Glass;
			this.Metal = Metal;
			this.Wood = Wood;
			this.Organic = Organic;
			this.Cloth = Cloth;
			this.Water = Water;
			this.HollowMetal = HollowMetal;
			this.OrganicBug = OrganicBug;
			this.OrganicGlow = OrganicGlow;
		}

		public ImpactList(ImpactList copyObject)
		{
			Stone = copyObject.Stone.Clone();
			Dirt = copyObject.Dirt.Clone();
			Grass = copyObject.Grass.Clone();
			Glass = copyObject.Glass.Clone();
			Metal = copyObject.Metal.Clone();
			Wood = copyObject.Wood.Clone();
			Organic = copyObject.Organic.Clone();
			Cloth = copyObject.Cloth.Clone();
			Water = copyObject.Water.Clone();
			HollowMetal = copyObject.HollowMetal.Clone();
			OrganicBug = copyObject.OrganicBug.Clone();
			OrganicGlow = copyObject.OrganicGlow.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Stone.ReadBinary(subReader);
					Dirt.ReadBinary(subReader);
					Grass.ReadBinary(subReader);
					Glass.ReadBinary(subReader);
					Metal.ReadBinary(subReader);
					Wood.ReadBinary(subReader);
					Organic.ReadBinary(subReader);
					Cloth.ReadBinary(subReader);
					Water.ReadBinary(subReader);
					HollowMetal.ReadBinary(subReader);
					OrganicBug.ReadBinary(subReader);
					OrganicGlow.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Stone.WriteBinary(writer);
			Dirt.WriteBinary(writer);
			Grass.WriteBinary(writer);
			Glass.WriteBinary(writer);
			Metal.WriteBinary(writer);
			Wood.WriteBinary(writer);
			Organic.WriteBinary(writer);
			Cloth.WriteBinary(writer);
			Water.WriteBinary(writer);
			HollowMetal.WriteBinary(writer);
			OrganicBug.WriteBinary(writer);
			OrganicGlow.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Stone", true, out subEle);
			Stone.WriteXML(subEle, master);

			ele.TryPathTo("Dirt", true, out subEle);
			Dirt.WriteXML(subEle, master);

			ele.TryPathTo("Grass", true, out subEle);
			Grass.WriteXML(subEle, master);

			ele.TryPathTo("Glass", true, out subEle);
			Glass.WriteXML(subEle, master);

			ele.TryPathTo("Metal", true, out subEle);
			Metal.WriteXML(subEle, master);

			ele.TryPathTo("Wood", true, out subEle);
			Wood.WriteXML(subEle, master);

			ele.TryPathTo("Organic", true, out subEle);
			Organic.WriteXML(subEle, master);

			ele.TryPathTo("Cloth", true, out subEle);
			Cloth.WriteXML(subEle, master);

			ele.TryPathTo("Water", true, out subEle);
			Water.WriteXML(subEle, master);

			ele.TryPathTo("HollowMetal", true, out subEle);
			HollowMetal.WriteXML(subEle, master);

			ele.TryPathTo("OrganicBug", true, out subEle);
			OrganicBug.WriteXML(subEle, master);

			ele.TryPathTo("OrganicGlow", true, out subEle);
			OrganicGlow.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Stone", false, out subEle))
				Stone.ReadXML(subEle, master);

			if (ele.TryPathTo("Dirt", false, out subEle))
				Dirt.ReadXML(subEle, master);

			if (ele.TryPathTo("Grass", false, out subEle))
				Grass.ReadXML(subEle, master);

			if (ele.TryPathTo("Glass", false, out subEle))
				Glass.ReadXML(subEle, master);

			if (ele.TryPathTo("Metal", false, out subEle))
				Metal.ReadXML(subEle, master);

			if (ele.TryPathTo("Wood", false, out subEle))
				Wood.ReadXML(subEle, master);

			if (ele.TryPathTo("Organic", false, out subEle))
				Organic.ReadXML(subEle, master);

			if (ele.TryPathTo("Cloth", false, out subEle))
				Cloth.ReadXML(subEle, master);

			if (ele.TryPathTo("Water", false, out subEle))
				Water.ReadXML(subEle, master);

			if (ele.TryPathTo("HollowMetal", false, out subEle))
				HollowMetal.ReadXML(subEle, master);

			if (ele.TryPathTo("OrganicBug", false, out subEle))
				OrganicBug.ReadXML(subEle, master);

			if (ele.TryPathTo("OrganicGlow", false, out subEle))
				OrganicGlow.ReadXML(subEle, master);
		}

		public ImpactList Clone()
		{
			return new ImpactList(this);
		}

        public int CompareTo(ImpactList other)
        {
			return Stone.CompareTo(other.Stone);
        }

        public static bool operator >(ImpactList objA, ImpactList objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ImpactList objA, ImpactList objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ImpactList objA, ImpactList objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ImpactList objA, ImpactList objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ImpactList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Stone == other.Stone &&
				Dirt == other.Dirt &&
				Grass == other.Grass &&
				Glass == other.Glass &&
				Metal == other.Metal &&
				Wood == other.Wood &&
				Organic == other.Organic &&
				Cloth == other.Cloth &&
				Water == other.Water &&
				HollowMetal == other.HollowMetal &&
				OrganicBug == other.OrganicBug &&
				OrganicGlow == other.OrganicGlow;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ImpactList other = obj as ImpactList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Stone.GetHashCode();
        }

        public static bool operator ==(ImpactList objA, ImpactList objB)
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

        public static bool operator !=(ImpactList objA, ImpactList objB)
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