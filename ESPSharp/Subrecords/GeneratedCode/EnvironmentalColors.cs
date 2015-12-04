
















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
	public partial class EnvironmentalColors : Subrecord, ICloneable, IComparable<EnvironmentalColors>, IEquatable<EnvironmentalColors>  
	{
		public TimeOfDayColors SkyUpper { get; set; }
		public TimeOfDayColors Fog { get; set; }
		public TimeOfDayColors Unused1 { get; set; }
		public TimeOfDayColors Ambient { get; set; }
		public TimeOfDayColors Sunlight { get; set; }
		public TimeOfDayColors Sun { get; set; }
		public TimeOfDayColors Stars { get; set; }
		public TimeOfDayColors SkyLower { get; set; }
		public TimeOfDayColors Horizon { get; set; }
		public TimeOfDayColors Unused2 { get; set; }


		public EnvironmentalColors(string Tag = null)
			:base(Tag)
		{
			SkyUpper = new TimeOfDayColors();
			Fog = new TimeOfDayColors();
			Unused1 = new TimeOfDayColors();
			Ambient = new TimeOfDayColors();
			Sunlight = new TimeOfDayColors();
			Sun = new TimeOfDayColors();
			Stars = new TimeOfDayColors();
			SkyLower = new TimeOfDayColors();
			Horizon = new TimeOfDayColors();
			Unused2 = new TimeOfDayColors();

		}

		public EnvironmentalColors(TimeOfDayColors SkyUpper, TimeOfDayColors Fog, TimeOfDayColors Unused1, TimeOfDayColors Ambient, TimeOfDayColors Sunlight, TimeOfDayColors Sun, TimeOfDayColors Stars, TimeOfDayColors SkyLower, TimeOfDayColors Horizon, TimeOfDayColors Unused2)
		{
			this.SkyUpper = SkyUpper;
			this.Fog = Fog;
			this.Unused1 = Unused1;
			this.Ambient = Ambient;
			this.Sunlight = Sunlight;
			this.Sun = Sun;
			this.Stars = Stars;
			this.SkyLower = SkyLower;
			this.Horizon = Horizon;
			this.Unused2 = Unused2;

		}

		public EnvironmentalColors(EnvironmentalColors copyObject)
		{
			if (copyObject.SkyUpper != null)
				SkyUpper = (TimeOfDayColors)copyObject.SkyUpper.Clone();
			if (copyObject.Fog != null)
				Fog = (TimeOfDayColors)copyObject.Fog.Clone();
			if (copyObject.Unused1 != null)
				Unused1 = (TimeOfDayColors)copyObject.Unused1.Clone();
			if (copyObject.Ambient != null)
				Ambient = (TimeOfDayColors)copyObject.Ambient.Clone();
			if (copyObject.Sunlight != null)
				Sunlight = (TimeOfDayColors)copyObject.Sunlight.Clone();
			if (copyObject.Sun != null)
				Sun = (TimeOfDayColors)copyObject.Sun.Clone();
			if (copyObject.Stars != null)
				Stars = (TimeOfDayColors)copyObject.Stars.Clone();
			if (copyObject.SkyLower != null)
				SkyLower = (TimeOfDayColors)copyObject.SkyLower.Clone();
			if (copyObject.Horizon != null)
				Horizon = (TimeOfDayColors)copyObject.Horizon.Clone();
			if (copyObject.Unused2 != null)
				Unused2 = (TimeOfDayColors)copyObject.Unused2.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					SkyUpper.ReadBinary(subReader);
					Fog.ReadBinary(subReader);
					Unused1.ReadBinary(subReader);
					Ambient.ReadBinary(subReader);
					Sunlight.ReadBinary(subReader);
					Sun.ReadBinary(subReader);
					Stars.ReadBinary(subReader);
					SkyLower.ReadBinary(subReader);
					Horizon.ReadBinary(subReader);
					Unused2.ReadBinary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			SkyUpper.WriteBinary(writer);
			Fog.WriteBinary(writer);
			Unused1.WriteBinary(writer);
			Ambient.WriteBinary(writer);
			Sunlight.WriteBinary(writer);
			Sun.WriteBinary(writer);
			Stars.WriteBinary(writer);
			SkyLower.WriteBinary(writer);
			Horizon.WriteBinary(writer);
			Unused2.WriteBinary(writer);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Sky/Upper", true, out subEle);
			SkyUpper.WriteXML(subEle, master);

			ele.TryPathTo("Fog", true, out subEle);
			Fog.WriteXML(subEle, master);

			ele.TryPathTo("Unused1", true, out subEle);
			Unused1.WriteXML(subEle, master);

			ele.TryPathTo("Ambient", true, out subEle);
			Ambient.WriteXML(subEle, master);

			ele.TryPathTo("Sunlight", true, out subEle);
			Sunlight.WriteXML(subEle, master);

			ele.TryPathTo("Sun", true, out subEle);
			Sun.WriteXML(subEle, master);

			ele.TryPathTo("Stars", true, out subEle);
			Stars.WriteXML(subEle, master);

			ele.TryPathTo("Sky/Lower", true, out subEle);
			SkyLower.WriteXML(subEle, master);

			ele.TryPathTo("Horizon", true, out subEle);
			Horizon.WriteXML(subEle, master);

			ele.TryPathTo("Unused2", true, out subEle);
			Unused2.WriteXML(subEle, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sky/Upper", false, out subEle))
				SkyUpper.ReadXML(subEle, master);

			if (ele.TryPathTo("Fog", false, out subEle))
				Fog.ReadXML(subEle, master);

			if (ele.TryPathTo("Unused1", false, out subEle))
				Unused1.ReadXML(subEle, master);

			if (ele.TryPathTo("Ambient", false, out subEle))
				Ambient.ReadXML(subEle, master);

			if (ele.TryPathTo("Sunlight", false, out subEle))
				Sunlight.ReadXML(subEle, master);

			if (ele.TryPathTo("Sun", false, out subEle))
				Sun.ReadXML(subEle, master);

			if (ele.TryPathTo("Stars", false, out subEle))
				Stars.ReadXML(subEle, master);

			if (ele.TryPathTo("Sky/Lower", false, out subEle))
				SkyLower.ReadXML(subEle, master);

			if (ele.TryPathTo("Horizon", false, out subEle))
				Horizon.ReadXML(subEle, master);

			if (ele.TryPathTo("Unused2", false, out subEle))
				Unused2.ReadXML(subEle, master);

		}

		public override object Clone()
		{
			return new EnvironmentalColors(this);
		}


        public int CompareTo(EnvironmentalColors other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(EnvironmentalColors objA, EnvironmentalColors objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EnvironmentalColors objA, EnvironmentalColors objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EnvironmentalColors objA, EnvironmentalColors objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EnvironmentalColors objA, EnvironmentalColors objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(EnvironmentalColors other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return SkyUpper == other.SkyUpper &&
				Fog == other.Fog &&
				Unused1 == other.Unused1 &&
				Ambient == other.Ambient &&
				Sunlight == other.Sunlight &&
				Sun == other.Sun &&
				Stars == other.Stars &&
				SkyLower == other.SkyLower &&
				Horizon == other.Horizon &&
				Unused2 == other.Unused2;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EnvironmentalColors other = obj as EnvironmentalColors;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Ambient.GetHashCode();
        }

        public static bool operator ==(EnvironmentalColors objA, EnvironmentalColors objB)
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

        public static bool operator !=(EnvironmentalColors objA, EnvironmentalColors objB)
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