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
	public partial class AddedQuest : SubrecordCollection, ICloneable<AddedQuest>
	{
		public RecordReference Quest { get; set; }
		public List<SharedInfo> SharedInfos { get; set; }

		public AddedQuest()
		{
		}

		public AddedQuest(RecordReference Quest, List<SharedInfo> SharedInfos)
		{
			this.Quest = Quest;
			this.SharedInfos = SharedInfos;
		}

		public AddedQuest(AddedQuest copyObject)
		{
			Quest = copyObject.Quest.Clone();
			SharedInfos = new List<SharedInfo>();
			foreach (var item in copyObject.SharedInfos)
			{
				SharedInfos.Add(item.Clone());
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
					case "QSTI":
						if (readTags.Contains("QSTI"))
							return;
						if (Quest == null)
							Quest = new RecordReference();

						Quest.ReadBinary(reader);
						break;
					case "INFC":
						if (SharedInfos == null)
							SharedInfos = new List<SharedInfo>();

						SharedInfo tempINFC = new SharedInfo();
						tempINFC.ReadBinary(reader);
						SharedInfos.Add(tempINFC);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Quest != null)
				Quest.WriteBinary(writer);
			if (SharedInfos != null)
				foreach (var item in SharedInfos)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Quest != null)		
			{		
				ele.TryPathTo("Quest", true, out subEle);
				Quest.WriteXML(subEle, master);
			}
			if (SharedInfos != null)		
			{		
				ele.TryPathTo("SharedInfos", true, out subEle);
				foreach (var entry in SharedInfos)
				{
					XElement newEle = new XElement("SharedInfo");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Quest", false, out subEle))
			{
				if (Quest == null)
					Quest = new RecordReference();
					
				Quest.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SharedInfos", false, out subEle))
			{
				if (SharedInfos == null)
					SharedInfos = new List<SharedInfo>();
					
				foreach (XElement e in subEle.Elements())
				{
					SharedInfo temp = new SharedInfo();
					temp.ReadXML(e, master);
					SharedInfos.Add(temp);
				}
			}
		}

		public AddedQuest Clone()
		{
			return new AddedQuest(this);
		}

	}
}
