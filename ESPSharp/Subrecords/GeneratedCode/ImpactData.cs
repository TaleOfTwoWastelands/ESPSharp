
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
	public partial class ImpactData : Subrecord, ICloneable, IComparable<ImpactData>, IEquatable<ImpactData>  
	{
		public Single EffectDuration { get; set; }
		public ImpactOrientation EffectOrientation { get; set; }
		public Single AngleThreshold { get; set; }
		public Single PlacementRadius { get; set; }
		public SoundLevel SoundLevel { get; set; }
		public YesNoUInt HasDecalData { get; set; }

		public ImpactData(string Tag = null)
			:base(Tag)
		{
			EffectDuration = new Single();
			EffectOrientation = new ImpactOrientation();
			AngleThreshold = new Single();
			PlacementRadius = new Single();
			SoundLevel = new SoundLevel();
			HasDecalData = new YesNoUInt();
		}

		public ImpactData(Single EffectDuration, ImpactOrientation EffectOrientation, Single AngleThreshold, Single PlacementRadius, SoundLevel SoundLevel, YesNoUInt HasDecalData)
		{
			this.EffectDuration = EffectDuration;
			this.EffectOrientation = EffectOrientation;
			this.AngleThreshold = AngleThreshold;
			this.PlacementRadius = PlacementRadius;
			this.SoundLevel = SoundLevel;
			this.HasDecalData = HasDecalData;
		}

		public ImpactData(ImpactData copyObject)
		{
			EffectDuration = copyObject.EffectDuration;
			EffectOrientation = copyObject.EffectOrientation;
			AngleThreshold = copyObject.AngleThreshold;
			PlacementRadius = copyObject.PlacementRadius;
			SoundLevel = copyObject.SoundLevel;
			HasDecalData = copyObject.HasDecalData;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					EffectDuration = subReader.ReadSingle();
					EffectOrientation = subReader.ReadEnum<ImpactOrientation>();
					AngleThreshold = subReader.ReadSingle();
					PlacementRadius = subReader.ReadSingle();
					SoundLevel = subReader.ReadEnum<SoundLevel>();
					HasDecalData = subReader.ReadEnum<YesNoUInt>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(EffectDuration);
			writer.Write((UInt32)EffectOrientation);
			writer.Write(AngleThreshold);
			writer.Write(PlacementRadius);
			writer.Write((UInt32)SoundLevel);
			writer.Write((UInt32)HasDecalData);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Effect/Duration", true, out subEle);
			subEle.Value = EffectDuration.ToString("G15");

			ele.TryPathTo("Effect/Orientation", true, out subEle);
			subEle.Value = EffectOrientation.ToString();

			ele.TryPathTo("AngleThreshold", true, out subEle);
			subEle.Value = AngleThreshold.ToString("G15");

			ele.TryPathTo("PlacementRadius", true, out subEle);
			subEle.Value = PlacementRadius.ToString("G15");

			ele.TryPathTo("SoundLevel", true, out subEle);
			subEle.Value = SoundLevel.ToString();

			ele.TryPathTo("HasDecalData", true, out subEle);
			subEle.Value = HasDecalData.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Effect/Duration", false, out subEle))
				EffectDuration = subEle.ToSingle();

			if (ele.TryPathTo("Effect/Orientation", false, out subEle))
				EffectOrientation = subEle.ToEnum<ImpactOrientation>();

			if (ele.TryPathTo("AngleThreshold", false, out subEle))
				AngleThreshold = subEle.ToSingle();

			if (ele.TryPathTo("PlacementRadius", false, out subEle))
				PlacementRadius = subEle.ToSingle();

			if (ele.TryPathTo("SoundLevel", false, out subEle))
				SoundLevel = subEle.ToEnum<SoundLevel>();

			if (ele.TryPathTo("HasDecalData", false, out subEle))
				HasDecalData = subEle.ToEnum<YesNoUInt>();
		}

		public override object Clone()
		{
			return new ImpactData(this);
		}

        public int CompareTo(ImpactData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(ImpactData objA, ImpactData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ImpactData objA, ImpactData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ImpactData objA, ImpactData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ImpactData objA, ImpactData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ImpactData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return EffectDuration == other.EffectDuration &&
				EffectOrientation == other.EffectOrientation &&
				AngleThreshold == other.AngleThreshold &&
				PlacementRadius == other.PlacementRadius &&
				SoundLevel == other.SoundLevel &&
				HasDecalData == other.HasDecalData;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ImpactData other = obj as ImpactData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return EffectDuration.GetHashCode();
        }

        public static bool operator ==(ImpactData objA, ImpactData objB)
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

        public static bool operator !=(ImpactData objA, ImpactData objB)
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