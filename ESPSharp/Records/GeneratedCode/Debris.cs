
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
	public partial class Debris : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public List<DebrisModel> DebrisList { get; set; }

		public Debris()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			DebrisList = new List<DebrisModel>();
		}

		public Debris(SimpleSubrecord<String> EditorID, List<DebrisModel> DebrisList)
		{
			this.EditorID = EditorID;
			this.DebrisList = DebrisList;
		}

		public Debris(Debris copyObject)
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
					case "DATA":
						if (DebrisList == null)
							DebrisList = new List<DebrisModel>();

						DebrisModel tempDATA = new DebrisModel();
						tempDATA.ReadBinary(reader);
						DebrisList.Add(tempDATA);
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
			if (DebrisList != null)
				foreach (var item in DebrisList)
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
			if (DebrisList != null)		
			{		
				ele.TryPathTo("DebrisList", true, out subEle);
				List<string> xmlNames = new List<string>{"Debris"};
				int i = 0;
				foreach (var entry in DebrisList)
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
			if (ele.TryPathTo("DebrisList", false, out subEle))
			{
				if (DebrisList == null)
					DebrisList = new List<DebrisModel>();
					
				foreach (XElement e in subEle.Elements())
				{
					DebrisModel tempDATA = new DebrisModel();
					tempDATA.ReadXML(e, master);
					DebrisList.Add(tempDATA);
				}
			}
		}		

		public Debris Clone()
		{
			return new Debris(this);
		}

	}
}