using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Records
{
	public partial class GlobalVariable : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<GlobalVarType> Type { get; set; }
		public SimpleSubrecord<Single> Value { get; set; }
	
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
					case "FNAM":
						if (Type == null)
							Type = new SimpleSubrecord<GlobalVarType>();

						Type.ReadBinary(reader);
						break;
					case "FLTV":
						if (Value == null)
							Value = new SimpleSubrecord<Single>();

						Value.ReadBinary(reader);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Type != null)
				Type.WriteBinary(writer);
			if (Value != null)
				Value.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (Type != null)		
			{		
				ele.TryPathTo("Type", true, out subEle);
				Type.WriteXML(subEle);
			}
			if (Value != null)		
			{		
				ele.TryPathTo("Value", true, out subEle);
				Value.WriteXML(subEle);
			}
		}

		public override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle);
			}
			if (ele.TryPathTo("Type", false, out subEle))
			{
				if (Type == null)
					Type = new SimpleSubrecord<GlobalVarType>();
					
				Type.ReadXML(subEle);
			}
			if (ele.TryPathTo("Value", false, out subEle))
			{
				if (Value == null)
					Value = new SimpleSubrecord<Single>();
					
				Value.ReadXML(subEle);
			}
		}

	}
}
