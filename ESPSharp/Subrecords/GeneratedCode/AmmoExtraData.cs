
















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
	public partial class AmmoExtraData : Subrecord, ICloneable, IComparable<AmmoExtraData>, IEquatable<AmmoExtraData>  
	{
		public UInt32 ProjectilesPerShot { get; set; }
		public FormID Projectile { get; set; }
		public Single Weight { get; set; }
		public FormID ConsumedAmmo { get; set; }
		public Single ConsumedPercentage { get; set; }


		public AmmoExtraData(string Tag = null)
			:base(Tag)
		{
			ProjectilesPerShot = new UInt32();
			Projectile = new FormID();
			Weight = new Single();
			ConsumedAmmo = new FormID();
			ConsumedPercentage = new Single();

		}

		public AmmoExtraData(UInt32 ProjectilesPerShot, FormID Projectile, Single Weight, FormID ConsumedAmmo, Single ConsumedPercentage)
		{
			this.ProjectilesPerShot = ProjectilesPerShot;
			this.Projectile = Projectile;
			this.Weight = Weight;
			this.ConsumedAmmo = ConsumedAmmo;
			this.ConsumedPercentage = ConsumedPercentage;

		}

		public AmmoExtraData(AmmoExtraData copyObject)
		{
			ProjectilesPerShot = copyObject.ProjectilesPerShot;
			if (copyObject.Projectile != null)
				Projectile = (FormID)copyObject.Projectile.Clone();
			Weight = copyObject.Weight;
			if (copyObject.ConsumedAmmo != null)
				ConsumedAmmo = (FormID)copyObject.ConsumedAmmo.Clone();
			ConsumedPercentage = copyObject.ConsumedPercentage;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					ProjectilesPerShot = subReader.ReadUInt32();
					Projectile.ReadBinary(subReader);
					Weight = subReader.ReadSingle();
					ConsumedAmmo.ReadBinary(subReader);
					ConsumedPercentage = subReader.ReadSingle();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(ProjectilesPerShot);
			Projectile.WriteBinary(writer);
			writer.Write(Weight);
			ConsumedAmmo.WriteBinary(writer);
			writer.Write(ConsumedPercentage);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("ProjectilesPerShot", true, out subEle);
			subEle.Value = ProjectilesPerShot.ToString();

			ele.TryPathTo("Projectile", true, out subEle);
			Projectile.WriteXML(subEle, master);

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");

			ele.TryPathTo("ConsumedAmmo", true, out subEle);
			ConsumedAmmo.WriteXML(subEle, master);

			ele.TryPathTo("ConsumedPercentage", true, out subEle);
			subEle.Value = ConsumedPercentage.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ProjectilesPerShot", false, out subEle))
				ProjectilesPerShot = subEle.ToUInt32();

			if (ele.TryPathTo("Projectile", false, out subEle))
				Projectile.ReadXML(subEle, master);

			if (ele.TryPathTo("Weight", false, out subEle))
				Weight = subEle.ToSingle();

			if (ele.TryPathTo("ConsumedAmmo", false, out subEle))
				ConsumedAmmo.ReadXML(subEle, master);

			if (ele.TryPathTo("ConsumedPercentage", false, out subEle))
				ConsumedPercentage = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new AmmoExtraData(this);
		}


        public int CompareTo(AmmoExtraData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(AmmoExtraData objA, AmmoExtraData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AmmoExtraData objA, AmmoExtraData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AmmoExtraData objA, AmmoExtraData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AmmoExtraData objA, AmmoExtraData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(AmmoExtraData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ProjectilesPerShot == other.ProjectilesPerShot &&
				Projectile == other.Projectile &&
				Weight == other.Weight &&
				ConsumedAmmo == other.ConsumedAmmo &&
				ConsumedPercentage == other.ConsumedPercentage;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AmmoExtraData other = obj as AmmoExtraData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Projectile.GetHashCode();
        }

        public static bool operator ==(AmmoExtraData objA, AmmoExtraData objB)
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

        public static bool operator !=(AmmoExtraData objA, AmmoExtraData objB)
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