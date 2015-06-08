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
	public partial class Icon : SubrecordCollection, ICloneable<Icon>
	{
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }

		public Icon()
		{
			LargeIcon = new SimpleSubrecord<String>();
		}

		public Icon(SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon)
		{
			this.LargeIcon = LargeIcon;
			this.SmallIcon = SmallIcon;
		}

		public Icon(Icon copyObject)
		{
			LargeIcon = copyObject.LargeIcon.Clone();
			SmallIcon = copyObject.SmallIcon.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "ICON":
						if (readTags.Contains("ICON"))
							return;
						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (readTags.Contains("MICO"))
							return;
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();

						SmallIcon.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("LargeIcon", true, out subEle);
				LargeIcon.WriteXML(subEle);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("SmallIcon", true, out subEle);
				SmallIcon.WriteXML(subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("LargeIcon", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle);
			}
			if (ele.TryPathTo("SmallIcon", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle);
			}
		}

		public Icon Clone()
		{
			return new Icon(this);
		}

	}
}
