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
	public partial class Static : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<PassthroughSound> PassthroughSound { get; set; }
		public RecordReference Looping_RandomSound { get; set; }

		public Static()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
		}

		public Static(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, Model Model, SimpleSubrecord<PassthroughSound> PassthroughSound, RecordReference Looping_RandomSound)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
		}

		public Static(Static copyObject)
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "BRUS":
						if (PassthroughSound == null)
							PassthroughSound = new SimpleSubrecord<PassthroughSound>();

						PassthroughSound.ReadBinary(reader);
						break;
					case "RNAM":
						if (Looping_RandomSound == null)
							Looping_RandomSound = new RecordReference();

						Looping_RandomSound.ReadBinary(reader);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (PassthroughSound != null)
				PassthroughSound.WriteBinary(writer);
			if (Looping_RandomSound != null)
				Looping_RandomSound.WriteBinary(writer);
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
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (PassthroughSound != null)		
			{		
				ele.TryPathTo("PassthroughSound", true, out subEle);
				PassthroughSound.WriteXML(subEle, master);
			}
			if (Looping_RandomSound != null)		
			{		
				ele.TryPathTo("Looping_RandomSound", true, out subEle);
				Looping_RandomSound.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PassthroughSound", false, out subEle))
			{
				if (PassthroughSound == null)
					PassthroughSound = new SimpleSubrecord<PassthroughSound>();
					
				PassthroughSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Looping_RandomSound", false, out subEle))
			{
				if (Looping_RandomSound == null)
					Looping_RandomSound = new RecordReference();
					
				Looping_RandomSound.ReadXML(subEle, master);
			}
		}		

		public Static Clone()
		{
			return new Static(this);
		}

	}
}