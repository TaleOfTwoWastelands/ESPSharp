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
	public partial class HeadPart : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<HeadPartFlags> HeadPartFlags { get; set; }
		public List<SimpleSubrecord<FormID>> ExtraParts { get; set; }
	
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DATA":
						if (HeadPartFlags == null)
							HeadPartFlags = new SimpleSubrecord<HeadPartFlags>();

						HeadPartFlags.ReadBinary(reader);
						break;
					case "HNAM":
						if (ExtraParts == null)
							ExtraParts = new List<SimpleSubrecord<FormID>>();

						SimpleSubrecord<FormID> tempPart = new SimpleSubrecord<FormID>();
						tempPart.ReadBinary(reader);
						ExtraParts.Add(tempPart);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (HeadPartFlags != null)
				HeadPartFlags.WriteBinary(writer);
			if (ExtraParts != null)
				foreach (var item in ExtraParts)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle);
			}
			if (HeadPartFlags != null)		
			{		
				ele.TryPathTo("Flags", true, out subEle);
				HeadPartFlags.WriteXML(subEle);
			}
			if (ExtraParts != null)		
			{		
				ele.TryPathTo("ExtraParts", true, out subEle);
				foreach (var entry in ExtraParts)
				{
					XElement newEle = new XElement("Part");
					entry.WriteXML(newEle);
					subEle.Add(newEle);
				}
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle);
			}
			if (ele.TryPathTo("Flags", false, out subEle))
			{
				if (HeadPartFlags == null)
					HeadPartFlags = new SimpleSubrecord<HeadPartFlags>();
					
				HeadPartFlags.ReadXML(subEle);
			}
			if (ele.TryPathTo("ExtraParts", false, out subEle))
			{
				if (ExtraParts == null)
					ExtraParts = new List<SimpleSubrecord<FormID>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<FormID> temp = new SimpleSubrecord<FormID>();
					temp.ReadXML(e);
					ExtraParts.Add(temp);
				}
			}
		}

	}
}
