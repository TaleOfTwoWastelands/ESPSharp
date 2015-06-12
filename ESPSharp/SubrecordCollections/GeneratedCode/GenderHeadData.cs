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
	public partial class GenderHeadData : SubrecordCollection, ICloneable<GenderHeadData>
	{
		public SubMarker Marker { get; set; }
		public List<HeadModel> HeadModels { get; set; }

		public GenderHeadData()
		{
			Marker = new SubMarker();
		}

		public GenderHeadData(List<HeadModel> HeadModels)
		{
			this.HeadModels = HeadModels;
		}

		public GenderHeadData(GenderHeadData copyObject)
		{
			HeadModels = new List<HeadModel>();
			foreach (var item in copyObject.HeadModels)
			{
				HeadModels.Add(item.Clone());
			}
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
						if (HeadModels == null)
							HeadModels = new List<HeadModel>();

						HeadModel tempINDX = new HeadModel();
						tempINDX.ReadBinary(reader);
						HeadModels.Add(tempINDX);
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

			if (HeadModels != null)
				foreach (var item in HeadModels)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (HeadModels != null)		
			{		
				ele.TryPathTo("HeadModels", true, out subEle);
				foreach (var entry in HeadModels)
				{
					XElement newEle = new XElement("HeadModel");
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

			if (ele.TryPathTo("HeadModels", false, out subEle))
			{
				if (HeadModels == null)
					HeadModels = new List<HeadModel>();
					
				foreach (XElement e in subEle.Elements())
				{
					HeadModel temp = new HeadModel();
					temp.ReadXML(e, master);
					HeadModels.Add(temp);
				}
			}
		}

		public GenderHeadData Clone()
		{
			return new GenderHeadData(this);
		}

	}
}
