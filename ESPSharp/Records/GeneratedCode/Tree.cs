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
	public partial class Tree : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public Model Model { get; set; }
		public Icon Icon { get; set; }
		public SpeedtreeSeeds SpeedtreeSeeds { get; set; }
		public TreeData Data { get; set; }
		public BillboardDimensions BillboardDimensions { get; set; }
	
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
					case "ICON":
						if (Icon == null)
							Icon = new Icon();

						Icon.ReadBinary(reader);
						break;
					case "SNAM":
						if (SpeedtreeSeeds == null)
							SpeedtreeSeeds = new SpeedtreeSeeds();

						SpeedtreeSeeds.ReadBinary(reader);
						break;
					case "CNAM":
						if (Data == null)
							Data = new TreeData();

						Data.ReadBinary(reader);
						break;
					case "BNAM":
						if (BillboardDimensions == null)
							BillboardDimensions = new BillboardDimensions();

						BillboardDimensions.ReadBinary(reader);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (Icon != null)
				Icon.WriteBinary(writer);
			if (SpeedtreeSeeds != null)
				SpeedtreeSeeds.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (BillboardDimensions != null)
				BillboardDimensions.WriteBinary(writer);
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
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
				Icon.WriteXML(subEle, master);
			}
			if (SpeedtreeSeeds != null)		
			{		
				ele.TryPathTo("SpeedtreeSeeds", true, out subEle);
				SpeedtreeSeeds.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (BillboardDimensions != null)		
			{		
				ele.TryPathTo("BillboardDimensions", true, out subEle);
				BillboardDimensions.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new Icon();
					
				Icon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SpeedtreeSeeds", false, out subEle))
			{
				if (SpeedtreeSeeds == null)
					SpeedtreeSeeds = new SpeedtreeSeeds();
					
				SpeedtreeSeeds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new TreeData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BillboardDimensions", false, out subEle))
			{
				if (BillboardDimensions == null)
					BillboardDimensions = new BillboardDimensions();
					
				BillboardDimensions.ReadXML(subEle, master);
			}
		}

	}
}
