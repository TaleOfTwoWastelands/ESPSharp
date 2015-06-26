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
	public partial class RaceDefaultHairColors : Subrecord, ICloneable<RaceDefaultHairColors>
	{
		public HairColor MaleColor { get; set; }
		public HairColor FemaleColor { get; set; }

		public RaceDefaultHairColors()
		{
			MaleColor = new HairColor();
			FemaleColor = new HairColor();
		}

		public RaceDefaultHairColors(HairColor MaleColor, HairColor FemaleColor)
		{
			this.MaleColor = MaleColor;
			this.FemaleColor = FemaleColor;
		}

		public RaceDefaultHairColors(RaceDefaultHairColors copyObject)
		{
			MaleColor = copyObject.MaleColor;
			FemaleColor = copyObject.FemaleColor;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaleColor = subReader.ReadEnum<HairColor>();
					FemaleColor = subReader.ReadEnum<HairColor>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)MaleColor);
			writer.Write((Byte)FemaleColor);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Male", true, out subEle);
			subEle.Value = MaleColor.ToString();

			ele.TryPathTo("Female", true, out subEle);
			subEle.Value = FemaleColor.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Male", false, out subEle))
			{
				MaleColor = subEle.ToEnum<HairColor>();
			}

			if (ele.TryPathTo("Female", false, out subEle))
			{
				FemaleColor = subEle.ToEnum<HairColor>();
			}
		}

		public RaceDefaultHairColors Clone()
		{
			return new RaceDefaultHairColors(this);
		}

	}
}
