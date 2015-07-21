
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
	public partial class Explosion : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public RecordReference Effect { get; set; }
		public RecordReference ImageSpaceModifier { get; set; }
		public ExplosionData Data { get; set; }
		public RecordReference ImpactObject { get; set; }

		public Explosion()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Data = new ExplosionData("DATA");
		}

		public Explosion(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, RecordReference Effect, RecordReference ImageSpaceModifier, ExplosionData Data, RecordReference ImpactObject)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Data = Data;
		}

		public Explosion(Explosion copyObject)
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
					case "EITM":
						if (Effect == null)
							Effect = new RecordReference();

						Effect.ReadBinary(reader);
						break;
					case "MNAM":
						if (ImageSpaceModifier == null)
							ImageSpaceModifier = new RecordReference();

						ImageSpaceModifier.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new ExplosionData();

						Data.ReadBinary(reader);
						break;
					case "INAM":
						if (ImpactObject == null)
							ImpactObject = new RecordReference();

						ImpactObject.ReadBinary(reader);
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
			if (Effect != null)
				Effect.WriteBinary(writer);
			if (ImageSpaceModifier != null)
				ImageSpaceModifier.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (ImpactObject != null)
				ImpactObject.WriteBinary(writer);
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
			if (Effect != null)		
			{		
				ele.TryPathTo("Effect", true, out subEle);
				Effect.WriteXML(subEle, master);
			}
			if (ImageSpaceModifier != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier", true, out subEle);
				ImageSpaceModifier.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (ImpactObject != null)		
			{		
				ele.TryPathTo("ImpactObject", true, out subEle);
				ImpactObject.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Effect", false, out subEle))
			{
				if (Effect == null)
					Effect = new RecordReference();
					
				Effect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier", false, out subEle))
			{
				if (ImageSpaceModifier == null)
					ImageSpaceModifier = new RecordReference();
					
				ImageSpaceModifier.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ExplosionData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImpactObject", false, out subEle))
			{
				if (ImpactObject == null)
					ImpactObject = new RecordReference();
					
				ImpactObject.ReadXML(subEle, master);
			}
		}		

		public Explosion Clone()
		{
			return new Explosion(this);
		}

	}
}