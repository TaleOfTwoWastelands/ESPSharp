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
	public partial class MagicEffect : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public Model Model { get; set; }
		public MagicEffectData Data { get; set; }

		public MagicEffect()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Description = new SimpleSubrecord<String>("DESC");
			Data = new MagicEffectData("DATA");
		}

		public MagicEffect(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, SimpleSubrecord<String> Description, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, Model Model, MagicEffectData Data)
		{
			this.EditorID = EditorID;
			this.Description = Description;
			this.Data = Data;
		}

		public MagicEffect(MagicEffect copyObject)
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
					case "DESC":
						if (Description == null)
							Description = new SimpleSubrecord<String>();

						Description.ReadBinary(reader);
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
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new MagicEffectData();

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
			if (Description != null)
				Description.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
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
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle, master);
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
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new MagicEffectData();
					
				Data.ReadXML(subEle, master);
			}
		}		

		public MagicEffect Clone()
		{
			return new MagicEffect(this);
		}

	}
}