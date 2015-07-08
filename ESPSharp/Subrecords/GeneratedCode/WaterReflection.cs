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
	public partial class WaterReflection : Subrecord, ICloneable<WaterReflection>, IReferenceContainer
	{
		public FormID Reference { get; set; }
		public WaterReflectionFlags Flags { get; set; }

		public WaterReflection()
		{
			Reference = new FormID();
			Flags = new WaterReflectionFlags();
		}

		public WaterReflection(FormID Reference, WaterReflectionFlags Flags)
		{
			this.Reference = Reference;
			this.Flags = Flags;
		}

		public WaterReflection(WaterReflection copyObject)
		{
			Reference = copyObject.Reference.Clone();
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Reference.ReadBinary(subReader);
					Flags = subReader.ReadEnum<WaterReflectionFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Reference.WriteBinary(writer);
			writer.Write((UInt32)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Reference", true, out subEle);
			Reference.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Reference", false, out subEle))
			{
				Reference.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<WaterReflectionFlags>();
			}
		}

		public WaterReflection Clone()
		{
			return new WaterReflection(this);
		}

	}
}
