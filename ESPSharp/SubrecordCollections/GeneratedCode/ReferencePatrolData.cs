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
	public partial class ReferencePatrolData : SubrecordCollection	{
		public SimpleSubrecord<Single> IdleTime { get; set; }
		public SubMarker ScriptMarker { get; set; }
		public RecordReference Idle { get; set; }
		public EmbeddedScript Script { get; set; }
		public RecordReference Topic { get; set; }

		public ReferencePatrolData()
		{
			IdleTime = new SimpleSubrecord<Single>();
		}

		public ReferencePatrolData(SimpleSubrecord<Single> IdleTime, SubMarker ScriptMarker, RecordReference Idle, EmbeddedScript Script, RecordReference Topic)
		{
			this.IdleTime = IdleTime;
			this.ScriptMarker = ScriptMarker;
			this.Idle = Idle;
			this.Script = Script;
			this.Topic = Topic;
		}

		public ReferencePatrolData(ReferencePatrolData copyObject)
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
					case "XPRD":
						if (readTags.Contains("XPRD"))
							return;
						IdleTime.ReadBinary(reader);
						break;
					case "XPPA":
						if (readTags.Contains("XPPA"))
							return;
						if (ScriptMarker == null)
							ScriptMarker = new SubMarker();

						ScriptMarker.ReadBinary(reader);
						break;
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
			if (IdleTime != null)
				IdleTime.WriteBinary(writer);
			if (ScriptMarker != null)
				ScriptMarker.WriteBinary(writer);
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

			if (IdleTime != null)		
			{		
				ele.TryPathTo("IdleTime", true, out subEle);
				IdleTime.WriteXML(subEle, master);
			}
			if (ScriptMarker != null)		
			{		
				ele.TryPathTo("ScriptMarker", true, out subEle);
				ScriptMarker.WriteXML(subEle, master);
			}
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
			
			if (ele.TryPathTo("IdleTime", false, out subEle))
			{
				if (IdleTime == null)
					IdleTime = new SimpleSubrecord<Single>();
					
				IdleTime.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScriptMarker", false, out subEle))
			{
				if (ScriptMarker == null)
					ScriptMarker = new SubMarker();
					
				ScriptMarker.ReadXML(subEle, master);
			}
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

		public ReferencePatrolData Clone()
		{
			return new ReferencePatrolData(this);
		}

	}
}
