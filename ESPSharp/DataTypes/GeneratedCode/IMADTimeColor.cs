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
	public partial class IMADTimeColor : IESPSerializable, ICloneable<IMADTimeColor>
	{
		public Single Time { get; set; }
		public Single Red { get; set; }
		public Single Green { get; set; }
		public Single Blue { get; set; }
		public Single Alpha { get; set; }

		public IMADTimeColor()
		{
			Time = new Single();
			Red = new Single();
			Green = new Single();
			Blue = new Single();
			Alpha = new Single();
		}

		public IMADTimeColor(Single Time, Single Red, Single Green, Single Blue, Single Alpha)
		{
			this.Time = Time;
			this.Red = Red;
			this.Green = Green;
			this.Blue = Blue;
			this.Alpha = Alpha;
		}

		public IMADTimeColor(IMADTimeColor copyObject)
		{
			Time = copyObject.Time;
			Red = copyObject.Red;
			Green = copyObject.Green;
			Blue = copyObject.Blue;
			Alpha = copyObject.Alpha;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Time = reader.ReadSingle();
				Red = reader.ReadSingle();
				Green = reader.ReadSingle();
				Blue = reader.ReadSingle();
				Alpha = reader.ReadSingle();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(Time);			
			writer.Write(Red);			
			writer.Write(Green);			
			writer.Write(Blue);			
			writer.Write(Alpha);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Time", true, out subEle);
			subEle.Value = Time.ToString();

			ele.TryPathTo("Color/Red", true, out subEle);
			subEle.Value = Red.ToString();

			ele.TryPathTo("Color/Green", true, out subEle);
			subEle.Value = Green.ToString();

			ele.TryPathTo("Color/Blue", true, out subEle);
			subEle.Value = Blue.ToString();

			ele.TryPathTo("Color/Alpha", true, out subEle);
			subEle.Value = Alpha.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Time", false, out subEle))
			{
				Time = subEle.ToSingle();
			}

			if (ele.TryPathTo("Color/Red", false, out subEle))
			{
				Red = subEle.ToSingle();
			}

			if (ele.TryPathTo("Color/Green", false, out subEle))
			{
				Green = subEle.ToSingle();
			}

			if (ele.TryPathTo("Color/Blue", false, out subEle))
			{
				Blue = subEle.ToSingle();
			}

			if (ele.TryPathTo("Color/Alpha", false, out subEle))
			{
				Alpha = subEle.ToSingle();
			}
		}

		public IMADTimeColor Clone()
		{
			return new IMADTimeColor(this);
		}
	}
}
