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
	public partial class ReferenceAudio : SubrecordCollection	{
		public SubMarker Marker { get; set; }
		public SimpleSubrecord<Byte[]> Unknown1 { get; set; }
		public RecordReference AudioLocation { get; set; }
		public SimpleSubrecord<Byte[]> Unknown2 { get; set; }
		public SimpleSubrecord<Single> Unknown3 { get; set; }
		public SimpleSubrecord<Single> Unknown4 { get; set; }

		public ReferenceAudio()
		{
			Marker = new SubMarker();
		}

		public ReferenceAudio(SimpleSubrecord<Byte[]> Unknown1, RecordReference AudioLocation, SimpleSubrecord<Byte[]> Unknown2, SimpleSubrecord<Single> Unknown3, SimpleSubrecord<Single> Unknown4)
		{
			this.Unknown1 = Unknown1;
			this.AudioLocation = AudioLocation;
			this.Unknown2 = Unknown2;
			this.Unknown3 = Unknown3;
			this.Unknown4 = Unknown4;
		}

		public ReferenceAudio(ReferenceAudio copyObject)
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
					case "FULL":
						if (readTags.Contains("FULL"))
							return;
						if (Unknown1 == null)
							Unknown1 = new SimpleSubrecord<Byte[]>();

						Unknown1.ReadBinary(reader);
						break;
					case "CNAM":
						if (readTags.Contains("CNAM"))
							return;
						if (AudioLocation == null)
							AudioLocation = new RecordReference();

						AudioLocation.ReadBinary(reader);
						break;
					case "BNAM":
						if (readTags.Contains("BNAM"))
							return;
						if (Unknown2 == null)
							Unknown2 = new SimpleSubrecord<Byte[]>();

						Unknown2.ReadBinary(reader);
						break;
					case "MNAM":
						if (readTags.Contains("MNAM"))
							return;
						if (Unknown3 == null)
							Unknown3 = new SimpleSubrecord<Single>();

						Unknown3.ReadBinary(reader);
						break;
					case "NNAM":
						if (readTags.Contains("NNAM"))
							return;
						if (Unknown4 == null)
							Unknown4 = new SimpleSubrecord<Single>();

						Unknown4.ReadBinary(reader);
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

			if (Unknown1 != null)
				Unknown1.WriteBinary(writer);
			if (AudioLocation != null)
				AudioLocation.WriteBinary(writer);
			if (Unknown2 != null)
				Unknown2.WriteBinary(writer);
			if (Unknown3 != null)
				Unknown3.WriteBinary(writer);
			if (Unknown4 != null)
				Unknown4.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (Unknown1 != null)		
			{		
				ele.TryPathTo("Unknown1", true, out subEle);
				Unknown1.WriteXML(subEle, master);
			}
			if (AudioLocation != null)		
			{		
				ele.TryPathTo("AudioLocation", true, out subEle);
				AudioLocation.WriteXML(subEle, master);
			}
			if (Unknown2 != null)		
			{		
				ele.TryPathTo("Unknown2", true, out subEle);
				Unknown2.WriteXML(subEle, master);
			}
			if (Unknown3 != null)		
			{		
				ele.TryPathTo("Unknown3", true, out subEle);
				Unknown3.WriteXML(subEle, master);
			}
			if (Unknown4 != null)		
			{		
				ele.TryPathTo("Unknown4", true, out subEle);
				Unknown4.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				if (Unknown1 == null)
					Unknown1 = new SimpleSubrecord<Byte[]>();
					
				Unknown1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AudioLocation", false, out subEle))
			{
				if (AudioLocation == null)
					AudioLocation = new RecordReference();
					
				AudioLocation.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				if (Unknown2 == null)
					Unknown2 = new SimpleSubrecord<Byte[]>();
					
				Unknown2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown3", false, out subEle))
			{
				if (Unknown3 == null)
					Unknown3 = new SimpleSubrecord<Single>();
					
				Unknown3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown4", false, out subEle))
			{
				if (Unknown4 == null)
					Unknown4 = new SimpleSubrecord<Single>();
					
				Unknown4.ReadXML(subEle, master);
			}
		}

		public ReferenceAudio Clone()
		{
			return new ReferenceAudio(this);
		}

	}
}
