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
	public partial class RaceBodyData : SubrecordCollection	{
		public SubMarker Marker { get; set; }
		public GenderBodyData Male { get; set; }
		public GenderBodyData Female { get; set; }

		public RaceBodyData()
		{
			Marker = new SubMarker();
			Male = new GenderBodyData();
			Female = new GenderBodyData();
		}

		public RaceBodyData(GenderBodyData Male, GenderBodyData Female)
		{
			this.Male = Male;
			this.Female = Female;
		}

		public RaceBodyData(RaceBodyData copyObject)
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
					case "MNAM":
						if (readTags.Contains("MNAM"))
							return;
						Male.ReadBinary(reader);
						break;
					case "FNAM":
						if (readTags.Contains("FNAM"))
							return;
						Female.ReadBinary(reader);
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

			if (Male != null)
				Male.WriteBinary(writer);
			if (Female != null)
				Female.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (Male != null)		
			{		
				ele.TryPathTo("Male", true, out subEle);
				Male.WriteXML(subEle, master);
			}
			if (Female != null)		
			{		
				ele.TryPathTo("Female", true, out subEle);
				Female.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("Male", false, out subEle))
			{
				if (Male == null)
					Male = new GenderBodyData();
					
				Male.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Female", false, out subEle))
			{
				if (Female == null)
					Female = new GenderBodyData();
					
				Female.ReadXML(subEle, master);
			}
		}

		public RaceBodyData Clone()
		{
			return new RaceBodyData(this);
		}

	}
}
