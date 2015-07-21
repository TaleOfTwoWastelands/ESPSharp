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
	public partial class Destructable : SubrecordCollection	{
		public DestructableHeader Header { get; set; }
		public List<DestructionStage> DestructionStages { get; set; }

		public Destructable()
		{
			Header = new DestructableHeader();
		}

		public Destructable(DestructableHeader Header, List<DestructionStage> DestructionStages)
		{
			this.Header = Header;
			this.DestructionStages = DestructionStages;
		}

		public Destructable(Destructable copyObject)
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
					case "DEST":
						if (readTags.Contains("DEST"))
							return;
						Header.ReadBinary(reader);
						break;
					case "DSTD":
						if (DestructionStages == null)
							DestructionStages = new List<DestructionStage>();

						DestructionStage tempDSTD = new DestructionStage();
						tempDSTD.ReadBinary(reader);
						DestructionStages.Add(tempDSTD);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Header != null)
				Header.WriteBinary(writer);
			if (DestructionStages != null)
				foreach (var item in DestructionStages)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Header != null)		
			{		
				ele.TryPathTo("Header", true, out subEle);
				Header.WriteXML(subEle, master);
			}
			if (DestructionStages != null)		
			{		
				ele.TryPathTo("DestructionStages", true, out subEle);
				foreach (var entry in DestructionStages)
				{
					XElement newEle = new XElement("DestructionStage");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Header", false, out subEle))
			{
				if (Header == null)
					Header = new DestructableHeader();
					
				Header.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DestructionStages", false, out subEle))
			{
				if (DestructionStages == null)
					DestructionStages = new List<DestructionStage>();
					
				foreach (XElement e in subEle.Elements())
				{
					DestructionStage temp = new DestructionStage();
					temp.ReadXML(e, master);
					DestructionStages.Add(temp);
				}
			}
		}

		public Destructable Clone()
		{
			return new Destructable(this);
		}

	}
}
