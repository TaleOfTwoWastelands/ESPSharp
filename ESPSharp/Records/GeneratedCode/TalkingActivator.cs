﻿
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
	public partial class TalkingActivator : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public RecordReference Script { get; set; }
		public Destructable Destructable { get; set; }
		public RecordReference LoopingSound { get; set; }
		public RecordReference VoiceType { get; set; }
		public RecordReference RadioTemplate { get; set; }

		public TalkingActivator()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
		}

		public TalkingActivator(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, RecordReference Script, Destructable Destructable, RecordReference LoopingSound, RecordReference VoiceType, RecordReference RadioTemplate)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
		}

		public TalkingActivator(TalkingActivator copyObject)
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
						if (VoiceType == null)
							VoiceType = new RecordReference();

						VoiceType.ReadBinary(reader);
						break;
					case "INAM":
						if (RadioTemplate == null)
							RadioTemplate = new RecordReference();

						RadioTemplate.ReadBinary(reader);
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
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (LoopingSound != null)
				LoopingSound.WriteBinary(writer);
			if (VoiceType != null)
				VoiceType.WriteBinary(writer);
			if (RadioTemplate != null)
				RadioTemplate.WriteBinary(writer);
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
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (LoopingSound != null)		
			{		
				ele.TryPathTo("LoopingSound", true, out subEle);
				LoopingSound.WriteXML(subEle, master);
			}
			if (VoiceType != null)		
			{		
				ele.TryPathTo("VoiceType", true, out subEle);
				VoiceType.WriteXML(subEle, master);
			}
			if (RadioTemplate != null)		
			{		
				ele.TryPathTo("RadioTemplate", true, out subEle);
				RadioTemplate.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LoopingSound", false, out subEle))
			{
				if (LoopingSound == null)
					LoopingSound = new RecordReference();
					
				LoopingSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("VoiceType", false, out subEle))
			{
				if (VoiceType == null)
					VoiceType = new RecordReference();
					
				VoiceType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RadioTemplate", false, out subEle))
			{
				if (RadioTemplate == null)
					RadioTemplate = new RecordReference();
					
				RadioTemplate.ReadXML(subEle, master);
			}
		}		

		public TalkingActivator Clone()
		{
			return new TalkingActivator(this);
		}

	}
}