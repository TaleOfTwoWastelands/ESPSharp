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
	public partial class AmmoEffectData : Subrecord, ICloneable<AmmoEffectData>
	{
		public AmmoEffectType Type { get; set; }
		public AmmoEffectOperation Operation { get; set; }
		public Single Value { get; set; }

		public AmmoEffectData()
		{
			Type = new AmmoEffectType();
			Operation = new AmmoEffectOperation();
			Value = new Single();
		}

		public AmmoEffectData(AmmoEffectType Type, AmmoEffectOperation Operation, Single Value)
		{
			this.Type = Type;
			this.Operation = Operation;
			this.Value = Value;
		}

		public AmmoEffectData(AmmoEffectData copyObject)
		{
			Type = copyObject.Type;
			Operation = copyObject.Operation;
			Value = copyObject.Value;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<AmmoEffectType>();
					Operation = subReader.ReadEnum<AmmoEffectOperation>();
					Value = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Type);
			writer.Write((UInt32)Operation);
			writer.Write(Value);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Operation", true, out subEle);
			subEle.Value = Operation.ToString();

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<AmmoEffectType>();
			}

			if (ele.TryPathTo("Operation", false, out subEle))
			{
				Operation = subEle.ToEnum<AmmoEffectOperation>();
			}

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToSingle();
			}
		}

		public AmmoEffectData Clone()
		{
			return new AmmoEffectData(this);
		}

	}
}
