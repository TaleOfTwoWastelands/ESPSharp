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
	public partial class ReferenceAmmo : SubrecordCollection, ICloneable<ReferenceAmmo>, IReferenceContainer
	{
		public RecordReference Type { get; set; }
		public SimpleSubrecord<Int32> Count { get; set; }

		public ReferenceAmmo()
		{
			Type = new RecordReference();
			Count = new SimpleSubrecord<Int32>();
		}

		public ReferenceAmmo(RecordReference Type, SimpleSubrecord<Int32> Count)
		{
			this.Type = Type;
			this.Count = Count;
		}

		public ReferenceAmmo(ReferenceAmmo copyObject)
		{
			Type = copyObject.Type.Clone();
			Count = copyObject.Count.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "XAMT":
						if (readTags.Contains("XAMT"))
							return;
						Type.ReadBinary(reader);
						break;
					case "XAMC":
						if (readTags.Contains("XAMC"))
							return;
						Count.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Type != null)
				Type.WriteBinary(writer);
			if (Count != null)
				Count.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Type != null)		
			{		
				ele.TryPathTo("Type", true, out subEle);
				Type.WriteXML(subEle, master);
			}
			if (Count != null)		
			{		
				ele.TryPathTo("Count", true, out subEle);
				Count.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
			{
				if (Type == null)
					Type = new RecordReference();
					
				Type.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Count", false, out subEle))
			{
				if (Count == null)
					Count = new SimpleSubrecord<Int32>();
					
				Count.ReadXML(subEle, master);
			}
		}

		public ReferenceAmmo Clone()
		{
			return new ReferenceAmmo(this);
		}

	}
}
