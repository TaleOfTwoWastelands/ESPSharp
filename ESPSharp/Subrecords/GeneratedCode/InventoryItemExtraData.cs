
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
	public partial class InventoryItemExtraData : Subrecord, ICloneable<InventoryItemExtraData>, IComparable<InventoryItemExtraData>, IEquatable<InventoryItemExtraData>  
	{
		public FormID Owner { get; set; }
		public UInt32 OwnerData { get; set; }
		public Single Condition { get; set; }

		public InventoryItemExtraData()
		{
			Owner = new FormID();
			OwnerData = new UInt32();
			Condition = new Single();
		}

		public InventoryItemExtraData(FormID Owner, UInt32 OwnerData, Single Condition)
		{
			this.Owner = Owner;
			this.OwnerData = OwnerData;
			this.Condition = Condition;
		}

		public InventoryItemExtraData(InventoryItemExtraData copyObject)
		{
			Owner = copyObject.Owner.Clone();
			OwnerData = copyObject.OwnerData;
			Condition = copyObject.Condition;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Owner.ReadBinary(subReader);
					OwnerData = subReader.ReadUInt32();
					Condition = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Owner.WriteBinary(writer);
			writer.Write(OwnerData);
			writer.Write(Condition);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Owner", true, out subEle);
			Owner.WriteXML(subEle, master);

			WriteOwnerDataXML(ele, master);

			ele.TryPathTo("Condition", true, out subEle);
			subEle.Value = Condition.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Owner", false, out subEle))
				Owner.ReadXML(subEle, master);

			ReadOwnerDataXML(ele, master);

			if (ele.TryPathTo("Condition", false, out subEle))
				Condition = subEle.ToSingle();
		}

		public InventoryItemExtraData Clone()
		{
			return new InventoryItemExtraData(this);
		}

        public int CompareTo(InventoryItemExtraData other)
        {
			return Owner.CompareTo(other.Owner);
        }

        public static bool operator >(InventoryItemExtraData objA, InventoryItemExtraData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(InventoryItemExtraData objA, InventoryItemExtraData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(InventoryItemExtraData objA, InventoryItemExtraData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(InventoryItemExtraData objA, InventoryItemExtraData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(InventoryItemExtraData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Owner == other.Owner &&
				OwnerData == other.OwnerData &&
				Condition == other.Condition;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            InventoryItemExtraData other = obj as InventoryItemExtraData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Owner.GetHashCode();
        }

        public static bool operator ==(InventoryItemExtraData objA, InventoryItemExtraData objB)
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

        public static bool operator !=(InventoryItemExtraData objA, InventoryItemExtraData objB)
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

		partial void ReadOwnerDataXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteOwnerDataXML(XElement ele, ElderScrollsPlugin master);
	}
}