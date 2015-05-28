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

namespace ESPSharp.Subrecords
{
	public partial class Attributes : Subrecord
	{
		public Byte Strength { get; set; }
		public Byte Perception { get; set; }
		public Byte Endurance { get; set; }
		public Byte Charisma { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Agility { get; set; }
		public Byte Luck { get; set; }
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Strength = subReader.ReadByte();
					Perception = subReader.ReadByte();
					Endurance = subReader.ReadByte();
					Charisma = subReader.ReadByte();
					Intelligence = subReader.ReadByte();
					Agility = subReader.ReadByte();
					Luck = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Strength);
			writer.Write(Perception);
			writer.Write(Endurance);
			writer.Write(Charisma);
			writer.Write(Intelligence);
			writer.Write(Agility);
			writer.Write(Luck);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Strength", true, out subEle);
			subEle.Value = Strength.ToString();

			ele.TryPathTo("Perception", true, out subEle);
			subEle.Value = Perception.ToString();

			ele.TryPathTo("Endurance", true, out subEle);
			subEle.Value = Endurance.ToString();

			ele.TryPathTo("Charisma", true, out subEle);
			subEle.Value = Charisma.ToString();

			ele.TryPathTo("Intelligence", true, out subEle);
			subEle.Value = Intelligence.ToString();

			ele.TryPathTo("Agility", true, out subEle);
			subEle.Value = Agility.ToString();

			ele.TryPathTo("Luck", true, out subEle);
			subEle.Value = Luck.ToString();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Strength", false, out subEle);
			Strength = subEle.ToByte();

			ele.TryPathTo("Perception", false, out subEle);
			Perception = subEle.ToByte();

			ele.TryPathTo("Endurance", false, out subEle);
			Endurance = subEle.ToByte();

			ele.TryPathTo("Charisma", false, out subEle);
			Charisma = subEle.ToByte();

			ele.TryPathTo("Intelligence", false, out subEle);
			Intelligence = subEle.ToByte();

			ele.TryPathTo("Agility", false, out subEle);
			Agility = subEle.ToByte();

			ele.TryPathTo("Luck", false, out subEle);
			Luck = subEle.ToByte();
		}
	}
}
