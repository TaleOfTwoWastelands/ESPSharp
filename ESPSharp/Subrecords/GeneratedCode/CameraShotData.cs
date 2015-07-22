
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
	public partial class CameraShotData : Subrecord, ICloneable, IComparable<CameraShotData>, IEquatable<CameraShotData>  
	{
		public CameraShotAction Action { get; set; }
		public CameraShotSubject Location { get; set; }
		public CameraShotSubject Target { get; set; }
		public CameraShotFlags Flags { get; set; }
		public Single TimeMultiplierPlayer { get; set; }
		public Single TimeMultiplierTarget { get; set; }
		public Single TimeMultiplierGlobal { get; set; }
		public Single TimeMax { get; set; }
		public Single TimeMin { get; set; }
		public Single TargetPercentBetweenActors { get; set; }

		public CameraShotData(string Tag = null)
			:base(Tag)
		{
			Action = new CameraShotAction();
			Location = new CameraShotSubject();
			Target = new CameraShotSubject();
			Flags = new CameraShotFlags();
			TimeMultiplierPlayer = new Single();
			TimeMultiplierTarget = new Single();
			TimeMultiplierGlobal = new Single();
			TimeMax = new Single();
			TimeMin = new Single();
			TargetPercentBetweenActors = new Single();
		}

		public CameraShotData(CameraShotAction Action, CameraShotSubject Location, CameraShotSubject Target, CameraShotFlags Flags, Single TimeMultiplierPlayer, Single TimeMultiplierTarget, Single TimeMultiplierGlobal, Single TimeMax, Single TimeMin, Single TargetPercentBetweenActors)
		{
			this.Action = Action;
			this.Location = Location;
			this.Target = Target;
			this.Flags = Flags;
			this.TimeMultiplierPlayer = TimeMultiplierPlayer;
			this.TimeMultiplierTarget = TimeMultiplierTarget;
			this.TimeMultiplierGlobal = TimeMultiplierGlobal;
			this.TimeMax = TimeMax;
			this.TimeMin = TimeMin;
			this.TargetPercentBetweenActors = TargetPercentBetweenActors;
		}

		public CameraShotData(CameraShotData copyObject)
		{
			Action = copyObject.Action;
			Location = copyObject.Location;
			Target = copyObject.Target;
			Flags = copyObject.Flags;
			TimeMultiplierPlayer = copyObject.TimeMultiplierPlayer;
			TimeMultiplierTarget = copyObject.TimeMultiplierTarget;
			TimeMultiplierGlobal = copyObject.TimeMultiplierGlobal;
			TimeMax = copyObject.TimeMax;
			TimeMin = copyObject.TimeMin;
			TargetPercentBetweenActors = copyObject.TargetPercentBetweenActors;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Action = subReader.ReadEnum<CameraShotAction>();
					Location = subReader.ReadEnum<CameraShotSubject>();
					Target = subReader.ReadEnum<CameraShotSubject>();
					Flags = subReader.ReadEnum<CameraShotFlags>();
					TimeMultiplierPlayer = subReader.ReadSingle();
					TimeMultiplierTarget = subReader.ReadSingle();
					TimeMultiplierGlobal = subReader.ReadSingle();
					TimeMax = subReader.ReadSingle();
					TimeMin = subReader.ReadSingle();
					TargetPercentBetweenActors = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Action);
			writer.Write((UInt32)Location);
			writer.Write((UInt32)Target);
			writer.Write((UInt32)Flags);
			writer.Write(TimeMultiplierPlayer);
			writer.Write(TimeMultiplierTarget);
			writer.Write(TimeMultiplierGlobal);
			writer.Write(TimeMax);
			writer.Write(TimeMin);
			writer.Write(TargetPercentBetweenActors);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Action", true, out subEle);
			subEle.Value = Action.ToString();

			ele.TryPathTo("Location", true, out subEle);
			subEle.Value = Location.ToString();

			ele.TryPathTo("Target", true, out subEle);
			subEle.Value = Target.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("TimeMultiplier/Player", true, out subEle);
			subEle.Value = TimeMultiplierPlayer.ToString("G15");

			ele.TryPathTo("TimeMultiplier/Target", true, out subEle);
			subEle.Value = TimeMultiplierTarget.ToString("G15");

			ele.TryPathTo("TimeMultiplier/Global", true, out subEle);
			subEle.Value = TimeMultiplierGlobal.ToString("G15");

			ele.TryPathTo("Time/Max", true, out subEle);
			subEle.Value = TimeMax.ToString("G15");

			ele.TryPathTo("Time/Min", true, out subEle);
			subEle.Value = TimeMin.ToString("G15");

			ele.TryPathTo("TargetPercentBetweenActors", true, out subEle);
			subEle.Value = TargetPercentBetweenActors.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Action", false, out subEle))
				Action = subEle.ToEnum<CameraShotAction>();

			if (ele.TryPathTo("Location", false, out subEle))
				Location = subEle.ToEnum<CameraShotSubject>();

			if (ele.TryPathTo("Target", false, out subEle))
				Target = subEle.ToEnum<CameraShotSubject>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<CameraShotFlags>();

			if (ele.TryPathTo("TimeMultiplier/Player", false, out subEle))
				TimeMultiplierPlayer = subEle.ToSingle();

			if (ele.TryPathTo("TimeMultiplier/Target", false, out subEle))
				TimeMultiplierTarget = subEle.ToSingle();

			if (ele.TryPathTo("TimeMultiplier/Global", false, out subEle))
				TimeMultiplierGlobal = subEle.ToSingle();

			if (ele.TryPathTo("Time/Max", false, out subEle))
				TimeMax = subEle.ToSingle();

			if (ele.TryPathTo("Time/Min", false, out subEle))
				TimeMin = subEle.ToSingle();

			if (ele.TryPathTo("TargetPercentBetweenActors", false, out subEle))
				TargetPercentBetweenActors = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new CameraShotData(this);
		}

        public int CompareTo(CameraShotData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(CameraShotData objA, CameraShotData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CameraShotData objA, CameraShotData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CameraShotData objA, CameraShotData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CameraShotData objA, CameraShotData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(CameraShotData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Action == other.Action &&
				Location == other.Location &&
				Target == other.Target &&
				Flags == other.Flags &&
				TimeMultiplierPlayer == other.TimeMultiplierPlayer &&
				TimeMultiplierTarget == other.TimeMultiplierTarget &&
				TimeMultiplierGlobal == other.TimeMultiplierGlobal &&
				TimeMax == other.TimeMax &&
				TimeMin == other.TimeMin &&
				TargetPercentBetweenActors == other.TargetPercentBetweenActors;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CameraShotData other = obj as CameraShotData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Action.GetHashCode();
        }

        public static bool operator ==(CameraShotData objA, CameraShotData objB)
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

        public static bool operator !=(CameraShotData objA, CameraShotData objB)
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