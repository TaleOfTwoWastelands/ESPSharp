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
	public partial class GenderBodyData : SubrecordCollection	{
		public SubMarker Marker { get; set; }
		public List<BodyModel> BodyModels { get; set; }

		public GenderBodyData()
		{
			Marker = new SubMarker();
		}

		public GenderBodyData(List<BodyModel> BodyModels)
		{
			this.BodyModels = BodyModels;
		}

		public GenderBodyData(GenderBodyData copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			readTags.Add(reader.PeekTag());
			Marker.ReadBinary(reader);

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "INDX":
						if (BodyModels == null)
							BodyModels = new List<BodyModel>();

						BodyModel tempINDX = new BodyModel();
						tempINDX.ReadBinary(reader);
						BodyModels.Add(tempINDX);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			Marker.WriteBinary(writer);

			if (BodyModels != null)
				foreach (var item in BodyModels)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (BodyModels != null)		
			{		
				ele.TryPathTo("BodyModels", true, out subEle);
				foreach (var entry in BodyModels)
				{
					XElement newEle = new XElement("BodyModel");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("BodyModels", false, out subEle))
			{
				if (BodyModels == null)
					BodyModels = new List<BodyModel>();
					
				foreach (XElement e in subEle.Elements())
				{
					BodyModel temp = new BodyModel();
					temp.ReadXML(e, master);
					BodyModels.Add(temp);
				}
			}
		}

		public GenderBodyData Clone()
		{
			return new GenderBodyData(this);
		}

	}
}
