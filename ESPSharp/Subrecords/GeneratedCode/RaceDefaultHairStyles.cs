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
	public partial class RaceDefaultHairStyles : Subrecord, ICloneable<RaceDefaultHairStyles>, IReferenceContainer
	{
		public FormID MaleStyle { get; set; }
		public FormID FemaleStyle { get; set; }

		public RaceDefaultHairStyles()
		{
			MaleStyle = new FormID();
			FemaleStyle = new FormID();
		}

		public RaceDefaultHairStyles(FormID MaleStyle, FormID FemaleStyle)
		{
			this.MaleStyle = MaleStyle;
			this.FemaleStyle = FemaleStyle;
		}

		public RaceDefaultHairStyles(RaceDefaultHairStyles copyObject)
		{
			MaleStyle = copyObject.MaleStyle.Clone();
			FemaleStyle = copyObject.FemaleStyle.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaleStyle.ReadBinary(subReader);
					FemaleStyle.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			MaleStyle.WriteBinary(writer);
			FemaleStyle.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Male", true, out subEle);
			MaleStyle.WriteXML(subEle);

			ele.TryPathTo("Female", true, out subEle);
			FemaleStyle.WriteXML(subEle);
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Male", false, out subEle))
			{
				MaleStyle.ReadXML(subEle);
			}

			if (ele.TryPathTo("Female", false, out subEle))
			{
				FemaleStyle.ReadXML(subEle);
			}
		}

		public RaceDefaultHairStyles Clone()
		{
			return new RaceDefaultHairStyles(this);
		}
	}
}
