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
	public partial class Region : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public SimpleSubrecord<Color> MapColor { get; set; }
		public RecordReference Worldspace { get; set; }
		public List<RegionArea> Areas { get; set; }
		public List<RegionDataEntry> DataEntries { get; set; }
	
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
					case "RCLR":
						if (MapColor == null)
							MapColor = new SimpleSubrecord<Color>();

						MapColor.ReadBinary(reader);
						break;
					case "WNAM":
						if (Worldspace == null)
							Worldspace = new RecordReference();

						Worldspace.ReadBinary(reader);
						break;
					case "RPLI":
						if (Areas == null)
							Areas = new List<RegionArea>();

						RegionArea tempRPLI = new RegionArea();
						tempRPLI.ReadBinary(reader);
						Areas.Add(tempRPLI);
						break;
					case "RDAT":
						if (DataEntries == null)
							DataEntries = new List<RegionDataEntry>();

						RegionDataEntry tempRDAT = new RegionDataEntry();
						tempRDAT.ReadBinary(reader);
						DataEntries.Add(tempRDAT);
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
			if (MapColor != null)
				MapColor.WriteBinary(writer);
			if (Worldspace != null)
				Worldspace.WriteBinary(writer);
			if (Areas != null)
				foreach (var item in Areas)
					item.WriteBinary(writer);
			if (DataEntries != null)
				foreach (var item in DataEntries)
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
			if (MapColor != null)		
			{		
				ele.TryPathTo("MapColor", true, out subEle);
				MapColor.WriteXML(subEle, master);
			}
			if (Worldspace != null)		
			{		
				ele.TryPathTo("Worldspace", true, out subEle);
				Worldspace.WriteXML(subEle, master);
			}
			if (Areas != null)		
			{		
				ele.TryPathTo("Areas", true, out subEle);
				List<string> xmlNames = new List<string>{"Area"};
				int i = 0;
				foreach (var entry in Areas)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (DataEntries != null)		
			{		
				ele.TryPathTo("DataEntries", true, out subEle);
				List<string> xmlNames = new List<string>{"DataEntry"};
				int i = 0;
				foreach (var entry in DataEntries)
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
			if (ele.TryPathTo("MapColor", false, out subEle))
			{
				if (MapColor == null)
					MapColor = new SimpleSubrecord<Color>();
					
				MapColor.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Worldspace", false, out subEle))
			{
				if (Worldspace == null)
					Worldspace = new RecordReference();
					
				Worldspace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Areas", false, out subEle))
			{
				if (Areas == null)
					Areas = new List<RegionArea>();
					
				foreach (XElement e in subEle.Elements())
				{
					RegionArea tempRPLI = new RegionArea();
					tempRPLI.ReadXML(e, master);
					Areas.Add(tempRPLI);
				}
			}
			if (ele.TryPathTo("DataEntries", false, out subEle))
			{
				if (DataEntries == null)
					DataEntries = new List<RegionDataEntry>();
					
				foreach (XElement e in subEle.Elements())
				{
					RegionDataEntry tempRDAT = new RegionDataEntry();
					tempRDAT.ReadXML(e, master);
					DataEntries.Add(tempRDAT);
				}
			}
		}

	}
}
