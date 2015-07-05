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
	public partial class DebrisData : Subrecord, ICloneable<DebrisData>
	{
		public Byte Percentage { get; set; }
		public String Model { get; set; }
		public NoYesByte HasCollisionData { get; set; }

		public DebrisData()
		{
			Percentage = new Byte();
			Model = "";
			HasCollisionData = new NoYesByte();
		}

		public DebrisData(Byte Percentage, String Model, NoYesByte HasCollisionData)
		{
			this.Percentage = Percentage;
			this.Model = Model;
			this.HasCollisionData = HasCollisionData;
		}

		public DebrisData(DebrisData copyObject)
		{
			Percentage = copyObject.Percentage;
			Model = (String)copyObject.Model.Clone();
			HasCollisionData = copyObject.HasCollisionData;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Percentage = subReader.ReadByte();
					Model = subReader.ReadString();
					HasCollisionData = subReader.ReadEnum<NoYesByte>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Percentage);			
			writer.Write(Model);			
			writer.Write((Byte)HasCollisionData);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Percentage", true, out subEle);
			subEle.Value = Percentage.ToString();

			ele.TryPathTo("Model", true, out subEle);
			subEle.Value = Model.ToString();

			ele.TryPathTo("HasCollisionData", true, out subEle);
			subEle.Value = HasCollisionData.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Percentage", false, out subEle))
			{
				Percentage = subEle.ToByte();
			}

			if (ele.TryPathTo("Model", false, out subEle))
			{
				Model = subEle.ToString();
			}

			if (ele.TryPathTo("HasCollisionData", false, out subEle))
			{
				HasCollisionData = subEle.ToEnum<NoYesByte>();
			}
		}

		public DebrisData Clone()
		{
			return new DebrisData(this);
		}

	}
}
