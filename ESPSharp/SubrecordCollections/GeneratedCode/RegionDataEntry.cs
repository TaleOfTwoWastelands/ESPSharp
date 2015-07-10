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

namespace ESPSharp.SubrecordCollections
{
	public partial class RegionDataEntry : SubrecordCollection, ICloneable<RegionDataEntry>, IReferenceContainer
	{
		public RegionDataHeader Header { get; set; }
		public RegionObjectList ObjectList { get; set; }
		public SimpleSubrecord<String> MapName { get; set; }
		public RegionGrassList GrassList { get; set; }
		public SimpleSubrecord<RegionMusicType> MusicType { get; set; }
		public RecordReference Music { get; set; }
		public RecordReference IncidentalMediaSet { get; set; }
		public List<RecordReference> BattleMediaSets { get; set; }
		public RegionSoundList Sounds { get; set; }
		public RegionWeatherList Weathers { get; set; }
		public FormArray Imposters { get; set; }

		public RegionDataEntry()
		{
			Header = new RegionDataHeader();
		}

		public RegionDataEntry(RegionDataHeader Header, RegionObjectList ObjectList, SimpleSubrecord<String> MapName, RegionGrassList GrassList, SimpleSubrecord<RegionMusicType> MusicType, RecordReference Music, RecordReference IncidentalMediaSet, List<RecordReference> BattleMediaSets, RegionSoundList Sounds, RegionWeatherList Weathers, FormArray Imposters)
		{
			this.Header = Header;
			this.ObjectList = ObjectList;
			this.MapName = MapName;
			this.GrassList = GrassList;
			this.MusicType = MusicType;
			this.Music = Music;
			this.IncidentalMediaSet = IncidentalMediaSet;
			this.BattleMediaSets = BattleMediaSets;
			this.Sounds = Sounds;
			this.Weathers = Weathers;
			this.Imposters = Imposters;
		}

		public RegionDataEntry(RegionDataEntry copyObject)
		{
			Header = copyObject.Header.Clone();
			ObjectList = copyObject.ObjectList.Clone();
			MapName = copyObject.MapName.Clone();
			GrassList = copyObject.GrassList.Clone();
			MusicType = copyObject.MusicType.Clone();
			Music = copyObject.Music.Clone();
			IncidentalMediaSet = copyObject.IncidentalMediaSet.Clone();
			BattleMediaSets = new List<RecordReference>();
			foreach (var item in copyObject.BattleMediaSets)
			{
				BattleMediaSets.Add(item.Clone());
			}
			Sounds = copyObject.Sounds.Clone();
			Weathers = copyObject.Weathers.Clone();
			Imposters = copyObject.Imposters.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "RDAT":
						if (readTags.Contains("RDAT"))
							return;
						Header.ReadBinary(reader);
						break;
					case "RDOT":
						if (readTags.Contains("RDOT"))
							return;
						if (ObjectList == null)
							ObjectList = new RegionObjectList();

						ObjectList.ReadBinary(reader);
						break;
					case "RDMP":
						if (readTags.Contains("RDMP"))
							return;
						if (MapName == null)
							MapName = new SimpleSubrecord<String>();

						MapName.ReadBinary(reader);
						break;
					case "RDGS":
						if (readTags.Contains("RDGS"))
							return;
						if (GrassList == null)
							GrassList = new RegionGrassList();

						GrassList.ReadBinary(reader);
						break;
					case "RDMD":
						if (readTags.Contains("RDMD"))
							return;
						if (MusicType == null)
							MusicType = new SimpleSubrecord<RegionMusicType>();

						MusicType.ReadBinary(reader);
						break;
					case "RDMO":
						if (readTags.Contains("RDMO"))
							return;
						if (Music == null)
							Music = new RecordReference();

						Music.ReadBinary(reader);
						break;
					case "RDSI":
						if (readTags.Contains("RDSI"))
							return;
						if (IncidentalMediaSet == null)
							IncidentalMediaSet = new RecordReference();

						IncidentalMediaSet.ReadBinary(reader);
						break;
					case "RDSB":
						if (BattleMediaSets == null)
							BattleMediaSets = new List<RecordReference>();

						RecordReference tempRDSB = new RecordReference();
						tempRDSB.ReadBinary(reader);
						BattleMediaSets.Add(tempRDSB);
						break;
					case "RDSD":
						if (readTags.Contains("RDSD"))
							return;
						if (Sounds == null)
							Sounds = new RegionSoundList();

						Sounds.ReadBinary(reader);
						break;
					case "RDWT":
						if (readTags.Contains("RDWT"))
							return;
						if (Weathers == null)
							Weathers = new RegionWeatherList();

						Weathers.ReadBinary(reader);
						break;
					case "RDID":
						if (readTags.Contains("RDID"))
							return;
						if (Imposters == null)
							Imposters = new FormArray();

						Imposters.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Header != null)
				Header.WriteBinary(writer);
			if (ObjectList != null)
				ObjectList.WriteBinary(writer);
			if (MapName != null)
				MapName.WriteBinary(writer);
			if (GrassList != null)
				GrassList.WriteBinary(writer);
			if (MusicType != null)
				MusicType.WriteBinary(writer);
			if (Music != null)
				Music.WriteBinary(writer);
			if (IncidentalMediaSet != null)
				IncidentalMediaSet.WriteBinary(writer);
			if (BattleMediaSets != null)
				foreach (var item in BattleMediaSets)
					item.WriteBinary(writer);
			if (Sounds != null)
				Sounds.WriteBinary(writer);
			if (Weathers != null)
				Weathers.WriteBinary(writer);
			if (Imposters != null)
				Imposters.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Header != null)		
			{		
				ele.TryPathTo("Header", true, out subEle);
				Header.WriteXML(subEle, master);
			}
			if (ObjectList != null)		
			{		
				ele.TryPathTo("ObjectList", true, out subEle);
				ObjectList.WriteXML(subEle, master);
			}
			if (MapName != null)		
			{		
				ele.TryPathTo("MapName", true, out subEle);
				MapName.WriteXML(subEle, master);
			}
			if (GrassList != null)		
			{		
				ele.TryPathTo("GrassList", true, out subEle);
				GrassList.WriteXML(subEle, master);
			}
			if (MusicType != null)		
			{		
				ele.TryPathTo("MusicType", true, out subEle);
				MusicType.WriteXML(subEle, master);
			}
			if (Music != null)		
			{		
				ele.TryPathTo("Music", true, out subEle);
				Music.WriteXML(subEle, master);
			}
			if (IncidentalMediaSet != null)		
			{		
				ele.TryPathTo("MediaSet/Incidental", true, out subEle);
				IncidentalMediaSet.WriteXML(subEle, master);
			}
			if (BattleMediaSets != null)		
			{		
				ele.TryPathTo("MediaSet/Battle", true, out subEle);
				foreach (var entry in BattleMediaSets)
				{
					XElement newEle = new XElement("MediaSet");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
			if (Sounds != null)		
			{		
				ele.TryPathTo("Sounds", true, out subEle);
				Sounds.WriteXML(subEle, master);
			}
			if (Weathers != null)		
			{		
				ele.TryPathTo("Weathers", true, out subEle);
				Weathers.WriteXML(subEle, master);
			}
			if (Imposters != null)		
			{		
				ele.TryPathTo("Imposters", true, out subEle);
				Imposters.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Header", false, out subEle))
			{
				if (Header == null)
					Header = new RegionDataHeader();
					
				Header.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ObjectList", false, out subEle))
			{
				if (ObjectList == null)
					ObjectList = new RegionObjectList();
					
				ObjectList.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MapName", false, out subEle))
			{
				if (MapName == null)
					MapName = new SimpleSubrecord<String>();
					
				MapName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("GrassList", false, out subEle))
			{
				if (GrassList == null)
					GrassList = new RegionGrassList();
					
				GrassList.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MusicType", false, out subEle))
			{
				if (MusicType == null)
					MusicType = new SimpleSubrecord<RegionMusicType>();
					
				MusicType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Music", false, out subEle))
			{
				if (Music == null)
					Music = new RecordReference();
					
				Music.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MediaSet/Incidental", false, out subEle))
			{
				if (IncidentalMediaSet == null)
					IncidentalMediaSet = new RecordReference();
					
				IncidentalMediaSet.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MediaSet/Battle", false, out subEle))
			{
				if (BattleMediaSets == null)
					BattleMediaSets = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference temp = new RecordReference();
					temp.ReadXML(e, master);
					BattleMediaSets.Add(temp);
				}
			}
			if (ele.TryPathTo("Sounds", false, out subEle))
			{
				if (Sounds == null)
					Sounds = new RegionSoundList();
					
				Sounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Weathers", false, out subEle))
			{
				if (Weathers == null)
					Weathers = new RegionWeatherList();
					
				Weathers.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Imposters", false, out subEle))
			{
				if (Imposters == null)
					Imposters = new FormArray();
					
				Imposters.ReadXML(subEle, master);
			}
		}

		public RegionDataEntry Clone()
		{
			return new RegionDataEntry(this);
		}

	}
}
