
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
	public partial class AnimatedObject : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Model Model { get; set; }
		public RecordReference Animation { get; set; }

		public AnimatedObject()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Model = new Model();
			Animation = new RecordReference("DATA");
		}

		public AnimatedObject(SimpleSubrecord<String> EditorID, Model Model, RecordReference Animation)
		{
			this.EditorID = EditorID;
			this.Model = Model;
			this.Animation = Animation;
		}

		public AnimatedObject(AnimatedObject copyObject)
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DATA":
						if (Animation == null)
							Animation = new RecordReference();

						Animation.ReadBinary(reader);
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
			if (Model != null)
				Model.WriteBinary(writer);
			if (Animation != null)
				Animation.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Animation != null)		
			{		
				ele.TryPathTo("Animation", true, out subEle);
				Animation.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Animation", false, out subEle))
			{
				if (Animation == null)
					Animation = new RecordReference();
					
				Animation.ReadXML(subEle, master);
			}
		}		

		public AnimatedObject Clone()
		{
			return new AnimatedObject(this);
		}

	}
}