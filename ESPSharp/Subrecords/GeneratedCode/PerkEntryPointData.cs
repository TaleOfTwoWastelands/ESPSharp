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
	public partial class PerkEntryPointData : Subrecord, ICloneable<PerkEntryPointData>
	{
		public EntryPoint EntryPoint { get; set; }
		public PerkFunction Function { get; set; }
		public Byte PerkConditionTabCount { get; set; }

		public PerkEntryPointData()
		{
			EntryPoint = new EntryPoint();
			Function = new PerkFunction();
			PerkConditionTabCount = new Byte();
		}

		public PerkEntryPointData(EntryPoint EntryPoint, PerkFunction Function, Byte PerkConditionTabCount)
		{
			this.EntryPoint = EntryPoint;
			this.Function = Function;
			this.PerkConditionTabCount = PerkConditionTabCount;
		}

		public PerkEntryPointData(PerkEntryPointData copyObject)
		{
			EntryPoint = copyObject.EntryPoint;
			Function = copyObject.Function;
			PerkConditionTabCount = copyObject.PerkConditionTabCount;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					EntryPoint = subReader.ReadEnum<EntryPoint>();
					Function = subReader.ReadEnum<PerkFunction>();
					PerkConditionTabCount = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)EntryPoint);
			writer.Write((Byte)Function);
			writer.Write(PerkConditionTabCount);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("EntryPoint", true, out subEle);
			subEle.Value = EntryPoint.ToString();

			ele.TryPathTo("Function", true, out subEle);
			subEle.Value = Function.ToString();

			ele.TryPathTo("PerkConditionTabCount", true, out subEle);
			subEle.Value = PerkConditionTabCount.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EntryPoint", false, out subEle))
			{
				EntryPoint = subEle.ToEnum<EntryPoint>();
			}

			if (ele.TryPathTo("Function", false, out subEle))
			{
				Function = subEle.ToEnum<PerkFunction>();
			}

			if (ele.TryPathTo("PerkConditionTabCount", false, out subEle))
			{
				PerkConditionTabCount = subEle.ToByte();
			}
		}

		public PerkEntryPointData Clone()
		{
			return new PerkEntryPointData(this);
		}

	}
}
