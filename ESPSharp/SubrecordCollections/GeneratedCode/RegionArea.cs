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
	public partial class RegionArea : SubrecordCollection	{
		public SimpleSubrecord<UInt32> EdgeFallOff { get; set; }
		public RegionPointList PointList { get; set; }

		public RegionArea()
		{
		}

		public RegionArea(SimpleSubrecord<UInt32> EdgeFallOff, RegionPointList PointList)
		{
			this.EdgeFallOff = EdgeFallOff;
			this.PointList = PointList;
		}

		public RegionArea(RegionArea copyObject)
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
					case "RPLI":
						if (readTags.Contains("RPLI"))
							return;
						if (EdgeFallOff == null)
							EdgeFallOff = new SimpleSubrecord<UInt32>();

						EdgeFallOff.ReadBinary(reader);
						break;
					case "RPLD":
						if (readTags.Contains("RPLD"))
							return;
						if (PointList == null)
							PointList = new RegionPointList();

						PointList.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (EdgeFallOff != null)
				EdgeFallOff.WriteBinary(writer);
			if (PointList != null)
				PointList.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (EdgeFallOff != null)		
			{		
				ele.TryPathTo("EdgeFallOff", true, out subEle);
				EdgeFallOff.WriteXML(subEle, master);
			}
			if (PointList != null)		
			{		
				ele.TryPathTo("PointList", true, out subEle);
				PointList.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("EdgeFallOff", false, out subEle))
			{
				if (EdgeFallOff == null)
					EdgeFallOff = new SimpleSubrecord<UInt32>();
					
				EdgeFallOff.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PointList", false, out subEle))
			{
				if (PointList == null)
					PointList = new RegionPointList();
					
				PointList.ReadXML(subEle, master);
			}
		}

		public RegionArea Clone()
		{
			return new RegionArea(this);
		}

	}
}
