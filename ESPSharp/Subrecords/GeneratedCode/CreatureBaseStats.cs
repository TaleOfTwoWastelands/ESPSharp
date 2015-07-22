
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
	public partial class CreatureBaseStats : Subrecord, ICloneable, IComparable<CreatureBaseStats>, IEquatable<CreatureBaseStats>  
	{
		public CreatureFlags Flags { get; set; }
		public UInt16 Fatigue { get; set; }
		public UInt16 BarterGold { get; set; }
		public Int16 Level { get; set; }
		public UInt16 CalcMin { get; set; }
		public UInt16 CalcMax { get; set; }
		public UInt16 SpeedMultiplier { get; set; }
		public Single Karma { get; set; }
		public Int16 DispositionBase { get; set; }
		public ActorTemplateFlags TemplateFlags { get; set; }

		public CreatureBaseStats(string Tag = null)
			:base(Tag)
		{
			Flags = new CreatureFlags();
			Fatigue = new UInt16();
			BarterGold = new UInt16();
			Level = new Int16();
			CalcMin = new UInt16();
			CalcMax = new UInt16();
			SpeedMultiplier = new UInt16();
			Karma = new Single();
			DispositionBase = new Int16();
			TemplateFlags = new ActorTemplateFlags();
		}

		public CreatureBaseStats(CreatureFlags Flags, UInt16 Fatigue, UInt16 BarterGold, Int16 Level, UInt16 CalcMin, UInt16 CalcMax, UInt16 SpeedMultiplier, Single Karma, Int16 DispositionBase, ActorTemplateFlags TemplateFlags)
		{
			this.Flags = Flags;
			this.Fatigue = Fatigue;
			this.BarterGold = BarterGold;
			this.Level = Level;
			this.CalcMin = CalcMin;
			this.CalcMax = CalcMax;
			this.SpeedMultiplier = SpeedMultiplier;
			this.Karma = Karma;
			this.DispositionBase = DispositionBase;
			this.TemplateFlags = TemplateFlags;
		}

		public CreatureBaseStats(CreatureBaseStats copyObject)
		{
			Flags = copyObject.Flags;
			Fatigue = copyObject.Fatigue;
			BarterGold = copyObject.BarterGold;
			Level = copyObject.Level;
			CalcMin = copyObject.CalcMin;
			CalcMax = copyObject.CalcMax;
			SpeedMultiplier = copyObject.SpeedMultiplier;
			Karma = copyObject.Karma;
			DispositionBase = copyObject.DispositionBase;
			TemplateFlags = copyObject.TemplateFlags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<CreatureFlags>();
					Fatigue = subReader.ReadUInt16();
					BarterGold = subReader.ReadUInt16();
					Level = subReader.ReadInt16();
					CalcMin = subReader.ReadUInt16();
					CalcMax = subReader.ReadUInt16();
					SpeedMultiplier = subReader.ReadUInt16();
					Karma = subReader.ReadSingle();
					DispositionBase = subReader.ReadInt16();
					TemplateFlags = subReader.ReadEnum<ActorTemplateFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Flags);
			writer.Write(Fatigue);
			writer.Write(BarterGold);
			writer.Write(Level);
			writer.Write(CalcMin);
			writer.Write(CalcMax);
			writer.Write(SpeedMultiplier);
			writer.Write(Karma);
			writer.Write(DispositionBase);
			writer.Write((UInt16)TemplateFlags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Fatigue", true, out subEle);
			subEle.Value = Fatigue.ToString();

			ele.TryPathTo("BarterGold", true, out subEle);
			subEle.Value = BarterGold.ToString();

			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			ele.TryPathTo("CalcMin", true, out subEle);
			subEle.Value = CalcMin.ToString();

			ele.TryPathTo("CalcMax", true, out subEle);
			subEle.Value = CalcMax.ToString();

			ele.TryPathTo("SpeedMultiplier", true, out subEle);
			subEle.Value = SpeedMultiplier.ToString();

			ele.TryPathTo("Karma", true, out subEle);
			subEle.Value = Karma.ToString("G15");

			ele.TryPathTo("DispositionBase", true, out subEle);
			subEle.Value = DispositionBase.ToString();

			ele.TryPathTo("TemplateFlags", true, out subEle);
			subEle.Value = TemplateFlags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<CreatureFlags>();

			if (ele.TryPathTo("Fatigue", false, out subEle))
				Fatigue = subEle.ToUInt16();

			if (ele.TryPathTo("BarterGold", false, out subEle))
				BarterGold = subEle.ToUInt16();

			if (ele.TryPathTo("Level", false, out subEle))
				Level = subEle.ToInt16();

			if (ele.TryPathTo("CalcMin", false, out subEle))
				CalcMin = subEle.ToUInt16();

			if (ele.TryPathTo("CalcMax", false, out subEle))
				CalcMax = subEle.ToUInt16();

			if (ele.TryPathTo("SpeedMultiplier", false, out subEle))
				SpeedMultiplier = subEle.ToUInt16();

			if (ele.TryPathTo("Karma", false, out subEle))
				Karma = subEle.ToSingle();

			if (ele.TryPathTo("DispositionBase", false, out subEle))
				DispositionBase = subEle.ToInt16();

			if (ele.TryPathTo("TemplateFlags", false, out subEle))
				TemplateFlags = subEle.ToEnum<ActorTemplateFlags>();
		}

		public override object Clone()
		{
			return new CreatureBaseStats(this);
		}

        public int CompareTo(CreatureBaseStats other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(CreatureBaseStats objA, CreatureBaseStats objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CreatureBaseStats objA, CreatureBaseStats objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CreatureBaseStats objA, CreatureBaseStats objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CreatureBaseStats objA, CreatureBaseStats objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CreatureBaseStats other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				Fatigue == other.Fatigue &&
				BarterGold == other.BarterGold &&
				Level == other.Level &&
				CalcMin == other.CalcMin &&
				CalcMax == other.CalcMax &&
				SpeedMultiplier == other.SpeedMultiplier &&
				Karma == other.Karma &&
				DispositionBase == other.DispositionBase &&
				TemplateFlags == other.TemplateFlags;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CreatureBaseStats other = obj as CreatureBaseStats;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Level.GetHashCode();
        }

        public static bool operator ==(CreatureBaseStats objA, CreatureBaseStats objB)
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

        public static bool operator !=(CreatureBaseStats objA, CreatureBaseStats objB)
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