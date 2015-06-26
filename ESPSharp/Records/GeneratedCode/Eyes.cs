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
	public partial class Eyes : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> Texture { get; set; }
		public SimpleSubrecord<EyesFlags> EyesFlags { get; set; }
	
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
					case "ICON":
						if (Texture == null)
							Texture = new SimpleSubrecord<String>();

						Texture.ReadBinary(reader);
						break;
					case "DATA":
						if (EyesFlags == null)
							EyesFlags = new SimpleSubrecord<EyesFlags>();

						EyesFlags.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (Texture != null)
				Texture.WriteBinary(writer);
			if (EyesFlags != null)
				EyesFlags.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Texture != null)		
			{		
				ele.TryPathTo("Texture", true, out subEle);
				Texture.WriteXML(subEle, master);
			}
			if (EyesFlags != null)		
			{		
				ele.TryPathTo("Flags", true, out subEle);
				EyesFlags.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Texture", false, out subEle))
			{
				if (Texture == null)
					Texture = new SimpleSubrecord<String>();
					
				Texture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Flags", false, out subEle))
			{
				if (EyesFlags == null)
					EyesFlags = new SimpleSubrecord<EyesFlags>();
					
				EyesFlags.ReadXML(subEle, master);
			}
		}

	}
}
