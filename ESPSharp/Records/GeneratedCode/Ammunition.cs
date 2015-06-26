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
	public partial class Ammunition : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public Icon Icon { get; set; }
		public RecordReference Script { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference PickUpSound { get; set; }
		public RecordReference DropSound { get; set; }
		public AmmoData Data { get; set; }
		public AmmoExtraData ExtraData { get; set; }
		public SimpleSubrecord<String> ShortName { get; set; }
		public SimpleSubrecord<String> Abbreviation { get; set; }
		public List<RecordReference> AmmoEffects { get; set; }
	
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
						if (Icon == null)
							Icon = new Icon();

						Icon.ReadBinary(reader);
						break;
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
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
						if (Data == null)
							Data = new AmmoData();

						Data.ReadBinary(reader);
						break;
					case "DAT2":
						if (ExtraData == null)
							ExtraData = new AmmoExtraData();

						ExtraData.ReadBinary(reader);
						break;
					case "ONAM":
						if (ShortName == null)
							ShortName = new SimpleSubrecord<String>();

						ShortName.ReadBinary(reader);
						break;
					case "QNAM":
						if (Abbreviation == null)
							Abbreviation = new SimpleSubrecord<String>();

						Abbreviation.ReadBinary(reader);
						break;
					case "RCIL":
						if (AmmoEffects == null)
							AmmoEffects = new List<RecordReference>();

						RecordReference tempRCIL = new RecordReference();
						tempRCIL.ReadBinary(reader);
						AmmoEffects.Add(tempRCIL);
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
			if (Icon != null)
				Icon.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (PickUpSound != null)
				PickUpSound.WriteBinary(writer);
			if (DropSound != null)
				DropSound.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ExtraData != null)
				ExtraData.WriteBinary(writer);
			if (ShortName != null)
				ShortName.WriteBinary(writer);
			if (Abbreviation != null)
				Abbreviation.WriteBinary(writer);
			if (AmmoEffects != null)
				foreach (var item in AmmoEffects)
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
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
				Icon.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
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
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (ExtraData != null)		
			{		
				ele.TryPathTo("ExtraData", true, out subEle);
				ExtraData.WriteXML(subEle, master);
			}
			if (ShortName != null)		
			{		
				ele.TryPathTo("ShortName", true, out subEle);
				ShortName.WriteXML(subEle, master);
			}
			if (Abbreviation != null)		
			{		
				ele.TryPathTo("Abbreviation", true, out subEle);
				Abbreviation.WriteXML(subEle, master);
			}
			if (AmmoEffects != null)		
			{		
				ele.TryPathTo("AmmoEffects", true, out subEle);
				List<string> xmlNames = new List<string>{"Effect"};
				int i = 0;
				foreach (var entry in AmmoEffects)
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
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new Icon();
					
				Icon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new AmmoData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExtraData", false, out subEle))
			{
				if (ExtraData == null)
					ExtraData = new AmmoExtraData();
					
				ExtraData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ShortName", false, out subEle))
			{
				if (ShortName == null)
					ShortName = new SimpleSubrecord<String>();
					
				ShortName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Abbreviation", false, out subEle))
			{
				if (Abbreviation == null)
					Abbreviation = new SimpleSubrecord<String>();
					
				Abbreviation.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AmmoEffects", false, out subEle))
			{
				if (AmmoEffects == null)
					AmmoEffects = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempRCIL = new RecordReference();
					tempRCIL.ReadXML(e, master);
					AmmoEffects.Add(tempRCIL);
				}
			}
		}

	}
}
