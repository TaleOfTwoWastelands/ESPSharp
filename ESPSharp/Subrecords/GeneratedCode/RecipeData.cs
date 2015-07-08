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

namespace ESPSharp.Subrecords
{
	public partial class RecipeData : Subrecord, ICloneable<RecipeData>, IReferenceContainer
	{
		public ActorValues Skill { get; set; }
		public UInt32 Level { get; set; }
		public FormID Category { get; set; }
		public FormID SubCategory { get; set; }

		public RecipeData()
		{
			Skill = new ActorValues();
			Level = new UInt32();
			Category = new FormID();
			SubCategory = new FormID();
		}

		public RecipeData(ActorValues Skill, UInt32 Level, FormID Category, FormID SubCategory)
		{
			this.Skill = Skill;
			this.Level = Level;
			this.Category = Category;
			this.SubCategory = SubCategory;
		}

		public RecipeData(RecipeData copyObject)
		{
			Skill = copyObject.Skill;
			Level = copyObject.Level;
			Category = copyObject.Category.Clone();
			SubCategory = copyObject.SubCategory.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Skill = subReader.ReadEnum<ActorValues>();
					Level = subReader.ReadUInt32();
					Category.ReadBinary(subReader);
					SubCategory.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Int32)Skill);
			writer.Write(Level);			
			Category.WriteBinary(writer);
			SubCategory.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Skill", true, out subEle);
			subEle.Value = Skill.ToString();

			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			ele.TryPathTo("Category", true, out subEle);
			Category.WriteXML(subEle, master);

			ele.TryPathTo("SubCategory", true, out subEle);
			SubCategory.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Skill", false, out subEle))
			{
				Skill = subEle.ToEnum<ActorValues>();
			}

			if (ele.TryPathTo("Level", false, out subEle))
			{
				Level = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Category", false, out subEle))
			{
				Category.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("SubCategory", false, out subEle))
			{
				SubCategory.ReadXML(subEle, master);
			}
		}

		public RecipeData Clone()
		{
			return new RecipeData(this);
		}

	}
}
