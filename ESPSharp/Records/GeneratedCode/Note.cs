
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
	public partial class Note : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public RecordReference PickUpSound { get; set; }
		public RecordReference DropSound { get; set; }
		public SimpleSubrecord<NoteType> Type { get; set; }
		public List<RecordReference> Quests { get; set; }
		public SimpleSubrecord<String> Image { get; set; }
		public Subrecord EntryData { get; set; }
		public RecordReference Audio { get; set; }

		public Note()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Name = new SimpleSubrecord<String>("FULL");
		}

		public Note(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, RecordReference PickUpSound, RecordReference DropSound, SimpleSubrecord<NoteType> Type, List<RecordReference> Quests, SimpleSubrecord<String> Image, Subrecord EntryData, RecordReference Audio)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Name = Name;
		}

		public Note(Note copyObject)
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
					case "ICON":
						if (LargeIcon == null)
							LargeIcon = new SimpleSubrecord<String>();

						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();

						SmallIcon.ReadBinary(reader);
						break;
					case "YNAM":
						if (PickUpSound == null)
							PickUpSound = new RecordReference();

						PickUpSound.ReadBinary(reader);
						break;
					case "ZNAM":
						if (DropSound == null)
							DropSound = new RecordReference();

						DropSound.ReadBinary(reader);
						break;
					case "DATA":
						if (Type == null)
							Type = new SimpleSubrecord<NoteType>();

						Type.ReadBinary(reader);
						break;
					case "ONAM":
						if (Quests == null)
							Quests = new List<RecordReference>();

						RecordReference tempONAM = new RecordReference();
						tempONAM.ReadBinary(reader);
						Quests.Add(tempONAM);
						break;
					case "XNAM":
						if (Image == null)
							Image = new SimpleSubrecord<String>();

						Image.ReadBinary(reader);
						break;
					case "TNAM":
						ReadEntryData(reader);
						break;
					case "SNAM":
						if (Audio == null)
							Audio = new RecordReference();

						Audio.ReadBinary(reader);
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
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (PickUpSound != null)
				PickUpSound.WriteBinary(writer);
			if (DropSound != null)
				DropSound.WriteBinary(writer);
			if (Type != null)
				Type.WriteBinary(writer);
			if (Quests != null)
				foreach (var item in Quests)
					item.WriteBinary(writer);
			if (Image != null)
				Image.WriteBinary(writer);

			WriteEntryData(writer);
			if (Audio != null)
				Audio.WriteBinary(writer);
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
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon/Large", true, out subEle);
				LargeIcon.WriteXML(subEle, master);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon/Small", true, out subEle);
				SmallIcon.WriteXML(subEle, master);
			}
			if (PickUpSound != null)		
			{		
				ele.TryPathTo("PickUpSound", true, out subEle);
				PickUpSound.WriteXML(subEle, master);
			}
			if (DropSound != null)		
			{		
				ele.TryPathTo("DropSound", true, out subEle);
				DropSound.WriteXML(subEle, master);
			}
			if (Type != null)		
			{		
				ele.TryPathTo("Type", true, out subEle);
				Type.WriteXML(subEle, master);
			}
			if (Quests != null)		
			{		
				ele.TryPathTo("Quests", true, out subEle);
				List<string> xmlNames = new List<string>{"Quest"};
				int i = 0;
				foreach (var entry in Quests)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Image != null)		
			{		
				ele.TryPathTo("Image", true, out subEle);
				Image.WriteXML(subEle, master);
			}

			WriteEntryDataXML(ele, master);
			if (Audio != null)		
			{		
				ele.TryPathTo("Audio", true, out subEle);
				Audio.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Icon/Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PickUpSound", false, out subEle))
			{
				if (PickUpSound == null)
					PickUpSound = new RecordReference();
					
				PickUpSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DropSound", false, out subEle))
			{
				if (DropSound == null)
					DropSound = new RecordReference();
					
				DropSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Type", false, out subEle))
			{
				if (Type == null)
					Type = new SimpleSubrecord<NoteType>();
					
				Type.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Quests", false, out subEle))
			{
				if (Quests == null)
					Quests = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempONAM = new RecordReference();
					tempONAM.ReadXML(e, master);
					Quests.Add(tempONAM);
				}
			}
			if (ele.TryPathTo("Image", false, out subEle))
			{
				if (Image == null)
					Image = new SimpleSubrecord<String>();
					
				Image.ReadXML(subEle, master);
			}

			ReadEntryDataXML(ele, master);
			if (ele.TryPathTo("Audio", false, out subEle))
			{
				if (Audio == null)
					Audio = new RecordReference();
					
				Audio.ReadXML(subEle, master);
			}
		}		

		public Note Clone()
		{
			return new Note(this);
		}


		partial void ReadEntryData(ESPReader reader);

		partial void WriteEntryData(ESPWriter writer);

		partial void WriteEntryDataXML(XElement ele, ElderScrollsPlugin master);

		partial void ReadEntryDataXML(XElement ele, ElderScrollsPlugin master);
	}
}