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
	public partial class EmbeddedScript : SubrecordCollection, ICloneable<EmbeddedScript>
	{
		public ScriptData Data { get; set; }
		public SimpleSubrecord<Byte[]> CompiledScript { get; set; }
		public SimpleSubrecord<Char[]> ScriptSource { get; set; }
		public List<LocalVariable> LocalVariables { get; set; }
		public List<SimpleSubrecord<UInt32>> LocalReferences { get; set; }
		public List<RecordReference> GlobalReferences { get; set; }

		public EmbeddedScript()
		{
			Data = new ScriptData();
			CompiledScript = new SimpleSubrecord<Byte[]>();
			ScriptSource = new SimpleSubrecord<Char[]>();
		}

		public EmbeddedScript(ScriptData Data, SimpleSubrecord<Byte[]> CompiledScript, SimpleSubrecord<Char[]> ScriptSource, List<LocalVariable> LocalVariables, List<SimpleSubrecord<UInt32>> LocalReferences, List<RecordReference> GlobalReferences)
		{
			this.Data = Data;
			this.CompiledScript = CompiledScript;
			this.ScriptSource = ScriptSource;
			this.LocalVariables = LocalVariables;
			this.LocalReferences = LocalReferences;
			this.GlobalReferences = GlobalReferences;
		}

		public EmbeddedScript(EmbeddedScript copyObject)
		{
			Data = copyObject.Data.Clone();
			CompiledScript = copyObject.CompiledScript.Clone();
			ScriptSource = copyObject.ScriptSource.Clone();
			LocalVariables = new List<LocalVariable>();
			foreach (var item in copyObject.LocalVariables)
			{
				LocalVariables.Add(item.Clone());
			}
			LocalReferences = new List<SimpleSubrecord<UInt32>>();
			foreach (var item in copyObject.LocalReferences)
			{
				LocalReferences.Add(item.Clone());
			}
			GlobalReferences = new List<RecordReference>();
			foreach (var item in copyObject.GlobalReferences)
			{
				GlobalReferences.Add(item.Clone());
			}
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
						CompiledScript.ReadBinary(reader);
						break;
					case "SCTX":
						if (readTags.Contains("SCTX"))
							return;
						ScriptSource.ReadBinary(reader);
						break;
					case "SLSD":
						if (LocalVariables == null)
							LocalVariables = new List<LocalVariable>();

						LocalVariable tempSLSD = new LocalVariable();
						tempSLSD.ReadBinary(reader);
						LocalVariables.Add(tempSLSD);
						break;
					case "SCRV":
						if (LocalReferences == null)
							LocalReferences = new List<SimpleSubrecord<UInt32>>();

						SimpleSubrecord<UInt32> tempSCRV = new SimpleSubrecord<UInt32>();
						tempSCRV.ReadBinary(reader);
						LocalReferences.Add(tempSCRV);
						break;
					case "SCRO":
						if (GlobalReferences == null)
							GlobalReferences = new List<RecordReference>();

						RecordReference tempSCRO = new RecordReference();
						tempSCRO.ReadBinary(reader);
						GlobalReferences.Add(tempSCRO);
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
			if (LocalReferences != null)
				foreach (var item in LocalReferences)
					item.WriteBinary(writer);
			if (GlobalReferences != null)
				foreach (var item in GlobalReferences)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;

			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (CompiledScript != null)		
			{		
				ele.TryPathTo("CompiledScript", true, out subEle);
				CompiledScript.WriteXML(subEle);
			}
			if (ScriptSource != null)		
			{		
				ele.TryPathTo("ScriptSource", true, out subEle);
				ScriptSource.WriteXML(subEle);
			}
			if (LocalVariables != null)		
			{		
				ele.TryPathTo("LocalVariables", true, out subEle);
				foreach (var entry in LocalVariables)
				{
					XElement newEle = new XElement("Variable");
					entry.WriteXML(newEle);
					subEle.Add(newEle);
				}
			}
			if (LocalReferences != null)		
			{		
				ele.TryPathTo("LocalReferences", true, out subEle);
				foreach (var entry in LocalReferences)
				{
					XElement newEle = new XElement("Reference");
					entry.WriteXML(newEle);
					subEle.Add(newEle);
				}
			}
			if (GlobalReferences != null)		
			{		
				ele.TryPathTo("GlobalReferences", true, out subEle);
				foreach (var entry in GlobalReferences)
				{
					XElement newEle = new XElement("Reference");
					entry.WriteXML(newEle);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ScriptData();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("CompiledScript", false, out subEle))
			{
				if (CompiledScript == null)
					CompiledScript = new SimpleSubrecord<Byte[]>();
					
				CompiledScript.ReadXML(subEle);
			}
			if (ele.TryPathTo("ScriptSource", false, out subEle))
			{
				if (ScriptSource == null)
					ScriptSource = new SimpleSubrecord<Char[]>();
					
				ScriptSource.ReadXML(subEle);
			}
			if (ele.TryPathTo("LocalVariables", false, out subEle))
			{
				if (LocalVariables == null)
					LocalVariables = new List<LocalVariable>();
					
				foreach (XElement e in subEle.Elements())
				{
					LocalVariable temp = new LocalVariable();
					temp.ReadXML(e);
					LocalVariables.Add(temp);
				}
			}
			if (ele.TryPathTo("LocalReferences", false, out subEle))
			{
				if (LocalReferences == null)
					LocalReferences = new List<SimpleSubrecord<UInt32>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<UInt32> temp = new SimpleSubrecord<UInt32>();
					temp.ReadXML(e);
					LocalReferences.Add(temp);
				}
			}
			if (ele.TryPathTo("GlobalReferences", false, out subEle))
			{
				if (GlobalReferences == null)
					GlobalReferences = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference temp = new RecordReference();
					temp.ReadXML(e);
					GlobalReferences.Add(temp);
				}
			}
		}

		public EmbeddedScript Clone()
		{
			return new EmbeddedScript(this);
		}

	}
}
