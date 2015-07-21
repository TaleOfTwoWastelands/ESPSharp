
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
	public partial class ClimateTiming : Subrecord, ICloneable, IComparable<ClimateTiming>, IEquatable<ClimateTiming>  
	{
		public Byte SunriseBegin { get; set; }
		public Byte SunriseEnd { get; set; }
		public Byte SunsetBegin { get; set; }
		public Byte SunsetEnd { get; set; }
		public Byte Volatility { get; set; }
		public MoonData MoonData { get; set; }

		public ClimateTiming(string Tag = null)
			:base(Tag)
		{
			SunriseBegin = new Byte();
			SunriseEnd = new Byte();
			SunsetBegin = new Byte();
			SunsetEnd = new Byte();
			Volatility = new Byte();
			MoonData = new MoonData();
		}

		public ClimateTiming(Byte SunriseBegin, Byte SunriseEnd, Byte SunsetBegin, Byte SunsetEnd, Byte Volatility, MoonData MoonData)
		{
			this.SunriseBegin = SunriseBegin;
			this.SunriseEnd = SunriseEnd;
			this.SunsetBegin = SunsetBegin;
			this.SunsetEnd = SunsetEnd;
			this.Volatility = Volatility;
			this.MoonData = MoonData;
		}

		public ClimateTiming(ClimateTiming copyObject)
		{
			SunriseBegin = copyObject.SunriseBegin;
			SunriseEnd = copyObject.SunriseEnd;
			SunsetBegin = copyObject.SunsetBegin;
			SunsetEnd = copyObject.SunsetEnd;
			Volatility = copyObject.Volatility;
			if (copyObject.MoonData != null)
				MoonData = (MoonData)copyObject.MoonData.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					SunriseBegin = subReader.ReadByte();
					SunriseEnd = subReader.ReadByte();
					SunsetBegin = subReader.ReadByte();
					SunsetEnd = subReader.ReadByte();
					Volatility = subReader.ReadByte();
					MoonData.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(SunriseBegin);
			writer.Write(SunriseEnd);
			writer.Write(SunsetBegin);
			writer.Write(SunsetEnd);
			writer.Write(Volatility);
			MoonData.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sunrise/Begin", true, out subEle);
			subEle.Value = SunriseBegin.ToString();

			ele.TryPathTo("Sunrise/End", true, out subEle);
			subEle.Value = SunriseEnd.ToString();

			ele.TryPathTo("Sunset/Begin", true, out subEle);
			subEle.Value = SunsetBegin.ToString();

			ele.TryPathTo("Sunset/End", true, out subEle);
			subEle.Value = SunsetEnd.ToString();

			ele.TryPathTo("Volatility", true, out subEle);
			subEle.Value = Volatility.ToString();

			ele.TryPathTo("MoonData", true, out subEle);
			MoonData.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sunrise/Begin", false, out subEle))
				SunriseBegin = subEle.ToByte();

			if (ele.TryPathTo("Sunrise/End", false, out subEle))
				SunriseEnd = subEle.ToByte();

			if (ele.TryPathTo("Sunset/Begin", false, out subEle))
				SunsetBegin = subEle.ToByte();

			if (ele.TryPathTo("Sunset/End", false, out subEle))
				SunsetEnd = subEle.ToByte();

			if (ele.TryPathTo("Volatility", false, out subEle))
				Volatility = subEle.ToByte();

			if (ele.TryPathTo("MoonData", false, out subEle))
				MoonData.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new ClimateTiming(this);
		}

        public int CompareTo(ClimateTiming other)
        {
			return SunriseBegin.CompareTo(other.SunriseBegin);
        }

        public static bool operator >(ClimateTiming objA, ClimateTiming objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ClimateTiming objA, ClimateTiming objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ClimateTiming objA, ClimateTiming objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ClimateTiming objA, ClimateTiming objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ClimateTiming other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return SunriseBegin == other.SunriseBegin &&
				SunriseEnd == other.SunriseEnd &&
				SunsetBegin == other.SunsetBegin &&
				SunsetEnd == other.SunsetEnd &&
				Volatility == other.Volatility &&
				MoonData == other.MoonData;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ClimateTiming other = obj as ClimateTiming;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return SunriseBegin.GetHashCode();
        }

        public static bool operator ==(ClimateTiming objA, ClimateTiming objB)
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

        public static bool operator !=(ClimateTiming objA, ClimateTiming objB)
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