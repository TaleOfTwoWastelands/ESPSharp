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
	public partial class EmbeddedScript : SubrecordCollection	{
		public ScriptData Data { get; set; }
		public SimpleSubrecord<Byte[]> CompiledScript { get; set; }
		public SimpleSubrecord<Char[]> ScriptSource { get; set; }
		public List<LocalVariable> LocalVariables { get; set; }
		public List<Subrecord> References { get; set; }

		public EmbeddedScript()
		{
			Data = new ScriptData();
		}

		public EmbeddedScript(ScriptData Data, SimpleSubrecord<Byte[]> CompiledScript, SimpleSubrecord<Char[]> ScriptSource, List<LocalVariable> LocalVariables, List<Subrecord> References)
		{
			this.Data = Data;
			this.CompiledScript = CompiledScript;
			this.ScriptSource = ScriptSource;
			this.LocalVariables = LocalVariables;
			this.References = References;
		}

		public EmbeddedScript(EmbeddedScript copyObject)
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
					case "SCHR":
						if (readTags.Contains("SCHR"))
							return;
						Data.ReadBinary(reader);
						break;
					case "SCDA":
						if (readTags.Contains("SCDA"))
							return;
						if (CompiledScript == null)
							CompiledScript = new SimpleSubrecord<Byte[]>();

						CompiledScript.ReadBinary(reader);
						break;
					case "SCTX":
						if (readTags.Contains("SCTX"))
							return;
						if (ScriptSource == null)
							ScriptSource = new SimpleSubrecord<Char[]>();

						ScriptSource.ReadBinary(reader);
						break;
					case "SLSD":
						if (LocalVariables == null)
							LocalVariables = new List<LocalVariable>();

						LocalVariable tempSLSD = new LocalVariable();
						tempSLSD.ReadBinary(reader);
						LocalVariables.Add(tempSLSD);
						break;
					case "DUMY":
						ReadReferences(reader);
						break;
					case "SCRV":
						ReadLocalReference(reader);
						break;
					case "SCRO":
						ReadGlobalReference(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Data != null)
				Data.WriteBinary(writer);
			if (CompiledScript != null)
				CompiledScript.WriteBinary(writer);
			if (ScriptSource != null)
				ScriptSource.WriteBinary(writer);
			if (LocalVariables != null)
				foreach (var item in LocalVariables)
					item.WriteBinary(writer);

			WriteReferences(writer);

			WriteLocalReference(writer);

			WriteGlobalReference(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (CompiledScript != null)		
			{		
				ele.TryPathTo("CompiledScript", true, out subEle);
				CompiledScript.WriteXML(subEle, master);
			}
			if (ScriptSource != null)		
			{		
				ele.TryPathTo("ScriptSource", true, out subEle);
				ScriptSource.WriteXML(subEle, master);
			}
			if (LocalVariables != null)		
			{		
				ele.TryPathTo("LocalVariables", true, out subEle);
				foreach (var entry in LocalVariables)
				{
					XElement newEle = new XElement("Variable");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}

			WriteReferencesXML(ele, master);


			WriteLocalReferenceXML(ele, master);


			WriteGlobalReferenceXML(ele, master);

		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ScriptData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CompiledScript", false, out subEle))
			{
				if (CompiledScript == null)
					CompiledScript = new SimpleSubrecord<Byte[]>();
					
				CompiledScript.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScriptSource", false, out subEle))
			{
				if (ScriptSource == null)
					ScriptSource = new SimpleSubrecord<Char[]>();
					
				ScriptSource.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LocalVariables", false, out subEle))
			{
				if (LocalVariables == null)
					LocalVariables = new List<LocalVariable>();
					
				foreach (XElement e in subEle.Elements())
				{
					LocalVariable temp = new LocalVariable();
					temp.ReadXML(e, master);
					LocalVariables.Add(temp);
				}
			}

			ReadReferencesXML(ele, master);


			ReadLocalReferenceXML(ele, master);


			ReadGlobalReferenceXML(ele, master);

		}

		public EmbeddedScript Clone()
		{
			return new EmbeddedScript(this);
		}

		partial void ReadReferences(ESPReader reader);
		partial void ReadLocalReference(ESPReader reader);
		partial void ReadGlobalReference(ESPReader reader);
		partial void WriteReferences(ESPWriter writer);
		partial void WriteLocalReference(ESPWriter writer);
		partial void WriteGlobalReference(ESPWriter writer);
		partial void WriteReferencesXML(XElement ele, ElderScrollsPlugin master);
		partial void WriteLocalReferenceXML(XElement ele, ElderScrollsPlugin master);
		partial void WriteGlobalReferenceXML(XElement ele, ElderScrollsPlugin master);
		partial void ReadReferencesXML(XElement ele, ElderScrollsPlugin master);
		partial void ReadLocalReferenceXML(XElement ele, ElderScrollsPlugin master);
		partial void ReadGlobalReferenceXML(XElement ele, ElderScrollsPlugin master);
	}
}
