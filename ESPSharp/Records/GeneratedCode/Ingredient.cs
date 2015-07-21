
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
	public partial class Ingredient : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public RecordReference Script { get; set; }
		public SimpleSubrecord<EquipmentType> EquipmentType { get; set; }
		public SimpleSubrecord<Single> Weight { get; set; }
		public IngredientData Data { get; set; }
		public List<Effect> Effects { get; set; }

		public Ingredient()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
			EquipmentType = new SimpleSubrecord<EquipmentType>("ETYP");
			Weight = new SimpleSubrecord<Single>("DATA");
			Data = new IngredientData("ENIT");
			Effects = new List<Effect>();
		}

		public Ingredient(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, RecordReference Script, SimpleSubrecord<EquipmentType> EquipmentType, SimpleSubrecord<Single> Weight, IngredientData Data, List<Effect> Effects)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
			this.EquipmentType = EquipmentType;
			this.Weight = Weight;
			this.Data = Data;
			this.Effects = Effects;
		}

		public Ingredient(Ingredient copyObject)
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
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "ETYP":
						if (EquipmentType == null)
							EquipmentType = new SimpleSubrecord<EquipmentType>();

						EquipmentType.ReadBinary(reader);
						break;
					case "DATA":
						if (Weight == null)
							Weight = new SimpleSubrecord<Single>();

						Weight.ReadBinary(reader);
						break;
					case "ENIT":
						if (Data == null)
							Data = new IngredientData();

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
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (EquipmentType != null)
				EquipmentType.WriteBinary(writer);
			if (Weight != null)
				Weight.WriteBinary(writer);
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
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (EquipmentType != null)		
			{		
				ele.TryPathTo("EquipmentType", true, out subEle);
				EquipmentType.WriteXML(subEle, master);
			}
			if (Weight != null)		
			{		
				ele.TryPathTo("Weight", true, out subEle);
				Weight.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EquipmentType", false, out subEle))
			{
				if (EquipmentType == null)
					EquipmentType = new SimpleSubrecord<EquipmentType>();
					
				EquipmentType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Weight", false, out subEle))
			{
				if (Weight == null)
					Weight = new SimpleSubrecord<Single>();
					
				Weight.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new IngredientData();
					
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

		public Ingredient Clone()
		{
			return new Ingredient(this);
		}

	}
}