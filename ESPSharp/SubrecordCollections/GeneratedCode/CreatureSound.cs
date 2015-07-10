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
	public partial class CreatureSound : SubrecordCollection, ICloneable<CreatureSound>
	{
		public RecordReference Sound { get; set; }
		public SimpleSubrecord<Byte> Chance { get; set; }

		public CreatureSound()
		{
			Sound = new RecordReference();
			Chance = new SimpleSubrecord<Byte>();
		}

		public CreatureSound(RecordReference Sound, SimpleSubrecord<Byte> Chance)
		{
			this.Sound = Sound;
			this.Chance = Chance;
		}

		public CreatureSound(CreatureSound copyObject)
		{
			Sound = copyObject.Sound.Clone();
			Chance = copyObject.Chance.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "CSDI":
						if (readTags.Contains("CSDI"))
							return;
						Sound.ReadBinary(reader);
						break;
					case "CSDC":
						if (readTags.Contains("CSDC"))
							return;
						Chance.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Sound != null)
				Sound.WriteBinary(writer);
			if (Chance != null)
				Chance.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Sound != null)		
			{		
				ele.TryPathTo("Sound", true, out subEle);
				Sound.WriteXML(subEle, master);
			}
			if (Chance != null)		
			{		
				ele.TryPathTo("Chance", true, out subEle);
				Chance.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Sound", false, out subEle))
			{
				if (Sound == null)
					Sound = new RecordReference();
					
				Sound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Chance", false, out subEle))
			{
				if (Chance == null)
					Chance = new SimpleSubrecord<Byte>();
					
				Chance.ReadXML(subEle, master);
			}
		}

		public CreatureSound Clone()
		{
			return new CreatureSound(this);
		}

	}
}
