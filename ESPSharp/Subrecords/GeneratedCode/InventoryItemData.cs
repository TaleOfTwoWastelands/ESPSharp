
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
	public partial class InventoryItemData : Subrecord, ICloneable, IComparable<InventoryItemData>, IEquatable<InventoryItemData>  
	{
		public FormID Item { get; set; }
		public Int32 Count { get; set; }

		public InventoryItemData(string Tag = null)
			:base(Tag)
		{
			Item = new FormID();
			Count = new Int32();
		}

		public InventoryItemData(FormID Item, Int32 Count)
		{
			this.Item = Item;
			this.Count = Count;
		}

		public InventoryItemData(InventoryItemData copyObject)
		{
			if (copyObject.Item != null)
				Item = (FormID)copyObject.Item.Clone();
			Count = copyObject.Count;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Item.ReadBinary(subReader);
					Count = subReader.ReadInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Item.WriteBinary(writer);
			writer.Write(Count);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Item", true, out subEle);
			Item.WriteXML(subEle, master);

			ele.TryPathTo("Count", true, out subEle);
			subEle.Value = Count.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Item", false, out subEle))
				Item.ReadXML(subEle, master);

			if (ele.TryPathTo("Count", false, out subEle))
				Count = subEle.ToInt32();
		}

		public override object Clone()
		{
			return new InventoryItemData(this);
		}

        public int CompareTo(InventoryItemData other)
        {
			int result = 0;

			if (result == 0 && Item != null && other.Item != null)	
				result = Item.CompareTo(other.Item);

			if (result == 0 && Count != null && other.Count != null)	
				result = Count.CompareTo(other.Count);

			return result;
		}

        public static bool operator >(InventoryItemData objA, InventoryItemData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(InventoryItemData objA, InventoryItemData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(InventoryItemData objA, InventoryItemData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(InventoryItemData objA, InventoryItemData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(InventoryItemData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Item == other.Item &&
				Count == other.Count;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            InventoryItemData other = obj as InventoryItemData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }

        public static bool operator ==(InventoryItemData objA, InventoryItemData objB)
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

        public static bool operator !=(InventoryItemData objA, InventoryItemData objB)
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