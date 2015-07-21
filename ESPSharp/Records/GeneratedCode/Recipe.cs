
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
	public partial class Recipe : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public List<Condition> Conditions { get; set; }
		public RecipeData Data { get; set; }
		public List<RecipeIngredient> Ingredients { get; set; }
		public List<RecipeOutput> Outputs { get; set; }

		public Recipe()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public Recipe(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, List<Condition> Conditions, RecipeData Data, List<RecipeIngredient> Ingredients, List<RecipeOutput> Outputs)
		{
			this.EditorID = EditorID;
		}

		public Recipe(Recipe copyObject)
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
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "DATA":
						if (Data == null)
							Data = new RecipeData();

						Data.ReadBinary(reader);
						break;
					case "RCIL":
						if (Ingredients == null)
							Ingredients = new List<RecipeIngredient>();

						RecipeIngredient tempRCIL = new RecipeIngredient();
						tempRCIL.ReadBinary(reader);
						Ingredients.Add(tempRCIL);
						break;
					case "RCOD":
						if (Outputs == null)
							Outputs = new List<RecipeOutput>();

						RecipeOutput tempRCOD = new RecipeOutput();
						tempRCOD.ReadBinary(reader);
						Outputs.Add(tempRCOD);
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
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Ingredients != null)
				foreach (var item in Ingredients)
					item.WriteBinary(writer);
			if (Outputs != null)
				foreach (var item in Outputs)
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
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				List<string> xmlNames = new List<string>{"Condition"};
				int i = 0;
				foreach (var entry in Conditions)
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
			if (Ingredients != null)		
			{		
				ele.TryPathTo("Ingredients", true, out subEle);
				List<string> xmlNames = new List<string>{"Ingredient"};
				int i = 0;
				foreach (var entry in Ingredients)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Outputs != null)		
			{		
				ele.TryPathTo("Outputs", true, out subEle);
				List<string> xmlNames = new List<string>{"Output"};
				int i = 0;
				foreach (var entry in Outputs)
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
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition tempCTDA = new Condition();
					tempCTDA.ReadXML(e, master);
					Conditions.Add(tempCTDA);
				}
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new RecipeData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Ingredients", false, out subEle))
			{
				if (Ingredients == null)
					Ingredients = new List<RecipeIngredient>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecipeIngredient tempRCIL = new RecipeIngredient();
					tempRCIL.ReadXML(e, master);
					Ingredients.Add(tempRCIL);
				}
			}
			if (ele.TryPathTo("Outputs", false, out subEle))
			{
				if (Outputs == null)
					Outputs = new List<RecipeOutput>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecipeOutput tempRCOD = new RecipeOutput();
					tempRCOD.ReadXML(e, master);
					Outputs.Add(tempRCOD);
				}
			}
		}		

		public Recipe Clone()
		{
			return new Recipe(this);
		}

	}
}