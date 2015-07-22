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

namespace ESPSharp.DataTypes
{
	public partial class TimeOfDayColors : IESPSerializable, ICloneable, IComparable<TimeOfDayColors>, IEquatable<TimeOfDayColors>  
	{
		public Color Sunrise { get; set; }
		public Color Day { get; set; }
		public Color Sunset { get; set; }
		public Color Night { get; set; }
		public Color HighNoon { get; set; }
		public Color Midnight { get; set; }

		public TimeOfDayColors()
		{
			Sunrise = new Color();
			Day = new Color();
			Sunset = new Color();
			Night = new Color();
			HighNoon = new Color();
			Midnight = new Color();
		}

		public TimeOfDayColors(Color Sunrise, Color Day, Color Sunset, Color Night, Color HighNoon, Color Midnight)
		{
			this.Sunrise = Sunrise;
			this.Day = Day;
			this.Sunset = Sunset;
			this.Night = Night;
			this.HighNoon = HighNoon;
			this.Midnight = Midnight;
		}

		public TimeOfDayColors(TimeOfDayColors copyObject)
		{
			if (copyObject.Sunrise != null)
				Sunrise = (Color)copyObject.Sunrise.Clone();
			if (copyObject.Day != null)
				Day = (Color)copyObject.Day.Clone();
			if (copyObject.Sunset != null)
				Sunset = (Color)copyObject.Sunset.Clone();
			if (copyObject.Night != null)
				Night = (Color)copyObject.Night.Clone();
			if (copyObject.HighNoon != null)
				HighNoon = (Color)copyObject.HighNoon.Clone();
			if (copyObject.Midnight != null)
				Midnight = (Color)copyObject.Midnight.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Sunrise.ReadBinary(reader);
					Day.ReadBinary(reader);
					Sunset.ReadBinary(reader);
					Night.ReadBinary(reader);
					HighNoon.ReadBinary(reader);
					Midnight.ReadBinary(reader);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Sunrise.WriteBinary(writer);
			Day.WriteBinary(writer);
			Sunset.WriteBinary(writer);
			Night.WriteBinary(writer);
			HighNoon.WriteBinary(writer);
			Midnight.WriteBinary(writer);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sunrise", true, out subEle);
			Sunrise.WriteXML(subEle, master);

			ele.TryPathTo("Day", true, out subEle);
			Day.WriteXML(subEle, master);

			ele.TryPathTo("Sunset", true, out subEle);
			Sunset.WriteXML(subEle, master);

			ele.TryPathTo("Night", true, out subEle);
			Night.WriteXML(subEle, master);

			ele.TryPathTo("HighNoon", true, out subEle);
			HighNoon.WriteXML(subEle, master);

			ele.TryPathTo("Midnight", true, out subEle);
			Midnight.WriteXML(subEle, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sunrise", false, out subEle))
				Sunrise.ReadXML(subEle, master);

			if (ele.TryPathTo("Day", false, out subEle))
				Day.ReadXML(subEle, master);

			if (ele.TryPathTo("Sunset", false, out subEle))
				Sunset.ReadXML(subEle, master);

			if (ele.TryPathTo("Night", false, out subEle))
				Night.ReadXML(subEle, master);

			if (ele.TryPathTo("HighNoon", false, out subEle))
				HighNoon.ReadXML(subEle, master);

			if (ele.TryPathTo("Midnight", false, out subEle))
				Midnight.ReadXML(subEle, master);
		}

		public object Clone()
		{
			return new TimeOfDayColors(this);
		}

        public int CompareTo(TimeOfDayColors other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(TimeOfDayColors objA, TimeOfDayColors objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(TimeOfDayColors objA, TimeOfDayColors objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(TimeOfDayColors objA, TimeOfDayColors objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(TimeOfDayColors objA, TimeOfDayColors objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(TimeOfDayColors other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Sunrise == other.Sunrise &&
				Day == other.Day &&
				Sunset == other.Sunset &&
				Night == other.Night &&
				HighNoon == other.HighNoon &&
				Midnight == other.Midnight;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            TimeOfDayColors other = obj as TimeOfDayColors;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Sunrise.GetHashCode();
        }

        public static bool operator ==(TimeOfDayColors objA, TimeOfDayColors objB)
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

        public static bool operator !=(TimeOfDayColors objA, TimeOfDayColors objB)
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