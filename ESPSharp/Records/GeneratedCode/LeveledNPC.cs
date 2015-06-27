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
	public partial class LeveledNPC : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<Byte> ChanceNone { get; set; }
		public SimpleSubrecord<LeveledListFlags> LeveledObjectFlags { get; set; }
		public List<LeveledListEntry> LeveledList { get; set; }
		public Model Model { get; set; }
	
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
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "LVLD":
						if (ChanceNone == null)
							ChanceNone = new SimpleSubrecord<Byte>();

						ChanceNone.ReadBinary(reader);
						break;
					case "LVLF":
						if (LeveledObjectFlags == null)
							LeveledObjectFlags = new SimpleSubrecord<LeveledListFlags>();

						LeveledObjectFlags.ReadBinary(reader);
						break;
					case "LVLO":
						if (LeveledList == null)
							LeveledList = new List<LeveledListEntry>();

						LeveledListEntry tempLVLO = new LeveledListEntry();
						tempLVLO.ReadBinary(reader);
						LeveledList.Add(tempLVLO);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
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
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (ChanceNone != null)
				ChanceNone.WriteBinary(writer);
			if (LeveledObjectFlags != null)
				LeveledObjectFlags.WriteBinary(writer);
			if (LeveledList != null)
				foreach (var item in LeveledList)
					item.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle, master);
			}
			if (ChanceNone != null)		
			{		
				ele.TryPathTo("ChanceNone", true, out subEle);
				ChanceNone.WriteXML(subEle, master);
			}
			if (LeveledObjectFlags != null)		
			{		
				ele.TryPathTo("LeveledObjectFlags", true, out subEle);
				LeveledObjectFlags.WriteXML(subEle, master);
			}
			if (LeveledList != null)		
			{		
				ele.TryPathTo("LeveledList", true, out subEle);
				List<string> xmlNames = new List<string>{"Entry"};
				int i = 0;
				foreach (var entry in LeveledList)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
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
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ChanceNone", false, out subEle))
			{
				if (ChanceNone == null)
					ChanceNone = new SimpleSubrecord<Byte>();
					
				ChanceNone.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LeveledObjectFlags", false, out subEle))
			{
				if (LeveledObjectFlags == null)
					LeveledObjectFlags = new SimpleSubrecord<LeveledListFlags>();
					
				LeveledObjectFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LeveledList", false, out subEle))
			{
				if (LeveledList == null)
					LeveledList = new List<LeveledListEntry>();
					
				foreach (XElement e in subEle.Elements())
				{
					LeveledListEntry tempLVLO = new LeveledListEntry();
					tempLVLO.ReadXML(e, master);
					LeveledList.Add(tempLVLO);
				}
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
		}

	}
}
