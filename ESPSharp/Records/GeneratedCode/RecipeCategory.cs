
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

namespace ESPSharp.Records
{
	public partial class RecipeCategory : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<NoYesByte> IsSubcategory { get; set; }

		public RecipeCategory()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public RecipeCategory(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, SimpleSubrecord<NoYesByte> IsSubcategory)
		{
			this.EditorID = EditorID;
		}

		public RecipeCategory(RecipeCategory copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "DATA":
						if (IsSubcategory == null)
							IsSubcategory = new SimpleSubrecord<NoYesByte>();

						IsSubcategory.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (IsSubcategory != null)
				IsSubcategory.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (IsSubcategory != null)		
			{		
				ele.TryPathTo("IsSubcategory", true, out subEle);
				IsSubcategory.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IsSubcategory", false, out subEle))
			{
				if (IsSubcategory == null)
					IsSubcategory = new SimpleSubrecord<NoYesByte>();
					
				IsSubcategory.ReadXML(subEle, master);
			}
		}		

		public RecipeCategory Clone()
		{
			return new RecipeCategory(this);
		}

	}
}