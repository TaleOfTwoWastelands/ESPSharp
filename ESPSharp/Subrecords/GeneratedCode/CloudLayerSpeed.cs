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
	public partial class CloudLayerSpeed : Subrecord, ICloneable<CloudLayerSpeed>
	{
		public Byte Layer0 { get; set; }
		public Byte Layer1 { get; set; }
		public Byte Layer2 { get; set; }
		public Byte Layer3 { get; set; }

		public CloudLayerSpeed()
		{
			Layer0 = new Byte();
			Layer1 = new Byte();
			Layer2 = new Byte();
			Layer3 = new Byte();
		}

		public CloudLayerSpeed(Byte Layer0, Byte Layer1, Byte Layer2, Byte Layer3)
		{
			this.Layer0 = Layer0;
			this.Layer1 = Layer1;
			this.Layer2 = Layer2;
			this.Layer3 = Layer3;
		}

		public CloudLayerSpeed(CloudLayerSpeed copyObject)
		{
			Layer0 = copyObject.Layer0;
			Layer1 = copyObject.Layer1;
			Layer2 = copyObject.Layer2;
			Layer3 = copyObject.Layer3;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Layer0 = subReader.ReadByte();
					Layer1 = subReader.ReadByte();
					Layer2 = subReader.ReadByte();
					Layer3 = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Layer0);			
			writer.Write(Layer1);			
			writer.Write(Layer2);			
			writer.Write(Layer3);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Layer0", true, out subEle);
			subEle.Value = Layer0.ToString();

			ele.TryPathTo("Layer1", true, out subEle);
			subEle.Value = Layer1.ToString();

			ele.TryPathTo("Layer2", true, out subEle);
			subEle.Value = Layer2.ToString();

			ele.TryPathTo("Layer3", true, out subEle);
			subEle.Value = Layer3.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Layer0", false, out subEle))
			{
				Layer0 = subEle.ToByte();
			}

			if (ele.TryPathTo("Layer1", false, out subEle))
			{
				Layer1 = subEle.ToByte();
			}

			if (ele.TryPathTo("Layer2", false, out subEle))
			{
				Layer2 = subEle.ToByte();
			}

			if (ele.TryPathTo("Layer3", false, out subEle))
			{
				Layer3 = subEle.ToByte();
			}
		}

		public CloudLayerSpeed Clone()
		{
			return new CloudLayerSpeed(this);
		}

	}
}
