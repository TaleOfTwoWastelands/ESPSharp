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
	public partial class HeadData : SubrecordCollection
	{
		public SimpleSubrecord<UInt32> Index { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
	
		public override void ReadBinary(ESPReader reader)
		{
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "INDX":
						if (Index == null)
							Index = new SimpleSubrecord<UInt32>();
						else
							return;

						Index.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();
						else
							return;

						break;
					case "ICON":
						if (LargeIcon == null)
							LargeIcon = new SimpleSubrecord<String>();
						else
							return;

						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();
						else
							return;

						SmallIcon.ReadBinary(reader);
						break;
				default:
					return;
				}
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Index != null)
				Index.WriteBinary(writer);
			if (Model != null)
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;
			if (Index != null)		
			{		
				ele.TryPathTo("Index", true, out subEle);
				Index.WriteXML(subEle);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon\\Large", true, out subEle);
				LargeIcon.WriteXML(subEle);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon\\Small", true, out subEle);
				SmallIcon.WriteXML(subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Index", false, out subEle))
			{
				if (Index == null)
					Index = new SimpleSubrecord<UInt32>();
					
				Index.ReadXML(subEle);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
			}
			if (ele.TryPathTo("Icon\\Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("Icon\\Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle);
			}
		}

	}
}
