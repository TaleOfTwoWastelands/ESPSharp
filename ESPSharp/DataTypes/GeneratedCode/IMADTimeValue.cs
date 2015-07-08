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
	public partial class IMADTimeValue : IESPSerializable, ICloneable<IMADTimeValue>
	{
		public Single Time { get; set; }
		public Single Value { get; set; }

		public IMADTimeValue()
		{
			Time = new Single();
			Value = new Single();
		}

		public IMADTimeValue(Single Time, Single Value)
		{
			this.Time = Time;
			this.Value = Value;
		}

		public IMADTimeValue(IMADTimeValue copyObject)
		{
			Time = copyObject.Time;
			Value = copyObject.Value;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Time = reader.ReadSingle();
				Value = reader.ReadSingle();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(Time);			
			writer.Write(Value);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Time", true, out subEle);
			subEle.Value = Time.ToString("G15");

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString("G15");
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Time", false, out subEle))
			{
				Time = subEle.ToSingle();
			}

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToSingle();
			}
		}

		public IMADTimeValue Clone()
		{
			return new IMADTimeValue(this);
		}
	}
}
