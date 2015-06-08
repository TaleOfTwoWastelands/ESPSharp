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
	public partial class RecordReference : Subrecord, ICloneable<RecordReference>, IReferenceContainer
	{
		public FormID Reference { get; set; }

		public RecordReference()
		{
			Reference = new FormID();
		}

		public RecordReference(FormID Reference)
		{
			this.Reference = Reference;
		}

		public RecordReference(RecordReference copyObject)
		{
			Reference = copyObject.Reference.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Reference.ReadBinary(subReader);
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
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Reference", true, out subEle);
			Reference.WriteXML(subEle);
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Reference", false, out subEle))
			{
				Reference.ReadXML(subEle);
			}
		}

		public RecordReference Clone()
		{
			return new RecordReference(this);
		}
	}
}
