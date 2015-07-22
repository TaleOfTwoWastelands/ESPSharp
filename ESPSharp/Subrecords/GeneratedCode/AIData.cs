
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
	public partial class AIData : Subrecord, ICloneable, IComparable<AIData>, IEquatable<AIData>  
	{
		public AggressionType Aggression { get; set; }
		public ConfidenceType Confidence { get; set; }
		public Byte EnergyLevel { get; set; }
		public Byte Responsibility { get; set; }
		public MoodType Mood { get; set; }
		public Byte[] Unused { get; set; }
		public ServicesFlag Services { get; set; }
		public Skills Teaches { get; set; }
		public Byte MaxTrainingLevel { get; set; }
		public AssistanceType Assistance { get; set; }
		public AggroRadiusBehaviorFlags AggroRadiusBehavior { get; set; }
		public Int32 AggroRadius { get; set; }

		public AIData(string Tag = null)
			:base(Tag)
		{
			Aggression = new AggressionType();
			Confidence = new ConfidenceType();
			EnergyLevel = new Byte();
			Responsibility = new Byte();
			Mood = new MoodType();
			Unused = new byte[3];
			Services = new ServicesFlag();
			Teaches = new Skills();
			MaxTrainingLevel = new Byte();
			Assistance = new AssistanceType();
			AggroRadiusBehavior = new AggroRadiusBehaviorFlags();
			AggroRadius = new Int32();
		}

		public AIData(AggressionType Aggression, ConfidenceType Confidence, Byte EnergyLevel, Byte Responsibility, MoodType Mood, Byte[] Unused, ServicesFlag Services, Skills Teaches, Byte MaxTrainingLevel, AssistanceType Assistance, AggroRadiusBehaviorFlags AggroRadiusBehavior, Int32 AggroRadius)
		{
			this.Aggression = Aggression;
			this.Confidence = Confidence;
			this.EnergyLevel = EnergyLevel;
			this.Responsibility = Responsibility;
			this.Mood = Mood;
			this.Unused = Unused;
			this.Services = Services;
			this.Teaches = Teaches;
			this.MaxTrainingLevel = MaxTrainingLevel;
			this.Assistance = Assistance;
			this.AggroRadiusBehavior = AggroRadiusBehavior;
			this.AggroRadius = AggroRadius;
		}

		public AIData(AIData copyObject)
		{
			Aggression = copyObject.Aggression;
			Confidence = copyObject.Confidence;
			EnergyLevel = copyObject.EnergyLevel;
			Responsibility = copyObject.Responsibility;
			Mood = copyObject.Mood;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			Services = copyObject.Services;
			Teaches = copyObject.Teaches;
			MaxTrainingLevel = copyObject.MaxTrainingLevel;
			Assistance = copyObject.Assistance;
			AggroRadiusBehavior = copyObject.AggroRadiusBehavior;
			AggroRadius = copyObject.AggroRadius;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Aggression = subReader.ReadEnum<AggressionType>();
					Confidence = subReader.ReadEnum<ConfidenceType>();
					EnergyLevel = subReader.ReadByte();
					Responsibility = subReader.ReadByte();
					Mood = subReader.ReadEnum<MoodType>();
					Unused = subReader.ReadBytes(3);
					Services = subReader.ReadEnum<ServicesFlag>();
					Teaches = subReader.ReadEnum<Skills>();
					MaxTrainingLevel = subReader.ReadByte();
					Assistance = subReader.ReadEnum<AssistanceType>();
					AggroRadiusBehavior = subReader.ReadEnum<AggroRadiusBehaviorFlags>();
					AggroRadius = subReader.ReadInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Aggression);
			writer.Write((Byte)Confidence);
			writer.Write(EnergyLevel);
			writer.Write(Responsibility);
			writer.Write((Byte)Mood);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
			writer.Write((UInt32)Services);
			writer.Write((SByte)Teaches);
			writer.Write(MaxTrainingLevel);
			writer.Write((Byte)Assistance);
			writer.Write((Byte)AggroRadiusBehavior);
			writer.Write(AggroRadius);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Aggression", true, out subEle);
			subEle.Value = Aggression.ToString();

			ele.TryPathTo("Confidence", true, out subEle);
			subEle.Value = Confidence.ToString();

			ele.TryPathTo("EnergyLevel", true, out subEle);
			subEle.Value = EnergyLevel.ToString();

			ele.TryPathTo("Responsibility", true, out subEle);
			subEle.Value = Responsibility.ToString();

			ele.TryPathTo("Mood", true, out subEle);
			subEle.Value = Mood.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("Services", true, out subEle);
			subEle.Value = Services.ToString();

			ele.TryPathTo("Teaches", true, out subEle);
			subEle.Value = Teaches.ToString();

			ele.TryPathTo("MaxTrainingLevel", true, out subEle);
			subEle.Value = MaxTrainingLevel.ToString();

			ele.TryPathTo("Assistance", true, out subEle);
			subEle.Value = Assistance.ToString();

			ele.TryPathTo("AggroRadiusBehavior", true, out subEle);
			subEle.Value = AggroRadiusBehavior.ToString();

			ele.TryPathTo("AggroRadius", true, out subEle);
			subEle.Value = AggroRadius.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Aggression", false, out subEle))
				Aggression = subEle.ToEnum<AggressionType>();

			if (ele.TryPathTo("Confidence", false, out subEle))
				Confidence = subEle.ToEnum<ConfidenceType>();

			if (ele.TryPathTo("EnergyLevel", false, out subEle))
				EnergyLevel = subEle.ToByte();

			if (ele.TryPathTo("Responsibility", false, out subEle))
				Responsibility = subEle.ToByte();

			if (ele.TryPathTo("Mood", false, out subEle))
				Mood = subEle.ToEnum<MoodType>();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("Services", false, out subEle))
				Services = subEle.ToEnum<ServicesFlag>();

			if (ele.TryPathTo("Teaches", false, out subEle))
				Teaches = subEle.ToEnum<Skills>();

			if (ele.TryPathTo("MaxTrainingLevel", false, out subEle))
				MaxTrainingLevel = subEle.ToByte();

			if (ele.TryPathTo("Assistance", false, out subEle))
				Assistance = subEle.ToEnum<AssistanceType>();

			if (ele.TryPathTo("AggroRadiusBehavior", false, out subEle))
				AggroRadiusBehavior = subEle.ToEnum<AggroRadiusBehaviorFlags>();

			if (ele.TryPathTo("AggroRadius", false, out subEle))
				AggroRadius = subEle.ToInt32();
		}

		public override object Clone()
		{
			return new AIData(this);
		}

        public int CompareTo(AIData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(AIData objA, AIData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AIData objA, AIData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AIData objA, AIData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AIData objA, AIData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(AIData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Aggression == other.Aggression &&
				Confidence == other.Confidence &&
				EnergyLevel == other.EnergyLevel &&
				Responsibility == other.Responsibility &&
				Mood == other.Mood &&
				Unused.SequenceEqual(other.Unused) &&
				Services == other.Services &&
				Teaches == other.Teaches &&
				MaxTrainingLevel == other.MaxTrainingLevel &&
				Assistance == other.Assistance &&
				AggroRadiusBehavior == other.AggroRadiusBehavior &&
				AggroRadius == other.AggroRadius;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AIData other = obj as AIData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Aggression.GetHashCode();
        }

        public static bool operator ==(AIData objA, AIData objB)
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

        public static bool operator !=(AIData objA, AIData objB)
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