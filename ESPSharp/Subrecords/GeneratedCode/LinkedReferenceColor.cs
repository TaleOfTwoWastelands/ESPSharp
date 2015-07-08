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
	public partial class LinkedReferenceColor : Subrecord, ICloneable<LinkedReferenceColor>
	{
		public Color Start { get; set; }
		public Color End { get; set; }

		public LinkedReferenceColor()
		{
			Start = new Color();
			End = new Color();
		}

		public LinkedReferenceColor(Color Start, Color End)
		{
			this.Start = Start;
			this.End = End;
		}

		public LinkedReferenceColor(LinkedReferenceColor copyObject)
		{
			Start = copyObject.Start.Clone();
			End = copyObject.End.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Start.ReadBinary(subReader);
					End.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Start.WriteBinary(writer);
			End.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Start", true, out subEle);
			Start.WriteXML(subEle, master);

			ele.TryPathTo("End", true, out subEle);
			End.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Start", false, out subEle))
			{
				Start.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("End", false, out subEle))
			{
				End.ReadXML(subEle, master);
			}
		}

		public LinkedReferenceColor Clone()
		{
			return new LinkedReferenceColor(this);
		}

	}
}
