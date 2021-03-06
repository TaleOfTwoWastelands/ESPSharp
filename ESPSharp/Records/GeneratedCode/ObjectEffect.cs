﻿
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
	public partial class ObjectEffect : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public EnchantData Data { get; set; }
		public List<Effect> Effects { get; set; }

		public ObjectEffect()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Data = new EnchantData("ENIT");
		}

		public ObjectEffect(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, EnchantData Data, List<Effect> Effects)
		{
			this.EditorID = EditorID;
			this.Data = Data;
		}

		public ObjectEffect(ObjectEffect copyObject)
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
					case "ENIT":
						if (Data == null)
							Data = new EnchantData();

						Data.ReadBinary(reader);
						break;
					case "EFID":
						if (Effects == null)
							Effects = new List<Effect>();

						Effect tempEFID = new Effect();
						tempEFID.ReadBinary(reader);
						Effects.Add(tempEFID);
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
			if (Effects != null)
				foreach (var item in Effects)
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
			if (Effects != null)		
			{		
				ele.TryPathTo("Effects", true, out subEle);
				List<string> xmlNames = new List<string>{"Effect"};
				int i = 0;
				foreach (var entry in Effects)
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
					Data = new EnchantData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Effects", false, out subEle))
			{
				if (Effects == null)
					Effects = new List<Effect>();
					
				foreach (XElement e in subEle.Elements())
				{
					Effect tempEFID = new Effect();
					tempEFID.ReadXML(e, master);
					Effects.Add(tempEFID);
				}
			}
		}		

		public ObjectEffect Clone()
		{
			return new ObjectEffect(this);
		}

	}
}