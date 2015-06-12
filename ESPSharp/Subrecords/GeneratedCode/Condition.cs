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
	public partial class Condition : Subrecord, ICloneable<Condition>, IReferenceContainer
	{
		public Comparison Comparison { get; set; }
		public Function Function { get; set; }
		public FunctionTarget RunOn { get; set; }
		public FormID RunOnReference { get; set; }

		public Condition()
		{
			Comparison = new Comparison();
			Function = new Function();
			RunOn = new FunctionTarget();
			RunOnReference = new FormID();
		}

		public Condition(Comparison Comparison, Function Function, FunctionTarget RunOn, FormID RunOnReference)
		{
			this.Comparison = Comparison;
			this.Function = Function;
			this.RunOn = RunOn;
			this.RunOnReference = RunOnReference;
		}

		public Condition(Condition copyObject)
		{
			Comparison = copyObject.Comparison.Clone();
			Function = copyObject.Function.Clone();
			RunOn = copyObject.RunOn;
			RunOnReference = copyObject.RunOnReference.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Comparison.ReadBinary(subReader);
					Function.ReadBinary(subReader);
					RunOn = subReader.ReadEnum<FunctionTarget>();
					RunOnReference.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Comparison.WriteBinary(writer);
			Function.WriteBinary(writer);
			writer.Write((UInt32)RunOn);
			RunOnReference.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Comparison", true, out subEle);
			Comparison.WriteXML(subEle, master);

			ele.TryPathTo("Function", true, out subEle);
			Function.WriteXML(subEle, master);

			ele.TryPathTo("RunOn", true, out subEle);
			subEle.Value = RunOn.ToString();

			ele.TryPathTo("RunOnReference", true, out subEle);
			RunOnReference.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Comparison", false, out subEle))
			{
				Comparison.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Function", false, out subEle))
			{
				Function.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("RunOn", false, out subEle))
			{
				RunOn = subEle.ToEnum<FunctionTarget>();
			}

			if (ele.TryPathTo("RunOnReference", false, out subEle))
			{
				RunOnReference.ReadXML(subEle, master);
			}
		}

		public Condition Clone()
		{
			return new Condition(this);
		}
	}
}
