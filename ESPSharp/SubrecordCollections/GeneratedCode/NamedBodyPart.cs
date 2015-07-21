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
	public partial class NamedBodyPart : SubrecordCollection	{
		public SimpleSubrecord<String> PartName { get; set; }
		public BodyPart BodyPart { get; set; }

		public NamedBodyPart()
		{
			PartName = new SimpleSubrecord<String>();
			BodyPart = new BodyPart();
		}

		public NamedBodyPart(SimpleSubrecord<String> PartName, BodyPart BodyPart)
		{
			this.PartName = PartName;
			this.BodyPart = BodyPart;
		}

		public NamedBodyPart(NamedBodyPart copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "BPTN":
						if (readTags.Contains("BPTN"))
							return;
						PartName.ReadBinary(reader);
						break;
					case "BPNN":
						if (readTags.Contains("BPNN"))
							return;
						BodyPart.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (PartName != null)
				PartName.WriteBinary(writer);
			if (BodyPart != null)
				BodyPart.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (PartName != null)		
			{		
				ele.TryPathTo("PartName", true, out subEle);
				PartName.WriteXML(subEle, master);
			}
			if (BodyPart != null)		
			{		
				ele.TryPathTo("BodyPart", true, out subEle);
				BodyPart.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("PartName", false, out subEle))
			{
				if (PartName == null)
					PartName = new SimpleSubrecord<String>();
					
				PartName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BodyPart", false, out subEle))
			{
				if (BodyPart == null)
					BodyPart = new BodyPart();
					
				BodyPart.ReadXML(subEle, master);
			}
		}

		public NamedBodyPart Clone()
		{
			return new NamedBodyPart(this);
		}

	}
}
