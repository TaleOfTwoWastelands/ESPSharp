
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
	public partial class PerkQuestStageData : Subrecord, ICloneable, IComparable<PerkQuestStageData>, IEquatable<PerkQuestStageData>  
	{
		public FormID Quest { get; set; }
		public UInt32 QuestStage { get; set; }

		public PerkQuestStageData(string Tag = null)
			:base(Tag)
		{
			Quest = new FormID();
			QuestStage = new UInt32();
		}

		public PerkQuestStageData(FormID Quest, UInt32 QuestStage)
		{
			this.Quest = Quest;
			this.QuestStage = QuestStage;
		}

		public PerkQuestStageData(PerkQuestStageData copyObject)
		{
			if (copyObject.Quest != null)
				Quest = (FormID)copyObject.Quest.Clone();
			QuestStage = copyObject.QuestStage;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Quest.ReadBinary(subReader);
					QuestStage = subReader.ReadUInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Quest.WriteBinary(writer);
			writer.Write(QuestStage);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Quest", true, out subEle);
			Quest.WriteXML(subEle, master);

			ele.TryPathTo("QuestStage", true, out subEle);
			subEle.Value = QuestStage.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Quest", false, out subEle))
				Quest.ReadXML(subEle, master);

			if (ele.TryPathTo("QuestStage", false, out subEle))
				QuestStage = subEle.ToUInt32();
		}

		public override object Clone()
		{
			return new PerkQuestStageData(this);
		}

        public int CompareTo(PerkQuestStageData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(PerkQuestStageData objA, PerkQuestStageData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PerkQuestStageData objA, PerkQuestStageData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PerkQuestStageData objA, PerkQuestStageData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PerkQuestStageData objA, PerkQuestStageData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PerkQuestStageData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Quest == other.Quest &&
				QuestStage == other.QuestStage;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PerkQuestStageData other = obj as PerkQuestStageData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Quest.GetHashCode();
        }

        public static bool operator ==(PerkQuestStageData objA, PerkQuestStageData objB)
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

        public static bool operator !=(PerkQuestStageData objA, PerkQuestStageData objB)
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
	}
}