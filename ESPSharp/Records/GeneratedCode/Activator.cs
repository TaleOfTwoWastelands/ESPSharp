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
	public partial class Activator : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public RecordReference Script { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference LoopingSound { get; set; }
		public RecordReference ActivationSound { get; set; }
		public RecordReference RadioTemplate { get; set; }
		public RecordReference RadioStation { get; set; }
		public RecordReference WaterType { get; set; }
		public SimpleSubrecord<String> ActivationPrompt { get; set; }
	
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
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "SNAM":
						if (LoopingSound == null)
							LoopingSound = new RecordReference();

						LoopingSound.ReadBinary(reader);
						break;
					case "VNAM":
						if (ActivationSound == null)
							ActivationSound = new RecordReference();

						ActivationSound.ReadBinary(reader);
						break;
					case "INAM":
						if (RadioTemplate == null)
							RadioTemplate = new RecordReference();

						RadioTemplate.ReadBinary(reader);
						break;
					case "RNAM":
						if (RadioStation == null)
							RadioStation = new RecordReference();

						RadioStation.ReadBinary(reader);
						break;
					case "WNAM":
						if (WaterType == null)
							WaterType = new RecordReference();

						WaterType.ReadBinary(reader);
						break;
					case "XATO":
						if (ActivationPrompt == null)
							ActivationPrompt = new SimpleSubrecord<String>();

						ActivationPrompt.ReadBinary(reader);
						break;
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
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (LoopingSound != null)
				LoopingSound.WriteBinary(writer);
			if (ActivationSound != null)
				ActivationSound.WriteBinary(writer);
			if (RadioTemplate != null)
				RadioTemplate.WriteBinary(writer);
			if (RadioStation != null)
				RadioStation.WriteBinary(writer);
			if (WaterType != null)
				WaterType.WriteBinary(writer);
			if (ActivationPrompt != null)
				ActivationPrompt.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle);
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
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle);
			}
			if (LoopingSound != null)		
			{		
				ele.TryPathTo("Sound/Looping", true, out subEle);
				LoopingSound.WriteXML(subEle);
			}
			if (ActivationSound != null)		
			{		
				ele.TryPathTo("Sound/Activation", true, out subEle);
				ActivationSound.WriteXML(subEle);
			}
			if (RadioTemplate != null)		
			{		
				ele.TryPathTo("RadioTemplate", true, out subEle);
				RadioTemplate.WriteXML(subEle);
			}
			if (RadioStation != null)		
			{		
				ele.TryPathTo("RadioStation", true, out subEle);
				RadioStation.WriteXML(subEle);
			}
			if (WaterType != null)		
			{		
				ele.TryPathTo("WaterType", true, out subEle);
				WaterType.WriteXML(subEle);
			}
			if (ActivationPrompt != null)		
			{		
				ele.TryPathTo("ActivationPrompt", true, out subEle);
				ActivationPrompt.WriteXML(subEle);
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
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle);
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
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle);
			}
			if (ele.TryPathTo("Sound/Looping", false, out subEle))
			{
				if (LoopingSound == null)
					LoopingSound = new RecordReference();
					
				LoopingSound.ReadXML(subEle);
			}
			if (ele.TryPathTo("Sound/Activation", false, out subEle))
			{
				if (ActivationSound == null)
					ActivationSound = new RecordReference();
					
				ActivationSound.ReadXML(subEle);
			}
			if (ele.TryPathTo("RadioTemplate", false, out subEle))
			{
				if (RadioTemplate == null)
					RadioTemplate = new RecordReference();
					
				RadioTemplate.ReadXML(subEle);
			}
			if (ele.TryPathTo("RadioStation", false, out subEle))
			{
				if (RadioStation == null)
					RadioStation = new RecordReference();
					
				RadioStation.ReadXML(subEle);
			}
			if (ele.TryPathTo("WaterType", false, out subEle))
			{
				if (WaterType == null)
					WaterType = new RecordReference();
					
				WaterType.ReadXML(subEle);
			}
			if (ele.TryPathTo("ActivationPrompt", false, out subEle))
			{
				if (ActivationPrompt == null)
					ActivationPrompt = new SimpleSubrecord<String>();
					
				ActivationPrompt.ReadXML(subEle);
			}
		}

	}
}
