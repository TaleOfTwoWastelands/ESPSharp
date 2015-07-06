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
	public partial class FormList : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public List<RecordReference> List { get; set; }
	
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
					case "LNAM":
						if (List == null)
							List = new List<RecordReference>();

						RecordReference tempLNAM = new RecordReference();
						tempLNAM.ReadBinary(reader);
						List.Add(tempLNAM);
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
			if (List != null)
				foreach (var item in List)
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
			if (List != null)		
			{		
				ele.TryPathTo("List", true, out subEle);
				List<string> xmlNames = new List<string>{"Entry"};
				int i = 0;
				foreach (var entry in List)
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
			if (ele.TryPathTo("List", false, out subEle))
			{
				if (List == null)
					List = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempLNAM = new RecordReference();
					tempLNAM.ReadXML(e, master);
					List.Add(tempLNAM);
				}
			}
		}

	}
}
