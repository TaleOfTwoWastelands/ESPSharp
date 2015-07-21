
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
	public partial class FootstepMaterial : Subrecord, ICloneable, IComparable<FootstepMaterial>, IEquatable<FootstepMaterial>  
	{
		public Byte[] ConcreteSolid { get; set; }
		public Byte[] ConcreteBroken { get; set; }
		public Byte[] MetalSolid { get; set; }
		public Byte[] MetalHollow { get; set; }
		public Byte[] MetalSheet { get; set; }
		public Byte[] Wood { get; set; }
		public Byte[] Sand { get; set; }
		public Byte[] Dirt { get; set; }
		public Byte[] Grass { get; set; }
		public Byte[] Water { get; set; }

		public FootstepMaterial(string Tag = null)
			:base(Tag)
		{
			ConcreteSolid = new byte[30];
			ConcreteBroken = new byte[30];
			MetalSolid = new byte[30];
			MetalHollow = new byte[30];
			MetalSheet = new byte[30];
			Wood = new byte[30];
			Sand = new byte[30];
			Dirt = new byte[30];
			Grass = new byte[30];
			Water = new byte[30];
		}

		public FootstepMaterial(Byte[] ConcreteSolid, Byte[] ConcreteBroken, Byte[] MetalSolid, Byte[] MetalHollow, Byte[] MetalSheet, Byte[] Wood, Byte[] Sand, Byte[] Dirt, Byte[] Grass, Byte[] Water)
		{
			this.ConcreteSolid = ConcreteSolid;
			this.ConcreteBroken = ConcreteBroken;
			this.MetalSolid = MetalSolid;
			this.MetalHollow = MetalHollow;
			this.MetalSheet = MetalSheet;
			this.Wood = Wood;
			this.Sand = Sand;
			this.Dirt = Dirt;
			this.Grass = Grass;
			this.Water = Water;
		}

		public FootstepMaterial(FootstepMaterial copyObject)
		{
			if (copyObject.ConcreteSolid != null)
				ConcreteSolid = (Byte[])copyObject.ConcreteSolid.Clone();
			if (copyObject.ConcreteBroken != null)
				ConcreteBroken = (Byte[])copyObject.ConcreteBroken.Clone();
			if (copyObject.MetalSolid != null)
				MetalSolid = (Byte[])copyObject.MetalSolid.Clone();
			if (copyObject.MetalHollow != null)
				MetalHollow = (Byte[])copyObject.MetalHollow.Clone();
			if (copyObject.MetalSheet != null)
				MetalSheet = (Byte[])copyObject.MetalSheet.Clone();
			if (copyObject.Wood != null)
				Wood = (Byte[])copyObject.Wood.Clone();
			if (copyObject.Sand != null)
				Sand = (Byte[])copyObject.Sand.Clone();
			if (copyObject.Dirt != null)
				Dirt = (Byte[])copyObject.Dirt.Clone();
			if (copyObject.Grass != null)
				Grass = (Byte[])copyObject.Grass.Clone();
			if (copyObject.Water != null)
				Water = (Byte[])copyObject.Water.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					ConcreteSolid = subReader.ReadBytes(30);
					ConcreteBroken = subReader.ReadBytes(30);
					MetalSolid = subReader.ReadBytes(30);
					MetalHollow = subReader.ReadBytes(30);
					MetalSheet = subReader.ReadBytes(30);
					Wood = subReader.ReadBytes(30);
					Sand = subReader.ReadBytes(30);
					Dirt = subReader.ReadBytes(30);
					Grass = subReader.ReadBytes(30);
					Water = subReader.ReadBytes(30);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			if (ConcreteSolid == null)
				writer.Write(new byte[30]);
			else
			writer.Write(ConcreteSolid);
			if (ConcreteBroken == null)
				writer.Write(new byte[30]);
			else
			writer.Write(ConcreteBroken);
			if (MetalSolid == null)
				writer.Write(new byte[30]);
			else
			writer.Write(MetalSolid);
			if (MetalHollow == null)
				writer.Write(new byte[30]);
			else
			writer.Write(MetalHollow);
			if (MetalSheet == null)
				writer.Write(new byte[30]);
			else
			writer.Write(MetalSheet);
			if (Wood == null)
				writer.Write(new byte[30]);
			else
			writer.Write(Wood);
			if (Sand == null)
				writer.Write(new byte[30]);
			else
			writer.Write(Sand);
			if (Dirt == null)
				writer.Write(new byte[30]);
			else
			writer.Write(Dirt);
			if (Grass == null)
				writer.Write(new byte[30]);
			else
			writer.Write(Grass);
			if (Water == null)
				writer.Write(new byte[30]);
			else
			writer.Write(Water);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("ConcreteSolid", true, out subEle);
			subEle.Value = ConcreteSolid.ToHex();

			ele.TryPathTo("ConcreteBroken", true, out subEle);
			subEle.Value = ConcreteBroken.ToHex();

			ele.TryPathTo("MetalSolid", true, out subEle);
			subEle.Value = MetalSolid.ToHex();

			ele.TryPathTo("MetalHollow", true, out subEle);
			subEle.Value = MetalHollow.ToHex();

			ele.TryPathTo("MetalSheet", true, out subEle);
			subEle.Value = MetalSheet.ToHex();

			ele.TryPathTo("Wood", true, out subEle);
			subEle.Value = Wood.ToHex();

			ele.TryPathTo("Sand", true, out subEle);
			subEle.Value = Sand.ToHex();

			ele.TryPathTo("Dirt", true, out subEle);
			subEle.Value = Dirt.ToHex();

			ele.TryPathTo("Grass", true, out subEle);
			subEle.Value = Grass.ToHex();

			ele.TryPathTo("Water", true, out subEle);
			subEle.Value = Water.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ConcreteSolid", false, out subEle))
				ConcreteSolid = subEle.ToBytes();

			if (ele.TryPathTo("ConcreteBroken", false, out subEle))
				ConcreteBroken = subEle.ToBytes();

			if (ele.TryPathTo("MetalSolid", false, out subEle))
				MetalSolid = subEle.ToBytes();

			if (ele.TryPathTo("MetalHollow", false, out subEle))
				MetalHollow = subEle.ToBytes();

			if (ele.TryPathTo("MetalSheet", false, out subEle))
				MetalSheet = subEle.ToBytes();

			if (ele.TryPathTo("Wood", false, out subEle))
				Wood = subEle.ToBytes();

			if (ele.TryPathTo("Sand", false, out subEle))
				Sand = subEle.ToBytes();

			if (ele.TryPathTo("Dirt", false, out subEle))
				Dirt = subEle.ToBytes();

			if (ele.TryPathTo("Grass", false, out subEle))
				Grass = subEle.ToBytes();

			if (ele.TryPathTo("Water", false, out subEle))
				Water = subEle.ToBytes();
		}

		public override object Clone()
		{
			return new FootstepMaterial(this);
		}

        public int CompareTo(FootstepMaterial other)
        {
			return ConcreteSolid.GetHashCode().CompareTo(other.ConcreteSolid.GetHashCode());
        }

        public static bool operator >(FootstepMaterial objA, FootstepMaterial objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(FootstepMaterial objA, FootstepMaterial objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(FootstepMaterial objA, FootstepMaterial objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(FootstepMaterial objA, FootstepMaterial objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(FootstepMaterial other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ConcreteSolid.SequenceEqual(other.ConcreteSolid) &&
				ConcreteBroken.SequenceEqual(other.ConcreteBroken) &&
				MetalSolid.SequenceEqual(other.MetalSolid) &&
				MetalHollow.SequenceEqual(other.MetalHollow) &&
				MetalSheet.SequenceEqual(other.MetalSheet) &&
				Wood.SequenceEqual(other.Wood) &&
				Sand.SequenceEqual(other.Sand) &&
				Dirt.SequenceEqual(other.Dirt) &&
				Grass.SequenceEqual(other.Grass) &&
				Water.SequenceEqual(other.Water);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            FootstepMaterial other = obj as FootstepMaterial;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ConcreteSolid.GetHashCode();
        }

        public static bool operator ==(FootstepMaterial objA, FootstepMaterial objB)
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

        public static bool operator !=(FootstepMaterial objA, FootstepMaterial objB)
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