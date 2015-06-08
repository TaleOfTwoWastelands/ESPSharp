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
	public partial class Faction : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public List<Relationship> Relationships { get; set; }
		public FactionData Data { get; set; }
		public SimpleSubrecord<Single> Unused { get; set; }
		public List<FactionRank> Ranks { get; set; }
		public RecordReference Reputation { get; set; }
	
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
					case "XNAM":
						if (Relationships == null)
							Relationships = new List<Relationship>();

						Relationship tempXNAM = new Relationship();
						tempXNAM.ReadBinary(reader);
						Relationships.Add(tempXNAM);
						break;
					case "DATA":
						if (Data == null)
							Data = new FactionData();

						Data.ReadBinary(reader);
						break;
					case "CNAM":
						if (Unused == null)
							Unused = new SimpleSubrecord<Single>();

						Unused.ReadBinary(reader);
						break;
					case "RNAM":
						if (Ranks == null)
							Ranks = new List<FactionRank>();

						FactionRank tempRNAM = new FactionRank();
						tempRNAM.ReadBinary(reader);
						Ranks.Add(tempRNAM);
						break;
					case "WMI1":
						if (Reputation == null)
							Reputation = new RecordReference();

						Reputation.ReadBinary(reader);
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
			if (Relationships != null)
				foreach (var item in Relationships)
					item.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Unused != null)
				Unused.WriteBinary(writer);
			if (Ranks != null)
				foreach (var item in Ranks)
					item.WriteBinary(writer);
			if (Reputation != null)
				Reputation.WriteBinary(writer);
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
			if (Relationships != null)		
			{		
				ele.TryPathTo("Relationships", true, out subEle);
				List<string> xmlNames = new List<string>{"Relationship"};
				int i = 0;
				foreach (var entry in Relationships)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (Unused != null)		
			{		
				ele.TryPathTo("Unused", true, out subEle);
				Unused.WriteXML(subEle);
			}
			if (Ranks != null)		
			{		
				ele.TryPathTo("Ranks", true, out subEle);
				List<string> xmlNames = new List<string>{"Rank"};
				int i = 0;
				foreach (var entry in Ranks)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Reputation != null)		
			{		
				ele.TryPathTo("Reputation", true, out subEle);
				Reputation.WriteXML(subEle);
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
					Data = new FactionData();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("Unused", false, out subEle))
			{
				if (Unused == null)
					Unused = new SimpleSubrecord<Single>();
					
				Unused.ReadXML(subEle);
			}
			if (ele.TryPathTo("Ranks", false, out subEle))
			{
				if (Ranks == null)
					Ranks = new List<FactionRank>();
					
				foreach (XElement e in subEle.Elements())
				{
					FactionRank tempRNAM = new FactionRank();
					tempRNAM.ReadXML(e);
					Ranks.Add(tempRNAM);
				}
			}
			if (ele.TryPathTo("Reputation", false, out subEle))
			{
				if (Reputation == null)
					Reputation = new RecordReference();
					
				Reputation.ReadXML(subEle);
			}
		}

	}
}
