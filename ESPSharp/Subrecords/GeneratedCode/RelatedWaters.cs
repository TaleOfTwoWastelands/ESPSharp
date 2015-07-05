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
	public partial class RelatedWaters : Subrecord, ICloneable<RelatedWaters>, IReferenceContainer
	{
		public FormID Daytime { get; set; }
		public FormID Nighttime { get; set; }
		public FormID Underwater { get; set; }

		public RelatedWaters()
		{
			Daytime = new FormID();
			Nighttime = new FormID();
			Underwater = new FormID();
		}

		public RelatedWaters(FormID Daytime, FormID Nighttime, FormID Underwater)
		{
			this.Daytime = Daytime;
			this.Nighttime = Nighttime;
			this.Underwater = Underwater;
		}

		public RelatedWaters(RelatedWaters copyObject)
		{
			Daytime = copyObject.Daytime.Clone();
			Nighttime = copyObject.Nighttime.Clone();
			Underwater = copyObject.Underwater.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Daytime.ReadBinary(subReader);
					Nighttime.ReadBinary(subReader);
					Underwater.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Daytime.WriteBinary(writer);
			Nighttime.WriteBinary(writer);
			Underwater.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Daytime", true, out subEle);
			Daytime.WriteXML(subEle, master);

			ele.TryPathTo("Nighttime", true, out subEle);
			Nighttime.WriteXML(subEle, master);

			ele.TryPathTo("Underwater", true, out subEle);
			Underwater.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Daytime", false, out subEle))
			{
				Daytime.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Nighttime", false, out subEle))
			{
				Nighttime.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Underwater", false, out subEle))
			{
				Underwater.ReadXML(subEle, master);
			}
		}

		public RelatedWaters Clone()
		{
			return new RelatedWaters(this);
		}

	}
}
