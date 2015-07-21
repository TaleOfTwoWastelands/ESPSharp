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

namespace ESPSharp.SubrecordCollections
{
	public partial class RecipeIngredient : SubrecordCollection	{
		public RecordReference Item { get; set; }
		public SimpleSubrecord<UInt32> Quantity { get; set; }

		public RecipeIngredient()
		{
			Item = new RecordReference();
			Quantity = new SimpleSubrecord<UInt32>();
		}

		public RecipeIngredient(RecordReference Item, SimpleSubrecord<UInt32> Quantity)
		{
			this.Item = Item;
			this.Quantity = Quantity;
		}

		public RecipeIngredient(RecipeIngredient copyObject)
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
					case "RCIL":
						if (readTags.Contains("RCIL"))
							return;
						Item.ReadBinary(reader);
						break;
					case "RCQY":
						if (readTags.Contains("RCQY"))
							return;
						Quantity.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Item != null)
				Item.WriteBinary(writer);
			if (Quantity != null)
				Quantity.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Item != null)		
			{		
				ele.TryPathTo("Item", true, out subEle);
				Item.WriteXML(subEle, master);
			}
			if (Quantity != null)		
			{		
				ele.TryPathTo("Quantity", true, out subEle);
				Quantity.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Item", false, out subEle))
			{
				if (Item == null)
					Item = new RecordReference();
					
				Item.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Quantity", false, out subEle))
			{
				if (Quantity == null)
					Quantity = new SimpleSubrecord<UInt32>();
					
				Quantity.ReadXML(subEle, master);
			}
		}

		public RecipeIngredient Clone()
		{
			return new RecipeIngredient(this);
		}

	}
}
