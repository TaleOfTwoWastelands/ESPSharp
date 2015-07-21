
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
	public partial class LoadScreen : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public List<LoadScreenLocation> Locations { get; set; }
		public RecordReference LoadScreenType { get; set; }

		public LoadScreen()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			LargeIcon = new SimpleSubrecord<String>("ICON");
			SmallIcon = new SimpleSubrecord<String>("MICO");
			Description = new SimpleSubrecord<String>("DESC");
		}

		public LoadScreen(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, SimpleSubrecord<String> Description, List<LoadScreenLocation> Locations, RecordReference LoadScreenType)
		{
			this.EditorID = EditorID;
			this.LargeIcon = LargeIcon;
			this.SmallIcon = SmallIcon;
			this.Description = Description;
		}

		public LoadScreen(LoadScreen copyObject)
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
					case "DESC":
						if (Description == null)
							Description = new SimpleSubrecord<String>();

						Description.ReadBinary(reader);
						break;
					case "LNAM":
						if (Locations == null)
							Locations = new List<LoadScreenLocation>();

						LoadScreenLocation tempLNAM = new LoadScreenLocation();
						tempLNAM.ReadBinary(reader);
						Locations.Add(tempLNAM);
						break;
					case "WMI1":
						if (LoadScreenType == null)
							LoadScreenType = new RecordReference();

						LoadScreenType.ReadBinary(reader);
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
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Description != null)
				Description.WriteBinary(writer);
			if (Locations != null)
				foreach (var item in Locations)
					item.WriteBinary(writer);
			if (LoadScreenType != null)
				LoadScreenType.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon/Large", true, out subEle);
				LargeIcon.WriteXML(subEle, master);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon/Small", true, out subEle);
				SmallIcon.WriteXML(subEle, master);
			}
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle, master);
			}
			if (Locations != null)		
			{		
				ele.TryPathTo("Locations", true, out subEle);
				List<string> xmlNames = new List<string>{"Location"};
				int i = 0;
				foreach (var entry in Locations)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (LoadScreenType != null)		
			{		
				ele.TryPathTo("LoadScreenType", true, out subEle);
				LoadScreenType.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Icon/Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Locations", false, out subEle))
			{
				if (Locations == null)
					Locations = new List<LoadScreenLocation>();
					
				foreach (XElement e in subEle.Elements())
				{
					LoadScreenLocation tempLNAM = new LoadScreenLocation();
					tempLNAM.ReadXML(e, master);
					Locations.Add(tempLNAM);
				}
			}
			if (ele.TryPathTo("LoadScreenType", false, out subEle))
			{
				if (LoadScreenType == null)
					LoadScreenType = new RecordReference();
					
				LoadScreenType.ReadXML(subEle, master);
			}
		}		

		public LoadScreen Clone()
		{
			return new LoadScreen(this);
		}

	}
}