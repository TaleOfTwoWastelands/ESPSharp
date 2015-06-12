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
	public partial class InventoryItemData : Subrecord, ICloneable<InventoryItemData>, IReferenceContainer
	{
		public FormID Item { get; set; }
		public Int32 Count { get; set; }

		public InventoryItemData()
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
			Item = copyObject.Item.Clone();
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
			{
				Item.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Count", false, out subEle))
			{
				Count = subEle.ToInt32();
			}
		}

		public InventoryItemData Clone()
		{
			return new InventoryItemData(this);
		}

	}
}
