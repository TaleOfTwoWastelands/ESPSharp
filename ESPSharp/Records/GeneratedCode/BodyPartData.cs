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
	public partial class BodyPartData : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Model Model { get; set; }
		public List<NamedBodyPart> NamedBodyParts { get; set; }
		public List<BodyPart> BodyParts { get; set; }
		public RecordReference Ragdoll { get; set; }
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "BPTN":
						if (NamedBodyParts == null)
							NamedBodyParts = new List<NamedBodyPart>();

						NamedBodyPart tempBPTN = new NamedBodyPart();
						tempBPTN.ReadBinary(reader);
						NamedBodyParts.Add(tempBPTN);
						break;
					case "BPNN":
						if (BodyParts == null)
							BodyParts = new List<BodyPart>();

						BodyPart tempBPNN = new BodyPart();
						tempBPNN.ReadBinary(reader);
						BodyParts.Add(tempBPNN);
						break;
					case "RAGA":
						if (Ragdoll == null)
							Ragdoll = new RecordReference();

						Ragdoll.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (NamedBodyParts != null)
				foreach (var item in NamedBodyParts)
					item.WriteBinary(writer);
			if (BodyParts != null)
				foreach (var item in BodyParts)
					item.WriteBinary(writer);
			if (Ragdoll != null)
				Ragdoll.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (NamedBodyParts != null)		
			{		
				ele.TryPathTo("NamedBodyParts", true, out subEle);
				List<string> xmlNames = new List<string>{"NamedBodyPart"};
				int i = 0;
				foreach (var entry in NamedBodyParts)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (BodyParts != null)		
			{		
				ele.TryPathTo("BodyParts", true, out subEle);
				List<string> xmlNames = new List<string>{"BodyPart"};
				int i = 0;
				foreach (var entry in BodyParts)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Ragdoll != null)		
			{		
				ele.TryPathTo("Ragdoll", true, out subEle);
				Ragdoll.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NamedBodyParts", false, out subEle))
			{
				if (NamedBodyParts == null)
					NamedBodyParts = new List<NamedBodyPart>();
					
				foreach (XElement e in subEle.Elements())
				{
					NamedBodyPart tempBPTN = new NamedBodyPart();
					tempBPTN.ReadXML(e, master);
					NamedBodyParts.Add(tempBPTN);
				}
			}
			if (ele.TryPathTo("BodyParts", false, out subEle))
			{
				if (BodyParts == null)
					BodyParts = new List<BodyPart>();
					
				foreach (XElement e in subEle.Elements())
				{
					BodyPart tempBPNN = new BodyPart();
					tempBPNN.ReadXML(e, master);
					BodyParts.Add(tempBPNN);
				}
			}
			if (ele.TryPathTo("Ragdoll", false, out subEle))
			{
				if (Ragdoll == null)
					Ragdoll = new RecordReference();
					
				Ragdoll.ReadXML(subEle, master);
			}
		}

	}
}
