
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
	public partial class Climate : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public WeatherList Weathers { get; set; }
		public SimpleSubrecord<String> SunTexture { get; set; }
		public SimpleSubrecord<String> SunGlareTexture { get; set; }
		public Model Model { get; set; }
		public ClimateTiming Timing { get; set; }

		public Climate()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public Climate(SimpleSubrecord<String> EditorID, WeatherList Weathers, SimpleSubrecord<String> SunTexture, SimpleSubrecord<String> SunGlareTexture, Model Model, ClimateTiming Timing)
		{
			this.EditorID = EditorID;
		}

		public Climate(Climate copyObject)
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
					case "WLST":
						if (Weathers == null)
							Weathers = new WeatherList();

						Weathers.ReadBinary(reader);
						break;
					case "FNAM":
						if (SunTexture == null)
							SunTexture = new SimpleSubrecord<String>();

						SunTexture.ReadBinary(reader);
						break;
					case "GNAM":
						if (SunGlareTexture == null)
							SunGlareTexture = new SimpleSubrecord<String>();

						SunGlareTexture.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "TNAM":
						if (Timing == null)
							Timing = new ClimateTiming();

						Timing.ReadBinary(reader);
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
			if (Weathers != null)
				Weathers.WriteBinary(writer);
			if (SunTexture != null)
				SunTexture.WriteBinary(writer);
			if (SunGlareTexture != null)
				SunGlareTexture.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Timing != null)
				Timing.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Weathers != null)		
			{		
				ele.TryPathTo("Weathers", true, out subEle);
				Weathers.WriteXML(subEle, master);
			}
			if (SunTexture != null)		
			{		
				ele.TryPathTo("SunTexture", true, out subEle);
				SunTexture.WriteXML(subEle, master);
			}
			if (SunGlareTexture != null)		
			{		
				ele.TryPathTo("SunGlareTexture", true, out subEle);
				SunGlareTexture.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Timing != null)		
			{		
				ele.TryPathTo("Timing", true, out subEle);
				Timing.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Weathers", false, out subEle))
			{
				if (Weathers == null)
					Weathers = new WeatherList();
					
				Weathers.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SunTexture", false, out subEle))
			{
				if (SunTexture == null)
					SunTexture = new SimpleSubrecord<String>();
					
				SunTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SunGlareTexture", false, out subEle))
			{
				if (SunGlareTexture == null)
					SunGlareTexture = new SimpleSubrecord<String>();
					
				SunGlareTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Timing", false, out subEle))
			{
				if (Timing == null)
					Timing = new ClimateTiming();
					
				Timing.ReadXML(subEle, master);
			}
		}		

		public Climate Clone()
		{
			return new Climate(this);
		}

	}
}