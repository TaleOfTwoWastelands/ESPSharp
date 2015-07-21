
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

namespace ESPSharp.Records
{
	public partial class DialogResponse : Record
	{
		public DialogResponseData Data { get; set; }
		public RecordReference Quest { get; set; }
		public RecordReference Topic { get; set; }
		public RecordReference PreviousDialogResponse { get; set; }
		public List<RecordReference> LearnedTopics { get; set; }
		public List<Response> Responses { get; set; }
		public List<Condition> Conditions { get; set; }
		public List<RecordReference> Choices { get; set; }
		public List<RecordReference> LinkedFromList { get; set; }
		public List<RecordReference> UnknownList { get; set; }
		public EmbeddedScript BeginScript { get; set; }
		public DialogEndScript EndScript { get; set; }
		public RecordReference UnusedSound { get; set; }
		public SimpleSubrecord<String> Prompt { get; set; }
		public RecordReference Speaker { get; set; }
		public RecordReference RelatedSkillOrPerk { get; set; }
		public SimpleSubrecord<SpeechChallengeType> SpeechChallenge { get; set; }

		public DialogResponse()
		{
			Data = new DialogResponseData("DATA");
			Quest = new RecordReference("QSTI");
		}

		public DialogResponse(DialogResponseData Data, RecordReference Quest, RecordReference Topic, RecordReference PreviousDialogResponse, List<RecordReference> LearnedTopics, List<Response> Responses, List<Condition> Conditions, List<RecordReference> Choices, List<RecordReference> LinkedFromList, List<RecordReference> UnknownList, EmbeddedScript BeginScript, DialogEndScript EndScript, RecordReference UnusedSound, SimpleSubrecord<String> Prompt, RecordReference Speaker, RecordReference RelatedSkillOrPerk, SimpleSubrecord<SpeechChallengeType> SpeechChallenge)
		{
			this.Data = Data;
			this.Quest = Quest;
		}

		public DialogResponse(DialogResponse copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "DATA":
						if (Data == null)
							Data = new DialogResponseData();

						Data.ReadBinary(reader);
						break;
					case "QSTI":
						if (Quest == null)
							Quest = new RecordReference();

						Quest.ReadBinary(reader);
						break;
					case "TPIC":
						if (Topic == null)
							Topic = new RecordReference();

						Topic.ReadBinary(reader);
						break;
					case "PNAM":
						if (PreviousDialogResponse == null)
							PreviousDialogResponse = new RecordReference();

						PreviousDialogResponse.ReadBinary(reader);
						break;
					case "NAME":
						if (LearnedTopics == null)
							LearnedTopics = new List<RecordReference>();

						RecordReference tempNAME = new RecordReference();
						tempNAME.ReadBinary(reader);
						LearnedTopics.Add(tempNAME);
						break;
					case "TRDT":
						if (Responses == null)
							Responses = new List<Response>();

						Response tempTRDT = new Response();
						tempTRDT.ReadBinary(reader);
						Responses.Add(tempTRDT);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "TCLT":
						if (Choices == null)
							Choices = new List<RecordReference>();

						RecordReference tempTCLT = new RecordReference();
						tempTCLT.ReadBinary(reader);
						Choices.Add(tempTCLT);
						break;
					case "TCLF":
						if (LinkedFromList == null)
							LinkedFromList = new List<RecordReference>();

						RecordReference tempTCLF = new RecordReference();
						tempTCLF.ReadBinary(reader);
						LinkedFromList.Add(tempTCLF);
						break;
					case "TCFU":
						if (UnknownList == null)
							UnknownList = new List<RecordReference>();

						RecordReference tempTCFU = new RecordReference();
						tempTCFU.ReadBinary(reader);
						UnknownList.Add(tempTCFU);
						break;
					case "SCHR":
						if (BeginScript == null)
							BeginScript = new EmbeddedScript();

						BeginScript.ReadBinary(reader);
						break;
					case "NEXT":
						if (EndScript == null)
							EndScript = new DialogEndScript();

						EndScript.ReadBinary(reader);
						break;
					case "SNDD":
						if (UnusedSound == null)
							UnusedSound = new RecordReference();

						UnusedSound.ReadBinary(reader);
						break;
					case "RNAM":
						if (Prompt == null)
							Prompt = new SimpleSubrecord<String>();

						Prompt.ReadBinary(reader);
						break;
					case "ANAM":
						if (Speaker == null)
							Speaker = new RecordReference();

						Speaker.ReadBinary(reader);
						break;
					case "KNAM":
						if (RelatedSkillOrPerk == null)
							RelatedSkillOrPerk = new RecordReference();

						RelatedSkillOrPerk.ReadBinary(reader);
						break;
					case "DNAM":
						if (SpeechChallenge == null)
							SpeechChallenge = new SimpleSubrecord<SpeechChallengeType>();

						SpeechChallenge.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (Data != null)
				Data.WriteBinary(writer);
			if (Quest != null)
				Quest.WriteBinary(writer);
			if (Topic != null)
				Topic.WriteBinary(writer);
			if (PreviousDialogResponse != null)
				PreviousDialogResponse.WriteBinary(writer);
			if (LearnedTopics != null)
				foreach (var item in LearnedTopics)
					item.WriteBinary(writer);
			if (Responses != null)
				foreach (var item in Responses)
					item.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (Choices != null)
				foreach (var item in Choices)
					item.WriteBinary(writer);
			if (LinkedFromList != null)
				foreach (var item in LinkedFromList)
					item.WriteBinary(writer);
			if (UnknownList != null)
				foreach (var item in UnknownList)
					item.WriteBinary(writer);
			if (BeginScript != null)
				BeginScript.WriteBinary(writer);
			if (EndScript != null)
				EndScript.WriteBinary(writer);
			if (UnusedSound != null)
				UnusedSound.WriteBinary(writer);
			if (Prompt != null)
				Prompt.WriteBinary(writer);
			if (Speaker != null)
				Speaker.WriteBinary(writer);
			if (RelatedSkillOrPerk != null)
				RelatedSkillOrPerk.WriteBinary(writer);
			if (SpeechChallenge != null)
				SpeechChallenge.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Quest != null)		
			{		
				ele.TryPathTo("Quest", true, out subEle);
				Quest.WriteXML(subEle, master);
			}
			if (Topic != null)		
			{		
				ele.TryPathTo("Topic", true, out subEle);
				Topic.WriteXML(subEle, master);
			}
			if (PreviousDialogResponse != null)		
			{		
				ele.TryPathTo("PreviousDialogResponse", true, out subEle);
				PreviousDialogResponse.WriteXML(subEle, master);
			}
			if (LearnedTopics != null)		
			{		
				ele.TryPathTo("LearnedTopics", true, out subEle);
				List<string> xmlNames = new List<string>{"Topic"};
				int i = 0;
				foreach (var entry in LearnedTopics)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Responses != null)		
			{		
				ele.TryPathTo("Responses", true, out subEle);
				List<string> xmlNames = new List<string>{"Response"};
				int i = 0;
				foreach (var entry in Responses)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				List<string> xmlNames = new List<string>{"Condition"};
				int i = 0;
				foreach (var entry in Conditions)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Choices != null)		
			{		
				ele.TryPathTo("Choices", true, out subEle);
				List<string> xmlNames = new List<string>{"Choice"};
				int i = 0;
				foreach (var entry in Choices)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (LinkedFromList != null)		
			{		
				ele.TryPathTo("LinkedFromList", true, out subEle);
				List<string> xmlNames = new List<string>{"LinkedFrom"};
				int i = 0;
				foreach (var entry in LinkedFromList)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (UnknownList != null)		
			{		
				ele.TryPathTo("UnknownList", true, out subEle);
				List<string> xmlNames = new List<string>{"Unknown"};
				int i = 0;
				foreach (var entry in UnknownList)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (BeginScript != null)		
			{		
				ele.TryPathTo("BeginScript", true, out subEle);
				BeginScript.WriteXML(subEle, master);
			}
			if (EndScript != null)		
			{		
				ele.TryPathTo("EndScript", true, out subEle);
				EndScript.WriteXML(subEle, master);
			}
			if (UnusedSound != null)		
			{		
				ele.TryPathTo("UnusedSound", true, out subEle);
				UnusedSound.WriteXML(subEle, master);
			}
			if (Prompt != null)		
			{		
				ele.TryPathTo("Prompt", true, out subEle);
				Prompt.WriteXML(subEle, master);
			}
			if (Speaker != null)		
			{		
				ele.TryPathTo("Speaker", true, out subEle);
				Speaker.WriteXML(subEle, master);
			}
			if (RelatedSkillOrPerk != null)		
			{		
				ele.TryPathTo("RelatedSkillOrPerk", true, out subEle);
				RelatedSkillOrPerk.WriteXML(subEle, master);
			}
			if (SpeechChallenge != null)		
			{		
				ele.TryPathTo("SpeechChallenge", true, out subEle);
				SpeechChallenge.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new DialogResponseData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Quest", false, out subEle))
			{
				if (Quest == null)
					Quest = new RecordReference();
					
				Quest.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Topic", false, out subEle))
			{
				if (Topic == null)
					Topic = new RecordReference();
					
				Topic.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PreviousDialogResponse", false, out subEle))
			{
				if (PreviousDialogResponse == null)
					PreviousDialogResponse = new RecordReference();
					
				PreviousDialogResponse.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LearnedTopics", false, out subEle))
			{
				if (LearnedTopics == null)
					LearnedTopics = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempNAME = new RecordReference();
					tempNAME.ReadXML(e, master);
					LearnedTopics.Add(tempNAME);
				}
			}
			if (ele.TryPathTo("Responses", false, out subEle))
			{
				if (Responses == null)
					Responses = new List<Response>();
					
				foreach (XElement e in subEle.Elements())
				{
					Response tempTRDT = new Response();
					tempTRDT.ReadXML(e, master);
					Responses.Add(tempTRDT);
				}
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition tempCTDA = new Condition();
					tempCTDA.ReadXML(e, master);
					Conditions.Add(tempCTDA);
				}
			}
			if (ele.TryPathTo("Choices", false, out subEle))
			{
				if (Choices == null)
					Choices = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempTCLT = new RecordReference();
					tempTCLT.ReadXML(e, master);
					Choices.Add(tempTCLT);
				}
			}
			if (ele.TryPathTo("LinkedFromList", false, out subEle))
			{
				if (LinkedFromList == null)
					LinkedFromList = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempTCLF = new RecordReference();
					tempTCLF.ReadXML(e, master);
					LinkedFromList.Add(tempTCLF);
				}
			}
			if (ele.TryPathTo("UnknownList", false, out subEle))
			{
				if (UnknownList == null)
					UnknownList = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempTCFU = new RecordReference();
					tempTCFU.ReadXML(e, master);
					UnknownList.Add(tempTCFU);
				}
			}
			if (ele.TryPathTo("BeginScript", false, out subEle))
			{
				if (BeginScript == null)
					BeginScript = new EmbeddedScript();
					
				BeginScript.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EndScript", false, out subEle))
			{
				if (EndScript == null)
					EndScript = new DialogEndScript();
					
				EndScript.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("UnusedSound", false, out subEle))
			{
				if (UnusedSound == null)
					UnusedSound = new RecordReference();
					
				UnusedSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Prompt", false, out subEle))
			{
				if (Prompt == null)
					Prompt = new SimpleSubrecord<String>();
					
				Prompt.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Speaker", false, out subEle))
			{
				if (Speaker == null)
					Speaker = new RecordReference();
					
				Speaker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RelatedSkillOrPerk", false, out subEle))
			{
				if (RelatedSkillOrPerk == null)
					RelatedSkillOrPerk = new RecordReference();
					
				RelatedSkillOrPerk.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SpeechChallenge", false, out subEle))
			{
				if (SpeechChallenge == null)
					SpeechChallenge = new SimpleSubrecord<SpeechChallengeType>();
					
				SpeechChallenge.ReadXML(subEle, master);
			}
		}		

		public DialogResponse Clone()
		{
			return new DialogResponse(this);
		}

	}
}