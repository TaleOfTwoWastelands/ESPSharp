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
	public partial class MapMarker : SubrecordCollection, ICloneable<MapMarker>
	{
		public SubMarker Marker { get; set; }
		public SimpleSubrecord<MapMarkerFlags> Flags { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public MapMarkerData Data { get; set; }
		public RecordReference Reputation { get; set; }

		public MapMarker()
		{
			Marker = new SubMarker();
			Name = new SimpleSubrecord<String>();
			Data = new MapMarkerData();
		}

		public MapMarker(SimpleSubrecord<MapMarkerFlags> Flags, SimpleSubrecord<String> Name, MapMarkerData Data, RecordReference Reputation)
		{
			this.Flags = Flags;
			this.Name = Name;
			this.Data = Data;
			this.Reputation = Reputation;
		}

		public MapMarker(MapMarker copyObject)
		{
			Flags = copyObject.Flags.Clone();
			Name = copyObject.Name.Clone();
			Data = copyObject.Data.Clone();
			Reputation = copyObject.Reputation.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			readTags.Add(reader.PeekTag());
			Marker.ReadBinary(reader);

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "FNAM":
						if (readTags.Contains("FNAM"))
							return;
						if (Flags == null)
							Flags = new SimpleSubrecord<MapMarkerFlags>();

						Flags.ReadBinary(reader);
						break;
					case "FULL":
						if (readTags.Contains("FULL"))
							return;
						Name.ReadBinary(reader);
						break;
					case "TNAM":
						if (readTags.Contains("TNAM"))
							return;
						Data.ReadBinary(reader);
						break;
					case "WMI1":
						if (readTags.Contains("WMI1"))
							return;
						if (Reputation == null)
							Reputation = new RecordReference();

						Reputation.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			Marker.WriteBinary(writer);

			if (Flags != null)
				Flags.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Reputation != null)
				Reputation.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (Flags != null)		
			{		
				ele.TryPathTo("Flags", true, out subEle);
				Flags.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Reputation != null)		
			{		
				ele.TryPathTo("Reputation", true, out subEle);
				Reputation.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				if (Flags == null)
					Flags = new SimpleSubrecord<MapMarkerFlags>();
					
				Flags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new MapMarkerData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Reputation", false, out subEle))
			{
				if (Reputation == null)
					Reputation = new RecordReference();
					
				Reputation.ReadXML(subEle, master);
			}
		}

		public MapMarker Clone()
		{
			return new MapMarker(this);
		}

	}
}
