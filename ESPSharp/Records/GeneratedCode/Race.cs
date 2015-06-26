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
	public partial class Race : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public List<Relationship> Relationships { get; set; }
		public RaceData Data { get; set; }
		public RecordReference OlderRace { get; set; }
		public RecordReference YoungerRace { get; set; }
		public SubMarker UnknownMarker { get; set; }
		public RaceDefaultVoices DefaultVoices { get; set; }
		public RaceDefaultHairStyles DefaultHairStyles { get; set; }
		public RaceDefaultHairColors DefaultHairColors { get; set; }
		public SimpleSubrecord<Single> FaceGenMainClamp { get; set; }
		public SimpleSubrecord<Single> FaceGenFaceClamp { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }
		public RaceHeadData HeadData { get; set; }
		public RaceBodyData BodyData { get; set; }
		public FormArray Hairs { get; set; }
		public FormArray Eyes { get; set; }
		public FaceGenData MaleFaceGenData { get; set; }
		public FaceGenData FemaleFaceGenData { get; set; }
	
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
							Data = new RaceData();

						Data.ReadBinary(reader);
						break;
					case "ONAM":
						if (OlderRace == null)
							OlderRace = new RecordReference();

						OlderRace.ReadBinary(reader);
						break;
					case "YNAM":
						if (YoungerRace == null)
							YoungerRace = new RecordReference();

						YoungerRace.ReadBinary(reader);
						break;
					case "NAM2":
						if (UnknownMarker == null)
							UnknownMarker = new SubMarker();

						UnknownMarker.ReadBinary(reader);
						break;
					case "VTCK":
						if (DefaultVoices == null)
							DefaultVoices = new RaceDefaultVoices();

						DefaultVoices.ReadBinary(reader);
						break;
					case "DNAM":
						if (DefaultHairStyles == null)
							DefaultHairStyles = new RaceDefaultHairStyles();

						DefaultHairStyles.ReadBinary(reader);
						break;
					case "CNAM":
						if (DefaultHairColors == null)
							DefaultHairColors = new RaceDefaultHairColors();

						DefaultHairColors.ReadBinary(reader);
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
					case "NAM0":
						if (HeadData == null)
							HeadData = new RaceHeadData();

						HeadData.ReadBinary(reader);
						break;
					case "NAM1":
						if (BodyData == null)
							BodyData = new RaceBodyData();

						BodyData.ReadBinary(reader);
						break;
					case "HNAM":
						if (Hairs == null)
							Hairs = new FormArray();

						Hairs.ReadBinary(reader);
						break;
					case "ENAM":
						if (Eyes == null)
							Eyes = new FormArray();

						Eyes.ReadBinary(reader);
						break;
					case "MNAM":
						if (MaleFaceGenData == null)
							MaleFaceGenData = new FaceGenData();

						MaleFaceGenData.ReadBinary(reader);
						break;
					case "FNAM":
						if (FemaleFaceGenData == null)
							FemaleFaceGenData = new FaceGenData();

						FemaleFaceGenData.ReadBinary(reader);
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
			if (UnknownMarker != null)
				UnknownMarker.WriteBinary(writer);
			if (DefaultVoices != null)
				DefaultVoices.WriteBinary(writer);
			if (DefaultHairStyles != null)
				DefaultHairStyles.WriteBinary(writer);
			if (DefaultHairColors != null)
				DefaultHairColors.WriteBinary(writer);
			if (FaceGenMainClamp != null)
				FaceGenMainClamp.WriteBinary(writer);
			if (FaceGenFaceClamp != null)
				FaceGenFaceClamp.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (HeadData != null)
				HeadData.WriteBinary(writer);
			if (BodyData != null)
				BodyData.WriteBinary(writer);
			if (Hairs != null)
				Hairs.WriteBinary(writer);
			if (Eyes != null)
				Eyes.WriteBinary(writer);
			if (MaleFaceGenData != null)
				MaleFaceGenData.WriteBinary(writer);
			if (FemaleFaceGenData != null)
				FemaleFaceGenData.WriteBinary(writer);
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
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle, master);
			}
			if (Relationships != null)		
			{		
				ele.TryPathTo("Relationships", true, out subEle);
				List<string> xmlNames = new List<string>{"Relationship"};
				int i = 0;
				foreach (var entry in Relationships)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (OlderRace != null)		
			{		
				ele.TryPathTo("Race/Older", true, out subEle);
				OlderRace.WriteXML(subEle, master);
			}
			if (YoungerRace != null)		
			{		
				ele.TryPathTo("Race/Younger", true, out subEle);
				YoungerRace.WriteXML(subEle, master);
			}
			if (UnknownMarker != null)		
			{		
				ele.TryPathTo("UnknownMarker", true, out subEle);
				UnknownMarker.WriteXML(subEle, master);
			}
			if (DefaultVoices != null)		
			{		
				ele.TryPathTo("Defaults/Voices", true, out subEle);
				DefaultVoices.WriteXML(subEle, master);
			}
			if (DefaultHairStyles != null)		
			{		
				ele.TryPathTo("Defaults/HairStyles", true, out subEle);
				DefaultHairStyles.WriteXML(subEle, master);
			}
			if (DefaultHairColors != null)		
			{		
				ele.TryPathTo("Defaults/HairColors", true, out subEle);
				DefaultHairColors.WriteXML(subEle, master);
			}
			if (FaceGenMainClamp != null)		
			{		
				ele.TryPathTo("FaceGen/Clamps/Main", true, out subEle);
				FaceGenMainClamp.WriteXML(subEle, master);
			}
			if (FaceGenFaceClamp != null)		
			{		
				ele.TryPathTo("FaceGen/Clamps/Face", true, out subEle);
				FaceGenFaceClamp.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (HeadData != null)		
			{		
				ele.TryPathTo("HeadData", true, out subEle);
				HeadData.WriteXML(subEle, master);
			}
			if (BodyData != null)		
			{		
				ele.TryPathTo("BodyData", true, out subEle);
				BodyData.WriteXML(subEle, master);
			}
			if (Hairs != null)		
			{		
				ele.TryPathTo("Hairs", true, out subEle);
				Hairs.WriteXML(subEle, master);
			}
			if (Eyes != null)		
			{		
				ele.TryPathTo("Eyes", true, out subEle);
				Eyes.WriteXML(subEle, master);
			}
			if (MaleFaceGenData != null)		
			{		
				ele.TryPathTo("FaceGen/Male", true, out subEle);
				MaleFaceGenData.WriteXML(subEle, master);
			}
			if (FemaleFaceGenData != null)		
			{		
				ele.TryPathTo("FaceGen/Female", true, out subEle);
				FemaleFaceGenData.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Relationships", false, out subEle))
			{
				if (Relationships == null)
					Relationships = new List<Relationship>();
					
				foreach (XElement e in subEle.Elements())
				{
					Relationship tempXNAM = new Relationship();
					tempXNAM.ReadXML(e, master);
					Relationships.Add(tempXNAM);
				}
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new RaceData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Race/Older", false, out subEle))
			{
				if (OlderRace == null)
					OlderRace = new RecordReference();
					
				OlderRace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Race/Younger", false, out subEle))
			{
				if (YoungerRace == null)
					YoungerRace = new RecordReference();
					
				YoungerRace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("UnknownMarker", false, out subEle))
			{
				if (UnknownMarker == null)
					UnknownMarker = new SubMarker();
					
				UnknownMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Defaults/Voices", false, out subEle))
			{
				if (DefaultVoices == null)
					DefaultVoices = new RaceDefaultVoices();
					
				DefaultVoices.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Defaults/HairStyles", false, out subEle))
			{
				if (DefaultHairStyles == null)
					DefaultHairStyles = new RaceDefaultHairStyles();
					
				DefaultHairStyles.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Defaults/HairColors", false, out subEle))
			{
				if (DefaultHairColors == null)
					DefaultHairColors = new RaceDefaultHairColors();
					
				DefaultHairColors.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Clamps/Main", false, out subEle))
			{
				if (FaceGenMainClamp == null)
					FaceGenMainClamp = new SimpleSubrecord<Single>();
					
				FaceGenMainClamp.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Clamps/Face", false, out subEle))
			{
				if (FaceGenFaceClamp == null)
					FaceGenFaceClamp = new SimpleSubrecord<Single>();
					
				FaceGenFaceClamp.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HeadData", false, out subEle))
			{
				if (HeadData == null)
					HeadData = new RaceHeadData();
					
				HeadData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BodyData", false, out subEle))
			{
				if (BodyData == null)
					BodyData = new RaceBodyData();
					
				BodyData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Hairs", false, out subEle))
			{
				if (Hairs == null)
					Hairs = new FormArray();
					
				Hairs.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Eyes", false, out subEle))
			{
				if (Eyes == null)
					Eyes = new FormArray();
					
				Eyes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Male", false, out subEle))
			{
				if (MaleFaceGenData == null)
					MaleFaceGenData = new FaceGenData();
					
				MaleFaceGenData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGen/Female", false, out subEle))
			{
				if (FemaleFaceGenData == null)
					FemaleFaceGenData = new FaceGenData();
					
				FemaleFaceGenData.ReadXML(subEle, master);
			}
		}

	}
}
