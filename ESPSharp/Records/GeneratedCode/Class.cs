using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Records
{
	public partial class Class : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public ClassData Data { get; set; }
		public Attributes Attributes { get; set; }
	
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
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "DESC":
						if (Description == null)
							Description = new SimpleSubrecord<String>();

						Description.ReadBinary(reader);
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
					case "DATA":
						if (Data == null)
							Data = new ClassData();

						Data.ReadBinary(reader);
						break;
					case "ATTR":
						if (Attributes == null)
							Attributes = new Attributes();

						Attributes.ReadBinary(reader);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Description != null)
				Description.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Attributes != null)
				Attributes.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle);
			}
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("LargeIcon", true, out subEle);
				LargeIcon.WriteXML(subEle);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("SmallIcon", true, out subEle);
				SmallIcon.WriteXML(subEle);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (Attributes != null)		
			{		
				ele.TryPathTo("Attributes", true, out subEle);
				Attributes.WriteXML(subEle);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle);
			}
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle);
			}
			if (ele.TryPathTo("LargeIcon", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("SmallIcon", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ClassData();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("Attributes", false, out subEle))
			{
				if (Attributes == null)
					Attributes = new Attributes();
					
				Attributes.ReadXML(subEle);
			}
		}

	}
}
