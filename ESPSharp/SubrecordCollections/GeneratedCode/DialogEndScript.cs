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
	public partial class DialogEndScript : SubrecordCollection	{
		public SubMarker EndScriptMarker { get; set; }
		public EmbeddedScript EmbeddedScript { get; set; }

		public DialogEndScript()
		{
		}

		public DialogEndScript(SubMarker EndScriptMarker, EmbeddedScript EmbeddedScript)
		{
			this.EndScriptMarker = EndScriptMarker;
			this.EmbeddedScript = EmbeddedScript;
		}

		public DialogEndScript(DialogEndScript copyObject)
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
					case "NEXT":
						if (readTags.Contains("NEXT"))
							return;
						if (EndScriptMarker == null)
							EndScriptMarker = new SubMarker();

						EndScriptMarker.ReadBinary(reader);
						break;
					case "SCHR":
						if (readTags.Contains("SCHR"))
							return;
						if (EmbeddedScript == null)
							EmbeddedScript = new EmbeddedScript();

						EmbeddedScript.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (EndScriptMarker != null)
				EndScriptMarker.WriteBinary(writer);
			if (EmbeddedScript != null)
				EmbeddedScript.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (EndScriptMarker != null)		
			{		
				ele.TryPathTo("EndScriptMarker", true, out subEle);
				EndScriptMarker.WriteXML(subEle, master);
			}
			if (EmbeddedScript != null)		
			{		
				ele.TryPathTo("EmbeddedScript", true, out subEle);
				EmbeddedScript.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("EndScriptMarker", false, out subEle))
			{
				if (EndScriptMarker == null)
					EndScriptMarker = new SubMarker();
					
				EndScriptMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EmbeddedScript", false, out subEle))
			{
				if (EmbeddedScript == null)
					EmbeddedScript = new EmbeddedScript();
					
				EmbeddedScript.ReadXML(subEle, master);
			}
		}

		public DialogEndScript Clone()
		{
			return new DialogEndScript(this);
		}

	}
}
