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
	public partial class CameraShot : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Model Model { get; set; }
		public CameraShotData Data { get; set; }
		public RecordReference ImageSpaceModifier { get; set; }
	
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new CameraShotData();

						Data.ReadBinary(reader);
						break;
					case "MNAM":
						if (ImageSpaceModifier == null)
							ImageSpaceModifier = new RecordReference();

						ImageSpaceModifier.ReadBinary(reader);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ImageSpaceModifier != null)
				ImageSpaceModifier.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (ImageSpaceModifier != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier", true, out subEle);
				ImageSpaceModifier.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new CameraShotData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier", false, out subEle))
			{
				if (ImageSpaceModifier == null)
					ImageSpaceModifier = new RecordReference();
					
				ImageSpaceModifier.ReadXML(subEle, master);
			}
		}

	}
}
