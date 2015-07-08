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
	public partial class Casino : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public CasinoData Data { get; set; }
		public List<SimpleSubrecord<String>> Models { get; set; }
		public SimpleSubrecord<String> ModelSlotMachine { get; set; }
		public SimpleSubrecord<String> ModelBlackjackTable { get; set; }
		public SimpleSubrecord<String> ModelRouletteTable { get; set; }
		public List<SimpleSubrecord<String>> SlotReelTextures { get; set; }
		public List<SimpleSubrecord<String>> BlackjackTextures { get; set; }
	
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
					case "DATA":
						if (Data == null)
							Data = new CasinoData();

						Data.ReadBinary(reader);
						break;
					case "MODL":
						if (Models == null)
							Models = new List<SimpleSubrecord<String>>();

						SimpleSubrecord<String> tempMODL = new SimpleSubrecord<String>();
						tempMODL.ReadBinary(reader);
						Models.Add(tempMODL);
						break;
					case "MOD2":
						if (ModelSlotMachine == null)
							ModelSlotMachine = new SimpleSubrecord<String>();

						ModelSlotMachine.ReadBinary(reader);
						break;
					case "MOD3":
						if (ModelBlackjackTable == null)
							ModelBlackjackTable = new SimpleSubrecord<String>();

						ModelBlackjackTable.ReadBinary(reader);
						break;
					case "MOD4":
						if (ModelRouletteTable == null)
							ModelRouletteTable = new SimpleSubrecord<String>();

						ModelRouletteTable.ReadBinary(reader);
						break;
					case "ICON":
						if (SlotReelTextures == null)
							SlotReelTextures = new List<SimpleSubrecord<String>>();

						SimpleSubrecord<String> tempICON = new SimpleSubrecord<String>();
						tempICON.ReadBinary(reader);
						SlotReelTextures.Add(tempICON);
						break;
					case "ICO2":
						if (BlackjackTextures == null)
							BlackjackTextures = new List<SimpleSubrecord<String>>();

						SimpleSubrecord<String> tempICO2 = new SimpleSubrecord<String>();
						tempICO2.ReadBinary(reader);
						BlackjackTextures.Add(tempICO2);
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
			if (Data != null)
				Data.WriteBinary(writer);
			if (Models != null)
				foreach (var item in Models)
					item.WriteBinary(writer);
			if (ModelSlotMachine != null)
				ModelSlotMachine.WriteBinary(writer);
			if (ModelBlackjackTable != null)
				ModelBlackjackTable.WriteBinary(writer);
			if (ModelRouletteTable != null)
				ModelRouletteTable.WriteBinary(writer);
			if (SlotReelTextures != null)
				foreach (var item in SlotReelTextures)
					item.WriteBinary(writer);
			if (BlackjackTextures != null)
				foreach (var item in BlackjackTextures)
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
			if (Models != null)		
			{		
				ele.TryPathTo("Models", true, out subEle);
				List<string> xmlNames = new List<string>{"Chip1", "Chip5", "Chip10", "Chip25", "Chip100", "Chip500", "RouletteChip", "SlotMachine"};
				int i = 0;
				foreach (var entry in Models)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (ModelSlotMachine != null)		
			{		
				ele.TryPathTo("Model/SlotMachine", true, out subEle);
				ModelSlotMachine.WriteXML(subEle, master);
			}
			if (ModelBlackjackTable != null)		
			{		
				ele.TryPathTo("Model/BlackjackTable", true, out subEle);
				ModelBlackjackTable.WriteXML(subEle, master);
			}
			if (ModelRouletteTable != null)		
			{		
				ele.TryPathTo("Model/RouletteTable", true, out subEle);
				ModelRouletteTable.WriteXML(subEle, master);
			}
			if (SlotReelTextures != null)		
			{		
				ele.TryPathTo("SlotReelTextures", true, out subEle);
				List<string> xmlNames = new List<string>{"Symbol1", "Symbol2", "Symbol3", "Symbol4", "Symbol5", "Symbol6", "SymbolW"};
				int i = 0;
				foreach (var entry in SlotReelTextures)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (BlackjackTextures != null)		
			{		
				ele.TryPathTo("BlackjackTextures", true, out subEle);
				List<string> xmlNames = new List<string>{"Deck1", "Deck2", "Deck3", "Deck4"};
				int i = 0;
				foreach (var entry in BlackjackTextures)
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new CasinoData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Models", false, out subEle))
			{
				if (Models == null)
					Models = new List<SimpleSubrecord<String>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<String> tempMODL = new SimpleSubrecord<String>();
					tempMODL.ReadXML(e, master);
					Models.Add(tempMODL);
				}
			}
			if (ele.TryPathTo("Model/SlotMachine", false, out subEle))
			{
				if (ModelSlotMachine == null)
					ModelSlotMachine = new SimpleSubrecord<String>();
					
				ModelSlotMachine.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model/BlackjackTable", false, out subEle))
			{
				if (ModelBlackjackTable == null)
					ModelBlackjackTable = new SimpleSubrecord<String>();
					
				ModelBlackjackTable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model/RouletteTable", false, out subEle))
			{
				if (ModelRouletteTable == null)
					ModelRouletteTable = new SimpleSubrecord<String>();
					
				ModelRouletteTable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SlotReelTextures", false, out subEle))
			{
				if (SlotReelTextures == null)
					SlotReelTextures = new List<SimpleSubrecord<String>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<String> tempICON = new SimpleSubrecord<String>();
					tempICON.ReadXML(e, master);
					SlotReelTextures.Add(tempICON);
				}
			}
			if (ele.TryPathTo("BlackjackTextures", false, out subEle))
			{
				if (BlackjackTextures == null)
					BlackjackTextures = new List<SimpleSubrecord<String>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<String> tempICO2 = new SimpleSubrecord<String>();
					tempICO2.ReadXML(e, master);
					BlackjackTextures.Add(tempICO2);
				}
			}
		}

	}
}
