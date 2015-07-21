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
	public partial class WeatherList : Subrecord, ICloneable, IEquatable<WeatherList>, IReferenceContainer  
	{
		public List<WeatherChance> Weathers { get; set; }

		public WeatherList(string Tag = null)
			:base(Tag)
		{
			Weathers = new List<WeatherChance>();
		}

		public WeatherList(List<WeatherChance> Weathers)
		{
			this.Weathers = Weathers;
		}

		public WeatherList(WeatherList copyObject)
		{
			if (copyObject.Weathers != null)
				foreach(var temp in copyObject.Weathers)
					Weathers.Add((WeatherChance)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/12; i++)
					{
						var temp = new WeatherChance();
						temp.ReadBinary(subReader);
						Weathers.Add(temp);
					}
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			foreach (var temp in Weathers)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Weathers", true, out subEle);
			foreach (var temp in Weathers)
			{
				XElement e = new XElement("Weather");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Weathers", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new WeatherChance();
					temp.ReadXML(e, master);
					Weathers.Add(temp);
				}
		}

		public override object Clone()
		{
			return new WeatherList(this);
		}

        public bool Equals(WeatherList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Weathers.SequenceEqual(other.Weathers);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            WeatherList other = obj as WeatherList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Weathers.GetHashCode();
        }

        public static bool operator ==(WeatherList objA, WeatherList objB)
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

        public static bool operator !=(WeatherList objA, WeatherList objB)
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