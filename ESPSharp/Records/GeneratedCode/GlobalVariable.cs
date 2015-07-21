
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
	public partial class GlobalVariable : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<GlobalVarType> Type { get; set; }
		public SimpleSubrecord<Single> Value { get; set; }

		public GlobalVariable()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Type = new SimpleSubrecord<GlobalVarType>("FNAM");
			Value = new SimpleSubrecord<Single>("FLTV");
		}

		public GlobalVariable(SimpleSubrecord<String> EditorID, SimpleSubrecord<GlobalVarType> Type, SimpleSubrecord<Single> Value)
		{
			this.EditorID = EditorID;
			this.Type = Type;
			this.Value = Value;
		}

		public GlobalVariable(GlobalVariable copyObject)
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
					default:
						throw new Exception();
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

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Type != null)		
			{		
				ele.TryPathTo("Type", true, out subEle);
				Type.WriteXML(subEle, master);
			}
			if (Value != null)		
			{		
				ele.TryPathTo("Value", true, out subEle);
				Value.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Type", false, out subEle))
			{
				if (Type == null)
					Type = new SimpleSubrecord<GlobalVarType>();
					
				Type.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Value", false, out subEle))
			{
				if (Value == null)
					Value = new SimpleSubrecord<Single>();
					
				Value.ReadXML(subEle, master);
			}
		}		

		public GlobalVariable Clone()
		{
			return new GlobalVariable(this);
		}

	}
}