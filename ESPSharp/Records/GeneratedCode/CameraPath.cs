
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
	public partial class CameraPath : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public List<Condition> Conditions { get; set; }
		public RelatedCameraPaths RelatedCameraPaths { get; set; }
		public SimpleSubrecord<CameraPathZoom> CameraZoom { get; set; }
		public List<RecordReference> CameraShots { get; set; }

		public CameraPath()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			CameraZoom = new SimpleSubrecord<CameraPathZoom>("DATA");
		}

		public CameraPath(SimpleSubrecord<String> EditorID, List<Condition> Conditions, RelatedCameraPaths RelatedCameraPaths, SimpleSubrecord<CameraPathZoom> CameraZoom, List<RecordReference> CameraShots)
		{
			this.EditorID = EditorID;
			this.CameraZoom = CameraZoom;
		}

		public CameraPath(CameraPath copyObject)
		{
					}
	
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
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
					case "ANAM":
						if (RelatedCameraPaths == null)
							RelatedCameraPaths = new RelatedCameraPaths();

						RelatedCameraPaths.ReadBinary(reader);
						break;
					case "DATA":
						if (CameraZoom == null)
							CameraZoom = new SimpleSubrecord<CameraPathZoom>();

						CameraZoom.ReadBinary(reader);
						break;
					case "SNAM":
						if (CameraShots == null)
							CameraShots = new List<RecordReference>();

						RecordReference tempSNAM = new RecordReference();
						tempSNAM.ReadBinary(reader);
						CameraShots.Add(tempSNAM);
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
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
			if (RelatedCameraPaths != null)
				RelatedCameraPaths.WriteBinary(writer);
			if (CameraZoom != null)
				CameraZoom.WriteBinary(writer);
			if (CameraShots != null)
				foreach (var item in CameraShots)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
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
			if (RelatedCameraPaths != null)		
			{		
				ele.TryPathTo("RelatedCameraPaths", true, out subEle);
				RelatedCameraPaths.WriteXML(subEle, master);
			}
			if (CameraZoom != null)		
			{		
				ele.TryPathTo("CameraZoom", true, out subEle);
				CameraZoom.WriteXML(subEle, master);
			}
			if (CameraShots != null)		
			{		
				ele.TryPathTo("CameraShots", true, out subEle);
				List<string> xmlNames = new List<string>{"CameraShot"};
				int i = 0;
				foreach (var entry in CameraShots)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("RelatedCameraPaths", false, out subEle))
			{
				if (RelatedCameraPaths == null)
					RelatedCameraPaths = new RelatedCameraPaths();
					
				RelatedCameraPaths.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CameraZoom", false, out subEle))
			{
				if (CameraZoom == null)
					CameraZoom = new SimpleSubrecord<CameraPathZoom>();
					
				CameraZoom.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CameraShots", false, out subEle))
			{
				if (CameraShots == null)
					CameraShots = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempSNAM = new RecordReference();
					tempSNAM.ReadXML(e, master);
					CameraShots.Add(tempSNAM);
				}
			}
		}		

		public CameraPath Clone()
		{
			return new CameraPath(this);
		}

	}
}