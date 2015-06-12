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
	public partial class ArmorData : Subrecord, ICloneable<ArmorData>
	{
		public Int32 Value { get; set; }
		public Int32 MaxCondition { get; set; }
		public Single Weight { get; set; }

		public ArmorData()
		{
			Value = new Int32();
			MaxCondition = new Int32();
			Weight = new Single();
		}

		public ArmorData(Int32 Value, Int32 MaxCondition, Single Weight)
		{
			this.Value = Value;
			this.MaxCondition = MaxCondition;
			this.Weight = Weight;
		}

		public ArmorData(ArmorData copyObject)
		{
			Value = copyObject.Value;
			MaxCondition = copyObject.MaxCondition;
			Weight = copyObject.Weight;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Value = subReader.ReadInt32();
					MaxCondition = subReader.ReadInt32();
					Weight = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Value);			
			writer.Write(MaxCondition);			
			writer.Write(Weight);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("MaxCondition", true, out subEle);
			subEle.Value = MaxCondition.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToInt32();
			}

			if (ele.TryPathTo("MaxCondition", false, out subEle))
			{
				MaxCondition = subEle.ToInt32();
			}

			if (ele.TryPathTo("Weight", false, out subEle))
			{
				Weight = subEle.ToSingle();
			}
		}

		public ArmorData Clone()
		{
			return new ArmorData(this);
		}
	}
}
