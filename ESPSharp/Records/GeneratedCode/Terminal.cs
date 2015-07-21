
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
	public partial class Terminal : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public RecordReference Script { get; set; }
		public Destructable Destructable { get; set; }
		public SimpleSubrecord<String> WelcomeText { get; set; }
		public RecordReference LoopingSound { get; set; }
		public RecordReference Password { get; set; }
		public TerminalData Data { get; set; }
		public List<TerminalMenu> Selections { get; set; }

		public Terminal()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			WelcomeText = new SimpleSubrecord<String>("DESC");
			Data = new TerminalData("DNAM");
		}

		public Terminal(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, RecordReference Script, Destructable Destructable, SimpleSubrecord<String> WelcomeText, RecordReference LoopingSound, RecordReference Password, TerminalData Data, List<TerminalMenu> Selections)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.WelcomeText = WelcomeText;
			this.Data = Data;
		}

		public Terminal(Terminal copyObject)
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
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "DESC":
						if (WelcomeText == null)
							WelcomeText = new SimpleSubrecord<String>();

						WelcomeText.ReadBinary(reader);
						break;
					case "SNAM":
						if (LoopingSound == null)
							LoopingSound = new RecordReference();

						LoopingSound.ReadBinary(reader);
						break;
					case "PNAM":
						if (Password == null)
							Password = new RecordReference();

						Password.ReadBinary(reader);
						break;
					case "DNAM":
						if (Data == null)
							Data = new TerminalData();

						Data.ReadBinary(reader);
						break;
					case "ITXT":
						if (Selections == null)
							Selections = new List<TerminalMenu>();

						TerminalMenu tempITXT = new TerminalMenu();
						tempITXT.ReadBinary(reader);
						Selections.Add(tempITXT);
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
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (WelcomeText != null)
				WelcomeText.WriteBinary(writer);
			if (LoopingSound != null)
				LoopingSound.WriteBinary(writer);
			if (Password != null)
				Password.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Selections != null)
				foreach (var item in Selections)
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
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (WelcomeText != null)		
			{		
				ele.TryPathTo("WelcomeText", true, out subEle);
				WelcomeText.WriteXML(subEle, master);
			}
			if (LoopingSound != null)		
			{		
				ele.TryPathTo("LoopingSound", true, out subEle);
				LoopingSound.WriteXML(subEle, master);
			}
			if (Password != null)		
			{		
				ele.TryPathTo("Password", true, out subEle);
				Password.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Selections != null)		
			{		
				ele.TryPathTo("Selections", true, out subEle);
				List<string> xmlNames = new List<string>{"Selection"};
				int i = 0;
				foreach (var entry in Selections)
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
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WelcomeText", false, out subEle))
			{
				if (WelcomeText == null)
					WelcomeText = new SimpleSubrecord<String>();
					
				WelcomeText.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LoopingSound", false, out subEle))
			{
				if (LoopingSound == null)
					LoopingSound = new RecordReference();
					
				LoopingSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Password", false, out subEle))
			{
				if (Password == null)
					Password = new RecordReference();
					
				Password.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new TerminalData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Selections", false, out subEle))
			{
				if (Selections == null)
					Selections = new List<TerminalMenu>();
					
				foreach (XElement e in subEle.Elements())
				{
					TerminalMenu tempITXT = new TerminalMenu();
					tempITXT.ReadXML(e, master);
					Selections.Add(tempITXT);
				}
			}
		}		

		public Terminal Clone()
		{
			return new Terminal(this);
		}

	}
}