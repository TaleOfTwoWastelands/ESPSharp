﻿using System;
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

namespace ESPSharp.SubrecordCollections
{
	public partial class InventoryItem : SubrecordCollection, IComparable<InventoryItem>	{
		public InventoryItemData Data { get; set; }
		public InventoryItemExtraData ExtraData { get; set; }

		public InventoryItem()
		{
			Data = new InventoryItemData();
		}

		public InventoryItem(InventoryItemData Data, InventoryItemExtraData ExtraData)
		{
			this.Data = Data;
			this.ExtraData = ExtraData;
		}

		public InventoryItem(InventoryItem copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "CNTO":
						if (readTags.Contains("CNTO"))
							return;
						Data.ReadBinary(reader);
						break;
					case "COED":
						if (readTags.Contains("COED"))
							return;
						if (ExtraData == null)
							ExtraData = new InventoryItemExtraData();

						ExtraData.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Data != null)
				Data.WriteBinary(writer);
			if (ExtraData != null)
				ExtraData.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (ExtraData != null)		
			{		
				ele.TryPathTo("ExtraData", true, out subEle);
				ExtraData.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new InventoryItemData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExtraData", false, out subEle))
			{
				if (ExtraData == null)
					ExtraData = new InventoryItemExtraData();
					
				ExtraData.ReadXML(subEle, master);
			}
		}

		public InventoryItem Clone()
		{
			return new InventoryItem(this);
		}

		public int CompareTo(InventoryItem other)
        {
			int result = 0;

			if (result == 0 && Data != null && other.Data != null)
				result = Data.CompareTo(other.Data);

			if (result == 0 && ExtraData != null && other.ExtraData != null)
				result = ExtraData.CompareTo(other.ExtraData);

			return result;
        }

        public static bool operator >(InventoryItem objA, InventoryItem objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(InventoryItem objA, InventoryItem objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(InventoryItem objA, InventoryItem objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(InventoryItem objA, InventoryItem objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

	}
}
