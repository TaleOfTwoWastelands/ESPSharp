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
	public partial class CreatureSoundData : SubrecordCollection, ICloneable<CreatureSoundData>
	{
		public SimpleSubrecord<CreatureSoundType> SoundType { get; set; }
		public List<CreatureSound> Sounds { get; set; }

		public CreatureSoundData()
		{
			SoundType = new SimpleSubrecord<CreatureSoundType>();
			Sounds = new List<CreatureSound>();
		}

		public CreatureSoundData(SimpleSubrecord<CreatureSoundType> SoundType, List<CreatureSound> Sounds)
		{
			this.SoundType = SoundType;
			this.Sounds = Sounds;
		}

		public CreatureSoundData(CreatureSoundData copyObject)
		{
			SoundType = copyObject.SoundType.Clone();
			Sounds = new List<CreatureSound>();
			foreach (var item in copyObject.Sounds)
			{
				Sounds.Add(item.Clone());
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
					case "CSDT":
						if (readTags.Contains("CSDT"))
							return;
						SoundType.ReadBinary(reader);
						break;
					case "CSDI":
						CreatureSound tempCSDI = new CreatureSound();
						tempCSDI.ReadBinary(reader);
						Sounds.Add(tempCSDI);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (SoundType != null)
				SoundType.WriteBinary(writer);
			if (Sounds != null)
				foreach (var item in Sounds)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (SoundType != null)		
			{		
				ele.TryPathTo("SoundType", true, out subEle);
				SoundType.WriteXML(subEle, master);
			}
			if (Sounds != null)		
			{		
				ele.TryPathTo("Sounds", true, out subEle);
				foreach (var entry in Sounds)
				{
					XElement newEle = new XElement("Sound");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("SoundType", false, out subEle))
			{
				if (SoundType == null)
					SoundType = new SimpleSubrecord<CreatureSoundType>();
					
				SoundType.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sounds", false, out subEle))
			{
				if (Sounds == null)
					Sounds = new List<CreatureSound>();
					
				foreach (XElement e in subEle.Elements())
				{
					CreatureSound temp = new CreatureSound();
					temp.ReadXML(e, master);
					Sounds.Add(temp);
				}
			}
		}

		public CreatureSoundData Clone()
		{
			return new CreatureSoundData(this);
		}

	}
}
