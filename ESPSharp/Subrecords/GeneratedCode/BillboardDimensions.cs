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
	public partial class BillboardDimensions : Subrecord, ICloneable<BillboardDimensions>
	{
		public Single Width { get; set; }
		public Single Height { get; set; }

		public BillboardDimensions()
		{
			Width = new Single();
			Height = new Single();
		}

		public BillboardDimensions(Single Width, Single Height)
		{
			this.Width = Width;
			this.Height = Height;
		}

		public BillboardDimensions(BillboardDimensions copyObject)
		{
			Width = copyObject.Width;
			Height = copyObject.Height;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Width = subReader.ReadSingle();
					Height = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Width);			
			writer.Write(Height);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Width", true, out subEle);
			subEle.Value = Width.ToString("G15");

			ele.TryPathTo("Height", true, out subEle);
			subEle.Value = Height.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Width", false, out subEle))
			{
				Width = subEle.ToSingle();
			}

			if (ele.TryPathTo("Height", false, out subEle))
			{
				Height = subEle.ToSingle();
			}
		}

		public BillboardDimensions Clone()
		{
			return new BillboardDimensions(this);
		}

	}
}
