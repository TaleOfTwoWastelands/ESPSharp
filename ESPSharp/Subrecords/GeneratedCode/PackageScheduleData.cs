
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
	public partial class PackageScheduleData : Subrecord, ICloneable, IComparable<PackageScheduleData>, IEquatable<PackageScheduleData>  
	{
		public SByte Month { get; set; }
		public PackageScheduleDays DayOfWeek { get; set; }
		public Byte Date { get; set; }
		public SByte Time { get; set; }
		public Int32 Duration { get; set; }

		public PackageScheduleData(string Tag = null)
			:base(Tag)
		{
			Month = new SByte();
			DayOfWeek = new PackageScheduleDays();
			Date = new Byte();
			Time = new SByte();
			Duration = new Int32();
		}

		public PackageScheduleData(SByte Month, PackageScheduleDays DayOfWeek, Byte Date, SByte Time, Int32 Duration)
		{
			this.Month = Month;
			this.DayOfWeek = DayOfWeek;
			this.Date = Date;
			this.Time = Time;
			this.Duration = Duration;
		}

		public PackageScheduleData(PackageScheduleData copyObject)
		{
			Month = copyObject.Month;
			DayOfWeek = copyObject.DayOfWeek;
			Date = copyObject.Date;
			Time = copyObject.Time;
			Duration = copyObject.Duration;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Month = subReader.ReadSByte();
					DayOfWeek = subReader.ReadEnum<PackageScheduleDays>();
					Date = subReader.ReadByte();
					Time = subReader.ReadSByte();
					Duration = subReader.ReadInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Month);
			writer.Write((SByte)DayOfWeek);
			writer.Write(Date);
			writer.Write(Time);
			writer.Write(Duration);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Month", true, out subEle);
			subEle.Value = Month.ToString();

			ele.TryPathTo("DayOfWeek", true, out subEle);
			subEle.Value = DayOfWeek.ToString();

			ele.TryPathTo("Date", true, out subEle);
			subEle.Value = Date.ToString();

			ele.TryPathTo("Time", true, out subEle);
			subEle.Value = Time.ToString();

			ele.TryPathTo("Duration", true, out subEle);
			subEle.Value = Duration.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Month", false, out subEle))
				Month = subEle.ToSByte();

			if (ele.TryPathTo("DayOfWeek", false, out subEle))
				DayOfWeek = subEle.ToEnum<PackageScheduleDays>();

			if (ele.TryPathTo("Date", false, out subEle))
				Date = subEle.ToByte();

			if (ele.TryPathTo("Time", false, out subEle))
				Time = subEle.ToSByte();

			if (ele.TryPathTo("Duration", false, out subEle))
				Duration = subEle.ToInt32();
		}

		public override object Clone()
		{
			return new PackageScheduleData(this);
		}

        public int CompareTo(PackageScheduleData other)
        {
			return DayOfWeek.CompareTo(other.DayOfWeek);
        }

        public static bool operator >(PackageScheduleData objA, PackageScheduleData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PackageScheduleData objA, PackageScheduleData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PackageScheduleData objA, PackageScheduleData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PackageScheduleData objA, PackageScheduleData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PackageScheduleData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Month == other.Month &&
				DayOfWeek == other.DayOfWeek &&
				Date == other.Date &&
				Time == other.Time &&
				Duration == other.Duration;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PackageScheduleData other = obj as PackageScheduleData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return DayOfWeek.GetHashCode();
        }

        public static bool operator ==(PackageScheduleData objA, PackageScheduleData objB)
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

        public static bool operator !=(PackageScheduleData objA, PackageScheduleData objB)
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