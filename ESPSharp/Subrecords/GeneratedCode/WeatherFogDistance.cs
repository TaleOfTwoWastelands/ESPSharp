
















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
	public partial class WeatherFogDistance : Subrecord, ICloneable, IComparable<WeatherFogDistance>, IEquatable<WeatherFogDistance>  
	{
		public Single DayNear { get; set; }
		public Single DayFar { get; set; }
		public Single NightNear { get; set; }
		public Single NightFar { get; set; }
		public Single DayPower { get; set; }
		public Single NightPower { get; set; }


		public WeatherFogDistance(string Tag = null)
			:base(Tag)
		{
			DayNear = new Single();
			DayFar = new Single();
			NightNear = new Single();
			NightFar = new Single();
			DayPower = new Single();
			NightPower = new Single();

		}

		public WeatherFogDistance(Single DayNear, Single DayFar, Single NightNear, Single NightFar, Single DayPower, Single NightPower)
		{
			this.DayNear = DayNear;
			this.DayFar = DayFar;
			this.NightNear = NightNear;
			this.NightFar = NightFar;
			this.DayPower = DayPower;
			this.NightPower = NightPower;

		}

		public WeatherFogDistance(WeatherFogDistance copyObject)
		{
			DayNear = copyObject.DayNear;
			DayFar = copyObject.DayFar;
			NightNear = copyObject.NightNear;
			NightFar = copyObject.NightFar;
			DayPower = copyObject.DayPower;
			NightPower = copyObject.NightPower;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					DayNear = subReader.ReadSingle();
					DayFar = subReader.ReadSingle();
					NightNear = subReader.ReadSingle();
					NightFar = subReader.ReadSingle();
					DayPower = subReader.ReadSingle();
					NightPower = subReader.ReadSingle();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DayNear);
			writer.Write(DayFar);
			writer.Write(NightNear);
			writer.Write(NightFar);
			writer.Write(DayPower);
			writer.Write(NightPower);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Day/Near", true, out subEle);
			subEle.Value = DayNear.ToString("G15");

			ele.TryPathTo("Day/Far", true, out subEle);
			subEle.Value = DayFar.ToString("G15");

			ele.TryPathTo("Night/Near", true, out subEle);
			subEle.Value = NightNear.ToString("G15");

			ele.TryPathTo("Night/Far", true, out subEle);
			subEle.Value = NightFar.ToString("G15");

			ele.TryPathTo("Day/Power", true, out subEle);
			subEle.Value = DayPower.ToString("G15");

			ele.TryPathTo("Night/Power", true, out subEle);
			subEle.Value = NightPower.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Day/Near", false, out subEle))
				DayNear = subEle.ToSingle();

			if (ele.TryPathTo("Day/Far", false, out subEle))
				DayFar = subEle.ToSingle();

			if (ele.TryPathTo("Night/Near", false, out subEle))
				NightNear = subEle.ToSingle();

			if (ele.TryPathTo("Night/Far", false, out subEle))
				NightFar = subEle.ToSingle();

			if (ele.TryPathTo("Day/Power", false, out subEle))
				DayPower = subEle.ToSingle();

			if (ele.TryPathTo("Night/Power", false, out subEle))
				NightPower = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new WeatherFogDistance(this);
		}


        public int CompareTo(WeatherFogDistance other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(WeatherFogDistance objA, WeatherFogDistance objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WeatherFogDistance objA, WeatherFogDistance objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WeatherFogDistance objA, WeatherFogDistance objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WeatherFogDistance objA, WeatherFogDistance objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(WeatherFogDistance other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DayNear == other.DayNear &&
				DayFar == other.DayFar &&
				NightNear == other.NightNear &&
				NightFar == other.NightFar &&
				DayPower == other.DayPower &&
				NightPower == other.NightPower;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeatherFogDistance other = obj as WeatherFogDistance;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return DayNear.GetHashCode();
        }

        public static bool operator ==(WeatherFogDistance objA, WeatherFogDistance objB)
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

        public static bool operator !=(WeatherFogDistance objA, WeatherFogDistance objB)
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