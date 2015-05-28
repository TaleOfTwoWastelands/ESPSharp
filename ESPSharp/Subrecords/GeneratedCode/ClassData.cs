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

namespace ESPSharp.Subrecords
{
	public partial class ClassData : Subrecord
	{
		public ActorValues TagSkill1 { get; set; }
		public ActorValues TagSkill2 { get; set; }
		public ActorValues TagSkill3 { get; set; }
		public ActorValues TagSkill4 { get; set; }
		public ClassDataFlag ClassDataFlags { get; set; }
		public ServicesFlag Services { get; set; }
		public Skills TrainingSkill { get; set; }
		public Byte MaxTrainingLevel { get; set; }
		public Byte[] Unused { get; set; }
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					TagSkill1 = subReader.ReadEnum<ActorValues>();
					TagSkill2 = subReader.ReadEnum<ActorValues>();
					TagSkill3 = subReader.ReadEnum<ActorValues>();
					TagSkill4 = subReader.ReadEnum<ActorValues>();
					ClassDataFlags = subReader.ReadEnum<ClassDataFlag>();
					Services = subReader.ReadEnum<ServicesFlag>();
					TrainingSkill = subReader.ReadEnum<Skills>();
					MaxTrainingLevel = subReader.ReadByte();
					Unused = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Int32)TagSkill1);
			writer.Write((Int32)TagSkill2);
			writer.Write((Int32)TagSkill3);
			writer.Write((Int32)TagSkill4);
			writer.Write((UInt32)ClassDataFlags);
			writer.Write((UInt32)Services);
			writer.Write((SByte)TrainingSkill);
			writer.Write(MaxTrainingLevel);
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("TagSkills/Skill1", true, out subEle);
			subEle.Value = TagSkill1.ToString();

			ele.TryPathTo("TagSkills/Skill2", true, out subEle);
			subEle.Value = TagSkill2.ToString();

			ele.TryPathTo("TagSkills/Skill3", true, out subEle);
			subEle.Value = TagSkill3.ToString();

			ele.TryPathTo("TagSkills/Skill4", true, out subEle);
			subEle.Value = TagSkill4.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = ClassDataFlags.ToString();

			ele.TryPathTo("Services", true, out subEle);
			subEle.Value = Services.ToString();

			ele.TryPathTo("Training/Skill", true, out subEle);
			subEle.Value = TrainingSkill.ToString();

			ele.TryPathTo("Training/MaxLevel", true, out subEle);
			subEle.Value = MaxTrainingLevel.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("TagSkills/Skill1", false, out subEle);
			TagSkill1 = subEle.ToEnum<ActorValues>();

			ele.TryPathTo("TagSkills/Skill2", false, out subEle);
			TagSkill2 = subEle.ToEnum<ActorValues>();

			ele.TryPathTo("TagSkills/Skill3", false, out subEle);
			TagSkill3 = subEle.ToEnum<ActorValues>();

			ele.TryPathTo("TagSkills/Skill4", false, out subEle);
			TagSkill4 = subEle.ToEnum<ActorValues>();

			ele.TryPathTo("Flags", false, out subEle);
			ClassDataFlags = subEle.ToEnum<ClassDataFlag>();

			ele.TryPathTo("Services", false, out subEle);
			Services = subEle.ToEnum<ServicesFlag>();

			ele.TryPathTo("Training/Skill", false, out subEle);
			TrainingSkill = subEle.ToEnum<Skills>();

			ele.TryPathTo("Training/MaxLevel", false, out subEle);
			MaxTrainingLevel = subEle.ToByte();

			ele.TryPathTo("Unused", false, out subEle);
			Unused = subEle.ToBytes();
		}
	}
}
