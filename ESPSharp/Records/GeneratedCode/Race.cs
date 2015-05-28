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
	public partial class Race : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public List<Relationship> Relationships { get; set; }
		public SimpleSubrecord<Byte[]> Data { get; set; }
		public SimpleSubrecord<FormID> OlderRace { get; set; }
		public SimpleSubrecord<FormID> YoungerRace { get; set; }
		public SimpleSubrecord<Byte[]> MarkerUnknown { get; set; }
		public SimpleSubrecord<Byte[]> Voice { get; set; }
		public SimpleSubrecord<Byte[]> DefaultHairStyle { get; set; }
		public SimpleSubrecord<Byte[]> DefaultHairColor { get; set; }
		public SimpleSubrecord<Single> FaceGenMainClamp { get; set; }
		public SimpleSubrecord<Single> FaceGenFaceClamp { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }
	
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
					case "XNAM":
						if (Relationships == null)
							Relationships = new List<Relationship>();

						Relationship tempXNAM = new Relationship();
						tempXNAM.ReadBinary(reader);
						Relationships.Add(tempXNAM);
						break;
					case "DATA":
						if (Data == null)
							Data = new SimpleSubrecord<Byte[]>();

						Data.ReadBinary(reader);
						break;
					case "ONAM":
						if (OlderRace == null)
							OlderRace = new SimpleSubrecord<FormID>();

						OlderRace.ReadBinary(reader);
						break;
					case "YNAM":
						if (YoungerRace == null)
							YoungerRace = new SimpleSubrecord<FormID>();

						YoungerRace.ReadBinary(reader);
						break;
					case "NAM2":
						if (MarkerUnknown == null)
							MarkerUnknown = new SimpleSubrecord<Byte[]>();

						MarkerUnknown.ReadBinary(reader);
						break;
					case "VTCK":
						if (Voice == null)
							Voice = new SimpleSubrecord<Byte[]>();

						Voice.ReadBinary(reader);
						break;
					case "DNAM":
						if (DefaultHairStyle == null)
							DefaultHairStyle = new SimpleSubrecord<Byte[]>();

						DefaultHairStyle.ReadBinary(reader);
						break;
					case "CNAM":
						if (DefaultHairColor == null)
							DefaultHairColor = new SimpleSubrecord<Byte[]>();

						DefaultHairColor.ReadBinary(reader);
						break;
					case "PNAM":
						if (FaceGenMainClamp == null)
							FaceGenMainClamp = new SimpleSubrecord<Single>();

						FaceGenMainClamp.ReadBinary(reader);
						break;
					case "UNAM":
						if (FaceGenFaceClamp == null)
							FaceGenFaceClamp = new SimpleSubrecord<Single>();

						FaceGenFaceClamp.ReadBinary(reader);
						break;
					case "ATTR":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte[]>();

						Unknown.ReadBinary(reader);
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
			if (Relationships != null)
				foreach (var item in Relationships)
					item.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (OlderRace != null)
				OlderRace.WriteBinary(writer);
			if (YoungerRace != null)
				YoungerRace.WriteBinary(writer);
			if (MarkerUnknown != null)
				MarkerUnknown.WriteBinary(writer);
			if (Voice != null)
				Voice.WriteBinary(writer);
			if (DefaultHairStyle != null)
				DefaultHairStyle.WriteBinary(writer);
			if (DefaultHairColor != null)
				DefaultHairColor.WriteBinary(writer);
			if (FaceGenMainClamp != null)
				FaceGenMainClamp.WriteBinary(writer);
			if (FaceGenFaceClamp != null)
				FaceGenFaceClamp.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
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
			if (Relationships != null)		
			{		
				ele.TryPathTo("Relationships", true, out subEle);
				foreach (var entry in Relationships)
				{
					XElement newEle = new XElement("Relationship");
					entry.WriteXML(newEle);
					subEle.Add(newEle);
				}
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (OlderRace != null)		
			{		
				ele.TryPathTo("Race\\Older", true, out subEle);
				OlderRace.WriteXML(subEle);
			}
			if (YoungerRace != null)		
			{		
				ele.TryPathTo("Race\\Younger", true, out subEle);
				YoungerRace.WriteXML(subEle);
			}
			if (MarkerUnknown != null)		
			{		
				ele.TryPathTo("MarkerUnknown", true, out subEle);
				MarkerUnknown.WriteXML(subEle);
			}
			if (Voice != null)		
			{		
				ele.TryPathTo("Voice", true, out subEle);
				Voice.WriteXML(subEle);
			}
			if (DefaultHairStyle != null)		
			{		
				ele.TryPathTo("DefaultHair\\Style", true, out subEle);
				DefaultHairStyle.WriteXML(subEle);
			}
			if (DefaultHairColor != null)		
			{		
				ele.TryPathTo("DefaultHair\\Color", true, out subEle);
				DefaultHairColor.WriteXML(subEle);
			}
			if (FaceGenMainClamp != null)		
			{		
				ele.TryPathTo("FaceGen\\MainClamp", true, out subEle);
				FaceGenMainClamp.WriteXML(subEle);
			}
			if (FaceGenFaceClamp != null)		
			{		
				ele.TryPathTo("FaceGen\\FaceClamp", true, out subEle);
				FaceGenFaceClamp.WriteXML(subEle);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle);
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
			if (ele.TryPathTo("Relationships", false, out subEle))
			{
				if (Relationships == null)
					Relationships = new List<Relationship>();
					
				foreach (XElement e in subEle.Elements())
				{
					Relationship tempXNAM = new Relationship();
					tempXNAM.ReadXML(e);
					Relationships.Add(tempXNAM);
				}
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new SimpleSubrecord<Byte[]>();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("Race\\Older", false, out subEle))
			{
				if (OlderRace == null)
					OlderRace = new SimpleSubrecord<FormID>();
					
				OlderRace.ReadXML(subEle);
			}
			if (ele.TryPathTo("Race\\Younger", false, out subEle))
			{
				if (YoungerRace == null)
					YoungerRace = new SimpleSubrecord<FormID>();
					
				YoungerRace.ReadXML(subEle);
			}
			if (ele.TryPathTo("MarkerUnknown", false, out subEle))
			{
				if (MarkerUnknown == null)
					MarkerUnknown = new SimpleSubrecord<Byte[]>();
					
				MarkerUnknown.ReadXML(subEle);
			}
			if (ele.TryPathTo("Voice", false, out subEle))
			{
				if (Voice == null)
					Voice = new SimpleSubrecord<Byte[]>();
					
				Voice.ReadXML(subEle);
			}
			if (ele.TryPathTo("DefaultHair\\Style", false, out subEle))
			{
				if (DefaultHairStyle == null)
					DefaultHairStyle = new SimpleSubrecord<Byte[]>();
					
				DefaultHairStyle.ReadXML(subEle);
			}
			if (ele.TryPathTo("DefaultHair\\Color", false, out subEle))
			{
				if (DefaultHairColor == null)
					DefaultHairColor = new SimpleSubrecord<Byte[]>();
					
				DefaultHairColor.ReadXML(subEle);
			}
			if (ele.TryPathTo("FaceGen\\MainClamp", false, out subEle))
			{
				if (FaceGenMainClamp == null)
					FaceGenMainClamp = new SimpleSubrecord<Single>();
					
				FaceGenMainClamp.ReadXML(subEle);
			}
			if (ele.TryPathTo("FaceGen\\FaceClamp", false, out subEle))
			{
				if (FaceGenFaceClamp == null)
					FaceGenFaceClamp = new SimpleSubrecord<Single>();
					
				FaceGenFaceClamp.ReadXML(subEle);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle);
			}
		}

	}
}
