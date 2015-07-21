
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
	public partial class AddonNode : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<Int32> NodeIndex { get; set; }
		public RecordReference Sound { get; set; }
		public AddonNodeData Data { get; set; }

		public AddonNode()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
			NodeIndex = new SimpleSubrecord<Int32>("DATA");
			Data = new AddonNodeData("DNAM");
		}

		public AddonNode(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, Model Model, SimpleSubrecord<Int32> NodeIndex, RecordReference Sound, AddonNodeData Data)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
			this.NodeIndex = NodeIndex;
			this.Data = Data;
		}

		public AddonNode(AddonNode copyObject)
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
					case "DATA":
						if (NodeIndex == null)
							NodeIndex = new SimpleSubrecord<Int32>();

						NodeIndex.ReadBinary(reader);
						break;
					case "SNAM":
						if (Sound == null)
							Sound = new RecordReference();

						Sound.ReadBinary(reader);
						break;
					case "DNAM":
						if (Data == null)
							Data = new AddonNodeData();

						Data.ReadBinary(reader);
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
			if (NodeIndex != null)
				NodeIndex.WriteBinary(writer);
			if (Sound != null)
				Sound.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
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
			if (NodeIndex != null)		
			{		
				ele.TryPathTo("NodeIndex", true, out subEle);
				NodeIndex.WriteXML(subEle, master);
			}
			if (Sound != null)		
			{		
				ele.TryPathTo("Sound", true, out subEle);
				Sound.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
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
			if (ele.TryPathTo("NodeIndex", false, out subEle))
			{
				if (NodeIndex == null)
					NodeIndex = new SimpleSubrecord<Int32>();
					
				NodeIndex.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound", false, out subEle))
			{
				if (Sound == null)
					Sound = new RecordReference();
					
				Sound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new AddonNodeData();
					
				Data.ReadXML(subEle, master);
			}
		}		

		public AddonNode Clone()
		{
			return new AddonNode(this);
		}

	}
}