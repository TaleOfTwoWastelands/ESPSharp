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

namespace ESPSharp.SubrecordCollections
{
	public partial class MasterFileData : SubrecordCollection, ICloneable<MasterFileData>
	{
		public SimpleSubrecord<String> FileName { get; set; }
		public SimpleSubrecord<UInt64> FileSize { get; set; }

		public MasterFileData()
		{
			FileName = new SimpleSubrecord<String>();
			FileSize = new SimpleSubrecord<UInt64>();
		}

		public MasterFileData(SimpleSubrecord<String> FileName, SimpleSubrecord<UInt64> FileSize)
		{
			this.FileName = FileName;
			this.FileSize = FileSize;
		}

		public MasterFileData(MasterFileData copyObject)
		{
			FileName = copyObject.FileName.Clone();
			FileSize = copyObject.FileSize.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "MAST":
						if (readTags.Contains("MAST"))
							return;
						FileName.ReadBinary(reader);
						break;
					case "DATA":
						if (readTags.Contains("DATA"))
							return;
						FileSize.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
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

		public MasterFileData Clone()
		{
			return new MasterFileData(this);
		}

	}
}
