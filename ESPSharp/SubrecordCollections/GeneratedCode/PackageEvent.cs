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
	public partial class PackageEvent : SubrecordCollection, ICloneable<PackageEvent>, IReferenceContainer
	{
		public SubMarker Marker { get; set; }
		public RecordReference Idle { get; set; }
		public EmbeddedScript Script { get; set; }
		public RecordReference Topic { get; set; }

		public PackageEvent()
		{
			Marker = new SubMarker();
		}

		public PackageEvent(RecordReference Idle, EmbeddedScript Script, RecordReference Topic)
		{
			this.Idle = Idle;
			this.Script = Script;
			this.Topic = Topic;
		}

		public PackageEvent(PackageEvent copyObject)
		{
			Idle = copyObject.Idle.Clone();
			Script = copyObject.Script.Clone();
			Topic = copyObject.Topic.Clone();
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
					case "INAM":
						if (readTags.Contains("INAM"))
							return;
						if (Idle == null)
							Idle = new RecordReference();

						Idle.ReadBinary(reader);
						break;
					case "SCHR":
						if (readTags.Contains("SCHR"))
							return;
						if (Script == null)
							Script = new EmbeddedScript();

						Script.ReadBinary(reader);
						break;
					case "TNAM":
						if (readTags.Contains("TNAM"))
							return;
						if (Topic == null)
							Topic = new RecordReference();

						Topic.ReadBinary(reader);
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

			if (Idle != null)
				Idle.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (Topic != null)
				Topic.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (Idle != null)		
			{		
				ele.TryPathTo("Idle", true, out subEle);
				Idle.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (Topic != null)		
			{		
				ele.TryPathTo("Topic", true, out subEle);
				Topic.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("Idle", false, out subEle))
			{
				if (Idle == null)
					Idle = new RecordReference();
					
				Idle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new EmbeddedScript();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Topic", false, out subEle))
			{
				if (Topic == null)
					Topic = new RecordReference();
					
				Topic.ReadXML(subEle, master);
			}
		}

		public PackageEvent Clone()
		{
			return new PackageEvent(this);
		}

	}
}
