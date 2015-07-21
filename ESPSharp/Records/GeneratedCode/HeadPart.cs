
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
	public partial class HeadPart : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<HeadPartFlags> HeadPartFlags { get; set; }
		public List<RecordReference> ExtraParts { get; set; }

		public HeadPart()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Name = new SimpleSubrecord<String>("FULL");
			HeadPartFlags = new SimpleSubrecord<HeadPartFlags>("DATA");
			ExtraParts = new List<RecordReference>();
		}

		public HeadPart(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, Model Model, SimpleSubrecord<HeadPartFlags> HeadPartFlags, List<RecordReference> ExtraParts)
		{
			this.EditorID = EditorID;
			this.Name = Name;
			this.HeadPartFlags = HeadPartFlags;
			this.ExtraParts = ExtraParts;
		}

		public HeadPart(HeadPart copyObject)
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
							ExtraParts = new List<RecordReference>();

						RecordReference tempHNAM = new RecordReference();
						tempHNAM.ReadBinary(reader);
						ExtraParts.Add(tempHNAM);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (HeadPartFlags != null)
				HeadPartFlags.WriteBinary(writer);
			if (ExtraParts != null)
				foreach (var item in ExtraParts)
					item.WriteBinary(writer);
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
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (HeadPartFlags != null)		
			{		
				ele.TryPathTo("Flags", true, out subEle);
				HeadPartFlags.WriteXML(subEle, master);
			}
			if (ExtraParts != null)		
			{		
				ele.TryPathTo("ExtraParts", true, out subEle);
				List<string> xmlNames = new List<string>{"Part"};
				int i = 0;
				foreach (var entry in ExtraParts)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Flags", false, out subEle))
			{
				if (HeadPartFlags == null)
					HeadPartFlags = new SimpleSubrecord<HeadPartFlags>();
					
				HeadPartFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExtraParts", false, out subEle))
			{
				if (ExtraParts == null)
					ExtraParts = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempHNAM = new RecordReference();
					tempHNAM.ReadXML(e, master);
					ExtraParts.Add(tempHNAM);
				}
			}
		}		

		public HeadPart Clone()
		{
			return new HeadPart(this);
		}

	}
}