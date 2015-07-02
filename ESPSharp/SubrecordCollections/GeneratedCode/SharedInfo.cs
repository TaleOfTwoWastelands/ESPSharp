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
	public partial class SharedInfo : SubrecordCollection, ICloneable<SharedInfo>, IReferenceContainer
	{
		public RecordReference InfoConnection { get; set; }
		public SimpleSubrecord<Int32> InfoIndex { get; set; }

		public SharedInfo()
		{
		}

		public SharedInfo(RecordReference InfoConnection, SimpleSubrecord<Int32> InfoIndex)
		{
			this.InfoConnection = InfoConnection;
			this.InfoIndex = InfoIndex;
		}

		public SharedInfo(SharedInfo copyObject)
		{
			InfoConnection = copyObject.InfoConnection.Clone();
			InfoIndex = copyObject.InfoIndex.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "INFC":
						if (readTags.Contains("INFC"))
							return;
						if (InfoConnection == null)
							InfoConnection = new RecordReference();

						InfoConnection.ReadBinary(reader);
						break;
					case "INFX":
						if (readTags.Contains("INFX"))
							return;
						if (InfoIndex == null)
							InfoIndex = new SimpleSubrecord<Int32>();

						InfoIndex.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (InfoConnection != null)
				InfoConnection.WriteBinary(writer);
			if (InfoIndex != null)
				InfoIndex.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (InfoConnection != null)		
			{		
				ele.TryPathTo("InfoConnection", true, out subEle);
				InfoConnection.WriteXML(subEle, master);
			}
			if (InfoIndex != null)		
			{		
				ele.TryPathTo("InfoIndex", true, out subEle);
				InfoIndex.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("InfoConnection", false, out subEle))
			{
				if (InfoConnection == null)
					InfoConnection = new RecordReference();
					
				InfoConnection.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("InfoIndex", false, out subEle))
			{
				if (InfoIndex == null)
					InfoIndex = new SimpleSubrecord<Int32>();
					
				InfoIndex.ReadXML(subEle, master);
			}
		}

		public SharedInfo Clone()
		{
			return new SharedInfo(this);
		}

	}
}
