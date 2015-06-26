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
	public partial class Container : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public RecordReference Script { get; set; }
		public List<InventoryItem> Contents { get; set; }
		public Destructable Destructable { get; set; }
		public ContainerData Data { get; set; }
		public RecordReference OpenSound { get; set; }
		public RecordReference CloseSound { get; set; }
		public RecordReference Random_LoopingSound { get; set; }
	
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
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "CNTO":
						if (Contents == null)
							Contents = new List<InventoryItem>();

						InventoryItem tempCNTO = new InventoryItem();
						tempCNTO.ReadBinary(reader);
						Contents.Add(tempCNTO);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new ContainerData();

						Data.ReadBinary(reader);
						break;
					case "SNAM":
						if (OpenSound == null)
							OpenSound = new RecordReference();

						OpenSound.ReadBinary(reader);
						break;
					case "QNAM":
						if (CloseSound == null)
							CloseSound = new RecordReference();

						CloseSound.ReadBinary(reader);
						break;
					case "RNAM":
						if (Random_LoopingSound == null)
							Random_LoopingSound = new RecordReference();

						Random_LoopingSound.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Contents != null)
				foreach (var item in Contents)
					item.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (OpenSound != null)
				OpenSound.WriteBinary(writer);
			if (CloseSound != null)
				CloseSound.WriteBinary(writer);
			if (Random_LoopingSound != null)
				Random_LoopingSound.WriteBinary(writer);
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
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Contents != null)		
			{		
				ele.TryPathTo("Contents", true, out subEle);
				List<string> xmlNames = new List<string>{"Item"};
				int i = 0;
				foreach (var entry in Contents)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (OpenSound != null)		
			{		
				ele.TryPathTo("OpenSound", true, out subEle);
				OpenSound.WriteXML(subEle, master);
			}
			if (CloseSound != null)		
			{		
				ele.TryPathTo("CloseSound", true, out subEle);
				CloseSound.WriteXML(subEle, master);
			}
			if (Random_LoopingSound != null)		
			{		
				ele.TryPathTo("Random_LoopingSound", true, out subEle);
				Random_LoopingSound.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Contents", false, out subEle))
			{
				if (Contents == null)
					Contents = new List<InventoryItem>();
					
				foreach (XElement e in subEle.Elements())
				{
					InventoryItem tempCNTO = new InventoryItem();
					tempCNTO.ReadXML(e, master);
					Contents.Add(tempCNTO);
				}
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ContainerData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OpenSound", false, out subEle))
			{
				if (OpenSound == null)
					OpenSound = new RecordReference();
					
				OpenSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloseSound", false, out subEle))
			{
				if (CloseSound == null)
					CloseSound = new RecordReference();
					
				CloseSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Random_LoopingSound", false, out subEle))
			{
				if (Random_LoopingSound == null)
					Random_LoopingSound = new RecordReference();
					
				Random_LoopingSound.ReadXML(subEle, master);
			}
		}

	}
}
