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
	public partial class Weather : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public RecordReference ImageSpaceModifierSunrise { get; set; }
		public RecordReference ImageSpaceModifierDay { get; set; }
		public RecordReference ImageSpaceModifierSunset { get; set; }
		public RecordReference ImageSpaceModifierNight { get; set; }
		public RecordReference ImageSpaceModifierHighNoon { get; set; }
		public RecordReference ImageSpaceModifierMidnight { get; set; }
		public SimpleSubrecord<String> CloudTextureLayer0 { get; set; }
		public SimpleSubrecord<String> CloudTextureLayer1 { get; set; }
		public SimpleSubrecord<String> CloudTextureLayer2 { get; set; }
		public SimpleSubrecord<String> CloudTextureLayer3 { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }
		public CloudLayerSpeed CloudLayerSpeed { get; set; }
		public CloudLayerColors CloudLayerColors { get; set; }
		public EnvironmentalColors EnvironmentalColors { get; set; }
		public WeatherFogDistance WeatherFogDistance { get; set; }
		public SimpleSubrecord<Byte[]> Unused { get; set; }
		public WeatherData Data { get; set; }
		public List<WeatherSound> Sounds { get; set; }
	
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
					case "aIAD":
						if (ImageSpaceModifierSunrise == null)
							ImageSpaceModifierSunrise = new RecordReference();

						ImageSpaceModifierSunrise.ReadBinary(reader);
						break;
					case "bIAD":
						if (ImageSpaceModifierDay == null)
							ImageSpaceModifierDay = new RecordReference();

						ImageSpaceModifierDay.ReadBinary(reader);
						break;
					case "cIAD":
						if (ImageSpaceModifierSunset == null)
							ImageSpaceModifierSunset = new RecordReference();

						ImageSpaceModifierSunset.ReadBinary(reader);
						break;
					case "dIAD":
						if (ImageSpaceModifierNight == null)
							ImageSpaceModifierNight = new RecordReference();

						ImageSpaceModifierNight.ReadBinary(reader);
						break;
					case "eIAD":
						if (ImageSpaceModifierHighNoon == null)
							ImageSpaceModifierHighNoon = new RecordReference();

						ImageSpaceModifierHighNoon.ReadBinary(reader);
						break;
					case "fIAD":
						if (ImageSpaceModifierMidnight == null)
							ImageSpaceModifierMidnight = new RecordReference();

						ImageSpaceModifierMidnight.ReadBinary(reader);
						break;
					case "DNAM":
						if (CloudTextureLayer0 == null)
							CloudTextureLayer0 = new SimpleSubrecord<String>();

						CloudTextureLayer0.ReadBinary(reader);
						break;
					case "CNAM":
						if (CloudTextureLayer1 == null)
							CloudTextureLayer1 = new SimpleSubrecord<String>();

						CloudTextureLayer1.ReadBinary(reader);
						break;
					case "ANAM":
						if (CloudTextureLayer2 == null)
							CloudTextureLayer2 = new SimpleSubrecord<String>();

						CloudTextureLayer2.ReadBinary(reader);
						break;
					case "BNAM":
						if (CloudTextureLayer3 == null)
							CloudTextureLayer3 = new SimpleSubrecord<String>();

						CloudTextureLayer3.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "LNAM":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte[]>();

						Unknown.ReadBinary(reader);
						break;
					case "ONAM":
						if (CloudLayerSpeed == null)
							CloudLayerSpeed = new CloudLayerSpeed();

						CloudLayerSpeed.ReadBinary(reader);
						break;
					case "PNAM":
						if (CloudLayerColors == null)
							CloudLayerColors = new CloudLayerColors();

						CloudLayerColors.ReadBinary(reader);
						break;
					case "NAM0":
						if (EnvironmentalColors == null)
							EnvironmentalColors = new EnvironmentalColors();

						EnvironmentalColors.ReadBinary(reader);
						break;
					case "FNAM":
						if (WeatherFogDistance == null)
							WeatherFogDistance = new WeatherFogDistance();

						WeatherFogDistance.ReadBinary(reader);
						break;
					case "INAM":
						if (Unused == null)
							Unused = new SimpleSubrecord<Byte[]>();

						Unused.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new WeatherData();

						Data.ReadBinary(reader);
						break;
					case "SNAM":
						if (Sounds == null)
							Sounds = new List<WeatherSound>();

						WeatherSound tempSNAM = new WeatherSound();
						tempSNAM.ReadBinary(reader);
						Sounds.Add(tempSNAM);
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
			if (ImageSpaceModifierSunrise != null)
				ImageSpaceModifierSunrise.WriteBinary(writer);
			if (ImageSpaceModifierDay != null)
				ImageSpaceModifierDay.WriteBinary(writer);
			if (ImageSpaceModifierSunset != null)
				ImageSpaceModifierSunset.WriteBinary(writer);
			if (ImageSpaceModifierNight != null)
				ImageSpaceModifierNight.WriteBinary(writer);
			if (ImageSpaceModifierHighNoon != null)
				ImageSpaceModifierHighNoon.WriteBinary(writer);
			if (ImageSpaceModifierMidnight != null)
				ImageSpaceModifierMidnight.WriteBinary(writer);
			if (CloudTextureLayer0 != null)
				CloudTextureLayer0.WriteBinary(writer);
			if (CloudTextureLayer1 != null)
				CloudTextureLayer1.WriteBinary(writer);
			if (CloudTextureLayer2 != null)
				CloudTextureLayer2.WriteBinary(writer);
			if (CloudTextureLayer3 != null)
				CloudTextureLayer3.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (CloudLayerSpeed != null)
				CloudLayerSpeed.WriteBinary(writer);
			if (CloudLayerColors != null)
				CloudLayerColors.WriteBinary(writer);
			if (EnvironmentalColors != null)
				EnvironmentalColors.WriteBinary(writer);
			if (WeatherFogDistance != null)
				WeatherFogDistance.WriteBinary(writer);
			if (Unused != null)
				Unused.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Sounds != null)
				foreach (var item in Sounds)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierSunrise != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/Sunrise", true, out subEle);
				ImageSpaceModifierSunrise.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierDay != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/Day", true, out subEle);
				ImageSpaceModifierDay.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierSunset != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/Sunset", true, out subEle);
				ImageSpaceModifierSunset.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierNight != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/Night", true, out subEle);
				ImageSpaceModifierNight.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierHighNoon != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/HighNoon", true, out subEle);
				ImageSpaceModifierHighNoon.WriteXML(subEle, master);
			}
			if (ImageSpaceModifierMidnight != null)		
			{		
				ele.TryPathTo("ImageSpaceModifier/Midnight", true, out subEle);
				ImageSpaceModifierMidnight.WriteXML(subEle, master);
			}
			if (CloudTextureLayer0 != null)		
			{		
				ele.TryPathTo("CloudTexture/Layer0", true, out subEle);
				CloudTextureLayer0.WriteXML(subEle, master);
			}
			if (CloudTextureLayer1 != null)		
			{		
				ele.TryPathTo("CloudTexture/Layer1", true, out subEle);
				CloudTextureLayer1.WriteXML(subEle, master);
			}
			if (CloudTextureLayer2 != null)		
			{		
				ele.TryPathTo("CloudTexture/Layer2", true, out subEle);
				CloudTextureLayer2.WriteXML(subEle, master);
			}
			if (CloudTextureLayer3 != null)		
			{		
				ele.TryPathTo("CloudTexture/Layer3", true, out subEle);
				CloudTextureLayer3.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (CloudLayerSpeed != null)		
			{		
				ele.TryPathTo("CloudLayerSpeed", true, out subEle);
				CloudLayerSpeed.WriteXML(subEle, master);
			}
			if (CloudLayerColors != null)		
			{		
				ele.TryPathTo("CloudLayerColors", true, out subEle);
				CloudLayerColors.WriteXML(subEle, master);
			}
			if (EnvironmentalColors != null)		
			{		
				ele.TryPathTo("EnvironmentalColors", true, out subEle);
				EnvironmentalColors.WriteXML(subEle, master);
			}
			if (WeatherFogDistance != null)		
			{		
				ele.TryPathTo("WeatherFogDistance", true, out subEle);
				WeatherFogDistance.WriteXML(subEle, master);
			}
			if (Unused != null)		
			{		
				ele.TryPathTo("Unused", true, out subEle);
				Unused.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Sounds != null)		
			{		
				ele.TryPathTo("Sounds", true, out subEle);
				List<string> xmlNames = new List<string>{"Sound"};
				int i = 0;
				foreach (var entry in Sounds)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("ImageSpaceModifier/Sunrise", false, out subEle))
			{
				if (ImageSpaceModifierSunrise == null)
					ImageSpaceModifierSunrise = new RecordReference();
					
				ImageSpaceModifierSunrise.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier/Day", false, out subEle))
			{
				if (ImageSpaceModifierDay == null)
					ImageSpaceModifierDay = new RecordReference();
					
				ImageSpaceModifierDay.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier/Sunset", false, out subEle))
			{
				if (ImageSpaceModifierSunset == null)
					ImageSpaceModifierSunset = new RecordReference();
					
				ImageSpaceModifierSunset.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier/Night", false, out subEle))
			{
				if (ImageSpaceModifierNight == null)
					ImageSpaceModifierNight = new RecordReference();
					
				ImageSpaceModifierNight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier/HighNoon", false, out subEle))
			{
				if (ImageSpaceModifierHighNoon == null)
					ImageSpaceModifierHighNoon = new RecordReference();
					
				ImageSpaceModifierHighNoon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ImageSpaceModifier/Midnight", false, out subEle))
			{
				if (ImageSpaceModifierMidnight == null)
					ImageSpaceModifierMidnight = new RecordReference();
					
				ImageSpaceModifierMidnight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudTexture/Layer0", false, out subEle))
			{
				if (CloudTextureLayer0 == null)
					CloudTextureLayer0 = new SimpleSubrecord<String>();
					
				CloudTextureLayer0.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudTexture/Layer1", false, out subEle))
			{
				if (CloudTextureLayer1 == null)
					CloudTextureLayer1 = new SimpleSubrecord<String>();
					
				CloudTextureLayer1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudTexture/Layer2", false, out subEle))
			{
				if (CloudTextureLayer2 == null)
					CloudTextureLayer2 = new SimpleSubrecord<String>();
					
				CloudTextureLayer2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudTexture/Layer3", false, out subEle))
			{
				if (CloudTextureLayer3 == null)
					CloudTextureLayer3 = new SimpleSubrecord<String>();
					
				CloudTextureLayer3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudLayerSpeed", false, out subEle))
			{
				if (CloudLayerSpeed == null)
					CloudLayerSpeed = new CloudLayerSpeed();
					
				CloudLayerSpeed.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CloudLayerColors", false, out subEle))
			{
				if (CloudLayerColors == null)
					CloudLayerColors = new CloudLayerColors();
					
				CloudLayerColors.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnvironmentalColors", false, out subEle))
			{
				if (EnvironmentalColors == null)
					EnvironmentalColors = new EnvironmentalColors();
					
				EnvironmentalColors.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WeatherFogDistance", false, out subEle))
			{
				if (WeatherFogDistance == null)
					WeatherFogDistance = new WeatherFogDistance();
					
				WeatherFogDistance.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused", false, out subEle))
			{
				if (Unused == null)
					Unused = new SimpleSubrecord<Byte[]>();
					
				Unused.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new WeatherData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sounds", false, out subEle))
			{
				if (Sounds == null)
					Sounds = new List<WeatherSound>();
					
				foreach (XElement e in subEle.Elements())
				{
					WeatherSound tempSNAM = new WeatherSound();
					tempSNAM.ReadXML(e, master);
					Sounds.Add(tempSNAM);
				}
			}
		}

	}
}
