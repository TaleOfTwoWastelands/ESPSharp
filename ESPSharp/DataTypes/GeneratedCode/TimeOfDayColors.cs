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
	public partial class TimeOfDayColors : IESPSerializable, ICloneable<TimeOfDayColors>
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
			Sunrise = copyObject.Sunrise.Clone();
			Day = copyObject.Day.Clone();
			Sunset = copyObject.Sunset.Clone();
			Night = copyObject.Night.Clone();
			HighNoon = copyObject.HighNoon.Clone();
			Midnight = copyObject.Midnight.Clone();
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
			{
				Sunrise.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Day", false, out subEle))
			{
				Day.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Sunset", false, out subEle))
			{
				Sunset.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Night", false, out subEle))
			{
				Night.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("HighNoon", false, out subEle))
			{
				HighNoon.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Midnight", false, out subEle))
			{
				Midnight.ReadXML(subEle, master);
			}
		}

		public TimeOfDayColors Clone()
		{
			return new TimeOfDayColors(this);
		}
	}
}
