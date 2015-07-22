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
	public partial class DateStamp : IESPSerializable, ICloneable, IComparable<DateStamp>, IEquatable<DateStamp>  
	{
		public Byte DayOfMonth { get; set; }
		public Byte MonthsSince2001 { get; set; }

		public DateStamp()
		{
			DayOfMonth = new Byte();
			MonthsSince2001 = new Byte();
		}

		public DateStamp(Byte DayOfMonth, Byte MonthsSince2001)
		{
			this.DayOfMonth = DayOfMonth;
			this.MonthsSince2001 = MonthsSince2001;
		}

		public DateStamp(DateStamp copyObject)
		{
			DayOfMonth = copyObject.DayOfMonth;
			MonthsSince2001 = copyObject.MonthsSince2001;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				DayOfMonth = reader.ReadByte();
					MonthsSince2001 = reader.ReadByte();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(DayOfMonth);
			writer.Write(MonthsSince2001);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("DayOfMonth", true, out subEle);
			subEle.Value = DayOfMonth.ToString();

			ele.TryPathTo("MonthsSince2001", true, out subEle);
			subEle.Value = MonthsSince2001.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("DayOfMonth", false, out subEle))
				DayOfMonth = subEle.ToByte();

			if (ele.TryPathTo("MonthsSince2001", false, out subEle))
				MonthsSince2001 = subEle.ToByte();
		}

		public object Clone()
		{
			return new DateStamp(this);
		}

        public int CompareTo(DateStamp other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(DateStamp objA, DateStamp objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DateStamp objA, DateStamp objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DateStamp objA, DateStamp objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DateStamp objA, DateStamp objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DateStamp other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DayOfMonth == other.DayOfMonth &&
				MonthsSince2001 == other.MonthsSince2001;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DateStamp other = obj as DateStamp;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MonthsSince2001.GetHashCode();
        }

        public static bool operator ==(DateStamp objA, DateStamp objB)
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

        public static bool operator !=(DateStamp objA, DateStamp objB)
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