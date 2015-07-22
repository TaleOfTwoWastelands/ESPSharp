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
	public partial class WeatherChance : IESPSerializable, ICloneable, IComparable<WeatherChance>, IEquatable<WeatherChance>  
	{
		public FormID Weather { get; set; }
		public Int32 Chance { get; set; }
		public FormID Global { get; set; }

		public WeatherChance()
		{
			Weather = new FormID();
			Chance = new Int32();
			Global = new FormID();
		}

		public WeatherChance(FormID Weather, Int32 Chance, FormID Global)
		{
			this.Weather = Weather;
			this.Chance = Chance;
			this.Global = Global;
		}

		public WeatherChance(WeatherChance copyObject)
		{
			if (copyObject.Weather != null)
				Weather = (FormID)copyObject.Weather.Clone();
			Chance = copyObject.Chance;
			if (copyObject.Global != null)
				Global = (FormID)copyObject.Global.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Weather.ReadBinary(reader);
					Chance = reader.ReadInt32();
					Global.ReadBinary(reader);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Weather.WriteBinary(writer);
			writer.Write(Chance);
			Global.WriteBinary(writer);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Weather", true, out subEle);
			Weather.WriteXML(subEle, master);

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();

			ele.TryPathTo("Global", true, out subEle);
			Global.WriteXML(subEle, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Weather", false, out subEle))
				Weather.ReadXML(subEle, master);

			if (ele.TryPathTo("Chance", false, out subEle))
				Chance = subEle.ToInt32();

			if (ele.TryPathTo("Global", false, out subEle))
				Global.ReadXML(subEle, master);
		}

		public object Clone()
		{
			return new WeatherChance(this);
		}

        public int CompareTo(WeatherChance other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(WeatherChance objA, WeatherChance objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(WeatherChance objA, WeatherChance objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(WeatherChance objA, WeatherChance objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(WeatherChance objA, WeatherChance objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(WeatherChance other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Weather == other.Weather &&
				Chance == other.Chance &&
				Global == other.Global;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeatherChance other = obj as WeatherChance;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Weather.GetHashCode();
        }

        public static bool operator ==(WeatherChance objA, WeatherChance objB)
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

        public static bool operator !=(WeatherChance objA, WeatherChance objB)
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