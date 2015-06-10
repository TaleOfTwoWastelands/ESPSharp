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
	public partial class LandscapeTexture : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Icon Icon { get; set; }
		public RecordReference TextureSet { get; set; }
		public HavokData HavokData { get; set; }
		public SimpleSubrecord<Byte> TextureSpecularExponent { get; set; }
		public List<RecordReference> Grasses { get; set; }
	
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
					case "ICON":
						if (Icon == null)
							Icon = new Icon();

						Icon.ReadBinary(reader);
						break;
					case "TNAM":
						if (TextureSet == null)
							TextureSet = new RecordReference();

						TextureSet.ReadBinary(reader);
						break;
					case "HNAM":
						if (HavokData == null)
							HavokData = new HavokData();

						HavokData.ReadBinary(reader);
						break;
					case "SNAM":
						if (TextureSpecularExponent == null)
							TextureSpecularExponent = new SimpleSubrecord<Byte>();

						TextureSpecularExponent.ReadBinary(reader);
						break;
					case "GNAM":
						if (Grasses == null)
							Grasses = new List<RecordReference>();

						RecordReference tempGNAM = new RecordReference();
						tempGNAM.ReadBinary(reader);
						Grasses.Add(tempGNAM);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Icon != null)
				Icon.WriteBinary(writer);
			if (TextureSet != null)
				TextureSet.WriteBinary(writer);
			if (HavokData != null)
				HavokData.WriteBinary(writer);
			if (TextureSpecularExponent != null)
				TextureSpecularExponent.WriteBinary(writer);
			if (Grasses != null)
				foreach (var item in Grasses)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
				Icon.WriteXML(subEle);
			}
			if (TextureSet != null)		
			{		
				ele.TryPathTo("TextureSet", true, out subEle);
				TextureSet.WriteXML(subEle);
			}
			if (HavokData != null)		
			{		
				ele.TryPathTo("HavokData", true, out subEle);
				HavokData.WriteXML(subEle);
			}
			if (TextureSpecularExponent != null)		
			{		
				ele.TryPathTo("TextureSpecularExponent", true, out subEle);
				TextureSpecularExponent.WriteXML(subEle);
			}
			if (Grasses != null)		
			{		
				ele.TryPathTo("Grasses", true, out subEle);
				List<string> xmlNames = new List<string>{"Grass"};
				int i = 0;
				foreach (var entry in Grasses)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new Icon();
					
				Icon.ReadXML(subEle);
			}
			if (ele.TryPathTo("TextureSet", false, out subEle))
			{
				if (TextureSet == null)
					TextureSet = new RecordReference();
					
				TextureSet.ReadXML(subEle);
			}
			if (ele.TryPathTo("HavokData", false, out subEle))
			{
				if (HavokData == null)
					HavokData = new HavokData();
					
				HavokData.ReadXML(subEle);
			}
			if (ele.TryPathTo("TextureSpecularExponent", false, out subEle))
			{
				if (TextureSpecularExponent == null)
					TextureSpecularExponent = new SimpleSubrecord<Byte>();
					
				TextureSpecularExponent.ReadXML(subEle);
			}
			if (ele.TryPathTo("Grasses", false, out subEle))
			{
				if (Grasses == null)
					Grasses = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempGNAM = new RecordReference();
					tempGNAM.ReadXML(e);
					Grasses.Add(tempGNAM);
				}
			}
		}

	}
}
