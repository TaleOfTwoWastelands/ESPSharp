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
	public partial class Response : SubrecordCollection	{
		public ResponseData ResponseData { get; set; }
		public SimpleSubrecord<String> ResponseText { get; set; }
		public SimpleSubrecord<String> ScriptNotes { get; set; }
		public SimpleSubrecord<String> Edits { get; set; }
		public RecordReference SpeakerAnimation { get; set; }
		public RecordReference ListenerAnimation { get; set; }

		public Response()
		{
		}

		public Response(ResponseData ResponseData, SimpleSubrecord<String> ResponseText, SimpleSubrecord<String> ScriptNotes, SimpleSubrecord<String> Edits, RecordReference SpeakerAnimation, RecordReference ListenerAnimation)
		{
			this.ResponseData = ResponseData;
			this.ResponseText = ResponseText;
			this.ScriptNotes = ScriptNotes;
			this.Edits = Edits;
			this.SpeakerAnimation = SpeakerAnimation;
			this.ListenerAnimation = ListenerAnimation;
		}

		public Response(Response copyObject)
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
					case "TRDT":
						if (readTags.Contains("TRDT"))
							return;
						if (ResponseData == null)
							ResponseData = new ResponseData();

						ResponseData.ReadBinary(reader);
						break;
					case "NAM1":
						if (readTags.Contains("NAM1"))
							return;
						if (ResponseText == null)
							ResponseText = new SimpleSubrecord<String>();

						ResponseText.ReadBinary(reader);
						break;
					case "NAM2":
						if (readTags.Contains("NAM2"))
							return;
						if (ScriptNotes == null)
							ScriptNotes = new SimpleSubrecord<String>();

						ScriptNotes.ReadBinary(reader);
						break;
					case "NAM3":
						if (readTags.Contains("NAM3"))
							return;
						if (Edits == null)
							Edits = new SimpleSubrecord<String>();

						Edits.ReadBinary(reader);
						break;
					case "SNAM":
						if (readTags.Contains("SNAM"))
							return;
						if (SpeakerAnimation == null)
							SpeakerAnimation = new RecordReference();

						SpeakerAnimation.ReadBinary(reader);
						break;
					case "LNAM":
						if (readTags.Contains("LNAM"))
							return;
						if (ListenerAnimation == null)
							ListenerAnimation = new RecordReference();

						ListenerAnimation.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (ResponseData != null)
				ResponseData.WriteBinary(writer);
			if (ResponseText != null)
				ResponseText.WriteBinary(writer);
			if (ScriptNotes != null)
				ScriptNotes.WriteBinary(writer);
			if (Edits != null)
				Edits.WriteBinary(writer);
			if (SpeakerAnimation != null)
				SpeakerAnimation.WriteBinary(writer);
			if (ListenerAnimation != null)
				ListenerAnimation.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ResponseData != null)		
			{		
				ele.TryPathTo("ResponseData", true, out subEle);
				ResponseData.WriteXML(subEle, master);
			}
			if (ResponseText != null)		
			{		
				ele.TryPathTo("ResponseText", true, out subEle);
				ResponseText.WriteXML(subEle, master);
			}
			if (ScriptNotes != null)		
			{		
				ele.TryPathTo("ScriptNotes", true, out subEle);
				ScriptNotes.WriteXML(subEle, master);
			}
			if (Edits != null)		
			{		
				ele.TryPathTo("Edits", true, out subEle);
				Edits.WriteXML(subEle, master);
			}
			if (SpeakerAnimation != null)		
			{		
				ele.TryPathTo("SpeakerAnimation", true, out subEle);
				SpeakerAnimation.WriteXML(subEle, master);
			}
			if (ListenerAnimation != null)		
			{		
				ele.TryPathTo("ListenerAnimation", true, out subEle);
				ListenerAnimation.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ResponseData", false, out subEle))
			{
				if (ResponseData == null)
					ResponseData = new ResponseData();
					
				ResponseData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ResponseText", false, out subEle))
			{
				if (ResponseText == null)
					ResponseText = new SimpleSubrecord<String>();
					
				ResponseText.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScriptNotes", false, out subEle))
			{
				if (ScriptNotes == null)
					ScriptNotes = new SimpleSubrecord<String>();
					
				ScriptNotes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Edits", false, out subEle))
			{
				if (Edits == null)
					Edits = new SimpleSubrecord<String>();
					
				Edits.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SpeakerAnimation", false, out subEle))
			{
				if (SpeakerAnimation == null)
					SpeakerAnimation = new RecordReference();
					
				SpeakerAnimation.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ListenerAnimation", false, out subEle))
			{
				if (ListenerAnimation == null)
					ListenerAnimation = new RecordReference();
					
				ListenerAnimation.ReadXML(subEle, master);
			}
		}

		public Response Clone()
		{
			return new Response(this);
		}

	}
}
