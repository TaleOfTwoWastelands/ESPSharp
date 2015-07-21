
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
	public partial class Message : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Content { get; set; }
		public SimpleSubrecord<String> Header { get; set; }
		public RecordReference Icon { get; set; }
		public SimpleSubrecord<Byte[]> Unused0 { get; set; }
		public SimpleSubrecord<Byte[]> Unused1 { get; set; }
		public SimpleSubrecord<Byte[]> Unused2 { get; set; }
		public SimpleSubrecord<Byte[]> Unused3 { get; set; }
		public SimpleSubrecord<Byte[]> Unused4 { get; set; }
		public SimpleSubrecord<Byte[]> Unused5 { get; set; }
		public SimpleSubrecord<Byte[]> Unused6 { get; set; }
		public SimpleSubrecord<Byte[]> Unused7 { get; set; }
		public SimpleSubrecord<Byte[]> Unused8 { get; set; }
		public SimpleSubrecord<Byte[]> Unused9 { get; set; }
		public SimpleSubrecord<MessageFlags> MessageFlags { get; set; }
		public SimpleSubrecord<UInt32> DisplayTime { get; set; }
		public List<MessageButton> Buttons { get; set; }

		public Message()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Content = new SimpleSubrecord<String>("DESC");
			Icon = new RecordReference("INAM");
			MessageFlags = new SimpleSubrecord<MessageFlags>("DNAM");
		}

		public Message(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Content, SimpleSubrecord<String> Header, RecordReference Icon, SimpleSubrecord<Byte[]> Unused0, SimpleSubrecord<Byte[]> Unused1, SimpleSubrecord<Byte[]> Unused2, SimpleSubrecord<Byte[]> Unused3, SimpleSubrecord<Byte[]> Unused4, SimpleSubrecord<Byte[]> Unused5, SimpleSubrecord<Byte[]> Unused6, SimpleSubrecord<Byte[]> Unused7, SimpleSubrecord<Byte[]> Unused8, SimpleSubrecord<Byte[]> Unused9, SimpleSubrecord<MessageFlags> MessageFlags, SimpleSubrecord<UInt32> DisplayTime, List<MessageButton> Buttons)
		{
			this.EditorID = EditorID;
			this.Content = Content;
			this.Icon = Icon;
			this.MessageFlags = MessageFlags;
		}

		public Message(Message copyObject)
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
					case "DESC":
						if (Content == null)
							Content = new SimpleSubrecord<String>();

						Content.ReadBinary(reader);
						break;
					case "FULL":
						if (Header == null)
							Header = new SimpleSubrecord<String>();

						Header.ReadBinary(reader);
						break;
					case "INAM":
						if (Icon == null)
							Icon = new RecordReference();

						Icon.ReadBinary(reader);
						break;
					case "NAM0":
						if (Unused0 == null)
							Unused0 = new SimpleSubrecord<Byte[]>();

						Unused0.ReadBinary(reader);
						break;
					case "NAM1":
						if (Unused1 == null)
							Unused1 = new SimpleSubrecord<Byte[]>();

						Unused1.ReadBinary(reader);
						break;
					case "NAM2":
						if (Unused2 == null)
							Unused2 = new SimpleSubrecord<Byte[]>();

						Unused2.ReadBinary(reader);
						break;
					case "NAM3":
						if (Unused3 == null)
							Unused3 = new SimpleSubrecord<Byte[]>();

						Unused3.ReadBinary(reader);
						break;
					case "NAM4":
						if (Unused4 == null)
							Unused4 = new SimpleSubrecord<Byte[]>();

						Unused4.ReadBinary(reader);
						break;
					case "NAM5":
						if (Unused5 == null)
							Unused5 = new SimpleSubrecord<Byte[]>();

						Unused5.ReadBinary(reader);
						break;
					case "NAM6":
						if (Unused6 == null)
							Unused6 = new SimpleSubrecord<Byte[]>();

						Unused6.ReadBinary(reader);
						break;
					case "NAM7":
						if (Unused7 == null)
							Unused7 = new SimpleSubrecord<Byte[]>();

						Unused7.ReadBinary(reader);
						break;
					case "NAM8":
						if (Unused8 == null)
							Unused8 = new SimpleSubrecord<Byte[]>();

						Unused8.ReadBinary(reader);
						break;
					case "NAM9":
						if (Unused9 == null)
							Unused9 = new SimpleSubrecord<Byte[]>();

						Unused9.ReadBinary(reader);
						break;
					case "DNAM":
						if (MessageFlags == null)
							MessageFlags = new SimpleSubrecord<MessageFlags>();

						MessageFlags.ReadBinary(reader);
						break;
					case "TNAM":
						if (DisplayTime == null)
							DisplayTime = new SimpleSubrecord<UInt32>();

						DisplayTime.ReadBinary(reader);
						break;
					case "ITXT":
						if (Buttons == null)
							Buttons = new List<MessageButton>();

						MessageButton tempITXT = new MessageButton();
						tempITXT.ReadBinary(reader);
						Buttons.Add(tempITXT);
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
			if (Content != null)
				Content.WriteBinary(writer);
			if (Header != null)
				Header.WriteBinary(writer);
			if (Icon != null)
				Icon.WriteBinary(writer);
			if (Unused0 != null)
				Unused0.WriteBinary(writer);
			if (Unused1 != null)
				Unused1.WriteBinary(writer);
			if (Unused2 != null)
				Unused2.WriteBinary(writer);
			if (Unused3 != null)
				Unused3.WriteBinary(writer);
			if (Unused4 != null)
				Unused4.WriteBinary(writer);
			if (Unused5 != null)
				Unused5.WriteBinary(writer);
			if (Unused6 != null)
				Unused6.WriteBinary(writer);
			if (Unused7 != null)
				Unused7.WriteBinary(writer);
			if (Unused8 != null)
				Unused8.WriteBinary(writer);
			if (Unused9 != null)
				Unused9.WriteBinary(writer);
			if (MessageFlags != null)
				MessageFlags.WriteBinary(writer);
			if (DisplayTime != null)
				DisplayTime.WriteBinary(writer);
			if (Buttons != null)
				foreach (var item in Buttons)
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
			if (Content != null)		
			{		
				ele.TryPathTo("Content", true, out subEle);
				Content.WriteXML(subEle, master);
			}
			if (Header != null)		
			{		
				ele.TryPathTo("Header", true, out subEle);
				Header.WriteXML(subEle, master);
			}
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
				Icon.WriteXML(subEle, master);
			}
			if (Unused0 != null)		
			{		
				ele.TryPathTo("Unused/Unused0", true, out subEle);
				Unused0.WriteXML(subEle, master);
			}
			if (Unused1 != null)		
			{		
				ele.TryPathTo("Unused/Unused1", true, out subEle);
				Unused1.WriteXML(subEle, master);
			}
			if (Unused2 != null)		
			{		
				ele.TryPathTo("Unused/Unused2", true, out subEle);
				Unused2.WriteXML(subEle, master);
			}
			if (Unused3 != null)		
			{		
				ele.TryPathTo("Unused/Unused3", true, out subEle);
				Unused3.WriteXML(subEle, master);
			}
			if (Unused4 != null)		
			{		
				ele.TryPathTo("Unused/Unused4", true, out subEle);
				Unused4.WriteXML(subEle, master);
			}
			if (Unused5 != null)		
			{		
				ele.TryPathTo("Unused/Unused5", true, out subEle);
				Unused5.WriteXML(subEle, master);
			}
			if (Unused6 != null)		
			{		
				ele.TryPathTo("Unused/Unused6", true, out subEle);
				Unused6.WriteXML(subEle, master);
			}
			if (Unused7 != null)		
			{		
				ele.TryPathTo("Unused/Unused7", true, out subEle);
				Unused7.WriteXML(subEle, master);
			}
			if (Unused8 != null)		
			{		
				ele.TryPathTo("Unused/Unused8", true, out subEle);
				Unused8.WriteXML(subEle, master);
			}
			if (Unused9 != null)		
			{		
				ele.TryPathTo("Unused/Unused9", true, out subEle);
				Unused9.WriteXML(subEle, master);
			}
			if (MessageFlags != null)		
			{		
				ele.TryPathTo("MessageFlags", true, out subEle);
				MessageFlags.WriteXML(subEle, master);
			}
			if (DisplayTime != null)		
			{		
				ele.TryPathTo("DisplayTime", true, out subEle);
				DisplayTime.WriteXML(subEle, master);
			}
			if (Buttons != null)		
			{		
				ele.TryPathTo("Buttons", true, out subEle);
				List<string> xmlNames = new List<string>{"Button"};
				int i = 0;
				foreach (var entry in Buttons)
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
			if (ele.TryPathTo("Content", false, out subEle))
			{
				if (Content == null)
					Content = new SimpleSubrecord<String>();
					
				Content.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Header", false, out subEle))
			{
				if (Header == null)
					Header = new SimpleSubrecord<String>();
					
				Header.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new RecordReference();
					
				Icon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused0", false, out subEle))
			{
				if (Unused0 == null)
					Unused0 = new SimpleSubrecord<Byte[]>();
					
				Unused0.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused1", false, out subEle))
			{
				if (Unused1 == null)
					Unused1 = new SimpleSubrecord<Byte[]>();
					
				Unused1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused2", false, out subEle))
			{
				if (Unused2 == null)
					Unused2 = new SimpleSubrecord<Byte[]>();
					
				Unused2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused3", false, out subEle))
			{
				if (Unused3 == null)
					Unused3 = new SimpleSubrecord<Byte[]>();
					
				Unused3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused4", false, out subEle))
			{
				if (Unused4 == null)
					Unused4 = new SimpleSubrecord<Byte[]>();
					
				Unused4.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused5", false, out subEle))
			{
				if (Unused5 == null)
					Unused5 = new SimpleSubrecord<Byte[]>();
					
				Unused5.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused6", false, out subEle))
			{
				if (Unused6 == null)
					Unused6 = new SimpleSubrecord<Byte[]>();
					
				Unused6.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused7", false, out subEle))
			{
				if (Unused7 == null)
					Unused7 = new SimpleSubrecord<Byte[]>();
					
				Unused7.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused8", false, out subEle))
			{
				if (Unused8 == null)
					Unused8 = new SimpleSubrecord<Byte[]>();
					
				Unused8.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unused/Unused9", false, out subEle))
			{
				if (Unused9 == null)
					Unused9 = new SimpleSubrecord<Byte[]>();
					
				Unused9.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MessageFlags", false, out subEle))
			{
				if (MessageFlags == null)
					MessageFlags = new SimpleSubrecord<MessageFlags>();
					
				MessageFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DisplayTime", false, out subEle))
			{
				if (DisplayTime == null)
					DisplayTime = new SimpleSubrecord<UInt32>();
					
				DisplayTime.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Buttons", false, out subEle))
			{
				if (Buttons == null)
					Buttons = new List<MessageButton>();
					
				foreach (XElement e in subEle.Elements())
				{
					MessageButton tempITXT = new MessageButton();
					tempITXT.ReadXML(e, master);
					Buttons.Add(tempITXT);
				}
			}
		}		

		public Message Clone()
		{
			return new Message(this);
		}

	}
}