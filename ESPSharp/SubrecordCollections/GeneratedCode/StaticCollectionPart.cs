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
	public partial class StaticCollectionPart : SubrecordCollection, ICloneable<StaticCollectionPart>, IReferenceContainer
	{
		public RecordReference Static { get; set; }
		public StaticCollectionPartData Placements { get; set; }

		public StaticCollectionPart()
		{
			Static = new RecordReference();
			Placements = new StaticCollectionPartData();
		}

		public StaticCollectionPart(RecordReference Static, StaticCollectionPartData Placements)
		{
			this.Static = Static;
			this.Placements = Placements;
		}

		public StaticCollectionPart(StaticCollectionPart copyObject)
		{
			Static = copyObject.Static.Clone();
			Placements = copyObject.Placements.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "ONAM":
						if (readTags.Contains("ONAM"))
							return;
						Static.ReadBinary(reader);
						break;
					case "DATA":
						if (readTags.Contains("DATA"))
							return;
						Placements.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Static != null)
				Static.WriteBinary(writer);
			if (Placements != null)
				Placements.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Static != null)		
			{		
				ele.TryPathTo("Static", true, out subEle);
				Static.WriteXML(subEle, master);
			}
			if (Placements != null)		
			{		
				ele.TryPathTo("Placements", true, out subEle);
				Placements.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Static", false, out subEle))
			{
				if (Static == null)
					Static = new RecordReference();
					
				Static.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Placements", false, out subEle))
			{
				if (Placements == null)
					Placements = new StaticCollectionPartData();
					
				Placements.ReadXML(subEle, master);
			}
		}

		public StaticCollectionPart Clone()
		{
			return new StaticCollectionPart(this);
		}

	}
}
