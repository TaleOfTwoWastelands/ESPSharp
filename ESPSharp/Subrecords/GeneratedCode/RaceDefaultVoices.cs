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
	public partial class RaceDefaultVoices : Subrecord, ICloneable<RaceDefaultVoices>, IReferenceContainer
	{
		public FormID MaleVoice { get; set; }
		public FormID FemaleVoice { get; set; }

		public RaceDefaultVoices()
		{
			MaleVoice = new FormID();
			FemaleVoice = new FormID();
		}

		public RaceDefaultVoices(FormID MaleVoice, FormID FemaleVoice)
		{
			this.MaleVoice = MaleVoice;
			this.FemaleVoice = FemaleVoice;
		}

		public RaceDefaultVoices(RaceDefaultVoices copyObject)
		{
			MaleVoice = copyObject.MaleVoice.Clone();
			FemaleVoice = copyObject.FemaleVoice.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaleVoice.ReadBinary(subReader);
					FemaleVoice.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			MaleVoice.WriteBinary(writer);
			FemaleVoice.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Male", true, out subEle);
			MaleVoice.WriteXML(subEle, master);

			ele.TryPathTo("Female", true, out subEle);
			FemaleVoice.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Male", false, out subEle))
			{
				MaleVoice.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Female", false, out subEle))
			{
				FemaleVoice.ReadXML(subEle, master);
			}
		}

		public RaceDefaultVoices Clone()
		{
			return new RaceDefaultVoices(this);
		}
	}
}
