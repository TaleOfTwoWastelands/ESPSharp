
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
	public partial class ClassData : Subrecord, ICloneable, IComparable<ClassData>, IEquatable<ClassData>  
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

		public ClassData(string Tag = null)
			:base(Tag)
		{
			TagSkill1 = new ActorValues();
			TagSkill2 = new ActorValues();
			TagSkill3 = new ActorValues();
			TagSkill4 = new ActorValues();
			ClassDataFlags = new ClassDataFlag();
			Services = new ServicesFlag();
			TrainingSkill = new Skills();
			MaxTrainingLevel = new Byte();
			Unused = new byte[2];
		}

		public ClassData(ActorValues TagSkill1, ActorValues TagSkill2, ActorValues TagSkill3, ActorValues TagSkill4, ClassDataFlag ClassDataFlags, ServicesFlag Services, Skills TrainingSkill, Byte MaxTrainingLevel, Byte[] Unused)
		{
			this.TagSkill1 = TagSkill1;
			this.TagSkill2 = TagSkill2;
			this.TagSkill3 = TagSkill3;
			this.TagSkill4 = TagSkill4;
			this.ClassDataFlags = ClassDataFlags;
			this.Services = Services;
			this.TrainingSkill = TrainingSkill;
			this.MaxTrainingLevel = MaxTrainingLevel;
			this.Unused = Unused;
		}

		public ClassData(ClassData copyObject)
		{
			TagSkill1 = copyObject.TagSkill1;
			TagSkill2 = copyObject.TagSkill2;
			TagSkill3 = copyObject.TagSkill3;
			TagSkill4 = copyObject.TagSkill4;
			ClassDataFlags = copyObject.ClassDataFlags;
			Services = copyObject.Services;
			TrainingSkill = copyObject.TrainingSkill;
			MaxTrainingLevel = copyObject.MaxTrainingLevel;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
		}
	
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
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
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

			WriteUnusedXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("TagSkills/Skill1", false, out subEle))
				TagSkill1 = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("TagSkills/Skill2", false, out subEle))
				TagSkill2 = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("TagSkills/Skill3", false, out subEle))
				TagSkill3 = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("TagSkills/Skill4", false, out subEle))
				TagSkill4 = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("Flags", false, out subEle))
				ClassDataFlags = subEle.ToEnum<ClassDataFlag>();

			if (ele.TryPathTo("Services", false, out subEle))
				Services = subEle.ToEnum<ServicesFlag>();

			if (ele.TryPathTo("Training/Skill", false, out subEle))
				TrainingSkill = subEle.ToEnum<Skills>();

			if (ele.TryPathTo("Training/MaxLevel", false, out subEle))
				MaxTrainingLevel = subEle.ToByte();

			ReadUnusedXML(ele, master);
		}

		public override object Clone()
		{
			return new ClassData(this);
		}

        public int CompareTo(ClassData other)
        {
			return TagSkill1.CompareTo(other.TagSkill1);
        }

        public static bool operator >(ClassData objA, ClassData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ClassData objA, ClassData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ClassData objA, ClassData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ClassData objA, ClassData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ClassData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return TagSkill1 == other.TagSkill1 &&
				TagSkill2 == other.TagSkill2 &&
				TagSkill3 == other.TagSkill3 &&
				TagSkill4 == other.TagSkill4 &&
				ClassDataFlags == other.ClassDataFlags &&
				Services == other.Services &&
				TrainingSkill == other.TrainingSkill &&
				MaxTrainingLevel == other.MaxTrainingLevel &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ClassData other = obj as ClassData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return TagSkill1.GetHashCode();
        }

        public static bool operator ==(ClassData objA, ClassData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(ClassData objA, ClassData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}