
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
	public partial class CaravanDeck : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public List<RecordReference> Cards { get; set; }
		public SimpleSubrecord<UInt32> Data { get; set; }

		public CaravanDeck()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public CaravanDeck(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, List<RecordReference> Cards, SimpleSubrecord<UInt32> Data)
		{
			this.EditorID = EditorID;
		}

		public CaravanDeck(CaravanDeck copyObject)
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
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "CARD":
						if (Cards == null)
							Cards = new List<RecordReference>();

						RecordReference tempCARD = new RecordReference();
						tempCARD.ReadBinary(reader);
						Cards.Add(tempCARD);
						break;
					case "DATA":
						if (Data == null)
							Data = new SimpleSubrecord<UInt32>();

						Data.ReadBinary(reader);
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
			if (Cards != null)
				foreach (var item in Cards)
					item.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
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
			if (Cards != null)		
			{		
				ele.TryPathTo("Cards", true, out subEle);
				List<string> xmlNames = new List<string>{"Card"};
				int i = 0;
				foreach (var entry in Cards)
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
			if (ele.TryPathTo("Cards", false, out subEle))
			{
				if (Cards == null)
					Cards = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempCARD = new RecordReference();
					tempCARD.ReadXML(e, master);
					Cards.Add(tempCARD);
				}
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new SimpleSubrecord<UInt32>();
					
				Data.ReadXML(subEle, master);
			}
		}		

		public CaravanDeck Clone()
		{
			return new CaravanDeck(this);
		}

	}
}