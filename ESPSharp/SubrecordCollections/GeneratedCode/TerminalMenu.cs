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
	public partial class TerminalMenu : SubrecordCollection, ICloneable<TerminalMenu>, IReferenceContainer
	{
		public SimpleSubrecord<String> ItemText { get; set; }
		public SimpleSubrecord<String> ResultText { get; set; }
		public SimpleSubrecord<TerminalMenuFlags> Flags { get; set; }
		public RecordReference DisplayNote { get; set; }
		public RecordReference SubMenu { get; set; }
		public EmbeddedScript Script { get; set; }
		public List<Condition> Conditions { get; set; }

		public TerminalMenu()
		{
			ItemText = new SimpleSubrecord<String>();
			ResultText = new SimpleSubrecord<String>();
			Flags = new SimpleSubrecord<TerminalMenuFlags>();
		}

		public TerminalMenu(SimpleSubrecord<String> ItemText, SimpleSubrecord<String> ResultText, SimpleSubrecord<TerminalMenuFlags> Flags, RecordReference DisplayNote, RecordReference SubMenu, EmbeddedScript Script, List<Condition> Conditions)
		{
			this.ItemText = ItemText;
			this.ResultText = ResultText;
			this.Flags = Flags;
			this.DisplayNote = DisplayNote;
			this.SubMenu = SubMenu;
			this.Script = Script;
			this.Conditions = Conditions;
		}

		public TerminalMenu(TerminalMenu copyObject)
		{
			ItemText = copyObject.ItemText.Clone();
			ResultText = copyObject.ResultText.Clone();
			Flags = copyObject.Flags.Clone();
			DisplayNote = copyObject.DisplayNote.Clone();
			SubMenu = copyObject.SubMenu.Clone();
			Script = copyObject.Script.Clone();
			Conditions = new List<Condition>();
			foreach (var item in copyObject.Conditions)
			{
				Conditions.Add(item.Clone());
			}
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "ITXT":
						if (readTags.Contains("ITXT"))
							return;
						ItemText.ReadBinary(reader);
						break;
					case "RNAM":
						if (readTags.Contains("RNAM"))
							return;
						ResultText.ReadBinary(reader);
						break;
					case "ANAM":
						if (readTags.Contains("ANAM"))
							return;
						Flags.ReadBinary(reader);
						break;
					case "INAM":
						if (readTags.Contains("INAM"))
							return;
						if (DisplayNote == null)
							DisplayNote = new RecordReference();

						DisplayNote.ReadBinary(reader);
						break;
					case "TNAM":
						if (readTags.Contains("TNAM"))
							return;
						if (SubMenu == null)
							SubMenu = new RecordReference();

						SubMenu.ReadBinary(reader);
						break;
					case "SCHR":
						if (readTags.Contains("SCHR"))
							return;
						if (Script == null)
							Script = new EmbeddedScript();

						Script.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (ItemText != null)
				ItemText.WriteBinary(writer);
			if (ResultText != null)
				ResultText.WriteBinary(writer);
			if (Flags != null)
				Flags.WriteBinary(writer);
			if (DisplayNote != null)
				DisplayNote.WriteBinary(writer);
			if (SubMenu != null)
				SubMenu.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ItemText != null)		
			{		
				ele.TryPathTo("ItemText", true, out subEle);
				ItemText.WriteXML(subEle, master);
			}
			if (ResultText != null)		
			{		
				ele.TryPathTo("ResultText", true, out subEle);
				ResultText.WriteXML(subEle, master);
			}
			if (Flags != null)		
			{		
				ele.TryPathTo("Flags", true, out subEle);
				Flags.WriteXML(subEle, master);
			}
			if (DisplayNote != null)		
			{		
				ele.TryPathTo("DisplayNote", true, out subEle);
				DisplayNote.WriteXML(subEle, master);
			}
			if (SubMenu != null)		
			{		
				ele.TryPathTo("SubMenu", true, out subEle);
				SubMenu.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				foreach (var entry in Conditions)
				{
					XElement newEle = new XElement("Condition");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ItemText", false, out subEle))
			{
				if (ItemText == null)
					ItemText = new SimpleSubrecord<String>();
					
				ItemText.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ResultText", false, out subEle))
			{
				if (ResultText == null)
					ResultText = new SimpleSubrecord<String>();
					
				ResultText.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Flags", false, out subEle))
			{
				if (Flags == null)
					Flags = new SimpleSubrecord<TerminalMenuFlags>();
					
				Flags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DisplayNote", false, out subEle))
			{
				if (DisplayNote == null)
					DisplayNote = new RecordReference();
					
				DisplayNote.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SubMenu", false, out subEle))
			{
				if (SubMenu == null)
					SubMenu = new RecordReference();
					
				SubMenu.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new EmbeddedScript();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition temp = new Condition();
					temp.ReadXML(e, master);
					Conditions.Add(temp);
				}
			}
		}

		public TerminalMenu Clone()
		{
			return new TerminalMenu(this);
		}

	}
}
