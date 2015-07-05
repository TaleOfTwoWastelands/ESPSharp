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
	public partial class LoadScreenLocation : Subrecord, ICloneable<LoadScreenLocation>, IReferenceContainer
	{
		public FormID Direct { get; set; }
		public FormID IndirectWorld { get; set; }
		public Int16 IndirectGridY { get; set; }
		public Int16 IndirectGridX { get; set; }

		public LoadScreenLocation()
		{
			Direct = new FormID();
			IndirectWorld = new FormID();
			IndirectGridY = new Int16();
			IndirectGridX = new Int16();
		}

		public LoadScreenLocation(FormID Direct, FormID IndirectWorld, Int16 IndirectGridY, Int16 IndirectGridX)
		{
			this.Direct = Direct;
			this.IndirectWorld = IndirectWorld;
			this.IndirectGridY = IndirectGridY;
			this.IndirectGridX = IndirectGridX;
		}

		public LoadScreenLocation(LoadScreenLocation copyObject)
		{
			Direct = copyObject.Direct.Clone();
			IndirectWorld = copyObject.IndirectWorld.Clone();
			IndirectGridY = copyObject.IndirectGridY;
			IndirectGridX = copyObject.IndirectGridX;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Direct.ReadBinary(subReader);
					IndirectWorld.ReadBinary(subReader);
					IndirectGridY = subReader.ReadInt16();
					IndirectGridX = subReader.ReadInt16();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Direct.WriteBinary(writer);
			IndirectWorld.WriteBinary(writer);
			writer.Write(IndirectGridY);			
			writer.Write(IndirectGridX);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Direct", true, out subEle);
			Direct.WriteXML(subEle, master);

			ele.TryPathTo("Indirect/World", true, out subEle);
			IndirectWorld.WriteXML(subEle, master);

			ele.TryPathTo("Indirect/GridY", true, out subEle);
			subEle.Value = IndirectGridY.ToString();

			ele.TryPathTo("Indirect/GridX", true, out subEle);
			subEle.Value = IndirectGridX.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Direct", false, out subEle))
			{
				Direct.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Indirect/World", false, out subEle))
			{
				IndirectWorld.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Indirect/GridY", false, out subEle))
			{
				IndirectGridY = subEle.ToInt16();
			}

			if (ele.TryPathTo("Indirect/GridX", false, out subEle))
			{
				IndirectGridX = subEle.ToInt16();
			}
		}

		public LoadScreenLocation Clone()
		{
			return new LoadScreenLocation(this);
		}

	}
}
