using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.SubrecordCollections
{
	public partial class MasterFileData : SubrecordCollection
	{
		public SimpleSubrecord<String> FileName { get; set; }
		public SimpleSubrecord<UInt64> FileSize { get; set; }
	
		public override void ReadBinary(ESPReader reader)
		{
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "MAST":
						if (FileName == null)
							FileName = new SimpleSubrecord<String>();
						else
							return;

						FileName.ReadBinary(reader);
						break;
					case "DATA":
						if (FileSize == null)
							FileSize = new SimpleSubrecord<UInt64>();
						else
							return;

						FileSize.ReadBinary(reader);
						break;
				default:
					return;
				}
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (FileName != null)
				FileName.WriteBinary(writer);
			if (FileSize != null)
				FileSize.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;
			if (FileName != null)		
			{		
				ele.TryPathTo("FileName", true, out subEle);
				FileName.WriteXML(subEle);
			}
			if (FileSize != null)		
			{		
				ele.TryPathTo("FileSize", true, out subEle);
				FileSize.WriteXML(subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("FileName", false, out subEle))
			{
				if (FileName == null)
					FileName = new SimpleSubrecord<String>();
					
				FileName.ReadXML(subEle);
			}
			if (ele.TryPathTo("FileSize", false, out subEle))
			{
				if (FileSize == null)
					FileSize = new SimpleSubrecord<UInt64>();
					
				FileSize.ReadXML(subEle);
			}
		}

	}
}
